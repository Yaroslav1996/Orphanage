using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.DataManagement;
using Assets.Scripts.Managers;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace DataManagementTests
{
    public class BaseDataTests
    {
        BaseData _baseData;

        [SetUp]
        public void SetUp()
        {
            _baseData = new BaseData();
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void CheckStoryRequirements_RequirementsReturnValue_ReturnsValue(bool value)
        {
            IGameData gameData = Substitute.For<IGameData>();
            Func<IGameData, bool> requirement = (IGameData) => value;
            string key = "key";
            _baseData.Requirements.Add(key, requirement);

            bool assertion = _baseData.CheckStoryRequirements(key, gameData);

            Assert.That(assertion.Equals(value));
        }
    }
}
