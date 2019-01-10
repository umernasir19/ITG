<%@ Page Language="vb" MasterPageFile="~/MasterPage.master"  AutoEventWireup="false" CodeBehind="LogisticDepartmentShippedStatus.aspx.vb" Inherits="Integra.LogisticDepartmentShippedStatus" %>
 <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table width="100%">
 <tr>
 <td></td>
 <td class="ErrorMsg">
  <asp:Label ID="lblMsg" runat="server"  ></asp:Label>
 </td>
 </tr>
 <tr>
 <td>
 Customer:
 </td>
 <td>
   <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
    <ContentTemplate>
    <telerik:RadComboBox ID="cmbCustomer" Runat="server" AutoPostBack="True" Skin="WebBlue">
    </telerik:RadComboBox>
     </ContentTemplate>
     </asp:UpdatePanel>
 </td>
 <td>
Currency:
 </td>
 <td>
    <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
    <ContentTemplate>
     <telerik:RadComboBox ID="cmbCurrency" Runat="server" AutoPostBack="True" Skin="WebBlue">
      <Items>
     <telerik:RadComboBoxItem Value="0" Text="Dollar" />
     <telerik:RadComboBoxItem Value="1" Text="Euro" />
     </Items>
    </telerik:RadComboBox>
        </ContentTemplate>
     </asp:UpdatePanel>
 </td>
 </tr>
 <tr >
 <td style="height:10px"></td>
 </tr>
  <tr>
   
 <td>
Year: 
 </td>
 <td>
     <asp:UpdatePanel ID="UpdatePanel3" UpdateMode="Conditional" runat="server">
    <ContentTemplate>
     <telerik:RadComboBox ID="cmbYear" Runat="server" AutoPostBack="True" Skin="WebBlue">
    </telerik:RadComboBox>
    </ContentTemplate>
     </asp:UpdatePanel>
 </td>
 <td>
 Month: 
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
 <td></td>
 <td>

  <telerik:RadButton ID="btnDownload" runat="server" Text="Downlaod Excel Version" 
         Skin="WebBlue" Width="155px"  >
 </telerik:RadButton>
 </td>
 </tr>
   <tr >
 <td style="height:10px"></td>
 </tr>
 <tr>
 <td></td>
 <td>
  <telerik:RadButton ID="btnPDF" runat="server" Text="Downlaod Print Version" 
         Skin="WebBlue" Width="155px"  >
 </telerik:RadButton>
 </td>
 </tr>
   <tr >
 <td style="height:10px"></td>
 </tr>
 </table>
 <table width="100%">
<tr> 
<td  class="labelNew">
<b>
* All selection must be belongs to logistic dept.</b>
</td>
</tr>
</table>

 </asp:Content>