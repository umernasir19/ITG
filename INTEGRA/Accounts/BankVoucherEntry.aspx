<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="BankVoucherEntry.aspx.vb" Inherits="Integra.BankVoucherEntry"  Title="Bank Voucher Page" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        function allowNegativeNumber(e) {
            var charCode = (e.which) ? e.which : event.keyCode
            if (charCode > 31 && (charCode < 45 || charCode > 57)) {
                return false;
            }
            return true;

        }

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

    <asp:Panel ID="PnlBankVoucher" runat="server">
        <table width="100%" id="TABLE1">
            <tr style="font-style: italic; font-size: 25px; color: Blue; height: 30px; vertical-align: middle;">
                <td colspan="3">
                    <u>
                        <asp:Label ID="lblbnk" runat="server" Text=""></asp:Label>
                        <asp:Label runat="server" ID="lblBankH" Text=""></asp:Label></u></td>
            </tr>
            <tr style="height: 35px;">
                <td style="width: 100px;">
                    Voucher No
                </td>
                <td style="width: 300px;">
                <asp:UpdatePanel ID="udptxtVoucherNo" runat="server" ChildrenAsTriggers="true">
                        <contenttemplate>
                    <asp:TextBox ID="txtVoucherNo" ReadOnly="true" CssClass="textbox" runat="server"
                        Width="150px" Visible="true"></asp:TextBox>
                        </contenttemplate> 
                        </asp:UpdatePanel> 
                    <asp:TextBox ID="txtVno" ReadOnly="false" CssClass="textbox" runat="server" Width="150px"
                        Visible="false"></asp:TextBox></td>
                <td style="width: 100px;">
                    Voucher Date
                </td>
                <td> <asp:UpdatePanel ID="udptxtVoucherdate" runat="server" ChildrenAsTriggers="true">
                        <contenttemplate>
                    <asp:TextBox ID="txtVoucherdate" CssClass="textbox" Width="120" runat="server" ReadOnly="false"
                        AutoPostBack="true" Style="text-transform: uppercase;"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtVoucherdate"
                        PopupButtonID="ImageButton1" Enabled="true" />
                    <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" ImageUrl="~/Images/callendar.JPG"
                        AlternateText="Click here to display calendar" Visible="true" />
                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtVoucherdate"
                        Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                        CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                        Enabled="true" UserDateFormat="DayMonthYear" AutoComplete="False">
                    </cc1:MaskedEditExtender>
                    </contenttemplate> 
                    </asp:UpdatePanel> 
                </td>
            </tr>
            <%--  <tr style="height: 35px;">
                <td style="width: 100px;">
                    V No.
                </td>
                <td style="width: 300px;">
                    </td>
            </tr>--%>
            <asp:Panel ID="pnlbookaccountMst" runat="server" Visible="false">
                <tr style="height: 35px;">
                    <td style="width: 100px;">
                        Book Account
                    </td>
                    <td style="width: 300px;" colspan="3">
                        <asp:DropDownList ID="cmbBookAccount" Width="550" CssClass="combo" AutoPostBack="false"
                            runat="server">
                        </asp:DropDownList></td>
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
                        <asp:UpdatePanel id="btnSearchUPdatebookaccount" UpdateMode="Conditional" runat="server">
                            <contenttemplate>
</contenttemplate>
                            <triggers>
