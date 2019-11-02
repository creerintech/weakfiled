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

    public class DMFileRegister : Utility.Setting
    {
        public DataSet FillCombo(out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(FileRegister._Action, SqlDbType.BigInt);

                pAction.Value = 7;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, FileRegister.SP_FileRegister, pAction);
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

        public DataSet FillDepartmentSubCategory(long deptCatId, out string StrError)
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

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, FileRegister.SP_FileRegister, pAction, pCatId);
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
                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, FileRegister.SP_FileRegister, param);

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

        public DataSet GetAisle(int ID, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pId = new SqlParameter("@RoomId", SqlDbType.BigInt);

                pAction.Value = 8;
                pId.Value = ID;

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, FileRegister.SP_FileRegister, pAction, pId);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public DataSet GetRowNo(int RoomId, int AisleId, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pRoomId = new SqlParameter("@RoomId", SqlDbType.BigInt);
                SqlParameter pAisleId = new SqlParameter("@AisleId", SqlDbType.BigInt);

                pAction.Value = 9;
                pRoomId.Value = RoomId;
                pAisleId.Value = AisleId;

                Open(CONNECTION_STRING);
                SqlParameter[] param = { pAction, pRoomId, pAisleId };

                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, FileRegister.SP_FileRegister, param);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet GetCabinetNo(int RoomId, int AisleId, int RowId, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pRoomId = new SqlParameter("@RoomId", SqlDbType.BigInt);
                SqlParameter pAisleId = new SqlParameter("@AisleId", SqlDbType.BigInt);
                SqlParameter pRowId = new SqlParameter("@RowId", SqlDbType.BigInt);

                pAction.Value = 10;
                pRoomId.Value = RoomId;
                pAisleId.Value = AisleId;
                pRowId.Value = RowId;

                Open(CONNECTION_STRING);
                SqlParameter[] param = { pAction, pRoomId, pAisleId, pRowId };

                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, FileRegister.SP_FileRegister, param);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet GetShelfNo(int RoomId, int AisleId, int RowId, int CabinetId, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pRoomId = new SqlParameter("@RoomId", SqlDbType.BigInt);
                SqlParameter pAisleId = new SqlParameter("@AisleId", SqlDbType.BigInt);
                SqlParameter pRowId = new SqlParameter("@RowId", SqlDbType.BigInt);
                SqlParameter pCabinetId = new SqlParameter("@CabinetId", SqlDbType.BigInt);

                pAction.Value = 1111;
                pRoomId.Value = RoomId;
                pAisleId.Value = AisleId;
                pRowId.Value = RowId;
                pCabinetId.Value = CabinetId;

                Open(CONNECTION_STRING);
                SqlParameter[] param = { pAction, pRoomId, pAisleId, pRowId, pCabinetId };

                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, FileRegister.SP_FileRegister, param);
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

                pAction.Value = 555;
                PrepCondition.Value = condition;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, FileRegister.SP_FileRegister, pAction, PrepCondition);
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
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, FileRegister.SP_FileRegister, pAction, PrepCondition);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

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
                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, FileRegister.SP_FileRegister, pAction);

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


        public int InsertFileDetails(ref FileRegister Entity_FileRegister, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(FileRegister._Action, SqlDbType.BigInt);

                SqlParameter pDateDetails = new SqlParameter(FileRegister._DateDetails, SqlDbType.NVarChar);
                SqlParameter pDocumentNo = new SqlParameter(FileRegister._DocumentNo, SqlDbType.NVarChar);
                SqlParameter pFileName = new SqlParameter(FileRegister._FileName, SqlDbType.NVarChar);
                SqlParameter pFileSubject = new SqlParameter(FileRegister._FileSubject, SqlDbType.NVarChar);
                SqlParameter pDepartmentCategoryId = new SqlParameter(FileRegister._DepartmentCategoryId, SqlDbType.BigInt);
                SqlParameter pDepartmentSubCategoryId = new SqlParameter(FileRegister._DepartmentSubCategoryId, SqlDbType.BigInt);
                SqlParameter pDepartmentSubSubCategoryId = new SqlParameter(FileRegister._DepartmentSubSubCategoryId, SqlDbType.BigInt);

                SqlParameter pFileNo = new SqlParameter(FileRegister._FileNo, SqlDbType.NVarChar);
                SqlParameter pRoomId = new SqlParameter(FileRegister._RoomId, SqlDbType.BigInt);
                SqlParameter pAisleId = new SqlParameter(FileRegister._AisleId, SqlDbType.BigInt);
                SqlParameter pRowId = new SqlParameter(FileRegister._RowId, SqlDbType.BigInt);
                SqlParameter pCabinetId = new SqlParameter(FileRegister._CabinetId, SqlDbType.BigInt);
                SqlParameter pShelfId = new SqlParameter(FileRegister._ShelfId, SqlDbType.BigInt);

                SqlParameter pAdditionalNotes = new SqlParameter(FileRegister._AdditionalNotes, SqlDbType.NVarChar);                
                SqlParameter pCreatedBy = new SqlParameter(FileRegister._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(FileRegister._CreatedDate, SqlDbType.SmallDateTime);

                pAction.Value = 1;

                pDateDetails.Value = Entity_FileRegister.DateDetails;
                pDocumentNo.Value = Entity_FileRegister.DocumentNo;
                pFileName.Value = Entity_FileRegister.FileName;
                pFileSubject.Value = Entity_FileRegister.FileSubject;
                pDepartmentCategoryId.Value = Entity_FileRegister.DepartmentCategoryId;
                pDepartmentSubCategoryId.Value = Entity_FileRegister.DepartmentSubCategoryId;
                pDepartmentSubSubCategoryId.Value = Entity_FileRegister.DepartmentSubSubCategoryId;
                pFileNo.Value = Entity_FileRegister.FileNo;
                pRoomId.Value = Entity_FileRegister.RoomId;
                pAisleId.Value = Entity_FileRegister.AisleId;
                pRowId.Value = Entity_FileRegister.RowId;
                pCabinetId.Value = Entity_FileRegister.CabinetId;
                pShelfId.Value = Entity_FileRegister.ShelfId;
                pAdditionalNotes.Value = Entity_FileRegister.AdditionalNotes;
               
                pCreatedBy.Value = Entity_FileRegister.UserId;
                pCreatedDate.Value = Entity_FileRegister.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pDateDetails, pDocumentNo,  pFileName, pFileSubject,
                        pDepartmentCategoryId, pDepartmentSubCategoryId, pDepartmentSubSubCategoryId, pFileNo,
                        pRoomId,pAisleId,pRowId,pCabinetId,pShelfId,pAdditionalNotes, pCreatedBy,pCreatedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteScalar(_Connection, _Transaction, CommandType.StoredProcedure, FileRegister.SP_FileRegister, param);

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

        public int InsertFileRegPartyDtls(ref  FileRegister Entity_FileDocument, out string strError)
        {
            int InsertRow = 0;
            strError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(FileRegister._Action, SqlDbType.BigInt);
                SqlParameter pFileRegisterId = new SqlParameter(FileRegister._FileRegisterId, SqlDbType.BigInt);
                SqlParameter pPartyId = new SqlParameter(FileRegister._PartyId, SqlDbType.BigInt);

                pAction.Value = 11;
                pFileRegisterId.Value = Entity_FileDocument.FileRegisterId;
                pPartyId.Value = Entity_FileDocument.PartyId;

                SqlParameter[] ParamArray = new SqlParameter[] { pAction, pFileRegisterId, pPartyId };
                Open(CONNECTION_STRING);
                BeginTransaction();
                InsertRow = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, FileRegister.SP_FileRegister, ParamArray);

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

        public int InsertFileRegPropertyDtls(ref  FileRegister Entity_FileDocument, out string strError)
        {
            int InsertRow = 0;
            strError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(FileRegister._Action, SqlDbType.BigInt);
                SqlParameter pFileRegisterId = new SqlParameter(FileRegister._FileRegisterId, SqlDbType.BigInt);
                SqlParameter pPropertyId = new SqlParameter(FileRegister._PropertyId, SqlDbType.BigInt);

                pAction.Value = 111;
                pFileRegisterId.Value = Entity_FileDocument.FileRegisterId;
                pPropertyId.Value = Entity_FileDocument.PropertyId;

                SqlParameter[] ParamArray = new SqlParameter[] { pAction, pFileRegisterId, pPropertyId };
                Open(CONNECTION_STRING);
                BeginTransaction();
                InsertRow = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, FileRegister.SP_FileRegister, ParamArray);

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

        public int UpdateFileRegister(ref FileRegister Entity_FileRegister, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(FileRegister._Action, SqlDbType.BigInt);

                SqlParameter pFileRegisterId = new SqlParameter(FileRegister._FileRegisterId, SqlDbType.BigInt);
                SqlParameter pDateDetails = new SqlParameter(FileRegister._DateDetails, SqlDbType.NVarChar);
                SqlParameter pDocumentNo = new SqlParameter(FileRegister._DocumentNo, SqlDbType.NVarChar);
                SqlParameter pFileName = new SqlParameter(FileRegister._FileName, SqlDbType.NVarChar);
                SqlParameter pFileSubject = new SqlParameter(FileRegister._FileSubject, SqlDbType.NVarChar);
                SqlParameter pDepartmentCategoryId = new SqlParameter(FileRegister._DepartmentCategoryId, SqlDbType.BigInt);
                SqlParameter pDepartmentSubCategoryId = new SqlParameter(FileRegister._DepartmentSubCategoryId, SqlDbType.BigInt);
                SqlParameter pDepartmentSubSubCategoryId = new SqlParameter(FileRegister._DepartmentSubSubCategoryId, SqlDbType.BigInt);

                SqlParameter pFileNo = new SqlParameter(FileRegister._FileNo, SqlDbType.NVarChar);
                SqlParameter pRoomId = new SqlParameter(FileRegister._RoomId, SqlDbType.BigInt);
                SqlParameter pAisleId = new SqlParameter(FileRegister._AisleId, SqlDbType.BigInt);
                SqlParameter pRowId = new SqlParameter(FileRegister._RowId, SqlDbType.BigInt);
                SqlParameter pCabinetId = new SqlParameter(FileRegister._CabinetId, SqlDbType.BigInt);
                SqlParameter pShelfId = new SqlParameter(FileRegister._ShelfId, SqlDbType.BigInt);

                SqlParameter pAdditionalNotes = new SqlParameter(FileRegister._AdditionalNotes, SqlDbType.NVarChar);
                SqlParameter pCreatedBy = new SqlParameter(FileRegister._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(FileRegister._LoginDate, SqlDbType.SmallDateTime);

           
                pAction.Value = 2;
                pFileRegisterId.Value = Entity_FileRegister.FileRegisterId;
                pDateDetails.Value = Entity_FileRegister.DateDetails;
                pDocumentNo.Value = Entity_FileRegister.DocumentNo;
                pFileName.Value = Entity_FileRegister.FileName;
                pFileSubject.Value = Entity_FileRegister.FileSubject;
                pDepartmentCategoryId.Value = Entity_FileRegister.DepartmentCategoryId;
                pDepartmentSubCategoryId.Value = Entity_FileRegister.DepartmentSubCategoryId;
                pDepartmentSubSubCategoryId.Value = Entity_FileRegister.DepartmentSubSubCategoryId;
                pFileNo.Value = Entity_FileRegister.FileNo;
                pRoomId.Value = Entity_FileRegister.RoomId;
                pAisleId.Value = Entity_FileRegister.AisleId;
                pRowId.Value = Entity_FileRegister.RowId;
                pCabinetId.Value = Entity_FileRegister.CabinetId;
                pShelfId.Value = Entity_FileRegister.ShelfId;
                pAdditionalNotes.Value = Entity_FileRegister.AdditionalNotes;

                pCreatedBy.Value = Entity_FileRegister.UserId;
                pCreatedDate.Value = Entity_FileRegister.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction,pFileRegisterId, pDateDetails, pDocumentNo,  pFileName, pFileSubject,
                        pDepartmentCategoryId, pDepartmentSubCategoryId, pDepartmentSubSubCategoryId, pFileNo,
                        pRoomId,pAisleId,pRowId,pCabinetId,pShelfId,pAdditionalNotes, pCreatedBy,pCreatedDate };
                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, FileRegister.SP_FileRegister, param);

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

        public int DeleteFileRegister(ref FileRegister Entity_FileRegister, out string StrError)
        {
            int iDelete = 0;
            StrError = string.Empty;

            try
            {
                SqlParameter pAction = new SqlParameter(FileRegister._Action, SqlDbType.BigInt);
                SqlParameter pFileRegisterId = new SqlParameter(FileRegister._FileRegisterId, SqlDbType.BigInt);
                SqlParameter pDeletedBy = new SqlParameter(FileRegister._UserId, SqlDbType.BigInt);

                pAction.Value = 3;
                pFileRegisterId.Value = Entity_FileRegister.FileRegisterId;
                pDeletedBy.Value = Entity_FileRegister.UserId;

                SqlParameter[] param = new SqlParameter[] { pAction, pFileRegisterId, pDeletedBy };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iDelete = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, FileRegister.SP_FileRegister, param);

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

        public DataSet GetFileRegisterForEdit(int ID, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(FileRegister._Action, SqlDbType.BigInt);
                SqlParameter pFileRegisterId = new SqlParameter(FileRegister._FileRegisterId, SqlDbType.BigInt);

                pAction.Value = 4;
                pFileRegisterId.Value = ID;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, FileRegister.SP_FileRegister, pAction, pFileRegisterId);
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

        public string[] GetSuggestRecord(string preFixText)
        {
            List<string> SearchList = new List<string>();
            string ListItem = string.Empty;

            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter("@DocumentNo", SqlDbType.NVarChar);

                pAction.Value = 50;
                PrepCondition.Value = preFixText;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

                Open(CONNECTION_STRING);
                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, FileRegister.SP_FileRegister, oparamcol);

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

        public DMFileRegister()
        {

        }
    }
}