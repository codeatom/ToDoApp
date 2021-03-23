using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Data;
using ToDoApp.Model;
using Xunit;

namespace ToDoApp.Tests.Model
{
    public class TodoTest
    {
        [Fact]
        public void TodoConstructionTest_TestForProperConstructionOfTodoObject()
        {
            //Arrange
            int todoId = 1;
            string description = "Description of todo_1";
            TodoSequencer.reset();

            //Act
            Todo todo = new Todo(todoId, description);

            //Assert
            Assert.Equal(todoId, todo.todoId);
            Assert.Equal(description, todo.Description);

        }
    }
}
