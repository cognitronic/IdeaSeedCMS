using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using IdeaSeed.Core.Data.NHibernate;
using IdeaSeedCMS.Core.Domain;

namespace IdeaSeedCMS.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User, int>
    {
        public User GetByEmail(string email)
        {
            return Session.CreateCriteria<User>()
                .Add(Expression.Eq("Email", email))
                .UniqueResult<User>();
        }

        public User GetByEmailPassword(string email, string password)
        {
            return Session.CreateCriteria<User>()
                .Add(Expression.Eq("Email", email))
                .Add(Expression.Eq("Password", password))
                .UniqueResult<User>();
        }

        public User GetByUserName(string username)
        {
            return Session.CreateCriteria<User>()
                .Add(Expression.Eq("Email", username))
                .UniqueResult<User>();
        }

        public User GetByUserNamePassword(string username, string password)
        {
            return Session.CreateCriteria<User>()
                .Add(Expression.Eq("Email", username))
                .Add(Expression.Eq("Password", password))
                .UniqueResult<User>();
        }
    }
}
