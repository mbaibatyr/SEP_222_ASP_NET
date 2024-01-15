using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsCRUD
{
    public partial class Report : System.Web.UI.Page
    {
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
                    //ws.Cell(1, 1).Value = "Id";
                    //ws.Cell(1, 2).Value = "Name";
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
    }
}