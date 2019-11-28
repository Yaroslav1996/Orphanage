using NUnit.Framework;
using System.Collections;
using System.Linq;
using UnityEngine.TestTools;
using Assets.Scripts.StoryManagement.GameProgress;

namespace StoryManagementTests.GameProgressTests
{
    public class PersonTests
    {
        private Person _person;

        [SetUp]
        public void SetUp()
        {
            _person = new Person();
        }

        [Test]
        public void AddRelation_IsCalled_AddsRelation()
        {
            Person newPerson = new Person();
            _person.AddRelation(newPerson);


            Assert.That(_person.Relations.Single().Acquaintance.Equals(newPerson));
        }
    }
}
