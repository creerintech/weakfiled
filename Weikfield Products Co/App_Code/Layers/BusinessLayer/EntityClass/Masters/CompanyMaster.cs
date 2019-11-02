using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMS.EntityClass
{

    public class CompanyMaster
    {

        #region Constants

        public const string _CompanyId = "@CompanyId";
        public const string _CompanyTypeId = "@CompanyTypeId";
        public const string _Company = "@Company";
        public const string _PartyName = "@PartyName";
        public const string _CompanyAddress = "@CompanyAddress";
        public const string _Phone = "@Phone";
        public const string _Mobile = "@Mobile";
        public const string _CompanyEmailId = "@CompanyEmailId";
        public const string _AdditionalNotes = "@AdditionalNotes";
        public const string _WebSite = "@WebSite";
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
        public static string _CompanyType = "@CompanyType";
        #endregion

        #region Properties

        public Int32 CompanyId { get; set; }
        public Int32 CompanyTypeId { get; set; }
        public string Company { get; set; }
        public string CompanyType { get; set; }
        public string PartyName { get; set; }
        public string CompanyAddress { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string CompanyEmailId { get; set; }
        public string AdditionalNotes { get; set; }
        public string WebSite { get; set; }
        public Int32 CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public Int32 DeletedBy { get; set; }
        public DateTime DeletedOn { get; set; }
        public Int32 UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Int32 UsedCount { get; set; }
        public Int32 Action { get; set; }
        public string StrCondition { get; set; }
        public Int32 UserId { get; set; }
        public DateTime LoginDate { get; set; }

        #endregion


        # region Stored Procedure

        public static string SP_CompanyMaster = "SP_CompanyMaster";

        #endregion

        public CompanyMaster()
        {

        }
    }
}