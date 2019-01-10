<%@ Page Language="vb"   AutoEventWireup="false" CodeBehind="ICRSupplierPopup.aspx.vb" Inherits="Integra.ICRSupplierPopup" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ICR Supplier Page</title>
 <link href= "../App_Themes/Blue/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
 <table>
 <tr>
<td></td>
<td style="width: 185px">
 </td>
<td></td>
<td></td>
<td align="center">
    <asp:Label ID="lblMSG"  CssClass="ErrorMsg" runat="server"  ></asp:Label>
</td> 
</tr>
<tr >
 <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblDateProposed" CssClass="labelNew" runat="server" Text="Date Proposed"></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 185px; height: 30px;">
               
                 <telerik:RadDatePicker ID="txtDateProposed" runat="server" Culture="en-US">
<Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>
<DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" runat="server" DateFormat="dd/MM/yyyy" LabelWidth="30%"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                        </telerik:RadDatePicker>  

            </td>
            </tr>
            <tr >
 <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblPreperedby" CssClass="labelNew" runat="server" Text="Prepered by"></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 185px; height: 30px;">
              <telerik:RadTextBox ID="txtPreperedby" Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
             </td>
            </tr>
            <tr >
 <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblEmail"  CssClass="labelNew" runat="server" Text="Email"></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 185px; height: 30px;">
              <telerik:RadTextBox ID="txtEmail" Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
                	 <asp:RegularExpressionValidator ID="rfvEnmail" runat="server" CssClass="ErrorMsg" ErrorMessage="*" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator> 
              </td>
 <td></td>
 <td></td>
 <td></td>
 <td></td>
 <td></td>
 <td></td>
<td  align="right" style="width: 500px;">
 <telerik:RadButton ID="btnSave" runat="server" Text="Save My Selection(s)" Skin="WebBlue"></telerik:RadButton>
  
</td>
</tr>
 </table>
