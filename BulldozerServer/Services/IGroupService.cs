using BulldozerServer.Domain;
using BulldozerServer.Domain.MarketplacePosts;
using BulldozerServer.Payload.DTO;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace UBB_SE_2024_Popsicles.Services
{
    internal interface IGroupService
    {
        public Task<EntityEntry<Group>> CreateGroup(GroupDTO groupDTO);
        public ICollection<MarketplacePost> GetGroupPosts(Guid groupId);
        public List<User> GetGroupMembers(Guid groupId);
        public bool IsUserInGroup(Guid groupId, Guid groupMemberId);
        public List<JoinRequest> GetRequestsToJoinFromGroup(Guid groupId);
        public List<Group> GetAllGroupsUserBelongsTo(Guid groupMemberId);
        public Group GetGroup(Guid groupId);
        public List<Poll> GetGroupPolls(Guid groupId);
        public void CreateNewPoll(Guid groupId, Guid groupMemberId, string pollDescription);
        public void AddNewOptionToAPoll(Guid pollId, Guid groupId, string newPollOption);

    }
}