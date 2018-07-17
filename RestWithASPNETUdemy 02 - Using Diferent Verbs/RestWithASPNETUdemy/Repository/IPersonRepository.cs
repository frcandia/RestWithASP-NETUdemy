using System.Collections.Generic;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Repository
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person GetById(long id);
        Person Update(Person person);
        List<Person> GetAll();
        void Delete(long id);

        bool Exists(long? id);
    }
}
