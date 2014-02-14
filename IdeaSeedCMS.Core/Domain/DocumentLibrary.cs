using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeedCMS.Core.Domain.Interfaces;

namespace IdeaSeedCMS.Core.Domain
{
    public class DocumentLibrary : IDocumentLibrary
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Path { get; set; }
        public virtual bool IsFolder { get; set; }
        public virtual int? ParentID { get; set; }
        public virtual int EnteredBy { get; set; }
        public virtual int ChangedBy { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime LastUpdated { get; set; }
        public virtual bool MarkedForDeletion { get; set; }
        public virtual DocumentLibrary ParentDoc { get; set; }
        public virtual int ApplicationID { get; set; }
        public virtual User EnteredByRef { get; set; }
    }
}
