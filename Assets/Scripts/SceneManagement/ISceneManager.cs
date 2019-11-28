using Assets.Scripts.DataManagement;
using Assets.Scripts.Managers;
using Assets.Scripts.StoryManagement;
using System;

namespace Assets.Scripts.SceneManagement
{
    public interface ISceneManager
    {
        event Action<IGameData, IBaseData> EndStory;

        void SetupScene(IGameData gameData, IBaseData baseData);
        void ShowIntro(IGameData gameData, IBaseData baseData);
        void ShowStory(IStory story);
    }
}