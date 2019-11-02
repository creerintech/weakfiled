using DMS.DataModel;
using DMS.EntityClass;
using DMS.Utility;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Masters_PropertyMaster : System.Web.UI.Page
{
    #region Private Variable

    CommanFunction Obj_Comm = new CommanFunction();
    Property Entity_Property = new Property();
    DataSet Ds = new DataSet();
    private string StrCondition = string.Empty;
    private string StrError = string.Empty;
    private bool Flag = true;
    private static bool FlagAdd = false, FlagDel = false, FlagEdit = false;
    DMProperty obj_Property = new DMProperty();

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

                DataRow[] dtRow = dsChkUserRight1.Tables[1].Select("FormName ='PropertyMaster'");
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
        txtProjectname.Focus();
        txtAddress.Text = string.Empty;
        TxtSearch.Text = string.Empty;
        txtProjectname.Text = string.Empty;
        txtAddress.Text = string.Empty;
        txtAddress.Text = string.Empty;

        BtnSave.Visible = true;
        BtnUpdate.Visible = false;
        BtnDelete.Visible = false;
        BtnCancel.Visible = true;
        ReportGrid("");
      
        BindCMB();
        //SetInitialRow();
        foreach (System.Web.UI.WebControls.ListItem Chkitem in ddlParty.Items)
        {
            Chkitem.Selected = false;
        }
     
        lblPartyName.Text = string.Empty;
        lblCompanyName.Text = string.Empty;
    }

    public void ReportGrid(string RepCondition)
    {
        Ds = obj_Property.FillReportGrid(RepCondition, out StrError);
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
        // obj_Party = null;
        Ds = null;
    }

    private void BindCMB()
    {
        DataSet DSC = new DataSet();
        DSC = obj_Property.GetPartyType(out StrError);

        if (DSC.Tables.Count > 0)
        {
            if (DSC.Tables[0].Rows.Count > 0)
            {
                ddlCompany.DataSource = DSC.Tables[0];
                ddlCompany.DataTextField = "Company";
                ddlCompany.DataValueField = "CompanyId";
                ddlCompany.DataBind();
            }

            if (DSC.Tables[1].Rows.Count > 0)
            {
                ddlParty.DataSource = DSC.Tables[1];
                ddlParty.DataTextField = "CompanyType";
                ddlParty.DataValueField = "CompanyTypeId";
                ddlParty.DataBind();
            }
        }
    }

    private bool Check()
    {
        Ds = new DataSet();
        Flag = true;
        if (ViewState["EditID"] != null)
            Ds = obj_Property.ChkDuplicate(txtProjectname.Text.Trim(), long.Parse(ViewState["EditID"].ToString()), out StrError);
        else
            Ds = obj_Property.ChkDuplicate(txtProjectname.Text.Trim(), -1, out StrError);

        if (Ds.Tables.Count > 0)
        {
            if (Ds.Tables[0].Rows.Count > 0)
            {
                if (long.Parse(Ds.Tables[0].Rows[0][0].ToString()) > 0)
                {
                    Flag = false;
                    Obj_Comm.ShowPopUpMsg("Project Name is Already Present..!", this.Page);
                    txtProjectname.Text = string.Empty;
                }

            }
        }
        return Flag;
    }

    private void CompanyName()
    {
        try
        {
            string CompanyName = string.Empty;

            foreach (System.Web.UI.WebControls.ListItem Chkitem in ddlCompany.Items)
            {
                if (Chkitem.Selected == true)
                {
                    lblCompanyName.Visible = true;
                    string Company = Chkitem.ToString();

                    if (CompanyName.Length > 0)
                    {
                        CompanyName += " <br/>" + Company;
                    }
                    else
                    {
                        CompanyName += " " + Company;
                    }
                }
            }
            lblCompanyName.Text = CompanyName;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    private void PartyName()
    {
        try
        {
            string Party = string.Empty;

            foreach (System.Web.UI.WebControls.ListItem Chkitem in ddlParty.Items)
            {
                if (Chkitem.Selected == true)
                {
                    lblPartyName.Visible = true;

                    string PartyName = Chkitem.ToString();

                    if (Party.Length > 0)
                    {
                        Party += " <br/>" + PartyName;
                    }
                    else
                    {
                        Party += " " + PartyName;
                    }
                }
            }
            lblPartyName.Text = Party;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
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

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        int Unitcnt = 0;
        string unit;
        string CompanyId = string.Empty;
        int i = Convert.ToInt32(hiddenbox.Value);
        if (i == 0)
        {
            int UpdateRow = 0, InserDetails = 0;
            try
            {
                if (long.Parse(lblPartyName.Text.Length.ToString()) <= 0)
                {
                    Obj_Comm.ShowPopUpMsg("Please select atleast one party...", this.Page);
                    ddlParty.Focus();
                    return;
                }
                if (Check() == true)
                {
                    if (ViewState["EditID"] != null)
                    {
                        Entity_Property.PropertyId = Convert.ToInt32(ViewState["EditID"]);
                    }
                    Entity_Property.PropertyName = txtProjectname.Text.Trim();
                    //   Entity_Property.PartyId = Convert.ToInt32(ddlOwner.SelectedValue);
                    //Entity_Property.PropertyName = txtPropertyName.Text;
                    Entity_Property.PropertyAddress = txtAddress.Text;
                   // Entity_Property.PropertyDesc = txtPropertyDesc.Text;

                    Entity_Property.UserId = Convert.ToInt32(Session["UserId"]);
                    Entity_Property.LoginDate = DateTime.Now;

                    UpdateRow = obj_Property.UpdateProperty(ref Entity_Property, out StrError);
                    if (UpdateRow != 0)
                    {
                        foreach (System.Web.UI.WebControls.ListItem item in ddlCompany.Items)
                        {
                            if (item.Selected)
                            {
                                Entity_Property.PropertyId = Entity_Property.PropertyId;
                                Entity_Property.CompanyId = Convert.ToInt32(item.Value);
                                InserDetails = obj_Property.InsertPartyDtls(ref Entity_Property, out StrError);
                            }
                        }


                        foreach (System.Web.UI.WebControls.ListItem item in ddlParty.Items)
                        {
                            if (item.Selected)
                            {
                                unit = item.ToString();
                                string[] U = item.Value.Split('-');
                                int unitno = Convert.ToInt32(U[0].ToString());
                                Unitcnt++;

                                if (Unitcnt > 0)
                                {
                                    Entity_Property.PropertyId = Entity_Property.PropertyId; ;
                                    Entity_Property.CompanyId = Convert.ToInt32(U[1].ToString());
                                    Entity_Property.CompanyTypeId = Convert.ToInt32(U[0].ToString());

                                    InserDetails = obj_Property.InsertPropertyCompanyPartyDtls(ref Entity_Property, out StrError);

                                }
                            }
                        }

                        Obj_Comm.ShowPopUpMsg("Record Updated Successfully", this.Page);
                        MakeEmptyForm();
                        //  ddlOwner.Focus();
                        Entity_Property = null;
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
            Int32 DeleteId = 0;
            if (ViewState["EditID"] != null)
            {
                if (long.Parse(hdnFldUsedCnt.Value.ToString()) > 0)
                {
                    Obj_Comm.ShowPopUpMsg("Party is in use. Cannot Delete Record...", this.Page);
                    return;
                }
                DeleteId = Convert.ToInt32(ViewState["EditID"]);
            }
            if (DeleteId != 0)
            {
                Entity_Property.PropertyId = DeleteId;
                Entity_Property.UserId = Convert.ToInt32(Session["UserId"]);
                Entity_Property.LoginDate = DateTime.Now;
                int iDelete = obj_Property.DeleteProperty(ref Entity_Property, out StrError);

                if (iDelete != 0)
                {
                    Obj_Comm.ShowPopUpMsg("Record Deleted Successfully..!", this.Page);
                    MakeEmptyForm();
                }
                else
                {
                    Obj_Comm.ShowPopUpMsg("Property is in use. Cannot Delete Record...", this.Page);
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
        int InsertRow = 0, InserDetails = 0;
        int Unitcnt = 0;
        string unit;
        string CompanyId = string.Empty;
     
        try
        {
            if (long.Parse(lblPartyName.Text.Length.ToString()) <= 0)
            {
                Obj_Comm.ShowPopUpMsg("Please select atleast one party...", this.Page);
                lblPartyName.Text = string.Empty;
                ddlParty.Focus();
                return;
            }
            if (Check() == true)
            {
                Entity_Property.PropertyName = txtProjectname.Text.Trim();
                // Entity_Property.PartyId = Convert.ToInt32(ddlOwner.SelectedValue);
                Entity_Property.PropertyAddress = txtAddress.Text;
               // Entity_Property.PropertyDesc = txtPropertyDesc.Text;

                Entity_Property.UserId = Convert.ToInt32(Session["UserId"]);
                Entity_Property.LoginDate = DateTime.Now;

                InsertRow = obj_Property.InsertProperty(ref Entity_Property, out StrError);

                if (InsertRow > 0)
                {
                    foreach (System.Web.UI.WebControls.ListItem item in ddlCompany.Items)
                    {
                        if (item.Selected)
                        {
                            Entity_Property.PropertyId = InsertRow;
                            Entity_Property.CompanyId = Convert.ToInt32(item.Value);
                            InserDetails = obj_Property.InsertPartyDtls(ref Entity_Property, out StrError);
                        }
                    }


                    foreach (System.Web.UI.WebControls.ListItem item in ddlParty.Items)
                    {
                        if (item.Selected)
                        {
                                unit = item.ToString();
                                string[] U = item.Value.Split('-');
                                int unitno = Convert.ToInt32(U[0].ToString());
                                Unitcnt++;
                          
                            if (Unitcnt > 0)
                            {
                                Entity_Property.PropertyId = InsertRow;
                                Entity_Property.CompanyId = Convert.ToInt32(U[1].ToString());
                                Entity_Property.CompanyTypeId = Convert.ToInt32(U[0].ToString());

                                InserDetails = obj_Property.InsertPropertyCompanyPartyDtls(ref Entity_Property, out StrError);
                                
                            }                           
                        }
                    }

                    Obj_Comm.ShowPopUpMsg("Record Saved Successfully", this.Page);
                    MakeEmptyForm();
                    //  ddlOwner.Focus();
                    Entity_Property = null;
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
                        where (r.Field<string>("PropertyName")).Contains(StrCondition)
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

    protected void GrdReport_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            int Unitcnt = 0;
            string unit;
            string CompanyTypeId = string.Empty;
            DataTable dtmerge = new DataTable();
            DataSet DSP = new DataSet();
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
                            Ds = obj_Property.GetPartyForEdit(Convert.ToInt32(e.CommandArgument), out StrError);
                           
                            if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                            {
                                txtProjectname.Text = Ds.Tables[0].Rows[0]["PropertyName"].ToString();
                                txtAddress.Text = Ds.Tables[0].Rows[0]["PropertyAddress"].ToString();
                               // txtPropertyDesc.Text = Ds.Tables[0].Rows[0]["PropertyDesc"].ToString();

                                //if (Convert.ToInt32(Ds.Tables[0].Rows[0]["PartyId"]) > 0)
                                //{
                                //    ddlParty.SelectedValue = Ds.Tables[0].Rows[0]["PartyId"].ToString();
                                //}

                                foreach (System.Web.UI.WebControls.ListItem item in ddlCompany.Items)
                                {
                                    for (int i = 0; i < Ds.Tables[1].Rows.Count; i++)
                                    {
                                        if (item.Value == Ds.Tables[1].Rows[i]["CompanyId"].ToString())
                                        {
                                            item.Selected = true;
                                            break;
                                        }
                                        else
                                        {
                                            item.Selected = false;
                                        }
                                    }
                                }
                               CompanyName();

                                //foreach (System.Web.UI.WebControls.ListItem item in ddlParty.Items)
                                //{
                                //    for (int i = 0; i < Ds.Tables[1].Rows.Count; i++)
                                //    {
                                //        if (item.Value == Ds.Tables[1].Rows[i]["CompanyId"].ToString())
                                //        {
                                //            item.Selected = true;
                                //            break;
                                //        }
                                //        else
                                //        {
                                //            item.Selected = false;
                                //        }
                                //    }
                                //}

                               if (Convert.ToInt32(ddlCompany.SelectedValue) > 0)
                               {
                                   foreach (System.Web.UI.WebControls.ListItem Chkitem2 in ddlCompany.Items)
                                   {
                                       if (Chkitem2.Selected == true)
                                       {
                                           if (CompanyTypeId == string.Empty)
                                           {
                                               CompanyTypeId = Chkitem2.Value.ToString();
                                           }
                                           else
                                           {
                                               CompanyTypeId = CompanyTypeId + "," + Chkitem2.Value.ToString();
                                           }

                                       }
                                   }

                                   DSP = obj_Property.GetPartyTypeOnCompany(CompanyTypeId, out StrError);

                                   if (DSP.Tables.Count > 0)
                                   {
                                       if (DSP.Tables[0].Rows.Count > 0)
                                       {
                                           ddlParty.DataSource = DSP.Tables[0];
                                           ddlParty.DataTextField = "CompanyType";
                                           ddlParty.DataValueField = "CompanyTypeId";
                                           ddlParty.DataBind();
                                       }
                                   }


                               }


                               foreach (System.Web.UI.WebControls.ListItem item in ddlParty.Items)
                               {
                                   for (int i = 0; i < Ds.Tables[2].Rows.Count; i++)
                                   {
                                       string[] U = item.Value.Split('-');
                                       int unitno = Convert.ToInt32(U[0].ToString());

                                       if (unitno == Convert.ToInt32(Ds.Tables[2].Rows[i]["CompanyTypeId"].ToString()))
                                       {
                                           item.Selected = true;
                                           break;
                                       }
                                       else
                                       {
                                           item.Selected = false;
                                       }
                                   }
                               }


                                PartyName();
                            }
                            else
                            {
                                MakeEmptyForm();
                            }
                            Ds = null;
                            obj_Property = null;
                            BtnSave.Visible = false;
                            if (!FlagEdit)
                                BtnUpdate.Visible = true;
                            if (!FlagDel)
                                BtnDelete.Visible = true;
                            //txtPropertyName.Focus();
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
            DMProperty obj_St = new DMProperty();
            DataTable DtNew = (DataTable)HttpContext.Current.Cache["Dir"];
            var query = from r in DtNew.AsEnumerable()
                        where (r.Field<string>("PropertyName").ToLower()).Contains(prefixText.ToLower())
                        select (r.Field<string>("PropertyName"));
            string[] SearchList = query.ToArray();
            return SearchList;
        }
    }

    protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int Unitcnt = 0;
            string unit;
            string CompanyTypeId = string.Empty;
            DataTable dtmerge = new DataTable();
            DataSet DSP = new DataSet();

            foreach (System.Web.UI.WebControls.ListItem Chkitem in ddlCompany.Items)
            {
                if (Chkitem.Selected == true)
                {
                    unit = Chkitem.ToString();
                    int unitno = Convert.ToInt32(Chkitem.Value.ToString());

                  //  DSP = obj_Property.GetPartyOnCompany(unitno, out StrError);
                    Unitcnt++;
                }
            }

            if (Unitcnt > 0)
            {
                CompanyName();
            }
            else
            {
                Obj_Comm.ShowPopUpMsg("Please Select Company", this.Page);
                ddlCompany.Focus();
                return;
            }


            if (Convert.ToInt32(ddlCompany.SelectedValue) > 0)
            {
                foreach (System.Web.UI.WebControls.ListItem Chkitem2 in ddlCompany.Items)
                {
                    if (Chkitem2.Selected == true)
                    {
                        if (CompanyTypeId == string.Empty)
                        {
                            CompanyTypeId = Chkitem2.Value.ToString();
                        }
                        else
                        {
                            CompanyTypeId = CompanyTypeId + "," + Chkitem2.Value.ToString();
                        }

                    }
                }

                DSP = obj_Property.GetPartyTypeOnCompany(CompanyTypeId, out StrError);

                if (DSP.Tables.Count > 0)
                {
                    if (DSP.Tables[0].Rows.Count > 0)
                    {
                        ddlParty.DataSource = DSP.Tables[0];
                        ddlParty.DataTextField = "CompanyType";
                        ddlParty.DataValueField = "CompanyTypeId";
                        ddlParty.DataBind();
                    }
                }

               

            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void ddlParty_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int Unitcnt = 0;
            string unit;
            string CompanyId = string.Empty;
            DataTable dtmerge = new DataTable();

            foreach (System.Web.UI.WebControls.ListItem Chkitem in ddlParty.Items)
            {
                if (Chkitem.Selected == true)
                {
                    unit = Chkitem.ToString();
                    string[] U = Chkitem.Value.Split('-');
                    int unitno = Convert.ToInt32(U[0].ToString());
                    Unitcnt++;
                }
            }

            if (Unitcnt > 0)
            {
                PartyName();
            }
            else
            {
                Obj_Comm.ShowPopUpMsg("Please Select Company", this.Page);
                ddlParty.Focus();
                return;
            }

            //if (Convert.ToInt32(ddlParty.SelectedValue) > 0)
            //{
            //    foreach (System.Web.UI.WebControls.ListItem Chkitem1 in ddlParty.Items)
            //    {
            //        if (Chkitem1.Selected == true)
            //        {
            //            if (CompanyId == string.Empty)
            //            {
            //                CompanyId = Chkitem1.Value.ToString();
            //            }
            //            else
            //            {
            //                CompanyId = CompanyId + "," + Chkitem1.Value.ToString();
            //            }

            //        }
            //    }

            //    Ds = obj_Property.GetPartyOnCompany(CompanyId, out StrError);

            //    ddlCompany.DataSource = Ds.Tables[0];
            //    ddlCompany.DataTextField = "Company";
            //    ddlCompany.DataValueField = "CompanyId";
            //    ddlCompany.DataBind();

            //}

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}