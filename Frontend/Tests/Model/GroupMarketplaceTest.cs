using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISSLab.Model.Entities;

namespace Tests.Model
{
    internal class GroupMarketplaceTest
    {
        private GroupMarketplace groupMarketplaceEmpty;
        private GroupMarketplace groupMarketplaceWithId;
        private GroupMarketplace groupMarketplaceWithoutId;

        private Guid groupId;
        private string name;
        private int memberCount;
        private List<Guid> members;
        private List<Guid> posts;
        private List<Guid> topSellers;
        private List<Guid> admins;
        private List<Guid>? sellingUsers;
        private List<Guid> usersRequestingToSell;

        private string description;
        private string type;
        private string bannerPath;
        private DateTime creationDate;

        [SetUp]
        public void SetUp()
        {
            groupId = Guid.NewGuid();
            name = "name";
            memberCount = 10;
            members = new List<Guid>();
            posts = new List<Guid>();
            topSellers = new List<Guid>();
            admins = new List<Guid>();
            usersRequestingToSell = new List<Guid>();
            description = "description";
            type = "type";
            bannerPath = "path";
            creationDate = DateTime.Now;

            groupMarketplaceEmpty = new GroupMarketplace();
            groupMarketplaceWithoutId = new GroupMarketplace(name, description, type, bannerPath);
            groupMarketplaceWithId = new GroupMarketplace(groupId, name, memberCount, members, posts, admins, sellingUsers, description, type, bannerPath, creationDate, topSellers, usersRequestingToSell);
        }

        [Test]
        public void GroupId_GetGroupIdFromGroupEmpty_ShouldNotBeEmpty()
        {
            Assert.That(groupMarketplaceEmpty.GroupId, Is.Not.EqualTo(Guid.Empty));
        }
        [Test]
        public void GroupId_GetGroupIdFromGroupWithoutId_ShouldNotBeEmpty()
        {
            Assert.That(groupMarketplaceWithoutId.GroupId, Is.Not.EqualTo(Guid.Empty));
        }
        [Test]
        public void GroupId_GetGroupIdFromGroupWithId_ShouldBeEqualToGroupId()
        {
            Assert.That(groupMarketplaceWithId.GroupId, Is.EqualTo(groupId));
        }

        [Test]
        public void Name_GetNameFromGroupEmpty_ShouldBeEmpty()
        {
            Assert.That(groupMarketplaceEmpty.Name, Is.Empty);
        }
        [Test]
        public void Name_GetNameFromGroupWithoutId_ShouldBeEqualToName()
        {
            Assert.That(groupMarketplaceWithoutId.Name, Is.EqualTo(name));
        }
        [Test]
        public void Name_GetNameFromGroupWithId_ShouldBeEqualToName()
        {
            Assert.That(groupMarketplaceWithId.Name, Is.EqualTo(name));
        }

        [Test]
        public void Name_SetNameForGroupEmpty_ShouldBeNewGroupName()
        {
            string newGroupName = "new";
            groupMarketplaceEmpty.Name = newGroupName;
            Assert.That(groupMarketplaceEmpty.Name, Is.EqualTo(newGroupName));
        }
        [Test]
        public void Name_SetNameForGroupWithoutId_ShouldBeNewGroupName()
        {
            string newGroupName = "new";
            groupMarketplaceWithoutId.Name = newGroupName;
            Assert.That(groupMarketplaceWithoutId.Name, Is.EqualTo(newGroupName));
        }
        [Test]
        public void Name_SetNameForGroupWithId_ShouldBeNewGroupName()
        {
            string newGroupName = "new";
            groupMarketplaceWithId.Name = newGroupName;
            Assert.That(groupMarketplaceWithId.Name, Is.EqualTo(newGroupName));
        }

        [Test]
        public void MemberCount_GetFromGroupEmpty_ShouldBeZero()
        {
            Assert.That(groupMarketplaceEmpty.MemberCount, Is.Zero);
        }
        [Test]
        public void MemberCount_GetFromGroupWithoutIde_ShouldBeZero()
        {
            Assert.That(groupMarketplaceWithoutId.MemberCount, Is.Zero);
        }
        [Test]
        public void MemberCount_GetFromGroupWithId_ShouldBeEqualToMemberCount()
        {
            Assert.That(memberCount, Is.EqualTo(groupMarketplaceWithId.MemberCount));
        }

