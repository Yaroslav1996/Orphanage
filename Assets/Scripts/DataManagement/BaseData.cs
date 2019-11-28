using Assets.Scripts.DataManagement.BaseDataCollections;
using Assets.Scripts.Managers;
using Assets.Scripts.StoryManagement;
using Assets.Scripts.StoryManagement.GameProgress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.DataManagement
{
    public class BaseData : IBaseData
    {
        public BaseData()
        {
            Requirements = new Dictionary<string, Func<IGameData, bool>>();
            BaseOrphans = new List<Orphan>();
            BaseStories = new List<IStory>();
        }

        /// <summary>
        /// Data loaded by SaveLoad
        /// </summary>
        public List<Orphan> BaseOrphans { get; set; }

        /// <summary>
        /// Data loaded by SaveLoad
        /// </summary>
        public List<IStory> BaseStories { get; set; }
        
        /// <summary>
        /// Hardcoded data
        /// </summary>
        public Dictionary<string, Func<IGameData, bool>> Requirements { get; set; }

        public PersonelCollection Personel { get; set; }

        //look dictionaries
        public bool CheckStoryRequirements(string storyKey, IGameData gameData)
        {
            var requirement = Requirements[storyKey];
            return requirement(gameData);
        }
    }
}
