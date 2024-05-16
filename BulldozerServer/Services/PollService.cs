using BulldozerServer.Domain;
using BulldozerServer.Mapper;
using BulldozerServer.Payload.DTO;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BulldozerServer.Services
{
    public class PollService : IPollService
    {
        private DatabaseContext context;

        public PollService(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<EntityEntry<Poll>> AddNewPoll(PollDTO pollDTO)
        {
            Poll poll = PollMapper.MapPollDtoToPoll(pollDTO);
            if (context.Polls.Find(poll.PollId) != null)
            {
                throw new Exception("Poll already added!");
            }
            var result = context.Polls.Add(poll);
            await context.SaveChangesAsync();
            return result;
        }

        public List<Poll> GetGroupPolls(Guid groupId)
        {
            return context.Polls.Where(poll => poll.GroupId == groupId).ToList();
        }
    }
}