        [Test]
        public void Members_GetFromGroupEmpty_ShouldBeEmpty()
        {
            Assert.That(groupMarketplaceEmpty.Members, Is.Empty);
        }
        [Test]
        public void Members_GetFromGroupWithoutId_ShouldBeEmpty()
        {
            Assert.That(groupMarketplaceWithoutId.Members, Is.Empty);
        }
        [Test]
        public void Members_GetFromGroupWithId_ShouldBeEqualToMembers()
        {
            Assert.That(groupMarketplaceEmpty.Members, Is.EqualTo(members));
        }

        [Test]
        public void Posts_GetFromGroupEmpty_ShouldBeEmpty()
        {
            Assert.That(groupMarketplaceEmpty.Posts, Is.Empty);
        }
        [Test]
        public void Posts_GetFromGroupWithoutId_ShouldBeEmpty()
        {
            Assert.That(groupMarketplaceWithoutId.Posts, Is.Empty);
        }
        [Test]
        public void Posts_GetFromGroupWithId_ShouldBeEqualToPosts()
        {
            Assert.That(groupMarketplaceWithId.Posts, Is.EqualTo(posts));
        }

        [Test]
        public void Admins_GetFromGroupEmpty_ShouldBeEmpty()
        {
            Assert.That(groupMarketplaceEmpty.Admins, Is.Empty);
        }
        [Test]
        public void Admins_GetFromGroupWithoutId_ShouldBeEmpty()
        {
            Assert.That(groupMarketplaceWithoutId.Admins, Is.Empty);
        }
        [Test]
        public void Admins_GetFromGroupWithId_ShouldBeEqualToAdmins()
        {
            Assert.That(groupMarketplaceWithId.Admins, Is.EqualTo(admins));
        }

        [Test]
        public void SellingUsers_GetFromGroupEmpty_ShouldBeEmpty()
        {
            Assert.That(groupMarketplaceEmpty.SellingUsers, Is.Empty);
        }
        [Test]
        public void SellingUsers_GetFromGroupWithoutId_ShouldBeEmpty()
        {
            Assert.That(groupMarketplaceWithoutId.SellingUsers, Is.Empty);
        }
        [Test]
        public void SellingUsers_GetFromGroupWithId_ShouldBeEqualToSellingUsers()
        {
            Assert.That(groupMarketplaceWithId.SellingUsers, Is.EqualTo(sellingUsers));
        }

        [Test]
        public void UsersRequestingToSell_GetFromGroupEmpty_ShouldBeEmpty()
        {
            Assert.That(groupMarketplaceEmpty.UsersRequestingToSell, Is.Empty);
        }
        [Test]
        public void UsersRequestingToSell_GetFromGroupWithoutId_ShouldBeEmpty()
        {
            Assert.That(groupMarketplaceWithoutId.UsersRequestingToSell, Is.Empty);
        }
        [Test]
        public void UsersRequestingToSell_GetFromGroupWithId_ShouldBeEqualToUsersRequestingToSell()
        {
            Assert.That(groupMarketplaceWithId.UsersRequestingToSell, Is.EqualTo(usersRequestingToSell));
        }

        [Test]
        public void Description_GetFromGroupEmpty_ShouldBeEmpty()
        {
            Assert.IsEmpty(groupMarketplaceEmpty.Description);
        }
        [Test]
        public void Description_GetFromGroupWithoutId_ShouldBeEqualToDescription()
        {
            Assert.That(groupMarketplaceWithoutId.Description, Is.EqualTo(description));
        }
        [Test]
        public void Description_GetFromGroupWithId_ShouldBeEqualToDescription()
        {
            Assert.That(groupMarketplaceWithId.Description, Is.EqualTo(description));
        }

