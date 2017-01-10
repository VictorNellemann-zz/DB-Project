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
        SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = Pokemons");
        SqlCommand cmd = null;
        SqlDataReader rdr = null;
        string sqldel = @"SELECT c.CatchID, p.PokemonName FROM [Pokemons].[dbo].[Catches] c INNER JOIN Pokemons p ON p.PokemonNumber = c.PokemonNumber 
                        WHERE c.PokehunterID = @PokehunterID ORDER BY p.PokemonName";

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
            DropDownListMyDelete.AutoPostBack = true;
        }

        public void UpdateGridView()
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand(sqldel, conn);
                cmd.Parameters.Add("@PokehunterID", SqlDbType.Int).Value = int.Parse(Session["PokehunterID"].ToString());
                rdr = cmd.ExecuteReader();

                GridViewDelete.DataSource = rdr;
                GridViewDelete.DataBind();
            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
            finally
            {
                rdr.Close();
                conn.Close();
            }

            try
            {
                conn.Open();
                cmd = new SqlCommand(sqldel, conn);
                cmd.Parameters.Add("@PokehunterID", SqlDbType.Int).Value = int.Parse(Session["PokehunterID"].ToString());
                rdr = cmd.ExecuteReader();

                DropDownListMyDelete.DataSource = rdr;
                DropDownListMyDelete.DataTextField = "PokemonName";
                DropDownListMyDelete.DataValueField = "CatchID";
                DropDownListMyDelete.DataBind();
                DropDownListMyDelete.Items.Insert(0, "Select a catch");
            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
            finally
            {
                rdr.Close();
                conn.Close();
            }

        }

        protected void DropDownListMyDelete_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListMyDelete.SelectedIndex != 0)
            {
                LabelMessage.Text = "You chose catch " + DropDownListMyDelete.SelectedValue;
            }
            else
            {
                LabelMessage.Text = "You chose none";
            }
        }

        protected void ButtonMyDelete_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand("DELETE FROM Catches WHERE CatchID = @CatchID", conn);

                cmd.Parameters.Add("@CatchID", SqlDbType.Int);
                cmd.Parameters["@CatchID"].Value = Convert.ToInt32(DropDownListMyDelete.SelectedValue);

                cmd.ExecuteNonQuery();
                LabelMessage.Text = "Catch has been deleted";
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