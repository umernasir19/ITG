<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeBehind="ComplainDatabaseView.aspx.vb" Inherits="Integra.ComplainDatabaseView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td align="right">
                <asp:Button ID="btnAdd" CssClass="button" Width="170" runat="server" Text="Add Complain Database" />
            </td>
        </tr>
        <tr>
            <td>
                <Smart:SmartDataGrid ID="dgView" OnSortCommand="SortByColumn" OnPageIndexChanged="PageChanged"
                    OnItemDataBound="DataBound" runat="server" Width="100%" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="4" CssClass="table" PagerCurrentPageCssClass=""
                    PagerOtherPageCssClass="" PageSize="15" RecordCount="0" ShowFooter="True" SortedAscending="yes"
                    ForeColor="white" GridLines="Both">
                    <Columns>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="ComplainDatabaseID"
                            DataField="ComplainDatabaseID" Visible="False">
                            <HeaderStyle Width="1%" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="15%" HeaderText="PO No."
                            DataField="PONO">
                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="15%" HeaderText="Customer"
                            DataField="Customername">
                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="15%" HeaderText="Supplier"
                            DataField="vendername">
                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                     	<ASP:TEMPLATECOLUMN HeaderText="View">
                                    <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
                                    <asp:LinkButton id="lnkEdit" CommandName="Edit" runat="server">Edit</asp:LinkButton>
                                    </ITEMTEMPLATE>
                                    <headerstyle width="07%" />
								</ASP:TEMPLATECOLUMN>
                    </Columns>
                    <PagerStyle HorizontalAlign="NotSet" />
                </Smart:SmartDataGrid>
            </td>
        </tr>
    </table>
</asp:Content>
