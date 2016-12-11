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
    public partial class AdminSponsor : System.Web.UI.Page
    {
        DataSet ds;
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!Page.IsPostBack)
            {
                UpdatePage();

                TextBoxName.Text = String.Empty;
                TextBoxWebsite.Text = String.Empty;
                TextBoxLogo.Text = String.Empty;
            }
            else
            {
                if (DropDownListSponsor.SelectedIndex != 0)
                {
                    ds = new DataSet();
                    ds.ReadXml(Server.MapPath("~/XMLFiles/Sponsors.xml"));
                    dt = ds.Tables["Sponsor"];

                    foreach (DataRow r in dt.Select("SponsorId = " + Convert.ToInt32(DropDownListSponsor.SelectedValue)))
                    {
                        TextBoxId.Text = r["SponsorId"].ToString();
                        TextBoxName.Text = r["Name"].ToString();
                        TextBoxWebsite.Text = r["Website"].ToString();
                        TextBoxLogo.Text = r["Logo"].ToString();
                    }

                    LabelMessage.Text = TextBoxName.Text + " has been selected";

                    DropDownListSponsor.SelectedIndex = 0;

                    ButtonCreate.Enabled = false;
                    ButtonUpdate.Enabled = true;
                    ButtonDelete.Enabled = true;
                }
            }

        }

        public void UpdatePage()
        {
            DropDownListSponsor.AutoPostBack = true;
            DropDownListSponsor.Items.Clear();
            try
            {
                ds = new DataSet();
                ds.ReadXml(Server.MapPath("~/XMLFiles/Sponsors.xml"));
                dt = ds.Tables["Sponsor"];

                DropDownListSponsor.DataSource = dt;
                DropDownListSponsor.DataTextField = dt.Columns[1].ToString();
                DropDownListSponsor.DataValueField = dt.Columns[0].ToString();
                DropDownListSponsor.DataBind();
            }
            catch
            {
                MakeNewDataSetAndDataTable();
            }
            finally
            {
                RepeaterSponsor.DataSource = dt;
                RepeaterSponsor.DataBind();

                DropDownListSponsor.Items.Insert(0, "You can choose a sponsor");
            }

            TextBoxId.Text = "";
            TextBoxName.Text = "";
            TextBoxWebsite.Text = "";
            TextBoxLogo.Text = "";
            ButtonCreate.Enabled = true;
            ButtonUpdate.Enabled = false;
            ButtonDelete.Enabled = false;
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

        protected void ButtonCreate_Click(object sender, EventArgs e)
        {
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

            int maxSponsorId = 0;
            if (dt == null)
            {
                MakeNewDataSetAndDataTable();
            }
            else
            {
                foreach (DataRow r in dt.Rows)
                {
                    if (Convert.ToInt32(r["SponsorId"].ToString()) > maxSponsorId) maxSponsorId = Convert.ToInt32(r["SponsorId"].ToString());
                }
            }

            DataRow newRow = dt.NewRow();
            newRow["SponsorId"] = maxSponsorId + 1;
            newRow["Name"] = TextBoxName.Text;
            newRow["Website"] = TextBoxWebsite.Text;
            newRow["Logo"] = TextBoxLogo.Text;
            dt.Rows.Add(newRow);

            ds.WriteXml(Server.MapPath("~/XMLFiles/Sponsors.xml"));

            LabelMessage.Text = TextBoxName.Text + " has been created with SponsorId " + (maxSponsorId + 1);
            UpdatePage();
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            ds.ReadXml(Server.MapPath("~/XMLFiles/Sponsors.xml"));
            dt = ds.Tables["Sponsor"];

            foreach (DataRow r in dt.Select("SponsorID = " + TextBoxId.Text))
            {
                r["SponsorId"] = Convert.ToInt32(TextBoxId.Text);
                r["Name"] = TextBoxName.Text;
                r["Website"] = TextBoxWebsite.Text;
                r["Logo"] = TextBoxLogo.Text;
            }

            ds.WriteXml(Server.MapPath("~/XMLFiles/Sponsors.xml"));
            LabelMessage.Text = TextBoxName.Text + " has been updated";
            UpdatePage();
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            ds.ReadXml(Server.MapPath("~/XMLFiles/Sponsors.xml"));
            dt = ds.Tables["Sponsor"];

            foreach (DataRow r in dt.Select("SponsorID = " + TextBoxId.Text))
            {
                r.Delete();
            }

            ds.WriteXml(Server.MapPath("~/XMLFiles/Sponsors.xml"));
            LabelMessage.Text = TextBoxName.Text + " has been deleted";
            UpdatePage();
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            LabelMessage.Text = "Input fields have been cleared";
            UpdatePage();
        }
    }
}