using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Model.Base;
using RestWithASPNETUdemy.Model.Context;

namespace RestWithASPNETUdemy.Repository.Generic
{
    public class GerenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MySQLContext _context;
        private readonly DbSet<T> _dataset;

        public GerenericRepository(MySQLContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                _dataset.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // ReSharper disable once PossibleIntendedRethrow
                throw ex;
            }

            return item;
        }

        public void Delete(long id)
        {
            var result = _dataset.SingleOrDefault(p => p.Id == id);

            try
            {
                if (result != null)
                    _dataset.Remove(result);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // ReSharper disable once PossibleIntendedRethrow
                throw ex;
            }
        }

        public bool Exists(long? id)
        {
            return _dataset.Any(p => p.Id == id);
        }

        public List<T> GetAll()
        {
            return _dataset.ToList();
        }

        public T GetById(long id)
        {
            return _dataset.SingleOrDefault(p => p.Id == id);
        }

        public T Update(T item)
        {
            if (!Exists(item.Id))
                return null;

            var result = _dataset.SingleOrDefault(p => p.Id == item.Id);

            try
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                _context.Entry(result).CurrentValues.SetValues(item);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // ReSharper disable once PossibleIntendedRethrow
                throw ex;
            }

            return result;
        }
    }
}
