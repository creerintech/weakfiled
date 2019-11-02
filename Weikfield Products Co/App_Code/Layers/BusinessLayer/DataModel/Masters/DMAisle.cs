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
    public class DMAisle:Utility.Setting
    {
        public int InsertAisle(ref AisleMaster Entity_Aisle, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(AisleMaster._Action, SqlDbType.BigInt);
                SqlParameter pAisle = new SqlParameter(AisleMaster._Aisle, SqlDbType.NVarChar);
                SqlParameter pRoomId = new SqlParameter(AisleMaster._RoomId, SqlDbType.BigInt);

                SqlParameter pCreatedBy = new SqlParameter(AisleMaster._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(AisleMaster._LoginDate, SqlDbType.DateTime);

                pAction.Value = 1;
                pAisle.Value = Entity_Aisle.Aisle;
                pRoomId.Value = Entity_Aisle.RoomId;
                pCreatedBy.Value = Entity_Aisle.UserId;
                pCreatedDate.Value = Entity_Aisle.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pAisle,pRoomId,  pCreatedBy, pCreatedDate };
                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, AisleMaster.SP_AisleMaster, param);

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

        public int UpdateAisle(ref AisleMaster Entity_Aisle, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(AisleMaster._Action, SqlDbType.BigInt);
                SqlParameter pAisleId = new SqlParameter(AisleMaster._AisleId, SqlDbType.BigInt);
                SqlParameter pAisle = new SqlParameter(AisleMaster._Aisle, SqlDbType.NVarChar);
                SqlParameter pRoomId = new SqlParameter(AisleMaster._RoomId, SqlDbType.BigInt);

                SqlParameter pCreatedBy = new SqlParameter(AisleMaster._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(AisleMaster._LoginDate, SqlDbType.DateTime);

                pAction.Value = 2;
                pAisleId.Value = Entity_Aisle.AisleId;
                pAisle.Value = Entity_Aisle.Aisle;
                pRoomId.Value = Entity_Aisle.RoomId;
                pCreatedBy.Value = Entity_Aisle.UserId;
                pCreatedDate.Value = Entity_Aisle.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pAisleId, pAisle,pRoomId, pCreatedBy, pCreatedDate };
                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, AisleMaster.SP_AisleMaster, param);

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

        public int DeleteAisle(ref AisleMaster Entity_Aisle, out string StrError)
        {
            int iDelete = 0;
            StrError = string.Empty;

            try
            {
                SqlParameter pAction = new SqlParameter(AisleMaster._Action, SqlDbType.BigInt);
                SqlParameter pAisleId = new SqlParameter(AisleMaster._AisleId, SqlDbType.BigInt);
                SqlParameter pDeletedBy = new SqlParameter(AisleMaster._UserId, SqlDbType.BigInt);
                SqlParameter pDeletedDate = new SqlParameter(AisleMaster._LoginDate, SqlDbType.DateTime);

                pAction.Value = 3;
                pAisleId.Value = Entity_Aisle.AisleId;
                pDeletedBy.Value = Entity_Aisle.UserId;
                pDeletedDate.Value = Entity_Aisle.LoginDate;
                // pIsDeleted.Value = Entity_Country.IsDeleted;

                SqlParameter[] param = new SqlParameter[] { pAction, pAisleId, pDeletedBy, pDeletedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iDelete = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, AisleMaster.SP_AisleMaster, param);

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

        public DataSet GetAisleForEdit(int ID, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();

            try
            {
                SqlParameter pAction = new SqlParameter(AisleMaster._Action, SqlDbType.BigInt);
                SqlParameter pAisleId = new SqlParameter(AisleMaster._AisleId, SqlDbType.BigInt);

                pAction.Value = 4;
                pAisleId.Value = ID;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, AisleMaster.SP_AisleMaster, pAction, pAisleId);

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

        public DataSet GetAisleList(string RepCondition, out string StrError)
        {
            StrError = string.Empty;

            DataSet DS = new DataSet();

            try
            {
                SqlParameter pAction = new SqlParameter(AisleMaster._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter(AisleMaster._StrCondition, SqlDbType.NVarChar);

                pAction.Value = 5;
                PrepCondition.Value = RepCondition;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, AisleMaster.SP_AisleMaster, pAction, PrepCondition);


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

        public DataSet ChkDuplicate(string Name,Int32 RoomId, long AisleId,  out string StrError)
        {
            StrError = string.Empty;

            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(AisleMaster._Action, SqlDbType.BigInt);
                SqlParameter pRepCondition = new SqlParameter("@Aisle", SqlDbType.NVarChar);
                SqlParameter pAisleId = new SqlParameter(AisleMaster._AisleId, SqlDbType.BigInt);
                SqlParameter pRoomId = new SqlParameter(AisleMaster._RoomId, SqlDbType.BigInt);
              
                pAction.Value = 6;
                pRepCondition.Value = Name;
                pAisleId.Value = AisleId;
                pRoomId.Value = RoomId;

                SqlParameter[] param = new SqlParameter[] { pAction, pRepCondition, pAisleId, pRoomId };

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, AisleMaster.SP_AisleMaster, param);

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
                SqlParameter pAction = new SqlParameter(AisleMaster._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter(AisleMaster._StrCondition, SqlDbType.NVarChar);

                pAction.Value = 5;
                PrepCondition.Value = preFixText;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

                Open(CONNECTION_STRING);
                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, AisleMaster.SP_AisleMaster, oparamcol);

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


        public DataSet GetRoom(out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(AisleMaster._Action, SqlDbType.BigInt);

                pAction.Value = 7;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, AisleMaster.SP_AisleMaster, pAction);

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

                pAction.Value = 7;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_AisleMaster", pAction);

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
        public DataSet FillComboAsile(out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(Cabinet._Action, SqlDbType.BigInt);

                pAction.Value = 8;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_AisleMaster", pAction);

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
        public DMAisle()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}