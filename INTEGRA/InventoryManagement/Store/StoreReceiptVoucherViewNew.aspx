<%@ Page Title="Store Receipt Voucher View" Language="vb" AutoEventWireup="false"
    MasterPageFile="~/MasterPage.master" CodeBehind="StoreReceiptVoucherViewNew.aspx.vb"
    Inherits="Integra.StoreReceiptVoucherViewNew" %>

<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td align="right">
                <asp:Button ID="btnAdd" Width="140px" CssClass="Button" runat="server" Text="Add Voucher" />
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr style="height: 35px">
            <td>
                <Smart:SmartDataGrid ID="dgVoucherView" runat="server" Width="100%" OnSortCommand="SortByColumn"
                    OnPageIndexChanged="PageChanged" OnItemDataBound="DataBound" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                    PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="200" RecordCount="0"
                    ShowFooter="True" ForeColor="white" GridLines="both">
                    <Columns>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderText="StoreReceiptVoucherMstID"
                            DataField="StoreReceiptVoucherMstID" Visible="False">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="2%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderText="Voucher Date" DataField="StoreRecieptVoucherDate"
                            Visible="true">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="5%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="PDF" Visible="false">
                            <ItemTemplate>
                                <asp:ImageButton ID="PDF" ImageUrl="~/Images/pdf_icon_small.gif" CommandName="PDF"
                                    runat="server" Visible="true"></asp:ImageButton>
                            </ItemTemplate>
                            <HeaderStyle Width="4%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateColumn>
                    </Columns>
                </Smart:SmartDataGrid>
            </td>
        </tr>
    </table>
</asp:Content>
