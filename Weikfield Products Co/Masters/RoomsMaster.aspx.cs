﻿using DMS.DataModel;
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

public partial class Masters_RoomsMaster : System.Web.UI.Page
{
    #region Private Variable

    CommanFunction Obj_Comm = new CommanFunction();
    Rooms Entity_Rooms = new Rooms();
    DataSet Ds = new DataSet();
    //DataSet Dsa = new DataSet();
    private string StrCondition = string.Empty;
    private string StrError = string.Empty;
    private bool Flag = true;
    private static bool FlagAdd = false, FlagDel = false, FlagEdit = false;
    DMRooms obj_Rooms = new DMRooms();

    #endregion

    #region  User Funtions
    //User Right Function===========
    public void CheckUserRight()
    {
       // FlagAdd = FlagDel = FlagEdit = false;
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

                DataRow[] dtRow = dsChkUserRight1.Tables[1].Select("FormName ='Rooms Master'");
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
        ViewState["EditID"] = null;
        HttpContext.Current.Cache["Dir"] = "";
        txtRoom.Text = string.Empty;
        TxtSearch.Text = string.Empty;
        if(!FlagAdd)
        BtnSave.Visible = true;
        BtnUpdate.Visible = false;
        BtnDelete.Visible = false;
        BtnCancel.Visible = true;
        ReportGrid("");
        txtRoom.Focus();
        //SetInitialRow();
    }

    public void ReportGrid(string RepCondition)
    {
        Ds = obj_Rooms.FillReportGrid(RepCondition, out StrError);
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
        obj_Rooms = null;
        Ds = null;
    }

    private bool Check()
    {

        Ds = new DataSet();
        Flag = true;
        if (ViewState["EditID"] != null)
            Ds = obj_Rooms.ChkDuplicate(txtRoom.Text, long.Parse(ViewState["EditID"].ToString()), out StrError);
        else
            Ds = obj_Rooms.ChkDuplicate(txtRoom.Text, -1, out StrError);

        if (Ds.Tables.Count > 0)
        {
            if (Ds.Tables[0].Rows.Count > 0)
            {
                if (long.Parse(Ds.Tables[0].Rows[0][0].ToString()) > 0)
                {
                    Flag = false;
                    Obj_Comm.ShowPopUpMsg("Room is Already Present..!", this.Page);
                    txtRoom.Text = string.Empty;
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
                                txtRoom.Text = lnk.Text.ToString();
                                hdnFldUsedCnt.Value = lbl.Text;
                            }
                            BtnSave.Visible = false;
                            if(!FlagEdit)
                            BtnUpdate.Visible = true;

                           
                            if(!FlagDel)
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

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)

            return;

        int i = Convert.ToInt32(hiddenbox.Value);
        if (i == 0)
        {

            int UpdateRow = 0;
            try
            {
                if (Check() == true)
                {
                    UpdateRow = obj_Rooms.UpdateRoomMaster(txtRoom.Text.Trim(), long.Parse(ViewState["EditID"].ToString()), long.Parse((Session["UserID"]).ToString()), out StrError);
                    if (UpdateRow > 0)
                    {
                        Obj_Comm.ShowPopUpMsg("Record Updated Successfully", this.Page);
                        MakeEmptyForm();
                    }

                }

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        int InsertRow = 0;
        try
        {
            if (Check() == true)
            {
                InsertRow = obj_Rooms.InsertRoomMaster(txtRoom.Text.Trim(), long.Parse((Session["UserID"]).ToString()), out StrError);
                //InsertRow = obj_Rooms.InsertRoomMaster(txtRoom.Text.Trim(), long.Parse((Session["UserID"]).ToString()), out StrError);
                if (InsertRow > 0)
                {
                    Obj_Comm.ShowPopUpMsg("Record Saved Successfully", this.Page);
                    MakeEmptyForm();
                }
            }
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        int i = Convert.ToInt32(hiddenbox.Value);
        if (i == 0)
        {
            try
            {
                long DeleteId = 0;
                if (ViewState["EditID"] != null)
                {
                    if (long.Parse(hdnFldUsedCnt.Value.ToString()) > 0)
                    {
                        Obj_Comm.ShowPopUpMsg("Room is in use. Cannot Delete Record...", this.Page);
                        return;
                    }
                    DeleteId = Convert.ToInt32(ViewState["EditID"]);
                }
                if (DeleteId != 0)
                {
                    int iDelete = obj_Rooms.DeleteRoomMaster(DeleteId, Convert.ToInt32(Session["UserId"]), out StrError);

                    if (iDelete != 0)
                    {
                        Obj_Comm.ShowPopUpMsg("Record Deleted Successfully..!", this.Page);
                        MakeEmptyForm();
                    }
                    else
                    {
                        Obj_Comm.ShowPopUpMsg("Room is in use. Cannot Delete Record...", this.Page);
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
    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        MakeEmptyForm();
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
                        where (r.Field<string>("Room").ToLower()).Contains(prefixText.ToLower())
                        select (r.Field<string>("Room"));
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
                        where (r.Field<string>("Room")).Contains(StrCondition)
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
}