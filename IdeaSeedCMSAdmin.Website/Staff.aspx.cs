using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IdeaSeedCMSAdmin.Presenters.ViewInterfaces;
using IdeaSeedCMSAdmin.Presenters;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Core.Security;
using IdeaSeed.Core;
using IdeaSeedCMSAdmin.Web.Bases;
using IdeaSeedCMS.Core;
using Telerik.Web.UI;
using IdeaSeedCMS.Services;
using System.Configuration;

namespace IdeaSeedCMSAdmin.Website
{
    public partial class Staff : System.Web.UI.Page
    {
        private IdeaSeedCMS.Core.Domain.Staff SelectedStaff
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    return new StaffServices().GetByID(Convert.ToInt16(Request.QueryString["id"]));
                }
                return null;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.Page.Title = "Staff Profile";
            if (!IsPostBack)
                LoadStaff();
        }

        protected void SaveClicked(object o, EventArgs e)
        {
            if (SelectedStaff != null)
            {
                SelectedStaff.IsActive = cbIsActive.Checked;
                SelectedStaff.FirstName = tbFirstName.Text;
                SelectedStaff.LastName = tbLastName.Text;
                SelectedStaff.Title = tbTitle.Text;
                SelectedStaff.Email = tbEmail.Text;
                new StaffServices().Save(SelectedStaff);
            }
            else
            {
                var s = new IdeaSeedCMS.Core.Domain.Staff();
                s.IsActive = cbIsActive.Checked;
                s.FirstName = tbFirstName.Text;
                s.LastName = tbLastName.Text;
                s.Title = tbTitle.Text;
                s.Email = tbEmail.Text;
                new StaffServices().Save(s); 
            }
        }

        protected void CancelClicked(object o, EventArgs e)
        {
            Response.Redirect("/StaffList.aspx");
        }

        private void LoadStaff()
        {
            if (SelectedStaff != null)
            {
                cbIsActive.Checked = SelectedStaff.IsActive;
                tbEmail.Text = SelectedStaff.Email;
                tbFirstName.Text = SelectedStaff.FirstName;
                tbLastName.Text = SelectedStaff.LastName;
                tbTitle.Text = SelectedStaff.Title;
            }
        }
    }
}