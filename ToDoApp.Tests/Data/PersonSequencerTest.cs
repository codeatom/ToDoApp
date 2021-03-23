using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Data;
using ToDoApp.Model;
using Xunit;

namespace ToDoApp.Tests.Data
{
    public class PersonSequencerTest
    {
        [Fact]
        public void nextPersonIdTest_TestThatPersonIdIsIncrementedAndReturned()
        {
            //Arrange
            int expected = 1;
            PersonSequencer.reset();

            //Act          
            int result = PersonSequencer.nextPersonId();

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void resetTest_TestThatPersonIdIsResetToZero()
        {
            //Arrange
            int expected = 1;
            PersonSequencer.reset();

            //Act
            PersonSequencer.nextPersonId();
            PersonSequencer.nextPersonId();
            PersonSequencer.nextPersonId();
            PersonSequencer.reset();

            //Assert
            Assert.Equal(expected, PersonSequencer.nextPersonId());
        }
    }
}
