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

    public class DMRows:Utility.Setting
    {

        public int InsertRow(ref Rows Entity_Rows, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(Rows._Action, SqlDbType.BigInt);
                SqlParameter pAisleId = new SqlParameter(Rows._AisleId, SqlDbType.BigInt);
                SqlParameter pRoomId = new SqlParameter(Rows._RoomId, SqlDbType.BigInt);
                SqlParameter pRowNo = new SqlParameter(Rows._RowNo, SqlDbType.NVarChar);

                SqlParameter pCreatedBy = new SqlParameter(Rows._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(Rows._LoginDate, SqlDbType.DateTime);

                pAction.Value = 1;
                pAisleId.Value = Entity_Rows.AisleId;
                pRoomId.Value = Entity_Rows.RoomId;
                pRowNo.Value = Entity_Rows.RowNo;
                pCreatedBy.Value = Entity_Rows.UserId;
                pCreatedDate.Value = Entity_Rows.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pAisleId, pRoomId, pRowNo, pCreatedBy, pCreatedDate };
                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, Rows.SP_RowMaster, param);

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

        public int UpdateRow(ref Rows Entity_Rows, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(Rows._Action, SqlDbType.BigInt);
                SqlParameter pRowId = new SqlParameter(Rows._RowId, SqlDbType.BigInt);
                SqlParameter pAisleId = new SqlParameter(Rows._AisleId, SqlDbType.BigInt);
                SqlParameter pRowNo = new SqlParameter(Rows._RowNo, SqlDbType.NVarChar);
                SqlParameter pRoomId = new SqlParameter(Rows._RoomId, SqlDbType.BigInt);
                SqlParameter pCreatedBy = new SqlParameter(Rows._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(Rows._LoginDate, SqlDbType.DateTime);

                pAction.Value = 2;
                pRowId.Value = Entity_Rows.RowId;
                pAisleId.Value = Entity_Rows.AisleId;
                pRowNo.Value = Entity_Rows.RowNo;
                pRoomId.Value = Entity_Rows.RoomId;
                pCreatedBy.Value = Entity_Rows.UserId;
                pCreatedDate.Value = Entity_Rows.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pRowId, pAisleId, pRowNo, pRoomId, pCreatedBy, pCreatedDate };
                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, Rows.SP_RowMaster, param);

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

        public int DeleteRow(ref Rows Entity_Rows, out string StrError)
        {
            int iDelete = 0;
            StrError = string.Empty;

            try
            {
                SqlParameter pAction = new SqlParameter(Rows._Action, SqlDbType.BigInt);
                SqlParameter pRowId = new SqlParameter(Rows._RowId, SqlDbType.BigInt);
                SqlParameter pDeletedBy = new SqlParameter(Rows._UserId, SqlDbType.BigInt);
                SqlParameter pDeletedDate = new SqlParameter(Rows._LoginDate, SqlDbType.DateTime);

                pAction.Value = 3;
                pRowId.Value = Entity_Rows.RowId;
                pDeletedBy.Value = Entity_Rows.UserId;
                pDeletedDate.Value = Entity_Rows.LoginDate;
              
                
                SqlParameter[] param = new SqlParameter[] { pAction, pRowId, pDeletedBy, pDeletedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iDelete = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, Rows.SP_RowMaster, param);

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

        public DataSet GetRowForEdit(int ID, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();

            try
            {
                SqlParameter pAction = new SqlParameter(Rows._Action, SqlDbType.BigInt);
                SqlParameter pRowId = new SqlParameter(Rows._RowId, SqlDbType.BigInt);

                pAction.Value = 4;
                pRowId.Value = ID;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, Rows.SP_RowMaster, pAction, pRowId);
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

        public DataSet GetRowList(string RepCondition, out string StrError)
        {
            StrError = string.Empty;

            DataSet DS = new DataSet();

            try
            {
                SqlParameter pAction = new SqlParameter(Rows._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter(Rows._StrCondition, SqlDbType.NVarChar);

                pAction.Value = 5;
                PrepCondition.Value = RepCondition;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, Rows.SP_RowMaster, pAction, PrepCondition);


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

        //public DataSet ChkDuplicate(string Name,int id, out string StrError)
        //{
        //    StrError = string.Empty;

        //    DataSet DS = new DataSet();
        //    try
        //    {
        //        SqlParameter pAction = new SqlParameter(Rows._Action, SqlDbType.BigInt);
        //        SqlParameter pId = new SqlParameter(Rows._AisleId, SqlDbType.BigInt);
        //        SqlParameter pRepCondition = new SqlParameter(Rows._StrCondition, SqlDbType.NVarChar);

        //        pAction.Value = 6;
        //        pId.Value = id;
        //        pRepCondition.Value = Name;

        //        Open(CONNECTION_STRING);
        //        SqlParameter[] param = { pAction, pId, pRepCondition };
        //        DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, Rows.SP_RowMaster, param);

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


        public DataSet ChkDuplicate(string Name, long RowId, string Room, string Aisle, out string StrError)
        {
            StrError = string.Empty;

            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(Rows._Action, SqlDbType.BigInt);
                SqlParameter pRepCondition = new SqlParameter(Rows._StrCondition, SqlDbType.NVarChar);
                SqlParameter pRowId = new SqlParameter(Rows._RowId, SqlDbType.BigInt);
                SqlParameter pRoom = new SqlParameter("@Room", SqlDbType.NVarChar);
                SqlParameter pAisle = new SqlParameter("@Aisle", SqlDbType.NVarChar);

                pAction.Value = 6;
                pRepCondition.Value = Name;
                pRowId.Value = RowId;
                pRoom.Value = Room;
                pAisle.Value = Aisle;

                SqlParameter[] param = new SqlParameter[] { pAction, pRepCondition, pRowId, pRoom, pAisle };

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, Rows.SP_RowMaster, param);

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
                SqlParameter pAction = new SqlParameter(Rows._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter(Rows._StrCondition, SqlDbType.NVarChar);

                pAction.Value = 5;
                PrepCondition.Value = preFixText;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

                Open(CONNECTION_STRING);
                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, Rows.SP_RowMaster, oparamcol);

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
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, Rows.SP_RowMaster, pAction, pId);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public DataSet FillCombo(out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(Rows._Action, SqlDbType.BigInt);

                pAction.Value = 7;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, Rows.SP_RowMaster, pAction);

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

        public DMRows()
        {
          
        }
    }
}