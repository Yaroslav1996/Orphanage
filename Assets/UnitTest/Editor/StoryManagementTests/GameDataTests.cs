using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.StoryManagement.GameProgress;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Linq;

namespace StoryManagementTests
{
    public class GameDataTests
    {
        GameData _gameData;

        [SetUp]
        public void SetUp()
        {
            _gameData = new GameData();
        }

        [Test]
        public void AddPerson_IsCalledWithPersonel_AddsToPersonelList()
        {
            Person person = new Person();

            _gameData.AddPerson(person);

            Assert.That(_gameData.Personel.Contains(person));
        }
        
        [Test]
        public void AddPerson_IsCalledWithPersonel_AddsRelationsToNewPerson()
        {
            Person person1 = new Person();
            Person person2 = new Person();
            _gameData.AddPerson(person1);
            _gameData.AddPerson(person2);
            Person person3 = new Person();

            _gameData.AddPerson(person3);

            List<Person> relatedPeople = _gameData.Personel.Single(p => p.Equals(person3)).Relations.Select(p => p.Acquaintance).ToList();
            Assert.That(relatedPeople.Contains(person1) && relatedPeople.Contains(person2));
        }

        [Test]
        public void AddPerson_IsCalledWithPersonel_AddsRelationToOldPeople()
        {
            Person person1 = new Person();
            Person person2 = new Person();
            _gameData.AddPerson(person1);
            _gameData.AddPerson(person2);
            Person person3 = new Person();

            _gameData.AddPerson(person3);

            List<Person> person1related = _gameData.Personel.Single(p => p.Equals(person1)).Relations.Select(p => p.Acquaintance).ToList();
            List<Person> person2related = _gameData.Personel.Single(p => p.Equals(person2)).Relations.Select(p => p.Acquaintance).ToList();
            Assert.That(person1related.Contains(person3) && person2related.Contains(person3));
        }

        [Test]
        public void AddPerson_IsCalledWithOrphan_AddToOrphanList()
        {
            Orphan orphan = new Orphan();

            _gameData.AddPerson(orphan);

            Assert.That(_gameData.Orphans.Contains(orphan));
        }

        [Test]
        public void AddPerson_IsCalledWithOrphan_AddsRelationToNewOrphan()
        {
            Orphan orphan1 = new Orphan();
            Orphan orphan2 = new Orphan();
            _gameData.AddPerson(orphan1);
            _gameData.AddPerson(orphan2);
            Orphan orphan3 = new Orphan();

            _gameData.AddPerson(orphan3);

            List<Person> relatedPeople = _gameData.Orphans.Single(p => p.Equals(orphan3)).Relations.Select(p => p.Acquaintance).ToList();
            Assert.That(relatedPeople.Contains(orphan1) && relatedPeople.Contains(orphan2));
        }

        [Test]
        public void AddPerson_IsCalledWithOrphan_AddRelationsToOldOrphans()
        {
            Orphan orphan1 = new Orphan();
            Orphan orphan2 = new Orphan();
            _gameData.AddPerson(orphan1);
            _gameData.AddPerson(orphan2);
            Orphan orphan3 = new Orphan();

            _gameData.AddPerson(orphan3);

            List<Person> orphan1related = _gameData.Orphans.Single(p => p.Equals(orphan1)).Relations.Select(p => p.Acquaintance).ToList();
            List<Person> orphan2related = _gameData.Orphans.Single(p => p.Equals(orphan2)).Relations.Select(p => p.Acquaintance).ToList();
            Assert.That(orphan1related.Contains(orphan3) && orphan2related.Contains(orphan3));
        }

        [Test]
        public void AddPerson_IsCalledWithPerson_AddsRelationsWithOrphans()
        {
            Orphan orphan1 = new Orphan();
            Orphan orphan2 = new Orphan();
            _gameData.AddPerson(orphan1);
            _gameData.AddPerson(orphan2);
            Person person = new Person();

            _gameData.AddPerson(person);

            List<Person> relatedPeople = _gameData.Personel.Single(p => p.Equals(person)).Relations.Select(p => p.Acquaintance).ToList();
            Assert.That(relatedPeople.Contains(orphan1) && relatedPeople.Contains(orphan2));
        }

        [Test]
        public void AddPerson_IsCalledWithPerson_AddsRelationToOrphans()
        {
            Orphan orphan1 = new Orphan();
            Orphan orphan2 = new Orphan();
            _gameData.AddPerson(orphan1);
            _gameData.AddPerson(orphan2);
            Person person = new Person();

            _gameData.AddPerson(person);

            List<Person> orphan1related = _gameData.Orphans.Single(p => p.Equals(orphan1)).Relations.Select(p => p.Acquaintance).ToList();
            List<Person> orphan2related = _gameData.Orphans.Single(p => p.Equals(orphan2)).Relations.Select(p => p.Acquaintance).ToList();
            Assert.That(orphan1related.Contains(person) && orphan2related.Contains(person));
        }

        [Test]
        public void AddPerson_IsCalledWithOrphan_AddsRelationsWithPersonel()
        {
            Person person1 = new Person();
            Person person2 = new Person();
            _gameData.AddPerson(person1);
            _gameData.AddPerson(person2);
            Orphan orphan = new Orphan();

            _gameData.AddPerson(orphan);

            List<Person> relatedPeople = _gameData.Orphans.Single(p => p.Equals(orphan)).Relations.Select(p => p.Acquaintance).ToList();
            Assert.That(relatedPeople.Contains(person1) && relatedPeople.Contains(person2));
        }

        [Test]
        public void AddPerson_IsCalledWithOrphan_AddRelationsToPersonel()
        {
            Person person1 = new Person();
            Person person2 = new Person();
            _gameData.AddPerson(person1);
            _gameData.AddPerson(person2);
            Orphan orphan = new Orphan();

            _gameData.AddPerson(orphan);

            List<Person> person1related = _gameData.Personel.Single(p => p.Equals(person1)).Relations.Select(p => p.Acquaintance).ToList();
            List<Person> person2related = _gameData.Personel.Single(p => p.Equals(person2)).Relations.Select(p => p.Acquaintance).ToList();
            Assert.That(person1related.Contains(orphan) && person2related.Contains(orphan));
        }
    }
}
