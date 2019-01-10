<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="ShipmentInfoACC.aspx.vb" Inherits="Integra.ShipmentInfoACC" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
                &nbsp; <b>PLS NOTE THAT THE SHIPMENT DETAILS. FOR YOUR INFORMATION. PLS DO THE NEEDFUL.</b>:-
            </td>
        </tr>
    </table><br />

    <table>
    <TR>
     <td>
                <div class="txt_newwww" style="width: 140px; margin-left: 0px;">
                   Date :
                </div>
            </td>
    
    <td>
    <div class="text_box" style="">
                    <asp:TextBox ID="txtDate" Width ="120px" CssClass="textbox" runat="server" Style="margin-left: 0px;
                        height: 20px;" ReadOnly="false" AutoPostBack="false"></asp:TextBox>
                     </div>  
    </td>
    </TR>


    <tr style =" height ">
     <td>
                <div class="txt_newwww" style="width: 140px; margin-left: 0px;">
                   Shipment Mode :
                </div>
            </td>
    
    <td>
    <div class="text_box" style="">
                    <asp:TextBox ID="txtShipmentMode" Width ="120px" CssClass="textbox" runat="server" Style="margin-left: 0px;
                        height: 20px;" ReadOnly="false" AutoPostBack="false"></asp:TextBox>
                     </div>  
    </td>

    <td>
    
    </td>
    <td>
     <div class="txt_newwww" style="width: 140px; margin-left: 140px;">
                   BUYER'S NAME :
                </div>
                </td>

                <td>
                 <div class="text_box" style="">
                    <asp:TextBox ID="txtBUYERSNAME" Width ="456px" CssClass="textbox" runat="server" Style="margin-left: 0px;
                        height: 20px;" ReadOnly="false" AutoPostBack="false"></asp:TextBox>
                     </div>  
                
                </td>
    </tr>
    </TABLE><TABLE>



    <tr>
     <td>
                <div class="txt_newwww" style="width: 140px; margin-left: 0px;">
                   INVOICE NO. :
                </div>
            </td>
    
    <td>
    <div class="text_box" style="">
                    <asp:TextBox ID="txtINVOICENO" Width ="120px" CssClass="textbox" runat="server" Style="margin-left: 0px;
                        height: 20px;" ReadOnly="false" AutoPostBack="false"></asp:TextBox>
                     </div>  
    </td>

    <td>
    
    </td>
    <td>
     <div class="txt_newwww" style="width: 140px; margin-left: 140px;">
                   L/C NO.:
                </div>
                </td>

                <td>
                 <div class="text_box" style="">
                    <asp:TextBox ID="txtLCNO" Width ="120px" CssClass="textbox" runat="server" Style="margin-left: 0px;
                        height: 20px;" ReadOnly="false" AutoPostBack="false"></asp:TextBox>
                     </div>  
                
                </td>


                 <td>
     <div class="txt_newwww" style="width: 140px; margin-left: 150px;">
                   INVOICE AMT.:
                </div>
                </td>

                <td>
                 <div class="text_box" style="">
                    <asp:TextBox ID="TXTINVOICEAMT" Width ="120px" CssClass="textbox" runat="server" Style="margin-left: 0px;
                        height: 20px;" ReadOnly="false" AutoPostBack="false"></asp:TextBox>
                     </div>  
                
                </td>
    </tr>
     </TABLE><TABLE>
    <tr>


 <td>
                <div class="txt_newwww" style="width: 140px; margin-left: 0px;">
                   EXCHANGE RATE. :
                </div>
            </td>
    
    <td>
    <div class="text_box" style="">
                    <asp:TextBox ID="TXTEXCHANGERATE" Width ="120px" CssClass="textbox" runat="server" Style="margin-left: 0px;
                        height: 20px;" ReadOnly="false" AutoPostBack="false"></asp:TextBox>
                     </div>  
    </td>

    <td>
     <div class="txt_newwww" style="width: 140px; margin-left: 140px;">
                  IN BANK.:
                </div>
                </td>

                <td>
                 <div class="text_box" style="">
                    <asp:TextBox ID="TXTINBANK" Width ="120px" CssClass="textbox" runat="server" Style="margin-left: 0px;
                        height: 20px;" ReadOnly="false" AutoPostBack="false"></asp:TextBox>
                     </div>  
                
                </td>
                </TR><TR>
                </TABLE><TABLE>

                 <td>
     <div class="txt_newwww" style="width: 140px; margin-left: 0px;">
                   NEG BANK.:
                </div>
                </td>

                <td>
                 <div class="text_box" style="">
                    <asp:TextBox ID="TXTNEGBANK" Width ="446px" CssClass="textbox" runat="server" Style="margin-left: 0px;
                        height: 20px;" ReadOnly="false" AutoPostBack="false"></asp:TextBox>
                     </div>  
                
                </td>
    
    </tr>
     </TABLE><TABLE>
    <tr>
    <td>
     <div class="txt_newwww" style="width: 140px; margin-left: 0px;">
                  EXPECTED DATE.:
                </div>
                </td>

                <td>
                 <div class="text_box" style="">
                    <asp:TextBox ID="TXTEXPECTEDDATE" Width ="120px" CssClass="textbox" runat="server" Style="margin-left: 0px;
                        height: 20px;" ReadOnly="false" AutoPostBack="false"></asp:TextBox>
                     </div>  
                
                </td>


                 <td>
     <div class="txt_newwww" style="width: 140px; margin-left: 140px;">
                   BL DATE.:
                </div>
                </td>

                <td>
                 <div class="text_box" style="">
                    <asp:TextBox ID="TXTBLDATE" Width ="120px" CssClass="textbox" runat="server" Style="margin-left: 0px;
                        height: 20px;" ReadOnly="false" AutoPostBack="false"></asp:TextBox>
                     </div>  
                
                </td>
                
    </tr>
    
    </table>

  

  <br />
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
                <tr class="heading"><td>&nbsp; <b>Shipment-Info-ACC</b></td></tr><tr style="HEIGHT: 8px">
                </tr>
                </tbody>
                </table>
                <table style="BORDER-RIGHT: #000 1px solid; BORDER-TOP: #000 1px solid; BORDER-LEFT: #000 1px solid; BORDER-BOTTOM: #000 1px solid" width="100%">
               <tbody>
                <tr style="BORDER-RIGHT: #000 1px solid; BORDER-TOP: #000 1px solid; BORDER-LEFT: #000 1px solid; BORDER-BOTTOM: #000 1px solid">
                <td style="FONT-SIZE: 16px; BACKGROUND-COLOR: lightblue">
                <asp:Label id="lblShipmentMode" runat="server" Text="Shipment Mode">
                </asp:Label></td>
                <td><asp:Label style="FONT-SIZE: 16px; BACKGROUND-COLOR: white" id="lblShipmentModee" runat="server"></asp:Label>
                </td>
                </tr>


                  <tr style="BORDER-RIGHT: #000 1px solid; BORDER-TOP: #000 1px solid; BORDER-LEFT: #000 1px solid; BORDER-BOTTOM: #000 1px solid">
                <td style="FONT-SIZE: 16px; BACKGROUND-COLOR: lightblue">
                <asp:Label id="lblBuyer" runat="server" Text="Buyer">
                </asp:Label></td>
                <td><asp:Label style="FONT-SIZE: 16px; BACKGROUND-COLOR: white" id="lblBuyerr" runat="server"></asp:Label>
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
                <asp:Label id="Label1" runat="server" Text="LC NO.">
                </asp:Label>
                </td>
                <td>
                <asp:Label style="FONT-SIZE: 16px; BACKGROUND-COLOR: white" id="LBLLCNO" runat="server"></asp:Label>
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
