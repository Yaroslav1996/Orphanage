using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.StoryManagement.GameProgress
{
    public enum Gender
    {
        Male,
        Female
    }

    public class Person
    {
        public Person()
        {
            Relations = new List<Relation>();
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        //look

        public List<Relation> Relations { get; set; }


        public void AddRelation(Person person)
        {
            Relation relation = new Relation(person);
            Relations.Add(relation);
        }
    }
}
