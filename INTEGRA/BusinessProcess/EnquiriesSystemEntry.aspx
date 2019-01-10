<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="EnquiriesSystemEntry.aspx.vb" Inherits="Integra.EnquiriesSystemEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Enquiries  
            </th>
        </tr>
        <tr>
            <td>
                Enq. No.
            </td>
            <td>
                <asp:TextBox ID="txtEnqNo" CssClass="textbox" runat="server"></asp:TextBox>
            </td>
            <td>
                Enq. Date
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <asp:TextBox ID="InqDate" Width="100" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server" TargetControlID="InqDate"
                    PopupButtonID="ImageButton3" />
                <asp:ImageButton runat="Server" ID="ImageButton3" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                    AlternateText="Click here to display calendar" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="InqDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>
            </td>
            <td>
                Enq. Type
            </td>
            <td>
                <asp:DropDownList ID="cmbEnqType" runat="server" Width="120">
                    <asp:ListItem Value="0" Text="Initial"></asp:ListItem>
                    <asp:ListItem Value="1" Text="Repeat"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Customer
            </td>
            <td>
                <asp:DropDownList ID="cmbCustomer" AutoPostBack="true" runat="server" Width="140">
                </asp:DropDownList>
            </td>
            <td>
                Supplier
            </td>
            <td>
                <asp:DropDownList ID="cmbSupplier" AutoPostBack="true" runat="server" Width="180">
                </asp:DropDownList>
            </td>
            <td>
                Dept.
            </td>
            <td>
                <asp:TextBox ID="txtDept" CssClass="textbox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Season
            </td>
            <td>
             <asp:TextBox ID="txtSeason" CssClass="textbox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Article Description
            </th>
        </tr>
        <tr>
            <td>
                Art. Name
            </td>
            <td>
                <asp:TextBox ID="txtArtName" runat="server"></asp:TextBox>
            </td>
            <td>
                Art. No
            </td>
            <td>
                <asp:TextBox ID="txtArtNo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Colorways
            </td>
            <td>
                <asp:TextBox ID="txtColorways" runat="server"></asp:TextBox>
            </td>
            <td>
                MOQ / Qty.
            </td>
            <td>
                <asp:TextBox ID="txtQty" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
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
                        <asp:BoundColumn HeaderText="Detail ID" DataField="EnquiriesSystemDetailID" Visible="False" />
                        <asp:BoundColumn HeaderText="Art. Name" DataField="ArtName">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Art. No" DataField="ArtNo">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Colorways" DataField="Colorways">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="MOQ / Qty" DataField="MOQorQty">
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
            <td>
                Status:
            </td>
            <td align="left">
                <asp:DropDownList ID="cmbStatus" AutoPostBack="true" runat="server" Width="120">
                    <asp:ListItem Value="0" Text="Unconfirmed"></asp:ListItem>
                    <asp:ListItem Value="1" Text="Confirmed"></asp:ListItem>
                    <asp:ListItem Value="2" Text="Cancelled"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblConfirmedDate" runat="server" Text=" Confirmed Date:"></asp:Label>
               
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <asp:TextBox ID="txtConfirmedDate" Width="100" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtConfirmedDate"
                    PopupButtonID="ImageButton1" />
                <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                    AlternateText="Click here to display calendar" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtConfirmedDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>
            </td>
            <td>
                <asp:Label ID="lblPONo" runat="server" Text=" PO No."></asp:Label>
               
            </td>
            <td>
                <asp:TextBox ID="txtPONO" CssClass="textbox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblRemarks" runat="server" Text="Remarks:"></asp:Label>
               
            </td>
            <td>
                <asp:TextBox ID="txtRemarks" runat="server"></asp:TextBox>
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
