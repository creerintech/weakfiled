<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu1.ascx.cs" Inherits="Controls_Menu1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<!-- Navigation -->
<link href="../StyleSheet/NewMenuStyle.css" rel="stylesheet" type="text/css" />

<script src="../Jscript/jquery.js" type="text/javascript" />

<script type="text/javascript" src="../Jscript/js.js"></script>

<div id="menu">
    <ul class="menu">
        <li><a href="../Masters/HomeNew.aspx" class="parent"><span>Home</span></a></li>
        <li><a href="#" class="parent"><span>Masters</span></a>
            <ul>
                <%--<li><a href="#">Users</a>
                    <ul>
                     <li><a href="../Masters/EmployeeMaster.aspx">Employee Master</a></li>
                      <li><a href="../Masters/UserMaster.aspx">User Master</a></li>
                      
                    </ul>
                </li>--%>
                  <%--  <li><a href="../Masters/UserMaster.aspx">User Master</a></li>--%>
                     <li><a href="../Masters/EmployeeMaster.aspx">Employee Master</a></li>
                    <li><a href="../Masters/Department.aspx">Department </a></li>
                    <li><a href="../Masters/Document.aspx">Document Title And Sub Title</a></li>
                      <li><a href="../Masters/RoomsMaster.aspx">Room Master</a></li>
                    <li><a href="../Masters/AisleMaster.aspx">Aisle Master</a></li>
                    <%--<li><a href="../Masters/CabinetMaster.aspx">CabinetMaster</a></li>--%>
                    <li><a href="../Masters/ShelfMaster.aspx">Shelf Master</a></li>
                         <li><a href="../Masters/PropertyMaster.aspx">Property Master</a></li>                    
                  <li><a href="../Masters/CompanyMaster.aspx">Company Master</a></li>
            
               
             
               
              <%--   <li><a href="../Masters/RowsMaster.aspx">Rows Master</a></li>--%>
               
               
                <%-- <li><a href="../Masters/FileMaster.aspx">File Master</a></li>--%>
              <%--  <li><a href="../Masters/DocumentTitles.aspx">Document Title</a></li>--%>
                <%-- <li><a href="../Masters/DocumentSubject.aspx">Document Subject</a></li>--%>
               <%--  <li><a href="../Masters/DepartmentCategory.aspx">Category</a></li>
                 <li><a href="../Masters/DepartmentSubCategoryMaster.aspx">Sub Category Master</a></li>
                 <li><a href="../Masters/DepartmentSubSubCatMaster.aspx">Sub Sub Category Master</a></li>
                 <li><a href="../Masters/PartyType.aspx">Party Type Master</a></li>--%>
              

            </ul>
        </li>
        <li><a href="#" class="parent"><span>Transactions</span></a>
            <ul>
              <li><a href="../Transactions/FileCreateEditDelete.aspx">File Create/Edit/Delete</a></li>
               <li><a href="../Transactions/SearchDocumentNew.aspx">Search Your Document</a></li>
               <li><a href="../Transactions/PrintIndex.aspx">Print Index For File</a></li>
              <%--  <li><a href="../Transactions/FileInwordRegister.aspx">File InOut Register</a></li>--%>
                 <li><a href="../Transactions/File Outward Register.aspx">File Outward Register</a></li>
                <li><a href="../Transactions/File Inward Register.aspx">File Inward Register</a></li>
              <%--  <li><a href="../Transactions/FileRegister.aspx">File Register</a></li>--%>
            <%--   <li><a href="../Transactions/FileDocument.aspx">File Your Document</a></li>--%>
                 <%--<li><a href="../Transactions/SearchDocument.aspx">Search Your File</a></li>--%>
               <%-- <li><a href="../Transactions/SearchFiles.aspx">Search Your File New</a></li>--%>

            </ul>
        </li>
        <li><a href="#" class="parent"><span>Reports</span></a>
                <ul>
                 <li><a href="../MIS/CheckAllDocumnentStatus.aspx">Check All Document Status</a></li>
                <li><a href="../MIS/Check Outward Documents.aspx">Check Outward Documents </a></li>
               <li><a href="../MIS/RptListOfFilesAndDocuments.aspx">List Of File and Document</a> </li>
               <%-- <li><a href="../MIS/YearAndTitlesDetails.aspx">Year And Titles Details</a></li>--%>
            </ul>
        </li>
        <li><a href="#" class="parent"><span>Search</span></a>
            <ul>
                
               <%-- <li><a href="../MIS/ProjectTowerFlatList.aspx">List Of Flats</a></li>
                <li><a href="../MIS/AvailabilityChart.aspx">Availability Chart</a></li>--%>
                
            </ul>
        </li>
        <li class="last"><a href="../Masters/ContactUs.aspx"><span>Contact Us</span></a></li>
    </ul>
</div>
