<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage_RN.master" AutoEventWireup="true"
    CodeFile="HomeNew.aspx.cs" Inherits="Masters_HomeNew" Title="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SearchContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Title" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="Server">
    <div id="sliderFrame">
      <%--  <div id="slider">
           <%-- <img src="../jsImgSlider/images/1.png" alt="" />
            <img src="../jsImgSlider/images/2.png" alt="" />
            <img src="../jsImgSlider/images/3.png" alt="" />--%>
        <%--    <img src="../jsImgSlider/images/4.jpg" alt="" />
        </div>--%>
        <div id="htmlcaption" style="display: none;">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ReportTitle" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Report" runat="Server">
    <table>
        <tr>
            <td>
                <%--<ul>
                    <li>
                        <img src="../Images/New Icon/icon1.jpeg" height="16px" width="16px" /><a href="../Transactions/FollowUpDetails.aspx"
                            class="linkButtonMenu">Today's Enquiry FollowUp</a></li>
                    <li>
                        <img src="../Images/New Icon/icon1.jpeg" height="16px" width="16px" /><a href="../Transactions/PaymentFollowUp.aspx"
                            class="linkButtonMenu">Today's Payment FollowUp</a></li>
                    <li>
                        <img src="../Images/New Icon/icon1.jpeg" height="16px" width="16px" /><a href="ProjectwiseSaleGraph.aspx"
                            class="linkButtonMenu">Projectwise Sale</a></li>
                    <li>
                        <img src="../Images/New Icon/icon1.jpeg" height="16px" width="16px" />
                        <a href="MonthwiseSaleGraph.aspx"
                            class="linkButtonMenu">Monthwise Sale</a></li>
                                         <li>
            <img src="../Images/New Icon/icon1.jpeg" height="16px" width="16px" />
            <a href="../MIS/TaskListReport.aspx" class="linkButtonMenu">Today's Task</a>
            </li>
                </ul>--%>
            </td>
        </tr>
        <tr>
            <td>
                <hr width="100%" />
            </td>
        </tr>
        <tr>
            <td id="Tr1" runat="server">
                <asp:Label runat="server" ID="LBLEMP" CssClass="Display_None" Text="Please Select Employee" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr><td>    </td></tr>
        <tr>
        <td>
        <asp:DropDownList ID="ddlEmp" runat="server" CssClass="Display_None" Width="180px" AutoPostBack="true" Visible="false"
                ></asp:DropDownList> 
        </td>
        </tr>
        <%-- <marquee direction="Up" height="300px" scrollamount="3">--%>
        <tr>
            <td>
                <div>
                    <asp:ListView ID="LstToday" runat="server" ItemPlaceholderID="itemContainer" Visible="false">
                        <LayoutTemplate>
                            <asp:PlaceHolder ID="itemContainer" runat="server" Visible="false" />
                        </LayoutTemplate>
                        <ItemTemplate>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                            <li class="LabelToday" >'<%# Eval("Total")%>'  </li>
                        </ItemTemplate>
                    </asp:ListView>
              
                </div>
            </td>
        </tr>
        <%--</marquee>--%>
    </table>
</asp:Content>
