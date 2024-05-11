using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISSLab.Model.Entities;

namespace Tests.Model
{
    internal class MarketplacePostTests
    {
        private MarketplacePost firstConstructorMarketplacePost;
        private MarketplacePost secondConstructorMarketplacePost;
        private MarketplacePost thirdConstructorMarketplacePost;
        private Guid idUserToLike;
        private Guid idUserToFavorite;
        private Guid idUserToShare;
        private Guid idUserInterested1;
        private Guid idUserInterested2;
        private InterestStatus interestStatusToAdd1;
        private InterestStatus interestStatusToAdd2;
        private InterestStatus interestStatusToAdd3;
        private InterestStatus interestStatusToAdd4;

        [SetUp]
        public void SetUp()
        {
            idUserToLike = Guid.NewGuid();
            idUserToFavorite = Guid.NewGuid();
            idUserInterested1 = Guid.NewGuid();
            idUserInterested2 = Guid.NewGuid();
            idUserToShare = Guid.NewGuid();
            firstConstructorMarketplacePost = new MarketplacePost("./cat.jpg", Guid.NewGuid(), Guid.NewGuid(), "Cluj", "description1", "title1", "contacts1", string.Empty, true);
            secondConstructorMarketplacePost = new MarketplacePost(Guid.NewGuid(), new List<Guid>(), new List<Guid>(),
                "./cat.jpg", DateTime.Parse("Jan 1, 2024"), Guid.NewGuid(), Guid.NewGuid(), false, new List<Guid>(), "Cluj", "description2", "title2",
                new List<InterestStatus>(), "0744444444", "type2", false, 100);
            thirdConstructorMarketplacePost = new MarketplacePost();
            interestStatusToAdd1 = new InterestStatus(idUserInterested1, firstConstructorMarketplacePost.Id, true);
            interestStatusToAdd2 = new InterestStatus(idUserInterested1, secondConstructorMarketplacePost.Id, true);
            interestStatusToAdd3 = new InterestStatus(idUserInterested1, thirdConstructorMarketplacePost.Id, false);
            interestStatusToAdd4 = new InterestStatus(idUserInterested2, firstConstructorMarketplacePost.Id, false);
        }

        [Test]
        public void IdGet_PostFirstConstructor_ShouldBeNotEmpty()
        {
            Assert.True(firstConstructorMarketplacePost.Id != new Guid());
        }

        [Test]
        public void IdGet_GetTheIdOfPostSecondConstructor_ShouldBeNotEmpty()
        {
            Assert.True(secondConstructorMarketplacePost.Id != new Guid());
        }

        [Test]
        public void IdGet_GetTheIdOfPostThirdConstructor_ShouldBeNotEmpty()
        {
            Assert.True(thirdConstructorMarketplacePost.Id != new Guid());
        }

        [Test]
        public void ViewsGet_PostFirstConstructor_ShouldBe100()
        {
            Assert.True(firstConstructorMarketplacePost.Views.Equals(0));
        }
        [Test]
        public void ViewsGet_PostSecondConstructor_ShouldBe_0()
        {
            Assert.True(secondConstructorMarketplacePost.Views.Equals(100));
        }
        [Test]
        public void ViewsGet_getTheViewsPostThirdConstructor_ShouldBe_0()
        {
            Assert.True(thirdConstructorMarketplacePost.Views.Equals(0));
        }
        [Test]
        public void UsersThatLikedGet_PostFirstConstructor_ShouldBeListGuid()
        {
            Assert.IsInstanceOf<List<Guid>>(firstConstructorMarketplacePost.UsersThatLiked);
        }

        [Test]
        public void UsersThatLikedGet_PostSecondConstructor_ShouldBeListGuid()
        {
            Assert.IsInstanceOf<List<Guid>>(secondConstructorMarketplacePost.UsersThatLiked);
        }

        [Test]
        public void UsersThatLikedGet_getUsersThatLikedOfPostThirdConstructor_ShouldBeListGuid()
        {
            Assert.IsInstanceOf<List<Guid>>(thirdConstructorMarketplacePost.UsersThatLiked);
        }

        [Test]
        public void UsersThatSharedGet_getUsersThatSharedOfPostFirstConstructor_ShouldBeListGuid()
        {
            Assert.IsInstanceOf<List<Guid>>(firstConstructorMarketplacePost.UsersThatShared);
        }
        [Test]
        public void UsersThatSharedGet_getUsersThatSharedOfPostSecondConstructor_ShouldBeListGuid()
        {
            Assert.IsInstanceOf<List<Guid>>(secondConstructorMarketplacePost.UsersThatShared);
        }

