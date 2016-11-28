using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;


namespace _3rd_Handin_Victor_Website
{
    public partial class Website : System.Web.UI.MasterPage
    {
        public void Page_Init(object sender, EventArgs e)
        {
            var isLoggedIn = Session["Name"] != null && !string.IsNullOrEmpty(Session["Name"].ToString());
            var isAdmin = Session["Admin"] != null && !string.IsNullOrEmpty(Session["Admin"].ToString());

            IsLoggedInContainer.Visible = isLoggedIn;
            IsNotLoggedInContainer.Visible = !isLoggedIn;
            isAdminContainer.Visible = isAdmin && isLoggedIn;

            if (isLoggedIn)
            {
                UsernameLabel.Text = Session["Name"].ToString();
            }
        }
    }
}