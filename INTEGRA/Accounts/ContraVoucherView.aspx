<%@ Page Title="Contra Voucher View" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="ContraVoucherView.aspx.vb" Inherits="Integra.ContraVoucherView" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <table width="100%">
    <tr>
    
 <td style="width: 918px" align="right">
 <asp:button id="cmdAdd"  runat="server" CssClass="button" Text="ADD CONTRA VOUCHER" width="218"></asp:button>
 </td>
 </tr>
 
  <tr style="height: 5px"></tr>
        <tr>
            <td>
            
                <Smart:SmartDataGrid ID="dgView" runat="server" Width="100%" OnSortCommand="SortByColumn"
                    OnPageIndexChanged="PageChanged" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                    CellPadding="4" CssClass="table" PageSize="1000" ShowFooter="True" ForeColor="white"
                    GridLines="both">
                    <Columns>
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="ContraVoucherMstID"
                            DataField="ContraVoucherMstID" visible="false" />
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Cash Payment Date" DataField="ContraPaymentDatee">
                            <headerstyle horizontalalign="center" width="5%" />
                        </asp:BOUNDCOLUMN>
                         <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Contra No" DataField="ContraNo">
                            <headerstyle horizontalalign="center" width="5%" />
                        </asp:BOUNDCOLUMN>
                           <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Account Name" DataField="Account">
                            <headerstyle horizontalalign="center" width="5%" />
                        </asp:BOUNDCOLUMN>
                       <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="EDIT"
                            Visible="true">
                            <ItemTemplate> 
                                 <asp:ImageButton ID="lnkEdit" ToolTip="Click here to edit" ImageUrl="~/Images/editIcon.jpg"
                                    CommandName="Edit" runat="server"></asp:ImageButton> 
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="PDF"
                            Visible="true">
                            <ItemTemplate>
                                <asp:ImageButton ID="lnkPDF" ToolTip="Click here to download PDF" ImageUrl="~/Images/pdf_icon_small.gif"
                                    CommandName="PDF" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </Smart:SmartDataGrid>
               
            </td>
        </tr>
    </table>
</asp:Content>


