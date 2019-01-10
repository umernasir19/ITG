<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DetailPopup.aspx.vb" Inherits="Integra.DetailPopup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Invoice Detai Popup Page</title>
    <link type="text/css" rel="stylesheet" href="../App_Themes/Blue/NewCSS/NewStyle.css" />
    <link type="text/css" rel="stylesheet" href="../css/style.css" />
    <link type="text/css" rel="stylesheet" href="../App_Themes/Blue/StyleSheet.css" />
    <link href="../StyleSheet.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="stylesheet" href="../NewLayout.css" />
    <link type="text/css" rel="stylesheet" href="../css/VAF.css" />
    <link href="../css/new.css" rel="stylesheet" type="text/css" />
    <link href="../css/buttons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Styles/sooperfish.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="../Styles/sooperfish-theme-large.css"
        media="screen" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <table width="100%">
            <tr>
                <td>
                    <Smart:SmartDataGrid ID="dgpaymentDetailInvoicewise" runat="server" Width="100%" AllowPaging="false"
                        AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                        PageSize="500" ShowFooter="True" ForeColor="white" GridLines="both">
                        <Columns>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="tblBankDtlID"
                                DataField="tblBankDtlID" visible="False" />
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Cheque No"
                                DataField="ChequeNo">
                                <itemstyle horizontalalign="Center" />
                                <headerstyle width="7%" horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Date"
                                DataField="ChequeDate">
                                <itemstyle horizontalalign="Center" />
                                <headerstyle width="7%" horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="Account Code"
                                DataField="AccountCode">
                                <itemstyle horizontalalign="Center" />
                                <headerstyle width="10%" horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="Account Name"
                                DataField="AccountName">
                                <itemstyle horizontalalign="Center" />
                                <headerstyle width="15%" horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="Description Entry"
                                DataField="DescriptionEntry">
                                <itemstyle horizontalalign="Center" />
                                <headerstyle width="15%" horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="Type "
                                DataField="Type">
                                <itemstyle horizontalalign="Center" />
                                <headerstyle width="5%" horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="Inv. Amount"
                                DataField="InitialAmount">
                                <itemstyle horizontalalign="Center" />
                                <headerstyle width="7%" horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="W.H.Tax.%"
                                DataField="WHTaxAmount" visible="false">
                                <itemstyle horizontalalign="Center" />
                                <headerstyle width="7%" horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="G.S.Tax.%"
                                DataField="GSTaxAmount" visible="false">
                                <itemstyle horizontalalign="Center" />
                                <headerstyle width="7%" horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="Paid Amount"
                                DataField="Amount">
                                <itemstyle horizontalalign="Center" />
                                <headerstyle width="7%" horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="W.H.Tax.CR%"
                                DataField="WHTaxAmountCr" visible="false">
                                <itemstyle horizontalalign="Center" />
                                <headerstyle width="7%" horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="G.S.Tax.Cr%"
                                DataField="GSTaxAmountCr" visible="false">
                                <itemstyle horizontalalign="Center" />
                                <headerstyle width="7%" horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="W.H.Tax.DB%"
                                DataField="WHTaxAmountDB" visible="false">
                                <itemstyle horizontalalign="Center" />
                                <headerstyle width="7%" horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="G.S.Tax.DB%"
                                DataField="GSTaxAmountDB" visible="false">
                                <itemstyle horizontalalign="Center" />
                                <headerstyle width="7%" horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="WHTaxPercentage"
                                DataField="WHTaxPercentage" visible="false">
                                <itemstyle horizontalalign="Center" />
                                <headerstyle width="1%" horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="GSTaxPercentage"
                                DataField="GSTaxPercentage" visible="false">
                                <itemstyle horizontalalign="Center" />
                                <headerstyle width="1%" horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                             <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="Ref No"
                                DataField="RefNo">
                                <itemstyle horizontalalign="Center" />
                                <headerstyle width="7%" horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN HeaderText="PaymentTermID" DataField="PaymentTermID" visible="False">
                                <headerstyle width="5%" />
                                <itemstyle horizontalalign="Left" />
                            </asp:BOUNDCOLUMN>
                                                        
                             <asp:BOUNDCOLUMN HeaderText="SaleTaxInvoiceNo" DataField="SaleTaxInvoiceNo" visible="true">
                                <headerstyle width="5%" />
                                <itemstyle horizontalalign="Left" />
                            </asp:BOUNDCOLUMN>
                             <asp:TEMPLATECOLUMN visible="true">
                                <itemtemplate>
									        <asp:checkbox id="lblCheckdstatusForInvoiceInfo"   runat="server" Style="width: 20px; "  ></asp:checkbox>
							      
</itemtemplate>
                                <headerstyle width="2%" />
                                <itemstyle horizontalalign="Center" />
                            </asp:TEMPLATECOLUMN>
                        </Columns>
                    </Smart:SmartDataGrid>
                </td>
            </tr>
            </table> 
    </div>
    </form>
</body>
</html>
