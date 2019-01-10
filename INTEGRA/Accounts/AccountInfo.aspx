<%@ Page Title="Account Info" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="AccountInfo.aspx.vb" Inherits="Integra.AccountInfo" %>
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


   
    <table>
    <tr>
            <td style="height: 13px">
                <asp:LinkButton ID="btnBackMainPage" runat="server">Back To Main Page</asp:LinkButton>
            </td>
        </tr>
    </table>
      <br />
    <table width="100%">
        <tr>
            <td style="height: 13px">
                <asp:LinkButton ID="LnkbView" runat="server">View</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style="height: 13px">
                <asp:LinkButton ID="LnkbPrint" runat="server">Print</asp:LinkButton>
            </td>
        </tr>
           <tr>
            <td style="height: 13px">
                <asp:LinkButton ID="lnkTreeView" runat="server">Tree View</asp:LinkButton>
            </td>
        </tr>
    </table>
   


    <br />
    <asp:Panel ID="PnlInfo" runat="server" Visible="true">
        <table width="100%">
            <tr>
                <td>
                    <asp:Button ID="btnGroup" runat="server" Style="float: left;" CssClass="btn btn-outline btn-success"
                        Text="Group" CausesValidation ="false"  />
                    <asp:Button ID="btnLedger" runat="server" Style="float: left;" CssClass="btn btn-outline btn-success"
                        Text="Ledger" CausesValidation ="false"  />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <asp:Panel ID="PanelViewCreateGroup" runat="server" Visible="false">
        <table width="100%">
            <tr>
                <td>
                    <asp:Button ID="btnGrouopView" runat="server" Style="float: left;" CssClass="btn btn-outline btn-success"
                        Text="Group View" />
                    <asp:Button ID="btnGrouopCreate" runat="server" Style="float: left;" CssClass="btn btn-outline btn-success"
                        Text="Group Create" />
                    <asp:Button ID="btnalterGroup" runat="server" Style="float: left;" CssClass="btn btn-outline btn-success"
                        Text="Group Alter" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="PanelViewCreateLedger" runat="server" Visible="false">
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnLedgerView" runat="server" Style="float: left;" CssClass="btn btn-outline btn-success"
                        Text="Ledger View" />
                    <asp:Button ID="btnLedgerCreate" runat="server" Style="float: left;" CssClass="btn btn-outline btn-success"
                        Text="Ledger Create" />
                    <asp:Button ID="btnalterLedger" runat="server" Style="float: left;" CssClass="btn btn-outline btn-success"
                        Text="Ledger Alter" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="PanelLedgerCreate" runat="server" Visible="false">
        <table>
            <br />
            <tr>
                <div class="heading">
                    <asp:Label ID="lblHeading" runat="server"></asp:Label></div>
            </tr>
            <br />
            <tr>
                <td>
                    <div style="margin-left: 38px" class="txt">
                        Account Name
                    </div>
                </td>
                <td>
                    <div style="width: 120px" class="text_box">
                        <asp:TextBox Style="width: 120px; margin-left: 13px" ID="txtAccountName" runat="server"></asp:TextBox>
                    </div>
                </td>
                <td>
                    <div style="margin-left: 24px" class="txt">
                        Group Name
                    </div>
                </td>
                <td>
                    <div style="width: 120px" class="text_box">
                        <asp:TextBox ID="txtAllGrouppAuto" runat="server" CssClass="textbox" AutoPostBack="true"
                            autocomplete="off" Style="width: 300px; margin-left: 20px;" ToolTip="Group Info.."> </asp:TextBox>
                        <cc1:AutoCompleteExtender runat="server" ID="AutoCompleteExtender1" TargetControlID="txtAllGrouppAuto"
                            ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                            CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="ShowInfoDataonEntry" />
                    </div>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="PnlFalseInfo" runat="server" Visible="false">
        <table>
            <tr style="height: 35px;">
                <td style="height: 37px">
                    <div style="margin-left: 38px" class="txt">
                        Account Code</div>
                </td>
                <td style="height: 37px">
                    <div style="width: 120px" class="text_box">
                        <asp:TextBox Style="width: 120px; margin-left: 15px" ID="txtAccountCode" runat="server"></asp:TextBox>
                    </div>
                </td>
                <td style="height: 37px">
                    <div class="icon" align="center">
                    </div>
                </td>
                <td style="height: 37px">
                    <div class="txt" style="width: 100px;">
                        Group Act</div>
                </td>
                <td style="height: 37px">
                    <div style="width: 120px" class="text_box">
                        <asp:TextBox Style="width: 120px; margin-left: 15px" ID="txtGroupAct" runat="server"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr style="height: 35px;">
                <td>
                    <div style="margin-left: 38px" class="txt">
                        Account Nature
                    </div>
                </td>
                <td>
                    <div style="width: 120px" class="text_box">
                        <asp:TextBox ID="txtAccountNature" Style="width: 120px; margin-left: 15px;" runat="server"></asp:TextBox>
                    </div>
                </td>
                <td>
                    <div class="icon" align="center">
                    </div>
                </td>
                <td>
                    <div class="txt" style="width: 100px;">
                        Account type</div>
                </td>
                <td>
                    <div style="width: 120px" class="text_box">
                        <asp:TextBox Style="width: 120px; margin-left: 15px" ID="txtAccountType" runat="server"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr style="height: 35px;">
                <td colspan="2">
                    <div class="txt" style="width: 228px; margin-left: 38px;">
                        Account Level Digits</div>
                </td>
                <td>
                </td>
                <td>
                    <div style="width: 120px" class="text_box">
                        <asp:TextBox ID="txtAccountLevelDigits" Style="width: 60px; margin-left: 10px; text-align: center;"
                            runat="server"></asp:TextBox>
                    </div>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="PnlOptionalOnSelection" runat="server" Visible="false">
        <table>
            <tr>
                <td>
                    <div class="txt" style="width: 108px; margin-left: 39px;">
                        Account Level
                    </div>
                </td>
                <td>
                    <div style="width: 120px" class="text_box">
                        <asp:DropDownList ID="cmbAccountLevel" Enabled="false" Style="width: 121px; margin-left: 15px"
                            CssClass="combo" AutoPostBack="true" runat="server">
                        </asp:DropDownList>
                    </div>
                </td>
            </tr>
            <tr style="height: 35px;">
                <td>
                    <div style="margin-left: 38px" class="txt">
                        NTN No</div>
                </td>
                <td>
                    <div style="width: 120px" class="text_box">
                        <asp:TextBox Style="width: 120px; margin-left: 15px" ID="txtntnno" runat="server"></asp:TextBox>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender" runat="server" TargetControlID="txtntnno"
                            Mask="9999999-9" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                            OnInvalidCssClass="MaskedEditError" MaskType="Number" ClearMaskOnLostFocus="false"
                            ErrorTooltipEnabled="True" />
                        <asp:RegularExpressionValidator ID="REQFVtxtntnno" runat="server" ErrorMessage="not validate."
                            ControlToValidate="txtntnno" ValidationExpression="^\d{7}-\d{1}$" />
                    </div>
                </td>
                <td>
                    <div class="icon" align="center">
                    </div>
                </td>
                <td>
                    <div class="txt" style="width: 100px;    margin-left: 27px;">
                        GST No</div>
                </td>
                <td>
                    <div style="width: 120px" class="text_box">
                        <asp:TextBox Style="width: 120px; margin-left: 15px" ID="txtGstNo" runat="server"></asp:TextBox>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtGstNo"
                            Mask="99-99-9999-999-99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                            OnInvalidCssClass="MaskedEditError" MaskType="Number" ClearMaskOnLostFocus="false"
                            ErrorTooltipEnabled="True" />
                        <asp:RegularExpressionValidator ID="REQFVtxtGstNo" runat="server" ErrorMessage="not validate."
                            ControlToValidate="txtGstNo" ValidationExpression="^\d{2}-\d{2}-\d{4}-\d{3}-\d{2}$" />
                    </div>
                </td>
            </tr>
            <tr style="height: 35px;">
                <td>
                    <div style="margin-left: 38px" class="txt">
                        Opening CR</div>
                </td>
                <td>
                    <div style="width: 120px" class="text_box">
                        <asp:TextBox Style="width: 120px; margin-left: 15px" onkeypress="return isNumericKeyy(event);"
                            ID="txtOpeningCR" runat="server"></asp:TextBox>
                    </div>
                </td>
                <td>
                    <div class="icon" align="center">
                    </div>
                </td>
                <td>
                    <div class="txt" style="width: 100px;    margin-left: 27px;">
                        Opening DB</div>
                </td>
                <td>
                    <div style="width: 120px" class="text_box">
                        <asp:TextBox Style="width: 120px; margin-left: 15px" onkeypress="return isNumericKeyy(event);"
                            ID="txtOpeningDB" runat="server"></asp:TextBox>
                    </div>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <%--<div class="txt" style="width: 186px; margin-left: 39px; font-size: 20px; font-weight: bold;
                                                            font-style: normal; color: red; font-family: initial;">
                                                            IS SUPPLIER</div>--%>
                </td>
                <td>
                    <div style="margin-left: 10px;">
                        <%-- <asp:CheckBox ID="ChkForSupplier" style="width:100px; height:100px;"  runat="server" />--%>
                        <asp:CheckBox ID="ChkForSupplier" CssClass="largerCheckbox" runat="server" AutoPostBack="true"
                            Visible="false" />
                    </div>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="PanelExtraForRevenewandExpence" runat="server" Visible="false">
        <table>
            <tr style="height: 35px;">
                <td>
                    <div style="margin-left: 38px; width: 243px;" class="txt">
                        Currency of Ledger
                    </div>
                </td>
                <td colspan="2">
                    <div style="width: 120px" class="text_box">
                        <asp:TextBox Style="width: 100px; margin-left: 15px" onkeypress="return isNumericKeyy(event);"
                            ID="txtCurrencyofledger" runat="server"></asp:TextBox>
                    </div>
                    <asp:Label ID="lblRS" runat="server" Text="RS" Style="font-size: 18px;"></asp:Label>
                </td>
            </tr>
            <tr style="height: 35px;">
                <td>
                    <div style="margin-left: 38px; width: 243px;" class="txt">
                        Maintain balance bill-by-bill</div>
                </td>
                <td colspan="2">
                    <div style="width: 120px; margin-left: 61px;">
                        <asp:RadioButtonList ID="rbtMaintainbalancebillbybill" CssClass="scaledRadioButtons"
                            RepeatDirection="Horizontal" runat="server">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem Selected="True">No</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </td>
            </tr>
            <tr style="height: 35px;">
                <td>
                    <div style="margin-left: 38px; width: 243px;" class="txt">
                        Inventory values are affected</div>
                </td>
                <td colspan="2">
                    <div style="width: 120px; margin-left: 61px;">
                        <asp:RadioButtonList ID="rbtInventoryvaluesareaffected" CssClass="scaledRadioButtons"
                            RepeatDirection="Horizontal" runat="server">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem Selected="True">No</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </td>
            </tr>
            <tr style="height: 35px;">
                <td>
                    <div style="margin-left: 38px; width: 243px;" class="txt">
                        Cost Centres are applicable</div>
                </td>
                <td colspan="2">
                    <div style="width: 120px; margin-left: 61px;">
                        <asp:RadioButtonList ID="rblCostCentresareapplicable" CssClass="scaledRadioButtons"
                            RepeatDirection="Horizontal" runat="server">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem Selected="True">No</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </td>
            </tr>
            <tr style="height: 35px;">
                <td>
                    <div style="margin-left: 38px; width: 243px;" class="txt">
                        Alow Cost allocation (StockItem)</div>
                </td>
                <td colspan="2">
                    <div style="width: 120px; margin-left: 61px;">
                        <asp:RadioButtonList ID="rblAlowCostallocationStockItem" CssClass="scaledRadioButtons"
                            runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem Selected="True">No</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </td>
            </tr>
            <tr style="height: 35px;">
                <td>
                    <div style="margin-left: 38px; width: 243px;" class="txt">
                        Activate Interest Calculation</div>
                </td>
                <td colspan="2">
                    <div style="width: 120px; margin-left: 61px;">
                        <asp:RadioButtonList ID="rblActivateInterestCalculation" CssClass="scaledRadioButtons"
                            runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem Selected="True">No</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <asp:Panel ID="PnlSupplierCategory" runat="server" Visible="false">
        <table>
            <tr>
                <td>
                    <div style="margin-left: 38px; width: 140px;" class="txt">
                        Supplier Category</div>
                </td>
                <td>
                    <div style="width: 120px" class="text_box">
                        <asp:DropDownList ID="cmbSupplierCategory" Font-Size="14px" CssClass="combo" AutoPostBack="true"
                            runat="server" Width="120px" Height="23px" BackColor="#f5f6f5">
                        </asp:DropDownList>
                    </div>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="PnlSupplier" runat="server" Visible="false">
        <table>
            <tr style="height: 35px;">
                <td>
                    <div style="margin-left: 38px; width: 114px;" class="txt">
                        Is Cost affected</div>
                </td>
                <td colspan="2">
                    <div style="width: 120px; margin-left: 61px;">
                        <asp:RadioButtonList ID="RdbIsCostAffected" CssClass="scaledRadioButtons" Style="margin-left: -28px;"
                            RepeatDirection="Horizontal" runat="server">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem Selected="True">No</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="margin-left: 38px; width: 114px;" class="txt">
                        Address</div>
                </td>
                <td>
                    <div style="width: 120px" class="text_box">
                        <asp:TextBox ID="txtAddress" Style="margin-left: 15px;" runat="server" Width="363px">  </asp:TextBox></div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="margin-left: 38px; width: 114px;" class="txt">
                        Phone
                    </div>
                </td>
                <td>
                    <div style="width: 120px" class="text_box">
                        <asp:TextBox ID="txtPhone" Style="margin-left: 15px; width: 120px;" runat="server"></asp:TextBox></div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="margin-left: 38px; width: 114px;" class="txt">
                        Fax</div>
                </td>
                <td>
                    <div style="width: 120px" class="text_box">
                        <asp:TextBox ID="txtFax" Style="margin-left: 15px; width: 120px;" runat="server"></asp:TextBox></div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="margin-left: 38px; width: 114px;" class="txt">
                        Email Address
                    </div>
                </td>
                <td>
                    <div style="width: 120px" class="text_box">
                        <asp:TextBox ID="txtEmailAddress" Text="abc@abc.com" Style="margin-left: 15px; width: 120px;"
                            runat="server">                  
                        </asp:TextBox>&nbsp;
                        <asp:RegularExpressionValidator ID="REVEmail" runat="server" CssClass="ErrorMsg"
                            ErrorMessage="Not Valid" ControlToValidate="txtEmailAddress" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="margin-left: 38px; width: 114px;" class="txt">
                        Contact Person
                    </div>
                </td>
                <td>
                    <div style="width: 120px" class="text_box">
                        <asp:TextBox ID="txtContactPerson" Style="margin-left: 15px; width: 120px;" runat="server"></asp:TextBox></div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="margin-left: 38px; width: 114px;" class="txt">
                        Cell No.</div>
                </td>
                <td>
                    <div style="width: 120px" class="text_box">
                        <asp:TextBox ID="txtCellNo" Style="margin-left: 15px; width: 120px;" runat="server"></asp:TextBox></div>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="PanelSaveButton" runat="server" Visible="false">
        <table>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnSave" ToolTip="Click here To Save data." CssClass="btn btn-outline btn-success"
                        runat="server" Text="Save" Width="120px" Style="margin-left: 408px;" CausesValidation="false" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="PnlGropLedgerView" runat="server" Visible="false">
        <table width="100%">
            <br />
            <tr>
                <div class="heading">
                    <asp:Label ID="lblHeadingMain2" runat="server"></asp:Label></div>
            </tr>
            <br />
            <tr style="height: 34px;">
                <td>
                    Search:</td>
                <td>
                    <asp:TextBox ID="txtShowMe" runat="server" CssClass="textbox" AutoPostBack="true"
                        autocomplete="off" Width="270px" ToolTip="Chart Of Account Info.."> </asp:TextBox>
                    <cc1:AutoCompleteExtender runat="server" ID="autoComplete1" TargetControlID="txtShowMe"
                        ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                        CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="ShoInfoData" />
                </td>
                <td style="width: 54%">
                </td>
            </tr>
            <br />
            <tr>
                <td colspan="4">
                    <Smart:SmartDataGrid ID="dgView" runat="server" Width="100%" OnSortCommand="SortByColumn"
                        OnPageIndexChanged="PageChanged" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                        CellPadding="4" CssClass="table" PageSize="1000" ShowFooter="True" ForeColor="white"
                        GridLines="both">
                        <Columns>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="AccountCode" DataField="AccountCode" SortExpression="AccountCode">
                                <headerstyle horizontalalign="center" width="1%" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Account Name" DataField="AccountName"
                                visible="False" SortExpression="AccountName">
                                <headerstyle horizontalalign="center" width="1%" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Opening Debit" visible="false"
                                DataField="Opening_Debit">
                                <headerstyle horizontalalign="center" width="1%" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Opening Credit" visible="false"
                                DataField="Opening_Credit">
                                <headerstyle horizontalalign="center" width="1%" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="ID"
                                DataField="ChartOfAccountID" visible="false" />
                            <asp:TemplateColumn HeaderText="Account Name" SortExpression="AccountName">
                                <itemtemplate>
 <asp:textbox ID="txtAccountNamee" Cssclass="textbox"   width="270px"  Font-Size="8pt"   runat="server" >
 </asp:textbox>
 
