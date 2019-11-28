using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.StoryManagement.GameProgress
{
    public enum TalkingPerson
    {
        Main,
        Second,
        Third
    }

    public class Dialog
    {
        public string Text { get; set; }
        public TalkingPerson Talker { get; set; }
    }
}
