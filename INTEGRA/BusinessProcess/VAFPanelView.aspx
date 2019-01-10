<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeBehind="VAFPanelView.aspx.vb" Inherits="Integra.VAFPanelView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        
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
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="15%" HeaderText="Status"
                            DataField="SupplierStatus">
                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="15%" HeaderText="Supplier"
                            DataField="VenderName">
                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="15%" HeaderText="Supplier Code"
                            DataField="Code">
                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="15%" HeaderText=" Year Established"
                            DataField="YearNo">
                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="View">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEdit" CommandName="ViewVAF" runat="server">View VAF</asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle Width="07%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Approval">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkApproval" CommandName="Approval" runat="server">Approval</asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle Width="07%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Print">
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
