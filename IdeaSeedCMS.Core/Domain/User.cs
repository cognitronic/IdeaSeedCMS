using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;
using IdeaSeedCMS.Core.Domain.Interfaces;

namespace IdeaSeedCMS.Core.Domain
{
    [Serializable]
    public class User : IUser
    {
        public virtual int ID { get; set; }
        public virtual string Description { get; set; }
        public virtual string UserName { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual int EnteredBy { get; set; }
        public virtual int ChangedBy { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime LastUpdated { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual string PasswordAnswer { get; set; }
        public virtual string PasswordQuestion { get; set; }
        public virtual DateTime PasswordLastChangedDate { get; set; }
        public virtual DateTime LastLoginDate { get; set; }
        public virtual string Name { get; set; }
        public virtual bool MarkedForDeletion { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual object ItemReference { get; set; }
        public virtual string URL { get; set; }
        public virtual ItemType TypeOfItem { get; set; }
        public virtual string SEOTitle { get; set; }
        public virtual int AccessLevel { get; set; }
        public virtual string SEOKeywords { get; set; }
        public virtual string SEODescription { get; set; }

        //public User()
        //{
        //    this.TypeOfItem = ItemType.USER;
        //}
    }
}
