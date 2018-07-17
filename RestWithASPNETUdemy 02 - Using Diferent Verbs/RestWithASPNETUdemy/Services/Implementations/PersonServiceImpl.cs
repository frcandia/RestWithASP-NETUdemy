using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Services.Implementations
{
    public class PersonServiceImpl : IPersonService
    {
        private volatile int _count;

        public Person Create(Person person)
        {
            return person;
        }

        public Person GetById(long id)
        {
            return new Person()
            {
                Id = id,
                FirstName = "Fábio",
                LastName = "Candiá",
                Address = "Juiz de Fora - MG - Brasil",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        public List<Person> GetAll()
        {
            var persons = new List<Person>();

            for (var i = 0; i < 8; i++)
            {
                var person = MockPerson(i);
                persons.Add(person);
            }

            return persons;
        }

        private Person MockPerson(int i)
        {
            return new Person()
            {
                Id = IncrementAndGet(),
                FirstName = $"Person Name {i}",
                LastName = $"Person LastName {i}",
                Address = $"Some Address {i}",
                Gender = "Male"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref _count);
        }

        public void Delete(long id)
        {
        }
    }
}
