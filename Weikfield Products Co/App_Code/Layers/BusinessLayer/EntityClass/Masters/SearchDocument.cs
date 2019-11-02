using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class SearchDocument
{

    public const string _DocumentId = "@DocumentId";
    public const string _DateDetails = "@DateDetails";
    public const string _DocumentNo = "@DocumentNo";
    public const string _FileName = "@FileName";
    public const string _FileSubject = "@FileSubject";
    public const string _DepartmentCategory = "@DepartmentCategory";
    public const string _DepartmentSubCategory = "@DepartmentSubCategory";
    public const string _DepartmentSubSubCategory = "@DepartmentSubSubCategory";
    public const string _Party = "@Party";
    public const string _PartyId = "@PartyId";
    
    public const string _PropertyName = "@PropertyName";
    public const string _FileNo = "@FileNo";
    public const string _Room = "@Room";
    public const string _Aisle = "@Aisle";
    public const string _RowNo = "@RowNo";
    public const string _CabinetNo = "@CabinetNo";
    public const string _ShelfNo = "@ShelfNo";
    public static string _StrCondition = "@StrCond";
    public static string _StrCondition2 = "@StrCond2";

    #region Properties

    public Int32 DocumentId { get; set; }
    public string DateDetails { get; set; }
    public string DocumentNo { get; set; }
    public string FileName { get; set; }
    public string FileSubject { get; set; }
    public string DepartmentCategory { get; set; }
    public string DepartmentSubCategory { get; set; }
    public string DepartmentSubSubCategory { get; set; }
    public string Party { get; set; }
    public string PropertyName { get; set; }
    public string FileNo { get; set; }
    public string Room { get; set; }
    public string Aisle { get; set; }
    public string RowNo { get; set; }
    public string CabinetNo { get; set; }
    public string ShelfNo { get; set; }
    public string StrCondition { get; set; }
    public string StrCondition2 { get; set; }
   
    #endregion

    # region Stored Procedure
    public static string SP_FileDocuments = "SP_FileDocuments";
    #endregion


	public SearchDocument()
	{
		
	}
}