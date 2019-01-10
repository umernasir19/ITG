<%@ Page Title="Cash Voucher Entry" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="CashVoucherEntry.aspx.vb" Inherits="Integra.CashVoucherEntry" %>

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
        <table width="100%">
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
                    <asp:TextBox ID="txtVoucherNo" ReadOnly="true" CssClass="textbox" runat="server"
                        Width="150px"></asp:TextBox>
                </td>
                <td style="width: 100px;">
                    <asp:Label ID="lblHddate" runat="server" Text=" Voucher Date (dd/mm/yyyy)" Style="text-align: center;"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtVoucherdate2" CssClass="textbox" Width="75" runat="server" Visible="False"
                        AutoPostBack="true" Style="text-transform: uppercase;" ToolTip="dd/mm/yyyy" placeholder="dd/mm/yyyy"
                        autocomplete="off"></asp:TextBox>
                    <asp:TextBox ID="txtVoucherdate" CssClass="textbox" Width="95px" runat="server" AutoPostBack="False"
                        Style="text-transform: uppercase;" Visible="True"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtVoucherdate"
                        PopupButtonID="ImageButton1" />
                    <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" ImageUrl="~/Images/callendar.JPG"
                        AlternateText="Click here to display calendar" Visible="True" />
                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtVoucherdate"
                        Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                        CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                        Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                    </cc1:MaskedEditExtender>
                </td>
                <td>
                    <asp:CheckBox runat="server" ID="chkshowCalander" Visible="false" AutoPostBack="true" />
                </td>
            </tr>
            <tr style="height: 35px;">
                <td style="width: 100px;">
                    V No.
                </td>
                <td style="width: 300px;">
                    <asp:TextBox ID="txtVno" ReadOnly="false" CssClass="textbox" runat="server" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <asp:Panel ID="pnlbookaccountMst" runat="server" Visible="false">
                <tr style="height: 35px;">
                    <td style="width: 100px;">
                        Book Account
                    </td>
                    <td style="width: 300px;" colspan="3">
                        <asp:DropDownList ID="cmbBookAccount" Width="550" CssClass="combo" AutoPostBack="true"
                            runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lbldrcrM" Style="font-weight: bold; background-color: darkgray;
                            font-size: 13px;"></asp:Label>
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
            <tr>
                <td>
                    Curr Balance
                </td>
                <td>
                    <asp:UpdatePanel ID="udptxtBankbalance" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <asp:TextBox ID="txtBankbalance" Style="background-color: beige;" Enabled="false"
                                CssClass="textbox" runat="server" Width="150px"></asp:TextBox>
                            <asp:Label runat="server" ID="lblCurrBalanceCRDR" Style="font-weight: bold; background-color: darkgray;
                                font-size: 13px;"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr style="height: 35px;">
                <td style="width: 100px;">
                    Voucher Type
                </td>
                <td style="width: 300px;">
                    <asp:DropDownList ID="cmbVoucherType" Width="150" CssClass="combo" AutoPostBack="true"
                        runat="server">
                        <asp:ListItem Value="0" Text="Select Type"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Cash Receipt"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Cash Payment"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="height: 35px;">
                <td style="width: 100px;">
                </td>
                <td style="width: 300px;" colspan="3">
                    <asp:TextBox ID="txtdescription" AutoPostBack="true" Visible="false" Text="N/A" CssClass="textbox"
                        runat="server" Width="557px">  </asp:TextBox>
                </td>
            </tr>
            <tr style="font-style: italic; font-size: 25px; color: Blue; height: 30px; vertical-align: middle;">
                <td>
                    <u>Detail</u>
                </td>
            </tr>
            <%-- <tr style="height: 35px;">
                <td style="width: 100px;">
                    Cheque No
                </td>
                <td style="width: 300px;">
                    <asp:TextBox ID="txtchequeNo" CssClass="textbox" runat="server" Width="150px"></asp:TextBox></td>
                <td style="width: 100px;">
                    Cheque Date
                </td>
                <td>
                    <asp:TextBox ID="txtchequedate" CssClass="textbox" Width="95px" runat="server" AutoPostBack="false"
                        Style="text-transform: uppercase;"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="txtchequedate"
                        PopupButtonID="ImageButton2" />
                    <asp:ImageButton runat="Server" ID="ImageButton2" CausesValidation="false" ImageUrl="~/Images/callendar.JPG"
                        AlternateText="Click here to display calendar" />
                    <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtchequedate"
                        Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                        CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                        Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                    </cc1:MaskedEditExtender>
                </td>
            </tr>--%>
            <asp:Panel ID="pnlAccountCodedtl" runat="server" Visible="false">
                <tr style="height: 35px;">
                    <td style="width: 100px;">
                        Account Code
                    </td>
                    <td style="width: 300px;" colspan="3">
                        <asp:DropDownList ID="cmbAccountCode" Width="563px" CssClass="combo" AutoPostBack="false"
                            runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
            </asp:Panel>
            <asp:Panel ID="pnlAccountCodedtlSearchAuto" runat="server" Visible="false">
                <tr style="height: 35px;">
                    <td style="width: 100px;">
                        <%--  Account Name--%>
                        Ledger
                    </td>
                    <td style="width: 300px;">
                        <asp:TextBox ID="txtAccountName" CssClass="textbox" runat="server" AutoPostBack="true"
                            autocomplete="off" Width="350px" ToolTip="Voucher No"> </asp:TextBox>
                        <cc1:AutoCompleteExtender runat="server" ID="autoComplete1" TargetControlID="txtAccountName"
                            ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                            CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="AccountNamewithcode" />
                        <asp:UpdatePanel ID="btnSearchUPdate" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="txtAccountName" EventName="TextChanged"></asp:AsyncPostBackTrigger>
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="udpGrid" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtAccountCode" Enabled="false" CssClass="textbox" Width="100" runat="server"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="udpGrid1" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtAccountLevel" Enabled="false" CssClass="textbox" Width="95px"
                                    runat="server"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lbldrcrD" Style="font-weight: bold; background-color: darkgray;
                            font-size: 13px;"></asp:Label>
                    </td>
                </tr>
            </asp:Panel>
            <tr style="height: 35px;">
                <td>
                    Ledger Balane
                </td>
                <td>
                    <asp:UpdatePanel ID="udptxtLedgerBalance" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtLedgerBalance" Style="background-color: beige;" Enabled="false"
                                CssClass="textbox" runat="server" Width="150px"></asp:TextBox>
                            <asp:Label runat="server" ID="lblLedgerBalanceCRDR" Style="font-weight: bold; background-color: darkgray;
                                font-size: 13px;"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td style="width: 100px;">
                    <%-- Account Name--%>
                    Cost Center
                </td>
                <td style="width: 300px;">
                    <asp:TextBox ID="txtCostCenter" CssClass="textbox" runat="server" AutoPostBack="true"
                        autocomplete="off" Width="200px" ToolTip="Cost Center"> </asp:TextBox>
                    <cc1:AutoCompleteExtender runat="server" ID="AutoCompleteExtender2" TargetControlID="txtCostCenter"
                        ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                        CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="CostCenter" />
                    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:Label runat="server" ID="lblCostCenterId" Text ="0" Visible="false" Style="font-weight: bold;
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
                    Narration
                </td>
                <td style="width: 300px;" colspan="3">
                    <asp:TextBox ID="txtDescriptionDetail" Height="20px" Width="557px" runat="server"
                        TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr style="height: 35px;">
                <td style="width: 100px;">
                    Type
                </td>
                <td style="width: 300px;">
                    <asp:DropDownList ID="cmbType" Width="150" CssClass="combo" AutoPostBack="false"
                        runat="server">
                        <asp:ListItem Value="0" Text="D"></asp:ListItem>
                        <asp:ListItem Value="1" Text="C"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 100px;">
                    Amount
                </td>
                <td>
                    <asp:TextBox ID="txtamount" autocomplete="off" onkeyup="FormatCurrency(this);" CssClass="textbox"
                        Width="95px" runat="server" onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                    <asp:Label ID="lbldetail" Visible="false" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="height: 35px;">
                <td>
                </td>
                <td>
                    <asp:Button ID="btnAdd" Text="Add" runat="server" Width="100" CssClass="button">
                    </asp:Button>
                </td>
                <td>
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td>
                    <Smart:SmartDataGrid ID="dgView" runat="server" Width="100%" AllowPaging="True" AllowSorting="True"
                        AutoGenerateColumns="False" CellPadding="4" CssClass="table" PageSize="15" ShowFooter="True"
                        ForeColor="white" GridLines="both">
                        <Columns>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="tblCashDtlID"
                                DataField="tblCashDtlID" Visible="False" />
                            <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Cheque No"
                                DataField="ChequeNo" Visible="false">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle Width="15%" HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Date"
                                DataField="ChequeDate" Visible="false">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle Width="15%" HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="Account Code"
                                DataField="AccountCode">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle Width="15%" HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="Account Name"
                                DataField="AccountName">
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
                                <HeaderStyle Width="15%" HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="Amount"
                                DataField="Amount">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle Width="15%" HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Cost" DataField="Cost">
                                <HeaderStyle Width="6%" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="CostCenterId" DataField="CostCenterId" Visible="False">
                                <HeaderStyle Width="5%" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="EDIT" Visible="false">
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkEdit" Visible="false" ToolTip="Click here to edit" ImageUrl="~/Images/editIcon.jpg"
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
                        </Columns>
                    </Smart:SmartDataGrid>
                </td>
            </tr>
        </table>
        <br />
        <%-- <table>
            <tr style="height: 35px; width: 50%;">
                <td>
                    <asp:LinkButton ID="lnkDeliveryType" runat="server" Visible="false" CausesValidation="false"
                        CssClass="label">Get Invoice</asp:LinkButton>
                </td>
            </tr>
        </table>--%>
        <%-- <table width="100%">
            <tr>
                <td style="width: 450px;">
                </td>
                <td>
                    <asp:Label ID="lblTotalHding" runat="server" Visible="false" Text="Total Amount that will Impact on Book Account:"
                        Style="color: Navy; font-weight: bold;"></asp:Label></td>
                <td align="center" style="width: 150px;">
                    <asp:Label ID="lbltotalAmount" runat="server" Visible="false"></asp:Label>
                    <%--<asp:TextBox ID="txttotalAmount" ReadOnly="true"   Visible ="false" CssClass="textbox" Width="100" runat="server"
                    onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 450px;">
                    <asp:RadioButtonList ID="RBBtn" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" Visible ="false" >
                        <asp:ListItem Value="0">Adjust Invoice</asp:ListItem>
                        <asp:ListItem Value="1" Selected="True" style="margin-left: 96px;">General Expense</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
        --%>
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnSave" Text="Save" runat="server" Width="100" CssClass="button"
                        align="right"></asp:Button>
                    <asp:Button ID="btnCancel" Text="Cancel" runat="server" Width="100" CssClass="button"
                        CausesValidation="false"></asp:Button>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <%-- <table>
        <tr>
            <td>
                <asp:Button ID="btnCheck" Text="Check" runat="server" Visible="false" Width="100"
                    CssClass="button" align="right"></asp:Button>
                <asp:Button ID="aaa" Text="Caaaheck" runat="server" Visible="false" Width="100" CssClass="button"
                    align="right"></asp:Button>
            </td>
        </tr>
    </table>--%>
    <%--  <asp:Panel ID="PnlInvoiceGridAdjust" runat="server">
        <table width="100%">
            <tr>
                <td>
                    <Smart:SmartDataGrid ID="dgInvoiceFirst" runat="server" Width="100%" OnSortCommand="SortByColumn"
                        OnPageIndexChanged="PageChanged" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                        CellPadding="4" CssClass="table" PageSize="10" ShowFooter="True" ForeColor="white"
                        GridLines="both">
                        <Columns>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="InvoiceMstID"
                                DataField="InvoiceMstID" visible="false" />
                            <%--<asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="InvoiceDtlID"
                                DataField="InvoiceDtlID" visible="false" />
    <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Supplier Name" DataField="SupplierName">
        <headerstyle horizontalalign="center" width="25%" />
    </asp:BOUNDCOLUMN>
    <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Invoice No" DataField="InvoiceNo">
        <headerstyle horizontalalign="center" width="7%" />
    </asp:BOUNDCOLUMN>
    <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Invoice Date" DataField="InvoiceDatee">
        <headerstyle horizontalalign="center" width="7%" />
    </asp:BOUNDCOLUMN>
    <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Payable Amount" DataField="PayableAmount">
        <headerstyle horizontalalign="center" width="6%" />
    </asp:BOUNDCOLUMN>
    <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" visible="TRUE" HeaderStyle-Width="02%"
        HeaderText="Adjust">
        <itemtemplate>																	
						<asp:ImageButton id="lnkAdjustInvoice" tooltip="Click here to edit"  ImageUrl="~/Images/editIcon.jpg" CommandName="Adjust" runat="server"></asp:ImageButton>
						</itemtemplate>
    </asp:TEMPLATECOLUMN>
    <%--  <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="REMOVE"  visible="FALSE">
                            <itemtemplate>									 								
										<asp:ImageButton id="lnkRemoveInvoice" tooltip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png" CommandName="Remove" runat="server"></asp:ImageButton>
									</itemtemplate>
                        </asp:TEMPLATECOLUMN>
                            <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="PDF"
                                visible="false">
                                <itemtemplate>								
	<asp:ImageButton id="lnkPDF" tooltip="Click here to download PDF" ImageUrl="~/Images/pdf_icon_small.gif" CommandName="PDF" runat="server"></asp:ImageButton>
									</itemtemplate>
                            </asp:TEMPLATECOLUMN>
                             
                        </Columns>
                    </Smart:SmartDataGrid>
                </td>
            </tr>
        </table>
    </asp:Panel>--%>
    <asp:Panel ID="PNAfterAdjustClickLabelGridBind" runat="server">
        <%-- <table width="100%">
            <tr style="height: 35px;">
                <td style="width: 100px;">
                    Supplier :
                </td>
                <td style="width: 300px;">
                    <asp:Label ID="lblSupplierInv" ReadOnly="true" CssClass="textbox" runat="server"
                        Width="150px"></asp:Label></td>
                <td style="width: 100px;">
                    Invoice No :
                </td>
                <td>
                    <asp:Label ID="lblInvoiceNoInv" ReadOnly="true" CssClass="textbox" runat="server"
                        Width="150px"></asp:Label>
                </td>
            </tr>
            <tr style="height: 35px;">
                <td style="width: 100px;">
                    Payable :
                </td>
                <td style="width: 300px;">
                    <asp:Label ID="lblPayable" ReadOnly="true" CssClass="textbox" runat="server" Width="150px"></asp:Label></td>
                <td style="width: 100px;">
                    Invoice Date :
                </td>
                <td>
                    <asp:Label ID="lblInvoiceDateInv" ReadOnly="true" CssClass="textbox" runat="server"
                        Width="150px"></asp:Label>
                </td>
            </tr>
        </table>--%>
        <%--  <table width="100%">
            <tr>
                <td colspan="3">
                    <h1 style="background: #c6deff; color: Black;" align="center">
                        PARTY LeDGER / INVOICE ADJUSTMENT</h1>
                </td>
            </tr>
            <tr>
                <td>
                    <Smart:SmartDataGrid ID="dgAfterAdjustClickLabelGridBind" runat="server" Width="100%"
                        OnSortCommand="SortByColumn" OnPageIndexChanged="PageChanged" AllowPaging="True"
                        AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                        PageSize="10" ShowFooter="True" ForeColor="white" GridLines="both">
                        <Columns>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="InvoiceMstID"
                                DataField="InvoiceMstID" visible="false" />
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="InvoiceDtlID"
                                DataField="InvoiceDtlID" visible="false" />
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Invoice Date" DataField="InvoiceDatee">
                                <headerstyle horizontalalign="center" width="7%" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Opening Amount" DataField="OpeningAmount">
                                <headerstyle horizontalalign="center" width="7%" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Ajusted Amount" DataField="AjustedAmount">
                                <headerstyle horizontalalign="center" width="7%" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Balance Amount" DataField="BalanceAmountDTL">
                                <headerstyle horizontalalign="center" width="6%" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Payment Type" DataField="PaymentType">
                                <headerstyle horizontalalign="center" width="6%" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Payment Vocuher RefNo"
                                DataField="PaymentVocuherRefNo">
                                <headerstyle horizontalalign="center" width="6%" />
                            </asp:BOUNDCOLUMN>
                            <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" visible="false" HeaderStyle-Width="02%"
                                HeaderText="Adjust Invoice">
                                <itemtemplate>																	
						<asp:ImageButton id="lnkAfterAdjust" tooltip="Click here to edit"  ImageUrl="~/Images/editIcon.jpg" CommandName="Adjust" runat="server"></asp:ImageButton>
						</itemtemplate>
                            </asp:TEMPLATECOLUMN>
                            <%-- <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="REMOVE"  visible="FALSE">
                            <itemtemplate>									 								
										<asp:ImageButton id="lnkRemoveInvoice" tooltip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png" CommandName="Remove" runat="server"></asp:ImageButton>
									</itemtemplate>
                        </asp:TEMPLATECOLUMN>
                        </Columns>
                    </Smart:SmartDataGrid>
                </td>
            </tr>
        </table>--%>
        <br />
        <%-- <table>
            <tr>
                <td>
                    <asp:Button ID="btnAdjust" runat="server" Text="Adjust" Width="100" CssClass="button"
                        align="right" />
                </td>
            </tr>
        </table>--%>
        <br />
        <%--     <table width="100%">
            <tr>
                <td>
                    <Smart:SmartDataGrid ID="dgAfterAdjustClickLabelGridBindForUpdate" runat="server"
                        Width="100%" OnSortCommand="SortByColumn" OnPageIndexChanged="PageChanged" AllowPaging="True"
                        AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                        PageSize="10" ShowFooter="True" ForeColor="white" GridLines="both" Visible="FALSE">
                        <Columns>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="InvoiceMstID"
                                DataField="InvoiceMstID" visible="false" />
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="InvoiceDtlID"
                                DataField="InvoiceDtlID" visible="false" />
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Voucher Date" DataField="VoucherDatee">
                                <headerstyle horizontalalign="center" width="4%" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Opening Amount" DataField="BalanceAmountDTL">
                                <headerstyle horizontalalign="center" width="4%" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Ajusted Amount" DataField="TotalAmount">
                                <headerstyle horizontalalign="center" width="5%" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Balance Amount" DataField="BalanceAmountDTL">
                                <headerstyle horizontalalign="center" width="6%" />
                            </asp:BOUNDCOLUMN>
                            <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" visible="true" HeaderStyle-Width="02%"
                                HeaderText="Payment Type">
                                <itemtemplate>																	
						<asp:textbox id="txtBalanaceAmountDTL"  runat="server" width="120px" style="text-transform:uppercase;"></asp:textbox>
						</itemtemplate>
                            </asp:TEMPLATECOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Payment Vocuher Ref No"
                                DataField="VoucherNo">
                                <headerstyle horizontalalign="center" width="6%" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" visible="false" HeaderText="PaymentType"
                                DataField="PaymentType">
                                <headerstyle horizontalalign="center" width="6%" />
                            </asp:BOUNDCOLUMN>
                            <%--     <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" visible="true" HeaderStyle-Width="02%" HeaderText="Adjust Invoice">
                            <itemtemplate>																	
						<asp:ImageButton id="lnkAfterAdjustForUpdate" tooltip="Click here to edit"  ImageUrl="~/Images/editIcon.jpg" CommandName="Adjust" runat="server"></asp:ImageButton>
						</itemtemplate>
                        </asp:TEMPLATECOLUMN>
                      <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="REMOVE"  visible="FALSE">
                            <itemtemplate>									 								
										<asp:ImageButton id="lnkRemoveInvoice" tooltip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png" CommandName="Remove" runat="server"></asp:ImageButton>
									</itemtemplate>
                        </asp:TEMPLATECOLUMN>
                        </Columns>
                    </Smart:SmartDataGrid>
                </td>
            </tr>
            <asp:Panel ID="AdjustDataUpdate" runat="server">
                <table width="100%">
                    <tr style="height: 35px;">
                        <td style="width: 100px;">
                            Voucher Date :
                        </td>
                        <td style="width: 300px;">
                            <asp:Label ID="LblVoucherDate" ReadOnly="true" CssClass="textbox" runat="server"
                                Width="150px"></asp:Label></td>
                        <td style="width: 100px;">
                            Opening Balance :
                        </td>
                        <td>
                            <asp:Label ID="lblBalance" ReadOnly="true" CssClass="textbox" runat="server" Width="150px"></asp:Label>
                        </td>
                    </tr>
                    <tr style="height: 35px;">
                        <td style="width: 100px;">
                            Payment :
                        </td>
                        <td style="width: 300px;">
                            <asp:Label ID="LblAMOUNT" ReadOnly="true" CssClass="textbox" runat="server" Width="150px"></asp:Label></td>
                        <td style="width: 121px;">
                            Adjusted Amount :
                        </td>
                        <td>
                            <asp:Label ID="lblAdjustedAmount" ReadOnly="true" CssClass="textbox" runat="server"
                                Width="150px"></asp:Label>
                        </td>
                    </tr>
                    <tr style="height: 35px;">
                        <td style="width: 100px;">
                        Payment Type :
                        </td>
                        <td style="width: 300px;">
                        <asp:TextBox ID="txtPaymentType" runat ="server" Width ="150px"></asp:TextBox>
                        </td>
                         <td style="width: 147px;">
                           Payment Ref. Voucher :
                        </td>
                        <td>
                            <asp:Label ID="lblRefVoucher" ReadOnly="true" CssClass="textbox" runat="server"
                                Width="150px"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <tr>
                <td>
                  <asp:Label ID="LblInvoiceMstId" ReadOnly="true" CssClass="textbox" runat="server"
                                Width="150px"  Visible ="false" ></asp:Label>
                    <asp:Button ID="btnUpadateInv" runat="server" Text="Update" Visible="false" Width="100"
                        CssClass="button" align="right" />
                    <asp:Button ID="BtnCanelInv" runat="server" Text="Cancel" Width="100" Visible="false"
                        CssClass="button" align="right" />
                </td>
            </tr>
        </table>--%>
    </asp:Panel>
</asp:Content>
