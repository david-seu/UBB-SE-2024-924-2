using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulldozerServer.Domain;
using Microsoft.EntityFrameworkCore;

namespace UBB_SE_2024_Popsicles.Services
{
    internal class GroupService : IGroupService
    {
        private DatabaseContext context;

        public GroupService(DatabaseContext context)
        {
            this.context = context;
        }

        private static string defaultGroupName = "New Group";
        private static string defaultGroupDescription = "This is a new group";
        private static string defaultGroupIcon = "default";
        private static string defaultGroupBanner = "default";
        private static int defaultMaximumNumberOfPostsPerHourPerUser = 5;
        private static bool defaultIsGroupPublic = false;
        private static bool defaultAllowanceOfPostage = false;
        private static string defaultGroupRole = "user";

        // private static bool defaultPostIsPinned = false;
        // private static string defaultPostDescription = "This is a new post";
        // Add the three repos: GroupRepository, GroupMemberRepository, and GroupMembershipRepository
        public void CreateGroup(Guid groupOwnerId)
        {
            Guid groupId = Guid.NewGuid();
            // Generate a random group code by slicing a random GUID into a 6-character string
            // This results in a 1 in 2^36 chance of a collision (it should be fine)
            string uniqueGroupCode = Guid.NewGuid().ToString().Substring(0, 6);
            Group newGroup = new Group(groupId, groupOwnerId, defaultGroupName, defaultGroupDescription, DateTime.Now, true, defaultAllowanceOfPostage);
            // Add the new group to the GroupRepository
            context.Groups.Add(newGroup);
            AddMemberToGroup(groupOwnerId, groupId, "admin");
            context.SaveChangesAsync();
        }

        public void UpdateGroup(Guid groupId, string newGroupName, string newGroupDescription, string newGroupIcon, string newGroupBanner,
            int maximumNumberOfPostsPerHourPerUser, bool isGroupPublic, bool allowanceOfPostageByDefault)
        {
            // Get the Group from the GroupRepository
            if (context.Groups.Find(groupId) == null)
            {
                throw new Exception("Group not found");
            }
            Group group = context.Groups.Find(groupId);

            Group newGroup = new Group(groupId, group.GroupOwnerId, newGroupName, newGroupDescription, newGroupIcon, newGroupBanner, maximumNumberOfPostsPerHourPerUser, isGroupPublic, allowanceOfPostageByDefault, group.GroupCode);

            // Update the group in the GroupRepository
            context.Groups.Update(newGroup);
        }

        public async void DeleteGroup(Guid groupId)
        {
            // Delete the group from the GroupRepository
            Group group = context.Groups.Find(groupId);
            if (group == null)
            {
                throw new Exception("Group not found");
            }
            context.Groups.Remove(group);

            await context.SaveChangesAsync();
        }

        public async void AddMemberToGroup(Guid groupMemberId, Guid groupId, string userRole = "user")
        {
            Guid groupMembershipId = Guid.NewGuid();
            DateOnly joinDate = DateOnly.FromDateTime(DateTime.Now);
            bool isBannedFromGroup = false;
            bool isTimedOutFromGroup = false;
            bool bypassPostageRestrictionPostSettings = true;
            if (userRole == "user")
            {
                bypassPostageRestrictionPostSettings = false;
            }
            Membership newMembership = new Membership(groupId, groupMemberId, joinDate, isBannedFromGroup, isTimedOutFromGroup, bypassPostageRestrictionPostSettings);
            context.Memberships.Add(newMembership);
            await context.SaveChangesAsync();
        }

        public async void RemoveMemberFromGroup(Guid groupMemberId, Guid groupId)
        {
            // Get the GroupMember from the GroupMemberRepository
            Membership foundMembership = context.Memberships.Find(groupId, groupMemberId);
            if (foundMembership == null)
            {
                throw new Exception("User doesn't belong to this group");
            }

            context.Memberships.Remove(foundMembership);
            await context.SaveChangesAsync();
        }

        public async void BanMemberFromGroup(Guid bannedGroupMemberId, Guid groupId)
        {
            // Get the Group from the GroupRepository
            Membership updateMembership = context.Memberships.Find(groupId, bannedGroupMemberId);
            if (updateMembership == null)
            {
                throw new Exception("User doesn't belong to this group");
            }
            updateMembership.IsBanned = true;
            context.Memberships.Update(updateMembership);
            await context.SaveChangesAsync();
        }

