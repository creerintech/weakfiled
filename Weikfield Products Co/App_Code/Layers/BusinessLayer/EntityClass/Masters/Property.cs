using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMS.EntityClass
{
    public class Property
    {
        #region Constants

        public const string _PropertyId = "@PropertyId";
        public const string _CompanyId = "@CompanyId";
        public const string _PropertyName = "@PropertyName";
        public const string _PropertyAddress = "@PropertyAddress";
        public const string _PropertyDesc = "@PropertyDesc";
        public const string _CreatedBy = "@CreatedBy";
        public const string _CreatedOn = "@CreatedOn";
        public const string _IsDeleted = "@IsDeleted";
        public const string _DeletedBy = "@DeletedBy";
        public const string _DeletedOn = "@DeletedOn";
        public const string _UpdatedBy = "@UpdatedBy";
        public const string _UpdatedOn = "@UpdatedOn";
        public const string _UsedCount = "@UsedCount";
        public static string _Action = "@Action";
        public static string _StrCondition = "@StrCond";
        public static string _UserId = "@UserId";
        public static string _LoginDate = "@LoginDate";
        public static string _CompanyTypeId = "@CompanyTypeId";
        #endregion

        #region Properties

        public Int32 Action { get; set; }
        public Int32 CompanyId { get; set; }
        public Int32 PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyAddress { get; set; }
        public string PropertyDesc { get; set; }
        public Int32 CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public Int32 DeletedBy { get; set; }
        public DateTime DeletedOn { get; set; }
        public Int32 UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Int32 UsedCount { get; set; }
        public string StrCondition { get; set; }
        public Int32 UserId { get; set; }
        public DateTime LoginDate { get; set; }
        public Int32 CompanyTypeId { get; set; }
        #endregion


        # region Stored Procedure

        public static string SP_PropertyMaster = "SP_PropertyMaster";

        #endregion

        public Property()
        {
           
        }
    }
}