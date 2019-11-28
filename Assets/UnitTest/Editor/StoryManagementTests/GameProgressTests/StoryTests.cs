using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.DataManagement;
using Assets.Scripts.Managers;
using Assets.Scripts.StoryManagement;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace StoryManagementTests.GameProgressTests
{
    public class StoryTests
    {
        private Story _story;

        [SetUp]
        public void SetUp()
        {
            _story = new Story();
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void CanHappen_RequirementReturnesValue_ReturnesValue(bool value)
        {
            string key = "key";
            _story.RequirementsKey = key;
            IBaseData baseData = Substitute.For<IBaseData>();
            IGameData gameData = Substitute.For<IGameData>();
            baseData.CheckStoryRequirements(key, gameData).Returns(value);

            bool assertion = _story.CanHappen(baseData, gameData);

            Assert.That(assertion.Equals(value));
        }
    }
}
