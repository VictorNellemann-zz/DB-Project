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
    public partial class Administration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                UpdateGridView();
            }
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
                da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sqlsel, conn);

                ds = new DataSet();
                da.Fill(ds, "MyPokemons");
                dt = ds.Tables["MyPokemons"];

                GridViewPokemons.DataSource = dt;
                GridViewPokemons.DataBind();
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