        [Test]
        public void UsersThatSharedGet_getUsersThatSharedOfPostThirdConstructor_ShouldBeListGuid()
        {
            Assert.IsInstanceOf<List<Guid>>(thirdConstructorMarketplacePost.UsersThatShared);
        }

        [Test]
        public void UsersThatFavoritedGet_getUsersThatFavoritedOfPostFirstConstructor_ShouldBeListGuid()
        {
            Assert.IsInstanceOf<List<Guid>>(firstConstructorMarketplacePost.UsersThatFavorited);
        }

        [Test]
        public void UsersThatFavoritedGet_getUsersThatFavoritedOfPostSecondConstructor_ShouldBeListGuid()
        {
            Assert.IsInstanceOf<List<Guid>>(secondConstructorMarketplacePost.UsersThatFavorited);
        }

        [Test]
        public void UsersThatFavoritedGet_getUsersThatFavoritedOfPostThirdConstructor_ShouldBeListGuid()
        {
            Assert.IsInstanceOf<List<Guid>>(thirdConstructorMarketplacePost.UsersThatFavorited);
        }
        [Test]
        public void MediaContentGet_getMediaContentOfPostFirstConstructor_ShouldBeString()
        {
            Assert.IsInstanceOf<string>(firstConstructorMarketplacePost.MediaContent);
            Assert.That(firstConstructorMarketplacePost.MediaContent == "./cat.jpg");
        }

        [Test]
        public void MediaContentGet_getMediaContentOfPostSecondConstructor_ShouldBeString()
        {
            Assert.IsInstanceOf<string>(secondConstructorMarketplacePost.MediaContent);
            Assert.That(secondConstructorMarketplacePost.MediaContent == "./cat.jpg");
        }

        [Test]
        public void MediaContentGet_getMediaContentOfPostThirdConstructor_ShouldBeString()
        {
            Assert.IsInstanceOf<string>(thirdConstructorMarketplacePost.MediaContent);
            Assert.That(thirdConstructorMarketplacePost.MediaContent == string.Empty);
        }

        [Test]
        public void CreationDateGet_getCreationDateOfPostFirstConstructor_ShouldBeDatetime()
        {
            Assert.IsInstanceOf<DateTime>(firstConstructorMarketplacePost.CreationDate);
        }

        [Test]
        public void CreationDateGet_getCreationDateOfPostThirdConstructor_ShouldBeDatetime()
        {
            Assert.IsInstanceOf<DateTime>(thirdConstructorMarketplacePost.CreationDate);
        }

        [Test]
        public void AuthorIdGet_GetTheAuthorIdOfPostFirstConstructor_ShouldBeNotEmpty()
        {
            Assert.True(firstConstructorMarketplacePost.AuthorId != new Guid());
        }

        [Test]
        public void GroupIdGet_GetTheGroupIdOfPostFirstConstructor_ShouldBeNotEmpty()
        {
            Assert.True(firstConstructorMarketplacePost.GroupId != new Guid());
        }

        [Test]
        public void ContactsSet_SetTheContactsOfPostFirstConstructor_ShouldBeEqualWith0755555555()
        {
            firstConstructorMarketplacePost.Contacts = "0755555555";
            Assert.True(firstConstructorMarketplacePost.Contacts == "0755555555");
        }

        [Test]
        public void ConfirmedSet_SetTheConfirmedOfPostFirstConstructor_ShouldBeEqualWithTrue()
        {
            firstConstructorMarketplacePost.Confirmed = true;
            Assert.True(firstConstructorMarketplacePost.Confirmed);
        }

        [Test]
        public void PromotedSet_SetTheContactsOfPostSecondConstructor_ShouldBeEqualWithTrue()
        {
            Assert.False(firstConstructorMarketplacePost.Promoted);
            firstConstructorMarketplacePost.Promoted = true;
            Assert.True(firstConstructorMarketplacePost.Promoted);
        }

        [Test]
        public void TitleSet_SetTheTitleOfPostFirstConstructor_ShouldBeEqualWithtitle1()
        {
            Assert.True(firstConstructorMarketplacePost.Title == "title1");
        }

        [Test]
        public void DescriptionSet_SetTheDescriptionOfPostFirstConstructor_ShouldBeEqualWithdescription1()
        {
            Assert.True(firstConstructorMarketplacePost.Description == "description1");
        }

