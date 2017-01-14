using System;
using System.Data;
using System.Data.SqlClient;

namespace _3rd_Handin_Victor_Website
{
    public partial class LoginPage : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = Pokemons");
        SqlCommand cmd = new SqlCommand();
        private string splogin;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            conn.Open();
            splogin = "sp_LoginPokehunter-admin";
            SqlCommand cmd = new SqlCommand(splogin, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Username", TextBoxName.Text.ToString());
            cmd.Parameters.AddWithValue("@Password", TextBoxPassword.Text.ToString());

            using (var rdr = cmd.ExecuteReader())
            {
                if(rdr.HasRows)
                {
                    rdr.Read();

                    Session["Name"] = rdr["Name"].ToString();
                    Session["Admin"] = Convert.ToBoolean(rdr["IsAdmin"].ToString());
                    Session["PokehunterID"] = Convert.ToInt32(rdr["PokehunterID"].ToString());

                    if (rdr != null)
                    {
                        rdr.Close();
                    }
                    if (conn != null)
                    {
                        conn.Close();
                    }
                    Response.Redirect("MyPage.aspx");
                }
                else
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                    LabelLogin.Text = "Invalid user name or password";
                }
            }
        }
    }
}