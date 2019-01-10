<%@ Page Title="Dead Stock Summary" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="DeadStockSummary.aspx.vb" Inherits="Integra.DeadStockSummary" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table  >
<tr style="border-bottom-style: solid; height :50px; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="6" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                Dead Stock Summary
            </th>
        </tr>
       
       
       
       <tr>
         <td style="width: 110px;">
                Item Category.
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadComboBox ID="cmbItemCategory" runat="server" AutoPostBack="true" Skin="WebBlue"
                    >
                </telerik:RadComboBox>
            </td>


             <td style="width: 110px;">
              Item Name.
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadComboBox ID="cmbItemName" runat="server" AutoPostBack="false" Skin="WebBlue"
                    >
                </telerik:RadComboBox>
            </td>



       </tr>   

        




<tr>
<td></td>
<td  >
  <telerik:RadButton ID="btnGetReport" runat="server" Text="Download Report" Skin="WebBlue"  >
  </telerik:RadButton></td>
</tr>

</table> 
</asp:Content> 

