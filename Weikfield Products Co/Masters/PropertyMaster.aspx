<%@ Page Title="Project Master" Language="C#" MasterPageFile="~/MasterPages/MasterPage_RN.master" AutoEventWireup="true" CodeFile="PropertyMaster.aspx.cs" Inherits="Masters_PropertyMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SearchContent" runat="Server">
    <input type="hidden" id="hiddenbox" runat="server" value="" />
      <style type="text/css">
        .modalPopup {
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

            var value = document.getElementById('<%=txtProjectname.ClientID%>').value;

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

            var value = document.getElementById('<%=txtProjectname.ClientID%>').value;

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
            <div style="text-align: right; margin-right: 5px;">
                Search for Property :
            <asp:TextBox ID="TxtSearch" runat="server" CssClass="search" ToolTip="Enter The Text"
                Width="292px" AutoPostBack="True" OnTextChanged="TxtSearch_TextChanged"
                TabIndex="1"></asp:TextBox>
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
    Project Master 
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
                                    <td class="Label"></td>
                                    <td align="left">
                                        <asp:HiddenField ID="hdnFldUsedCnt" runat="server" />
                                    </td>
                                    <td></td>
                                </tr>
                                
                                
                                  <tr>
                                    <td class="Label">Project Name :
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtProjectname" runat="server" TextMode="MultiLine" CssClass="TextBox"  
                                            Width="500px" TabIndex="1"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="ReqPropertyName" runat="server" ControlToValidate="txtProjectname"
                                            Display="None" ErrorMessage="Property Name Is Required" SetFocusOnError="True"
                                            ValidationGroup="Add">
                                        </asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" Enabled="True"
                                            TargetControlID="ReqPropertyName" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                        </ajax:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                               <tr>
                                    <td class="Label">Address :
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtAddress" runat="server" CssClass="TextBox" TextMode="MultiLine"
                                            Width="500px" TabIndex="1"></asp:TextBox>
                                    </td>
                                    <td>
                                       
                                    </td>
                                </tr>
                                 <tr >
                                    <td class="Label">Select Company :
                                    </td>
                                    <td align="left">
                                       <%-- <asp:DropDownList ID="ddlOwner" runat="server" CssClass="ComboBox" Width="370px" OnSelectedIndexChanged="ddlOwner_SelectedIndexChanged" AutoPostBack="true"
                                            TabIndex="1">
                                        </asp:DropDownList>--%>
                                          <asp:DropDownCheckBoxes ID="ddlCompany" runat="server" AddJQueryReference="True" AutoPostBack="true"
                                            CssClass="ComboBox" UseButtons="True" UseSelectAllNode="True" TabIndex="1"  OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged">
                                      <%--  <Style SelectBoxWidth="500" DropDownBoxBoxWidth="500" DropDownBoxBoxHeight="120" />--%>
                                            <Texts SelectBoxCaption="-----Select Company-----" />
                                        </asp:DropDownCheckBoxes>
                                    </td>
                                    <td>
                                     
                                    </td>
                                </tr>
                                 <tr>
                                    <td></td>
                                    
                                    <td>
                                        <asp:Label ID="lbl1" Font-Names="Verdana" Text="Note : User can select multiple Company..." runat="server"></asp:Label>
                                    </td>
                                     <td ></td>
                                </tr>
                                 <tr>
                                    <td>                                       
                                    </td>
                                 
                                    <td>
                                        <div  style="background-color:darkgray; width:505px; text-align:center; height:22px;">
                                            
                                            <table width="100%" >
                                                <tr>
                                                    <td style="height:22px; vertical-align:central">
                                                          <asp:Label ID="lbl222" Text=" Selected Company(s) : " Font-Size="12px" Font-Bold="true"  runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                     
                                            </div>
                                    </td>
                                      <td></td>
                                </tr>                              
                                 <tr>
                                    <td>                                      
                                    </td>                                   
                                    <td>
                                        <div style="min-height:100px;max-height:150px;overflow:scroll; text-align:center; width:500px;border:2px ridge black;">
                                           <%--  <asp:Label ID="lbl22" Text=" Selected Party(s) : " Font-Size="12px"  runat="server"></asp:Label><br />--%>
                                        <asp:Label ID="lblCompanyName" Font-Names="Verdana" Text="" Font-Size="12px" runat="server"></asp:Label>
                                            </div>
                                    </td>
                                       <td></td>
                                </tr>
                                              
                                 <tr >
                                    <td class="Label">Select Party :
                                    </td>
                                    <td align="left">
                                       <%-- <asp:DropDownList ID="ddlOwner" runat="server" CssClass="ComboBox" Width="370px" OnSelectedIndexChanged="ddlOwner_SelectedIndexChanged" AutoPostBack="true"
                                            TabIndex="1">
                                        </asp:DropDownList>--%>
                                          <asp:DropDownCheckBoxes ID="ddlParty" runat="server" AddJQueryReference="True" AutoPostBack="true"
                                            CssClass="ComboBox" UseButtons="True" UseSelectAllNode="True" TabIndex="1" OnSelectedIndexChanged="ddlParty_SelectedIndexChanged" >
                                      <%--  <Style SelectBoxWidth="500" DropDownBoxBoxWidth="500" DropDownBoxBoxHeight="120" />--%>
                                            <Texts SelectBoxCaption="-----Select Party-----" />
                                        </asp:DropDownCheckBoxes>
                                    </td>
                                    <td>
                                     
                                    </td>
                                     <tr>
                                      <tr>
                                    <td>                                       
                                    </td>
                                 
                                    <td >
                                        <div  style="background-color:darkgray; width:505px; text-align:center; height:22px;">
                                            
                                            <table width="100%" >
                                                <tr>
                                                    <td style="height:22px; vertical-align:central">
                                                          <asp:Label ID="lblComp" Text=" Selected Party(s) : " Font-Size="12px" Font-Bold="true"  runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                     
                                            </div>
                                    </td>
                                      <td></td>
                                </tr>
                                    <td></td>
                                    
                                    <td>
                                        <asp:Label ID="lbl3" Font-Names="Verdana" Text="Note : User can select multiple Party..." runat="server"></asp:Label>
                                    </td>
                                     <td ></td>
                                </tr>
                                </tr>
                                 
                                 <tr>
                                    <td>                                      
                                    </td>                                   
                                    <td>
                                        <div style="min-height:100px;max-height:150px;overflow:scroll; text-align:center; width:500px;border:2px ridge black;">
                                           <%--  <asp:Label ID="lbl22" Text=" Selected Party(s) : " Font-Size="12px"  runat="server"></asp:Label><br />--%>
                                        <asp:Label ID="lblPartyName" Font-Names="Verdana" Text="" Font-Size="12px" runat="server"></asp:Label>
                                            </div>
                                    </td>
                                       <td></td>
                                </tr>
                                  <tr>
                                    <td height="10px"></td>
                                </tr>

                               
                              
                               <%--<tr>
                                    <td class="Label">Description :
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtPropertyDesc" runat="server" CssClass="TextBox" TextMode="MultiLine"
                                           Width="500px" TabIndex="2"></asp:TextBox>
                                    </td>
                                    <td>
                                      
                                    </td>
                                </tr>--%>
                              
                                <tr>
                                    <td class="Label"></td>
                                    <td align="left"></td>
                                    <td></td>
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
                                                        OnClientClick="UpdateEquipFunction();" OnClick="BtnUpdate_Click" TabIndex="1" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="button" TabIndex="1"
                                                        ValidationGroup="Add" OnClick="BtnSave_Click" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnDelete" runat="server" Text="Delete" CssClass="button" ValidationGroup="Add"
                                                        OnClientClick="DeleteEquipFunction();" OnClick="BtnDelete_Click" TabIndex="1" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnCancel" runat="server" Text="Cancel" CssClass="button" CausesValidation="False"
                                                        OnClick="BtnCancel_Click" TabIndex="1" />
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
   Project List 
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
                                CommandArgument='<%# Eval("#") %>' runat="server" Text='<%# Eval("PropertyName") %>' TabIndex="1"></asp:LinkButton>
                            <asp:Label ID="lblUsedCnt" runat="server" Visible="false" Text='<%# Eval("UsedCount") %>'></asp:Label>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
