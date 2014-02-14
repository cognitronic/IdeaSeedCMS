using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Services;
using Telerik.Web.UI;
using IdeaSeed.Web.UI;

namespace IdeaSeedCMSAdmin.Web.Controls
{
    public class PageTypeDDL : DropDownList
    {
        public PageTypeDDL()
        {
            this.Items.Clear();
            this.EmptyMessage = "-- Select --";
            this.Items.Add(new RadComboBoxItem("", ""));
            this.Skin = "Metro";
            this.Items.Add(new RadComboBoxItem("Default Content", "6"));
            this.Items.Add(new RadComboBoxItem("Profile", "5"));
        }
    }
}
