using System;
using System.Collections.Generic;
using System.Linq;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repository;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class PersonBusinessImpl : IPersonBusiness
    {
        private readonly IPersonRepository _repository;

        public PersonBusinessImpl(IPersonRepository repository)
        {
            _repository = repository;
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public Person GetById(long id)
        {
            return _repository.GetById(id);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

        public List<Person> GetAll()
        {
            return _repository.GetAll();
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
