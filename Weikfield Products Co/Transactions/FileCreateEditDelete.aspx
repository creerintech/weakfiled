<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true"
    CodeFile="FileCreateEditDelete.aspx.cs" Inherits="Transactions_FileCreateEditDelete"
    Title="File Create/Edit/Delete" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SearchContent" runat="Server">
    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
    <input type="hidden" id="hiddenbox" runat="server" value="" />
    <asp:HiddenField ID="HdnPropertyId" runat="server" />

    <script type="text/javascript" language="javascript">
        function OnContactSelected(source, eventArgs) {

            var hdnValueID = "<%= hdnValue.ClientID %>";

            document.getElementById(hdnValueID).value = eventArgs.get_value();
          
        }
    </script>

    <script type="text/javascript" language="javascript">
        function OnContactSelectedSubDoc(source, eventArgs) {

            var hdnValueSubId = "<%= hndSubTitle.ClientID %>";

            document.getElementById(hdnValueSubId).value = eventArgs.get_value();
          
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Title" runat="Server">
    File Register
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
    <asp:UpdatePanel ID="uPanel" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td valign="top">
                        <fieldset id="fieldset" runat="server" class="FieldSet">
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
                                        <asp:RequiredFieldValidator ID="reqFile" runat="server" ControlToValidate="txtFileNo"
                                            Display="None" ErrorMessage="Enter File No" SetFocusOnError="True" ValidationGroup="Add">                                        
                                        </asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender18" runat="server" Enabled="True"
                                            TargetControlID="reqFile" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                        </ajax:ValidatorCalloutExtender>
                                    </td>
                                    <td class="Label" colspan="2">
                                        Select Project :
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlProject" runat="server" Width="390px" OnSelectedIndexChanged="ddlProject_SelectedIndexChanged"
                                            AutoPostBack="true" CssClass="ComboBox" TabIndex="1">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ReqddlProject" runat="server" ControlToValidate="ddlProject"
                                            InitialValue="0" Display="None" ErrorMessage="Select Project" SetFocusOnError="True"
                                            ValidationGroup="Add">
                                        </asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" Enabled="True"
                                            TargetControlID="ReqddlProject" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                        </ajax:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <asp:GridView ID="GrdCompany" runat="server" AllowPaging="True" AlternatingRowStyle-CssClass="alt"
                                            AutoGenerateColumns="False" CssClass="mGrid" GridLines="None" PagerStyle-CssClass="pgr"
                                            Width="98%">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="GrdSelectAllHeader" runat="server" AutoPostBack="true" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox runat="server" ID="ChkSelect" Checked="true" />
                                                    </ItemTemplate>
                                                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="8%" Wrap="false" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sr. No.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblSrNo" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" Width="7%" />
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Company Names" DataField="Company">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="CompanyId" DataField="CompanyId">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="false" CssClass="Display_None" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" CssClass="Display_None" />
                                                </asp:BoundField>
                                            </Columns>
                                            <PagerStyle CssClass="pgr" />
                                            <AlternatingRowStyle CssClass="alt" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Label" colspan="2">
                                        File Name :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFileName" runat="server" Width="200px" TabIndex="1"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                    <td class="Label">
                                        Barcode :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtBarcode" runat="server" Width="230px" TabIndex="1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <%--colspan="2"--%>
                                    <td>
                                    </td>
                                    <td class="Label">
                                        Document Date :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDate" runat="server" Width="180px" TabIndex="1"></asp:TextBox>
                                        <ajax:CalendarExtender CssClass="cal_Theme1" ID="CalEx_Date" runat="server" Format="dd MMM yyyy"
                                            PopupButtonID="Img_Date" TargetControlID="txtDate" />
                                        <asp:ImageButton ID="Img_Date" runat="server" CausesValidation="False" CssClass="Imagebutton"
                                            ImageUrl="~/Images/Icon/DateSelector.png" TabIndex="1" />
                                        <asp:RequiredFieldValidator ID="ReqDate" runat="server" ControlToValidate="txtDate"
                                            Display="None" ErrorMessage="Enter Date" SetFocusOnError="True" ValidationGroup="Add">
                                        </asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                            TargetControlID="ReqDate" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                        </ajax:ValidatorCalloutExtender>
                                    </td>
                                    <td class="Label" colspan="2">
                                        Expiry Date :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtExpireDate" runat="server" Width="200px" TabIndex="1"></asp:TextBox>
                                        <ajax:CalendarExtender CssClass="cal_Theme1" ID="CalendarExtender1" runat="server"
                                            Format="dd MMM yyyy" PopupButtonID="Img_ExpDate" TargetControlID="txtExpireDate" />
                                        <asp:ImageButton ID="Img_ExpDate" runat="server" CausesValidation="False" CssClass="Imagebutton"
                                            ImageUrl="~/Images/Icon/DateSelector.png" TabIndex="1" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtExpireDate"
                                            Display="None" ErrorMessage="Enter Expiry Date" SetFocusOnError="True" ValidationGroup="Add">
                                        </asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" Enabled="True"
                                            TargetControlID="RequiredFieldValidator4" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                        </ajax:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td class="Label">
                                        Renewed After Date :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRenewed" runat="server" Width="200px" TabIndex="1"></asp:TextBox>
                                    </td>
                                    <td class="Label" colspan="2">
                                        Day / Month / Year :
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlDay" runat="server" Width="70px" AutoPostBack="true" TabIndex="1"
                                            OnSelectedIndexChanged="OnSelectedIndexChangedGetDate">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddlmonth" runat="server" Width="80px" AutoPostBack="true" OnSelectedIndexChanged="OnSelectedIndexChangedGetDate"
                                            TabIndex="1">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddlYear" runat="server" Width="80px" AutoPostBack="true" TabIndex="1"
                                            OnSelectedIndexChanged="OnSelectedIndexChangedGetDate">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Label" colspan="2">
                                        Select Room :
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlRoom" runat="server" CssClass="ComboBox" Width="205px" AutoPostBack="true"
                                            OnSelectedIndexChanged="ddlRoom_SelectedIndexChanged" TabIndex="1">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ReqRoom" runat="server" ControlToValidate="ddlRoom"
                                            Display="None" ErrorMessage="Room Is Required" SetFocusOnError="True" ValidationGroup="Add"
                                            InitialValue="0">
                                        </asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="ReqRoom_ValidatorCalloutExtender" runat="server"
                                            Enabled="True" TargetControlID="ReqRoom" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                        </ajax:ValidatorCalloutExtender>
                                    </td>
                                    <td colspan="2">
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Label" colspan="2">
                                        Select Aisle :
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlAisle" runat="server" CssClass="ComboBox" Width="205px"
                                            OnSelectedIndexChanged="ddlAisle_SelectedIndexChanged" AutoPostBack="true" TabIndex="1">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ReqddlAisle" runat="server" ControlToValidate="ddlAisle"
                                            Display="None" ErrorMessage="Aisle Is Required" SetFocusOnError="True" ValidationGroup="Add"
                                            InitialValue="0">
                                        </asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                                            TargetControlID="ReqddlAisle" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                        </ajax:ValidatorCalloutExtender>
                                    </td>
                                    <td colspan="2">
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Label" colspan="2">
                                        Select Shelf :
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlShelf" runat="server" CssClass="ComboBox" Width="205px"
                                            AutoPostBack="true" TabIndex="1">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ReqddlShelf" runat="server" ControlToValidate="ddlShelf"
                                            Display="None" ErrorMessage="Shelf No Is Required" SetFocusOnError="True" ValidationGroup="Add"
                                            InitialValue="0">
                                        </asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" Enabled="True"
                                            TargetControlID="ReqddlShelf" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                        </ajax:ValidatorCalloutExtender>
                                    </td>
                                    <td class="Display_None" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Select
                                        Cabinet :
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlCabinet" runat="server" CssClass="Display_None" Width="200px"
                                            AutoPostBack="true" TabIndex="1">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ReqddlCabinet" runat="server" ControlToValidate="ddlCabinet"
                                            Display="None" ErrorMessage="Cabinet No Is Required" SetFocusOnError="True" ValidationGroup="Add"
                                            InitialValue="0">
                                        </asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server" Enabled="True"
                                            TargetControlID="ReqddlCabinet" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                        </ajax:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Label" colspan="2">
                                        Document Ref No :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDocRefno" runat="server" Width="200px" TabIndex="1"></asp:TextBox>
                                    </td>
                                    <td class="Display_None">
                                        Document Attach Date :
                                    </td>
                                    <td class="Display_None">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Label" colspan="2">
                                        Document Sub Title :
                                    </td>
                                    <td>
                                        <%--<asp:DropDownList ID="ddlDocSubType" runat="server" Width="200px" AutoPostBack="true"
                                                                        CssClass="ComboBox" TabIndex="1">
                                                                    </asp:DropDownList>  --%>
                                        <asp:TextBox ID="txtDocSubTitle" runat="server" CssClass="TextBox" TabIndex="1" Width="200px"
                                            OnTextChanged="txtDocSubTitle_TextChanged" Height="20px" AutoPostBack="true"></asp:TextBox>
                                        <asp:HiddenField ID="hndSubTitle" runat="server" />
                                        <ajax:AutoCompleteExtender ID="ACESub" runat="server" TargetControlID="txtDocSubTitle"
                                            CompletionInterval="100" UseContextKey="True" FirstRowSelected="true" ShowOnlyCurrentWordInCompletionListItem="true"
                                            ServiceMethod="GetCompletionListSubDocuments" CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                            OnClientItemSelected="OnContactSelectedSubDoc" MinimumPrefixLength="1">
                                        </ajax:AutoCompleteExtender>
                                    </td>
                                    <td class="Label" colspan="2">
                                        Select Document Title:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSelectDoc" runat="server" CssClass="TextBox" TabIndex="1" Width="250px"
                                            OnTextChanged="txtSelectDoc_TextChanged" Height="20px" AutoPostBack="true"></asp:TextBox>
                                        <asp:HiddenField ID="hdnValue" runat="server" />
                                        <ajax:AutoCompleteExtender ID="ACE1" runat="server" TargetControlID="txtSelectDoc"
                                            CompletionInterval="100" UseContextKey="True" FirstRowSelected="true" ShowOnlyCurrentWordInCompletionListItem="true"
                                            ServiceMethod="GetCompletionListDocuments" CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                            OnClientItemSelected="OnContactSelected" MinimumPrefixLength="1">
                                        </ajax:AutoCompleteExtender>
                                    </td>
                                </tr>
                                <tr>
                                </tr>
                                <tr>
                                    <td class="Label" colspan="2">
                                        Documents :
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="updatePanel3" runat="server">
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="lnkLogo" />
                                            </Triggers>
                                            <ContentTemplate>
                                                <asp:FileUpload ID="LogoUpload" runat="server" CssClass="TextBox" TabIndex="1" Width="200px" />
                                                <asp:Label ID="lblOfferLogopath" runat="server" Text="Label" Visible="false"></asp:Label>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td class="Label" colspan="2">
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lnkLogo" runat="server" ValidationGroup="LogoUpload" OnClick="lnkLogo_Click"
                                            Text="Upload" CssClass="buttonClass" TabIndex="1">Upload</asp:LinkButton>
                                        <asp:LinkButton ID="lnkCancel" runat="server" OnClick="lnkCancel_Click" TabIndex="1"
                                            CssClass="buttonClass">Cancel</asp:LinkButton>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td colspan="6">
                                        <table width="100%" cellspacing="6">
                                            <tr>
                                            </tr>
                                            <tr>
                                                <td align="center" valign="top" width="100px" colspan="4">
                                                    <div style="overflow: scroll; width: 840px">
                                                        <asp:GridView ID="GridLogo" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                                                            AllowPaging="true" OnPageIndexChanging="GridLogo_PageIndexChanging" TabIndex="1"
                                                            Width="100%" OnRowCommand="GridLogo_RowCommand" OnRowDeleting="GridLogo_RowDeleting">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Edit/Delete" HeaderStyle-Width="50px">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkLogo" runat="server" Checked="True" Visible="false" />
                                                                        <%--<asp:ImageButton ID="ImgEditLogo" runat="server" CausesValidation="false" CommandArgument="<%#((GridViewRow)Container).RowIndex %>"
                                                                            CommandName="Select" ImageUrl="~/Images/Icon/GridEdit.png" ToolTip="Edit" TabIndex="1" />--%>
                                                                        <asp:ImageButton ID="ImgBtnEdit" runat="server" CausesValidation="False" CssClass="Imagebutton"
                                                                           CommandName="Select" ImageUrl="~/Images/Icon/GridEdit.png"
                                                                            ToolTip="Edit Record" TabIndex="1" />
                                                                        <asp:ImageButton ID="ImgDeleteLogo" runat="server" CommandArgument='<%# Eval("#") %>'
                                                                            CommandName="Delete"  ImageUrl="~/Images/Icon/GridDelete.png"
                                                                            ToolTip="Delete" TabIndex="1" />
                                                                        <ajax:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" ConfirmText="Would You Like To Delete This Record?"
                                                                            TargetControlID="ImgDeleteLogo">
                                                                        </ajax:ConfirmButtonExtender>
                                                                    </ItemTemplate>
                                                                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                </asp:TemplateField>
                                                                <%-- <asp:BoundField DataField="DocDate" HeaderText="Document Attach Date">
                                                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" Width="100px" />
                                                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                                                </asp:BoundField>--%>
                                                                <asp:BoundField DataField="DocRefNo" HeaderText="DocRefNo">
                                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" Width="100px" />
                                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="DocumentTitle" HeaderText="Document Title">
                                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" Width="100px" />
                                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="DocumentTitleId" HeaderText="DocumentTitleId">
                                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" Width="100px"
                                                                        CssClass="Display_None" />
                                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" CssClass="Display_None" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="DocumentSubTitle" HeaderText="Document Sub Title">
                                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" Width="100px" />
                                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Id" HeaderText="Document Subtitle Id">
                                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" Width="100px"
                                                                        CssClass="Display_None" />
                                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" CssClass="Display_None" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="DocImagePath" HeaderText="Document">
                                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="Download">
                                                                    <ItemTemplate>
                                                                        <asp:UpdatePanel ID="UpLnkButton" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:LinkButton ID="lblButton" runat="server" Text="Download" OnClick="DownloadFile"
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
                                                                <asp:BoundField DataField="Status" HeaderText="Status">
                                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" CssClass="Display_None" />
                                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" CssClass="Display_None" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="FileUploadDocId" HeaderText="FileUploadDocId">
                                                                    <HeaderStyle CssClass="Display_None" />
                                                                    <ItemStyle CssClass="Display_None" />
                                                                </asp:BoundField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Label" colspan="2">
                                        Narration :
                                    </td>
                                    <td colspan="5">
                                        <asp:TextBox ID="txtAdditionalNotes" TextMode="MultiLine" runat="server" MaxLength="10000"
                                            Rows="2" Columns="10" Width="720px" TabIndex="1"></asp:TextBox>
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
                                        <asp:Button ID="BtnUpdate" runat="server" Text="Update" CssClass="button" ValidationGroup="Add"
                                            OnClick="BtnUpdate_Click" TabIndex="1" />&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="button" TabIndex="1"
                                            OnClick="BtnSave_Click" ValidationGroup="Add" />&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="BtnDelete" runat="server" Text="Delete" CssClass="button" ValidationGroup="Add"
                                            OnClick="BtnDelete_Click" Visible="false" TabIndex="1" />
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="BtnCancel" runat="server" Text="Cancel" CssClass="button" CausesValidation="False"
                                            OnClick="BtnCancel_Click" TabIndex="1" />
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
            <center>
                <h2>
                    Search File
                </h2>
            </center>
            <asp:UpdatePanel ID="Content1_UpdatePanel" runat="server">
                <ContentTemplate>
                    <asp:TextBox ID="TxtSearch" runat="server" CssClass="search" ToolTip="Enter The Text"
                        TabIndex="15" Width="292px" AutoPostBack="True" OnTextChanged="TxtSearch_TextChanged"> </asp:TextBox>
                    <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtSearch"
                        CompletionInterval="100" UseContextKey="True" FirstRowSelected="true" ShowOnlyCurrentWordInCompletionListItem="true"
                        ServiceMethod="GetCompletionList" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight">
                    </ajax:AutoCompleteExtender>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div style="overflow: scroll; margin-top: 10px;">
                <table width="100%">
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel_GrdReport" runat="server">
                                <ContentTemplate>
                                    <a name="Navigate">
                                        <asp:GridView ID="GrdReport" runat="server" AllowPaging="True" AlternatingRowStyle-CssClass="alt"
                                            AutoGenerateColumns="False" CssClass="mGrid" GridLines="None" PagerStyle-CssClass="pgr"
                                            OnRowCommand="GrdReport_RowCommand" OnRowDeleting="GrdReport_RowDeleting" Width="98%"
                                            OnPageIndexChanging="GrdReport_PageIndexChanging" AllowSorting="true">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImgBtnEdit" runat="server" CausesValidation="False" CssClass="Imagebutton"
                                                            CommandArgument='<%# Eval("#") %>' CommandName="Select" ImageUrl="~/Images/Icon/GridEdit.png"
                                                            ToolTip="Edit Record" TabIndex="1" />
                                                        <asp:ImageButton ID="ImgBtnDelete" runat="server" CausesValidation="False" CssClass="Imagebutton"
                                                            CommandArgument='<%# Eval("#") %>' CommandName="Delete" ImageUrl="~/Images/Icon/GridDelete.png"
                                                            ToolTip="Delete Record" TabIndex="1" />
                                                        <ajax:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" ConfirmText="Would You Like To Delete This Record?"
                                                            TargetControlID="ImgBtnDelete">
                                                        </ajax:ConfirmButtonExtender>
                                                    </ItemTemplate>
                                                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="8%" Wrap="false" />
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
                                                <asp:BoundField HeaderText="FileName" DataField="FileName" SortExpression="FileName">
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Project Name" DataField="PropertyName" SortExpression="PropertyName">
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Barcode" DataField="Barcode" SortExpression="Barcode">
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Room" DataField="Room" SortExpression="Room">
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Aisle" DataField="Aisle" SortExpression="Aisle">
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Shelf No" DataField="ShelfNo" SortExpression="ShelfNo">
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="DocDate" DataField="DocDate" SortExpression="DocDate">
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="DocExpiryDate" DataField="DocExpiryDate" SortExpression="DocExpiryDate">
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="PropertyId" DataField="PropertyId" SortExpression="PropertyId">
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
                </table>
            </div>
            <div>
                <asp:Button ID="btnPopHide" runat="server" Style="display: none;" />
                <asp:Panel ID="pnlInfo" runat="server" CssClass="ModelPopUpPanelBackGroundBig" Style="display: none;">
                    <table width="100%" class="PopUpHeader">
                        <tr style="background-color: #1569C7; height: 25px; text-align: center; vertical-align: middle;">
                            <td>
                                <div style="float: left; margin-left: 5px;">
                                    &nbsp;<asp:Label ID="popUpTitle" runat="server" ForeColor="White" Font-Bold="true"
                                        Font-Size="12px" Text="File Contents"></asp:Label>
                                </div>
                                <div style="float: right; margin-right: 5px;">
                                    <asp:ImageButton ID="btnPopUpClose" ImageUrl="~/Images/Icon/CloseButton.png" ToolTip="Close"
                                        runat="server" /></div>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <ajax:ModalPopupExtender ID="PopUpFiles" BackgroundCssClass="modalBackground" runat="server"
                    TargetControlID="btnPopHide" PopupControlID="pnlInfo">
                </ajax:ModalPopupExtender>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
