using Assets.Scripts.DataManagement;
using Assets.Scripts.Managers;
using Assets.Scripts.StoryManagement.GameProgress;

namespace Assets.Scripts.StoryManagement
{
    public interface IStory
    {
        string RequirementsKey { get; set; }
        string ResultKey { get; set; }
        Person Main { get; set; }
        Person Second { get; set; }
        Person Third { get; set; }
        DialogSequence Dialog { get; set; }
        bool IsDone { get; set; }

        bool CanHappen(IBaseData baseData, IGameData gameData);
    }
}