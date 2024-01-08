using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebForms
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bt_result_Click(object sender, EventArgs e)
        {
            tb_result.Text = (int.Parse(tb_1.Text) + int.Parse(tb_2.Text)).ToString();
            Response.Write(cb_operation.Text);
        }
    }
}