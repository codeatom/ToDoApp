using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Model;

namespace ToDoApp.Data
{
    public class TodoItems
    {
        private static Todo[] todoArr = new Todo[0];

        public int Size()
        {
            return todoArr.Length;
        }

        public Todo[] FindAll()
        {
            return todoArr;
        }

        public Todo FindById(int todoId)
        {
            foreach (Todo todo in todoArr)
            {
                if (todo.todoId == todoId)
                {
                    return todo;
                }       
            }

            return null;
        }

        public Todo CreateTodo(string description)
        {
            bool idIsNotAvailable = true;
            int nextAvailableId = 0;
            int newTodoArrIndex = 0;
            Todo newTodo = null;

            if (todoArr.Length == 0)
            {
                TodoSequencer.reset();
                nextAvailableId = TodoSequencer.nextTodoId();
                newTodo = new Todo(nextAvailableId, description);
            }
            else
            {
                while (idIsNotAvailable)
                {
                    nextAvailableId = PersonSequencer.nextPersonId();

                    foreach (Todo todo in todoArr)
                    {
                        if (todo.todoId == nextAvailableId)
                        {
                            idIsNotAvailable = true;
                            break;
                        }
                        else
                        {
                            idIsNotAvailable = false;
                        }
                    }
                }

                newTodo = new Todo(nextAvailableId, description);
            }

            Array.Resize(ref todoArr, todoArr.Length + 1);
            newTodoArrIndex = todoArr.Length - 1;
            todoArr[newTodoArrIndex] = newTodo;
            return newTodo;
        }

        public void Clear()
        {
            Array.Resize(ref todoArr, 0);
        }

        public Todo[] FindByDoneStatus(bool doneStatus)
        {
            Todo[] completed = new Todo[0];

            foreach (Todo todo in todoArr)
            {
                if (todo.Done == true)
                {
                    Array.Resize(ref completed, completed.Length+1);
                    completed[completed.Length - 1] = todo;
                }                    
            }

            return completed;
        }

        public Todo[] FindByAssignee(int personId)
        {
            Todo[] assignee = new Todo[0];

            foreach (Todo todo in todoArr)
            {
                if (todo.Assignee.personId == personId)
                {
                    Array.Resize(ref assignee, assignee.Length + 1);
                    assignee[assignee.Length - 1] = todo;
                }
            }

            return assignee;
        }

        public Todo[] FindByAssignee(Person assignee)
        {
            Todo[] assigned = new Todo[0];

            foreach (Todo todo in todoArr)
            {
                if (todo.Assignee == assignee)
                {
                    Array.Resize(ref assigned, assigned.Length + 1);
                    assigned[assigned.Length - 1] = todo;
                }
            }

            return assigned;
        }

        public Todo[] FindUnassignedTodoItems()
        {
            Todo[] unAssigneed= new Todo[0];

            foreach (Todo todo in todoArr)
            {
                if (todo.Assignee == null)
                {
                    Array.Resize(ref unAssigneed, unAssigneed.Length + 1);
                    unAssigneed[unAssigneed.Length - 1] = todo;
                }
            }

            return unAssigneed;
        }

        public void RemoveArrElement(Todo todo)
        {
            int index = 0;

            for (int i = 0; i<todoArr.Length; i++)
            {
                if (todoArr[i] == todo)
                {
                    index = i;
                    break;
                }                  
            }

            for (int i=index; i<todoArr.Length-1; i++)
            {
                todoArr[i] = todoArr[i + 1];
            }               

            Array.Resize(ref todoArr, todoArr.Length - 1);
        }
    }
}
