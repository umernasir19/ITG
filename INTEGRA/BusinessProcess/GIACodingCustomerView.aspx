<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="GIACodingCustomerView.aspx.vb" Inherits="Integra.GIACodingCustomerView" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td align="right">
                <telerik:RadButton ID="cmdAdd" runat="server" Text="Add Customer GIA No" Skin="WebBlue">
                </telerik:RadButton>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadGrid ID="dgLKZ" runat="server" CellSpacing="0" AutoGenerateColumns="false"
                    Skin="WebBlue" Visible="False" PageSize="200" AllowCustomPaging="true">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn HeaderText="SupplierID" DataField="SupplierID">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="CustomerID" DataField="CustomerID">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Supplier" DataField="vendername">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Customer" DataField="CustomerName">
                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="GIA No" DataField="GIANumber">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                    <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                        <Selecting AllowRowSelect="true" EnableDragToSelectRows="false" />
                    </ClientSettings>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
</asp:Content>
