<%@ Page Language="vb" MasterPageFile="~/MasterPage.master"  AutoEventWireup="false" CodeBehind="TypeOfSamplingEntry.aspx.vb" Inherits="Integra.TypeOfSamplingEntry" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table>
  <th colspan ="5" align="left"   style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080;" > Purchase Order Information</th>
<tr>
<td>
Type Name:
</td>
<td>
   <telerik:RadTextBox ID="txtTypeName" Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
</td>
</tr>
<tr>
<td> 
    <telerik:RadButton ID="btnSave" runat="server" Text="Save" 
                    Skin="WebBlue">
                </telerik:RadButton>
</td>
<td> 
       <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" 
                 Skin="WebBlue">
                </telerik:RadButton>
</td>
</tr>
</table>
</asp:Content> 