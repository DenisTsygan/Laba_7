using System;
using System.Collections.Generic;

namespace Laba_7
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Person> persons =(List<Person>)FileManager.DeserializationFromJSON("persons.json", new List<Person>());
            var filteredPersons = FilterManagerPersons.SearchByField(persons, "Age", 66);
            foreach (var person in filteredPersons)
            {
                Console.WriteLine($"Id={person.Id} ; Age={person.Age} ; LastName={person.LastName}");
            }
            var filteredPersons_2 = FilterManagerPersons.SearchByField(filteredPersons, "LastName", "a");
            Console.WriteLine("Filter by two fields:");
            foreach (var person in filteredPersons_2)
            {
                Console.WriteLine($"Id={person.Id} ; Age={person.Age} ; LastName={person.LastName}");

            }
            int maxId = FilterManagerPersons.FindMaxValueByField(filteredPersons_2, "Id");
            int minId = FilterManagerPersons.FindMinValueByField(filteredPersons_2, "Id");
            double averageId = FilterManagerPersons.FindAverageValuebyField(filteredPersons_2, "Id");
            Console.WriteLine("max id=" + maxId);
            Console.WriteLine("min id=" + minId);
            Console.WriteLine("average id=" + averageId);
        }
    }
}