        [Test]
        public void Description_SetForGroupEmpty_ShouldBeNewGroupDescription()
        {
            string newGroupDescription = "new";
            groupMarketplaceEmpty.Description = newGroupDescription;
            Assert.That(groupMarketplaceEmpty.Description, Is.EqualTo(newGroupDescription));
        }
        [Test]
        public void Description_SetForGroupWithoutId_ShouldBeNewGroupDescription()
        {
            string newGroupDescription = "new";
            groupMarketplaceWithoutId.Description = newGroupDescription;
            Assert.That(groupMarketplaceWithoutId.Description, Is.EqualTo(newGroupDescription));
        }
        [Test]
        public void Description_SetForGroupWithId_ShouldBeNewGroupDescription()
        {
            string newGroupDescription = "new";
            groupMarketplaceWithId.Description = newGroupDescription;
            Assert.That(groupMarketplaceWithId.Description, Is.EqualTo(newGroupDescription));
        }

        [Test]
        public void Type_GetFromGroupEmpty_ShouldBeEmpty()
        {
            Assert.IsEmpty(groupMarketplaceEmpty.Type);
        }
        [Test]
        public void Type_GetFromGroupWithoutId_ShouldBeEqualToType()
        {
            Assert.That(groupMarketplaceWithoutId.Type, Is.EqualTo(type));
        }
        [Test]
        public void Type_GetFromGroupWithId_ShouldBeEqualToType()
        {
            Assert.That(groupMarketplaceWithId.Type, Is.EqualTo(type));
        }

        [Test]
        public void Type_SetForGroupEmpty_ShouldBeNewGroupType()
        {
            string newGroupType = "new";
            groupMarketplaceEmpty.Type = newGroupType;
            Assert.That(groupMarketplaceEmpty.Type, Is.EqualTo(newGroupType));
        }
        [Test]
        public void Type_SetForGroupWithoutId_ShouldBeNewGroupType()
        {
            string newGroupType = "new";
            groupMarketplaceWithoutId.Type = newGroupType;
            Assert.That(groupMarketplaceWithoutId.Type, Is.EqualTo(newGroupType));
        }
        [Test]
        public void Type_SetForGroupWithId_ShouldBeNewGroupType()
        {
            string newGroupType = "new";
            groupMarketplaceWithId.Type = newGroupType;
            Assert.That(groupMarketplaceWithId.Type, Is.EqualTo(newGroupType));
        }

        [Test]
        public void BannerPath_GetFromGroupEmpty_ShouldBeEmpty()
        {
            Assert.IsEmpty(groupMarketplaceEmpty.BannerPath);
        }
        [Test]
        public void BannerPath_GetFromGroupWithoutId_ShouldBeEqualToBannerPath()
        {
            Assert.That(groupMarketplaceWithoutId.BannerPath, Is.EqualTo(bannerPath));
        }
        [Test]
        public void BannerPath_GetFromGroupWithId_ShouldBeEqualToBannerPath()
        {
            Assert.That(groupMarketplaceWithId.BannerPath, Is.EqualTo(bannerPath));
        }

        [Test]
        public void BannerPath_SetForGroupEmpty_ShouldBeNewGroupBannerPath()
        {
            string newGroupBannerPath = "new";
            groupMarketplaceEmpty.BannerPath = newGroupBannerPath;
            Assert.That(groupMarketplaceEmpty.BannerPath, Is.EqualTo(newGroupBannerPath));
        }
        [Test]
        public void BannerPath_SetForGroupWithoutId_ShouldBeNewGroupBannerPath()
        {
            string newGroupBannerPath = "new";
            groupMarketplaceWithoutId.BannerPath = newGroupBannerPath;
            Assert.That(groupMarketplaceWithoutId.BannerPath, Is.EqualTo(newGroupBannerPath));
        }
        [Test]
        public void BannerPath_SetForGroupWithId_ShouldBeNewGroupBannerPath()
        {
            string newGroupBannerPath = "new";
            groupMarketplaceWithId.BannerPath = newGroupBannerPath;
            Assert.That(groupMarketplaceWithId.BannerPath, Is.EqualTo(newGroupBannerPath));
        }

