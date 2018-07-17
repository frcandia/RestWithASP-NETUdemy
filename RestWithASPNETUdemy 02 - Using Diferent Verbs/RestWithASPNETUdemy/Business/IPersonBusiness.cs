using System.Collections.Generic;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Business
{
    public interface IPersonBusiness
    {
        Person Create(Person person);
        Person GetById(long id);
        Person Update(Person person);
        List<Person> GetAll();
        void Delete(long id);
    }
}
