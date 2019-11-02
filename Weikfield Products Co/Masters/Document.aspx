<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage_RN.master" AutoEventWireup="true" CodeFile="Document.aspx.cs" Inherits="Masters_Document" Title="Document Master" %>
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

            var value = document.getElementById('<%=txtDocument.ClientID%>').value;

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

            var value = document.getElementById('<%=txtDocument.ClientID%>').value;

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
            <div style="text-align:right; margin-right:10px;">Search for Document :
            <asp:TextBox ID="TxtSearch" runat="server" CssClass="search" ToolTip="Enter The Text"
                Width="292px" AutoPostBack="True"  OnTextChanged="TxtSearch_TextChanged"
                TabIndex="1"></asp:TextBox>
            <div id="divwidth">
            </div>
            <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtSearch"
                CompletionInterval="100" UseContextKey="True" FirstRowSelected="true" ShowOnlyCurrentWordInCompletionListItem="true"
                ServiceMethod="GetCompletionList" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                CompletionListHighlightedItemCssClass="AutoExtenderHighlight">
            </ajax:AutoCompleteExtender></div>
            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Title" Runat="Server">
Document Title and Sub Title
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
                                    <table width="100%" cellspacing="6">
                                        <tr>
                                            <td class="Label">
                                            </td>
                                            <td><asp:HiddenField ID="hdnFldUsedCnt" runat="server" />
                                            </td>
                                        </tr>
                                         <tr>
                                    <td class="Label">
                                      Select Department :
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="ComboBox" Width="370px" AutoPostBack="true"
                                            TabIndex="1" >
                                        </asp:DropDownList>
                                    </td>
                                    </tr>
                                        <tr>
                                            <td class="Label" style="height: 24px">
                                                Document Title:
                                            </td>
                                            <td style="height: 24px">
                                                <asp:TextBox ID="txtDocument" runat="server" CssClass="TextBox" MaxLength="200" Width="370px" TabIndex="1"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="Req1" runat="server" ControlToValidate="txtDocument"
                                                    Display="None" ErrorMessage="Enter Document Title" SetFocusOnError="True" ValidationGroup="Add">
                                                </asp:RequiredFieldValidator>
                                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True"
                                                    TargetControlID="Req1" WarningIconImageUrl="~/Images/Icon/Warning.png">
                                                </ajax:ValidatorCalloutExtender>
                                              
                                            </td>
                                        </tr>
                                        <tr>
                                        
                                         <td class="Label" style="height: 24px">
                                                Document Sub Title:
                                            </td>
                                            <td style="height: 24px">
                                                <asp:TextBox ID="txtSubTitle" runat="server" CssClass="TextBox" MaxLength="200" Width="370px" TabIndex="1"></asp:TextBox>
                                                   <asp:ImageButton ID="ImgAddDocument" runat="server" ToolTip="Add DocumentSubTitle" ImageUrl="~/Images/Icon/Gridadd.png"  TabIndex="1" OnClick="ImgAddDocument_Click" />
                                                
                                              
                                            </td>
                                            <td>
                                      
                                            </td>
                                       
                                        </tr>
                                        <tr>
                                        <td>&nbsp;</td></tr>
                                         <tr>
                                        <td colspan="2">
                                       
                                                            <div class="scrollableDiv1">
                                        <asp:GridView ID="GrdDocument" runat="server" AllowPaging="false"
                                    AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" CssClass="mGrid"
                                    GridLines="None"
                                    PagerStyle-CssClass="pgr" Width="100%"
                                    OnRowCommand="GrdDocument_RowCommand" OnRowDeleting="GrdDocument_RowDeleting"  TabIndex="1">
                                       <%-- <asp:GridView ID="GrdDocument" runat="server" AllowPaging="True" AlternatingRowStyle-CssClass="alt"
                                            AutoGenerateColumns="False" CssClass="mGrid" GridLines="None" PagerStyle-CssClass="pgr" DataKeyNames="UsedCount,#"
                                            Width="100%" OnRowCommand="GrdDocument_RowCommand" OnRowDeleting="GrdDocument_RowDeleting" OnPageIndexChanging="GrdDocument_PageIndexChanging"  >
--%>
                                          <%--  <SortedAscendingHeaderStyle BackColor="Blue" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="LightBlue" />
                                            <SortedDescendingHeaderStyle BackColor="Green" ForeColor="White" />
                                            <SortedDescendingCellStyle BackColor="LightGreen" />--%>

                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                      <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CssClass="Imagebutton"
                                                                CommandArgument="<%#((GridViewRow)Container).RowIndex %>" CommandName="Select"
                                                                ImageUrl="~/Images/Icon/GridEdit.png" TabIndex="1" ToolTip="Edit Record" />                                                       
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
                                                <asp:BoundField HeaderText="Document Sub Title" DataField="DocumentSubTitle">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                                </asp:BoundField>                                           
                                            </Columns>
                                            <PagerStyle CssClass="pgr" />
                                            <AlternatingRowStyle CssClass="alt" />
                                            <%--    <SelectedRowStyle BackColor="#990099" />
                                        <SortedAscendingHeaderStyle BackColor="#009900" ForeColor="#990033" />--%>
                                        </asp:GridView>
                                         </div>
                                                      
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
<asp:Content ID="Content4" ContentPlaceHolderID="ReportTitle" Runat="Server">
 Document SubTitle List  
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Report" Runat="Server">
 <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <ul id="subnav">
                <%--Ul Li Problem Solved repeater--%>
                 <div style="height: 500px; overflow: auto; width: 245px; ">
                <asp:Repeater ID="GrdReport" runat="server" OnItemCommand="GrdReport_ItemCommand">
                    <ItemTemplate>
                        <li id="Menuitem" runat="server">
                            <asp:LinkButton ID="lbtn_List" CssClass="linkButton" CausesValidation="false" CommandName="Select"
                                CommandArgument='<%# Eval("#") %>' runat="server" Text='<%# Eval("DocumentTitle") %>' TabIndex="1"></asp:LinkButton>
                                <asp:Label ID="lblUsedCnt"  runat="server" Visible="false" Text='<%# Eval("UsedCount") %>'></asp:Label>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
                 </div>
            </ul>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