        [Test]
        public void ItemLotionSet_SetTheItemLocationOfPostFirstConstructor_ShouldBeEqualWithBucuresti()
        {
            Assert.True(firstConstructorMarketplacePost.ItemLocation == "Cluj");
            firstConstructorMarketplacePost.ItemLocation = "Bucuresti";
            Assert.True(firstConstructorMarketplacePost.ItemLocation == "Bucuresti");
        }

        [Test]
        public void ToggleLike_OneUserLikesThePostFirstConstructor_NumberOfUsersThatLikedPostFirstConstructorShouldBe1()
        {
            firstConstructorMarketplacePost.ToggleLike(idUserToShare);
            Assert.That(firstConstructorMarketplacePost.UsersThatLiked, Has.Count.EqualTo(1));
        }
        [Test]
        public void ToggleLike_OneUserLikesThePostSecondConstructor_NumberOfUsersThatLikedPostSecondConstructorShouldBe1()
        {
            secondConstructorMarketplacePost.ToggleLike(idUserToShare);
            Assert.That(secondConstructorMarketplacePost.UsersThatLiked, Has.Count.EqualTo(1));
        }
        [Test]
        public void ToggleLike_OneUserLikesThePostThirdConstructor_NumberOfUsersThatLikedPostThirdConstructorShouldBe1()
        {
            thirdConstructorMarketplacePost.ToggleLike(idUserToShare);
            Assert.That(thirdConstructorMarketplacePost.UsersThatLiked, Has.Count.EqualTo(1));
        }
        [Test]
        public void ToggleLike_OneUserDoesNotSharesAnymoreThePostFirstConstructor_NumberOfUsersThatSharedPostFirstConstructorShouldBe0()
        {
            firstConstructorMarketplacePost.ToggleLike(idUserToShare);
            firstConstructorMarketplacePost.ToggleLike(idUserToShare);
            Assert.That(firstConstructorMarketplacePost.UsersThatLiked, Has.Count.EqualTo(0));
        }
        [Test]
        public void ToggleLike_OneUserDoesNotLikeAnymoreThePostSecondConstructor_NumberOfUsersThatLikedPostSecondConstructorShouldBe0()
        {
            secondConstructorMarketplacePost.ToggleLike(idUserToLike);
            secondConstructorMarketplacePost.ToggleLike(idUserToLike);
            Assert.That(secondConstructorMarketplacePost.UsersThatLiked, Has.Count.EqualTo(0));
        }
        [Test]
        public void ToggleLike_OneUserDoesNotLikeAnymoreThePostThirdConstructor_NumberOfUsersThatLikedPostThirdConstructorShouldBe0()
        {
            thirdConstructorMarketplacePost.ToggleLike(idUserToLike);
            thirdConstructorMarketplacePost.ToggleLike(idUserToLike);
            Assert.That(thirdConstructorMarketplacePost.UsersThatLiked, Has.Count.EqualTo(0));
        }
        [Test]
        public void ToggleFavorite_OneUserFavoritesThePostFirstConstructor_NumberOfUsersThatFavoritedPostFirstConstructorShouldBe1()
        {
            firstConstructorMarketplacePost.ToggleFavorite(idUserToFavorite);
            Assert.That(firstConstructorMarketplacePost.UsersThatFavorited, Has.Count.EqualTo(1));
        }
        [Test]
        public void ToggleFavorites_OneUserFavoritesThePostSecondConstructor_NumberOfUsersThatFavoritedPostSecondConstructorShouldBe1()
        {
            secondConstructorMarketplacePost.ToggleFavorite(idUserToFavorite);
            Assert.That(secondConstructorMarketplacePost.UsersThatFavorited, Has.Count.EqualTo(1));
        }
        [Test]
        public void ToggleFavorites_OneUserFavoritesThePostThirdConstructor_NumberOfUsersThatFavoritesPostThirdConstructorShouldBe1()
        {
            thirdConstructorMarketplacePost.ToggleFavorite(idUserToFavorite);
            Assert.That(thirdConstructorMarketplacePost.UsersThatFavorited, Has.Count.EqualTo(1));
        }
        [Test]
        public void ToggleFavorites_OneUserDoesNotFavoriteAnymoreThePostFirstConstructor_NumberOfUsersThatFavoritedPostFirstConstructorShouldBe0()
        {
            firstConstructorMarketplacePost.ToggleFavorite(idUserToFavorite);
            firstConstructorMarketplacePost.ToggleFavorite(idUserToFavorite);
            Assert.That(firstConstructorMarketplacePost.UsersThatFavorited, Has.Count.EqualTo(0));
        }
        [Test]
        public void ToggleFavorite_OneUserDoesNotFavoriteAnymoreThePostSecondConstructor_NumberOfUsersThatLikedPostSecondConstructorShouldBe0()
        {
            secondConstructorMarketplacePost.ToggleFavorite(idUserToFavorite);
            secondConstructorMarketplacePost.ToggleFavorite(idUserToFavorite);
            Assert.That(secondConstructorMarketplacePost.UsersThatFavorited, Has.Count.EqualTo(0));
        }
        [Test]
        public void ToggleFavorite_OneUserDoesNotFavoriteAnymoreThePostThirdConstructor_NumberOfUsersThatFavoritedPostThirdConstructorShouldBe0()
        {
            thirdConstructorMarketplacePost.ToggleFavorite(idUserToFavorite);
            thirdConstructorMarketplacePost.ToggleFavorite(idUserToFavorite);
            Assert.That(thirdConstructorMarketplacePost.UsersThatFavorited, Has.Count.EqualTo(0));
        }
        [Test]
        public void ToggleShare_OneUserSharesThePostFirstConstructor_NumberOfUsersThatSharedPostFirstConstructorShouldBe1()
        {
            firstConstructorMarketplacePost.ToggleShare(idUserToShare);
            Assert.That(firstConstructorMarketplacePost.UsersThatShared, Has.Count.EqualTo(1));
        }
        [Test]
        public void ToggleShare_OneUserSharesThePostSecondConstructor_NumberOfUsersThatSharedPostSecondConstructorShouldBe1()
        {
            secondConstructorMarketplacePost.ToggleShare(idUserToShare);
            Assert.That(secondConstructorMarketplacePost.UsersThatShared, Has.Count.EqualTo(1));
        }
        [Test]
        public void ToggleShare_OneUserSharesThePostThirdConstructor_NumberOfUsersThatSharedPostThirdConstructorShouldBe1()
        {
            thirdConstructorMarketplacePost.ToggleShare(idUserToShare);
            Assert.That(thirdConstructorMarketplacePost.UsersThatShared, Has.Count.EqualTo(1));
        }
        [Test]
        public void ToggleShare_OneUserDoesNotSharesAnymoreThePostFirstConstructor_NumberOfUsersThatSharedPostFirstConstructorShouldBe0()
        {
            firstConstructorMarketplacePost.ToggleShare(idUserToShare);
            firstConstructorMarketplacePost.ToggleShare(idUserToShare);
            Assert.That(firstConstructorMarketplacePost.UsersThatShared, Has.Count.EqualTo(0));
        }
        [Test]
        public void ToggleShare_OneUserDoesNotSharesAnymoreThePostSecondConstructor_NumberOfUsersThatSharedPostSecondConstructorShouldBe0()
        {
            secondConstructorMarketplacePost.ToggleShare(idUserToShare);
            secondConstructorMarketplacePost.ToggleShare(idUserToShare);
            Assert.That(secondConstructorMarketplacePost.UsersThatShared, Has.Count.EqualTo(0));
        }
        [Test]
        public void ToggleShare_OneUserDoesNotSharesAnymoreThePostThirdConstructor_NumberOfUsersThatSharedPostThirdConstructorShouldBe0()
        {
            thirdConstructorMarketplacePost.ToggleShare(idUserToShare);
            thirdConstructorMarketplacePost.ToggleShare(idUserToShare);
            Assert.That(thirdConstructorMarketplacePost.UsersThatShared, Has.Count.EqualTo(0));
        }

