<%@ Page Title="Cash Voucher View" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="CashVoucherView.aspx.vb" Inherits="Integra.CashVoucherView" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table width="100%">
        <tr>
            <td>
                <table>
                    <tr>
                        <td style="width: 10%">
                            Show Me:
                        </td>
                        <td style="width: 20%">
                            <asp:TextBox ID="txtShowMe" runat="server" CssClass="textbox" AutoPostBack="true"
                                autocomplete="off" Width="140px" ToolTip="Voucher No"> </asp:TextBox>
                            <cc1:AutoCompleteExtender runat="server" ID="autoComplete1" TargetControlID="txtShowMe"
                                ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                                CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="tblCV" />
                        </td>
                        <td style="width: 54%">
                            <asp:Button ID="btnSearch" runat="server" Width="80" Text="Filter" Visible="false"
                                CssClass="button" OnClick="btnSearch_Click"></asp:Button>
                        </td>
                        <td style="width: 50%" align="right">
                            <asp:Button ID="cmdAdd" runat="server" CssClass="button" Text="ADD CASH VOUCHER"
                                Width="150"></asp:Button>
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
                <Smart:SmartDataGrid ID="dgView" runat="server" Width="100%" OnSortCommand="SortByColumn"
                    OnPageIndexChanged="PageChanged" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                    CellPadding="4" CssClass="table" PageSize="1000" ShowFooter="True" ForeColor="white"
                    GridLines="both">
                    <Columns>
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="tblCashMstID"
                            DataField="tblCashMstID" visible="false" />
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Voucher  Date" DataField="VoucherDate">
                            <headerstyle horizontalalign="center" width="5%" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Voucher  No" DataField="VoucherNo">
                            <headerstyle horizontalalign="center" width="7%" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Description" DataField="Description">
                            <headerstyle horizontalalign="center" width="25%" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="DB" DataField="Debit">
                            <headerstyle horizontalalign="center" width="6%" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="CR" DataField="Credit">
                            <headerstyle horizontalalign="center" width="6%" />
                        </asp:BOUNDCOLUMN>
                        <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="EDIT">
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
                        <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="PDF"
                            visible="true">
                            <itemtemplate>								
	<asp:ImageButton id="lnkPDF" tooltip="Click here to download PDF" ImageUrl="~/Images/pdf_icon_small.gif" CommandName="PDF" runat="server"></asp:ImageButton>
									</itemtemplate>
                        </asp:TEMPLATECOLUMN>
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="VoucherType"
                            DataField="VoucherType" visible="FALSE" />
                    </Columns>
                </Smart:SmartDataGrid>
            </td>
        </tr>
    </table>
</asp:Content>

