using DMS.DataModel;
using DMS.EntityClass;
using DMS.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Masters_CompanyMaster : System.Web.UI.Page
{
    #region Private Variable

    CommanFunction Obj_Comm = new CommanFunction();
    CompanyMaster Entity_Company = new CompanyMaster();
    DataSet Ds = new DataSet();
    private string StrCondition = string.Empty;
    private string StrError = string.Empty;
    private bool Flag = true;
    private static bool FlagAdd = false, FlagDel = false, FlagEdit = false;
     DMCompany obj_Company = new DMCompany();

    #endregion

    #region  User Funtions
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

                DataRow[] dtRow = dsChkUserRight1.Tables[1].Select("FormName ='CompanyMaster'");
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
                    foreach (GridViewRow GRow in GrdCompanyParty.Rows)
                    {
                        GRow.FindControl("ImgDeleteLogo").Visible = false;
                        GRow.FindControl("ImgEditLogo").Visible = false;
                    }
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
                        foreach (GridViewRow GRow in GrdCompanyParty.Rows)
                        {
                            GRow.FindControl("ImgDeleteLogo").Visible = false;
                            BtnDelete.Visible = false;
                            FlagDel = true;
                        }
                     
                    }

                    //Checking Edit Right ========
                    if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["EditAuth"].ToString()) == false)
                    {
                        foreach (GridViewRow GRow in GrdCompanyParty.Rows)
                        {
                            GRow.FindControl("ImgEditLogo").Visible = false;
                            BtnUpdate.Visible = false;
                            FlagEdit = true;

                        }
                  
                    }
                }
                dsChkUserRight.Dispose();
                 //}
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
        txtCompany.Text = string.Empty;
        TxtSearch.Text = string.Empty;
         txtAdditionalNotes.Text = string.Empty;
        BtnSave.Visible = true;
        BtnUpdate.Visible = false;
        BtnDelete.Visible = false;
        BtnCancel.Visible = true;
        SetInitialRow();
        ReportGrid("");
        txtCompany.Focus();
      
        //SetInitialRow();
    }

    private void MakeControlEmpty()
    {
        txtPartyName.Text = string.Empty;
        hdnValue.Value = null;
        ViewState["GridindexLogo"] = null;
        //GrdCompanyParty.DataSource = null;
        //GrdCompanyParty.DataBind();
    }

    public void ReportGrid(string RepCondition)
    {
        Ds = obj_Company.FillReportGrid(RepCondition, out StrError);
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
        // obj_Company = null;
        Ds = null;
    }

    public void SetInitialRow()
    {
        try
        {
            DataTable dtTable = new DataTable();
            DataRow dr;

            dtTable.Columns.Add("#", typeof(int));
            dtTable.Columns.Add("CompanyType", typeof(string));
            dtTable.Columns.Add("CompanyTypeId", typeof(Int32));
            dr = dtTable.NewRow();
            dr["#"] = 0;

            dr["CompanyType"] = string.Empty;
            dr["CompanyTypeId"] = 0;

            dtTable.Rows.Add(dr);           
            GrdCompanyParty.DataSource = dtTable;
            GrdCompanyParty.DataBind();
            ViewState["CurrentTable"] = dtTable;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    private bool Check()
    {
        Ds = new DataSet();
        Flag = true;
        if (ViewState["EditID"] != null)
            Ds = obj_Company.ChkDuplicate(txtCompany.Text, long.Parse(ViewState["EditID"].ToString()), out StrError);
        else
            Ds = obj_Company.ChkDuplicate(txtCompany.Text, -1, out StrError);

        if (Ds.Tables.Count > 0)
        {
            if (Ds.Tables[0].Rows.Count > 0)
            {
                if (long.Parse(Ds.Tables[0].Rows[0][0].ToString()) > 0)
                {
                    Flag = false;
                    Obj_Comm.ShowPopUpMsg("Company is Already Present..!", this.Page);
                    txtCompany.Text = string.Empty;
                }

            }
        }
        return Flag;
    }
        #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            MakeEmptyForm();
            CheckUserRight();
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
                        where (r.Field<string>("Company")).Contains(StrCondition)
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

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        int i = Convert.ToInt32(hiddenbox.Value);
        if (i == 0)
        {
            int UpdateRow = 0, InserDetails1=0;
            try
            {
                if (Check() == true)
                {
                    if (ViewState["EditID"] != null)
                    {
                        Entity_Company.CompanyId = Convert.ToInt32(ViewState["EditID"]);
                    }
                    Entity_Company.Company = txtCompany.Text.Trim();                  
                    Entity_Company.PartyName = txtPartyName.Text;                 
                    Entity_Company.AdditionalNotes = txtAdditionalNotes.Text;                   
                    Entity_Company.UserId = Convert.ToInt32(Session["UserId"]);
                    Entity_Company.LoginDate = DateTime.Now;

                    UpdateRow = obj_Company.UpdateCompanyMaster(ref Entity_Company, out StrError);

                    if (UpdateRow != 0)
                    {
                        for (int j = 0; j < GrdCompanyParty.Rows.Count; j++)
                        {

                            Entity_Company.CompanyId = Convert.ToInt32(ViewState["EditID"]);
                            Entity_Company.CompanyType = GrdCompanyParty.Rows[j].Cells[2].Text;

                            InserDetails1 = obj_Company.InsertCompanyPartyDtls(ref Entity_Company, out StrError);
                        }


                        Obj_Comm.ShowPopUpMsg("Record Updated Successfully", this.Page);
                        MakeEmptyForm();
                       
                        Entity_Company = null;
                        Obj_Comm = null;
                    }
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int DeleteId = 0;
            if (ViewState["EditID"] != null)
            {
                if (long.Parse(hdnFldUsedCnt.Value.ToString()) > 0)
                {
                    Obj_Comm.ShowPopUpMsg("Company is in use. Cannot Delete Record...", this.Page);
                    return;
                }
                DeleteId = Convert.ToInt32(ViewState["EditID"]);
            }
            if (DeleteId != 0)
            {
                Entity_Company.CompanyId = DeleteId;
                Entity_Company.UserId = Convert.ToInt32(Session["UserId"]);
                Entity_Company.LoginDate = DateTime.Now;
                int iDelete = obj_Company.DeleteCompanyMaster(ref Entity_Company, out StrError);

                if (iDelete > 0)
                {
                    Obj_Comm.ShowPopUpMsg("Record Deleted Successfully..!", this.Page);
                    MakeEmptyForm();
                }
                else
                {
                    Obj_Comm.ShowPopUpMsg("Company is in use. Cannot Delete Record...", this.Page);
                    MakeEmptyForm();
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
        int InsertRow = 0, InserDetails1=0;
        try
        {
            if (Check() == true)
            {
                Entity_Company.Company = txtCompany.Text.Trim();
                Entity_Company.PartyName = txtPartyName.Text;              
                Entity_Company.AdditionalNotes = txtAdditionalNotes.Text;
               
                Entity_Company.UserId = Convert.ToInt32(Session["UserId"]);
                Entity_Company.LoginDate = DateTime.Now;

                InsertRow = obj_Company.InsertCompanyMaster(ref Entity_Company, out StrError);

                if (InsertRow > 0)
                {
                    for (int j = 0; j < GrdCompanyParty.Rows.Count; j++)
                    {
                                            
                        Entity_Company.CompanyId = InsertRow;
                        Entity_Company.CompanyType = GrdCompanyParty.Rows[j].Cells[2].Text;

                        InserDetails1 = obj_Company.InsertCompanyPartyDtls(ref Entity_Company, out StrError);
                    }

                    Obj_Comm.ShowPopUpMsg("Record Saved Successfully", this.Page);
                    MakeEmptyForm();
                    
                    Entity_Company = null;
                    Obj_Comm = null;
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        MakeEmptyForm();
        MakeControlEmpty();
    }

    //protected void ImgAddPartyClick(object sender, EventArgs e)
    //{
    //    //////////try
    //    //////////{            
    //    //////////    if (ViewState["CurrentTable"] != null)
    //    //////////    {
    //    //////////        DataTable dt = (DataTable)ViewState["CurrentTable"];
    //    //////////        int count = dt.Rows.Count;
    //    //////////        BindGrid(count);
    //    //////////    }
    //    //////////    else
    //    //////////    {
    //    //////////        BindGrid(1);
    //    //////////    }
    //    //////////    txtPartyName.Text = string.Empty;

    //    //////////    txtPartyName.Focus();   
    //    //////////}
    //    //////////catch (Exception)
    //    //////////{

    //    //////////    throw;
    //    //////////}   



    //    try
    //    {
    //        //int HReplcae = Convert.ToInt32(HFAddItem.Value);

    //        if (ViewState["CurrentTable"] != null)
    //        {
    //            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

    //            DataRow dtTableRow = null;
    //            bool DupFlag = false;
    //            int k = 0;
    //            if (dtCurrentTable.Rows.Count > 0)
    //            {

    //                if (dtCurrentTable.Rows.Count == 1 && string.IsNullOrEmpty(dtCurrentTable.Rows[0]["CompanyType"].ToString()))
    //                {
    //                    dtCurrentTable.Rows.RemoveAt(0);
    //                }
    //                if (ViewState["GridindexLogo"] != null)
    //                {
    //                    for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
    //                    {

    //                        if (Convert.ToString(dtCurrentTable.Rows[i]["CompanyType"]) == txtPartyName.Text)
    //                        {
    //                            DupFlag = true;
    //                            k = i;
    //                        }

    //                    }

    //                    if (DupFlag == true)
    //                    {
    //                        dtCurrentTable.Rows[k]["CompanyType"] = txtPartyName.Text;

    //                        if (Convert.ToInt32(hdnValue.Value) > 0)
    //                        {
    //                            dtCurrentTable.Rows[k]["CompanyTypeId"] = Convert.ToInt32(hdnValue.Value);
    //                        }
    //                        else
    //                        {
    //                            dtCurrentTable.Rows[k]["CompanyTypeId"] = 0;
    //                        }
                               
    //                            ViewState["CurrentTable"] = dtCurrentTable;
    //                            GrdCompanyParty.DataSource = dtCurrentTable;
    //                            GrdCompanyParty.DataBind();
    //                            MakeControlEmpty();                           
    //                    }

    //                    else
    //                    {
    //                        dtTableRow = dtCurrentTable.NewRow();
    //                        int rowindex = Convert.ToInt32(ViewState["GridIndex"]);

    //                        dtTableRow["CompanyType"] = txtPartyName.Text;

    //                        if (Convert.ToInt32(hdnValue.Value) > 0)
    //                        {
    //                            dtTableRow["CompanyTypeId"] = Convert.ToInt32(hdnValue.Value);
    //                        }
    //                        else
    //                        {
    //                            dtTableRow["CompanyTypeId"] = 0;
    //                        }
                                                      
    //                        dtCurrentTable.Rows.Add(dtTableRow);

    //                        ViewState["CurrentTable"] = dtCurrentTable;
    //                        GrdCompanyParty.DataSource = dtCurrentTable;
    //                        GrdCompanyParty.DataBind();
    //                        //MakeControlEmpty();
    //                    }
    //                }
    //                else
    //                {
    //                    for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
    //                    {

    //                        if (Convert.ToString(dtCurrentTable.Rows[i]["CompanyType"]) == txtPartyName.Text)
    //                        {
    //                            DupFlag = true;
    //                            k = i;
    //                        }
    //                    }
    //                    if (DupFlag == true)
    //                    {

    //                        dtCurrentTable.Rows[k]["CompanyType"] = txtPartyName.Text;
    //                        if (Convert.ToInt32(hdnValue.Value) > 0)
    //                        {
    //                            dtCurrentTable.Rows[k]["CompanyTypeId"] = Convert.ToInt32(hdnValue.Value);
    //                        }
    //                        else
    //                        {
    //                            dtCurrentTable.Rows[k]["CompanyTypeId"] = 0;
    //                        }

    //                            ViewState["CurrentTable"] = dtCurrentTable;
    //                            GrdCompanyParty.DataSource = dtCurrentTable;
    //                            GrdCompanyParty.DataBind();
    //                            MakeControlEmpty();
                          
    //                    }

    //                    else
    //                    {
    //                        dtTableRow = dtCurrentTable.NewRow();
    //                        int rowindex = Convert.ToInt32(ViewState["GridIndex"]);

    //                        dtTableRow["CompanyType"] = txtPartyName.Text;

    //                        if (Convert.ToInt32(hdnValue.Value) > 0)
    //                        {
    //                            dtTableRow["CompanyTypeId"] = Convert.ToInt32(hdnValue.Value);
    //                        }
    //                        else
    //                        {
    //                            dtTableRow["CompanyTypeId"] = 0;
    //                        }
                           

    //                        dtCurrentTable.Rows.Add(dtTableRow);

    //                        ViewState["CurrentTable"] = dtCurrentTable;
    //                        GrdCompanyParty.DataSource = dtCurrentTable;
    //                        GrdCompanyParty.DataBind();
    //                       // MakeControlEmpty();

    //                    }

    //                }
    //            }
    //        }
    //    }
    //    catch (Exception ex) { Obj_Comm.ShowPopUpMsg(ex.Message, this.Page); }
    //}



    protected void ImgAddPartyClick(object sender, EventArgs e)
    {
        try
        {
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow dtTableRow = null;
                bool DupFlag = false;
                int k = 0;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    if (dtCurrentTable.Rows.Count == 1 && string.IsNullOrEmpty(dtCurrentTable.Rows[0]["CompanyType"].ToString()))
                    {
                        dtCurrentTable.Rows.RemoveAt(0);
                    }
                    if (ViewState["GridindexLogo"] != null)
                    {
                        k = Convert.ToInt32(ViewState["GridindexLogo"]);

                        if (!string.IsNullOrEmpty(hdnValue.Value))
                        {
                            dtCurrentTable.Rows[k]["CompanyTypeId"] = Convert.ToInt32(hdnValue.Value);
                        }
                        else
                        {
                            dtCurrentTable.Rows[k]["CompanyTypeId"] = 0;
                        }
                        dtCurrentTable.Rows[k]["CompanyType"] = txtPartyName.Text;

                        //dtCurrentTable.Rows[k]["CompanyTypeId"] = Convert.ToInt32(hdnValue.Value);
                        ViewState["CurrentTable"] = dtCurrentTable;
                        GrdCompanyParty.DataSource = dtCurrentTable;
                        GrdCompanyParty.DataBind();
                        MakeControlEmpty();

                    }

                    else
                    {

                        dtTableRow = dtCurrentTable.NewRow();
                        int rowindex = Convert.ToInt32(ViewState["GridindexLogo"]);

                        dtTableRow["CompanyType"] = txtPartyName.Text;

                        if (!string.IsNullOrEmpty(hdnValue.Value))
                        {
                            dtTableRow["CompanyTypeId"] = Convert.ToInt32(hdnValue.Value);
                        }
                        else
                        {
                            dtTableRow["CompanyTypeId"] = 0;
                        }
                      // dtTableRow["CompanyTypeId"] = Convert.ToInt32(hdnValue.Value);
                        dtCurrentTable.Rows.Add(dtTableRow);


                        ViewState["CurrentTable"] = dtCurrentTable;
                        GrdCompanyParty.DataSource = dtCurrentTable;
                        GrdCompanyParty.DataBind();
                        MakeControlEmpty();
                    }

                }
            }
        }
        catch (Exception ex) { throw new Exception(ex.Message); }

    }

    private void BindGrid(int rowcount)
    {
        DataTable dt = new DataTable();
        DataRow dr;       
        if (ViewState["CurrentTable"] != null)
        {
            for (int i = 0; i < rowcount + 1; i++)
            {
                dt = (DataTable)ViewState["CurrentTable"];
                //if (dt.Rows.Count > 0)
                //{
                //    dr = dt.NewRow();
                //   // dr[0] = dt.Rows[0][0].ToString();

                //}
                if (dt.Rows.Count == 1 && (string.IsNullOrEmpty(dt.Rows[0]["CompanyType"].ToString()) || dt.Rows[0]["CompanyType"].ToString().Equals("&nbsp;")))
                {
                    dt.Rows.RemoveAt(0);
                }

            }
            dr = dt.NewRow();
            dr[0] = 0;
            dr[1] = txtPartyName.Text;
            //dr[2] = Convert.ToInt32(hdnValue.Value);
            dt.Rows.Add(dr);

        }
        else
        {
            dr = dt.NewRow();
            dr[0] =0;
            dr[1] = txtPartyName.Text;
            dr[2] = 0;

            dt.Rows.Add(dr);

        }

        // If ViewState has a data then use the value as the DataSource
        if (ViewState["CurrentTable"] != null)
        {
            GrdCompanyParty.DataSource = (DataTable)ViewState["CurrentTable"];
            GrdCompanyParty.DataBind();
        }
        else
        {
            // Bind GridView with the initial data assocaited in the DataTable
            GrdCompanyParty.DataSource = dt;
            GrdCompanyParty.DataBind();

        }
        // Store the DataTable in ViewState to retain the values
        ViewState["CurrentTable"] = dt;

    }

    #region["Web Services"]
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionListParty(string prefixText, int count, string contextKey)
    {
        DMCompany obj_PartyMaster = new DMCompany();
        String[] SearchList = obj_PartyMaster.GetSuggestedRecordForParty(prefixText);
        return SearchList;
    }
    #endregion

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
                            Ds = obj_Company.GetCompanyForEdit(Convert.ToInt32(e.CommandArgument), out StrError);
                            if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                            {
                                txtCompany.Text = Ds.Tables[0].Rows[0]["Company"].ToString();
                               // txtPartyName.Text = Ds.Tables[0].Rows[0]["PartyName"].ToString();
                                
                                txtAdditionalNotes.Text = Ds.Tables[0].Rows[0]["AdditionalNotes"].ToString();

                                if (Ds.Tables[1].Rows.Count > 0)
                                {
                                    GrdCompanyParty.DataSource = Ds.Tables[1];
                                    GrdCompanyParty.DataBind();
                                    ViewState["CurrentTable"] = Ds.Tables[1];
                                }
                               
                            }
                            else
                            {
                                MakeEmptyForm();
                            }
                            Ds = null;
                            obj_Company = null;
                            BtnSave.Visible = false;
                            if (!FlagEdit)
                                BtnUpdate.Visible = true;
                            if (!FlagDel)
                                BtnDelete.Visible = true;
                            txtCompany.Focus();
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
            DMCompany obj_St = new DMCompany();
            DataTable DtNew = (DataTable)HttpContext.Current.Cache["Dir"];
            var query = from r in DtNew.AsEnumerable()
                        where (r.Field<string>("Company").ToLower()).Contains(prefixText.ToLower())
                        select (r.Field<string>("Company"));
            string[] SearchList = query.ToArray();
            return SearchList;
        }
    }


    protected void GrdCompanyParty_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int Index;
            if (e.CommandName == "Select")
            {
                Index = Convert.ToInt32(e.CommandArgument);

                if (ViewState["CurrentTable"] != null)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        ViewState["GridindexLogo"] = Index;
                        txtPartyName.Text = dtCurrentTable.Rows[Index]["CompanyType"].ToString();                       
                    }
                }
                else
                {
                   // MakeEmptyDocument();
                }
            }
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }

    protected void GrdCompanyParty_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            if (ViewState["CurrentTable"] != null)
            {
                int id = e.RowIndex;
                DataTable dt = (DataTable)ViewState["CurrentTable"];

                dt.Rows.RemoveAt(id);
                if (dt.Rows.Count > 0)
                {
                    GrdCompanyParty.DataSource = dt;
                    ViewState["CurrentTable"] = dt;
                    GrdCompanyParty.DataBind();
                }
                else
                {
                    SetInitialRow();
                }
               // MakeEmptyDocument();
            }
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }
   
}