        [Test]
        public void AddInterestUser_InterestStatus1andInterestStatus4AddedToPostFirstConstructor_ThereShouldBeTwoInterestStatusesInPostFirstConstructor()
        {
            firstConstructorMarketplacePost.AddInterestStatus(interestStatusToAdd1);
            firstConstructorMarketplacePost.AddInterestStatus(interestStatusToAdd4);
            Assert.That(firstConstructorMarketplacePost.InterestStatuses, Has.Count.EqualTo(2));
        }

        [Test]
        public void AddInterestUser_InterestStatus2AddedToPostSecondConstructor_ThereShouldBeOneInterestStatusInPostSecondConstructor()
        {
            secondConstructorMarketplacePost.AddInterestStatus(interestStatusToAdd2);
            Assert.That(secondConstructorMarketplacePost.InterestStatuses, Has.Count.EqualTo(1));
        }

        [Test]
        public void AddInterestUser_InterestStatus3AddedToPostThirdConstructor_ThereShouldBeOneInterestStatusInPostThirdConstructor()
        {
            thirdConstructorMarketplacePost.AddInterestStatus(interestStatusToAdd3);
            Assert.That(thirdConstructorMarketplacePost.InterestStatuses, Has.Count.EqualTo(1));
        }

        [Test]
        public void ToggleInterestStatus_AddInterestStatusToPostFirstConstructor_SwitchedTheInterestStatusesOfPostFirstConstructorToTheOppositeValues()
        {
            firstConstructorMarketplacePost.AddInterestStatus(interestStatusToAdd1);
            firstConstructorMarketplacePost.AddInterestStatus(interestStatusToAdd4);
            firstConstructorMarketplacePost.ToggleInterestStatus(interestStatusToAdd1.InterestedUserId);
            firstConstructorMarketplacePost.ToggleInterestStatus(interestStatusToAdd4.InterestedUserId);
            Assert.False(firstConstructorMarketplacePost.InterestStatuses[0].Interested);
            Assert.True(firstConstructorMarketplacePost.InterestStatuses[1].Interested);
        }
        [Test]
        public void ToggleInterestStatus_AddInterestStatusToPostSecondConstructor_SwitchedTheInterestStatusesOfPostSecondConstructorToTheOppositeValue()
        {
            secondConstructorMarketplacePost.AddInterestStatus(interestStatusToAdd2);
            secondConstructorMarketplacePost.ToggleInterestStatus(interestStatusToAdd2.InterestedUserId);
            Assert.False(secondConstructorMarketplacePost.InterestStatuses[0].Interested);
        }
        [Test]
        public void ToggleInterestStatus_AddInterestStatusToPostThirdConstructor_SwitchedTheInterestStatusesOfPostThirdConstructorToTheOppositeValue()
        {
            thirdConstructorMarketplacePost.AddInterestStatus(interestStatusToAdd3);
            thirdConstructorMarketplacePost.ToggleInterestStatus(interestStatusToAdd3.InterestedUserId);
            Assert.True(thirdConstructorMarketplacePost.InterestStatuses[0].Interested);
        }
        [Test]
        public void ToggleInterestStatus_TryToToggleInterestStatusOfAUserThatWasNotInterestedForPostThirdConstructor_ThereShouldBeAnError()
        {
            var exceptionMessage = Assert.Throws<Exception>(() => { thirdConstructorMarketplacePost.ToggleInterestStatus(interestStatusToAdd3.InterestedUserId); });
            Assert.That(exceptionMessage.Message, Is.EqualTo("Interest status not found"));
        }

