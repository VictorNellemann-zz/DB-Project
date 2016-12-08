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
    public partial class temp : System.Web.UI.Page
    {
        DataSet ds;
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ds = new DataSet();
                ds.ReadXml(Server.MapPath("~/XMLFiles/Sponsors.xml"));
                dt = ds.Tables["Sponsor"];

            }
            catch
            {
                // The XML file does not excist or is empty; dt made only for display of repeater heading
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

