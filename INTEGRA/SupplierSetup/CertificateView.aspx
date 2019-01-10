<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeBehind="CertificateView.aspx.vb" Inherits="Integra.CertificateView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
<table>
<tr>
<td style="height: 40px; width: 140px">
<asp:Label ID="lblSupplier" runat="server" Text="Supplier"></asp:Label>
</td>
<td style="height: 40px; width: 776px">
 <asp:UpdatePanel ID="cmbcmbSupplier" UpdateMode="Conditional" runat="server">
<ContentTemplate>
<telerik:RadComboBox ID="cmbSupplier" Runat="server" Skin="WebBlue" AutoPostBack="true">
 <DefaultItem Text="Select Supplier" />
</telerik:RadComboBox>
      </ContentTemplate>
</asp:UpdatePanel>
</td>
</tr>
<tr>
<td style="height: 44px; width: 140px">
<asp:Label ID="lblCertificateName" runat="server" Text="Certificate Name"></asp:Label>
</td>
<td style="height: 44px; width: 776px">
   <asp:UpdatePanel ID="upcmbCertificate" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
<telerik:RadComboBox ID="cmbCertificate" Runat="server" Skin="WebBlue"></telerik:RadComboBox>
       </ContentTemplate>
 </asp:UpdatePanel>
</td>
</tr>
<tr>
<td style="width: 140px">

</td>
<td class="TopHeaderTable3" style="width: 776px">
   <asp:UpdatePanel ID="upbtnViewCertificate" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
<telerik:RadButton ID="btnViewCertificate" runat="server" Text="View Certificate" Skin="WebBlue"></telerik:RadButton>
           </ContentTemplate>
                 </asp:UpdatePanel>
</td>
</tr>

</table>
</div>
</asp:Content>