<asp:AsyncPostBackTrigger ControlID="txtBookAccountName" EventName="TextChanged"></asp:AsyncPostBackTrigger>
</triggers>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="udpBookAccount" runat="server">
                            <contenttemplate>
                <asp:TextBox ID="txtBookAccountCode" Enabled="false"  CssClass="textbox" Width="100" runat="server"></asp:TextBox>
                    </contenttemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="udpGrid3" runat="server">
                            <contenttemplate>
                <asp:TextBox ID="txtBookAccountLevel"  Enabled="false" CssClass="textbox" Width="130" runat="server"></asp:TextBox>
                    </contenttemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </asp:Panel>
            <tr style="height: 35px;">
                <td style="width: 100px;">
                    Description
                </td>
                <td style="width: 300px;" colspan="3">
                    <asp:UpdatePanel ID="udptxtdescription" runat="server" ChildrenAsTriggers="true">
                        <contenttemplate>
                    <asp:TextBox ID="txtdescription" AutoPostBack="true" CssClass="textbox" runat="server"
                        Width="550px">  </asp:TextBox>
                        </contenttemplate>
                        <%-- <triggers>
    <asp:AsyncPostBackTrigger ControlID="txtDescriptionDetail"  EventName="SelectedIndexChanged" />
        </triggers>--%>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr style="height: 35px;">
                <td style="width: 100px;">
                    Voucher Type
                </td>
                <td style="width: 300px;">
                 <asp:UpdatePanel ID="udpcmbVoucherType" runat="server">
                            <contenttemplate>
                    <asp:DropDownList ID="cmbVoucherType" Width="150" CssClass="combo" AutoPostBack="true"
                        runat="server">
                        <%-- <asp:ListItem Value="0" Text="Select Type"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Receipt Voucher"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Payment Voucher"></asp:ListItem>
                         <asp:ListItem Value="3" Text="Contra Voucher"></asp:ListItem>--%>
                    </asp:DropDownList>
                      </contenttemplate>
                              </asp:UpdatePanel>
                </td>
            </tr>


            <tr style="height: 35px;">
                <td style="width: 100px;">
                    Cash Type
                </td>
                <td style="width: 300px;">
                 <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true">
                        <contenttemplate>
                    <asp:DropDownList ID="cmbpaytype" Width="150" CssClass="combo" AutoPostBack="false"
                        runat="server">
                    </asp:DropDownList>
                    </contenttemplate>
                    </asp:UpdatePanel>
                    </td>
                <td>
                   <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="true">
                        <contenttemplate>
                    <asp:Label ID="Label2" Visible="false" runat="server"></asp:Label></contenttemplate>
                    </asp:UpdatePanel>
                    Presented
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" ChildrenAsTriggers="true">
                        <contenttemplate>
<asp:DropDownList id="cmbpresented" runat="server" Width="150" AutoPostBack="true" CssClass="combo" OnSelectedIndexChanged="cmbPaymentTerms_SelectedIndexChanged">
                            </asp:DropDownList> 
</contenttemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>

            <tr style="font-style: italic; font-size: 25px; color: Blue; height: 30px; vertical-align: middle;">
                <td>
                    <u>Detail</u></td>
            </tr>
            <tr style="height: 35px;">
                <td style="width: 100px;">
                    Cheque No
                </td>
                <td style="width: 300px;">
                <asp:UpdatePanel ID="udptxtchequeNo" runat="server">
                            <contenttemplate>
<asp:TextBox id="txtchequeNo" runat="server" Width="150px" CssClass="textbox" OnTextChanged="txtchequeNo_TextChanged1" autopostback="true"></asp:TextBox> 
</contenttemplate>
                              </asp:UpdatePanel>
                    </td>
                <td style="width: 100px;">
                    Cheque Date
                </td>
                <td>
                  <asp:UpdatePanel ID="udptxtchequedate" runat="server">
                            <contenttemplate>
                    <asp:TextBox ID="txtchequedate" CssClass="textbox" Width="120" runat="server" AutoPostBack="false"
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
                     </contenttemplate>
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
            <asp:Panel ID="pnlAccountCodedtlSearchAuto" runat="server" Visible="false">
                <tr style="height: 35px;">
                    <td style="width: 100px;">
                        Account Code
                    </td>
                    <td style="width: 300px;">
                    <asp:UpdatePanel ID="udptxtAccountName" runat="server">
                            <contenttemplate>
                        <asp:TextBox ID="txtAccountName" CssClass="textbox" runat="server" AutoPostBack="true"
                            autocomplete="off" Width="278px" ToolTip="Voucher No"> </asp:TextBox>
                        <cc1:AutoCompleteExtender runat="server" ID="autoComplete1" TargetControlID="txtAccountName"
                            ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                            CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="AccountName" />
                             </contenttemplate>
                              </asp:UpdatePanel>
                        <%--<asp:UpdatePanel id="btnSearchUPdate" UpdateMode="Conditional" runat="server">
                            <contenttemplate>
