<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="QRCodeQD.aspx.vb" Inherits="Integra.QRCodeQD" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inspection Update</title>
         <link href= "../App_Themes/Blue/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
       <table>
    <tr>
    <td>
      <asp:Label ID="vv" CssClass="labelNew" Text="PO No." runat="server" ></asp:Label>    
    </td>
    <td>
        <asp:Label ID="lblPONO" CssClass="labelNew"  runat="server" ></asp:Label>    
    </td>
    <td> </td>
    <td>

 <asp:Label ID="Label1" runat="server" CssClass="labelNew" Text="Supplier:" ></asp:Label>   
    </td>
      <td>
        <asp:Label ID="lblSupplier" CssClass="labelNew"  runat="server" ></asp:Label>    
    </td>
    </tr>
    <tr>
        <td>

 <asp:Label ID="Label2" runat="server" CssClass="labelNew" Text="Customer:" ></asp:Label>   
    </td>
      <td>
        <asp:Label ID="lblCustomer" CssClass="labelNew"  runat="server" ></asp:Label>    
    </td><td></td>
           <td>

 <asp:Label ID="Label3" runat="server" CssClass="labelNew" Text="Shipment:" ></asp:Label>   
    </td>
      <td>
        <asp:Label ID="lblShipment" CssClass="labelNew"  runat="server" ></asp:Label>    
    </td>
    </tr>
 
        <tr>
        <td>

 <asp:Label ID="Label4" runat="server" CssClass="labelNew" Text="Dept:" ></asp:Label>   
    </td>
      <td>
        <asp:Label ID="lblEknumber" CssClass="labelNew"  runat="server" ></asp:Label>    
    </td><td></td>
           <td>

 <asp:Label ID="Label5" runat="server" CssClass="labelNew" Text="Season:" ></asp:Label>   
    </td>
      <td>
        <asp:Label ID="lblSeason"  CssClass="labelNew"  runat="server" ></asp:Label>    
    </td>
    </tr>
    <tr>
    <td>
 
     <asp:Label ID="Label6" runat="server" CssClass="labelNew" Text="QD Name:" ></asp:Label>       
    </td>
    <td>
        <asp:DropDownList ID="cmbQDName"  CssClass="labelNew" runat="server" AutoPostBack="true">
        </asp:DropDownList>    
    </td>
    <td>
    
     <asp:Label ID="Label7" runat="server" CssClass="labelNew" Text="Ins. Date:" ></asp:Label>       
    </td>
    <td>
     <telerik:RadDatePicker ID="txtInspDate" runat="server" Culture="en-US">
<Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>
<DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" runat="server" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
    </td>
    </tr>
    <tr>
   <td>
    
      <asp:Label ID="Label8" runat="server" CssClass="labelNew" Text="Insp. Type:" ></asp:Label>       
    </td>
    <td>
     <asp:DropDownList ID="cmbStatus"  CssClass="labelNew" runat="server" AutoPostBack="true">
        </asp:DropDownList> 
    </td>
    <td>
   
      <asp:Label ID="Label9" runat="server" CssClass="labelNew" Text="Insp. Status:" ></asp:Label>    
    </td>
    <td>
      <asp:DropDownList ID="cmbInspStatus" CssClass="labelNew" runat="server" AutoPostBack="true">
        </asp:DropDownList> 
     </td>
    </tr>


    </table>

    <table>
    <tr>
    <td align="right">
       <asp:Button ID="btnSave" runat="server"  CssClass="button" Text="Save My Selection(s)" Width="134px" />
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
	   PagerOtherPageCssClass="" PageSize="15" RecordCount="0" ShowFooter="True" SortedAscending="yes"
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
							 <ASP:BOUNDCOLUMN HeaderText="Size"
							 DataField="SizeRange" >
                             <itemstyle horizontalalign="Left" />
							 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
							 <ASP:BOUNDCOLUMN HeaderText="Color"
							 DataField="Colorway" >
                             <itemstyle horizontalalign="Left" />
							 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
		            		 <ASP:BOUNDCOLUMN HeaderText="Order Qty"
							 DataField="OrderQty" >
                             <itemstyle horizontalalign="Left" />
							 <headerstyle width="5%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
							 <ASP:BOUNDCOLUMN HeaderText="Insptd"
							 DataField="InspectedQty" >
                             <itemstyle horizontalalign="Left" />
							 <headerstyle width="5%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
							 	<ASP:TEMPLATECOLUMN HeaderText="Final Insptd Qty">
                                  <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
									  <asp:textbox id="txtInsQty" runat="server" width="50" Text="0" CssClass="textbox" ></asp:textbox>
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
    </table>
 
    </form>
</body>
</html>
