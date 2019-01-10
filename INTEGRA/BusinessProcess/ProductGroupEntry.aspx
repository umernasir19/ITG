<%@ Page Language="vb"  MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeBehind="ProductGroupEntry.aspx.vb" Inherits="Integra.ProductGroupEntry" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
   Product Group:
   </td>
   <td align="left">
 <asp:TextBox ID="txtProductGroup" Width="209px"  CssClass="textbox" runat="server"></asp:TextBox>
   </td>
   <td>
   
   </td>
   </tr>  
  
 </table> 
  <table width="100%">
<tr>
<td align="right">
 <telerik:RadButton ID="btnSave" runat="server" Text="Save" Skin="WebBlue">
                    </telerik:RadButton>
</td>
<td>
 <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" Skin="WebBlue">
                    </telerik:RadButton>
</td>
</tr>
 </table>

 </asp:Content> 