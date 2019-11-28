using Assets.Scripts.DataManagement;
using Assets.Scripts.Managers;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.StoryManagement.TurnManagement
{
    public interface ITurnManager
    {
        List<IStory> ViableStories { get; set; }

        event Action EndTurn;

        void BeginTurn(IBaseData baseData, IGameData gameData);
        void GetViableStories(IBaseData baseData, IGameData gameData);
        void StartNextStory(IGameData gameData, IBaseData baseData);
    }
}