<%@ Page Language="vb"  MasterPageFile="~/MasterPage.master"  AutoEventWireup="false" CodeBehind="StatusSheet.aspx.vb" Inherits="Integra.StatusSheet" %>
 <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
 <table  width="100%">
   <tr>
    <td>
  <telerik:RadGrid ID="dgMGTSheetForAldiOrders" runat="server" CellSpacing="0"  AutoGenerateColumns="false"  Skin="WebBlue"  Visible="true" PageSize="50">
            <MasterTableView>
           <Columns>            
            <telerik:GridBoundColumn HeaderText="POID" DataField="POID" Display ="false" AllowFiltering ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn>
           <telerik:GridBoundColumn HeaderText="Customer" DataField="CustomerName" AllowFiltering ="true"  FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                    FilterDelay="3000" ShowFilterIcon="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>      
            <telerik:GridBoundColumn HeaderText="Supplier" DataField="VenderName" AllowFiltering ="true"  FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                    FilterDelay="3000" ShowFilterIcon="false">
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn>
             <telerik:GridBoundColumn HeaderText="Merchant" DataField="UserName" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>  
             <telerik:GridBoundColumn HeaderText="PO No." DataField="PONO" AllowFiltering ="true" FilterControlWidth="65px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                    FilterDelay="4000" ShowFilterIcon="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>    
              <telerik:GridBoundColumn HeaderText="PO Qty" DataField="POQuantity" DataFormatString="{0:#,##0;(#,##0);0}" DataType="System.Decimal" AllowFiltering ="false" Aggregate="Sum" FooterText=" " FooterStyle-Font-Bold="true" FooterStyle-Font-Names="Calibri">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>  
             <telerik:GridBoundColumn HeaderText="Placement" DataField="PlacementDate" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>   
                <telerik:GridBoundColumn HeaderText="Shipment" DataField="ShipmentDate" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>  
              <telerik:GridTemplateColumn  HeaderText="Status View"  AllowFiltering ="false">
                                    <itemstyle horizontalalign="Center" />
                                      <HeaderStyle Width="5%" HorizontalAlign="Center" Font-Size="Smaller"/>
									<ITEMTEMPLATE>
  <asp:ImageButton ID="lnkStatus" CommandName="Status"  ImageUrl="~/Images/po.png"  ToolTip="Click here to View Status"  runat="server"></asp:ImageButton>
                                    </ITEMTEMPLATE>
                                    <headerstyle width="10%" />
								</telerik:GridTemplateColumn >    
  
   </Columns>
   </MasterTableView>
     <HeaderStyle Font-Names="Microsoft Sans Serif" />
                <ItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" Wrap="False" />
 <ClientSettings EnableRowHoverStyle="false" EnablePostBackOnRowClick="false">
<Selecting AllowRowSelect="false" EnableDragToSelectRows="false" />
 </ClientSettings>
   </telerik:RadGrid>
    </td>
        </tr>
    </table> 
</asp:Content> 