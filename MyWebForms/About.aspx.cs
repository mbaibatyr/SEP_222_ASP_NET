﻿using System;
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
            if(Session["value_1"] != null)
                tb_1.Text = Session["value_1"].ToString();
            if (Session["value_2"] != null)
                tb_2.Text = Session["value_2"].ToString();
        }

        protected void bt_result_Click(object sender, EventArgs e)
        {
            tb_result.Text = (int.Parse(tb_1.Text) + int.Parse(tb_2.Text)).ToString();
            Response.Write(cb_operation.Text);
        }
    }
}


/*
 
 https://github.com/mbaibatyr/SEP_222_ASP_NET.git
 */