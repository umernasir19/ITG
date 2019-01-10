<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ProductionTracking.aspx.vb" Inherits="Integra.ProductionTracking" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Production Tracking</title>
 <link href= "../App_Themes/Blue/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

     <table>
    <tr>
    <td>
      <asp:Label ID="vv" CssClass="labelNew" Text="PO No." runat="server" ></asp:Label>    
    </td>
    <td>
        <asp:Label ID="lblPONO" CssClass="labelNew"  runat="server" ></asp:Label>    
    </td>
    <td> </td>
    <td>

 <asp:Label ID="Label1" runat="server" CssClass="labelNew" Text="Supplier:" ></asp:Label>   
    </td>
      <td>
        <asp:Label ID="lblSupplier" CssClass="labelNew"  runat="server" ></asp:Label>    
    </td>
    </tr>
    <tr>
        <td>

 <asp:Label ID="Label2" runat="server" CssClass="labelNew" Text="Customer:" ></asp:Label>   
    </td>
      <td>
        <asp:Label ID="lblCustomer" CssClass="labelNew"  runat="server" ></asp:Label>    
    </td><td></td>
           <td>

 <asp:Label ID="Label3" runat="server" CssClass="labelNew" Text="Shipment:" ></asp:Label>   
    </td>
      <td>
        <asp:Label ID="lblShipment" CssClass="labelNew"  runat="server" ></asp:Label>    
    </td>
    </tr>
 
        <tr>
        <td>

 <asp:Label ID="Label4" runat="server" CssClass="labelNew" Text="Dept:" ></asp:Label>   
    </td>
      <td>
        <asp:Label ID="lblEknumber" CssClass="labelNew"  runat="server" ></asp:Label>    
    </td><td></td>
           <td>

 <asp:Label ID="Label5" runat="server" CssClass="labelNew"  Text="Season:" ></asp:Label>   
    </td>
      <td>
        <asp:Label ID="lblSeason"  CssClass="labelNew"  runat="server" ></asp:Label>    
    </td>
    </tr>
       <tr>
        <td>
        <asp:Label ID="Label6" runat="server" CssClass="labelNew"  Text="PO Qty:" ></asp:Label>   
 </td>
      <td>
                 <asp:Label ID="lblPOQty"   CssClass="labelNew"  runat="server" ></asp:Label>    
          
          </td><td></td>
    <td>&nbsp;</td><td>
        <asp:Label ID="lblPORefNo" Visible="false" CssClass="labelNew"  runat="server" ></asp:Label>    
           </td>
    </tr>
     </table>
     <table width="100%">
     <tr>
     <td>
     <telerik:RadGrid ID="dgSelecttion" runat="server" CellSpacing="0" 
                AutoGenerateColumns="false"  Skin="WebBlue"  
                Visible="False" PageSize="50">
            <MasterTableView>
            <Columns>
             <telerik:GridBoundColumn HeaderText="WIPProcessID" DataField="WIPProcessID" Display="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="2%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Process Route" DataField="ProcessName">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
              <telerik:GridTemplateColumn HeaderText="Estimated Date">
            <ItemTemplate>
                 <asp:Label id="lblEstimatedDate" runat="server"></asp:Label>	
            </ItemTemplate>
                <HeaderStyle Width="15%" HorizontalAlign="Left" />
             </telerik:GridTemplateColumn>
           <telerik:GridTemplateColumn HeaderText="Last Update">
            <ItemTemplate>
                 <asp:Label id="lblProcessStage" runat="server"></asp:Label>	
            </ItemTemplate>
                <HeaderStyle Width="15%" HorizontalAlign="Left" />
             </telerik:GridTemplateColumn>
              <telerik:GridTemplateColumn HeaderText="Yield" Visible="false">
            <ItemTemplate>
                 <asp:Label id="lblYield" runat="server"></asp:Label>						
            </ItemTemplate>
                <HeaderStyle Width="15%" HorizontalAlign="Left" />
             </telerik:GridTemplateColumn>     
           
         </Columns>
            </MasterTableView>
            <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="false">
                                <Selecting AllowRowSelect="true" EnableDragToSelectRows="false" />
                            </ClientSettings>
            </telerik:RadGrid>
     </td>
     </tr>
     </table>
    </form>
</body>
</html>