        [Test]
        public void CreationDate_GetFromGroupEmpty_IsInstanceOfDateTime()
        {
            Assert.That(groupMarketplaceEmpty.CreationDate, Is.InstanceOf<DateTime>());
        }

        [Test]
        public void CreationDate_GetFromGroupWithoutId_IsInstanceOfDateTime()
        {
            Assert.That(groupMarketplaceWithoutId.CreationDate, Is.InstanceOf<DateTime>());
        }

        [Test]
        public void CreationDate_GetFromGroupWithId_ShouldBeEqualToCreationDate()
        {
            Assert.That(groupMarketplaceWithId.CreationDate, Is.EqualTo(creationDate));
        }

        [Test]
        public void UsersWithSellRequests_GetFromGroupEmpty_ShouldBeEmpty()
        {
            Assert.That(groupMarketplaceEmpty.UsersWithSellRequests, Is.Empty);
        }
        [Test]
        public void UsersWithSellRequests_GetFromGroupWithoutId_ShouldBeEmpty()
        {
            Assert.That(groupMarketplaceWithoutId.UsersWithSellRequests, Is.Empty);
        }
        [Test]
        public void UsersWithSellRequests_GetFromGroupWithId_ShouldBeEqualToUsersRequestingToSell()
        {
            Assert.That(groupMarketplaceWithId.UsersWithSellRequests, Is.EqualTo(sellingUsers));
        }

        [Test]
        public void UsersWithSellRequests_SetToNewList_ShouldBeNewList()
        {
            List<Guid> guids = new List<Guid>();
            guids.Add(groupId);
            groupMarketplaceEmpty.UsersWithSellRequests = guids;
            Assert.That(groupMarketplaceEmpty.UsersWithSellRequests, Is.EqualTo(guids));
        }

        [Test]
        public void TopSellers_GetFromGroupEmpty_ShouldBeEmpty()
        {
            Assert.That(groupMarketplaceEmpty.TopSellers, Is.Empty);
        }
        [Test]
        public void TopSellers_GetFromGroupWithoutId_ShouldBeEmpty()
        {
            Assert.That(groupMarketplaceWithoutId.TopSellers, Is.Empty);
        }
        [Test]
        public void TopSellers_GetFromGroupWithId_ShouldBeEqualToTopSellers()
        {
            Assert.That(groupMarketplaceWithId.TopSellers, Is.EqualTo(topSellers));
        }
        [Test]
        public void TopSellers_SetTopSellers_TopSellersEqualToNewList()
        {
            List<Guid> guids = new List<Guid>();
            guids.Add(groupId);
            groupMarketplaceEmpty.TopSellers = guids;
            Assert.That(groupMarketplaceEmpty.TopSellers, Is.EqualTo(guids));
        }

        [Test]
        public void AddUserWithSellRequest_AddNotExistingUser_UserShouldBeAddedToUsersWithSellRequests()
        {
            Guid userId = Guid.NewGuid();
            groupMarketplaceEmpty.AddUserWithSellRequest(userId);
            Assert.Contains(userId, groupMarketplaceEmpty.UsersWithSellRequests);
        }

        [Test]
        public void AddUserWithSellRequest_AddNotExistingUser_UserShouldNotBeInSellers()
        {
            Guid userId = Guid.NewGuid();
            groupMarketplaceEmpty.AddUserWithSellRequest(userId);
            Assert.Contains(userId, groupMarketplaceEmpty.SellingUsers);
        }

        [Test]
        public void AddUserWithSellRequest_AddExistingUser_UserShouldNotBeAddedAgain()
        {
            Guid userId = Guid.NewGuid();
            groupMarketplaceEmpty.AddUserWithSellRequest(userId);
            groupMarketplaceEmpty.AddUserWithSellRequest(userId);

            Assert.That(groupMarketplaceEmpty.SellingUsers, Has.Count.EqualTo(2));
        }

        [Test]
        public void RemoveUserWithSellRequest_RemoveExisting_UserShouldBeRemoved()
        {
            Guid userId = Guid.NewGuid();
            groupMarketplaceEmpty.AddUserWithSellRequest(userId);
            groupMarketplaceEmpty.RemoveUserWithSellRequest(userId);
            Assert.IsFalse(groupMarketplaceEmpty.UsersWithSellRequests.Contains(userId));
        }

