using BulldozerServer.Domain;
using BulldozerServer.Payload.DTO;

namespace BulldozerServer.Mapper
{
    public class GroupMapper
    {
        public static GroupDTO GroupToGroupDTO(Group group)
        {
            GroupDTO groupDTO = new GroupDTO();
            groupDTO.GroupId = group.GroupId;
            groupDTO.UserId = group.UserId;
            groupDTO.CreatedDate = group.CreatedDate;
            groupDTO.Description = group.Description;
            groupDTO.GroupName = group.GroupName;
            groupDTO.AllowanceOfPostage = group.AllowanceOfPostage;
            groupDTO.MarketplacePosts = group.MarketplacePosts;
            return groupDTO;
        }

        public static Group GroupDTOToJoinRequest(GroupDTO groupDTO)
        {
            return new Group(groupDTO.GroupId, groupDTO.UserId, groupDTO.GroupName, groupDTO.Description, groupDTO.CreatedDate, groupDTO.IsPublic, groupDTO.AllowanceOfPostage);
        }
    }
}
