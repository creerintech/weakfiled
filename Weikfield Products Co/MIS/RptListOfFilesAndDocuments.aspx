<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="RptListOfFilesAndDocuments.aspx.cs" Inherits="MIS_RptListOfFilesAndDocuments" Title="List OF Files And Documents" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SearchContent" Runat="Server">
  <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
  
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
    
     <script type="text/javascript" language="javascript">
        function OnContactSelectedFile(source, eventArgs) {

            var HdnFieldFileID = "<%= HdnFieldFile.ClientID %>";

            document.getElementById(HdnFieldFileID).value = eventArgs.get_value();
          
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Title" Runat="Server">
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
<asp:Content ID="Content3" ContentPlaceHolderID="Body" Runat="Server">
 <fieldset id="F1" class="FieldSet" runat="server">
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
                                    <td class="Label" style="width: 150px">
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
                             <asp:HiddenField ID="HdnFieldFile" runat="server" />
                                        <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtFileName"
                                            CompletionInterval="100" UseContextKey="True" FirstRowSelected="true" ShowOnlyCurrentWordInCompletionListItem="true"
                                            ServiceMethod="GetCompletionListFile" CompletionListCssClass="AutoExtender"
                                            CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                            OnClientItemSelected="OnContactSelectedFile" MinimumPrefixLength="1">
                                        </ajax:AutoCompleteExtender>
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
                                        <asp:TextBox ID="txtDocSubTitle" runat="server" CssClass="TextBox" TabIndex="1" Width="250px"
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
                                        <asp:TextBox ID="txtSelectDoc" runat="server" CssClass="TextBox" TabIndex="1" Width="250px"
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
    <fieldset id="FieldSet" class="FieldSet" runat="server">
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
                                                        ValidationGroup="Add" OnClick="BtnShow_Click" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnPrint" runat="server" CssClass="Display_None" TabIndex="42" Text="Print"
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
    
    <fieldset id="fieldset1" runat="server" class="FieldSet">
                <div style="overflow: scroll; width: 990px; height: 400px;">
                    <table width="100%">
                      <tr>
                        <td align="center">
                            <asp:Label ID="LblRecordCount" runat="server" CssClass="Label"></asp:Label>
                        </td>
                    </tr>
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel_GrdReport" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="GrdReport" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                            AutoGenerateColumns="False" GridLines="Both" PagerStyle-CssClass="pgr" CellPadding="5"
                                            CellSpacing="5" Width="98%" PageSize="20" CssClass="mGridNew" TabIndex="16" AllowSorting="True"
                                            ForeColor="#333333" DataKeyNames="#">
                                            <RowStyle BackColor="white" Font-Bold="true" Font-Size="13px" Height="25px" ForeColor="#333333" />
                                            <HeaderStyle Font-Size="15px" Height="30px" VerticalAlign="Middle" ForeColor="White" />
                                            <AlternatingRowStyle BackColor="LightGray" CssClass="alt" ForeColor="Black" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Srl">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblSrNo" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" Width="6%" />
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Doc Date" DataField="DocDate">
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="File No" DataField="FileNo">
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="FileName" DataField="FileName">
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Project" DataField="PropertyName">
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                </asp:BoundField>
                                                <%--<asp:BoundField HeaderText="Company" DataField="Company">
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                </asp:BoundField>--%>
                                                <asp:BoundField HeaderText="Barcode" DataField="Barcode">
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Room" DataField="Room">
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Aisle" DataField="Aisle">
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Shelf No" DataField="ShelfNo">
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Doc Date" DataField="DocDate">
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                </asp:BoundField>
                                                <%--<asp:BoundField HeaderText="Doc Expiry Date" DataField="DocExpiryDate">
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Narration" DataField="Narration">
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                </asp:BoundField>--%>
                                                 <asp:TemplateField HeaderText="ShowFileDetails">
                                            <ItemTemplate>
                                                <asp:UpdatePanel ID="UpLnkButton" runat="server">
                                                    <ContentTemplate>
                                                        <asp:LinkButton ID="lblButton" runat="server" Text="ShowFileDetails" OnClick="DownloadFile"
                                                            TabIndex="1" CommandArgument='<%# Eval("#") %>' OnClientClick="aspnetForm.target ='_blank';"></asp:LinkButton>
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
                                            <EditRowStyle BackColor="#999999" />
                                            <FooterStyle CssClass="footer" />
                                            <PagerStyle CssClass="pgr" BackColor="#284775" ForeColor="White" HorizontalAlign="Left" />
                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />                                            
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </div>
            </fieldset>
</asp:Content>

