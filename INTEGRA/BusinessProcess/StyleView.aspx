<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeBehind="StyleView.aspx.vb" Inherits="Integra.StyleView" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td align="center">
                <table width="100%">
                    <tr>
                        <td>
                            <div>
                                <asp:TextBox ID="txtsearchStyle" Style="margin-left: 142px; width: 209px;" runat="server"
                                    AutoPostBack="true" autocomplete="off"></asp:TextBox>
                                <cc1:AutoCompleteExtender runat="server" ID="autoComplete1" TargetControlID="txtsearchStyle"
                                    ServicePath="~/AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                                    CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="SearchStyle" />
                            </div>
                        </td>
                        <td align="right">
                            <div>
                                <asp:Button ID="btnAdd" runat="server" CssClass="button" Text="Add Style" Width="110">
                                </asp:Button></div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <Smart:SmartDataGrid ID="dgStyle" runat="server" Width="100%" OnSortCommand="SortByColumn"
                    OnPageIndexChanged="PageChanged" OnItemDataBound="DataBound" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                    PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="50" RecordCount="0"
                    ShowFooter="True" SortedAscending="yes" ForeColor="white" GridLines="Both">
                    <Columns>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="StyleID"
                            SortExpression="StyleID" DataField="StyleID" Visible="false">
                            <HeaderStyle Width="10%" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="Entry Date"
                            DataField="CreationDatee">
                            <HeaderStyle Width="10%" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="StyleNo"
                            DataField="StyleNo">
                            <HeaderStyle Width="15%" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="CoreLine"
                            DataField="CoreLine" Visible="false">
                            <HeaderStyle Width="15%" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="BuyerName"
                            DataField="BuyerName">
                            <HeaderStyle Width="15%" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="View">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:HyperLink ID="lnkEdit" runat="server" NavigateUrl='<%# "StyleDatabaseEntry.aspx?lStyleID=" &amp; DataBinder.Eval(Container.DataItem,"StyleID")%>'
                                    Enabled="true">
											View
                                </asp:HyperLink>
                                <br />
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "StyleDatabaseEntry.aspx?lStyleID=" &amp; DataBinder.Eval(Container.DataItem,"StyleID")&"&Type=Copy"%>'
                                    Enabled="true">
											Copy
                                </asp:HyperLink>
                            </ItemTemplate>
                            <HeaderStyle Width="10%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Report View">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:HyperLink ID="lnkEdit1" runat="server" NavigateUrl='<%# "StyleDatabaseReportView.aspx?lStyleID=" &amp; DataBinder.Eval(Container.DataItem,"StyleID")%>'
                                    Enabled="true">
											Report View
                                </asp:HyperLink>
                            </ItemTemplate>
                            <HeaderStyle Width="10%" />
                        </asp:TemplateColumn>
                         <asp:TemplateColumn HeaderText="Sealer Approval">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:HyperLink ID="lnkEditEDIT" runat="server" NavigateUrl='<%# "StyleSealerApprovalNew.aspx?StyleID=" &amp; DataBinder.Eval(Container.DataItem,"StyleID")&"&StyleNo="&amp; DataBinder.Eval(Container.DataItem,"StyleNo")%>'
                                    Enabled="true">
											Sealer Approval
                                </asp:HyperLink>
                            </ItemTemplate>
                            <HeaderStyle Width="10%" />
                        </asp:TemplateColumn>
                    </Columns>
                    <PagerStyle HorizontalAlign="NotSet" />
                </Smart:SmartDataGrid>
            </td>
        </tr>
    </table>
</asp:Content>
