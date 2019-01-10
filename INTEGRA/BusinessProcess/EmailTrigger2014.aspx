<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeBehind="EmailTrigger2014.aspx.vb" Inherits="Integra.EmailTrigger2014" %>
 <%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%">
<tr>
<td>
 
</td>
</tr>
<tr>
<td>
   <telerik:RadButton ID="btnFabricCuttingYarnMail" runat="server" Text="1- Daily Open Order Alert"  Skin="WebBlue">
                    </telerik:RadButton>
</td>
<td>
   <telerik:RadButton ID="btnNeworRepeatOrder" runat="server" Text="2- New or Repeat Order Alert"  Skin="WebBlue">
                    </telerik:RadButton>
</td>
<td>
   <telerik:RadButton ID="btnInspection" runat="server" Text="3- Pass or Fail Inspection Alert"  Skin="WebBlue">
                    </telerik:RadButton>
</td>
</tr>
<tr>
<td>
   <telerik:RadButton ID="btnNoCertificate" runat="server" Text="4-No Supplier Certificate in System Alert"  Skin="WebBlue">
                    </telerik:RadButton>
</td>
<td>
   <telerik:RadButton ID="btnVAF" runat="server" Text="5-VAF Alert"  Skin="WebBlue">
                    </telerik:RadButton>
</td>
<td>
   <telerik:RadButton ID="btnInspectionRoster" runat="server" Text="6-Inspection Roster"  Skin="WebBlue">
                    </telerik:RadButton>
</td>
</tr>
<tr>
<td>
   <telerik:RadButton ID="btnWeeklySamplingPass" runat="server" Text="7-Weekly Sampling Pass"  Skin="WebBlue">
                    </telerik:RadButton>
</td>
<td>
   <telerik:RadButton ID="btnWeeklySamplingFail" runat="server" Text="8-Weekly Sampling Fail"  Skin="WebBlue">
                    </telerik:RadButton>
</td>
<td>
   <telerik:RadButton ID="btnCuttingApproval" runat="server" Text="9-Cutting Approval"  Skin="WebBlue">
                    </telerik:RadButton>
</td>
</tr>
<tr>
<td>
 <telerik:RadButton ID="btninlineinspection" runat="server" Text="10-inline inspection Alert"  Skin="WebBlue">
                    </telerik:RadButton>
</td>
<td>
 <telerik:RadButton ID="btn2inlineinspection" runat="server" Text="11-2nd inline inspection Alert"  Skin="WebBlue">
                    </telerik:RadButton>
</td>
<td>
 <telerik:RadButton ID="btnFinalInspectionPlanning" runat="server" Text="12-Final Inspection Planning"  Skin="WebBlue">
                    </telerik:RadButton>
</td>
</tr>
<tr>
<td>
 <telerik:RadButton ID="btnokaytoship" runat="server" Text="13-okay to ship"  Skin="WebBlue">
                    </telerik:RadButton>
</td>
<td>
 <telerik:RadButton ID="btnCloseOrders" runat="server" Text="14-Close Orders"  Skin="WebBlue">
                    </telerik:RadButton>
