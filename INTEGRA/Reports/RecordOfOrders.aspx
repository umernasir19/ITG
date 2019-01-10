<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"  CodeBehind="RecordOfOrders.aspx.vb" Inherits="Integra.RecordOfOrders" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <table width="100%">
 <tr style="height:20px">
  <td></td>
  </tr>
  <tr>
  <td  >
  Type:
  </td>
  <td align="left">
  <asp:DropDownList ID="cmbReportType" runat="server" AutoPostBack="true" CssClass="textbox" Width="192px"  >
<asp:ListItem>General</asp:ListItem>
<asp:ListItem>Customer Wise</asp:ListItem>
</asp:DropDownList>
  </td>
  </tr>
  <tr> 
 <td></td>
  <td  >
                <asp:Button ID="btnSreach" runat="server" Text="Generate Report"
                 CssClass="button" Width="122px"  />
                </td></tr>
             
            </table>
     <table width="100%">
                 <tr>
                <td   align="center" style="height: 13px">
              <b>  Please be patient, this report may take longer time to download.</b>
                </td>
                </tr>
            <tr>
      
            <td  align="center">
                <asp:Label ID="lblheading"  runat="server"  >
                </asp:Label>
                </td>
           
            </tr>
            </table>
</asp:Content> 