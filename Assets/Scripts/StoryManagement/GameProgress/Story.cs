using Assets.Scripts.DataManagement;
using Assets.Scripts.Managers;
using Assets.Scripts.StoryManagement.GameProgress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.StoryManagement
{
    public class Story : IStory
    {
        public Person Main { get; set; }
        public Person Second { get; set; }
        public Person Third { get; set; }

        public DialogSequence Dialog { get; set; }

        public string RequirementsKey { get; set; }
        public string ResultKey { get; set; }

        public bool IsDone { get; set; }

        public bool CanHappen(IBaseData baseData, IGameData gameData)
        {
            return baseData.CheckStoryRequirements(RequirementsKey, gameData);
        }

    }
}