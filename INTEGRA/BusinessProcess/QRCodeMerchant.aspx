<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="QRCodeMerchant.aspx.vb" Inherits="Integra.QRCodeMerchant" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Merchant QR Code -WIP Working Control Panel</title>
        <link href= "../App_Themes/Blue/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
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
        <asp:Label ID="lblSupplier"  CssClass="labelNew"  runat="server" ></asp:Label>    
    </td>
    </tr>
    <tr>
        <td>

  <asp:Label ID="Label3" CssClass="labelNew" Text="Customer:" runat="server" ></asp:Label>  
    </td>
      <td>
        <asp:Label ID="lblCustomer"  CssClass="labelNew"  runat="server" ></asp:Label>    
    </td><td></td>
           <td>

  <asp:Label ID="Label4" CssClass="labelNew" Text="Shipment:" runat="server" ></asp:Label>  
    </td>
      <td>
        <asp:Label ID="lblShipment"  CssClass="labelNew"  runat="server" ></asp:Label>    
    </td>
    </tr>
    </table>
    <table>
    <tr>
    <td align="center">
        <asp:Label ID="lblMsg" runat="server" CssClass="ErrorMsg"  ></asp:Label>
    </td>
    </tr>
    <tr>
    <td align="right">
     <asp:Button ID="Button1" runat="server"  CssClass="button" Text="Save My Selection(s)" Width="134px" />
    </td>
    </tr>
    <tr>
    <td>
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
 <ContentTemplate>
 <SMART:SMARTDATAGRID id="dgPurchaseOrder" runat="server" width="100%" OnSortCommand="SortByColumn"
	 OnPageIndexChanged="PageChanged" OnItemDataBound="DataBound" AllowPaging="True" AllowSorting="True"
	  AutoGenerateColumns="False" CellPadding="4" CssClass="table" PagerCurrentPageCssClass=""
	   PagerOtherPageCssClass="" PageSize="15" RecordCount="0" ShowFooter="True" SortedAscending="yes"
	    ForeColor="white" GridLines="Both"  >
 					
							<COLUMNS>
							<ASP:BOUNDCOLUMN HeaderText="POID"
									SortExpression="POID" DataField="POID" Visible="false"   >
                                <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
							<ASP:BOUNDCOLUMN HeaderText="PoDetailID"
									SortExpression="PoDetailID" DataField="PoDetailID" Visible="false"   >
                                <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
							<ASP:BOUNDCOLUMN visible="false" HeaderText="PoRefNO"
									 DataField="POrefNO" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
							 <ASP:BOUNDCOLUMN HeaderText="Style NO."
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
							 
							 		<ASP:TEMPLATECOLUMN HeaderText="WIP">
                                    <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
                                    <asp:DropDownList id="cmbWIPProcess" CssClass="textbox" 
                                      OnSelectedIndexChanged="cmbWIPProcess_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                                    <asp:CheckBox id="chkWIPProcess" runat="server"></asp:CheckBox>
                                    </ITEMTEMPLATE>
                                    <headerstyle width="20%" />
								</ASP:TEMPLATECOLUMN>
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
