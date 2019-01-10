<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="UserRightsView.aspx.vb" Inherits="Integra.UserRightsView" %>

<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <td>
                <asp:Label ID="Label1" runat="server" Text="User Name:    " Style="font-family: Century Gothic;
                    font-size: 16PX; font-weight: bold; color: Blue"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblUserName" runat="server" Text="" Style="font-family: Century Gothic;
                    font-size: 16PX; font-weight: bold; color: Red"></asp:Label>
            </td>
            <td align="right">
                <asp:Button ID="cmdback" Visible="true" runat="server" CssClass="button" Style="margin-left: 699px;"
                    Text="Back"></asp:Button>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <table width="100%">
        <tr>
            <td>
                <div style="width: 920PX;">
                    <Smart:SmartDataGrid ID="dgUserAllow" runat="server" Width="100%" Style="overflow: scroll;"
                        CssClass="tablemultigrid" AutoGenerateColumns="False" CellPadding="3" SortedAscending="yes"
                        ForeColor="White" GridLines="both" PagerCurrentPageCssClass="" PagerOtherPageCssClass=""
                        PageSize="1000" RecordCount="0" AllowPaging="True" AllowSorting="True" ShowFooter="True">
                        <Columns>
                            <asp:BoundColumn Visible="true" HeaderText="Form Role Id" HeaderStyle-BackColor="#04A4BD"
                                HeaderStyle-ForeColor="Black" SortExpression="FormRoleId" DataField="FormRoleId">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle Width="1%" HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn Visible="False" HeaderText="RoleId" SortExpression="RoleId" DataField="RoleId">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle Width="1%" HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Menu's" DataField="TextToDisplay" HeaderStyle-BackColor="#04A4BD"
                                HeaderStyle-ForeColor="Black">
                                <ItemStyle HorizontalAlign="center" />
                                <HeaderStyle HorizontalAlign="center" Width="9%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn Visible="false" HeaderText="Form Role Id" HeaderStyle-BackColor="#04A4BD"
                                HeaderStyle-ForeColor="Black" SortExpression="ID" DataField="ID">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle Width="1%" HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn Visible="false" HeaderText="AddStatus" HeaderStyle-BackColor="#04A4BD"
                                HeaderStyle-ForeColor="Black" SortExpression="ID" DataField="AddStatus">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle Width="1%" HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn Visible="false" HeaderText="ViewStatus" HeaderStyle-BackColor="#04A4BD"
                                HeaderStyle-ForeColor="Black" SortExpression="ID" DataField="ViewStatus">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle Width="1%" HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn Visible="false" HeaderText="DeleteStatus" HeaderStyle-BackColor="#04A4BD"
                                HeaderStyle-ForeColor="Black" SortExpression="ID" DataField="DeleteStatus">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle Width="1%" HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="Add" Visible="true" HeaderStyle-BackColor="#04A4BD"
                                HeaderStyle-ForeColor="Black">
                                <ItemTemplate>
                                    <asp:CheckBox ID="ChkAdd" AutoPostBack="true" runat="server" OnCheckedChanged="UpdateStatusAdd" />
                                </ItemTemplate>
                                <HeaderStyle Width="2%" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="View" Visible="true" HeaderStyle-BackColor="#04A4BD"
                                HeaderStyle-ForeColor="Black">
                                <ItemTemplate>
                                    <asp:CheckBox ID="ChkView" AutoPostBack="true" runat="server" OnCheckedChanged="UpdateStatusView" />
                                </ItemTemplate>
                                <HeaderStyle Width="2%" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Delete" Visible="true" HeaderStyle-BackColor="#04A4BD"
                                HeaderStyle-ForeColor="Black">
                                <ItemTemplate>
                                    <asp:CheckBox ID="ChkDelete" AutoPostBack="true" runat="server" OnCheckedChanged="UpdateStatusDelete" />
                                </ItemTemplate>
                                <HeaderStyle Width="2%" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateColumn>
                        </Columns>
                    </Smart:SmartDataGrid></div>
            </td>
        </tr>
    </table>
</asp:Content>
