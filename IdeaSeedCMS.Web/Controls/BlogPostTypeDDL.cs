using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Services;
using Telerik.Web.UI;
using IdeaSeed.Web.UI;

namespace IdeaSeedCMS.Web.Controls
{
    public class BlogPostTypeDDL : DropDownList
    {
        public BlogPostTypeDDL()
        {
            this.Items.Clear();
            this.EmptyMessage = "-- Select --";
            this.Items.Add(new RadComboBoxItem("", ""));
            this.Skin = "Default";
            this.Items.Add(new RadComboBoxItem("Arts", "1"));
            this.Items.Add(new RadComboBoxItem("Business", "2"));
            this.Items.Add(new RadComboBoxItem("City", "3"));
        }
    }
}
