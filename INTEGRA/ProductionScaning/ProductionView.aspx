<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="ProductionView.aspx.vb" Inherits="Integra.ProductionView" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                Season
            </td>
            <td>
                <asp:DropDownList ID="cmbSeason" Width="160" CssClass="combo" AutoPostBack="TRUE"
                    runat="server" Style="margin-left: 9px; height: 28px;">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td>
                <div style="width: 920px;">
                    <Smart:SmartDataGrid ID="Dgview2" Font-Size="Large" CellPadding="4" Font-Names="serif"
                        HeaderStyle-BackColor="#C6DEFF" HeaderStyle-ForeColor="black" runat="server"
                        Width="100%" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                        PageSize="1000" ShowFooter="True" Font-Bold="true" HeaderStyle-Font-Size="Large"
                        ItemStyle-ForeColor="black" ForeColor="black" GridLines="both">
                        <Columns>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="SR NO" DataField="SRNO"
                                Visible="true">
                                <HeaderStyle HorizontalAlign="center" Width="3%" Font-Size="12px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Style" DataField="Style">
                                <HeaderStyle HorizontalAlign="center" Width="2%" Font-Size="10px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Customer" DataField="CustomerName">
                                <HeaderStyle HorizontalAlign="center" Width="3%" Font-Size="10px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Color" DataField="buyerColor">
                                <HeaderStyle HorizontalAlign="center" Width="3%" Font-Size="12px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Item" DataField="ItemDesc">
                                <HeaderStyle HorizontalAlign="center" Width="2%" Font-Size="8px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Cutting Qty" DataField="CuttingQty">
                                <HeaderStyle HorizontalAlign="center" Width="2%" Font-Size="10px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Total Stitching"
                                DataField="TotalStitching">
                                <HeaderStyle HorizontalAlign="center" Width="2%" Font-Size="10px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Total Washing" DataField="TotalWashing">
                                <HeaderStyle HorizontalAlign="center" Width="2%" Font-Size="10px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" ItemStyle-ForeColor="White" HeaderText="B.In. Washing"
                                DataField="BalInWashing">
                                <HeaderStyle HorizontalAlign="center" Width="3%" BackColor="red" Font-Size="12px"
                                    ForeColor="White" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Total DDL Receiving"
                                DataField="TotalPacking">
                                <HeaderStyle HorizontalAlign="center" Width="2%" Font-Size="10px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Balance In DDL Receiving"
                                DataField="BalanceInDDL">
                                <HeaderStyle HorizontalAlign="center" Width="2%" Font-Size="10px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Total Recv Washing"
                                DataField="TotalRecvWashing">
                                <HeaderStyle HorizontalAlign="center" Width="2%" Font-Size="10px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" ItemStyle-ForeColor="White" HeaderText="B.In. Recv Washing"
                                DataField="BalanceInRecvWashing">
                                <HeaderStyle HorizontalAlign="center" Width="3%" BackColor="red" Font-Size="12px"
                                    ForeColor="White" />
                            </asp:BoundColumn>
                        </Columns>
                    </Smart:SmartDataGrid>
                </div>
            </td>
        </tr>
    </table>
    <asp:Panel ID="Pnlgmdaily" runat="server" Visible="false">
        <table width="100%">
            <tbody>
                <tr style="height: 15px">
                </tr>
                <tr class="heading">
                    <td>
                        &nbsp; <b>Today Activity </b>
                    </td>
                </tr>
                <tr style="height: 8px">
                </tr>
            </tbody>
        </table>
        <table style="border-right: #000 1px solid; border-top: #000 1px solid; border-left: #000 
                            1px solid; border-bottom: #000 1px solid" width="100%">
            <tbody>
                <tr style="border-right: #000 1px solid; border-top: #000 1px solid; border-left: #000 1px solid;
                    border-bottom: #000 1px solid">
                    <td style="font-size: 30px; background-color: lightblue">
                        <asp:Label ID="lblsH" runat="server" Text="Stitching">
                        </asp:Label>
                    </td>
                    <td>
                        <asp:Label Style="font-size: 30px; background-color: white" ID="lbls" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="border-right: #000 1px solid; border-top: #000 1px solid; border-left: #000 1px solid;
                    border-bottom: #000 1px solid">
                    <td style="font-size: 30px; background-color: lightblue">
                        <asp:Label ID="lblWH" runat="server" Text="Washing"></asp:Label>
                    </td>
                    <td>
                        <asp:Label Style="font-size: 30px; background-color: white" ID="lblW" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="border-right: #000 1px solid; border-top: #000 1px solid; border-left: #000 1px solid;
                    border-bottom: #000 1px solid">
                    <td style="font-size: 30px; background-color: lightblue">
                        <asp:Label ID="Label1" runat="server" Text="Receive Wash"></asp:Label>
                    </td>
                    <td>
                        <asp:Label Style="font-size: 30px; background-color: white" ID="lblRW" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="border-right: #000 1px solid; border-top: #000 1px solid; border-left: #000 1px solid;
                    border-bottom: #000 1px solid">
                    <td style="font-size: 30px; background-color: lightblue">
                        <asp:Label ID="lblFH" runat="server" Text="DDL Receiving"></asp:Label>
                    </td>
                    <td>
                        <asp:Label Style="font-size: 30px; background-color: white" ID="lblF" runat="server"></asp:Label>
                    </td>
                </tr>
            </tbody>
        </table>
    </asp:Panel>
    </contenttemplate> </asp:UpdatePanel> </TD></TR></TBODY></TABLE><table width="100%">
        <tbody>
            <tr>
                <td>
                    <%-- style="font-size: Large;background-color: darkgoldenrod;font-family: serif;" --%>
</asp:Content>