        [Test]
        public void RemoveUserWithSellRequest_RemoveNonExisting_ShouldNotThrowException()
        {
            Guid userId = Guid.NewGuid();

            Assert.DoesNotThrow(() => { groupMarketplaceEmpty.RemoveUserWithSellRequest(userId); });
        }
        [Test]
        public void AddMember_UserNotMember_MembersShouldContainUser()
        {
            Guid user = Guid.NewGuid();
            groupMarketplaceEmpty.AddMember(user);
            Assert.Contains(user, groupMarketplaceEmpty.Members);
        }

        [Test]
        public void AddMember_UserNotMember_MemberCountShouldBe1()
        {
            Guid user = Guid.NewGuid();
            groupMarketplaceEmpty.AddMember(user);
            Assert.AreEqual(groupMarketplaceEmpty.MemberCount, 1);
        }
        [Test]
        public void AddMember_UserMember_ThrowException()
        {
            Guid user = Guid.NewGuid();
            groupMarketplaceEmpty.AddMember(user);
            var exceptionMessage = Assert.Throws<Exception>(() => { groupMarketplaceEmpty.AddMember(user); });
            Assert.That(exceptionMessage.Message, Is.EqualTo("User is already a member of this groupMarketplace"));
        }
        [Test]
        public void RemoveMember_UserIsMember_MembersDontContainUserAnymore()
        {
            Guid user = Guid.NewGuid();
            groupMarketplaceEmpty.AddMember(user);
            groupMarketplaceEmpty.RemoveMember(user);
            Assert.False(groupMarketplaceEmpty.Members.Contains(user));
        }
        [Test]
        public void RemoveMember_UserIsMember_MembersCountDecreases()
        {
            Guid user = Guid.NewGuid();
            groupMarketplaceEmpty.AddMember(user);
            groupMarketplaceEmpty.RemoveMember(user);
            Assert.Zero(groupMarketplaceEmpty.MemberCount);
        }
        [Test]
        public void RemoveMember_UserNotMember_ThrowException()
        {
            Guid user = Guid.NewGuid();
            var exceptionMessage = Assert.Throws<Exception>(() => { groupMarketplaceEmpty.RemoveMember(user); });
            Assert.That(exceptionMessage.Message, Is.EqualTo("User is not a member of this groupMarketplace"));
        }
        [Test]
        public void AddPost_AnyPost_PostIsAdded()
        {
            Guid post = Guid.NewGuid();
            groupMarketplaceEmpty.AddPost(post);
            Assert.That(groupMarketplaceEmpty.Posts, Has.Count.EqualTo(1));
        }
        [Test]
        public void RemovePost_PostExists_PostIsRemoved()
        {
            Guid post = Guid.NewGuid();
            groupMarketplaceEmpty.AddPost(post);
            groupMarketplaceEmpty.RemovePost(post);
            Assert.That(groupMarketplaceEmpty.Posts, Is.Empty);
        }
        [Test]
        public void RemovePost_PostDoesntExist_DoesNotThrowException()
        {
            Guid post = Guid.NewGuid();
            Assert.DoesNotThrow(() => { groupMarketplaceEmpty.RemovePost(post); });
        }
        [Test]
        public void AddAdmin_UserIsNotMember_ThrowException()
        {
            Guid user = Guid.NewGuid();
            var exceptionMessage = Assert.Throws<Exception>(() => { groupMarketplaceEmpty.AddAdmin(user); });
            Assert.That(exceptionMessage.Message, Is.EqualTo("User is not a member of this groupMarketplace"));
        }
        [Test]
        public void AddAdmin_UserMemberAndAdmin_ThrowException()
        {
            Guid user = Guid.NewGuid();
            groupMarketplaceEmpty.AddMember(user);
            groupMarketplaceEmpty.AddAdmin(user);
            var exceptionMessage = Assert.Throws<Exception>(() => { groupMarketplaceEmpty.AddAdmin(user); });
            Assert.That(exceptionMessage.Message, Is.EqualTo("User is already an admin of this groupMarketplace"));
        }
        [Test]
        public void AddAdmin_UserMemberNotAdmin_UserIsAddedAsAdmin()
        {
            Guid user = Guid.NewGuid();
            groupMarketplaceEmpty.AddMember(user);
            groupMarketplaceEmpty.AddAdmin(user);
            Assert.That(groupMarketplaceEmpty.Admins, Has.Count.EqualTo(1));
        }

