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


public partial class Transactions_PrintIndex : System.Web.UI.Page
{

    #region [Private Variables]

    DMSearchDocument obj_File = new DMSearchDocument();
   
    CommanFunction obj_Comman = new CommanFunction();
    DataSet Ds = new DataSet();
    DataSet DSA = new DataSet();
    private string StrCondition = string.Empty;
    private string StrError = string.Empty;
    private bool Flag = false;
    int str = 0;
    public static int countPage = 0;
    private static bool FlagAdd = false, FlagDel = false, FlagEdit =false, FlagPrint = false;

    #endregion

    //User Right Function===========
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

                DataRow[] dtRow = dsChkUserRight1.Tables[1].Select("FormName ='PrintIndex'");
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
                ////Checking Add Right ========                    
                //if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["AddAuth"].ToString()) == false)
                //{
                //    BtnSave.Visible = false;
                //    FlagAdd = true;

                //}
                //Checking Print Right ========                    
                if (Convert.ToBoolean(dsChkUserRight.Tables[0].Rows[0]["PrintAuth"].ToString()) == false)
                {
                    {
                        foreach (GridViewRow GRow in GrdReport.Rows)
                        {
                            GRow.FindControl("Image1").Visible = false;
                            FlagPrint = true;
                        }
                            }

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

    public void SetInitialRow()
    {
        try
        {
            DataTable dtTable = new DataTable();
            DataRow dr;

            dtTable.Columns.Add("#", typeof(int));           
            dtTable.Columns.Add("FileNo", typeof(string));
            dtTable.Columns.Add("FileName", typeof(string));
            dtTable.Columns.Add("PropertyName", typeof(string));
            dtTable.Columns.Add("Barcode", typeof(string));
            dtTable.Columns.Add("Room", typeof(string));
            dtTable.Columns.Add("Aisle", typeof(string));
            dtTable.Columns.Add("ShelfNo", typeof(string));

            dr = dtTable.NewRow();
            dr["#"] = 0;            
            dr["FileNo"] = string.Empty;
            dr["FileName"] = string.Empty;
            dr["Barcode"] = string.Empty;
            dr["Room"] = string.Empty;
            dr["PropertyName"] = string.Empty;
            dr["Aisle"] = string.Empty;
            dr["ShelfNo"] = string.Empty;
            
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

    public void ReportGrid()
    {
        try
        {
            Ds = obj_File.FillReportGrid(out StrError);
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
            SetInitialRow();           
            ReportGrid();
            CheckUserRight();
        }
    }
}
