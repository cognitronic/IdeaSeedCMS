using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeedCMS.Presenters.ViewInterfaces;
using IdeaSeedCMS.Core.Domain;
using IdeaSeedCMS.Core.Security;
using IdeaSeed.Core;
using System.Configuration;
using IdeaSeedCMS.Services;
using IdeaSeedCMS.Core;


namespace IdeaSeedCMS.Presenters
{
    public class ContactUsPresenter : Presenter
    {
        IContactUsView _view;

        public ContactUsPresenter(IContactUsView view, ISessionProvider session)
            : base(view, session)
        {
            _view = base.GetView<IContactUsView>();
            _view.InitView += new EventHandler(_view_InitView);
            _view.LoadView += new EventHandler(_view_LoadView);
            _view.UnloadView += new EventHandler(_view_UnloadView);
            _view.SendMessage += new EventHandler(_view_SendMessage);
        }

        void _view_SendMessage(object sender, EventArgs e)
        {
            SendMessage();
        }

        void _view_UnloadView(object sender, EventArgs e)
        {

        }

        void _view_LoadView(object sender, EventArgs e)
        {
            
        }

        void _view_InitView(object sender, EventArgs e)
        {

        }

        private void SendMessage()
        {
            var sb = new StringBuilder();
            sb.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
            sb.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">");
            sb.Append("<head>");
            sb.Append("<title> Modesto Power Contact Us Form Message </title>");
            sb.Append("</head><body><div style='width: 600px;'><div><div><b>Name:</b></div>");
            sb.Append(_view.Name);
            sb.Append("</div><div><div><b>Email:</b></div>");
            sb.Append(_view.Email);
            sb.Append("</div><div><div><b>Phone:</b></div>");
            sb.Append(_view.Phone);
            sb.Append("</div><div><div><b>Message:</b></div>");
            sb.Append(_view.Message);
            sb.Append("</div></div></body></html>");
            
            if(IdeaSeed.Core.Mail.EmailUtils.SendEmail(ConfigurationManager.AppSettings["CONTACTUS_RECIPIENTS"], _view.Email, "", "dschreiber@mydatapath.com", "Online Contact Us Form", sb.ToString(),false, ""))
            {
                _view.IsSuccessful = true;
            }
            else
            {
                _view.IsSuccessful = false;
            }
        }
    }
}
