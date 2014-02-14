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
    public class DayOfWeekDDL : DropDownList
    {
        public DayOfWeekDDL()
        {
            this.Items.Clear();
            this.EmptyMessage = "-- Select --";
            this.Items.Add(new RadComboBoxItem("", ""));
            this.Skin = "Metro";
            this.Items.Add(new RadComboBoxItem("Monday", "Monday"));
            this.Items.Add(new RadComboBoxItem("Tuesday", "Tuesday"));
            this.Items.Add(new RadComboBoxItem("Wednesday", "Wednesday"));
            this.Items.Add(new RadComboBoxItem("Thursday", "Thursday"));
            this.Items.Add(new RadComboBoxItem("Friday", "Friday"));
            this.Items.Add(new RadComboBoxItem("Saturday", "Saturday"));
            this.Items.Add(new RadComboBoxItem("Sunday", "Sunday"));
        }
    }
}
