<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="Check Outward Documents.aspx.cs" Inherits="Reports_Check_Outward_Documents" Title="Check Outward Documents" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SearchContent" Runat="Server">
<ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Title" Runat="Server">
Documnet Status Report
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
<table width="100%">
        <tr>
            <td valign="top">
                <fieldset id="fieldset1" runat="server" class="FieldSet">
                    <table>
                       
                        <tr align="center">
                         <td>                               
                            </td>
                            <td style="width: 100px">
                            </td>
                            <td class="Label" style="width: 100px">
                                As On Date:
                            </td>
                            <td>
                                <asp:TextBox ID="txtFromDate" runat="server" TabIndex="1" Width="200px" placeholder="Select From Date "></asp:TextBox>
                                <ajax:CalendarExtender ID="CalFrom_Date" runat="server" CssClass="cal_Theme1" Enabled="True"
                                    Format="dd MMM yyyy" PopupButtonID="Img_Date" TargetControlID="txtFromDate">
                                </ajax:CalendarExtender>
                                <asp:ImageButton ID="Img_Date" runat="server" CausesValidation="False" CssClass="Imagebutton"
                                    ImageUrl="~/Images/Icon/DateSelector.png" TabIndex="1" />
                            </td>
                            <td class="Label" style="width: 100px">
                               
                            </td>
                           
                            <td style="width: 100px">
                              
                            </td>
                        </tr>   
                        <tr>
                        </tr>                     
                    </table>
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
                                                                    <asp:Button ID="btnSearch" runat="server" CssClass="button" TabIndex="41" Text="Show"
                                                                        ValidationGroup="Add" OnClick="btnSearch_Click" />
                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="BtnCancel" runat="server" CssClass="button" TabIndex="43" Text="Cancel"
                                                                        ValidationGroup="Add" OnClick="btnCancel_Click" />
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
                                <asp:PostBackTrigger ControlID="BtnCancel" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </fieldset>
                    <table>
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel_GrdReport" runat="server">
                                    <ContentTemplate>
                                        <a name="Navigate">
                                            <asp:GridView ID="GrdInOutReport" runat="server" AllowPaging="True" AlternatingRowStyle-CssClass="alt"
                                                AutoGenerateColumns="False" CssClass="mGrid" GridLines="None" PagerStyle-CssClass="pgr"
                                                Width="100%" AllowSorting="true">
                                                <%--OnRowCommand="GrdReport_RowCommand" OnRowDeleting="GrdReport_RowDeleting"--%>
                                                <Columns>
                                                    <%--1--%>
                                                    <asp:TemplateField HeaderText="Sr. No.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="LblSrNo" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" Width="7%" />
                                                    </asp:TemplateField>
                                                    <%--5--%>
                                                    <asp:BoundField HeaderText="Property Name" DataField="PropertyName" SortExpression="PropertyName">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:BoundField>
                                                    <%--6--%><%--<asp:BoundField HeaderText="Company Name" DataField="Company" SortExpression="Company">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:BoundField>--%>
                                                    <%--2--%>
                                                    <asp:BoundField HeaderText="File No" DataField="FileNo" SortExpression="FileNo">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:BoundField>
                                                    <%--3--%>
                                                    <asp:BoundField HeaderText="File Name" DataField="FileName" SortExpression="FileName">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:BoundField>
                                                    <%--4--%>
                                                    <asp:BoundField HeaderText="Document Title" DataField="DocumentTitle" SortExpression="DocumentTitle">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Document SubTitle" DataField="DocumentSubTitle" SortExpression="DocumentSubTitle">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:BoundField>
                                                    <%--7--%><asp:BoundField HeaderText="Given To" DataField="Empname" SortExpression="Empname">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:BoundField>
                                                    
                                                    <%--9--%><asp:BoundField HeaderText="Outward Date" DataField="OutwardDate" SortExpression="OutwardDate"
                                                        DataFormatString="{0:dd-MM-yyyy}">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:BoundField>
                                                    <%--9--%><%--<asp:BoundField HeaderText="Given By" DataField="Empname" SortExpression="FileInDate">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:BoundField>--%>
                                                    
                                                    <%--10--%><asp:BoundField HeaderText="Outward Status" DataField="OutwardStatus" SortExpression="Status">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                    </asp:BoundField>
                                                    <%--10--%><asp:BoundField HeaderText="Outward Time" DataField="OutWardTime" SortExpression="OutWardTime" DataFormatString="{0:hh:mm}">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
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
                </fieldset>
            </td>
        </tr>
    </table>
</asp:Content>

