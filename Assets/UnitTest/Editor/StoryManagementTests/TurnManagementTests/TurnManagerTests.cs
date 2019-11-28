using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.DataManagement;
using Assets.Scripts.Managers;
using Assets.Scripts.SceneManagement;
using Assets.Scripts.StoryManagement;
using Assets.Scripts.StoryManagement.TurnManagement;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace StoryManagementTests.TurnManagementTests
{
    public class TurnManagerTests
    {
        TurnManager _turnManager;

        [SetUp]
        public void SetUp()
        {
            _turnManager = new TurnManager(new SceneManager());
        }

        [Test]
        public void GetViableStories_IsCalled_GetsViableStory()
        {
            IGameData gameData = Substitute.For<IGameData>();
            BaseData baseData = new BaseData();
            IStory viableStory = Substitute.For<IStory>();
            viableStory.CanHappen(baseData, gameData).Returns(true);
            baseData.BaseStories.Add(viableStory);

            _turnManager.GetViableStories(baseData, gameData);

            Assert.That(_turnManager.ViableStories.Contains(viableStory));
        }

        [Test]
        public void GetViableStories_IsCalled_RejectsUnviableStory()
        {
            IGameData gameData = Substitute.For<IGameData>();
            BaseData baseData = new BaseData();
            IStory unViableStory = Substitute.For<IStory>();
            unViableStory.CanHappen(baseData, gameData).Returns(false);
            baseData.BaseStories.Add(unViableStory);

            _turnManager.GetViableStories(baseData, gameData);

            Assert.That(!_turnManager.ViableStories.Contains(unViableStory));
        }

        [Test]
        public void GetViableStories_IsCalled_RejectsDoneStories()
        {
            IGameData gameData = Substitute.For<IGameData>();
            BaseData baseData = new BaseData();
            IStory story = Substitute.For<IStory>();
            story.CanHappen(baseData, gameData).Returns(true);
            story.IsDone.Returns(true);
            baseData.BaseStories.Add(story);

            _turnManager.GetViableStories(baseData, gameData);

            Assert.That(!_turnManager.ViableStories.Contains(story));
        }

        [Test]
        public void StartNextStory_IsCalledWithAviableStory_SetUpScene()
        {
            ISceneManager sceneManager = Substitute.For<ISceneManager>();
            _turnManager = new TurnManager(sceneManager);
            Story story = new Story()
            {
                IsDone = false
            };
            _turnManager.ViableStories.Add(story);
            IGameData gameData = Substitute.For<IGameData>();
            IBaseData baseData = Substitute.For<IBaseData>();

            _turnManager.StartNextStory(gameData, baseData);

            sceneManager.Received().SetupScene(gameData, baseData);
        }

        [Test]
        public void StartNextStory_IsCalledWithAviableStory_GetsOneNewStory()
        {
            ISceneManager sceneManager = Substitute.For<ISceneManager>();
            _turnManager = new TurnManager(sceneManager);
            Story story = new Story()
            {
                IsDone = false
            };
            _turnManager.ViableStories.Add(story);
            IGameData gameData = Substitute.For<IGameData>();
            IBaseData baseData = Substitute.For<IBaseData>();

            _turnManager.StartNextStory(gameData, baseData);

            sceneManager.Received().ShowStory(story);
        }

        [Test]
        public void StartNextTurn_IsCalledWithNoAviableStory_EndsTurn()
        {
            ISceneManager sceneManager = Substitute.For<ISceneManager>();
            _turnManager = new TurnManager(sceneManager);
            Story story = new Story()
            {
                IsDone = true
            };
            _turnManager.ViableStories.Add(story);
            bool eventRaised = false;
            _turnManager.EndTurn += () => eventRaised = true;
            IGameData gameData = Substitute.For<IGameData>();
            IBaseData baseData = Substitute.For<IBaseData>();

            _turnManager.StartNextStory(gameData, baseData);

            Assert.That(eventRaised);
        }
    }
}
