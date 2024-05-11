using System;
using ISSLab.Model.Entities;
using ISSLab.Model.Repositories;

namespace Tests.Model.Repositories
{
    public class GroupRepositoryTests
    {
        private GroupRepository groupRepository;

        [SetUp]
        public void SetUp()
        {
            groupRepository = new GroupRepository();
        }

        [Test]
        public void FindAll_NoGroups_ReturnsEmptyList()
        {
            List<GroupMarketplace> actualGroups = groupRepository.FindAll();
            Assert.That(actualGroups, Is.Empty);
        }

        [Test]
        public void FindAll_AtLeastOneGroup_ReturnsGroupsList()
        {
            GroupMarketplace firstGroupMarketplace = new GroupMarketplace(Guid.NewGuid(), string.Empty, 0, new List<Guid>(), new List<Guid>(), new List<Guid>(), new List<Guid>(),
                string.Empty, string.Empty, string.Empty, new DateTime(), new List<Guid>(), new List<Guid>());
            GroupMarketplace secondGroupMarketplace = new GroupMarketplace(Guid.NewGuid(), string.Empty, 0, new List<Guid>(), new List<Guid>(), new List<Guid>(), new List<Guid>(), string.Empty, string.Empty, string.Empty, new DateTime(), new List<Guid>(), new List<Guid>());
            groupRepository.AddGroup(firstGroupMarketplace);
            groupRepository.AddGroup(secondGroupMarketplace);

            List<GroupMarketplace> expectedGroups = new List<GroupMarketplace>
            {
                firstGroupMarketplace, secondGroupMarketplace
            };
            List<GroupMarketplace> actualGroups = groupRepository.FindAll();
            Assert.That(actualGroups, Has.Count.EqualTo(2));
            Assert.That(actualGroups, Is.EqualTo(expectedGroups));
        }

        [Test]
        public void FindById_NoGroups_ExceptionThrown()
        {
            var exceptionMessage = Assert.Throws<Exception>(() => { groupRepository.FindById(Guid.Empty); });
            Assert.That(exceptionMessage.Message, Is.EqualTo("GroupMarketplace does not exist"));
        }

        [Test]
        public void FindById_NonExistingId_ExceptionThrown()
        {
            groupRepository.AddGroup(new GroupMarketplace());

            var exceptionMessage = Assert.Throws<Exception>(() => { groupRepository.FindById(Guid.Empty); });
            Assert.That(exceptionMessage.Message, Is.EqualTo("GroupMarketplace does not exist"));
        }

        [Test]
        public void FindById_ValidId_TheGroupIsReturned()
        {
            Guid existingGuid = Guid.NewGuid();
            GroupMarketplace firstGroupMarketplace = new GroupMarketplace(existingGuid, string.Empty, 0, new List<Guid>(), new List<Guid>(), new List<Guid>(), new List<Guid>(),
                string.Empty, string.Empty, string.Empty, new DateTime(), new List<Guid>(), new List<Guid>());
            groupRepository.AddGroup(firstGroupMarketplace);

            GroupMarketplace returnedById = groupRepository.FindById(existingGuid);
            Assert.That(firstGroupMarketplace, Is.EqualTo(returnedById));
        }

        [Test]
        public void RemoveGroup_NoGroup_NoGroupIsRemoved()
        {
            groupRepository.RemoveGroup(Guid.Empty);
            Assert.That(groupRepository.FindAll(), Is.Empty);
        }

        [Test]
        public void RemoveGroup_NonexistingId_NoGroupIsRemoved()
        {
            groupRepository.AddGroup(new GroupMarketplace());

            groupRepository.RemoveGroup(Guid.Empty);

            Assert.That(groupRepository.FindAll().Count, Is.EqualTo(1));
        }

        [Test]
        public void RemoveGroup_ValidId_GroupIsRemoved()
        {
            Guid existingGuid = Guid.NewGuid();
            GroupMarketplace firstGroupMarketplace = new GroupMarketplace(existingGuid, string.Empty, 0, new List<Guid>(), new List<Guid>(), new List<Guid>(), new List<Guid>(), string.Empty, string.Empty, string.Empty, new DateTime(), new List<Guid>(), new List<Guid>());
            groupRepository.AddGroup(firstGroupMarketplace);

            groupRepository.RemoveGroup(existingGuid);
            Assert.That(groupRepository.FindAll(), Is.Empty);
        }

        [Test]
        public void AddGroup_AnyGroup_GroupIsAdded()
        {
            GroupMarketplace firstGroupMarketplace = new GroupMarketplace(Guid.NewGuid(), string.Empty, 0, new List<Guid>(), new List<Guid>(), new List<Guid>(), new List<Guid>(), string.Empty, string.Empty, string.Empty, new DateTime(), new List<Guid>(), new List<Guid>());
            groupRepository.AddGroup(firstGroupMarketplace);
            Assert.That(groupRepository.FindAll(), Has.Count.EqualTo(1));
            Assert.That(groupRepository.FindAll(), Does.Contain(firstGroupMarketplace));
        }
    }
}
