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
    public class DMDepartmentSubCategory:Utility.Setting
    {

        public int InsertDepartmentSubCategory(ref DepartmentSubCategoryMaster Entity_DepartmentSubCategory, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(DepartmentSubCategoryMaster._Action, SqlDbType.BigInt);
                SqlParameter pDepartmentSubCategory = new SqlParameter(DepartmentSubCategoryMaster._DepartmentSubCategory, SqlDbType.NVarChar);
                SqlParameter pDepartmentCategoryId = new SqlParameter(DepartmentSubCategoryMaster._DepartmentCategoryId, SqlDbType.BigInt);

                SqlParameter pCreatedBy = new SqlParameter(DepartmentSubCategoryMaster._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(DepartmentSubCategoryMaster._LoginDate, SqlDbType.DateTime);

                pAction.Value = 1;
                pDepartmentSubCategory.Value = Entity_DepartmentSubCategory.DepartmentSubCategory;
                pDepartmentCategoryId.Value = Entity_DepartmentSubCategory.DepartmentCategoryId;
                pCreatedBy.Value = Entity_DepartmentSubCategory.UserId;
                pCreatedDate.Value = Entity_DepartmentSubCategory.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pDepartmentSubCategory, pDepartmentCategoryId, pCreatedBy, pCreatedDate };
                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, DepartmentSubCategoryMaster.SP_DepartmentSubCategoryMaster, param);

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

        public int UpdateDepartmentSubCategory(ref DepartmentSubCategoryMaster Entity_DepartmentSubCategory, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(DepartmentSubCategoryMaster._Action, SqlDbType.BigInt);
                SqlParameter pDepartmentSubCategoryId = new SqlParameter(DepartmentSubCategoryMaster._DepartmentSubCategoryId, SqlDbType.BigInt);
                SqlParameter pDepartmentSubCategory = new SqlParameter(DepartmentSubCategoryMaster._DepartmentSubCategory, SqlDbType.NVarChar);
                SqlParameter pDepartmentCategoryId = new SqlParameter(DepartmentSubCategoryMaster._DepartmentCategoryId, SqlDbType.BigInt);
                SqlParameter pCreatedBy = new SqlParameter(DepartmentSubCategoryMaster._UserId, SqlDbType.BigInt);
                SqlParameter pCreatedDate = new SqlParameter(DepartmentSubCategoryMaster._LoginDate, SqlDbType.DateTime);

                pAction.Value = 2;
                pDepartmentSubCategoryId.Value = Entity_DepartmentSubCategory.DepartmentSubCategoryId;
                pDepartmentSubCategory.Value = Entity_DepartmentSubCategory.DepartmentSubCategory;
                pDepartmentCategoryId.Value = Entity_DepartmentSubCategory.DepartmentCategoryId;
                pCreatedBy.Value = Entity_DepartmentSubCategory.UserId;
                pCreatedDate.Value = Entity_DepartmentSubCategory.LoginDate;

                SqlParameter[] param = new SqlParameter[] { pAction, pDepartmentSubCategoryId, pDepartmentSubCategory, pDepartmentCategoryId, pCreatedBy, pCreatedDate };
                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, DepartmentSubCategoryMaster.SP_DepartmentSubCategoryMaster, param);

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

        public int DeleteDepartmentSubCategory(ref DepartmentSubCategoryMaster Entity_DepartmentSubCategory, out string StrError)
        {
            int iDelete = 0;
            StrError = string.Empty;

            try
            {
                SqlParameter pAction = new SqlParameter(DepartmentSubCategoryMaster._Action, SqlDbType.BigInt);
                SqlParameter pDepartmentSubCategoryId = new SqlParameter(DepartmentSubCategoryMaster._DepartmentSubCategoryId, SqlDbType.BigInt);
                SqlParameter pDeletedBy = new SqlParameter(DepartmentSubCategoryMaster._UserId, SqlDbType.BigInt);
                SqlParameter pDeletedDate = new SqlParameter(DepartmentSubCategoryMaster._LoginDate, SqlDbType.DateTime);

                pAction.Value = 3;
                pDepartmentSubCategoryId.Value = Entity_DepartmentSubCategory.DepartmentSubCategoryId;
                pDeletedBy.Value = Entity_DepartmentSubCategory.UserId;
                pDeletedDate.Value = Entity_DepartmentSubCategory.LoginDate;
                // pIsDeleted.Value = Entity_Country.IsDeleted;

                SqlParameter[] param = new SqlParameter[] { pAction, pDepartmentSubCategoryId, pDeletedBy, pDeletedDate };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iDelete = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, DepartmentSubCategoryMaster.SP_DepartmentSubCategoryMaster, param);

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
                SqlParameter pAction = new SqlParameter(DepartmentSubCategoryMaster._Action, SqlDbType.BigInt);
                SqlParameter pDepartmentSubCategoryId = new SqlParameter(DepartmentSubCategoryMaster._DepartmentSubCategoryId, SqlDbType.BigInt);

                pAction.Value = 4;
                pDepartmentSubCategoryId.Value = ID;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, DepartmentSubCategoryMaster.SP_DepartmentSubCategoryMaster, pAction, pDepartmentSubCategoryId);

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
                SqlParameter pAction = new SqlParameter(DepartmentSubCategoryMaster._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter(DepartmentSubCategoryMaster._StrCondition, SqlDbType.NVarChar);

                pAction.Value = 5;
                PrepCondition.Value = RepCondition;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, DepartmentSubCategoryMaster.SP_DepartmentSubCategoryMaster, pAction, PrepCondition);


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
        //        SqlParameter pAction = new SqlParameter(DepartmentSubCategoryMaster._Action, SqlDbType.BigInt);
        //        SqlParameter pId = new SqlParameter(DepartmentSubCategoryMaster._DepartmentCategoryId, SqlDbType.BigInt);
        //        SqlParameter pRepCondition = new SqlParameter(DepartmentSubCategoryMaster._StrCondition, SqlDbType.NVarChar);

        //        pAction.Value = 6;
        //        pId.Value = id;
        //        pRepCondition.Value = Name;

        //        Open(CONNECTION_STRING);
        //        SqlParameter[] param = { pAction, pId, pRepCondition };
        //        DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, DepartmentSubCategoryMaster.SP_DepartmentSubCategoryMaster, param);

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


        public DataSet ChkDuplicate(string Name, long DepartmentSubCategoryId, string DepartmentCategory,  out string StrError)
        {
            StrError = string.Empty;

            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(DepartmentSubCategoryMaster._Action, SqlDbType.BigInt);
                SqlParameter pDepartmentSubCategoryId = new SqlParameter(DepartmentSubCategoryMaster._DepartmentSubCategoryId, SqlDbType.BigInt);
                SqlParameter pRepCondition = new SqlParameter(DepartmentSubCategoryMaster._StrCondition, SqlDbType.NVarChar);
                SqlParameter pDepartmentCategory = new SqlParameter("@DepartmentCategory", SqlDbType.NVarChar);
               
                pAction.Value = 6;
                pDepartmentSubCategoryId.Value = DepartmentSubCategoryId;
                pRepCondition.Value = Name;
                pDepartmentCategory.Value = DepartmentCategory;
             
                Open(CONNECTION_STRING);
                SqlParameter[] param = { pAction, pDepartmentSubCategoryId, pRepCondition, pDepartmentCategory };
                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, DepartmentSubCategoryMaster.SP_DepartmentSubCategoryMaster, param);

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
                SqlParameter pAction = new SqlParameter(DepartmentSubCategoryMaster._Action, SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter(DepartmentSubCategoryMaster._StrCondition, SqlDbType.NVarChar);

                pAction.Value = 5;
                PrepCondition.Value = preFixText;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

                Open(CONNECTION_STRING);
                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, DepartmentSubCategoryMaster.SP_DepartmentSubCategoryMaster, oparamcol);

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
                SqlParameter pAction = new SqlParameter(DepartmentSubCategoryMaster._Action, SqlDbType.BigInt);

                pAction.Value = 7;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, DepartmentSubCategoryMaster.SP_DepartmentSubCategoryMaster, pAction);

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

        public DMDepartmentSubCategory()
        {

        }
    }
}