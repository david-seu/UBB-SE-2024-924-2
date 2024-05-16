using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulldozerServer.Domain;
using BulldozerServer.Mapper;
using BulldozerServer.Payload.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace UBB_SE_2024_Popsicles.Services
{
    internal class GroupService : IGroupService
    {
        private DatabaseContext context;

        public GroupService(DatabaseContext context)
        {
            this.context = context;
        }

        /*private static string defaultGroupName = "New Group";
        private static string defaultGroupDescription = "This is a new group";
        private static string defaultGroupIcon = "default";
        private static string defaultGroupBanner = "default";
        private static int defaultMaximumNumberOfPostsPerHourPerUser = 5;
        private static bool defaultIsGroupPublic = false;
        private static bool defaultAllowanceOfPostage = false;
        private static string defaultGroupRole = "user";*/

        public async EntityEntry<Group> CreateGroup(GroupDTO groupDTO)
        {
            if (context.Groups.Find(groupDTO.GroupId) != null)
            {
                throw new Exception("Group with this id already exists");
            }
            Group group = GroupMapper.GroupDTOToGroup(groupDTO);
            var addResult = context.Groups.Add(group);
            AddMemberToGroup(group.UserId, group.GroupId, "admin");

            await context.SaveChangesAsync();
            return addResult;
        }

        public async void UpdateGroup(GroupDTO groupDTO)
        {
            if (context.Groups.Find(groupDTO.GroupId) == null)
            {
                throw new Exception("Group not found");
            }
            Group group = GroupMapper.GroupDTOToGroup(groupDTO);
            var updateResult = context.Groups.Update(group);

            await context.SaveChangesAsync();
            return updateResult;
        }

        public async void DeleteGroup(Guid groupId)
        {
            Group group = context.Groups.Find(groupId);
            if (group == null)
            {
                throw new Exception("Group not found");
            }
            context.Groups.Remove(group);

            await context.SaveChangesAsync();
        }

        public async void AddMemberToGroup(MembershipDTO membershipDTO)
        {
            Guid userId = membershipDTO.UserId;
            Guid groupId = membershipDTO.GroupId;

            if (context.Memberships.Find(groupId, userId) != null)
            {
                throw new Exception("User is already in group");
            }

            Membership membership = MembershipMapper.MembershipDTOToMembership(membershipDTO);
            var addResult = context.Memberships.Add(membership);
            await context.SaveChangesAsync();
            return addResult;
        }

        public async void RemoveMemberFromGroup(Guid groupId, Guid userId)
        {
            var membership = context.Memberships.Find(groupId, userId);
            if (membership == null)
            {
                throw new Exception("User doesn't belong to this group");
            }
            context.Memberships.Remove(membership);
            await context.SaveChangesAsync();
        }

        public async  UpdateMembership(MembershipDTO membershipDTO)
        {
            Guid userId = membershipDTO.UserId;
            Guid groupId = membershipDTO.GroupId;

            if (context.Memberships.Find(groupId, userId) == null)
            {
                throw new Exception("User doesn't belong to this group");
            }

            Membership membership = MembershipMapper.MembershipDTOToMembership(membershipDTO);
            var updateResult = context.Memberships.Update(membership);
            await context.SaveChangesAsync();
            return updateResult;
        }

        public async void AddNewRequestToJoinGroup(JoinRequestDTO joinRequestDTO)
        {
            JoinRequest joinRequest = JoinRequestMapper.JoinRequestDTOToJoinRequest(joinRequestDTO);
            var addResult = context.JoinRequests.Add(joinRequest);
            await context.SaveChangesAsync();
            return addResult;
        }

        public async void AcceptRequestToJoinGroup(JoinRequestDTO joinRequestDTO)
        {
            if (context.JoinRequests.Find(joinRequestDTO.JoinRequestId) == null)
            {
                throw new Exception("User didnt request to join this group");
            }
            JoinRequest joinRequest = 
            context.Memberships.Add(new Membership(groupId, userId));
            context.JoinRequests.Remove(request);
            await context.SaveChangesAsync();
        }

        public void RejectRequestToJoinGroup(Guid joinRequestId)
        {
            
        }

        public void CreateNewPostOnGroupChat(Guid groupId, Guid groupMemberId, string postContent, string postImage)
        {
            Guid postId = Guid.NewGuid();
            DateTime postDate = DateTime.Now;
            // Get the Group from the GroupRepository
            Group group = groupRepository.GetGroupById(groupId);

            GroupMembership groupMembership = group.GetMembershipFromGroupMemberId(groupMemberId);

            if (groupMembership.BypassPostageRestriction || group.AllowanceOfPostage)
            {
                GroupPost newPost = new GroupPost(postId, groupMemberId, postContent, postImage, groupId);
                group.ListOfGroupPosts.Add(newPost);
            }
            else
            {
                int postCount = 0;
                foreach (GroupPost post in group.ListOfGroupPosts)
                {
                    if (post.PostOwnerId == groupMemberId && post.PostageDateTime.Date == postDate.Date)
                    {
                        postCount++;
                    }
                }

                if (postCount < group.MaximumNumberOfPostsPerHourPerUser)
                {
                    GroupPost newPost = new GroupPost(postId, groupMemberId, postContent, postImage, groupId);

                    group.ListOfGroupPosts.Add(newPost);
                }
                else
                {
                    throw new Exception("Post limit exceeded");
                }
            }
        }

        public List<GroupPost> GetGroupPosts(Guid groupId)
        {
            // Get the Group from the GroupRepository
            Group group = groupRepository.GetGroupById(groupId);

            return group.ListOfGroupPosts;
        }

        public List<GroupMember> GetGroupMembers(Guid groupId)
        {
            // Get the Group from the GroupRepository
            Group group = groupRepository.GetGroupById(groupId);

            // Get the Members from the Group
            List<GroupMember> listOfGroupMembers = new List<GroupMember>();
            foreach (GroupMembership groupMembership in group.ListOfGroupMemberships)
            {
                GroupMember groupMember = groupMemberRepository.GetGroupMemberById(groupMembership.GroupMemberId);
                listOfGroupMembers.Add(groupMember);
            }

            return listOfGroupMembers;
        }

        public GroupMember GetMemberFromGroup(Guid groupId, Guid groupMemberId)
        {
            Group group = groupRepository.GetGroupById(groupId);
            foreach (GroupMembership membership in group.ListOfGroupMemberships)
            {
                if (membership.GroupMemberId == groupMemberId)
                {
                    return groupMemberRepository.GetGroupMemberById(groupMemberId);
                }
            }
            throw new Exception("Group member not found");
        }

        public List<JoinRequest> GetRequestsToJoin(Guid groupId)
        {
            // Get the Group from the GroupRepository
            Group group = groupRepository.GetGroupById(groupId);

            return group.ListOfJoinRequests;
        }

        public List<Group> GetAllGroups(Guid groupMemberId)
        {
            // Get the GroupMember from the GroupMemberRepository
            GroupMember groupMember = groupMemberRepository.GetGroupMemberById(groupMemberId);

            // Get the Groups from the GroupMember
            List<Group> groups = new List<Group>();
            foreach (GroupMembership membership in groupMember.GroupMemberships)
            {
                Group group = groupRepository.GetGroupById(membership.GroupId);
                groups.Add(group);
            }

            return groups;
        }

        public Group GetGroup(Guid groupId)
        {
            return groupRepository.GetGroupById(groupId);
        }

        public List<GroupPoll> GetGroupPolls(Guid groupId)
        {
            // Get the Group from the GroupRepository
            Group group = groupRepository.GetGroupById(groupId);

            return group.ListOfGroupPolls;
        }

        public GroupPoll GetSpecificGroupPoll(Guid groupId, Guid pollId)
        {
            // Get the Group from the GroupRepository
            Group group = groupRepository.GetGroupById(groupId);

            return group.GetGroupPoll(pollId);
        }

        public void CreateNewPoll(Guid groupId, Guid groupMemberId, string pollDescription)
        {
            Guid pollId = Guid.NewGuid();
            GroupPoll newGroupPoll = new GroupPoll(pollId, groupMemberId, pollDescription, groupId);

            // Get the Group from the GroupRepository
            Group group = groupRepository.GetGroupById(groupId);

            group.ListOfGroupPolls.Add(newGroupPoll);
        }

        public void AddNewOptionToAPoll(Guid pollId, Guid groupId, string newPollOption)
        {
            Group group = groupRepository.GetGroupById(groupId);
            GroupPoll groupPoll = group.GetGroupPoll(pollId);
            if (groupPoll != null)
            {
                   groupPoll.AddGroupPollOption(newPollOption);
            }
            else
            {
                throw new Exception("GroupPoll not found");
            }
        }
    }
}