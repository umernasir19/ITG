<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeBehind="SupplierLKZEntery.aspx.vb" Inherits="Integra.SupplierLKZEntery" %>

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
                LKZ Number :
            </td>
            <td>
                <telerik:RadTextBox ID="txtLKZNo" runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
            </td>
            <td>
            </td>
            <td>
                <telerik:RadButton ID="btnAdd" runat="server" Text="Add LKZ" Skin="WebBlue">
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
                        <asp:BoundColumn HeaderText="LKZid" DataField="LKZid" Visible="False" />
                        <asp:BoundColumn HeaderText="SupplierID" DataField="SupplierID" Visible="False" />
                        <asp:BoundColumn HeaderText="CustomerID" DataField="CustomerID" Visible="False" />
                        <asp:BoundColumn HeaderText="Supplier" DataField="SupplierName">
                            <ItemStyle HorizontalAlign="Left" />
                            <HeaderStyle Width="20%" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Customer" DataField="CustomerName" />
                        <asp:BoundColumn HeaderText="LKZ No" DataField="LKZNumber" />
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
