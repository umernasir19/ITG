<%@ Page Title="Size Range Add" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="SizeRangeAdd_A.aspx.vb" Inherits="Integra.SizeRangeAdd_A" %>

<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <asp:Panel ID="PnlAddGender1" runat="server" Visible="true">
                <td>
                    Gender
                </td>
                <td>
                    <asp:DropDownList ID="cmbGender" Width="150" AutoPostBack="true" runat="server">
                    </asp:DropDownList>
                    <asp:ImageButton ID="BtnAddGender" runat="server" ImageUrl="~/Images/AddButton.jpg"
                        Style="margin-left: 7px; width: 19px;" />
                </td>
            </asp:Panel>
            <asp:Panel ID="PnlAddGender2" runat="server" Visible="false">
                <td>
                    Gender
                </td>
                <td>
                    <asp:TextBox ID="txtAddGender" runat="server" Width="150px" CssClass="textbox"></asp:TextBox>
                    <asp:ImageButton ID="BtnSaveGender" runat="server" ImageUrl="~/Images/SaveButton.jpg"
                        Style="margin-left: 7px; width: 19px;" />
                </td>
            </asp:Panel>
        </tr>
        <tr>
            <td>
                Size Range
            </td>
            <td>
                <asp:TextBox ID="txtSizeRange" CssClass="textbox" Width="280" runat="server" Style="margin-top: 5px;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <asp:Panel ID="PnlSizes1" runat="server" Visible="true">
                <td>
                    Sizes
                </td>
                <td>
                    <asp:DropDownList ID="cmbSizes" Width="150" AutoPostBack="true" runat="server">
                    </asp:DropDownList>
                    <asp:ImageButton ID="BtnAddSizes" runat="server" ImageUrl="~/Images/AddButton.jpg"
                        Style="margin-left: 7px; width: 19px;" />
                </td>
            </asp:Panel>
            <asp:Panel ID="PnlSizes2" runat="server" Visible="false">
                <td>
                    Sizes
                </td>
                <td>
                    <asp:TextBox ID="txtAddSizes" runat="server" Width="150px" CssClass="textbox" Style="text-transform: uppercase;"></asp:TextBox>
                    <asp:ImageButton ID="BtnSaveSizes" runat="server" ImageUrl="~/Images/SaveButton.jpg"
                        Style="margin-left: 7px; width: 19px;" />
                </td>
            </asp:Panel>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td>
            </td>
            <td>
                <div style="margin-left: 193px;">
                    <asp:Button ID="btnAddDeatil" CssClass="button" runat="server" Text="Add Detail" /></div>
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td>
                <Smart:SmartDataGrid ID="dgView" Font-Size="15pt" runat="server" Width="100%" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="2" CssClass="table" PageSize="100" ShowFooter="False"
                    ForeColor="white" GridLines="both">
                    <Columns>
                        <asp:BoundColumn Visible="false" ItemStyle-HorizontalAlign="center" HeaderText="SizeRangeDetailID"
                            DataField="SizeRangeDetailID">
                            <HeaderStyle HorizontalAlign="center" Width="2%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn Visible="false" ItemStyle-HorizontalAlign="center" HeaderText="SizeDatabaseID"
                            DataField="SizeDatabaseID">
                            <HeaderStyle HorizontalAlign="center" Width="2%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="SIZE" DataField="Sizes">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="RATIO" DataField="Ratio">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                    </Columns>
                    <PagerStyle Visible="False" CssClass="GridPagerStyle" Mode="NumericPages" HorizontalAlign="Right" />
                    <AlternatingItemStyle CssClass="GridAlternativeRow" />
                    <ItemStyle CssClass="GridRow" />
                    <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                </Smart:SmartDataGrid>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnSave" CssClass="button" runat="server" Text="Save" />&nbsp; &nbsp;<asp:Button
                    ID="btnCancel" CssClass="button" runat="server" Text="Cancel" />
            </td>
        </tr>
    </table>
</asp:Content>
