<%@ Page Language="vb" AutoEventWireup="false"  MasterPageFile="~/MasterPage.master"  CodeBehind="ErrorCodes.aspx.vb" Inherits="Integra.ErrorCodes" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 
  <div>
   
        <table style="width: 100%;" align ="center">
          <tr valign ="top" >
         <td style="width: 81px; height: 30px;">
                <asp:Label ID="lblErrorNo" runat="server" Text="Error Code"></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
              <telerik:RadTextBox ID="txtErrorNo" Runat="server" Skin="WebBlue" >
                </telerik:RadTextBox>

            </td>
        </tr>
        <tr valign ="top" >
         <td style="width: 81px; height: 30px;">
                <asp:Label ID="Label1" runat="server" Text="Error Description"></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
              <telerik:RadTextBox ID="txtErrorDescription" Runat="server" Skin="WebBlue" 
                    TextMode ="MultiLine" Width="479px" >
                </telerik:RadTextBox>

            </td>
        </tr>
        </table>
        <table style="width: 100%;" align ="center">
           <tr>
       <td colspan="2" align="right"></td>
            <td colspan="4" align="right">
                <telerik:RadButton ID="btnSave" runat="server" Text="Save" 
                    Skin="WebBlue">
                </telerik:RadButton>&nbsp; &nbsp; &nbsp;
                 <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" 
                 Skin="WebBlue">
                </telerik:RadButton>
            </td>
                 
        
           </tr>      
    </table> 
    </div> 
 </asp:Content>