</td>
</tr>
</table>
<table width="100%">
<tr>
<td>
<asp:GridView ID="dgOpenOrder" runat="server" AutoGenerateColumns="False" 
   CellPadding="4" Font-Size="Small" ForeColor="#333333" GridLines="both">
    <COLUMNS>
                               <asp:TemplateField HeaderText="S.No." >
                               <ItemTemplate>    
                                   <%# CType(Container, GridViewRow).RowIndex + 1 %>
                               </ItemTemplate>
                                  <itemstyle horizontalalign="Center" />
                                <headerstyle width="5%" horizontalalign="Center"  />
                            </asp:TemplateField>
								<ASP:BoundField HeaderText="PO No."
									 DataField="PONO" >
                                    <itemstyle horizontalalign="Center" />
								 <headerstyle width="10%" horizontalalign="Center"  />
							</ASP:BoundField>
                                  <ASP:BoundField HeaderText="Type"
									DataField="Potype" >
                                    <itemstyle horizontalalign="Center" />
								 <headerstyle width="5%" horizontalalign="Center"  />
							</ASP:BoundField>
								<ASP:BoundField HeaderText="Customer"
									 DataField="CustomerName" >
                                    <itemstyle horizontalalign="Center" />
								 <headerstyle width="10%" horizontalalign="Center"  />
							</ASP:BoundField>
									<ASP:BoundField HeaderText="Supplier"
									DataField="VenderName" >
                                    <itemstyle horizontalalign="Center" />
								 <headerstyle width="10%" horizontalalign="Center"  />
							</ASP:BoundField>
                      
                                  <ASP:BoundField HeaderText="Lead Time"
									DataField="timespame" >
                                    <itemstyle horizontalalign="Center" />
								 <headerstyle width="5%" horizontalalign="Center"  />
							</ASP:BoundField>
							<ASP:BoundField HeaderText="Quantity"
									 DataField="Quantity" >
                                    <itemstyle horizontalalign="Center" />
								 <headerstyle width="10%" horizontalalign="Center"  />
							</ASP:BoundField>
							<ASP:BoundField HeaderText="Value"
									 DataField="Value" >
                                    <itemstyle horizontalalign="Center" />
								 <headerstyle width="10%" horizontalalign="Center"  />
							</ASP:BoundField>
							<ASP:BoundField HeaderText="Placement"
									 DataField="PlacementDate" >
                                    <itemstyle horizontalalign="Center" />
								 <headerstyle width="10%" horizontalalign="Center"  />
							</ASP:BoundField>
							<ASP:BoundField HeaderText="Shipment"
									 DataField="ShipmentDate" >
                                    <itemstyle horizontalalign="Center" />
								 <headerstyle width="10%" horizontalalign="Center"  />
							</ASP:BoundField>			
								<ASP:BoundField HeaderText="Merchant"
									 DataField="userName" >
                                    <itemstyle horizontalalign="Center" />
								 <headerstyle width="10%" horizontalalign="Center"  />
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
<asp:GridView ID="dgInspectionAlert" runat="server" AutoGenerateColumns="False" 
   CellPadding="4" Font-Size="Small" ForeColor="#333333" GridLines="both">
    <COLUMNS>
                               <asp:TemplateField HeaderText="S.No." >
                               <ItemTemplate>    
                                   <%# CType(Container, GridViewRow).RowIndex + 1 %>
                               </ItemTemplate>
                                <headerstyle width="5%" horizontalalign="Left"  />
                            </asp:TemplateField>
                            	<ASP:BoundField HeaderText="PO No."
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
									 DataField="Vendername" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
                           	<ASP:BoundField HeaderText="Activity Date"
									 DataField="CreationDate" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
                                 	<ASP:BoundField HeaderText="Style No"
									 DataField="styleNo" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
                                 	<ASP:BoundField HeaderText="Article"
									 DataField="Article" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
								<ASP:BoundField HeaderText="QD Name"
									 DataField="Username" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
									<ASP:BoundField HeaderText="Insp. Date"
									DataField="InspectionDate" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
                            <ASP:BoundField HeaderText="Insp. Qty"
									DataField="InspectedQty" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="5%" horizontalalign="Left"  />
							</ASP:BoundField>
                                  <ASP:BoundField HeaderText="Insp. Type"
									DataField="InspectionStatus" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="5%" horizontalalign="Left"  />
							</ASP:BoundField>
							<ASP:BoundField HeaderText="Insp. Status"
									 DataField="InspStatus" >
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
<asp:GridView ID="dgInspectionRoster" runat="server" AutoGenerateColumns="False" 
   CellPadding="4" Font-Size="Small" ForeColor="#333333" GridLines="both">
    <COLUMNS>
                               <asp:TemplateField HeaderText="S.No." >
                               <ItemTemplate>    
                                   <%# CType(Container, GridViewRow).RowIndex + 1 %>
                               </ItemTemplate>
                                <headerstyle width="5%" horizontalalign="Left"  />
                            </asp:TemplateField>
                            	<ASP:BoundField HeaderText="Month"
									 DataField="InspMonth" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
                            	<ASP:BoundField HeaderText="Inspection Week"
									 DataField="ProcessWeekNo" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
                            	<ASP:BoundField HeaderText="Proposed Insp. Date"
									 DataField="InspDate" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
                           	<ASP:BoundField HeaderText="ICR" Visible="false"
									 DataField="ICR" >
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
								<ASP:BoundField HeaderText="Merchant"
									 DataField="UserName" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
									<ASP:BoundField HeaderText="PO No."
									DataField="PONO" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
                            <ASP:BoundField HeaderText="Placement"
									DataField="PlacementDate" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="5%" horizontalalign="Left"  />
							</ASP:BoundField>
                                  <ASP:BoundField HeaderText="Shipment"
									DataField="Shipmentdate" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="5%" horizontalalign="Left"  />
							</ASP:BoundField>
							<ASP:BoundField HeaderText="PO Qty"
									 DataField="POQuantity" >
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
<asp:GridView ID="dgWeeklySamplingPass" runat="server" AutoGenerateColumns="False" 
   CellPadding="4" Font-Size="Small" ForeColor="#333333" GridLines="both">
    <COLUMNS>
                               <asp:TemplateField HeaderText="S.No." >
                               <ItemTemplate>    
                                   <%# CType(Container, GridViewRow).RowIndex + 1 %>
                               </ItemTemplate>
                                <headerstyle width="5%" horizontalalign="Left"  />
                            </asp:TemplateField>
                            	<ASP:BoundField HeaderText="PD"
									 DataField="PD" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
                            	<ASP:BoundField HeaderText="Date"
									 DataField="EntryDatee" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
                            	<ASP:BoundField HeaderText="Customer"
									 DataField="CustomerName" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
                           	<ASP:BoundField HeaderText="Supplier"
									 DataField="SupplierName" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
                                 	<ASP:BoundField HeaderText="B/M"
									 DataField="UserName" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
                                 	<ASP:BoundField HeaderText="Style No"
									 DataField="StyleNo" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
								<ASP:BoundField HeaderText="Pcs"
									 DataField="NoOfPieces" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
									<ASP:BoundField HeaderText="Type of Sampling"
									DataField="TypeName" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BoundField>
                            <ASP:BoundField HeaderText="Status"
									DataField="Status" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="5%" horizontalalign="Left"  />
							</ASP:BoundField>
                                  <ASP:BoundField HeaderText="Progress"
									DataField="Progress" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="5%" horizontalalign="Left"  />
							</ASP:BoundField>
							<ASP:BoundField HeaderText="Submission"
									 DataField="Submission" >
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
<asp:GridView ID="dgCuttingApproved" runat="server" AutoGenerateColumns="False" 
   CellPadding="4" Font-Size="Small" ForeColor="#333333" GridLines="both">
    <COLUMNS>
                               <asp:TemplateField HeaderText="S.No." >
                               <ItemTemplate>    
                                   <%# CType(Container, GridViewRow).RowIndex + 1 %>
                               </ItemTemplate>
                               <itemstyle horizontalalign="Center" />
                                <headerstyle width="5%" horizontalalign="Center"  />
                            </asp:TemplateField>
							
								<ASP:BoundField HeaderText="Customer"
									 DataField="CustomerName" >
                                    <itemstyle horizontalalign="Center" />
								 <headerstyle width="10%" horizontalalign="Center"  />
							</ASP:BoundField>
									<ASP:BoundField HeaderText="Supplier"
									DataField="VenderName" >
                                    <itemstyle horizontalalign="Center" />
								 <headerstyle width="10%" horizontalalign="Center"  />
							</ASP:BoundField>
                            	<ASP:BoundField HeaderText="Merchant"
									 DataField="userName" >
                                    <itemstyle horizontalalign="Center" />
								 <headerstyle width="10%" horizontalalign="Center"  />
							</ASP:BoundField>	
                            	<ASP:BoundField HeaderText="PO No."
									 DataField="PONO" >
                                    <itemstyle horizontalalign="Center" />
								 <headerstyle width="10%" horizontalalign="Center"  />
							</ASP:BoundField>
                             <ASP:BoundField HeaderText="Style No"
									DataField="StyleNo" >
                                    <itemstyle horizontalalign="Center" />
								 <headerstyle width="5%" horizontalalign="Center"  />
							</ASP:BoundField>
                            <ASP:BoundField HeaderText="Quantity"
									 DataField="Quantity" >
                                    <itemstyle horizontalalign="Center" />
								 <headerstyle width="10%" horizontalalign="Center"  />
							</ASP:BoundField>
                            <ASP:BoundField HeaderText="Type"
									DataField="Potype" >
                                    <itemstyle horizontalalign="Center" />
								 <headerstyle width="5%" horizontalalign="Center"  />
							</ASP:BoundField>
                             	<ASP:BoundField HeaderText="Shipment"
									 DataField="ShipmentDate" >
                                    <itemstyle horizontalalign="Center" />
								 <headerstyle width="10%" horizontalalign="Center"  />
							</ASP:BoundField>

                                  <ASP:BoundField HeaderText="Lead Time" Visible="false"
									DataField="timespame" >
                                    <itemstyle horizontalalign="Center" />
								 <headerstyle width="5%" horizontalalign="Center"  />
							</ASP:BoundField>
							
							<ASP:BoundField HeaderText="Value"  Visible="false"
									 DataField="Value" >
                                    <itemstyle horizontalalign="Center" />
								 <headerstyle width="10%" horizontalalign="Center"  />
							</ASP:BoundField>
							<ASP:BoundField HeaderText="Placement" Visible="false"
									 DataField="PlacementDate" >
                                    <itemstyle horizontalalign="Center" />
								 <headerstyle width="10%" horizontalalign="Center"  />
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
