<%@ Page Title="Consumption Report" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="GGTConsumptionReport.aspx.vb" Inherits="Integra.GGTConsumptionReport" %>
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
    <table width="100%">
    <tr style="border-bottom-style: solid; height :50px; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="6" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                Consumption Report
            </th>
        </tr>
        <tr>
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblDal" runat="server" Text="DAL No"></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
              
                <telerik:RadComboBox ID="cmbDal" runat="server" AutoPostBack="false" Skin="WebBlue">
                </telerik:RadComboBox>
            </td>
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="Label1" runat="server" Text="Style"></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
              
                <telerik:RadComboBox ID="cmbStyle" runat="server" AutoPostBack="false" Skin="WebBlue">
                </telerik:RadComboBox>
            </td>
        </tr>
          <tr>
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="Label2" runat="server" Text="Buyer"></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
              
                <telerik:RadComboBox ID="cmbBuyer" runat="server" AutoPostBack="false" Skin="WebBlue">
                </telerik:RadComboBox>
            </td>
          
        </tr>
        <tr>
<td >
   
    <asp:Label ID="lblForm" runat="server" visible="true"  Text="From :"></asp:Label>
   </td>
<td  valign="top">
<telerik:RadDatePicker ID="txtDateFrom" runat="server" Culture="en-US" visible="true">
<Calendar ID="Calendar1" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" runat="server" visible="true"></Calendar>
<DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" runat="server"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
</telerik:RadDatePicker>
 

</td>
<td  >

    <asp:Label ID="lblTo" runat="server" visible="true" Text="To :"></asp:Label>
</td>

<td  valign="top">
<telerik:RadDatePicker ID="txtDateTo" runat="server" Culture="en-US" visible="true">
<Calendar ID="Calendar2" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" runat="server" visible="true"></Calendar>
<DateInput ID="DateInput2" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" runat="server"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
</telerik:RadDatePicker>
  
</td>
<td>      
    </td>
    <td>
    </td>
</tr>
        <tr>
            <td colspan="2" align="Left">
                <telerik:RadButton ID="btnReport" runat="server" Text="Download Report" Skin="WebBlue" width="65px">
                </telerik:RadButton>
            </td>
        </tr>
    </table>
</asp:Content>
