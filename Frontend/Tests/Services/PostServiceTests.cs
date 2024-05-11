using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISSLab.Model;
using ISSLab.Model.Entities;
using ISSLab.Model.Repositories;
using ISSLab.Services;
using Moq;

namespace Tests.Services
{
    internal class PostServiceTests
    {
        private PostService postService;
        private Mock<IPostRepository> postRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            postRepositoryMock = new Mock<IPostRepository>();
            postService = new PostService(postRepositoryMock.Object);
        }

        [Test]
        public void GetPosts_OnePost_ReturnsListWithThatPost()
        {
            var post = new MarketplacePost();
            var expectedPosts = new List<MarketplacePost> { post };
            postRepositoryMock.Setup(repository => repository.GetAllPosts()).Returns(expectedPosts);

            var result = postService.GetPosts();

            Assert.That(result, Is.EqualTo(expectedPosts));
        }

        [Test]
        public void AddPost_AnyPost_PostAdded()
        {
            Guid authorId = Guid.NewGuid();
            Guid groupId = Guid.NewGuid();
            MarketplacePost addedMarketplacePost = new MarketplacePost(string.Empty, authorId, groupId, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, true);

            postService.AddPost(addedMarketplacePost);

            postRepositoryMock.Verify(repository => repository.AddPost(addedMarketplacePost), Times.Once);
        }

        [Test]
        public void RemovePost_AnyPost_PostRemoved()
        {
            Guid authorId = Guid.NewGuid();
            Guid groupId = Guid.NewGuid();
            MarketplacePost removedMarketplacePost = new MarketplacePost(string.Empty, authorId, groupId, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, true);

            postService.RemovePost(removedMarketplacePost);

            postRepositoryMock.Verify(repository => repository.RemovePost(removedMarketplacePost.Id), Times.Once);
        }

        [Test]
        public void GetPostById_PostDoesNotExist_ThrowsException()
        {
            var exceptionMessage = Assert.Throws<Exception>(() => { postService.GetPostById(Guid.NewGuid()); });
            Assert.That(exceptionMessage.Message, Is.EqualTo("MarketplacePost not found"));
        }

        [Test]
        public void GetPostById_PostExists_PostReturned()
        {
            MarketplacePost marketplacePostToBeReturned = new MarketplacePost();

            postRepositoryMock.Setup(repository => repository.GetPostById(It.IsAny<Guid>())).Returns(marketplacePostToBeReturned);

            Assert.That(postService.GetPostById(Guid.NewGuid()), Is.EqualTo(marketplacePostToBeReturned));
        }

        [Test]
        public void GetPosts_Any_PostRepositoryGetAllIsCalled()
        {
            postService.GetPosts();

            postRepositoryMock.Verify(repository => repository.GetAllPosts(), Times.Once);
        }

        [Test]
        public void CheckIfNeedConfirmationTest_ExceptionThrown()
        {
            Guid guid = Guid.NewGuid();
            var exceptionMessage = Assert.Throws<Exception>(() => { postService.GetPostById(guid); });
            Assert.That(exceptionMessage.Message, Is.EqualTo("MarketplacePost not found"));
        }

        [Test]
        public void RemoveConfirmation_PostDoesNotExist_ExceptionThrown()
        {
            var exceptionMessage = Assert.Throws<Exception>(() => { postService.RemoveConfirmation(Guid.NewGuid()); });
            Assert.That(exceptionMessage.Message, Is.EqualTo("MarketplacePost not found"));
        }

        [Test]
        public void RemoveConfirmation_PostDoesExist_PostIsNoLongerConfirmed()
        {
            MarketplacePost theOnlyMarketplacePost = new MarketplacePost();
            theOnlyMarketplacePost.Confirmed = true;
            postRepositoryMock.Setup(repository => repository.GetPostById(It.IsAny<Guid>())).Returns(theOnlyMarketplacePost);

            postService.RemoveConfirmation(theOnlyMarketplacePost.Id);

            Assert.That(theOnlyMarketplacePost.Confirmed, Is.False);
        }

        [Test]
        public void ConfirmPost_PostDoesNotExist_ExceptionThrown()
        {
            var exceptionMessage = Assert.Throws<Exception>(() => { postService.ConfirmPost(Guid.NewGuid()); });
            Assert.That(exceptionMessage.Message, Is.EqualTo("MarketplacePost not found"));
        }

        [Test]
        public void ConfirmPost_PostDoesExist_PostIsConfirmed()
        {
            MarketplacePost theOnlyMarketplacePost = new MarketplacePost();
            theOnlyMarketplacePost.Confirmed = false;
            postRepositoryMock.Setup(repository => repository.GetPostById(It.IsAny<Guid>())).Returns(theOnlyMarketplacePost);

            postService.ConfirmPost(theOnlyMarketplacePost.Id);

            Assert.That(theOnlyMarketplacePost.Confirmed, Is.True);
        }

        [Test]
        public void FavoritePost_PostDoesNotExist_ExceptionThrown()
        {
            var exceptionMessage = Assert.Throws<Exception>(() => { postService.FavoritePost(Guid.NewGuid(), Guid.NewGuid()); });
            Assert.That(exceptionMessage.Message, Is.EqualTo("MarketplacePost not found"));
        }

        [Test]
        public void FavoritePost_PostDoesExist_UserIsAddedToPostsFavoritersUsers()
        {
            MarketplacePost theOnlyMarketplacePost = new MarketplacePost();
            Guid idOfTheOnlyPost = theOnlyMarketplacePost.Id;
            postRepositoryMock.Setup(repository => repository.GetPostById(It.IsAny<Guid>())).Returns(theOnlyMarketplacePost);
            Guid userId = Guid.NewGuid();

            postService.FavoritePost(idOfTheOnlyPost, userId);

            Assert.That(theOnlyMarketplacePost.UsersThatFavorited.Count, Is.EqualTo(1));
        }

        [Test]
        public void UnfavoritePost_PostDoesNotExist_ExceptionThrown()
        {
            var exceptionMessage = Assert.Throws<Exception>(() => { postService.UnfavoritePost(Guid.NewGuid(), Guid.NewGuid()); });
            Assert.That(exceptionMessage.Message, Is.EqualTo("MarketplacePost not found"));
        }

        [Test]
        public void UnfavoritePost_PostDoesExist_UserIsNotInPostsFavoritersUsers()
        {
            MarketplacePost theOnlyMarketplacePost = new MarketplacePost();
            Guid idOfTheOnlyPost = theOnlyMarketplacePost.Id;
            postRepositoryMock.Setup(repository => repository.GetPostById(It.IsAny<Guid>())).Returns(theOnlyMarketplacePost);
            Guid userId = Guid.NewGuid();
            theOnlyMarketplacePost.UsersThatFavorited.Add(userId);

            postService.UnfavoritePost(idOfTheOnlyPost, userId);

            Assert.That(theOnlyMarketplacePost.UsersThatFavorited, Is.Empty);
        }
    }
}
