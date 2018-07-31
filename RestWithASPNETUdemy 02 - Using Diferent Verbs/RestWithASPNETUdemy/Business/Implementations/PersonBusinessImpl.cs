using System;
using System.Collections.Generic;
using System.Linq;
using RestWithASPNETUdemy.Data.Converters;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repository;
using RestWithASPNETUdemy.Repository.Generic;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class PersonBusinessImpl : IPersonBusiness
    {
        private readonly IPersonRepository _repository;
        private readonly PersonConverter _converter;

        public PersonBusinessImpl(IPersonRepository repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        public PersonVO Create(PersonVO person)
        {
            var entity = _converter.Parse(person);
            entity = _repository.Create(entity);

            return _converter.Parse(entity);
        }

        public PersonVO GetById(long id)
        {
            return _converter.Parse(_repository.GetById(id));
        }

        public PersonVO Update(PersonVO person)
        {
            var entity = _converter.Parse(person);
            entity = _repository.Update(entity);

            return _converter.Parse(entity);
        }

        public List<PersonVO> GetAll()
        {
            return _converter.ParseList(_repository.GetAll());
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<PersonVO> FindByName(string firstName, string lastName)
        {
            return _converter.ParseList(_repository.FindByName(firstName, lastName));
        }
    }
}

