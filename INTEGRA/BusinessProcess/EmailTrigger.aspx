<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeBehind="EmailTrigger.aspx.vb" Inherits="Integra.EmailTrigger" %>
 <%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table width="100&">
 <tr>
 <td>
   <telerik:RadButton ID="btnFabricCuttingYarnMail" runat="server" Text="Setp: 1 Fabric Cutting Yarn Mail Detail"  Skin="WebBlue">
                    </telerik:RadButton>
 
 </td>
  <td>
      <telerik:RadButton ID="btnFabricCuttingYarnMasterMail" runat="server"  Text="Setp: 2 Fabric Cutting Yarn Mail Master"  Skin="WebBlue">
                    </telerik:RadButton>
 </td>
   <td>
     <telerik:RadButton ID="btnWeekShipmentt" runat="server"  Text="Setp: 3 Week Shipment"  Skin="WebBlue">
                    </telerik:RadButton>
 
 </td>

 </tr>
 <tr>
   <td>
     <telerik:RadButton ID="btnSocail" runat="server"  Text="Setp: 4 Socail Compliance"  Skin="WebBlue">
                    </telerik:RadButton>
 
 </td>
    <td>
     <telerik:RadButton ID="btnSupplier" runat="server"  Text="Supplier Mail"  Skin="WebBlue">
                    </telerik:RadButton>
   
 </td>
   <td>
     <telerik:RadButton ID="btnRedAlert" runat="server"  Visible="true" Text="Red Alert Mail"  Skin="WebBlue">
                    </telerik:RadButton>
 
 </td>
 </tr>
 <tr>
 <td>
  <telerik:RadButton ID="btnShrmlaYarn" runat="server"  Text="Sharmila Yarn"  Skin="WebBlue">
                    </telerik:RadButton>
 </td>
  <td>
  <telerik:RadButton ID="btnShrmlaFabric" runat="server"    Text="Sharmila Fabric"  Skin="WebBlue">
                    </telerik:RadButton>
 </td>
  <td>
  <telerik:RadButton ID="btnShrmlaCutting" runat="server"   Text="Sharmila Cutting"  Skin="WebBlue">
                    </telerik:RadButton>
 </td>
 </tr>
 <tr>
 
  <td>
  <telerik:RadButton ID="btnTT" runat="server"   Text="5 Test"  Skin="WebBlue">
                    </telerik:RadButton>
 </td>
   <td>
  <telerik:RadButton ID="btnAutoWIP" runat="server"   Text="Auto Fill WIP"  Skin="WebBlue">
                    </telerik:RadButton>
 </td>
 </tr>
 <tr>
    <td>
  <telerik:RadButton ID="btnUpdateTNA" runat="server"   Text="Update TNA"  Skin="WebBlue">
                    </telerik:RadButton>
 </td>
     <td>
  <telerik:RadButton ID="btnBMMail" runat="server"   Text=" Fabric Cutting Yarn Mail B/M"  Skin="WebBlue">
                    </telerik:RadButton>
 </td>
   <td>
  <telerik:RadButton ID="btnUpdateRevisedShipment11" runat="server"   Text=" Revise Shipment"  Skin="WebBlue">
                    </telerik:RadButton>
 </td>
 </tr>
 <tr>
   <td>
  <telerik:RadButton ID="btnCP" runat="server"   Text="CP Celio"  Skin="WebBlue">
                    </telerik:RadButton>
 </td>
 </tr>
 </table>
 <table>
 <tr><td>
   <asp:GridView ID="dgPurchaseOrder" runat="server" AutoGenerateColumns="False" 
   CellPadding="4" Font-Size="Small" ForeColor="#333333" GridLines="both">
    <COLUMNS>
                               <asp:TemplateField HeaderText="S.No." >
                               <ItemTemplate>    
                                   <%# CType(Container, GridViewRow).RowIndex + 1%>
                               </ItemTemplate>
                            </asp:TemplateField>
								<ASP:BoundField HeaderText="PO. No."
									 DataField="PONO" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
								<ASP:BoundField HeaderText="Article #"
									 DataField="Article" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
								<ASP:BoundField HeaderText="Customer"
									 DataField="CustomerName" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
									<ASP:BoundField HeaderText="Supplier"
									DataField="VenderName" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
							<ASP:BoundField HeaderText="Quantity"
									 DataField="ArticleQTY" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
							<ASP:BoundField HeaderText="Value"
									 DataField="ArticleValue" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
							<ASP:BoundField HeaderText="Placement Date"
									 DataField="PlacementDatee" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
							<ASP:BoundField HeaderText="Shipment Date"
									 DataField="ShipmentDatee" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>			
								<ASP:BoundField HeaderText="Merchant"
									 DataField="userName" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>		
							</COLUMNS>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <EditRowStyle BackColor="#999999" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    
    
    </asp:GridView> 
