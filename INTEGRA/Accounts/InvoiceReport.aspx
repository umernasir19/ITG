<%@ Page Title="Invoice Report" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="InvoiceReport.aspx.vb" Inherits="Integra.InvoiceReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="main_container">
        <div style="margin-left: 20px; margin-left: -2px;">
            <br />
            <div class="heading" style="width: 898px">
               Invoice Report</div>
            <br />
           <div class="raw_2" style="margin-left: 22px;">
                <div class="txt" style="width: 150px">
                    Supplier :</div>
                <div >
                    <asp:DropDownList ID="cmbSupplier" Width="200px" runat="server" AutoPostBack="true"
                        CssClass="combo" style="margin-left: 10px;">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="raw_2" style="margin-left: 22px;">
                <div class="txt" style="width: 150px ; margin-left: -152px; margin-top: 11px;">
                    Voucher No. :</div>
                <div >
                    <asp:DropDownList ID="cmbVoucherNo" Width="152px" runat="server" AutoPostBack="false"
                        CssClass="combo" style="margin-left: 10px; margin-top: 11px;">
                    </asp:DropDownList>
                </div>
            </div>
            
            
            <div class="raw_2">
                <div class="raw_btn_new_2">
                    <asp:Button ID="btnQuantityReport" CssClass="btn" runat="server" Text="Print"
                        Style="width: 95px; height :30px; margin-left: 185px;" />
                    <asp:Button ID="btnAmountReport"  Visible="false" CssClass="btn" runat="server" Text="Inventory [Amount]"
                        Style="width: 165px;" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>


