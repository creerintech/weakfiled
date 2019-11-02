﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class MasterPages_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"]!=null)
        {

            lblLoggedInUserNm.Text = string.Empty;
            lblLoggedInUserNm.Text = lblLoggedInUserNm.Text + " " + Session["UserName"].ToString();    
        }
        
    }
    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Remove("UserName");
            Session.Remove("UserID");
            Session.Remove("UserRole");
            Session.Remove("Password");
            Session.Remove("Admin");
            Session.Remove("DataSet");
            Response.Redirect("~/Default.aspx", false);
        }
        catch (Exception exp)
        {
            throw new Exception(exp.Message);
        }
    }
}
