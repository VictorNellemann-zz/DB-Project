using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace _3rd_Handin_Victor_Website
{
    public partial class Default : System.Web.UI.Page
    {
        SqlDataAdapter da = null;
        DataSet ds = null;
        DataTable dt = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"data source = .\SQLEXPRESS; integrated security = true; database = Pokemons");
            string query = @" SELECT TOP 6 PictureLink FROM Pokemons";

            try
            {
                da = new SqlDataAdapter(query, conn);
                ds = new DataSet();
                dt = new DataTable();

                da.Fill(ds, "Pokemons");
                dt = ds.Tables["Pokemons"];
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
            finally
            {
                RepeaterFrontpage.DataSource = dt;
                RepeaterFrontpage.DataBind();
            }

            try
            {
                ds = new DataSet();
                ds.ReadXml(Server.MapPath("~/XMLFiles/Sponsors.xml"));
                dt = ds.Tables["Sponsor"];
            }
            catch
            {
                MakeNewDataSetAndDataTable();
            }
            finally
            {
                RepeaterSponsors.DataSource = dt;
                RepeaterSponsors.DataBind();
            }
        }

        public void MakeNewDataSetAndDataTable()
        {
            ds = new DataSet("Sponsors");
            dt = ds.Tables.Add("Sponsor");
            dt.Columns.Add("SponsorId", typeof(Int32));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Website", typeof(string));
            dt.Columns.Add("Logo", typeof(string));
        }
    }
}