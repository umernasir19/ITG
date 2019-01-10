<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master"
    CodeBehind="SizeRangeEntry.aspx.vb" Inherits="Integra.SizeRangeEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                Size Range
            </td>
            <td>
                <asp:TextBox ID="txtSizeRange" CssClass="textbox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Size(s)
            </td>
            <td>
                <asp:TextBox ID="txtSize" CssClass="textbox" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnAddDetail" CssClass="button" runat="server" Text="Add More" />
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td>
                <Smart:SmartDataGrid ID="dgPurchaseOrder" runat="server" Width="100%" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="2" CssClass="table" PagerCurrentPageCssClass=""
                    PagerOtherPageCssClass="" PageSize="600" RecordCount="0" ShowFooter="True" SortedAscending="yes">
                    <Columns>
                        <asp:BoundColumn HeaderText="SizeRangeDBID" DataField="SizeRangeDBID" Visible="False" />
                       
                        <asp:BoundColumn HeaderText="Size Range" DataField="SizeRange">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Size" DataField="Sizes">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                       
                        <asp:TemplateColumn HeaderText="Action">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:ImageButton ID="lnkRemove" runat="server" CommandName="Remove" BackColor="transparent"
                                    ImageUrl="~/Images/RemoveIcon.png" />
                            </ItemTemplate>
                            <HeaderStyle Width="3%" />
                        </asp:TemplateColumn>
                    </Columns>
                    <PagerStyle HorizontalAlign="NotSet" Visible="false" />
                    <AlternatingItemStyle CssClass="GridAlternativeRow" />
                    <ItemStyle CssClass="GridRow" />
                    <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                </Smart:SmartDataGrid>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td align="center">
                <asp:Button ID="btnSave" CssClass="button" runat="server" Text="Save" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancel" CssClass="button" runat="server" Text="Cancel" />
            </td>
        </tr>
    </table>
</asp:Content>
