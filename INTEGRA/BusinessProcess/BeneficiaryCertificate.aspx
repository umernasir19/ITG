<%@ Page Title="Beneficiary Certificate" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="BeneficiaryCertificate.aspx.vb" Inherits="Integra.BeneficiaryCertificate" %>
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

               <asp:TextBox ID="txtRemarksSupplier" runat="server" CssClass="forcapital" ReadOnly ="false"   TextMode ="MultiLine"  AutoPostBack="false" Width="400px" style="margin-left:0px;"></asp:TextBox>
            
            </td>
            </tr>
            </table><br />
              <table  width="100%">
          <tr>
            <td>
                 <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="button" Visible ="true" 
                            Width="85px" style="margin-left: 463px;" /></td>
          </tr>

</table>  <br />
             <table width="100%">
        <tr>
            <th colspan="16" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                BENEFICIARY CERTIFICATE'S
            </th>
        </tr>
    
        </table><br />
        <table width="100%">
             <tr>
            
             <td style="width: 110px;" >

               <asp:TextBox ID="txtRemarks1" runat="server" CssClass="forcapital" ReadOnly ="false"   TextMode ="MultiLine"  AutoPostBack="false" Width="400px" style="margin-left: 0px; margin-top :8px;"></asp:TextBox>
            
            </td>
            <td>
                 <asp:Button ID="btnRem1" runat="server" Text="Print" CssClass="button" Visible ="true" 
                            Width="85px" style="margin-left: 62px;" /></td>
            </tr>
              <tr>
  
             <td style="width: 110px;" >

               <asp:TextBox ID="txtRemarks2" runat="server" CssClass="forcapital" ReadOnly ="false"   TextMode ="MultiLine"  AutoPostBack="false" Width="400px" style="margin-left:0px;margin-top :8px;"></asp:TextBox>
            
            </td>
            <td>
                 <asp:Button ID="btnRem2" runat="server" Text="Print" CssClass="button" Visible ="true" 
                            Width="85px" style="margin-left: 62px;" /></td>
            </tr>
              <tr>
                                    
             <td style="width: 110px;" >

               <asp:TextBox ID="txtRemarks3" runat="server" CssClass="forcapital" ReadOnly ="false"   TextMode ="MultiLine"  AutoPostBack="false" Width="400px" style="margin-left: 0px;margin-top :8px;"></asp:TextBox>
            
            </td>
            <td>
                 <asp:Button ID="btnRem3" runat="server" Text="Print" CssClass="button" Visible ="true" 
                            Width="85px" style="margin-left: 62px;" /></td>
            </tr>
              <tr>
            
             <td style="width: 110px;" >

               <asp:TextBox ID="txtRemarks4" runat="server" CssClass="forcapital" ReadOnly ="false"   TextMode ="MultiLine"  AutoPostBack="false" Width="400px" style="margin-left: 0px;margin-top :8px;"></asp:TextBox>
            
            </td>
            <td>
                 <asp:Button ID="btnRem4" runat="server" Text="Print" CssClass="button" Visible ="true" 
                            Width="85px" style="margin-left: 62px;" /></td>
            </tr>
            </table><br />
          <br />

           <table>
        <tr>
            <td align="center" width="100%" style="height: 22px">
                <asp:Button ID="btnAdd" runat="server" Visible="TRUE" CssClass="button" Text="Back"
                    Width="140px"></asp:Button>
            </td>
        </tr>
    </table>

</asp:Content>
