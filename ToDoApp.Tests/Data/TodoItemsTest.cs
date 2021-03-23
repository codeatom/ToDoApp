using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Data;
using ToDoApp.Model;
using Xunit;

namespace ToDoApp.Tests.Data
{
    public class TodoItemsTest
    {
        [Fact]
        public void FindById_TestThatATodoObjectIsFoundAndReturnedUsingItsTodoId()
        {
            //Arrange
            string todo_1_description = "Code a calculator application";
            string todo_2_description = "Code a Todo application";

            TodoSequencer.reset();
            TodoItems todoItems = new TodoItems();
            Todo todo_1 = todoItems.CreateTodo(todo_1_description);
            Todo todo_2 = todoItems.CreateTodo(todo_2_description);

            Todo expected = todo_2;

            //Act
            Todo todo = todoItems.FindById(2);

            //Assert
            Assert.Equal(expected, todo);
        }

        [Fact]
        public void CreateTodo_TestThatATodoObjectIsCreatedAndReturned()
        {
            //Arrange
            int todo_1_TodoId = 1;
            string todo_1_description = "Code a calculator application";

            int todo_2_TodoId = 2;
            string todo_2_description = "Code a Todo application";

            TodoSequencer.reset();
            TodoItems todoItems = new TodoItems();

            //Act
            Todo todo_1 = todoItems.CreateTodo(todo_1_description);
            Todo todo_2 = todoItems.CreateTodo(todo_2_description);

            //Assert
            Assert.Equal(todo_1_TodoId, todoItems.FindAll()[0].todoId);
            Assert.Equal(todo_1_description, todoItems.FindAll()[0].Description);          

            Assert.Equal(todo_2_TodoId, todoItems.FindAll()[1].todoId);
            Assert.Equal(todo_2_description, todoItems.FindAll()[1].Description);
        }

        [Fact]
        public void Clear_TestThatPersonObjectsAreClearedFromPersonArray()
        {
            //Arrange
            string todo_1_description = "Code a calculator application";
            string todo_2_description = "Code a Todo application";

            int expected = 0;

            TodoSequencer.reset();
            TodoItems todoItems = new TodoItems();
            Todo todo_1 = todoItems.CreateTodo(todo_1_description);
            Todo todo_2 = todoItems.CreateTodo(todo_2_description);

            //Act
            todoItems.Clear();

            //Assert
            Assert.Equal(expected, todoItems.Size());
        }

