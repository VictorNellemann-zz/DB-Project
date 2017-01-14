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
    public partial class AdminAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateGridView();
        }

        private void UpdateGridView()
        {
            SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = Pokemons");
            SqlDataAdapter da = null;
            DataSet ds = null;
            DataTable dt = null;

            string sqlsel = "SELECT PokemonNumber,PokemonName,NextEvulotion,PictureLink FROM Pokemons";

            try
            {
                da = new SqlDataAdapter(sqlsel, conn);
                ds = new DataSet();
                dt = new DataTable();

                da.Fill(ds, "MyPokemons");
                dt = ds.Tables["MyPokemons"];

                GridViewAdd.DataSource = dt;
                GridViewAdd.DataBind();
            }
            catch (Exception ex)
            {
                LabelMessageAdd.Text = ex.Message;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        protected void ButtonAddPokemon_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = Pokemons");
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            DataSet ds = null;
            DataTable dt = null;


            string sqlsel = "SELECT * FROM Pokemons";
            string sqlins = "INSERT INTO pokemons VALUES (@PokemonName, @NextEvulotion, @PictureLink)";

            if (Page.IsValid)

            try
            {
                da = new SqlDataAdapter(sqlsel, conn);
                ds = new DataSet();

                da.Fill(ds, "MyPokemons");
                dt = ds.Tables["MyPokemons"];

                DataRow newrow = dt.NewRow();
                newrow["PokemonName"] = TextBoxPokeName.Text;
                newrow["NextEvulotion"] = TextBoxNextEvol.Text;
                newrow["PictureLink"] = TextBoxPic.Text;
                dt.Rows.Add(newrow);

                cmd = new SqlCommand(sqlins, conn);
                cmd.Parameters.Add("@PokemonName", SqlDbType.Text, 50, "PokemonName");
                cmd.Parameters.Add("@NextEvulotion", SqlDbType.Text, 50, "NextEvulotion");
                cmd.Parameters.Add("@PictureLink", SqlDbType.Text, 50, "PictureLink");

                da.InsertCommand = cmd;
                da.Update(ds, "MyPokemons");
                LabelMessageAdd.Text = "The pokémon has been added";
            }
            catch (Exception ex)
            {
                LabelMessageAdd.Text = ex.Message;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }

                UpdateGridView();

                TextBoxPokeName.Text = String.Empty;
                TextBoxNextEvol.Text = String.Empty;
                TextBoxPic.Text = String.Empty;
            }
        }
    }
}