<%@ Page Title="Permission View" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="UserPermissionView.aspx.vb" Inherits="Integra.UserPermissionView" %>

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
    <table width="100%">
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="5" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                User Allowed
            </th>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td>
                <div style="width: 920PX; overflow: scroll; height: 250PX;">
                    <Smart:SmartDataGrid ID="dgUserAllow" runat="server" Width="100%" Style="overflow: scroll;"
                        Height="300px" CssClass="tablemultigrid" AutoGenerateColumns="False" CellPadding="3"
                        SortedAscending="yes" ForeColor="White" GridLines="both" PagerCurrentPageCssClass=""
                        PagerOtherPageCssClass="" PageSize="1000" RecordCount="0" AllowPaging="True"
                        AllowSorting="True" ShowFooter="True">
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
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="Remove"
                                HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor="Black" Visible="true">
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkRemove" ToolTip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png"
                                        CommandName="Delete" runat="server"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                    </Smart:SmartDataGrid></div>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="5" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                Menu's
            </th>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td>
                <div style="width: 920PX; overflow: scroll; height: 350PX;">
                    <Smart:SmartDataGrid ID="dgAllMenu" runat="server" Width="100%" Style="overflow: scroll;"
                        Height="300px" CssClass="tablemultigrid" AutoGenerateColumns="False" CellPadding="3"
                        SortedAscending="yes" ForeColor="White" GridLines="both" PagerCurrentPageCssClass=""
                        PagerOtherPageCssClass="" PageSize="1000" RecordCount="0" AllowPaging="True"
                        AllowSorting="True" ShowFooter="True">
                        <Columns>
                            <asp:BoundColumn Visible="true" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor="Black"
                                HeaderText="Form Role Id" SortExpression="FormRoleId" DataField="FormRoleId">
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
                                <HeaderStyle HorizontalAlign="center" Width="8%" />
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="Allow" Visible="true" HeaderStyle-BackColor="#04A4BD"
                                HeaderStyle-ForeColor="Black">
                                <ItemTemplate>
                                    <asp:CheckBox ID="ChkDownLoad" AutoPostBack="true" runat="server" OnCheckedChanged="UpdateStatus" />
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
