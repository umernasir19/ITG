<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="StyleSealerApprovalNew.aspx.vb" Inherits="Integra.StyleSealerApprovalNew" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td style="width: 150px;">
                Style No
            </td>
            <td>
                <asp:TextBox ID="txtStyleNo" runat="server" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                Season
            </td>
            <td>
                <asp:DropDownList ID="cmbSeason" runat="server" Width="140">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                Sealer Approval Date:
            </td>
            <td align="left">
                <telerik:RadDatePicker ID="txtSealerApprovalDate" runat="server" Culture="en-US">
                    <Calendar ID="Calendar5" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                        runat="server">
                    </Calendar>
                    <DateInput ID="DateInput5" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%" runat="server">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
        </tr>
        <tr style="height: 35px;">
        <td style="width: 100px;"></td>
            <td align="center">
                <asp:Button ID="btnAdd" runat="server" CssClass="button" Text="Add Detail" />
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td>
                <Smart:SmartDataGrid ID="dgStyleSealer" OnPageIndexChanged="PageChanged" runat="server"
                    Width="100%" AllowSorting="True" AutoGenerateColumns="False" CellPadding="2"
                    CssClass="table" PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="300"
                    RecordCount="0" ShowFooter="True" SortedAscending="yes">
                    <Columns>
                        <asp:BoundColumn HeaderText="StyleSealerAppID" DataField="StyleSealerAppID" Visible="false" />
                        <asp:BoundColumn HeaderText="StyleID" DataField="StyleID" Visible="false" />
                        <asp:BoundColumn HeaderText="Style No" DataField="StyleNo" />
                        <asp:BoundColumn HeaderText="SeasonID" DataField="SeasonID" Visible="false" />
                        <asp:BoundColumn HeaderText="Season" DataField="Season" />
                        <asp:BoundColumn HeaderText="Sealer Approval Date" DataField="SealerApprovalDate" />
                        <asp:TemplateColumn HeaderText="Remove">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Remove" BackColor="transparent"
                                    ImageUrl="~/Images/Remove.png" />
                            </ItemTemplate>
                            <HeaderStyle Width="10%" />
                        </asp:TemplateColumn>
                    </Columns>
                    <PagerStyle Visible="False" CssClass="GridPagerStyle" Mode="NumericPages" HorizontalAlign="Right" />
                    <AlternatingItemStyle CssClass="GridAlternativeRow" />
                    <ItemStyle CssClass="GridRow" />
                    <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                </Smart:SmartDataGrid>
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td style="width: 100px;">
            </td>
            <td style="width: 100px;">
            </td>
            <td style="width: 100px;">
            </td>
             <td  style ="width :100px;"></td> 
              <td  style ="width :100px;"></td> 
            <td style="width: 100px;">
            </td>
            <td style="width: 100px;">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" Visible="false" />
            </td>
            <td>
                <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" Visible="true" />
            </td>
        </tr>
    </table>
</asp:Content>
