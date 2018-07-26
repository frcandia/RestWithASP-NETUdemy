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
    public class BookBusinessImpl : IBookBusiness
    {
        private readonly IRepository<Book> _repository;
        private readonly BookConverter _converter;

        public BookBusinessImpl(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }

        public BookVO Create(BookVO book)
        {
            var entity = _converter.Parse(book);
            entity = _repository.Create(entity);

            return _converter.Parse(entity);
        }

        public BookVO GetById(long id)
        {
            return _converter.Parse(_repository.GetById(id));
        }

        public BookVO Update(BookVO book)
        {
            var entity = _converter.Parse(book);
            entity = _repository.Update(entity);

            return _converter.Parse(entity);
        }

        public List<BookVO> GetAll()
        {
            return _converter.ParseList(_repository.GetAll());
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
