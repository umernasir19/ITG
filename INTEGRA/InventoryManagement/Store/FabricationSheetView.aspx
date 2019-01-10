<%@ Page Title="Fabrication Sheet View" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="FabricationSheetView.aspx.vb" Inherits="Integra.FabricationSheetView" %>

<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%">
        <tr>
            <td style="width: 918px; height: 22px;" align="right">
                <asp:Button ID="cmdAdd" runat="server" CssClass="button" Text="Add" Width="200">
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
                            <Smart:SmartDataGrid ID="dgView" runat="server" Width="100%" OnSortCommand="SortByColumn"
                                OnPageIndexChanged="PageChanged" OnItemDataBound="DataBound" AllowPaging="True"
                                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                                PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="100" RecordCount="0"
                                ShowFooter="True" ForeColor="white" GridLines="vertical">
                                <Columns>
                                    <asp:BoundColumn HeaderText="ID" DataField="FabricationSheetMstID" Visible="False">
                                        <HeaderStyle Width="5%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Fabric Date" DataField="FabricDate">
                                        <HeaderStyle HorizontalAlign="Center" Width="7%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Reference No" DataField="ReferenceNo">
                                        <HeaderStyle HorizontalAlign="Center" Width="7%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Buyer" DataField="Buyer">
                                        <HeaderStyle HorizontalAlign="Center" Width="7%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <%--<ASP:BOUNDCOLUMN  HeaderText="Total Order Qty."
									  DataField="TotalOrderQty" >
							 	<headerstyle horizontalalign="Center" width="7%" />
                                    <itemstyle horizontalalign="Center" />
								</ASP:BOUNDCOLUMN>--%>
                                    <asp:BoundColumn HeaderText="PO.Number" DataField="PONumber">
                                        <HeaderStyle HorizontalAlign="Center" Width="7%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Item" DataField="Item">
                                        <HeaderStyle HorizontalAlign="Center" Width="7%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:TemplateColumn HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="lnkEdit" ToolTip="Click here to edit" ImageUrl="~/Images/editIcon.jpg"
                                                CommandName="Edit" runat="server"></asp:ImageButton>
                                        </ItemTemplate>
                                        <HeaderStyle Width="5%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="PDF" Visible="false">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="PDF" ImageUrl="~/Images/pdf_icon_small.gif" CommandName="PDF"
                                                runat="server" Visible="true"></asp:ImageButton>
                                        </ItemTemplate>
                                        <HeaderStyle Width="4%" />
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
