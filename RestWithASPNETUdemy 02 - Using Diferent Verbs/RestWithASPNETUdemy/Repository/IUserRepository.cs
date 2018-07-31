using System.Collections.Generic;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Repository
{
    public interface IUserRepository
    {
        User Create(User user);
        User GetById(long id);
        User Update(User user);
        List<User> GetAll();
        void Delete(long id);

        bool Exists(long? id);
        User FindByLogin(string login);
    }
}
