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
using System.Threading;
using DMS.EntityClass;
using DMS.DALSQLHelper;
using DMS.DB;
using DMS.Utility;
using DMS.BussinessLayer;
using DMS.DataModel;

public partial class Transactions_FileCreateEditDelete : System.Web.UI.Page
{

    #region [Private Variables]

    DMFileDocument obj_File = new DMFileDocument();
    FileDocument Entity_File = new FileDocument();
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

    #region["Web Services"]
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionListDocuments(string prefixText, int count, string contextKey)
    {
        DMCompany obj_PartyMaster = new DMCompany();
        String[] SearchList = obj_PartyMaster.GetSuggestedRecordForDocuments(prefixText);
        return SearchList;
    }
    #endregion

    private void SetInitialRowGrid()
    {
        try
        {
            DataTable dt = new DataTable();

            DataRow dr = null;
            dt.Columns.Add(new DataColumn("#", typeof(int)));
            dt.Columns.Add(new DataColumn("FileNo", typeof(string)));
            dt.Columns.Add(new DataColumn("FileName", typeof(string)));
            dt.Columns.Add(new DataColumn("PropertyId", typeof(Int32)));
            dt.Columns.Add(new DataColumn("DocumentTitleId", typeof(Int32)));
            dt.Columns.Add(new DataColumn("DocRefNo", typeof(string)));
            dt.Columns.Add(new DataColumn("PropertyName", typeof(string)));
            dt.Columns.Add(new DataColumn("DocumentTitle", typeof(string)));
            dt.Columns.Add(new DataColumn("DocumentSubTitle", typeof(string)));
            dt.Columns.Add(new DataColumn("DocDate", typeof(string)));
            dt.Columns.Add(new DataColumn("DocExpiryDate", typeof(string)));
            dt.Columns.Add(new DataColumn("Id", typeof(Int32)));
            dt.Columns.Add(new DataColumn("Barcode", typeof(string)));
            dt.Columns.Add(new DataColumn("Room", typeof(string)));
            dt.Columns.Add(new DataColumn("Aisle", typeof(string)));
            dt.Columns.Add(new DataColumn("ShelfNo", typeof(string)));
                                
            dr = dt.NewRow();

            dr["#"] = 0;
            dr["FileNo"] = "";
            dr["FileName"] = "";
            dr["PropertyId"] = 0;
            dr["DocumentTitleId"] = 0;
            dr["DocRefNo"] = "";
            dr["PropertyName"] = "";
            dr["DocumentTitle"] = "";
            dr["DocumentSubTitle"] = "";
            dr["Barcode"] = "";
            dr["Room"] = "";
            dr["Aisle"] = "";
            dr["ShelfNo"] = "";
            dr["DocDate"] = "";
            dr["DocExpiryDate"] = "";
            dr["Id"] = 0;
           
            dt.Rows.Add(dr);
            
            ViewState["GridRptCurrentTable"] = dt;
            GrdReport.DataSource = dt;
            GrdReport.DataBind();

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void SetInitialRow()
    {
        try
        {
            DataTable dtTable = new DataTable();
            DataRow dr;

            dtTable.Columns.Add("#", typeof(int));
            dtTable.Columns.Add("Company", typeof(string));
            dtTable.Columns.Add("CompanyId", typeof(Int32)); 
            dr = dtTable.NewRow();
            dr["#"] = 0;
            dr["Company"] = string.Empty;
            dr["CompanyId"] = 0;
            dtTable.Rows.Add(dr);
            ViewState["CurrentTable"] = dtTable;
            GrdCompany.DataSource = dtTable;
            GrdCompany.DataBind();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    private void SetInitialRowLogo()
    {
        try
        {
            DataTable dt = new DataTable();

            DataRow dr = null;
            dt.Columns.Add("#", typeof(int));
            dt.Columns.Add(new DataColumn("DocImagePath", typeof(string)));
            dt.Columns.Add("FileUploadDocId", typeof(Int32));
            dt.Columns.Add("DocumentTitle", typeof(string));
            dt.Columns.Add("DocumentTitleId", typeof(Int32));
            dt.Columns.Add("DocumentSubTitle", typeof(string));
            dt.Columns.Add("Id", typeof(Int32));
            dt.Columns.Add("DocRefNo", typeof(string));
            dt.Columns.Add("Status", typeof(string)); 
            dr = dt.NewRow();

            dr["#"] = 0;
            dr["DocImagePath"] = "";
            dr["FileUploadDocId"] = 0; 
            dr["DocumentTitle"] = "";
            dr["DocumentTitleId"] =0;
            dr["DocumentSubTitle"] = "";
            dr["DocRefNo"] = ""; 
            dr["Id"] = 0;
            dr["Status"] = "";
            dt.Rows.Add(dr);

            //Store the DataTable in ViewState
            ViewState["CurrentTableLogo"] = dt;
            GridLogo.DataSource = dt;
            GridLogo.DataBind();

            dt = null;
            dr = null;
        }
        catch (Exception ex)
        {
            obj_Comman.ShowPopUpMsg(ex.Message, this.Page);
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

                DataRow[] dtRow = dsChkUserRight1.Tables[1].Select("FormName ='FileCreateEditDelete'");
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
                }
                //Checking Add Right ========                    
                if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["AddAuth"].ToString()) == false)
                {
                    BtnSave.Visible = false;
                    FlagAdd = true;

                }
                ////Checking Print Right ========                    
                //if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["PrintAuth"].ToString()) == false)
                //{

                //} 
                //Edit /Delete Column Visible ========
                if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["DelAuth"].ToString()) == false && Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["EditAuth"].ToString()) == false)
                {
                    foreach (GridViewRow GRow in GrdReport.Rows)
                    {
                        GRow.FindControl("ImgBtnEdit").Visible = false;
                        GRow.FindControl("ImgBtnDelete").Visible = false;
                    }
                    //BtnDelete.Visible = false;
                    BtnUpdate.Visible = false;
                    FlagDel = true;
                    FlagEdit = true;
                }
                else
                {
                    //Checking Delete Right ========
                    if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["DelAuth"].ToString()) == false)
                    {
                        foreach (GridViewRow GRow in GrdReport.Rows)
                        {
                            GRow.FindControl("ImgBtnDelete").Visible = false;
                             FlagDel = true;
                        }
                       
                    }

                    //Checking Edit Right ========
                    if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["EditAuth"].ToString()) == false)
                    {
                        foreach (GridViewRow GRow in GrdReport.Rows)
                        {
                            GRow.FindControl("ImgBtnEdit").Visible = false;
                       
                        FlagEdit = true;
                        }
                    }
                }
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

    private void MakeEmptyForm()
    {
        ViewState["EditId"] = null;
        HttpContext.Current.Cache["Dir"] = "";

        txtAdditionalNotes.Text = string.Empty;
        //TxtSearch.Text = string.Empty;
        txtDate.Text =DateTime.Now.ToString("dd/MMM/yyyy");
        txtDocRefno.Text = string.Empty;
        txtExpireDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
        txtFileNo.Enabled = false;
        txtFileNo.Text = string.Empty;
        txtRenewed.Text = string.Empty;
        ddlProject.Focus();
        ddlRoom.SelectedValue = "0";
        ddlAisle.Items.Clear();
        ddlShelf.Items.Clear();
        //ddlCabinet.SelectedValue = "0";
        //ddlShelf.SelectedValue = "0";

        
        //ddlDocSubType.SelectedValue = "0";
        ddlmonth.SelectedValue = "0";
        ddlDay.SelectedValue = "0";
       // ddlYear.SelectedValue = "0";
        txtSelectDoc.Text = string.Empty;
        TxtBarcode.Text = string.Empty;
        BtnSave.Visible = true;
        BtnUpdate.Visible = false;
        BtnDelete.Visible = false;
        BtnCancel.Visible = true;
        txtFileName.Text = string.Empty;
        TxtSearch.Text = string.Empty;
        GetCode();
        FillCombo();
        SetInitialRow();
        SetInitialRowLogo();
        SetInitialRowGrid();
        ReportGrid(StrCondition);
    }

    private bool Check()
    {
        DataSet Ds = new DataSet();
        Flag = true;
        if (ViewState["EditID"] != null)
            Ds = obj_File.ChkDuplicateFile(txtFileName.Text.Trim(), Convert.ToInt32(ddlProject.SelectedValue), Convert.ToInt32(ViewState["EditID"].ToString()), out StrError);
        else
            Ds = obj_File.ChkDuplicateFile(txtFileName.Text.Trim(), Convert.ToInt32(ddlProject.SelectedValue), -1, out StrError);

        if (Ds.Tables.Count > 0)
        {
            if (Ds.Tables[0].Rows.Count > 0)
            {
                if (long.Parse(Ds.Tables[0].Rows[0][0].ToString()) > 0)
                {
                    Flag = false;
                    obj_Comman.ShowPopUpMsg("This File Name and Project Already Exist....!", this.Page);
                    txtFileName.Focus();
                }
            }
        }
        return Flag;
    }

    public void MakeEmptyDocument()
    {
        //txtDocDate.Text = string.Empty;
        txtSelectDoc.Text = string.Empty;
        //ddlDocSubType.SelectedValue = "0";
        txtDocSubTitle.Text = string.Empty;
        txtDocRefno.Text = string.Empty;
        ViewState["GridindexLogo"] = null;
        lblOfferLogopath.Text = string.Empty;
        // txtRemarks.Text = string.Empty;
        // ViewState["CurrentTableLogo"] = null;
    }
      
    private void GetCode()
    {
        Ds = obj_File.GetCode(out StrError);
        if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {
            txtFileNo.Text = Ds.Tables[0].Rows[0]["FileNo"].ToString();
        }
    }

    private void FillCombo()
    {
        Ds = obj_File.FillCombo(out StrError);
        if (Ds.Tables.Count > 0)
        {
            if (Ds.Tables[0].Rows.Count > 0)
            {
                ddlProject.DataSource = Ds.Tables[0];
                ddlProject.DataTextField = "PropertyName";
                ddlProject.DataValueField = "PropertyId";
                ddlProject.DataBind();
            }
            //if (Ds.Tables[1].Rows.Count > 0)
            //{
            //    ddlDocumentList.DataSource = Ds.Tables[1];
            //    ddlDocumentList.DataTextField = "DocumentTitle";
            //    ddlDocumentList.DataValueField = "DocumentTitleId";
            //    ddlDocumentList.DataBind();
            //}
            if (Ds.Tables[2].Rows.Count > 0)
            {
                ddlRoom.DataSource = Ds.Tables[2];
                ddlRoom.DataTextField = "Room";
                ddlRoom.DataValueField = "RoomId";
                ddlRoom.DataBind();
            }
            if (Ds.Tables[3].Rows.Count > 0)
            {
                //ddlAisle.DataSource = Ds.Tables[3];
                //ddlAisle.DataTextField = "Aisle";
                //ddlAisle.DataValueField = "AisleId";
                //ddlAisle.DataBind();
               
            }
            if (Ds.Tables[4].Rows.Count > 0)
            {
                //ddlShelf.DataSource = Ds.Tables[4];
                //ddlShelf.DataTextField = "ShelfNo";
                //ddlShelf.DataValueField = "ShelfId";
                //ddlShelf.DataBind();
            }
            if (Ds.Tables[5].Rows.Count > 0)
            {
                ddlDay.DataSource = Ds.Tables[5];
                ddlDay.DataTextField = "Day";
                ddlDay.DataValueField = "DayId";
                ddlDay.DataBind();
            }
            if (Ds.Tables[6].Rows.Count > 0)
            {
                ddlmonth.DataSource = Ds.Tables[6];
                ddlmonth.DataTextField = "Month";
                ddlmonth.DataValueField = "MonthId";
                ddlmonth.DataBind();
            }
            if (Ds.Tables[7].Rows.Count > 0)
            {
                ddlYear.DataSource = Ds.Tables[7];
                ddlYear.DataTextField = "YEAR";
                ddlYear.DataValueField = "YearId";
                ddlYear.DataBind();
            }

            if (Ds.Tables[8].Rows.Count > 0)
            {
                //ddlDocSubType.DataSource = Ds.Tables[8];
                //ddlDocSubType.DataTextField = "DocumentSubTitle";
                //ddlDocSubType.DataValueField = "Id";
                //ddlDocSubType.DataBind();
            }  
        }
    }

    public void ReportGrid(string RepCondition)
    {
        try
        {
            Ds = obj_File.FillReportGrid(RepCondition, out StrError);
            if (Ds.Tables.Count > 0)
            {
                if (Ds.Tables[0].Rows.Count > 0)
                {
                    GrdReport.DataSource = Ds.Tables[0];
                    GrdReport.DataBind();
                }
                else
                {
                    GrdReport.DataSource = null;
                    GrdReport.DataBind();
                }

            }
            else
            {
                GrdReport.DataSource = null;
                GrdReport.DataBind();
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
          

            DataSet DST = new DataSet();

            if (!string.IsNullOrEmpty(Request.QueryString["FileCEId"]))
            {
                FillCombo();

                int FileId = Convert.ToInt32(Request.QueryString["FileCEId"]);
                {
                    DST = obj_File.GetFileDocumentForEdit(FileId, out StrError);

                    if (DST.Tables.Count > 0 && DST.Tables[0].Rows.Count > 0)
                    {

                        txtFileNo.Text = DST.Tables[0].Rows[0]["FileNo"].ToString();

                        if (Convert.ToInt32(DST.Tables[0].Rows[0]["PropertyId"]) > 0)
                        {
                            ddlProject.SelectedValue = Convert.ToInt32(DST.Tables[0].Rows[0]["PropertyId"]).ToString();
                        }
                        txtDate.Text = DST.Tables[0].Rows[0]["DocDate"].ToString();
                        txtExpireDate.Text = DST.Tables[0].Rows[0]["DocExpiryDate"].ToString();
                        txtRenewed.Text = DST.Tables[0].Rows[0]["RenewAfterDate"].ToString();
                        txtAdditionalNotes.Text = DST.Tables[0].Rows[0]["Narration"].ToString();
                        TxtBarcode.Text = DST.Tables[0].Rows[0]["Barcode"].ToString();
                        txtFileName.Text = DST.Tables[0].Rows[0]["FileName"].ToString();

                        if (Convert.ToInt32(DST.Tables[0].Rows[0]["RoomId"]) > 0)
                        {
                            ddlRoom.SelectedValue = Convert.ToInt32(DST.Tables[0].Rows[0]["RoomId"]).ToString();
                            ddlRoom_SelectedIndexChanged(sender, e);
                        }

                        if (Convert.ToInt32(DST.Tables[0].Rows[0]["AisleId"]) > 0)
                        {
                            ddlAisle.SelectedValue = Convert.ToInt32(DST.Tables[0].Rows[0]["AisleId"]).ToString();
                            ddlAisle_SelectedIndexChanged(sender, e);
                        }

                        if (Convert.ToInt32(DST.Tables[0].Rows[0]["ShelfId"]) > 0)
                        {
                            ddlShelf.SelectedValue = DST.Tables[0].Rows[0]["ShelfId"].ToString();
                        }

                        if (Convert.ToInt32(DST.Tables[0].Rows[0]["DayId"]) > 0)
                        {
                            ddlDay.SelectedValue = DST.Tables[0].Rows[0]["DayId"].ToString();
                        }
                        if (Convert.ToInt32(DST.Tables[0].Rows[0]["MonthId"]) > 0)
                        {
                            ddlmonth.SelectedValue = DST.Tables[0].Rows[0]["MonthId"].ToString();
                        }
                        if (Convert.ToInt32(DST.Tables[0].Rows[0]["YearId"]) > 0)
                        {
                            ddlYear.SelectedValue = DST.Tables[0].Rows[0]["YearId"].ToString();
                        }
                    }

                    if (DST.Tables[1].Rows.Count > 0)
                    {
                        GridLogo.DataSource = DST.Tables[1];
                        GridLogo.DataBind();
                        ViewState["CurrentTableLogo"] = DST.Tables[1];
                    }
                    if (DST.Tables[2].Rows.Count > 0)
                    {
                        GrdCompany.DataSource = DST.Tables[2];
                        GrdCompany.DataBind();
                        ViewState["CurrentTable"] = DST.Tables[2];
                    }
                    else
                    {
                        MakeEmptyForm();
                    }
                    DST = null;
                    obj_File = null;
                    BtnSave.Visible = false;
                    if (!FlagEdit)
                        BtnUpdate.Visible = true;
                    if (!FlagDel)
                        BtnDelete.Visible = false;
                    txtDate.Focus();
                }
                CheckUserRight();
            }
            else
            {
                SetInitialRow();
                MakeEmptyForm();
                CheckUserRight();
            }

            
        }
    }

    protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet Ds = new DataSet();
            Ds = obj_File.FillCompanyOnProject(Convert.ToInt32(ddlProject.SelectedValue), out StrError);
            if (Ds.Tables.Count > 0)
            {
                if (Ds.Tables[0].Rows.Count > 0)
                {
                    GrdCompany.DataSource = Ds.Tables[0];
                    GrdCompany.DataBind();

                }
            }
            ddlProject.Focus();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    //protected void ddlDocumentList_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        DataSet Ds = new DataSet();
    //        Ds = obj_File.FillSubTypeOnDocument(Convert.ToInt32(ddlDocumentList.SelectedValue), out StrError);
    //        if (Ds.Tables.Count > 0)
    //        {
    //            if (Ds.Tables[0].Rows.Count > 0)
    //            {
    //                ddlDocSubType.DataSource = Ds.Tables[0];
    //                ddlDocSubType.DataTextField = "DocumentSubTitle";
    //                ddlDocSubType.DataValueField = "Id";
    //                ddlDocSubType.DataBind();
    //            }
    //        }
    //        ddlDocSubType.Focus();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.Message);
    //    }
    //}

    protected void lnkLogo_Click(object sender, EventArgs e)
    {
        try
        {            
            Random random = new Random();
            string filename = string.Empty;
            if (LogoUpload.Visible)
            {
                if (!string.IsNullOrEmpty(txtDocSubTitle.Text))
                {
                    //if (LogoUpload.HasFile)
                    //{
                    lblOfferLogopath.Visible = false;
                    //--Total No of Files--
                    Int64 TotalFiles = System.IO.Directory.GetFiles(Server.MapPath("~/Images/FileCreateEditDelete")).Count();

                    filename = System.IO.Path.GetFileName(LogoUpload.FileName);
                    filename = TotalFiles + "-" + filename;
                    filename = filename.Replace("&", "and");
                    LogoUpload.SaveAs(Server.MapPath("~/Images/FileCreateEditDelete/") + filename);
                    lblOfferLogopath.Text = "~/Images/FileCreateEditDelete/" + filename;
                    AddtoGridLogo(filename);
                    LogoUpload.Focus();
                    //}
                    //else
                    //{
                    //    obj_Comman.ShowPopUpMsg("Please select any file to upload", this.Page);
                    //    LogoUpload.Focus();
                    //}
                }
                else
                {
                    obj_Comman.ShowPopUpMsg("Please select Document Sub Title First..!", this.Page);
                    txtDocSubTitle.Focus();
                }

            }
            else
            {
                AddtoGridLogo(filename);
            }
            MakeEmptyDocument();
        }
        catch (Exception ex)
        {
            obj_Comman.ShowPopUpMsg("Upload status: The file could not be uploaded. The following error occured: " + ex.Message, this.Page);
        }
    }

    private void AddtoGridLogo(string filename)
    {
        try
        {
            if (ViewState["CurrentTableLogo"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTableLogo"];

                DataRow dtTableRow = null;
                bool DupFlag = false;
                int k = 0;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    if (dtCurrentTable.Rows.Count == 1 && string.IsNullOrEmpty(dtCurrentTable.Rows[0]["DocImagePath"].ToString()))
                    {
                        dtCurrentTable.Rows.RemoveAt(0);
                    }
                    if (ViewState["GridindexLogo"] != null)
                    {
                        for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                        {
                            if ((Convert.ToString(dtCurrentTable.Rows[i]["DocImagePath"].ToString()) == Convert.ToString(lblOfferLogopath.Text)))
                            {
                                DupFlag = true;
                                k = i;
                            }
                        }
                        if (DupFlag == true)
                        {
                            //LogoUpload.Visible=true;
                            dtCurrentTable.Rows[k]["DocImagePath"] = !string.IsNullOrEmpty(lblOfferLogopath.Text) ? lblOfferLogopath.Text : "";
                            dtCurrentTable.Rows[k]["DocRefNo"] = !string.IsNullOrEmpty(txtDocRefno.Text) ? txtDocRefno.Text : "";
                            
                            //dtCurrentTable.Rows[k]["DocDate"] = !string.IsNullOrEmpty(txtDocDate.Text) ? txtDocDate.Text : "";
                            dtCurrentTable.Rows[k]["DocumentTitle"] = !string.IsNullOrEmpty(txtSelectDoc.Text) ? txtSelectDoc.Text : "";


                            if (Convert.ToInt32(hdnValue.Value) == 0 && string.IsNullOrEmpty(hdnValue.Value))
                            {
                                if (dtCurrentTable.Rows[k]["DocumentTitleId"] != null)
                                {

                                    dtCurrentTable.Rows[k]["DocumentTitleId"] = dtCurrentTable.Rows[k]["DocumentTitleId"].ToString();
                                }
                                else
                                {
                                    dtCurrentTable.Rows[k]["DocumentTitleId"] = 0;
                                }
                            }
                            else
                            {
                                dtCurrentTable.Rows[k]["DocumentTitleId"] = Convert.ToInt32(hdnValue.Value);
                            }




                            dtCurrentTable.Rows[k]["DocumentSubTitle"] = !string.IsNullOrEmpty(txtDocSubTitle.Text) ? txtDocSubTitle.Text : "";


                            if (Convert.ToInt32(hndSubTitle.Value) == 0 && string.IsNullOrEmpty(hndSubTitle.Value))
                            {
                                if (dtCurrentTable.Rows[k]["Id"] != null)
                                {

                                    dtCurrentTable.Rows[k]["Id"] = dtCurrentTable.Rows[k]["Id"].ToString();
                                }
                                else
                                {
                                    dtCurrentTable.Rows[k]["Id"] = 0;
                                }
                            }
                            else
                            {
                                dtCurrentTable.Rows[k]["Id"] = Convert.ToInt32(hndSubTitle.Value);
                            }

                            //dtCurrentTable.Rows[k]["DocumentSubTitle"] = !string.IsNullOrEmpty(ddlDocSubType.SelectedItem.Text) ? ddlDocSubType.SelectedItem.Text : "";
                            //if (Convert.ToInt32(ddlDocSubType.SelectedValue) > 0)
                            //{
                            //    dtCurrentTable.Rows[k]["Id"] = Convert.ToInt32(ddlDocSubType.SelectedValue);
                            //}
                            //else
                            //{
                            //    dtCurrentTable.Rows[k]["Id"] = Convert.ToInt32(ddlDocSubType.SelectedValue);
                            //}


                            ViewState["CurrentTableLogo"] = dtCurrentTable;
                            GridLogo.DataSource = dtCurrentTable;
                            GridLogo.DataBind();
                            MakeEmptyDocument();
                        }
                        else
                        {
                            dtTableRow = dtCurrentTable.NewRow();
                            int rowindex = Convert.ToInt32(ViewState["GridindexLogo"]);

                            dtTableRow["DocImagePath"] = !string.IsNullOrEmpty(lblOfferLogopath.Text) ? lblOfferLogopath.Text : "";
                            dtTableRow["DocRefNo"] = !string.IsNullOrEmpty(txtDocRefno.Text) ? txtDocRefno.Text : "";
                            //dtTableRow["DocDate"] = !string.IsNullOrEmpty(txtDocDate.Text) ? txtDocDate.Text : "";
                            dtTableRow["DocumentTitle"] = !string.IsNullOrEmpty(txtSelectDoc.Text) ? txtSelectDoc.Text : "";
                            if (Convert.ToInt32(hdnValue.Value) != 0 || !string.IsNullOrEmpty(hdnValue.Value))
                            {

                                dtTableRow["DocumentTitleId"] = Convert.ToInt32(hdnValue.Value);
                            }
                            else
                            {
                                dtTableRow["DocumentTitleId"] = 0;
                            }




                            dtTableRow["DocumentSubTitle"] = !string.IsNullOrEmpty(txtDocSubTitle.Text) ? txtDocSubTitle.Text : "";

                            if (Convert.ToInt32(hndSubTitle.Value) != 0 || !string.IsNullOrEmpty(hndSubTitle.Value))
                            {

                                dtTableRow["Id"] = Convert.ToInt32(hndSubTitle.Value);
                            }
                            else
                            {
                                dtTableRow["Id"] = 0;
                            }
                           


                            //dtTableRow["DocumentSubTitle"] = !string.IsNullOrEmpty(ddlDocSubType.SelectedItem.Text) ? ddlDocSubType.SelectedItem.Text : "";
                            //if (Convert.ToInt32(ddlDocSubType.SelectedValue) > 0)
                            //{
                            //    dtTableRow["Id"] = Convert.ToInt32(ddlDocSubType.SelectedValue);
                            //}
                            //else
                            //{
                            //    dtTableRow["Id"] = Convert.ToInt32(ddlDocSubType.SelectedValue);
                            //}
                            dtCurrentTable.Rows.Add(dtTableRow);

                            ViewState["CurrentTableLogo"] = dtCurrentTable;
                            GridLogo.DataSource = dtCurrentTable;
                            GridLogo.DataBind();
                           MakeEmptyDocument();
                        }
                    }
                    else
                    {


                        for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                        {
                            if ((Convert.ToString(dtCurrentTable.Rows[i]["DocImagePath"]) == Convert.ToString(lblOfferLogopath.Text)))
                            {
                                DupFlag = true;
                                k = i;
                            }
                        }
                        if (DupFlag == true)
                        {
                            dtCurrentTable.Rows[k]["DocImagePath"] = !string.IsNullOrEmpty(lblOfferLogopath.Text) ? lblOfferLogopath.Text : "";
                            //dtCurrentTable.Rows[k]["DocDate"] = !string.IsNullOrEmpty(txtDocDate.Text) ? txtDocDate.Text : "";
                            dtCurrentTable.Rows[k]["DocRefNo"] = !string.IsNullOrEmpty(txtDocRefno.Text) ? txtDocRefno.Text : "";
                            dtCurrentTable.Rows[k]["DocumentTitle"] = !string.IsNullOrEmpty(txtSelectDoc.Text) ? txtSelectDoc.Text : "";
                            if (Convert.ToInt32(hdnValue.Value) != 0 && !string.IsNullOrEmpty(hdnValue.Value))
                            {

                                dtCurrentTable.Rows[k]["DocumentTitleId"] = Convert.ToInt32(hdnValue.Value);
                            }
                            else
                            {
                                dtCurrentTable.Rows[k]["DocumentTitleId"] = 0;
                            }

                            dtCurrentTable.Rows[k]["DocumentSubTitle"] = !string.IsNullOrEmpty(txtDocSubTitle.Text) ? txtDocSubTitle.Text : "";


                            if (Convert.ToInt32(hndSubTitle.Value) == 0 && string.IsNullOrEmpty(hndSubTitle.Value))
                            {
                                if (dtCurrentTable.Rows[k]["Id"] != null)
                                {

                                    dtCurrentTable.Rows[k]["Id"] = dtCurrentTable.Rows[k]["Id"].ToString();
                                }
                                else
                                {
                                    dtCurrentTable.Rows[k]["Id"] = 0;
                                }
                            }
                            else
                            {
                                dtCurrentTable.Rows[k]["Id"] = Convert.ToInt32(hndSubTitle.Value);
                            }
                           
                            ViewState["CurrentTableLogo"] = dtCurrentTable;
                            GridLogo.DataSource = dtCurrentTable;
                            GridLogo.DataBind();
                            MakeEmptyDocument();
                        }
                        else
                        {
                            dtTableRow = dtCurrentTable.NewRow();
                            int rowindex = Convert.ToInt32(ViewState["GridindexLogo"]);

                            dtTableRow["DocImagePath"] = !string.IsNullOrEmpty(lblOfferLogopath.Text) ? lblOfferLogopath.Text : "";
                            dtTableRow["DocRefNo"] = !string.IsNullOrEmpty(txtDocRefno.Text) ? txtDocRefno.Text : "";
                            //dtTableRow["DocDate"] = !string.IsNullOrEmpty(txtDocDate.Text) ? txtDocDate.Text : "";
                            dtTableRow["DocumentTitle"] = !string.IsNullOrEmpty(txtSelectDoc.Text) ? txtSelectDoc.Text : "";
                            if (Convert.ToInt32(hdnValue.Value) != 0 && !string.IsNullOrEmpty(hdnValue.Value))
                            {

                                dtTableRow["DocumentTitleId"] = Convert.ToInt32(hdnValue.Value);
                            }
                            else
                            {
                                dtTableRow["DocumentTitleId"] = 0;
                            }


                            dtTableRow["DocumentSubTitle"] = !string.IsNullOrEmpty(txtDocSubTitle.Text) ? txtDocSubTitle.Text : "";

                            if (Convert.ToInt32(hndSubTitle.Value) != 0 || !string.IsNullOrEmpty(hndSubTitle.Value))
                            {

                                dtTableRow["Id"] = Convert.ToInt32(hndSubTitle.Value);
                            }
                            else
                            {
                                dtTableRow["Id"] = 0;
                            }
                            dtTableRow["FileUploadDocId"] = 0;
                            dtCurrentTable.Rows.Add(dtTableRow);

                            ViewState["CurrentTableLogo"] = dtCurrentTable;
                            GridLogo.DataSource = dtCurrentTable;
                            GridLogo.DataBind();
                            MakeEmptyDocument();
                        }
                    }
                }
                lblOfferLogopath.Text = "";
                LogoUpload.Visible = true;
            }
        }
        catch (Exception ex)
        {
            obj_Comman.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    protected void lnkCancel_Click(object sender, EventArgs e)
    {
        try
        {
            lblOfferLogopath.Text = "";
            LogoUpload.Visible = true;
            MakeEmptyDocument();
            LogoUpload.Focus();
        }
        catch (Exception ex)
        {
            obj_Comman.ShowPopUpMsg("Upload status: The file could not be uploaded. The following error occured: " + ex.Message, this.Page);
        }
    }

    protected void OnSelectedIndexChangedGetDate(object sender, EventArgs e)
    {
        this.txtRenewed.Text = string.Format("{0}/{1}/{2}", this.ddlDay.SelectedItem.Text, this.ddlmonth.SelectedItem.Text, this.ddlYear.SelectedItem.Text);
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        int InsertRow = 0, InsertRowDtls = 0, InserDetails1 = 0;

        try
        {
           
            if (long.Parse(txtFileNo.Text.Length.ToString()) <= 0)
            {
                obj_Comman.ShowPopUpMsg("Enter File No...", this.Page);
                txtFileNo.Focus();
                return;
            }

            if (Check() == true)
            {
                Entity_File.FileNo = txtFileNo.Text.Trim();
                Entity_File.Barcode = TxtBarcode.Text;
                Entity_File.DocRefNo = txtDocRefno.Text;

                if (ddlProject.SelectedIndex > 0)
                {
                    Entity_File.PropertyId = Convert.ToInt32(ddlProject.SelectedValue);
                }
                else
                {
                    Entity_File.PropertyId = 0;
                }
                
                if (string.IsNullOrEmpty(txtDate.Text) || txtDate.Text.Equals("&nbsp;"))
                {
                    Entity_File.DocDate = Convert.ToDateTime("01/01/1975");
                }
                else
                {
                    Entity_File.DocDate = Convert.ToDateTime(txtDate.Text);
                }

                if (string.IsNullOrEmpty(txtExpireDate.Text) || txtExpireDate.Text.Equals("&nbsp;"))
                {
                    Entity_File.DocExpiryDate = Convert.ToDateTime("01/01/1975");
                }
                else
                {
                    Entity_File.DocExpiryDate = Convert.ToDateTime(txtExpireDate.Text);
                }
                
                
                if (ddlRoom.SelectedIndex > 0)
                {
                    Entity_File.RoomId = Convert.ToInt32(ddlRoom.SelectedValue);
                }
                else
                {
                    Entity_File.RoomId = 0;
                }

                if (ddlAisle.SelectedIndex > 0)
                {
                    Entity_File.AisleId = Convert.ToInt32(ddlAisle.SelectedValue);
                }
                else
                {
                    Entity_File.AisleId = 0;
                }

                if (ddlShelf.SelectedIndex > 0)
                {
                    Entity_File.ShelfId = Convert.ToInt32(ddlShelf.SelectedValue);
                }
                else
                {
                    Entity_File.ShelfId = 0;
                }
                if (string.IsNullOrEmpty(txtRenewed.Text) || txtRenewed.Text.Equals("&nbsp;"))
                {
                    Entity_File.RenewAfterDate = Convert.ToDateTime("01/01/1975");
                }
                else
                {
                    Entity_File.RenewAfterDate = Convert.ToDateTime(txtRenewed.Text);
                }

                if (ddlDay.SelectedIndex > 0)
                {
                    Entity_File.DayId = Convert.ToInt32(ddlDay.SelectedValue);
                }
                else
                {
                    Entity_File.DayId = 0;
                }

                if (ddlmonth.SelectedIndex > 0)
                {
                    Entity_File.MonthId = Convert.ToInt32(ddlmonth.SelectedValue);
                }
                else
                {
                    Entity_File.MonthId = 0;
                }

                if (ddlYear.SelectedIndex > 0)
                {
                    Entity_File.YearId = Convert.ToInt32(ddlYear.SelectedValue);
                }
                else
                {
                    Entity_File.YearId = 0;
                }
                Entity_File.FileName = txtFileName.Text;
                Entity_File.Narration = txtAdditionalNotes.Text;                
                Entity_File.UserId = Convert.ToInt32(Session["UserId"]);
                Entity_File.LoginDate = DateTime.Now;

                InsertRow = obj_File.InsertFileDocument(ref Entity_File, out StrError);

                if (InsertRow != 0)
                {
                    
                        if (Convert.ToInt32(ddlProject.SelectedValue) > 0)
                        {
                           
                            for (int j = 0; j < GrdCompany.Rows.Count; j++)
                            {
                                  Entity_File.FileCEDId = InsertRow;
                                  Entity_File.PropertyId = Convert.ToInt32(ddlProject.SelectedValue);
                                 CheckBox Check_Com = (CheckBox)GrdCompany.Rows[j].Cells[0].FindControl("ChkSelect");
                                 if (Check_Com.Checked == true)
                                 {
                                     Entity_File.CompanyId = Convert.ToInt32(GrdCompany.Rows[j].Cells[3].Text);
                                 }
                                 InserDetails1 = obj_File.InsertFileCompanyPropertyDtls(ref Entity_File, out StrError);
                            }                                                       
                        }
                  
                    if (ViewState["CurrentTableLogo"] != null)
                    {
                        DataTable dtInsert = new DataTable();
                        dtInsert = (DataTable)ViewState["CurrentTableLogo"];
                        for (int i = 0; i < dtInsert.Rows.Count; i++)
                        {
                            if (!string.IsNullOrEmpty(dtInsert.Rows[i]["DocImagePath"].ToString()))
                            {
                                Entity_File.FileCEDId = InsertRow;
                                Entity_File.DocumentTitleId = Convert.ToInt32(dtInsert.Rows[i]["DocumentTitleId"]);
                                Entity_File.Id = Convert.ToInt32(dtInsert.Rows[i]["Id"]);
                                Entity_File.DocImagePath = dtInsert.Rows[i]["DocImagePath"].ToString();
                                Entity_File.DocRefNo = dtInsert.Rows[i]["DocRefNo"].ToString();
                               // Entity_File.DocDate = !string.IsNullOrEmpty(dtInsert.Rows[i]["DocDate"].ToString()) ? Convert.ToDateTime(dtInsert.Rows[i]["DocDate"].ToString()) : Convert.ToDateTime("1-july-1975");
                                Entity_File.Status = "IN";
                                InsertRowDtls = obj_File.InsertDocumentDtls(ref Entity_File, out StrError);
                            }
                        }
                   
                }
                    obj_Comman.ShowPopUpMsg("Record Saved Successfully", this.Page);
                    MakeEmptyForm();
                    Entity_File = null;
                    obj_File = null;
            }
        }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {        
        int UpdateRow = 0, InserDetails = 0, InserDetails1 = 0, InsertRowDtls=0;
            try
            {
                DateTime dt;
                
                if (Check() == true)
                {
                    if (ViewState["EditID"] != null)
                    {
                        Entity_File.FileCEDId = Convert.ToInt32(ViewState["EditID"]);
                    }
                    Entity_File.FileNo = txtFileNo.Text.Trim();
                    Entity_File.Barcode = TxtBarcode.Text;
                    Entity_File.DocRefNo = txtDocRefno.Text;
                    if (ddlProject.SelectedIndex > 0)
                    {
                        Entity_File.PropertyId = Convert.ToInt32(ddlProject.SelectedValue);
                    }
                    else
                    {
                        Entity_File.PropertyId = 0;
                    }
                   
                    //if (ddlDocSubType.SelectedIndex > 0)
                    //{
                    //    Entity_File.Id = Convert.ToInt32(ddlDocSubType.SelectedValue);
                    //}
                    //else
                    //{
                    //    Entity_File.Id = 0;
                    //}
                    Entity_File.DocRefNo = txtDocRefno.Text;

                    if (string.IsNullOrEmpty(txtDate.Text) || txtDate.Text.Equals("&nbsp;"))
                    {
                        Entity_File.DocDate = Convert.ToDateTime("01/01/1975");
                    }
                    else
                    {
                        Entity_File.DocDate = Convert.ToDateTime(txtDate.Text);
                    }

                    if (string.IsNullOrEmpty(txtExpireDate.Text) || txtExpireDate.Text.Equals("&nbsp;"))
                    {
                        Entity_File.DocExpiryDate = Convert.ToDateTime("01/01/1975");
                    }
                    else
                    {
                        Entity_File.DocExpiryDate = Convert.ToDateTime(txtExpireDate.Text);
                    }


                    if (ddlRoom.SelectedIndex > 0)
                    {
                        Entity_File.RoomId = Convert.ToInt32(ddlRoom.SelectedValue);
                    }
                    else
                    {
                        Entity_File.RoomId = 0;
                    }

                    if (ddlAisle.SelectedIndex > 0)
                    {
                        Entity_File.AisleId = Convert.ToInt32(ddlAisle.SelectedValue);
                    }
                    else
                    {
                        Entity_File.AisleId = 0;
                    }

                    if (ddlShelf.SelectedIndex > 0)
                    {
                        Entity_File.ShelfId = Convert.ToInt32(ddlShelf.SelectedValue);
                    }
                    else
                    {
                        Entity_File.ShelfId = 0;
                    }
                    if (string.IsNullOrEmpty(txtRenewed.Text) || txtRenewed.Text.Equals("&nbsp;"))
                    {
                        Entity_File.RenewAfterDate = Convert.ToDateTime("01/01/1975");
                    }
                    else
                    {
                        Entity_File.RenewAfterDate = Convert.ToDateTime(txtRenewed.Text);
                    }
                    if (ddlDay.SelectedIndex > 0)
                    {
                        Entity_File.DayId = Convert.ToInt32(ddlDay.SelectedValue);
                    }
                    else
                    {
                        Entity_File.DayId = 0;
                    }

                    if (ddlmonth.SelectedIndex > 0)
                    {
                        Entity_File.MonthId = Convert.ToInt32(ddlmonth.SelectedValue);
                    }
                    else
                    {
                        Entity_File.MonthId = 0;
                    }

                    if (ddlYear.SelectedIndex > 0)
                    {
                        Entity_File.YearId = Convert.ToInt32(ddlYear.SelectedValue);
                    }
                    else
                    {
                        Entity_File.YearId = 0;
                    }
                    Entity_File.Narration = txtAdditionalNotes.Text;
                    Entity_File.FileName = txtFileName.Text;
                    Entity_File.UserId = Convert.ToInt32(Session["UserId"]);
                    Entity_File.LoginDate = DateTime.Now;
                   
                    UpdateRow = obj_File.UpdateFileDocument(ref Entity_File, out StrError);

                    if (UpdateRow != 0)
                    {
                        if (Convert.ToInt32(ddlProject.SelectedValue) > 0)
                        {

                            for (int j = 0; j < GrdCompany.Rows.Count; j++)
                            {
                                Entity_File.FileCEDId = Convert.ToInt32(ViewState["EditID"]);
                                Entity_File.PropertyId = Convert.ToInt32(ddlProject.SelectedValue);
                                CheckBox Check_Com = (CheckBox)GrdCompany.Rows[j].Cells[0].FindControl("ChkSelect");
                                if (Check_Com.Checked == true)
                                {
                                    Entity_File.CompanyId = Convert.ToInt32(GrdCompany.Rows[j].Cells[3].Text);
                                }
                                InserDetails1 = obj_File.InsertFileCompanyPropertyDtls(ref Entity_File, out StrError);
                            }
                        }

                        if (ViewState["CurrentTableLogo"] != null)
                        {
                            DataTable dtInsert = new DataTable();
                            dtInsert = (DataTable)ViewState["CurrentTableLogo"];
                            for (int i = 0; i < dtInsert.Rows.Count; i++)
                            {
                                if (!string.IsNullOrEmpty(dtInsert.Rows[i]["DocImagePath"].ToString()))
                                {
                                    Entity_File.FileCEDId = Convert.ToInt32(ViewState["EditID"]);
                                    Entity_File.DocumentTitleId = Convert.ToInt32(dtInsert.Rows[i]["DocumentTitleId"]);
                                    Entity_File.Id = Convert.ToInt32(dtInsert.Rows[i]["Id"]);
                                    Entity_File.DocImagePath = dtInsert.Rows[i]["DocImagePath"].ToString();
                                    Entity_File.DocRefNo = dtInsert.Rows[i]["DocRefNo"].ToString();
                                   // Entity_File.DocDate = !string.IsNullOrEmpty(dtInsert.Rows[i]["DocDate"].ToString()) ? Convert.ToDateTime(dtInsert.Rows[i]["DocDate"].ToString()) : Convert.ToDateTime("1-july-1975");
                                    Entity_File.Status = "IN";
                                    //InsertRowDtls = obj_File.InsertDocumentDtls(ref Entity_File, out StrError);
                                   // || GridLogo.Rows[i].Cells[9].Text == "&nbsp;"

                                    if (Convert.ToInt32(dtInsert.Rows[i]["FileUploadDocId"]) > 0)
                                    {
                                        Entity_File.FileUploadDocId = Convert.ToInt32(dtInsert.Rows[i]["FileUploadDocId"]); ;

                                        InsertRowDtls = obj_File.UpdateDocumentDtls(ref Entity_File, out StrError);
                                    }                                   
                                    else
                                    {
                                        InsertRowDtls = obj_File.InsertDocumentDtls(ref Entity_File, out StrError);
                                    }
                                }
                            }
                        }

                        obj_Comman.ShowPopUpMsg("Record Updated Successfully", this.Page);
                        MakeEmptyForm();
                        //  ddlOwner.Focus();
                        Entity_File = null;
                        obj_Comman = null;
                    }
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
       // }
    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {

    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        MakeEmptyForm();
        MakeEmptyDocument();
    }

    protected void GrdReport_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int DeleteId = Convert.ToInt32(((ImageButton)GrdReport.Rows[e.RowIndex].Cells[0].FindControl("ImgBtnDelete")).CommandArgument.ToString());

            if (DeleteId != 0)
            {
                Entity_File.FileCEDId = DeleteId;
                Entity_File.UserId = Convert.ToInt32(Session["UserId"]);
                Entity_File.LoginDate = DateTime.Now;
                int iDelete = obj_File.DeleteFileDocument(ref Entity_File, out StrError);
                if (iDelete != 0)
                {
                    obj_Comman.ShowPopUpMsg("Record Deleted Successfully..!", this.Page);
                    MakeEmptyForm();
                }
            }
            Entity_File = null;
            obj_Comman = null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void GrdReport_RowCommand(object sender, GridViewCommandEventArgs e)
    {       
        try
        {
            switch (e.CommandName)
            {

                case ("Select"):
                    {
                        #region Select

                        if (Convert.ToInt32(e.CommandArgument) != 0)
                        {
                            ViewState["EditID"] = Convert.ToInt32(e.CommandArgument);

                            DSA = obj_File.GetFileDocumentForEdit(Convert.ToInt32(e.CommandArgument), out StrError);

                            if (DSA.Tables.Count > 0 && DSA.Tables[0].Rows.Count > 0)
                            {

                                txtFileNo.Text = DSA.Tables[0].Rows[0]["FileNo"].ToString();

                                if (Convert.ToInt32(DSA.Tables[0].Rows[0]["PropertyId"]) > 0)
                                {
                                   
                                    ddlProject.SelectedValue = DSA.Tables[0].Rows[0]["PropertyId"].ToString();
                                }
                                txtDate.Text = DSA.Tables[0].Rows[0]["DocDate"].ToString();
                                txtExpireDate.Text = DSA.Tables[0].Rows[0]["DocExpiryDate"].ToString();
                                txtRenewed.Text = DSA.Tables[0].Rows[0]["RenewAfterDate"].ToString();
                                txtAdditionalNotes.Text = DSA.Tables[0].Rows[0]["Narration"].ToString();
                                TxtBarcode.Text = DSA.Tables[0].Rows[0]["Barcode"].ToString();
                                txtFileName.Text = DSA.Tables[0].Rows[0]["FileName"].ToString();

                                if (Convert.ToInt32(DSA.Tables[0].Rows[0]["RoomId"]) > 0)
                                {
                                    ddlRoom.SelectedValue = DSA.Tables[0].Rows[0]["RoomId"].ToString();
                                    ddlRoom_SelectedIndexChanged(sender, e);
                                }

                                if (Convert.ToInt32(DSA.Tables[0].Rows[0]["AisleId"]) > 0)
                                {
                                    ddlAisle.SelectedValue = DSA.Tables[0].Rows[0]["AisleId"].ToString();
                                    ddlAisle_SelectedIndexChanged(sender, e);
                                }

                                if (Convert.ToInt32(DSA.Tables[0].Rows[0]["ShelfId"]) > 0)
                                {
                                    ddlShelf.SelectedValue = DSA.Tables[0].Rows[0]["ShelfId"].ToString();
                                }

                                if (Convert.ToInt32(DSA.Tables[0].Rows[0]["DayId"]) > 0)
                                {
                                    ddlDay.SelectedValue = DSA.Tables[0].Rows[0]["DayId"].ToString();
                                }
                                if (Convert.ToInt32(DSA.Tables[0].Rows[0]["MonthId"]) > 0)
                                {
                                    ddlmonth.SelectedValue = DSA.Tables[0].Rows[0]["MonthId"].ToString();
                                }
                                if (Convert.ToInt32(DSA.Tables[0].Rows[0]["YearId"]) > 0)
                                {
                                    ddlYear.SelectedValue = DSA.Tables[0].Rows[0]["YearId"].ToString();
                                }
                            }

                            if (DSA.Tables[1].Rows.Count > 0)
                            {
                                GridLogo.DataSource = DSA.Tables[1];
                                GridLogo.DataBind();
                                ViewState["CurrentTableLogo"] = DSA.Tables[1];
                            }
                            if (DSA.Tables[2].Rows.Count > 0)
                            {
                                GrdCompany.DataSource = DSA.Tables[2];
                                GrdCompany.DataBind();
                                ViewState["CurrentTable"] = DSA.Tables[2];
                            }
                            else
                            {
                                MakeEmptyForm();
                            }
                            DSA = null;
                            obj_File = null;
                            BtnSave.Visible = false;
                            if (!FlagEdit)
                                BtnUpdate.Visible = true;
                            if (!FlagDel)
                                BtnDelete.Visible = false;
                            txtDate.Focus();

                        }

                        break;
                        #endregion
                    }              
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    
    protected void DownloadFile(object sender, EventArgs e)
    {
        try
        {            
            LinkButton LB = (LinkButton)sender;
            int RowIndex = Convert.ToInt32(LB.CommandArgument);
            if (!GridLogo.Rows[RowIndex].Cells[6].Text.Equals("&nbsp;"))
            {
                if (!string.IsNullOrEmpty(GridLogo.Rows[RowIndex].Cells[6].Text))
                {
                    Response.Redirect(ResolveUrl(GridLogo.Rows[RowIndex].Cells[6].Text));
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

    protected void GridLogo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            DataSet DSE = new DataSet();
            int Index;
            Index = Convert.ToInt32(e.CommandArgument);
         
            if (e.CommandName == "Select")
            {


                Index = Convert.ToInt32(e.CommandArgument);


                if (ViewState["CurrentTableLogo"] != null)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["CurrentTableLogo"];

                    DSE = obj_File.GetFileDocumentDetailsForEdit(Convert.ToInt32(e.CommandArgument), out StrError);


                    if (DSE.Tables[0].Rows.Count > 0)
                    {
                        ViewState["GridindexLogo"] = Index;
                        LogoUpload.Visible = false;
                        lblOfferLogopath.Visible = true;
                        lblOfferLogopath.Text = DSE.Tables[0].Rows[0]["DocImagePath"].ToString();
                        //txtDocDate.Text = dtCurrentTable.Rows[Index]["DocDate"].ToString();
                        txtSelectDoc.Text = DSE.Tables[0].Rows[0]["DocumentTitle"].ToString();
                        hdnValue.Value = DSE.Tables[0].Rows[0]["DocumentTitleId"].ToString();
                       // txtSelectDoc_TextChanged(sender, e);

                        txtDocSubTitle.Text = DSE.Tables[0].Rows[0]["DocumentSubTitle"].ToString();
                        hndSubTitle.Value = DSE.Tables[0].Rows[0]["Id"].ToString();
                       // ddlDocSubType.SelectedItem = dtCurrentTable.Rows[Index]["DocumentSubTitle"].ToString();
                        //if (dtCurrentTable.Rows[Index]["Id"].ToString())
                        //ddlDocSubType.SelectedValue = dtCurrentTable.Rows[Index]["Id"].ToString();
                        txtDocRefno.Text = DSE.Tables[0].Rows[0]["DocRefNo"].ToString();
                    }
                }
                else
                {
                    MakeEmptyDocument();
                }

            }

            else if (e.CommandName == "Delete")
                {
                database db = new database();
                db.insert("delete FileUploadDoc where  FileUploadDocId ='" + Index + "'");
                obj_Comman.ShowPopUpMsg("Record Deleted Succesfully ...", this.Page);
            }
                
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }

    protected void GridLogo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            if (ViewState["CurrentTableLogo"] != null)
            {
                int id = e.RowIndex;
                DataTable dt = (DataTable)ViewState["CurrentTableLogo"];

                dt.Rows.RemoveAt(id);
                if (dt.Rows.Count > 0)
                {
                    GridLogo.DataSource = dt;
                    ViewState["CurrentTableLogo"] = dt;
                    GridLogo.DataBind();
                }
                else
                {
                    SetInitialRowLogo();
                }
                MakeEmptyDocument();
            }
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }

    #region[Web Services]
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        DMFileDocument Obj_Call = new DMFileDocument();
        string[] SearchList = Obj_Call.GetSuggestRecord(prefixText);
        return SearchList;
    }
    #endregion

    protected void TxtSearch_TextChanged(object sender, EventArgs e)
    {
        StrCondition = TxtSearch.Text.Trim();
        StrCondition = StrCondition.Replace("[", @"\[");
        ReportGrid(StrCondition);
    }

    protected void txtSelectDoc_TextChanged(object sender, EventArgs e)
    {
        try
        {

            if (!string.IsNullOrEmpty(hdnValue.Value))
            {

                int DocTitleId = Convert.ToInt32(hdnValue.Value);


                DataSet Ds = new DataSet();

                Ds = obj_File.FillSubTypeOnDocument(DocTitleId, out StrError);

                if (Ds.Tables.Count > 0)
                {
                    if (Ds.Tables[0].Rows.Count > 0)
                    {
                        //ddlDocSubType.DataSource = Ds.Tables[0];
                        //ddlDocSubType.DataTextField = "DocumentSubTitle";
                        //ddlDocSubType.DataValueField = "Id";
                        //ddlDocSubType.DataBind();
                    }
                }
               // ddlDocSubType.Focus();
            }
            else
            {
                obj_Comman.ShowPopUpMsg("Please Select Valid Document Title", this.Page);
                txtSelectDoc.Text = string.Empty;
                txtSelectDoc.Focus();
               // ddlDocSubType.SelectedValue = "0";
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

      
    }

    protected void ddlRoom_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet Ds = new DataSet();
            Ds = obj_File.FillAisleOnRoom(Convert.ToInt32(ddlRoom.SelectedValue), out StrError);
            if (Ds.Tables.Count > 0)
            {
                if (Ds.Tables[0].Rows.Count > 0)
                {
                    ddlAisle.DataSource = Ds.Tables[0];
                    ddlAisle.DataValueField = "AisleId";
                    ddlAisle.DataTextField = "Aisle";
                    ddlAisle.DataBind();
                }
            }
            ddlAisle.Focus();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void ddlAisle_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet Ds = new DataSet();

            Ds = obj_File.FillShelfOnAisleRoom(Convert.ToInt32(ddlRoom.SelectedValue), Convert.ToInt32(ddlAisle.SelectedValue), out StrError);
            if (Ds.Tables.Count > 0)
            {
                if (Ds.Tables[0].Rows.Count > 0)
                {
                    ddlShelf.DataSource = Ds.Tables[0];
                    ddlShelf.DataValueField = "ShelfId";
                    ddlShelf.DataTextField = "ShelfNo";
                    ddlShelf.DataBind();
                }
            }
            ddlShelf.Focus();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    #region["Web Services"]
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionListSubDocuments(string prefixText, int count, string contextKey)
    {
        DMFileDocument obj_FileMaster = new DMFileDocument();
        String[] SearchList = obj_FileMaster.GetSuggestedRecordForSubDocuments(prefixText);
        return SearchList;
    }
    #endregion

    protected void txtDocSubTitle_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(hndSubTitle.Value))
            {

                int DocSubTitleId = Convert.ToInt32(hndSubTitle.Value);


                DataSet Ds = new DataSet();

                Ds = obj_File.FillDocumentOnSubType(DocSubTitleId, out StrError);

                if (Ds.Tables.Count > 0)
                {
                    if (Ds.Tables[0].Rows.Count > 0)
                    {
                        txtSelectDoc.Text = Ds.Tables[0].Rows[0]["DocumentTitle"].ToString();
                        hdnValue.Value = Ds.Tables[0].Rows[0]["DocumentTitleId"].ToString();
                    }
                }
              
            }
            else
            {
                obj_Comman.ShowPopUpMsg("Please Select Valid Sub Document Title", this.Page);
                txtDocSubTitle.Text = string.Empty;
                txtDocSubTitle.Focus();               
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }


    }

    protected void GrdReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GrdReport.PageIndex = e.NewPageIndex;
            ReportGrid(TxtSearch.Text.Trim());
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void GridLogo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridLogo.PageIndex = e.NewPageIndex;
            GridLogo.DataSource = ViewState["CurrentTableLogo"];
            GridLogo.DataBind();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
