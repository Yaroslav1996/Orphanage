using Assets.Scripts.StoryManagement.GameProgress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.DataManagement.BaseDataCollections
{
    public class PersonelCollection
    {
        public PersonelCollection()
        {
            Secretary = new Person()
            {
                Name = "Janet",
                Surname = "Brown",
                Gender = Gender.Female
            };

            Janitor = new Person()
            {
                Name = "Frank",
                Surname = "Perkins",
                Gender = Gender.Male
            };
        }

        public Person Secretary { get; set; }
        public Person Janitor { get; set; }
    }
}
