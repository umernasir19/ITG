<%@ Page Language="vb" MasterPageFile="~/MasterPage.master"  AutoEventWireup="false" CodeBehind="DownloadExcelSheet.aspx.vb" Inherits="Integra.DownloadExcelSheet" %>
 <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <table  width="100%" >
 <tr>
 <td>
 Type
 </td>
 <td ></td>
 <td>
 <telerik:RadComboBox ID="cmbType" Runat="server" AutoPostBack="True" Skin="WebBlue">
 <Items>
 <telerik:RadComboBoxItem Value="0" Text="Bank Transaction" />
  <telerik:RadComboBoxItem Value="1" Text="Cash Transaction" />
  <telerik:RadComboBoxItem Value="2" Text="Bank Ledger" />
   <telerik:RadComboBoxItem Value="3" Text="Cash Book" />
    <telerik:RadComboBoxItem Value="4" Text="Cost Center Analysis" />
     <telerik:RadComboBoxItem Value="5" Text="Budget Forecast" />
 </Items>
    </telerik:RadComboBox>
 </td>
 </tr>
  <tr>
 <td>
Year
 </td>
  <td></td>
 <td>
   <telerik:RadComboBox ID="cmbYear" Runat="server" AutoPostBack="True" Skin="WebBlue">
    </telerik:RadComboBox>
 </td>
 <td>
 Month
 </td>

 <td>
  <telerik:RadComboBox ID="cmbMonth" Runat="server" AutoPostBack="True" Skin="WebBlue">
    </telerik:RadComboBox>
   
 </td>
 
 </tr>
  <tr >
 <td style="height:10px"></td>
 </tr>
 <tr>
 <td></td> <td></td>
 <td>

  <telerik:RadButton ID="btnDownload" runat="server" Text="Downlaod" 
         Skin="WebBlue" Width="155px"  >
 </telerik:RadButton>
 </td>
 </tr>
   <tr >
 <td style="height:10px"></td>
 </tr>
 
    
 </table>
</asp:Content> 
