<%@ Page Title="Supplier List Report" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="SupplierListReport.aspx.vb" Inherits="Integra.SupplierListReport" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript">
    function isNumericKey(e) {
        var charInp = window.event.keyCode;
        if (charInp > 31 && (charInp < 48 || charInp > 57)) {
            return false;
        }
        return true;
    }
    function isNumericKeyy(e) {
        var charInp = window.event.keyCode;
        if (charInp != 46 && (charInp < 48 || charInp > 57)) {
            return false;
        }
        return true;
    }
   
    </script>
    <table>
    <tr style="border-bottom-style: solid; height :50px; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="6" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                Supplier List Sheet
            </th>
        </tr>
        </table>
        <br />
        <table>
        <tr>
             <td style="width: 110px;">
                <asp:Label ID="lblDal" runat="server" Text="Supplier Name"></asp:Label>
            </td>
            <td>
             </td><td>
                <telerik:RadComboBox ID="cmbSupplier" runat="server" AutoPostBack="false" Skin="WebBlue">
                </telerik:RadComboBox>
            </td>


              


        </tr> </table>
        <table>

          <tr>


          <td style="width: 110px;">
                Supplier Code.
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadComboBox ID="cmbSupplierCode" runat="server" AutoPostBack="true" Skin="WebBlue"
                    >
                </telerik:RadComboBox>
            </td>

         <td style="width: 110px;">
               Supplier Category.
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadComboBox ID="cmbSupplierCategory" runat="server" AutoPostBack="true" Skin="WebBlue"
                    >
                </telerik:RadComboBox>
            </td>



          


       </tr>          
        
           </table>
            <br />
        <br />
           <table>
           <tr>
       
        <tr>
            <td colspan="2" align="Left">
                <telerik:RadButton ID="btnReport" runat="server" Text="Gen Report" Skin="WebBlue" width="108px">
                </telerik:RadButton>
            </td>
        </tr>
 </table>
</asp:Content>



