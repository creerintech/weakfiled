<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true"
    Title="Check All Document Status" CodeFile="CheckAllDocumnentStatus.aspx.cs"
    Inherits="Transactions_CheckAllDocumnentStatus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SearchContent" runat="Server">
    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />

    <script type="text/javascript" language="javascript">
        function OnSerchProjSelected(source, eventArgs) {

            var hdnValueID = "<%= hdvSerchProj.ClientID %>";

            document.getElementById(hdnValueID).value = eventArgs.get_value();
          
        }
    </script>

    <script type="text/javascript" language="javascript">
        function OnSerchFileName(source, eventArgs) {

            var hdnValueID = "<%= hdvSerchFileName.ClientID %>";

            document.getElementById(hdnValueID).value = eventArgs.get_value();
          
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Title" runat="Server">
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
<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="Server">
    <table width="100%">
        <tr>
            <td valign="top">
                <fieldset id="fieldset1" runat="server" class="FieldSet">
                    <table>
                        <tr style="height: 50px">
                            <td colspan="6" align="center">
                                <asp:Label ID="lblError" runat="server" ForeColor="Red" Font-Names="Verdana" Font-Size="12px"
                                    Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                        <tr align="center">
                            <td style="width: 100px">
                            </td>
                            <td class="Label" style="width: 100px">
                                Select Property:
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtProperty" runat="server" TabIndex="1" Width="200px" placeholder="Enter Property Name"></asp:TextBox>
                                <asp:HiddenField ID="hdvSerchProj" runat="server" />
                                <ajax:AutoCompleteExtender ID="ACEProp" runat="server" TargetControlID="txtProperty"
                                    CompletionInterval="100" UseContextKey="True" FirstRowSelected="True" ShowOnlyCurrentWordInCompletionListItem="True"
                                    ServiceMethod="GetAllProjectName" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" OnClientItemSelected="OnSerchProjSelected"
                                    MinimumPrefixLength="1" DelimiterCharacters="" Enabled="True" ServicePath="">
                                </ajax:AutoCompleteExtender>
                            </td>
                            <td class="Label" style="width: 150px">
                                Select File Name :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtSearchFileName" runat="server" TabIndex="1" Width="200px" Height="20px"
                                    placeholder="Enter Filename"></asp:TextBox>
                                <asp:HiddenField ID="hdvSerchFileName" runat="server" />
                                <ajax:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" TargetControlID="txtSearchFileName"
                                    CompletionInterval="100" UseContextKey="True" FirstRowSelected="True" ShowOnlyCurrentWordInCompletionListItem="True"
                                    ServiceMethod="GetFileFormatedFileName" CompletionListCssClass="AutoExtender"
                                    CompletionListItemCssClass="AutoExtenderList" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                    OnClientItemSelected="OnSerchFileName" MinimumPrefixLength="1" DelimiterCharacters=""
                                    Enabled="True" ServicePath="">
                                </ajax:AutoCompleteExtender>
                            </td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        <tr align="center">
                            <td style="width: 100px">
                            </td>
                            <td class="Label" style="width: 100px">
                                From Date:
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
                                To Date :
                            </td>
                            <td>
                                <asp:TextBox ID="txtTodate" runat="server" TabIndex="1" Width="200px" placeholder="Select From Todate "></asp:TextBox>
                                <ajax:CalendarExtender ID="CalTo_Date" runat="server" CssClass="cal_Theme1" Enabled="True"
                                    Format="dd MMM yyyy" PopupButtonID="Img_TodateDate" TargetControlID="txtTodate">
                                </ajax:CalendarExtender>
                                <asp:ImageButton ID="Img_TodateDate" runat="server" CausesValidation="False" CssClass="Imagebutton"
                                    ImageUrl="~/Images/Icon/DateSelector.png" TabIndex="1" />
                            </td>
                        </tr>
                        <tr style="height: 50px">
                            <td colspan="6" align="center">
                            </td>
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
                                            <div style="overflow: scroll; width: 940px">
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
                                                        <asp:BoundField HeaderText="Property Name" DataField="PropertyName" SortExpression="PropertyName">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                        </asp:BoundField>
                                                        <%--4--%>
                                                        <asp:BoundField HeaderText="Document Title" DataField="DocumentTitle" SortExpression="DocumentTitle">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Document Sub Title" DataField="DocumentSubTitle" SortExpression="DocumentSubTitle">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                        </asp:BoundField>
                                                        <%--7--%><asp:BoundField HeaderText="Given To" DataField="UserGivenToId" SortExpression="Empname">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                        </asp:BoundField>
                                                        <%--8--%><asp:BoundField HeaderText="Given By" DataField="UserGivenById" SortExpression="Empname">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                        </asp:BoundField>
                                                        <%--10--%><asp:BoundField HeaderText="Outward Status" DataField="OutwardStatus" SortExpression="Status">
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
                                                        <%--10--%><asp:BoundField HeaderText="Inward Status" DataField="InwardStatus" SortExpression="Status">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                        </asp:BoundField>
                                                        <%--9--%><asp:BoundField HeaderText="Inword Date" DataField="InwardDate" SortExpression="InwardDate"
                                                            DataFormatString="{0:dd-MM-yyyy}">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <PagerStyle CssClass="pgr" />
                                                    <AlternatingRowStyle CssClass="alt" />
                                                </asp:GridView>
                                            </div>
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
