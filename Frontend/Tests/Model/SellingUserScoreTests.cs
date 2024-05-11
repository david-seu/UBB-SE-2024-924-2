﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISSLab.Model;

namespace Tests.Model
{
    internal class SellingUserScoreTests
    {
        private SellingUserScore userScoreEmptyConstructor;
        private SellingUserScore userScoreSimpleConstructor;

        private Guid userIdSimpleConstructor;
        private Guid groupIdSimpleConstructor;

        private SellingUserScore userScoreFullConstructor;

        private Guid userIdFullConstructor;
        private Guid groupIdFullConstructor;
        private int scoreFullConstructor;

        [SetUp]
        public void Setup()
        {
            userScoreEmptyConstructor = new SellingUserScore();

            userIdSimpleConstructor = new Guid();
            groupIdSimpleConstructor = new Guid();

            userScoreSimpleConstructor = new SellingUserScore(userIdSimpleConstructor, groupIdSimpleConstructor);

            userIdFullConstructor = new Guid();
            groupIdFullConstructor = new Guid();
            scoreFullConstructor = 0;

            userScoreFullConstructor = new SellingUserScore(userIdFullConstructor, groupIdFullConstructor, scoreFullConstructor);
        }

        [Test]
        public void UserScoreGetUserId_GetUserIdFromFullConstructor_UserIdMatches()
        {
            Assert.That(userScoreFullConstructor.UserId, Is.EqualTo(userIdFullConstructor));
        }

        [Test]
        public void UserScoreGetGroupId_GetGroupIdFromFullConstructor_GroupIdMatches()
        {
            Assert.That(userScoreFullConstructor.GroupId, Is.EqualTo(groupIdFullConstructor));
        }

        [Test]
        public void UserScoreSetScore_SetAndGetScoreForFullConstructor_NewScoreMatches()
        {
            userScoreFullConstructor.Score = 1;
            Assert.That(userScoreFullConstructor.Score, Is.EqualTo(1));
        }
    }
}
