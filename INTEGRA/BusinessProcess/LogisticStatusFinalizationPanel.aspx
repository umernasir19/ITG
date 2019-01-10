<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LogisticStatusFinalizationPanel.aspx.vb" Inherits="Integra.LogisticStatusFinalizationPanel" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Final Status</title>
     <link href= "../App_Themes/Blue/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <table width="100%">
     <tr>
    <td align="center">
      <asp:Label ID="lblMSG"  CssClass="ErrorMsg" runat="server"  ></asp:Label>
     </td>
     </tr>
       <tr>
    <td align="right">
       <telerik:RadButton ID="btnSave" runat="server" Text="Save My Selection(s)" 
         Skin="WebBlue" >
 </telerik:RadButton>
     </td>
     </tr>
     <tr>
     <td>
     <SMART:SMARTDATAGRID id="dgPurchaseOrder" runat="server" width="100%" OnSortCommand="SortByColumn"
	 OnPageIndexChanged="PageChanged" OnItemDataBound="DataBound" AllowPaging="True" AllowSorting="True"
	  AutoGenerateColumns="False" CellPadding="4" CssClass="table" PagerCurrentPageCssClass=""
	   PagerOtherPageCssClass="" PageSize="15" RecordCount="0" ShowFooter="True" SortedAscending="yes"
	    ForeColor="white" GridLines="Both">
 					
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
							 	<ASP:BOUNDCOLUMN visible="true" HeaderText="Customer"
									 DataField="Customername" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
									<ASP:BOUNDCOLUMN HeaderText="Vendor"
									DataField="vendername" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
							<ASP:BOUNDCOLUMN HeaderText="PO. NO."
									DataField="PONO" >
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
							<ASP:BOUNDCOLUMN HeaderText="Order QTY."
									 DataField="OrderQuantity">
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
							<ASP:BOUNDCOLUMN HeaderText="Ship QTY."
									 DataField="ReleaseQty">
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
							 
							 		<ASP:TEMPLATECOLUMN HeaderText="Final Staus">
                                    <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
                                    <asp:DropDownList id="cmbLogisticStaus" CssClass="textbox" AutoPostBack="true" runat="server"></asp:DropDownList>
                                    <asp:CheckBox id="chkLogisticStaus" runat="server"></asp:CheckBox>
                                    </ITEMTEMPLATE>
                                    <headerstyle width="20%" />
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

    </form>
</body>
</html>
