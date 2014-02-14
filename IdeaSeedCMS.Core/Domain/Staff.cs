using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core;
using IdeaSeedCMS.Core.Domain.Interfaces;

namespace IdeaSeedCMS.Core.Domain
{
    [Serializable]
    public class Staff : IStaff
    {
        public virtual int ID { get; set; }
        public virtual string Description { get; set; }
        public virtual string Bio { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string Title { get; set; }
        public virtual string AvatarPath{ get; set; }
        public virtual string Email { get; set; }
        public virtual string Name { get; set; }
        public virtual bool MarkedForDeletion { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual object ItemReference { get; set; }
        public virtual string URL { get; set; }
        public virtual ItemType TypeOfItem { get; set; }
        public virtual string SEOTitle { get; set; }
        public virtual string SEOKeywords { get; set; }
        public virtual string SEODescription { get; set; }
    }
}
