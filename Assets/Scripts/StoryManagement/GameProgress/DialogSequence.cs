using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.StoryManagement.GameProgress
{
    public class DialogSequence
    {
        public DialogSequence()
        {
            Dialogs = new List<Dialog>();
            Options = new List<Option>();
        }

        public List<Dialog> Dialogs { get; set; }
        public List<Option> Options { get; set; }

        public Option ChosenOption { get; set; }
    }
}
