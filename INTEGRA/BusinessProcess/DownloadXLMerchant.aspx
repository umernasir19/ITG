<%@ Page Language="vb" MasterPageFile="~/MasterPage.master"  AutoEventWireup="false" CodeBehind="DownloadXLMerchant.aspx.vb" Inherits="Integra.DownloadXLMerchant" %>
 <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <table  width="100%">
 
   <tr >
 <td align="center">
 <asp:UpdatePanel ID="upcmbYYear" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
     <telerik:RadComboBox ID="cmbYYear" Runat="server" AutoPostBack="True" Skin="WebBlue">
     <Items>
       <telerik:RadComboBoxItem Value="0" Text="2014 & above Item Vise" />
         <telerik:RadComboBoxItem Value="1" Text="2014 & above PO. Vise" />
     </Items>
     </telerik:RadComboBox>
           </ContentTemplate>
</asp:UpdatePanel>   
 </td>
  </tr>
   <tr>
 <td align="center">
 <telerik:RadButton ID="btnsupplychn" Text="Download Order Status"  runat="server"  Skin="WebBlue">
 </telerik:RadButton>
 </td>
 </tr>
 </table>
</asp:Content>
