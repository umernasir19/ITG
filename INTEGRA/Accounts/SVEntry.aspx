<%@ Page Title="SV Entry" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="SVEntry.aspx.vb" Inherits="Integra.SVEntry" %>

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
    <table width="100%">
        <tr style="font-style: italic; font-size: 25px; color: Blue; height: 30px; vertical-align: middle;">
            <td colspan="3">
                <u>SALES VOUCHER</u>
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
                <asp:TextBox ID="txtVoucherdate2" CssClass="textbox" Width="75" runat="server" Visible="true"
                    AutoPostBack="true" Style="text-transform: uppercase;" ToolTip="dd/mm/yyyy" placeholder="dd/mm/yyyy"
                    autocomplete="off"></asp:TextBox>
                <asp:TextBox ID="txtVoucherdate" CssClass="textbox" Width="120" runat="server" AutoPostBack="true"
                    Style="text-transform: uppercase;" Visible="false"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtVoucherdate"
                    PopupButtonID="ImageButton1" />
                <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                    AlternateText="Click here to display calendar" Visible="false" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtVoucherdate"
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
        <tr style="height: 35px;">
            <td style="width: 100px;">
              Inv No.
            </td>
            <td style="width: 300px;">
                <asp:TextBox ID="txtVno" ReadOnly="false" CssClass="textbox" runat="server" Width="150px"
                    Visible="true"></asp:TextBox>
            </td>
            <td style="width: 100px;">
            <asp:label ID ="Label1" runat ="server" Text ="Inv Val." style=" color :Red " Font-Bold ="true"    ></asp:label>
                                    
              
            </td>
            <td style="width: 300px;">

            <asp:label ID ="lblInvoiceVal" runat ="server" style=" color :Red " Font-Bold ="true"  ></asp:label>
              
            </td>
        </tr>
        <tr style="height: 35px;">
            <td style="width: 100px;">
                <%-- Description--%>
            </td>
            <td style="width: 300px;" colspan="3">
                <asp:TextBox ID="txtdescription" AutoPostBack="true" Visible="false" CssClass="textbox"
                    runat="server" Width="550px">  </asp:TextBox>
            </td>
        </tr>
        <tr style="font-style: italic; font-size: 25px; color: Blue; height: 30px; vertical-align: middle;">
            <td>
                <u>Detail</u>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td>
                <div id="divJVDetail" style="width: 930px; overflow: scroll">
                    <Smart:SmartDataGrid ID="dgJVDetail" runat="server" ForeColor="white" CssClass="table"
                        Width="100%" ShowFooter="True" PageSize="20" CellPadding="2" GridLines="both"
                        AutoGenerateColumns="False" AllowSorting="True">
                        <PagerStyle Mode="NumericPages" CssClass="GridPagerStyle" HorizontalAlign="Right"
                            Visible="False"></PagerStyle>
                        <AlternatingItemStyle CssClass="GridAlternativeRow"></AlternatingItemStyle>
                        <ItemStyle CssClass="GridRow"></ItemStyle>
                        <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center"></HeaderStyle>
                        <Columns>
                            <asp:BoundColumn DataField="tblJvDtlID" HeaderText="Detail ID" Visible="False"></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="TypeID" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblTypeID" runat="server" Font-Size="8pt" Width="30" CssClass="textbox"
                                        __designer:wfdid="w6" Visible="false">
                                    </asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="2%" HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="S.No">
                                <ItemTemplate>
                                    <asp:Label ID="lblRowNo" runat="server" Font-Size="8pt" Width="30" CssClass="textbox"
                                        __designer:wfdid="w1">
                                    </asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="2%" HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Type">
                                <ItemTemplate>
                                    <asp:DropDownList ID="cmbType" runat="server" AutoPostBack="true" TabIndex="0" Font-Size="8pt"
                                        Width="80" CssClass="textbox" __designer:wfdid="w5" OnSelectedIndexChanged="cmbType_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </ItemTemplate>
                                <HeaderStyle Width="6%" HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Account Name">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAccountName" CssClass="textbox" runat="server" TabIndex="1" AutoPostBack="true"
                                        autocomplete="off" Width="480px" OnTextChanged="txtAccountName_TextChanged" ToolTip="Item Name"> </asp:TextBox>
                                    <cc1:AutoCompleteExtender runat="server" ID="autoComplete1" TargetControlID="txtAccountName"
                                        ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                                        CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="AccountName" />
                                </ItemTemplate>
                                <HeaderStyle Width="6%" HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle Width="25%" HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Account Code">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAccountCode" CssClass="textbox" ReadOnly="TRUE" Width="80" Font-Size="8pt"
                                        runat="server">
                                    </asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Width="6%" HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="DR">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDebit" runat="server" AutoPostBack="true" Font-Size="8pt" TabIndex="2"
                                        Width="80" CssClass="textbox" __designer:wfdid="w7" OnTextChanged="txtDebit_TextChanged">
                                    </asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Width="6%" HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="CR">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCredit" runat="server" AutoPostBack="true" Font-Size="8pt" TabIndex="2"
                                        Width="80" CssClass="textbox" __designer:wfdid="w8" OnTextChanged="txtCredit_TextChanged"></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Width="6%" HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:TemplateColumn>
                        </Columns>
                    </Smart:SmartDataGrid>
                </div>
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td style="width: 450px;">
            </td>
            <td>
                <asp:Label ID="lblTotalHding" runat="server" Style="margin-left: 440px;" Visible="true"
                    Text="Total Account:"></asp:Label>
            </td>
            <td align="center" style="width: 150px;">
                <asp:TextBox ID="txttotalDebit" Width="80" Enabled="false" Style="margin-left: -76px;"
                    runat="server" Visible="true"></asp:TextBox>
                <asp:TextBox ID="txttotalCredit" Width="80" Enabled="false" runat="server" Visible="true"></asp:TextBox>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td style="width: 100px;">
                Description
            </td>
            <td style="width: 300px;" colspan="3">
                <asp:TextBox ID="txtDescriptionDetail" Enabled="false" CssClass="textbox" Width="750"
                    runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
            </td>
            <td>
            </td>
            <td>
                <asp:Button ID="btnAdd" Text="Add NEW ROW" TabIndex="3" runat="server" Width="124px;"
                    CssClass="button"></asp:Button>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnSave" Text="Save" runat="server" TabIndex="4" Width="100" CssClass="button"
                    Visible="false"></asp:Button>
                <asp:Button ID="btnCancel" Text="Cancel" runat="server" Width="100" CssClass="button"
                    Visible="false" CausesValidation="false"></asp:Button>
            </td>
        </tr>
    </table>
    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" TargetControlID="btnSave"
        OnClientCancel="cancelClick" DisplayModalPopupID="ModalPopupExtender1" />
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnSave"
        PopupControlID="PNL" OkControlID="ButtonOk" CancelControlID="ButtonCancel" BackgroundCssClass="modalBackground" />
    <asp:Panel ID="PNL" runat="server" Style="display: none; height: 120px; width: 350px;
        background-color: White; top: 50px; border-width: 2px; border-color: Black; border-style: solid;
        padding: 20px;">
        <table>
            <tr>
                <td>
                    <asp:Image ID="imgSave" runat="server" Height="70px" ImageUrl="~/Images/warning.ico" />
                </td>
                <td style="width: 5px;">
                </td>
                <td style="font-family: Tahoma; font-size: 11px; font-weight: bold;">
                    <asp:Label ID="lblUser" CssClass="label" runat="server"></asp:Label>&nbsp; Are you
                    sure you want to Save Voucher?
                </td>
            </tr>
        </table>
        <br />
        <div style="text-align: right;">
            <asp:ImageButton ID="ButtonOk" CssClass="button" runat="server" Width="40" Height="40"
                ImageUrl="~/Images/Ok.png" />
            <asp:ImageButton ID="ButtonCancel" CssClass="button" runat="server" Width="40" Height="40"
                ImageUrl="~/Images/close.png" />
        </div>
    </asp:Panel>
</asp:Content>
