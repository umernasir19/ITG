<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="ProductionStatus.aspx.vb" Inherits="Integra.ProductionStatus1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%">
        <%--'-------Heading Row--------'--%>
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="5" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
              Production Status
            </th>
        </tr>
    </table>
    <table>
        <tr>
            <td style="width: 100px;">
                Customer
            </td>
            <td>
                <asp:DropDownList ID="cmbCustomer" runat="server" Style="width: 140px; margin-left: 75px;" AutoPostBack="true">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height:35px;">
            <td>
               Department
            </td>
            <td>
                <asp:DropDownList ID="cmbDept" runat="server"  AutoPostBack="true" Style="width: 140px; margin-left: 75px;" >
                </asp:DropDownList>
            </td>
        </tr>
           
           <tr style="height:35px;">
            <td>
               Supplier
            </td>
            <td>
                <asp:DropDownList ID="cmbSupplier" runat="server" Style="width: 140px; margin-left: 75px;" >
                </asp:DropDownList>
            </td>
        </tr>
          <tr>
            <td>
                Start Date
            </td>
            <td>
              <telerik:RadDatePicker ID="txtStartDatee" runat="server" Culture="en-US">
                    <Calendar ID="Calendar2" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                        runat="server">
                    </Calendar>
                    <DateInput ID="DateInput2" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        runat="server">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
              <%--  <asp:TextBox ID="txtStartDate" Width="100" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server" TargetControlID="txtStartDate"
                    PopupButtonID="ImageButton3" />
                <asp:ImageButton runat="Server" ID="ImageButton3" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                    AlternateText="Click here to display calendar" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtStartDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>--%>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                End Date
            </td>
            <td>
             <telerik:RadDatePicker ID="txtEndDatee" runat="server" Culture="en-US">
                    <Calendar ID="Calendar1" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                        runat="server">
                    </Calendar>
                    <DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        runat="server">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
              <%--  <asp:TextBox ID="txtEndDate" Width="100" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="txtEndDate"
                    PopupButtonID="ImageButton2" />
                <asp:ImageButton runat="Server" ID="ImageButton2" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                    AlternateText="Click here to display calendar" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtEndDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>--%>
            </td>
        </tr>
    </table>
      <br />
    <table width="100%">
        <tr>
            <td align="center">
                <asp:Button ID="btnReport" runat="server" Text="View Report" Style="margin-left: 19px;" />
            </td>
        </tr>
    </table>
</asp:Content>
