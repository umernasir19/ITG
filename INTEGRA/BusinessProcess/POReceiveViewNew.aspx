<%@ Page Title="PO Receive View" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="POReceiveViewNew.aspx.vb" Inherits="Integra.POReceiveViewNew" %>

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
            <td style="width: 20%">
                <asp:TextBox ID="txtShowMe" runat="server" AutoPostBack="true" autocomplete="off"
                    Width="196px" ToolTip="Item Name"> </asp:TextBox>
                <cc1:AutoCompleteExtender runat="server" ID="autoComplete1" TargetControlID="txtShowMe"
                    ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                    CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="GetPoReceivingSearching" />
            </td>
            <td style="width: 10%">
                <asp:UpdatePanel ID="btnSearchUPdate" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnSearch" Visible="false" runat="server" CssClass="button" Text="Search"
                            Width="80"></asp:Button>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click"></asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Button ID="btnAll" runat="server" CssClass="button" Text="Show All" Width="80"
                    Visible="false"></asp:Button>
            </td>
                <td>
            <div style=" margin-left: -25px; margin-top: -14px;">
                <asp:Button ID="btnshow" Visible="true"  runat="server" CssClass="button" Text="Show All Data"
                    Width="160" Style="margin-top: 14px; margin-left: 0px;"></asp:Button></div>
            </td>
        </tr>
    </table>
   <table>
        <tr>
            <td>
                        <asp:Label ID="Label4" runat="server" Font-Size="Medium" Style="margin-left: 0px; font-family: Calibri; font-size: 12PX; font-weight: bolder;
                        color: red" Text="Current Data Showing Last 30 Days."></asp:Label>
                    </td>
            <td>
                <asp:Button ID="cmdAdd" Visible="true"  runat="server" CssClass="button" Text="ADD Receive"
                    Width="160" Style="margin-top: 14px; margin-left: 589px;"></asp:Button>
            </td>
           
        </tr>
    </table>
    <br />
   <table width="100%">
        <tr>
            <td style="width: 918px" align="right">
            </td>
        </tr>
        <tr>
            <td>
                <div style="width: 920PX; overflow: scroll; ">
                    <Smart:SmartDataGrid ID="dgView" runat="server" Width="100%" OnSortCommand="SortByColumn"
                        OnPageIndexChanged="PageChanged" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
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
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Recv Date" DataField="PORecvDate"
                                DataFormatString="{0:dd/MM/yyyy}">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="PO Date" DataField="POdate">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="PO NO" DataField="PONO">
                                <HeaderStyle HorizontalAlign="center" Width="8%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Style" DataField="Style">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Supplier" DataField="SupplierName">
                                <HeaderStyle HorizontalAlign="center" Width="10%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Item Name" DataField="ItemName">
                                <HeaderStyle HorizontalAlign="center" Width="14%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="PO Qty" DataField="POQTY"
                                Visible="true">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Recv QTY" DataField="RecvQuantityy">
                                <HeaderStyle HorizontalAlign="center" Width="6%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" Visible="false" HeaderText="Balance Qty"
                                DataField="BalanceQty">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="EDIT"
                                Visible="true">
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkEdit" ToolTip="Click here to edit" ImageUrl="~/Images/editIcon.jpg"
                                        CommandName="Edit" runat="server"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="PDF"
                                Visible="true">
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkPDF" ToolTip="Click here to download PDF" ImageUrl="~/Images/pdf_icon_small.gif"
                                        CommandName="PDF" runat="server"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="ItemId" DataField="ItemId"
                                Visible="false">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="Return"
                                Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkReturn" ToolTip="Click here to Go Return" Text="Return" CommandName="ReturnNew"
                                        runat="server"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="Return PDF"
                                Visible="false">
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkReturnPDF" ToolTip="Click here to download PDF" ImageUrl="~/Images/pdf_icon_small.gif"
                                        CommandName="ReturnPDF" runat="server"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="REMOVE"
                                Visible="true">
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkRemove" ToolTip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png"
                                        CommandName="Remove" runat="server"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" Visible="false" HeaderText="AuditorStatus"
                                DataField="AuditorStatus">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="Return"
                                Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkReturnNew" ToolTip="Click here to Go Return" Text="Return"
                                        CommandName="Return" runat="server"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                    </Smart:SmartDataGrid>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
