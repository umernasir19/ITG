<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="ItemUnit.aspx.vb" Inherits="Integra.ItemUnit" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="main_container">
<div class="header_columns">
<div class="heading">Measuring Unit Item</div>
<br />
<div class="colum ">
<div class ="text_colum ">Measuring Unit:</div>
<div  class ="text_field "><ASP:TextBox ID="txtName" CssClass="textbox" runat ="server" Width="350px" ></ASP:TextBox>
</div>
</div>
<div class ="colum">
<div class="text_colum">Short Name:</div>
<div class="text_field">
<ASP:TextBox  ID="txtUnitPerfix" CssClass="textbox" runat="server"></ASP:TextBox >
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

