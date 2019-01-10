<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="CargoReleaseNew.aspx.vb" Inherits="Integra.CargoReleaseNew" %>

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
    <table>
        <tr>
            <td style="height: 20px;">
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td>
            </td>
            <td class="ErrorMsg">
                <asp:Label ID="lblInvoiceMSG" Visible="false" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                Invoice NO:
            </td>
            <td align="left">
                <asp:TextBox ID="txtInvoiceNo" Width="70" ReadOnly="false" runat="server" CssClass="forcapital"
                    AutoPostBack="true" Style="margin-left: 27px; margin-right: -3px;"></asp:TextBox>
                <asp:TextBox ID="txtInvoiceNoo" Width="30" runat="server" CssClass="forcapital" AutoPostBack="false"></asp:TextBox>
                <asp:TextBox ID="txtInvoiceNooo" Width="25" ReadOnly="true" runat="server" CssClass="forcapital"
                    AutoPostBack="true" Style="margin-left: -3PX; margin-right: 161px;"></asp:TextBox>
            </td>
            <td>
            </td>
            <td align="left">
                Invoice Date:
            </td>
            <td align="left">
                <telerik:RadDatePicker ID="txtInvoiceDatee" runat="server" Culture="en-US">
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
    </table>
    <table>
        <tr>
            <td>
                From 'E' NO:
            </td>
            <td align="left">
                <asp:TextBox ID="TXTFromENo" runat="server" CssClass="forcapital" AutoPostBack="false"
                    Style="margin-left: 23px; margin-right: 124px;"></asp:TextBox>
            </td>
            <td>
            </td>
            <td>
                From 'E' Date:
            </td>
            <td align="left">
                <telerik:RadDatePicker ID="txtFromEDate" runat="server" Culture="en-US">
                    <Calendar ID="Calendar6" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                        runat="server">
                    </Calendar>
                    <DateInput ID="DateInput6" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%" runat="server">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                LC NO:
            </td>
            <td align="left">
                <asp:TextBox ID="TXTLCNo" runat="server" CssClass="forcapital" AutoPostBack="TRUE"
                    Style="margin-left: 55px; margin-right: 122px;"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="10"
                    CompletionSetCount="12" ContextKey="LCNo" EnableCaching="true" MinimumPrefixLength="1"
                    ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="TXTLCNo" />
            </td>
            <td>
            </td>
            <td>
                Date Of Issue:
            </td>
            <td align="left">
                <telerik:RadDatePicker ID="txtDateOfIssue" runat="server" Culture="en-US">
                    <Calendar ID="Calendar7" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                        runat="server">
                    </Calendar>
                    <DateInput ID="DateInput7" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%" runat="server">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                Bank:
            </td>
            <td align="left">
                <asp:TextBox ID="cmbBank" runat="server" CssClass="forcapital" ReadOnly="true" AutoPostBack="false"
                    Width="280px" Style="margin-left: 35px;"></asp:TextBox>
                &nbsp;
            </td>
            <td>
            </td>
            <td>
                Ship Mode:
            </td>
            <td align="left">
                <asp:DropDownList ID="cmbShipMode" Width="150" CssClass="combo" AutoPostBack="false"
                    runat="server" Style="margin-left: 14px;">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Drawn On:
            </td>
            <td align="left">
                <asp:TextBox ID="txtDrawnOn" runat="server" CssClass="forcapital" ReadOnly="true"
                    AutoPostBack="false" Width="280px" Style="margin-left: 35px;"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                Payment Term:
            </td>
            <td align="left" colspan="4">
                <asp:TextBox ID="TXTLCTerms" runat="server" ReadOnly="true" CssClass="forcapital"
                    AutoPostBack="false" Width="160px" Style="margin-left: 10px;"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td align="left">
                <asp:DropDownList ID="cmbMode" runat="server" CssClass="forcapital" ToolTip="Select Mode"
                    Width="72px" AutoPostBack="true" Visible="false">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>AIR</asp:ListItem>
                    <asp:ListItem>SEA</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            </td>
            <td align="left">
            </td>
        </tr>
        <tr>
            <asp:Panel ID="PNLFreightTerm1" runat="server" Visible="true">
                <td>
                    Freight Term:
                </td>
                <td>
                    <asp:DropDownList ID="cmbItemDesc" CssClass="forcapital" runat="server" Width="159px"
                        Style="margin-left: 0px;">
                        <asp:ListItem>FOB</asp:ListItem>
                        <asp:ListItem>CNF</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:ImageButton ID="btnAddFreightTerm" runat="server" ImageUrl="~/Images/AddButton.jpg"
                        Style="margin-left: -135px; width: 19px;" />
                </td>
            </asp:Panel>
            <asp:Panel ID="PNLFreightTerm2" runat="server" Visible="false">
                <td>
                    Freight Term:
                </td>
                <td>
                    <asp:TextBox ID="txtFreightTerm" runat="server" Width="159px" CssClass="textbox"
                        Style="margin-right: 0px; text-transform: uppercase; margin-left: 0px;"></asp:TextBox>
                    <asp:ImageButton ID="btnsaveFreightTerm" runat="server" ImageUrl="~/Images/SaveButton.jpg"
                        Style="margin-left: 1px; width: 19px; margin-bottom: -2px;" />
                </td>
            </asp:Panel>
            <td>
            </td>
            <td align="left">
                <asp:TextBox ID="txtItemDesc" runat="server" CssClass="forcapital" Visible="false"></asp:TextBox>&nbsp;
            </td>
            <td>
            </td>
            <td>
            </td>
            <td align="left">
            </td>
        </tr>
        <tr>
            <td>
                Shipping Line:
            </td>
            <td align="left">
                <asp:TextBox ID="txtShippingLine" runat="server" CssClass="forcapital"></asp:TextBox>&nbsp;
            </td>
            <td>
            </td>
            <td align="left" class="NormalBoldText">
            </td>
            <td align="left">
                <asp:TextBox ID="txtForwarder" runat="server" CssClass="forcapital" Visible="false"></asp:TextBox>&nbsp;
            </td>
        </tr>
        <tr>
            <td id="TDMAWB" runat="server">
                MBL / MAWB:
            </td>
            <td align="left">
                <asp:TextBox ID="txtMode" runat="server" CssClass="forcapital"></asp:TextBox>&nbsp;
            </td>
            <td>
            </td>
            <td align="left" class="NormalBoldText">
            </td>
            <td align="left">
            </td>
        </tr>
        <tr>
            <td>
                Carrier Name:
            </td>
            <td align="left">
                <asp:TextBox ID="txtCarrierName" runat="server" CssClass="forcapital"></asp:TextBox>&nbsp;
            </td>
            <td>
            </td>
            <td align="left" class="NormalBoldText">
            </td>
            <td align="left">
            </td>
        </tr>
        <tr>
            <td>
                Voyage/Flight:
            </td>
            <td align="left" style="height: 21px">
                <asp:TextBox ID="txtVoyageFlight" runat="server" CssClass="forcapital"></asp:TextBox>&nbsp;
            </td>
            <td style="height: 21px">
            </td>
            <td align="left" class="NormalBoldText" style="height: 21px">
            </td>
            <td align="left" style="height: 21px">
            </td>
        </tr>
        <tr>
            <td>
                HBL / HAWB NO:
            </td>
            <td align="left">
                <asp:TextBox ID="txtBillNo" runat="server" CssClass="forcapital"></asp:TextBox>&nbsp;
            </td>
            <td>
                Shipment Date:
            </td>
            <td align="left">
                <telerik:RadDatePicker ID="txtCargoDatee" runat="server" Culture="en-US">
                    <Calendar ID="Calendar4" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                        runat="server">
                    </Calendar>
                    <DateInput ID="DateInput4" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%" runat="server">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td>
            </td>
            <td align="left">
                <telerik:RadDatePicker ID="txtETDD" runat="server" Culture="en-US" Visible="false">
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
            <td valign="top">
                CBM:
            </td>
            <td align="left">
                <asp:TextBox ID="txtCBM" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td align="left">
                <telerik:RadDatePicker ID="txtHandOverDate" runat="server" Culture="en-US" Visible="false">
                    <Calendar ID="Calendar5" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                        runat="server">
                    </Calendar>
                    <DateInput ID="DateInput5" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%" runat="server">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                No. of carton:
            </td>
            <td align="left">
                <asp:UpdatePanel ID="UpNoOfCarton" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtNoOfCarton" runat="server" CssClass="textbox" onkeypress="return isNumber(event)"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" CssClass="ErrorMsg" ErrorMessage="Invalid."
                            ControlToValidate="txtNoOfCarton" Operator="dataTypeCheck" Type="double"></asp:CompareValidator>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" CssClass="ErrorMsg" ErrorMessage="Not Allowed."
                            ControlToValidate="txtNoOfCarton" Operator='LessThanEqual' ValueToCompare="100000.00"
                            Type="Double">
                        </asp:CompareValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td align="left">
            </td>
        </tr>
        <tr>
            <td id="TDContainerNo" runat="server">
                Container No:
            </td>
            <td align="left">
                <asp:TextBox ID="txtContainer" runat="server" CssClass="forcapital" Visible="true"></asp:TextBox>
            </td>
            <td id="TDContainerSize" runat="server">
                Container Size:
            </td>
            <td align="left">
                <asp:DropDownList ID="cmbContainerSize" runat="server" CssClass="forcapital" Width="126px">
                    <asp:ListItem>20 FT</asp:ListItem>
                    <asp:ListItem>40 FT Standard</asp:ListItem>
                    <asp:ListItem>40 HC</asp:ListItem>
                    <asp:ListItem>45 FT</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>
                    <asp:ListItem>NA</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td id="TDConsolidation" runat="server">
                Consolidation:
            </td>
            <td align="left">
                <asp:DropDownList ID="cmbConsolidation" CssClass="forcapital" runat="server" Visible="false"
                    Width="160px">
                    <asp:ListItem>FCL</asp:ListItem>
                    <asp:ListItem>LCL</asp:ListItem>
                    <asp:ListItem>NA</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td id="5" align="left">
                <asp:TextBox ID="txtShippedExchangeRate" runat="server" Visible="false" Width="50px"
                    Style="margin-left: -385px;"></asp:TextBox>
                <asp:TextBox ID="txtRemarks" runat="server" Width="400px" CssClass="forcapital" Visible="false"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <asp:Panel ID="PnlPOA1" runat="server" Visible="true">
                <td>
                    POA:
                </td>
                <td>
                    <asp:DropDownList ID="cmbPODPOA" CssClass="forcapital" runat="server" Width="218px"
                        Style="margin-left: 66px; margin-right: 82px;">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:ImageButton ID="BtnAddPOA" runat="server" ImageUrl="~/Images/AddButton.jpg"
                        Style="margin-left: -77px; width: 19px;" />
                </td>
            </asp:Panel>
            <asp:Panel ID="PnlPOA2" runat="server" Visible="false">
                <td style="width: 150px;">
                    POA:
                </td>
                <td>
                    <asp:TextBox ID="txtPOA" runat="server" Width="218px" CssClass="textbox" Style="margin-right: 82px;
                        text-transform: uppercase; margin-left: -55px;"></asp:TextBox>
                    <asp:ImageButton ID="BtnSavePOA" runat="server" ImageUrl="~/Images/SaveButton.jpg"
                        Style="margin-left: -83px; width: 19px; margin-bottom: -2px;" />
                </td>
            </asp:Panel>
            <asp:Panel ID="pnlPOD1" runat="server" Visible="true">
                <td>
                    POD:
                </td>
                <td>
                    <asp:DropDownList ID="CMBFinalDestination" CssClass="forcapital" runat="server" Width="218px"
                        Style="margin-left: 61px; margin-right: 82px;">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:ImageButton ID="BTNADDCMBFinalDestination" runat="server" ImageUrl="~/Images/AddButton.jpg"
                        Style="margin-left: -77px; width: 19px;" />
                </td>
            </asp:Panel>
            <asp:Panel ID="pnlPOD2" runat="server" Visible="false">
                <td style="width: 150px;">
                    POD:
                </td>
                <td>
                    <asp:TextBox ID="TXTADDFinalDestination" runat="server" Width="218px" CssClass="textbox"
                        Style="margin-right: 82px; text-transform: uppercase; margin-left: -55px;"></asp:TextBox>
                    <asp:ImageButton ID="BTNSAVECMBFinalDestination" runat="server" ImageUrl="~/Images/SaveButton.jpg"
                        Style="margin-left: -83px; width: 19px; margin-bottom: -2px;" />
                </td>
            </asp:Panel>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td>
                 Net Weight KGS:
            </td>
            <td align="left">
                     <asp:UpdatePanel ID="UpNetWeightKGS" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtNetWeight" runat="server" ReadOnly="true" CssClass="forcapital"
                            onkeypress="return isNumber(event)" AutoPostBack="true" Width="100px" Style="margin-left: -1px;"></asp:TextBox>
                        <asp:CompareValidator ID="cmpNetWeight" runat="server" CssClass="ErrorMsg" ErrorMessage="Invalid."
                            ControlToValidate="txtNetWeight" Operator="dataTypeCheck" Type="double"></asp:CompareValidator>
                        <asp:DropDownList ID="CmbNetWeighUnit" CssClass="forcapital" Visible="false" runat="server"
                            Width="40px" Style="margin-left: 113px; margin-top: -21px; margin-right: 117px;">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:DropDownList ID="cmbgrossWeightUnit" Visible="false" CssClass="forcapital" runat="server"
                    Width="40px" Style="margin-left: -69px; margin-top: -21px; margin-right: 165px;">
                </asp:DropDownList>
            </td>
            <td>
            </td>
            <td>
                Weight / CTN:
            </td>
            <td align="left">
                <asp:UpdatePanel ID="UptxtWeightCTN" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtWeightCTN" runat="server" CssClass="forcapital" AutoPostBack="true"
                            Width="154px" Style="margin-right: 72px; margin-left: 1px;"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
              Gross Wt KGS: 
            </td>
            <td align="left">
             <asp:UpdatePanel ID="UpTXTGrossWeightKGS" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtGrossWeight" runat="server" CssClass="forcapital" onkeypress="return isNumber(event)"
                            ReadOnly="true" Style="margin-right: 209px; margin-left: 11px;" AutoPostBack="true"
                            Width="100px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>

          
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                By Order & Risk:
            </td>
            <td align="left">
                <asp:TextBox ID="txtByOrderAndRiskOf" TextMode="MultiLine" runat="server" CssClass="forcapital"
                    AutoPostBack="false" Width="300px" Style="margin-left: 1px; margin-right: 117px;"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td align="left">
                Marks And Num:
            </td>
            <td align="left">
                <asp:TextBox ID="txtMarksAndNumbers" runat="server" CssClass="forcapital" TextMode="MultiLine"
                    AutoPostBack="false" Width="300px" Style="margin-left: 1px;"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
            </td>
            <td align="left">
            </td>
            <td align="left">
                <asp:TextBox ID="txtTermOfSale" runat="server" CssClass="forcapital" Visible="false"
                    AutoPostBack="false" Style="margin-left: -1px;"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <asp:Panel ID="pnlCurrency1" runat="server" Visible="true">
                <td>
                    Currency:
                </td>
                <td>
                    <asp:DropDownList ID="cmbCurrencyNew" Width="160" CssClass="combo" AutoPostBack="false"
                        runat="server" Style="margin-left: 38px; margin-right: 112px;">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:ImageButton ID="btnAddCurrency" runat="server" ImageUrl="~/Images/AddButton.jpg"
                        Style="margin-left: -107px; width: 19px;" />
                </td>
            </asp:Panel>
            <asp:Panel ID="pnlCurrency2" runat="server" Visible="false">
                <td style="width: 150px;">
                    Currency:
                </td>
                <td>
                    <asp:TextBox ID="txtAddCurrency" runat="server" Width="218px" CssClass="textbox"
                        Style="margin-right: 82px; text-transform: uppercase; margin-left: -55px;"></asp:TextBox>
                    <asp:ImageButton ID="btnSaveCurrency" runat="server" ImageUrl="~/Images/SaveButton.jpg"
                        Style="margin-left: -83px; width: 19px; margin-bottom: -2px;" />
                </td>
            </asp:Panel>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                Invoice Value:
            </td>
            <td align="left">
                <asp:UpdatePanel ID="UptxtInvoiceValue" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtInvoiceValue" runat="server" ReadOnly="true" Width="100PX" CssClass="textbox"
                            Style="margin-left: 13px; margin-right: 196px;"></asp:TextBox>&nbsp;
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                ETA:
            </td>
            <td align="left">
                <telerik:RadDatePicker ID="txtETAA" runat="server" Culture="en-US" Style="margin-left: 63px;">
                    <Calendar ID="Calendar1" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                        runat="server">
                    </Calendar>
                    <DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%" runat="server">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td style="width: 95px;">
                ETD:
            </td>
            <td>
                <telerik:RadDatePicker ID="TXTETDDate" runat="server" Culture="en-US" SYTLE=" margin-left: 39px;">
                    <Calendar ID="Calendar8" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                        runat="server">
                    </Calendar>
                    <DateInput ID="DateInput8" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%" runat="server">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                Clearning Agent:
            </td>
            <td align="left">
                <asp:TextBox ID="txtClearningAgent" runat="server" CssClass="forcapital" AutoPostBack="false"
                    Style="margin-left: -1px; margin-right: 134px;"></asp:TextBox>
            </td>
            <td>
            </td>
            <td align="left">
                Forwarding Agent:
            </td>
            <td align="left">
                <asp:TextBox ID="txtForwardingAgent" runat="server" CssClass="forcapital" AutoPostBack="false"
                    Style="margin-left: 2px; margin-right: 0px;"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                Remarks:
            </td>
            <td align="left">
                <asp:TextBox ID="txtRemarksNew" runat="server" CssClass="forcapital" Width="300px"
                    AutoPostBack="false" Style="margin-left: 40px;" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr align="center">
        <td class="NormalBoldText" align="center">
                <asp:Label ID="Label1" runat="server" CssClass="Label" Text="Customer:"></asp:Label>
            </td>
            <td>
                <div style="margin-left: 31px;">
                    <asp:DropDownList ID="cmbCustomer" runat="server" Width="134px" Style="margin-left: -96px;"
                        AutoPostBack="true" Visible="true">
                    </asp:DropDownList>
                </div>
            </td>



            <td class="NormalBoldText" align="center">
                <asp:Label ID="Label3" runat="server" CssClass="Label" Text="Packing No:"></asp:Label>
            </td>
            <td>
                <div style="margin-left: 21px;">
                    <asp:DropDownList ID="cmbPackingNo" runat="server" Width="134px" Style="margin-left: -96px;"
                        AutoPostBack="false" Visible="true">
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td>
                <asp:Button ID="btnSearch" runat="server" CssClass="button" Text="Get Data" Style="margin-left: 93px;
                    width: 140px;"></asp:Button>
            </td>
        </tr>
    </table>
    <br />
    <asp:UpdatePanel ID="UpMsgs" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td class="ErrorMsg" style="width: 783px; height: 13px;">
                        <asp:Label ID="lblmsg" Visible="false" runat="server"></asp:Label>
                        <asp:Label ID="lblSystemValue" Visible="false" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="ErrorMsg" style="width: 783px; height: 13px;">
                        <asp:Label ID="lblReleaseQTY" Visible="false" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="ErrorMsg" style="width: 783px; height: 13px;">
                        <asp:Label ID="lblTotalCTN" Visible="false" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="ErrorMsg" style="width: 783px; height: 13px;">
                        <asp:Label ID="lblOk" Visible="false" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <table>
        <tr>
            <td align="center">
                <asp:Label ID="Errormgs" CssClass="ErrorMsg" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <div style="width: 930px;">
                    <Smart:SmartDataGrid ID="dgArticle" runat="server" Width="100%" OnPageIndexChanged="PageChanged"
                        AllowSorting="True" AutoGenerateColumns="False" CellPadding="2" CssClass="table"
                        PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="50" RecordCount="0"
                        ShowFooter="True" SortedAscending="yes">
                        <Columns>
                            <asp:BoundColumn HeaderText="CargoDetailid" DataField="CargoDetailid" Visible="false" />
                            <asp:BoundColumn HeaderText="POPOID" DataField="POPOID" Visible="false" />
                            <asp:BoundColumn HeaderText="POID" DataField="POID" Visible="false" />
                            <asp:BoundColumn HeaderText="CustomerID" DataField="CustomerID" Visible="false" />
                            <asp:TemplateColumn HeaderText="Style/Model Ref">
                                <ItemStyle Width="4%" HorizontalAlign="Left"></ItemStyle>
                                <ItemTemplate>
                                    <asp:TextBox ID="TXTStyle" runat="server" Width="100" CssClass="textbox" OnTextChanged="TXTCommodity_TextChanged"
                                        AutoPostBack="false" ReadOnly="true"></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Width="4%" HorizontalAlign="Center"></HeaderStyle>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Hs Code">
                                <ItemStyle Width="4%" HorizontalAlign="Left"></ItemStyle>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtHsCode" runat="server" Width="100" CssClass="textbox" AutoPostBack="FALSE"
                                        ReadOnly="false"></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Width="4%" HorizontalAlign="Center"></HeaderStyle>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Commodity">
                                <ItemStyle Width="6%" HorizontalAlign="Left"></ItemStyle>
                                <ItemTemplate>
                                    <asp:TextBox ID="TXTCommodity" runat="server" Width="90" CssClass="textbox" OnTextChanged="TXTCommodity_TextChanged"
                                        AutoPostBack="true"></asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" CompletionInterval="10"
                                        CompletionSetCount="12" ContextKey="SearchCommodity" EnableCaching="true" MinimumPrefixLength="1"
                                        ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="TXTCommodity" />
                                    <asp:ImageButton ID="imgSyleAdd" runat="server" ToolTip="Click here to Add Style."
                                        CommandName="AddCommdity" ImageUrl="~/Images/AddButton.jpg" Style="margin-top: -19px;
                                        margin-left: 95px; width: 18px; height: 17px;" Visible="true" />
                                    <asp:Label ID="LBLCommodityID" runat="server" Visible="false" CssClass="Label" Text="0"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="6%" HorizontalAlign="Center"></HeaderStyle>
                            </asp:TemplateColumn>
                            <asp:BoundColumn HeaderText="SR NO." DataField="SRNO">
                                <ItemStyle HorizontalAlign="Center" Width="50%" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Customer" DataField="CustomerName">
                                <ItemStyle HorizontalAlign="Center" Width="60%" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="PO Quantity" DataField="Quantity">
                                <ItemStyle HorizontalAlign="Center" Width="40%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Shipped Quantity" DataField="ShippedQty">
                                <ItemStyle HorizontalAlign="Center" Width="40%" />
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="PCS">
                                <ItemStyle HorizontalAlign="Center" Width="20%" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtReleaseQuantity" runat="server" Width="60" AutoPostBack="true" OnTextChanged="txtReleaseQuantity_TextChanged" CssClass="textbox"
                                        ReadOnly="false" Text='<%#Eval("PCS") %>'></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Width="6%" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="CTNS">
                                <ItemStyle HorizontalAlign="Center" Width="20%" />
                                <ItemTemplate>
                                    <asp:TextBox ID="Cartons" runat="server" AutoPostBack="true" OnTextChanged="Cartons_TextChanged"
                                        ReadOnly="false" Width="40" CssClass="textbox" Text='<%#Eval("CTNS") %>'></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Width="6%" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Shipped Rate">
                                <ItemStyle HorizontalAlign="Center" Width="20%" />
                                <ItemTemplate>
                                    <asp:TextBox ID="ShippedRate" runat="server" Width="40" ReadOnly="true" CssClass="textbox"
                                        Text='<%#Eval("ShippedRate") %>'></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Width="6%" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Weight Per PCS">
                                <ItemStyle HorizontalAlign="Center" Width="20%" />
                                <ItemTemplate>
                                    <asp:TextBox ID="TXTWeightPCS" OnTextChanged="TXTWeightPCS_TextChanged" AutoPostBack="true"
                                        runat="server" Width="40" ReadOnly="false" CssClass="textbox"></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Width="6%" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="White PCS">
                                <ItemStyle HorizontalAlign="Center" Width="20%" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtWhitePCS" runat="server" Width="40" ReadOnly="false" CssClass="textbox"></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Width="6%" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="White Carton" Visible="true">
                                <ItemStyle HorizontalAlign="Center" Width="20%" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtWhiteCarton" AutoPostBack="false" runat="server" Width="40" ReadOnly="false"
                                        CssClass="textbox"></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Width="6%" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="ID" Visible="false">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" CssClass="label" Text='<%#Eval("POID")%>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="10%" />
                            </asp:TemplateColumn>
                            <asp:BoundColumn HeaderText="Rate" DataField="ShippedRate" Visible="False">
                                <ItemStyle HorizontalAlign="Center" Width="40%" />
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="Remove">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkRemove" ToolTip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png"
                                        CommandName="Remove" runat="server"></asp:ImageButton>
                                </ItemTemplate>
                                <HeaderStyle Width="1%" HorizontalAlign="Center"></HeaderStyle>
                            </asp:TemplateColumn>
                        </Columns>
                        <PagerStyle CssClass="GridPagerStyle" Mode="NumericPages" />
                        <AlternatingItemStyle CssClass="GridAlternativeRow" />
                        <ItemStyle CssClass="GridRow" />
                        <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                    </Smart:SmartDataGrid>
                </div>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td align="right">
                <asp:Button ID="btnSelect" Visible="false" runat="server" CssClass="button" Text="Save"
                    OnClientClick="window.close();" />
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td align="right">
                <asp:Button ID="btnSave" runat="server" CssClass="button" />
            </td>
            <td>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" />
            </td>
        </tr>
    </table>
</asp:Content>
