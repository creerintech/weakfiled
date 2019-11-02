using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using DMS.Utility;
using DMS.EntityClass;
using DMS.DB;
using DMS.DataModel;
using DMS.DALSQLHelper;

public partial class Masters_HomeNew : System.Web.UI.Page
{

    DataSet DS = new DataSet();
    string StrError = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Convert.ToString(Session["UserRole"]) == "Administrator")
            {
                ddlEmp.Visible = true;
                Tr1.Visible = true;
               
            }
            else
            {
                Tr1.Visible = false;
                ddlEmp.Visible = false;               
              
            }
        }
    }

 
   
}
