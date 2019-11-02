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

using DMS.DataModel;
using DMS.EntityClass;
using DMS.Utility;

public partial class Reports_Check_Outward_Documents : System.Web.UI.Page
{
    #region[Private Variables]

    DMFileInwardRegister Obj_FileInWard = new DMFileInwardRegister();
    FileInWard Entity_FileInWard = new FileInWard();
    CommanFunction Obj_Comm = new CommanFunction();
    DataSet DS = new DataSet();
    DataSet Dsa = new DataSet();
    private bool Flag = true;
    private string StrError = string.Empty;
    private string InwardDate = string.Empty;
    private string OutwardDate = string.Empty;
    private string StrCondition = string.Empty;
    public string StrCondition1 = string.Empty;
    private static bool FlagAdd = false, FlagDel = false, FlagEdit = false;
    private int FileId = 0;
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

                DataRow[] dtRow = dsChkUserRight1.Tables[1].Select("FormName ='Check Outward Documents'");
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
                    GrdInOutReport.Visible = false;
                    btnSearch.Visible = false;
                }
                //Checking Add Right ========                    
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

    private void MakeEmptyForm()
    {
        txtFromDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");

        SetInitialRowInGridIndata();
       
    }

    private void SetInitialRowInGridIndata()
    {
        try
        {
            DataTable dt = new DataTable();

            DataRow dr = null;
            dt.Columns.Add("#", typeof(int));
            dt.Columns.Add("PropertyName", typeof(string));
            dt.Columns.Add("Company", typeof(string));
            dt.Columns.Add(new DataColumn("FileNo", typeof(string)));
            dt.Columns.Add("FileName", typeof(string));
            dt.Columns.Add("DocumentTitle", typeof(string));
            dt.Columns.Add("DocumentSubTitle", typeof(string));  
            dt.Columns.Add("UserGivenToId", typeof(string));
            dt.Columns.Add("UserGivenById", typeof(string));
            dt.Columns.Add("OutWardTime", typeof(string));
            dt.Columns.Add("OutwardDate", typeof(string));
            dt.Columns.Add("OutwardStatus", typeof(string));
            dt.Columns.Add("InwardStatus", typeof(string));
            dt.Columns.Add("Empname", typeof(string)); 
            dr = dt.NewRow();

            dr["#"] = 0;
            dr["PropertyName"] = "";
            dr["Company"] = "";
            dr["FileNo"] = "";
            dr["FileName"] = "";
            dr["DocumentTitle"] = "";
            dr["DocumentSubTitle"] = "";
            dr["Empname"] = ""; 
            dr["UserGivenToId"] = "";
            dr["UserGivenById"] = "";
            dr["OutwardStatus"] = "";
            dr["OutWardTime"] = "";
            dr["OutwardDate"] = "";
            dr["InwardStatus"] = "";
            dt.Rows.Add(dr);
            ViewState["CurrentTableInwordData"] = dt;
            GrdInOutReport.DataSource = dt;
            GrdInOutReport.DataBind();

        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    public void ReportGrid2(DateTime FromDate, DateTime ToDate)
    {
        try
        {
            DS = Obj_FileInWard.FillCheckReportOnlyOutward(FromDate, ToDate, out StrError);

            //--------------------Inword Grid Bind--------------------------------
            if (DS.Tables.Count > 0)
            {
                if (DS.Tables[0].Rows.Count > 0)
                {
                    GrdInOutReport.DataSource = DS.Tables[0];
                    GrdInOutReport.DataBind();
                }
                else
                {
                    SetInitialRowInGridIndata();
                    GrdInOutReport.DataSource = null;
                    GrdInOutReport.DataBind();
                }

            }
            else
            {
                //SetInitialRowInGridIndata();
                GrdInOutReport.DataSource = null;
                GrdInOutReport.DataBind();
            }



        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    public void ReportGrid(DateTime FromDate)
    {
        try
        {
            DS = Obj_FileInWard.CheckReportOnlyOutwardDocument(FromDate, out StrError);

            //--------------------Inword Grid Bind--------------------------------
            if (DS.Tables.Count > 0)
            {
                if (DS.Tables[0].Rows.Count > 0)
                {
                    GrdInOutReport.DataSource = DS.Tables[0];
                    GrdInOutReport.DataBind();
                }
                else
                {
                    SetInitialRowInGridIndata();
                    GrdInOutReport.DataSource = null;
                    GrdInOutReport.DataBind();
                }

            }
            else
            {
                //SetInitialRowInGridIndata();
                GrdInOutReport.DataSource = null;
                GrdInOutReport.DataBind();
            }



        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    public void ReportGrid1()
    {
        try
        {
            DS = Obj_FileInWard.FillCheckReportOnlyOutwardWithoutDate(out StrError);

            //--------------------Inword Grid Bind--------------------------------
            if (DS.Tables.Count > 0)
            {
                if (DS.Tables[0].Rows.Count > 0)
                {
                    GrdInOutReport.DataSource = DS.Tables[0];
                    GrdInOutReport.DataBind();
                }
                else
                {
                    SetInitialRowInGridIndata();
                    GrdInOutReport.DataSource = null;
                    GrdInOutReport.DataBind();
                }

            }
            else
            {
                //SetInitialRowInGridIndata();
                GrdInOutReport.DataSource = null;
                GrdInOutReport.DataBind();
            }



        }
        catch (Exception ex)
        {
            Obj_Comm.ShowPopUpMsg(ex.Message, this.Page);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            CheckUserRight();
            SetInitialRowInGridIndata();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(txtFromDate.Text) != "")
        {
            DateTime FromDate = Convert.ToDateTime(txtFromDate.Text);
           // DateTime ToDate = Convert.ToDateTime(txtTodate.Text);
            ReportGrid(FromDate);
        }
        else
        {
            ReportGrid1();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        MakeEmptyForm();
    }
}
