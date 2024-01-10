using MyWebForms.App_code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebForms
{
    public partial class Page_1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Session["value_1"] = "hello";
            //Session["value_2"] = "step";
            //string[] array = new string[3] { "111", "222", "333" };
            //Session["array"] = array;
            //Common.value_1 = "hello world";
            //Response.Redirect("about.aspx");

            
            TableCell c1 = new TableCell();
            TableCell c2 = new TableCell();

            c1.Text = "1";
            c2.Text = "2";

            TableRow r = new TableRow();
            r.Cells.Add(new TableCell { Text = "1"});
            r.Cells.Add(c2);

            Table1.Rows.Add(r);
            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}