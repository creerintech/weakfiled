<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true"
    CodeFile="File Outward Register.aspx.cs" Inherits="Transactions_File_Outward_Register"
    Title="File OutWord Entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SearchContent" runat="Server">
    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
    <input type="hidden" id="hiddenbox" runat="server" value="" />
    <%-- <script type="text/javascript" language="javascript">
        function OnContactSelected(source, eventArgs) {

            var hdnValueID = "<%= hdnValue.ClientID %>";

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
--%>


<script language="javascript" type="text/javascript">
        function PrintAftersave() {
            if (confirm("Would You Like To Print ?") == true) {
                var clickButton = document.getElementById("<%= BtnPrint.ClientID %>");
                clickButton.click();
            }
        }
        
       
    </script>
    <script type="text/javascript" language="javascript">
        function OnContactSelected(source, eventArgs) {

            var hdnValueID = "<%= hdnValue.ClientID %>";

            document.getElementById(hdnValueID).value = eventArgs.get_value();          
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Title" runat="Server">
    File Outward Register
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
                <fieldset id="fieldset" runat="server" class="FieldSet">
                    <table>
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="font-size: 14px;">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Search File :
                            </td>
                            <td style="width: 10px;">
                            </td>
                            <td>
                                <asp:TextBox ID="TxtSearch" runat="server" CssClass="TextBox_Search" ToolTip="Enter The Text like FileNo-FileName-ProjectName-Company"
                                    AutoPostBack="true" OnTextChanged="TxtSearch_TextChanged" Width="610px"></asp:TextBox>
                                <asp:HiddenField ID="hdnValue" runat="server" />
                                <asp:RequiredFieldValidator ID="Req_BuildingName" runat="server" ControlToValidate="TxtSearch"
                                    Display="None" ErrorMessage="Party Name is Required" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                    TargetControlID="Req_BuildingName" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                </ajax:ValidatorCalloutExtender>
                                <ajax:AutoCompleteExtender ID="ACE1" runat="server" TargetControlID="TxtSearch" CompletionInterval="100"
                                    UseContextKey="True" FirstRowSelected="true" ShowOnlyCurrentWordInCompletionListItem="true"
                                    ServiceMethod="GetCompletionListParty" CompletionListCssClass="AutoExtender"
                                    CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                    OnClientItemSelected="OnContactSelected" MinimumPrefixLength="1">
                                </ajax:AutoCompleteExtender>
                            </td>
                        </tr>
                        <%--<tr>
                                    <td style="width: 90px; padding-top: 20px">
                                    </td>
                                    <td style="width: 80px">
                                        <asp:Label ID="lblCriteria" runat="server" Text="Search By" CssClass="Label2"></asp:Label>
                                    </td>
                                    <td style="width: 70px">
                                      
                                        <asp:RadioButton ID="rbtnFileNo" runat="server" Text="File No" GroupName="Criteria"
                                            Checked="True" CssClass="LabelSearch" OnCheckedChanged="rbtnFileNo_CheckedChanged"
                                            AutoPostBack="True" />
                                      
                                    </td>
                                    <td style="width: 80px">
                                       
                                        <asp:RadioButton ID="rbtnFileName" runat="server" Text="File Name" GroupName="Criteria"
                                            CssClass="LabelSearch" OnCheckedChanged="rbtnFileName_CheckedChanged"
                                            AutoPostBack="True" />
                                       
                                    </td>
                                    <td style="width: 70px">
                                      
                                        <asp:RadioButton ID="rbtnProject" runat="server" Text="Project" GroupName="Criteria"
                                            CssClass="LabelSearch" OnCheckedChanged="rbtnProject_CheckedChanged" AutoPostBack="True" />
                                     
                                    </td>
                                    <td style="width: 80px">
                                        <asp:RadioButton ID="rbtnCompany" runat="server" Text="Company" GroupName="Criteria"
                                            CssClass="LabelSearch" OnCheckedChanged="rbtnCompany_CheckedChanged" AutoPostBack="True"/>
                                    </td>
                                    <td>
                                       
                                    </td>
                                </tr>--%>
                        <%--<tr>
                                    <td colspan="2">
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtSearch" runat="server" Width="200px" TabIndex="1" OnTextChanged="txtSearch_TextChanged"
                                            AutoPostBack="True" ToolTip="Enter File No" CssClass="TextBox_Search"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="reqFile" runat="server" ControlToValidate="txtSearch"
                                            Display="None" ErrorMessage="Enter File No" SetFocusOnError="True" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender18" runat="server" Enabled="True"
                                            TargetControlID="reqFile" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                        </ajax:ValidatorCalloutExtender>
                                        <asp:HiddenField ID="hdnValue" runat="server" />
                                        <ajax:AutoCompleteExtender ID="ACEFileNo" runat="server" TargetControlID="txtSearch"
                                            CompletionInterval="100" UseContextKey="True" FirstRowSelected="True" ShowOnlyCurrentWordInCompletionListItem="True"
                                            ServiceMethod="GetFileFormatedFileNo" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" OnClientItemSelected="OnContactSelected"
                                            MinimumPrefixLength="1" DelimiterCharacters="" Enabled="True" ServicePath="">
                                        </ajax:AutoCompleteExtender>
                                        
                                        <asp:TextBox ID="txtSearchFileName" runat="server" Width="200px" TabIndex="1" OnTextChanged="txtSearchFileName_TextChanged"
                                            AutoPostBack="True" ToolTip="Enter File Name" CssClass="TextBox_Search"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="reqFileName" runat="server" ControlToValidate="txtSearchFileName"
                                            Display="None" ErrorMessage="Enter File No" SetFocusOnError="True" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender11" runat="server" Enabled="True"
                                            TargetControlID="reqFileName" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                        </ajax:ValidatorCalloutExtender>
                                        <asp:HiddenField ID="hdvSerchFileName" runat="server" />
                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" TargetControlID="txtSearchFileName"
                                            CompletionInterval="100" UseContextKey="True" FirstRowSelected="True" ShowOnlyCurrentWordInCompletionListItem="True"
                                            ServiceMethod="GetFileFormatedFileName" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" OnClientItemSelected="OnSerchFileName"
                                            MinimumPrefixLength="1" DelimiterCharacters="" Enabled="True" ServicePath="">
                                        </ajax:AutoCompleteExtender>

                                        
                                        <asp:TextBox ID="txtSearchProject" runat="server" Width="200px" TabIndex="1" OnTextChanged="txtSearchProject_TextChanged"
                                            AutoPostBack="True" ToolTip="Enter Project name" CssClass="TextBox_Search"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="reqProjectFile" runat="server" ControlToValidate="txtSearchProject"
                                            Display="None" ErrorMessage="Enter File No" SetFocusOnError="True" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                            TargetControlID="reqProjectFile" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                        </ajax:ValidatorCalloutExtender>
                                        <asp:HiddenField ID="hdvSerchProj" runat="server" />
                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtSearchProject"
                                            CompletionInterval="100" UseContextKey="True" FirstRowSelected="True" ShowOnlyCurrentWordInCompletionListItem="True"
                                            ServiceMethod="GetAllProjectName" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" OnClientItemSelected="OnSerchProjSelected"
                                            MinimumPrefixLength="1" DelimiterCharacters="" Enabled="True" ServicePath="">
                                        </ajax:AutoCompleteExtender>
                                        <asp:TextBox ID="txtCompany" runat="server" Width="200px" TabIndex="1" OnTextChanged="txtCompany_TextChanged"
                                            AutoPostBack="True" ToolTip="Enter Company name" CssClass="TextBox_Search"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="reqCompanyFile" runat="server" ControlToValidate="txtCompany"
                                            Display="None" ErrorMessage="Enter File No" SetFocusOnError="True" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" Enabled="True"
                                            TargetControlID="reqCompanyFile" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                        </ajax:ValidatorCalloutExtender>
                                        <asp:HiddenField ID="hdvSerchCompany" runat="server" />
                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtCompany"
                                            CompletionInterval="100" UseContextKey="True" FirstRowSelected="True" ShowOnlyCurrentWordInCompletionListItem="True"
                                            ServiceMethod="GetAllCompanyName" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" OnClientItemSelected="OnSerchCompany"
                                            MinimumPrefixLength="1" DelimiterCharacters="" Enabled="True" ServicePath="">
                                        </ajax:AutoCompleteExtender>
                                    </td>
                                    <td>
                                    </td>
                                </tr>--%>
                    </table>
                    <table width="90%">
                        <tr>
                            <td height="10px">
                            </td>
                        </tr>
                        <tr>
                            <td class="Label" colspan="2">
                                File No :
                            </td>
                            <td>
                                <asp:TextBox ID="txtFileNo" runat="server" Width="200px" TabIndex="1"></asp:TextBox>
                                <asp:DropDownList ID="ddlFileNo" runat="server" Width="200px" OnSelectedIndexChanged="ddlFileNo_SelectedIndexChanged"
                                    AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                            <td class="Label" colspan="2">
                                File Name :
                            </td>
                            <td>
                                <asp:TextBox ID="txtFileName" runat="server" TabIndex="1" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtFileName"
                                    Display="None" ErrorMessage="Enter File Name" SetFocusOnError="True" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True"
                                    TargetControlID="RequiredFieldValidator12" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                </ajax:ValidatorCalloutExtender>
                            </td>
                        </tr>
                        <tr>
                            <td class="Label" colspan="2">
                                Project Name :
                            </td>
                            <td>
                                <asp:TextBox ID="txtProjectName" runat="server" TabIndex="1" Width="200px"></asp:TextBox>
                                <asp:HiddenField ID="hdnProjectId" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtProjectName"
                                    Display="None" ErrorMessage="Enter Project Name" SetFocusOnError="True" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                                    TargetControlID="RequiredFieldValidator1" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                </ajax:ValidatorCalloutExtender>
                            </td>
                            <td class="Label" colspan="2">
                                Barcode :
                            </td>
                            <td>
                                <asp:TextBox ID="TxtBarcode" runat="server" Width="200px" TabIndex="1"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="ReqBarcode" runat="server" ControlToValidate="TxtBarcode"
                                    Display="None" ErrorMessage="Enter Barcode" SetFocusOnError="True" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" Enabled="True"
                                    TargetControlID="ReqBarcode" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                </ajax:ValidatorCalloutExtender>--%>
                            </td>
                        </tr>
                        <tr>
                            <td class="Label" colspan="2">
                                Given To:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="ComboBox" TabIndex="1"
                                    Width="205px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ReqddlEmployee" runat="server" ControlToValidate="txtFileName"
                                    Display="None" ErrorMessage="Enter File Name" SetFocusOnError="True" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" Enabled="True"
                                    TargetControlID="ReqddlEmployee" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                </ajax:ValidatorCalloutExtender>
                            </td>
                            <td class="Label" colspan="2">
                                Date :
                            </td>
                            <td>
                                <asp:TextBox ID="txtDate" runat="server" TabIndex="1" Width="200px"></asp:TextBox>
                                <%--<ajax:CalendarExtender ID="CalEx_Date" runat="server" CssClass="cal_Theme1" Enabled="True"
                                            Format="dd MMM yyyy" PopupButtonID="Img_Date" TargetControlID="txtDate">
                                        </ajax:CalendarExtender>
                                        <asp:ImageButton ID="Img_Date" runat="server" CausesValidation="False" CssClass="Imagebutton"
                                            ImageUrl="~/Images/Icon/DateSelector.png" TabIndex="1" />--%>
                            </td>
                        </tr>
                    </table>
                    <table width="95%">
                        <tr>
                            <td>
                                <asp:GridView ID="InwordGrid" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    CssClass="mGrid" GridLines="None" Width="100%" OnRowCommand="InwordGrid_RowCommand">
                                    <AlternatingRowStyle CssClass="alt" />
                                    <Columns>
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
                                        <asp:TemplateField HeaderText="Sr. No.">
                                            <ItemTemplate>
                                                <asp:Label ID="LblSrNo" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="7%" Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="DocumentTitle" HeaderText="Document Name">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DocumentSubTitle" HeaderText="Document Subtitle">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DocImagePath" HeaderText="Document Path Name">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Status" HeaderText="Status">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DocumentTitleId" HeaderText="DocumentTitleId">
                                            <HeaderStyle CssClass="Display_None" HorizontalAlign="Center" VerticalAlign="Middle"
                                                Wrap="False" />
                                            <ItemStyle CssClass="Display_None" HorizontalAlign="Center" VerticalAlign="Middle"
                                                Wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FileUploadDocId" HeaderText="FileUploadDocId">
                                            <HeaderStyle CssClass="Display_None" HorizontalAlign="Center" VerticalAlign="Middle"
                                                Wrap="False" />
                                            <ItemStyle CssClass="Display_None" HorizontalAlign="Center" VerticalAlign="Middle"
                                                Wrap="False" />
                                        </asp:BoundField>
                                        <%-- <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkPrint" runat="server" Text="Print" CommandName="Print" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"DocImagePath") %>' />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="8%" Wrap="False" />
                                                </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Print">
                                            <ItemTemplate>
                                                <asp:UpdatePanel ID="UpLnkButton" runat="server">
                                                    <ContentTemplate>
                                                        <asp:LinkButton ID="lblButton" runat="server" Text="Print" OnClick="DownloadFile"
                                                            TabIndex="1" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' OnClientClick="aspnetForm.target ='_blank';"></asp:LinkButton>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="lblButton" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle CssClass="pgr" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <table width="100%">
                        <tr>
                            <td height="10px">
                            </td>
                        </tr>
                        <tr>
                            <td height="10px">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnSaveRecords" runat="server" Text="Save Outward Entry" CssClass="button"
                                            TabIndex="1" OnClick="btnSaveRecords_Click" Width="150px" />
                                        &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                         <asp:Button ID="BtnPrint" runat="server" Text="Print" CssClass="button" TabIndex="1" 
                                            OnClick="BtnPrint_Click" ValidationGroup="Add"/>
                                            
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" TabIndex="1" 
                                            OnClick="btnCancel_Click" ValidationGroup="Add"/>
                                            
                                            
                                    </ContentTemplate>
                                </asp:UpdatePanel>
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
                                                Width="98%" AllowSorting="true" OnRowDeleting="GrdInReport_RowDeleting">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="50px">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImgBtnDelete" runat="server" CausesValidation="False" CssClass="Imagebutton"
                                                                CommandArgument='<%# Eval("#") %>' CommandName="Delete" ImageUrl="~/Images/Icon/GridDelete.png"
                                                                ToolTip="Delete Record" TabIndex="1" />
                                                            <ajax:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" ConfirmText="Would You Like To Delete This Record?"
                                                                TargetControlID="ImgBtnDelete">
                                                            </ajax:ConfirmButtonExtender>
                                                        </ItemTemplate>
                                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Sr. No.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="LblSrNo" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" Width="7%" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="File No" DataField="FileNo" SortExpression="FileNo">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="File Name" DataField="FileName" SortExpression="FileName">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Property Name" DataField="PropertyName" SortExpression="PropertyName">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Document Title" DataField="DocumentTitle" SortExpression="DocumentTitle">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:BoundField>
                                                     <asp:BoundField HeaderText="Document SubTitle" DataField="DocumentSubTitle" SortExpression="DocumentSubTitle">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:BoundField>
                                                    <%--<asp:BoundField HeaderText="Document Path" DataField="DocImagePath" SortExpression="DocImagePath"" ItemStyle-Wrap="False">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:BoundField>--%>
                                                    
                                                   <%-- <asp:BoundField HeaderText="Company Name" DataField="Company" SortExpression="Company">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:BoundField>--%>
                                                    <asp:BoundField HeaderText="Given To" DataField="Empname" SortExpression="Empname">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:BoundField>
                                                    <%-- <asp:BoundField HeaderText="Barcode" DataField="Barcode" SortExpression="Barcode">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:BoundField>--%>
                                                    <asp:BoundField HeaderText="Outward Date" DataField="OutwardDate" SortExpression="OutwardDate"
                                                        DataFormatString="{0:dd-MM-yyyy}">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="File Status" DataField="Status" SortExpression="Status">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:BoundField>
                                                    <%--<asp:BoundField HeaderText="PropertyId" DataField="PropertyId" SortExpression="PropertyId">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" CssClass="Display_None" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" CssClass="Display_None" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="InID" DataField="InID" SortExpression="InID">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" CssClass="Display_None" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" CssClass="Display_None" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="InDetailsId" DataField="InDetailsId" SortExpression="InDetailsId">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" CssClass="Display_None" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" CssClass="Display_None" />
                                                    </asp:BoundField>--%>
                                                </Columns>
                                                <PagerStyle CssClass="pgr" />
                                                <AlternatingRowStyle CssClass="alt" />
                                            </asp:GridView>
                                        </a>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
    </table>
</asp:Content>
