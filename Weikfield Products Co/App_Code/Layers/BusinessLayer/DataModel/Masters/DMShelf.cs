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
    public class DMShelf:Utility.Setting
    {
        public int InsertShelf(ref Shelf Entity_Shelf, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(Shelf._Action, SqlDbType.BigInt);
                SqlParameter pShelfNo = new SqlParameter(Shelf._ShelfNo, SqlDbType.NVarChar);
                SqlParameter pRoomId = new SqlParameter(Shelf._RoomId, SqlDbType.BigInt);
                SqlParameter pAisleId = new SqlParameter(Shelf._AisleId, SqlDbType.BigInt);

                SqlParameter pCreatedBy = new SqlParameter(Shelf._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(Shelf._LoginDate, SqlDbType.DateTime);

                pAction.Value = 1;
            
                pShelfNo.Value = Entity_Shelf.ShelfNo;
                pRoomId.Value = Entity_Shelf.RoomId;
                pAisleId.Value = Entity_Shelf.AisleId;
                pCreatedBy.Value = Entity_Shelf.UserId;
                pCreatedDate.Value = Entity_Shelf.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pShelfNo,pRoomId,pAisleId, pCreatedBy, pCreatedDate };
                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, Shelf.SP_ShelfMaster, param);

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

        public int UpdateShelf(ref Shelf Entity_Shelf, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(Shelf._Action, SqlDbType.BigInt);
                SqlParameter pShelfId = new SqlParameter(Shelf._ShelfId, SqlDbType.BigInt);
                SqlParameter pRoomId = new SqlParameter(Shelf._RoomId, SqlDbType.BigInt);
                SqlParameter pAisleId = new SqlParameter(Shelf._AisleId, SqlDbType.BigInt);

                SqlParameter pShelfNo = new SqlParameter(Shelf._ShelfNo, SqlDbType.NVarChar);
                SqlParameter pCabinetId = new SqlParameter(Shelf._CabinetId, SqlDbType.BigInt);
                SqlParameter pCreatedBy = new SqlParameter(Shelf._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(Shelf._LoginDate, SqlDbType.DateTime);

                pAction.Value = 2;
                pShelfId.Value = Entity_Shelf.ShelfId;
              
                pShelfNo.Value = Entity_Shelf.ShelfNo;
                pRoomId.Value = Entity_Shelf.RoomId;
                pAisleId.Value = Entity_Shelf.AisleId;
                pCabinetId.Value = Entity_Shelf.CabinetId;
                pCreatedBy.Value = Entity_Shelf.UserId;
                pCreatedDate.Value = Entity_Shelf.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pShelfId,  pShelfNo,pRoomId,pAisleId,  pCabinetId, pCreatedBy, pCreatedDate };
                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, Shelf.SP_ShelfMaster, param);

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

        public int DeleteShelf(ref Shelf Entity_Shelf, out string StrError)
        {
            int iDelete = 0;
            StrError = string.Empty;

            try
            {
                SqlParameter pAction = new SqlParameter(Shelf._Action, SqlDbType.BigInt);
                SqlParameter pShelfId = new SqlParameter(Shelf._ShelfId, SqlDbType.BigInt);
                SqlParameter pDeletedBy = new SqlParameter(Shelf._UserId, SqlDbType.BigInt);
                SqlParameter pDeletedDate = new SqlParameter(Shelf._LoginDate, SqlDbType.DateTime);

                pAction.Value = 3;
                pShelfId.Value = Entity_Shelf.ShelfId;
                pDeletedBy.Value = Entity_Shelf.UserId;
                pDeletedDate.Value = Entity_Shelf.LoginDate;


                SqlParameter[] param = new SqlParameter[] { pAction, pShelfId, pDeletedBy, pDeletedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iDelete = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, Shelf.SP_ShelfMaster, param);

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

        public DataSet GetShelfForEdit(int ID, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();

            try
            {
                SqlParameter pAction = new SqlParameter(Shelf._Action, SqlDbType.BigInt);
                SqlParameter pShelfId = new SqlParameter(Shelf._ShelfId, SqlDbType.BigInt);

                pAction.Value = 4;
                pShelfId.Value = ID;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, Shelf.SP_ShelfMaster, pAction, pShelfId);
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

        public DataSet GetShelfList(string RepCondition, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();

            try
            {
                SqlParameter pAction = new SqlParameter(Shelf._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter(Shelf._StrCondition, SqlDbType.NVarChar);

                pAction.Value = 5;
                PrepCondition.Value = RepCondition;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, Shelf.SP_ShelfMaster, pAction, PrepCondition);
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

        public DataSet ChkDuplicate(string Name,Int32 RoomId,Int32 AisleId, long ShelfId,out string StrError)
        {
            StrError = string.Empty;

            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(Shelf._Action, SqlDbType.BigInt);
                SqlParameter pRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);
                SqlParameter pShelfId = new SqlParameter(Shelf._ShelfId, SqlDbType.BigInt);
                SqlParameter pRoomId = new SqlParameter(Shelf._RoomId, SqlDbType.BigInt);
                SqlParameter pAisleId = new SqlParameter(Shelf._AisleId, SqlDbType.BigInt);
                 
                pAction.Value = 6;
                pRepCondition.Value = Name;
                pShelfId.Value = ShelfId;
                pRoomId.Value=RoomId;
                pAisleId.Value = AisleId;

                SqlParameter[] param = new SqlParameter[] { pAction, pRepCondition, pShelfId, pRoomId, pAisleId };

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, Shelf.SP_ShelfMaster, param);

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
                SqlParameter pAction = new SqlParameter(Shelf._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter(Shelf._StrCondition, SqlDbType.NVarChar);

                pAction.Value = 5;
                PrepCondition.Value = preFixText;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

                Open(CONNECTION_STRING);
                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, Shelf.SP_ShelfMaster, oparamcol);

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

        public DataSet FillAisle(int RoomId, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(FileDocument._Action, SqlDbType.BigInt);
                SqlParameter pRoomId= new SqlParameter(FileDocument._RoomId, SqlDbType.BigInt);

                pAction.Value = 8;
                pRoomId.Value = RoomId;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_ShelfMaster", pAction, pRoomId);
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
                SqlParameter pAction = new SqlParameter(Shelf._Action, SqlDbType.BigInt);

                pAction.Value = 7;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, Shelf.SP_ShelfMaster, pAction);
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

        public DMShelf()
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
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, Shelf.SP_ShelfMaster, pAction, pId);

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

                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, Cabinet.SP_CabinetMaster, param);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

        public DataSet GetCabinetNo(int RoomId, int AisleId,int RowId, out string strError)
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

                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, Shelf.SP_ShelfMaster, param);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;
        }

    }
}