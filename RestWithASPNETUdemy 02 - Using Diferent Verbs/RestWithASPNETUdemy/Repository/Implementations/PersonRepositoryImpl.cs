using System;
using System.Collections.Generic;
using System.Linq;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repository.Generic;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public class PersonRepositoryImpl : GerenericRepository<Person>, IPersonRepository
    {
        public PersonRepositoryImpl(MySQLContext context) : base(context) { }

        public List<Person> FindByName(string firstName, string lastName)
        {
            if (!String.IsNullOrEmpty(firstName) && !String.IsNullOrEmpty(lastName))
                return Context.Persons.Where(w => w.FirstName.Contains(firstName) && w.LastName.Contains(lastName)).ToList();

            if (!String.IsNullOrEmpty(firstName))
                return Context.Persons.Where(w => w.FirstName.Contains(firstName)).ToList();

            if (!String.IsNullOrEmpty(lastName))
                return Context.Persons.Where(w => w.LastName.Contains(lastName)).ToList();

            return GetAll();
        }
    }
}
