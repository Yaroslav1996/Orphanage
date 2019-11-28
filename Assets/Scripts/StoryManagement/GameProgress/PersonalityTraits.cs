using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.StoryManagement.GameProgress
{
    public enum PersonalityType
    {
        Agressive,
        Passive,
        Perspective,
        Victim,
        Balanced
    }

    public class PersonalityTraits
    {
        public PersonalityTraits()
        {
            _agression = 25;
            _passivity = 25;
            _perspectiveness = 25;
            _victimness = 25;
        }

        //Every character trait is a value between 0 and 100
        //The sum of all traits must be equal to 100
        //Every factor adding to traits must substract from other traits the same amount

        private int _agression;
        private int _passivity;
        private int _perspectiveness;
        private int _victimness;

        public PersonalityType Personality
        {
            get
            {
                if (_agression > 50)
                    return PersonalityType.Agressive;

                if (_passivity > 50)
                    return PersonalityType.Passive;

                if (_perspectiveness > 50)
                    return PersonalityType.Perspective;

                if (_victimness > 50)
                    return PersonalityType.Victim;

                return PersonalityType.Balanced;
            }
        }

        public void ChangePersonality(int agression, int passivity, int perspectiveness, int victimness)
        {
            if ((agression + passivity + perspectiveness + victimness) != 0)
            {
                throw new Exception("Sum of trait value changes is not equal to 0");
            }

            _agression += agression;
            _passivity += passivity;
            _perspectiveness += perspectiveness;
            _victimness += victimness;
        }
    }
}