        public async void UnbanMemberFromGroup(Guid unbannedGroupMemberId, Guid groupId)
        {
            // Get the Group from the GroupRepository
            Membership updateMembership = context.Memberships.Find(groupId, unbannedGroupMemberId);
            if (updateMembership == null)
            {
                throw new Exception("User doesn't belong to this group");
            }
            updateMembership.IsBanned = false;
            context.Memberships.Update(updateMembership);
            await context.SaveChangesAsync();
        }

        public async void TimeoutMemberFromGroup(Guid groupMemberId, Guid groupId)
        {
            // Get the Group from the GroupRepository
            Membership updateMembership = context.Memberships.Find(groupId, groupMemberId);
            if (updateMembership == null)
            {
                throw new Exception("User doesn't belong to this group");
            }
            updateMembership.IsTO = true;
            context.Memberships.Update(updateMembership);
            await context.SaveChangesAsync();
        }

        public async void EndTimeoutOfMemberFromGroup(Guid groupMemberId, Guid groupId)
        {
            // Get the Group from the GroupRepository
            Membership updateMembership = context.Memberships.Find(groupId, groupMemberId);
            if (updateMembership == null)
            {
                throw new Exception("User doesn't belong to this group");
            }
            updateMembership.IsTO = false;
            context.Memberships.Update(updateMembership);
            await context.SaveChangesAsync();
        }

        public async void ChangeMemberRoleInTheGroup(Guid groupMemberId, Guid groupId, string newGroupRole)
        {
            // Get the Group from the GroupRepository
            var group = await context.Groups.FindAsync(groupId);
            if (group == null)
            {
                throw new Exception("Group not found");
            }

            //GroupMembership groupMembership = group.GetMembershipFromGroupMemberId(groupMemberId);
            GroupMembership groupMembership = context.
            groupMembership.GroupMemberRole = newGroupRole;

            // Update the GroupMembership in the GroupMembershipRepository
            context.Groups.Update(groupMembership);
            await context.SaveChangesAsync();
        }

        public void AllowMemberToBypassPostageRestriction(Guid groupMemberId, Guid groupId)
        {
            // Get the Group from the GroupRepository
            Group group = groupRepository.GetGroupById(groupId);

            GroupMembership groupMembership = group.GetMembershipFromGroupMemberId(groupMemberId);

            groupMembership.BypassPostageRestriction = true;

            // Update the GroupMembership in the GroupMembershipRepository
            groupMembershipRepository.UpdateGroupMembership(groupMembership);
        }

        public void DisallowMemberToBypassPostageRestriction(Guid groupMemberId, Guid groupId)
        {
            // Get the Group from the GroupRepository
            Group group = groupRepository.GetGroupById(groupId);

            GroupMembership groupMembership = group.GetMembershipFromGroupMemberId(groupMemberId);

            groupMembership.BypassPostageRestriction = false;

            // Update the GroupMembership in the GroupMembershipRepository
            groupMembershipRepository.UpdateGroupMembership(groupMembership);
        }

        public async void AddNewRequestToJoinGroup(Guid groupMemberId, Guid groupId)
        {
            Guid joinRequestId = Guid.NewGuid();
            var result = context.JoinRequests.Add(new JoinRequest(joinRequestId,groupMemberId, groupId));
            await context.SaveChangesAsync();
        }

        public void AcceptRequestToJoinGroup(Guid joinRequestId)
        {
            var request = context.JoinRequests.Find(joinRequestId);
            if (request == null)
            {
                throw new Exception("User didnt request to join this group");
            }
            Guid groupId = request.GroupId;
            Guid userId = request.UserId;
            context.Memberships.Add(new Membership(groupId, userId));
            context.JoinRequests.ExecuteDelete()
        }

        public void RejectRequestToJoinGroup(Guid joinRequestId)
        {
            // Get the JoinRequest from the RequestRepository
            JoinRequest joinRequest = joinRequestsRepository.GetJoinRequestById(joinRequestId);

            // Get the Group from the GroupRepository
            Group group = groupRepository.GetGroupById(joinRequest.GroupId);
            // Get the GroupMember from the GroupMemberRepository
            GroupMember groupMember = groupMemberRepository.GetGroupMemberById(joinRequest.GroupMemberId);

            group.RemoveJoinRequest(joinRequest.JoinRequestId);
            groupMember.RemoveActiveJoinRequest(joinRequest.JoinRequestId);

            // Delete the JoinRequest from the RequestRepository
            joinRequestsRepository.RemoveJoinRequestById(joinRequest.JoinRequestId);
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