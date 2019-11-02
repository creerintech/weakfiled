using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMS.EntityClass
{
    public class Rows
    {

        #region Constants

        public static string _Action = "@Action";
        public const string _RowId = "@RowId";
        public const string _AisleId = "@AisleId";
        public const string _RoomId = "@RoomId";
        public const string _RowNo = "@RowNo";
        public const string _CreatedBy = "@CreatedBy";
        public const string _CreatedDate = "@CreatedDate";
        public const string _IsDeleted = "@IsDeleted";
        public const string _DeletedBy = "@DeletedBy";
        public const string _DeletedDate = "@DeletedDate";
        public const string _UpdatedBy = "@UpdatedBy";
        public const string _UpdatedDate = "@UpdatedDate";
        public const string _UsedCount = "@UsedCount";
        public static string _StrCondition = "@StrCond";
        public static string _UserId = "@UserId";
        public static string _LoginDate = "@LoginDate";

        #endregion

        #region Properties

        public Int32 Action { get; set; }
        public Int32 RowId { get; set; }
        public Int32 AisleId { get; set; }
        public Int32 RoomId { get; set; }
        public string RowNo { get; set; }
        public Int32 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public Int32 DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }
        public Int32 UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Int32 UsedCount { get; set; }
        public string StrCondition { get; set; }
        public Int32 UserId { get; set; }
        public DateTime LoginDate { get; set; }

        #endregion

        # region Stored Procedure
        public static string SP_RowMaster = "SP_RowMaster";
        #endregion

        public Rows()
        {
           
        }
    }
}