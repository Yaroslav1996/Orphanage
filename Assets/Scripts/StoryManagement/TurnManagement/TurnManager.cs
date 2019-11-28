using Assets.Scripts.DataManagement;
using Assets.Scripts.Managers;
using Assets.Scripts.SceneManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StoryManagement.TurnManagement
{
    public class TurnManager : ITurnManager
    {
        public TurnManager(ISceneManager sceneManager)
        {
            ViableStories = new List<IStory>();
            this.sceneManager = sceneManager;
        }

        public List<IStory> ViableStories { get; set; }

        public event Action EndTurn;

        private readonly ISceneManager sceneManager;

        
        public void GetViableStories(IBaseData baseData, IGameData gameData)
        {
            foreach(var story in baseData.BaseStories)
            {
                if (story.CanHappen(baseData, gameData) && !story.IsDone)
                {
                    ViableStories.Add(story);
                }
            }
        }

        public void BeginTurn(IBaseData baseData, IGameData gameData)
        {
            sceneManager.EndStory += EndStory;
            StartNextStory(gameData, baseData);
        }

        public void StartNextStory(IGameData gameData, IBaseData baseData)
        {
            sceneManager.SetupScene(gameData, baseData);

            try
            {
                IStory story = ViableStories.First(p => !p.IsDone);
                sceneManager.ShowStory(story);
            }
            catch(InvalidOperationException)
            {
                EndTurn();
            }
        }

        private void EndStory(IGameData gameData, IBaseData baseData)
        {
            int storiesLeft = ViableStories.Where(p => !p.IsDone).ToList().Count;

            if (storiesLeft > 0)
            {
                StartNextStory(gameData, baseData);
            }
            else
            {
                EndTurn();
            }
        }
    }
}
