<%@ Page Title="Daily Offline Sheet" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="DailyOfflineSheet.aspx.vb" Inherits="Integra.DailyOfflineSheet" %>
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
                Daily Offline Sheet
            </th>
        </tr>
        <tr>
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
              
                 <telerik:RadComboBox ID="cmbSrNoo" runat="server" CheckBoxes="True" Width="140"
                        Skin="WebBlue">
                    </telerik:RadComboBox>
                    &nbsp;
                    <asp:Label ID="lblSrNo" runat="server"></asp:Label>

            </td>
           <%-- <th style="padding:8px 5px;">
                <asp:Label ID="Label3" runat="server" Text="Color"></asp:Label>
            </th>--%>
            <td valign="top" style="padding:8px 5px;">
                <asp:DropDownList runat="server" ID="cmbColor" style="width:140px" Visible="false" >
                </asp:DropDownList>
            </td>
        </tr>
       
    


      </table><br />
     <table >
        <tr>
            <td >
                <asp:Label ID="lblForm" runat="server" style="margin-left: 24px;" Text="Date :"></asp:Label>
            </td>

            <td valign="top">
            <%--<asp:TextBox ID="txtDate" runat="server" CssClass="combo" style="margin-left: -36px; width: 104px;"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="imagedtbtn"
                    TargetControlID="txtDate" Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
                <asp:ImageButton ID="imagedtbtn" runat="Server" ImageUrl="~/Images/calendar.JPG"
                    CausesValidation="false" AlternateText="Click here to display calendar"></asp:ImageButton>
                <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Enabled="True" TargetControlID="txtDate"
                    AutoComplete="False" UserDateFormat="DayMonthYear" CultureTimePlaceholder=":"
                    CultureThousandsPlaceholder="," CultureDecimalPlaceholder="." CultureDatePlaceholder="/"
                    CultureDateFormat="YMD" CultureCurrencySymbolPlaceholder="" CultureAMPMPlaceholder="AM;PM"
                    MaskType="Date" Century="2000" Mask="99/99/9999">
                </cc1:MaskedEditExtender>--%>

                <telerik:RadDatePicker ID="txtDate" runat="server" Culture="en-US">
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
            </td>
            <td>
                <%--<asp:Label ID="lblTo" runat="server" Text="To :"></asp:Label>--%>
            </td>
            <td valign="top">
                <%--<telerik:RadDatePicker ID="txtDateTo" runat="server" Culture="en-US">
                    <Calendar ID="Calendar4" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                        runat="server">
                    </Calendar>
                    <DateInput ID="DateInput4" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%" runat="server">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>--%>
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
    </table>
</asp:Content>


