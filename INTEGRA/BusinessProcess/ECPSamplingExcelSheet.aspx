<%@ Page Language="vb" MasterPageFile="~/MasterPage.master"  AutoEventWireup="false" CodeBehind="ECPSamplingExcelSheet.aspx.vb" Inherits="Integra.ECPSamplingExcelSheet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <table  width="100%">
  <tr>
 <td align="center">
 <telerik:RadButton ID="btnDownloadExcel" Text="Download PDM Status"  runat="server"  Skin="WebBlue">
 </telerik:RadButton>
 </td>
 </tr>
 </table>
</asp:Content> 