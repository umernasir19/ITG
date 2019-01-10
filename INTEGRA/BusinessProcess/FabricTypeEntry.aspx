<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="FabricTypeEntry.aspx.vb" Inherits="Integra.FabricTypeEntry" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table>
   <tr><td style="height:20px;"></td></tr>
   <tr>
   <td>  
   </td>
   <td align="left">
    <asp:Label ID="lblMsg" runat="server"  CssClass="ErrorMsg"></asp:Label>
   </td>
   </tr>
 
      <tr>
   <td class="labelNew">
  FabricType:
   </td>
   <td align="left">
 <asp:TextBox ID="txtFabricType" Width="209px"  CssClass="textbox" runat="server"></asp:TextBox>
   </td>
   <td>
   
   </td>
   </tr>  
  
 </table> 
  <table width="100%">
<tr>
<td align="right">
 <asp:Button ID="btnSave" runat="server" Text="Save" Skin="WebBlue">
                    </asp:Button>
</td>
<td>
 <asp:Button  ID="btnCancel" runat="server" Text="Cancel" Skin="WebBlue">
                   </asp:Button>
</td>
</tr>
 </table>
</asp:Content>
