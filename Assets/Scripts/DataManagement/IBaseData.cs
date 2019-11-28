using System.Collections.Generic;
using System;
using Assets.Scripts.StoryManagement.GameProgress;
using Assets.Scripts.StoryManagement;
using Assets.Scripts.Managers;

namespace Assets.Scripts.DataManagement
{
    public interface IBaseData
    {
        Dictionary<string, Func<IGameData, bool>> Requirements { get; set; }
        List<Orphan> BaseOrphans { get; set; }
        List<IStory> BaseStories { get; set; }

        bool CheckStoryRequirements(string storyKey, IGameData gameData);
    }
}