<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="QRCodeMGT.aspx.vb" Inherits="Integra.QRCodeMGT" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PO Tracking</title>
        <link href= "../App_Themes/Blue/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
    <tr>
    <td>
    
     <asp:Label ID="Label1" CssClass="labelNew" Text="PO No." runat="server" ></asp:Label>
         </td>
    <td>
        <asp:Label ID="lblPONO" CssClass="labelNew" runat="server" ></asp:Label>    
    </td>
    <td> </td>
    <td>

     <asp:Label ID="Label2" CssClass="labelNew" Text="Supplier:" runat="server" ></asp:Label>
    </td>
      <td>
        <asp:Label ID="lblSupplier" CssClass="labelNew" runat="server" ></asp:Label>    
    </td>
    </tr>
    <tr>
        <td>

<asp:Label ID="Label3" CssClass="labelNew" Text="Customer:" runat="server" ></asp:Label>
    </td>
      <td>
        <asp:Label ID="lblCustomer" CssClass="labelNew" runat="server" ></asp:Label>    
    </td><td></td>
           <td>

<asp:Label ID="Label4" CssClass="labelNew" Text="Shipment:" runat="server" ></asp:Label>
    </td>
      <td>
        <asp:Label ID="lblShipment" CssClass="labelNew" runat="server" ></asp:Label>    
    </td>
    </tr>
    <tr>
   <td>

<asp:Label ID="Label5" CssClass="labelNew" Text="No. of Article:" runat="server" ></asp:Label>
    </td>
      <td>
        <asp:Label ID="lblNoOfArticle" CssClass="labelNew" runat="server" ></asp:Label>    
    </td>
    
    </tr>
        <tr>
   <td>

<asp:Label ID="Label6" CssClass="labelNew" Text="Po Quantity:" runat="server" ></asp:Label>
    </td>
      <td>
        <asp:Label ID="lblPoQuantity" CssClass="labelNew" runat="server" ></asp:Label>    
    </td>    
    </tr>
    </table>
    <table>
    <tr>
    <td >
      
       <asp:Label ID="Label7" CssClass="labelNew" Font-Bold="true" Text="Tracking Result:" runat="server" ></asp:Label>
    </td>
    </tr>
    
    <tr>
    <td>
 
 <SMART:SMARTDATAGRID id="dgPurchaseOrder" runat="server" width="100%" OnSortCommand="SortByColumn"
	 OnPageIndexChanged="PageChanged" OnItemDataBound="DataBound" AllowPaging="false" AllowSorting="True"
	  AutoGenerateColumns="False" CellPadding="4" CssClass="table" PagerCurrentPageCssClass=""
	   PagerOtherPageCssClass="" PageSize="100" RecordCount="0" ShowFooter="false" SortedAscending="yes"
	    ForeColor="white" GridLines="Both"  >
 					
							<COLUMNS>
	 
							 <ASP:BOUNDCOLUMN HeaderText="Date"
									 DataField="ActivityDate">
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="20%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
								
								<ASP:BOUNDCOLUMN HeaderText="Status"
									 DataField="TrackingObject">
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="20%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
								 
							 </COLUMNS>
		 <PagerStyle CssClass="GridPagerStyle" Mode="NumericPages" HorizontalAlign="Right"    />
	        <AlternatingItemStyle CssClass="GridAlternativeRow" />
        <ItemStyle CssClass="GridRow" />
        <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                                                  
						</SMART:SMARTDATAGRID>
 
    </td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
