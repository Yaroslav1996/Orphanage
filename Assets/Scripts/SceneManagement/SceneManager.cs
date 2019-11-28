using Assets.Scripts.DataManagement;
using Assets.Scripts.Managers;
using Assets.Scripts.StoryManagement;
using System;
using UnityEngine;

namespace Assets.Scripts.SceneManagement
{
    public class SceneManager : MonoBehaviour, ISceneManager
    {
        public event Action<IGameData, IBaseData> EndStory;

        //Interface used by game manager

        public void SetupScene(IGameData gameData, IBaseData baseData)
        {
            //SetBackground(gameData, baseData);
            //SetProgressingItems(gameData, baseData);
            //SetInteractiveItems(gameData, baseData);
        }

        public void ShowIntro(IGameData gameData, IBaseData baseData)
        {
            //TODO
        }

        public void ShowStory(IStory story)
        {

        }

        //Private methods

        private void SetBackground(IGameData gameData, IBaseData baseData)
        {
            throw new NotImplementedException();
        }

        private void SetProgressingItems(IGameData gameData, IBaseData baseData)
        {
            throw new NotImplementedException();
        }

        private void SetInteractiveItems(IGameData gameData, IBaseData baseData)
        {
            throw new NotImplementedException();
        }
    }
}