using DMS.EntityClass;
using DMS.DALSQLHelper;
using DMS.DB;
using DMS.Utility;
using DMS.BussinessLayer;
using DMS.DataModel;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Masters_Document : System.Web.UI.Page
{
    #region Private Variable

    CommanFunction Obj_Comm = new CommanFunction();
    private static bool FlagAdd = false, FlagDel = false, FlagEdit = false;
    DataSet Ds = new DataSet();
    private string StrCondition = string.Empty;
    private string StrError = string.Empty;
    private bool Flag = true;
    DMDocumentTitle obj_DocumentTitle = new DMDocumentTitle();
    FileDocument Entity_File = new FileDocument();
    #endregion

    #region  User Funtions
   

    private void MakeEmptyForm()
    {
        ViewState["EditID"] = null;
        HttpContext.Current.Cache["Dir"] = "";

        txtDocument.Text = string.Empty;
        TxtSearch.Text = string.Empty;
        ddlDepartment.SelectedValue = "0";
        txtSubTitle.Text = string.Empty;
        BindCMB();

        if(!FlagAdd)
        BtnSave.Visible = true;
        BtnUpdate.Visible = false;
        BtnDelete.Visible = false;
       

        ReportGrid("");
        ddlDepartment.Focus();
        SetInitialRow();
    }

    private void MakeControlEmpty()
    {
        txtSubTitle.Text = string.Empty;
        ViewState["GridIndexPersons"] = null;

        //ImgAddGrid.ImageUrl = "~/Images/Icon/ImgAddGrid.png";
        //ImgAddGrid.ToolTip = "Add Grid";
    }

    public void ReportGrid(string RepCondition)
    {
        Ds = obj_DocumentTitle.FillReportGrid(RepCondition, out StrError);
        if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {
            HttpContext.Current.Cache["Dir"] = Ds.Tables[0];
            GrdReport.DataSource = Ds.Tables[0];
            GrdReport.DataBind();
        }
        else
        {
            GrdReport.DataSource = null;
            GrdReport.DataBind();
        }
        obj_DocumentTitle = null;
        Ds = null;
    }

    private void BindCMB()
    {
        DataSet DSC = new DataSet();
        DSC = obj_DocumentTitle.FillDepartment(out StrError);

        if (DSC.Tables.Count > 0)
        {
            if (DSC.Tables[1].Rows.Count > 0)
            {
                ddlDepartment.DataSource = DSC.Tables[1];
                ddlDepartment.DataTextField = "Department";
                ddlDepartment.DataValueField = "DepartmentId";
                ddlDepartment.DataBind();
            }
                       
        }
    }
    private bool Check()
    {

        Ds = new DataSet();
        Flag = true;
        if (ViewState["EditID"] != null)
            Ds = obj_DocumentTitle.ChkDuplicate(txtDocument.Text, long.Parse(ViewState["EditID"].ToString()), out StrError);
        else
            Ds = obj_DocumentTitle.ChkDuplicate(txtDocument.Text, -1, out StrError);

        if (Ds.Tables.Count > 0)
        {
            if (Ds.Tables[0].Rows.Count > 0)
            {
                if (long.Parse(Ds.Tables[0].Rows[0][0].ToString()) > 0)
                {
                    Flag = false;
                    Obj_Comm.ShowPopUpMsg("DocumentTitle is Already Present..!", this.Page);
                    txtDocument.Text = string.Empty;
                }

            }
        }
        return Flag;
    }
    public void SetInitialRow()
    {
        try
        {
            DataTable dtTable = new DataTable();
            DataRow dr;

            dtTable.Columns.Add("#", typeof(int));
            dtTable.Columns.Add("DocumentSubTitle", typeof(string));
            dtTable.Columns.Add("UsedCount", typeof(Int32));
            dr = dtTable.NewRow();

            dr["#"] = 0;
            dr["DocumentSubTitle"] = string.Empty;
            dr["UsedCount"] = 0;


            dtTable.Rows.Add(dr);
            ViewState["CurrentTable"] = dtTable;
            GrdDocument.DataSource = dtTable;
            GrdDocument.DataBind();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }

    //User Right Function===========
    public void CheckUserRight()
    {

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

                DataRow[] dtRow = dsChkUserRight1.Tables[1].Select("FormName ='Document'");
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
                //Checking Print Right ========                    
                if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["PrintAuth"].ToString()) == false)
                {

                }
                //Edit /Delete Column Visible ========
                if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["DelAuth"].ToString()) == false && Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["EditAuth"].ToString()) == false)
                {
                    BtnDelete.Visible = false;
                    BtnUpdate.Visible = false;
                    FlagDel = true;
                    FlagEdit = true;
                }
                else
                {
                    //Checking Delete Right ========
                    if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["DelAuth"].ToString()) == false)
                    {
                        BtnDelete.Visible = false;
                        FlagDel = true;
                    }

                    //Checking Edit Right ========
                    if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["EditAuth"].ToString()) == false)
                    {
                        BtnUpdate.Visible = false;
                        FlagEdit = true;
                    }
                }
                //if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["DelAuth"].ToString()) == false && Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["EditAuth"].ToString()) == false)
                //{
                //    if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["ViewAuth"].ToString()) == true)
                //    {
                //        Obj_Comm.ShowPopUpMsg("You don't have a View Authority to Delete and Update...Please contact Admin", this.Page);
                //        BtnUpdate.Visible = false;
                //        BtnDelete.Visible = false;
                //        GrdReport.Visible = true;
                //        return;
                //    }
                //}
                //else if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["DelAuth"].ToString()) == false && Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["ViewAuth"].ToString()) == false)
                //{
                //    Obj_Comm.ShowPopUpMsg("You don't have a View Authority to Delete ...Please contact Admin", this.Page);
                //    GrdReport.Visible = true;
                //    BtnDelete.Visible = false;
                //    return;
                //}
                //else if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["EditAuth"].ToString()) == false && Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["ViewAuth"].ToString()) == false)
                //{
                //    Obj_Comm.ShowPopUpMsg("You don't have a View Authority to Update...Please contact Admin", this.Page);
                //    BtnUpdate.Visible = false;
                //    GrdReport.Visible = true;
                //    return;
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
 #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
          {
            MakeEmptyForm();
            CheckUserRight();
          }
    }

 [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]

    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        if (string.IsNullOrEmpty((HttpContext.Current.Cache["Dir"]).ToString()))
        {
            DataTable DtNew = null;
            return null;
        }
        else
        {
            DMSalutation obj_St = new DMSalutation();
            DataTable DtNew = (DataTable)HttpContext.Current.Cache["Dir"];
            var query = from r in DtNew.AsEnumerable()
                        where (r.Field<string>("DocumentTitle").ToLower()).Contains(prefixText.ToLower())
                        select (r.Field<string>("DocumentTitle"));
            string[] SearchList = query.ToArray();
            return SearchList;
        }
    }

    protected void TxtSearch_TextChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty((HttpContext.Current.Cache["Dir"]).ToString()))
        {
            DataTable DtNew = null;
        }
        else
        {
            DataTable DtNew = (DataTable)HttpContext.Current.Cache["Dir"];
            StrCondition = TxtSearch.Text.Trim();
            var query = from r in DtNew.AsEnumerable()
                        where (r.Field<string>("DocumentTitle")).Contains(StrCondition)
                        select r;
            if (query != null && query.Count() > 0)
            {
                DataTable DTNEW = query.CopyToDataTable();

                GrdReport.DataSource = DTNEW;
                GrdReport.DataBind();
            }
            else
            {
                GrdReport.DataSource = null;
                GrdReport.DataBind();
            }
        }
    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        MakeEmptyForm();
    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            long DeleteId = 0;
            if (ViewState["EditID"] != null)
            {
                if (long.Parse(hdnFldUsedCnt.Value.ToString()) > 0)
                {
                    Obj_Comm.ShowPopUpMsg("DocumentTitle is in use. Cannot Delete Record...", this.Page);
                    return;
                }
                DeleteId = Convert.ToInt32(ViewState["EditID"]);
            }
            if (DeleteId != 0)
            {
                int iDelete = obj_DocumentTitle.DeleteDocumentTitleMaster(DeleteId, Convert.ToInt32(Session["UserId"]), out StrError);

                if (iDelete != 0)
                {
                    Obj_Comm.ShowPopUpMsg("Record Deleted Successfully..!", this.Page);
                    MakeEmptyForm();
                }
                else
                {
                    Obj_Comm.ShowPopUpMsg("Document Title is in use. Cannot Delete Record...", this.Page);
                    return;
                }
            }

            Obj_Comm = null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        int InsertRow = 0,InserDtls=0;
        try
        {
            if (Check() == true)
            {
                InsertRow = obj_DocumentTitle.InsertDocumentTitleMaster(txtDocument.Text.Trim(), long.Parse((Session["UserID"]).ToString()),Convert.ToInt32(ddlDepartment.SelectedValue), out StrError);
                if (InsertRow > 0)
                {
                    if (ViewState["CurrentTable"] != null)
                    {
                        DataTable dtInsert = new DataTable();
                        dtInsert = (DataTable)ViewState["CurrentTable"];
                        for (int i = 0; i < dtInsert.Rows.Count; i++)
                        {
                            InserDtls=obj_DocumentTitle.InsertDocumentSubtitleDetails(dtInsert.Rows[i]["DocumentSubTitle"].ToString(),InsertRow,out StrError);
                        }
                    }
                    Obj_Comm.ShowPopUpMsg("Record Saved Successfully", this.Page);
                    MakeEmptyForm();
                }
            }
        }

        catch (Exception ex) { throw new Exception(ex.Message); }
    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)

            return;

        int UpdateRow = 0, InserDtls = 0, delete = 0, insertRowDet=0;
        try
        {
            if (Check() == true)
            {
                UpdateRow = obj_DocumentTitle.UpdateDocumentTitleMaster(txtDocument.Text.Trim(), long.Parse(ViewState["EditID"].ToString()), long.Parse((Session["UserID"]).ToString()), Convert.ToInt32(ddlDepartment.SelectedValue), out StrError);
                if (UpdateRow > 0)
                {
                  //  delete=obj_DocumentTitle.DeleteDocumentSubtitleDetails1(Convert.ToInt32(ViewState["EditID"].ToString()),out StrError);
                    if (ViewState["CurrentTable"] != null)
                    {
                        DataTable dtInsert = new DataTable();
                        dtInsert = (DataTable)ViewState["CurrentTable"];

                        for (int i = 0; i < dtInsert.Rows.Count; i++)
                        {
                            if (string.IsNullOrEmpty(dtInsert.Rows[i]["#"].ToString()))
                            {
                                InserDtls = obj_DocumentTitle.InsertDocumentSubtitleDetails(dtInsert.Rows[i]["DocumentSubTitle"].ToString(), Convert.ToInt32(ViewState["EditID"].ToString()), out StrError);
                            }
                            else
                            {
                                insertRowDet = obj_DocumentTitle.UpdateDocumentSubtitleDetails(dtInsert.Rows[i]["DocumentSubTitle"].ToString(), Convert.ToInt32(ViewState["EditID"].ToString()), Convert.ToInt32(dtInsert.Rows[i]["#"].ToString()), Convert.ToInt32(dtInsert.Rows[i]["UsedCount"].ToString()), out StrError);
                            }
                        }

                    }
                    Obj_Comm.ShowPopUpMsg("Record Updated Successfully", this.Page);
                    MakeEmptyForm();
                }

            }

        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }

    protected void GrdReport_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            switch (e.CommandName)
            {
                case ("Select"):
                    {
                        if (Convert.ToInt32(e.CommandArgument) != 0)
                        {

                            ViewState["EditID"] = Convert.ToInt32(e.CommandArgument);

                            LinkButton lnk = (LinkButton)e.Item.FindControl("lbtn_List");
                            Label lbl = (Label)e.Item.FindControl("lblUsedCnt");
                            if (lnk != null)
                            {
                               
                                hdnFldUsedCnt.Value = lbl.Text;
                            }
                            Ds = obj_DocumentTitle.GetRocordtoEdit(Convert.ToInt32(e.CommandArgument), out StrError);
                            if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                            {
                                txtDocument.Text = Ds.Tables[0].Rows[0]["DocumentTitle"].ToString();
                                ddlDepartment.SelectedValue = Ds.Tables[0].Rows[0]["DepartmentId"].ToString();

                                GrdDocument.DataSource = Ds.Tables[1];
                                GrdDocument.DataBind();
                                ViewState["CurrentTable"] = Ds.Tables[1];


                            }
                            else
                            {
                                MakeEmptyForm();
                            }
                            BtnSave.Visible = false;
                            if(!FlagEdit)
                            BtnUpdate.Visible = true;
                            if (!FlagDel)
                            BtnDelete.Visible = true;
                        }

                        break;
                    }
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
   
    //protected void ImgAddDocument_Click(object sender, ImageClickEventArgs e)
    //{
    //    try
    //    {
    //        if (ViewState["CurrentTable"] != null)
    //        {
    //            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
    //            DataRow dtTableRow = null;
    //            bool DupFlag = false;
    //            int k = 0;
    //            //if (dtCurrentTable.Rows.Count > 0)
    //            //{
    //                if (dtCurrentTable.Rows.Count == 1 && string.IsNullOrEmpty(dtCurrentTable.Rows[0]["DocumentSubTitle"].ToString()))
    //                {
    //                    dtCurrentTable.Rows.RemoveAt(0);
    //                }
    //                if (ViewState["GridIndexPersons"] != null)
    //                {
    //                    //k = Convert.ToInt32(ViewState["GridIndexPersons"]);
    //                    //dtCurrentTable.Rows[k]["DocumentSubTitle"] = txtSubTitle.Text;
                       
    //                    //ViewState["CurrentTable"] = dtCurrentTable;
    //                    //GrdDocument.DataSource = dtCurrentTable;
    //                    //GrdDocument.DataBind();
    //                    //MakeControlEmpty();
    //                    for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
    //                    {
    //                        if ((Convert.ToString(dtCurrentTable.Rows[i]["DocumentSubTitle"].ToString()) == Convert.ToString(txtSubTitle.Text)))
    //                        {
    //                            DupFlag = true;
    //                            k = i;
    //                        }
    //                    }
    //                    if (DupFlag == true)
    //                    {

    //                        dtCurrentTable.Rows[k]["DocumentSubTitle"] = txtSubTitle.Text;

    //                        ViewState["CurrentTable"] = dtCurrentTable;
    //                        GrdDocument.DataSource = dtCurrentTable;
    //                        GrdDocument.DataBind();
    //                        MakeControlEmpty();

    //                    }
    //                    else
    //                    {
    //                        dtTableRow = dtCurrentTable.NewRow();
    //                        int rowindex = Convert.ToInt32(ViewState["GridIndexPersons"]);

    //                        dtTableRow["DocumentSubTitle"] = txtSubTitle.Text;
    //                        dtCurrentTable.Rows.Add(dtTableRow);


    //                        ViewState["CurrentTable"] = dtCurrentTable;
    //                        GrdDocument.DataSource = dtCurrentTable;
    //                        GrdDocument.DataBind();
    //                        MakeControlEmpty();
    //                    }
    //                }

    //                else
    //                {


    //                    for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
    //                    {
    //                        if ((Convert.ToString(dtCurrentTable.Rows[i]["DocumentSubTitle"].ToString()) == Convert.ToString(txtSubTitle.Text)))
    //                        {
    //                            DupFlag = true;
    //                            k = i;
    //                        }
    //                    }
    //                    if (DupFlag == true)
    //                    {

    //                        dtCurrentTable.Rows[k]["DocumentSubTitle"] = txtSubTitle.Text;

    //                        ViewState["CurrentTable"] = dtCurrentTable;
    //                        GrdDocument.DataSource = dtCurrentTable;
    //                        GrdDocument.DataBind();
    //                        MakeControlEmpty();

    //                    }
    //                    else
    //                    {
    //                        dtTableRow = dtCurrentTable.NewRow();
    //                        int rowindex = Convert.ToInt32(ViewState["GridIndexPersons"]);

    //                        dtTableRow["DocumentSubTitle"] = txtSubTitle.Text;
    //                        dtCurrentTable.Rows.Add(dtTableRow);


    //                        ViewState["CurrentTable"] = dtCurrentTable;
    //                        GrdDocument.DataSource = dtCurrentTable;
    //                        GrdDocument.DataBind();
    //                        MakeControlEmpty();
    //                    }
    //                }

    //           // }
    //        }
    //    }
    //    catch (Exception ex) { throw new Exception(ex.Message); }
    //}

    protected void ImgAddDocument_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow dtTableRow = null;
                bool DupFlag = false;
                int k = 0;
                //if (dtCurrentTable.Rows.Count > 0)
                //{
                if (dtCurrentTable.Rows.Count == 1 && string.IsNullOrEmpty(dtCurrentTable.Rows[0]["DocumentSubTitle"].ToString()))
                {
                    dtCurrentTable.Rows.RemoveAt(0);
                }
                if (ViewState["GridIndexPersons"] != null)
                {
                    k = Convert.ToInt32(ViewState["GridIndexPersons"]);
                    dtCurrentTable.Rows[k]["DocumentSubTitle"] = txtSubTitle.Text;

                    ViewState["CurrentTable"] = dtCurrentTable;
                    GrdDocument.DataSource = dtCurrentTable;
                    GrdDocument.DataBind();
                    MakeControlEmpty();
                }
                else
                {
                    dtTableRow = dtCurrentTable.NewRow();
                    int rowindex = Convert.ToInt32(ViewState["GridIndexPersons"]);

                    dtTableRow["DocumentSubTitle"] = txtSubTitle.Text;
                    dtCurrentTable.Rows.Add(dtTableRow);

                    ViewState["CurrentTable"] = dtCurrentTable;
                    GrdDocument.DataSource = dtCurrentTable;
                    GrdDocument.DataBind();
                    MakeControlEmpty();
                }
                // }
            }
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }

    protected void GrdDocument_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int Index;
            if (e.CommandName == "Select")
            {               
                ImgAddDocument.ToolTip = "Update";

                Index = Convert.ToInt32(e.CommandArgument);

                if (ViewState["CurrentTable"] != null)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        ViewState["GridIndexPersons"] = Index;
                        txtSubTitle.Text = dtCurrentTable.Rows[Index]["DocumentSubTitle"].ToString();                                                                 
                    }
                }               
            }
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }

    protected void GrdDocument_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            if (ViewState["CurrentTable"] != null)
            {
                int id = e.RowIndex;
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (Convert.ToInt32(dt.Rows[id]["UsedCount"].ToString()) > 0)
                {
                    Obj_Comm.ShowPopUpMsg("Cannot delete record. It is in use...!", this.Page);
                    return;
                }

                //if (Convert.ToInt32(GrdDocument.DataKeys[e.RowIndex].Values["UsedCount"].ToString()) > 0)
                //{
                //    Obj_Comm.ShowPopUpMsg("Cannot delete record. It is in use...!", this.Page);
                //    return;
                //}
                else
                {
                    int DeleteId = Convert.ToInt32(((ImageButton)GrdDocument.Rows[e.RowIndex].Cells[0].FindControl("ImgBtnDelete")).CommandArgument.ToString());
                    if (DeleteId != 0)
                    {
                        if (DeleteId != 0)
                        {
                            //Ent_File.DocumentTitleId = DeleteId;
                            //Ent_File.Id = long.Parse(GrdDocument.DataKeys[e.RowIndex].Values["UsedCount"].ToString());
                            //Ent_File.DeletedBy = Convert.ToInt32(Session["UserID"]);
                            //Ent_File.DeletedBy = DateTime.Now;

                            int iDelete = obj_DocumentTitle.DeleteSubDocument(DeleteId, Convert.ToInt32(dt.Rows[id]["#"].ToString()),1, out StrError);
                            if (iDelete != 0)
                            {
                                Obj_Comm.ShowPopUpMsg("Record Deleted Successfully..!", this.Page);
                                MakeEmptyForm();
                            }
                        }
                        else
                        {
                            Obj_Comm.ShowPopUpMsg("Default User Can't Delete.!", this.Page);
                        }
                    }
                  
                }
                MakeControlEmpty();
            }           
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }
   
}
