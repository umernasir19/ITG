<%@ Page Title="Bank Voucher Entry" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="BankVoucherEntry.aspx.vb" Inherits="Integra.BankVoucherEntry" %>

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
    <asp:Panel ID="PnlBankVoucher" runat="server">
        <table width="100%" id="TABLE1">
            <tr style="font-style: italic; font-size: 25px; color: Blue; height: 30px; vertical-align: middle;">
                <td colspan="3">
                    <u>
                        <asp:Label runat="server" ID="lblBankH" Text=""></asp:Label></u>
                </td>
            </tr>
            <tr style="height: 35px;">
                <td style="width: 100px;">
                    Voucher No
                </td>
                <td style="width: 300px;">
                    <asp:TextBox ID="txtVoucherNo" Style="margin-left: -180px;" ReadOnly="true" CssClass="textbox"
                        runat="server" Width="150px" Visible="true"></asp:TextBox>
                    <asp:TextBox ID="txtVno" ReadOnly="false" CssClass="textbox" runat="server" Width="150px"
                        Visible="false"></asp:TextBox>
                </td>
                <td>
                    <div style="margin-left: -180px; width: 100px; height: 30px;">
                        Voucher Date (dd/mm/yyyy)
                    </div>
                    <%-- <asp:Label ID="lblHddate" runat="server" Text=" Voucher Date (dd/mm/yyyy)" Style="text-align: center;     margin-left: -190px;"></asp:Label>--%>
                </td>
                <td>
                    <asp:TextBox ID="txtVoucherdate2" CssClass="textbox" Width="67" runat="server" Visible="true"
                        AutoPostBack="true" Style="text-transform: uppercase; margin-left: -190px;" ToolTip="dd/mm/yyyy"
                        placeholder="dd/mm/yyyy" autocomplete="off"></asp:TextBox>
                    <asp:TextBox ID="txtVoucherdate" CssClass="textbox" Width="75" runat="server" ReadOnly="false"
                        Visible="false" AutoPostBack="true" Style="text-transform: uppercase;"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtVoucherdate"
                        PopupButtonID="ImageButton1" Enabled="true" />
                    <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" ImageUrl="~/Images/callendar.JPG"
                        Visible="false" AlternateText="Click here to display calendar" />
                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtVoucherdate"
                        Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                        CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                        Enabled="true" UserDateFormat="DayMonthYear" AutoComplete="False">
                    </cc1:MaskedEditExtender>
                    <asp:TextBox ID="txtOriginaldate" CssClass="textbox" Width="75" runat="server" Visible="false"
                        AutoPostBack="true" Style="text-transform: uppercase;" ToolTip="dd/mm/yyyy" placeholder="dd/mm/yyyy"
                        autocomplete="off"></asp:TextBox>
                </td>
                <td>
                    <asp:CheckBox runat="server" ID="chkshowCalander" AutoPostBack="true" Visible="false" />
                </td>
            </tr>
            <asp:Panel ID="pnlbookaccountMst" runat="server" Visible="false">
                <tr style="height: 35px;">
                    <td style="width: 100px;">
                        Book Account
                    </td>
                    <td style="width: 300px;" colspan="3">
                        <asp:UpdatePanel ID="udpcmbBookAccount" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:DropDownList ID="cmbBookAccount" Style="margin-left: -180px;" runat="server"
                                    Width="550" AutoPostBack="true" CssClass="combo" OnSelectedIndexChanged="cmbBookAccount_SelectedIndexChanged">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lbldrcrM" Visible="false" Style="font-weight: bold;
                            background-color: darkgray; font-size: 13px;"></asp:Label>
                    </td>
                </tr>
            </asp:Panel>
            <asp:Panel ID="pnlbookaccountMstSearch" runat="server" Visible="false">
                <tr style="height: 35px;">
                    <td style="width: 100px;">
                        Book Account
                    </td>
                    <td style="width: 300px;">
                        <asp:TextBox ID="txtBookAccountName" CssClass="textbox" runat="server" AutoPostBack="true"
                            autocomplete="off" Width="140px" ToolTip="Voucher No"> </asp:TextBox>
                        <cc1:AutoCompleteExtender runat="server" ID="AutoCompleteExtender1" TargetControlID="txtBookAccountName"
                            ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                            CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="AccountName" />
                        <asp:UpdatePanel ID="btnSearchUPdatebookaccount" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="txtBookAccountName" EventName="TextChanged">
                                </asp:AsyncPostBackTrigger>
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="udpBookAccount" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtBookAccountCode" Enabled="false" CssClass="textbox" Width="100"
                                    runat="server"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="udpGrid3" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtBookAccountLevel" Enabled="false" CssClass="textbox" Width="130"
                                    runat="server"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </asp:Panel>
            <asp:Panel ID="pnlMasterDesc" runat="server" Visible="false">
                <tr style="height: 35px;">
                    <td style="width: 100px;">
                    </td>
                    <td style="width: 300px;" colspan="3">
                        <asp:UpdatePanel ID="udptxtdescription" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtdescription" AutoPostBack="true" runat="server" Width="550px"
                                    TextMode="multiline" Visible="false">  </asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </asp:Panel>
            <tr>
                <td>
                    <asp:UpdatePanel ID="udptxtBankbalance" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <asp:TextBox ID="txtBankbalance" Visible="false" Style="background-color: beige;"
                                Enabled="false" CssClass="textbox" runat="server" Width="150px"></asp:TextBox>
                            <asp:Label runat="server" ID="lblCurrBalanceCRDR" Visible="false" Style="font-weight: bold;
                                background-color: darkgray; font-size: 13px;"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr style="height: 35px;">
                <td style="width: 100px;">
                    Voucher Type
                </td>
                <td style="width: 300px;">
                    <asp:DropDownList ID="cmbVoucherType" Style="margin-left: -180px;" Width="150" CssClass="combo"
                        AutoPostBack="true" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="font-style: italic; font-size: 25px; color: Blue; height: 30px; vertical-align: middle;">
                <td>
                    <u>Detail</u>
                </td>
            </tr>
            <tr>
                <td>
                    Total Payment
                </td>
                <td>
                    <asp:TextBox ID="txtTotalPayment" Style="margin-left: -180px;" onkeypress="return CheckNumeric();"
                        autocomplete="off" onkeyup="FormatCurrency(this);" AutoPostBack="False" CssClass="textbox"
                        runat="server" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr style="height: 35px;">
                <td style="width: 100px;">
                    Cheque No
                </td>
                <td style="width: 300px;">
                    <asp:UpdatePanel ID="udptxtchequeNo" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtchequeNo" Style="margin-left: -180px;" autocomplete="off" CssClass="textbox"
                                runat="server" Width="150px"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td style="width: 100px;">
                </td>
                <td>
                    <asp:UpdatePanel ID="udptxtchequedate" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtchequedate" CssClass="textbox" Width="120" runat="server" AutoPostBack="false"
                                Style="text-transform: uppercase; margin-left: -190px;" Visible="true"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="txtchequedate"
                                PopupButtonID="ImageButton2" />
                            <asp:ImageButton runat="Server" ID="ImageButton2" CausesValidation="false" ImageUrl="~/Images/callendar.JPG"
                                AlternateText="Click here to display calendar" Visible="true" />
                            <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtchequedate"
                                Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                                CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                                Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                            </cc1:MaskedEditExtender>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <asp:Panel ID="pnlAccountCodedtl" runat="server" Visible="false">
                <tr style="height: 35px;">
                    <td style="width: 100px;">
                        Account Code
                    </td>
                    <td style="width: 300px;" colspan="3">
                        <asp:DropDownList ID="cmbAccountCode" Width="550" CssClass="combo" AutoPostBack="false"
                            runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
            </asp:Panel>
            <asp:Panel ID="pnlAccountCodedtlSearchAuto" runat="server" Visible="true">
                <tr style="height: 35px;">
                    <td style="width: 300px;">
                        <asp:UpdatePanel ID="udptxtAccountName" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtAccountName" Visible="false" CssClass="textbox" runat="server"
                                    AutoPostBack="true" autocomplete="off" Width="278px" ToolTip="Voucher No"> </asp:TextBox>
                                <cc1:AutoCompleteExtender runat="server" ID="autoComplete1" TargetControlID="txtAccountName"
                                    ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                                    CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="AccountName" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="udpGrid" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtAccountCode" Enabled="false" Visible="false" CssClass="textbox"
                                    Width="100" runat="server"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="udpGrid1" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtAccountLevel" Enabled="false" Visible="false" CssClass="textbox"
                                    Width="130" runat="server"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lbldrcrD" Visible="false" Style="font-weight: bold;
                            background-color: darkgray; font-size: 13px;"></asp:Label>
                    </td>
                </tr>
            </asp:Panel>
            <tr style="height: 35px;">
                <td>
                    <asp:UpdatePanel ID="udptxtLedgerBalance" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtLedgerBalance" Visible="false" Style="background-color: beige;"
                                Enabled="false" CssClass="textbox" runat="server" Width="150px"></asp:TextBox>
                            <asp:Label runat="server" ID="lblLedgerBalanceCRDR" Visible="false" Style="font-weight: bold;
                                background-color: darkgray; font-size: 13px;"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td style="width: 300px;">
                    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtCostCenter" Visible="false" CssClass="textbox" runat="server"
                                AutoPostBack="true" autocomplete="off" Width="200px" ToolTip="Cost Center"> </asp:TextBox>
                            <cc1:AutoCompleteExtender runat="server" ID="AutoCompleteExtender3" TargetControlID="txtCostCenter"
                                ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                                CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="CostCenter" />
                            <asp:Label runat="server" ID="lblCostCenterId" Text="0" Visible="false" Style="font-weight: bold;
                                background-color: darkgray; font-size: 13px;"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="txtCostCenter" EventName="TextChanged"></asp:AsyncPostBackTrigger>
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr style="height: 35px;">
                <td style="width: 100px;">
                    Description
                </td>
                <td style="width: 300px;" colspan="3">
                    <asp:UpdatePanel ID="udptxtDescriptionDetail" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <asp:TextBox ID="txtDescriptionDetail" Style="margin-left: -180px;" TextMode="multiline"
                                Width="550" runat="server"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr style="height: 35px;">
                <td style="width: 100px;">
                    Type
                </td>
                <td style="width: 300px;">
                    <asp:UpdatePanel ID="udcmbType" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <asp:DropDownList ID="cmbType" Style="margin-left: -180px;" Width="150" CssClass="combo"
                                AutoPostBack="false" runat="server">
                                <asp:ListItem Value="0" Text="D"></asp:ListItem>
                                <asp:ListItem Value="1" Text="C"></asp:ListItem>
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:UpdatePanel ID="udplbldetail" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <asp:Label ID="lbldetail" Visible="false" runat="server"></asp:Label></ContentTemplate>
                    </asp:UpdatePanel>
                    <div style="margin-left: -170px;">
                        Payment Terms
                    </div>
                </td>
                <td>
                    <asp:UpdatePanel ID="udpcmbPaymentTerms" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <asp:DropDownList ID="cmbPaymentTerms" Style="margin-left: -182px;" runat="server"
                                Width="150" AutoPostBack="true" CssClass="combo" OnSelectedIndexChanged="cmbPaymentTerms_SelectedIndexChanged">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr style="height: 35px;">
                <td style="width: 100px;">
                    <asp:UpdatePanel ID="udplblNetAmount" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <asp:Label ID="lblNetAmount" runat="server" Text=" Net Amount" Visible="false"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td style="width: 300px;">
                    <asp:UpdatePanel ID="udptxtPaymentAmount" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <asp:TextBox ID="txtPaymentAmount" onkeyup="FormatCurrency(this);" CssClass="textbox"
                                onkeypress="return isNumericKeyy(event);" Width="120" runat="server" Visible="false"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:UpdatePanel ID="udplblRefNo" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <asp:Label ID="lblRefNo" runat="server" Text="Ref No." Visible="false"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:UpdatePanel ID="udptxtRefNo" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <asp:TextBox ID="txtRefNo" runat="server" Width="120" Visible="false" CssClass="textbox"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td align="right">
                    <asp:UpdatePanel ID="upGetArticle" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:LinkButton Style="margin-left: 0px" ID="LinkToShowPageOFAllInvoiceDetail" runat="server"
                                Visible="False" OnClick="LinkToShowPageOFAllInvoiceDetail_Click">Click here to Show Detail</asp:LinkButton>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="udppnlllfalse" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="pnlllfalse" runat="server" Visible="false">
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:Label ID="lblinvhdng" runat="server" Text="INV. Search"></asp:Label>
                                <asp:TextBox ID="txtShowMeINV" runat="server" Width="140px" AutoPostBack="true" CssClass="textbox"
                                    autocomplete="off" ToolTip="INO. No"> </asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtShowMeINV"
                                    ContextKey="INVShowme" CompletionSetCount="12" EnableCaching="true" CompletionInterval="10"
                                    MinimumPrefixLength="1" ServiceMethod="GetCompletionList" ServicePath="../AutoComplete.asmx">
                                </cc1:AutoCompleteExtender>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="udpdgs" runat="server" ChildrenAsTriggers="true">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td>
                            <Smart:SmartDataGrid ID="dgInvoice" runat="server" Width="100%" AllowPaging="false"
                                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                                PageSize="500" ShowFooter="True" ForeColor="white" GridLines="both">
                                <Columns>
                                    <asp:BoundColumn HeaderText="POInvoiceMstID" DataField="POInvoiceMstID" Visible="False">
                                        <HeaderStyle Width="5%" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <%--<asp:BOUNDCOLUMN HeaderText="POInvoiceAdjDetailID" DataField="POInvoiceAdjDetailID"
                                visible="False">
                                <headerstyle width="5%" />
                                <itemstyle horizontalalign="Left" />
                            </asp:BOUNDCOLUMN>--%>
                                    <asp:BoundColumn HeaderText="S.Tax Inv No" DataField="SaleTaxInvoiceNo">
                                        <HeaderStyle Width="6%" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Payable Party" DataField="SupplierName">
                                        <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Inv. Amount" DataField="InvoiceNetAmount">
                                        <HeaderStyle Width="8%" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Already Payment" DataField="PaymentAmount">
                                        <HeaderStyle Width="8%" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:TemplateColumn HeaderText="S.Tax %" Visible="False">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtSTaxPercentage" runat="server" CssClass="textbox" ReadOnly="false"
                                                Width="40px" Text="0" AutoPostBack="true" OnTextChanged="txtSTaxPercentage_TextChanged"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="4%" HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="S.T Amount" Visible="False">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtSTaxAmount" ReadOnly="true" runat="server" Width="60px" CssClass="textbox"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="6%" HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="G.S.Tax.%" Visible="False">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtGSTaxPercentage" runat="server" CssClass="textbox" AutoPostBack="true"
                                                Text="0" Width="40px" ReadOnly="false" OnTextChanged="txtGSTaxPercentage_TextChanged"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="6%" HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="G.S.Tax. Amount" Visible="False">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtGSTaxAmount" ReadOnly="true" runat="server" Width="60px" CssClass="textbox"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="6%" HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="WHTax %" Visible="False">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtWHTaxPercentage" runat="server" CssClass="textbox" AutoPostBack="true"
                                                Text="0" Width="40px" ReadOnly="false" OnTextChanged="txtWHTaxPercentage_TextChanged"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="6%" HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="WHTax Amount" Visible="False">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtWHTaxAmount" ReadOnly="true" runat="server" Width="60px" CssClass="textbox"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="6%" HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Paid Amount">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtAmount" onkeypress="return isNumericKeyy(event);" runat="server"
                                                Width="100px" CssClass="textbox"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="1%" HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkStatus" runat="server" Style="width: 20px;"></asp:CheckBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="2%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateColumn>
                                    <asp:BoundColumn HeaderText="Date" DataField="Creationdate" Visible="False">
                                        <HeaderStyle Width="5%" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="SupplierdatabaseID" DataField="SupplierdatabaseID" Visible="False">
                                        <HeaderStyle Width="5%" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:TemplateColumn Visible="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCheckdstatus" runat="server" Style="width: 20px;" Text="0"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="2%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateColumn>
                                </Columns>
                                <PagerStyle CssClass="GridPagerStyle" HorizontalAlign="Right" Mode="NumericPages" />
                                <AlternatingItemStyle CssClass="GridAlternativeRow" />
                                <ItemStyle CssClass="GridRow" />
                                <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                            </Smart:SmartDataGrid>
                        </td>
                    </tr>
                    <tr style="height: 25px;">
                        <td>
                            <asp:Button ID="btnAdd" Text="Add" runat="server" Width="100" CssClass="button">
                            </asp:Button>
                            <asp:Label ID="lblerorMsgg" runat="server" Style="background-color: Transparent;
                                color: Red; font-family: Verdana; font-weight: bold; height: 18px; width: 926px;"></asp:Label>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td>
                            <Smart:SmartDataGrid ID="dgView" runat="server" Width="100%" AllowPaging="false"
                                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                                PageSize="500" ShowFooter="True" ForeColor="white" GridLines="both">
                                <Columns>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="tblBankDtlID"
                                        DataField="tblBankDtlID" Visible="False" />
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Cheque No"
                                        DataField="ChequeNo">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="7%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Date"
                                        DataField="ChequeDate">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="7%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="Account Code"
                                        DataField="AccountCode" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="Account Name"
                                        DataField="AccountName" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="Description Entry"
                                        DataField="DescriptionEntry">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="Type "
                                        DataField="Type">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="5%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="Inv. Amount"
                                        DataField="InitialAmount">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="7%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="W.H.Tax.%"
                                        DataField="WHTaxAmount" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="7%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="G.S.Tax.%"
                                        DataField="GSTaxAmount" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="7%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="Paid Amount"
                                        DataField="Amount" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="7%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="W.H.Tax.CR%"
                                        DataField="WHTaxAmountCr" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="7%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="G.S.Tax.Cr%"
                                        DataField="GSTaxAmountCr" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="7%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="W.H.Tax.DB%"
                                        DataField="WHTaxAmountDB" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="7%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="G.S.Tax.DB%"
                                        DataField="GSTaxAmountDB" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="7%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="WHTaxPercentage"
                                        DataField="WHTaxPercentage" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="1%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="GSTaxPercentage"
                                        DataField="GSTaxPercentage" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="1%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="Ref No"
                                        DataField="RefNo" Visible="False">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle Width="7%" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="PaymentTermID" DataField="PaymentTermID" Visible="False">
                                        <HeaderStyle Width="5%" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <%-- <asp:BoundColumn HeaderText="Cost" DataField="Cost">
                                        <HeaderStyle Width="6%" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="CostCenterId" DataField="CostCenterId" Visible="False">
                                        <HeaderStyle Width="5%" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>--%>
                                    <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="EDIT"
                                        Visible="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="lnkEdit" ToolTip="Click here to edit" ImageUrl="~/Images/editIcon.jpg"
                                                CommandName="Edit" runat="server"></asp:ImageButton>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="REMOVE"
                                        Visible="false">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="lnkRemove" ToolTip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png"
                                                CommandName="Remove" runat="server"></asp:ImageButton>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:BoundColumn HeaderText="SaleTaxInvoiceNo" DataField="SaleTaxInvoiceNo" Visible="False">
                                        <HeaderStyle Width="5%" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                </Columns>
                            </Smart:SmartDataGrid>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblTotalHding" runat="server" Visible="false" Text="Total Amount that will Impact on Book Account:"
                                Style="color: Navy; font-weight: bold; margin-left: 483px;"></asp:Label>
                            <asp:Label ID="lbltotalAmount" runat="server" Visible="false"></asp:Label>
                        </td>
                    </tr>
                </table>
                <asp:Panel ID="pnldgpaymentDetailInvoicewise" runat="server" Visible="false">
                    <table width="100%">
                        <tr>
                            <td>
                                <Smart:SmartDataGrid ID="dgpaymentDetailInvoicewise" runat="server" Width="100%"
                                    AllowPaging="false" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4"
                                    CssClass="table" PageSize="500" ShowFooter="True" ForeColor="white" GridLines="both">
                                    <Columns>
                                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="tblBankDtlID"
                                            DataField="tblBankDtlID" Visible="False" />
                                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Cheque No"
                                            DataField="ChequeNo">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="7%" HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Date"
                                            DataField="ChequeDate">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="7%" HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left"  HeaderStyle-Width="0%"  HeaderText=""
                                            DataField="AccountCode"  Visible="false" >
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="0%" HorizontalAlign="Center"/>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left"   HeaderStyle-Width="0%"   HeaderText=""
                                            DataField="AccountName"  Visible="false" >
                                            <ItemStyle HorizontalAlign="Center"  />
                                            <HeaderStyle Width="0%" HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="Description Entry"
                                            DataField="DescriptionEntry">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="Type "
                                            DataField="Type">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="5%" HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="Inv. Amount"
                                            DataField="InitialAmount">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="7%" HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="W.H.Tax.%"
                                            DataField="WHTaxAmount" Visible="false">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="7%" HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="G.S.Tax.%"
                                            DataField="GSTaxAmount" Visible="false">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="7%" HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="Paid Amount"
                                            DataField="Amount">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="7%" HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="W.H.Tax.CR%"
                                            DataField="WHTaxAmountCr" Visible="false">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="7%" HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="G.S.Tax.Cr%"
                                            DataField="GSTaxAmountCr" Visible="false">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="7%" HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="W.H.Tax.DB%"
                                            DataField="WHTaxAmountDB" Visible="false">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="7%" HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="G.S.Tax.DB%"
                                            DataField="GSTaxAmountDB" Visible="false">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="7%" HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="WHTaxPercentage"
                                            DataField="WHTaxPercentage" Visible="false">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="1%" HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="GSTaxPercentage"
                                            DataField="GSTaxPercentage" Visible="false">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="1%" HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="Ref No"
                                            DataField="RefNo">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="7%" HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="PaymentTermID" DataField="PaymentTermID" Visible="False">
                                            <HeaderStyle Width="5%" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="SaleTaxInvoiceNo" DataField="SaleTaxInvoiceNo" Visible="true">
                                            <HeaderStyle Width="5%" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="POInvoiceMstID" DataField="POInvoiceMstID" Visible="true">
                                            <HeaderStyle Width="5%" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="AlreadyPayment" DataField="AlreadyPayment" Visible="true">
                                            <HeaderStyle Width="5%" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="TotalInvoiceAmount" DataField="TotalInvoiceAmount" Visible="true">
                                            <HeaderStyle Width="5%" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <%--  <asp:BoundColumn HeaderText="Cost" DataField="Cost">
                                            <HeaderStyle Width="6%" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="CostCenterId" DataField="CostCenterId" Visible="False">
                                            <HeaderStyle Width="5%" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundColumn>--%>
                                        <asp:TemplateColumn Visible="true">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="lblCheckdstatusForInvoiceInfo" runat="server" Style="width: 20px;">
                                                </asp:CheckBox>
                                            </ItemTemplate>
                                            <HeaderStyle Width="2%" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateColumn>
                                    </Columns>
                                </Smart:SmartDataGrid>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
    </asp:Panel>
    <table>
        <tr>
            <td>
                <asp:Label ID="LblInvoiceMstId" ReadOnly="true" CssClass="textbox" runat="server"
                    Width="150px" Visible="false"></asp:Label>
                <asp:UpdatePanel ID="udpbtnUpadateInv" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:Button ID="btnUpadateInv" runat="server" Text="Save" Visible="true" Width="100"
                    CssClass="button" align="right" />
                <asp:Button ID="BtnCanelInv" runat="server" Text="Cancel" Width="100" Visible="true"
                    CssClass="button" align="right" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtTotalWHTaxAmount" runat="server" Visible="false"></asp:TextBox>
                <asp:TextBox ID="txtTotalSTaxAmount" runat="server" Visible="false"></asp:TextBox>
                <asp:Label ID="LblSupplierId" runat="server" Visible="false"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
