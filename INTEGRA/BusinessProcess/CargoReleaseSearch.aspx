<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="CargoReleaseSearch.aspx.vb" Inherits="Integra.CargoReleaseSearch" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%">
<tr><td style="height:20px;"></td></tr>
<tr> <td  style=" height: 20px;">
Report Type :
        </td>
<td  align="left">

<asp:DropDownList ID="cmbReportType" runat="server" AutoPostBack="true" CssClass="textbox"  >
<asp:ListItem>Select..</asp:ListItem>
<asp:ListItem>Customer Vise</asp:ListItem>
<asp:ListItem>Supplier Vise</asp:ListItem> 
<asp:ListItem>PO Number Vise</asp:ListItem> 
</asp:DropDownList>
</td> 
</tr>
<tr><td   align="center">
<asp:Label ID="lblCustomer" runat="server" Text="Customer:"></asp:Label>
<asp:Label ID="lblSupplier" runat="server" Text="Supplier:"></asp:Label>
</td> <td>

  <asp:DropDownList ID="cmbBuyerWise" runat="server" AutoPostBack="True">
  </asp:DropDownList>
   <asp:DropDownList ID="cmbSupplier" runat="server" AutoPostBack="True">
  </asp:DropDownList>
</td><td>
<asp:button id="btnSearch" runat="server" CssClass="button" Text="Search" width="100"></asp:button>
</td></tr>
<tr>
<td class="NormalBoldText" align="center">
 </td> <td>

 
</td><td>

</td>
</tr>
</table>
<table width="100%">
<tr><td style="height:20px;" >
    <asp:Label ID="lblMsg" CssClass="ErrorMsg"  runat="server"  Text="Record Not Found!!!!"></asp:Label>
</td></tr>

<tr><td align="left" valign="top">
<table width="100%">
<tr><td>
	<SMART:SMARTDATAGRID id="dgCagro" runat="server" width="100%" OnSortCommand="SortByColumn" OnPageIndexChanged="PageChanged"
							OnItemDataBound="DataBound" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table" PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="15" RecordCount="0" ShowFooter="True" SortedAscending="yes" ForeColor="white" GridLines="Both">
							<COLUMNS>
							<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="Shipment NO"
									SortExpression="CargoID" DataField="CargoID"  visible="False">
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
	<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="Customer"
									SortExpression="CustomerName" DataField="CustomerName"  >
								 <headerstyle width="15%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="Supplier"
									SortExpression="vendername" DataField="vendername"  >
								 <headerstyle width="15%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="Invoice NO"
									SortExpression="InvoiceNo" DataField="InvoiceNo"  >
								 <headerstyle width="15%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="Shipment Date[ETD]"
									SortExpression="InvoiceDateF" DataField="InvoiceDateF" >
								 <headerstyle width="15%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
						
								<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="Mode"
									SortExpression="Terms" DataField="Terms"  >
								 <headerstyle width="15%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
							<ASP:TEMPLATECOLUMN HeaderText="View">
                                    <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
<asp:HyperLink id="lnkEdit" Runat="server" NavigateUrl='<%# "CargoReleaseNew.aspx?IcargoID=" &amp; DataBinder.Eval(Container.DataItem,"CargoID")%>' Enabled="true">
											View
										</asp:HyperLink> 
</ITEMTEMPLATE>
                                    <headerstyle width="10%" />
								</ASP:TEMPLATECOLUMN>
						
								
													</COLUMNS>
							<PagerStyle  HorizontalAlign="NotSet"    />
						</SMART:SMARTDATAGRID></td>
</tr>
</table>
</td></tr>


</table>
</asp:Content>
