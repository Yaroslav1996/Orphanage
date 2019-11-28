using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.StoryManagement.GameProgress
{
    public class History
    {
        public History()
        {
            Chapters = new List<string>();
        }

        public Orphan Owner { get; set; }
        public string Father { get; set; }
        public string Mother { get; set; }
        public int BirthYear { get; set; }
        public DateTime BirthDate { get; set; }
        public List<string> Chapters { get; set; }
    }
}
