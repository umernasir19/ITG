<%@ Page Title="Item Class View" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="ItemClassView.aspx.vb" Inherits="Integra.ItemClassView" %>

<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%">
        <tr>
            <td style="width: 918px" align="right">
                <asp:LinkButton ID="lnkPrint" runat="server" Visible="false">Click here for Print</asp:LinkButton>
                <asp:Button ID="cmdAdd" runat="server" CssClass="button" Text="Add Item Class" Width="200">
                </asp:Button>
            </td>
        </tr>
        <tr style="height: 5px">
        </tr>
        <tr>
            <td align="center" valign="top" style="width: 918px">
                <table width="100%">
                    <tr>
                        <td>
                            <Smart:SmartDataGrid ID="dgItemClass" runat="server" Width="100%" OnSortCommand="SortByColumn"
                                OnPageIndexChanged="PageChanged" OnItemDataBound="DataBound" AllowPaging="True"
                                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                                PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="100" RecordCount="0"
                                ShowFooter="True" ForeColor="white" GridLines="Vertical">
                                <Columns>
                                    <asp:BoundColumn HeaderText="ID" DataField="IMSItemClassID" Visible="False">
                                        <HeaderStyle Width="5%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Item Class Name" DataField="ItemClassName">
                                        <HeaderStyle HorizontalAlign="Center" Width="7%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Item Code" DataField="ItemCode">
                                        <HeaderStyle HorizontalAlign="Center" Width="7%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:TemplateColumn HeaderText="Edit" Visible="true">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="lnkEdit" ToolTip="Click here to edit" ImageUrl="~/Images/editIcon.jpg"
                                                CommandName="Edit" runat="server"></asp:ImageButton>
                                        </ItemTemplate>
                                        <HeaderStyle Width="5%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateColumn>
                                </Columns>
                                <PagerStyle CssClass="GridPagerStyle" HorizontalAlign="Right" Mode="NumericPages" />
                                <AlternatingItemStyle CssClass="GridAlternativeRow" />
                                <ItemStyle CssClass="GridRow" />
                                <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                            </Smart:SmartDataGrid>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