        [Fact]
        public void FindByDoneStatus_TestThatATodoObjectIsFoundAndReturnedUsingItsDoneStatus()
        {
            //Arrange
            string todo_1_description = "Code a calculator application";
            bool todo_1_status = true;

            string todo_2_description = "Code a Todo application";
            bool todo_2_status = true;

            string todo_3_description = "Code a Hangman application";
            bool todo_3_status = false;

            TodoSequencer.reset();
            TodoItems todoItems = new TodoItems();

            Todo todo_1 = todoItems.CreateTodo(todo_1_description);
            todo_1.Done = todo_1_status;
            Todo todo_2 = todoItems.CreateTodo(todo_2_description);
            todo_2.Done = todo_2_status;
            Todo todo_3 = todoItems.CreateTodo(todo_3_description);
            todo_3.Done = todo_3_status;

            Todo[] expected = { todo_1, todo_2 };

            //Act
            Todo[] result = todoItems.FindByDoneStatus(true);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FindByAssignee_TestThatATodoObjectIsFoundAndReturnedUsingItsAssigneeId()
        {
            //Arrange
            string todo_1_description = "Code a calculator application";
            string todo_2_description = "Code a Todo application"; 
            string todo_3_description = "Code a Hangman application";

            string person_1_Firstname = "Neri";
            string person_1_Lastname = "Chris";
            string person_2_Firstname = "Joey";
            string person_2_Lastname = "Ken";

            TodoSequencer.reset();
            TodoItems todoItems = new TodoItems();
            People people = new People();

            Person person_1 = people.CreatePerson(person_1_Firstname, person_1_Lastname);
            Person person_2 = people.CreatePerson(person_2_Firstname, person_2_Lastname);

            Todo todo_1 = todoItems.CreateTodo(todo_1_description);
            todo_1.Assignee = person_1;

            Todo todo_2 = todoItems.CreateTodo(todo_2_description);
            todo_2.Assignee = person_1;

            Todo todo_3 = todoItems.CreateTodo(todo_3_description);
            todo_3.Assignee = person_2;

            Todo[] expected = { todo_1, todo_2 };

            //Act
            Todo[] result = todoItems.FindByAssignee(1);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FindByAssignee_TestThatATodoObjectIsFoundAndReturnedUsingItsAssignee()
        {
            //Arrange
            string todo_1_description = "Code a calculator application";
            string todo_2_description = "Code a Todo application";
            string todo_3_description = "Code a Hangman application";

            string person_1_Firstname = "Neri";
            string person_1_Lastname = "Chris";
            string person_2_Firstname = "Joey";
            string person_2_Lastname = "Ken";

            TodoSequencer.reset();
            TodoItems todoItems = new TodoItems();
            People people = new People();

            Person person_1 = people.CreatePerson(person_1_Firstname, person_1_Lastname);
            Person person_2 = people.CreatePerson(person_2_Firstname, person_2_Lastname);

            Todo todo_1 = todoItems.CreateTodo(todo_1_description);
            todo_1.Assignee = person_1;

            Todo todo_2 = todoItems.CreateTodo(todo_2_description);
            todo_2.Assignee = person_2;

            Todo todo_3 = todoItems.CreateTodo(todo_3_description);
            todo_3.Assignee = person_2;

            Todo[] expected = { todo_2, todo_3 };

            //Act
            Todo[] result = todoItems.FindByAssignee(person_2);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FindByAssignee_TestThatATodoObjectWithNoAssigneeIsFoundAndReturned()
        {
            //Arrange
            string todo_1_description = "Code a calculator application";
            string todo_2_description = "Code a Todo application";
            string todo_3_description = "Code a Hangman application";

            string person_1_Firstname = "Neri";
            string person_1_Lastname = "Chris";
            string person_2_Firstname = "Joey";
            string person_2_Lastname = "Ken";

            TodoSequencer.reset();
            TodoItems todoItems = new TodoItems();
            People people = new People();

            Person person_1 = people.CreatePerson(person_1_Firstname, person_1_Lastname);
            Person person_2 = people.CreatePerson(person_2_Firstname, person_2_Lastname);

            Todo todo_1 = todoItems.CreateTodo(todo_1_description);
            todo_1.Assignee = null;

            Todo todo_2 = todoItems.CreateTodo(todo_2_description);
            todo_2.Assignee = person_2;

            Todo todo_3 = todoItems.CreateTodo(todo_3_description);
            todo_3.Assignee = person_2;

            Todo[] expected = { todo_1 };

            //Act
            Todo[] result = todoItems.FindByAssignee(null);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void RemoveArrElement_TestThatAGivenObjectIsDeletedFromTheArray()
        {
            //Arrange          
            string todo_1_description = "Code a calculator application";
            string todo_2_description = "Code a Todo application";
            string todo_3_description = "Code a Hangman application";
            string todo_4_description = "Test calculator application";
            string todo_5_description = "Test Todo application";

            TodoSequencer.reset();
            TodoItems todoItems = new TodoItems();

            Todo todo_1 = todoItems.CreateTodo(todo_1_description);
            Todo todo_2 = todoItems.CreateTodo(todo_2_description);
            Todo todo_3 = todoItems.CreateTodo(todo_3_description);
            Todo todo_4 = todoItems.CreateTodo(todo_4_description);
            Todo todo_5 = todoItems.CreateTodo(todo_5_description);

            Todo[] result = {todo_1, todo_3, todo_4, todo_5};

            //Act
            todoItems.RemoveArrElement(todo_2);

            //Assert
            Assert.Equal(result, todoItems.FindAll());
        }
    }
}
