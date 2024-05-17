using BulldozerServer.Domain;
using BulldozerServer.Payload.DTO;

namespace BulldozerServer.Mapper
{
    public class GroupPostMapper
    {
        public static GroupPostDTO GroupPostToGroupPostDTO(GroupPost groupPost)
        {
            GroupPostDTO groupPostDTO = new GroupPostDTO();
            groupPostDTO.GroupPostId = groupPost.GroupPostId;
            groupPostDTO.AuthorId = groupPost.AuthorId;
            groupPostDTO.CreationDate = DateTime.Now;
            groupPostDTO.GroupId = groupPost.GroupId;
            groupPostDTO.IsPinned = groupPost.IsPinned;
            groupPostDTO.AdminOnly = groupPost.AdminOnly;
            groupPostDTO.PostImage = groupPost.MediaContent;
            groupPostDTO.PostContent = groupPost.Description;
            return groupPostDTO;
        }

        public static GroupPost GroupPostDTOToGroupPost(GroupPostDTO groupPostDTO)
        {
            return new GroupPost(groupPostDTO.GroupPostId, groupPostDTO.AuthorId, groupPostDTO.GroupId, groupPostDTO.PostContent, groupPostDTO.PostImage, groupPostDTO.CreationDate, groupPostDTO.IsPinned, groupPostDTO.AdminOnly);
        }
    }
}
