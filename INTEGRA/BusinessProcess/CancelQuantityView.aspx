<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="CancelQuantityView.aspx.vb" Inherits="Integra.CancelQuantityView" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
<table width="100%">
<tr>
<td valign="top" >
<SMART:SMARTDATAGRID id="DgSeach" runat="server" width="100%" OnSortCommand="SortByColumn" OnPageIndexChanged="PageChanged"
							OnItemDataBound="DataBound" AllowPaging="True" AllowSorting="True"  AutoGenerateColumns="False" CellPadding="4" CssClass="table" PagerCurrentPageCssClass="" PagerOtherPageCssClass=""   ShowFooter="false" SortedAscending="yes" ForeColor="white" GridLines="None">
							<COLUMNS>
								 
								<ASP:TEMPLATECOLUMN HeaderText="Vendor">
                                    <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
                                    <asp:DropDownList ID="cmbVendor" width="130" OnSelectedIndexChanged="getRecord"  runat="server" AutoPostBack="true"   >
                                    </asp:DropDownList>
                                    </ITEMTEMPLATE>
                                    <headerstyle width="10%" />
								</ASP:TEMPLATECOLUMN>
						 		</COLUMNS>
                     	   <PagerStyle  HorizontalAlign="NotSet"   Visible="false" />
                          </SMART:SMARTDATAGRID>
</td>
</tr>

<tr><td>
	<SMART:SMARTDATAGRID id="dgPurchaseOrder" runat="server" width="100%" OnSortCommand="SortByColumn" OnPageIndexChanged="PageChanged"
							OnItemDataBound="DataBound" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table" PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="15" RecordCount="0" ShowFooter="True" SortedAscending="yes" ForeColor="white" GridLines="both">
							<COLUMNS>
							<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="POID"
								  DataField="POID" visible="false" >
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="PO. No."
								  DataField="PONO" >
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
					 					 
								<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="Customer"
									  DataField="Customer" >
								 <headerstyle width="15%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Vendor"
									  DataField="Vendor" >
								 <headerstyle width="15%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="Placement"
								  DataField="PlacementDate" >
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Shipment"
								  DataField="ShipmentDate">
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Booked Qty"
								  DataField="BookedQty">
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Shipped Qty"
								  DataField="ShippedQty">
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
				 
						  
									<ASP:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="Cancel Qty">
									<ITEMTEMPLATE>
										<asp:HyperLink id=lnkCancelQTY Enabled =true NavigateUrl='<%# "CancelQuantityNew.aspx?lPOId=" &amp; DataBinder.Eval(Container.DataItem,"POId")%>' Runat="server">
											Cancel QTY
										</asp:HyperLink>
									</ITEMTEMPLATE>
								</ASP:TEMPLATECOLUMN>
								
							</COLUMNS>
							<PagerStyle  HorizontalAlign="NotSet"    />
						</SMART:SMARTDATAGRID></td>
</tr>
</table>
 
</asp:Content>
