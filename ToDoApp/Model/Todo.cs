using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Model
{
    public class Todo
    {
        public readonly int todoId;
        private string description;
        private bool done;
        private Person assignee;

        public Todo(int TodoId, string Description)
        {
            this.todoId = TodoId;
            this.Description = Description;
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public bool Done
        {
            get
            {
                return done;
            }
            set
            {
                done = value;
            }

        }

        public Person Assignee
        {
            get
            {
                return assignee;
            }
            set
            {
                assignee = value;
            }
        }

    
    }
}
