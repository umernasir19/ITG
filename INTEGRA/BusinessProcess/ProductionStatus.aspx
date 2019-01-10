<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ProductionStatus.aspx.vb" Inherits="Integra.ProductionStatus" %>
 <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table  width="100%">
   <tr>
    <td>
  <telerik:RadGrid ID="dgProductionStatus" runat="server" CellSpacing="0"  AutoGenerateColumns="false"  Skin="WebBlue"  Visible="true" PageSize="50">
            <MasterTableView>
           <Columns>            
 
           <telerik:GridBoundColumn HeaderText="Process" DataField="Process" AllowFiltering ="true"  FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                    FilterDelay="3000" ShowFilterIcon="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>      
            <telerik:GridBoundColumn HeaderText="Target" DataField="EstimatedDate" AllowFiltering ="true"  FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                    FilterDelay="3000" ShowFilterIcon="false">
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn>
             <telerik:GridBoundColumn HeaderText="Parameter" DataField="Parameter" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>  
             <telerik:GridBoundColumn HeaderText="Capacity/ Day" DataField="TotalCapacity" AllowFiltering ="true" FilterControlWidth="65px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                    FilterDelay="4000" ShowFilterIcon="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>    
              <telerik:GridBoundColumn HeaderText="Required" DataField="Required"  AllowFiltering ="false" Aggregate="Sum" FooterText=" " FooterStyle-Font-Bold="true" FooterStyle-Font-Names="Calibri">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>  
             <telerik:GridBoundColumn HeaderText="Yield" DataField="YieldQty" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>   
                <telerik:GridBoundColumn HeaderText="Balance" DataField="Balance" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>  
                            <telerik:GridBoundColumn HeaderText="Days Left" DataField="daysLeft" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn> 
                            <telerik:GridBoundColumn HeaderText="Status Delayed" DataField="Status" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn> 
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
    </form>
</body>
</html>
