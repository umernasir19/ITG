<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeBehind="ErrorCodesView.aspx.vb" Inherits="Integra.ErrorCodesView" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:LinkButton ID="lnkPrint" runat="server" Text="Click here to Download PDF"></asp:LinkButton>
            </td>
            <td align="right">
                <telerik:RadButton ID="btnAdd" runat="server" Text="Add Error Codes" Skin="WebBlue">
                </telerik:RadButton>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td>
                <telerik:RadGrid ID="dgErrorCodes" runat="server" CellSpacing="0" AutoGenerateColumns="false"
                    Skin="WebBlue" Visible="true" PageSize="50">
                    <AlternatingItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" />
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn HeaderText="ID" DataField="ID" Display="false">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="2%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Error Code" DataField="ErrorNo">
                                <ItemStyle HorizontalAlign="Left" Width="50px" />
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Error Description" DataField="errorDescription">
                                <ItemStyle HorizontalAlign="Left" Width="50px" />
                                <HeaderStyle Width="10%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="View" Display="true">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="3%" HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnView" runat="server" CommandName="EDIT" HeaderText="View" Text="Edit"></asp:LinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                    <HeaderStyle Font-Names="Microsoft Sans Serif" />
                    <ItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" />
                    <ClientSettings EnableRowHoverStyle="false" EnablePostBackOnRowClick="false">
                        <Selecting AllowRowSelect="false" EnableDragToSelectRows="false" />
                        <Selecting AllowRowSelect="True" />
                    </ClientSettings>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
</asp:Content>
