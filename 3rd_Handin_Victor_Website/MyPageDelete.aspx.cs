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
            {
                UpdateGridView();
            }
        }

        private void UpdateGridView()
        {
            SqlConnection conn = new SqlConnection
                (@"data source = .\SQLEXPRESS; integrated security = true; database = Pokemons");
            SqlDataAdapter da = null;
            DataSet ds = null;
            DataTable dt = null;
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
                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);

                ds = new DataSet();
                da.Fill(ds, "MyCatches");
                dt = ds.Tables["MyCatches"];

                GridViewDelete.DataSource = dt;
                GridViewDelete.DataBind();

                DropDownCatches.DataSource = dt;
                DropDownCatches.DataTextField = "CatchID";
                DropDownCatches.DataValueField = "CatchID";
                DropDownCatches.DataBind();
                DropDownCatches.Items.Insert(0, "Select catch to delete");
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

        protected void DropDownCatches_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownCatches.SelectedIndex == 0)
            {
                LabelMessage.Text = "You choose none";
                ButtonDelete.Enabled = false;
            }
            else
            {
                LabelMessage.Text = "You chose catch: " + DropDownCatches.SelectedValue;
                ButtonDelete.Enabled = true;
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection
                (@"data source = .\SQLEXPRESS; integrated security = true; database = Pokemons");
            SqlDataAdapter da = null;
            SqlCommandBuilder cb = null;
            DataSet ds = null;
            DataTable dt = null;
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
                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);

                cb = new SqlCommandBuilder(da);

                ds = new DataSet();
                da.Fill(ds, "MyCatches");
                dt = ds.Tables["MyCatches"];

                foreach (DataRow myrow in dt.Select("CatchID =" + Convert.ToInt32(DropDownCatches.SelectedValue)))
                {
                    myrow.Delete();
                }

                da.Update(ds, "MyCatches");

                ButtonDelete.Enabled = false;
                LabelMessage.Text = "Catch " + DropDownCatches.SelectedValue + " was deleted from the database";
            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
            finally
            {
                conn.Close();

                UpdateGridView();
            }
        }
    }
}