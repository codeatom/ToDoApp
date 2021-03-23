using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Model;
using Xunit;

namespace ToDoApp.Tests.Model
{
    public class PersonTest
    {
        [Fact]
        public void PersonConstructionTest_TestForProperConstructionOfPersonObject()
        {
            //Arrange
            int personId = 1;
            string firstName = "Neri";
            string lastName = "Chris";

            //Act
            Person person = new Person(personId, firstName, lastName);

            //Assert
            Assert.Equal(personId, person.personId);
            Assert.Equal(firstName, person.FirstName);
            Assert.Equal(lastName, person.LastName);
        }

        [Fact]
        public void NullOrEmptyNameTest_TestThatNullOrEmptyStringsAreNotSaved()
        {
            //Arrange
            int personId = 1;
            string firstName = "";
            string lastName = null;
            Person person = new Person(personId, firstName, lastName);

            //Act
            string result1 = "No first name";
            string result2 = "No last name";

            //Assert
            Assert.Equal(personId, person.personId);
            Assert.Equal(result1, person.FirstName);
            Assert.Equal(result2, person.LastName);
        }
    }
}
