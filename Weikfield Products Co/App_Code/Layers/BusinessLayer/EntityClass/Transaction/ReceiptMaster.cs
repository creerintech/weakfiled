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
    public class ReceiptMaster
    {
        #region[constants]
        public static string _Action = "@Action";
        public static string _ReceiptId = "@RcptId";
        public static string _ReceiptNo = "@ReceiptNo";
        public static string _ReceiptDate = "@ReceiptDate";
        public static string _VoucherNo = "@VoucherNo";
        public static string _PCId = "@PCId";
        public static string _BookingId = "@BookingId";
        
        public static string _BuildingNo = "@BuildingNo";
        public static string _FlatNo = "@FlatNo";    
        public static string _PayModeType = "@PayModeType";
        public static string _NetAmount = "@NetAmount";
        public static string _Amount = "@Amount";
        public static string _PayModeFlag = "@PayModeFlag";
        public static string _ReceiptDtlsId = "@ReceiptDtlsId";
        public static string _AccountTypeId = "@AccountTypeId";
        public static string _PSDtlId = "@PSDtlId";
        public static string _TaxdtlId = "@TaxdtlId";
        public static string _ChargeId = "@ChargeId";
        public static string _ReceiptFor = "@ReceiptFor";
        public static string _PayModeTypeId = "@PayModeTypeId";
        public static string _ChequeDDNO = "@ChequeDDNO";
        public static string _ChequeDDDate = "@ChequeDDDate";
        
       
        public static string _UserId = "@UserId";
        public static string _LoginDate = "@LoginDate";
        public static string _IsDeleted = "@IsDeleted";
        public static string _StrCondition = "@StrCond";

        public static string _PCMLedgerID = "@PCMLedgerID";
        public static string _BMLedgerID = "@BMLedgerID";
        public static string _VoucherId = "@VoucherId";
        public static string _VoucherType = "@VoucherType";
        public static string _CustId = "@CustId";
        public static string _VoucherDebit = "@VoucherDebit";
        public static string _VoucherCredit = "@VoucherCredit";
        public static string _VoucherAmount = "@VoucherAmount";
        public static string _TransId = "@TransId";
        public static string _EmpID = "@EmpID";

        public static string _DifferenceAmt = "@DifferenceAmt";

        public static string _STReceiptAmt = "@STReceiptAmt";
        public static string _BounceDate = "@BounceDate";
        public static string _BounceReason= "@BounceReason";
       
        public static string _DraweeBankId = "@BankId";
        public static string _BankName = "@BankName";
        public static string _BankId = "@BankId";
        public static string _BranchName = "@BranchName";

        public static string _DepositionBankId = "@DepostionBankId";
        public static string _NewBranchId = "@NewDraweeBranchId";
        public static string _RTGSTranNo = "@RTGSTranNo";
        public static string _Remarks = "@Remarks";  
      
        //RcptDtlsId	bigint	Unchecked
//ReceiptId	bigint	Unchecked
//CollectedOn	varchar(1)	Checked
//Booking_ChargeDtlsId	bigint	Checked
//Booking_TaxDtlsId	bigint	Checked
//BookingPaymentScheduleId	bigint	Checked
//StageId	bigint	Checked
//ChargeId	bigint	Checked
//TaxDtlId	bigint	Checked
//PaymentMode	varchar(1)	Checked
//RcptAmount	decimal(18, 2)	Checked

        //manish 8-4-2014
        public string RTGSTranNo { get; set; }
        public string Remarks { get; set; }
        public int DepositionBankId { get; set; }
        public int NewDraweeBranchId { get; set; }

        public string DraweeBankBranchName { get; set; }
        public int DraweeBankId { get; set; }
        public static string _CollectedOn = "@CollectedOn";
        public static string _RcptAmount = "@RcptAmount";
        public static string _Booking_ChargeDtlsId = "@Booking_ChargeDtlsId";
        public static string _Booking_TaxDtlsId = "@Booking_TaxDtlsId";
        public static string _BookingPaymentScheduleId = "@BookingPaymentScheduleId";
        public static string _StageId = "@StageId";
        //public static string _ChargeId = "@ChargeId";
        public static string _TaxDtlId = "@TaxDtlId";
        public static string _PaymentMode = "@PaymentMode";
        public static string _Narration = "@Narration";


        public static string _Tower = "@Tower";

        #endregion

        #region[Defination]
       
        private string m_Tower;
        public string ChequeBounceDate { get; set; }
        public string BounceReason { get; set; }

        public string Tower
        {
            get { return m_Tower; }
            set { m_Tower = value; }
        }


        private decimal m_STReceiptAmt;

        public decimal STReceiptAmt
        {
            get { return m_STReceiptAmt; }
            set { m_STReceiptAmt = value; }
        }


        private decimal m_DifferenceAmt;
         public decimal DifferenceAmt
        {
            get { return m_DifferenceAmt; }
            set { m_DifferenceAmt = value; }
        }

        private string m_Narration;

        public string Narration
        {
            get { return m_Narration; }
            set { m_Narration = value; }
        }


        private char m_PaymentMode;

        public char PaymentMode
        {
            get { return m_PaymentMode; }
            set { m_PaymentMode = value; }
        }

        private char m_CollectedOn;

        public char CollectedOn
        {
            get { return m_CollectedOn; }
            set { m_CollectedOn = value; }
        }

        private Int32 m_Booking_TaxDtlsId;

        public Int32 Booking_TaxDtlsId
        {
            get { return m_Booking_TaxDtlsId; }
            set { m_Booking_TaxDtlsId = value; }
        }
        private Int32 m_BookingPaymentScheduleId;

        public Int32 BookingPaymentScheduleId
        {
            get { return m_BookingPaymentScheduleId; }
            set { m_BookingPaymentScheduleId = value; }
        }
        private Int32 m_StageId;

        public Int32 StageId
        {
            get { return m_StageId; }
            set { m_StageId = value; }
        }



        private Int32 m_TaxDtlId;

        public Int32 TaxDtlId
        {
            get { return m_TaxDtlId; }
            set { m_TaxDtlId = value; }
        }


        private decimal m_RcptAmount;

        public decimal RcptAmount
        {
            get { return m_RcptAmount; }
            set { m_RcptAmount = value; }
        }



        private Int32 m_Booking_ChargeDtlsId;

        public Int32 Booking_ChargeDtlsId
        {
            get { return m_Booking_ChargeDtlsId; }
            set { m_Booking_ChargeDtlsId = value; }
        }


        private Int32 m_Action;
        public Int32 Action
        {
            get { return m_Action; }
            set { m_Action = value; }
        }

        private Int32 m_EmpID;

        public Int32 EmpID
        {
            get { return m_EmpID; }
            set { m_EmpID = value; }
        }

        private Int32 m_ReceiptId;

        public Int32 ReceiptId
        {
            get { return m_ReceiptId; }
            set { m_ReceiptId = value; }
        }

        private string m_ReceiptNo;

        public string ReceiptNo
        {
            get { return m_ReceiptNo; }
            set { m_ReceiptNo = value; }
        }

        private DateTime m_ReceiptDate;

        public DateTime ReceiptDate
        {
            get { return m_ReceiptDate; }
            set { m_ReceiptDate = value; }
        }

        private string m_VoucherNo;

        public string VoucherNo
        {
              get { return m_VoucherNo; }
              set { m_VoucherNo = value; }
        }

        private Int32 m_PCId;

        public Int32 PCId
        {
            get { return m_PCId; }
            set { m_PCId = value; }
        }

        private Int32 m_BookingId;
        public Int32 BookingId
        {
            get { return m_BookingId; }
            set { m_BookingId = value; }
        }

        private Int32 m_PSDtlId;

        public Int32 PSDtlId
        {
            get { return m_PSDtlId; }
            set { m_PSDtlId = value; }
        }

        
        private string m_BuildingNo;

        public string BuildingNo
        {
            get { return m_BuildingNo; }
            set { m_BuildingNo = value; }
        }

        private string m_FlatNo;

        public string FlatNo
        {
            get { return m_FlatNo; }
            set { m_FlatNo = value; }
        }

        private Int32 m_ReceiptDtlsId;

        public Int32 ReceiptDtlsId
        {
            get { return m_ReceiptDtlsId; }
            set { m_ReceiptDtlsId = value; }
        }

        private Int32 m_PayModeTypeId;

        public Int32 PayModeTypeId
        {
            get { return m_PayModeTypeId; }
            set { m_PayModeTypeId = value; }
        }
        private Int32 m_AccountTypeId;

        public Int32 AccountTypeId
        {
            get { return m_AccountTypeId; }
            set { m_AccountTypeId = value; }
        }

        private Int32 m_TaxdtlId;

        public Int32 TaxdtlId
        {
            get { return m_TaxdtlId; }
            set { m_TaxdtlId = value; }
        }

        private Int32 m_ChargeId;

        public Int32 ChargeId
        {
            get { return m_ChargeId; }
            set { m_ChargeId = value; }
        }
        private string m_ReceiptFor;

        public string ReceiptFor
        {
            get { return m_ReceiptFor; }
            set { m_ReceiptFor = value; }
        }

        

        private string m_ChequeDDNO;

        private decimal m_Amount;

        public decimal Amount
        {
            get { return m_Amount; }
            set { m_Amount = value; }
        }

        private decimal m_NetAmount;

        public decimal NetAmount
        {
            get { return m_NetAmount; }
            set { m_NetAmount = value; }
        }

        public string ChequeDDNO
        {
            get { return m_ChequeDDNO; }
            set { m_ChequeDDNO = value; }
        }
        private DateTime m_ChequeDDDate;

        public DateTime ChequeDDDate
        {
            get { return m_ChequeDDDate; }
            set { m_ChequeDDDate = value; }
        }
        private Int32 m_BankId;

        public Int32 BankId
        {
            get { return m_BankId; }
            set { m_BankId = value; }
        }
        private string m_BranchName;

        public string BranchName
        {
            get { return m_BranchName; }
            set { m_BranchName = value; }
        }

        private string m_BankName;

        public string BankName
        {
            get { return m_BankName; }
            set { m_BankName = value; }
        }
        private Boolean m_PayModeFlag;

        public Boolean PayModeFlag
        {
            get { return m_PayModeFlag; }
            set { m_PayModeFlag = value; }
        }
        private Int32 m_UserId;
        public Int32 UserId
        {
            get { return m_UserId; }
            set { m_UserId = value; }
        }

        private DateTime m_LoginDate;
        public string UpdatedOn { get; set; }

        public DateTime LoginDate
        {
            get { return m_LoginDate; }
            set { m_LoginDate = value; }
        }

        private bool m_IsDeleted;

        public bool IsDeleted
        {
            get { return m_IsDeleted; }
            set { m_IsDeleted = value; }
        }

        private string m_StrCondition;

        public string StrCondition
        {
            get { return m_StrCondition; }
            set { m_StrCondition = value; }
        }


        private Int32 m_PCMLedgerID;

        public Int32 PCMLedgerID
        {
            get { return m_PCMLedgerID; }
            set { m_PCMLedgerID = value; }
        }
        private Int32 m_BMLedgerID;

        public Int32 BMLedgerID
        {
            get { return m_BMLedgerID; }
            set { m_BMLedgerID = value; }
        }

        private char m_VoucherType;

        public char VoucherType
        {
            get { return m_VoucherType; }
            set { m_VoucherType = value; }
        }
        private DateTime m_VoucherDate;

        public DateTime VoucherDate
        {
            get { return m_VoucherDate; }
            set { m_VoucherDate = value; }
        }
        private Int32 m_CustId;

        public Int32 CustId
        {
            get { return m_CustId; }
            set { m_CustId = value; }
        }
        private Int32 m_VoucherDebit;

        public Int32 VoucherDebit
        {
            get { return m_VoucherDebit; }
            set { m_VoucherDebit = value; }
        }
        private Int32 m_VoucherCredit;

        public Int32 VoucherCredit
        {
            get { return m_VoucherCredit; }
            set { m_VoucherCredit = value; }
        }
        private decimal m_VoucherAmount;

        public decimal VoucherAmount
        {
            get { return m_VoucherAmount; }
            set { m_VoucherAmount = value; }
        }
        private Int32 m_TransId;

        public Int32 TransId
        {
            get { return m_TransId; }
            set { m_TransId = value; }
        }
        private string m_DraweeBankName;

        public string DraweeBankName
        {
            get { return m_DraweeBankName; }
            set { m_DraweeBankName = value; }
        }
       
   
        #endregion

        #region[procedure]
        public static string SP_ReceiptMaster_Part2 = "SP_ReceiptMasterNew_Part2";
        public static string SP_ReceiptMaster_Part1 = "SP_ReceiptMasterNew_Part1";
        public static string SP_Print="SP_Print";
        #endregion
        public ReceiptMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
