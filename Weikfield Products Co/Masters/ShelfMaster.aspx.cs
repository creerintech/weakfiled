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

public partial class Masters_ShelfMaster : System.Web.UI.Page
{

    #region[Private Variables]
    DataSet Dsa = new DataSet();
    DMAisle Obj_Aisle = new DMAisle();
    AisleMaster Entity_Aisle = new AisleMaster();
    DMShelf Obj_Shelf = new DMShelf();
    Shelf Entity_Shelf = new Shelf();
    CommanFunction Obj_Comm = new CommanFunction();
    DataSet DS = new DataSet();

    private string StrError = string.Empty;
    private string StrCondition = string.Empty;
    private static bool FlagAdd = false, FlagDel = false, FlagEdit = false;
    private bool Flag = true;
    #endregion

    #region[UserDefinedFunction]

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

                DataRow[] dtRow = dsChkUserRight1.Tables[1].Select("FormName ='ShelfMaster'");
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

        txtShelfNo.Focus();
        if (!FlagAdd)
            BtnSave.Visible = true;
        BtnUpdate.Visible = false;
        BtnDelete.Visible = false;
        BtnCancel.Visible = true;
        txtShelfNo.Text = string.Empty;
        TxtSearch.Text = string.Empty;
        FillCombo();
       // FillComboAisle();
        ReportGrid(StrCondition);
        
    }

    private void MakeControlEmpty()
    {
        txtShelfNo.Text = string.Empty;
        ddlRoom.SelectedValue = "0";
        ddlAisle.SelectedValue = "0";
        ReportGrid(StrCondition);
        txtShelfNo.Focus();
    }

    private void ReportGrid(string RepCondition)
    {
        try
        {
            DS = Obj_Shelf.GetShelfList(RepCondition, out StrError);

            if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
            {
                GrdReport.DataSource = DS;
                GrdReport.DataBind();
            }
            else
            {
                GrdReport.DataSource = null;
                GrdReport.DataBind();
            }
            Obj_Shelf = null;
            DS = null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }

    private void FillCombo()
    {
        Dsa = Obj_Aisle.FillCombo(out StrError);
        if (Dsa.Tables.Count > 0)
        {

            if (Dsa.Tables[0].Rows.Count > 0)
            {
                ddlRoom.DataSource = Dsa.Tables[0];
                ddlRoom.DataTextField = "Room";
                ddlRoom.DataValueField = "RoomId";
                ddlRoom.DataBind();
            }
            if (Dsa.Tables[1].Rows.Count > 0)
            {
                ddlAisle.DataSource = Dsa.Tables[1];
                ddlAisle.DataTextField = "Aisle";
                ddlAisle.DataValueField = "AisleId";
                ddlAisle.DataBind();
            }
        }
    }

    private void fillAisle()
    {
        try
        {
            DataSet Ds = new DataSet();
            Ds = Obj_Shelf.FillAisle(Convert.ToInt32(ddlRoom.SelectedValue), out StrError);
            if (Ds.Tables.Count > 0)
            {
                if (Ds.Tables[0].Rows.Count > 0)
                {
                    ddlAisle.DataSource = Ds.Tables[0];
                    ddlAisle.DataTextField = "Aisle";
                    ddlAisle.DataValueField = "AisleId";
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

    private bool Check()
    {
        DataSet Ds = new DataSet();
        Flag = true;
        //if (ViewState["EditID"] != null)

        //    Ds = Obj_Shelf.ChkDuplicate(txtShelfNo.Text.Trim(), Convert.ToInt32(ddlRoom.SelectedValue), Convert.ToInt32(ddlAisle.SelectedValue), long.Parse(ViewState["EditID"].ToString()), out StrError);
        //else
            Ds = Obj_Shelf.ChkDuplicate(txtShelfNo.Text.Trim(),Convert.ToInt32(ddlRoom.SelectedValue),Convert.ToInt32(ddlAisle.SelectedValue), -1,  out StrError);

        if (Ds.Tables.Count > 0)
        {
            if (Ds.Tables[0].Rows.Count > 0)
            {
                if (long.Parse(Ds.Tables[0].Rows[0][0].ToString()) > 0)
                {
                    Flag = false;
                    Obj_Comm.ShowPopUpMsg("This Shelf No Already Exist....!", this.Page);
                    txtShelfNo.Focus();
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

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        DMShelf Obj_Shelf = new DMShelf();
        string[] SearchList = Obj_Shelf.GetSuggestRecord(prefixText);
        return SearchList;
    }

    protected void TxtSearch_TextChanged(object sender, EventArgs e)
    {
        StrCondition = TxtSearch.Text.Trim();
        ReportGrid(StrCondition);
    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        int i = Convert.ToInt32(hiddenbox.Value);
        if (i == 0)
        {
            int UpdateRow = 0;
            try
            {
                if (Check() == true)
                {
                    if (ViewState["EditID"] != null)
                    {
                        Entity_Shelf.ShelfId = Convert.ToInt32(ViewState["EditID"]);
                    }
                    Entity_Shelf.ShelfNo = txtShelfNo.Text.Trim();
                    Entity_Shelf.RoomId =Convert.ToInt32(ddlRoom.SelectedValue);
                    Entity_Shelf.AisleId = Convert.ToInt32(ddlAisle.SelectedValue);
                    Entity_Shelf.UserId = Convert.ToInt32(Session["UserId"]);
                    Entity_Shelf.LoginDate = DateTime.Now;

                    UpdateRow = Obj_Shelf.UpdateShelf(ref Entity_Shelf, out StrError);

                    if (UpdateRow != 0)
                    {
                        Obj_Comm.ShowPopUpMsg("Record Updated Successfully", this.Page);
                        MakeEmptyForm();
                       
                        Entity_Shelf = null;
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
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        int InsertRow = 0;
        try
        {
            if (Check() == true)
            {
                Entity_Shelf.ShelfNo = txtShelfNo.Text.Trim();
                Entity_Shelf.AisleId =Convert.ToInt32(ddlAisle.SelectedValue);
                Entity_Shelf.RoomId = Convert.ToInt32(ddlRoom.SelectedValue);
                Entity_Shelf.UserId = Convert.ToInt32(Session["UserId"]);
                Entity_Shelf.LoginDate = DateTime.Now;

                InsertRow = Obj_Shelf.InsertShelf(ref Entity_Shelf, out StrError);

                if (InsertRow > 0)
                {
                    Obj_Comm.ShowPopUpMsg("Record Saved Successfully", this.Page);
                    //  MakeEmptyForm();
                    //  ddlRoom.Focus();
                    MakeControlEmpty();
                    Entity_Shelf = null;
                    Obj_Comm = null;
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        int i = Convert.ToInt32(hiddenbox.Value);
        if (i == 0)
        {
            try
            {
                int DeleteId = 0;
                if (ViewState["EditID"] != null)
                {
                    if (long.Parse(hdnFldUsedCnt.Value.ToString()) > 0)
                    {
                        Obj_Comm.ShowPopUpMsg("Shelf is in use. Cannot Delete Record...", this.Page);
                        return;
                    }

                    DeleteId = Convert.ToInt32(ViewState["EditID"]);
                }
                if (DeleteId != 0)
                {
                    Entity_Shelf.ShelfId = DeleteId;
                    Entity_Shelf.UserId = Convert.ToInt32(Session["UserId"]);
                    Entity_Shelf.LoginDate = DateTime.Now;
                    int iDelete = Obj_Shelf.DeleteShelf(ref Entity_Shelf, out StrError);
                    if (iDelete != 0)
                    {
                        Obj_Comm.ShowPopUpMsg("Record Deleted Successfully..!", this.Page);
                        MakeEmptyForm();
                    }
                    else
                    {
                        Obj_Comm.ShowPopUpMsg("Shelf is in use. Cannot Delete Record...", this.Page);
                        return;
                    }

                }
                Entity_Shelf = null;
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

                            DS = Obj_Shelf.GetShelfForEdit(Convert.ToInt32(e.CommandArgument), out StrError);

                            if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
                            {
                                txtShelfNo.Text = DS.Tables[0].Rows[0]["ShelfNo"].ToString();
                                ddlRoom.SelectedValue = DS.Tables[0].Rows[0]["RoomId"].ToString();
                                fillAisle();
                                ddlAisle.SelectedValue = DS.Tables[0].Rows[0]["AisleId"].ToString();
                            }
                            else
                            {
                                MakeEmptyForm();
                            }

                            DS = null;
                            Obj_Shelf = null;
                            BtnSave.Visible = false;
                            if (!FlagEdit)
                                BtnUpdate.Visible = true;
                            if (!FlagDel)
                                BtnDelete.Visible = true;
                            txtShelfNo.Focus();
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

    protected void ddlRoom_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillAisle();
    }

    protected void ddlAisle_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}