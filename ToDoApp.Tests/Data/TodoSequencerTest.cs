using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Data;
using ToDoApp.Model;
using Xunit;

namespace ToDoApp.Tests.Data
{
    public class TodoSequencerTest
    {
        [Fact]
        public void nextTodoIdTest_TestThatTodoIdIsIncrementedAndReturned()
        {
            //Arrange
            int expected = 1;

            //Act
            TodoSequencer.reset();
            int result = TodoSequencer.nextTodoId();

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void resetTest_TestThatTodoIdIsResetToZero()
        {
            //Arrange
            int expected = 1;

            //Act
            TodoSequencer.nextTodoId();
            TodoSequencer.nextTodoId();
            TodoSequencer.nextTodoId();
            TodoSequencer.reset();

            //Assert
            Assert.Equal(expected, TodoSequencer.nextTodoId());
        }
    }
}
