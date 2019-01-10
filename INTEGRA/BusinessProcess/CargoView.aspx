<%@ Page Language="vb"  MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeBehind="CargoView.aspx.vb" Inherits="Integra.CargoView" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%">
<tr>
 <td align="right">
 </td>
 </tr>
<tr><td>
	    <telerik:RadGrid ID="dgPurchaseOrder" runat="server" CellSpacing="0"  AutoGenerateColumns="false"  Skin="WebBlue"  Visible="true" PageSize="50">
            <MasterTableView>
            <Columns>            
            <telerik:GridBoundColumn HeaderText="CommercialInvoiceID" DataField="CommercialInvoiceID" Display ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" Font-Size="Smaller"  />
            </telerik:GridBoundColumn>                
             <telerik:GridBoundColumn HeaderText="Invoice No" DataField="InvoiceNo" >
           <ItemStyle HorizontalAlign="Left" Width ="50px" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" Font-Size="Smaller"  />
            </telerik:GridBoundColumn>   
            <telerik:GridBoundColumn HeaderText="Invoice Date" DataField="InvoiceDate">
            <ItemStyle HorizontalAlign="Left" Width="30px" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
               <telerik:GridBoundColumn HeaderText="BL/AWB" DataField="BillNo">
            <HeaderStyle Width="15%" HorizontalAlign="Left" Font-Size="Smaller"  /> 
            </telerik:GridBoundColumn>   
            <telerik:GridBoundColumn HeaderText="Form-E Date" DataField="ShipmentDate" >
            <ItemStyle HorizontalAlign="Left"  Width="30px"/>
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" /> 
            </telerik:GridBoundColumn>                  
              <telerik:GridBoundColumn HeaderText="Mode" DataField="Terms">
            <ItemStyle HorizontalAlign="Left"  Width="30px"  />
            <HeaderStyle Width="7%" HorizontalAlign="Left"  Font-Size="Smaller" />
            </telerik:GridBoundColumn>
               <telerik:GridBoundColumn HeaderText="ETD" DataField="ETD" ItemStyle-HorizontalAlign="Right">
            <ItemStyle HorizontalAlign="left"  Width="20px" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn>
                 <telerik:GridBoundColumn HeaderText="ETDD"  DataField="ETDD" ItemStyle-HorizontalAlign="Right" Display="false" >
            <ItemStyle HorizontalAlign="left"  Width="20px" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn>
               <telerik:GridBoundColumn HeaderText="Value" DataField="ShippedValue">
            <ItemStyle HorizontalAlign="Right"  Width="50px"  />
            <HeaderStyle Width="15%" HorizontalAlign="Center"  Font-Size="Smaller"  />
            </telerik:GridBoundColumn>
            
                <telerik:GridTemplateColumn HeaderText ="View"  Display="true">
                <ItemTemplate >
                <asp:LinkButton ID="lnView"  runat ="server" CommandName ="PDF" HeaderText ="PDF" Text="PDF" ></asp:LinkButton>
                </ItemTemplate>
                </telerik:GridTemplateColumn>
                 <telerik:GridTemplateColumn HeaderText="Exchange Rate" >
            <ItemTemplate>
                  <telerik:RadTextBox ID="txtExchangeRate" ReadOnly="true" width="50"  Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
            </ItemTemplate>
             </telerik:GridTemplateColumn>
                  <telerik:GridTemplateColumn HeaderText ="Action" >
                <ItemTemplate >
                <asp:LinkButton ID="lnConfirm"  runat ="server" CommandName ="Confirm" ></asp:LinkButton>
                </ItemTemplate>
                </telerik:GridTemplateColumn>           
            </Columns>
            </MasterTableView>
            <ClientSettings EnableRowHoverStyle="false" EnablePostBackOnRowClick="false">
<Selecting AllowRowSelect="false" EnableDragToSelectRows="false" />
 </ClientSettings>
            </telerik:RadGrid>
                        
 
  </td>			
</tr> 
</table>
 </asp:Content> 