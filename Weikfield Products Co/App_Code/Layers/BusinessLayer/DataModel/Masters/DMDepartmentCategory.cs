using DMS.DALSQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DMS.DataModel
{
    public class DMDepartmentCategory:Utility.Setting
    {
        public int InsertDepartmentCategoryMaster(string DepartmentCategory, long userId, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pCreatedBy = new SqlParameter("@UserId", SqlDbType.BigInt);
                SqlParameter pDepartmentCategory = new SqlParameter("@DepartmentCategory", SqlDbType.NVarChar);
              


                pAction.Value = 1;
                pCreatedBy.Value = userId;
                pDepartmentCategory.Value = DepartmentCategory;
               
                SqlParameter[] param = new SqlParameter[] { pAction, pCreatedBy, pDepartmentCategory };

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, "SP_DepartmentCategoryMaster", param);


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

        public int UpdateDepartmentCategoryMaster(string DepartmentCategory, long DepartmentCategoryId, long userId, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pId = new SqlParameter("@DepartmentCategoryId", SqlDbType.BigInt);
                SqlParameter pUpdatedBy = new SqlParameter("@UserId", SqlDbType.BigInt);
                SqlParameter pDepartmentCategory = new SqlParameter("@DepartmentCategory", SqlDbType.NVarChar);

                pAction.Value = 2;
                pId.Value = DepartmentCategoryId;
                pUpdatedBy.Value = userId;
                pDepartmentCategory.Value = DepartmentCategory;

                SqlParameter[] param = new SqlParameter[] { pAction, pId, pUpdatedBy, pDepartmentCategory };

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, "SP_DepartmentCategoryMaster", param);

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

        public int DeleteDepartmentCategoryMaster(long DepartmentCategoryId, long userId, out string StrError)
        {
            int iDelete = 0;
            StrError = string.Empty;

            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pId = new SqlParameter("@DepartmentCategoryId", SqlDbType.BigInt);
                SqlParameter pDeletedBy = new SqlParameter("@UserId", SqlDbType.BigInt);

                pAction.Value = 3;
                pId.Value = DepartmentCategoryId;
                pDeletedBy.Value = userId;

                SqlParameter[] param = new SqlParameter[] { pAction, pId, pDeletedBy };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iDelete = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, "SP_DepartmentCategoryMaster", param);

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

        public DataSet ChkDuplicate(string DepartmentCategory, long DepartmentCategoryId, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pId = new SqlParameter("@DepartmentCategoryId", SqlDbType.BigInt);
                SqlParameter pName = new SqlParameter("@DepartmentCategory", SqlDbType.NVarChar);

                pAction.Value = 4;
                pName.Value = DepartmentCategory;
                pId.Value = DepartmentCategoryId;

                SqlParameter[] param = new SqlParameter[] { pAction, pName, pId };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_DepartmentCategoryMaster", param);

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

                pAction.Value = 5;
                PrepCondition.Value = condition;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_DepartmentCategoryMaster", pAction, PrepCondition);


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
                Ds = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_DepartmentCategoryMaster", pAction);
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
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter("@DepartmentCategory", SqlDbType.NVarChar);

                pAction.Value = 5;
                PrepCondition.Value = preFixText;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

                Open(CONNECTION_STRING);
                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, "SP_DepartmentCategoryMaster", oparamcol);

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

        public DMDepartmentCategory()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}