<%@ Page Title="Store Issue Vouchar" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="StoreIssueVouchar.aspx.vb" Inherits="Integra.StoreIssueVouchar" %>

<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr style="height: 30px;">
            <td>
                <div class="heading">
                    STORE ISSUE VOUCHER WINDOW</div>
            </td>
        </tr>
    </table>
    <table>
        <tr style="height: 30px;">
            <td style="width: 150px;">
                <div class="txt" style="height: 20px;">
                    <asp:Label ID="lblCounter" Text="Counter No:" runat="server"></asp:Label>
                </div>
            </td>
            <td style="width: 150px;">
                <div class="text_box">
                    <asp:TextBox ID="txtCounterNo" runat="server" Style="width: 98px; text-align: center;
                        margin-left: -31px;" ReadOnly="false"></asp:TextBox>
                </div>
            </td>
            <td style="width: 150px;">
                <div class="txt" style="height: 20px; margin-left: 38px;">
                    Today is</div>
            </td>
            <td style="width: 150px;">
                <div class="text_box">
                    <asp:TextBox ID="txtTodayis" runat="server" Style="width: 78px; text-align: center;
                        margin-left: 6px;" ReadOnly="True"></asp:TextBox>
                </div>
            </td>
        </tr>
    </table>
    <table>
        <tr style="height: 30px;">
            <td style="width: 170px;">
                <div class="txt" style="height: 20px; width: 110px;">
                    St.Voucher No.
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
                    Issue Type
                </div>
            </td>
            <td style="width: 130px;">
                <div class="text_box" style="width: 130px;">
                    <asp:DropDownList ID="cmbIssueType" Width="100" CssClass="combo" AutoPostBack="true"
                        Style="width: 100px; text-align: center; margin-left: -52px;" runat="server">
                    </asp:DropDownList>
                    <%-- <asp:TextBox ID="txtIssueType" Style="width: 100px; text-align: center; margin-left: -52px;"
                        ReadOnly="true" runat="server"></asp:TextBox>--%>
                </div>
            </td>
            <td style="width: 30px; margin-left: 20px;">
                <div class="txt" style="height: 20px; margin-left: 38px;">
                    CC No.
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtCCNo" Style="width: 80px; text-align: center; margin-left: 5px;"
                        runat="server"></asp:TextBox>
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
        <tr style="height: 30px;">
            <td style="width: 2px">
                <div class="txt" style="height: 20px;">
                    Item Name
                </div>
            </td>
            <td style="width: 130px;">
                <div class="text_box">
                    <asp:DropDownList ID="cmbItemName" Width="100" CssClass="combo" AutoPostBack="true"
                        Style="width: 100px; text-align: center; margin-left: 5px;" runat="server">
                    </asp:DropDownList>
                    <%--<asp:TextBox ID="txtITEMNAME"  style=" margin-left: 2px; width: 100px;" runat="server"   ReadOnly="True"></asp:TextBox>--%>
                </div>
            </td>
            <td style="width: 110px;">
                <div class="txt" style="height: 20px; margin-left: -6px;">
                    Item Code
                </div>
            </td>
            <td style="width: 130px;">
                <div class="text_box">
                    <asp:TextBox ID="txtITEMCODE" AutoPostBack="true" Style="width: 100px; margin-left: 2PX;
                        margin-top: -2px;" runat="server"></asp:TextBox>
                </div>
                <asp:LinkButton ID="lnkItemPopup" Style="margin-left: 68px; font-family: Calibri;
                    font-size: 12px; color: Black;" runat="server" Visible="false"></asp:LinkButton>
                <asp:ImageButton ID="btnShow" runat="server" CommandName="AmountCalculation" BackColor="transparent"
                    ToolTip="Click here to show data." Visible="false" ImageUrl="~/Images/redCal.jpg" />
            </td>
            <td style="width: 110px;">
                <div class="txt" style="height: 20px;">
                    Qty In Hand
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtQtyInHand" runat="server" Style="width: 100px; margin-left: 5px;"
                        ReadOnly="True"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr style="height: 30px;">
            <td style="width: 110px;">
                <div class="txt" style="height: 20px;">
                    Issue Dpt.Code
                </div>
            </td>
            <td style="width: 130px;">
                <div class="text_box">
                    <asp:DropDownList ID="cmbIssueDeptCode" Width="100" CssClass="combo" AutoPostBack="true"
                        Style="margin-left: 5PX; height: 23px;" runat="server">
                    </asp:DropDownList>
                </div>
            </td>
            <td style="width: 110px;">
                <div class="txt" style="height: 20px; margin-left: -7px;">
                    Rate
                </div>
            </td>
            <td style="width: 130px;">
                <div class="text_box">
                    <asp:TextBox ID="txtRATE" Style="width: 100px; margin-left: 2px;" runat="server"
                        ReadOnly="false"></asp:TextBox>
                </div>
            </td>
            <td style="width: 110px;">
                <div class="txt" style="height: 20px;">
                    Qty Issue
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtQtyIssue" AutoPostBack="true" runat="server" Style="width: 100px;
                        margin-left: 5px;"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr style="height: 30px;">
            <td style="width: 110px;">
                <div class="txt" style="height: 20px;">
                    Amount
                </div>
            </td>
            <td style="width: 230px;">
                <div class="text_box">
                    <asp:TextBox ID="txtAMOUNT" Style="width: 100px; margin-left: 4px;" runat="server"
                        ReadOnly="True"></asp:TextBox>
                </div>
            </td>
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
                        <asp:BoundColumn HeaderText="StoreIssueDetailID" DataField="StoreIssueDetailID" Visible="False">
                            <HeaderStyle Width="5%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="IMSItemID" DataField="IMSItemID" Visible="False">
                            <HeaderStyle Width="5%" />
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
                        <asp:BoundColumn HeaderText="Issue Dept. Code" DataField="DeptAbbrivation">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Rate" DataField="AVGRATE">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Qty Issue" DataField="QtyIssue">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Amount" DataField="AMOUNT">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="DeptDatabaseId" Visible="False" DataField="DeptDatabaseId">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="TransactionMethodID" Visible="False" DataField="TransactionMethodID">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
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
        <tr>
            <td>
                <asp:Button ID="btnSave" CssClass="btn" runat="server" Text="Save" Style="margin-left: 682px;
                    width: 100px;" />
            </td>
            <td>
                <asp:Button ID="btnCancel" CssClass="btn" runat="server" Text="Cancel" Style="width: 100px;" />
            </td>
        </tr>
    </table>
</asp:Content>
