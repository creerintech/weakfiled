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
    public class DMProperty:Utility.Setting
    {
        public int InsertProperty(ref Property Entity_Party, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(Property._Action, SqlDbType.BigInt);

                SqlParameter pCompanyId = new SqlParameter(Property._CompanyId, SqlDbType.BigInt);
                SqlParameter pPropertyName = new SqlParameter(Property._PropertyName, SqlDbType.NVarChar);
                SqlParameter pPropertyAddress = new SqlParameter(Property._PropertyAddress, SqlDbType.NVarChar);
              
                SqlParameter pCreatedBy = new SqlParameter(Property._UserId, SqlDbType.BigInt);

                pAction.Value = 1;

                pCompanyId.Value = Entity_Party.CompanyId;
                pPropertyName.Value = Entity_Party.PropertyName;
                pPropertyAddress.Value = Entity_Party.PropertyAddress;
                
                pCreatedBy.Value = Entity_Party.UserId;

                SqlParameter[] param = new SqlParameter[] { pAction, pCompanyId, pPropertyName, pPropertyAddress, pCreatedBy };

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteScalar(_Connection, _Transaction, CommandType.StoredProcedure, "SP_PropertyMaster", param);

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

        public int InsertPartyDtls(ref  Property Entity_Property, out string strError)
        {
            int InsertRow = 0;
            strError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(Property._Action, SqlDbType.BigInt);
                SqlParameter pPropertyId = new SqlParameter(Property._PropertyId, SqlDbType.BigInt);
                SqlParameter pCompanyId = new SqlParameter(Property._CompanyId, SqlDbType.BigInt);

                pAction.Value = 11;
                pPropertyId.Value = Entity_Property.PropertyId;
                pCompanyId.Value = Entity_Property.CompanyId;

                SqlParameter[] ParamArray = new SqlParameter[] { pAction, pPropertyId, pCompanyId };
                Open(CONNECTION_STRING);
                BeginTransaction();
                InsertRow = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, Property.SP_PropertyMaster, ParamArray);

                if (InsertRow != 0)
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
                strError = ex.Message;
                RollBackTransaction();
            }
            finally
            {
                Close();
            }
            return InsertRow;

        }

        public int UpdateProperty(ref Property Entity_Party, out string StrError)
        {
            int iInsert = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(Property._Action, SqlDbType.BigInt);
                SqlParameter pPropertyId = new SqlParameter(Property._PropertyId, SqlDbType.BigInt);
                SqlParameter pCompanyId = new SqlParameter(Property._CompanyId, SqlDbType.BigInt);
                SqlParameter pPropertyName = new SqlParameter(Property._PropertyName, SqlDbType.NVarChar);
                SqlParameter pPropertyAddress = new SqlParameter(Property._PropertyAddress, SqlDbType.NVarChar);
             
                SqlParameter pCreatedBy = new SqlParameter(Property._UserId, SqlDbType.BigInt);

     
                pAction.Value = 2;
                pPropertyId.Value = Entity_Party.PropertyId;
                pCompanyId.Value = Entity_Party.CompanyId;
                pPropertyName.Value = Entity_Party.PropertyName;
                pPropertyAddress.Value = Entity_Party.PropertyAddress;
                
                pCreatedBy.Value = Entity_Party.UserId;

                SqlParameter[] param = new SqlParameter[] { pAction, pPropertyId, pCompanyId, pPropertyName, pPropertyAddress, pCreatedBy };

                Open(CONNECTION_STRING);
                BeginTransaction();
                iInsert = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, Property.SP_PropertyMaster, param);

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

        public int DeleteProperty(ref Property Entity_Party, out string StrError)
        {
            int iDelete = 0;
            StrError = string.Empty;

            try
            {
                SqlParameter pAction = new SqlParameter(Property._Action, SqlDbType.BigInt);
                SqlParameter pPropertyId = new SqlParameter(Property._PropertyId, SqlDbType.BigInt);
                SqlParameter pDeletedBy = new SqlParameter(Property._UserId, SqlDbType.BigInt);

                pAction.Value = 3;
                pPropertyId.Value = Entity_Party.PropertyId;
                pDeletedBy.Value = Entity_Party.UserId;

                SqlParameter[] param = new SqlParameter[] { pAction, pPropertyId, pDeletedBy };

                Open(CONNECTION_STRING);
                BeginTransaction();

                iDelete = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, Property.SP_PropertyMaster, param);

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

        public DataSet GetPartyForEdit(int ID, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(Property._Action, SqlDbType.BigInt);
                SqlParameter pPropertyId = new SqlParameter(Property._PropertyId, SqlDbType.BigInt);

                pAction.Value = 7;
                pPropertyId.Value = ID;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, Property.SP_PropertyMaster, pAction, pPropertyId);
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

        public DataSet ChkDuplicate(string PropertyName, long PropertyId, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pPropertyId = new SqlParameter("@PropertyId", SqlDbType.BigInt);
                SqlParameter pPropertyName = new SqlParameter("@PropertyName", SqlDbType.NVarChar);

                pAction.Value = 4;
                pPropertyName.Value = PropertyName;
                pPropertyId.Value = PropertyId;

                SqlParameter[] param = new SqlParameter[] { pAction, pPropertyName, pPropertyId };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, Property.SP_PropertyMaster, param);

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
                Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, Property.SP_PropertyMaster, pAction, PrepCondition);
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
                Ds = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, Property.SP_PropertyMaster, pAction);
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
                SqlParameter PrepCondition = new SqlParameter("@PropertyName", SqlDbType.NVarChar);

                pAction.Value = 5;
                PrepCondition.Value = preFixText;

                SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

                Open(CONNECTION_STRING);
                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, Property.SP_PropertyMaster, oparamcol);

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

        public DataSet GetPartyType(out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(Property._Action, SqlDbType.BigInt);

                pAction.Value = 6;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, Property.SP_PropertyMaster, pAction);
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

        public DataSet GetPartyOnCompany(string CompanyId,out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(Property._Action, SqlDbType.BigInt);
                SqlParameter pPartyId = new SqlParameter("@PartyId1", SqlDbType.NVarChar);
                pAction.Value = 8;
                pPartyId.Value = CompanyId;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, Property.SP_PropertyMaster, pAction,pPartyId);
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

        public DMProperty()
        {

        }

        public DataSet GetPartyTypeOnCompany(string CompanyTypeId, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter(Property._Action, SqlDbType.BigInt);
                SqlParameter pComapnyPartyId1 = new SqlParameter("@ComapnyPartyId1", SqlDbType.NVarChar);
                pAction.Value = 16;
                pComapnyPartyId1.Value = CompanyTypeId;

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, Property.SP_PropertyMaster, pAction, pComapnyPartyId1);
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

        public int InsertPropertyCompanyPartyDtls(ref Property Entity_Property, out string StrError)
        {
            int InsertRow = 0;
            StrError = string.Empty;
            try
            {
                SqlParameter pAction = new SqlParameter(Property._Action, SqlDbType.BigInt);
                SqlParameter pPropertyId = new SqlParameter(Property._PropertyId, SqlDbType.BigInt);
                SqlParameter pCompanyId = new SqlParameter(Property._CompanyId, SqlDbType.BigInt);
                SqlParameter pCompanyTypeId = new SqlParameter(Property._CompanyTypeId, SqlDbType.BigInt);

                pAction.Value = 17;
                pPropertyId.Value = Entity_Property.PropertyId;
                pCompanyId.Value = Entity_Property.CompanyId;
                pCompanyTypeId.Value = Entity_Property.CompanyTypeId;

                SqlParameter[] ParamArray = new SqlParameter[] { pAction, pPropertyId, pCompanyId, pCompanyTypeId };
                Open(CONNECTION_STRING);
                BeginTransaction();
                InsertRow = SQLHelper.ExecuteNonQuery(_Connection, _Transaction, CommandType.StoredProcedure, Property.SP_PropertyMaster, ParamArray);

                if (InsertRow != 0)
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
                StrError = ex.Message;
                RollBackTransaction();
            }
            finally
            {
                Close();
            }
            return InsertRow;
        }
    }
}