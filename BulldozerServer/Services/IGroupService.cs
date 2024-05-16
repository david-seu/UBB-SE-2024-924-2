using BulldozerServer.Domain;
using BulldozerServer.Domain.MarketplacePosts;
using BulldozerServer.Payload.DTO;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace UBB_SE_2024_Popsicles.Services
{
    public interface IGroupService
    {
        Task<EntityEntry<Group>> CreateGroup(GroupDTO groupDTO);
        Task<EntityEntry<Group>> UpdateGroup(GroupDTO groupDTO);
        Task DeleteGroup(Guid groupId);

        Task<EntityEntry<Membership>> AddMemberToGroup(MembershipDTO membershipDTO);
        Task RemoveMemberFromGroup(Guid groupId, Guid userId);
        Task<EntityEntry<Membership>> UpdateMembership(MembershipDTO membershipDTO);

        Task<EntityEntry<JoinRequest>> AddNewRequestToJoinGroup(JoinRequestDTO joinRequestDTO);
        Task AcceptRequestToJoinGroup(JoinRequestDTO joinRequestDTO);
        Task RejectRequestToJoinGroup(Guid joinRequestId);

        void CreateNewPostOnGroupChat(Guid groupId, Guid groupMemberId, string postContent, string postImage);
        ICollection<MarketplacePost> GetGroupPosts(Guid groupId);

        List<User> GetGroupMembers(Guid groupId);
        bool IsUserInGroup(Guid groupId, Guid groupMemberId);

        List<JoinRequest> GetRequestsToJoinFromGroup(Guid groupId);
        List<Group> GetAllGroupsUserBelongsTo(Guid groupMemberId);
        Task<Group> GetGroup(Guid groupId);
    }
}