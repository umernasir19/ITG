<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="GodownTarnsfer.aspx.vb" Inherits="Integra.GodownTarnsfer" %>

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
        <tr style="height: 30px;">
            <td>
                <div class="heading">
                    Godown to Godown Transfer</div>
            </td>
        </tr>
    </table>
    <table>
        <tr style="height: 30px;">
            <td style="width: 150px;">
                <div class="txt" style="height: 20px;">
                    Today is
                    <asp:Label ID="lblCounter" Text="Counter No:" runat="server" Visible="false"></asp:Label>
                </div>
            </td>
            <td style="width: 150px;">
                <div class="text_box">
                    <asp:TextBox ID="txtCounterNo" runat="server" Style="width: 98px; text-align: center;
                        margin-left: -31px;" ReadOnly="false" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="txtTodayis" runat="server" Style="width: 78px; text-align: center;
                        margin-left: -31px;" ReadOnly="True"></asp:TextBox>
                </div>
            </td>
            <td style="width: 150px;">
                <div class="txt" style="height: 20px; margin-left: 39px;">
                    Challan No
                </div>
            </td>
            <td style="width: 150px;">
                <asp:TextBox ID="txtChallanNo" Style="width: 100px; border-radius: 4px; text-align: center;
                    margin-left: 3px;" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table>
        <tr style="height: 30px;">
            <td style="width: 170px;">
                <div class="txt" style="height: 20px; width: 110px;">
                    Voucher No.
                </div>
            </td>
            <td style="width: 130px;">
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtStoreIssueVoucherNo" ReadOnly="true" Style="width: 100px; text-align: center;
                        margin-left: -52px;" runat="server"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="txt" style="height: 20px; margin-left: 38px;">
                    Date</div>
            </td>
            <td style="width: 160px;">
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtDate" Style="text-align: center; margin-left: 6px;" runat="server"
                        Width="80" Font-Size="8pt"></asp:TextBox>
                </div>
                <div class="icon" align="center">
                    <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtDate"
                        PopupButtonID="ImageButton1" />
                    <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" Style="margin-left: -94px;"
                        ImageUrl="~/Images/calendar.JPG" AlternateText="Click here to display calendar" />
                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDate"
                        Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                        CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                        Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                    </cc1:MaskedEditExtender>
                </div>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                <div class="txt" style="height: 20px;">
                    Location From
                </div>
            </td>
            <td style="width: 130px;">
                <div class="text_box" style="width: 130px;">
                    <asp:DropDownList ID="cmbLocationFrom" Width="100" CssClass="combo" AutoPostBack="true"
                        Style="width: 160px; text-align: center; margin-left: -52px;" runat="server">
                    </asp:DropDownList>
                </div>
            </td>
            <td style="width: 30px; margin-left: 20px;">
                <div class="txt" style="height: 20px; margin-left: 38px;">
                    Location To
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:DropDownList ID="cmbLocationTo" Width="100" CssClass="combo" AutoPostBack="false"
                        Style="width: 100px; text-align: center; margin-left: 5px;" runat="server">
                    </asp:DropDownList>
                    <asp:TextBox ID="txtCCNo" Style="width: 80px; text-align: center; margin-left: 5px;"
                        runat="server" Visible="false"></asp:TextBox>
                </div>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr style="height: 5px;">
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtID" Visible="false" runat="server" Width="21px"></asp:TextBox>
                <asp:TextBox ID="IMSItemID" Visible="false" runat="server" Width="25px"></asp:TextBox>
                <asp:TextBox ID="txtTransactionMethodID" Visible="false" runat="server" Width="25px"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table>
        <tr style="height: 30px;">
            <td style="width: 110px;">
                <div class="txt" style="height: 20px; margin-left: 0px;">
                    Item Code
                </div>
            </td>
            <td style="width: 130px;">
                <div class="text_box" style="margin-left: 5px;">
                    <asp:TextBox ID="txtITEMCODE" AutoPostBack="true" Style="width: 100px; margin-left: 2PX;
                        margin-top: -2px;" runat="server"></asp:TextBox>
                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="10"
                        CompletionSetCount="12" ContextKey="ItemCodeForGodownSearch" EnableCaching="true"
                        MinimumPrefixLength="1" ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx"
                        TargetControlID="txtITEMCODE" />
                </div>
                <asp:Label ID="lblItemId" runat="server" Visible="false" Text="0"></asp:Label>
            </td>
            <td style="width: 110px;">
                <div class="txt" style="height: 20px; margin-left: 96px;">
                    Season
                </div>
            </td>
            <td style="width: 130px;">
                <div class="text_box">
                    <asp:DropDownList ID="cmbSeason" Width="100" CssClass="combo" AutoPostBack="true"
                        Style="width: 100px; text-align: center; margin-left: 5px;" runat="server">
                    </asp:DropDownList>
                </div>
            </td>
            <td style="width: 110px;">
                <div class="txt" style="height: 20px;">
                    Sr No
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:DropDownList ID="cmbSrNo" Width="100" CssClass="combo" AutoPostBack="true" Style="width: 100px;
                        text-align: center; margin-left: 5px;" runat="server">
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
    </table>
    <table>
        <tr style="height: 30px;">
            <td style="width: 2px">
                <div class="txt" style="height: 20px;">
                    Item Name
                </div>
            </td>
            <td style="width: 130px;">
                <div class="text_box">
                    <asp:TextBox ID="txtITEMNAME" Style="margin-left: 6px; width: 333px;" runat="server"
                        ReadOnly="True"></asp:TextBox>
                </div>
            </td>
            <td style="width: 110px;">
                <div class="txt" style="height: 20px; margin-left: 338px;">
                    Qty In Hand
                </div>
            </td>
            <td>
                <div class="text_box" style="margin-left: -3px;">
                    <asp:TextBox ID="txtQtyInHand" runat="server" Style="width: 100px; margin-left: 9px;"
                        ReadOnly="True"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr style="height: 30px;">
            <td style="width: 110px;">
                <div class="txt" style="height: 20px;">
                    Qty Transfer
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtQtyIssue" AutoPostBack="true" runat="server" Style="width: 100px;
                        margin-left: 5px;" onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                </div>
            </td>
            <td style="width: 110px;">
                <div class="txt" style="height: 20px; margin-left: 97px;">
                    Rate
                </div>
            </td>
            <td>
                <div class="text_box" style="margin-left: -241px;">
                    <asp:TextBox ID="txtRate" AutoPostBack="false" runat="server" Style="width: 100px;
                        margin-left: 5px;" onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                </div>
            </td>
        </tr>
    </table>
    <table>
        <tr style="height: 30px;">
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
                <asp:Button ID="btnAddDetail" CssClass="btn" runat="server" Text="ADD GRID" />
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td>
                <Smart:SmartDataGrid ID="dgItemView" runat="server" Width="100%" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                    PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="200" RecordCount="0"
                    ShowFooter="True" ForeColor="white" GridLines="both">
                    <Columns>
                        <asp:BoundColumn HeaderText="GodownIssueDetailID" DataField="GodownIssueDetailID"
                            Visible="False">
                            <HeaderStyle Width="5%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="IMSItemID" DataField="IMSItemID" Visible="False">
                            <HeaderStyle Width="5%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="From Location" DataField="FromLocation">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="FromLocationID" DataField="FromLocationID" Visible="False">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="To Location" DataField="ToLocation">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="ToLocationID" DataField="ToLocationID" Visible="False">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Item Code" DataField="ItemCodee">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Item Name" DataField="ItemName">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Qty In Hand" DataField="QtyInHand">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Qty Issue" DataField="QtyIssue">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="TransactionMethodID" Visible="False" DataField="TransactionMethodID">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="Rate">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtRate" runat="server" Width="80" Text='<% #Eval("Rate") %>' CssClass="textbox"></asp:TextBox>
                            </ItemTemplate>
                            <HeaderStyle Width="1%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" Visible="false"
                            HeaderText="EDIT">
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
    <table>
        <tr>
            <td style="width: 110px;">
                <div class="txt" style="height: 20px; float: left;">
                    Remarks
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtRemarks" TextMode="MultiLine" AutoPostBack="false" runat="server"
                        Style="width: 337px; margin-left: 5px;"></asp:TextBox>
                </div>
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td>
                <asp:Button ID="btnSave" CssClass="btn" runat="server" Text="Save" Style="margin-left: 682px;
                    width: 100px;" />
            </td>
            <td>
                <asp:Button ID="btnCancel" CssClass="btn" runat="server" Text="Cancel" Style="width: 100px;" />
            </td>
            <td>
                <asp:Label ID="lblGodownIssueDetailID" runat="server" Visible="false"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblIMSItemID" runat="server" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lblUserId" runat="server" Visible="false" Text="0"></asp:Label>
                <asp:Label ID="lblAuditorStatus" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lblAuditorID" runat="server" Visible="false"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
