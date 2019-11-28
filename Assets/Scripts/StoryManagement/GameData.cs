using Assets.Scripts.StoryManagement;
using Assets.Scripts.StoryManagement.GameProgress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    [Serializable]
    public class GameData : IGameData
    {
        public GameData()
        {
            Personel = new List<Person>();
            Orphans = new List<Orphan>();
            Stories = new List<IStory>();
            TurnNumber = 0;
        }

        public string SaveName { get; set; }
        public List<IStory> Stories { get; set; }
        public Collected CollectedValues { get; set; }
        public List<Person> Personel { get; private set; }
        public List<Orphan> Orphans { get; private set; }
        public int TurnNumber { get; set; }

        public void AddPerson(Person person)
        {
            Personel.Add(person);

            foreach (Person p in Personel)
            {
                p.AddRelation(person);
                person.AddRelation(p);
            }

            foreach (Orphan o in Orphans)
            {
                o.AddRelation(person);
                person.AddRelation(o);
            }
        }

        public void AddPerson(Orphan orphan)
        {
            Orphans.Add(orphan);

            foreach (Person p in Personel)
            {
                p.AddRelation(orphan);
                orphan.AddRelation(p);
            }

            foreach (Orphan o in Orphans)
            {
                o.AddRelation(orphan);
                orphan.AddRelation(o);
            }
        }
    }
}
