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
    public class DMFile:Utility.Setting
    {

        public int InsertFile(ref File Entity_File, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(File._Action, SqlDbType.BigInt);
                SqlParameter pAisleId = new SqlParameter(File._AisleId, SqlDbType.BigInt);
                SqlParameter pRoomId = new SqlParameter(File._RoomId, SqlDbType.BigInt);
                SqlParameter pRowId = new SqlParameter(File._RowId, SqlDbType.BigInt);
                SqlParameter pCabinetId = new SqlParameter(File._CabinetId, SqlDbType.BigInt);
                SqlParameter pShelfId = new SqlParameter(File._ShelfId, SqlDbType.BigInt);
                SqlParameter pFileNo = new SqlParameter(File._FileNo, SqlDbType.NVarChar);

                SqlParameter pCreatedBy = new SqlParameter(File._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(File._LoginDate, SqlDbType.DateTime);

                pAction.Value = 1;
                pAisleId.Value = Entity_File.AisleId;
                pRoomId.Value = Entity_File.RoomId;
                pRowId.Value = Entity_File.RowId;
                pCabinetId.Value = Entity_File.CabinetId;
                pShelfId.Value = Entity_File.ShelfId;
                pFileNo.Value = Entity_File.FileNo;
                pCreatedBy.Value = Entity_File.UserId;
                pCreatedDate.Value = Entity_File.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pAisleId, pRoomId, pRowId, pCabinetId, pShelfId, pFileNo, pCreatedBy, pCreatedDate };
                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, File.SP_FileMaster, param);

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

        public int UpdateFile(ref File Entity_File, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(File._Action, SqlDbType.BigInt);
                SqlParameter pFileId = new SqlParameter(File._FileId, SqlDbType.BigInt);
                SqlParameter pRowId = new SqlParameter(File._RowId, SqlDbType.BigInt);
                SqlParameter pAisleId = new SqlParameter(File._AisleId, SqlDbType.BigInt);
                SqlParameter pFileNo = new SqlParameter(File._FileNo, SqlDbType.NVarChar);
                SqlParameter pRoomId = new SqlParameter(File._RoomId, SqlDbType.BigInt);

                SqlParameter pCabinetId = new SqlParameter(File._CabinetId, SqlDbType.BigInt);
                SqlParameter pShelfId = new SqlParameter(File._ShelfId, SqlDbType.BigInt);
                SqlParameter pCreatedBy = new SqlParameter(File._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(File._LoginDate, SqlDbType.DateTime);

                pAction.Value = 2;
                pFileId.Value = Entity_File.FileId;
                pRowId.Value = Entity_File.RowId;
                pAisleId.Value = Entity_File.AisleId;
                pFileNo.Value = Entity_File.FileNo;
                pRoomId.Value = Entity_File.RoomId;
                pCabinetId.Value = Entity_File.CabinetId;
                pShelfId.Value = Entity_File.ShelfId;
                pCreatedBy.Value = Entity_File.UserId;
                pCreatedDate.Value = Entity_File.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pFileId, pRowId, pAisleId, pFileNo, pRoomId, pCabinetId, pShelfId, pCreatedBy, pCreatedDate };
                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, File.SP_FileMaster, param);

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

        public int DeleteFile(ref File Entity_File, out string StrError)
        {
            int iDelete = 0;
            StrError = string.Empty;

            try
            {
                SqlParameter pAction = new SqlParameter(File._Action, SqlDbType.BigInt);
                SqlParameter pFileId = new SqlParameter(File._FileId, SqlDbType.BigInt);
                SqlParameter pDeletedBy = new SqlParameter(File._UserId, SqlDbType.BigInt);
                SqlParameter pDeletedDate = new SqlParameter(File._LoginDate, SqlDbType.DateTime);

                pAction.Value = 3;
                pFileId.Value = Entity_File.FileId;
                pDeletedBy.Value = Entity_File.UserId;
                pDeletedDate.Value = Entity_File.LoginDate;


                SqlParameter[] param = new SqlParameter[] { pAction, pFileId, pDeletedBy, pDeletedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iDelete = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, File.SP_FileMaster, param);

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

        public DataSet GetFileForEdit(int ID, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();

            try
            {
                SqlParameter pAction = new SqlParameter(File._Action, SqlDbType.BigInt);
                SqlParameter pFileId = new SqlParameter(File._FileId, SqlDbType.BigInt);

                pAction.Value = 4;
                pFileId.Value = ID;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, File.SP_FileMaster, pAction, pFileId);
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

        public DataSet GetFileList(string RepCondition, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();

            try
            {
                SqlParameter pAction = new SqlParameter(File._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter(File._StrCondition, SqlDbType.NVarChar);

                pAction.Value = 5;
                PrepCondition.Value = RepCondition;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, File.SP_FileMaster, pAction, PrepCondition);
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

        //public DataSet ChkDuplicate(int id, string Name, out string StrError)
        //{
        //    StrError = string.Empty;

        //    DataSet DS = new DataSet();
        //    try
        //    {
        //        SqlParameter pAction = new SqlParameter(File._Action, SqlDbType.BigInt);
        //        SqlParameter pId = new SqlParameter(File._CabinetId, SqlDbType.BigInt);
        //        SqlParameter pRepCondition = new SqlParameter(File._StrCondition, SqlDbType.NVarChar);

        //        pAction.Value = 6;
        //        pId.Value = id;
        //        pRepCondition.Value = Name;

        //        Open(CONNECTION_STRING);
        //        SqlParameter[] param = { pAction, pId, pRepCondition };
        //        DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, File.SP_FileMaster, param);

        //    }
        //    catch (Exception ex)
        //    {
        //        StrError = ex.Message;
        //    }
        //    finally
        //    {
        //        Close();
        //    }
        //    return DS;
        //}


        public DataSet ChkDuplicate(string Name, long FileId, string Room, string Aisle, string RowNo, string CabinetNo,string ShelfNo, out string StrError)
        {
            StrError = string.Empty;

            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(FileDocument._Action, SqlDbType.BigInt);
                SqlParameter pRepCondition = new SqlParameter(FileDocument._StrCondition, SqlDbType.NVarChar);
                SqlParameter pFileId = new SqlParameter(FileDocument._ShelfId, SqlDbType.BigInt);
                SqlParameter pRoom = new SqlParameter("@Room", SqlDbType.NVarChar);
                SqlParameter pAisle = new SqlParameter("@Aisle", SqlDbType.NVarChar);
                SqlParameter pRowNo = new SqlParameter("@RowNo", SqlDbType.NVarChar);
                SqlParameter pCabinetNo = new SqlParameter("@CabinetNo", SqlDbType.NVarChar);
                SqlParameter pShelfNo = new SqlParameter("@ShelfNo", SqlDbType.NVarChar);

                pAction.Value = 6;
                pRepCondition.Value = Name;
                pFileId.Value = FileId;
                pRoom.Value = Room;
                pAisle.Value = Aisle;
                pRowNo.Value = RowNo;
                pCabinetNo.Value = CabinetNo;
                pShelfNo.Value = ShelfNo;


                SqlParameter[] param = new SqlParameter[] { pAction, pRepCondition, pFileId, pRoom, pAisle, pRowNo, pCabinetNo, pShelfNo };

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, FileDocument.SP_FileDocuments, param);

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
                SqlParameter pAction = new SqlParameter(File._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter(File._StrCondition, SqlDbType.NVarChar);

                pAction.Value = 5;
                PrepCondition.Value = preFixText;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

                Open(CONNECTION_STRING);
                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, File.SP_FileMaster, oparamcol);

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


        public DataSet FillCombo(out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(File._Action, SqlDbType.BigInt);

                pAction.Value = 7;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, File.SP_FileMaster, pAction);
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

        public DMFile()
        {
          
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
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, File.SP_FileMaster, pAction, pId);

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

                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, File.SP_FileMaster, param);
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

                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, File.SP_FileMaster, param);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet GetShelfNo(int RoomId, int AisleId, int RowId,int CabinetId, out string strError)
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

                pAction.Value = 11;
                pRoomId.Value = RoomId;
                pAisleId.Value = AisleId;
                pRowId.Value = RowId;
                pCabinetId.Value = CabinetId;

                Open(CONNECTION_STRING);
                SqlParameter[] param = { pAction, pRoomId, pAisleId, pRowId, pCabinetId };

                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, File.SP_FileMaster, param);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet GetFileNo(int RoomId, int AisleId, int RowId, int CabinetId,int ShelfId, out string strError)
        {
            DataSet Ds = new DataSet();
            strError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pRoomId = new SqlParameter("@RoomId", SqlDbType.BigInt);
                SqlParameter pAisleId = new SqlParameter("@AisleId", SqlDbType.BigInt);
                SqlParameter pRowId = new SqlParameter("@RowId", SqlDbType.BigInt);
                SqlParameter pCabinetId = new SqlParameter("@CabinetId", SqlDbType.BigInt);
                SqlParameter pShelfId = new SqlParameter("@ShelfId", SqlDbType.BigInt);

                pAction.Value = 12;
                pRoomId.Value = RoomId;
                pAisleId.Value = AisleId;
                pRowId.Value = RowId;
                pCabinetId.Value = CabinetId;
                pShelfId.Value = ShelfId;

                Open(CONNECTION_STRING);
                SqlParameter[] param = { pAction, pRoomId, pAisleId, pRowId, pCabinetId, pShelfId };

                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, File.SP_FileMaster, param);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally
            {
                Close();
            }
            return Ds;
        }
    }
}