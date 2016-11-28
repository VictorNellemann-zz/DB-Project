using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace _3rd_Handin_Victor_Website
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["Pokemon"].ToString();
            string query = @" SELECT TOP 5 PictureLink FROM Pokemons";

            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(query, connString);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }

            RepeaterFrontpage.DataSource = dt;
            RepeaterFrontpage.DataBind();
        }
    }
}