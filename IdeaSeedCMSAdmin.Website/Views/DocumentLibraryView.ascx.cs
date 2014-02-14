using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IdeaSeedCMSAdmin.Web.Bases;
using IdeaSeedCMS.Core;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Services;
using IdeaSeed.Core;
using Telerik.Web.UI;
using IdeaSeedCMS.Core.Security;
using System.Configuration;

namespace IdeaSeedCMSAdmin.Website.Views
{
    public partial class DocumentLibraryView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPages(true);
                rtlPages.ExpandAllItems();
            }
        }

        protected void AddRootFolderClicked(object o, EventArgs e)
        {
            Response.Redirect("/Document-Library/New");
        }

        protected void EditClicked(object o, EventArgs e)
        {
            Response.Redirect("/Document-Library/" + ((IdeaSeed.Web.UI.LinkButton)o).Attributes["itemID"] + "/Edit");
        }

        protected void DeleteClicked(object o, EventArgs e)
        {
            var p = new DocumentLibraryServices().GetByID(Convert.ToInt16(((IdeaSeed.Web.UI.LinkButton)o).Attributes["itemID"]));
            if (p != null)
            {
                var kids = new DocumentLibraryServices().GetByParentID((int)p.ID);
                foreach (var k in kids)
                {
                    new DocumentLibraryServices().Delete(k);
                }
                new DocumentLibraryServices().Delete(p);
            }
            LoadPages(true);
        }

        protected void ItemCreated(object o, TreeListItemDataBoundEventArgs e)
        {
            if (e.Item is TreeListDataItem)
            {
                TreeListDataItem dataItem = e.Item as TreeListDataItem;
                var lb = dataItem["AddSub"].Controls[1] as IdeaSeed.Web.UI.LinkButton;
                if (lb.Attributes["isfolder"].Equals("False"))
                    lb.Visible = false;
                else
                    lb.Visible = true;
            }
        }

        protected void AddSubPageClicked(object o, EventArgs e)
        {
            Response.Redirect("/Document-Library/" + ((IdeaSeed.Web.UI.LinkButton)o).Attributes["itemID"] + "/Add");
        }

        protected void NeedDataSource(object o, TreeListNeedDataSourceEventArgs e)
        {
            LoadPages(false);
        }

        private void LoadPages(bool bindData)
        {
            if (SecurityContextManager.Current.CurrentManagedApplication != null)
            {
                rtlPages.DataSource = new DocumentLibraryServices().GetByFilters(false, SecurityContextManager.Current.CurrentManagedApplication.ID);
                if (bindData)
                {
                    rtlPages.DataBind();
                }
            }
        }
    }
}