using System;
using System.Collections.Generic;
using System.Linq;
using IdeaSeedCMS.Core.Domain.Interfaces;
using System.Text;

namespace IdeaSeedCMS.Core.Domain
{
    public class BannerImage : IBannerImage
    {
        public virtual int ID { get; set; }
        public virtual string Title { get; set; }
        public virtual string Path { get; set; }
        public virtual string ToolTip { get; set; }
        public virtual string SubText { get; set; }
    }
}
