using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWithASPNETUdemy.Model.Base;

namespace RestWithASPNETUdemy.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T GetById(long id);
        T Update(T item);
        List<T> GetAll();
        void Delete(long id);
        bool Exists(long? id);
    }
}
