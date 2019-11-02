<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true"
    CodeFile="PrintIndex.aspx.cs" Inherits="Transactions_PrintIndex" Title="Print File Index" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SearchContent" runat="Server">
    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Title" runat="Server">
    PRINT INDEX FOR FILES
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="Server">
    <asp:UpdatePanel ID="uPanel" runat="server">
        <ContentTemplate>
            <asp:UpdatePanel ID="Content1_UpdatePanel" runat="server">
                <ContentTemplate>
                    <%--   <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtSearch"
                        CompletionInterval="100" UseContextKey="True" FirstRowSelected="true" ShowOnlyCurrentWordInCompletionListItem="true"
                        ServiceMethod="GetCompletionList" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight">
                    </ajax:AutoCompleteExtender>--%>
                </ContentTemplate>
            </asp:UpdatePanel>
            <fieldset id="fieldset1" runat="server" class="FieldSet">
                <table width="100%">
                    <tr>
                        <center>
                            <td>
                                <asp:Button runat="server" ID="btnPrint" Text="Print" CssClass="Display_None" />
                            </td>
                        </center>
                    </tr>
                </table>
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
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <a href='../PrintReport/PrintRpt.aspx?ID=<%# Eval("#")%>&Flag=<%="FIndex"%>'
                                                            target="_blank">
                                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Icon/GridPrint.png" 
                                                                ToolTip="Print File Index" TabIndex="1" />
                                                        </a>
                                                        <%--<asp:ImageButton ID="ImgBtnPrint" runat="server" CausesValidation="False" CssClass="Imagebutton"
                                                    CommandArgument='<%# Eval("#") %>' CommandName="Print"
                                                    ImageUrl="~/Images/Icon/GridPrint.png" TabIndex="1" ToolTip="Print Record" />  --%>
                                                    </ItemTemplate>
                                                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="false" Width="7%" />
                                                </asp:TemplateField>
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
                                                <asp:BoundField HeaderText="File Name" DataField="FileName">
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Project Name" DataField="PropertyName">
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
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="ShelfNo" DataField="ShelfNo">
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
