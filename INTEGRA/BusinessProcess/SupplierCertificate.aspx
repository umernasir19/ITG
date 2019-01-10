<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="SupplierCertificate.aspx.vb" Inherits="Integra.SupplierCertificate" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
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
 <table width="100%">
        <tr>
            <th colspan="16" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                SUPPLIER CERTIFICATE
            </th>
        </tr>
    
        </table><br />
<table width="100%">

 <tr>
            <td style="width: 110px;">
               INVOICE NO#:
            </td>

            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <asp:TextBox ID="txtInvoice" runat="server" CssClass="forcapital" ReadOnly ="false"  
                AutoPostBack="false" Width="150px" style=" margin-left: -148px;"></asp:TextBox>
            
                       </td>

          </tr>
            <tr>
              <td style="width: 110px;">
                DATED:
            </td>
            <td style="width: 110px;">

            <telerik:RadDatePicker ID="txtInvoiceDate" runat="server" Culture="en-US" Width="100px" style="margin-left: -148px;">
              <Calendar ID="Calendar3" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
              </Calendar>
              <DateInput ID="DateInput3" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
              LabelWidth="40%">
               </DateInput>
              <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
               </telerik:RadDatePicker>            
            </td>
            </tr>
            <tr>
            <td style="width: 110px;">
            LC #:
            </td>
               <td style="width: 110px;">
            <asp:TextBox ID="txtLCNo" runat="server" CssClass="forcapital" ReadOnly ="false"   AutoPostBack="false" Width="150px" style=" margin-left: -148px;margin-top: 2px;"></asp:TextBox>
            </td>
          </tr>
            <tr>
             <td style="width: 110px;">
             LC DATE:
            </td>
            <td style="width: 110px;">
              <telerik:RadDatePicker ID="txtLCDate" runat="server" Culture="en-US" Width="100px" style=" margin-left: -148px;">
              <Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
              </Calendar>
              <DateInput ID="DateInput1" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
              LabelWidth="40%">
               </DateInput>
              <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
               </telerik:RadDatePicker>
                            
            </td>
            </tr>

             <tr>
            
              <td>
            
            </td>
            
             <td style="width: 110px;" >

               <asp:TextBox ID="txtRemarks" runat="server" CssClass="forcapital" ReadOnly ="false"   TextMode ="MultiLine"  AutoPostBack="false" Width="400px" style="margin-left: -148px;"></asp:TextBox>
            
            </td>
            </tr>
            </table><br />
            <table  width="100%">
          <tr>
            <td>
                 <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="button" Visible ="true" 
                            Width="120px" /></td>
          </tr>

</table>    
</asp:Content>
