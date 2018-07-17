using System;
using System.Collections.Generic;
using System.Linq;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public class PersonRepositoryImpl : IPersonRepository
    {
        private readonly MySQLContext _context;

        public PersonRepositoryImpl(MySQLContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // ReSharper disable once PossibleIntendedRethrow
                throw ex;
            }

            return person;
        }

        public Person GetById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id == id);
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id))
                return null;

            var result = _context.Persons.SingleOrDefault(p => p.Id == person.Id);

            try
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                _context.Entry(result).CurrentValues.SetValues(person);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // ReSharper disable once PossibleIntendedRethrow
                throw ex;
            }

            return result;
        }

        public bool Exists(long? id)
        {
            return _context.Persons.Any(p => p.Id == id);
        }

        public List<Person> GetAll()
        {
            return _context.Persons.ToList();
        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id == id);

            try
            {
                if (result != null)
                    _context.Persons.Remove(result);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // ReSharper disable once PossibleIntendedRethrow
                throw ex;
            }
        }
    }
}
