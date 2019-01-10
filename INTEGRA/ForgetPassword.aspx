<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ForgetPassword.aspx.vb" Inherits="Integra.ForgetPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Forget Password</title>
    <link href="App_Themes/Blue/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body class="rounded-boxDS">
    <form id="form1" runat="server">
    <div align="center">
   <%-- <table>
    <tr>
    <td style="height:20px" align="center">
        <asp:Label ID="Label2" runat="server" Text="Password Reset Form" Font-Size="X-Large" Font-Bold="True" ForeColor="Red" Font-Underline="True"></asp:Label>
    
    </td>
    </tr>
    <tr>
    <td style="height:20px"></td>
    </tr>
    </table>
    </div>
    <div align="center">
    <table>
   
        <asp:Panel ID="Panel1" runat="server" >
       
    <tr>
    <td>
   Login User Code:
    </td>
    <td>
    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtUserName" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
    </td>
    <td>
    <asp:ImageButton ID="btnShow" runat="server"  CausesValidation="false"   ImageUrl="~/Images/product-design.png" TabIndex="23" />

    </td>
    </tr>
    <tr>
    <td>
    Security Question:
    </td>
    <td align ="left" >
        <asp:Label ID="lbSecurityQ" runat="server" Font-Size="Larger" ForeColor="Red" Font-Bold="true"></asp:Label>
    
    </td>
    </tr>
     <tr>
    <td>
    Answer:
    </td>
    <td>
    <asp:TextBox ID="txtAnswer" runat="server"></asp:TextBox>
    </td>
    <td> 
    <asp:Label ID="Label1" runat="server"></asp:Label>
    </td>
    </tr>
      </asp:Panel>
      <asp:Panel ID="Panel2" runat="server">
      <tr>
    <td>
   Login User Code:
    </td>
    <td>
    <asp:TextBox ID="ttxtUserCode" runat="server"></asp:TextBox>
    </td>
    </tr>
    
     <tr>
    <td>
   Password:
    </td>
    <td>
    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
    </td>
    </tr>
     <tr>
    <td>
   Re-Password:
    </td>
    <td>
    <asp:TextBox ID="txtRepassword" runat="server"></asp:TextBox>
    <asp:CompareValidator ID="cmpdate" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtRepassword" Type="Date" Operator ="Equal"  CssClass="ErrorMsg" ErrorMessage="Password Not Match."></asp:CompareValidator>
    </td>
    </tr>
      </asp:Panel> 
     <tr>
    <td>
    </td>
     <td>
    <asp:button id="btncheck" runat="server" CssClass="button" Text="Check" width="120"></asp:button>
        </td>
        <td>
            <asp:Label ID="lblUserIDHide" runat="server" Visible="false" ></asp:Label>
              
        </td>
        
    </tr>
    
    
    
    </table>--%>
   <table width="100%" align="center">
    <tr>
    <td style="height:20px" align="center">
        <asp:Label ID="Label2" runat="server" Text="Password Reset Form" Font-Size="X-Large" Font-Bold="True" ForeColor="Red" Font-Underline="True"></asp:Label>
    
    </td>
    </tr>
    <tr>
    <td style="height:20px"></td>
    </tr>
    </table>
    
    </div>
    <div>
    <table width="100%" align="center">
    <asp:Panel ID="Panel1"  runat="server" >
    <tr>
    <td class="NormalBoldText" align="right">
    Login User Code:
    </td>
    <td align="left">
    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
    </td>
    <td align="left">
    <asp:ImageButton ID="btnShow" runat="server"  CausesValidation="false"   ImageUrl="~/Images/product-design.png" TabIndex="23" />
    </td>
    <td align="left">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtUserName" runat="server" ErrorMessage="Required!!!" Font-Size="Small" Font-Bold="true"></asp:RequiredFieldValidator>
    
    </td>
    </tr>
    <tr>
    <td  class="NormalBoldText" align="right">
    Security Question:
    </td>
    <td align ="left" >
        <asp:Label ID="lbSecurityQ" runat="server" Font-Size="Small" ForeColor="Red" Font-Bold="true"></asp:Label>
   </td>
    </tr>
     <tr>
    <td class="NormalBoldText" align="right">
    Answer:
    </td>
    <td align="left">
    <asp:TextBox ID="txtAnswer" runat="server"></asp:TextBox>
    </td>
    <td> 
    <asp:Label ID="Label1"  runat="server" ForeColor="Red"  Font-Size="Small" Width="200px"></asp:Label>
    </td>
    </tr>
      </asp:Panel>
      <asp:Panel ID="Panel2" runat="server">
      <tr>
    <td class="NormalBoldText" style="height: 26px" align="right">
   Login User Code:
    </td>
    <td style="height: 26px" align="left">
    <asp:TextBox ID="ttxtUserCode" runat="server"></asp:TextBox>
    </td>
    </tr>
    
     <tr>
    <td class="NormalBoldText" style="height: 26px" align="right">
   Password:
    </td>
    <td style="height: 26px" align="left">
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator2"  runat="server" ErrorMessage="Required !!!" ControlToValidate="txtPassword" Font-Bold="true"></asp:RequiredFieldValidator>
    </td>
    </tr>
     <tr>
    <td class="NormalBoldText" style="height: 26px" align="right">
   Re-Password:
    </td>
    <td style="height: 26px">
    <asp:TextBox ID="txtRepassword" runat="server" TextMode="Password"></asp:TextBox>
    <asp:CompareValidator ID="cmpdate" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtRepassword" Operator ="Equal"  CssClass="ErrorMsg" ErrorMessage="Password Not Match."></asp:CompareValidator>
        </td>
    <td>
       
    </td>
    </tr>
    </asp:Panel>
     <tr>
    <td>
    </td>
     <td align="left">
    <asp:button id="btncheck" runat="server" CssClass="button" Text="Check" width="120"></asp:button>
     </td>
      <td>
            <asp:Label ID="lblUserIDHide" runat="server" Visible="false" ></asp:Label>
              
        </td>
        
    </tr>
    <tr>
    <td align="center" colspan="3" >
        <asp:Label ID="lblMsgShow" runat="server" Text="Password Successfully Changed !" ForeColor="Green" Visible="false" Font-Size="Large"></asp:Label>
    </td>
    </tr>
    
    </table>
</div>

    </form>
</body>
</html>

