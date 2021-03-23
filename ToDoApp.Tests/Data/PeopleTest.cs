using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Data;
using ToDoApp.Model;
using Xunit;

namespace ToDoApp.Tests.Data
{
    public class PeopleTest
    {
        [Fact]
        public void FindById_TestThatAPersonObjectIsFoundAndReturnedUsingItsPersonId()
        {
            //Arrange
            string person_1_Firstname = "Neri";
            string person_1_Lastname = "Chris";

            string person_2_Firstname = "Joey";
            string person_2_Lastname = "Ken";

            People people = new People();
            Person person_1 = people.CreatePerson(person_1_Firstname, person_1_Lastname);
            Person person_2 = people.CreatePerson(person_2_Firstname, person_2_Lastname);

            Person expected = person_2;

            //Act
            Person person = people.FindById(2);

            //Assert
            Assert.Equal(expected, person);
        }

        [Fact]
        public void CreatePerson_TestThatAPersonObjectIsCreatedAndReturned()
        {
            //Arrange
            int person_1_PersonId = 1;
            string person_1_Firstname = "Neri";
            string person_1_Lastname = "Chris";

            int person_2_PersonId = 2;
            string person_2_Firstname = "Joey";
            string person_2_Lastname = "Ken";

            People people = new People();

            //Act
            Person person_1 = people.CreatePerson(person_1_Firstname, person_1_Lastname);
            Person person_2 = people.CreatePerson(person_2_Firstname, person_2_Lastname);

            //Assert
            Assert.Equal(person_1_PersonId, people.FindAll()[0].personId);
            Assert.Equal(person_1_Firstname, people.FindAll()[0].FirstName);
            Assert.Equal(person_1_Lastname, people.FindAll()[0].LastName);

            Assert.Equal(person_2_PersonId, people.FindAll()[1].personId);
            Assert.Equal(person_2_Firstname, people.FindAll()[1].FirstName);
            Assert.Equal(person_2_Lastname, people.FindAll()[1].LastName);
        }

        [Fact]
        public void Clear_TestThatPersonObjectsAreClearedFromPersonArray()
        {
            //Arrange
            string person_1_Firstname = "Neri";
            string person_1_Lastname = "Chris";

            string person_2_Firstname = "Joey";
            string person_2_Lastname = "Ken";

            int expected = 0;

            People people = new People();
            Person person_1 = people.CreatePerson(person_1_Firstname, person_1_Lastname);
            Person person_2 = people.CreatePerson(person_2_Firstname, person_2_Lastname);

            //Act
            people.Clear();

            //Assert
            Assert.Equal(expected, people.Size());
        }

        [Fact]
        public void RemoveArrElement_TestThatAGivenObjectIsDeletedFromTheArray()
        {
            //Arrange
            string person_1_Firstname = "Neri";
            string person_1_Lastname = "Chris";
            string person_2_Firstname = "Joey";
            string person_2_Lastname = "Ken";
            string person_3_Firstname = "Akon";
            string person_3_Lastname = "Akon";

            PersonSequencer.reset();
            People people = new People();

            Person person_1 = people.CreatePerson(person_1_Firstname, person_1_Lastname);
            Person person_2 = people.CreatePerson(person_2_Firstname, person_2_Lastname);
            Person person_3 = people.CreatePerson(person_3_Firstname, person_3_Lastname);

            Person[] result = { person_1, person_3,};

            //Act
            people.RemoveArrElement(person_2);

            //Assert
            Assert.Equal(result, people.FindAll());
        }
    }
}
