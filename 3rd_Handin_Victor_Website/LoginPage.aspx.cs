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
    public partial class LoginPage : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection
           (@"data source = .\SQLEXPRESS; integrated security = true; database = Pokemons");
        SqlCommand cmd = new SqlCommand();
        private string query;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            conn.Open();
            query = "sp_LoginPokehunter";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", TextBoxName.Text.ToString());
            cmd.Parameters.AddWithValue("@Password", TextBoxPassword.Text.ToString());

            var firstColumn = cmd.ExecuteScalar();

            if (firstColumn != null)
            {
                Session["Name"] = TextBoxName.Text;
                Response.Redirect("MyPage.aspx");
                Session.RemoveAll();

            }

            else
            {
                conn.Close();
                LabelLogin.Text = "Invalid user name or password";
            }
        }
    }
}