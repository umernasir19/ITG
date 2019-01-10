<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SplitShipment.aspx.vb" Inherits="Integra.SplitShipment" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Split Shipment Details</title>
 <link href= "../App_Themes/Blue/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <table>
    <tr>
    <td>
  <asp:Label ID="Label1"  CssClass="labelNew" Text="PO No." runat="server" ></asp:Label>    
    </td>
    <td>
        <asp:Label ID="lblPONO"  CssClass="labelNew" runat="server" ></asp:Label>    
    </td>
    <td> </td>
    <td>

 <asp:Label ID="Label2"  CssClass="labelNew" Text="Supplier:" runat="server" ></asp:Label> 
    </td>
      <td>
        <asp:Label ID="lblSupplier"  CssClass="labelNew" runat="server" ></asp:Label>    
    </td>
    </tr>
    <tr>
        <td>

 <asp:Label ID="Label3"  CssClass="labelNew" Text="Customer:" runat="server" ></asp:Label> 
    </td>
      <td>
        <asp:Label ID="lblCustomer"  CssClass="labelNew" runat="server" ></asp:Label>    
    </td><td></td>
           <td>

 <asp:Label ID="Label4"  CssClass="labelNew" Text="Shipment:" runat="server" ></asp:Label> 
    </td>
      <td>
        <asp:Label ID="lblShipment"  CssClass="labelNew" runat="server" ></asp:Label>    
    </td>
    </tr>
   <tr>
        <td>

 <asp:Label ID="Label5"  CssClass="labelNew" Text="Dept:" runat="server" ></asp:Label> 
    </td>
      <td>
        <asp:Label ID="lblEknumber"  CssClass="labelNew" runat="server" ></asp:Label>    
    </td><td></td>
           <td>

