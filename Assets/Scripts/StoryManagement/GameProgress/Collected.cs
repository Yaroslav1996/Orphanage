using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.StoryManagement.GameProgress
{
    public class Collected
    {
        public int Money { get; set; }

        /// <summary>
        /// How good players choices were, between -100 and 100
        /// </summary>
        public int GoodMeter { get; set; }
    }
}
