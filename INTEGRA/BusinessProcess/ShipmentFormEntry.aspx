<%@ Page Title="Shipment Form Entry" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="ShipmentFormEntry.aspx.vb" Inherits="Integra.ShipmentFormEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }

    </script>
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
    <style>
    #ShipmentTB1 tr td:nth-child(even) 
    {
    	padding:2px;
    }
    #ShipmentTB1 tr td:nth-child(odd) 
    {
    	text-align:right;
    	font-size:9px;
    	font-weight:bold;
    }
    #ShipmentTB1 .DatePick
    {
    	width:170px !important;
    }
    #ShipmentTB1 .combo
    {
    	width:160px;
    }
    </style>
    <table id="ShipmentTB1">
        <tr>
            <td>Invoice NO:</td>
            <td>
                <asp:DropDownList ID="cmbInvoiceNo" runat="server" AutoPostBack ="true"  CssClass="combo"></asp:DropDownList>                
            </td>
            <td>B/L OR AWB#:</td>
            <td>
                 <asp:TextBox ID="txtBLorAWB" ReadOnly ="true" runat="server" CssClass="forcapital"></asp:TextBox>
            </td>
            <td>Discrepacy Msg Date:</td>
            <td>
                 <telerik:RadDatePicker ID="rdpDiscrepacyMsgDate" runat="server" Culture="en-US" CssClass="DatePick">
                    <Calendar ID="Calendar2" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                        runat="server">
                    </Calendar>
                    <DateInput ID="DateInput2" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%" runat="server">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
        </tr>
        <tr>
            <td>Buyer:</td>
            <td>
                 <asp:TextBox ID="txtBuyer" runat="server" CssClass="forcapital" ReadOnly ="true" ></asp:TextBox>
            </td>
            <td>B/L OR AWB Date:</td>
            <td>
                 <telerik:RadDatePicker ID="rdpBLorAWBDate" runat="server" Culture="en-US" CssClass="DatePick">
                    <Calendar ID="Calendar1" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                        runat="server">
                    </Calendar>
                    <DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%" runat="server">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td>Telex Sending Date:</td>
            <td>
                 <telerik:RadDatePicker ID="rdpTelexSendingDate" runat="server" Culture="en-US" CssClass="DatePick">
                    <Calendar ID="Calendar3" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                        runat="server">
                    </Calendar>
                    <DateInput ID="DateInput3" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%" runat="server">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
        </tr>
        <tr>
            <td>Currency:</td>
            <td>
                 <asp:TextBox ID="txtCurrency" runat="server" CssClass="forcapital" ReadOnly ="true"></asp:TextBox>
            </td>
            <td>Container No:</td>
            <td>
                 <asp:TextBox ID="txtContainerNo" ReadOnly ="true" runat="server" CssClass="forcapital"></asp:TextBox>
            </td>
            <td>Pay Maburity Date:</td>
            <td>
                 <telerik:RadDatePicker ID="rdpPayMaburityDate" runat="server" Culture="en-US" CssClass="DatePick">
                    <Calendar ID="Calendar4" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                        runat="server">
                    </Calendar>
                    <DateInput ID="DateInput4" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%" runat="server">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
        </tr>
        <tr>
            <td>Invoice Amount:</td>
            <td>
                 <asp:TextBox ID="txtInvoiceAmount" runat="server" CssClass="forcapital" ReadOnly ="true"></asp:TextBox>
            </td>
            <td>Container Size:</td>
            <td>
            <asp:TextBox ID="txtContainerSize" ReadOnly ="true" runat="server" CssClass="forcapital"></asp:TextBox>
                         
            </td>
            <td>Amount To Be Realized:</td>
            <td>
                 <asp:TextBox ID="txtAmountToBeRealized" runat="server" CssClass="forcapital"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Invoice Date:</td>
            <td>
                <telerik:RadDatePicker ID="rdpInvoiceDate" runat="server" Culture="en-US" CssClass="DatePick" Enabled ="false">
                <Calendar ID="Calendar5" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                    runat="server" Enabled ="false" >
                </Calendar>
                <DateInput ID="DateInput5" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                    LabelWidth="40%" runat="server">
                </DateInput>
                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td>ETA Destination:</td>
            <td>
                <telerik:RadDatePicker ID="rdpETADestination" runat="server" Enabled ="false" Culture="en-US" CssClass="DatePick">
                <Calendar ID="Calendar6" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                    runat="server" Enabled ="false">
                </Calendar>
                <DateInput ID="DateInput6" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                    LabelWidth="40%" runat="server">
                </DateInput>
                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td>Exchange Rate:</td>
            <td>
                 <asp:TextBox ID="txtExchangeRate" runat="server" CssClass="forcapital"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Ex. Factory Date:</td>
            <td>
            <asp:TextBox ID="txtExFactoryDate" runat="server" CssClass="forcapital" ReadOnly ="true"></asp:TextBox>
                  
            </td>
            <td>Clearing Agent:</td>
            <td>
                 <asp:TextBox ID="txtClearingAgent" ReadOnly ="true" runat="server" CssClass="forcapital"></asp:TextBox>
            </td>
            <td>Amount In PKR:</td>
            <td>
                 <asp:TextBox ID="txtAmountInPKR" runat="server" CssClass="forcapital"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Qty Pcs:</td>
            <td>
                 <asp:TextBox ID="txtQtyPcs" runat="server" CssClass="forcapital" ReadOnly ="true"></asp:TextBox>
            </td>
            <td>G.D #:</td>
            <td>
                 <asp:TextBox ID="txtGD" runat="server" CssClass="forcapital"></asp:TextBox>
            </td>
            <td>Purchase Amount:</td>
            <td>
                 <asp:TextBox ID="txtPurchaseAmount" runat="server" CssClass="forcapital"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>L/C No:</td>
            <td>
                 <asp:TextBox ID="txtLCNo" runat="server" CssClass="forcapital" ReadOnly ="true"></asp:TextBox>
            </td>
            <td>G.D Date:</td>
            <td>
                <telerik:RadDatePicker ID="rdpGDDate" runat="server" Culture="en-US" CssClass="DatePick">
                <Calendar ID="Calendar7" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                    runat="server">
                </Calendar>
                <DateInput ID="DateInput7" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                    LabelWidth="40%" runat="server">
                </DateInput>
                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td>Purchase Rate:</td>
            <td>
                 <asp:TextBox ID="txtPurchaseRate" runat="server" CssClass="forcapital"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>L/C Date:</td>
            <td>
                <telerik:RadDatePicker ID="rdpLCDate" runat="server" Culture="en-US" CssClass="DatePick" Enabled ="false">
                <Calendar ID="Calendar8" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                    runat="server" Enabled ="false">
                </Calendar>
                <DateInput ID="DateInput8" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                    LabelWidth="40%" runat="server">
                </DateInput>
                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td>Payment Terms</td>
            <td>
                <asp:TextBox ID="TXTPaymentTerms" ReadOnly ="true"  runat="server" CssClass="forcapital"></asp:TextBox>
                              </td>
            <td>Purchase Amount PKR:</td>
            <td>
                 <asp:TextBox ID="txtPurchaseAmountPKR" runat="server" CssClass="forcapital"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Ship Mode:</td>
             <td>
                <asp:DropDownList ID="cmbShipMode" runat="server" CssClass="combo" Enabled="false" ></asp:DropDownList>                
            </td>
            <td>Payment Days:</td>
             <td>
              <asp:TextBox ID="txtPaymentDays" AutoPostBack="true"  runat="server" onkeypress="return isNumericKeyy(event);" CssClass="forcapital"></asp:TextBox>
                    
            </td>
            <td>Purchase Date:</td>
             <td>
                <telerik:RadDatePicker ID="rdpPurchaseDate" runat="server" Culture="en-US" CssClass="DatePick">
                <Calendar ID="Calendar9" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                    runat="server">
                </Calendar>
                <DateInput ID="DateInput9" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                    LabelWidth="40%" runat="server">
                </DateInput>
                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
        </tr>
        <tr>
            <td>Ship Term:</td>
             <td>
                <asp:DropDownList ID="cmbShipTerm" runat="server" CssClass="combo" Enabled="false"></asp:DropDownList>                
            </td>
            <td>Docs. Submit Into Bank On:</td>
             <td>
                <telerik:RadDatePicker ID="rdpDocsSubmitIntoBankOn" runat="server" Culture="en-US" CssClass="DatePick">
                <Calendar ID="Calendar10" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                    runat="server">
                </Calendar>
                <DateInput ID="DateInput10" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                    LabelWidth="40%" runat="server">
                </DateInput>
                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td>Bal. Realized Amount:</td>
             <td>
                 <asp:TextBox ID="txtBalRealizedAmount" runat="server" CssClass="forcapital"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Bank Code:</td>
            <td>

                <asp:TextBox ID="txtBankCode" runat="server" ReadOnly ="true" CssClass="forcapital"></asp:TextBox>            
            </td>
            <td>Bank To Bank DHL No:</td>
            <td>
                 <asp:TextBox ID="txtBankToBankDHLNo" runat="server" CssClass="forcapital"></asp:TextBox>
            </td>
            <td>Realized Rate:</td>
            <td>
                 <asp:TextBox ID="txtRealizedRate" runat="server" CssClass="forcapital"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Form 'E' No:</td>
            <td>
                 <asp:TextBox ID="txtFormENo" runat="server" ReadOnly ="true" CssClass="forcapital"></asp:TextBox>
            </td>
            <td>Bank To Bank DHL Date:</td>
            <td>
                <telerik:RadDatePicker ID="rdpBankToBankDHLDate" runat="server" Culture="en-US" CssClass="DatePick">
                <Calendar ID="Calendar11" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                    runat="server">
                </Calendar>
                <DateInput ID="DateInput11" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                    LabelWidth="40%" runat="server">
                </DateInput>
                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td>Bal. Realized Amount PKR:</td>
            <td>
                 <asp:TextBox ID="txtBalRealizedAmountPKR" runat="server" CssClass="forcapital"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Form 'E' Date:</td>
            <td>
                <telerik:RadDatePicker ID="rdpFormEDate" Enabled ="false" runat="server" Culture="en-US" CssClass="DatePick">
                <Calendar ID="Calendar13" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                    runat="server" Enabled ="false">
                </Calendar>
                <DateInput ID="DateInput13" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                    LabelWidth="40%" runat="server">
                </DateInput>
                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td>Buyer DHL No:</td>
            <td>
                 <asp:TextBox ID="txtBuyerDHLNo" runat="server" CssClass="forcapital"></asp:TextBox>
            </td>
            <td>Realized Date:</td>
            <td>
                <telerik:RadDatePicker ID="rdpRealizedDate" runat="server" Culture="en-US" CssClass="DatePick">
                <Calendar ID="Calendar12" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                    runat="server">
                </Calendar>
                <DateInput ID="DateInput12" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                    LabelWidth="40%" runat="server">
                </DateInput>
                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td>Buyer DHL Date:</td>
            <td>
                <telerik:RadDatePicker ID="rdpBuyerDHLDate" runat="server" Culture="en-US" CssClass="DatePick">
                <Calendar ID="Calendar14" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                    runat="server">
                </Calendar>
                <DateInput ID="DateInput14" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                    LabelWidth="40%" runat="server">
                </DateInput>
                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td>FB Charges:</td>
            <td>
                 <asp:TextBox ID="txtFBCharges" runat="server" CssClass="forcapital"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td>Expected Pay. Rcv. Date:</td>
            <td>
                 
             <asp:TextBox ID="txtExpectedPayRecDate" runat="server" ReadOnly ="true"  CssClass="forcapital"></asp:TextBox>     
            </td>
            <td>Net Realized Amount:</td>
            <td>
                 <asp:TextBox ID="txtNetRealizedAmount" runat="server" CssClass="forcapital"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td>Net Realized Amount PKR:</td>
            <td>
                 <asp:TextBox ID="txtNetRealizedAmountPKR" runat="server" CssClass="forcapital"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td>Remarks:</td>
            <td>
                 <asp:TextBox ID="txtRemarks" runat="server" CssClass="forcapital"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td>
                <asp:CheckBox runat="server" ID="cbPaymentReceived" />
            </td>
            <td>
                 <b>Payment Received</b>
            </td>
        </tr>
        <tr>
            <td colspan="6" style="text-align:center;">
                <asp:Button runat="server" ID="btnSave" Text ="Save"/>
                <asp:Button runat="server" ID="btnCancel" Text ="Cancel"/>
            </td>
        </tr>
    </table>
</asp:Content>
