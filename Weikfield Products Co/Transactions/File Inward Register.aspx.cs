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

public partial class Transactions_File_Inward_Register : System.Web.UI.Page
{
    #region[Private Variables]

    DMFileInwardRegister Obj_FileInWard = new DMFileInwardRegister();
    FileInWard Entity_FileInWard = new FileInWard();
    CommanFunction Obj_Comm = new CommanFunction();
    DataSet DS = new DataSet();
    DataSet Dsa = new DataSet();
    private bool Flag = true;
    private string StrError = string.Empty;
    private string StrCondition = string.Empty;
    public string StrCondition1 = string.Empty;
    private static bool FlagAdd = false, FlagDel = false, FlagEdit = false;
    private int FileId = 0;
    #endregion

    #region["Web Services"]
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetFormatedEmployee(string prefixText, int count, string contextKey)
    {
        DMFileInwardRegister obj_Inward = new DMFileInwardRegister();
        String[] SearchList = obj_Inward.GetSuggestedRecordForEmployee(prefixText);
        return SearchList;
    }
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
    //public static string[] GetCompletionListParty(string prefixText, int count, string contextKey)
    //{
    //    DMFileInwardRegister obj_Inward = new DMFileInwardRegister();
    //    String[] SearchList = obj_Inward.GetSuggestedRecordForParty(prefixText);
    //    return SearchList;
    //}
    //#endregion
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

