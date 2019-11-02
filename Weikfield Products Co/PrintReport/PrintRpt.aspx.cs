using DMS.DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Web;
using DMS.Utility;
using DMS.EntityClass;
using DMS.DB;
using DMS.DALSQLHelper;

public partial class PrintReport_PrintRpt : System.Web.UI.Page
{

    #region Private Variable
    DataSet DS = new DataSet();
    DataSet DSShow = new DataSet();
    Random oRandom = new Random();
    string CheckCondition = "";
    DMYearAndDoctTitleDtls obj_YearAndTitle = new DMYearAndDoctTitleDtls();
    public string PDFMaster = string.Empty;
    string Flag = "0";
    string strError = string.Empty;
    int ID = 0;
    string FileNo = string.Empty;
    string FileNo1 = string.Empty;
    ReportDocument CRpt = new ReportDocument();
    public static int Print_Flag = 0;
    String CType = string.Empty;

    #endregion

    //#region [User Created Function]


    //#endregion


    ////protected void Page_Load(object sender, EventArgs e)
    ////{

    ////}

    protected void Page_Init(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Print_Flag = 0;
            PrintReport();
        }
        else
        {
            Print_Flag = 1;
            PrintReport();
        }
     
    }

    private void PrintReport()
    {
        try
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Flag"]))
            {
                Flag = Convert.ToString(Request.QueryString["Flag"]);
                if (Flag.Contains("FIndex"))
                {
                    CheckCondition = "FIndex";
                    this.Page.Title = "";
                }
            }
            else
            {
                //Go to Default Error Page===========                        
            }
            if (!string.IsNullOrEmpty(Request.QueryString["FileNo"]))
            {
                FileNo = Request.QueryString["FileNo"].ToString();
            }
            else
            {
                //Go to Default Error Page===========                        
            }
            switch (Flag)
            {
                #region[DepartmentBillSummary]
                case "FIndex":
                    {
                        ID = Convert.ToInt32(Request.QueryString["ID"]);
                        DS = obj_YearAndTitle.PrintFileIndex(ID, out strError);
                        CRpt.Load(Server.MapPath("~/PrintReport/CryPrintFileIndexrpt.rpt"));

                        DS.Tables[0].TableName = "FileIndex";
                        DS.Tables[1].TableName = "FileProjectCompany";
                        DS.Tables[2].TableName = "FileUploadFile";
                     
                        CRpt.SetDataSource(DS);
                        CRPrint.ReportSource = CRpt;
                        //CRpt.SetParameterValue(0, DS.Tables[0].Rows[0]["CompanyName"].ToString());
                        PDFMaster = Server.MapPath(@"~/TempFile/" + "FileIndex - " + (DateTime.Now).ToString("dd-MMM-yyyy") + ".pdf");
                        CRpt.ExportToDisk(ExportFormatType.PortableDocFormat, PDFMaster);
                        Response.Redirect("ShowPDF.aspx?Id=" + PDFMaster);
                        //CRPrint.DataBind();
                        //CRPrint.DisplayToolbar = true;

                        break;
                    }
                #endregion

            }
        }
        catch (ThreadAbortException th)
        {

        }
        catch (Exception ex) { throw new Exception(ex.Message); }

    }  
}