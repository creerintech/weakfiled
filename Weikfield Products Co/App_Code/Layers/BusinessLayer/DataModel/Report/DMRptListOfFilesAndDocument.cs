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
    public class DMRptListOfFilesAndDocument : Utility.Setting
    {
        public DataSet GetListOfFilesAndDocument(string RepCondition, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter MAction = new SqlParameter("Action", SqlDbType.BigInt);
                SqlParameter MRepCondition = new SqlParameter("RepCondition", SqlDbType.NVarChar);

                MAction.Value = 1;
                MRepCondition.Value = RepCondition;

                Open(CONNECTION_STRING);

                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ReportFileList", MAction, MRepCondition);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public DMRptListOfFilesAndDocument()
        {

        }
    }
}
