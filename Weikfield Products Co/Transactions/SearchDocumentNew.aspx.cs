using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.IO;
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
using System.Threading;
using DMS.Utility;
using DMS.BussinessLayer;
using DMS.DataModel;

public partial class Transactions_SearchDocumentNew : System.Web.UI.Page
{
    #region [Private Variables]

    DMSearchDocument obj_Doc = new DMSearchDocument();
    SearchDocument Entity_File = new SearchDocument();
    CommanFunction obj_Comman = new CommanFunction();
    DataSet Ds = new DataSet();
    DataSet DSA = new DataSet();
    private string StrCondition = string.Empty;
    private string StrError = string.Empty;
    private bool Flag = false;
    int str = 0;
    public static int countPage = 0;
    private static bool FlagAdd = false, FlagDel = false, FlagEdit = false;

    #endregion

    private void MakeEmptyForm()
    {       
        TxtSearch.Text = string.Empty;
        TxtSearch.Focus();
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

    public void SetInitialRowDocDetails()
    {
        try
        {
            DataTable dtTable = new DataTable();
            DataRow dr;

            dtTable.Columns.Add("#", typeof(int));

            dtTable.Columns.Add("DocImagePath", typeof(string));
            dtTable.Columns.Add("DocumentTitle", typeof(string));
            dtTable.Columns.Add("DocumentSubTitle", typeof(string));
            dtTable.Columns.Add("DocRefNo", typeof(string));
            dtTable.Columns.Add("Status", typeof(string));
            dtTable.Columns.Add("DocDate", typeof(string));    
            dr = dtTable.NewRow();

            dr["#"] = 0;
            dr["DocImagePath"] = string.Empty;
            dr["DocumentTitle"] = string.Empty;
            dr["DocumentSubTitle"] = string.Empty;
            dr["DocRefNo"] = string.Empty;
            dr["Status"] = string.Empty;
            dr["DocDate"] = string.Empty;

            dtTable.Rows.Add(dr);

            ViewState["CurrentTableUpload"] = dtTable;
            GridDocDetails.DataSource = dtTable;
            GridDocDetails.DataBind();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }
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

                DataRow[] dtRow = dsChkUserRight1.Tables[1].Select("FormName ='SearchDocumentNew'");
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
                    GridDocDetails.Visible = false;
                    GrdReport.Visible = false;
                
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
                //    }
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CheckUserRight();
            MakeEmptyForm();
            SetInitialRow();
            SetInitialRowDocDetails();
        }
    }

    protected void TxtSearch_TextChanged(object sender, EventArgs e)
    {
        try
        {

            DataSet Ds = new DataSet();
            int DocTitleId = 0, FileCEDId = 0, CompanyId=0,SubTitleId=0;
            DataSet DSA = new DataSet();
            //int DocTitleId = Convert.ToInt32(hdnValue.Value);
            string SearchT = TxtSearch.Text;

            DSA = obj_Doc.GetDocumentDetails(SearchT, out StrError);
            {
                if (DSA.Tables.Count > 0)
                {
                     DocTitleId = Convert.ToInt32(DSA.Tables[0].Rows[0]["DocumentTitleId"].ToString());
                     FileCEDId = Convert.ToInt32(DSA.Tables[0].Rows[0]["#"].ToString());
                     CompanyId = Convert.ToInt32(DSA.Tables[0].Rows[0]["CompanyId"].ToString());
                     SubTitleId = Convert.ToInt32(DSA.Tables[0].Rows[0]["Id"].ToString());
                }
            }

            Ds = obj_Doc.FillDocumentDetails(DocTitleId, SubTitleId, FileCEDId, CompanyId, out StrError);

            if (Ds.Tables.Count > 0)
            {
                if (Ds.Tables[0].Rows.Count > 0)
                {
                    GrdReport.DataSource = Ds.Tables[0];
                    GrdReport.DataBind();
                    ViewState["FileDoc"] = Ds.Tables[0];
                }
                else
                {
                    GrdReport.DataSource = null;
                    GrdReport.DataBind();
                }
                if (Ds.Tables[1].Rows.Count > 0)
                {
                    GridDocDetails.DataSource = Ds.Tables[1];
                    GridDocDetails.DataBind();
                    ViewState["FileDocDetails"] = Ds.Tables[1];
                }
                else
                {
                    GridDocDetails.DataSource = null;
                    GridDocDetails.DataBind();
                }

            }
            TxtSearch.Focus();


        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }


    }

