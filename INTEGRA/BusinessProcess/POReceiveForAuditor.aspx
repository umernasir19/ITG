<%@ Page Title="PO Receive" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="POReceiveForAuditor.aspx.vb" Inherits="Integra.POReceiveForAuditor" %>

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
                <marquee>Searching Criteria For PONO,Style,Supplier,Item Name</marquee>
            </th>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td>
                Search:
            </td>
            <td style="width: 150px;">
                <asp:TextBox ID="txtSummarySearch" runat="server" AutoPostBack="true" autocomplete="off"
                    Width="196px" Style="margin-left: 12px;"> </asp:TextBox>
                <cc1:AutoCompleteExtender runat="server" ID="AutoCompleteExtender1" TargetControlID="txtSummarySearch"
                    ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                    CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="GetPoReceivingSearchingForAuditor" />
            </td>
             <td>
                <asp:Label ID="lblForm" runat="server" Text="Date Vise :"></asp:Label>
            </td>
            <td >
                <telerik:RadDatePicker ID="txtDateFrom" runat="server" Culture="en-US">
                    <Calendar ID="Calendar1" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                        runat="server">
                    </Calendar>
                    <DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%" runat="server">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td>
           
            <div style="     margin-left: 0px;">
                <telerik:RadButton ID="btnGetDateWise" runat="server" Text="Search" Skin="WebBlue">
                </telerik:RadButton></div>
           
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="5" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                Auditor Check
            </th>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td>
                <div style="width: 920PX; overflow: scroll; height: 350PX;">
                    <Smart:SmartDataGrid ID="dgView" runat="server" Width="100%" 
                        AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                        CellPadding="4" CssClass="table" PageSize="1000" ShowFooter="True" ForeColor="white"
                        GridLines="both">
                        <Columns>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="2%" HeaderText="POID"
                                DataField="POID" Visible="false" />
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="2%" HeaderText="PODetailID"
                                DataField="PODetailID" Visible="false" />
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="2%" HeaderText="PORecvMasterID"
                                DataField="PORecvMasterID" Visible="false" />
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="2%" HeaderText="PORecvDetailID"
                                DataField="PORecvDetailID" Visible="false" />
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="Recv Date" DataField="PORecvDate"
                                DataFormatString="{0:dd/MM/yyyy}">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="PO Date" DataField="POdate">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="PO NO" DataField="PONO">
                                <HeaderStyle HorizontalAlign="center" Width="8%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="Style" DataField="Style">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="Supplier" DataField="SupplierName">
                                <HeaderStyle HorizontalAlign="center" Width="10%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="Item Name" DataField="ItemName">
                                <HeaderStyle HorizontalAlign="center" Width="14%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="PO Qty" DataField="POQTY"
                                Visible="true">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="Recv QTY" DataField="RecvQuantityy">
                                <HeaderStyle HorizontalAlign="center" Width="6%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" Visible="false" HeaderText="Balance Qty"
                                DataField="BalanceQty">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" Visible="false" HeaderText="AuditorStatus"
                            DataField="AuditorStatus">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                        </asp:BoundColumn>

                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderStyle-Width="02%" HeaderText="PDF"
                            Visible="true">
                            <ItemTemplate>
                                <asp:ImageButton ID="lnkPDF" ToolTip="Click here to download PDF" ImageUrl="~/Images/pdf_icon_small.gif"
                                    CommandName="PDF" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>

                        <asp:TemplateColumn HeaderText="Auditor Check" Visible="true" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black">
                            <ItemTemplate>
                                <asp:CheckBox ID="ChkAuditorStatus" OnCheckedChanged="AuditorStatus" AutoPostBack="true"
                                    runat="server" />
                            </ItemTemplate>
                            <HeaderStyle Width="2%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateColumn>

                        </Columns>
                    </Smart:SmartDataGrid>
                </div>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <table width="100%">
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="5" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                Auditor Authorised
            </th>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td>
                <div style="width: 920PX; overflow: scroll; height: 350PX;">
                    <Smart:SmartDataGrid ID="DgAuthorised" runat="server" Width="100%" 
                       AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                        CellPadding="4" CssClass="table" PageSize="1000" ShowFooter="True" ForeColor="white"
                        GridLines="both">
                        <Columns>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="2%" HeaderText="POID"
                                DataField="POID" Visible="false" />
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="2%" HeaderText="PODetailID"
                                DataField="PODetailID" Visible="false" />
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="2%" HeaderText="PORecvMasterID"
                                DataField="PORecvMasterID" Visible="false" />
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="2%" HeaderText="PORecvDetailID"
                                DataField="PORecvDetailID" Visible="false" />
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="Recv Date" DataField="PORecvDate"
                                DataFormatString="{0:dd/MM/yyyy}">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="PO Date" DataField="POdate">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="PO NO" DataField="PONO">
                                <HeaderStyle HorizontalAlign="center" Width="8%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="Style" DataField="Style">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="Supplier" DataField="SupplierName">
                                <HeaderStyle HorizontalAlign="center" Width="10%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="Item Name" DataField="ItemName">
                                <HeaderStyle HorizontalAlign="center" Width="14%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="PO Qty" DataField="POQTY"
                                Visible="true">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="Recv QTY" DataField="RecvQuantityy">
                                <HeaderStyle HorizontalAlign="center" Width="6%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" Visible="false" HeaderText="Balance Qty"
                                DataField="BalanceQty">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" Visible="false" HeaderText="AuditorStatus"
                            DataField="AuditorStatus">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="Auditor Checked" Visible="true" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black">
                            <ItemTemplate>
                                <asp:CheckBox ID="ChkAuditorStatusAuth" OnCheckedChanged="AuditorStatusAuth" AutoPostBack="true"
                                    runat="server" />
                            </ItemTemplate>
                            <HeaderStyle Width="2%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateColumn>
                        </Columns>
                    </Smart:SmartDataGrid>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
