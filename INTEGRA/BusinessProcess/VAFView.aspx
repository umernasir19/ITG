<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeBehind="VAFView.aspx.vb" Inherits="Integra.VAFView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td align="right">
                <asp:Button ID="btnadd" runat="server" CssClass="button" Text="Proceed To Vendor Assessment Form"
                    Width="300"></asp:Button>
            </td>
        </tr>
        <tr>
            <td>
                <Smart:SmartDataGrid ID="dgView" runat="server" Width="100%" OnSortCommand="SortByColumn"
                    OnPageIndexChanged="PageChanged" OnItemDataBound="DataBound" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                    PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="15" RecordCount="0"
                    ShowFooter="True" SortedAscending="yes" ForeColor="white" GridLines="Both">
                    <Columns>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="VAFID"
                            DataField="VAFID" Visible="False">
                            <HeaderStyle Width="10%" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="15%" HeaderText="Supplier"
                            DataField="VenderName">
                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="15%" HeaderText="Supplier Code"
                            DataField="Code">
                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="15%" HeaderText="Company"
                            DataField="Company">
                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="15%" HeaderText=" Year Established"
                            DataField="YearNo">
                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="15%" HeaderText="Phone No."
                            DataField="PhoneNumber">
                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="View">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEdit" CommandName="ViewVAF" runat="server">View VAF</asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle Width="07%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Print" visible="False">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkPrintl" CommandName="Print" runat="server">Print</asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle Width="07%" />
                        </asp:TemplateColumn>
                    </Columns>
                    <PagerStyle HorizontalAlign="NotSet" />
                </Smart:SmartDataGrid>
            </td>
        </tr>
    </table>
</asp:Content>
