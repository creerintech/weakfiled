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
    public class DMFileInOutWord : Utility.Setting
    {

        public DataSet FillCombo(out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(Cabinet._Action, SqlDbType.BigInt);

                pAction.Value = 2;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInOutOpration", pAction);

            }

            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return DS;
        }

        public DataSet FillComboForProject(int PropertyId, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(Cabinet._Action, SqlDbType.BigInt);
                SqlParameter pPropId = new SqlParameter("@PropertyId",SqlDbType.BigInt);
                
                pAction.Value = 16;
                pPropId.Value = PropertyId;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInOutOpration", pAction, pPropId);

            }

            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return DS;
        }

        public DataSet FillComboForCompany(int CompanyId, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(Cabinet._Action, SqlDbType.BigInt);
                SqlParameter pCompId = new SqlParameter("@CompanyId", SqlDbType.BigInt);

                pAction.Value = 17;
                pCompId.Value = CompanyId;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInOutOpration", pAction,pCompId);

            }

            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return DS;
        }

        public string[] GetSuggestedRecordForFileNo(string prefixText)
        {
            List<string> SearchList = new List<string>();
            string ListItem = string.Empty;
            try
            {

                // -- For Checking OF Execution of Procedure=========
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter MRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                MAction.Value = 3;
                MRepCondition.Value = prefixText;

                SqlParameter[] oParmCol = new SqlParameter[] { MAction, MRepCondition };
                Open(CONNECTION_STRING);

                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInOutOpration", oParmCol);

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

        public string[] GetSuggestedRecordForFileName(string prefixText)
        {
            List<string> SearchList = new List<string>();
            string ListItem = string.Empty;
            try
            {

                // -- For Checking OF Execution of Procedure=========
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter MRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                MAction.Value = 18;
                MRepCondition.Value = prefixText;

                SqlParameter[] oParmCol = new SqlParameter[] { MAction, MRepCondition };
                Open(CONNECTION_STRING);

                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInOutOpration", oParmCol);

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

        public string[] GetSuggestedAllProjectName(string prefixText)
        {
            List<string> SearchList = new List<string>();
            string ListItem = string.Empty;
            try
            {

                // -- For Checking OF Execution of Procedure=========
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter MRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                MAction.Value =11;
                MRepCondition.Value = prefixText;

                SqlParameter[] oParmCol = new SqlParameter[] { MAction, MRepCondition };
                Open(CONNECTION_STRING);

                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInOutOpration", oParmCol);

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

        public string[] GetSuggestedAllCompanyName(string prefixText)
        {
            List<string> SearchList = new List<string>();
            string ListItem = string.Empty;
            try
            {

                // -- For Checking OF Execution of Procedure=========
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter MRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                MAction.Value = 14;
                MRepCondition.Value = prefixText;

                SqlParameter[] oParmCol = new SqlParameter[] { MAction, MRepCondition };
                Open(CONNECTION_STRING);

                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInOutOpration", oParmCol);

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
        
        public int InsertFileInWordRecords(ref FileInOutReCords Entity_FileInOut, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(FileInOutReCords._Action, SqlDbType.BigInt);
                SqlParameter pFileCEDId = new SqlParameter(FileInOutReCords._FileCEDId, SqlDbType.BigInt);
                SqlParameter pFileNo = new SqlParameter(FileInOutReCords._FileNo, SqlDbType.NVarChar);
                SqlParameter pFileName= new SqlParameter(FileInOutReCords._FileName, SqlDbType.NVarChar);
                SqlParameter pBarcode = new SqlParameter(FileInOutReCords._Barcode, SqlDbType.NVarChar);
                SqlParameter PEmpID = new SqlParameter(FileInOutReCords._EmpID, SqlDbType.BigInt);
                SqlParameter pFileInDate = new SqlParameter(FileInOutReCords._FileInDate, SqlDbType.DateTime);

                pAction.Value = 9;
                pFileCEDId.Value = Entity_FileInOut.FileCEDId;
                pFileNo.Value = Entity_FileInOut.FileNo;
                pFileName.Value = Entity_FileInOut.FileName;
                PEmpID.Value = Entity_FileInOut.EmpID;
                pFileInDate.Value = Entity_FileInOut.FileInDate;
                pBarcode.Value = Entity_FileInOut.Barcode;

                SqlParameter[] param = new SqlParameter[] { pAction,pFileCEDId,pFileNo, pFileName, PEmpID, pFileInDate, pBarcode };
                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteScalar(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInOutOpration", param);

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
       
        public int InsertUpdateFileInOutREcords(ref FileInOutReCords Entity_FileInOut, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(FileInOutReCords._Action, SqlDbType.BigInt);
                SqlParameter pFileCEDId = new SqlParameter(FileInOutReCords._FileCEDId, SqlDbType.BigInt);
                SqlParameter pFileUploadDocId = new SqlParameter(FileInOutReCords._FileUploadDocId, SqlDbType.BigInt);
                SqlParameter pDocumentTitleId = new SqlParameter(FileInOutReCords._DocumentTitleId, SqlDbType.BigInt);
                SqlParameter pUserGivenToId = new SqlParameter(FileInOutReCords._UserGivenToId, SqlDbType.BigInt);
                SqlParameter pUserGivenById = new SqlParameter(FileInOutReCords._UserGivenById, SqlDbType.BigInt);
                SqlParameter pInwardTime = new SqlParameter(FileInOutReCords._InwardTime, SqlDbType.VarChar);
                SqlParameter pOutWardTime = new SqlParameter(FileInOutReCords._OutWardTime, SqlDbType.VarChar);
                SqlParameter pStatus = new SqlParameter(FileInOutReCords._Status, SqlDbType.NVarChar);
                SqlParameter pPropertyId = new SqlParameter(FileDocument._PropertyId, SqlDbType.BigInt);
                SqlParameter pOutWardStatus= new SqlParameter(FileInOutReCords._OutWardStatus, SqlDbType.NVarChar);
                SqlParameter pCreatedBy = new SqlParameter(FileDocument._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(FileDocument._LoginDate, SqlDbType.DateTime);

                pAction.Value = 20;
               // pInID.Value = Entity_FileInOut.InID;
                pFileCEDId.Value = Entity_FileInOut.FileCEDId;
                pFileUploadDocId.Value = Entity_FileInOut.FileUploadDocId;
                pDocumentTitleId.Value = Entity_FileInOut.DocumentTitleId;
                pUserGivenToId.Value = Entity_FileInOut.UserGivenToId;
                pUserGivenById.Value = Entity_FileInOut.UserGivenById;
                pInwardTime.Value = Entity_FileInOut.InwardTime;
                pOutWardTime.Value = Entity_FileInOut.OutWardTime;
                pStatus.Value = "OUT";
                pOutWardStatus.Value = "OUT";
                pPropertyId.Value = Entity_FileInOut.PropertyId;
                pCreatedBy.Value = Entity_FileInOut.UserId;
                pCreatedDate.Value = Entity_FileInOut.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pFileCEDId, pFileUploadDocId, pDocumentTitleId, pUserGivenToId, pUserGivenById, pInwardTime, pOutWardTime, pStatus, pOutWardStatus, pPropertyId ,pCreatedBy, pCreatedDate  };
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

        public int UpdateFileUploadDtable(ref FileInOutReCords Entity_FileInOut, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(FileInOutReCords._Action, SqlDbType.BigInt);
                SqlParameter pDocumentTitleId = new SqlParameter(FileInOutReCords._DocumentTitleId, SqlDbType.BigInt);
                SqlParameter pStatus = new SqlParameter("@Status", SqlDbType.NVarChar);
                SqlParameter pFileCEDId = new SqlParameter(FileInOutReCords._FileCEDId,SqlDbType.BigInt);
                SqlParameter pFileUploadDocId = new SqlParameter(FileInOutReCords._FileUploadDocId, SqlDbType.BigInt);

                pAction.Value = 8;
                pDocumentTitleId.Value = Entity_FileInOut.DocumentTitleId;
                pStatus.Value = Entity_FileInOut.Status;
                pFileCEDId.Value = Entity_FileInOut.FileCEDId;
                pFileUploadDocId.Value = Entity_FileInOut.FileUploadDocId;

                SqlParameter[] param = new SqlParameter[] { pAction, pDocumentTitleId, pStatus,pFileCEDId,pFileUploadDocId};

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

        public DataSet FillOtherFeilds(string FileNo, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(FileInOutReCords._Action, SqlDbType.BigInt);
                SqlParameter pFileNo = new SqlParameter("@strCond", SqlDbType.NVarChar);

                pAction.Value = 5;
                pFileNo.Value = FileNo;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInOutOpration", pAction, pFileNo);
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return DS;
        }

        public DataSet FillOtherFeildsForFilename(int FileId, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(FileInOutReCords._Action, SqlDbType.BigInt);
                SqlParameter pFileID = new SqlParameter("@strCond", SqlDbType.NVarChar);

                pAction.Value = 19;
                pFileID.Value = FileId;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInOutOpration", pAction, pFileID);
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return DS;
        }

        public DataSet FillOtherFeildsProj(string PropertyId, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(FileDocument._Action, SqlDbType.BigInt);
                SqlParameter pProjId = new SqlParameter("@strCond", SqlDbType.NVarChar);

                pAction.Value = 12;
                pProjId.Value = PropertyId;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInOutOpration", pAction, pProjId);
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return DS;
        }

        public DataSet FillOtherFeildsCompany(string CompanyId, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(FileDocument._Action, SqlDbType.BigInt);
                SqlParameter pCompId = new SqlParameter("@strCond", SqlDbType.NVarChar);

                pAction.Value = 15;
                pCompId.Value = CompanyId;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInOutOpration", pAction, pCompId);
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return DS;
        }

        public DataSet FillInWordGrid(int FileCEDId, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pFileId = new SqlParameter("@fileId", SqlDbType.BigInt);
                
                pAction.Value = 6;
                pFileId.Value = FileCEDId;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, pFileId};

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInOutOpration", pAction, pFileId);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

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

                pAction.Value = 21;
                //pFileId.Value = FileCEDId;
                pstatus.Value = Status;
                SqlParameter[] oparamcol = new SqlParameter[] { pAction, pstatus };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInOutOpration", pAction, pstatus);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet FillOutWordGrid(int FileCEDId, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pFileId = new SqlParameter("@fileId", SqlDbType.BigInt);

                pAction.Value = 7;
                pFileId.Value = FileCEDId;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, pFileId };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInOutOpration", pAction, pFileId);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public DMFileInOutWord()
        {
        }

        public int DeleteOutWardFileDocument(ref FileInOutReCords Entity_FileInOut, out string StrError)
        {
            int iDelete = 0;
            StrError = string.Empty;

            try
            {
                SqlParameter pAction = new SqlParameter(FileInOutReCords._Action, SqlDbType.BigInt);
                SqlParameter pInOutId = new SqlParameter(FileInOutReCords._InOutId, SqlDbType.BigInt);
                SqlParameter pDeletedBy = new SqlParameter(FileInOutReCords._UserId, SqlDbType.BigInt);
                SqlParameter pDeletedDate = new SqlParameter(FileInOutReCords._LoginDate, SqlDbType.DateTime);

                pAction.Value = 22;
                pInOutId.Value = Entity_FileInOut.InOutId;
                pDeletedBy.Value = Entity_FileInOut.UserId;
                pDeletedDate.Value = Entity_FileInOut.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pInOutId, pDeletedBy, pDeletedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iDelete = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInOutOpration", param);

                if (iDelete > 0)
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
            return iDelete;
        }

        public string[] GetSuggestedRecordForParty(string prefixText)
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

                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInOutWordOperation", oParmCol);

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

        public DataSet GetDocumentDetails(string SearchT, out string StrError)
        {
            StrError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {

                // -- For Checking OF Execution of Procedure=========
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter MRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                MAction.Value = 3;
                MRepCondition.Value = SearchT;

                SqlParameter[] oParmCol = new SqlParameter[] { MAction, MRepCondition };
                Open(CONNECTION_STRING);

                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInOutWordOperation", oParmCol);
            }

            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet FillDocumentDetails(int DocTitleId, int SubTitleId, int FileCEDId, int CompanyId, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pDocTitleId = new SqlParameter("@DocumentTitleId", SqlDbType.BigInt);
                SqlParameter pFileCEDId = new SqlParameter("@FileCEDId", SqlDbType.BigInt);
                SqlParameter pCompanyId = new SqlParameter("@CompanyId", SqlDbType.BigInt);
                SqlParameter pDocSubId = new SqlParameter("@Id", SqlDbType.BigInt);

                pAction.Value = 2;
                pFileCEDId.Value = FileCEDId;
                pDocTitleId.Value = DocTitleId;
                pCompanyId.Value = CompanyId;
                pDocSubId.Value = SubTitleId;

                SqlParameter[] oParmCol = new SqlParameter[] { pAction, pFileCEDId, pDocTitleId, pCompanyId, pDocSubId };

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileInOutWordOperation", oParmCol);
            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally
            {
                Close();
            }
            return DS;
        }


        public int InsertFileInRecordsDetails(ref FileInOutReCords Entity_FileInOut, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(FileInOutReCords._Action, SqlDbType.BigInt);
                SqlParameter pInID = new SqlParameter(FileInOutReCords._InID, SqlDbType.BigInt);
                SqlParameter pFileUploadDocId = new SqlParameter(FileInOutReCords._FileUploadDocId, SqlDbType.BigInt);
                SqlParameter pStatus = new SqlParameter(FileInOutReCords._Status, SqlDbType.NVarChar);

                pAction.Value = 10;
                pInID.Value = Entity_FileInOut.InID;
                pFileUploadDocId.Value = Entity_FileInOut.FileUploadDocId;
                pStatus.Value = "OUT";

                SqlParameter[] param = new SqlParameter[] { pAction, pInID, pFileUploadDocId, pStatus };
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
    }
}