                DataRow[] dtRow = dsChkUserRight1.Tables[1].Select("FormName ='File Inward Register'");
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
                    GrdInReport.Visible = false;
                }
                //Checking Add Right ========                    
                if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["AddAuth"].ToString()) == false)
                {
                    Button1.Visible = false;
                    FlagAdd = true;

                }
                //Checking Print Right ========                    
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CheckUserRight();
            //SetInitialRowInGridIndata();
            MakeFormEmpty();
            txtOutDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            txtOutDate.Enabled = false;
        }

    }

    public void MakeFormEmpty()
    {
        txtCompany.Text = "";
        txtProperty.Text = string.Empty;
        txtSearchFileName.Text = "";
        txtSearchFileNo.Text = "";
        txtEmployee.Text = "";
        txtOutDate.Text = "";
        SetInitialRowInGridIndata();
        txtCompany.Text = string.Empty;
        //StrCondition = "OUT";
        //ReportGrid(StrCondition);
       
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
            dt.Columns.Add("Company", typeof(string));
            dt.Columns.Add("Empname", typeof(string));
            dt.Columns.Add("Barcode", typeof(string));
            dt.Columns.Add("FileInDate", typeof(string));
            dt.Columns.Add("OutwardDate", typeof(string));
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("OutwardStatus", typeof(string));
            dt.Columns.Add("InwardStatus", typeof(string));
            dt.Columns.Add("PropertyId", typeof(Int32));
            dt.Columns.Add("InOutId", typeof(Int32));
            dt.Columns.Add("EmpID", typeof(Int32));
            dt.Columns.Add("FileUploadDocId", typeof(Int32));
            dt.Columns.Add("FileCEDId", typeof(Int32));
            dt.Columns.Add("DocumentTitleId", typeof(Int32));
            dr = dt.NewRow();

            dr["#"] = 0;
            dr["FileNo"] = "";
            dr["FileName"] = "";
            dr["DocumentTitle"] = "";
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
            dr["InOutId"] = 0;
            dr["EmpID"] = 0;
            dr["FileUploadDocId"] = 0;
            dr["FileCEDId"] = 0;
            dr["DocumentTitleId"] = 0;
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

    public void ReportGrid(string StrCondition1)
    {
        try
        {
            DS = Obj_FileInWard.FillReportInGrid(StrCondition1, out StrError);

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
                   // GrdInReport.DataSource = null;
                    //GrdInReport.DataBind();
                }

            }
            else
            {
                SetInitialRowInGridIndata();
                GrdInReport.DataSource = null;
                GrdInReport.DataBind();
            }



        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    protected void btnSaveRecords_Click(object sender, EventArgs e)
    {
        int InserDetails1 = 0, UpdateUploadDoc=0;

        try
        {

            if (!string.IsNullOrEmpty(hdnValue.Value))
            {
                Entity_FileInWard.UserGivenById = Convert.ToInt32(hdnValue.Value);
            }
            else
            {
                Obj_Comm.ShowPopUpMsg("Please Select Given To Employee Name..!",this.Page);
            }
                if (txtEmployee.Text != "")
            {
                
                for (int j = 0; j < GrdInReport.Rows.Count; j++)
                {

                    CheckBox Check_Com = (CheckBox)GrdInReport.Rows[j].Cells[0].FindControl("ChkSelect");
                    if (Check_Com.Checked == true)
                    {
                        Entity_FileInWard.FileCEDId = Convert.ToInt32(GrdInReport.Rows[j].Cells[12].Text);
                        Entity_FileInWard.InOutId = Convert.ToInt32(GrdInReport.Rows[j].Cells[10].Text);
                        Entity_FileInWard.FileUploadDocId = Convert.ToInt32(GrdInReport.Rows[j].Cells[11].Text);
                        Entity_FileInWard.DocumentTitleId = Convert.ToInt32(GrdInReport.Rows[j].Cells[13].Text);
                        Entity_FileInWard.UserGivenToId = Convert.ToInt32(GrdInReport.Rows[j].Cells[14].Text);
                        string CurrentTime = DateTime.Now.ToString("hh:mm tt");
                        Entity_FileInWard.InwardTime = CurrentTime;
                        InserDetails1 = Obj_FileInWard.InsertUpdateFileInOutREcords(ref Entity_FileInWard, out StrError);
                        Entity_FileInWard.Status = "IN";
                        UpdateUploadDoc = Obj_FileInWard.UpdateFileUploadDtable(ref Entity_FileInWard, out StrError);
                    }
                }
                lblError.Text = "Files Inword Successfully";
                //Obj_Comm.ShowPopUpMsg("Files Inword Successfully", this.Page);
                MakeFormEmpty();
                Entity_FileInWard = null;
                Obj_FileInWard = null;

            }
            else
            {
                lblError.Text = "Select Given By Employee";
                MakeFormEmpty();
                //Obj_Comm.ShowPopUpMsg("Select Given By Employee", this.Page);
            }
           ////}ven 
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    //protected void txtSearch_TextChanged(object sender, EventArgs e)
    //{
    //    try
    //    {

    //        DataSet Ds = new DataSet();
    //        int DocTitleId = 0, FileCEDId = 0, CompanyId = 0, SubTitleId = 0;
    //        DataSet DSA = new DataSet();
    //        //int DocTitleId = Convert.ToInt32(hdnValue.Value);
    //        string SearchT = txtSearch.Text;

    //        DSA = Obj_FileInWard.GetDocumentDetails(SearchT, out StrError);
    //        {
    //            if (DSA.Tables.Count > 0)
    //            {
    //                DocTitleId = Convert.ToInt32(DSA.Tables[0].Rows[0]["DocumentTitleId"].ToString());
    //                FileCEDId = Convert.ToInt32(DSA.Tables[0].Rows[0]["#"].ToString());
    //                CompanyId = Convert.ToInt32(DSA.Tables[0].Rows[0]["CompanyId"].ToString());
    //                SubTitleId = Convert.ToInt32(DSA.Tables[0].Rows[0]["Id"].ToString());
    //            }
    //        }

            
    //        txtSearch.Focus();


    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.Message);
    //    }


    //}

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        MakeFormEmpty();
    
    }

    //***************Search By Property**************************
    protected void ImgPropSerch_Click(object sender, ImageClickEventArgs e)
    {
        StrCondition = "OUT";
        int propID = Convert.ToInt32(hdvSerchProj.Value);
        ReportGridByProp(propID,StrCondition);
    }

    public void ReportGridByProp(int PropID, string StrCondition)
    {
        try
        {
            DS = Obj_FileInWard.FillReportInGridByProp(PropID, StrCondition, out StrError);

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
                    // GrdInReport.DataSource = null;
                    //GrdInReport.DataBind();
                }

            }
            else
            {
                SetInitialRowInGridIndata();
                GrdInReport.DataSource = null;
                GrdInReport.DataBind();
            }



        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    //***************End Search By Property**************************

    //***************Search By Company**************************

    protected void imgCompnySearch_Click(object sender, ImageClickEventArgs e)
    {
        StrCondition = "OUT";
        int CompanyID = Convert.ToInt32(hdvSerchCompany.Value);
        ReportGridByCompany(CompanyID, StrCondition);
    }

    public void ReportGridByCompany(int CompID, string StrCondition)
    {
        try
        {
            DS = Obj_FileInWard.FillReportInGridByCompany(CompID, StrCondition, out StrError);

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
                    //SetInitialRowInGridIndata();
                   GrdInReport.DataSource = null;
                    GrdInReport.DataBind();
                }

            }
            else
            {
                SetInitialRowInGridIndata();
                GrdInReport.DataSource = null;
                GrdInReport.DataBind();
            }



        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    //***************End Search By Company**************************

    //***************Search By FileNo**************************

    protected void ImgSearchFileNo_Click(object sender, ImageClickEventArgs e)
    {
        StrCondition = "OUT";
        string FileNo = Convert.ToString(hdnValueFileNo.Value);
        ReportGridByFileNo(FileNo, StrCondition);
    }

    public void ReportGridByFileNo(string FileNo, string StrCondition)
    {
        try
        {
            DS = Obj_FileInWard.FillReportInGridByFileNo(FileNo, StrCondition, out StrError);

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
                }
            }
            else
            {
                SetInitialRowInGridIndata();
                GrdInReport.DataSource = null;
                GrdInReport.DataBind();
            }



        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    //***************End Search By FileNo**************************
    protected void ImgFileNameSearch_Click(object sender, ImageClickEventArgs e)
    {
        StrCondition = "OUT";
        int FileID = Convert.ToInt32(hdvSerchFileName.Value);
        ReportGridByFileName(FileID, StrCondition);
    }

    public void ReportGridByFileName(int FileID, string StrCondition)
    {
        try
        {
            DS = Obj_FileInWard.FillReportInGridByFileName(FileID, StrCondition, out StrError);

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
                    //SetInitialRowInGridIndata();
                    GrdInReport.DataSource = null;
                    GrdInReport.DataBind();
                }

            }
            else
            {
                SetInitialRowInGridIndata();
                GrdInReport.DataSource = null;
                GrdInReport.DataBind();
            }



        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        }
    }
}
