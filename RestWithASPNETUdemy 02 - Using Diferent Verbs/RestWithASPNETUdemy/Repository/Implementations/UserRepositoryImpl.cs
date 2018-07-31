using System;
using System.Collections.Generic;
using System.Linq;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public class UserRepositoryImpl : IUserRepository
    {
        private readonly MySQLContext _context;

        public UserRepositoryImpl(MySQLContext context)
        {
            _context = context;
        }

        public User Create(User user)
        {
            try
            {
                _context.Add(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // ReSharper disable once PossibleIntendedRethrow
                throw ex;
            }

            return user;
        }

        public User GetById(long id)
        {
            return _context.Users.SingleOrDefault(p => p.Id == id);
        }

        public User Update(User user)
        {
            if (!Exists(user.Id))
                return null;

            var result = _context.Users.SingleOrDefault(p => p.Id == user.Id);

            try
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                _context.Entry(result).CurrentValues.SetValues(user);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // ReSharper disable once PossibleIntendedRethrow
                throw ex;
            }

            return result;
        }

        public bool Exists(long? id)
        {
            return _context.Users.Any(p => p.Id == id);
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public void Delete(long id)
        {
            var result = _context.Users.SingleOrDefault(p => p.Id == id);

            try
            {
                if (result != null)
                    _context.Users.Remove(result);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // ReSharper disable once PossibleIntendedRethrow
                throw ex;
            }
        }

        public User FindByLogin(string login)
        {
            return _context.Users.SingleOrDefault(w => w.Login.Equals(login));
        }
    }
}
