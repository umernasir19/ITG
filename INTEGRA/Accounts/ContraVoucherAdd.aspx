     <%@ Page Title="Contra Voucher Add" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="ContraVoucherAdd.aspx.vb" Inherits="Integra.ContraVoucherAdd" %>

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
    <table width="100%" id="TABLE1">
        <tr style="font-style: italic; font-size: 25px; color: Blue; height: 30px; vertical-align: middle;">
            <td colspan="3">
                <u>Contra Voucher</u>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td style="width: 100px;">
                Contra Voucher No#
            </td>
            <td style="width: 300px;">
                <asp:TextBox ID="txtContraNo" ReadOnly="true" CssClass="textbox" runat="server" Width="150px"
                    Visible="true"></asp:TextBox>
            </td>
            <td style="width: 100px;">
                <asp:Label ID="lblHddate" runat="server" Text=" Voucher Date (dd/mm/yyyy)" Style="text-align: center;"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtVoucherdate2" CssClass="textbox" Width="75" runat="server" Visible="true"
                    AutoPostBack="true" Style="text-transform: uppercase;" ToolTip="dd/mm/yyyy" placeholder="dd/mm/yyyy"
                    autocomplete="off"></asp:TextBox>
                <asp:TextBox ID="txtContradate" CssClass="textbox" Width="120" runat="server" ReadOnly="false"
                    Visible="false" AutoPostBack="true" Style="text-transform: uppercase;"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtContradate"
                    PopupButtonID="ImageButton1" Enabled="true" />
                <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" ImageUrl="~/Images/callendar.JPG"
                    AlternateText="Click here to display calendar" Visible="false" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtContradate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="true" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>
            </td>
            <td>
                <asp:CheckBox runat="server" ID="chkshowCalander" AutoPostBack="true" />Show Calander
            </td>
        </tr>
        <tr>
            <td>
                Ref No
            </td>
            <td>
                <asp:TextBox ID="txtchkno" CssClass="textbox" runat="server" Width="150px" Visible="true"></asp:TextBox>
            </td>
        </tr>
        <%--  <tr style="height: 35px;">
                <td style="width: 100px;">
                    V No.
                </td>
                <td style="width: 300px;">
                    </td>
            </tr>--%>
        <tr style="height: 35px;">
            <td style="width: 100px;">
                Account
            </td>
            <td style="width: 300px;">
                <asp:DropDownList ID="cmbAccount" Width="351px" CssClass="combo" AutoPostBack="true"
                    runat="server">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label runat="server" ID="lbldrcrM" Style="font-weight: bold; background-color: darkgray;
                    font-size: 13px;" Text="Dr"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Curr Balane
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
        <tr style="font-style: italic; font-size: 25px; color: Blue; height: 30px; vertical-align: middle;">
            <td>
                <u>Detail</u>
            </td>
        </tr>
        <%--        <tr style="height: 35px;">
                <td style="width: 100px;">
                    Particulars
                </td>
                <td style="width: 300px;" colspan="3">
                 
                    <asp:TextBox ID="txtdescription" AutoPostBack="false" CssClass="textbox" runat="server"
                        Width="550px">  </asp:TextBox>
                            <cc1:AutoCompleteExtender runat="server" ID="autoComplete1" TargetControlID="txtdescription"
                            ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                            CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="AccountNameForContra" />

                </td>
            </tr>
        --%>
        <tr style="height: 35px;">
            <td style="width: 100px;">
                <%-- Account Name--%>
                Ledger
            </td>
            <td style="width: 300px;">
                <asp:TextBox ID="txtAccountName" CssClass="textbox" runat="server" AutoPostBack="true"
                    autocomplete="off" Width="350px" ToolTip="Voucher No"> </asp:TextBox>
                <cc1:AutoCompleteExtender runat="server" ID="autoComplete1" TargetControlID="txtAccountName"
                    ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                    CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="AccountNameForContra" />
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
                    font-size: 13px;" Text="Cr"></asp:Label>
            </td>
        </tr>
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
                <cc1:AutoCompleteExtender runat="server" ID="AutoCompleteExtender1" TargetControlID="txtCostCenter"
                    ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                    CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="CostCenter" />
                <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Label runat="server" ID="lblCostCenterId" Visible ="false" Text ="0"  Style="font-weight: bold; background-color: darkgray;
                            font-size: 13px;"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtCostCenter" EventName="TextChanged"></asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td style="width: 100px;">
                Amount
            </td>
            <td style="width: 300px;">
                <asp:TextBox ID="txtAmount" autocomplete="off" runat="server" onkeyup="FormatCurrency(this);"
                    CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td style="width: 100px;" valign="top">
                Narration
            </td>
            <td style="width: 300px;" colspan="4">
                <asp:TextBox ID="txtNarration" TextMode="MultiLine" runat="server" Style="text-transform: uppercase;"
                    Width="560px"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table>
        <tr style="height: 25px;">
            <td>
                <asp:Button ID="btnAdd" Text="Add" runat="server" Width="100" Style="margin-left: 480px;"
                    CssClass="button"></asp:Button><asp:Label ID="lbldetail" Visible="false" runat="server"></asp:Label>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td>
                <Smart:SmartDataGrid ID="dgView" runat="server" Width="100%" AllowPaging="false"
                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                    PageSize="15" ShowFooter="True" ForeColor="white" GridLines="both">
                    <Columns>
                        <asp:BoundColumn HeaderText="ContraVoucherDtlID" DataField="ContraVoucherDtlID" 
                        Visible="false">
                            <HeaderStyle Width="5%" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Particulars" DataField="Particulars">
                            <HeaderStyle Width="15%" HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Amount" DataField="Amount">
                            <HeaderStyle Width="6%" HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Narration" DataField="Narration">
                            <HeaderStyle Width="15%" HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="AccountCode" DataField="AccountCode" Visible="False">
                            <HeaderStyle Width="5%" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="DrCr" DataField="DrCr" Visible="False">
                            <HeaderStyle Width="5%" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Cost" DataField="Cost">
                            <HeaderStyle Width="6%" HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="CostCenterId" DataField="CostCenterId" Visible="False">
                            <HeaderStyle Width="5%" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="EDIT">
                            <ItemTemplate>
                                <asp:ImageButton ID="lnkEdit" ToolTip="Click here to edit" ImageUrl="~/Images/editIcon.jpg"
                                    CommandName="Edit" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                    <PagerStyle CssClass="GridPagerStyle" HorizontalAlign="Right" Mode="NumericPages" />
                    <AlternatingItemStyle CssClass="GridAlternativeRow" />
                    <ItemStyle CssClass="GridRow" />
                    <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                </Smart:SmartDataGrid>
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr style="height: 30px;">
            <td align="center">
                <asp:Button ID="btnCancel" CssClass="btn btn-outline btn-danger" runat="server" Text="Cancel"
                    Width="120px" Visible="true" />
                <asp:Button ID="btnSave" ToolTip="Click here To Save data." CssClass="btn btn-outline btn-success"
                    runat="server" Text="Save" Width="120px" Visible="true" />
            </td>
        </tr>
    </table>
</asp:Content>
