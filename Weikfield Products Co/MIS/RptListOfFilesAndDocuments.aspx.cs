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
using DMS.EntityClass;
using DMS.DALSQLHelper;
using DMS.DB;
using DMS.Utility;
using System.Threading;
using DMS.BussinessLayer;
using DMS.DataModel;


public partial class MIS_RptListOfFilesAndDocuments : System.Web.UI.Page
{
    #region [Private Variables]

    DMRptListOfFilesAndDocument obj_Doc = new DMRptListOfFilesAndDocument();
    SearchDocument Entity_File = new SearchDocument();
    CommanFunction obj_Comman = new CommanFunction();
    DataSet Ds = new DataSet();
    DataSet DSA = new DataSet();
    private string StrCondition = string.Empty;
    private string StrConditionFilters = string.Empty;
    private string StrError = string.Empty;
    private bool Flag = false;
    int str = 0;
    public static int countPage = 0;
    private static bool FlagAdd = false, FlagDel = false, FlagEdit = false;

    #endregion

    //User Right Function===========
    public void CheckUserRight()
    {
        FlagAdd = FlagDel = FlagEdit = false;
        try
        {
            #region [USER RIGHT]
            //Checking Session Varialbels========
            if (Session["UserName"] != null && Session["UserRole"] != null)
            {
                //Checking User Role========
                //if (!Session["UserRole"].Equals("Administrator"))
                //{
                //Checking Right of users=======

                System.Data.DataSet dsChkUserRight = new System.Data.DataSet();
                System.Data.DataSet dsChkUserRight1 = new System.Data.DataSet();
                dsChkUserRight1 = (DataSet)Session["DataSet"];

                DataRow[] dtRow = dsChkUserRight1.Tables[1].Select("FormName ='RptListOfFilesAndDocuments'");
                if (dtRow.Length > 0)
                {
                    DataTable dt = dtRow.CopyToDataTable();
                    dsChkUserRight.Tables.Add(dt);// = dt.Copy();
                }
                if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["ViewAuth"].ToString()) == false && Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["AddAuth"].ToString()) == false &&
                    Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["DelAuth"].ToString()) == false && Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["EditAuth"].ToString()) == false)
                {
                    Response.Redirect("~/Masters/NotAuthUser.aspx");
                }
                //Checking View Right ========                    
                if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["ViewAuth"].ToString()) == false)
                {
                    GrdReport.Visible = false;
                    BtnShow.Visible = false;
                    BtnExportDetail.Visible = false;
                }
                ////Checking Add Right ========                    
                //if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["AddAuth"].ToString()) == false)
                //{
                //    BtnSave.Visible = false;
                //    FlagAdd = true;

                //}
                ////Checking Print Right ========                    
                //if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["PrintAuth"].ToString()) == false)
                //{

                //}
                ////Edit /Delete Column Visible ========
                //if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["DelAuth"].ToString()) == false && Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["EditAuth"].ToString()) == false)
                //{
                //    BtnDelete.Visible = false;
                //    BtnUpdate.Visible = false;
                //    FlagDel = true;
                //    FlagEdit = true;
                //}
                //else
                //{
                //    //Checking Delete Right ========
                //    if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["DelAuth"].ToString()) == false)
                //    {
                //        BtnDelete.Visible = false;
                //        FlagDel = true;
                //    }

                //    //Checking Edit Right ========
                //    if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["EditAuth"].ToString()) == false)
                //    {
                //        BtnUpdate.Visible = false;
                //        FlagEdit = true;
                    //}
                //}
                dsChkUserRight.Dispose();
                // }
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            #endregion
        }
        catch (ThreadAbortException)
        {
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    //User Right Function===========

    private void MakeFormEmpty()
    {
        SetInitialRow();       
        ChkDate.Checked = true;
        txtFromDate.Enabled = true;
        txtToDate.Enabled = true;
        //txtFromDate.Text = DateTime.Now.AddMonths(-1).ToString("dd-MMM-yyyy");
        if (Session["FinStartDate"] != null)
        {
            txtFromDate.Text = DateTime.Parse(Session["FinStartDate"].ToString()).ToString("dd-MMM-yyyy");
        }
        else
        {
            txtFromDate.Text = DateTime.Now.AddMonths(-1).ToString("dd-MMM-yyyy");
        }
        txtToDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
        txtFileName.Text = string.Empty;
        txtSelectDoc.Text = string.Empty;
        txtDocSubTitle.Text = string.Empty;

        //ViewState["Condition"] = null;
        //BtnPrint.Visible = false;
        //BtnExportDetail.Visible = false;
    }

    public void SetInitialRow()
    {
        try
        {
            DataTable dtTable = new DataTable();
            DataRow dr;

            dtTable.Columns.Add("#", typeof(int));

            dtTable.Columns.Add("FileNo", typeof(string));
            dtTable.Columns.Add("PropertyName", typeof(string));
            dtTable.Columns.Add("FileName", typeof(string));
            dtTable.Columns.Add("Company", typeof(string));
            dtTable.Columns.Add("Barcode", typeof(string));
            dtTable.Columns.Add("Room", typeof(string));
            dtTable.Columns.Add("Aisle", typeof(string));
            dtTable.Columns.Add("DocDate", typeof(string));
            dtTable.Columns.Add("ShelfNo", typeof(string));
            dtTable.Columns.Add("DocExpiryDate", typeof(string));
            dtTable.Columns.Add("Narration", typeof(string));

            dr = dtTable.NewRow();
            dr["#"] = 0;

            dr["FileNo"] = string.Empty;
            dr["PropertyName"] = string.Empty;
            dr["FileName"] = string.Empty;
            dr["Company"] = string.Empty;
            dr["Barcode"] = string.Empty;
            dr["Room"] = string.Empty;
            dr["Aisle"] = string.Empty;
            dr["DocDate"] = string.Empty;
            dr["ShelfNo"] = string.Empty;
            dr["DocExpiryDate"] = string.Empty;
            dr["Narration"] = string.Empty;



            dtTable.Rows.Add(dr);
            ViewState["CurrentTable"] = dtTable;
            GrdReport.DataSource = dtTable;
            GrdReport.DataBind();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }

    private void ReportGrid()
    {
        try
        {
            StrCondition = string.Empty;
            StrConditionFilters = string.Empty;

            if (ChkDate.Checked == true)
            {
                StrCondition = StrCondition + " and FC.DocDate between '" + Convert.ToDateTime(txtFromDate.Text).ToString("MM-dd-yyyy") + "' AND '" + Convert.ToDateTime(txtToDate.Text).ToString("MM-dd-yyyy") + "' ";
                StrConditionFilters = StrConditionFilters + "FromDate : " + txtFromDate.Text + "    ToDate : " + txtToDate.Text + "";
            }
            else
            {
                StrCondition = StrCondition + " AND FC.DocDate  between '01-01-1975' AND '" + DateTime.Now.ToString("MM-dd-yyyy") + "' ";
            }
            if (!string.IsNullOrEmpty(txtFileName.Text) && Convert.ToInt32(HdnFieldFile.Value) > 0)
            {
                StrCondition = StrCondition + " and FC.FileCEDId=" + Convert.ToInt32(HdnFieldFile.Value);
                StrConditionFilters = StrConditionFilters + "    FileName : " + txtFileName.Text + " ";
            }
            if (!string.IsNullOrEmpty(txtDocSubTitle.Text) && Convert.ToInt32(hndSubTitle.Value) > 0)
            {
                StrCondition = StrCondition + " and FU.Id=" + Convert.ToInt32(hndSubTitle.Value);
                //StrConditionFilters = StrConditionFilters + "    Prepared By : " + txtDocSubTitle.SelectedItem + " ";
            }
            if (!string.IsNullOrEmpty(txtSelectDoc.Text) && Convert.ToInt32(hdnValue.Value) > 0) 
            {
                StrCondition = StrCondition + " and FU.DocumentTitleId=" + Convert.ToInt32(hdnValue.Value);
               // StrConditionFilters = StrConditionFilters + "    OA No : " + ddlOrder.SelectedItem + " ";
            }
            //if (!string.IsNullOrEmpty(ddlPO.Text) && Convert.ToInt32(ddlPO.SelectedValue) > 0)
            //{
            //    StrCondition = StrCondition + " and POM.POId=" + Convert.ToInt32(ddlPO.SelectedValue);
            //    StrConditionFilters = StrConditionFilters + "    Purchase No : " + ddlPO.SelectedItem + " ";
            //}

            //ViewState["Condition"] = StrCondition;
            //ViewState["ConditionFilter"] = StrConditionFilters;

            DSA = obj_Doc.GetListOfFilesAndDocument(StrCondition, out StrError);

            if (DSA.Tables.Count > 0 && DSA.Tables[0].Rows.Count > 0)
            {
                GrdReport.DataSource = DSA.Tables[0];
                GrdReport.DataBind();
                //ViewState["Summary"] is For Export To Excel
                ViewState["Summary"] = DSA.Tables[0];
                //if (!FlagPrint)
                //{
                //    BtnPrint.Visible = true;
                //    BtnExportDetail.Visible = true;
                //}
                LblRecordCount.Visible = true;
                LblRecordCount.Text = DSA.Tables[0].Rows.Count + " Record(s) Found!!";
            }
            else
            {
                GrdReport.DataSource = null;
                GrdReport.DataBind();
                LblRecordCount.Visible = true;
                LblRecordCount.Text = "No Record Found!!";
                SetInitialRow();
            }
        }
        catch (Exception ex)
        {
            obj_Comman.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CheckUserRight();
            MakeFormEmpty();
        }
    }

    protected void BtnShow_Click(object sender, EventArgs e)
    {
        try
        {
            ReportGrid();
            //GrdReport.Focus();
        }
        catch (Exception ex)
        {
            obj_Comman.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    #region["Web Services"]
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionListDocuments(string prefixText, int count, string contextKey)
    {
        DMCompany obj_PartyMaster = new DMCompany();
        String[] SearchList = obj_PartyMaster.GetSuggestedRecordForDocuments(prefixText);
        return SearchList;
    }
    #endregion

    #region["Web Services"]
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionListSubDocuments(string prefixText, int count, string contextKey)
    {
        DMFileDocument obj_FileMaster = new DMFileDocument();
        String[] SearchList = obj_FileMaster.GetSuggestedRecordForSubDocuments(prefixText);
        return SearchList;
    }
    #endregion

    #region["Web Services"]
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionListFile(string prefixText, int count, string contextKey)
    {
        DMFileDocument obj_FileMaster = new DMFileDocument();
        String[] SearchList = obj_FileMaster.GetSuggestedRecordFile(prefixText);
        return SearchList;
    }
    #endregion


    protected void DownloadFile(object sender, EventArgs e)
    {
        try
        {
            LinkButton LB = (LinkButton)sender;
            int RowIndex = Convert.ToInt32(LB.CommandArgument);

            Response.Redirect("~/Transactions/FileCreateEditDelete.aspx?FileCEId=" + RowIndex + " ");
            Response.End();
           
        }
        catch (Exception ex)
        {
            obj_Comman.ShowPopUpMsg(ex.Message, this.Page);

        }
    }
}
