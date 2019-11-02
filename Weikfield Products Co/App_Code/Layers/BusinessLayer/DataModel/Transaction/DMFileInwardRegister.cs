using DMS.DALSQLHelper;
using DMS.EntityClass;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
namespace DMS.DataModel
{
    public class DMFileInwardRegister:Utility.Setting
    {        
        public string[] GetSuggestedRecordForEmployee(string prefixText)
        {
            List<string> SearchList = new List<string>();
            string ListItem = string.Empty;
            try
            {

                // -- For Checking OF Execution of Procedure=========
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter MRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                MAction.Value = 1;
                MRepCondition.Value = prefixText;

                SqlParameter[] oParmCol = new SqlParameter[] { MAction, MRepCondition };
                Open(CONNECTION_STRING);

                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInWard", oParmCol);

                if (dr != null && dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        ListItem = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(dr[1].ToString(), dr[0].ToString());
                        SearchList.Add(ListItem);
                    }
                }
                dr.Close();
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }
            return SearchList.ToArray();
        }
        
        public DataSet FillReportInGrid(string Status, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                //SqlParameter pFileId = new SqlParameter("@fileId", SqlDbType.BigInt);
                SqlParameter pstatus = new SqlParameter("@status", SqlDbType.NVarChar);

                pAction.Value = 3;
                //pFileId.Value = FileCEDId;
                pstatus.Value = Status;
                SqlParameter[] oparamcol = new SqlParameter[] { pAction, pstatus };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInWard", pAction, pstatus);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        
        public int InsertUpdateFileInOutREcords(ref FileInWard Entity_FileInWard, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(FileInWard._Action, SqlDbType.BigInt);
                SqlParameter pFileCEDId = new SqlParameter(FileInWard._FileCEDId, SqlDbType.BigInt);
                SqlParameter pFileUploadDocId = new SqlParameter(FileInWard._FileUploadDocId, SqlDbType.BigInt);
                SqlParameter pDocumentTitleId = new SqlParameter(FileInWard._DocumentTitleId, SqlDbType.BigInt);
                SqlParameter pUserGivenToId = new SqlParameter(FileInWard._UserGivenToId, SqlDbType.BigInt);
                SqlParameter pUserGivenById = new SqlParameter(FileInWard._UserGivenById, SqlDbType.BigInt);
                SqlParameter pInwardTime = new SqlParameter(FileInWard._InwardTime, SqlDbType.VarChar);
                SqlParameter pOutWardTime = new SqlParameter(FileInWard._OutWardTime, SqlDbType.VarChar);
                SqlParameter pStatus = new SqlParameter(FileInWard._Status, SqlDbType.NVarChar);
                SqlParameter pInwardStaus= new SqlParameter(FileInWard._InwardStatus, SqlDbType.VarChar);

                pAction.Value = 20;
                // pInID.Value = Entity_FileInOut.InID;
                pFileCEDId.Value = Entity_FileInWard.FileCEDId;
                pFileUploadDocId.Value = Entity_FileInWard.FileUploadDocId;
                pDocumentTitleId.Value = Entity_FileInWard.DocumentTitleId;
                pUserGivenToId.Value = Entity_FileInWard.UserGivenToId;
                pUserGivenById.Value = Entity_FileInWard.UserGivenById;
                pInwardTime.Value = Entity_FileInWard.InwardTime;
                pOutWardTime.Value = Entity_FileInWard.OutWardTime;
                pStatus.Value = "OUT";
                pInwardStaus.Value = "IN";
                SqlParameter[] param = new SqlParameter[] { pAction, pFileCEDId, pFileUploadDocId, pDocumentTitleId, pUserGivenToId, pUserGivenById, pInwardTime, pOutWardTime, pStatus,pInwardStaus };
                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInOutOpration", param);

                if (iInsert > 0)
                {
                    CommitTransaction();
                }
                else
                {
                    RollBackTransaction();
                }

            }
            catch (Exception ex)
            {
                RollBackTransaction();
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return iInsert;
        }
        public int UpdateFileUploadDtable(ref FileInWard Entity_FileInWard, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(FileInWard._Action, SqlDbType.BigInt);
                SqlParameter pDocumentTitleId = new SqlParameter(FileInWard._DocumentTitleId, SqlDbType.BigInt);
                SqlParameter pStatus = new SqlParameter(FileInWard._Status, SqlDbType.NVarChar);
                SqlParameter pFileCEDId = new SqlParameter(FileInWard._FileCEDId, SqlDbType.BigInt);
                SqlParameter pFileUploadDocId = new SqlParameter(FileInWard._FileUploadDocId, SqlDbType.BigInt);

                pAction.Value = 4;
                pDocumentTitleId.Value = Entity_FileInWard.DocumentTitleId;
                pStatus.Value = Entity_FileInWard.Status;
                pFileCEDId.Value = Entity_FileInWard.FileCEDId;
                pFileUploadDocId.Value = Entity_FileInWard.FileUploadDocId;

                SqlParameter[] param = new SqlParameter[] { pAction, pDocumentTitleId, pStatus, pFileCEDId, pFileUploadDocId };

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInWard", param);

                if (iInsert > 0)
                {
                    CommitTransaction();
                }
                else
                {
                    RollBackTransaction();
                }
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return iInsert;
        }

        public DataSet FillCheckReportInGrid1(out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                //SqlParameter pFromDate = new SqlParameter("@FromDate", SqlDbType.DateTime);
                //SqlParameter pToDate = new SqlParameter("@ToDate", SqlDbType.DateTime);
                //SqlParameter pToDate = new SqlParameter("@OutwardDate", SqlDbType.NVarChar);

                pAction.Value = 6;
                //pFromDate.Value = FromDate;
                //pToDate.Value = ToDate;
                //pToDate.Value = ToDate;
                //pStatus.Value = "OUT";
                SqlParameter[] oparamcol = new SqlParameter[] { pAction};

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInWard", oparamcol);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet FillCheckReportOnlyOutward(DateTime FromDate, DateTime ToDate, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pFromDate = new SqlParameter("@FromDate", SqlDbType.DateTime);
                SqlParameter pToDate = new SqlParameter("@ToDate", SqlDbType.DateTime);
                //SqlParameter pToDate = new SqlParameter("@OutwardDate", SqlDbType.NVarChar);

                pAction.Value =17;
                pFromDate.Value = FromDate;
                pToDate.Value = ToDate;
                //pToDate.Value = ToDate;
                //pStatus.Value = "OUT";
                SqlParameter[] oparamcol = new SqlParameter[] { pAction, pFromDate, pToDate };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInWard", oparamcol);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet CheckReportOnlyOutwardDocument(DateTime FromDate, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pFromDate = new SqlParameter("@FromDate", SqlDbType.DateTime);              

                pAction.Value = 19;
                pFromDate.Value = FromDate;
               
                SqlParameter[] oparamcol = new SqlParameter[] { pAction, pFromDate };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInWard", oparamcol);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet FillCheckReportOnlyOutwardWithoutDate( out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
               
                pAction.Value = 20;
               
                SqlParameter[] oparamcol = new SqlParameter[] { pAction };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInWard", oparamcol);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet FillCheckReportInGrid(DateTime FromDate, DateTime ToDate, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pFromDate = new SqlParameter("@FromDate", SqlDbType.DateTime);
                SqlParameter pToDate = new SqlParameter("@ToDate", SqlDbType.DateTime);
                //SqlParameter pToDate = new SqlParameter("@OutwardDate", SqlDbType.NVarChar);

                pAction.Value = 5;
                pFromDate.Value =FromDate;
                pToDate.Value = ToDate;
                //pToDate.Value = ToDate;
                //pStatus.Value = "OUT";
                SqlParameter[] oparamcol = new SqlParameter[] { pAction,pFromDate,pToDate};

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInWard", oparamcol);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet FillReportInGridByProp(int PropertyId, string strCond, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pPropID = new SqlParameter("@PropertyId", SqlDbType.BigInt);
                SqlParameter pStrcon = new SqlParameter("@strCond", SqlDbType.NVarChar);
               
                pAction.Value = 7;
                pPropID.Value = PropertyId;
                pStrcon.Value = strCond;
                //pToDate.Value = ToDate;
                //pStatus.Value = "OUT";
                SqlParameter[] oparamcol = new SqlParameter[] { pAction, pPropID, pStrcon };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInWard", oparamcol);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet FillReportInGridByCompany(int CompanyId, string strCond, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pCompID = new SqlParameter("@CompanyId", SqlDbType.BigInt);
                SqlParameter pStrcon = new SqlParameter("@strCond", SqlDbType.NVarChar);

                pAction.Value = 8;
                pCompID.Value = CompanyId;
                pStrcon.Value = strCond;
                //pToDate.Value = ToDate;
                //pStatus.Value = "OUT";
                SqlParameter[] oparamcol = new SqlParameter[] { pAction, pCompID, pStrcon };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInWard", oparamcol);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }
        public DataSet FillReportInGridByFileNo(string FileNo, string strCond, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pFileNo = new SqlParameter("@FileNo", SqlDbType.NVarChar);
                SqlParameter pStrcon = new SqlParameter("@strCond", SqlDbType.NVarChar);

                pAction.Value = 9;
                pFileNo.Value = FileNo;
                pStrcon.Value = strCond;
                //pToDate.Value = ToDate;
                //pStatus.Value = "OUT";
                SqlParameter[] oparamcol = new SqlParameter[] { pAction, pFileNo, pStrcon };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInWard", oparamcol);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }
        public DataSet FillReportInGridByFileName(int FileCEDId, string strCond, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pFileID = new SqlParameter("@FileCEDId", SqlDbType.BigInt);
                SqlParameter pStrcon = new SqlParameter("@strCond", SqlDbType.NVarChar);

                pAction.Value = 10;
                pFileID.Value = FileCEDId;
                pStrcon.Value = strCond;
                //pToDate.Value = ToDate;
                //pStatus.Value = "OUT";
                SqlParameter[] oparamcol = new SqlParameter[] { pAction, pFileID, pStrcon };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInWard", oparamcol);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet FillCheckReportGridForProperty(DateTime FromDate, DateTime ToDate, int PropertyId, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pFromDate = new SqlParameter("@FromDate", SqlDbType.DateTime);
                SqlParameter pToDate = new SqlParameter("@ToDate", SqlDbType.DateTime);
                SqlParameter PPropId = new SqlParameter("@PropertyId",SqlDbType.Int);
                //SqlParameter pToDate = new SqlParameter("@OutwardDate", SqlDbType.NVarChar);

                pAction.Value = 11;
                pFromDate.Value = FromDate;
                pToDate.Value = ToDate;
                PPropId.Value = PropertyId;
                //pToDate.Value = ToDate;
                //pStatus.Value = "OUT";
                SqlParameter[] oparamcol = new SqlParameter[] { pAction, pFromDate, pToDate,PPropId };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInWard", oparamcol);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }
        public DataSet FillCheckReportGridForFileName(DateTime FromDate, DateTime ToDate, int FileCEDId, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pFromDate = new SqlParameter("@FromDate", SqlDbType.DateTime);
                SqlParameter pToDate = new SqlParameter("@ToDate", SqlDbType.DateTime);
                SqlParameter PFileCEDId = new SqlParameter("@FileCEDId", SqlDbType.Int);
                //SqlParameter pToDate = new SqlParameter("@OutwardDate", SqlDbType.NVarChar);

                pAction.Value = 12;
                pFromDate.Value = FromDate;
                pToDate.Value = ToDate;
                PFileCEDId.Value = FileCEDId;
                //pToDate.Value = ToDate;
                //pStatus.Value = "OUT";
                SqlParameter[] oparamcol = new SqlParameter[] { pAction, pFromDate, pToDate, PFileCEDId };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInWard", oparamcol);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }
        public DataSet FillCheckReportGridForPropertyFileName(DateTime FromDate, DateTime ToDate, int PropertyId, int FileCEDId, out string strError)
        { 
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pFromDate = new SqlParameter("@FromDate", SqlDbType.DateTime);
                SqlParameter pToDate = new SqlParameter("@ToDate", SqlDbType.DateTime);
                SqlParameter pPropID = new SqlParameter("@PropertyId", SqlDbType.Int);
                SqlParameter PFileCEDId = new SqlParameter("@FileCEDId", SqlDbType.Int);
                //SqlParameter pToDate = new SqlParameter("@OutwardDate", SqlDbType.NVarChar);

                pAction.Value = 13;
                pFromDate.Value = FromDate;
                pToDate.Value = ToDate;
                pPropID.Value = PropertyId;
                PFileCEDId.Value = FileCEDId;
                //pToDate.Value = ToDate;
                //pStatus.Value = "OUT";
                SqlParameter[] oparamcol = new SqlParameter[] { pAction, pFromDate, pToDate,pPropID, PFileCEDId };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInWard", oparamcol);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }
        public DataSet FillCheckReportGridForPropertyFileNameWithoutDate(int PropertyId, int FileCEDId, out string strError)
        { 
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                //SqlParameter pFromDate = new SqlParameter("@FromDate", SqlDbType.DateTime);
                //SqlParameter pToDate = new SqlParameter("@ToDate", SqlDbType.DateTime);
                SqlParameter pPropID = new SqlParameter("@PropertyId", SqlDbType.Int);
                SqlParameter PFileCEDId = new SqlParameter("@FileCEDId", SqlDbType.Int);
                //SqlParameter pToDate = new SqlParameter("@OutwardDate", SqlDbType.NVarChar);

                pAction.Value = 14;
                //pFromDate.Value = FromDate;
                //pToDate.Value = ToDate;
                pPropID.Value = PropertyId;
                PFileCEDId.Value = FileCEDId;
                //pToDate.Value = ToDate;
                //pStatus.Value = "OUT";
                SqlParameter[] oparamcol = new SqlParameter[] { pAction,pPropID, PFileCEDId };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInWard", oparamcol);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }
        public DataSet FillCheckReportGridForFileNameWithoutDate(int FileCEDId, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                //SqlParameter pFromDate = new SqlParameter("@FromDate", SqlDbType.DateTime);
                //SqlParameter pToDate = new SqlParameter("@ToDate", SqlDbType.DateTime);
                //SqlParameter pPropID = new SqlParameter("@PropertyId", SqlDbType.Int);
                SqlParameter PFileCEDId = new SqlParameter("@FileCEDId", SqlDbType.Int);
                //SqlParameter pToDate = new SqlParameter("@OutwardDate", SqlDbType.NVarChar);

                pAction.Value = 15;
                //pFromDate.Value = FromDate;
                //pToDate.Value = ToDate;
               // pPropID.Value = PropertyId;
                PFileCEDId.Value = FileCEDId;
                //pToDate.Value = ToDate;
                //pStatus.Value = "OUT";
                SqlParameter[] oparamcol = new SqlParameter[] { pAction,PFileCEDId };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInWard", oparamcol);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet FillCheckReportGridForPropertyWithoutDate(int PropertyId, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                //SqlParameter pFromDate = new SqlParameter("@FromDate", SqlDbType.DateTime);
                //SqlParameter pToDate = new SqlParameter("@ToDate", SqlDbType.DateTime);
                SqlParameter pPropID = new SqlParameter("@PropertyId", SqlDbType.Int);
               // SqlParameter PFileCEDId = new SqlParameter("@FileCEDId", SqlDbType.Int);
                //SqlParameter pToDate = new SqlParameter("@OutwardDate", SqlDbType.NVarChar);

                pAction.Value = 16;
                //pFromDate.Value = FromDate;
                //pToDate.Value = ToDate;
                pPropID.Value = PropertyId;
               // PFileCEDId.Value = FileCEDId;
                //pToDate.Value = ToDate;
                //pStatus.Value = "OUT";
                SqlParameter[] oparamcol = new SqlParameter[] { pAction,pPropID };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInWard", oparamcol);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }
        public DMFileInwardRegister()
        {
            
        }
    }
}
