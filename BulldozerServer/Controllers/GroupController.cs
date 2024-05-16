using BulldozerServer.Domain;
using Microsoft.AspNetCore.Mvc;
using UBB_SE_2024_Popsicles.Services;
using BulldozerServer.Payload.DTO;
using BulldozerServer.Domain.MarketplacePosts;

namespace BulldozerServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService groupService;

        public GroupController(IGroupService groupService)
        {
            this.groupService = groupService;
        }

        [HttpPost]
        public async Task<ActionResult<Group>> CreateGroup([FromBody] GroupDTO groupDTO)
        {
            try
            {
                var createdGroup = await groupService.CreateGroup(groupDTO);
                return CreatedAtAction(nameof(GetGroup), new { id = createdGroup.Entity.GroupId }, createdGroup.Entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Group>> UpdateGroup([FromBody] GroupDTO groupDTO)
        {
            try
            {
                var updatedGroup = await groupService.
                return Ok(updatedGroup.Entity);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{groupId}")]
        public async Task<IActionResult> DeleteGroup(Guid groupId)
        {
            try
            {
                await groupService.DeleteGroup(groupId);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("members")]
        public async Task<ActionResult<Membership>> AddMemberToGroup([FromBody] MembershipDTO membershipDTO)
        {
            try
            {
                var addedMember = await groupService.AddMemberToGroup(membershipDTO);
                return CreatedAtAction(nameof(IsUserInGroup), new { groupId = addedMember.Entity.GroupId, userId = addedMember.Entity.UserId }, addedMember.Entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("members/{groupId}/{userId}")]
        public async Task<IActionResult> RemoveMemberFromGroup(Guid groupId, Guid userId)
        {
            try
            {
                await groupService.RemoveMemberFromGroup(groupId, userId);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPut("members")]
        public async Task<ActionResult<Membership>> UpdateMembership([FromBody] MembershipDTO membershipDTO)
        {
            try
            {
                var updatedMembership = await groupService.UpdateMembership(membershipDTO);
                return Ok(updatedMembership.Entity);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("join-requests")]
        public async Task<ActionResult<JoinRequest>> AddNewRequestToJoinGroup([FromBody] JoinRequestDTO joinRequestDTO)
        {
            try
            {
                var joinRequest = await groupService.AddNewRequestToJoinGroup(joinRequestDTO);
                return CreatedAtAction(nameof(GetRequestsToJoinFromGroup), new { groupId = joinRequest.Entity.GroupId }, joinRequest.Entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("join-requests/accept")]
        public async Task<IActionResult> AcceptRequestToJoinGroup([FromBody] JoinRequestDTO joinRequestDTO)
        {
            try
            {
                await groupService.AcceptRequestToJoinGroup(joinRequestDTO);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("join-requests/{joinRequestId}")]
        public async Task<IActionResult> RejectRequestToJoinGroup(Guid joinRequestId)
        {
            try
            {
                await groupService.RejectRequestToJoinGroup(joinRequestId);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("{groupId}/posts")]
        public IActionResult CreateNewPostOnGroupChat(Guid groupId, [FromBody] GroupPostDTO groupPostDTO)
        {
            try
            {
                groupService.CreateNewPostOnGroupChat(groupId, groupPostDTO.GroupMemberId, groupPostDTO.PostContent, groupPostDTO.PostImage);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{groupId}/posts")]
        public ActionResult<ICollection<MarketplacePost>> GetGroupPosts(Guid groupId)
        {
            try
            {
                var posts = groupService.GetGroupPosts(groupId);
                return Ok(posts);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("{groupId}/members")]
        public ActionResult<List<User>> GetGroupMembers(Guid groupId)
        {
            try
            {
                var members = groupService.GetGroupMembers(groupId);
                return Ok(members);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("{groupId}/members/{groupMemberId}")]
        public ActionResult<bool> IsUserInGroup(Guid groupId, Guid groupMemberId)
        {
            var isInGroup = groupService.IsUserInGroup(groupId, groupMemberId);
            return Ok(isInGroup);
        }

        [HttpGet("{groupId}/join-requests")]
        public ActionResult<List<JoinRequest>> GetRequestsToJoinFromGroup(Guid groupId)
        {
            try
            {
                var requests = groupService.GetRequestsToJoinFromGroup(groupId);
                return Ok(requests);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("user/{groupMemberId}/groups")]
        public ActionResult<List<Group>> GetAllGroupsUserBelongsTo(Guid groupMemberId)
        {
            try
            {
                var groups = groupService.GetAllGroupsUserBelongsTo(groupMemberId);
                return Ok(groups);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("{groupId}")]
        public async Task<ActionResult<Group>> GetGroup(Guid groupId)
        {
            try
            {
                var group = await groupService.GetGroup(groupId);
                return Ok(group);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
