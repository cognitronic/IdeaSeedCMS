using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Persistence.Repositories;

namespace IdeaSeedCMS.Services
{
    public class UserServices
    {
        public User GetByID(int id)
        {
            return new UserRepository().GetByID(id, false);
        }

        public IList<User> GetPagedList(int startRow, int pageSize, out int count)
        {
            return new UserRepository()
                .GetPagedList(startRow, pageSize, out count)
                .OrderBy(o => o.Name)
                .ToList<User>(); ;
        }

        public IList<User> GetAll()
        {
            return new UserRepository()
                .GetAll()
                .OrderBy(o => o.Name)
                .ToList<User>(); ;
        }

        public User Save(User item)
        {
            return new UserRepository().SaveOrUpdate(item);
        }

        public void Delete(User item)
        {
            new UserRepository().Delete(item);
        }

        public User GetByEmail(string email)
        {
            return new UserRepository().GetByEmail(email);
        }

        public User GetByEmailPassword(string email, string password)
        {
            return new UserRepository().GetByEmailPassword(email, password);
        }

        public User GetByUsernamePassword(string username, string password)
        {
            return new UserRepository().GetByUserNamePassword(username, password);
        }

        public User GetByUserName(string username)
        {
            return new UserRepository().GetByUserName(username);
        }
    }
}
