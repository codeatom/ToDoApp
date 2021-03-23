using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Data
{
    public class TodoSequencer
    {
        private static int todoId;

        public static int nextTodoId()
        {
            return ++todoId;
        }

        public static void reset()
        {
            todoId = 0;
        }
    }
}
