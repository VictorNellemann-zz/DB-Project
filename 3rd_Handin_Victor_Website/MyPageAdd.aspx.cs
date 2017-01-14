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
    public partial class MyPageAdd : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = Pokemons");
        SqlCommand cmd = null;
        SqlDataReader rdr = null;
        string sqladd = @"SELECT c.CatchID, p.PokemonName FROM [Pokemons].[dbo].[Catches] c 
                        INNER JOIN Pokemons p ON p.PokemonNumber = c.PokemonNumber 
                        WHERE c.PokehunterID = @PokehunterID ORDER BY c.CatchID DESC";

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
            DropDownListPokemons.AutoPostBack = true;
        }

        public void UpdateGridView()
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand(sqladd, conn);
                cmd.Parameters.Add("@PokehunterID", SqlDbType.Int).Value = int.Parse(Session["PokehunterID"].ToString());
                rdr = cmd.ExecuteReader();

                GridViewCatch.DataSource = rdr;
                GridViewCatch.DataBind();
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

            try
            {
                conn.Open();
                cmd = new SqlCommand("SELECT * FROM Pokemons", conn);
                cmd.Parameters.Add("@PokehunterID", SqlDbType.Int).Value = int.Parse(Session["PokehunterID"].ToString());
                rdr = cmd.ExecuteReader();

                DropDownListPokemons.DataSource = rdr;
                DropDownListPokemons.DataTextField = "PokemonName";
                DropDownListPokemons.DataValueField = "PokemonNumber";
                DropDownListPokemons.DataBind();
                DropDownListPokemons.Items.Insert(0, "Select a Pokemon to catch");
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

        protected void DropDownListPokemons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListPokemons.SelectedIndex != 0)
            {
                LabelMessage.Text = "Attempt to catch " + DropDownListPokemons.SelectedValue;
            }
            else
            {
                LabelMessage.Text = "You chose none";
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int r = rnd.Next(0, 50);

            if (r <= 25)
            {
                try
                {
                    conn.Open();
                    cmd = new SqlCommand("INSERT INTO catches VALUES (@PokehunterID, @PokemonNumber)", conn);

                    cmd.Parameters.Add("@PokehunterID", SqlDbType.Int).Value = int.Parse(Session["PokehunterID"].ToString());
                    cmd.Parameters.Add("@PokemonNumber", SqlDbType.Int).Value = DropDownListPokemons.SelectedValue;

                    cmd.ExecuteNonQuery();

                    LabelMessage.Text = "";
                    LabelNeg.Text = "";
                    LabelPos.Text = "You got it!!!";
                    DropDownListPokemons.Items.Insert(0, "Select a Pokemon to catch");

                }
                catch (Exception ex)
                {
                    LabelNeg.Text = ex.Message;
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                        UpdateGridView();
                    }
                }
            }
            else
            {
                LabelPos.Text = "";
                LabelNeg.Text = "Your Pokémon got away";
            }

        }
    }
}