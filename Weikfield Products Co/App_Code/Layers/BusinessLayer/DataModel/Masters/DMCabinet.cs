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
    public class DMCabinet:Utility.Setting
    {

        public int InsertCabinet(ref Cabinet Entity_Cabinet, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(Cabinet._Action, SqlDbType.BigInt);
                SqlParameter pCabinetNo = new SqlParameter(Cabinet._CabinetNo, SqlDbType.NVarChar);

                SqlParameter pCreatedBy = new SqlParameter(Cabinet._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(Cabinet._LoginDate, SqlDbType.DateTime);

                pAction.Value = 1;
                pCabinetNo.Value = Entity_Cabinet.CabinetNo;
                pCreatedBy.Value = Entity_Cabinet.UserId;
                pCreatedDate.Value = Entity_Cabinet.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pCabinetNo, pCreatedBy, pCreatedDate };
                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, Cabinet.SP_CabinetMaster, param);

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

        public int UpdateCabinet(ref Cabinet Entity_Cabinet, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(Cabinet._Action, SqlDbType.BigInt);
                SqlParameter pCabinetId = new SqlParameter(Cabinet._CabinetId, SqlDbType.BigInt);
              
                SqlParameter pCabinetNo = new SqlParameter(Cabinet._CabinetNo, SqlDbType.NVarChar);
               
                SqlParameter pCreatedBy = new SqlParameter(Cabinet._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(Cabinet._LoginDate, SqlDbType.DateTime);

                pAction.Value = 2;
                pCabinetId.Value = Entity_Cabinet.CabinetId;
                
                pCabinetNo.Value = Entity_Cabinet.CabinetNo;
              
                pCreatedBy.Value = Entity_Cabinet.UserId;
                pCreatedDate.Value = Entity_Cabinet.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pCabinetId,  pCabinetNo, pCreatedBy, pCreatedDate };
                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, Cabinet.SP_CabinetMaster, param);

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

        public int DeleteCabinet(ref Cabinet Entity_Cabinet, out string StrError)
        {
            int iDelete = 0;
            StrError = string.Empty;

            try
            {
                SqlParameter pAction = new SqlParameter(Cabinet._Action, SqlDbType.BigInt);
                SqlParameter pCabinetId = new SqlParameter(Cabinet._CabinetId, SqlDbType.BigInt);
                SqlParameter pDeletedBy = new SqlParameter(Cabinet._UserId, SqlDbType.BigInt);
                SqlParameter pDeletedDate = new SqlParameter(Cabinet._LoginDate, SqlDbType.DateTime);

                pAction.Value = 3;
                pCabinetId.Value = Entity_Cabinet.CabinetId;
                pDeletedBy.Value = Entity_Cabinet.UserId;
                pDeletedDate.Value = Entity_Cabinet.LoginDate;


                SqlParameter[] param = new SqlParameter[] { pAction, pCabinetId, pDeletedBy, pDeletedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iDelete = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, Cabinet.SP_CabinetMaster, param);

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

        public DataSet GetCabinetForEdit(int ID, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();

            try
            {
                SqlParameter pAction = new SqlParameter(Cabinet._Action, SqlDbType.BigInt);
                SqlParameter pCabinetId = new SqlParameter(Cabinet._CabinetId, SqlDbType.BigInt);

                pAction.Value = 4;
                pCabinetId.Value = ID;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, Cabinet.SP_CabinetMaster, pAction, pCabinetId);
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

        public DataSet GetCabinetList(string RepCondition, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();

            try
            {
                SqlParameter pAction = new SqlParameter(Cabinet._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter(Cabinet._StrCondition, SqlDbType.NVarChar);

                pAction.Value = 5;
                PrepCondition.Value = RepCondition;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, Cabinet.SP_CabinetMaster, pAction, PrepCondition);
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

        public DataSet ChkDuplicate(string Name, long CabinetId, out string StrError)
        {
            StrError = string.Empty;

            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(Cabinet._Action, SqlDbType.BigInt);
                SqlParameter pRepCondition = new SqlParameter(Cabinet._StrCondition, SqlDbType.NVarChar);
                SqlParameter pCabinetId = new SqlParameter(Cabinet._CabinetId, SqlDbType.BigInt);
                
                pAction.Value = 6;
                pRepCondition.Value = Name;
                pCabinetId.Value = CabinetId;
             

                SqlParameter[] param = new SqlParameter[] { pAction, pRepCondition, pCabinetId };

                Open(CONNECTION_STRING);
                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, Cabinet.SP_CabinetMaster, param);

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
                SqlParameter pAction = new SqlParameter(Cabinet._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter(Cabinet._StrCondition, SqlDbType.NVarChar);

                pAction.Value = 5;
                PrepCondition.Value = preFixText;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

                Open(CONNECTION_STRING);
                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, Cabinet.SP_CabinetMaster, oparamcol);

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

        public DataSet GetAisle(int RoomId, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pRoomId = new SqlParameter("@RoomId", SqlDbType.BigInt);

                pAction.Value = 8;
                pRoomId.Value = RoomId;

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, Cabinet.SP_CabinetMaster, pAction, pRoomId);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public DataSet GetRowNo(int RoomId,int AisleId, out string strError)
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


        public DataSet FillCombo(out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(Cabinet._Action, SqlDbType.BigInt);

                pAction.Value = 7;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, Cabinet.SP_CabinetMaster, pAction);

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

        public DMCabinet()
        {
          
        }
    }
}