    protected void imgExcel_Click(object sender, EventArgs e)
    {
        if (ViewState["FileDoc"] != null)
        {
            DataTable DtGrd = (DataTable)ViewState["FileDoc"];
            string PURINVNO = string.Empty;
            if (DtGrd.Rows.Count > 0)
            {
                
                //========Call Register
                GridView GridExp = new GridView();
                
                GridExp.DataSource = DtGrd;
                GridExp.DataBind();
                obj_Comman.Export("FileDocument.xls", GridExp);
            }
            else
            {
                obj_Comman.ShowPopUpMsg("No Data Found To Export..!", this.Page);
                GrdReport.DataSource = null;
                GrdReport.DataBind();
            }

            //if (ViewState["FileDocDetails"] != null)
            //{
            //    DataTable DtGrdDetails = (DataTable)ViewState["FileDocDetails"];
               
            //    if (DtGrdDetails.Rows.Count > 0)
            //    {

            //        //========Call Register
            //        GridView GridExpDetails = new GridView();

            //        GridExpDetails.DataSource = DtGrd;
            //        GridExpDetails.DataBind();
            //        obj_Comman.Export("FileDocumentDetails.xls", GridExpDetails);
            //    }
            //    else
            //    {
            //        obj_Comman.ShowPopUpMsg("No Data Found To Export..!", this.Page);
            //        GridDocDetails.DataSource = null;
            //        GridDocDetails.DataBind();
            //    }
            //}
        }                                                   
        else
        {
            obj_Comman.ShowPopUpMsg("No Data Found To Export..!", this.Page);
            SetInitialRow();
        }
    }

    protected void ImgExcelDetails_Click(object sender, EventArgs e)
    {
        if (ViewState["FileDocDetails"] != null)
        {
            DataTable DtGrdDetails = (DataTable)ViewState["FileDocDetails"];

            if (DtGrdDetails.Rows.Count > 0)
            {

                //========Call Register
                GridView GridExpDetails = new GridView();

                GridExpDetails.DataSource = DtGrdDetails;
                GridExpDetails.DataBind();
                obj_Comman.Export("FileDocumentDetails.xls", GridExpDetails);
            }
            else
            {
                obj_Comman.ShowPopUpMsg("No Data Found To Export..!", this.Page);
                GridDocDetails.DataSource = null;
                GridDocDetails.DataBind();
            }
        }

        else
        {
            obj_Comman.ShowPopUpMsg("No Data Found To Export..!", this.Page);
            SetInitialRowDocDetails();
        }
    }

    //protected void DownloadFile(string FilePath)
    //{
    //    Response.Clear();
    //    //string FilePath = (sender as LinkButton).CommandArgument;
    //    Response.ContentType = @"application\octet-stream";
    //    System.IO.FileInfo file = new System.IO.FileInfo(Server.MapPath(FilePath));
    //    Response.AppendHeader("Content-Disposition", "attachment; Filename=" + file.Name);
    //    Response.AppendHeader("Content-Lenght", file.Length.ToString());
    //    Response.ContentType = "application/octet-stream";
    //    Response.WriteFile(file.FullName);
    //    Response.Flush();
    //}

    //protected void  GridDocDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    try
    //    {
    //        int Index;
    //        if (e.CommandName == "View")
    //        {
    //            DownloadFile(e.CommandArgument.ToString());
    //        }
    //    }
    //    catch (Exception ex) { throw new Exception(ex.Message); }
    //}

    protected void DownloadFile(object sender, EventArgs e)
    {
        try
        {
            LinkButton LB = (LinkButton)sender;
            int RowIndex = Convert.ToInt32(LB.CommandArgument);
            if (!GridDocDetails.Rows[RowIndex].Cells[5].Text.Equals("&nbsp;"))
            {
                if (!string.IsNullOrEmpty(GridDocDetails.Rows[RowIndex].Cells[5].Text))
                {
                    Response.Redirect(ResolveUrl(GridDocDetails.Rows[RowIndex].Cells[5].Text));
                }
                else
                {
                    obj_Comman.ShowPopUpMsg("There is no any file to view..", this.Page);
                    LB.Focus();
                }
            }
            else
            {
                obj_Comman.ShowPopUpMsg("There is no any file to view..", this.Page);
                LB.Focus();
            }
        }
        catch (Exception ex)
        {
            obj_Comman.ShowPopUpMsg(ex.Message, this.Page);

        }
    }

    #region["Web Services"]
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionListParty(string prefixText, int count, string contextKey)
    {        
        DMSearchDocument obj_PartyMaster = new DMSearchDocument();
        String[] SearchList = obj_PartyMaster.GetSuggestedRecordForParty(prefixText);
        return SearchList;
    }
    #endregion
   
}
