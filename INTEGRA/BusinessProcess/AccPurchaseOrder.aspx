<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="AccPurchaseOrder.aspx.vb" Inherits="Integra.AccPurchaseOrder" %>

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
    <div class="main_container">
        <div class="header_columns">
            <div class="heading">
                PURCHASE ORDER ENTRY</div>
            <br />
            <table>
                <tr style="height: 30px;">
                    <td style="width: 118px;">
                        PO Type:
                    </td>
                    <td style="width: 160px;">
                        <asp:DropDownList ID="cmbPOType" AutoPostBack="True" CssClass="combo" Width="133"
                            runat="server" TabIndex="0">
                        </asp:DropDownList>
                    </td>
                    <td>
                        Date:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCreationDate" CssClass="textbox" Width="129" runat="server" AutoPostBack="false"
                            Style="text-transform: uppercase;"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtCreationDate"
                            PopupButtonID="ImageButton1" />
                        <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" ImageUrl="~/Images/callendar.JPG"
                            AlternateText="Click here to display calendar" />
                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtCreationDate"
                            Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                            CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                            Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                        </cc1:MaskedEditExtender>
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td>
                        Inditex P.O No:
                    </td>
                    <td>
                        <asp:TextBox ID="TXTInditexPONo" CssClass="textbox" runat="server" ReadOnly="false"></asp:TextBox>
                    </td>
                    <td>
                        Consumer Age:
                    </td>
                    <td>
                        <asp:TextBox ID="txtConsumerAge" CssClass="textbox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td>
                        Sales Contract No:
                    </td>
                    <td>
                        <asp:TextBox ID="TXTSalesContractNo" CssClass="textbox" runat="server" ReadOnly="false"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td>
                        Purchase Order #:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPurchaseOrderNo" CssClass="textbox" runat="server" ReadOnly="true"></asp:TextBox>
                    </td>
                    <td>
                        Comments:
                    </td>
                    <td>
                        <asp:TextBox ID="txtcomment" CssClass="textbox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td>
                        <asp:TextBox ID="txtPartyRef" CssClass="textbox" runat="server" Visible="false"></asp:TextBox>
                        <asp:Label ID="lblPOdetailid" Visible="false" runat="server"></asp:Label>
                        <asp:TextBox ID="txtSample" CssClass="textbox" runat="server" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="txtPacking" CssClass="textbox" runat="server" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="txtInspection" CssClass="textbox" runat="server" Visible="false"></asp:TextBox>
                        <asp:Label ID="lblAuditorStatus" runat="server" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Pay Mode :
                    </td>
                    <td>
                        <asp:TextBox ID="txtPayMode" CssClass="textbox" Width="129" runat="server" AutoPostBack="false"
                            Style="text-transform: uppercase;"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="udpcmbJobNoo" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtQtyJOWise" Visible="false" CssClass="textbox" Width="129" runat="server"
                                    ReadOnly="true" Style="text-transform: uppercase;">
                             
                                </asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        Remarks :
                    </td>
                    <td>
                        <asp:TextBox ID="txtRemarks" CssClass="textbox" Width="373px" runat="server" AutoPostBack="false"
                            Style="text-transform: uppercase; margin-top: 4px; margin-left: 57px;"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <div class="heading">
                DETAIL</div>
            <br />
            <table>
                <tr style="height: 30px;">
                    <td>
                        Supplier:
                    </td>
                    <td style="width: 160px;">
                        <asp:TextBox ID="txtPartyAccount" CssClass="textbox" AutoPostBack="true" autocomplete="off"
                            runat="server"></asp:TextBox>
                        <cc1:AutoCompleteExtender runat="server" ID="autoComplete1" TargetControlID="txtPartyAccount"
                            ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                            CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="TblPartyforInvoice" />
                        <asp:Label ID="lblPartyid" runat="server" Visible="false"></asp:Label>
                    </td>
                    <td>
                        Season:
                    </td>
                    <td>
                        <asp:DropDownList ID="cmbseason" CssClass="combo" Width="133" runat="server" TabIndex="0"
                            AutoPostBack="True" OnSelectedIndexChanged="cmbseason_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        PO No:
                    </td>
                    <td>
                        <asp:DropDownList ID="cmbSrNo" CssClass="combo" Width="133" runat="server" TabIndex="0"
                            AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:TextBox ID="txtSrnooo" Visible="false" CssClass="textbox" Width="100px" runat="server"
                            AutoPostBack="true" Style="text-transform: uppercase; margin-top: 5px; margin-left: 0px;"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblJoborderidoo" runat="server" Visible="false" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Code Entry:
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpTXTCodeEntry" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="TXTCodeEntry" AutoPostBack="true" CssClass="textbox" runat="server"></asp:TextBox>
                                <cc1:AutoCompleteExtender runat="server" ID="AutoCompleteExtender2" TargetControlID="TXTCodeEntry"
                                    ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                                    CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="TXTCodeEntry" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        Delivery Date:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDeleiveryDate" CssClass="textbox" Width="129" runat="server"
                            AutoPostBack="false" Style="text-transform: uppercase;"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="txtDeleiveryDate"
                            PopupButtonID="ImageButton2" />
                        <asp:ImageButton runat="Server" ID="ImageButton2" CausesValidation="false" ImageUrl="~/Images/callendar.JPG"
                            AlternateText="Click here to display calendar" />
                        <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtDeleiveryDate"
                            Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                            CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                            Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                        </cc1:MaskedEditExtender>
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td>
                        Item Type:
                    </td>
                    <td colspan="3">
                        <asp:UpdatePanel ID="udpcmbProductType" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:DropDownList ID="cmbProductType" Width="133px" CssClass="combo" AutoPostBack="true"
                                    runat="server">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                    </td>
                    <td style="width: 160px;">
                        <asp:DropDownList ID="cmbFrom" Width="140px" CssClass="combo" AutoPostBack="false"
                            runat="server" Visible="false">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td>
                        Item Name:
                    </td>
                    <td colspan="3">
                        <asp:UpdatePanel ID="udpcmbProduct" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtProduct" CssClass="textbox" Width="373px" runat="server" AutoPostBack="true"
                                    Style="text-transform: uppercase; margin-top: 5px; margin-left: 0px;"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender9" runat="server" CompletionInterval="10"
                                    CompletionSetCount="12" ContextKey="ItemNameFStore" EnableCaching="true" MinimumPrefixLength="1"
                                    ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtProduct" />
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="cmbItemunit" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        Detail :
                    </td>
                    <td>
                        <asp:TextBox ID="txtRemarksDetail" TextMode="MultiLine" Columns="25" Rows="4" Wrap="true"
                            CssClass="textbox" Width="373px" runat="server" AutoPostBack="false" Style="text-transform: uppercase;
                            margin-top: 5px; margin-left: 0px;"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td>
                        <asp:Label ID="lblname" runat="server" Text="Quality:"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:UpdatePanel ID="udptxtQuality" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtQuality" CssClass="textbox" runat="server"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td colspan="3">
                        <asp:UpdatePanel ID="udptxtSize" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtSize" Visible="false" Text="N/A" CssClass="textbox" runat="server"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        Shade:
                    </td>
                    <td colspan="1">
                        <asp:UpdatePanel ID="udptxtColor" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtColor" CssClass="textbox" runat="server"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        Style:
                    </td>
                    <td colspan="3">
                        <asp:UpdatePanel ID="udptxtStyle" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtStyle" CssClass="textbox" runat="server"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td>
                        Quantity:
                    </td>
                    <td>
                        <asp:UpdatePanel ID="udptxtQuantity" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtQuantity" CssClass="textbox" runat="server" Style="width: 61px;"
                                    AutoPostBack="true" onkeypress="return isNumericKey(event);"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <asp:Label ID="lblWeight" runat="server" Visible="false" Text="Weight:"></asp:Label>
                    <td>
                        <asp:UpdatePanel ID="udpcmbItemunit" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:DropDownList ID="cmbItemunit" Width="66px" CssClass="combo" AutoPostBack="false"
                                    runat="server" Style="margin-top: 0px; margin-left: -304px;">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:UpdatePanel ID="udptxtWeight" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtWeight" CssClass="textbox" runat="server" onkeypress="return isNumericKey(event);"
                                    Visible="false"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td>
                        Rate:
                    </td>
                    <td>
                        <asp:UpdatePanel ID="udptxtrate" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtrate" CssClass="textbox" runat="server" AutoPostBack="true" Width="60px"
                                    onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                                <asp:DropDownList ID="cmbCurrencys" Width="61px" CssClass="combo" runat="server"
                                    AutoPostBack="false" Visible="true" Style="width: 65px; margin-left: 6px; margin-top: -20PX;">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        Gross Amount:
                    </td>
                    <td>
                        <asp:UpdatePanel ID="udptxtGrossAmount" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtGrossAmount" CssClass="textbox" runat="server" BackColor="Silver"
                                    Enabled="False" onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td>
                        Disc.%:
                    </td>
                    <td>
                        <asp:UpdatePanel ID="udptxtdiscPercentage" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtdiscPercentage" CssClass="textbox" runat="server" AutoPostBack="true"
                                    onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        Disc Amount:
                    </td>
                    <td>
                        <asp:UpdatePanel ID="udptxtDiscAmount" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtDiscAmount" CssClass="textbox" runat="server" BackColor="Silver"
                                    Enabled="False" onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td>
                        Value Excloude S.T.:
                    </td>
                    <td>
                        <asp:UpdatePanel ID="udptxtValueExcloudeST" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtValueExcloudeST" CssClass="textbox" runat="server" AutoPostBack="true"
                                    onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        Sales Tax%:
                    </td>
                    <td>
                        <asp:UpdatePanel ID="udptxtSalesTaxPercentage" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtSalesTaxPercentage" CssClass="textbox" runat="server" AutoPostBack="true"
                                    onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td>
                        Sales Tax Amount:
                    </td>
                    <td>
                        <asp:UpdatePanel ID="udptxtSalesTaxAmount" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtSalesTaxAmount" CssClass="textbox" runat="server" AutoPostBack="true"
                                    BackColor="Silver" Enabled="False" onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        Net Amount:
                    </td>
                    <td>
                        <asp:UpdatePanel ID="udptxtNetAmount" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtNetAmount" CssClass="textbox" runat="server" BackColor="Silver"
                                    Enabled="False" onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td>
                        Ex-Rate:
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpExRate" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtExRate" CssClass="textbox" runat="server" onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        Clearance Charges:
                    </td>
                    <td>
                        <asp:UpdatePanel ID="udptxtClearanceCharges" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtClearanceCharges" CssClass="textbox" AutoPostBack="true" runat="server"
                                    Enabled="TRUE" onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="udplblInvoiceQTY" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:Label ID="lblInvoiceQTY" Visible="true" runat="server"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnAdd" runat="server" Skin="WebBlue" Text="Add Detail" Font-Bold="True"
                            Font-Names="Calibri" Font-Size="Medium" Height="30px" Width="120px" CausesValidation="true">
                        </asp:Button>
                    </td>
                </tr>
            </table>
            <table width="100%">
                <tr style="height: 30px;">
                    <td>
                        <div style="overflow: scroll; width: 930px;">
                            <Smart:SmartDataGrid ID="dgProductdetail" runat="server" Width="100%" AllowPaging="True"
                                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                                PageSize="200" ShowFooter="True" ForeColor="white" GridLines="both">
                                <Columns>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="PoDetailId"
                                        DataField="PoDetailId" Visible="False" />
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="ItemID"
                                        DataField="ItemID" Visible="FALSE" />
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" Visible="false" HeaderStyle-Width="10%"
                                        HeaderText="Supplier" DataField="PartyAccount">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" Visible="false" HeaderStyle-Width="10%"
                                        HeaderText="Item Type" DataField="ProductType">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="5%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Item Name"
                                        DataField="ItemName">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="40%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Quality"
                                        DataField="Quality">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="8%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="PO QTY"
                                        DataField="Quantity">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="8%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" Visible="false" HeaderStyle-Width="25%"
                                        HeaderText="Item Unit" DataField="UOM">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="Weight"
                                        DataField="Weight" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="Rate"
                                        DataField="Rate">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="4%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="Gross Amount "
                                        DataField="GrossAmount">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" Visible="false" HeaderStyle-Width="25%"
                                        HeaderText="Disc.%" DataField="DiscPercent">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" Visible="false" HeaderStyle-Width="25%"
                                        HeaderText="Disc Amount" DataField="DiscAmount">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" Visible="false" HeaderStyle-Width="25%"
                                        HeaderText="Val Excl S.T" DataField="ValExcloudSalesTax">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" Visible="false" HeaderStyle-Width="25%"
                                        HeaderText="S.T Percentage" DataField="SalesTaxPercentage">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" Visible="false" HeaderStyle-Width="25%"
                                        HeaderText="S.T. Amount" DataField="SalesTaxAmount">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" Visible="false" HeaderStyle-Width="25%"
                                        HeaderText="Net Amount" DataField="NetAmount">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="Size"
                                        DataField="Size">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="6%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="Color"
                                        DataField="Color">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="6%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" Visible="false" HeaderStyle-Width="25%"
                                        HeaderText="Style" DataField="Style">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" Visible="false"
                                        HeaderText="CurrencyId" DataField="CurrencyId">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="Currency"
                                        DataField="Currency">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="8%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" Visible="false" HeaderStyle-Width="25%"
                                        HeaderText="Ex-Rate" DataField="ExchangeRate">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="InvoiceQTY"
                                        DataField="InvoiceQTY" Visible="false" />
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="AccountPayablePartyID"
                                        DataField="AccountPayablePartyID" Visible="False" />
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="ProductTypeId"
                                        DataField="ProductTypeId" Visible="FALSE">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="1%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="1%" HeaderText="UOMID"
                                        DataField="UOMID" Visible="FALSE">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="1%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="1%" HeaderText="JoborderID"
                                        DataField="JoborderID" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="1%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="1%" HeaderText="PO No"
                                        DataField="SrNo" Visible="true">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="1%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="1%" HeaderText="Delivery Date"
                                        DataField="DeliveryDate" Visible="true">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="1%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="1%" HeaderText="Remarks"
                                        DataField="Remarks" Visible="true">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="1%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="1%" HeaderText="SeasonDatabaseID"
                                        DataField="SeasonDatabaseID" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="1%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="1%" HeaderText="Season"
                                        DataField="Season" Visible="true">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="1%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="1%" HeaderText="ClearanceCharges"
                                        DataField="ClearanceCharges" Visible="FALSE">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="1%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" Visible="true" HeaderStyle-Width="02%"
                                        HeaderText="EDIT">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="lnkEdit" ToolTip="Click here to edit" ImageUrl="~/Images/editIcon.jpg"
                                                CommandName="Edit" runat="server"></asp:ImageButton>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="REMOVE"
                                        Visible="true">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="lnkRemove" ToolTip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png"
                                                CommandName="Remove" runat="server"></asp:ImageButton>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                            </Smart:SmartDataGrid>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnSave" runat="server" Skin="WebBlue" Text="Save" Font-Bold="True"
                        Font-Names="Calibri" Font-Size="Medium" Height="30px" Width="120px" CausesValidation="true"
                        Visible="false"></asp:Button>
                </td>
                <td>
                    <asp:Button ID="btnCancel" runat="server" Skin="WebBlue" Text="Cancel" Font-Bold="True"
                        Font-Names="Calibri" Font-Size="Medium" Height="30px" Width="110px" Visible="false">
                    </asp:Button>
                </td>
                <td>
                    <asp:Label ID="lblCheck" runat="server" Visible="false"></asp:Label>
                    <asp:Label ID="lblItemId" runat="server" Visible="false" Text="0"></asp:Label>
                    <asp:Label ID="lblAuditorID" runat="server" Visible="false"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
