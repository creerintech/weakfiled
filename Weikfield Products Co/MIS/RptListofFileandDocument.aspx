<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage_RN.master" AutoEventWireup="true"
    CodeFile="RptListofFileandDocument.aspx.cs" Inherits="MIS_RptListofFileandDocument"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SearchContent" runat="Server">
    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Title" runat="Server">
    List Of File And Document
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
    <fieldset id="F1" class="FieldSetMIS" runat="server">
        <asp:UpdatePanel ID="UpPnlBody" runat="server">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td colspan="6">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <table>
                                <tr>
                                    <td class="Label" style="width: 106px">
                                        <asp:CheckBox ID="ChkDate" runat="server" CssClass="CheckBox" Text=" " AutoPostBack="True" />
                                    </td>
                                    <td class="Label">
                                        From :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFromDate" runat="server" Width="115px" TabIndex="3"></asp:TextBox>
                                        <asp:ImageButton ID="ImageFromDate" runat="server" CausesValidation="False" CssClass="Imagebutton"
                                            ImageUrl="~/Images/Icon/DateSelector.png" TabIndex="4" />&nbsp;&nbsp;
                                        <ajax:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yyyy"
                                            PopupButtonID="ImageFromDate" TargetControlID="txtFromDate" />
                                    </td>
                                    <td class="Label">
                                        To :&nbsp;
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtToDate" runat="server" Width="115px" TabIndex="5"></asp:TextBox>
                                        <asp:ImageButton ID="ImageToDate" runat="server" CausesValidation="False" CssClass="Imagebutton"
                                            ImageUrl="~/Images/Icon/DateSelector.png" TabIndex="6" />
                                        <ajax:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MMM-yyyy"
                                            PopupButtonID="ImageToDate" TargetControlID="txtToDate" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td class="Label">
                            File Name :
                        </td>
                        <td>
                            <asp:TextBox ID="txtFileName" runat="server" Width="250px" TabIndex="1"></asp:TextBox>
                        </td>
                        <td class="Label">
                        </td>
                        <td>
                        </td>
                        <td >
                        </td>
                    </tr>
                    
                     <tr>
                                    <td class="Label">
                                        Document Sub Title :
                                    </td>
                                    <td>                                        
                                        <asp:TextBox ID="txtDocSubTitle" runat="server" CssClass="TextBox" TabIndex="1" Width="50px"
                                            Height="20px" AutoPostBack="true"></asp:TextBox>
                                        <asp:HiddenField ID="hndSubTitle" runat="server" />
                                        <ajax:AutoCompleteExtender ID="ACESub" runat="server" TargetControlID="txtDocSubTitle"
                                            CompletionInterval="100" UseContextKey="True" FirstRowSelected="true" ShowOnlyCurrentWordInCompletionListItem="true"
                                            ServiceMethod="GetCompletionListSubDocuments" CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                            OnClientItemSelected="OnContactSelectedSubDoc" MinimumPrefixLength="1">
                                        </ajax:AutoCompleteExtender>
                                    </td>
                                    <td class="Label" >
                                        Select Document Title:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSelectDoc" runat="server" CssClass="TextBox" TabIndex="1" Width="50px"
                                             Height="20px" AutoPostBack="true"></asp:TextBox>
                                        <asp:HiddenField ID="hdnValue" runat="server" />
                                        <ajax:AutoCompleteExtender ID="ACE1" runat="server" TargetControlID="txtSelectDoc"
                                            CompletionInterval="100" UseContextKey="True" FirstRowSelected="true" ShowOnlyCurrentWordInCompletionListItem="true"
                                            ServiceMethod="GetCompletionListDocuments" CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                            OnClientItemSelected="OnContactSelected" MinimumPrefixLength="1">
                                        </ajax:AutoCompleteExtender>
                                    </td>
                                    
                                </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </fieldset>
    <div class="clear">
    </div>
    <fieldset id="FieldSet" class="FieldSetMIS" runat="server">
        <asp:UpdatePanel ID="UPpANLEsAVE" runat="server">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td align="center">
                            <table width="35%">
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <table align="center" width="35%">
                                            <tr>
                                                <td>
                                                    <asp:Button ID="BtnShow" runat="server" CssClass="button" TabIndex="41" Text="Show"
                                                        ValidationGroup="Add" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnPrint" runat="server" CssClass="button" TabIndex="42" Text="Print"
                                                        ValidationGroup="Add" OnClientClick="aspnetForm.target ='_blank';" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnExportDetail" runat="server" CssClass="button" TabIndex="43" Text="Export Detail"
                                                        ValidationGroup="Add" Width="120px" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnCancel" runat="server" CssClass="button" TabIndex="43" Text="Cancel"
                                                        ValidationGroup="Add" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <%--aspnetForm.target ='_blank'; dosen't work under Update panel so we use postback trigger --%>
                <asp:PostBackTrigger ControlID="BtnShow" />
                <asp:PostBackTrigger ControlID="BtnPrint" />
                <asp:PostBackTrigger ControlID="BtnExportDetail" />
                <asp:PostBackTrigger ControlID="BtnCancel" />
            </Triggers>
        </asp:UpdatePanel>
    </fieldset>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ReportTitle" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Report" runat="Server">
</asp:Content>