</contenttemplate>
                             <triggers>
<asp:AsyncPostBackTrigger ControlID="txtAccountName" EventName="TextChanged"></asp:AsyncPostBackTrigger>
 <asp:AsyncPostBackTrigger ControlID="cmbInvoiceNo" EventName="TextChanged"></asp:AsyncPostBackTrigger>
</triggers> 
                        </asp:UpdatePanel>--%>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="udpGrid" runat="server">
                            <contenttemplate>
                <asp:TextBox ID="txtAccountCode"  Enabled="false" CssClass="textbox" Width="100" runat="server" ></asp:TextBox>
                
                    </contenttemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="udpGrid1" runat="server">
                            <contenttemplate>
                <asp:TextBox ID="txtAccountLevel"  Enabled="false" CssClass="textbox" Width="130" runat="server"></asp:TextBox>
                    </contenttemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </asp:Panel>
            <tr style="height: 35px;">
                <td style="width: 100px;">
                    Description
                </td>
                <td style="width: 300px;" colspan="3">
                    <asp:UpdatePanel ID="udptxtDescriptionDetail" runat="server" ChildrenAsTriggers="true">
                        <contenttemplate>
                    <asp:TextBox ID="txtDescriptionDetail" CssClass="textbox" Width="550" runat="server"></asp:TextBox>
                     </contenttemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr style="height: 35px;">
                <td style="width: 100px;">
                    Type
                </td>
                <td style="width: 300px;">
                 <asp:UpdatePanel ID="udcmbType" runat="server" ChildrenAsTriggers="true">
                        <contenttemplate>
                    <asp:DropDownList ID="cmbType" Width="150" CssClass="combo" AutoPostBack="false"
                        runat="server">
                        <asp:ListItem Value="0" Text="D"></asp:ListItem>
                        <asp:ListItem Value="1" Text="C"></asp:ListItem>
                    </asp:DropDownList>
                    </contenttemplate>
                    </asp:UpdatePanel>
                    </td>
                <td>
                   <asp:UpdatePanel ID="udplbldetail" runat="server" ChildrenAsTriggers="true">
                        <contenttemplate>
                    <asp:Label ID="lbldetail" Visible="false" runat="server"></asp:Label></contenttemplate>
                    </asp:UpdatePanel>
                    Payment Terms
                </td>
                <td>
                    <asp:UpdatePanel ID="udpcmbPaymentTerms" runat="server" ChildrenAsTriggers="true">
                        <contenttemplate>
<asp:DropDownList id="cmbPaymentTerms" runat="server" Width="150" AutoPostBack="true" CssClass="combo" OnSelectedIndexChanged="cmbPaymentTerms_SelectedIndexChanged">
                            </asp:DropDownList> 
</contenttemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>




            






            <tr style="height: 35px;">
                <td style="width: 100px;">
                    <asp:UpdatePanel ID="udplblNetAmount" runat="server" ChildrenAsTriggers="true">
                        <contenttemplate>
                    <asp:Label ID="lblNetAmount" runat="server" Text=" Net Amount" Visible="false"></asp:Label>
                     </contenttemplate>
                    </asp:UpdatePanel>
                </td>
                <td style="width: 300px;">
                    <asp:UpdatePanel ID="udptxtPaymentAmount" runat="server" ChildrenAsTriggers="true">
                        <contenttemplate>
                    <asp:TextBox ID="txtPaymentAmount" CssClass="textbox" onkeypress="return allowNegativeNumber(event);"  Width="120" runat="server" Visible="false"></asp:TextBox>
                     </contenttemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:UpdatePanel ID="udplblRefNo" runat="server" ChildrenAsTriggers="true">
                        <contenttemplate>
                    <asp:Label ID="lblRefNo" runat="server" Text="Ref No." Visible="false"></asp:Label>
                     </contenttemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:UpdatePanel ID="udptxtRefNo" runat="server" ChildrenAsTriggers="true">
                        <contenttemplate>
                    <asp:TextBox ID="txtRefNo" CssClass="textbox" Width="120" runat="server" Visible="false"></asp:TextBox>
                     </contenttemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr style="height: 35px;">
                <td style="width: 100px;">
                    Currency
                </td>
                <td style="width: 300px;">
                <asp:UpdatePanel ID="udpcmbCurrency" runat="server">
                        <contenttemplate>
                    <asp:DropDownList ID="cmbCurrency" Width="150" CssClass="combo" AutoPostBack="false"
                        runat="server">
                    </asp:DropDownList>
                    </contenttemplate>
                    </asp:UpdatePanel>
                    </td>
                <td>
                    <asp:Label ID="Label1" Visible="false" runat="server"></asp:Label>
                    Exchange Rate
                </td>
                <td>
                    <asp:UpdatePanel ID="udpExchangeRate" runat="server" ChildrenAsTriggers="true">
                        <contenttemplate>
   <asp:TextBox ID="txtxchangeRate"  Enabled="true" CssClass="textbox" text="1" onkeypress="return isNumericKeyy(event);" Width="130" runat="server"></asp:TextBox>
</contenttemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="udpdgs" runat="server" ChildrenAsTriggers="true">
            <contenttemplate>
        <table width="100%">
            <tr>
                <td>
                    <Smart:SmartDataGrid ID="dgInvoice" runat="server" Width="100%" AllowPaging="false"
                        AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                        PageSize="15" ShowFooter="True" ForeColor="white" GridLines="both">
                        <Columns>
                            <asp:BOUNDCOLUMN HeaderText="POInvoiceMstID" DataField="POInvoiceMstID" visible="False">
                                <headerstyle width="5%" />
                                <itemstyle horizontalalign="Left" />
                            </asp:BOUNDCOLUMN>
                            <%--<asp:BOUNDCOLUMN HeaderText="POInvoiceAdjDetailID" DataField="POInvoiceAdjDetailID"
                                visible="False">
                                <headerstyle width="5%" />
                                <itemstyle horizontalalign="Left" />
                            </asp:BOUNDCOLUMN>--%>
                            <asp:BOUNDCOLUMN HeaderText="S.Tax Inv No" DataField="SaleTaxInvoiceNo">
                                <headerstyle width="6%" horizontalalign="Center" />
                                <itemstyle horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN HeaderText="Payable Party" DataField="SupplierName">
                                <headerstyle width="15%" horizontalalign="Center" />
                                <itemstyle horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN HeaderText="Inv. Amount" DataField="InvoiceNetAmount">
                                <headerstyle width="8%" horizontalalign="Center" />
                                <itemstyle horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN HeaderText="Already Payment" DataField="PaymentAmount">
                                <headerstyle width="8%" horizontalalign="Center" />
                                <itemstyle horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:TemplateColumn HeaderText="S.Tax %" visible="False">
                                <itemtemplate>
<asp:textbox id="txtSTaxPercentage" runat="server" CssClass="textbox" readonly="false" width="40px" text="0" autopostback="true" OnTextChanged="txtSTaxPercentage_TextChanged"></asp:textbox> 
</itemtemplate>
                                <headerstyle width="4%" horizontalalign="Center"></headerstyle>
                                <itemstyle horizontalalign="Center"></itemstyle>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="S.T Amount" visible="False">
                                <itemtemplate>
                            <asp:textbox id="txtSTaxAmount"  readonly="true" runat="server" width="60px" CssClass="textbox"></asp:textbox>                             
