using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMS.EntityClass
{

    public class DepartmentSubCategoryMaster
    {
        #region Column Constant
        public static string _Action = "@Action";
        public static string _DepartmentSubCategoryId = "@DepartmentSubCategoryId";

        public static string _DepartmentCategoryId = "@DepartmentCategoryId";

        public static string _DepartmentSubCategory = "@DepartmentSubCategory";

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

        private Int32 m_DepartmentSubCategoryId;

        public Int32 DepartmentSubCategoryId
        {
            get { return m_DepartmentSubCategoryId; }
            set { m_DepartmentSubCategoryId = value; }
        }

        private string m_DepartmentSubCategory;

        public string DepartmentSubCategory
        {
            get { return m_DepartmentSubCategory; }
            set { m_DepartmentSubCategory = value; }
        }
        //DepartmentCategoryId
        private Int32 m_DepartmentCategoryId;
        public Int32 DepartmentCategoryId
        {
            get { return m_DepartmentCategoryId; }
            set { m_DepartmentCategoryId = value; }
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
        public static string SP_DepartmentSubCategoryMaster = "SP_DepartmentSubCategoryMaster";
        #endregion

        public DepartmentSubCategoryMaster()
        {

        }
    }
}