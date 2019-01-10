<%@ Page Title="Crd Db Note PO View" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="CrdDbNotePOView.aspx.vb" Inherits="Integra.CrdDbNotePOView" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table>
  <tr>
  <td >
       <div style="margin-left:785px">
                <asp:Button ID="btndAdd" runat="server" CssClass="button" Text="ADD " Visible ="true" 
                    Width="145px">
                    </asp:Button></div>
            </td>
        </tr>
         </table>
         <table width="100%">
        <tr>
            <td height="14px">
            </td>
        </tr>
        <tr>
            <td>
                <Smart:SmartDataGrid ID="dgInvoiceView" runat="server" Width="100%" OnSortCommand="SortByColumn"
                    OnPageIndexChanged="PageChanged" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                    CellPadding="4" CssClass="table" PageSize="1000" ShowFooter="True" ForeColor="white"
                    GridLines="both">
                    <Columns>
                  
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="CrdDbNotePOID"
                            DataField="CrdDbNotePOID" visible="False" />
                             <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="InvoiceNoID"
                            DataField="InvoiceNoID" visible="False" />
                             <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="SupplierID"
                            DataField="SupplierID" visible="False" />
                             <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="NoteTypeID"
                            DataField="NoteTypeID" visible="False" />
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="C/D Note No. #" DataField="CDNoteNo">
                            <headerstyle horizontalalign="center" width="5%" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Note Date" DataField="PODate">
                            <headerstyle horizontalalign="center" width="5%" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Note Type" DataField="NoteType">
                            <headerstyle horizontalalign="center" width="5%" />
                        </asp:BOUNDCOLUMN>
                             <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Supplier" DataField="Supplier">
                            <headerstyle horizontalalign="center" width="5%" />
                        </asp:BOUNDCOLUMN>
                         <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="InvoiceNo" DataField="InvNo">
                            <headerstyle horizontalalign="center" width="5%" />
                        </asp:BOUNDCOLUMN>
                          <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Invoice Amount" DataField="InvAmt">
                            <headerstyle horizontalalign="center" width="5%" />
                        </asp:BOUNDCOLUMN>
                     <asp:TEMPLATECOLUMN HeaderText="Edit" visible="false">
                            <itemtemplate>
																	
 <asp:ImageButton id="lnkEdit" tooltip="Click here to edit"  ImageUrl="~/Images/editIcon.jpg" CommandName="Edit" runat="server"></asp:ImageButton>
									
</itemtemplate>
                            <headerstyle width="2%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:TEMPLATECOLUMN>
                            
                        <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="01%" HeaderText="PDF" visible="false">
                            <itemtemplate>																	
									   <asp:ImageButton id="lnkSalesOrderPDF"  ImageUrl="~/Images/pdf_icon_small.gif" CommandName="PDF" runat="server"></asp:ImageButton>
									</itemtemplate>
                        </asp:TEMPLATECOLUMN>
                    </Columns>
                </Smart:SmartDataGrid>
            </td>
        </tr>
    </table>
</asp:Content>

