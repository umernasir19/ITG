<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="BankVoucherView.aspx.vb" Inherits="Integra.BankVoucherView" Title="Bank Voucher Page" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- <script src="../scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="../scripts/ScrollableGridPlugin.js" type="text/javascript"></script>

<script type="text/javascript" language="javascript">
$(document).ready(function() {
$('#<%=dgView.ClientID %>').Scrollable();
}
)
</script>  --%>
    <table width="100%">
        <tr>
            <td>
                <table>
                    <tr>
                        <td style="width: 10%">
                            Show Me:
                        </td>
                        <td style="width: 90%">
                            <asp:TextBox ID="txtShowMe" runat="server" CssClass="textbox" AutoPostBack="true"
                                autocomplete="off" Width="440px" ToolTip="Voucher No" placeholder="Voucher No/Party/Description"> </asp:TextBox>
                            <cc1:AutoCompleteExtender runat="server" ID="autoComplete1" TargetControlID="txtShowMe"
                                ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                                CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="tblBankMst" />
                            <asp:TextBox ID="txtdrcr" runat="server" CssClass="textbox" AutoPostBack="true" autocomplete="off"
                                Width="140px" ToolTip="Db/Cr" placeholder="Db/Cr"> </asp:TextBox>
                            <cc1:AutoCompleteExtender runat="server" ID="AutoCompleteExtender1" TargetControlID="txtdrcr"
                                ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                                CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="txtdrcr" />
                        </td>
                        <td style="width: 54%">
                            <asp:Button ID="btnSearch" runat="server" Width="80" Text="Filter" Visible="false"
                                CssClass="button" OnClick="btnSearch_Click"></asp:Button>
                        </td>
                        <td style="width: 50%" align="right">
                            <asp:Button ID="cmdAdd" runat="server" CssClass="button" Text="ADD BANK VOUCHER"
                                Width="150"></asp:Button>
                            <asp:Button ID="cmdAddCash" runat="server" CssClass="button" Text="ADD CASH VOUCHER"
                                Visible="false" Width="150"></asp:Button>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 918px" align="right">
            </td>
        </tr>
        <tr style="height: 5px">
        </tr>
        <tr>
            <td>
                 
                    <Smart:SmartDataGrid ID="dgHeader" runat="server" Width="100%" OnSortCommand="SortByColumn"
                        OnPageIndexChanged="PageChanged" AllowPaging="false" AllowSorting="false" AutoGenerateColumns="False"
                        CellPadding="4" CssClass="table" PageSize="10000000" ShowFooter="false" ForeColor="white"
                        GridLines="both" ShowHeader ="true" Visible ="true">
                        <Columns>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="tblBankMstID"
                                DataField="tblBankMstID" visible="false" />
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Voucher  Date" DataField="VoucherDate">
                                <headerstyle horizontalalign="center" width="5%" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Voucher  No" DataField="VoucherNo">
                                <headerstyle horizontalalign="center" width="7%" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Description" DataField="Description">
                                <headerstyle horizontalalign="center" width="20%" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="right" HeaderText="DB" DataField="Debit">
                                <headerstyle horizontalalign="center" width="6%" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="right" HeaderText="CR" DataField="Credit">
                                <headerstyle horizontalalign="center" width="6%" />
                            </asp:BOUNDCOLUMN>
                            <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" VISIBLE="true" HeaderStyle-Width="02%"
                                HeaderText="EDIT">
                                <itemtemplate>																	
										<%--<asp:ImageButton id="lnkEdit" tooltip="Click here to edit"  ImageUrl="~/Images/editIcon.jpg" CommandName="Edit" runat="server"></asp:ImageButton>--%>
									</itemtemplate>
                            </asp:TEMPLATECOLUMN>
                            <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="REMOVE"
                                visible="false">
                                <itemtemplate>									 								
										<%--<asp:ImageButton id="lnkRemove" tooltip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png" CommandName="Remove" runat="server"></asp:ImageButton>--%>
									</itemtemplate>
                            </asp:TEMPLATECOLUMN>
                            <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="PDF"
                                visible="true">
                                <itemtemplate>								
	<%--<asp:ImageButton id="lnkPDFf" tooltip="Click here to download PDF" ImageUrl="~/Images/pdf_icon_small.gif" CommandName="PDF" runat="server"></asp:ImageButton>--%>
									</itemtemplate>
                            </asp:TEMPLATECOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="VoucherType"
                                DataField="VoucherType" visible="false" />
                                
                        </Columns>
                    </Smart:SmartDataGrid>
                
            </td>
        </tr>
        <tr>
            <td>
                <div id="div1" runat="server" style="overflow: scroll; width: 100%; height: 600px;">
                    <Smart:SmartDataGrid ID="dgView" runat="server" Width="100%" OnSortCommand="SortByColumn"
                        OnPageIndexChanged="PageChanged" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                        CellPadding="4" CssClass="table" PageSize="10000000" ShowFooter="True" ForeColor="white"
                        GridLines="both" ShowHeader ="false" >
                        <Columns>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="tblBankMstID"
                                DataField="tblBankMstID" visible="false" />
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" ItemStyle-Width="94px" HeaderText="Voucher  Date" DataField="VoucherDate">
                                <headerstyle horizontalalign="center" width="5%" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" ItemStyle-Width="133px" HeaderText="Voucher  No" DataField="VoucherNo">
                                <headerstyle horizontalalign="center" width="7%" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" ItemStyle-Width="384px" HeaderText="Description" DataField="Description">
                                <headerstyle horizontalalign="center" width="20%" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="right" ItemStyle-Width="112px" HeaderText="DB" DataField="Debit">
                                <headerstyle horizontalalign="center" width="6%" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="right" ItemStyle-Width="114px" HeaderText="CR" DataField="Credit">
                                <headerstyle horizontalalign="center" width="6%" />
                            </asp:BOUNDCOLUMN>
                            <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" VISIBLE="true" HeaderStyle-Width="02%"
                                HeaderText="EDIT">
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
                            <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" ItemStyle-Width="24px" HeaderStyle-Width="02%" HeaderText="PDF"
                                visible="true">
                                <itemtemplate>								
	<asp:ImageButton id="lnkPDF" tooltip="Click here to download PDF" ImageUrl="~/Images/pdf_icon_small.gif" CommandName="PDF" runat="server"></asp:ImageButton>
									</itemtemplate>
                            </asp:TEMPLATECOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="VoucherType"
                                DataField="VoucherType" visible="false" />
                                 <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="LockBit"
                                DataField="LockBit" visible="true" />
                                 <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="BitBackDate"
                                DataField="BitBackDate" visible="false" />
                        </Columns>
                    </Smart:SmartDataGrid>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