        [Test]
        public void RemoveAdmin_UserIsNotMember_ThrowException()
        {
            Guid user = Guid.NewGuid();
            var exceptionMessage = Assert.Throws<Exception>(() => { groupMarketplaceEmpty.RemoveAdmin(user); });
            Assert.That(exceptionMessage.Message, Is.EqualTo("User is not a member of this groupMarketplace"));
        }
        [Test]
        public void RemoveAdmin_UserIsMemberNotAdmin_ThrowException()
        {
            Guid user = Guid.NewGuid();
            groupMarketplaceEmpty.AddMember(user);
            var exceptionMessage = Assert.Throws<Exception>(() => { groupMarketplaceEmpty.RemoveAdmin(user); });
            Assert.That(exceptionMessage.Message, Is.EqualTo("User is not an admin of this groupMarketplace"));
        }
        [Test]
        public void RemoveAdmin_UserIsAdmin_UserIsRemoved()
        {
            Guid user = Guid.NewGuid();
            groupMarketplaceEmpty.AddMember(user);
            groupMarketplaceEmpty.AddAdmin(user);
            groupMarketplaceEmpty.RemoveAdmin(user);
            Assert.That(groupMarketplaceEmpty.Admins, Has.Count.EqualTo(0));
        }

        [Test]
        public void AddSellingUser_UserIsNotMember_ThrowException()
        {
            Guid user = Guid.NewGuid();
            var exceptionMessage = Assert.Throws<Exception>(() => { groupMarketplaceEmpty.AddSellingUser(user); });
            Assert.That(exceptionMessage.Message, Is.EqualTo("User is not a member of this groupMarketplace"));
        }
        [Test]
        public void AddSellingUser_UserMemberAndSellingUser_ThrowException()
        {
            Guid user = Guid.NewGuid();
            groupMarketplaceEmpty.AddMember(user);
            groupMarketplaceEmpty.AddSellingUser(user);
            var exceptionMessage = Assert.Throws<Exception>(() => { groupMarketplaceEmpty.AddSellingUser(user); });
            Assert.That(exceptionMessage.Message, Is.EqualTo("User is already a selling user of this groupMarketplace"));
        }
        [Test]
        public void AddSellingUser_UserMemberNotSellingUser_UserIsAddedAsSellingUser()
        {
            Guid user = Guid.NewGuid();
            groupMarketplaceEmpty.AddMember(user);
            groupMarketplaceEmpty.AddSellingUser(user);
            Assert.That(groupMarketplaceEmpty.SellingUsers, Has.Count.EqualTo(1));
        }
        [Test]
        public void RemoveSellingUser_UserIsNotMember_ThrowException()
        {
            Guid user = Guid.NewGuid();
            var exceptionMessage = Assert.Throws<Exception>(() => { groupMarketplaceEmpty.RemoveSellingUser(user); });
            Assert.That(exceptionMessage.Message, Is.EqualTo("User is not a member of this groupMarketplace"));
        }
        [Test]
        public void RemoveSellingUser_UserIsMemberNotSellingUser_ThrowException()
        {
            Guid user = Guid.NewGuid();
            groupMarketplaceEmpty.AddMember(user);
            var exceptionMessage = Assert.Throws<Exception>(() => { groupMarketplaceEmpty.RemoveSellingUser(user); });
            Assert.That(exceptionMessage.Message, Is.EqualTo("User is not a selling user of this groupMarketplace"));
        }
        [Test]
        public void RemoveSellingUser_UserIsSellingUser_UserIsRemoved()
        {
            Guid user = Guid.NewGuid();
            groupMarketplaceEmpty.AddMember(user);
            groupMarketplaceEmpty.AddSellingUser(user);
            groupMarketplaceEmpty.RemoveSellingUser(user);
            Assert.That(groupMarketplaceEmpty.SellingUsers, Has.Count.EqualTo(0));
        }

