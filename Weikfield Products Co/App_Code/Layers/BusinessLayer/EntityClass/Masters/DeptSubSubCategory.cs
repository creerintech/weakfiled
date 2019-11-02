using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace DMS.EntityClass
{
    public class DeptSubSubCategory
    {
        #region Constants

            public const string _DepartmentSubSubCategoryId = "@DepartmentSubSubCategoryId";
            public const string _DepartmentSubCategoryId = "@DepartmentSubCategoryId";
            public const string _DepartmentCategoryId = "@DepartmentCategoryId";
            public const string _DepartmentSubSubCategory = "@DepartmentSubSubCategory";
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

            public Int32 DepartmentSubSubCategoryId { get; set; }
            public Int32 DepartmentSubCategoryId { get; set; }
            public Int32 DepartmentCategoryId { get; set; }
            public string DepartmentSubSubCategory { get; set; }
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

            public static string SP_DepartmentSubSubCategory = "SP_DepartmentSubSubCategory";

            #endregion

        public DeptSubSubCategory()
        {

        }
    }
}