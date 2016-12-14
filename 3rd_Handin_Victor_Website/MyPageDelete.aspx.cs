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
    public partial class MyPageDelete : System.Web.UI.Page
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

            if (!Page.IsPostBack)
            {
                UpdateGridView();
            }
            DropDownListDelete.AutoPostBack = true;
        }

        public void UpdateGridView()
        {
            SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = Pokemons");
            SqlCommand cmd = null;
            SqlDataReader rdr = null;
            string sqlsel = @"
                SELECT
	                p.PokemonName
                FROM [Pokemons].[dbo].[Catches] c
                INNER JOIN Pokemons p ON p.PokemonNumber = c.PokemonNumber
                WHERE c.PokehunterID = @PokehunterID
                ORDER BY
	                p.PokemonName";
            try
            {
                conn.Open();
                cmd = new SqlCommand(sqlsel, conn);
                rdr = cmd.ExecuteReader();

                GridViewDelete.DataSource = rdr;
                GridViewDelete.DataBind();

                rdr.Close();
                rdr = cmd.ExecuteReader();

                DropDownListDelete.DataSource = rdr;
                DropDownListDelete.DataTextField = "PokemonName";
                DropDownListDelete.DataValueField = "CatchID";
                DropDownListDelete.DataBind();
                DropDownListDelete.Items.Insert(0, "Select a catch");

            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }


        }
    }
}