        [Test]
        public void AddRequestingToSellUser_UserIsNotMember_ThrowException()
        {
            Guid user = Guid.NewGuid();
            var exceptionMessage = Assert.Throws<Exception>(() => { groupMarketplaceEmpty.AddRequestingToSellUser(user); });
            Assert.That(exceptionMessage.Message, Is.EqualTo("User is not a member of this groupMarketplace"));
        }
        [Test]
        public void AddRequestingToSellUser_UserMemberAndRequestingUser_ThrowException()
        {
            Guid user = Guid.NewGuid();
            groupMarketplaceEmpty.AddMember(user);
            groupMarketplaceEmpty.AddRequestingToSellUser(user);
            var exceptionMessage = Assert.Throws<Exception>(() => { groupMarketplaceEmpty.AddRequestingToSellUser(user); });
            Assert.That(exceptionMessage.Message, Is.EqualTo("User is already a selling user of this groupMarketplace"));
        }
        [Test]
        public void AddRequestingToSellUser_UserMemberNotRequestingUser_UserIsAddedAsRequestingUser()
        {
            Guid user = Guid.NewGuid();
            groupMarketplaceEmpty.AddMember(user);
            groupMarketplaceEmpty.AddRequestingToSellUser(user);
            Assert.That(groupMarketplaceEmpty.SellingUsers, Has.Count.EqualTo(1));
        }
        [Test]
        public void RemoveRequestingToSellUser_UserIsNotMember_ThrowException()
        {
            Guid user = Guid.NewGuid();
            var exceptionMessage = Assert.Throws<Exception>(() => { groupMarketplaceEmpty.RemoveRequestingToSellUser(user); });
            Assert.That(exceptionMessage.Message, Is.EqualTo("User is not a member of this groupMarketplace"));
        }
        [Test]
        public void RemoveRequestingToSellUser_UserIsMemberNotSellingUser_ThrowException()
        {
            Guid user = Guid.NewGuid();
            groupMarketplaceEmpty.AddMember(user);
            var exceptionMessage = Assert.Throws<Exception>(() => { groupMarketplaceEmpty.RemoveRequestingToSellUser(user); });
            Assert.That(exceptionMessage.Message, Is.EqualTo("User is not a selling user of this groupMarketplace"));
        }
        [Test]
        public void RemoveRequestingToSellUser_UserIsRequestingUser_UserIsRemoved()
        {
            Guid user = Guid.NewGuid();
            groupMarketplaceEmpty.AddMember(user);
            groupMarketplaceEmpty.AddRequestingToSellUser(user);
            groupMarketplaceEmpty.RemoveRequestingToSellUser(user);
            Assert.That(groupMarketplaceEmpty.SellingUsers, Has.Count.EqualTo(0));
        }

        [Test]
        public void AddTopSeller_AnyTopSeller_TopSellerIsAdded()
        {
            Guid seller = Guid.NewGuid();
            groupMarketplaceEmpty.AddTopSeller(seller);
            Assert.That(groupMarketplaceEmpty.TopSellers, Has.Count.EqualTo(1));
        }
        [Test]
        public void RemoveTopSeller_TopSellerExists_TopSellerIsRemoved()
        {
            Guid seller = Guid.NewGuid();
            groupMarketplaceEmpty.AddTopSeller(seller);
            groupMarketplaceEmpty.RemoveTopSeller(seller);
            Assert.That(groupMarketplaceEmpty.TopSellers, Is.Empty);
        }
        [Test]
        public void RemoveTopSeller_TopSellerDoesntExist_DoesNotThrowException()
        {
            Guid seller = Guid.NewGuid();
            Assert.DoesNotThrow(() => { groupMarketplaceEmpty.RemoveTopSeller(seller); });
        }
    }
}
