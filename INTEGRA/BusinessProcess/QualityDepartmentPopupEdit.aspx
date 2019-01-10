<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="QualityDepartmentPopupEdit.aspx.vb" Inherits="Integra.QualityDepartmentPopupEdit" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Quality Department Edit Page</title>
 <link href= "../App_Themes/Blue/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

           <table>
    <tr>
    <td>
  
     <asp:Label ID="Label1" CssClass="labelNew"  Text="PO No." runat="server" ></asp:Label> 
    </td>
    <td>
        <asp:Label ID="lblPONO" CssClass="labelNew"  runat="server" ></asp:Label>    
    </td>
    <td> </td>
    <td>

  <asp:Label ID="Label2" CssClass="labelNew"  Text="Supplier:" runat="server" ></asp:Label> 
    </td>
      <td>
        <asp:Label ID="lblSupplier" CssClass="labelNew"  runat="server" ></asp:Label>    
    </td>
    </tr>
    <tr>
        <td>

  <asp:Label ID="Label3" CssClass="labelNew"  Text="Customer:" runat="server" ></asp:Label> 
    </td>
      <td>
        <asp:Label ID="lblCustomer" CssClass="labelNew" runat="server" ></asp:Label>    
    </td><td></td>
           <td>

 <asp:Label ID="Label4" CssClass="labelNew"  Text="Shipment:" runat="server" ></asp:Label> 
    </td>
      <td>
        <asp:Label ID="lblShipment" CssClass="labelNew"  runat="server" ></asp:Label>    
    </td>
    </tr>
  <tr>
        <td>
 <asp:Label ID="Label5" CssClass="labelNew"  Text="Dept:" runat="server" ></asp:Label> 
    </td>
      <td>
        <asp:Label ID="lblEknumber" CssClass="labelNew" runat="server" ></asp:Label>    
    </td><td></td>
           <td>

 <asp:Label ID="Label6" CssClass="labelNew"  Text="Season:" runat="server" ></asp:Label> 
    </td>
      <td>
        <asp:Label ID="lblSeason" CssClass="labelNew"  runat="server" ></asp:Label>    
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
	   PagerOtherPageCssClass="" PageSize="500" RecordCount="0" ShowFooter="True" SortedAscending="yes"
	    ForeColor="White">
 					
							<COLUMNS>
                            	<ASP:BOUNDCOLUMN HeaderText="QDInspectionID"
								  DataField="QDInspectionID" visible="False" >
                                <itemstyle horizontalalign="Left" />
								 <headerstyle width="2%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
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
							   <ASP:TEMPLATECOLUMN HeaderText="QD Name">
                                  <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
									   <asp:DropDownList ID="cmbQDName" width="110"  cssclass="textbox" AutoPostBack="true"
                                        runat="server"    OnSelectedIndexChanged="cmbQDName_SelectedIndexChanged" ></asp:DropDownList>
									    </ITEMTEMPLATE>
                                         <headerstyle width="8%" />
							    	      </ASP:TEMPLATECOLUMN>                    
							<ASP:TEMPLATECOLUMN HeaderText="Ins. Date">
                            <itemstyle horizontalalign="Center"  />
							 <ITEMTEMPLATE>
    <telerik:RadDatePicker ID="txtInspDate" runat="server" Width="100" Culture="en-US">
<Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>
<DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" runat="server" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
                                </ITEMTEMPLATE>
                                <headerstyle width="12%" />
							    </ASP:TEMPLATECOLUMN>
							   <ASP:TEMPLATECOLUMN HeaderText="Insp. Type">
                                  <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
									   <asp:DropDownList ID="cmbStatus" width="75"   AutoPostBack="true" cssclass="textbox" 
                                       runat="server"  OnSelectedIndexChanged="cmbStatus_SelectedIndexChanged"></asp:DropDownList>
									    </ITEMTEMPLATE>
                                         <headerstyle width="10%" />
							    	      </ASP:TEMPLATECOLUMN>
							    	         <ASP:TEMPLATECOLUMN HeaderText="Insp. Status">
                                  <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
									   <asp:DropDownList ID="cmbInspStatus" width="60"   AutoPostBack="true" cssclass="textbox" 
                                       runat="server" OnSelectedIndexChanged="cmbInspStatus_SelectedIndexChanged" ></asp:DropDownList>
									    </ITEMTEMPLATE>
                                         <headerstyle width="10%" />
							    	      </ASP:TEMPLATECOLUMN>     
                                           <ASP:TEMPLATECOLUMN HeaderText="Error Code">
                                  <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
									    <telerik:RadComboBox ID="cmbErrorCode" Width="80"  Runat="server" 
                                        CheckBoxes="True" Skin="WebBlue"> </telerik:RadComboBox>
									    </ITEMTEMPLATE>
                                         <headerstyle width="10%" />
							    	      </ASP:TEMPLATECOLUMN>     
                                             
							<ASP:TEMPLATECOLUMN HeaderText="QD Remarks">
                                  <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
									  <asp:textbox id="txtRemarks" runat="server" width="80" CssClass="textbox" ></asp:textbox>
									   
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
