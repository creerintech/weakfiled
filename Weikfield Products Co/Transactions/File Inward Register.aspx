<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true"
    CodeFile="File Inward Register.aspx.cs" Inherits="Transactions_File_Inward_Register" Title="File Inward Register"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SearchContent" runat="Server">
    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
    <input type="hidden" id="hiddenbox" runat="server" value="" />

    <script type="text/javascript" language="javascript">
        function OnEmployeeSelected(source, eventArgs) {

            var hdnValueID = "<%= hdnValue.ClientID %>";

            document.getElementById(hdnValueID).value = eventArgs.get_value();
          
        }
    </script>

    <script type="text/javascript" language="javascript">
        function OnContactSelected(source, eventArgs) {

            var hdnValueID = "<%= hdnValueFileNo.ClientID %>";

            document.getElementById(hdnValueID).value = eventArgs.get_value();
          
        }
    </script>

    <script type="text/javascript" language="javascript">
        function OnSerchProjSelected(source, eventArgs) {

            var hdnValueID = "<%= hdvSerchProj.ClientID %>";

            document.getElementById(hdnValueID).value = eventArgs.get_value();
          
        }
    </script>

    <script type="text/javascript" language="javascript">
        function OnSerchCompany(source, eventArgs) {

            var hdnValueID = "<%= hdvSerchCompany.ClientID %>";

            document.getElementById(hdnValueID).value = eventArgs.get_value();
          
        }
    </script>

    <script type="text/javascript" language="javascript">
        function OnSerchFileName(source, eventArgs) {

            var hdnValueID = "<%= hdvSerchFileName.ClientID %>";

            document.getElementById(hdnValueID).value = eventArgs.get_value();
          
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Title" runat="Server">
    File Inward Register
    <asp:UpdatePanel ID="Upp" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="center">
                        <div>
                            <asp:UpdateProgress ID="UpdateProgress" runat="server">
                                <ProgressTemplate>
                                    <asp:Image ID="Image1" ImageUrl="~/Images/Icon/waiting.gif" AlternateText="Processing"
                                        runat="server" />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <ajax:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress"
                                PopupControlID="UpdateProgress" BackgroundCssClass="modalPopup" />
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="Server">
    <table width="100%">
        <tr>
            <td valign="top">
                <fieldset id="fieldset1" runat="server" class="FieldSet">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblHead" runat="server" Text="Fill Inward Details" CssClass="Label2"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table width="90%">
                        <tr>
                            <td align="center">
                            <asp:Label ID="lblError" runat="server" ForeColor="Red" Font-Names="Verdana" Font-Size="12px"
                                    Font-Bold="true" CssClass="Display_None"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="Label" colspan="2">
                                Property Name :
                            </td>
                            <td>
                                <asp:TextBox ID="txtProperty" runat="server" TabIndex="1" Width="200px" Height="20px"></asp:TextBox>
                                <asp:HiddenField ID="hdvSerchProj" runat="server" />
                                <ajax:AutoCompleteExtender ID="ACEProp" runat="server" TargetControlID="txtProperty"
                                    CompletionInterval="100" UseContextKey="True" FirstRowSelected="True" ShowOnlyCurrentWordInCompletionListItem="True"
                                    ServiceMethod="GetAllProjectName" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" OnClientItemSelected="OnSerchProjSelected"
                                    MinimumPrefixLength="1" DelimiterCharacters="" Enabled="True" ServicePath="">
                                </ajax:AutoCompleteExtender>
                                <asp:ImageButton ID="ImgPropSerch" runat="server" ImageUrl="~/Images/Icon/ImgSerach.png"
                                    OnClick="ImgPropSerch_Click" />
                            </td>
                            <td class="Label" colspan="2">
                                Company Name :
                            </td>
                            <td>
                                <asp:TextBox ID="txtCompany" runat="server" TabIndex="1" Width="200px" Height="20px"></asp:TextBox>
                                <asp:HiddenField ID="hdvSerchCompany" runat="server" />
                                <ajax:AutoCompleteExtender ID="ACECompeny" runat="server" TargetControlID="txtCompany"
                                    CompletionInterval="100" UseContextKey="True" FirstRowSelected="True" ShowOnlyCurrentWordInCompletionListItem="True"
                                    ServiceMethod="GetAllCompanyName" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" OnClientItemSelected="OnSerchCompany"
                                    MinimumPrefixLength="1" DelimiterCharacters="" Enabled="True" ServicePath="">
                                </ajax:AutoCompleteExtender>
                                <asp:ImageButton ID="imgCompnySearch" runat="server" ImageUrl="~/Images/Icon/ImgSerach.png"
                                    OnClick="imgCompnySearch_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="Label" colspan="2">
                                File No :
                            </td>
                            <td>
                                <asp:TextBox ID="txtSearchFileNo" runat="server" TabIndex="1" Width="200px" Height="20px"></asp:TextBox>
                                <asp:HiddenField ID="hdnValueFileNo" runat="server" />
                                <ajax:AutoCompleteExtender ID="ACEFileNo" runat="server" TargetControlID="txtSearchFileNo"
                                    CompletionInterval="100" UseContextKey="True" FirstRowSelected="True" ShowOnlyCurrentWordInCompletionListItem="True"
                                    ServiceMethod="GetFileFormatedFileNo" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" OnClientItemSelected="OnContactSelected"
                                    MinimumPrefixLength="1" DelimiterCharacters="" Enabled="True" ServicePath="">
                                </ajax:AutoCompleteExtender>
                                <asp:ImageButton ID="ImgSearchFileNo" runat="server" ImageUrl="~/Images/Icon/ImgSerach.png"
                                    OnClick="ImgSearchFileNo_Click" />
                            </td>
                            <td class="Label" colspan="2">
                                File Name :
                            </td>
                            <td>
                                <asp:TextBox ID="txtSearchFileName" runat="server" TabIndex="1" Width="200px" Height="20px"></asp:TextBox>
                                <asp:HiddenField ID="hdvSerchFileName" runat="server" />
                                <ajax:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" TargetControlID="txtSearchFileName"
                                    CompletionInterval="100" UseContextKey="True" FirstRowSelected="True" ShowOnlyCurrentWordInCompletionListItem="True"
                                    ServiceMethod="GetFileFormatedFileName" CompletionListCssClass="AutoExtender"
                                    CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                    OnClientItemSelected="OnSerchFileName" MinimumPrefixLength="1" DelimiterCharacters=""
                                    Enabled="True" ServicePath="">
                                </ajax:AutoCompleteExtender>
                                <asp:ImageButton ID="ImgFileName" runat="server" 
                                    ImageUrl="~/Images/Icon/ImgSerach.png" onclick="ImgFileNameSearch_Click"  />
                            </td>
                        </tr>
                        <tr>
                            <td class="Label" colspan="2">
                                Given By:
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmployee" runat="server" Width="182px" Height="20px" CssClass="TextBox_Search"
                                    TabIndex="1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="reqEmployee" runat="server" ControlToValidate="txtEmployee"
                                    Display="None" ErrorMessage="Enter File No" SetFocusOnError="True" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender18" runat="server" Enabled="True"
                                    TargetControlID="reqEmployee" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                </ajax:ValidatorCalloutExtender>
                                <asp:HiddenField ID="hdnValue" runat="server" />
                                <ajax:AutoCompleteExtender ID="ACEEmployee" runat="server" TargetControlID="txtEmployee"
                                    CompletionInterval="100" UseContextKey="True" FirstRowSelected="True" ShowOnlyCurrentWordInCompletionListItem="True"
                                    ServiceMethod="GetFormatedEmployee" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" OnClientItemSelected="OnEmployeeSelected"
                                    MinimumPrefixLength="1" DelimiterCharacters="" Enabled="True" ServicePath="">
                                </ajax:AutoCompleteExtender>
                            </td>
                            <td class="Label" colspan="2">
                                Date :
                            </td>
                            <td>
                                <asp:TextBox ID="txtOutDate" runat="server" TabIndex="1" Width="200px" Height="20px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="10px">
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
    </table>
    
    <table width="100%">
        <tr>
            <td valign="top">
                <fieldset id="fieldset2" runat="server" class="FieldSet">
                    <table width="100%">
                        <tr>
                            <td align="center">
                                <asp:Label ID="Label1" runat="server" Text="All Outward Records" CssClass="Label2"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel_GrdReport" runat="server">
                                    <ContentTemplate>
                                        <a name="Navigate">
                                            <asp:GridView ID="GrdInReport" runat="server" AllowPaging="True" AlternatingRowStyle-CssClass="alt"
                                                AutoGenerateColumns="False" CssClass="mGrid" GridLines="None" PagerStyle-CssClass="pgr"
                                                Width="98%" AllowSorting="true">
                                                <Columns>
                                                    <%--0--%>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="GrdSelectAllHeader" runat="server" AutoPostBack="true" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="ChkSelect" runat="server" />
                                                        </ItemTemplate>
                                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="8%" Wrap="False" />
                                                    </asp:TemplateField>
                                                    <%--1--%>
                                                    <asp:TemplateField HeaderText="Sr. No.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="LblSrNo" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" Width="7%" />
                                                    </asp:TemplateField>
                                                    <%--2--%>
                                                    <asp:BoundField HeaderText="File No" DataField="FileNo" SortExpression="FileNo">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:BoundField>
                                                    <%--3--%>
                                                    <asp:BoundField HeaderText="File Name" DataField="FileName" SortExpression="FileName">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:BoundField>
                                                    <%--4--%>
                                                    <asp:BoundField HeaderText="Document Title" DataField="DocumentTitle" SortExpression="DocumentTitle">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:BoundField>
                                                    <%--5--%>
                                                    <asp:BoundField HeaderText="Property Name" DataField="PropertyName" SortExpression="PropertyName">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:BoundField>
                                                    
                                                   <%-- <asp:BoundField HeaderText="Company Name" DataField="Company" SortExpression="Company">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:BoundField>--%>
                                                    <%--6--%><asp:BoundField HeaderText="Given To" DataField="Empname" SortExpression="Empname">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:BoundField>
                                                    <%--7--%><asp:BoundField HeaderText="Out Date" DataField="OutwardDate" SortExpression="FileInDate"
                                                        DataFormatString="{0:dd-MM-yyyy}">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:BoundField>
                                                    <%--8--%><asp:BoundField HeaderText="Status" DataField="Status" SortExpression="Status">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:BoundField>
                                                    <%--9--%><asp:BoundField HeaderText="PropertyId" DataField="PropertyId" SortExpression="PropertyId">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" CssClass="Display_None" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" CssClass="Display_None" />
                                                    </asp:BoundField>
                                                    <%--10--%><asp:BoundField HeaderText="InOutId" DataField="InOutId" SortExpression="InOutId">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" CssClass="Display_None" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" CssClass="Display_None" />
                                                    </asp:BoundField>
                                                    <%--11--%><asp:BoundField HeaderText="FileUploadDocId" DataField="FileUploadDocId"
                                                        SortExpression="FileUploadDocId">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" CssClass="Display_None" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" CssClass="Display_None" />
                                                    </asp:BoundField>
                                                    <%--12--%><asp:BoundField HeaderText="FileCEDId" DataField="FileCEDId" SortExpression="FileCEDId">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" CssClass="Display_None" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" CssClass="Display_None" />
                                                    </asp:BoundField>
                                                    <%--13--%><asp:BoundField HeaderText="DocumentTitleId" DataField="DocumentTitleId"
                                                        SortExpression="DocumentTitleId">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" CssClass="Display_None" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" CssClass="Display_None" />
                                                    </asp:BoundField>
                                                    <%--14--%><asp:BoundField HeaderText="EmpID" DataField="EmpID" SortExpression="EmpID">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" CssClass="Display_None" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" CssClass="Display_None" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <PagerStyle CssClass="pgr" />
                                                <AlternatingRowStyle CssClass="alt" />
                                            </asp:GridView>
                                        </a>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <br />
                                        <asp:Button ID="Button1" runat="server" Text="Save Inward Entry" CssClass="button"
                                            TabIndex="1" ValidationGroup="Add" OnClick="btnSaveRecords_Click" Width="150px" />
                                        &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="Button2" runat="server" Text="Cancel" CssClass="button" TabIndex="1"
                                            OnClick="btnCancel_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
    </table>
</asp:Content>
