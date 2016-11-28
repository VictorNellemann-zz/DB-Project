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
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSignUp_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection (@"data source = .\SQLEXPRESS; integrated security = true; database = Pokemons");
            SqlCommand cmd = null;
            string sqlins = "INSERT INTO Pokehunter VALUES (@Name, @Email, @Password)";

            if (Page.IsValid)

            try
            {
                conn.Open();

                cmd = new SqlCommand(sqlins, conn);
                cmd.Parameters.Add("@Name", SqlDbType.Text);
                cmd.Parameters.Add("@Email", SqlDbType.Text);
                cmd.Parameters.Add("@Password", SqlDbType.Text);

                cmd.Parameters["@Name"].Value = TextBoxName.Text;
                cmd.Parameters["@Email"].Value = TextBoxMail.Text;
                cmd.Parameters["@Password"].Value = TextBoxPassword.Text;

                cmd.ExecuteNonQuery();
                LabelMessage.Text = "Welcome! You are now a member";
            }

            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }

            finally
            {
                conn.Close();

                TextBoxName.Text = String.Empty;
                TextBoxMail.Text = String.Empty;
                TextBoxPassword.Text = String.Empty;
            }
        }
    }
}