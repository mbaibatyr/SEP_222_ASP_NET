using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsCRUD
{
    public partial class Report : System.Web.UI.Page
    {
        protected DataTable getData()
        {
            DataTable dt = new DataTable();
            using (SqlConnection db = new SqlConnection(ConfigurationManager.AppSettings["conStr"]))
            {
                db.Open();
                using (SqlCommand cmd = new SqlCommand("select * from city", db))
                {
                    dt.Load(cmd.ExecuteReader());
                }
                db.Close();

            }
            return dt;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["param1"] == "excel")
            {
                Response.Write(Request.QueryString["param1"].ToString());
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", "report.xlsx"));

                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.AddWorksheet(getData(), "report");
                    ws.Columns("B").AdjustToContents();
                    using (MemoryStream ms = new MemoryStream())
                    {
                        wb.SaveAs(ms);
                        //ms.CopyTo(Response.OutputStream);
                        Response.OutputStream.Write(ms.ToArray(), 0, (int)ms.Length);
                        Response.End();
                    }
                }
            }
        }

        protected void MyButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyCRUD.aspx?param1=hello&param2=step");
        }
    }
}