<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="POProcessReceiveView.aspx.vb" Inherits="Integra.POProcessReceiveView" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table>
  <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="6" align="left" style="font-family:Century Gothic ; font-size: 16PX; font-weight: bold;
                color:Blue ">
             <marquee >Searching Criteria For Process No,Supplier,Style,Fabric Code</marquee>
            </th>
        </tr>
</table>
<br />
    <table>
        <tr>
            <td style="width: 5%">
                    Search:
            </td>
            <td style="width: 20%">
                <asp:TextBox ID="txtShowMe" runat="server" AutoPostBack="true" autocomplete="off"
                    Width="196px"  Visible="true"> </asp:TextBox>
                <cc1:AutoCompleteExtender runat="server" ID="autoComplete1" TargetControlID="txtShowMe"
                    ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                    CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="GetProcessStatusSearching" />
            </td>
            <td style="width: 10%">
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
                <asp:Button ID="btnAll" runat="server" CssClass="button" Text="Show All" Width="80"
                    Visible="false"></asp:Button>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr style="height: 35px;">
            <td style="width: 50%" align="right">
                <asp:Button ID="cmdAdd" runat="server" CssClass="btn btn-outline btn-success" Text="ADD RECEIVE"
                    Width="150" Visible ="false" ></asp:Button>
            </td>
        </tr>
        <tr>
            <td style="width: 918px" align="right">
            </td>
        </tr>
        <tr>
            <td>
                <Smart:SmartDataGrid ID="dgView" runat="server" Width="100%" OnSortCommand="SortByColumn"
                    OnPageIndexChanged="PageChanged" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                    CellPadding="4" CssClass="table" PageSize="1000" ShowFooter="True" ForeColor="white"
                    GridLines="both">
                    <Columns>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="2%" HeaderText="POID"
                            DataField="ProcessOrderMstID" Visible="false" />

                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Process Date" DataField="POdate">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Process No" DataField="PONO">
                            <HeaderStyle HorizontalAlign="center" Width="8%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Fabric Code" DataField="CodeEntry">
                            <HeaderStyle HorizontalAlign="center" Width="8%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Style" DataField="Style">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Supplier" DataField="SupplierName">
                            <HeaderStyle HorizontalAlign="center" Width="12%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Item Name" DataField="ItemName">
                            <HeaderStyle HorizontalAlign="center" Width="14%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="PO Qty" DataField="POQTY"
                            Visible="true">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>

                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Recv QTY" DataField="RecvQuantity">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Balance Qty" DataField="BalanceQty">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" Visible ="false"  HeaderStyle-Width="02%" HeaderText="EDIT"
                            >
                            <ItemTemplate>
                                <asp:ImageButton ID="lnkEdit" ToolTip="Click here to edit" ImageUrl="~/Images/editIcon.jpg"
                                    CommandName="Edit" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="REMOVE"
                            Visible="false">
                            <ItemTemplate>
                                <asp:ImageButton ID="lnkRemove" ToolTip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png"
                                    CommandName="Remove" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="PDF"
                            Visible="false">
                            <ItemTemplate>
                                <asp:ImageButton ID="lnkPDF" ToolTip="Click here to download PDF" ImageUrl="~/Images/pdf_icon_small.gif"
                                    CommandName="PDF" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                      
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="Return"
                            Visible="false">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkReturn" ToolTip="Click here to Go Return" Text="Return" CommandName="Return"
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
                    </Columns>
                </Smart:SmartDataGrid>
            </td>
        </tr>
    </table>
</asp:Content>