        [Test]
        public void RemoveInterestStatus_InterestStatusRemovedFromPost()
        {
            thirdConstructorMarketplacePost.AddInterestStatus(interestStatusToAdd3);
            thirdConstructorMarketplacePost.RemoveInterestStatus(interestStatusToAdd3.InterestedUserId);
            Assert.That(thirdConstructorMarketplacePost.InterestStatuses, Has.Count.EqualTo(0));
        }
        [Test]
        public void InterestLevel_InterestLevelProperlyCalculatedForPostFirstConstructor_TheInterestShouldBeEqualWith0()
        {
            firstConstructorMarketplacePost.AddInterestStatus(interestStatusToAdd1);
            firstConstructorMarketplacePost.AddInterestStatus(interestStatusToAdd4);
            Assert.True(firstConstructorMarketplacePost.InterestLevel() == 0);
        }

        [Test]
        public void InterestLevel_InterestLevelProperlyCalculatedForPostSecondConstructor_TheInterestShouldBeEqualWith1()
        {
            secondConstructorMarketplacePost.AddInterestStatus(interestStatusToAdd2);
            Assert.True(secondConstructorMarketplacePost.InterestLevel() == 1);
        }
        [Test]
        public void InterestLevel_InterestLevelProperlyCalculatedForPostThirdConstructor_TheInterestShouldBeEqualWithMinus1()
        {
            thirdConstructorMarketplacePost.AddInterestStatus(interestStatusToAdd3);
            Assert.True(thirdConstructorMarketplacePost.InterestLevel() == -1);
        }
    }
}
