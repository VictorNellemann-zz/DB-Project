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
            if (Session["Name"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            else
            {
                LabelPokehunter.Text = "Logged in as: " + Session["Name"].ToString();
            }
            {
                UpdateGridView();
            }
        }

        public void UpdateGridView()
        {
            SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = Pokemons");
            SqlCommand cmd = null;
            SqlDataReader rdr = null;
            string sqlsel = @"SELECT c.CatchID, p.PokemonName FROM [Pokemons].[dbo].[Catches] c 
                        INNER JOIN Pokemons p ON p.PokemonNumber = c.PokemonNumber 
                        WHERE c.PokehunterID = @PokehunterID ORDER BY c.CatchID DESC";

            try
            {
                conn.Open();
                cmd = new SqlCommand(sqlsel, conn);
                cmd.Parameters.Add("@PokehunterID", SqlDbType.Int).Value = int.Parse(Session["PokehunterID"].ToString());
                rdr = cmd.ExecuteReader();

                GridViewCatches.DataSource = rdr;
                GridViewCatches.DataBind();
            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}

