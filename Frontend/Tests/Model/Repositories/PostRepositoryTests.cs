using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISSLab.Model.Entities;
using ISSLab.Model.Repositories;
using Moq;

namespace Tests.Model.Repositories
{
    public class PostRepositoryTests
    {
        private PostRepository postRepository;

        [SetUp]
        public void SetUp()
        {
            postRepository = new PostRepository();
        }

        [Test]
        public void AddPost_AnyPost_ThePostIsAdded()
        {
            MarketplacePost marketplacePost = new MarketplacePost("media_name", Guid.NewGuid(), Guid.NewGuid(), "Cluj", "at Cluj", "My MarketplacePost", "mom", "food", false);

            postRepository.AddPost(marketplacePost);

            Assert.That(postRepository.GetAllPosts().Count, Is.EqualTo(1));
            Assert.That(postRepository.GetAllPosts()[0], Is.EqualTo(marketplacePost));
        }

        [Test]
        public void RemovePost_PostExists_ThePostIsRemoved()
        {
            Guid postGuid = Guid.NewGuid();
            MarketplacePost marketplacePost = new MarketplacePost(postGuid, new List<Guid>(), new List<Guid>(), string.Empty, new DateTime(), Guid.NewGuid(),
                Guid.NewGuid(), false, new List<Guid>(), string.Empty, string.Empty, string.Empty, new List<InterestStatus>(), string.Empty, string.Empty, false, 0);
            postRepository.AddPost(marketplacePost);

            postRepository.RemovePost(postGuid);

            Assert.That(postRepository.GetAllPosts().Count, Is.EqualTo(0));
        }

        [Test]
        public void RemovePost_PostDoesNotExist_NoPostsAreRemoved()
        {
            Guid postGuid = Guid.NewGuid();
            MarketplacePost marketplacePost = new MarketplacePost(postGuid, new List<Guid>(), new List<Guid>(), string.Empty, new DateTime(), Guid.NewGuid(),
                Guid.NewGuid(), false, new List<Guid>(), string.Empty, string.Empty, string.Empty, new List<InterestStatus>(), string.Empty, string.Empty, false, 0);
            postRepository.AddPost(marketplacePost);

            postRepository.RemovePost(Guid.NewGuid());

            Assert.That(postRepository.GetAllPosts().Count, Is.EqualTo(1));
            Assert.That(postRepository.GetAllPosts()[0], Is.EqualTo(marketplacePost));
        }

        [Test]
        public void GetPostById_ValidId_ThePostIsReturned()
        {
            Guid postGuid = Guid.NewGuid();
            MarketplacePost marketplacePost = new MarketplacePost(postGuid, new List<Guid>(), new List<Guid>(), string.Empty, new DateTime(), Guid.NewGuid(),
                Guid.NewGuid(), false, new List<Guid>(), string.Empty, string.Empty, string.Empty, new List<InterestStatus>(), string.Empty, string.Empty, false, 0);
            postRepository.AddPost(marketplacePost);

            MarketplacePost gotByIdMarketplacePost = postRepository.GetPostById(postGuid);

            Assert.That(gotByIdMarketplacePost, Is.EqualTo(marketplacePost));
        }

        [Test]
        public void GetPostById_NonexistingId_ExceptionThrown()
        {
            postRepository.AddPost(new MarketplacePost());

            var exceptionMessage = Assert.Throws<Exception>(() => { postRepository.GetPostById(Guid.NewGuid()); });
            Assert.That(exceptionMessage.Message, Is.EqualTo("MarketplacePost does not exist!"));
        }

        [Test]
        public void GetPostById_NoPosts_ExceptionThrown()
        {
            var exceptionMessage = Assert.Throws<Exception>(() => { postRepository.GetPostById(Guid.NewGuid()); });
            Assert.That(exceptionMessage.Message, Is.EqualTo("MarketplacePost does not exist!"));
        }

        [Test]
        public void GetAllPosts_NoPosts_ReturnsEmptyList()
        {
            var allPosts = postRepository.GetAllPosts();

            Assert.That(allPosts.Count, Is.EqualTo(0));
        }

        [Test]
        public void GetAllPosts_AtLeastOnePost_ReturnsThePosts()
        {
            MarketplacePost firstMarketplacePost = new MarketplacePost(Guid.NewGuid(), new List<Guid>(), new List<Guid>(), string.Empty, new DateTime(), Guid.NewGuid(),
                Guid.NewGuid(), false, new List<Guid>(), string.Empty, string.Empty, string.Empty, new List<InterestStatus>(), string.Empty, string.Empty, false, 0);
            MarketplacePost secondMarketplacePost = new MarketplacePost(Guid.NewGuid(), new List<Guid>(), new List<Guid>(), "2", new DateTime(), Guid.NewGuid(),
                Guid.NewGuid(), false, new List<Guid>(), "2", "2", "2", new List<InterestStatus>(), "2", "2", true, 2);
            postRepository.AddPost(firstMarketplacePost);
            postRepository.AddPost(secondMarketplacePost);

            var allPosts = postRepository.GetAllPosts();

            Assert.That(allPosts.Count, Is.EqualTo(2));
            Assert.That(allPosts, Is.EquivalentTo(new List<MarketplacePost> { firstMarketplacePost, secondMarketplacePost }));
        }
    }
}
