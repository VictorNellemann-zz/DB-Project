using System;
using System.Data;
using System.Data.SqlClient;

namespace _3rd_Handin_Victor_Website
{
    public partial class LoginPage : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = Pokemons");
        SqlCommand cmd = new SqlCommand();
        private string query;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            conn.Open();
            query = "sp_LoginPokehunter-admin";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Username", TextBoxName.Text.ToString());
            cmd.Parameters.AddWithValue("@Password", TextBoxPassword.Text.ToString());

            using (var reader = cmd.ExecuteReader())
            {
                if(reader.HasRows)
                {
                    reader.Read();

                    Session["Name"] = reader["Name"].ToString();
                    Session["Admin"] = Convert.ToBoolean(reader["IsAdmin"].ToString());
                    Session["PokehunterID"] = Convert.ToInt32(reader["PokehunterID"].ToString());

                    conn.Close();
                    Response.Redirect("MyPage.aspx");
                }
                else
                {
                    conn.Close();
                    LabelLogin.Text = "Invalid user name or password";
                }
            }
        }
    }
}