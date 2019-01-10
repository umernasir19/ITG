<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeBehind="MGTSheetForAldiOrders.aspx.vb" Inherits="Integra.MGTSheetForAldiOrders" %>
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
              <telerik:GridTemplateColumn  HeaderText="PO"  AllowFiltering ="false">
                                    <itemstyle horizontalalign="Center" />
                                      <HeaderStyle Width="5%" HorizontalAlign="Center" Font-Size="Smaller"/>
									<ITEMTEMPLATE>
  <asp:ImageButton ID="lnkPO" CommandName="PO"  ImageUrl="~/Images/po.png"  ToolTip="Click here to View PO"  runat="server"></asp:ImageButton>
                                    </ITEMTEMPLATE>
                                    <headerstyle width="10%" />
								</telerik:GridTemplateColumn >    
  <telerik:GridTemplateColumn  HeaderText="Original Contract"  AllowFiltering ="false">
                                    <itemstyle horizontalalign="Center" />
                                      <HeaderStyle Width="5%" HorizontalAlign="Center" Font-Size="Smaller"/>
									<ITEMTEMPLATE>
  
  <asp:ImageButton ID="lnkOriginal" CommandName="OriginalContract"  ImageUrl="~/Images/Original.png" ToolTip="Click here For Original Contract"    runat="server"></asp:ImageButton>
                                    </ITEMTEMPLATE>
                                    <headerstyle width="10%" />
								</telerik:GridTemplateColumn >
  <telerik:GridTemplateColumn  HeaderText="Critical Path"  AllowFiltering ="false" Visible="false" >
                                    <itemstyle horizontalalign="Center" />
                                      <HeaderStyle Width="5%" HorizontalAlign="Center" Font-Size="Smaller"/>
									<ITEMTEMPLATE>
   <asp:ImageButton ID="lnkCriticalPath" CommandName="CriticalPath"  ImageUrl="~/Images/Critical.png"  ToolTip="Click here For Critical Path"   runat="server"></asp:ImageButton>
                                    
                                    </ITEMTEMPLATE>
                                    <headerstyle width="10%" />
								</telerik:GridTemplateColumn >
  <telerik:GridTemplateColumn  HeaderText="Cutting Line Status"  AllowFiltering ="false">
                                    <itemstyle horizontalalign="Center" />
                                      <HeaderStyle Width="5%" HorizontalAlign="Center" Font-Size="Smaller"/>
									<ITEMTEMPLATE>
 <asp:ImageButton ID="lnkCutting" CommandName="CuttingLineStatus"   ImageUrl="~/Images/Cutting.png"  ToolTip="Click here For Cutting Line Status"   runat="server"></asp:ImageButton>                                  
                                    </ITEMTEMPLATE>
                                    <headerstyle width="10%" />
								</telerik:GridTemplateColumn >
  <telerik:GridTemplateColumn  HeaderText="Stitching Line Status"  AllowFiltering ="false">
                                    <itemstyle horizontalalign="Center" />
                                      <HeaderStyle Width="5%" HorizontalAlign="Center" Font-Size="Smaller"/>
									<ITEMTEMPLATE>
 
 <asp:ImageButton ID="lnkStitching"   CommandName="StitchingLineStatus" ImageUrl="~/Images/Stitching.png" ToolTip="Click here For Stitching Line Status"  runat="server"></asp:ImageButton>                                                                     
                                        </ITEMTEMPLATE>
                                    <headerstyle width="10%" />
								</telerik:GridTemplateColumn >
  <telerik:GridTemplateColumn  HeaderText="Finishing Line Status"  AllowFiltering ="false">
                                    <itemstyle horizontalalign="Center" />
                                      <HeaderStyle Width="5%" HorizontalAlign="Center" Font-Size="Smaller"/>
									<ITEMTEMPLATE>

 <asp:ImageButton ID="lnkFinishing" CommandName="FinishingLineStatus" ImageUrl="~/Images/Finishing.png" ToolTip="Click here For Finishing Line Status"   runat="server"></asp:ImageButton>                                                                     
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
