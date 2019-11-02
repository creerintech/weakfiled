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
    public class DMDepartmentSubSubCategory:Utility.Setting
    {
        public int InsertDepartmentSubCategory(ref DeptSubSubCategory Entity_DeptSubSubCategory, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(DeptSubSubCategory._Action, SqlDbType.BigInt);
                SqlParameter pDepartmentSubSubCategory = new SqlParameter(DeptSubSubCategory._DepartmentSubSubCategory, SqlDbType.NVarChar);
                SqlParameter pDepartmentCategoryId = new SqlParameter(DeptSubSubCategory._DepartmentCategoryId, SqlDbType.BigInt);
                SqlParameter pDepartmentSubCategoryId = new SqlParameter(DeptSubSubCategory._DepartmentSubCategoryId, SqlDbType.BigInt);

                SqlParameter pCreatedBy = new SqlParameter(DeptSubSubCategory._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(DeptSubSubCategory._LoginDate, SqlDbType.DateTime);

                pAction.Value = 1;
                pDepartmentSubSubCategory.Value = Entity_DeptSubSubCategory.DepartmentSubSubCategory;
                pDepartmentCategoryId.Value = Entity_DeptSubSubCategory.DepartmentCategoryId;
                pDepartmentSubCategoryId.Value = Entity_DeptSubSubCategory.DepartmentSubCategoryId;
                pCreatedBy.Value = Entity_DeptSubSubCategory.UserId;
                pCreatedDate.Value = Entity_DeptSubSubCategory.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pDepartmentSubSubCategory, pDepartmentCategoryId, pDepartmentSubCategoryId, pCreatedBy, pCreatedDate };
                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, DeptSubSubCategory.SP_DepartmentSubSubCategory, param);

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

        public int UpdateDepartmentSubCategory(ref DeptSubSubCategory Entity_DeptSubSubCategory, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(DeptSubSubCategory._Action, SqlDbType.BigInt);
                SqlParameter pDepartmentSubCategoryId = new SqlParameter(DeptSubSubCategory._DepartmentSubCategoryId, SqlDbType.BigInt);
                SqlParameter pDepartmentSubSubCategoryId = new SqlParameter(DeptSubSubCategory._DepartmentSubSubCategoryId, SqlDbType.BigInt);
                SqlParameter pDepartmentSubSubCategory = new SqlParameter(DeptSubSubCategory._DepartmentSubSubCategory, SqlDbType.NVarChar);
                SqlParameter pDepartmentCategoryId = new SqlParameter(DeptSubSubCategory._DepartmentCategoryId, SqlDbType.BigInt);
                SqlParameter pCreatedBy = new SqlParameter(DeptSubSubCategory._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(DeptSubSubCategory._LoginDate, SqlDbType.DateTime);

                pAction.Value = 2;
                pDepartmentSubCategoryId.Value = Entity_DeptSubSubCategory.DepartmentSubCategoryId;
                pDepartmentSubSubCategoryId.Value = Entity_DeptSubSubCategory.DepartmentSubSubCategoryId;
                pDepartmentSubSubCategory.Value = Entity_DeptSubSubCategory.DepartmentSubSubCategory;
                pDepartmentCategoryId.Value = Entity_DeptSubSubCategory.DepartmentCategoryId;
                pCreatedBy.Value = Entity_DeptSubSubCategory.UserId;
                pCreatedDate.Value = Entity_DeptSubSubCategory.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pDepartmentSubCategoryId, pDepartmentSubSubCategoryId, pDepartmentSubSubCategory, pDepartmentCategoryId, pCreatedBy, pCreatedDate };
                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, DeptSubSubCategory.SP_DepartmentSubSubCategory, param);

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

        public int DeleteDepartmentSubCategory(ref DeptSubSubCategory Entity_DeptSubSubCategory, out string StrError)
        {
            int iDelete = 0;
            StrError = string.Empty;

            try
            {
                SqlParameter pAction = new SqlParameter(DeptSubSubCategory._Action, SqlDbType.BigInt);
                SqlParameter pDepartmentSubSubCategoryId = new SqlParameter(DeptSubSubCategory._DepartmentSubSubCategoryId, SqlDbType.BigInt);
                SqlParameter pDeletedBy = new SqlParameter(DeptSubSubCategory._UserId, SqlDbType.BigInt);
                SqlParameter pDeletedDate = new SqlParameter(DeptSubSubCategory._LoginDate, SqlDbType.DateTime);

                pAction.Value = 3;
                pDepartmentSubSubCategoryId.Value = Entity_DeptSubSubCategory.DepartmentSubSubCategoryId;
                pDeletedBy.Value = Entity_DeptSubSubCategory.UserId;
                pDeletedDate.Value = Entity_DeptSubSubCategory.LoginDate;
        
                SqlParameter[] param = new SqlParameter[] { pAction, pDepartmentSubSubCategoryId, pDeletedBy, pDeletedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iDelete = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, DeptSubSubCategory.SP_DepartmentSubSubCategory, param);

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

        public DataSet GetDepartmentSubCategoryForEdit(int ID, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();

            try
            {
                SqlParameter pAction = new SqlParameter(DeptSubSubCategory._Action, SqlDbType.BigInt);
                SqlParameter pDepartmentSubSubCategoryId = new SqlParameter(DeptSubSubCategory._DepartmentSubSubCategoryId, SqlDbType.BigInt);

                pAction.Value = 4;
                pDepartmentSubSubCategoryId.Value = ID;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, DeptSubSubCategory.SP_DepartmentSubSubCategory, pAction, pDepartmentSubSubCategoryId);

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

        public DataSet GetDepartmentSubCategoryList(string RepCondition, out string StrError)
        {
            StrError = string.Empty;

            DataSet DS = new DataSet();

            try
            {
                SqlParameter pAction = new SqlParameter(DeptSubSubCategory._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter(DeptSubSubCategory._StrCondition, SqlDbType.NVarChar);

                pAction.Value = 5;
                PrepCondition.Value = RepCondition;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, DeptSubSubCategory.SP_DepartmentSubSubCategory, pAction, PrepCondition);


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

        public DataSet ChkDuplicate(string Name, long DepartmentSubSubCategoryId, string DepartmentCategory, string DepartmentSubCategory, out string StrError)
        {
            StrError = string.Empty;

            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(DeptSubSubCategory._Action, SqlDbType.BigInt);
                SqlParameter pDepartmentSubSubCategoryId = new SqlParameter(DeptSubSubCategory._DepartmentSubSubCategoryId, SqlDbType.BigInt);
                SqlParameter pRepCondition = new SqlParameter(DeptSubSubCategory._StrCondition, SqlDbType.NVarChar);
                SqlParameter pDepartmentCategory = new SqlParameter("@DepartmentCategory", SqlDbType.NVarChar);
                SqlParameter pDepartmentSubCategory = new SqlParameter("@DepartmentSubCategory", SqlDbType.NVarChar);

                pAction.Value = 6;
                pDepartmentSubSubCategoryId.Value = DepartmentSubSubCategoryId;
                pRepCondition.Value = Name;
                pDepartmentCategory.Value = DepartmentCategory;
                pDepartmentSubCategory.Value = DepartmentSubCategory;

                Open(CONNECTION_STRING);
                SqlParameter[] param = { pAction, pDepartmentSubSubCategoryId, pRepCondition, pDepartmentCategory, pDepartmentSubCategory };
                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, DeptSubSubCategory.SP_DepartmentSubSubCategory, param);

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
                SqlParameter pAction = new SqlParameter(DeptSubSubCategory._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter(DeptSubSubCategory._StrCondition, SqlDbType.NVarChar);

                pAction.Value = 5;
                PrepCondition.Value = preFixText;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

                Open(CONNECTION_STRING);
                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, DeptSubSubCategory.SP_DepartmentSubSubCategory, oparamcol);

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


        public DataSet GetDepartmentSubCategory(out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(DeptSubSubCategory._Action, SqlDbType.BigInt);

                pAction.Value = 7;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, DeptSubSubCategory.SP_DepartmentSubSubCategory, pAction);

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


        public DataSet GetSubDepartment(int ID, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pDepartmentCategoryId = new SqlParameter("@DepartmentCategoryId", SqlDbType.BigInt);

                pAction.Value = 8;
                pDepartmentCategoryId.Value = ID;

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure,DeptSubSubCategory.SP_DepartmentSubSubCategory, pAction, pDepartmentCategoryId);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public DMDepartmentSubSubCategory()
        {

        }
    }
}