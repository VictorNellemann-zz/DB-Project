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
    public partial class AdminDelete : System.Web.UI.Page
    {
        SqlDataAdapter da = null;
        DataSet ds = null;
        DataTable dt = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ButtonDelete.Enabled = false;
                UpdateGridView();
            }

            DropDownListPokemons.AutoPostBack = true;
        }

        private void UpdateGridView()
        {
            SqlConnection conn = new SqlConnection (@"data source = .\SQLEXPRESS; integrated security = true; database = Pokemons");

            string sqlsel = "SELECT * FROM Pokemons";

            try
            {
                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);

                ds = new DataSet();
                da.Fill(ds, "MyPokemons");
                dt = ds.Tables["MyPokemons"];

                GridViewDelete.DataSource = dt;
                GridViewDelete.DataBind();

                DropDownListPokemons.DataSource = dt;
                DropDownListPokemons.DataTextField = "PokemonName";
                DropDownListPokemons.DataValueField = "PokemonNumber";
                DropDownListPokemons.DataBind();
                DropDownListPokemons.Items.Insert(0, "Select pokémon to delete");
            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        protected void DropDownListPokemons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListPokemons.SelectedIndex == 0)
            {
                LabelMessage.Text = "You choose none";
                ButtonDelete.Enabled = false;
            }
            else
            {
                LabelMessage.Text = "You chose Pokemon: " + DropDownListPokemons.SelectedValue;
                ButtonDelete.Enabled = true;
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = Pokemons");
            SqlCommandBuilder cb = null;

            string sqlsel = "SELECT * FROM Pokemons";

            try
            {
                da = new SqlDataAdapter(sqlsel, conn);
                cb = new SqlCommandBuilder(da);
                ds = new DataSet();

                da.Fill(ds, "MyPokemons");
                dt = ds.Tables["MyPokemons"];

                foreach (DataRow myrow in dt.Select("PokemonNumber =" + Convert.ToInt32(DropDownListPokemons.SelectedValue)))
                {
                    myrow.Delete();
                }

                da.Update(ds, "MyPokemons");

                ButtonDelete.Enabled = false;
                LabelMessage.Text = "Pokemon " + DropDownListPokemons.SelectedValue + " was deleted from the database";
            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }

                UpdateGridView();
            }
        }
    }
}