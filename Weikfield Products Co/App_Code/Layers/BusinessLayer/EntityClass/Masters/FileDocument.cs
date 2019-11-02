using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMS.EntityClass
{
    public class FileDocument
    {

        #region Constants

            public const string _DocumentId = "@DocumentId";
            public const string _DateDetails = "@DateDetails";
            public const string _DocumentNo = "@DocumentNo";
            public const string _DocumentTitleId = "@DocumentTitleId";
            public const string _DocumentSubjectId = "@DocumentSubjectId";
            public const string _DepartmentCategoryId = "@DepartmentCategoryId";
            public const string _DepartmentSubCategoryId = "@DepartmentSubCategoryId";
            public const string _DepartmentSubSubCategoryId = "@DepartmentSubSubCategoryId";
            public const string _PartyId = "@PartyId";
            public const string _PropertyId = "@PropertyId";
            public const string _FileId = "@FileId";
            public const string _Status = "@Status";
            public const string _RowId = "@RowId";
            
            public const string _AdditionalNotes = "@AdditionalNotes";

            public const string _FileUploadPath = "@FileUploadPath";

            public const string _CreatedBy = "@CreatedBy";
            public const string _CreatedDate = "@CreatedDate";
            public const string _IsDeleted = "@IsDeleted";
            public const string _DeletedBy = "@DeletedBy";
            public const string _DeletedDate = "@DeletedDate";
            public const string _UpdatedBy = "@UpdatedBy";
            public const string _UpdatedDate = "@UpdatedDate";
            public const string _UsedCount = "@UsedCount";
            public const string _RoomId = "@RoomId";
            public const string _AisleId = "@AisleId";
            public const string _CabinetId = "@CabinetId";
            public const string _ShelfId = "@ShelfId";
            public static string _Action = "@Action";
            public static string _StrCondition = "@StrCond";
            public static string _UserId = "@UserId";
            public static string _LoginDate = "@LoginDate";
            public static string _Id = "@Id";
            public static string _FileCEDId = "@FileCEDId";
            public static string _FileNo = "@FileNo";
            public static string _DocRefNo = "@DocRefNo";
            public static string _DocDate = "@DocDate";
            public static string _DocExpiryDate = "@DocExpiryDate";
            public static string _RenewAfterDate = "@RenewAfterDate";
            public static string _Narration = "@Narration";
            public static string _DocImagePath = "@DocImagePath";
            public static string _FileUploadDocId = "@FileUploadDocId";
            public static string _CompanyId = "@CompanyId";
            public static string _Barcode = "@Barcode";
            public static string _FileName = "@FileName";
            public static string _DayId = "@DayId";
            public static string _MonthId = "@MonthId";
            public static string _YearId = "@YearId";
         #endregion

         #region Properties
            public string DocImagePath { get; set;}
            public string Status { get; set; }
            public Int32 FileUploadDocId {get;set;}
            public Int32 DayId { get; set; }
            public Int32 YearId { get; set; }
            public Int32 MonthId { get; set; } 
            public Int32 DocumentId {get;set;}
            public string DateDetails {get;set;}
            public string DocumentNo {get;set;}
            public Int32 DocumentTitleId {get;set;}
            public Int32 DocumentSubjectId {get;set;}
            public Int32 DepartmentCategoryId {get;set;}
            public Int32 DepartmentSubCategoryId {get;set;}
            public Int32 DepartmentSubSubCategoryId {get;set;}
            public Int32 PartyId {get;set;}
            public Int32 PropertyId {get;set;}
            public Int32 FileId {get;set;}
            public Int32 RoomId {get;set;}
            public Int32 AisleId {get;set;}
            public Int32 RowId {get;set;}
            public Int32 CabinetId {get;set;}
            public Int32 ShelfId {get;set;}
            public string AdditionalNotes {get;set;}
            public string FileUploadPath {get;set;}
            public Int32 CreatedBy {get;set;}
            public DateTime CreatedDate {get;set;}
            public bool IsDeleted {get;set;}
            public Int32 DeletedBy {get;set;}
            public DateTime DeletedDate {get;set;}
            public Int32 UpdatedBy {get;set;}
            public DateTime UpdatedDate {get;set;}
            public Int32 UsedCount {get;set;}
            public Int32 CompanyId { get; set; }
            public Int32 Action { get; set; }
            public string StrCondition { get; set; }
            public Int32 UserId { get; set; }
            public DateTime LoginDate { get; set; }
            public Int32 Id { get; set; }
            public Int32 FileCEDId  { get; set; }
            public string FileNo { get; set; }
            public string DocRefNo { get; set; }
            public DateTime DocDate  { get; set; }
            public DateTime DocExpiryDate { get; set; }
            public DateTime RenewAfterDate { get; set; }
            public string Narration { get; set; }
            public string Barcode { get; set; }
            public string FileName { get; set; }
        #endregion

        # region Stored Procedure
                 public static string SP_FileDocuments = "SP_FileDocuments";
        #endregion

        public FileDocument()
        {
          
        }
    }
}