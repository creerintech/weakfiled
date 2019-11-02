using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMS.EntityClass
{
    public class AisleMaster
    {
        #region Column Constant
        public static string _Action = "@Action";
        public static string _AisleId = "@AisleId";

        public static string _RoomId = "@RoomId";

        public static string _Aisle = "@Aisle";

        public static string _UserId = "@UserId";
        public static string _LoginDate = "@LoginDate";
        public static string _IsDeleted = "@IsDeleted";
        public static string _StrCondition = "@StrCond";
        #endregion

        #region Definitions
        private Int32 m_Action;
        public Int32 Action
        {
            get { return m_Action; }
            set { m_Action = value; }
        }

        private Int32 m_AisleId;

        public Int32 AisleId
        {
            get { return m_AisleId; }
            set { m_AisleId = value; }
        }

        private string m_Aisle;

        public string Aisle
        {
            get { return m_Aisle; }
            set { m_Aisle = value; }
        }
        //RoomId
        private Int32 m_RoomId;
        public Int32 RoomId
        {
            get { return m_RoomId; }
            set { m_RoomId = value; }
        }


        private Int32 m_UserId;
        public Int32 UserId
        {
            get { return m_UserId; }
            set { m_UserId = value; }
        }

        private DateTime m_LoginDate;

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
        #endregion

        # region Stored Procedure
        public static string SP_AisleMaster = "SP_AisleMaster";
        #endregion


        public AisleMaster()
        {

        }
    }
}