</itemtemplate>
                                <headerstyle width="6%" horizontalalign="Center"></headerstyle>
                                <itemstyle horizontalalign="Center"></itemstyle>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="G.S.Tax.%" visible="False">
                                <itemtemplate>
<asp:textbox id="txtGSTaxPercentage" runat="server" CssClass="textbox" autopostback="true" text="0" width="40px" readonly="false" OnTextChanged="txtGSTaxPercentage_TextChanged"></asp:textbox> 
</itemtemplate>
                                <headerstyle width="6%" horizontalalign="Center"></headerstyle>
                                <itemstyle horizontalalign="Center"></itemstyle>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="G.S.Tax. Amount" visible="False">
                                <itemtemplate>
                            <asp:textbox id="txtGSTaxAmount"  readonly="true" runat="server" width="60px" CssClass="textbox"></asp:textbox>                             
                          
</itemtemplate>
                                <headerstyle width="6%" horizontalalign="Center"></headerstyle>
                                <itemstyle horizontalalign="Center"></itemstyle>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="WHTax %" visible="False">
                                <itemtemplate>
<asp:textbox id="txtWHTaxPercentage" runat="server" CssClass="textbox" autopostback="true"  text="0" width="40px" readonly="false" OnTextChanged="txtWHTaxPercentage_TextChanged"></asp:textbox> 
</itemtemplate>
                                <headerstyle width="6%" horizontalalign="Center"></headerstyle>
                                <itemstyle horizontalalign="Center"></itemstyle>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="WHTax Amount" visible="False">
                                <itemtemplate>
                            <asp:textbox id="txtWHTaxAmount"  readonly="true" runat="server" width="60px" CssClass="textbox"></asp:textbox>                             
                          
</itemtemplate>
                                <headerstyle width="6%" horizontalalign="Center"></headerstyle>
                                <itemstyle horizontalalign="Center"></itemstyle>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Paid Amount">
                                <itemtemplate>
                            <asp:textbox id="txtAmount" onkeypress="return isNumericKeyy(event);"   runat="server" width="100px" CssClass="textbox"></asp:textbox>                             
                          
</itemtemplate>
                                <headerstyle width="1%" horizontalalign="Center"></headerstyle>
                                <itemstyle horizontalalign="Center"></itemstyle>
                            </asp:TemplateColumn>
                            <asp:TEMPLATECOLUMN>
                                <itemtemplate>
									        <asp:checkbox id="ChkStatus"   runat="server" Style="width: 20px; " ></asp:checkbox>
							      
</itemtemplate>
                                <headerstyle width="2%" />
                                <itemstyle horizontalalign="Center" />
                            </asp:TEMPLATECOLUMN>
                            <asp:BOUNDCOLUMN HeaderText="Date" DataField="Creationdate" visible="False">
                                <headerstyle width="5%" />
                                <itemstyle horizontalalign="Left" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN HeaderText="SupplierdatabaseID" DataField="SupplierdatabaseID" visible="False">
                                <headerstyle width="5%" />
                                <itemstyle horizontalalign="Left" />
                            </asp:BOUNDCOLUMN>
                             
                            <%-- <asp:BOUNDCOLUMN HeaderText="PaymentType" DataField="PaymentType" visible="False">
                                <headerstyle width="5%" />
                                <itemstyle horizontalalign="Left" />
                            </asp:BOUNDCOLUMN>--%>
                             <asp:TEMPLATECOLUMN visible="true">
                                <itemtemplate>
									        <asp:label id="lblCheckdstatus"   runat="server" Style="width: 20px; " text="0" ></asp:label>
							      
