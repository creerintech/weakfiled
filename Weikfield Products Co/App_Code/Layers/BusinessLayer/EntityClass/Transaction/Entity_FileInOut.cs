using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace DMS.EntityClass
{
    public class FileInOutReCords
    {
        #region Constants

        public const string _InOutId = "@InOutId";
        public const string _PropertyId = "@PropertyId";
        public const string _InDetailsId = "@InDetailsId";
        public const string _FileCEDId = "@FileCEDId";
        public const string _FileUploadDocId = "@FileUploadDocId";
        public const string _DateDetails = "@DateDetails";
        public const string _DocumentTitleId = "@DocumentTitleId";
        public const string _FileName = "@FileName";
        public const string _FileSubject = "@FileSubject";
        public const string _FileNo = "@FileNo";
        public const string _Barcode = "@Barcode";
        public const string _DocRefNo = "@DocRefNo";
        public const string _EmpID = "@EmpID";
        public const string _FileInDate = "@FileInDate";
        public const string _FileOutDate = "@FileOutDate";
        public const string _Status = "@Status";

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
        public static string _UserGivenToId="@UserGivenToId";
        public static string _UserGivenById="@UserGivenById";
        public static string _InwardDate="@InwardDate";
        public static string _OutwardDate="@OutwardDate";
        public static string _InwardTime = "@InwardTime";
        public static string _OutWardTime = "@OutWardTime";
        public static string _InwardStatus = "@InwardStatus";
        public static string _OutWardStatus = "@OutWardStatus";
        public static string _InID = "@InID";
        #endregion

        #region Properties

        public Int32 InOutId { get; set; }
        public Int32 InID { get; set; }
        public Int32 PropertyId { get; set; }
        public Int32 InDetailsId { get; set; }
        public Int32 FileCEDId { get; set; }
        public Int32 FileUploadDocId { get; set; }
        public string DateDetails { get; set; }
        public Int32 DocumentTitleId { get; set; }
        public string FileName { get; set; }
        public string FileSubject { get; set; }
        public string FileNo { get; set; }
        public string Barcode { get; set; }
        public string DocRefNo { get; set; }
        public Int32 EmpID { get; set; }
        public DateTime FileOutDate { get; set; }
        public DateTime FileInDate { get; set; }
        public string Status { get; set; }
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

        public Int32 UserGivenToId { get; set; }
        public Int32 UserGivenById  { get; set; }
        public DateTime InwardDate { get; set; }
        public DateTime OutwardDate { get; set; }
        public string InwardTime { get; set; }
        public string OutWardTime { get; set; }
        public string InwardStatus { get; set; }
        public string OutWardStatus { get; set; }
        #endregion

        # region Stored Procedure
        public static string SP_FileRegister = "SP_FileInOutOpration";
        #endregion

        public FileInOutReCords()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}