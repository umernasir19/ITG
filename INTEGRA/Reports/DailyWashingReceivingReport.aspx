<%@ Page Title="Daily Washing Receiving Report" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="DailyWashingReceivingReport.aspx.vb" Inherits="Integra.DailyWashingReceivingReport" %>
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
                Daily Washing Receiving (Unit Wise) Report
            </th>
        </tr>

            <%--    <tr>
            <th style="padding:8px 5px;">
                <asp:Label ID="Label1" runat="server" Text="Season"></asp:Label>
            </th>
            <td valign="top" style="padding:8px 5px;">
                <asp:DropDownList runat="server" ID="cmbSeason" style="width:140px" autopostback="true">
                </asp:DropDownList>
            </td>
        
            <th style="padding:8px 5px;">
                <asp:Label ID="Label2" runat="server" Text="Sr No"></asp:Label>
            </th>
            <td valign="top" style="padding:8px 5px;">
                <asp:DropDownList runat="server" ID="cmbSrNo" style="width:140px" autopostback="true">
                </asp:DropDownList>
            </td>
            <th style="padding:8px 5px;">
                <asp:Label ID="Label3" runat="server" Text="Color"></asp:Label>
            </th>
            <td valign="top" style="padding:8px 5px;">
                <asp:DropDownList runat="server" ID="cmbColor" style="width:140px">
                </asp:DropDownList>
            </td>
        </tr>--%>
        <tr>

      </table><br />
      <table >
        <tr>
            <td>
                <asp:Label ID="lblForm" runat="server" style="margin-left: 22px;" Text="From :"></asp:Label>
            </td>
            <td valign="top">
                <telerik:RadDatePicker ID="txtDateFrom" runat="server" Culture="en-US">
                    <Calendar ID="Calendar1" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                        runat="server">
                    </Calendar>
                    <DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%" runat="server">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td>
            </td>
            <td>
                <asp:Label ID="lblTo" runat="server" style="margin-left: 14px;" Text="To :"></asp:Label>
            </td>
            <td valign="top">
                <telerik:RadDatePicker ID="txtDateTo" runat="server" Culture="en-US">
                    <Calendar ID="Calendar2" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                        runat="server">
                    </Calendar>
                    <DateInput ID="DateInput2" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
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
    </table><br /><br /><br />
</asp:Content>
