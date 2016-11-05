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
    public partial class MyPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"data source = .\sqlexpress; integrated security = true; database = Northwind");
            SqlCommand cmd = null;
            SqlDataReader rdr = null;
            string sqlsel = "";
        }
    }
}