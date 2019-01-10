<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CommercialInvoicesPopup.aspx.vb" Inherits="Integra.CommercialInvoicesPopup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href= "../App_Themes/Blue/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
     <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
    <div >
    <table >
    <tr align="center" Class="labelNew" >
    <td>PO No.</td> 
    <td>
         <telerik:RadTextBox ID="txtPONO" Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
    
    </td>
    
    
    <td>
     <telerik:RadButton ID="btnSearch" runat="server" Text="Search" Skin="WebBlue">
                    </telerik:RadButton>
    </td>
    </tr>
    </table>
    </div>
   
   <div>
    <table style="width: 100%;">
      <tr>  
<td   align="center" class="ErrorMsg" >
    <asp:Label ID="lblpopupMSG"   runat="server"  ></asp:Label>
</td>
       
     
    </tr>
      <tr>
        <td align="right" >
  <telerik:RadButton id="cmdSelect" runat="server" text="Select" skin="WebBlue">
  </telerik:RadButton>
    &nbsp;<asp:button id="cmdClose"    OnClientClick="window.close();" runat="server"
  CssClass="button" Text="Close"   ></asp:button>
 </td>
 </tr>
     
           <tr>
        <td colspan="6">
         <telerik:RadGrid ID="dgCommercialInvoiceSelection" runat="server" CellSpacing="0" 
                AutoGenerateColumns="false"  Skin="WebBlue"  
                Visible="False" PageSize="50">
           <AlternatingItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" />
          <MasterTableView>
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>
<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
            <Columns>
             <telerik:GridBoundColumn HeaderText="CommercialInvoiceDetailID" DataField="CommercialInvoiceDetailID" Display ="false" AllowFiltering ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn>         
              <telerik:GridBoundColumn HeaderText="StyleID" DataField="StyleID" Display ="false" AllowFiltering ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn>  
            <telerik:GridBoundColumn HeaderText="POID" DataField="POID" Display ="false" AllowFiltering ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn>  
           <telerik:GridBoundColumn HeaderText="PODetailID" DataField="PODetailID" Display ="false" AllowFiltering ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn>            
            <telerik:GridBoundColumn HeaderText="Customer" DataField="CustomerName" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>
               <telerik:GridBoundColumn HeaderText="Customer" DataField="CustomerName1" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Dept" DataField="EKNumber" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn>
            
            <telerik:GridBoundColumn HeaderText="Product Catergory" DataField="ProductCategories"  Display ="false" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>    
             <telerik:GridBoundColumn HeaderText="Style No" DataField="StyleNo" AllowFiltering ="false" FilterControlWidth="100px" AutoPostBackOnFilter="false" CurrentFilterFunction="equalto"
                    FilterDelay="4000" ShowFilterIcon="false" >
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>    
            <telerik:GridBoundColumn HeaderText="PO No" DataField="PONO" AllowFiltering ="false" FilterControlWidth="60px" AutoPostBackOnFilter="false" CurrentFilterFunction="equalto"
                    FilterDelay="4000" ShowFilterIcon="false" >
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>        
            <telerik:GridBoundColumn HeaderText="Received Date" DataField="PlacementDate"  Display ="false" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn> 
             <telerik:GridBoundColumn HeaderText="Article No" DataField="Article" AllowFiltering ="false" FilterControlWidth="60px" AutoPostBackOnFilter="false" CurrentFilterFunction="equalto"
                    FilterDelay="4000" ShowFilterIcon="false" >
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>  
             <telerik:GridBoundColumn HeaderText="Colorway" DataField="Colorway" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>   
                <telerik:GridBoundColumn HeaderText="Size" DataField="size" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>     
               <telerik:GridBoundColumn HeaderText="Price" DataField="Rate" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn> 
              <telerik:GridBoundColumn HeaderText="Article Qty." DataField="ItemQty" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>               
             <telerik:GridBoundColumn HeaderText="Shipment Date" DataField="ShipmentDate"  Display ="false" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn> 
               <telerik:GridBoundColumn HeaderText="Shipment Mode" DataField="ShipmentMode" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>              
                    <telerik:GridBoundColumn HeaderText="Shipment Term" DataField="ShipmentTerm" AllowFiltering ="false" >
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn> 
                    <telerik:GridBoundColumn HeaderText="Currency" DataField="Currency" AllowFiltering ="false"  >
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>        
             <telerik:GridTemplateColumn HeaderText="Select" UniqueName="Select" AllowFiltering ="false">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server"></asp:CheckBox>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
             </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
            </MasterTableView>
            <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="false">
  <Selecting AllowRowSelect="true" EnableDragToSelectRows="false" />
    </ClientSettings>
         <HeaderStyle Font-Names="Microsoft Sans Serif" />
             <ItemStyle Font-Names="Microsoft Sans Serif" />
<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
<FilterMenu EnableImageSprites="False"></FilterMenu>
         </telerik:RadGrid>
        </td>
        </tr>
    </table> 
    </div> 
</form>
</body>
</html>
