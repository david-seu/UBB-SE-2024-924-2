using BulldozerServer.Domain;
using BulldozerServer.Payload.DTO;

namespace BulldozerServer.Services
{
    public interface IPollService
    {
        public List<Poll> GetGroupPolls(Guid groupId);
        public Poll AddNewPoll(PollDTO pollDTO);
        public Poll GetPollById(Guid idPoll);
    }
}
