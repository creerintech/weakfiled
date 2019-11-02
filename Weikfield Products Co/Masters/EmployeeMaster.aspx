<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage_RN.master" AutoEventWireup="true"
    CodeFile="EmployeeMaster.aspx.cs" Inherits="Masters_EmployeeMaster" Title="Employee Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SearchContent" Runat="Server">
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

        var value = document.getElementById('<%=txtEmpName.ClientID%>').value;

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

        var value = document.getElementById('<%=txtEmpName.ClientID%>').value;

        if (value == "") {
            document.getElementById('<%= hiddenbox.ClientID%>').value = "1";
        }
        else {
            if (confirm("Would You like To Delete The Record ?") == true) {
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
            <div style="text-align:right; margin-right:10px;">Search for Department :
            <asp:TextBox ID="txtSearch" runat="server" CssClass="search" ToolTip="Enter The Text"
                Width="292px" AutoPostBack="True"
                TabIndex="1"></asp:TextBox>
            <div id="divwidth">
            </div>
            <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtSearch"
                CompletionInterval="100" UseContextKey="True" FirstRowSelected="true" ShowOnlyCurrentWordInCompletionListItem="true"
                ServiceMethod="GetCompletionList" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                CompletionListHighlightedItemCssClass="AutoExtenderHighlight">
            </ajax:AutoCompleteExtender></div>
            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Title" Runat="Server">
 Employee Master 
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
<asp:Content ID="Content3" ContentPlaceHolderID="Body" Runat="Server">
   <asp:UpdatePanel ID="AjaxPanelUpdateEntry" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td>
                        <fieldset id="fieldset1" width="100%" runat="server" class="FieldSet">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <table cellspacing="6px" style="background-color: #FFFAF0" width="100%">
                    <tr>
                        <td class="Label">
                            Code :
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtEmpCode" runat="server" CssClass="TextBox" MaxLength="15" Width="439px"
                                TabIndex="1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Label">
                            Name :
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtEmpName" runat="server" CssClass="TextBox" Width="439px" TabIndex="1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="Req_Name" runat="server" ControlToValidate="txtEmpName"
                                Display="None" ErrorMessage=" Name is  Required" SetFocusOnError="True" ValidationGroup="Add"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="VCE_Name" runat="server" Enabled="True" TargetControlID="Req_Name"
                                WarningIconImageUrl="~/Images/Icon/Warning.png">
                            </ajax:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="Label">
                            Address :
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="TxtAddress" runat="server" CssClass="TextBox" TextMode="MultiLine"
                                Width="439px" TabIndex="1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Label">
                            Tel(1) :
                        </td>
                        <td width=" 189px">
                            <asp:TextBox ID="TxtTel1" runat="server" CssClass="TextBox" MaxLength="15" TabIndex="1"></asp:TextBox>
                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom,Numbers"
                                TargetControlID="TxtTel1" ValidChars="-">
                            </ajax:FilteredTextBoxExtender>
                            <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" Enabled="False"
                                TargetControlID="TxtTel1">
                            </ajax:TextBoxWatermarkExtender>
                        </td>
                        <td class="Label" width="12%">
                            Tel(2) :
                        </td>
                        <td>
                            <asp:TextBox ID="TxtTel2" runat="server" CssClass="TextBox" MaxLength="15" TabIndex="1"></asp:TextBox>
                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Custom,Numbers"
                                TargetControlID="TxtTel2" ValidChars="-">
                            </ajax:FilteredTextBoxExtender>
                            <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" Enabled="False"
                                TargetControlID="TxtTel2">
                            </ajax:TextBoxWatermarkExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="Label">
                            Mobile :
                        </td>
                        <td width=" 189px">
                            <asp:TextBox ID="TxtMobile" runat="server" CssClass="TextBox" MaxLength="70" TabIndex="1"></asp:TextBox>
                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom,Numbers"
                                TargetControlID="TxtMobile" ValidChars="+">
                            </ajax:FilteredTextBoxExtender>
                            <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" Enabled="False"
                                TargetControlID="TxtMobile">
                            </ajax:TextBoxWatermarkExtender>
                        </td>
                        <td class="Label">
                            DOB :
                        </td>
                        <td>
                            <asp:TextBox ID="txtDOB" runat="server" CssClass="TextBox" TabIndex="1"></asp:TextBox>
                            <ajax:CalendarExtender ID="CalDOB" runat="server" Format="dd/MMM/yyyy" TargetControlID="txtDOB"
                                PopupButtonID="Img_DOB" />
                            <asp:ImageButton ID="Img_DOB" runat="server" ImageUrl="~/Images/Icon/DateSelector.png"
                                CausesValidation="False" CssClass="Imagebutton" TabIndex="1" />
                        </td>
                    </tr>
                    <tr>
                        <td class="Label">
                            Email :
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="TxtEmail" runat="server" CssClass="TextBox" Width="439px" TabIndex="1"
                                MaxLength="70"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="Reg" runat="server" ControlToValidate="TxtEmail"
                                Display="None" ErrorMessage="Enter valid email address!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                            </asp:RegularExpressionValidator>
                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                TargetControlID="Reg" WarningIconImageUrl="~/Images/Icon/Warning.png">
                            </ajax:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="Label">
                            City :
                        </td>
                        <td width=" 189px">
                            <asp:TextBox ID="TxtCity" runat="server" CssClass="TextBox" TabIndex="1"></asp:TextBox>
                        </td>
                        <td class="Label">
                            State :
                        </td>
                        <td>
                            <asp:TextBox ID="TxtState" runat="server" CssClass="TextBox" TabIndex="1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Label">
                            Pin Code :
                        </td>
                        <td>
                            <asp:TextBox ID="TxtPinCode" runat="server" CssClass="TextBox" TabIndex="1"></asp:TextBox>
                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" FilterType="Numbers"
                                TargetControlID="TxtPinCode">
                            </ajax:FilteredTextBoxExtender>
                        </td>
                        <td class="Label" nowrap="nowrap">
                            Employed On :
                        </td>
                        <td>
                            <asp:TextBox ID="txtDOJ" runat="server" CssClass="TextBox" TabIndex="1"></asp:TextBox>
                            <ajax:CalendarExtender ID="Cal_DOJ" runat="server" Format="dd/MMM/yyyy" TargetControlID="txtDOJ"
                                PopupButtonID="Img_DOJ" />
                            <asp:ImageButton ID="Img_DOJ" runat="server" ImageUrl="~/Images/Icon/DateSelector.png"
                                CausesValidation="False" CssClass="Imagebutton" TabIndex="1" />
                        </td>
                    </tr>
                    <tr>
                        <td class="Label">
                            Notes :
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="TxtNotes" runat="server" CssClass="TextBox" TextMode="MultiLine"
                                Width="439px" TabIndex="1"></asp:TextBox>
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
                                                        
                                                        TabIndex="1" OnClick="BtnUpdate_Click" OnClientClick="UpdateEquipFunction();"/>
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="button" ValidationGroup="Add"
                                                         TabIndex="1" OnClick="BtnSave_Click" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnDelete" runat="server" Text="Delete" CssClass="button" ValidationGroup="Add"
                                                        OnClientClick="DeleteEquipFunction();"
                                                        TabIndex="1" OnClick="BtnDelete_Click"/>
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnCancel" runat="server" Text="Cancel" CssClass="button" CausesValidation="False"
                                                        TabIndex="1" OnClick="BtnCancel_Click" />
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
<asp:Content ID="Content4" ContentPlaceHolderID="ReportTitle" Runat="Server">
  Employee List  
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Report" Runat="Server">
   <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <ul id="subnav">
                <%--Ul Li Problem Solved repeater--%>
                <asp:Repeater ID="GrdReport" runat="server" OnItemCommand="GrdReport_ItemCommand">
                    <ItemTemplate>
                        <li id="Menuitem" runat="server">
                            <asp:LinkButton ID="lbtn_List" CssClass="linkButton" CausesValidation="false" CommandName="Select"
                                CommandArgument='<%# Eval("#") %>' runat="server" Text='<%# Eval("Name") %>' TabIndex="1"></asp:LinkButton>
                               
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>