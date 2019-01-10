<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="UserView.aspx.vb" Inherits="Integra.UserView" %>

<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td align="right">
                <asp:Button ID="cmdAdd" Visible="true" runat="server" CssClass="button" Text="Add User">
                </asp:Button>
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td>
                <Smart:SmartDataGrid ID="dgUser" runat="server" Width="100%" CssClass="tablemultigrid"
                    OnSortCommand="SortByColumn" OnPageIndexChanged="PageChanged" AutoGenerateColumns="False"
                    CellPadding="3" SortedAscending="yes" ForeColor="White" GridLines="both" PagerCurrentPageCssClass=""
                    PagerOtherPageCssClass="" PageSize="30" RecordCount="0" AllowPaging="True" AllowSorting="True"
                    ShowFooter="True">
                    <Columns>
                        <asp:BoundColumn Visible="False" HeaderText="Userid" SortExpression="Userid" DataField="Userid">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="1%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="User Name" DataField="UserName">
                            <ItemStyle HorizontalAlign="center" />
                            <HeaderStyle HorizontalAlign="center" Width="10%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Login ID" DataField="UserCode">
                            <ItemStyle HorizontalAlign="center" />
                            <HeaderStyle HorizontalAlign="center" Width="10%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Division" DataField="ECPDivistion">
                            <ItemStyle HorizontalAlign="center" />
                            <HeaderStyle HorizontalAlign="center" Width="10%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Designation" DataField="Designation">
                            <ItemStyle HorizontalAlign="center" />
                            <HeaderStyle HorizontalAlign="center" Width="10%" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="Status"
                            Visible="false">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDisable" CommandName="DisableStatus" runat="server">Click to Disable</asp:LinkButton>
                                <asp:LinkButton ID="lnkEnable" CommandName="EnableStatus" runat="server">Click to Enable</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="Action">
                            <ItemTemplate>
                                <asp:HyperLink ID="lnkPermission" ToolTip='<%# "Edit Permission  Of : " + DataBinder.Eval(Container.DataItem,"UserName") %>'
                                    NavigateUrl='<%# "UserPermissionView.aspx?nUserId=" &amp; DataBinder.Eval(Container.DataItem,"UserId") &amp; "&amp;strUserCode=" &amp; DataBinder.Eval(Container.DataItem,"UserCode") &amp; "&amp;TabId=" &amp; Request.QueryString("TabId") %>'
                                    runat="server">
											Permission
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="User Rights">
                            <ItemTemplate>
                                <asp:HyperLink ID="lnkUserRights" ToolTip='<%# "Edit User Rights  Of : " + DataBinder.Eval(Container.DataItem,"UserName") %>'
                                    NavigateUrl='<%# "UserRightsView.aspx?nUserId=" &amp; DataBinder.Eval(Container.DataItem,"UserId") &amp; "&amp;strUserCode=" &amp; DataBinder.Eval(Container.DataItem,"UserCode") &amp; "&amp;TabId=" &amp; Request.QueryString("TabId") %>'
                                    runat="server">
											Rights
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="Edit">
                            <ItemTemplate>
                                <asp:HyperLink ID="lnkEdit" ToolTip='<%# "Edit Information  Of : " + DataBinder.Eval(Container.DataItem,"UserName") %>'
                                    NavigateUrl='<%# "UserAdd.aspx?nUserId=" &amp; DataBinder.Eval(Container.DataItem,"UserId") &amp; "&amp;strUserCode=" &amp; DataBinder.Eval(Container.DataItem,"UserCode") &amp; "&amp;TabId=" &amp; Request.QueryString("TabId") %>'
                                    runat="server">
											Edit
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </Smart:SmartDataGrid>
            </td>
        </tr>
    </table>
</asp:Content>
