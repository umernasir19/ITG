<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="GIACodingSupplierEntry.aspx.vb" Inherits="Integra.GIACodingSupplierEntry" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td>
            </td>
            <td class="ErrorMsg">
                <asp:Label ID="lblmsg" Visible="False" runat="server" Text="Not Save!!!!"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Supplier :
            </td>
            <td>
                <telerik:RadComboBox ID="cmbSupplier" runat="server" AutoPostBack="True" Skin="WebBlue">
                </telerik:RadComboBox>
            </td>
            <td>
                Customer :
            </td>
            <td>
                <telerik:RadComboBox ID="cmbBuyerWise" runat="server" AutoPostBack="True" Skin="WebBlue">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td>
                GIA No. :
            </td>
            <td>
                <telerik:RadTextBox ID="txtGIANo" runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
            </td>
            <td>
            </td>
            <td>
                <telerik:RadButton ID="btnAdd" runat="server" Text="Add GIA Code" Skin="WebBlue">
                </telerik:RadButton>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td>
                <Smart:SmartDataGrid ID="dgLKZz" OnPageIndexChanged="PageChanged" runat="server"
                    Width="100%" AllowSorting="True" AutoGenerateColumns="False" CellPadding="2"
                    CssClass="table" PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="100"
                    RecordCount="0" ShowFooter="True" SortedAscending="yes">
                    <Columns>
                        <asp:BoundColumn HeaderText="GIACodingSupplierID" DataField="GIACodingSupplierID" Visible="False" />
                        <asp:BoundColumn HeaderText="SupplierID" DataField="SupplierID" Visible="False" />
                        <asp:BoundColumn HeaderText="CustomerID" DataField="CustomerID" Visible="False" />
                        <asp:BoundColumn HeaderText="Supplier" DataField="SupplierName">
                            <ItemStyle HorizontalAlign="Left" />
                            <HeaderStyle Width="20%" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Customer" DataField="CustomerName" />
                        <asp:BoundColumn HeaderText="GIA Code" DataField="GIANumber" />
                    </Columns>
                    <PagerStyle Visible="False" CssClass="GridPagerStyle" Mode="NumericPages" HorizontalAlign="Right" />
                    <AlternatingItemStyle CssClass="GridAlternativeRow" />
                    <ItemStyle CssClass="GridRow" />
                    <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                </Smart:SmartDataGrid>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td align="right">
                <telerik:RadButton ID="btnSave" runat="server" Text="Save" Skin="WebBlue">
                </telerik:RadButton>
            </td>
            <td>
                <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" Skin="WebBlue">
                </telerik:RadButton>
            </td>
        </tr>
    </table>
</asp:Content>
