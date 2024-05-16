using BulldozerServer.Domain;
using BulldozerServer.Payload.DTO;

namespace BulldozerServer.Mapper
{
    public class PollMapper
    {
        public static PollDTO MapPollToPollDTO(Poll poll)
        {
            PollDTO userDto = new PollDTO();
            userDto.PollId = poll.PollId;
            userDto.GroupId = poll.GroupId;
            userDto.Description = poll.Description;
            userDto.CreationDate = poll.CreationDate;
            userDto.EndDate = poll.EndDate;
            userDto.IsPinned = poll.IsPinned;
            userDto.IsVisible = poll.IsVisible;
            userDto.IsMultipleChoice = poll.IsMultipleChoice;
            userDto.IsAnonymous = poll.IsAnonymous;
            return userDto;
        }

        public static Poll MapPollDtoToPoll(PollDTO pollDto)
        {
            return new Poll(pollDto.PollId, pollDto.GroupId, pollDto.Description, pollDto.CreationDate, pollDto.EndDate, pollDto.IsPinned, pollDto.IsVisible, pollDto.IsMultipleChoice, pollDto.IsAnonymous);
        }
    }
}
