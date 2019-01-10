<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="BankCoverAdd.aspx.vb" Inherits="Integra.BankCoverAdd" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <script type="text/javascript">
     function isNumber(evt) {
         evt = (evt) ? evt : window.event;
         var charCode = (evt.which) ? evt.which : evt.keyCode;
         if (charCode > 31 && (charCode < 48 || charCode > 57)) {
             return false;
         }
         return true;
     }

    </script>
    <table width="100%">
        <tr>
            <th colspan="16" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
               BUYER COVERING
            </th>
        </tr>
    
        </table><br />
<table width="100%">

 <tr>
            <td style="width: 110px;">
               INVOICE NO#:
            </td>

            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <asp:TextBox ID="txtInvoice" runat="server" CssClass="forcapital" ReadOnly ="false"  
                AutoPostBack="false" Width="150px" style=" margin-left: -148px;"></asp:TextBox>
            
                       </td>

          </tr>
            <tr>
              <td style="width: 110px;">
                DATED:
            </td>
            <td style="width: 110px;">

            <telerik:RadDatePicker ID="txtInvoiceDate" runat="server" Culture="en-US" Width="100px" style="margin-left: -148px;">
              <Calendar ID="Calendar3" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
              </Calendar>
              <DateInput ID="DateInput3" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
              LabelWidth="40%">
               </DateInput>
              <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
               </telerik:RadDatePicker>            
            </td>
            </tr>
             <tr>
            <td style="width: 110px;">
          BANK ADDRESS
            </td>
               <td style="width: 110px;">
            <asp:TextBox ID="txtBankAdd" runat="server" CssClass="forcapital" ReadOnly ="false" AutoPostBack="false" Width="150px" style=" margin-left: -148px;margin-top: 2px;"></asp:TextBox>
            </td>
          </tr>
                    
             <tr>
             </tr>
            </table><br />
            <table width="100%">
        <tr>
            <th colspan="16" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
               DETAIL
            </th>
        </tr>
    
        </table>
        <table  width="100%" >
          <tr>
             <td style="width: 110px;">
             List:
            </td>
            <td style="width: 110px;">
              <asp:DropDownList ID="cmbList" Width="150" CssClass="combo" AutoPostBack="false"
                        runat="server" Style="margin-left: -451px;">
                    </asp:DropDownList>
            </td>
            <td style="width: 110px;">
            <asp:TextBox ID="txtListNo" runat="server" CssClass="forcapital" ReadOnly ="false" AutoPostBack="false" Width="90px" style=" margin-left: -428px;margin-top: 2px;"></asp:TextBox>
            </td>
            </tr>
            <tr>
              <td>
                 <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="button" Visible ="true" 
                            Width="120px" style="margin-left: 449px; margin-top: 8px;" /></td>
            </tr>
            </table><br />
            <table width="80%">
             <tr>
                            <td colspan ="2" >
                                <telerik:RadGrid ID="dgDetail" runat="server" CellSpacing="0" AutoGenerateColumns="false"
                                    Skin="WebBlue" Visible="False" PageSize="50" AllowAutomaticDeletes="false" >
                                    <MasterTableView>
                                        <Columns>
                                            <telerik:GridBoundColumn HeaderText="BankCoverDtlId" DataField="BankCoverDtlId" Display="false">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="ListID" DataField="ListID" Display ="false" >
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="List Name" DataField="ListName">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                            </telerik:GridBoundColumn>
                                               <telerik:GridBoundColumn HeaderText="List No." DataField="ListNo">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                            </telerik:GridBoundColumn>
                                          <telerik:GridButtonColumn UniqueName="DeleteColumn" Text="" CommandName="Delete" Visible ="false" 
                                                ConfirmTextFormatString="Are You Sure You want to Delete Record" HeaderStyle-Width="5%"
                                                ButtonType="ImageButton">
                                            </telerik:GridButtonColumn>
                                        </Columns>
                                    </MasterTableView>
                                </telerik:RadGrid>
                            </td>
                           
                        </tr>
        </table><br />
            <table width="100%">
            <tr>
            <td>
                 <asp:Button ID="btnSave" runat="server" Text="Print" CssClass="button" Visible ="true" 
                            Width="120px" style="margin-left: 330px;" />
                 <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" Visible ="true" 
                            Width="120px"   /></td>
            </tr>
            </table>
</asp:Content>
