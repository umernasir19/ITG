<%@ Page Title="Mail Realization" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="MailRealizationAdd.aspx.vb" Inherits="Integra.MailRealizationAdd" %>
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
      function TABLE1_onclick() {

      }

    </script>
     <table width="100%">
             <tr style="height: 35px;">
            <td>
                <div class="txt_newwww" style="width: 140px; margin-left: 0px;">
                    TO :
                </div>
            </td>
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtToEmail" Width ="300px" PlaceHolder="example@someone.com" CssClass="textbox" runat="server" Style="margin-left: -435px;
                        height: 20px;" ReadOnly="false" AutoPostBack="false">
                                                </asp:TextBox>
                                                <br/>
                     </div>   
                     </td>
                     <td>
                     <asp:RegularExpressionValidator ID="EmailFormat" runat="server" Text="Please enter a valid Email" ToolTip="Please enter a valid Email" ControlToValidate="txtToEmail" ValidationExpression="(\w)+@(\w)+.com(.(\w)+)*" ForeColor="Red" style="margin-left: -236px;"  />

                     </td>
                     </tr> 
    </table><br />
    <table width="100%">
      <tr class="heading">
            <td>
                &nbsp; <b>THE REFRRED PAYMENT HAS BEEN REALIZED. DETAILS AS BELOW </b>:-
            </td>
        </tr>
    </table><br />
     <table width="100%">
             <tr style="height: 35px;">
            <td>
                <div class="txt_newwww" style="width: 140px; margin-left: 0px;">
                   BUYERS :
                </div>
            </td>
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtBuyer" Width ="300px" CssClass="textbox" runat="server" Style="margin-left: -551px;
                        height: 20px;" ReadOnly="false" AutoPostBack="false"></asp:TextBox>
                     </div>   
                     </td>
                     </tr> 
                       <tr style="height: 35px;">
            <td>
                <div class="txt_newwww" style="width: 140px; margin-left: 0px;">
                   INVOICE # :
                </div>
            </td>
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtInvoice" Width ="300px" CssClass="textbox" runat="server" Style="margin-left: -551px;
                        height: 20px;" ReadOnly="false" AutoPostBack="false"></asp:TextBox>
                     </div>   
                     </td>
                     </tr> 
                      <tr style="height: 35px;">
            <td>
                <div class="txt_newwww" style="width: 140px; margin-left: 0px;">
                   INV.AMOUNT :
                </div>
            </td>
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtInvAmt" Width ="300px" CssClass="textbox" runat="server" Style="margin-left: -551px;
                        height: 20px;" ReadOnly="false" AutoPostBack="false"></asp:TextBox>
                     </div>   
                     </td>
                     </tr> 
                      <tr style="height: 35px;">
            <td>
                <div class="txt_newwww" style="width: 140px; margin-left: 0px;">
                   EXCHANGE :
                </div>
            </td>
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtExchange" Width ="300px" CssClass="textbox" runat="server" Style="margin-left: -551px;
                        height: 20px;" ReadOnly="false" AutoPostBack="false"></asp:TextBox>
                     </div>   
                     </td>
                     </tr> 
                      <tr style="height: 35px;">
            <td>
                <div class="txt_newwww" style="width: 140px; margin-left: 0px;">
                   PKR :
                </div>
            </td>
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtPkr" Width ="300px" CssClass="textbox" runat="server" Style="margin-left: -551px;
                        height: 20px;" ReadOnly="false" AutoPostBack="false"></asp:TextBox>
                     </div>   
                     </td>
                     </tr> 
                        <tr style="height: 35px;">
            <td>
                <div class="txt_newwww" style="width: 140px; margin-left: 0px;">
                   LC TENOR :
                </div>
            </td>
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtLc" Width ="300px" CssClass="textbox" runat="server" Style="margin-left: -551px;
                        height: 20px;" ReadOnly="false" AutoPostBack="false"></asp:TextBox>
                     </div>   
                     </td>
                     </tr> 
                        <tr style="height: 35px;">
            <td>
                <div class="txt_newwww" style="width: 140px; margin-left: 0px;">
                   BANK :
                </div>
            </td>
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtBank" Width ="300px" CssClass="textbox" runat="server" Style="margin-left: -551px;
                        height: 20px;" ReadOnly="false" AutoPostBack="false"></asp:TextBox>
                     </div>   
                     </td>
                     </tr> 
                      <tr style="height: 35px;">
            <td>
                <div class="txt_newwww" style="width: 140px; margin-left: 0px;">
                   REMARKS :
                </div>
            </td>
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtRemarkss" Width ="300px" CssClass="textbox" runat="server" Style="margin-left: -551px;
                        height: 20px;" ReadOnly="false" AutoPostBack="false"></asp:TextBox>
                     </div>   
                     </td>
                     </tr> 
    </table><br />
     <table width="60%">
        <tr style="height: 30px;">
            <td align="center">
        <asp:Button ID="btnSendEmail" ToolTip="Click here To Send Email." CssClass="btn btn-outline btn-success"
                    runat="server" Text="Send Email" Width="120px" />
            </td>
        </tr>
    </table>
    <asp:Panel id="Pnlgmdaily" runat="server" Visible="false">
  <table width="100%">
  <tbody>
                <tr style="HEIGHT: 15px"></tr>
                <tr class="heading"><td>&nbsp; <b>MAIL REALIZATION </b></td></tr><tr style="HEIGHT: 8px">
                </tr>
                </tbody>
                </table>
                <table style="BORDER-RIGHT: #000 1px solid; BORDER-TOP: #000 1px solid; BORDER-LEFT: #000 1px solid; BORDER-BOTTOM: #000 1px solid" width="100%">
               <tbody>
                <tr style="BORDER-RIGHT: #000 1px solid; BORDER-TOP: #000 1px solid; BORDER-LEFT: #000 1px solid; BORDER-BOTTOM: #000 1px solid">
                <td style="FONT-SIZE: 16px; BACKGROUND-COLOR: lightblue">
                <asp:Label id="lblBuyer" runat="server" Text="BUYER">
                </asp:Label></td>
                <td><asp:Label style="FONT-SIZE: 16px; BACKGROUND-COLOR: white" id="lblbuy" runat="server"></asp:Label>
                </td>
                </tr>
                <tr style="BORDER-RIGHT: #000 1px solid; BORDER-TOP: #000 1px solid; BORDER-LEFT: #000 1px solid; BORDER-BOTTOM: #000 1px solid">
                <td style="FONT-SIZE: 16px; BACKGROUND-COLOR: lightblue">
                <asp:Label id="lblInv" runat="server" Text="INVOICE NO.">
                </asp:Label>
                </td>
                <td>
                <asp:Label style="FONT-SIZE: 16px; BACKGROUND-COLOR: white" id="lbli" runat="server"></asp:Label>
                </td>
                </tr>
                <tr style="BORDER-RIGHT: #000 1px solid; BORDER-TOP: #000 1px solid; BORDER-LEFT: #000 1px solid; BORDER-BOTTOM: #000 1px solid">
                <td style="FONT-SIZE: 16px; BACKGROUND-COLOR: lightblue">
                <asp:Label id="lblia" runat="server" Text="INVOICE AMOUNT">
                </asp:Label>
                </td>
                <td>
                <asp:Label style="FONT-SIZE: 16px; BACKGROUND-COLOR: white" id="lblInvAmt" runat="server"></asp:Label>
                </td>
                </tr>
                  <tr style="BORDER-RIGHT: #000 1px solid; BORDER-TOP: #000 1px solid; BORDER-LEFT: #000 1px solid; BORDER-BOTTOM: #000 1px solid">
                <td style="FONT-SIZE: 16px; BACKGROUND-COLOR: lightblue">
                <asp:Label id="lble" runat="server" Text="EXCHANGE">
                </asp:Label></td>
                <td><asp:Label style="FONT-SIZE: 16px; BACKGROUND-COLOR: white" id="lblEx" runat="server"></asp:Label>
                </td>
                </tr>
                  <tr style="BORDER-RIGHT: #000 1px solid; BORDER-TOP: #000 1px solid; BORDER-LEFT: #000 1px solid; BORDER-BOTTOM: #000 1px solid">
                <td style="FONT-SIZE: 16px; BACKGROUND-COLOR: lightblue">
                <asp:Label id="lblp" runat="server" Text="PKR">
                </asp:Label></td>
                <td><asp:Label style="FONT-SIZE: 16px; BACKGROUND-COLOR: white" id="lblPkr" runat="server"></asp:Label>
                </td>
                </tr>
                  <tr style="BORDER-RIGHT: #000 1px solid; BORDER-TOP: #000 1px solid; BORDER-LEFT: #000 1px solid; BORDER-BOTTOM: #000 1px solid">
                <td style="FONT-SIZE: 16px; BACKGROUND-COLOR: lightblue">
                <asp:Label id="lbll" runat="server" Text="LC NO.">
                </asp:Label></td>
                <td><asp:Label style="FONT-SIZE: 16px; BACKGROUND-COLOR: white" id="lblLc" runat="server"></asp:Label>
                </td>
                </tr>
                  <tr style="BORDER-RIGHT: #000 1px solid; BORDER-TOP: #000 1px solid; BORDER-LEFT: #000 1px solid; BORDER-BOTTOM: #000 1px solid">
                <td style="FONT-SIZE: 16px; BACKGROUND-COLOR: lightblue">
                <asp:Label id="lblb" runat="server" Text="BANK">
                </asp:Label></td>
                <td><asp:Label style="FONT-SIZE: 16px; BACKGROUND-COLOR: white" id="lblBank" runat="server"></asp:Label>
                </td>
                </tr>
                  <tr style="BORDER-RIGHT: #000 1px solid; BORDER-TOP: #000 1px solid; BORDER-LEFT: #000 1px solid; BORDER-BOTTOM: #000 1px solid">
                <td style="FONT-SIZE: 16px; BACKGROUND-COLOR: lightblue">
                <asp:Label id="lblR" runat="server" Text="REMARKS">
                </asp:Label></td>
                <td><asp:Label style="FONT-SIZE: 16px; BACKGROUND-COLOR: white" id="lblRemarks" runat="server"></asp:Label>
                </td>
                </tr>
                 </tbody>
                </table>
                </asp:Panel> 

</asp:Content>
