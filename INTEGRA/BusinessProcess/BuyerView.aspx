<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="BuyerView.aspx.vb" Inherits="Integra.BuyerView" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table width="100%">
        <tr>
            <td align="right">
                <asp:Button ID="btnAdd" runat="server" CssClass="button" Text="Add Buyer" Width="180">
                </asp:Button>
            </td>
        </tr>
        <tr>
            <td>
                <Smart:SmartDataGrid ID="dgPurchaseOrder" runat="server" Width="100%" OnSortCommand="SortByColumn"
                    OnPageIndexChanged="PageChanged" OnItemDataBound="DataBound" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                    PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="15" RecordCount="0"
                    ShowFooter="True" sortedascending="yes" ForeColor="white" GridLines="both">
                    <Columns>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="BuyerID"
                            DataField="BuyerID" Visible="false">
                            <HeaderStyle Width="10%" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Buyer Name"
                            DataField="BuyerName">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundColumn>
                         <ASP:TemplateColumn HeaderText="Edit" >
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Center"  />
                                    <ItemTemplate>
                                        <asp:HyperLink ID="lnkEdit" ToolTip ="Click here to Edit Buyer" runat="server" NavigateUrl='<%# "BuyerEntry.aspx?BuyerID=" &amp; DataBinder.Eval(Container.DataItem,"BuyerID")%>'
                                            Enabled="true">
										Edit
                                        </asp:HyperLink>
                                    </ItemTemplate>
                                   
                                </ASP:TemplateColumn>
                    </Columns>
                    <PagerStyle HorizontalAlign="NotSet" />
                </Smart:SmartDataGrid>
            </td>
        </tr>
    </table>
</asp:Content>
