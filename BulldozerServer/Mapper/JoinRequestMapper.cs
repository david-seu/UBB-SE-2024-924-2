using BulldozerServer.Domain;
using BulldozerServer.Payload.DTO;

namespace BulldozerServer.Mapper
{
    public class JoinRequestMapper
    {
        public static JoinRequestDTO JoinRequestToJoinRequestDTO(JoinRequest joinRequest)
        {
            JoinRequestDTO joinRequestDTO = new JoinRequestDTO();
            joinRequestDTO.GroupId = joinRequest.GroupId;
            joinRequestDTO.UserId = joinRequest.UserId;
            joinRequestDTO.JoinRequestId = joinRequest.JoinRequestId;
            return joinRequestDTO;
        }

        public static JoinRequest JoinRequestDTOToJoinRequest(JoinRequestDTO joinRequestDTO)
        {
            return new JoinRequest(joinRequestDTO.JoinRequestId, joinRequestDTO.UserId, joinRequestDTO.JoinRequestId);
        }
    }
}
