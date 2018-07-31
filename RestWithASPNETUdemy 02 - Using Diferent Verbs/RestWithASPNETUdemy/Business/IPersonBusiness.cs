using System.Collections.Generic;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO GetById(long id);
        PersonVO Update(PersonVO person);
        List<PersonVO> GetAll();
        void Delete(long id);
        List<PersonVO> FindByName(string firstName, string lastName);
    }
}
