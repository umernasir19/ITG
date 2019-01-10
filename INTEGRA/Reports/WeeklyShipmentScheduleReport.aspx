<%@ Page Title="Weekly Shipment Schedule Report" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="WeeklyShipmentScheduleReport.aspx.vb" Inherits="Integra.WeeklyShipmentScheduleReport" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript">
    function isNumericKey(e) {
        var charInp = window.event.keyCode;
        if (charInp > 31 && (charInp < 48 || charInp > 57)) {
            return false;
        }
        return true;
    }
    function isNumericKeyy(e) {
        var charInp = window.event.keyCode;
        if (charInp != 46 && (charInp < 48 || charInp > 57)) {
            return false;
        }
        return true;
    }
   
    </script>
     <table>
      <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Shipment Schedule
            </th>
        </tr>
        <tr>
            <td style="width: 110px;">
                Season Name.
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadComboBox ID="cmbSeason" runat="server" AutoPostBack="false" Skin="WebBlue">
                </telerik:RadComboBox>
            </td>
              <td style="width: 110px;">
                Buyer.
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadComboBox ID="cmbBuyer" runat="server" AutoPostBack="false" Skin="WebBlue">
                </telerik:RadComboBox>
            </td>
        </tr>
          <tr>
         <td style="width: 110px;">
                SR No.
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadComboBox ID="cmbSrNo" runat="server" AutoPostBack="false" Skin="WebBlue">
                </telerik:RadComboBox>
            </td>
             <td style="width: 110px;">
                Style.
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadComboBox ID="cmbStyle" runat="server" AutoPostBack="false" Skin="WebBlue">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblForm" runat="server" Text="From :"></asp:Label>
            </td>
            <td valign="top">
                <telerik:RadDatePicker ID="txtDateFrom" runat="server" Culture="en-US">
                    <Calendar ID="Calendar3" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                        runat="server">
                    </Calendar>
                    <DateInput ID="DateInput3" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%" runat="server">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td>
                <asp:Label ID="lblTo" runat="server" Text="To :"></asp:Label>
            </td>
            <td valign="top">
                <telerik:RadDatePicker ID="txtDateTo" runat="server" Culture="en-US">
                    <Calendar ID="Calendar4" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                        runat="server">
                    </Calendar>
                    <DateInput ID="DateInput4" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%" runat="server">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 10px">
                Status
            </td>
            <td style="height: 10px">
                <asp:CheckBox runat="server" ID="chkStatus"  />
            </td>
        </tr>
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
        <td>
        </td>
        <tr>
            <td>
            </td>
            <td>
                <telerik:RadButton ID="btnReport" runat="server" Text="Download Report" Skin="WebBlue">
                </telerik:RadButton>
            </td>
        </tr>
    </table>
  
</asp:Content>


