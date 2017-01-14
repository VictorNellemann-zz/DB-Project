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

            string sqlsel = "SELECT * FROM Pokemons";


            try
            {
                da = new SqlDataAdapter(sqlsel, conn);
                ds = new DataSet();
                dt = new DataTable();

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
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}