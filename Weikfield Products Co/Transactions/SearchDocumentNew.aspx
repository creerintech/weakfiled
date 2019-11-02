<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true"
    CodeFile="SearchDocumentNew.aspx.cs" Inherits="Transactions_SearchDocumentNew"
    Title="Search Document" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SearchContent" runat="Server">
    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />

    <script type="text/javascript" language="javascript">
        function OnContactSelected(source, eventArgs) {

            var hdnValueID = "<%= hdnValue.ClientID %>";

            document.getElementById(hdnValueID).value = eventArgs.get_value();
          
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Title" runat="Server">
    Search Your Document
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="Server">
    <asp:UpdatePanel ID="uPanel" runat="server">
        <ContentTemplate>
            <fieldset id="fieldset" runat="server" class="FieldSet">
                <center>
                    <table width="80%">
                        <tr>
                            <td colspan="3">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 14px;">
                                Search Document:
                            </td>
                            <td style="width: 10px;">
                            </td>
                            <td>
                                <asp:TextBox ID="TxtSearch" runat="server" CssClass="TextBox_Search" ToolTip="Enter The Text like FileNo-FileName-ProjectName-Company-DocTitle"
                                    AutoPostBack="true" OnTextChanged="TxtSearch_TextChanged" Width="500px"></asp:TextBox>
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
                        <tr>
                            <td colspan="3" align="right">
                                <asp:ImageButton ID="imgExcel" runat="server" ImageUrl="~/Images/Icon/excel.png"
                                    OnClick="imgExcel_Click" ToolTip="Export File Document" />
                                <asp:ImageButton ID="ImgExcelDetails" runat="server" ImageUrl="~/Images/Icon/excel.png"
                                    OnClick="ImgExcelDetails_Click" ToolTip="Export File Document Details" />
                            </td>
                        </tr>
                    </table>
                </center>
            </fieldset>
            </td> </tr> </table>
            <asp:UpdatePanel ID="Content1_UpdatePanel" runat="server">
                <ContentTemplate>
                    <%--   --%>
                </ContentTemplate>
            </asp:UpdatePanel>
            <fieldset id="fieldset1" runat="server" class="FieldSet">
                <div style="overflow: scroll; width: 990px; height: 400px;">
                    <table width="100%">
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
                                                <asp:BoundField HeaderText="Company" DataField="Company">
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                </asp:BoundField>
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
                                                <asp:BoundField HeaderText="Doc Expiry Date" DataField="DocExpiryDate">
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Narration" DataField="Narration">
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                </asp:BoundField>
                                            </Columns>
                                            <EditRowStyle BackColor="#999999" />
                                            <FooterStyle CssClass="footer" />
                                            <PagerStyle CssClass="pgr" BackColor="#284775" ForeColor="White" HorizontalAlign="Left" />
                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                            <%--   <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />--%>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </div>
            </fieldset>
            <fieldset id="fieldset2" runat="server" class="FieldSet">
                <div style="overflow: scroll; width: 990px; height: 400px;">
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="GridDocDetails" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt"
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
                                                <asp:BoundField HeaderText="DocUploaded Date" DataField="DocDate">
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" CssClass="Display_None" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" CssClass="Display_None" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Document Title" DataField="DocumentTitle">
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Document Sub Title" DataField="DocumentSubTitle">
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Document Ref No" DataField="DocRefNo">
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Document Path" DataField="DocImagePath" >
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" CssClass="Display_None"/>
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" CssClass="Display_None"/>
                                                </asp:BoundField>
                                                <%--  <asp:TemplateField HeaderText="Document Path">
                                                <ItemTemplate>
                                                 <asp:LinkButton ID="DocPath" runat="server" Text='<%# Eval("DocImagePath") %>' CommandArgument='<%#((GridViewRow)Container).RowIndex %>' OnClick="DownloadFile" >                                                
                                                </asp:LinkButton>
                                                </ItemTemplate>
                                                
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="Document Path">
                                                    <ItemTemplate>
                                                        <asp:UpdatePanel ID="UpLnkButton" runat="server">
                                                            <ContentTemplate>
                                                                <asp:LinkButton ID="lblButton" runat="server"  OnClick="DownloadFile" Text='<%# Eval("DocImagePath") %>'
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
                                                <asp:BoundField HeaderText="Status" DataField="Status">
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                </asp:BoundField>
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
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="imgExcel" />
            <asp:PostBackTrigger ControlID="ImgExcelDetails" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
