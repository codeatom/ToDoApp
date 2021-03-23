using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Model
{
    public class Person
    {
        public readonly int personId;
        private string firstName;
        private string lastName;

        public Person(int personId, string FirstName, string LastName)
        {
            this.personId = personId;
            this.FirstName = FirstName;
            this.LastName = LastName;
        }

        
        public string FirstName 
        { 
            get 
            {
                return firstName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    firstName = "No first name";
                }
                else
                {
                    firstName = value;
                }
                    
            } 
            
        } 
        
        public string LastName 
        {
            get
            {
                return lastName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    lastName = "No last name";
                }
                else
                {
                    lastName = value;
                }
                    
            }
        }
    }
}
