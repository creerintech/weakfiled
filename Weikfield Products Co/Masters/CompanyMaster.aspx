<%@ Page Title="Company Master" Language="C#" MasterPageFile="~/MasterPages/MasterPage_RN.master"
    AutoEventWireup="true" CodeFile="CompanyMaster.aspx.cs" Inherits="Masters_CompanyMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SearchContent" runat="Server">
    <input type="hidden" id="hiddenbox" runat="server" value="" />
    <style type="text/css">
        .modalPopup
        {
            background-color: #696969;
            filter: alpha(opacity=40);
            opacity: 0.7;
            xindex: -1;
        }
    </style>

    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        //Raised before processing of an asynchronous postback starts and the postback request is sent to the server.
        prm.add_beginRequest(BeginRequestHandler);
        // Raised after an asynchronous postback is finished and control has been returned to the browser.
        prm.add_endRequest(EndRequestHandler);
        function BeginRequestHandler(sender, args) {
            //Shows the modal popup - the update progress
            var popup = $find('<%= modalPopup.ClientID %>');
            if (popup != null) {
                popup.show();
            }
        }

        function EndRequestHandler(sender, args) {
            //Hide the modal popup - the update progress
            var popup = $find('<%= modalPopup.ClientID %>');
            if (popup != null) {
                popup.hide();
            }
        }
    </script>

    <script type="text/javascript" language="javascript">

        function UpdateEquipFunction() {

            var value = document.getElementById('<%=txtCompany.ClientID%>').value;

            if (value == "") {
                document.getElementById('<%= hiddenbox.ClientID%>').value = "1";
            }
            else {
                if (confirm("Would You Want To Upadte The Record ?") == true) {
                    document.getElementById('<%= hiddenbox.ClientID%>').value = "0";
                    return false;
                }
                else {
                    document.getElementById('<%= hiddenbox.ClientID%>').value = "100";
                }
            }
        }
        function DeleteEquipFunction() {

            var value = document.getElementById('<%=txtCompany.ClientID%>').value;

            if (value == "") {
                document.getElementById('<%= hiddenbox.ClientID%>').value = "1";
            }
            else {
                if (confirm("Would You Want To Delete This Record ?") == true) {
                    document.getElementById('<%= hiddenbox.ClientID%>').value = "0";
                    return false;
                }
                else {
                    document.getElementById('<%= hiddenbox.ClientID%>').value = "100";
                }
            }
        }
    </script>

    <script language="javascript" type="text/javascript">
         function AddCompanyType() {
             window.open('../Masters/CompanyType.aspx');
         }
    </script>

    <script type="text/javascript" language="javascript">
        function OnContactSelected(source, eventArgs) {

            var hdnValueID = "<%= hdnValue.ClientID %>";

            document.getElementById(hdnValueID).value = eventArgs.get_value();
          
        }
    </script>

    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            Search for Company Type :
            <asp:TextBox ID="TxtSearch" runat="server" CssClass="search" ToolTip="Enter The Text"
                Width="292px" AutoPostBack="True" OnTextChanged="TxtSearch_TextChanged" TabIndex="5"></asp:TextBox>
            <div id="divwidth">
            </div>
            <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtSearch"
                CompletionInterval="100" UseContextKey="True" FirstRowSelected="true" ShowOnlyCurrentWordInCompletionListItem="true"
                ServiceMethod="GetCompletionList" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                CompletionListHighlightedItemCssClass="AutoExtenderHighlight">
            </ajax:AutoCompleteExtender>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Title" runat="Server">
    Company Master
    <asp:UpdatePanel ID="Upp" runat="server">
        <ContentTemplate>
            <table width="90%">
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
    <asp:UpdatePanel ID="AjaxPanelUpdateEntry" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td>
                        <fieldset id="fieldset1" width="100%" runat="server" class="FieldSet">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <table width="100%" cellspacing="6">
                                        <tr>
                                            <td class="Label">
                                            </td>
                                            <td>
                                                <asp:HiddenField ID="hdnFldUsedCnt" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Label" style="height: 24px">
                                                Company :
                                            </td>
                                            <td style="height: 24px">
                                                <asp:TextBox ID="txtCompany" runat="server" CssClass="TextBox" MaxLength="200" Width="350px"
                                                    TabIndex="1"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="Req1" runat="server" ControlToValidate="txtCompany"
                                                    Display="None" ErrorMessage="Enter Company Text" SetFocusOnError="True" ValidationGroup="Add">
                                                </asp:RequiredFieldValidator>
                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                                                    TargetControlID="Req1" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                                </ajax:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Label" style="height: 24px">
                                                Party Name :
                                            </td>
                                            <td style="height: 24px">
                                                <asp:TextBox ID="txtPartyName" runat="server" CssClass="TextBox" MaxLength="200"
                                                    Width="350px" TabIndex="1">

                                                </asp:TextBox>
                                                <asp:HiddenField ID="hdnValue" runat="server" />
                                               <%-- <asp:RequiredFieldValidator ID="Req_BuildingName" runat="server" ControlToValidate="txtPartyName"
                                                    Display="None" ErrorMessage="Party Name is Required" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                                    TargetControlID="Req_BuildingName" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                                </ajax:ValidatorCalloutExtender>--%>
                                                <ajax:AutoCompleteExtender ID="ACE1" runat="server" TargetControlID="txtPartyName"
                                                    CompletionInterval="100" UseContextKey="True" FirstRowSelected="true" ShowOnlyCurrentWordInCompletionListItem="true"
                                                    ServiceMethod="GetCompletionListParty" CompletionListCssClass="AutoExtender"
                                                    CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                    OnClientItemSelected="OnContactSelected" MinimumPrefixLength="1">
                                                </ajax:AutoCompleteExtender>
                                                <asp:ImageButton ID="ImgAddParty" runat="server" ImageUrl="~/Images/Icon/Gridadd.png"
                                                    ToolTip="Add To Grid" TabIndex="1" ValidationGroup="Add" OnClick="ImgAddPartyClick" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:GridView ID="GrdCompanyParty" runat="server" AllowPaging="True" AlternatingRowStyle-CssClass="alt"
                                                    AutoGenerateColumns="False" CssClass="mGrid" GridLines="None" PagerStyle-CssClass="pgr" OnRowCommand="GrdCompanyParty_RowCommand" OnRowDeleting="GrdCompanyParty_RowDeleting"
                                                    Width="70%">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <%--<asp:CheckBox ID="GrdSelectAllHeader" runat="server" AutoPostBack="true" />--%>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkLogo" runat="server" Checked="True" Visible="false" />
                                                                <asp:ImageButton ID="ImgEditLogo" runat="server" CausesValidation="false" CommandArgument="<%#((GridViewRow)Container).RowIndex %>"
                                                                    CommandName="Select" ImageUrl="~/Images/Icon/GridEdit.png" ToolTip="Edit" TabIndex="1" />
                                                                <asp:ImageButton ID="ImgDeleteLogo" runat="server" CommandArgument="<%#((GridViewRow)Container).RowIndex %>"
                                                                    CommandName="Delete" OnClientClick="DeleteEquipFunction();" ImageUrl="~/Images/Icon/GridDelete.png"
                                                                    ToolTip="Delete" TabIndex="1" />
                                                                <ajax:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" ConfirmText="Would You Like To Delete This Record?"
                                                                    TargetControlID="ImgDeleteLogo">
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
                                                        <asp:BoundField HeaderText="Company Party Names" DataField="CompanyType">
                                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="false" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="CompanyTypeId" DataField="CompanyTypeId">                                                      
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
                                            <td class="Label" style="height: 24px">
                                                Additional Notes :
                                            </td>
                                            <td style="height: 24px">
                                                <asp:TextBox ID="txtAdditionalNotes" runat="server" CssClass="TextBox" TextMode="MultiLine"
                                                    Width="350px" TabIndex="1"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </fieldset>
                    </td>
                </tr>
                <tr id="TrGrid" runat="server" visible="false">
                    <td>
                        <div class="scrollableDiv">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <fieldset id="fieldset2" runat="server" class="FieldSet">
                            <table width="100%">
                                <tr>
                                    <td align="center">
                                        <table align="center" width="25%">
                                            <tr>
                                                <td>
                                                    <asp:Button ID="BtnUpdate" runat="server" Text="Update" CssClass="button" ValidationGroup="Add"
                                                        OnClientClick="UpdateEquipFunction();" OnClick="BtnUpdate_Click" TabIndex="2" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="button" ValidationGroup="Add"
                                                        OnClick="BtnSave_Click" TabIndex="2" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnDelete" runat="server" Text="Delete" CssClass="button" ValidationGroup="Add"
                                                        OnClientClick="DeleteEquipFunction();" OnClick="BtnDelete_Click" TabIndex="3" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnCancel" runat="server" Text="Cancel" CssClass="button" CausesValidation="False"
                                                        OnClick="BtnCancel_Click" TabIndex="4" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ReportTitle" runat="Server">
    Company List
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Report" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <ul id="subnav">
                <%--Ul Li Problem Solved repeater--%>
                <div style="height: 500px; overflow: auto; width: 245px;">
                    <asp:Repeater ID="GrdReport" runat="server" OnItemCommand="GrdReport_ItemCommand">
                        <ItemTemplate>
                            <li id="Menuitem" runat="server">
                                <asp:LinkButton ID="lbtn_List" CssClass="linkButton" CausesValidation="false" CommandName="Select"
                                    CommandArgument='<%# Eval("#") %>' runat="server" Text='<%# Eval("Company") %>'
                                    TabIndex="6"></asp:LinkButton>
                                <asp:Label ID="lblUsedCnt" runat="server" Visible="false" Text='<%# Eval("UsedCount") %>'></asp:Label>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </ul>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
