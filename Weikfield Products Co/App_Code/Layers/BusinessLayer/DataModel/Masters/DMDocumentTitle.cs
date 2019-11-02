using DMS.DALSQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DMS.DataModel
{
    public class DMDocumentTitle:Utility.Setting
    {

        public int InsertDocumentTitleMaster(string DocumentTitle,long userId,Int32 DepartmentId, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pCreatedBy = new SqlParameter("@UserId", SqlDbType.BigInt);
                SqlParameter pDocumentTitle = new SqlParameter("@DocumentTitle", SqlDbType.NVarChar);
                SqlParameter pDepartmentId = new SqlParameter("@DepartmentId", SqlDbType.NVarChar);

                pAction.Value = 1;
                pCreatedBy.Value = userId;
                pDocumentTitle.Value = DocumentTitle;
                pDepartmentId.Value=DepartmentId;

                SqlParameter[] param = new SqlParameter[] { pAction, pCreatedBy, pDocumentTitle,pDepartmentId};

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteScalar(_Connection, _Transaction, CommandType.StoredProcedure, "SP_DocumentTitleMaster", param);


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


        public int InsertDocumentSubtitleDetails(string DocumentSubTitle, Int32 DocumentTitleId, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pDocumentSubTitle = new SqlParameter("@DocumentSubTitle", SqlDbType.NVarChar);
                SqlParameter pDocumentTitleId = new SqlParameter("@DocumentTitleId", SqlDbType.NVarChar);

                pAction.Value = 7;

                pDocumentSubTitle.Value = DocumentSubTitle;
                pDocumentTitleId.Value = DocumentTitleId;

                SqlParameter[] param = new SqlParameter[] { pAction, pDocumentSubTitle, pDocumentTitleId };

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, "SP_DocumentTitleMaster", param);


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

        public int DeleteDocumentSubtitleDetails1(Int32 DocumentTitleId, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
              
                SqlParameter pDocumentTitleId = new SqlParameter("@DocumentTitleId", SqlDbType.NVarChar);

                pAction.Value = 9;

               
                pDocumentTitleId.Value = DocumentTitleId;

                SqlParameter[] param = new SqlParameter[] { pAction, pDocumentTitleId };

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, "SP_DocumentTitleMaster", param);


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

        public int UpdateDocumentTitleMaster(string DocumentTitle, long DocumentTitleId, long userId, Int32 DepartmentId, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pId = new SqlParameter("@DocumentTitleId", SqlDbType.BigInt);
                SqlParameter pUpdatedBy = new SqlParameter("@UserId", SqlDbType.BigInt);
                SqlParameter pDocumentTitle = new SqlParameter("@DocumentTitle", SqlDbType.NVarChar);
                SqlParameter pDepartmentId = new SqlParameter("@DepartmentId", SqlDbType.NVarChar);
                pAction.Value = 2;
                pId.Value = DocumentTitleId;
                pUpdatedBy.Value = userId;
                pDocumentTitle.Value = DocumentTitle;
                pDepartmentId.Value = DepartmentId;


                SqlParameter[] param = new SqlParameter[] { pAction, pId, pUpdatedBy, pDocumentTitle,pDepartmentId};

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, "SP_DocumentTitleMaster", param);

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

        public int DeleteDocumentTitleMaster(long DocumentTitleId, long userId, out string StrError)
        {
            int iDelete = 0;
            StrError = string.Empty;

            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pId = new SqlParameter("@DocumentTitleId", SqlDbType.BigInt);
                SqlParameter pDeletedBy = new SqlParameter("@UserId", SqlDbType.BigInt);

                pAction.Value = 3;
                pId.Value = DocumentTitleId;
                pDeletedBy.Value = userId;

                SqlParameter[] param = new SqlParameter[] { pAction, pId, pDeletedBy };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iDelete = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, "SP_DocumentTitleMaster", param);

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

        public DataSet ChkDuplicate(string DocumentTitle, long DocumentTitleId, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pId = new SqlParameter("@DocumentTitleId", SqlDbType.BigInt);
                SqlParameter pName = new SqlParameter("@DocumentTitle", SqlDbType.NVarChar);

                pAction.Value = 4;
                pName.Value = DocumentTitle;
                pId.Value = DocumentTitleId;

                SqlParameter[] param = new SqlParameter[] { pAction, pName, pId };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_DocumentTitleMaster", param);

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
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_DocumentTitleMaster", pAction, PrepCondition);


            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public DataSet GetRocordtoEdit(int Id,out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter PrepCondition = new SqlParameter("@DocumentTitleId", SqlDbType.NVarChar);

                pAction.Value = 8;
                PrepCondition.Value = Id;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_DocumentTitleMaster", pAction, PrepCondition);


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
                Ds = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_DocumentTitleMaster", pAction);
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
                SqlParameter PrepCondition = new SqlParameter("@DocumentTitle", SqlDbType.NVarChar);

                pAction.Value = 5;
                PrepCondition.Value = preFixText;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

                Open(CONNECTION_STRING);
                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, "SP_DocumentTitleMaster", oparamcol);

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

        public DataSet FillDepartment(out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
               

                pAction.Value = 6;
               

                SqlParameter[] oparamcol = new SqlParameter[] { pAction };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_DocumentTitleMaster", pAction);


            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public int UpdateDocumentSubtitleDetails(string DocumentSubTitle, Int32 DocumentTitleId,Int32 DocTitleSubId,Int32 UseCount, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pId = new SqlParameter("@DocumentTitleId", SqlDbType.BigInt);
                SqlParameter pDocumentTitle = new SqlParameter("@DocumentSubTitle", SqlDbType.NVarChar);
                SqlParameter pDocSubId = new SqlParameter("@Id", SqlDbType.BigInt);
                SqlParameter pUsedCount = new SqlParameter("@UsedCount", SqlDbType.BigInt);
                pAction.Value = 10;
                pId.Value = DocumentTitleId;
                pDocumentTitle.Value = DocumentSubTitle;
                pDocSubId.Value = DocTitleSubId;
                pUsedCount.Value = UseCount;


                SqlParameter[] param = new SqlParameter[] { pAction, pId, pDocumentTitle, pDocSubId, pUsedCount };

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, "SP_DocumentTitleMaster", param);

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
        public DMDocumentTitle()
        {
            //
            // TODO: Add constructor logic here
            //
        }



        public int DeleteSubDocument(Int32 Deleted,Int32 Id,int i, out string StrError)
        {
            int iDelete = 0;
            StrError = string.Empty;

            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pId = new SqlParameter("@DocumentTitleId", SqlDbType.BigInt);
                SqlParameter pDeletedBy = new SqlParameter("@Id", SqlDbType.BigInt);

                pAction.Value = 11;
                pId.Value = Deleted;
                pDeletedBy.Value = Id;

                SqlParameter[] param = new SqlParameter[] { pAction, pId, pDeletedBy };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iDelete = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, "SP_DocumentTitleMaster", param);

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
    }
}