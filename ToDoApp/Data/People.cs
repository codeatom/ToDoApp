using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Model;

namespace ToDoApp.Data
{
    public class People
    {
        private static Person[] persons = new Person[0];

        public int Size()
        {
            return persons.Length;
        }

        public Person[] FindAll()
        {
            return persons;
        }

        public Person FindById(int personId)
        {
            foreach (Person person in persons)
            {
                if (person.personId == personId)
                {
                    return person;
                }    
            }

            return null;
        }

        public Person CreatePerson(string firstName, string lastName)
        {           
            bool idIsNotAvailable = true;
            int nextAvailableId = 0;
            int newPersonArrIndex = 0;
            Person newPerson = null;

            if (persons.Length == 0)
            {
                PersonSequencer.reset();
                nextAvailableId = PersonSequencer.nextPersonId();
                newPerson = new Person(nextAvailableId, firstName, lastName);
            }
            else
            {            
                while (idIsNotAvailable)
                {
                    nextAvailableId = PersonSequencer.nextPersonId();

                    foreach (Person person in persons)
                    {
                        if (person.personId == nextAvailableId)
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

                newPerson = new Person(nextAvailableId, firstName, lastName);
            }

            Array.Resize(ref persons, persons.Length + 1);
            newPersonArrIndex = persons.Length - 1;
            persons[newPersonArrIndex] = newPerson;
            return newPerson;
        }

        public void Clear()
        {
            Array.Resize(ref persons, 0);
        }

        public void RemoveArrElement(Person person)
        {
            int index = 0;

            for (int i = 0; i < persons.Length; i++)
            {
                if (persons[i].Equals(person))
                {
                    index = i;
                    break;
                }                    
            }

            for (int i = index; i < persons.Length - 1; i++)
            {
                persons[i] = persons[i + 1];
            }
                
            Array.Resize(ref persons, persons.Length - 1);
        }
    }
}
