﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulldozerServer.Domain;
using BulldozerServer.Domain.MarketplacePosts;
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

        public async Task<EntityEntry<Group>> CreateGroup(GroupDTO groupDTO)
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

        public async Task<EntityEntry<Group>> UpdateGroup(GroupDTO groupDTO)
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

        public async Task<EntityEntry<Membership>> AddMemberToGroup(MembershipDTO membershipDTO)
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

        public async Task<EntityEntry<Membership>> UpdateMembership(MembershipDTO membershipDTO)
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

        public async Task<EntityEntry<JoinRequest>> AddNewRequestToJoinGroup(JoinRequestDTO joinRequestDTO)
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
                throw new Exception("User didn't request to join this group");
            }
            JoinRequest joinRequest = JoinRequestMapper.JoinRequestDTOToJoinRequest(joinRequestDTO);
            context.Memberships.Add(new Membership(joinRequest.GroupId, joinRequest.UserId));
            context.JoinRequests.Remove(joinRequest);
            await context.SaveChangesAsync();
        }

        public async void RejectRequestToJoinGroup(Guid joinRequestId)
        {
            var request = context.JoinRequests.Find(joinRequestId);
            if (request == null)
            {
                throw new Exception("User didn't request to join this group");
            }
            context.JoinRequests.Remove(request);
            await context.SaveChangesAsync();
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

        public ICollection<MarketplacePost> GetGroupPosts(Guid groupId)
        {
            // Get the Group from the GroupRepository
            Group group = context.Groups.Find(groupId);
            return group.MarketplacePosts;
        }

        public List<User> GetGroupMembers(Guid groupId)
        {
            // Get the Group from the GroupRepository
            var members = context.Users.Join(
             context.Memberships,
             user => user.UserId,
             membership => membership.UserId,
             (user, membership) => new { User = user, Membership = membership })
         .Where(joined => joined.Membership.GroupId == groupId)
         .Select(joined => joined.User)
         .ToList();

            return members;
        }

        public bool IsUserInGroup(Guid groupId, Guid groupMemberId)
        {
            var membership = context.Memberships.Find(groupId, groupMemberId);
            if (membership == null)
            {
                return false;
            }
            return true;
        }

        public List<JoinRequest> GetRequestsToJoinFromGroup(Guid groupId)
        {
            // Get the Group from the GroupRepository
            var allRequestsFromGroup = context.JoinRequests.Where(request => request.GroupId == groupId).ToList();
            return allRequestsFromGroup;
        }

        public List<Group> GetAllGroupsUserBelongsTo(Guid groupMemberId)
        {
            // Get the GroupMember from the GroupMemberRepository
            var groups = context.Groups.Join(
             context.Memberships,
             group => group.GroupId,
             membership => membership.GroupId,
             (group, membership) => new { Group = group, Membership = membership })
         .Where(joined => joined.Membership.UserId == groupMemberId)
         .Select(joined => joined.Group)
         .ToList();

            return groups;
        }

        public Group GetGroup(Guid groupId)
        {
            var group = context.Groups.Find(groupId);
            if (group == null)
            {
                throw new Exception("Can't find group");
            }
            return group;
        }
        public List<Poll> GetGroupPolls(Guid groupId)
        {
            // Get the Group from the GroupRepository
            var polls = context.Polls.Where(poll => poll.GroupId == groupId).ToList();

            return polls;
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