<asp:Label ID="Label6"  CssClass="labelNew" Text="Season:" runat="server" ></asp:Label> 
    </td>
      <td>
        <asp:Label ID="lblSeason"  CssClass="labelNew" runat="server" ></asp:Label>    
    </td>
       <td>
        <asp:Label ID="lblPOShipmentMode"  Visible="false"  CssClass="labelNew" runat="server" ></asp:Label>    
    </td>
    </tr>
     </table>
 <table>
 <tr>
    <td align="right">
 <asp:button id="cmdClose"    OnClientClick="window.close();" runat="server"
  CssClass="button" Text="Close"   ></asp:button>
    &nbsp;
    <telerik:RadButton ID="btnSavee" runat="server" Text="Save My Selection(s)" Skin="WebBlue">
     </telerik:RadButton>
  
    </td>
    </tr>
     <tr>
    <td align="center">
      <asp:Label ID="lblMsg" runat="server"  CssClass="ErrorMsg"></asp:Label>
 
    </td>
    </tr>
 <tr>
 <td>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
       <ContentTemplate>
       	<SMART:SMARTDATAGRID id="dgPurchaseOrder" runat="server" width="100%" OnSortCommand="SortByColumn"
	 OnPageIndexChanged="PageChanged" OnItemDataBound="DataBound" AllowPaging="True" AllowSorting="True"
	  AutoGenerateColumns="False" CellPadding="4" CssClass="table" PagerCurrentPageCssClass=""
	   PagerOtherPageCssClass="" PageSize="200" RecordCount="0" ShowFooter="True" SortedAscending="yes"
	    ForeColor="White">
 					
							<COLUMNS>
							<ASP:BOUNDCOLUMN HeaderText="POID"
								  DataField="POID" visible="False" >
                                <itemstyle horizontalalign="Left" />
								 <headerstyle width="2%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
							<ASP:BOUNDCOLUMN HeaderText="PoDetailID"
								  DataField="PoDetailID" visible="False" >
                                <itemstyle horizontalalign="Left" />
								 <headerstyle width="2%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
                            	<ASP:BOUNDCOLUMN HeaderText="StyleID"
								  DataField="StyleID" visible="False" >
                                <itemstyle horizontalalign="Left" />
								 <headerstyle width="2%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
                            	<ASP:BOUNDCOLUMN HeaderText="StyleDetailID"
								  DataField="StyleDetailID" visible="False" >
                                <itemstyle horizontalalign="Left" />
								 <headerstyle width="2%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
							  <ASP:BOUNDCOLUMN HeaderText="Style"
							 DataField="StyleNo" >
                             <itemstyle horizontalalign="Left" />
							 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
							 <ASP:BOUNDCOLUMN HeaderText="Article"
							 DataField="Article" >
                             <itemstyle horizontalalign="Left" />
							 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
                            	 <ASP:BOUNDCOLUMN HeaderText="Color"
							 DataField="Colorway" >
                             <itemstyle horizontalalign="Left" />
							 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
							 <ASP:BOUNDCOLUMN HeaderText="Size"
							 DataField="SizeRange" >
                             <itemstyle horizontalalign="Left" />
							 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
							 <ASP:BOUNDCOLUMN HeaderText="Price"
							 DataField="rate" >
                             <itemstyle horizontalalign="Left" />
							 <headerstyle width="5%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
							 <ASP:BOUNDCOLUMN HeaderText="Order Qty"
							 DataField="quantity" >
                             <itemstyle horizontalalign="Left" />
							 <headerstyle width="5%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
                             <ASP:BOUNDCOLUMN HeaderText="Order Qty"
							 DataField="quantity" Visible="false">
                             <itemstyle horizontalalign="Left" />
							 <headerstyle width="5%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
						
							 	<ASP:TEMPLATECOLUMN HeaderText="Move">
                                  <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
									 
									   <telerik:RadNumericTextBox id="txtMove" runat="server"  width="50" >
                                       <NumberFormat ZeroPattern="n" decimaldigits="0"></NumberFormat>
                                       </telerik:RadNumericTextBox>

                                       </ITEMTEMPLATE>
                                         <headerstyle width="10%" />
							    	      </ASP:TEMPLATECOLUMN> 	                                                                                                        
							   <ASP:TEMPLATECOLUMN HeaderText="Mode">
                                  <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
									   <asp:DropDownList ID="cmbMode" width="50"  cssclass="textbox" AutoPostBack="true" runat="server"  ></asp:DropDownList>
									   
                                            </ITEMTEMPLATE>
                                         <headerstyle width="10%" />
							    	      </ASP:TEMPLATECOLUMN>                    
							<ASP:TEMPLATECOLUMN HeaderText="Spilt Ship. Date">
                            <itemstyle horizontalalign="Center"  />
							                     <ITEMTEMPLATE>
                        <telerik:RadDatePicker ID="txtSpiltShipDate" runat="server" Width="100" Culture="en-US">
                    <Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>
                    <DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" runat="server" DateFormat="dd/MM/yyyy" ></DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                    </telerik:RadDatePicker>
                          </ITEMTEMPLATE>
                                <headerstyle width="10%" />
							    </ASP:TEMPLATECOLUMN>
							
							<ASP:TEMPLATECOLUMN HeaderText="Reason">
                                  <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
									  <asp:textbox id="txtReason" runat="server" width="240" CssClass="textbox" ></asp:textbox>
									   
                                    </ITEMTEMPLATE>
                                         <headerstyle width="10%" />
							    	      </ASP:TEMPLATECOLUMN> 	
							<ASP:TEMPLATECOLUMN HeaderText=" ">
                                    <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
                                    <asp:CheckBox id="chkStatus" runat="server"></asp:CheckBox>
                                    
                                    </ITEMTEMPLATE>
                                    <headerstyle width="5%" />
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
 <tr>
 <td align="right">
     <telerik:RadButton ID="btnCheckData" runat="server" Text="Check" Skin="WebBlue">
     </telerik:RadButton>
      
    </td>
 </tr>
 </table>  
    </form>
</body>
</html>
