<%@ Page Title="Numbering View" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="NumberingView.aspx.vb" Inherits="Integra.NumberingView" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="6" align="left" style="font-family: Century Gothic; font-size: 16PX;
                font-weight: bold; color: Blue">
                <marquee>Searching Criteria For Shipment No,Season,Customer,Sr No,Brand</marquee>
            </th>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td style="width: 150px;">
                <asp:TextBox ID="txtSearch" runat="server" Visible="true" AutoPostBack="true" autocomplete="off"
                    Width="196px" Style="margin-left: 0px;"> </asp:TextBox>
                <cc1:AutoCompleteExtender runat="server" ID="AutoCompleteExtender1" TargetControlID="txtSearch"
                    ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                    CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="ShipmetView" />
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="5" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                Shipment View
            </th>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td>
                <div style="width: 920PX; overflow: scroll; height: 300PX;">
                    <Smart:SmartDataGrid ID="dgView" runat="server" Width="100%" OnSortCommand="SortByColumn"
                        OnPageIndexChanged="PageChanged" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                        CellPadding="4" CssClass="table" PageSize="1000" ShowFooter="True" ForeColor="white"
                        GridLines="both">
                        <Columns>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="JobOrderId"
                                DataField="JobOrderId" Visible="false" />
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="JoborderDetailid"
                                DataField="JoborderDetailid" Visible="false" />
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderStyle-BackColor="#F294A0" HeaderStyle-ForeColor ="Black" HeaderText="Shipment No"
                                DataField="NumberingNoo">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#F294A0" HeaderStyle-ForeColor ="Black" HeaderStyle-Width="5%" HeaderText="Season"
                                DataField="SeasonName">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderStyle-BackColor="#F294A0" HeaderStyle-ForeColor ="Black" HeaderText="Customer"
                                DataField="CustomerName">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderStyle-BackColor="#F294A0" HeaderStyle-ForeColor ="Black" HeaderText="Brand"
                                DataField="Brand">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderStyle-BackColor="#F294A0" HeaderStyle-ForeColor ="Black" HeaderText="Sr No."
                                DataField="SRNO">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderStyle-BackColor="#F294A0" HeaderStyle-ForeColor ="Black" HeaderText="Ship"
                                DataField="StyleShipmentDatee">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderStyle-BackColor="#F294A0" HeaderStyle-ForeColor ="Black" HeaderText="Style"
                                DataField="Style">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderStyle-BackColor="#F294A0" HeaderStyle-ForeColor ="Black" HeaderText="Cus.Color"
                                DataField="BuyerColor">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderStyle-BackColor="#F294A0" HeaderStyle-ForeColor ="Black" HeaderText="Quantity"
                                DataField="Quantity">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="05%" HeaderText="View" HeaderStyle-BackColor="#F294A0" HeaderStyle-ForeColor ="Black">
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkView" ToolTip="Click here to View" ImageUrl="~/Images/green.png"
                                        CommandName="View" runat="server"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                    </Smart:SmartDataGrid></div>
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="5" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                Receiving View
            </th>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td>
                <div style="width: 920PX; overflow: scroll; height: 300PX;">
                    <Smart:SmartDataGrid ID="dgViewreceiving" runat="server" Width="100%" OnSortCommand="SortByColumn"
                        OnPageIndexChanged="PageChanged" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                        CellPadding="4" CssClass="table" PageSize="1000" ShowFooter="True" ForeColor="white"
                        GridLines="both">
                        <Columns>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="NumberingFinalID"
                                DataField="NumberingFinalID" Visible="false" />
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Shipment No" HeaderStyle-BackColor="#F294A0" HeaderStyle-ForeColor ="Black"
                                DataField="NumberingNo">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Receiving No" HeaderStyle-BackColor="#F294A0" HeaderStyle-ForeColor ="Black"
                                DataField="ReceivingNo">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Receive Date" HeaderStyle-BackColor="#F294A0" HeaderStyle-ForeColor ="Black"
                                DataField="ReceiveDate">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Customer Order" HeaderStyle-BackColor="#F294A0" HeaderStyle-ForeColor ="Black"
                                DataField="CustomerPoNo">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                             <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Sr No." HeaderStyle-BackColor="#F294A0" HeaderStyle-ForeColor ="Black"
                                DataField="SRNO">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Style" HeaderStyle-BackColor="#F294A0" HeaderStyle-ForeColor ="Black"
                                DataField="Style">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Color" HeaderStyle-BackColor="#F294A0" HeaderStyle-ForeColor ="Black"
                                DataField="BuyerColor">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Qty" HeaderStyle-BackColor="#F294A0" HeaderStyle-ForeColor ="Black"
                                DataField="Qty">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Carton" HeaderStyle-BackColor="#F294A0" HeaderStyle-ForeColor ="Black"
                                DataField="Carton">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Weight" HeaderStyle-BackColor="#F294A0" HeaderStyle-ForeColor ="Black"
                                DataField="Weight">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="05%" HeaderText="Weight" HeaderStyle-BackColor="#F294A0" HeaderStyle-ForeColor ="Black">
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkWeight" ToolTip="Click here to View" ImageUrl="~/Images/green.png"
                                        CommandName="Weight" runat="server"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                    </Smart:SmartDataGrid></div>
            </td>
        </tr>
    </table>
</asp:Content>
