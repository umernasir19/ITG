<%@ Page Title="PO Invoice View" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="POInvoiceView.aspx.vb" Inherits="Integra.POInvoiceView" %>
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
                        <td style="width: 100%">
                        </td>
                        <td style="width: 50%" align="right">
                            <asp:Button ID="cmdAdd" runat="server" CssClass="button" Text="ADD PURCHASE VOUCHER"
                                Width="175"></asp:Button>
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
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="POInvoiceMstID"
                            DataField="POInvoiceMstID" visible="false" />
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Transaction No" DataField="TransactionNo">
                            <headerstyle horizontalalign="center" width="8%" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Voucher No" DataField="VoucherNo">
                            <headerstyle horizontalalign="center" width="8%" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="S.T Inv.No" DataField="SaleTaxInvoiceNo">
                            <headerstyle horizontalalign="center" width="7%" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Date" DataField="CreationDatee">
                            <headerstyle horizontalalign="center" width="7%" />
                        </asp:BOUNDCOLUMN>
                      
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="A/C Payable" DataField="AccountPayable">
                            <headerstyle horizontalalign="center" width="15%" />
                        </asp:BOUNDCOLUMN>  
                        
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="G.T Type" DataField="GSTType">
                            <headerstyle horizontalalign="center" width="8%" />
                        </asp:BOUNDCOLUMN>    
                          <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Amount" DataField="AMOUNT">
                            <headerstyle horizontalalign="center" width="8%" />
                        </asp:BOUNDCOLUMN>         
                                                          
                        
                        <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="EDIT" visible="false">
                            <itemtemplate>																	
										<asp:ImageButton id="lnkEdit" tooltip="Click here to edit"  ImageUrl="~/Images/editIcon.jpg" CommandName="Edit" runat="server"></asp:ImageButton>
									</itemtemplate>
                        </asp:TEMPLATECOLUMN>
                        <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="REMOVE" visible="false">
 
                            <itemtemplate>									 								
										<asp:ImageButton id="lnkRemove" tooltip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png" CommandName="Remove" runat="server"></asp:ImageButton>
									</itemtemplate>
                        </asp:TEMPLATECOLUMN>
                        <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="PDF" visible="true">
                            
                            <itemtemplate>								
	<asp:ImageButton id="lnkPDF" tooltip="Click here to download PDF" ImageUrl="~/Images/pdf_icon_small.gif" CommandName="PDF" runat="server"></asp:ImageButton>
									</itemtemplate>
                        </asp:TEMPLATECOLUMN>
                         <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="AccountPayablePartyID"
                            DataField="AccountPayablePartyID" visible="false" />
                             <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="INVFrom"
                            DataField="INVFrom" visible="false" />
                    </Columns>
                </Smart:SmartDataGrid>
            </td>
        </tr>
    </table>

</asp:Content>
