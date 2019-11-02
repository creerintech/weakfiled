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

    public class DMFileDocument:Utility.Setting
    {
        public int InsertFileDocument(ref FileDocument Entity_File, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(FileDocument._Action, SqlDbType.BigInt);
                SqlParameter pFileNo = new SqlParameter(FileDocument._FileNo, SqlDbType.NVarChar);
                SqlParameter pBarcode = new SqlParameter(FileDocument._Barcode, SqlDbType.NVarChar);
                SqlParameter pPropertyId = new SqlParameter(FileDocument._PropertyId, SqlDbType.BigInt);
                SqlParameter pDocumentTitleId = new SqlParameter(FileDocument._DocumentTitleId, SqlDbType.BigInt);
                SqlParameter pId = new SqlParameter(FileDocument._Id, SqlDbType.BigInt);
                SqlParameter pDocDate = new SqlParameter(FileDocument._DocDate, SqlDbType.DateTime);
                SqlParameter pDocExpiryDate = new SqlParameter(FileDocument._DocExpiryDate, SqlDbType.DateTime);
                SqlParameter pRenewAfterDate = new SqlParameter(FileDocument._RenewAfterDate, SqlDbType.DateTime);
                SqlParameter pRoomId = new SqlParameter(FileDocument._RoomId, SqlDbType.BigInt);
                SqlParameter pAisleId = new SqlParameter(FileDocument._AisleId, SqlDbType.BigInt);
                //SqlParameter pRowId = new SqlParameter(FileDocument._RowId, SqlDbType.BigInt);
              //  SqlParameter pCabinetId = new SqlParameter(FileDocument._CabinetId, SqlDbType.BigInt);
                SqlParameter pShelfId = new SqlParameter(FileDocument._ShelfId, SqlDbType.BigInt);
                SqlParameter pDocRefNo = new SqlParameter(FileDocument._DocRefNo, SqlDbType.NVarChar);
                SqlParameter pNarration = new SqlParameter(FileDocument._Narration, SqlDbType.NVarChar);
                SqlParameter pFileName = new SqlParameter(FileDocument._FileName, SqlDbType.NVarChar);
                SqlParameter pDayId = new SqlParameter(FileDocument._DayId, SqlDbType.BigInt);
                SqlParameter pMonthId = new SqlParameter(FileDocument._MonthId, SqlDbType.BigInt);
                SqlParameter pYearId = new SqlParameter(FileDocument._YearId, SqlDbType.BigInt);
                SqlParameter pCreatedBy = new SqlParameter(FileDocument._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(FileDocument._LoginDate, SqlDbType.DateTime);

                pAction.Value = 1;
                pFileNo.Value = Entity_File.FileNo;
                pBarcode.Value = Entity_File.Barcode;
                pPropertyId.Value = Entity_File.PropertyId;
                pDocumentTitleId.Value = Entity_File.DocumentTitleId;
                pId.Value = Entity_File.Id;
                pDocDate.Value=Entity_File.DocDate;
                pDocExpiryDate.Value=Entity_File.DocExpiryDate;
                pRenewAfterDate.Value = Entity_File.RenewAfterDate;              
                pRoomId.Value = Entity_File.RoomId;
                pAisleId.Value = Entity_File.AisleId;
                pDocRefNo.Value = Entity_File.DocRefNo;
                //pCabinetId.Value = Entity_File.CabinetId;
                pShelfId.Value = Entity_File.ShelfId;
                pNarration.Value = Entity_File.Narration;
                pFileName.Value = Entity_File.FileName;
                pDayId.Value = Entity_File.DayId;
                pMonthId.Value = Entity_File.MonthId;
                pYearId.Value = Entity_File.YearId;
                pCreatedBy.Value = Entity_File.UserId;
                pCreatedDate.Value = Entity_File.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pFileNo, pBarcode,pPropertyId,pDocumentTitleId, pId,pDocDate,pDocExpiryDate,pRenewAfterDate,
                    pRoomId,pAisleId,pDocRefNo,pShelfId, pNarration,pFileName,pDayId,pMonthId,pYearId,pCreatedBy,pCreatedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteScalar(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileEditDelete", param);

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

        public int InsertFileDoctPartyDtls(ref  FileDocument Entity_FileDocument, out string strError)
        {
            int InsertRow = 0;
            strError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(FileDocument._Action, SqlDbType.BigInt);
                SqlParameter pDocumentId = new SqlParameter(FileDocument._DocumentId, SqlDbType.BigInt);
                SqlParameter pPartyId = new SqlParameter(FileDocument._PartyId, SqlDbType.BigInt);

                pAction.Value = 11;
                pDocumentId.Value = Entity_FileDocument.DocumentId;
                pPartyId.Value = Entity_FileDocument.PartyId;

                SqlParameter[] ParamArray = new SqlParameter[] { pAction, pDocumentId, pPartyId };
                Open(CONNECTION_STRING);
                BeginTransaction();
                InsertRow = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, FileDocument.SP_FileDocuments, ParamArray);

                if (InsertRow != 0)
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
                strError = ex.Message;
                RollBackTransaction();
            }
            finally
            {
                Close();
            }
            return InsertRow;

        }

        public int InsertFileCompanyPropertyDtls(ref  FileDocument Entity_FileDocument, out string strError)
        {
            int InsertRow = 0;
            strError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(FileDocument._Action, SqlDbType.BigInt);
                SqlParameter pFileCEDId = new SqlParameter(FileDocument._FileCEDId, SqlDbType.BigInt);
                SqlParameter pPropertyId = new SqlParameter(FileDocument._PropertyId, SqlDbType.BigInt);
                SqlParameter pCompanyId = new SqlParameter(FileDocument._CompanyId, SqlDbType.BigInt);
               
                pAction.Value = 8;
                pFileCEDId.Value = Entity_FileDocument.FileCEDId;
                pPropertyId.Value = Entity_FileDocument.PropertyId;
                pCompanyId.Value = Entity_FileDocument.CompanyId;

                SqlParameter[] ParamArray = new SqlParameter[] { pAction, pFileCEDId, pPropertyId, pCompanyId };
                
                Open(CONNECTION_STRING);
                BeginTransaction();

                InsertRow = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileEditDelete", ParamArray);

                if (InsertRow != 0)
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
                strError = ex.Message;
                RollBackTransaction();
            }
            finally
            {
                Close();
            }
            return InsertRow;

        }

        public int UpdateFileDocument(ref FileDocument Entity_File, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(FileDocument._Action, SqlDbType.BigInt);
                SqlParameter pFileCEDId = new SqlParameter(FileDocument._FileCEDId, SqlDbType.BigInt);
                SqlParameter pFileNo = new SqlParameter(FileDocument._FileNo, SqlDbType.NVarChar);
                SqlParameter pBarcode = new SqlParameter(FileDocument._Barcode, SqlDbType.NVarChar);
                SqlParameter pPropertyId = new SqlParameter(FileDocument._PropertyId, SqlDbType.NVarChar);
                SqlParameter pDocumentTitleId = new SqlParameter(FileDocument._DocumentTitleId, SqlDbType.BigInt);
                SqlParameter pId = new SqlParameter(FileDocument._Id, SqlDbType.BigInt);
                SqlParameter pDocDate = new SqlParameter(FileDocument._DocDate, SqlDbType.DateTime);
                SqlParameter pDocExpiryDate = new SqlParameter(FileDocument._DocExpiryDate, SqlDbType.DateTime);
                SqlParameter pRenewAfterDate = new SqlParameter(FileDocument._RenewAfterDate, SqlDbType.DateTime);
                SqlParameter pRoomId = new SqlParameter(FileDocument._RoomId, SqlDbType.BigInt);
                SqlParameter pAisleId = new SqlParameter(FileDocument._AisleId, SqlDbType.BigInt);               
                SqlParameter pShelfId = new SqlParameter(FileDocument._ShelfId, SqlDbType.BigInt);
                SqlParameter pDocRefNo = new SqlParameter(FileDocument._DocRefNo, SqlDbType.NVarChar);
                SqlParameter pNarration = new SqlParameter(FileDocument._Narration, SqlDbType.NVarChar);
                SqlParameter pFileName = new SqlParameter(FileDocument._FileName, SqlDbType.NVarChar);
                SqlParameter pDayId = new SqlParameter(FileDocument._DayId, SqlDbType.BigInt);
                SqlParameter pMonthId = new SqlParameter(FileDocument._MonthId, SqlDbType.BigInt);
                SqlParameter pYearId = new SqlParameter(FileDocument._YearId, SqlDbType.BigInt);
                SqlParameter pUpdatedBy = new SqlParameter(FileDocument._UserId, SqlDbType.BigInt);
                SqlParameter pUpdatedDate = new SqlParameter(FileDocument._LoginDate, SqlDbType.DateTime);

                pAction.Value = 2;
                pFileCEDId.Value = Entity_File.FileCEDId;
                pFileNo.Value = Entity_File.FileNo;
                pBarcode.Value = Entity_File.Barcode;
                pPropertyId.Value = Entity_File.PropertyId;
                pDocumentTitleId.Value = Entity_File.DocumentTitleId;
                pId.Value = Entity_File.Id;
                pDocDate.Value = Entity_File.DocDate;
                pDocExpiryDate.Value = Entity_File.DocExpiryDate;
                pRenewAfterDate.Value = Entity_File.RenewAfterDate;
                pDocRefNo.Value = Entity_File.DocRefNo;
                pRoomId.Value = Entity_File.RoomId;
                pAisleId.Value = Entity_File.AisleId;                
                pShelfId.Value = Entity_File.ShelfId;
                pNarration.Value = Entity_File.Narration;
                pFileName.Value = Entity_File.FileName;
                pDayId.Value = Entity_File.DayId;
                pMonthId.Value = Entity_File.MonthId;
                pYearId.Value = Entity_File.YearId;
                pUpdatedBy.Value = Entity_File.UserId;
                pUpdatedDate.Value = Entity_File.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction,pFileCEDId, pFileNo, pBarcode,pPropertyId, pDocumentTitleId, pDocRefNo,
                    pId, pDocDate, pDocExpiryDate, pRenewAfterDate,pRoomId,pAisleId,pShelfId,pNarration, pFileName,pDayId,pMonthId,pYearId,pUpdatedBy,pUpdatedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileEditDelete", param);

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

        public int DeleteFileDocument(ref FileDocument Entity_FileDocument, out string StrError)
        {
            int iDelete = 0;
            StrError = string.Empty;

            try
            {
                SqlParameter pAction = new SqlParameter(FileDocument._Action, SqlDbType.BigInt);
                SqlParameter pFileCEDId = new SqlParameter(FileDocument._FileCEDId, SqlDbType.BigInt);
                SqlParameter pDeletedBy = new SqlParameter(FileDocument._UserId, SqlDbType.BigInt);

                pAction.Value = 11;
                pFileCEDId.Value = Entity_FileDocument.FileCEDId;
                pDeletedBy.Value = Entity_FileDocument.UserId;

                SqlParameter[] param = new SqlParameter[] { pAction, pFileCEDId, pDeletedBy };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iDelete = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure,"SP_FileEditDelete", param);

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

        public DataSet GetFileDocumentForEdit(int ID, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(FileDocument._Action, SqlDbType.BigInt);
                SqlParameter pFileCEDId = new SqlParameter(FileDocument._FileCEDId, SqlDbType.BigInt);

                pAction.Value = 10;
                pFileCEDId.Value = ID;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileEditDelete", pAction, pFileCEDId);
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

        public DataSet GetFileDocumentDetailsForEdit(int DtlsID, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(FileDocument._Action, SqlDbType.BigInt);
                SqlParameter pFileUploadDocId = new SqlParameter(FileDocument._FileUploadDocId, SqlDbType.BigInt);

                pAction.Value = 18;
                pFileUploadDocId.Value = DtlsID;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileEditDelete", pAction, pFileUploadDocId);
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

        public DataSet ChkDuplicate(string DocumentNo, long DocumentId, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pDocumentId = new SqlParameter("@DocumentId", SqlDbType.BigInt);
                SqlParameter pDocumentNo = new SqlParameter("@DocumentNo", SqlDbType.NVarChar);

                pAction.Value = 6;
                pDocumentId.Value = DocumentId;
                pDocumentNo.Value = DocumentNo;

                SqlParameter[] param = new SqlParameter[] { pAction, pDocumentId, pDocumentNo };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, FileDocument.SP_FileDocuments, param);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet FillReportGrid(string condition, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                pAction.Value = 9;
                PrepCondition.Value = condition;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileEditDelete", pAction, PrepCondition);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public DataSet FillReportGrid_PopUp(string condition, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                pAction.Value = 556;
                PrepCondition.Value = condition;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, FileDocument.SP_FileDocuments, pAction, PrepCondition);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public DataSet FillReportGrid_PopUpDocNo(string condition, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                pAction.Value = 557;
                PrepCondition.Value = condition;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, FileDocument.SP_FileDocuments, pAction, PrepCondition);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public DataTable FillSalutation_Active()
        {
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                pAction.Value = 6;
                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, FileDocument.SP_FileDocuments, pAction);
                if (Ds.Tables.Count > 0)
                    return Ds.Tables[0];
                else
                    return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { Close(); }

        }

        public string[] GetSuggestRecord(string preFixText)
        {
            List<string> SearchList = new List<string>();
            string ListItem = string.Empty;

            try
            {
                SqlParameter pAction = new SqlParameter(FileDocument._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter(FileDocument._StrCondition, SqlDbType.NVarChar);

                pAction.Value = 9;
                PrepCondition.Value = preFixText;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

                Open(CONNECTION_STRING);
                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileEditDelete", oparamcol);

                if (dr != null && dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        ListItem = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(dr[0].ToString(),
                            dr[1].ToString());

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
      
        public DataSet FillDepartmentSubCategory(long deptCatId,out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pCatId = new SqlParameter("@DepartmentCategoryId", SqlDbType.BigInt);

                pAction.Value = 12;
                pCatId.Value = deptCatId;
                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileDocuments", pAction, pCatId);
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

        public DataSet FillDepartmentSubSubCategory(long deptCatId, long deptSubCatId, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pCatId = new SqlParameter("@DepartmentCategoryId", SqlDbType.BigInt);
                SqlParameter pSubCatId = new SqlParameter("@DepartmentSubCategoryId", SqlDbType.BigInt);

                pAction.Value = 13;
                pCatId.Value = deptCatId;
                pSubCatId.Value = deptSubCatId;

                SqlParameter[] param = new SqlParameter[] { pAction, pCatId, pSubCatId };

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileDocuments", param);
                
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

        public DataSet FillParty(out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                
                pAction.Value = 14;
                
                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileDocuments", pAction);

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

        public DataSet FillProperty(long PartyId, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pPartyId = new SqlParameter("@PartyId", SqlDbType.BigInt);

                pAction.Value = 15;
                pPartyId.Value = PartyId;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileDocuments", pAction, pPartyId);
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

        public DataSet FillCombo(out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(Cabinet._Action, SqlDbType.BigInt);

                pAction.Value = 4;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileEditDelete", pAction);

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

        public DataSet FillFiles(out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);

                pAction.Value = 9;

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileDocuments", pAction);

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

        public DataSet GetDocumentTitle(out string strError)
        {
            DataSet ds = new DataSet();
            strError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                pAction.Value = 70;
                Open(CONNECTION_STRING);
                ds = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileDocuments", pAction);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally
            {
                Close();
            }
            return ds;
        }

        public DataSet GetDocumentSubject(out string strError)
        {
            DataSet ds = new DataSet();
            strError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                pAction.Value = 76;
                Open(CONNECTION_STRING);
                ds = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileDocuments", pAction);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally
            {
                Close();
            }
            return ds;
        }

        public DataSet GetCategory(out string strError)
        {
            DataSet ds = new DataSet();
            strError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                pAction.Value = 71;
                Open(CONNECTION_STRING);
                ds = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileDocuments", pAction);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally
            {
                Close();
            }
            return ds;
        }

        public DataSet GetSubCategory(long deptCatId, out string strError)
        {
            DataSet ds = new DataSet();
            strError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pCatId = new SqlParameter("@DepartmentCategoryId", SqlDbType.BigInt);

                pAction.Value = 72;
                pCatId.Value = deptCatId;

                Open(CONNECTION_STRING);
                ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileDocuments", pAction, pCatId);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally
            {
                Close();
            }
            return ds;
        }

        public DataSet GetSubSubCategory(long deptCatId, long deptSubCatId, out string strError)
        {
            DataSet ds = new DataSet();
            strError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pCatId = new SqlParameter("@DepartmentCategoryId", SqlDbType.BigInt);
                SqlParameter pSubCatId = new SqlParameter("@DepartmentSubCategoryId", SqlDbType.BigInt);

                pAction.Value = 73;
                pCatId.Value = deptCatId;
                pSubCatId.Value = deptSubCatId;

                SqlParameter[] param = new SqlParameter[] { pAction, pCatId, pSubCatId };

                Open(CONNECTION_STRING);
                ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileDocuments", param);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally
            {
                Close();
            }
            return ds;
        }

        public DataSet GetParty(out string strError)
        {
            DataSet ds = new DataSet();
            strError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                pAction.Value = 74;
                Open(CONNECTION_STRING);
                ds = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileDocuments", pAction);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally
            {
                Close();
            }
            return ds;
        }

        public DataSet GetProperty(out string strError)
        {
            DataSet ds = new DataSet();
            strError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                pAction.Value = 75;
                Open(CONNECTION_STRING);
                ds = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileDocuments", pAction);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally
            {
                Close();
            }
            return ds;
        }

        public DataSet GetCode(out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter PAction = new SqlParameter("@Action", SqlDbType.BigInt);

                PAction.Value = 3;

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure,"SP_FileEditDelete", PAction);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public DataSet FillCompanyOnProject(int ProjectId, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(FileDocument._Action, SqlDbType.BigInt);
                SqlParameter pPropertyId = new SqlParameter(FileDocument._PropertyId, SqlDbType.BigInt);

                pAction.Value = 5;
                pPropertyId.Value = ProjectId;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileEditDelete", pAction, pPropertyId);
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

        public DataSet FillSubTypeOnDocument(int DocId, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(FileDocument._Action, SqlDbType.BigInt);
                SqlParameter pDocId = new SqlParameter(FileDocument._DocumentTitleId, SqlDbType.BigInt);

                pAction.Value = 6;
                pDocId.Value = DocId;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileEditDelete", pAction, pDocId);
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

        public int InsertDocumentDtls(ref FileDocument Entity_Call, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(FileDocument._Action, SqlDbType.BigInt);
                SqlParameter pFileCEDId = new SqlParameter(FileDocument._FileCEDId, SqlDbType.BigInt);
                SqlParameter pDocImagePath = new SqlParameter(FileDocument._DocImagePath, SqlDbType.NVarChar);
                SqlParameter pDocDate = new SqlParameter(FileDocument._DocDate, SqlDbType.DateTime);
                SqlParameter pDocumentTitleId = new SqlParameter(FileDocument._DocumentTitleId, SqlDbType.BigInt);
                SqlParameter pId = new SqlParameter(FileDocument._Id, SqlDbType.BigInt);
                SqlParameter pDocRefNo = new SqlParameter(FileDocument._DocRefNo, SqlDbType.NVarChar);
                SqlParameter pStatus = new SqlParameter(FileDocument._Status, SqlDbType.NVarChar);
                pAction.Value = 7;
                pFileCEDId.Value = Entity_Call.FileCEDId;
                pDocImagePath.Value = Entity_Call.DocImagePath;
                pDocDate.Value = Entity_Call.DocDate;
                pDocumentTitleId.Value = Entity_Call.DocumentTitleId;
                pId.Value = Entity_Call.Id;
                pDocRefNo.Value = Entity_Call.DocRefNo;
                pStatus.Value = Entity_Call.Status;
                SqlParameter[] param = new SqlParameter[] { pAction, pFileCEDId, pDocImagePath, pDocDate, pDocumentTitleId, pId, pDocRefNo, pStatus };
              
                Open(CONNECTION_STRING);
                
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileEditDelete", param);

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

        public DataSet FillAisleOnRoom(int RoomId, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(FileDocument._Action, SqlDbType.BigInt);
                SqlParameter pRoomId = new SqlParameter(FileDocument._RoomId, SqlDbType.BigInt);

                pAction.Value = 12;
                pRoomId.Value = RoomId;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileEditDelete", pAction, pRoomId);
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

        public DataSet FillShelfOnAisleRoom(int RoomId, int AisleId, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(FileDocument._Action, SqlDbType.BigInt);
                SqlParameter pRoomId = new SqlParameter(FileDocument._RoomId, SqlDbType.BigInt);
                SqlParameter pAisleId = new SqlParameter(FileDocument._AisleId, SqlDbType.BigInt);

                pAction.Value = 13;
                pRoomId.Value = RoomId;
                pAisleId.Value = AisleId;

                SqlParameter[] param = new SqlParameter[] { pAction, pRoomId, pAisleId };

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileEditDelete", param);
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

        public DMFileDocument()
        {

        }

        public DataSet ChkDuplicateFile(string FileName, Int32 ProjectID,Int32 FileId, out string StrError)
        {
            StrError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pFId = new SqlParameter("@FileCEDId", SqlDbType.BigInt);
                SqlParameter pName = new SqlParameter("@FileName", SqlDbType.NVarChar);
                SqlParameter pPId = new SqlParameter("@PropertyId", SqlDbType.BigInt);

                pAction.Value = 14;
                pName.Value = FileName;
                pFId.Value = FileId;
                pPId.Value = ProjectID;

                SqlParameter[] param = new SqlParameter[] { pAction, pName, pFId, pPId };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileEditDelete", param);

            }
            catch (Exception ex)
            {
                StrError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public string[] GetSuggestedRecordForSubDocuments(string prefixText)
        {
            List<string> SearchList = new List<string>();
            string ListItem = string.Empty;

            try
            {
                SqlParameter pAction = new SqlParameter(FileDocument._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                pAction.Value = 15;
                PrepCondition.Value = prefixText;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

                Open(CONNECTION_STRING);
                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileEditDelete", oparamcol);

                if (dr != null && dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        ListItem = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(dr[0].ToString(),
                            dr[1].ToString());

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

        public DataSet FillDocumentOnSubType(int DocId, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(FileDocument._Action, SqlDbType.BigInt);
                SqlParameter pDocSubId = new SqlParameter(FileDocument._Id, SqlDbType.BigInt);

                pAction.Value = 16;
                pDocSubId.Value = DocId;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileEditDelete", pAction, pDocSubId);
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

        public string[] GetSuggestedRecordFile(string prefixText)
        {
            List<string> SearchList = new List<string>();
            string ListItem = string.Empty;

            try
            {
                SqlParameter pAction = new SqlParameter(FileDocument._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                pAction.Value = 2;
                PrepCondition.Value = prefixText;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

                Open(CONNECTION_STRING);
                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ReportFileList", oparamcol);

                if (dr != null && dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        ListItem = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(dr[0].ToString(),
                            dr[1].ToString());

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

        public int UpdateDocumentDtls(ref FileDocument Entity_File, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                
                SqlParameter pAction = new SqlParameter(FileDocument._Action, SqlDbType.BigInt);
                SqlParameter pFileCEDId = new SqlParameter(FileDocument._FileCEDId, SqlDbType.BigInt);
                SqlParameter pFileUploadDocId = new SqlParameter(FileDocument._FileUploadDocId, SqlDbType.BigInt);
                SqlParameter pDocImagePath = new SqlParameter(FileDocument._DocImagePath, SqlDbType.NVarChar);
                SqlParameter pDocDate = new SqlParameter(FileDocument._DocDate, SqlDbType.DateTime);
                SqlParameter pDocumentTitleId = new SqlParameter(FileDocument._DocumentTitleId, SqlDbType.BigInt);
                SqlParameter pId = new SqlParameter(FileDocument._Id, SqlDbType.BigInt);
                SqlParameter pDocRefNo = new SqlParameter(FileDocument._DocRefNo, SqlDbType.NVarChar);
                SqlParameter pStatus = new SqlParameter(FileDocument._Status, SqlDbType.NVarChar);

                pAction.Value = 17;
                pFileCEDId.Value = Entity_File.FileCEDId;
                pFileUploadDocId.Value = Entity_File.FileUploadDocId;
                pDocImagePath.Value = Entity_File.DocImagePath;
                pDocDate.Value = Entity_File.DocDate;
                pDocumentTitleId.Value = Entity_File.DocumentTitleId;
                pId.Value = Entity_File.Id;
                pDocRefNo.Value = Entity_File.DocRefNo;
                pStatus.Value = Entity_File.Status;

                SqlParameter[] Param = new SqlParameter[] { pAction, pFileCEDId, pFileUploadDocId, pDocImagePath, pDocDate, pDocumentTitleId, pId, pDocRefNo, pStatus };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, "SP_FileEditDelete", Param);

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