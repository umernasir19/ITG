<%@ Page Title="Monthly Shipment Report" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="MonthlyShipmentReport.aspx.vb" Inherits="Integra.MonthlyShipmentReport" %>
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
                Monthly Shipment Report
            </th>
        </tr>
        </table><br /><table>
        <tr>
         <td style="width: 110px;">
               Buyer
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadComboBox ID="cmbBuyer" runat="server" AutoPostBack="false" Skin="WebBlue">
                </telerik:RadComboBox>
            </td>
             <td style="width: 110px;">
                Invoice No#
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadComboBox ID="cmbInvoice" runat="server" AutoPostBack="false" Skin="WebBlue">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
         <td style="width: 110px;">
              Order No#
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadComboBox ID="cmbOrder" runat="server" AutoPostBack="false" Skin="WebBlue">
                </telerik:RadComboBox>
            </td>
            </tr> 
        <tr>
            <td>
                <asp:Label ID="lblForm" runat="server" Text="Month :"></asp:Label>
            </td>
            <td valign="top">
               <telerik:RadComboBox ID="cmbMonth" Width="120px" runat="server" AutoPostBack="false"
                    Skin="WebBlue">
                    <Items>
                        <telerik:RadComboBoxItem Value="0" Text="All" />
                        <telerik:RadComboBoxItem Value="1" Text="01" />
                        <telerik:RadComboBoxItem Value="2" Text="02" />
                        <telerik:RadComboBoxItem Value="3" Text="03" />
                        <telerik:RadComboBoxItem Value="4" Text="04" />
                        <telerik:RadComboBoxItem Value="5" Text="05" />
                        <telerik:RadComboBoxItem Value="6" Text="06" />
                        <telerik:RadComboBoxItem Value="7" Text="07" />
                        <telerik:RadComboBoxItem Value="8" Text="08" />
                        <telerik:RadComboBoxItem Value="9" Text="09" />
                        <telerik:RadComboBoxItem Value="10" Text="10" />
                        <telerik:RadComboBoxItem Value="11" Text="11" />
                        <telerik:RadComboBoxItem Value="12" Text="12" />
                    </Items>
                </telerik:RadComboBox>
            </td>
                      <td>
                <asp:Label ID="lblTo" runat="server" Text="Year :"></asp:Label>
            </td>
            <td valign="top">
              <telerik:RadComboBox ID="cmbYear" runat="server" Width="120px" AutoPostBack="false"
                    Skin="WebBlue">
                    <Items>
                        <telerik:RadComboBoxItem Value="0" Text="All" />
                        <telerik:RadComboBoxItem Value="1" Text="2014" />
                        <telerik:RadComboBoxItem Value="2" Text="2015" />
                        <telerik:RadComboBoxItem Value="3" Text="2016" />
                        <telerik:RadComboBoxItem Value="4" Text="2017" />
                        <telerik:RadComboBoxItem Value="5" Text="2018" />
                        <telerik:RadComboBoxItem Value="6" Text="2019" />
                        <telerik:RadComboBoxItem Value="7" Text="2020" />
                        <telerik:RadComboBoxItem Value="8" Text="2021" />
                        <telerik:RadComboBoxItem Value="9" Text="2022" />
                        <telerik:RadComboBoxItem Value="10" Text="2023" />
                        <telerik:RadComboBoxItem Value="11" Text="2024" />
                        <telerik:RadComboBoxItem Value="12" Text="2025" />
                    </Items>
                </telerik:RadComboBox>
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


