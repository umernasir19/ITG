<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="APurchaseOrderView.aspx.vb" Inherits="Integra.APurchaseOrderView" %>

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
                <marquee>Searching Criteria For PONO,Supplier</marquee>
            </th>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td>
            </td>
            <td style="width: 150px;">
                <asp:TextBox ID="txtSummarySearch" runat="server" Visible="true" AutoPostBack="true"
                    autocomplete="off" Width="196px" Style="margin-left: 0px;"> </asp:TextBox>
                <cc1:AutoCompleteExtender runat="server" ID="AutoCompleteExtender1" TargetControlID="txtSummarySearch"
                    ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                    CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="GetPoEntrySearchingForAstore" />
            </td>
            <td>
                <asp:UpdatePanel ID="btnSearchUPdatee" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnSearchSummary" runat="server" CssClass="button" Text="Filter"
                            Width="80" Visible="false"></asp:Button>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSearchSummary" EventName="Click"></asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Button ID="btnSummaryShowAll" Visible="false" runat="server" CssClass="button"
                    Text="Show All" Width="80"></asp:Button>
            </td>
            <td>
                <div style="margin-left: 37px; margin-top: -14px;">
                    <asp:Button ID="btnshow" Visible="true" runat="server" CssClass="button" Text="Show All Data"
                        Width="160" Style="margin-top: 14px; margin-left: 0px;"></asp:Button></div>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Font-Size="Medium" Style="margin-left: 0px;
                    font-family: Calibri; font-size: 12PX; font-weight: bolder; color: red" Text="Current Data Showing Last 30 Days."></asp:Label>
            </td>
            <td>
                <asp:Button ID="cmdAdd" Visible="true" runat="server" CssClass="button" Text="ADD PURCHASE ORDER"
                    Width="160" Style="margin-top: 14px; margin-left: 599px;"></asp:Button>
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td>
                <Smart:SmartDataGrid ID="dgSummaryView" runat="server" Width="100%" OnSortCommand="SortByColumnSummary"
                    OnPageIndexChanged="PageChangedSummary" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="4" CssClass="table" PageSize="1000"
                    ShowFooter="True" ForeColor="white" Visible="true" GridLines="both">
                    <Columns>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="POID"
                            DataField="POID" Visible="false" />
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="PO Date" DataField="PODATE">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="PO No" DataField="PONo">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Supplier" DataField="SupplierNamee">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Delivery Date" DataField="DeliveryDatee">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Quantity" DataField="POQty">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Inditex PO No" DataField="InditexPONo">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Style" DataField="Style"
                            Visible="false">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="FabricStatus" DataField="FabricStatus"
                            Visible="false">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" Visible="false" HeaderText="AuditorStatus"
                            DataField="AuditorStatus">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="PO No" DataField="SrNo">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="EDIT"
                            Visible="TRUE">
                            <ItemTemplate>
                                <asp:ImageButton ID="lnkEditt" ToolTip="Click here to edit" ImageUrl="~/Images/editIcon.jpg"
                                    CommandName="Edit" runat="server" Enabled="true"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="REMOVE"
                            Visible="true">
                            <ItemTemplate>
                                <asp:ImageButton ID="lnkRemovee" ToolTip="Be sure, it will delete from database"
                                    ImageUrl="~/Images/RemoveIcon.png" CommandName="Remove" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="PDF"
                            Visible="TRUE">
                            <ItemTemplate>
                                <asp:ImageButton ID="lnkPDFF" ToolTip="Click here to download PDF" ImageUrl="~/Images/pdf_icon_small.gif"
                                    CommandName="PDF" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </Smart:SmartDataGrid>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnDetail" runat="server" CssClass="button" Visible="false" Text="Show Detail"
                    Width="160" Style="margin-top: 14px; margin-left: 772px;"></asp:Button>
                <asp:Button ID="btnHideDetail" runat="server" CssClass="button" Text="Hide Detail"
                    Width="160" Style="margin-top: 14px; margin-left: 772px;" Visible="false"></asp:Button>
            </td>
        </tr>
    </table>
    <asp:Panel ID="PanelDetail" runat="server" Visible="false">
        <table width="100%">
            <tr>
                <td>
                    Search:
                </td>
                <td style="width: 150px;">
                    <asp:TextBox ID="txtShowMe" runat="server" AutoPostBack="true" autocomplete="off"
                        Width="196px" ToolTip="Item Name"> </asp:TextBox>
                    <cc1:AutoCompleteExtender runat="server" ID="autoComplete1" TargetControlID="txtShowMe"
                        ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                        CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="PODetail" />
                </td>
                <td>
                    <asp:UpdatePanel ID="btnSearchUPdate" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnSearch" runat="server" CssClass="button" Text="Filter" Width="80"
                                Visible="false"></asp:Button>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click"></asp:AsyncPostBackTrigger>
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:Button ID="btnAll" runat="server" CssClass="button" Text="Show All" Width="80">
                    </asp:Button>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
