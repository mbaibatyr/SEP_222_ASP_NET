using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsCRUD.Model;

namespace WebFormsCRUD
{
    public partial class MyCRUD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(Request.QueryString["param1"]);
            Response.Write(Request.QueryString["param2"]);
            if (Page.IsPostBack)
                return;
            gvCity.DataSource = getData();
            gvCity.DataBind();
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            gvCity.DataSource = getData();
            gvCity.DataBind();
        }

        List<City> getData()
        {
            using (SqlConnection db = new SqlConnection(ConfigurationManager.AppSettings["conStr"]))
            {
                return db.Query<City>("pCity;6", new { name = tbSearch.Text }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        protected void btAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection db = new SqlConnection(ConfigurationManager.AppSettings["conStr"]))
            {
                var result = db.ExecuteScalar<string>("pCity;3", new { name = tbName.Text }, commandType: CommandType.StoredProcedure);
                if (result == "ok")
                {
                    gvCity.DataSource = getData();
                    gvCity.DataBind();
                }
            }
        }

        protected void btEdit_Click(object sender, EventArgs e)
        {
            using (SqlConnection db = new SqlConnection(ConfigurationManager.AppSettings["conStr"]))
            {
                var result = db.ExecuteScalar<string>("pCity;4", new { id = hfId.Value, name = tbName.Text }, commandType: CommandType.StoredProcedure);
                if (result == "ok")
                {
                    gvCity.DataSource = getData();
                    gvCity.DataBind();
                }
            }
        }

        protected void gvCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbName.Text = gvCity.DataKeys[gvCity.SelectedIndex].Values[1].ToString();
            hfId.Value = gvCity.DataKeys[gvCity.SelectedIndex].Values[0].ToString();

        }

        protected void btDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection db = new SqlConnection(ConfigurationManager.AppSettings["conStr"]))
            {
                var result = db.ExecuteScalar<int>("pCity;5", new { id = hfId.Value }, commandType: CommandType.StoredProcedure);
                if (result > 0)
                {
                    gvCity.DataSource = getData();
                    gvCity.DataBind();
                }
                tbName.Text = "";
            }
        }

        protected void cbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbReportType.SelectedIndex == 0)
                Response.Redirect("~/Report.aspx?param1=excel");
        }
    }
}