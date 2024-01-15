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

        }

        protected void gvCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbName.Text = gvCity.DataKeys[gvCity.SelectedIndex].Values[1].ToString();
            hfId.Value = gvCity.DataKeys[gvCity.SelectedIndex].Values[0].ToString();
            
        }
    }
}