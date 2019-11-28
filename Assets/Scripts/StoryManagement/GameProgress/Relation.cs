using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.StoryManagement.GameProgress
{
    public class Relation
    {
        public Relation(Person person)
        {
            Acquaintance = person;
        }

        public Person Acquaintance { get; set; }

        /// <summary>
        /// Describes how relation owner sees the acquaintance, values between -100 and 100
        /// </summary>
        public int Friendship { get; set; }
        public int Respect { get; set; }
    }
}