<table width="100%">
<tr><td>
  <asp:UpdatePanel ID="UpdatePanel1"   runat="server">
     <ContentTemplate>
	<SMART:SMARTDATAGRID id="dgPurchaseOrder" runat="server" width="100%" OnSortCommand="SortByColumn"
	 OnPageIndexChanged="PageChanged" OnItemDataBound="DataBound" AllowPaging="True" AllowSorting="True"
	  AutoGenerateColumns="False" CellPadding="4" CssClass="table" PagerCurrentPageCssClass=""
	   PagerOtherPageCssClass="" PageSize="200" RecordCount="0" ShowFooter="True" SortedAscending="yes"
	    ForeColor="white" GridLines="Both"  >
 					
							<COLUMNS>
							<ASP:BOUNDCOLUMN HeaderText="POID"
									SortExpression="POID" DataField="POID" visible="False" >
                                <itemstyle horizontalalign="Left" />
								 <headerstyle width="1%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
							<ASP:BOUNDCOLUMN HeaderText="PoDetailID"
									SortExpression="PoDetailID" DataField="PoDetailID" visible="False" >
                                <itemstyle horizontalalign="Left" />
								 <headerstyle width="1%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
							<ASP:BOUNDCOLUMN HeaderText="Destination"
									 DataField="Destination" >
                                    <itemstyle horizontalalign="Left" font-bold="False" font-italic="False" font-overline="False" font-strikeout="False" font-underline="False" wrap="False" />
								 <headerstyle width="10%" horizontalalign="center" font-bold="False" font-italic="False" font-overline="False" font-strikeout="False" font-underline="False" wrap="False"  />
							</ASP:BOUNDCOLUMN>
									<ASP:BOUNDCOLUMN HeaderText="Customer"
									DataField="CustomerName" >
                                    <itemstyle horizontalalign="Left" font-bold="False" font-italic="False" font-overline="False" font-strikeout="False" font-underline="False" wrap="False" />
								 <headerstyle width="10%" horizontalalign="center" font-bold="False" font-italic="False" font-overline="False" font-strikeout="False" font-underline="False" wrap="False"  />
							</ASP:BOUNDCOLUMN>
							 <ASP:BOUNDCOLUMN HeaderText="Dept. No."
									 DataField="Eknumber" >
                                    <itemstyle horizontalalign="Left" font-bold="False" font-italic="False" font-overline="False" font-strikeout="False" font-underline="False" wrap="False" />
								 <headerstyle width="10%" horizontalalign="center" font-bold="False" font-italic="False" font-overline="False" font-strikeout="False" font-underline="False" wrap="False"  />
							</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN HeaderText="Order No."
									 DataField="pono">
                                    <itemstyle horizontalalign="Left" font-bold="False" font-italic="False" font-overline="False" font-strikeout="False" font-underline="False" wrap="False" />
								 <headerstyle width="10%" horizontalalign="center" font-bold="False" font-italic="False" font-overline="False" font-strikeout="False" font-underline="False" wrap="False"  />
							</ASP:BOUNDCOLUMN>
						 
							<ASP:BOUNDCOLUMN  HeaderText="Shipment Date"
									DataField="RvDate" >
                                        <itemstyle horizontalalign="Left" font-bold="False" font-italic="False" font-overline="False" font-strikeout="False" font-underline="False" wrap="False" />
								 <headerstyle width="10%" horizontalalign="center" font-bold="False" font-italic="False" font-overline="False" font-strikeout="False" font-underline="False" wrap="False"  />
							</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN  HeaderText="Style No."
									DataField="StyleNo" >
                                        <itemstyle horizontalalign="Left" font-bold="False" font-italic="False" font-overline="False" font-strikeout="False" font-underline="False" wrap="False" />
								 <headerstyle width="10%" horizontalalign="center" font-bold="False" font-italic="False" font-overline="False" font-strikeout="False" font-underline="False" wrap="False"  />
							</ASP:BOUNDCOLUMN>
								
								<ASP:BOUNDCOLUMN  HeaderText="Article"
									DataField="Article" >
                                        <itemstyle horizontalalign="Left" font-bold="False" font-italic="False" font-overline="False" font-strikeout="False" font-underline="False" wrap="False" />
								 <headerstyle width="10%" horizontalalign="center" font-bold="False" font-italic="False" font-overline="False" font-strikeout="False" font-underline="False" wrap="False"  />
							</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN  HeaderText="Colorway"
									DataField="Colorway" >
                                        <itemstyle horizontalalign="Left" font-bold="False" font-italic="False" font-overline="False" font-strikeout="False" font-underline="False" wrap="False" />
								 <headerstyle width="10%" horizontalalign="center" font-bold="False" font-italic="False" font-overline="False" font-strikeout="False" font-underline="False" wrap="False"  />
							</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN  HeaderText="Size"
									DataField="SizeRange" >
                                        <itemstyle horizontalalign="Left" font-bold="False" font-italic="False" font-overline="False" font-strikeout="False" font-underline="False" wrap="False" />
								 <headerstyle width="10%" horizontalalign="center" font-bold="False" font-italic="False" font-overline="False" font-strikeout="False" font-underline="False" wrap="False"  />
							</ASP:BOUNDCOLUMN>
							<ASP:BOUNDCOLUMN  HeaderText="Quantity"
									DataField="Quantity" >
                                        <itemstyle horizontalalign="Left" font-bold="False" font-italic="False" font-overline="False" font-strikeout="False" font-underline="False" wrap="False" />
								 <headerstyle width="10%" horizontalalign="center" font-bold="False" font-italic="False" font-overline="False" font-strikeout="False" font-underline="False" wrap="False"  />
							</ASP:BOUNDCOLUMN>
							<ASP:BOUNDCOLUMN HeaderText="Shipment Mode"
									 DataField="Name" visible="false">
                                   <itemstyle horizontalalign="Left" font-bold="False" font-italic="False" font-overline="False" font-strikeout="False" font-underline="False" wrap="False" />
								<headerstyle width="10%" horizontalalign="center" font-bold="False" font-italic="False" font-overline="False" font-strikeout="False" font-underline="False" wrap="False"  />
							</ASP:BOUNDCOLUMN>
							<ASP:TEMPLATECOLUMN HeaderText="Suppling">
                                    <itemstyle horizontalalign="Left" font-bold="False" font-italic="False" font-overline="False" font-strikeout="False" font-underline="False" wrap="False" />
                                    <headerstyle width="10%" horizontalalign="center" font-bold="False" font-italic="False" font-overline="False" font-strikeout="False" font-underline="False" wrap="False"  />
									<ITEMTEMPLATE>
                                     <asp:TextBox id="txtSuppling" runat="server" width="60" height="15"  CssClass="textbox"></asp:TextBox>
                                     </ITEMTEMPLATE>
                                    <headerstyle width="10%" />
								</ASP:TEMPLATECOLUMN>					 
								 
							 		<ASP:TEMPLATECOLUMN HeaderText="CAT INSP(*)">
                                     <itemstyle horizontalalign="Left" font-bold="False" font-italic="False" font-overline="False" font-strikeout="False" font-underline="False" wrap="False" />
                                     <headerstyle width="10%" horizontalalign="center" font-bold="False" font-italic="False" font-overline="False" font-strikeout="False" font-underline="False" wrap="False"  />
									<ITEMTEMPLATE>
                                    <asp:DropDownList id="cmbCATINSP" CssClass="textbox" height="15"  AutoPostBack="false" runat="server"></asp:DropDownList>
                                     <asp:CheckBox id="chkICR" runat="server"></asp:CheckBox>
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


