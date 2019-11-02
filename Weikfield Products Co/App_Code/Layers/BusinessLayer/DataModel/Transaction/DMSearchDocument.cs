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
    public class DMSearchDocument:Utility.Setting
    {
        //public DataSet FillSearchGrid(string NoSel,ref SearchDocument Entity_SearchDocument, out string strError)
        //{
        //    strError = string.Empty;
        //    DataSet Ds = new DataSet();
        //    try
        //    {
        //        SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
             
        //       // SqlParameter pDocumentId = new SqlParameter(FileDocument._DocumentId, SqlDbType.BigInt);
        //        SqlParameter pDateDetails = new SqlParameter(SearchDocument._DateDetails, SqlDbType.NVarChar);
        //        SqlParameter pDocumentNo = new SqlParameter(SearchDocument._DocumentNo, SqlDbType.NVarChar);
        //        SqlParameter pFileName = new SqlParameter(SearchDocument._FileName, SqlDbType.NVarChar);
        //        SqlParameter pFileSubject = new SqlParameter(SearchDocument._FileSubject, SqlDbType.NVarChar);
        //        SqlParameter pDepartmentCategory = new SqlParameter(SearchDocument._DepartmentCategory, SqlDbType.NVarChar);
        //        SqlParameter pDepartmentSubCategory = new SqlParameter(SearchDocument._DepartmentSubCategory, SqlDbType.NVarChar);
        //        SqlParameter pDepartmentSubSubCategory = new SqlParameter(SearchDocument._DepartmentSubSubCategory, SqlDbType.NVarChar);

        //        SqlParameter pPropertyName = new SqlParameter(SearchDocument._PropertyName, SqlDbType.NVarChar);
        //        SqlParameter pParty = new SqlParameter(SearchDocument._Party, SqlDbType.NVarChar);

        //        SqlParameter pFileNo = new SqlParameter(SearchDocument._FileNo, SqlDbType.NVarChar);
        //        SqlParameter pRoom = new SqlParameter(SearchDocument._Room, SqlDbType.NVarChar);
        //        SqlParameter pAisle = new SqlParameter(SearchDocument._Aisle, SqlDbType.NVarChar);
        //        SqlParameter pRowNo = new SqlParameter(SearchDocument._RowNo, SqlDbType.NVarChar);
        //        SqlParameter pCabinetNo = new SqlParameter(SearchDocument._CabinetNo, SqlDbType.NVarChar);
        //        SqlParameter pShelfNo = new SqlParameter(SearchDocument._ShelfNo, SqlDbType.NVarChar);
        //        SqlParameter pStrCondition = new SqlParameter(SearchDocument._StrCondition, SqlDbType.NVarChar);
        //        SqlParameter pStrCondition2 = new SqlParameter(SearchDocument._StrCondition2, SqlDbType.NVarChar);
        //        SqlParameter pNoSel = new SqlParameter("@NoSelection", SqlDbType.NVarChar);


        //        pAction.Value = 16;
        //        pDateDetails.Value = Entity_SearchDocument.DateDetails;
        //        pDocumentNo.Value = Entity_SearchDocument.DocumentNo;
        //        pFileName.Value = Entity_SearchDocument.FileName;
        //        pFileSubject.Value = Entity_SearchDocument.FileSubject;
        //        pDepartmentCategory.Value = Entity_SearchDocument.DepartmentCategory;
        //        pDepartmentSubCategory.Value = Entity_SearchDocument.DepartmentSubCategory;
        //        pDepartmentSubSubCategory.Value = Entity_SearchDocument.DepartmentSubSubCategory;

        //        pPropertyName.Value = Entity_SearchDocument.PropertyName;
        //        pParty.Value = Entity_SearchDocument.Party;
        //        pFileNo.Value = Entity_SearchDocument.FileNo;
        //        pRoom.Value = Entity_SearchDocument.Room;
        //        pAisle.Value = Entity_SearchDocument.Aisle;
        //        pRowNo.Value = Entity_SearchDocument.RowNo;
        //        pCabinetNo.Value = Entity_SearchDocument.CabinetNo;
        //        pShelfNo.Value = Entity_SearchDocument.ShelfNo;
        //        pStrCondition.Value = Entity_SearchDocument.StrCondition;
        //        pNoSel.Value = NoSel;
        //        pStrCondition2.Value = Entity_SearchDocument.StrCondition2;

        //        SqlParameter[] oparamcol = new SqlParameter[] { pAction, pDateDetails, pDocumentNo, pFileName, 
        //            pFileSubject,pParty,pPropertyName, pDepartmentCategory, pDepartmentSubCategory,
        //            pDepartmentSubSubCategory, pFileNo, pRoom, pAisle, pRowNo, pCabinetNo, pShelfNo,
        //            pStrCondition ,pNoSel,pStrCondition2};

        //        Open(CONNECTION_STRING);
        //        Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, FileRegister.SP_FileRegister, oparamcol);
        //    }
        //    catch (Exception ex)
        //    {
        //        strError = ex.Message;
        //    }
        //    finally { Close(); }
        //    return Ds;

        //}

        //public DataSet FillReportGrid_PopUp(string condition, out string strError)
        //{
        //    strError = string.Empty;
        //    DataSet Ds = new DataSet();
        //    try
        //    {
        //        SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
        //        SqlParameter PrepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

        //        pAction.Value = 160;
        //        PrepCondition.Value = condition;

        //        SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

        //        Open(CONNECTION_STRING);
        //        Ds = SQLHelper.GetDataSetDoubleParm(_Connection, _Transaction, CommandType.StoredProcedure, FileDocument.SP_FileDocuments, pAction, PrepCondition);
        //    }
        //    catch (Exception ex)
        //    {
        //        strError = ex.Message;
        //    }
        //    finally { Close(); }
        //    return Ds;

        //}

        //public DataSet FillSearchGrid_GooleLike(string NoSel, ref SearchDocument Entity_SearchDocument,string strCon3, out string strError)
        //{
        //    strError = string.Empty;
        //    DataSet Ds = new DataSet();
        //    try
        //    {
        //        SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);

        //        // SqlParameter pDocumentId = new SqlParameter(FileDocument._DocumentId, SqlDbType.BigInt);
        //        SqlParameter pDateDetails = new SqlParameter(SearchDocument._DateDetails, SqlDbType.NVarChar);
        //        SqlParameter pDocumentNo = new SqlParameter(SearchDocument._DocumentNo, SqlDbType.NVarChar);
        //        SqlParameter pFileName = new SqlParameter(SearchDocument._FileName, SqlDbType.NVarChar);
        //        SqlParameter pFileSubject = new SqlParameter(SearchDocument._FileSubject, SqlDbType.NVarChar);
        //        SqlParameter pDepartmentCategory = new SqlParameter(SearchDocument._DepartmentCategory, SqlDbType.NVarChar);
        //        SqlParameter pDepartmentSubCategory = new SqlParameter(SearchDocument._DepartmentSubCategory, SqlDbType.NVarChar);
        //        SqlParameter pDepartmentSubSubCategory = new SqlParameter(SearchDocument._DepartmentSubSubCategory, SqlDbType.NVarChar);

        //        SqlParameter pPropertyName = new SqlParameter(SearchDocument._PropertyName, SqlDbType.NVarChar);
        //        SqlParameter pParty = new SqlParameter(SearchDocument._Party, SqlDbType.NVarChar);

        //        SqlParameter pFileNo = new SqlParameter(SearchDocument._FileNo, SqlDbType.NVarChar);
        //        SqlParameter pRoom = new SqlParameter(SearchDocument._Room, SqlDbType.NVarChar);
        //        SqlParameter pAisle = new SqlParameter(SearchDocument._Aisle, SqlDbType.NVarChar);
        //        SqlParameter pRowNo = new SqlParameter(SearchDocument._RowNo, SqlDbType.NVarChar);
        //        SqlParameter pCabinetNo = new SqlParameter(SearchDocument._CabinetNo, SqlDbType.NVarChar);
        //        SqlParameter pShelfNo = new SqlParameter(SearchDocument._ShelfNo, SqlDbType.NVarChar);
        //        SqlParameter pStrCondition = new SqlParameter(SearchDocument._StrCondition, SqlDbType.NVarChar);
        //        SqlParameter pStrCondition2 = new SqlParameter(SearchDocument._StrCondition2, SqlDbType.NVarChar);
        //        SqlParameter pStrCondition3 = new SqlParameter("@strCond1", SqlDbType.NVarChar);
        //        SqlParameter pNoSel = new SqlParameter("@NoSelection", SqlDbType.NVarChar);


        //        pAction.Value = 166;
        //        pDateDetails.Value = Entity_SearchDocument.DateDetails;
        //        pDocumentNo.Value = Entity_SearchDocument.DocumentNo;
        //        pFileName.Value = Entity_SearchDocument.FileName;
        //        pFileSubject.Value = Entity_SearchDocument.FileSubject;
        //        pDepartmentCategory.Value = Entity_SearchDocument.DepartmentCategory;
        //        pDepartmentSubCategory.Value = Entity_SearchDocument.DepartmentSubCategory;
        //        pDepartmentSubSubCategory.Value = Entity_SearchDocument.DepartmentSubSubCategory;

        //        pPropertyName.Value = Entity_SearchDocument.PropertyName;
        //        pParty.Value = Entity_SearchDocument.Party;
        //        pFileNo.Value = Entity_SearchDocument.FileNo;
        //        pRoom.Value = Entity_SearchDocument.Room;
        //        pAisle.Value = Entity_SearchDocument.Aisle;
        //        pRowNo.Value = Entity_SearchDocument.RowNo;
        //        pCabinetNo.Value = Entity_SearchDocument.CabinetNo;
        //        pShelfNo.Value = Entity_SearchDocument.ShelfNo;
        //        pStrCondition.Value = Entity_SearchDocument.StrCondition;
        //        pNoSel.Value = NoSel;
        //        pStrCondition2.Value = Entity_SearchDocument.StrCondition2;
        //        pStrCondition3.Value = strCon3;

        //        SqlParameter[] oparamcol = new SqlParameter[] { pAction, pDateDetails, pDocumentNo, pFileName, 
        //            pFileSubject,pParty,pPropertyName, pDepartmentCategory, pDepartmentSubCategory,
        //            pDepartmentSubSubCategory, pFileNo, pRoom, pAisle, pRowNo, pCabinetNo, pShelfNo,
        //            pStrCondition ,pNoSel,pStrCondition2,pStrCondition3};

        //        Open(CONNECTION_STRING);
        //        Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, FileRegister.SP_FileRegister, oparamcol);
        //    }
        //    catch (Exception ex)
        //    {
        //        strError = ex.Message;
        //    }
        //    finally { Close(); }
        //    return Ds;

        //}

        //public string[] GetSuggestedRecordForDocument(string preFixText)
        //{
        //    List<string> SearchList = new List<string>();
        //    string ListItem = string.Empty;

        //    try
        //    {
        //        SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
        //        SqlParameter PrepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

        //        pAction.Value = 1;
        //        PrepCondition.Value = preFixText;

        //        SqlParameter[] oparamcol = new SqlParameter[] { pAction, PrepCondition };

        //        Open(CONNECTION_STRING);
        //        SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, "SP_SearchDocument", oparamcol);

        //        if (dr != null && dr.HasRows == true)
        //        {
        //            while (dr.Read())
        //            {
        //                ListItem = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(dr[0].ToString(),
        //                    dr[1].ToString());

        //                SearchList.Add(ListItem);
        //            }

        //        }
        //        dr.Close();
        //    }

        //    catch (Exception ex)
        //    {
        //        throw ex;

        //    }
        //    finally
        //    {
        //        Close();
        //    }

        //    return SearchList.ToArray();
        //}

        public string[] GetSuggestedRecordForParty(string prefixText)
        {
            List<string> SearchList = new List<string>();
            string ListItem = string.Empty;
            try
            {

                // -- For Checking OF Execution of Procedure=========
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter MRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                MAction.Value = 1;
                MRepCondition.Value = prefixText;

                SqlParameter[] oParmCol = new SqlParameter[] { MAction, MRepCondition };
                Open(CONNECTION_STRING);

                SqlDataReader dr = SQLHelper.ExecuteReader(_Connection, _Transaction, CommandType.StoredProcedure, "SP_SearchDocument", oParmCol);

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


        public DMSearchDocument()
        {

        }

        public DataSet FillDocumentDetails(int DocTitleId,int DocSubId, int FileCEDId, int CompanyId, out string StrError)
        {
            StrError = string.Empty;
            DataSet DS = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter pDocTitleId = new SqlParameter("@DocumentTitleId", SqlDbType.BigInt);
                SqlParameter pFileCEDId = new SqlParameter("@FileCEDId", SqlDbType.BigInt);
                SqlParameter pCompanyId = new SqlParameter("@CompanyId", SqlDbType.BigInt);
                SqlParameter pDocSubId = new SqlParameter("@Id", SqlDbType.BigInt);
              
                pAction.Value = 2;
                pFileCEDId.Value = FileCEDId;
                pDocTitleId.Value = DocTitleId;
                pCompanyId.Value = CompanyId;
                pDocSubId.Value = DocSubId;

                SqlParameter[] oParmCol = new SqlParameter[] { pAction, pFileCEDId, pDocTitleId, pCompanyId, pDocSubId };

                Open(CONNECTION_STRING);

                DS = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_SearchDocument", oParmCol);
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

        public DataSet FillReportGrid(out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {
                SqlParameter pAction = new SqlParameter("@Action", SqlDbType.BigInt);               
                pAction.Value = 1;             

                //SqlParameter[] oparamcol = new SqlParameter[] { pAction };

                Open(CONNECTION_STRING);
                Ds = SQLHelper.GetDataSetSingleParm(_Connection, _Transaction, CommandType.StoredProcedure, "SP_PrintFileIndex", pAction);

            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            finally { Close(); }
            return Ds;

        }

        public DataSet GetDocumentDetails(string SearchT, out string strError)
        {
            strError = string.Empty;
            DataSet Ds = new DataSet();
            try
            {

                // -- For Checking OF Execution of Procedure=========
                SqlParameter MAction = new SqlParameter("@Action", SqlDbType.BigInt);
                SqlParameter MRepCondition = new SqlParameter("@strCond", SqlDbType.NVarChar);

                MAction.Value = 3;
                MRepCondition.Value = SearchT;

                SqlParameter[] oParmCol = new SqlParameter[] { MAction, MRepCondition };
                Open(CONNECTION_STRING);

                Ds = SQLHelper.GetDataSet(_Connection, _Transaction, CommandType.StoredProcedure, "SP_SearchDocument", oParmCol);
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