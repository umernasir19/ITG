<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="POCloseStatusPopup.aspx.vb" Inherits="Integra.POCloseStatusPopup" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>PO Close Status Popup</title>
     <link href= "../App_Themes/Blue/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
  <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table  >
    <tr>
    <td class="labelNew">
    PO No.
    </td>
    <td class="labelNew">
        <asp:Label ID="lblPONO" runat="server" ></asp:Label>    
    </td>
    <td> </td>
    <td class="labelNew">
Supplier:
    </td>
      <td class="labelNew">
        <asp:Label ID="lblSupplier" runat="server" ></asp:Label>    
    </td>
    </tr>
    <tr>
        <td class="labelNew">
Customer:
    </td>
      <td class="labelNew">
        <asp:Label ID="lblCustomer" runat="server" ></asp:Label>    
    </td><td></td>
           <td class="labelNew">
Shipment:
    </td>
      <td class="labelNew">
        <asp:Label ID="lblShipment" runat="server" ></asp:Label>    
    </td>
    </tr>
     </table>
    <table width="100%">
    <tr>
        
    <td align="center">
        <asp:Label ID="lblMsg" runat="server" CssClass="ErrorMsg"  ></asp:Label>
    </td>
    </tr>
    <tr>
    <td align="right">
     <asp:Button ID="btnSave" runat="server"  CssClass="button" Text="Save My Selection(s)" Width="134px" />
    </td>
    </tr>
    <tr>
    <td>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <ContentTemplate>
     	<SMART:SMARTDATAGRID id="dgPurchaseOrder" runat="server" width="100%" OnSortCommand="SortByColumn"
	 OnPageIndexChanged="PageChanged" OnItemDataBound="DataBound" AllowPaging="True" AllowSorting="True"
	  AutoGenerateColumns="False" CellPadding="4" CssClass="table" PagerCurrentPageCssClass=""
	   PagerOtherPageCssClass="" PageSize="100" RecordCount="0" ShowFooter="True" SortedAscending="yes"
	    ForeColor="white" GridLines="Both"  >
 					
							<COLUMNS>
							<ASP:BOUNDCOLUMN HeaderText="POID"
									SortExpression="POID" DataField="POID" visible="False" >
                                <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
							<ASP:BOUNDCOLUMN HeaderText="PoDetailID"
									SortExpression="PoDetailID" DataField="PoDetailID" visible="False" >
                                <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
							
				         	<ASP:BOUNDCOLUMN HeaderText="Style No."
									 DataField="styleNo">
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
								
								<ASP:BOUNDCOLUMN HeaderText="Article"
									 DataField="article">
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN HeaderText="Size"
									 DataField="SizeRange">
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN HeaderText="Color"
									 DataField="Colorway">
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
							 <ASP:BOUNDCOLUMN HeaderText="Booked Qty"
									 DataField="BookedQty">
                                    <itemstyle horizontalalign="Center" />
								 <headerstyle width="5%" horizontalalign="Center"  />
							</ASP:BOUNDCOLUMN>
                            <ASP:BOUNDCOLUMN HeaderText="Shipped Qty"
									 DataField="ShippedQty">
                                    <itemstyle horizontalalign="Center" />
								 <headerstyle width="5%" horizontalalign="Center"  />
							</ASP:BOUNDCOLUMN>
                            <ASP:BOUNDCOLUMN HeaderText="Diff."
									 DataField="Difference">
                                    <itemstyle horizontalalign="Center" />
								 <headerstyle width="5%" horizontalalign="Center"  />
							</ASP:BOUNDCOLUMN>
                            <ASP:TEMPLATECOLUMN HeaderText="Diff.">
                                    <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
                                   <asp:TextBox ID="txtDifference" CssClass="textbox" Text='<% #Eval("Difference") %>'   Width="50px" runat="server"></asp:TextBox>                                    
                                    </ITEMTEMPLATE>
                                    <headerstyle width="05%" />
								</ASP:TEMPLATECOLUMN>
                             <ASP:BOUNDCOLUMN HeaderText="Article Status"
									 DataField="ArticleStatus">
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
                              <ASP:BOUNDCOLUMN HeaderText="Cancel Qty"
									 DataField="CancelQty">
                                    <itemstyle horizontalalign="Center" />
								 <headerstyle width="5%" horizontalalign="Center"  />
							</ASP:BOUNDCOLUMN>
								</COLUMNS>
		 <PagerStyle CssClass="GridPagerStyle" Mode="NumericPages" HorizontalAlign="Right"    />
	        <AlternatingItemStyle CssClass="GridAlternativeRow" />
        <ItemStyle CssClass="GridRow" />
        <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                                                  
						</SMART:SMARTDATAGRID>

      </ContentTemplate>
    </asp:UpdatePanel>
       </td>
    </tr>
    </table>

    </form>
</body>
</html>
