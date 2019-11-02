<%@ Page Title="Aisle Master" Language="C#" MasterPageFile="~/MasterPages/MasterPage_RN.master"
    AutoEventWireup="true" CodeFile="AisleMaster.aspx.cs" Inherits="Masters_AisleMaster" %>

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

            var value = document.getElementById('<%=txtAisle.ClientID%>').value;

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

            var value = document.getElementById('<%=txtAisle.ClientID%>').value;

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

    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="text-align: right; margin-right: 10px;">
                Search for Aisle :
                <asp:TextBox ID="TxtSearch" runat="server" CssClass="search" ToolTip="Enter The Text"
                    Width="292px" AutoPostBack="True" TabIndex="6"></asp:TextBox>
                <div id="divwidth">
                </div>
                <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtSearch"
                    CompletionInterval="100" UseContextKey="True" FirstRowSelected="true" ShowOnlyCurrentWordInCompletionListItem="true"
                    ServiceMethod="GetCompletionList" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight">
                </ajax:AutoCompleteExtender>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Title" runat="Server">
    Aisle Master
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
            <%--<table style="width: 100%">
                <tr>
                    <td align="center">
                        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                            <ProgressTemplate>
                                <div id="progressBackgroundFilter">
                                </div>
                                <div id="processMessage">
                                    <center>
                                        <span class="SubTitle">Loading....!!! </span>
                                    </center>
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/Icon/updateprogress.gif" />
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </td>
                </tr>
            </table>--%>
            <table width="100%">
                <tr>
                    <td>
                        <fieldset id="fieldset" runat="server" class="FieldSet">
                            <table width="100%" cellspacing="6">
                                <tr>
                                    <td class="Label">
                                    </td>
                                    <td align="left">
                                        <asp:HiddenField ID="hdnFldUsedCnt" runat="server" />
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Label">
                                        Select Room :
                                    </td>
                                    <td align="left">
                                       <asp:DropDownList ID="ddlRoomList" runat="server" Width="370px" AutoPostBack="true"
                                            OnSelectedIndexChanged="ddlddlRoomList_SelectedIndexChanged" CssClass="ComboBox"
                                            TabIndex="1">
                                        </asp:DropDownList>
                                       <%-- <asp:RequiredFieldValidator ID="ReqddlDept" runat="server" ControlToValidate="ddlDocumentList"
                                            InitialValue="0" Display="None" ErrorMessage="Select Document List" SetFocusOnError="True"
                                            ValidationGroup="Add">
                                        </asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True"
                                            TargetControlID="ReqddlDept" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                        </ajax:ValidatorCalloutExtender>--%>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="ReqddlRooms" runat="server" ControlToValidate="ddlRoomList"
                                            Display="None" ErrorMessage="Aisle Is Required" SetFocusOnError="True" ValidationGroup="Add">
                                        </asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                            TargetControlID="ReqddlRooms" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                        </ajax:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Label">
                                        Aisle :
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtAisle" runat="server" CssClass="TextBox" Height="18px" MaxLength="200"
                                            Width="370px" TabIndex="2"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="ReqAisle" runat="server" ControlToValidate="txtAisle"
                                            Display="None" ErrorMessage="Aisle Is Required" SetFocusOnError="True" ValidationGroup="Add">
                                        </asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                                            TargetControlID="ReqAisle" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                        </ajax:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Label">
                                    </td>
                                    <td align="left">
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                </tr>
                <tr>
                    <td>
                        <fieldset id="fieldset1" runat="server" class="FieldSet">
                            <table width="100%">
                                <tr>
                                    <td align="center">
                                        <table align="center" width="25%">
                                            <tr>
                                                <td>
                                                    <asp:Button ID="BtnUpdate" runat="server" Text="Update" CssClass="button" ValidationGroup="Add"
                                                        OnClientClick="UpdateEquipFunction();" OnClick="BtnUpdate_Click" TabIndex="3" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="button" TabIndex="3"
                                                        ValidationGroup="Add" OnClick="BtnSave_Click" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnDelete" runat="server" Text="Delete" CssClass="button" ValidationGroup="Add"
                                                        OnClientClick="DeleteEquipFunction();" OnClick="BtnDelete_Click" TabIndex="4" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnCancel" runat="server" Text="Cancel" CssClass="button" CausesValidation="False"
                                                        OnClick="BtnCancel_Click" TabIndex="5" />
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
    Aisle List
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Report" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <ul id="subnav">
                <%--Ul Li Problem Solved repeater--%>
                <asp:Repeater ID="GrdReport" runat="server" OnItemCommand="GrdReport_ItemCommand">
                    <ItemTemplate>
                        <li id="Menuitem" runat="server">
                            <asp:LinkButton ID="lbtn_List" CssClass="linkButton" CausesValidation="false" CommandName="Select"
                                CommandArgument='<%# Eval("#") %>' runat="server" Text='<%# Eval("Name") %>'
                                TabIndex="6"></asp:LinkButton>
                            <asp:Label ID="lblUsedCnt" runat="server" Visible="false" Text='<%# Eval("UsedCount") %>'></asp:Label>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
