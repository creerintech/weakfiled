using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class FileRegister
{

    #region Constants

        public const string _FileRegisterId = "@FileRegisterId";
        public const string _DateDetails = "@DateDetails";
        public const string _DocumentNo = "@DocumentNo";
        public const string _FileName = "@FileName";
        public const string _FileSubject = "@FileSubject";
        public const string _DepartmentCategoryId = "@DepartmentCategoryId";
        public const string _DepartmentSubCategoryId = "@DepartmentSubCategoryId";
        public const string _DepartmentSubSubCategoryId = "@DepartmentSubSubCategoryId";
        public const string _FileNo = "@FileNo";
        public const string _RoomId = "@RoomId";
        public const string _AisleId = "@AisleId";
        public const string _RowId = "@RowId";
        public const string _CabinetId = "@CabinetId";
        public const string _ShelfId = "@ShelfId";

        public const string _PartyId = "@PartyId";
        public const string _PropertyId = "@PropertyId";

        public const string _AdditionalNotes = "@AdditionalNotes";     
        public const string _CreatedBy = "@CreatedBy";
        public const string _CreatedDate = "@CreatedDate";
        public const string _IsDeleted = "@IsDeleted";
        public const string _DeletedBy = "@DeletedBy";
        public const string _DeletedDate = "@DeletedDate";
        public const string _UpdatedBy = "@UpdatedBy";
        public const string _UpdatedDate = "@UpdatedDate";
        public const string _UsedCount = "@UsedCount";

        public static string _Action = "@Action";
        public static string _StrCondition = "@StrCond";
        public static string _UserId = "@UserId";
        public static string _LoginDate = "@LoginDate";

#endregion


        #region Properties

        public Int32 FileRegisterId { get; set; }
        public string DateDetails { get; set; }
        public string DocumentNo { get; set; }
        public string FileName { get; set; }
        public string FileSubject { get; set; }
        public Int32 DepartmentCategoryId { get; set; }
        public Int32 DepartmentSubCategoryId { get; set; }
        public Int32 DepartmentSubSubCategoryId { get; set; }
        public string FileNo { get; set; }
        public Int32 RoomId { get; set; }
        public Int32 AisleId { get; set; }
        public Int32 RowId { get; set; }
        public Int32 CabinetId { get; set; }
        public Int32 ShelfId { get; set; }
        
        public Int32 PartyId { get; set; }
        public Int32 PropertyId { get; set; }
        
        public string AdditionalNotes { get; set; }
        public string FileUploadPath { get; set; }
        public Int32 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public Int32 DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }
        public Int32 UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Int32 UsedCount { get; set; }

        public Int32 Action { get; set; }
        public string StrCondition { get; set; }
        public Int32 UserId { get; set; }
        public DateTime LoginDate { get; set; }    

        #endregion

        # region Stored Procedure
        public static string SP_FileRegister = "SP_FileRegister";
        #endregion



	public FileRegister()
	{
		
	}
}