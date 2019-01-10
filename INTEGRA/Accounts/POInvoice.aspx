<%@ Page Title="PO Voucher" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="POInvoice.aspx.vb" Inherits="Integra.POInvoice" %>

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

        function FormatCurrency(ctrl) {
            //Check if arrow keys are pressed - we want to allow navigation around textbox using arrow keys
            if (event.keyCode == 37 || event.keyCode == 38 || event.keyCode == 39 || event.keyCode == 40) {
                return;
            }

            var val = ctrl.value;

            val = val.replace(/,/g, "")
            ctrl.value = "";
            val += '';
            x = val.split('.');
            x1 = x[0];
            x2 = x.length > 1 ? '.' + x[1] : '';

            var rgx = /(\d+)(\d{3})/;

            while (rgx.test(x1)) {
                x1 = x1.replace(rgx, '$1' + ',' + '$2');
            }

            ctrl.value = x1 + x2;
        }

        function CheckNumeric() {
            return event.keyCode >= 48 && event.keyCode <= 57;
        }

    </script>
    <div class="main_container">
        <div class="header_columns">
            <div class="heading">
                PURCHASE VOUCHER ENTRY</div>
            <br />
            <table>
                <tr style="height: 30px;">
                    <td>
                        A/C Payable:
                    </td>
                    <td>
                        <asp:UpdatePanel ID="udpcmbPartyname" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:DropDownList ID="cmbPartyname" AutoPostBack="true" CssClass="combo" Width="161"
                                    runat="server" TabIndex="0">
                                </asp:DropDownList>
                                <asp:Label ID="lblPartyid" runat="server" Visible="false"></asp:Label>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="cmbDCNO" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:Label ID="lblHdngStax" runat="server" Text="Sales Tax Inv:"></asp:Label>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="udptxtsalesTaxInv" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtsalesTaxInv" runat="server" autocomplete="off" AutoPostBack="true"
                                    CssClass="textbox" OnTextChanged="txtsalesTaxInv_TextChanged"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        Date:
                    </td>
                    <td>
                        <asp:TextBox ID="txtVoucherdate2" CssClass="textbox" Width="75" runat="server" Visible="true"
                            AutoPostBack="true" Style="text-transform: uppercase;" ToolTip="dd/mm/yyyy" placeholder="dd/mm/yyyy"
                            autocomplete="off"></asp:TextBox>
                        <asp:TextBox ID="txtCreationDate" CssClass="textbox" Width="129" runat="server" AutoPostBack="true"
                            Style="text-transform: uppercase;" Visible="false"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtCreationDate"
                            PopupButtonID="ImageButton1" />
                        <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" ImageUrl="~/Images/callendar.JPG"
                            AlternateText="Click here to display calendar" Visible="false" />
                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtCreationDate"
                            Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                            CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                            Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                        </cc1:MaskedEditExtender>
                    </td>
                    <td>
                        <asp:CheckBox runat="server" ID="chkshowCalander" AutoPostBack="true" />Show Calander
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <asp:Panel ID="pnlWithGST" runat="server" Visible="false">
                        <td>
                            Supplier Ref No:
                        </td>
                        <td>
                            <asp:UpdatePanel ID="udptxtSupplierRefNo" runat="server" ChildrenAsTriggers="true">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtSupplierRefNo" autocomplete="off" CssClass="textbox" runat="server"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                            Sales Tax
                        </td>
                        <td>
                            <asp:UpdatePanel ID="udptxtSalesTaxP" runat="server" ChildrenAsTriggers="true">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtSalesTaxP" autocomplete="off" CssClass="textbox" runat="server"
                                        AutoPostBack="true"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </asp:Panel>
                </tr>
                <tr style="height: 30px;">
                    <td style="width: 118px;">
                        Transaction No:
                    </td>
                    <td style="width: 170px;">
                        <asp:TextBox ID="txtTransactionNo" autocomplete="off" CssClass="textbox" runat="server"></asp:TextBox>
                    </td>
                     <td style="width: 118px;">
                        Description:
                    </td>
                    <td style="width: 170px;">
                        <asp:TextBox ID="txtDescription" autocomplete="off" CssClass="textbox" runat="server" style="width: 320px;"></asp:TextBox>
                    </td>

                </tr>
                <tr style="height: 30px;">
                    <td>
                        VoucherNo:
                    </td>
                    <td>
                        <asp:TextBox ID="txtVoucherNo" CssClass="textbox" runat="server"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:RadioButtonList ID="RBBtn" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                            <asp:ListItem Value="0" Selected="True">With GST</asp:ListItem>
                            <asp:ListItem Value="1" style="margin-left: 16px;">With Out GST</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <asp:Panel ID="pnlExtra" runat="server" Visible="false">
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                            BillDate:
                        </td>
                        <td>
                            <asp:TextBox ID="txtBillDate" CssClass="textbox" Width="129" runat="server" AutoPostBack="false"
                                Style="text-transform: uppercase;"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="txtBillDate"
                                PopupButtonID="ImageButton2" />
                            <asp:ImageButton runat="Server" ID="ImageButton2" CausesValidation="false" ImageUrl="~/Images/callendar.JPG"
                                AlternateText="Click here to display calendar" />
                            <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtBillDate"
                                Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                                CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                                Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                            </cc1:MaskedEditExtender>
                        </td>
                    </tr>
                    <tr style="height: 30px;">
                        <td>
                            Company S.T No:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCompanySTNo" CssClass="textbox" runat="server" Text="0" onkeypress="return isNumericKey(event);"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height: 30px;">
                        <td>
                            Other Ref No.
                        </td>
                        <td>
                            <asp:TextBox ID="txtrefNo" CssClass="textbox" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            Buyer S.T No:
                        </td>
                        <td>
                            <asp:TextBox ID="txtBuyerSTNo" CssClass="textbox" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height: 30px;">
                        <td>
                            Company CST No:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCompanyCSTNo" CssClass="textbox" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            Comapny PAN:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCompanyPAN" CssClass="textbox" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </asp:Panel>
            </table>
            <%--<tr style="font-style: italic; font-size: 25px; color: Blue; height: 30px; vertical-align: middle;">
                    <td colspan="3">
                        <u>Detail</u></td>
                </tr>--%>
            <asp:UpdatePanel ID="udpdgJunaidinfo" runat="server">
                <ContentTemplate>
                    <asp:Panel runat="server" ID="pnlJunaidinfo" Visible="false">
                        <div class="heading">
                            Ledger Calculation</div>
                        <br />
                        <%-- Start Portion For Junaid info --%>
                        <table width="100%">
                            <tr style="height: 30px">
                                <td>
                                    <Smart:SmartDataGrid ID="dgJunaidinfo" runat="server" Width="100%" ForeColor="white"
                                        CssClass="table" GridLines="both" ShowFooter="false" PageSize="500" CellPadding="4"
                                        AutoGenerateColumns="False" AllowSorting="True" AllowPaging="false">
                                        <PagerStyle Mode="NumericPages" HorizontalAlign="Right" CssClass="GridPagerStyle">
                                        </PagerStyle>
                                        <AlternatingItemStyle CssClass="GridAlternativeRow"></AlternatingItemStyle>
                                        <ItemStyle CssClass="GridRow"></ItemStyle>
                                        <Columns>
                                            <asp:TemplateColumn HeaderText="Qunatity">
                                                <ItemTemplate>
                                                    <asp:Label ID="txtQunatityJND" runat="server" CssClass="textbox" Text='<%# Eval("TotalQty") %>'
                                                        Width="60"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="7%"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="Rate">
                                                <ItemTemplate>
                                                    <asp:Label ID="txtRateJND" runat="server" CssClass="textbox" Text='<%# Eval("Rate") %>'
                                                        Width="60"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="7%"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="txtNetAmountJND" runat="server" CssClass="textbox" Text='<%# Eval("NetAmount") %>'
                                                        Width="60"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="7%"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                            </asp:TemplateColumn>
                                        </Columns>
                                        <HeaderStyle HorizontalAlign="Center" CssClass="GridHeaderStyle"></HeaderStyle>
                                    </Smart:SmartDataGrid>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label Style="margin-left: 655px" ID="lblTotalAMtJND" runat="server" Text="Total Amount:"
                                        Visible="true"></asp:Label>
                                    <asp:TextBox Style="width: 99px" onkeyup="FormatCurrency(this);" ID="txtTotalAmountJND"
                                        runat="server" CssClass="textbox" Enabled="False" BackColor="Silver" Visible="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label Style="margin-left: 627px" ID="lblSalesTaxAmountJND" runat="server" Text="Sales Tax Amount:"
                                        Visible="true"></asp:Label>
                                    <asp:TextBox Style="width: 99px" onkeyup="FormatCurrency(this);" ID="txtTotalSalesTaxAmountJND"
                                        runat="server" CssClass="textbox" Enabled="False" BackColor="Silver" Visible="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label Style="margin-left: 650px" ID="lblTotalJND" runat="server" Text="Gross Amount:"
                                        Visible="true"></asp:Label>
                                    <asp:TextBox Style="width: 99px" onkeyup="FormatCurrency(this);" ID="txtTotalJND"
                                        runat="server" CssClass="textbox" Enabled="False" BackColor="Silver" Visible="true"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
            <%-- Start Portion For Junaid info --%>
            <div class="heading">
                DETAIL</div>
            <br />
            <table>
                <tr style="height: 30px;">
                    <td>
                        <asp:Label ID="lblDCNo" runat="server" Width="120" Text="DC NO:"></asp:Label>
                    </td>
                    <td style="width: 160px;">
                        <asp:UpdatePanel ID="udpcmbDCNO" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:DropDownList ID="cmbDCNO" runat="server" Width="136px" AutoPostBack="true" CssClass="combo"
                                    OnSelectedIndexChanged="cmbDCNO_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:Label ID="lblPartyFrom" runat="server" Visible="false"></asp:Label>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="dgProductdetail"></asp:AsyncPostBackTrigger>
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:Label ID="lblAccountLedgerCode" runat="server" Visible="false" Text=""></asp:Label>
                        <asp:Label ID="lblProductType" runat="server" Visible="false" Text=" Product Type:"></asp:Label>
                        <asp:Label ID="lblAccountLedger" runat="server" Visible="true" Text="Account Ledger:"></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:UpdatePanel ID="udpcmbProductType" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:DropDownList ID="cmbProductType" Width="133px" CssClass="combo" Visible="false"
                                    AutoPostBack="true" runat="server">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:TextBox ID="txtAccountLedger" runat="server" CssClass="textbox" AutoPostBack="true"
                            autocomplete="off" Width="250px" ToolTip="Voucher No"> </asp:TextBox>
                        <cc1:AutoCompleteExtender runat="server" ID="autoComplete1" TargetControlID="txtAccountLedger"
                            ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                            CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="AccountLedger" />
                    </td>
                </tr>


               <%-- <tr style="height: 30px;">
                    <td>
                        <asp:Label ID="Label1" runat="server" Width="120" Text="PO No:"></asp:Label>
                    </td>
                    <td style="width: 160px;">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                   <asp:TextBox ID="TXTPONo" AutoPostBack="true" CssClass="textbox" runat="server"></asp:TextBox>
                <cc1:AutoCompleteExtender runat="server" ID="AutoCompleteExtender2" TargetControlID="TXTPONo"
                    ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                    CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="TXTPONO" /></div>
                                <asp:Label ID="lblPONo" runat="server" Visible="false"></asp:Label>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="dgProductdetail"></asp:AsyncPostBackTrigger>
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                     
                    </td>
                    <td colspan="3">
                      
                    </td>
                </tr>--%>


            </table>
            <asp:Panel ID="PnlDetailEdit" runat="server" Visible="false">
                <table>
                    <tr style="height: 30px;">
                        <td>
                            Product Name:
                        </td>
                        <td colspan="3">
                            <asp:UpdatePanel ID="udpcmbProduct" runat="server" ChildrenAsTriggers="true">
                                <ContentTemplate>
                                    <asp:DropDownList ID="cmbproduct" Width="380px" CssClass="combo" AutoPostBack="false"
                                        runat="server">
                                    </asp:DropDownList>
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
                                    <asp:TextBox ID="txtQuantity" CssClass="textbox" runat="server" AutoPostBack="true"
                                        onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                            Weight:
                        </td>
                        <td>
                            <asp:UpdatePanel ID="udptxtWeight" runat="server" ChildrenAsTriggers="true">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtWeight" CssClass="textbox" runat="server" onkeypress="return isNumericKeyy(event);"></asp:TextBox>
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
                                    <asp:TextBox ID="txtrate" CssClass="textbox" runat="server" AutoPostBack="true" onkeypress="return isNumericKeyy(event);"></asp:TextBox>
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
                                    <asp:TextBox ID="txtValueExcloudeST" CssClass="textbox" runat="server" AutoPostBack="false"
                                        BackColor="Silver" Enabled="False" onkeypress="return isNumericKeyy(event);"></asp:TextBox>
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
                            <asp:UpdatePanel ID="udptxttxtNetAmount" runat="server" ChildrenAsTriggers="true">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtNetAmount" CssClass="textbox" runat="server" BackColor="Silver"
                                        Enabled="False" onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdatePanel ID="udplbldetail" runat="server" ChildrenAsTriggers="true">
                                <ContentTemplate>
                                    <asp:Label ID="lblPOInvoicedetailID" Visible="false" runat="server"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdatePanel ID="udplblPOdetailid" runat="server" ChildrenAsTriggers="true">
                                <ContentTemplate>
                                    <asp:Label ID="lblPOdetailid" Visible="false" runat="server"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdatePanel ID="udlblQuantity" runat="server" ChildrenAsTriggers="true">
                                <ContentTemplate>
                                    <asp:Label ID="lblQuantity" Visible="false" runat="server"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdatePanel ID="udplblPORecvDetailTwoID" runat="server" ChildrenAsTriggers="true">
                                <ContentTemplate>
                                    <asp:Label ID="lblPORecvDetailTwoID" Visible="false" runat="server"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdatePanel ID="udplblALreadyInvoiceQty" runat="server" ChildrenAsTriggers="true">
                                <ContentTemplate>
                                    <asp:Label ID="lblALreadyInvoiceQty" Visible="false" runat="server"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
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
            </asp:Panel>
            <asp:UpdatePanel ID="udpdgProductdetail" runat="server" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <table width="100%">
                        <tr style="height: 30px">
                            <td>
                                <Smart:SmartDataGrid ID="dgProductdetail" runat="server" Width="100%" ForeColor="white"
                                    CssClass="table" GridLines="both" ShowFooter="false" PageSize="500" CellPadding="4"
                                    AutoGenerateColumns="False" AllowSorting="True" AllowPaging="false">
                                    <PagerStyle Mode="NumericPages" HorizontalAlign="Right" CssClass="GridPagerStyle">
                                    </PagerStyle>
                                    <AlternatingItemStyle CssClass="GridAlternativeRow"></AlternatingItemStyle>
                                    <ItemStyle CssClass="GridRow"></ItemStyle>
                                    <Columns>
                                        <asp:BoundColumn DataField="POInvoiceDetailID" HeaderText="POInvoiceDetailID" Visible="False">
                                            <HeaderStyle Width="5%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="ItemID" HeaderText="ItemID" Visible="False">
                                            <HeaderStyle Width="5%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="DCDate" HeaderText="Date">
                                            <HeaderStyle HorizontalAlign="Center" Width="8%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="PartyDCNo" HeaderText="Party DCNo">
                                            <HeaderStyle HorizontalAlign="Center" Width="8%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="PONO" HeaderText="PO NO">
                                            <HeaderStyle HorizontalAlign="Center" Width="15%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="ItemCode" HeaderText="Product Code">
                                            <HeaderStyle HorizontalAlign="Center" Width="15%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="ItemName" HeaderText="Product Name">
                                            <HeaderStyle HorizontalAlign="Center" Width="15%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:TemplateColumn HeaderText="Qunatity">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtQunatity" runat="server" CssClass="textbox" Text='<%# Eval("TotalQty") %>'
                                                    Width="60" __designer:wfdid="w2" OnTextChanged="txtQunatity_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="7%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                        </asp:TemplateColumn>
                                        <asp:BoundColumn DataField="Weight" HeaderText="Weight" Visible="False">
                                            <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="Rate" HeaderText="Rate" Visible="False">
                                            <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="GrossAmount" HeaderText="Gross Amount" Visible="False">
                                            <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="DiscPercent" HeaderText="Disc.%" Visible="False">
                                            <HeaderStyle HorizontalAlign="Center" Width="7%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="DiscAmount" HeaderText="Disc Amount" Visible="False">
                                            <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="ValExcloudSalesTax" HeaderText="Val Excl S.T" Visible="False">
                                            <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="SalesTaxPercentage" HeaderText="S.T Percentage" Visible="False">
                                            <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="SalesTaxAmount" HeaderText="S.T. Amount" Visible="False">
                                            <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="NetAmount" HeaderText="Net Amount" Visible="False">
                                            <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:TemplateColumn HeaderText="EDIT" Visible="False">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="lnkEdit" ToolTip="Click here to edit" ImageUrl="~/Images/editIcon.jpg"
                                                    CommandName="Edit" runat="server" Visible="false"></asp:ImageButton>
                                            </ItemTemplate>
                                            <HeaderStyle Width="2%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="REMOVE" Visible="False">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="lnkRemove" ToolTip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png"
                                                    CommandName="Remove" runat="server"></asp:ImageButton>
                                            </ItemTemplate>
                                            <HeaderStyle Width="2%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn Visible="False">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkStatus" Visible="false" runat="server" Style="width: 20px;">
                                                </asp:CheckBox>
                                            </ItemTemplate>
                                            <HeaderStyle Width="2%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateColumn>
                                        <asp:BoundColumn DataField="PODetailID" HeaderText="PODetailID" Visible="False">
                                            <HeaderStyle Width="1%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="PORecvDetailTwoID" HeaderText="PORecvDetailTwoID" Visible="False">
                                            <HeaderStyle Width="1%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="PORecvMasterID" HeaderText="PORecvMasterID" Visible="False">
                                            <HeaderStyle Width="1%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="PreInvoiceQty" HeaderText="Pre Post Qty">
                                            <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="Balance" HeaderText="Balance">
                                            <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="INVFrom" HeaderText="INVFrom" Visible="false">
                                            <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundColumn>
                                    </Columns>
                                    <HeaderStyle HorizontalAlign="Center" CssClass="GridHeaderStyle"></HeaderStyle>
                                </Smart:SmartDataGrid>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label Style="margin-left: 655px" ID="lblTotalAMt" runat="server" Text="Total Amount:"
                                    Visible="false"></asp:Label>
                                <asp:TextBox Style="width: 99px" ID="txtTotalAmount" runat="server" CssClass="textbox"
                                    Enabled="true" BackColor="Silver" Visible="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label Style="margin-left: 627px" ID="lblSalesTaxAmount" runat="server" Text="Sales Tax Amount:"
                                    Visible="false"></asp:Label>
                                <asp:TextBox Style="width: 99px" ID="txtTotalSalesTaxAmount" runat="server" CssClass="textbox"
                                    Enabled="true" BackColor="Silver" Visible="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label Style="margin-left: 703px" ID="lblTotal" runat="server" Text="Total:"
                                    Visible="false"></asp:Label>
                                <asp:TextBox Style="width: 99px" ID="txtTotal" runat="server" CssClass="textbox"
                                    Enabled="true" BackColor="Silver" Visible="false"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <br />
        <%--  <asp:UpdatePanel ID="udpbtnSaveCancel" runat="server" ChildrenAsTriggers="true">
            <contenttemplate>--%>
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
            </tr>
        </table>
        <%--   <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" TargetControlID="btnSave"
        OnClientCancel="cancelClick" DisplayModalPopupID="ModalPopupExtender1" />
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnSave"
        PopupControlID="PNL" OkControlID="ButtonOk" CancelControlID="ButtonCancel" BackgroundCssClass="modalBackground" />
    <asp:Panel ID="PNL" runat="server" Style="display: none; height: 120px; width: 350px;
        background-color: White; top: 50px; border-width: 2px; border-color: Black; border-style: solid;
        padding: 20px;">
        <table>
            <tr>
                <td>
                    <asp:Image ID="imgSave" runat="server" Height="70px" ImageUrl="~/Images/warning.ico" /></td>
                <td style="width: 5px;">
                </td>
                <td style="font-family: Tahoma; font-size: 11px; font-weight: bold;">
                    <asp:Label ID="lblUser" CssClass="label" runat="server"></asp:Label>&nbsp; Are you
                    sure you want to Save Bill.?</td>
            </tr>
        </table>
        <br />
        <div style="text-align: right;">
            <asp:ImageButton ID="ButtonOk" CssClass="button" runat="server" Width="40" Height="40"
                ImageUrl="~/Images/OKNEW.png" />
            <asp:ImageButton ID="ButtonCancel" CssClass="button" runat="server" Width="40" Height="40"
                ImageUrl="~/Images/close.png" />
        </div>
    </asp:Panel>
        --%>
        <%--     </contenttemplate>
        </asp:UpdatePanel>--%>
    </div>
</asp:Content>
