<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="CancelQuantityNew.aspx.vb" Inherits="Integra.CancelQuantityNew" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%">
<tr><td><asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Names="Calibri"></asp:Label> </td></tr>
 
<tr><td align="left" valign="top">
<table width="100%">
 <tr>
<td>
<SMART:SMARTDATAGRID id="dgPOArticle" runat="server" width="100%" 	OnItemDataBound="DataBound" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"  PageSize="5" RecordCount="0" ShowFooter="True"  ForeColor="white" GridLines="both">
							<COLUMNS>
							<ASP:BOUNDCOLUMN HeaderText="POID"
								  DataField="POID" visible="False" >
                                <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
							
								<ASP:BOUNDCOLUMN HeaderText="PO. No."
								  DataField="PONO" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
					 					 
								<ASP:BOUNDCOLUMN HeaderText="Customer"
									  DataField="Customer" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="15%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN HeaderText="Supplier"
									  DataField="Vendor" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="15%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>		
								<ASP:BOUNDCOLUMN HeaderText="Placement" 
								  DataField="PlacementDate" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN HeaderText="Shipment"
								  DataField="ShipmentDate">
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
												                 	                       				
							</COLUMNS>
							<PagerStyle CssClass="GridPagerStyle" Mode="NumericPages" HorizontalAlign="Right"    />
    <AlternatingItemStyle CssClass="GridAlternativeRow" />
    <ItemStyle CssClass="GridRow" />
    <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
						</SMART:SMARTDATAGRID>
</td>
</tr>

<tr >
<td style="width: 797px" align="right">
<asp:Button CssClass="button" ID="btnSave" runat="server" Text="Save All in 1 Go!" Width="128px" />
</td>
</tr>

<tr>
<td>
<SMART:SMARTDATAGRID id="dgPurchaseOrder" runat="server" width="100%" 	OnItemDataBound="DataBound" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"  PageSize="50" RecordCount="0" ShowFooter="True"  ForeColor="white" GridLines="both">
							<COLUMNS>
							<ASP:BOUNDCOLUMN HeaderText="POID"
								  DataField="POID" visible="False" >
                                <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
							<ASP:BOUNDCOLUMN HeaderText="PODetailID"
								  DataField="PODetailID" visible="False" >
                                <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN HeaderText="PO. No." Visible="False"
								  DataField="PONO" >
                                    <itemstyle horizontalalign="Left"  />
								 <headerstyle width="10%" horizontalalign="Left"   />
							</ASP:BOUNDCOLUMN>
					 					 
								<ASP:BOUNDCOLUMN HeaderText="Customer" Visible="False"
									  DataField="Customer" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="15%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN HeaderText="Vendor" Visible="False"
									  DataField="Vendor" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="15%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN HeaderText="Style No"
									  DataField="StyleNo" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="15%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
							<ASP:BOUNDCOLUMN HeaderText="Article"
									  DataField="Article" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="15%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
						
							<ASP:BOUNDCOLUMN HeaderText="Colorway"
									  DataField="Colorway"   >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="15%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
							<ASP:BOUNDCOLUMN HeaderText="Size"
									  DataField="Size"  >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="15%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
						 <ASP:BOUNDCOLUMN HeaderText="Booked Qty"
								  DataField="BookedQty">
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN HeaderText="Shipped Qty"
								  DataField="ShippedQty">
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
							 <ASP:BOUNDCOLUMN HeaderText="Cancel Qty"
								  DataField="CancelQTY">
                     <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
							<ASP:BOUNDCOLUMN HeaderText="Differnce"
									  DataField="Differenc"  >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>	
				<ASP:TEMPLATECOLUMN  HeaderText="To be cancel">
                                                                <itemstyle horizontalalign="Center" />
									                        <ITEMTEMPLATE>
<asp:textbox id="txtCancelQuantity" runat="server" CssClass="textbox"
width="60" __designer:wfdid="w1" OnTextChanged="txtCancelQuantity_TextChanged" AutoPostBack="True" ></asp:textbox> 
</ITEMTEMPLATE>
                                                                <headerstyle width="10%" />
								                            </ASP:TEMPLATECOLUMN>
								                            <ASP:TEMPLATECOLUMN HeaderText="Select">
                                                                <itemstyle horizontalalign="Center" />
									                        <ITEMTEMPLATE>
										                  <asp:CheckBox ID="chkCancel" runat="server"></asp:CheckBox>
                                                                
</ITEMTEMPLATE>
                                                                <headerstyle width="10%" />
								                            </ASP:TEMPLATECOLUMN>	
								                           				
							</COLUMNS>
							<PagerStyle CssClass="GridPagerStyle" Mode="NumericPages" HorizontalAlign="Right"    />
    <AlternatingItemStyle CssClass="GridAlternativeRow" />
    <ItemStyle CssClass="GridRow" />
    <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
						</SMART:SMARTDATAGRID>
</td>
</tr>
</table>

</td>
</tr>
</table>
</asp:Content>