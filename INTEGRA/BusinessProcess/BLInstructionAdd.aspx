<%@ Page Title="BL Instruction Add" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="BLInstructionAdd.aspx.vb" Inherits="Integra.BLInstructionAdd" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
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
        function TABLE1_onclick() {

        }

    </script>
    <table width="100%">
        <tr>
            <th colspan="16" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                B/L INSTRUCTION
            </th>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td>
                Invoice NO#:
            </td>
            <td>
                <asp:DropDownList ID="cmbInvoiceNo" Width="150" CssClass="combo" AutoPostBack="true"
                    runat="server" Style="">
                </asp:DropDownList>
            </td>
             <td>
                BL NO#:
            </td>
            <td>
                <asp:TextBox ID="txtBlNo" runat="server" CssClass="forcapital" ReadOnly="true"
                    AutoPostBack="false" Width="150px" Style="margin-left: 0px;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                SUPPLIER:
            </td>
            <td>
                <asp:TextBox ID="txtShiper" runat="server" CssClass="forcapital" ReadOnly="false"
                    AutoPostBack="false" Width="150px" Style="margin-left: 0px;"></asp:TextBox>
            </td>
            <td>
                FORM 'E'#:
            </td>
            <td>
                <asp:TextBox ID="txtFormE" runat="server" CssClass="forcapital" ReadOnly="false"
                    AutoPostBack="false" Width="150px" Style="margin-left: 0px;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:TextBox ID="txtShiperAddress" runat="server" CssClass="forcapital" ReadOnly="false"
                    TextMode="MultiLine" AutoPostBack="false" Width="150px" Style="margin-left: 0px;
                    margin-top: 2px;"></asp:TextBox>
            </td>
            <td>
                FORM 'E'DATE:
            </td>
            <td>
                <telerik:RadDatePicker ID="txtFormEDate" runat="server" Culture="en-US" Width="100px">
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
            <td>
            </td>
            <td>
            </td>
            <td>
                FROM:
            </td>
            <td>
                <asp:TextBox ID="txtFrom" runat="server" CssClass="forcapital" ReadOnly="false" AutoPostBack="false"
                    Width="150px" Style="margin-left: 0px;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                CONSIGNEE:
            </td>
            <td>
                <asp:TextBox ID="txtConsignee" runat="server" CssClass="forcapital" TextMode="MultiLine"
                    ReadOnly="false" AutoPostBack="false" Width="150px" Style="margin-left: 0px;"></asp:TextBox>
            </td>
            <td>
                TO:
            </td>
            <td>
                <asp:TextBox ID="txtTo" runat="server" CssClass="forcapital" ReadOnly="false" AutoPostBack="false"
                    Width="150px" Style="margin-left: 0px;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
                QTY:
            </td>
            <td>
                <asp:TextBox ID="txtQtyCtn" runat="server" CssClass="forcapital" ReadOnly="false"
                    AutoPostBack="false" Width="46px" Style="margin-left: 0px;"></asp:TextBox>CTN
                <asp:TextBox ID="txtQtyPcs" runat="server" CssClass="forcapital" ReadOnly="false"
                    AutoPostBack="false" Width="46px" Style="margin-left: 0px;"></asp:TextBox>PCS
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
                NET WEIGHT
            </td>
            <td>
                <asp:TextBox ID="txtNetWt" runat="server" CssClass="forcapital" ReadOnly="false"
                    AutoPostBack="false" Width="150px" Style="margin-left: 0px;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
                GROSS WEIGHT:
            </td>
            <td>
                <asp:TextBox ID="txtGrossWt" runat="server" CssClass="forcapital" ReadOnly="false"
                    AutoPostBack="false" Width="150px" Style="margin-left: 0px;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                NOTIFY:
            </td>
            <td>
                <asp:TextBox ID="txtNotify" runat="server" CssClass="forcapital" ReadOnly="false"
                    AutoPostBack="false" Width="150px" TextMode="MultiLine" Style="margin-left: 0px;"></asp:TextBox>
            </td>
            <td>
                LC #:
            </td>
            <td>
                <asp:TextBox ID="txtLc" runat="server" CssClass="forcapital" ReadOnly="false" AutoPostBack="false"
                    Width="150px" Style="margin-left: 0px;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                LC DATED:
            </td>
            <td>
                <telerik:RadDatePicker ID="txtLcDate" runat="server" Culture="en-US" Width="100px">
                    <Calendar ID="Calendar2" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                    </Calendar>
                    <DateInput ID="DateInput2" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
                CONTAINER NO #:
            </td>
            <td>
                <asp:TextBox ID="txtContainer" runat="server" CssClass="forcapital" ReadOnly="false"
                    AutoPostBack="false" Width="150px" Style="margin-left: 0px;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
                VESSEL:
            </td>
            <td>
                <asp:TextBox ID="txtVessel" runat="server" CssClass="forcapital" ReadOnly="false"
                    AutoPostBack="false" Width="150px" Style="margin-left: 0px;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                FREIGHT #:
            </td>
            <td>
                <asp:DropDownList ID="cmbFreight" Width="150" CssClass="combo" AutoPostBack="true"
                    runat="server" Style="margin-left: 2px; margin-right: 208px;">
                    <asp:ListItem Value="FOB">FOB</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                Marks & Numbers:
            </td>
            <td>
                <asp:TextBox ID="txtMarksNo" runat="server" CssClass="forcapital" ReadOnly="false"
                    TextMode="MultiLine" AutoPostBack="false" Width="150px" Style="margin-left: 0px;"></asp:TextBox>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr style="height: 55px;">
            <td>
                <asp:Button ID="btnAdd" runat="server" Skin="WebBlue" Text="Add Detail" Font-Bold="True"
                    Font-Names="Calibri" Font-Size="Medium" Height="30px" Width="120px" Style="margin-left: 355px;">
                </asp:Button>
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr style="height: 30px;">
            <td>
            <div style=" width :930px; overflow :scroll ;">
                <Smart:SmartDataGrid ID="dgView" runat="server" Width="100%" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="4" CssClass="table" PageSize="1000"
                    ShowFooter="True" ForeColor="white" GridLines="both">
                    <Columns>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="BIInstDtlID"
                            DataField="BIInstDtlID" Visible="false" />
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="InvoiceID"
                            DataField="InvoiceID" Visible="false" />
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Invoice No"
                            DataField="InvoiceNo">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="15%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Shiper"
                            DataField="Shiper">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="7%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Form E No"
                            DataField="FormENo">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="15%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="Shiper Address"
                            DataField="ShiperAddress">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="15%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Form E Date"
                            DataField="FormEDate">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="15%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="From"
                            DataField="From">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="15%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Consignee"
                            DataField="Consignee">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="15%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Too"
                            DataField="Too">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="15%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Qty Ctn"
                            DataField="QtyCtn">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="15%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Qty Pcs"
                            DataField="QtyPcs">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="15%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Net Wt"
                            DataField="NetWt">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="15%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Gross Wt"
                            DataField="GrossWt">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="15%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Notify"
                            DataField="Notify">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="15%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Lc"
                            DataField="Lc">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="15%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="LcDate"
                            DataField="LcDate">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="15%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Container"
                            DataField="Container">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="15%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Vessel"
                            DataField="Vessel">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="15%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Freight"
                            DataField="Freight">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="15%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Marks No"
                            DataField="MarksNo">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="15%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Smart:SmartDataGrid></div>
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button" Visible="true"
                    Width="120px" />
            </td>
            <td>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" Visible="true"
                    Width="120px" />
            </td>
        </tr>
    </table>
</asp:Content>