</itemtemplate>
                                <headerstyle width="6%" horizontalalign="Center"></headerstyle>
                                <itemstyle horizontalalign="Center"></itemstyle>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="DR">
                                <itemtemplate>
<asp:textbox id="txtOpening_Debit" runat="server"   onkeypress="return isNumericKeyy(event);"  Font-Size="8pt" tabindex="2" width="80" Cssclass="textbox"  >
 </asp:textbox> 
</itemtemplate>
                                <headerstyle width="6%" horizontalalign="Center"></headerstyle>
                                <itemstyle horizontalalign="Left"></itemstyle>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="CR">
                                <itemtemplate>
<asp:textbox id="txtOpening_Credit" runat="server"   onkeypress="return isNumericKeyy(event);" Font-Size="8pt" tabindex="2" width="80" Cssclass="textbox"  ></asp:textbox> 
</itemtemplate>
                                <headerstyle width="6%" horizontalalign="Center"></headerstyle>
                                <itemstyle horizontalalign="Left"></itemstyle>
                            </asp:TemplateColumn>
                            <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="UPDATE"
                                visible="true">
                                <itemtemplate>									 								
										<asp:ImageButton id="lnkSave"   tooltip="Click here to update" ImageUrl="~/Images/saveeee.gif" CommandName="Save" runat="server"></asp:ImageButton>
									</itemtemplate>
                            </asp:TEMPLATECOLUMN>
                            <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="REMOVE"
                                visible="true">
                                <itemtemplate>									 								
										<asp:ImageButton id="lnkRemove" OnClientClick="return confirm('OK to Delete?');"   tooltip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png" CommandName="Remove" runat="server"></asp:ImageButton>
									</itemtemplate>
                            </asp:TEMPLATECOLUMN>
                        </Columns>
                    </Smart:SmartDataGrid>
                </td>
            </tr>
        </table>
        <asp:Panel ID="PnlSearch" runat="server" Visible="false">
            <table width="100%">
                <tr>
                    <td style ="width :150px">
                        First
                    </td>
                    <td>
                        <asp:Label ID="lblFirst" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style ="width :150px">
                        Second
                    </td>
                    <td>
                        <asp:Label ID="lblSecond" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </asp:Panel>
</asp:Content>

