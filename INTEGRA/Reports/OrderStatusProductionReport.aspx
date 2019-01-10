<%@ Page Title="Order Status Production Report" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="OrderStatusProductionReport.aspx.vb" Inherits="Integra.OrderStatusProductionReport" %>
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
                Order Status Production Report
            </th>
        </tr>
                <%--<tr>
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
        </table><br /><table>
         <tr>
            <th style="padding:8px 5px;">
                <asp:Label ID="Label1" runat="server" Text="Season"></asp:Label>
            </th>
            <td valign="top" style="padding:8px 5px;">
                <asp:DropDownList runat="server" ID="cmbSeason" style="width:120px" autopostback="true">
                </asp:DropDownList>
            </td>
        
            <th style="padding:8px 5px;">
                <asp:Label ID="Label2" runat="server" Text="Sr No"></asp:Label>
            </th>
            <td valign="top" style="padding:8px 5px;">
              
                 <telerik:RadComboBox ID="cmbSrNoo" runat="server" CheckBoxes="True" Width="120px"
                        Skin="WebBlue">
                    </telerik:RadComboBox>
                    &nbsp;
                    <asp:Label ID="lblSrNo" runat="server"></asp:Label>

            </td>
          
            <td valign="top" style="padding:8px 5px;">
                <asp:DropDownList runat="server" ID="cmbColor" style="width:140px" Visible="false" >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
             <th style="padding:8px 5px;">
                <asp:Label ID="Label4" runat="server" Text="Month:"></asp:Label>
            </th>
            <td valign="top">

            <div style=" margin-left: 5px;">
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
                </div>

            </td>
                    <th style="padding:8px 5px;">
                <asp:Label ID="Label3" runat="server" Text="Year:"></asp:Label>
            </th>
            <td valign="top">
            <div style=" margin-left: 5px;">
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
          </div>   </td>
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
             <div style=" margin-left: 8px;">
                <telerik:RadButton ID="btnReport" runat="server" Text="Download Report" Skin="WebBlue">
                </telerik:RadButton></div> 
            </td>
        </tr>
    </table>
  
</asp:Content>



