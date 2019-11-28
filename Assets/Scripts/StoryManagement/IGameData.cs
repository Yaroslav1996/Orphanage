using System.Collections.Generic;
using Assets.Scripts.StoryManagement;
using Assets.Scripts.StoryManagement.GameProgress;

namespace Assets.Scripts.Managers
{
    public interface IGameData
    {
        Collected CollectedValues { get; set; }
        List<Orphan> Orphans { get; }
        List<Person> Personel { get; }
        string SaveName { get; set; }
        List<IStory> Stories { get; set; }
        int TurnNumber { get; set; }

        void AddPerson(Orphan orphan);
        void AddPerson(Person person);
    }
}