</td>
</tr>
 <tr><td>
   <asp:GridView ID="dgPurchaseOrder1" runat="server" AutoGenerateColumns="False" 
   CellPadding="4" Font-Size="Small" ForeColor="#333333" GridLines="both">
    <COLUMNS>
                               <asp:TemplateField HeaderText="S.No." >
                                <headerstyle width="05%" horizontalalign="Center"  />
                               <ItemTemplate>    
                                   <%# CType(Container, GridViewRow).RowIndex + 1%>
                               </ItemTemplate>
                            </asp:TemplateField>
								<ASP:BoundField HeaderText="PO. No."
									 DataField="PONO" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
							 
								<ASP:BoundField HeaderText="Customer"
									 DataField="CustomerName" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
									<ASP:BoundField HeaderText="Supplier"
									DataField="VenderName" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
							<ASP:BoundField HeaderText="Qty"
									 DataField="Qty" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
							<ASP:BoundField HeaderText="Value"
									 DataField="Amount" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
							<ASP:BoundField HeaderText="Placement Date"
									 DataField="PlacementDatee" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
							<ASP:BoundField HeaderText="Shipment Date"
									 DataField="ShipmentDatee" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>			
								<ASP:BoundField HeaderText="Merchant"
									 DataField="userName" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>		
							</COLUMNS>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <EditRowStyle BackColor="#999999" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    
    
    </asp:GridView> 
</td>
</tr>
<tr>
<td>
    <asp:GridView ID="dgPurchaseOrder2" runat="server" AutoGenerateColumns="False" 
   CellPadding="4" Font-Size="Small" ForeColor="#333333" GridLines="both">
    <COLUMNS>
                               <asp:TemplateField HeaderText="S.No." >
                                <headerstyle width="05%" horizontalalign="Left"  />
                               <ItemTemplate>    
                                   <%# CType(Container, GridViewRow).RowIndex + 1%>
                               </ItemTemplate>
                            </asp:TemplateField>
								<ASP:BoundField HeaderText="Supplier"
									 DataField="Supplier" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
							 
								<ASP:BoundField HeaderText="Compliance"
									 DataField="Certificate" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
									<ASP:BoundField HeaderText="Validity"
									DataField="Validity" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
							<ASP:BoundField HeaderText="Status"
									 DataField="Status" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
							 	
							</COLUMNS>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <EditRowStyle BackColor="#999999" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    
    
    </asp:GridView>
</td>
</tr>
<tr><td>
   <asp:GridView ID="dgPurchaseOrderSupplier" runat="server" AutoGenerateColumns="False" 
   CellPadding="4" Font-Size="Small" ForeColor="#333333" GridLines="both">
    <COLUMNS>
                               <asp:TemplateField HeaderText="S.No." >
                                <headerstyle width="05%" horizontalalign="Left"  />
                               <ItemTemplate>    
                                   <%# CType(Container, GridViewRow).RowIndex + 1%>
                               </ItemTemplate>
                                 <itemstyle horizontalalign="Left" />
                            </asp:TemplateField>
								<ASP:BoundField HeaderText="PO. No."
									 DataField="PONO" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="5%" horizontalalign="Left"  />
							</ASP:BoundField>
							 
								<ASP:BoundField HeaderText="Customer"
									 DataField="CustomerName" Visible="false" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="5%" horizontalalign="Left"  />
							</ASP:BoundField>
									<ASP:BoundField HeaderText="Supplier"
									DataField="VenderName" Visible="false" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="5%" horizontalalign="Left"  />
							</ASP:BoundField>
                            	<ASP:BoundField HeaderText="ECP Merchant"
									 DataField="userName" Visible="false" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="5%" horizontalalign="Left"  />
							</ASP:BoundField>	
							<ASP:BoundField HeaderText="Qty"
									 DataField="Qty" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="5%" horizontalalign="Left"  />
							</ASP:BoundField>
							<ASP:BoundField HeaderText="Value"
									 DataField="Amount" Visible="false"  >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="5%" horizontalalign="Left"  />
							</ASP:BoundField>
							<ASP:BoundField HeaderText="Placement Date"
									 DataField="PlacementDatee"  >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="5%" horizontalalign="Left"  />
							</ASP:BoundField>
							<ASP:BoundField HeaderText="Shipment Date"
									 DataField="ShipmentDatee" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="5%" horizontalalign="Left"  />
							</ASP:BoundField>	
                            <ASP:BoundField HeaderText="No. of reminder(s)"
									 DataField="ReminderCount" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="5%" horizontalalign="Left"  />
							</ASP:BoundField>	
                        
								
							</COLUMNS>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <EditRowStyle BackColor="#999999" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    
    
    </asp:GridView> 
