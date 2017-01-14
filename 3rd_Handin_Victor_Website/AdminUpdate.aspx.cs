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
    public partial class AdminUpdate : System.Web.UI.Page
    {
        SqlDataAdapter da = null;
        DataSet ds = null;
        DataTable dt = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateGridView();
        }

        private void UpdateGridView()
        {
            SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = Pokemons");

            string sqlsel = "SELECT * FROM Pokemons";

            try
            {
                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);

                ds = new DataSet();
                da.Fill(ds, "MyPokemons");
                dt = ds.Tables["MyPokemons"];

                GridViewUpdate.DataSource = dt;
                GridViewUpdate.DataBind();
            }
            catch (Exception ex)
            {
                LabelMessageUpdate.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        protected void GridViewUpdate_SelectedIndexChanged1(object sender, EventArgs e)
        {
            TextBoxUpdateName.Text = GridViewUpdate.SelectedRow.Cells[2].Text;
            TextBoxUpdateEvol.Text = GridViewUpdate.SelectedRow.Cells[3].Text;
            TextBoxUpdatePic.Text = GridViewUpdate.SelectedRow.Cells[4].Text;
            LabelMessageUpdate.Text = "You chose pokémon " + GridViewUpdate.SelectedRow.Cells[1].Text;
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = Pokemons");
            SqlCommand cmd = null;

            string sqlsel = "SELECT * FROM Pokemons";
            string sqlupd = "UPDATE Pokemons SET PokemonName = @PokemonName, NextEvulotion = @NextEvulotion, PictureLink = @PictureLink WHERE PokemonNumber = @PokemonNumber";

            if (Page.IsValid)

            try
            {
                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);

                ds = new DataSet();
                da.Fill(ds, "MyPokemons");
                dt = ds.Tables["MyPokemons"];

                int mytableindex = GridViewUpdate.SelectedIndex;
                dt.Rows[mytableindex]["PokemonName"] = TextBoxUpdateName.Text;
                dt.Rows[mytableindex]["NextEvulotion"] = TextBoxUpdateEvol.Text;
                dt.Rows[mytableindex]["PictureLink"] = TextBoxUpdatePic.Text;


                cmd = new SqlCommand(sqlupd, conn);
                cmd.Parameters.Add("@PokemonName", SqlDbType.Text, 50, "PokemonName");
                cmd.Parameters.Add("@NextEvulotion", SqlDbType.Text, 50, "NextEvulotion");
                cmd.Parameters.Add("@PictureLink", SqlDbType.Text, -1, "PictureLink");
                SqlParameter parm = cmd.Parameters.Add("@PokemonNumber", SqlDbType.Int, 4, "PokemonNumber");
                parm.SourceVersion = DataRowVersion.Original;

                da.UpdateCommand = cmd;
                da.Update(ds, "MyPokemons");
                LabelMessageUpdate.Text = "Pokémon has been updated";

                UpdateGridView();
            }
            catch (Exception ex)
            {
                LabelMessageUpdate.Text = ex.Message;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }

                TextBoxUpdateName.Text = String.Empty;
                TextBoxUpdateEvol.Text = String.Empty;
                TextBoxUpdatePic.Text = String.Empty;
            }
        }
    }
}

