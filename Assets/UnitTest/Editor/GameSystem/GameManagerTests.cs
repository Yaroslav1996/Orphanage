using NUnit.Framework;
using NSubstitute;
using System.Collections;
using UnityEngine.TestTools;
using Assets.Scripts.StoryManagement;
using Assets.Scripts.Managers;
using UnityEngine;
using Assets.Scripts.DataManagement;
using Assets.Scripts.SceneManagement;
using Assets.Scripts.StoryManagement.TurnManagement;
using System.Collections.Generic;

namespace GameSystemTests
{
    public class GameManagerTests
    {
        private IGameData _gameData;
        private GameManager _gameManager;

        [SetUp]
        public void SetUp()
        {
            _gameData = new GameData();
            _gameManager = new GameObject().AddComponent<GameManager>();
            _gameManager.TestContruct();
        }

        [Test]
        public void SaveGame_UsesSaveMethod()
        {
            ISaveLoad saveLoad = Substitute.For<ISaveLoad>();
            _gameManager.saveLoad = saveLoad;
            _gameManager.GameData = _gameData;

            _gameManager.SaveGame();

            saveLoad.Received().Save(_gameData);
        }

        [Test]
        public void LoadGame_UsesLoadMethod()
        {
            ISaveLoad saveLoad = Substitute.For<ISaveLoad>();
            _gameManager.saveLoad = saveLoad;

            _gameManager.LoadGame("test");

            saveLoad.Received().Load("test");

        }

        [Test]
        public void LoadGame_ReturnsGameData()
        {
            ISaveLoad saveLoad = Substitute.For<ISaveLoad>();
            saveLoad.Load("test").Returns(_gameData);
            _gameManager.saveLoad = saveLoad;

            _gameManager.LoadGame("test");

            Assert.That(_gameManager.GameData.Equals(_gameData));
        }

        [Test]
        public void LoadBaseData_UsesLoadMethod()
        {
            ISaveLoad saveLoad = Substitute.For<ISaveLoad>();
            _gameManager.saveLoad = saveLoad;

            _gameManager.LoadBaseData();

            saveLoad.Received().LoadBaseData();
        }

        [Test]
        public void LoadBaseData_LoadsData()
        {
            BaseData _baseData = new BaseData();
            ISaveLoad saveLoad = Substitute.For<ISaveLoad>();
            saveLoad.LoadBaseData().Returns(_baseData);
            _gameManager.saveLoad = saveLoad;

            _gameManager.LoadBaseData();

            Assert.That(_gameManager.BaseData.Equals(_baseData));
        }

        [Test]
        public void StartGame_IsCalled_SetupScene()
        {
            ISceneManager sceneManager = Substitute.For<ISceneManager>();
            _gameManager.sceneManager = sceneManager;

            _gameManager.StartGame();

            sceneManager.Received().SetupScene(_gameManager.GameData, _gameManager.BaseData);
        }

        [Test]
        public void StartGame_IsCalled_StartIntro()
        {
            ISceneManager sceneManager = Substitute.For<ISceneManager>();
            _gameManager.sceneManager = sceneManager;

            _gameManager.StartGame();

            sceneManager.Received().ShowIntro(_gameManager.GameData, _gameManager.BaseData);
        }

        [Test]
        public void StartTurn_IsCalled_CreateTurnManager()
        {
            ITurnManager turnManager = Substitute.For<ITurnManager>();
            turnManager.ViableStories = new List<IStory>();

            _gameManager.StartTurn(turnManager);

            Assert.That(!_gameManager.turnManager.Equals(null));
        }

        [Test]
        public void StartTurn_IsCalled_GetsViableStories()
        {
            ITurnManager turnManager = Substitute.For<ITurnManager>();
            turnManager.ViableStories = new List<IStory>();

            _gameManager.StartTurn(turnManager);

            turnManager.Received().GetViableStories(_gameManager.BaseData, _gameManager.GameData);
        }

        [Test]
        public void StartTurn_HasViableStories_BeginsTurn()
        {
            ITurnManager turnManager = Substitute.For<ITurnManager>();
            turnManager.ViableStories = new List<IStory>();
            turnManager.ViableStories.Add(new Story());

            _gameManager.StartTurn(turnManager);

            turnManager.Received().BeginTurn(_gameManager.BaseData, _gameManager.GameData);
        }

    }
}