</td>
</tr>
<tr><td>
   <asp:GridView ID="dgRedAlert" runat="server" AutoGenerateColumns="False" 
   CellPadding="4" Font-Size="Small" ForeColor="#333333" GridLines="both">
    <COLUMNS>
                               <asp:TemplateField HeaderText="S.No." >
                                <headerstyle width="05%" horizontalalign="Center"  />
                               <ItemTemplate>    
                                   <%# CType(Container, GridViewRow).RowIndex + 1%>
                               </ItemTemplate>
                            </asp:TemplateField>
								<ASP:BoundField HeaderText="PO. No."
									 DataField="PONO" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
							 	<ASP:BoundField HeaderText="Supplier"
									DataField="VenderName"  >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
								<ASP:BoundField HeaderText="Customer"
									 DataField="CustomerName" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
								
                            	<ASP:BoundField HeaderText="Merchant"
									 DataField="userName" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>	
							<ASP:BoundField HeaderText="Qty"
									 DataField="Qty" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
							<ASP:BoundField HeaderText="Value"
									 DataField="Amount" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
							<ASP:BoundField HeaderText="Placement Date"
									 DataField="PlacementDatee" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
							<ASP:BoundField HeaderText="Shipment Date"
									 DataField="ShipmentDatee" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>	
                            <ASP:BoundField HeaderText="Reminder"
									 DataField="ReminderCount" >
                                    <itemstyle horizontalalign="Center" />
								 <headerstyle width="05%" horizontalalign="Center"  />
							</ASP:BoundField>	
                        
								
							</COLUMNS>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <EditRowStyle BackColor="#999999" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    
    
    </asp:GridView> 
</td>
</tr>
<tr><td>
   <asp:GridView ID="dgSupplierMailNew" runat="server" AutoGenerateColumns="False" 
   CellPadding="4" Font-Size="Small" ForeColor="#333333" GridLines="both">
    <COLUMNS>
                               <asp:TemplateField HeaderText="S.No." >
                                <headerstyle width="05%" horizontalalign="Center"  />
                               <ItemTemplate>    
                                   <%# CType(Container, GridViewRow).RowIndex + 1%>
                               </ItemTemplate>
                            </asp:TemplateField>
								<ASP:BoundField HeaderText="PO. No."
									 DataField="PONO" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
							 
								<ASP:BoundField HeaderText="Customer"
									 DataField="CustomerName" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
									<ASP:BoundField HeaderText="Supplier"
									DataField="VenderName" Visible="false" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
                            	<ASP:BoundField HeaderText="ECP Merchant"
									 DataField="userName" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>	
							<ASP:BoundField HeaderText="Qty"
									 DataField="Qty" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
							<ASP:BoundField HeaderText="Value"
									 DataField="Amount" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
							<ASP:BoundField HeaderText="Placement Date"
									 DataField="PlacementDatee" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
							<ASP:BoundField HeaderText="Shipment Date"
									 DataField="ShipmentDatee" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>	
                            <ASP:BoundField HeaderText="Delay Process"
									 DataField="Process" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>	
                        
								
							</COLUMNS>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <EditRowStyle BackColor="#999999" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    
    
    </asp:GridView> 
