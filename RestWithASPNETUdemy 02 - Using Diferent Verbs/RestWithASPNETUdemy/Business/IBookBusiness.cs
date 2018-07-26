using System.Collections.Generic;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO book);
        BookVO GetById(long id);
        BookVO Update(BookVO book);
        List<BookVO> GetAll();
        void Delete(long id);
    }
}
