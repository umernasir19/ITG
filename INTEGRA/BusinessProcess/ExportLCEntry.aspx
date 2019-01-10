<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="ExportLCEntry.aspx.vb" Inherits="Integra.ExportLCEntry" %>

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
            <th colspan="4" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Export LC Detail
            </th>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td style="width: 110px;">
                L/C NO.
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <asp:TextBox ID="txtLCNo" runat="server" autocomplete="off" ReadOnly="false" AutoPostBack="FALSE"
                    Style="margin-left: 0px; width: 100px;"></asp:TextBox>
            </td>
            <td style="width: 110px;">
                L/C ISSUE DATE
            </td>
            <td style="width: 110px;">
                <telerik:RadDatePicker ID="txtLCISSUEDATE" runat="server" Culture="en-US" Width="100px">
                    <Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                    </Calendar>
                    <DateInput ID="DateInput1" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
        </tr>
        <tr>
            <td style="width: 110px;">
                L/C RECEIVE DATE
            </td>
            <td style="width: 110px;">
                <telerik:RadDatePicker ID="txtLCRECEIVEDATE" runat="server" Culture="en-US" Width="100px">
                    <Calendar ID="Calendar2" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                    </Calendar>
                    <DateInput ID="DateInput2" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td style="width: 110px;">
                L/C AMOUNT.
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadNumericTextBox ID="txtLCAmountt" Width="105px" runat="server" Skin="WebBlue"
                    Type="Number" NumberFormat-DecimalDigits="2">
                </telerik:RadNumericTextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 110px;">
                L/C SHIPMENT DATE
            </td>
            <td style="width: 110px;">
                <telerik:RadDatePicker ID="txtLCSHIPMENTDATE" runat="server" Culture="en-US" Width="100px">
                    <Calendar ID="Calendar3" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                    </Calendar>
                    <DateInput ID="DateInput3" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td style="width: 110px;">
                L/C UNIT PRICE.
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadNumericTextBox ID="txtLcUnitPricee" Width="105px" runat="server" Skin="WebBlue"
                    Type="Number" NumberFormat-DecimalDigits="2">
                </telerik:RadNumericTextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 110px;">
                L/C AMMENDMENT DATE
            </td>
            <td style="width: 110px;">
                <telerik:RadDatePicker ID="txtLCAMMENDMENTDATE" runat="server" Culture="en-US" Width="100px">
                    <Calendar ID="Calendar4" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                    </Calendar>
                    <DateInput ID="DateInput4" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td style="width: 110px;">
                CUSTOMER
            </td>
            <td style="">
                <div style="margin-top: 5px;">
                    <telerik:RadComboBox ID="CMBCUSTOMER" runat="server" AutoPostBack="true" Skin="WebBlue">
                    </telerik:RadComboBox>
                </div>
            </td>
            <td style="width: 110px;">
                <div style="margin-left: 7px;">
                    SEASON</div>
            </td>
            <td style="">
                <div style="margin-left: 6PX;">
                    <telerik:RadComboBox ID="cmbSeason" runat="server" Width="107px" AutoPostBack="true"
                        Skin="WebBlue">
                    </telerik:RadComboBox>
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 110px;">
                SR NO
            </td>
            <td style="">
                <div style="margin-top: 5px;">
                    <telerik:RadComboBox ID="cmbSrNo" runat="server" AutoPostBack="true" Skin="WebBlue">
                    </telerik:RadComboBox>
                </div>
            </td>
            <td style="width: 110px;">
            </td>
            <td style="">
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td style="width: 110px;">
                NEGOTIATING BANK.
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <asp:TextBox ID="TXTNEGOTIATINGBANK" runat="server" autocomplete="off" ReadOnly="false"
                    AutoPostBack="FALSE" Style="margin-left: 0px; width: 376px;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 110px;">
                ISSUING BANK
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <asp:TextBox ID="TXTISSUINGBANK" runat="server" autocomplete="off" ReadOnly="false"
                    AutoPostBack="FALSE" Style="margin-left: 0px; width: 376px;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 110px;">
                REMARKS.
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <asp:TextBox ID="TXTREMARKS" runat="server" autocomplete="off" ReadOnly="false" AutoPostBack="FALSE"
                    Style="margin-left: 0px; width: 376px;"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td style="width: 10px;">
                <asp:Label ID="Label1" runat="server" Text="P.I No."></asp:Label>
            </td>
            <td style="width: 110px;">
                <div style="margin-left: 23px;">
                    <telerik:RadComboBox ID="cmbPINo" runat="server" AutoPostBack="true" Skin="WebBlue">
                    </telerik:RadComboBox>
                </div>
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td>
                <div style="overflow: scroll; width: 930px;">
                    <Smart:SmartDataGrid ID="dgExportLCDetail" runat="server" ForeColor="white" CssClass="table"
                        Width="100%" ShowFooter="True" PageSize="20" CellPadding="2" GridLines="both"
                        AutoGenerateColumns="False" AllowSorting="True">
                        <PagerStyle Mode="NumericPages" CssClass="GridPagerStyle" HorizontalAlign="Right"
                            Visible="False"></PagerStyle>
                        <AlternatingItemStyle CssClass="GridAlternativeRow"></AlternatingItemStyle>
                        <ItemStyle CssClass="GridRow"></ItemStyle>
                        <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center"></HeaderStyle>
                        <Columns>
                            <asp:BoundColumn DataField="LCExportDtlID" HeaderText="LCExportDtlID" Visible="False">
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Joborderid" HeaderText="Joborderid" Visible="False">
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="JoborderDetailid" HeaderText="Detail ID" Visible="False">
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="SeasonDatabaseID" HeaderText="SeasonDatabaseID" Visible="False">
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DPIDtlID" HeaderText="DPIDtlID" Visible="False"></asp:BoundColumn>
                            <asp:BoundColumn DataField="CurrencyID" HeaderText="CurrencyID" Visible="False">
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="PaymentTermID" HeaderText="PaymentTermID" Visible="False">
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="CustomerID" HeaderText="CustomerID" Visible="False">
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Season" DataField="Season">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="8%" HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="SRNo" DataField="SRNo">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="8%" HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Buyer" DataField="Buyer">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="8%" HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Style No" DataField="StyleNo">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="8%" HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Order No" DataField="OrderNo">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="8%" HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Description" DataField="Description">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="8%" HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Shipment Date" DataField="ShipmentDate">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="8%" HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Order Qty" DataField="OrderQty">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="8%" HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Shipment Qty" DataField="ShipmentQty">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="8%" HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Balance Qty" DataField="BalanceQty">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="8%" HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Remarks" DataField="Remarks">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="8%" HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Sales Contract No" DataField="salescontractno">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="8%" HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Sales Contract Qty" DataField="salesContractQty">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="8%" HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Sales Contract Amount" DataField="SalesContractAmount">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="8%" HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Payment Term" DataField="Paymentterm">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="8%" HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Currency" DataField="Currency">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="8%" HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="L/C No" DataField="LCNo">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="8%" HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="L/C Amount" DataField="LCAmount">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="8%" HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="L/C ISSUE Date" DataField="SendDate">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="8%" HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="L/C Recv Date" DataField="RecvDate">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="8%" HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="L/C Ship Date" DataField="ShipDate">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="8%" HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="L/C AMMENDMENT DATE" DataField="AmdDate">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="8%" HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Negotiate Bank" DataField="NegotiateBank">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="8%" HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Issue Bank" DataField="IssueBank">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="8%" HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Issue Remarks" DataField="IssueRemarks">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="8%" HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="" Visible="false">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkRemove" ToolTip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png"
                                        CommandName="Remove" runat="server"></asp:ImageButton>
                                </ItemTemplate>
                                <HeaderStyle Width="1%" HorizontalAlign="Center"></HeaderStyle>
                            </asp:TemplateColumn>
                        </Columns>
                    </Smart:SmartDataGrid>
                </div>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td colspan="2" align="right">
                <telerik:RadButton ID="btnSave" runat="server" Text="Save" Skin="WebBlue" Visible="false">
                </telerik:RadButton>
            </td>
            <td>
                &nbsp;
                <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" Skin="WebBlue">
                </telerik:RadButton>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
