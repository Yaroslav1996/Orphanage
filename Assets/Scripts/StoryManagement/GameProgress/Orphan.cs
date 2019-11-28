using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.StoryManagement.GameProgress
{
    public class Orphan : Person
    {
        private History pastHistory;

        public PersonalityTraits Personality { get; set; }
        public History PastHistory 
        { 
            get => pastHistory;
            set
            {
                pastHistory = value;
                pastHistory.Owner = this;
            }
        }


    }
}
