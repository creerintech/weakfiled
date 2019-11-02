using DMS.DataModel;
using DMS.EntityClass;
using DMS.Utility;
using System;
using System.Threading;

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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class Transactions_File_Outward_Register : System.Web.UI.Page
{
    #region[Private Variables]

    DMFileInOutWord Obj_FileInOut = new DMFileInOutWord();
    FileInOutReCords Entity_FileInOut = new FileInOutReCords();
    CommanFunction Obj_Comm = new CommanFunction();
    DataSet DS = new DataSet();
    DataSet Dsa = new DataSet();
    private bool Flag = true;
    private string StrError = string.Empty;
    private string StrCondition = string.Empty;
    public string StrCondition1 = string.Empty;
    private static bool FlagAdd = false, FlagDel = false, FlagEdit = false, FlagPrint=false;
    private int FileId = 0;
    #endregion

    #region["Web Services"]
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetFileFormatedFileNo(string prefixText, int count, string contextKey)
    {
        DMFileInOutWord obj_PartyMaster = new DMFileInOutWord();
        String[] SearchList = obj_PartyMaster.GetSuggestedRecordForFileNo(prefixText);
        return SearchList;
    }
    #endregion

    #region["Web Services"]
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetFileFormatedFileName(string prefixText, int count, string contextKey)
    {
        DMFileInOutWord obj_PartyMaster = new DMFileInOutWord();
        String[] SearchList = obj_PartyMaster.GetSuggestedRecordForFileName(prefixText);
        return SearchList;
    }
    #endregion

    #region["Web Services"]
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetAllProjectName(string prefixText, int count, string contextKey)
    {
        DMFileInOutWord obj_PartyMaster = new DMFileInOutWord();
        String[] SearchList = obj_PartyMaster.GetSuggestedAllProjectName(prefixText);
        return SearchList;
    }
    #endregion

    #region["Web Services"]
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetAllCompanyName(string prefixText, int count, string contextKey)
    {
        DMFileInOutWord obj_PartyMaster = new DMFileInOutWord();
        String[] SearchList = obj_PartyMaster.GetSuggestedAllCompanyName(prefixText);
        return SearchList;
    }
    #endregion

    //#region["Web Services"]
    //[System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    //public static string[] GetFileFormatedBarcode(string prefixText, int count, string contextKey)
    //{
    //    DMFileInOutWord obj_PartyMaster = new DMFileInOutWord();
    //    String[] SearchList1 = obj_PartyMaster.GetSuggestedRecordForBarcode(prefixText);
    //    return SearchList1;
    //}
    //#endregion


    #region[UserDefinedFunction]

    private void SetInitialRowInGrid()
    {
        try
        {
            DataTable dt = new DataTable();

            DataRow dr = null;
            dt.Columns.Add("#", typeof(int));
            dt.Columns.Add(new DataColumn("DocImagePath", typeof(string)));
            dt.Columns.Add("DocDate", typeof(string));
            dt.Columns.Add("DocumentTitle", typeof(string));
            dt.Columns.Add("DocumentTitleId", typeof(Int32));
            dt.Columns.Add("DocumentSubTitle", typeof(string));
            dt.Columns.Add("Id", typeof(Int32));
            dt.Columns.Add("DocRefNo", typeof(string));
            dt.Columns.Add("FileCEDId", typeof(Int32));
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("FileUploadDocId", typeof(Int32));
            dr = dt.NewRow();

            dr["#"] = 0;
            dr["DocImagePath"] = "";
            dr["DocDate"] = "";
            dr["DocumentTitle"] = "";
            dr["DocumentTitleId"] = 0;
            dr["DocumentSubTitle"] = "";
            dr["DocRefNo"] = "";
            dr["Id"] = 0;
            dr["FileCEDId"] = 0;
            dr["Status"] = "";
            dr["FileUploadDocId"] = 0;
            dt.Rows.Add(dr);

            //Store the DataTable in ViewState
            ViewState["CurrentTableInwordDoc"] = dt;
            InwordGrid.DataSource = dt;
            InwordGrid.DataBind();

            dt = null;
            dr = null;
        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    private void SetInitialRowInGridIndata()
    {
        try
        {
            DataTable dt = new DataTable();

            DataRow dr = null;
            dt.Columns.Add("#", typeof(int));
            dt.Columns.Add(new DataColumn("FileNo", typeof(string)));
            dt.Columns.Add("FileName", typeof(string));
            dt.Columns.Add("DocumentTitle", typeof(string));
            dt.Columns.Add("DocImagePath", typeof(string));
            dt.Columns.Add("PropertyName", typeof(string));
            dt.Columns.Add("DocumentSubTitle", typeof(string));
            dt.Columns.Add("Company", typeof(string));
            dt.Columns.Add("Empname", typeof(string));
            dt.Columns.Add("Barcode", typeof(string));
            dt.Columns.Add("FileInDate", typeof(string));
            dt.Columns.Add("OutwardDate", typeof(string));
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("OutwardStatus", typeof(string));
            dt.Columns.Add("InwardStatus", typeof(string));
            dt.Columns.Add("PropertyId", typeof(Int32));
            dt.Columns.Add("InID", typeof(Int32));
            dt.Columns.Add("InDetailsId", typeof(Int32));
            dr = dt.NewRow();

            dr["#"] = 0;
            dr["FileNo"] = "";
            dr["FileName"] = "";
            dr["DocumentTitle"] = "";
            dr["DocumentSubTitle"] = "";
            dr["DocImagePath"] = "";
            dr["PropertyName"] = "";
            dr["Company"] = "";
            dr["Empname"] = "";
            dr["Barcode"] = "";
            dr["FileInDate"] = "";
            dr["OutwardDate"] = "";
            dr["Status"] = "";
            dr["OutwardStatus"] = "";
            dr["InwardStatus"] = "";
            dr["PropertyId"] = 0;
            dr["InID"] = 0;
            dr["InDetailsId"] = 0;
            dt.Rows.Add(dr);

            //Store the DataTable in ViewState
            ViewState["CurrentTableInwordData"] = dt;
            GrdInReport.DataSource = dt;
            GrdInReport.DataBind();

        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    private void SetInitialRowOutGrid()
    {
        try
        {
            DataTable dt = new DataTable();

            DataRow dr = null;
            dt.Columns.Add("#", typeof(int));
            dt.Columns.Add(new DataColumn("DocImagePath", typeof(string)));
            dt.Columns.Add("DocDate", typeof(string));
            dt.Columns.Add("DocumentTitle", typeof(string));
            dt.Columns.Add("DocumentTitleId", typeof(Int32));
            dt.Columns.Add("DocumentSubTitle", typeof(string));
            dt.Columns.Add("Id", typeof(Int32));
            dt.Columns.Add("DocRefNo", typeof(string));
            dt.Columns.Add("FileCEDId", typeof(Int32));
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("FileUploadDocId", typeof(Int32));
            dr = dt.NewRow();

            dr["#"] = 0;
            dr["DocImagePath"] = "";
            dr["DocDate"] = "";
            dr["DocumentTitle"] = "";
            dr["DocumentTitleId"] = 0;
            dr["DocumentSubTitle"] = "";
            dr["DocRefNo"] = "";
            dr["Id"] = 0;
            dr["FileCEDId"] = 0;
            dr["Status"] = "";
            dr["FileUploadDocId"] = 0;
            dt.Rows.Add(dr);

            //Store the DataTable in ViewState
            ViewState["CurrentTableOutwordDoc"] = dt;
            InwordGrid.DataSource = dt;
            InwordGrid.DataBind();

            dt = null;
            dr = null;
        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    private void MakeEmptyForm()
    {

        txtFileName.Focus();
        // if (!FlagAdd)
        //BtnSave.Visible = true;

        BtnPrint.Visible = false;
        txtFileNo.Text = string.Empty;
        txtProjectName.Text = string.Empty;
        txtDate.Text = string.Empty;
        txtFileName.Text = string.Empty;
        TxtBarcode.Text = string.Empty;
        TxtSearch.Text = string.Empty;
        //txtSearchProject.Text = string.Empty;
        //txtFileOutDate.Text = string.Empty;
        //txtFileOutNo.Text = string.Empty;
        ////// txtFileOutDate.Text = string.Empty;
        //txtOutFileBarcode.Text = string.Empty;
        //TxtOutFileName.Text = string.Empty;
        FillCombo();
        SetInitialRowInGrid();
        SetInitialRowOutGrid();
        //SetInitialRowInGridIndata();
        StrCondition = "OUT";
        ReportGrid(StrCondition);
        //txtCompany.Visible = false;
        //txtSearchProject.Visible = false;
        //txtSearchFileName.Visible = false;
        txtFileNo.Visible = true;
        ddlFileNo.Visible = false;

        
    }

    public void BindInWordGrid(int FileCEDId)
    {
        try
        {
            DS = Obj_FileInOut.FillInWordGrid(FileCEDId, out StrError);

            //--------------------Inword Grid Bind--------------------------------
            if (DS.Tables.Count > 0)
            {
                if (DS.Tables[0].Rows.Count > 0)
                {
                    InwordGrid.DataSource = DS.Tables[0];
                    InwordGrid.DataBind();
                }
                else
                {
                    InwordGrid.DataSource = null;
                    InwordGrid.DataBind();
                }

            }
            else
            {
                InwordGrid.DataSource = null;
                InwordGrid.DataBind();
            }



        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    private void FillCombo()
    {
        Dsa = Obj_FileInOut.FillCombo(out StrError);
        if (Dsa.Tables.Count > 0)
        {

            if (Dsa.Tables[0].Rows.Count > 0)
            {
                ddlEmployee.DataSource = Dsa.Tables[0];
                ddlEmployee.DataTextField = "Empname";
                ddlEmployee.DataValueField = "EmpID";
                ddlEmployee.DataBind();

            }

        }


    }

    private void FillComboforProject(int PropertyId)
    {
        //int prpertyId = Convert.ToString(hdvSerchProj.Value);
        Dsa = Obj_FileInOut.FillComboForProject(PropertyId, out StrError);
        if (Dsa.Tables.Count > 0)
        {

            if (Dsa.Tables[0].Rows.Count > 0)
            {
                ddlFileNo.DataSource = Dsa.Tables[0];
                ddlFileNo.DataTextField = "FileNo";
                ddlFileNo.DataValueField = "FileCEDId";
                ddlFileNo.DataBind();

            }

        }
    }

    private void FillComboforCompany(int CompanyId)
    {
        //int prpertyId = Convert.ToString(hdvSerchProj.Value);
        Dsa = Obj_FileInOut.FillComboForCompany(CompanyId, out StrError);
        if (Dsa.Tables.Count > 0)
        {

            if (Dsa.Tables[0].Rows.Count > 0)
            {
                ddlFileNo.DataSource = Dsa.Tables[0];
                ddlFileNo.DataTextField = "FileNo";
                ddlFileNo.DataValueField = "FileCEDId";
                ddlFileNo.DataBind();

            }

        }
    }

    //public void Clear()
    //{
    //    txtBarcodeOut.Text = TxtBarcode.Text = txtDate.Text = txtFileName.Text = txtFileNameOut.Text = txtFileNo.Text = txtFileNoOut.Text = txtFileNoOutShow.Text = txtOutDate.Text = txtSearch.Text = txtSearchProject.Text = "";
    //    ddlEmployee.SelectedValue = ddlGivenBy.SelectedValue = "0";

    //}

    public void ReportGrid(string StrCondition1)
    {
        try
        {
            DS = Obj_FileInOut.FillReportInGrid(StrCondition1, out StrError);

            //--------------------Inword Grid Bind--------------------------------
            if (DS.Tables.Count > 0)
            {
                if (DS.Tables[0].Rows.Count > 0)
                {
                    GrdInReport.DataSource = DS.Tables[0];
                    GrdInReport.DataBind();
                }
                else
                {
                    SetInitialRowInGridIndata();
                    //GrdInReport.DataSource = null;
                    //GrdInReport.DataBind();
                }
            }
            else
            {                
                GrdInReport.DataSource = null;
                GrdInReport.DataBind();
            }
        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    #endregion
    public void CheckUserRight()
    {
        FlagAdd = FlagDel = FlagEdit = FlagPrint = false;
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

                DataRow[] dtRow = dsChkUserRight1.Tables[1].Select("FormName ='File Outward Register'");
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
                  InwordGrid.Visible = false;
                    //GrdInReport.Visible = false;
                }
                //Checking Add Right ========                    
                if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["AddAuth"].ToString()) == false)
                {
                    btnSaveRecords.Visible = false;
                    FlagAdd = true;

                }
                //Checking Print Right ========                    
                if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["PrintAuth"].ToString()) == false)
                {
                            BtnPrint.Visible = false;
                            FlagPrint = true;
                       
                }
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
                if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["DelAuth"].ToString()) == false)
                {
                    foreach (GridViewRow GRow in GrdInReport.Rows)
                    {
                        GRow.FindControl("ImgBtnDelete").Visible = false;
                        FlagDel = true;
                    }
                }
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            MakeEmptyForm();
            CheckUserRight();
            txtDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            txtDate.Enabled = false;

        }
    }

    protected void btnSaveRecords_Click(object sender, EventArgs e)
    {
        int InsertRow = 0, InserDetails1 = 0, UpdateUploadDoc = 0,InserDetails2 = 0;

        try
        {            
            Entity_FileInOut.FileCEDId = Convert.ToInt32(Session["fileID"]);
            Entity_FileInOut.FileNo = txtFileNo.Text;
            Entity_FileInOut.Barcode = TxtBarcode.Text.Trim();
            Entity_FileInOut.FileName = txtFileName.Text.Trim();
           
            if (ddlEmployee.SelectedIndex > 0)
            {
                Entity_FileInOut.EmpID = Convert.ToInt32(ddlEmployee.SelectedValue);
            }
            else
            {
                Entity_FileInOut.EmpID = 0;
            }

            if (string.IsNullOrEmpty(txtDate.Text) || txtDate.Text.Equals("&nbsp;"))
            {
                Entity_FileInOut.FileInDate = Convert.ToDateTime("01/01/1975");
            }
            else
            {
                Entity_FileInOut.FileInDate = Convert.ToDateTime(txtDate.Text);
            }
            Entity_FileInOut.Status = "OUT";
            Entity_FileInOut.PropertyId = Convert.ToInt32(hdnProjectId.Value);
            Entity_FileInOut.UserId = Convert.ToInt32(Session["UserId"]);
            Entity_FileInOut.LoginDate = DateTime.Now;

            if (Convert.ToInt32(ddlEmployee.SelectedValue) > 0)
            {

                //********insert into FileInWordRecords**************************
               
                // start Used For Print Reciepts 
                InsertRow = Obj_FileInOut.InsertFileInWordRecords(ref Entity_FileInOut, out StrError);
                ////end

                for (int j = 0; j < InwordGrid.Rows.Count; j++)
                {
                    Entity_FileInOut.InID = InsertRow;
                    Entity_FileInOut.UserGivenToId = Convert.ToInt32(ddlEmployee.SelectedValue);
                    CheckBox Check_Com = (CheckBox)InwordGrid.Rows[j].Cells[0].FindControl("ChkSelect");
                    if (Check_Com.Checked == true)
                    {
                        Entity_FileInOut.Status = "OUT";
                        string CurrentTime = DateTime.Now.ToString("h:mm:ss tt");
                        Entity_FileInOut.OutWardTime = CurrentTime;
                        Entity_FileInOut.DocumentTitleId = Convert.ToInt32(InwordGrid.Rows[j].Cells[6].Text);
                        Entity_FileInOut.FileUploadDocId = Convert.ToInt32(InwordGrid.Rows[j].Cells[7].Text);
                        Entity_FileInOut.OutWardStatus = "OUT";


                        InserDetails1 = Obj_FileInOut.InsertFileInRecordsDetails(ref Entity_FileInOut, out StrError);
                        //********insert into FileInRecordsDetails**************************

                        InserDetails2 = Obj_FileInOut.InsertUpdateFileInOutREcords(ref Entity_FileInOut, out StrError);
                        UpdateUploadDoc = Obj_FileInOut.UpdateFileUploadDtable(ref Entity_FileInOut, out StrError);
                    }

                }
                 
                Obj_Comm.ShowPopUpMsg("Files Outword Successfully", this.Page);

                MakeEmptyForm();
                Entity_FileInOut = null;
                Obj_FileInOut = null;

                if (InsertRow > 0 && InserDetails1 > 0)
                {
                    ViewState["EditID"] = InsertRow;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "PrintAftersave", "PrintAftersave();", true);
                    BtnPrint.Visible = true;

                    //Response.Redirect("~/Transactions/File Outward Register.aspx");
                }
            }
            else
            {
                Obj_Comm.ShowPopUpMsg("Please Select Emplyoee first..!", this.Page);
            
            }
            ////}
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        //if (rbtnFileNo.Checked)
        //{
            try
            {
                string selectFileNo = Convert.ToString(hdnValue.Value);
                DataSet Ds = new DataSet();

                Ds = Obj_FileInOut.FillOtherFeilds(selectFileNo, out StrError);

                if (Ds.Tables.Count > 0)
                {
                    if (Ds.Tables[0].Rows.Count > 0)
                    {
                        FileId = Convert.ToInt32(Ds.Tables[0].Rows[0]["FileCEDId"].ToString());
                        Session["fileID"] = FileId;
                        txtFileNo.Text = Ds.Tables[0].Rows[0]["FileNo"].ToString();
                        TxtBarcode.Text = Ds.Tables[0].Rows[0]["Barcode"].ToString();
                        txtFileName.Text = Ds.Tables[0].Rows[0]["FileName"].ToString();

                        int FileNo = Convert.ToInt32(Ds.Tables[0].Rows[0]["FileCEDId"].ToString());
                        BindInWordGrid(FileNo);
                    }
                }
                txtFileNo.Focus();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
       //}

    }

    protected void InwordGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Print")
        {
            if (e.CommandArgument != "")
            {
                string url = Convert.ToString(e.CommandArgument).Replace("~", "..");
                //string script = string.Format("window.open('{0}');", url);
                //url="../Images/FileCreateEditDelete/38-ListOfSundryDebitors.xls";
                //Page.ClientScript.RegisterStartupScript(this.GetType(),"newPage" + UniqueID, script, true);
                //Response.Redirect(url);
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('" + url + "','_newtab');", true);
                Context.Response.Write("<script language='javascript'>window.open('" + url + "','_newtab');</script>");
            }
        }
    }

    //protected void rbtnFileNo_CheckedChanged(object sender, EventArgs e)
    //{
    //    txtSearch.Visible = true;
    //    txtSearchProject.Visible = false;
    //    txtSearchFileName.Visible = false;
    //    txtCompany.Visible = false;
    //    txtFileNo.Visible = true;
    //    ddlFileNo.Visible = false;

    //}

    //protected void rbtnProject_CheckedChanged(object sender, EventArgs e)
    //{
    //    txtSearchProject.Visible = true;
    //    txtSearch.Visible = false;
    //    txtSearchFileName.Visible = false;
    //    txtCompany.Visible = false;
    //    txtFileNo.Visible = false;
    //    ddlFileNo.Visible = true;
    //}

    //protected void rbtnCompany_CheckedChanged(object sender, EventArgs e)
    //{
    //    txtSearchProject.Visible = false;
    //    txtSearchFileName.Visible = false;
    //    txtSearch.Visible = false;
    //    txtCompany.Visible = true;
    //    txtFileNo.Visible = false;
    //    ddlFileNo.Visible = true;
    //}

    //protected void rbtnFileName_CheckedChanged(object sender, EventArgs e)
    //{
    //    txtSearchProject.Visible = false;
    //    txtSearchFileName.Visible = true;
    //    txtSearch.Visible = false;
    //    txtCompany.Visible = false;
    //    txtFileNo.Visible = true;
    //    ddlFileNo.Visible = false;
    //}

    //protected void txtSearchProject_TextChanged(object sender, EventArgs e)
    //{
    //    if (rbtnProject.Checked)
    //    {
    //        try
    //        {
    //            int selectProjectId = Convert.ToInt32(hdvSerchProj.Value);
    //            FillComboforProject(selectProjectId);
    //            Session["FillddlFileNo"] = "FromProj";
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception(ex.Message);
    //        }
    //    }
    //}

    protected void ddlFileNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["FillddlFileNo"]) == "FromProj")
        {
            //if (rbtnProject.Checked)
            //{
                try
                {
                    string selectFileNo = Convert.ToString(ddlFileNo.SelectedItem.Text);
                    DataSet Ds = new DataSet();

                    Ds = Obj_FileInOut.FillOtherFeilds(selectFileNo, out StrError);

                    if (Ds.Tables.Count > 0)
                    {
                        if (Ds.Tables[0].Rows.Count > 0)
                        {
                            FileId = Convert.ToInt32(Ds.Tables[0].Rows[0]["FileCEDId"].ToString());
                            Session["fileID"] = FileId;
                            txtFileNo.Text = Ds.Tables[0].Rows[0]["FileNo"].ToString();
                            TxtBarcode.Text = Ds.Tables[0].Rows[0]["Barcode"].ToString();
                            txtFileName.Text = Ds.Tables[0].Rows[0]["FileName"].ToString();

                            int FileNo = Convert.ToInt32(Ds.Tables[0].Rows[0]["FileCEDId"].ToString());
                            BindInWordGrid(FileNo);
                        }
                    }
                    txtFileNo.Focus();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
           // }
        }
        else if (Convert.ToString(Session["FillddlFileNo"]) == "FromCompany")
        {
            //if (rbtnCompany.Checked)
            //{
                try
                {
                    string selectFileNo = Convert.ToString(ddlFileNo.SelectedItem.Text);
                    DataSet Ds = new DataSet();

                    Ds = Obj_FileInOut.FillOtherFeilds(selectFileNo, out StrError);

                    if (Ds.Tables.Count > 0)
                    {
                        if (Ds.Tables[0].Rows.Count > 0)
                        {
                            FileId = Convert.ToInt32(Ds.Tables[0].Rows[0]["FileCEDId"].ToString());
                            Session["fileID"] = FileId;
                            txtFileNo.Text = Ds.Tables[0].Rows[0]["FileNo"].ToString();
                            TxtBarcode.Text = Ds.Tables[0].Rows[0]["Barcode"].ToString();
                            txtFileName.Text = Ds.Tables[0].Rows[0]["FileName"].ToString();

                            int FileNo = Convert.ToInt32(Ds.Tables[0].Rows[0]["FileCEDId"].ToString());
                            BindInWordGrid(FileNo);
                        }
                    }
                    txtFileNo.Focus();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
           // }
        }


    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        MakeEmptyForm();
        //Response.Redirect("~/Transactions/FileOutNew.aspx");
    }

    //protected void txtCompany_TextChanged(object sender, EventArgs e)
    //{
    //    //if (rbtnCompany.Checked)
    //    //{
    //        try
    //        {
    //            int selectCompanyId = Convert.ToInt32(hdvSerchCompany.Value);
    //            FillComboforCompany(selectCompanyId);
    //            Session["FillddlFileNo"] = "FromCompany";

                
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception(ex.Message);
    //        }
    //    //}
    //}

    //protected void txtSearchFileName_TextChanged(object sender, EventArgs e)
    //{
    //    //if (rbtnFileName.Checked)
    //    //{
    //        try
    //        {
    //            int selectFileID = Convert.ToInt32(hdvSerchFileName.Value);
    //            DataSet Ds = new DataSet();

    //            Ds = Obj_FileInOut.FillOtherFeildsForFilename(selectFileID, out StrError);

    //            if (Ds.Tables.Count > 0)
    //            {
    //                if (Ds.Tables[0].Rows.Count > 0)
    //                {
    //                    FileId = Convert.ToInt32(Ds.Tables[0].Rows[0]["FileCEDId"].ToString());
    //                    Session["fileID"] = FileId;
    //                    txtFileNo.Text = Ds.Tables[0].Rows[0]["FileNo"].ToString();
    //                    TxtBarcode.Text = Ds.Tables[0].Rows[0]["Barcode"].ToString();
    //                    txtFileName.Text = Ds.Tables[0].Rows[0]["FileName"].ToString();

    //                    int FileNo = Convert.ToInt32(Ds.Tables[0].Rows[0]["FileCEDId"].ToString());
    //                    BindInWordGrid(FileNo);
    //                }
    //            }
    //            txtFileNo.Focus();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception(ex.Message);
    //        }
    //   // }

    //}

    protected void GrdInReport_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int DeleteId = Convert.ToInt32(((ImageButton)GrdInReport.Rows[e.RowIndex].Cells[0].FindControl("ImgBtnDelete")).CommandArgument.ToString());

            if (DeleteId != 0)
            {
                Entity_FileInOut.InOutId = DeleteId;
                Entity_FileInOut.UserId = Convert.ToInt32(Session["UserId"]);
                Entity_FileInOut.LoginDate = DateTime.Now;
                int iDelete = Obj_FileInOut.DeleteOutWardFileDocument(ref Entity_FileInOut, out StrError);
                if (iDelete != 0)
                {
                    Obj_Comm.ShowPopUpMsg("Record Deleted Successfully..!", this.Page);
                    MakeEmptyForm();
                }
            }
            Entity_FileInOut = null;
            Obj_Comm = null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    #region["Web Services"]
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionListParty(string prefixText, int count, string contextKey)
    {
        DMFileInOutWord obj_PartyMaster = new DMFileInOutWord();
        String[] SearchList = obj_PartyMaster.GetSuggestedRecordForParty(prefixText);
        return SearchList;
    }
    #endregion

    protected void TxtSearch_TextChanged(object sender, EventArgs e)
    {
        try
        {

            DataSet Ds = new DataSet();
            int DocTitleId = 0, FileCEDId = 0, CompanyId = 0, SubTitleId = 0;
            DataSet DSA = new DataSet();
            //int DocTitleId = Convert.ToInt32(hdnValue.Value);
            string SearchT = TxtSearch.Text;

            DSA = Obj_FileInOut.GetDocumentDetails(SearchT, out StrError);
            {
                if (DSA.Tables.Count > 0)
                {
                    //DocTitleId = Convert.ToInt32(DSA.Tables[0].Rows[0]["DocumentTitleId"].ToString());
                    FileCEDId = Convert.ToInt32(DSA.Tables[0].Rows[0]["#"].ToString());
                    CompanyId = Convert.ToInt32(DSA.Tables[0].Rows[0]["CompanyId"].ToString());
                    //SubTitleId = Convert.ToInt32(DSA.Tables[0].Rows[0]["Id"].ToString());
                }
            }

            Ds = Obj_FileInOut.FillDocumentDetails(DocTitleId, SubTitleId, FileCEDId, CompanyId, out StrError);

            if (Ds.Tables.Count > 0)
            {
                if (Ds.Tables[0].Rows.Count > 0)
                {
                    FileId = Convert.ToInt32(DSA.Tables[0].Rows[0]["#"].ToString());
                    Session["fileID"] = FileId;
                    txtFileNo.Text = Ds.Tables[0].Rows[0]["FileNo"].ToString();
                    TxtBarcode.Text = Ds.Tables[0].Rows[0]["Barcode"].ToString();
                    txtProjectName.Text = Ds.Tables[0].Rows[0]["PropertyName"].ToString();
                    hdnProjectId.Value = Ds.Tables[0].Rows[0]["PropertyId"].ToString();
                    txtFileName.Text = Ds.Tables[0].Rows[0]["FileName"].ToString();

                    // int FileNo = Convert.ToInt32(Ds.Tables[0].Rows[0]["FileCEDId"].ToString());

                }
                if (Ds.Tables[1].Rows.Count > 0)
                {
                    InwordGrid.DataSource = Ds.Tables[1];
                    InwordGrid.DataBind();
                    ViewState["FileDocDetails"] = Ds.Tables[1];
                }
                else
                {
                    InwordGrid.DataSource = null;
                    InwordGrid.DataBind();
                }
            }
            TxtSearch.Focus();
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
            if (!InwordGrid.Rows[RowIndex].Cells[4].Text.Equals("&nbsp;"))
            {
                if (!string.IsNullOrEmpty(InwordGrid.Rows[RowIndex].Cells[4].Text))
                {
                    Response.Redirect(ResolveUrl(InwordGrid.Rows[RowIndex].Cells[4].Text));
                }
                else
                {
                    Obj_Comm.ShowPopUpMsg("There is no any file to view..", this.Page);
                    LB.Focus();
                }
            }
            else
            {
                Obj_Comm.ShowPopUpMsg("There is no any file to view..", this.Page);
                LB.Focus();
            }
        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);

        }
    }

    protected void BtnPrint_Click(object sender, EventArgs e)
    {
        try
        {
            int Id = Convert.ToInt32(ViewState["EditID"]);
            string str = string.Empty;

            FileOutwardRecieptPdf(Id, str);           
        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        }      
    }

    private void FileOutwardRecieptPdf(Int32 ID, string str)
    {

        ReportDocument CRpt = new ReportDocument();
        //DMOrderAcceptance Obj_Dispatch = new DMOrderAcceptance();
        DMReport Obj_Report = new DMReport();
        DataSet DS = new DataSet();
        string strError = string.Empty;
        string PDF = string.Empty;

        //     ID = Convert.ToInt32(Request.QueryString["ID"]);
        DS = Obj_Report.GetFileoutwordDetaiRpt(ID, out strError);

        if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
        {           
            DS.Tables[0].TableName = "OutwardFile";
            DS.Tables[1].TableName = "OutwardDetails";


            CRpt.Load(Server.MapPath("~/PrintReport/CryForOutwardFileDtls.rpt"));
            CRpt.SetDataSource(DS);
         
            Int64 TotalFiles = System.IO.Directory.GetFiles(Server.MapPath("~/Pdf/FileOutwardDetails")).Count();
            PDF = Server.MapPath(@"~/Pdf/FileOutwardDetails/" + "FOD" + "_" + ID.ToString() + ".pdf").Trim();
            CRpt.ExportToDisk(ExportFormatType.PortableDocFormat, PDF);         
        }
        Response.Redirect(@"~/Pdf/FileOutwardDetails/" + "FOD" + "_" + ID.ToString() + ".pdf", false);
       
    }
   
}