</td>
</tr>
<tr><td>
   <asp:GridView ID="dgSupplierzz" runat="server" AutoGenerateColumns="False" 
   CellPadding="4" Font-Size="Small" ForeColor="#333333" GridLines="both">
    <COLUMNS>
                               <asp:TemplateField HeaderText="" >
                                <headerstyle  horizontalalign="Center"  />
                               <ItemTemplate>    
                                   <asp:Label ID="lblCustomer" runat="server" Text='<%#Eval("Customer") %>' ></asp:Label>
                               </ItemTemplate>
                                <itemstyle Wrap="false" horizontalalign="Left" />
                            </asp:TemplateField>
								<ASP:BoundField HeaderText=""
									 DataField="orders" >
                                    <itemstyle Wrap="false" horizontalalign="Left" />
								 <headerstyle   horizontalalign="Left"  />
							</ASP:BoundField>
							 
								<ASP:BoundField HeaderText=""
									 DataField="Status" >
                                    <itemstyle Wrap="false" horizontalalign="Left" />
								 <headerstyle  horizontalalign="Left"  />
							</ASP:BoundField>
									 <asp:TemplateField HeaderText="" >
                                <headerstyle width="30%" horizontalalign="Center"  />
                               <ItemTemplate>    
                                   <asp:Label ID="frr" runat="server"  ></asp:Label>
                               </ItemTemplate>
                            </asp:TemplateField> 
								
							</COLUMNS>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <EditRowStyle BackColor="#999999" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    
    
    </asp:GridView> 
</td>
</tr>
 <tr><td>
   <asp:GridView ID="dgMerchant" runat="server" AutoGenerateColumns="False" 
   CellPadding="4" Font-Size="Small" ForeColor="#333333" GridLines="both">
    <COLUMNS>
                               <asp:TemplateField HeaderText="S.No." >
                                <headerstyle width="05%" horizontalalign="Left"  />
                               <ItemTemplate>    
                                   <%# CType(Container, GridViewRow).RowIndex + 1%>
                               </ItemTemplate>
                                 <itemstyle horizontalalign="Left" />
                            </asp:TemplateField>
                            <ASP:BoundField HeaderText="Supplier"
									DataField="VenderName" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
                            <ASP:BoundField HeaderText="Customer"
									 DataField="CustomerName" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
								<ASP:BoundField HeaderText="PO. No."
									 DataField="PONO" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
							 
								
									
							<ASP:BoundField HeaderText="Qty"
									 DataField="Qty" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
							<ASP:BoundField HeaderText="Value"
									 DataField="Amount"  Visible="false">
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
							<ASP:BoundField HeaderText="Placement Date"
									 DataField="PlacementDatee"  >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
							<ASP:BoundField HeaderText="Shipment Date"
									 DataField="ShipmentDatee" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>			
								<ASP:BoundField HeaderText="Merchant"
									 DataField="userName"  Visible="false">
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>		
							</COLUMNS>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <EditRowStyle BackColor="#999999" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    
    
    </asp:GridView> 
</td>
</tr>
 <tr><td>
   <asp:GridView ID="dgShrmla" runat="server" AutoGenerateColumns="False" 
   CellPadding="4" Font-Size="Small" ForeColor="#333333" GridLines="both">
    <COLUMNS>
                               <asp:TemplateField HeaderText="S.No." >
                                <headerstyle width="05%" horizontalalign="Left"  />
                               <ItemTemplate>    
                                   <%# CType(Container, GridViewRow).RowIndex + 1%>
                               </ItemTemplate>
                                 <itemstyle horizontalalign="Left" />
                            </asp:TemplateField>
                            <ASP:BoundField HeaderText="Supplier"
									DataField="VenderName" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
                            <ASP:BoundField HeaderText="Merchant"
									 DataField="UserName" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
								<ASP:BoundField HeaderText="PO. No."
									 DataField="PONO" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
							  <ASP:BoundField HeaderText="Placement Date"
									 DataField="PlacementDate"  >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
                            	<ASP:BoundField HeaderText="Quantity"
									 DataField="POQuantity" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
                            <ASP:BoundField HeaderText="Value"
									 DataField="BookedValue"  Visible="false">
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
							<ASP:BoundField HeaderText="Shipment Date"
									 DataField="Shipmentdate" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>		
						   
							</COLUMNS>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <EditRowStyle BackColor="#999999" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    
    
    </asp:GridView> 
</td>
</tr>
 </table>
 </asp:Content> 
