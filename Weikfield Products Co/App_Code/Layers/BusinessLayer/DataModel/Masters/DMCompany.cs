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
    public class DMCompany:Utility.Setting
    {
        public int InsertCompanyMaster(ref CompanyMaster Entity_Company, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(CompanyMaster._Action, SqlDbType.BigInt);
              
                SqlParameter pCompany = new SqlParameter(CompanyMaster._Company, SqlDbType.NVarChar);

                SqlParameter pPartyName = new SqlParameter(CompanyMaster._PartyName, SqlDbType.NVarChar);
                
                SqlParameter pAdditionalNotes = new SqlParameter(CompanyMaster._AdditionalNotes, SqlDbType.NVarChar);
                
                SqlParameter pCreatedBy = new SqlParameter(CompanyMaster._UserId, SqlDbType.BigInt);

                pAction.Value = 1;
                pCompany.Value = Entity_Company.Company;

                pPartyName.Value = Entity_Company.PartyName;
              
                pAdditionalNotes.Value = Entity_Company.AdditionalNotes;
              
                pCreatedBy.Value = Entity_Company.UserId;

                SqlParameter[] param = new SqlParameter[] { pAction, pCompany, pPartyName, pAdditionalNotes, pCreatedBy };

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteScalar(_Connection, _Transaction, CommandType.StoredProcedure, "SP_CompanyMaster", param);


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

        public int UpdateCompanyMaster(ref CompanyMaster Entity_Company, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(CompanyMaster._Action, SqlDbType.BigInt);
                SqlParameter pCompanyId = new SqlParameter(CompanyMaster._CompanyId, SqlDbType.BigInt);
                SqlParameter pCompany = new SqlParameter(CompanyMaster._Company, SqlDbType.NVarChar);
                SqlParameter pPartyName = new SqlParameter(CompanyMaster._PartyName, SqlDbType.NVarChar);
                SqlParameter pAdditionalNotes = new SqlParameter(CompanyMaster._AdditionalNotes, SqlDbType.NVarChar);
                
                SqlParameter pCreatedBy = new SqlParameter(CompanyMaster._UserId, SqlDbType.BigInt);

                pAction.Value = 2;
                pCompanyId.Value = Entity_Company.CompanyId;
                pCompany.Value = Entity_Company.Company;

                pPartyName.Value = Entity_Company.PartyName;
                pAdditionalNotes.Value = Entity_Company.AdditionalNotes;
                
                pCreatedBy.Value = Entity_Company.UserId;

                SqlParameter[] param = new SqlParameter[] { pAction, pCompanyId, pCompany, pPartyName, pAdditionalNotes, pCreatedBy };
                              
                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, "SP_CompanyMaster", param);

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

        public int DeleteCompanyMaster(ref CompanyMaster Entity_Company, out string StrError)
        {
            int iDelete = 0;
            StrError = string.Empty;

            try
            {
                SqlParameter pAction = new SqlParameter(CompanyMaster._Action, SqlDbType.BigInt);
                SqlParameter pCompanyId = new SqlParameter(CompanyMaster._CompanyId, SqlDbType.BigInt);
                SqlParameter pDeletedBy = new SqlParameter(CompanyMaster._UserId, SqlDbType.BigInt);

                pAction.Value = 3;
                pCompanyId.Value = Entity_Company.CompanyId;
                pDeletedBy.Value = Entity_Company.UserId;

                SqlParameter[] param = new SqlParameter[] { pAction, pCompanyId, pDeletedBy };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iDelete = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, "SP_CompanyMaster", param);

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

        public DataSet GetCompanyForEdit(int ID, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();

            try
            {
                SqlParameter pAction = new SqlParameter(CompanyMaster._Action, SqlDbType.BigInt);
                SqlParameter pAisleId = new SqlParameter(CompanyMaster._CompanyId, SqlDbType.BigInt);

                pAction.Value = 7;
                pAisleId.Value = ID;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, CompanyMaster.SP_CompanyMaster, pAction, pAisleId);

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

        public DataSet GetPropertType(out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();

            try
            {
                SqlParameter pAction = new SqlParameter(CompanyMaster._Action, SqlDbType.BigInt);
              
                pAction.Value = 17;
               
                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, CompanyMaster.SP_CompanyMaster, pAction);

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
        

        public DataSet ChkDuplicate(string Company, long CompanyId, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pId = new SqlParameter("@CompanyId", SqlDbType.BigInt);
                SqlParameter pName = new SqlParameter("@Company", SqlDbType.NVarChar);

                pAction.Value = 4;
                pName.Value = Company;
                pId.Value = CompanyId;

                SqlParameter[] param = new SqlParameter[] { pAction, pName, pId };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_CompanyMaster", param);

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
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_CompanyMaster", pAction, PrepCondition);


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
                Ds = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_CompanyMaster", pAction);
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
                SqlParameter PrepCondition = new SqlParameter("@Company", SqlDbType.NVarChar);

                pAction.Value = 5;
                PrepCondition.Value = preFixText;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

                Open(CONNECTION_STRING);
                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, "SP_CompanyMaster", oparamcol);

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

        public DataSet GetCompanyType(out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(CompanyMaster._Action, SqlDbType.BigInt);

                pAction.Value = 6;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, CompanyMaster.SP_CompanyMaster, pAction);
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

        public string[] GetSuggestedRecordForParty(string prefixText)
        {
            List<string> SearchList = new List<string>();
            string ListItem = string.Empty;
            try
            {

                // -- For Checking OF Execution of Procedure=========
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter MRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                MAction.Value = 8;
                MRepCondition.Value = prefixText;

                SqlParameter[] oParmCol = new SqlParameter[] { MAction, MRepCondition };
                Open(CONNECTION_STRING);

                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, "SP_CompanyMaster", oParmCol);

                if (dr != null && dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        ListItem = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(dr[1].ToString(), dr[0].ToString());
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

        public int InsertCompanyPartyDtls(ref CompanyMaster Entity_Company, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(CompanyMaster._Action, SqlDbType.BigInt);
                SqlParameter pCompanyId = new SqlParameter(CompanyMaster._CompanyId, SqlDbType.BigInt);
                SqlParameter pCompanyParty = new SqlParameter(CompanyMaster._CompanyType, SqlDbType.NVarChar);
                                                               
                pAction.Value = 9;
                pCompanyId.Value = Entity_Company.CompanyId;
                pCompanyParty.Value = Entity_Company.CompanyType;

                SqlParameter[] param = new SqlParameter[] { pAction, pCompanyId, pCompanyParty };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, "SP_CompanyMaster", param);

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

        public string[] GetSuggestedRecordForDocuments(string prefixText)
        {
            List<string> SearchList = new List<string>();
            string ListItem = string.Empty;
            try
            {

                // -- For Checking OF Execution of Procedure=========
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter MRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                MAction.Value = 42;
                MRepCondition.Value = prefixText;

                SqlParameter[] oParmCol = new SqlParameter[] { MAction, MRepCondition };
                Open(CONNECTION_STRING);

                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, "SP_CompanyMaster", oParmCol);

                if (dr != null && dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        ListItem = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(dr[1].ToString(), dr[0].ToString());
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
        public DMCompany()
        {

        }
    }
}