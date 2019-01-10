<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="SupplierCriticalPathTracking.aspx.vb" Inherits="Integra.SupplierCriticalPathTracking" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <table width="100%">
   <tr>
            <td>
               Customer
            </td>
            <td>
                <asp:DropDownList ID="cmbCustomer" AutoPostBack="true" runat="server" Width="140"
                    ToolTip="select Customer">
                </asp:DropDownList>
            </td>
        </tr>
           <tr>
            <td>
               Buyer
            </td>
            <td>
                <asp:DropDownList ID="cmbBuyer" AutoPostBack="false" runat="server" Width="140"
                    ToolTip="select Buyer">
                </asp:DropDownList>
            </td>
        </tr>
          <tr>
            <td>
                Brand
        
            </td>
            <td>
                <asp:DropDownList ID="CmbBrand" AutoPostBack="false" runat="server" Visible="true"
                    Width="140" ToolTip="Select Brand" >
                </asp:DropDownList>
            </td>
        </tr>
           <tr>
            <td>
                Buying Dept.
            </td>
            <td>
                <asp:DropDownList ID="cmbBuyingDept" AutoPostBack="false" runat="server" Width="140"
                    ToolTip="select Style No">
                </asp:DropDownList>
            </td>
        </tr>
         <tr>
            <td>
                Season
            </td>
            <td>
                <asp:DropDownList ID="cmbSeason" AutoPostBack="false" runat="server" Width="140"
                    ToolTip="select Style No">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
               Supplier
            </td>
            <td>
                <asp:DropDownList ID="cmbSupplier" AutoPostBack="false" runat="server" Width="140" ToolTip="select Supplier">
                </asp:DropDownList>
            </td>
            </tr>
     <%--    <tr style="height: 35px;">
            <td>
                Arrange By
            </td>
            <td>
                <asp:DropDownList ID="cmbType" AutoPostBack="false" runat="server" Width="140" ToolTip="Select Type">
                    <asp:ListItem Value="0">By Date</asp:ListItem>
                    <asp:ListItem Value="1">By Time</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>--%>
        <tr  >
            <td>
                Start Date
            </td>
            <td>
                <asp:TextBox ID="txtStartDate" Width="100" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server" TargetControlID="txtStartDate"
                    PopupButtonID="ImageButton3" />
                <asp:ImageButton runat="Server" ID="ImageButton3" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                    AlternateText="Click here to display calendar" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtStartDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                End Date
            </td>
            <td>
                <asp:TextBox ID="txtEndDate" Width="100" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="txtEndDate"
                    PopupButtonID="ImageButton2" />
                <asp:ImageButton runat="Server" ID="ImageButton2" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                    AlternateText="Click here to display calendar" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtEndDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>
            </td>
        </tr>
        <tr  style="height: 35px;">
            <td>
                Meeting Date
            </td>
            <td>
                <asp:TextBox ID="txtMeetingDate" Width="100" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtMeetingDate"
                    PopupButtonID="ImageButton4" />
                <asp:ImageButton runat="Server" ID="ImageButton4" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                    AlternateText="Click here to display calendar" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtMeetingDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td align="center">
                <asp:Button ID="btnView" runat="server" Text="View Report" />
            </td>
        </tr>
    </table>
</asp:Content>
