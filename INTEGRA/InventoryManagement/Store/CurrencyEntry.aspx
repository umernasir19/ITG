<%@ Page Title="Currency Entry" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="CurrencyEntry.aspx.vb" Inherits="Integra.CurrencyEntry" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="main_container">
<div class="header_columns">
<div class="heading">Currency Panel</div>
<br />
<div class="colum ">
<div class ="text_colum "> Currency:</div>
<div  class ="text_field "><ASP:TextBox ID="txtCurrency" CssClass="textbox" runat ="server" Width="350px" ></ASP:TextBox>
</div>
</div>

 </div>
<br />
<table width="100%">
<tr>
<td align="right">
  <ASP:Button ID="btnSave" runat="server" Skin="WebBlue" 
        Text="Save" ButtonType="SkinnedButton" Font-Bold="True" 
        Font-Names="Calibri" Font-Size="Medium" Height="30px" Width="120px">
    </ASP:Button>
</td>
<td>
<ASP:Button ID="btnCancel" runat="server" Skin="WebBlue" 
        Text="Cancel" ButtonType="SkinnedButton" Font-Bold="True" 
        Font-Names="Calibri" Font-Size="Medium" Height="30px" Width="110px">
    </ASP:Button>
</td>
</tr>
</table>
</div>
</asp:Content>