</itemtemplate>
                                <headerstyle width="2%" />
                                <itemstyle horizontalalign="Center" />
                            </asp:TEMPLATECOLUMN>
                        </Columns>
                        <PagerStyle CssClass="GridPagerStyle" HorizontalAlign="Right" Mode="NumericPages" />
                        <AlternatingItemStyle CssClass="GridAlternativeRow" />
                        <ItemStyle CssClass="GridRow" />
                        <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                    </Smart:SmartDataGrid>
                </td>
            </tr>
            
        </table>
         
        
         <table width="100%">
        <tr style="height: 25px;">
                <td>
                    <asp:Button ID="btnAdd" Text="Add" runat="server" Width="100" CssClass="button" Visible="false"></asp:Button></td>
                <td>
                </td>
            </tr>
        </table>
              
        <table width="100%">
            <tr>
                <td>
                    <Smart:SmartDataGrid ID="dgView" runat="server" Width="100%" AllowPaging="false"
                        AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                        PageSize="15" ShowFooter="True" ForeColor="white" GridLines="both">
                        <Columns>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="tblBankDtlID"
                                DataField="tblBankDtlID" visible="False" />
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Cheque No"
                                DataField="ChequeNo">
                                <itemstyle horizontalalign="Center" />
                                <headerstyle width="7%" horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Date"
                                DataField="ChequeDate">
                                <itemstyle horizontalalign="Center" />
                                <headerstyle width="7%" horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="Account Code"
                                DataField="AccountCode">
                                <itemstyle horizontalalign="Center" />
                                <headerstyle width="10%" horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="Account Name"
                                DataField="AccountName">
                                <itemstyle horizontalalign="Center" />
                                <headerstyle width="15%" horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="Description Entry"
                                DataField="DescriptionEntry">
                                <itemstyle horizontalalign="Center" />
                                <headerstyle width="15%" horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="Type "
                                DataField="Type">
                                <itemstyle horizontalalign="Center" />
                                <headerstyle width="5%" horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="Inv. Amount"
                                DataField="InitialAmount">
                                <itemstyle horizontalalign="Center" />
                                <headerstyle width="7%" horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="W.H.Tax.%"
                                DataField="WHTaxAmount" visible="false">
                                <itemstyle horizontalalign="Center" />
                                <headerstyle width="7%" horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="G.S.Tax.%"
                                DataField="GSTaxAmount" visible="false">
                                <itemstyle horizontalalign="Center" />
                                <headerstyle width="7%" horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="Paid Amount"
                                DataField="Amount">
                                <itemstyle horizontalalign="Center" />
                                <headerstyle width="7%" horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="W.H.Tax.CR%"
                                DataField="WHTaxAmountCr" visible="false">
                                <itemstyle horizontalalign="Center" />
                                <headerstyle width="7%" horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="G.S.Tax.Cr%"
                                DataField="GSTaxAmountCr" visible="false">
                                <itemstyle horizontalalign="Center" />
                                <headerstyle width="7%" horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="W.H.Tax.DB%"
                                DataField="WHTaxAmountDB" visible="false">
                                <itemstyle horizontalalign="Center" />
                                <headerstyle width="7%" horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="G.S.Tax.DB%"
                                DataField="GSTaxAmountDB" visible="false">
                                <itemstyle horizontalalign="Center" />
                                <headerstyle width="7%" horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="WHTaxPercentage"
                                DataField="WHTaxPercentage" visible="false">
                                <itemstyle horizontalalign="Center" />
                                <headerstyle width="1%" horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="GSTaxPercentage"
                                DataField="GSTaxPercentage" visible="false">
                                <itemstyle horizontalalign="Center" />
                                <headerstyle width="1%" horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                             <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="Ref No"
                                DataField="RefNo">
                                <itemstyle horizontalalign="Center" />
                                <headerstyle width="7%" horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN HeaderText="PaymentTermID" DataField="PaymentTermID" visible="False">
                                <headerstyle width="5%" />
                                <itemstyle horizontalalign="Left" />
                            </asp:BOUNDCOLUMN>
                               <asp:BOUNDCOLUMN HeaderText="Exchange Rate" DataField="ExchangeRate" visible="true">
                                <headerstyle width="5%" />
                                <itemstyle horizontalalign="Left" />
                            </asp:BOUNDCOLUMN>
                              <asp:BOUNDCOLUMN HeaderText="CurrencyID" DataField="CurrencyID" visible="true">
                                <headerstyle width="5%" />
                                <itemstyle horizontalalign="Left" />
                            </asp:BOUNDCOLUMN>
                             <asp:BOUNDCOLUMN HeaderText="Currency" DataField="CurrencyName" visible="true">
                                <headerstyle width="5%" />
                                <itemstyle horizontalalign="Left" />
                            </asp:BOUNDCOLUMN>

                            <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="EDIT"
                                visible="true">
                                <itemtemplate>																	
										<asp:ImageButton id="lnkEdit" tooltip="Click here to edit"  ImageUrl="~/Images/editIcon.jpg" CommandName="Edit" runat="server"></asp:ImageButton>
									</itemtemplate>
                            </asp:TEMPLATECOLUMN>
                            <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="REMOVE"
                                visible="false">
                                <itemtemplate>									 								
										<asp:ImageButton id="lnkRemove" tooltip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png" CommandName="Remove" runat="server"></asp:ImageButton>
									</itemtemplate>
                            </asp:TEMPLATECOLUMN>
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
         </contenttemplate>
        </asp:UpdatePanel>
        <br />
    </asp:Panel>
    <asp:UpdatePanel ID="udpbtnsavesss" runat="server" ChildrenAsTriggers="true">
            <contenttemplate>
    <table>
        <tr>
            <td>
             
                <asp:Label ID="LblInvoiceMstId" ReadOnly="true" CssClass="textbox" runat="server"
                    Width="150px" Visible="false"></asp:Label>
      
                <asp:Button ID="btnUpadateInv" runat="server" Text="Save" Visible="false" Width="100"
                    CssClass="button"  align="right" />
         
                <asp:Button ID="BtnCanelInv" runat="server" Text="Cancel" Width="100" Visible="true"
                    CssClass="button" align="right" 
                    PostBackUrl="~/Accounts/BankVoucherView.aspx" />
                   
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
    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btnUpadateInv"
        OnClientCancel="cancelClick" DisplayModalPopupID="ModalPopupExtender2" />
    <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="btnUpadateInv"
        PopupControlID="PNLL" OkControlID="ButtonOkK" CancelControlID="ButtonCancell"
        BackgroundCssClass="modalBackground" />
    <asp:Panel ID="PNLL" runat="server" Style="display: none; height: 120px; width: 350px;
        background-color: White; top: 50px; border-width: 2px; border-color: Black; border-style: solid;
        padding: 20px;">
        <table>
            <tr>
                <td>
                    <asp:Image ID="Image2" runat="server" Height="70px" ImageUrl="~/Images/warning.ico" /></td>
                <td style="width: 5px;">
                </td>
                <td style="font-family: Tahoma; font-size: 11px; font-weight: bold;">
                    <asp:Label ID="lblUserr" CssClass="label" runat="server"></asp:Label>&nbsp; Are
                    you sure you want to Save Voucher.?</td>
            </tr>
        </table>
        <br />
        <div style="text-align: right;">
            <asp:ImageButton ID="ButtonOkK" CssClass="button" runat="server" Width="40" Height="40"
                ImageUrl="~/Images/OKNEW.png" />
            <asp:ImageButton ID="ButtonCancell" CssClass="button" runat="server" Width="40" Height="40"
                ImageUrl="~/Images/close.png" />
        </div>
    </asp:Panel>
     </contenttemplate>
        </asp:UpdatePanel>
</asp:Content>