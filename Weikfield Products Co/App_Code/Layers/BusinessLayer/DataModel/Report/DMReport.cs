using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using DMS.DALSQLHelper;
using System.Data.SqlClient;

namespace DMS.DataModel
{
    public class DMReport : Utility.Setting
    {

        public DataSet GetFileoutwordDetaiRpt(int ID, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pID = new SqlParameter("@InID", SqlDbType.BigInt);

                pAction.Value = 5;
                pID.Value = ID;

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInOutWordOperation", pAction, pID);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }


        public DMReport()
        {
            //
            // TODO: Add constructor logic here
            //
        }

    }
}
