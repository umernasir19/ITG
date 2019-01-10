<%@ Page Language="vb"  MasterPageFile="~/DeversaMaster.master" AutoEventWireup="false" CodeBehind="D_StyleLibrary.aspx.vb" Inherits="Integra.D_StyleLibrary" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%">
<tr>
<td>
    <asp:Label ID="lblmsg" runat="server" CssClass="ErrorMsg"  ></asp:Label>
</td>
</tr>
<tr>
<td>
Style
</td>
<td>
    <asp:TextBox ID="txtStyle" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>
Category
</td>
<td>
    <asp:DropDownList ID="cmbCategory" AutoPostBack="true" runat="server">
    <asp:ListItem Value="0" Text="Men"></asp:ListItem>
      <asp:ListItem Value="1" Text="Women"></asp:ListItem>
        <asp:ListItem Value="2" Text="Kids"></asp:ListItem>
          <asp:ListItem Value="3" Text="Home"></asp:ListItem>
            <asp:ListItem Value="4" Text="Sale"></asp:ListItem>
    </asp:DropDownList>
</td>
</tr>
<tr>
<td>
Description
</td>
<td>
   <asp:TextBox ID="txtDescription"   runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>
Upload Photos (Fornt)
</td>
<td>
    <asp:FileUpload ID="fpFornt" runat="server" />
</td>
</tr>
<tr>
<td>
Upload Photos (Back)
</td>
<td>
    <asp:FileUpload ID="fpBack" runat="server" />
</td>
</tr>
<tr>
<td>
Upload Photos (Left)
</td>
<td>
    <asp:FileUpload ID="fpLeft" runat="server" />
</td>
</tr>
<tr>
<td>
Upload Photos (Right)
</td>
<td>
    <asp:FileUpload ID="fpRight" runat="server" />
</td>
</tr>
<tr>
<td>
Material
</td>
<td>
   <asp:TextBox ID="txtMaterial" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>
Price
</td>
<td>
   <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>
MOQ
</td>
<td>
   <asp:TextBox ID="txtMOQ" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>
 
</td>
<td>
    <asp:Button ID="btnSave" CssClass="button" runat="server" Text="Save" />

   
</td>
</tr>
</table>
</asp:Content>