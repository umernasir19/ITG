<%@ Page Title="Commodity Entry" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="CommodityEntry.aspx.vb" Inherits="Integra.CommodityEntry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table>
        <tr>
            <td>
                Commodity:
            </td>
            <td align="left">
                <asp:TextBox ID="TXTCommodity" runat="server" CssClass="forcapital" AutoPostBack="false" style=""></asp:TextBox>
            </td>
            <td>
            </td>
           
        </tr>
        <tr>
       
        </table>
         <br />
          <br />

         <table>
         <tr>
         <td>
         
        
          <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button"
                            Width="120px"  />
         </td>
            <td>
         
        
          <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button"
                            Width="120px"  />
         </td>
         </tr> </table>
</asp:Content>
