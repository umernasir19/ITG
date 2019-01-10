<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WIPEntry.aspx.vb" Inherits="Integra.WIPEntry" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>WIP Working Control Panel</title>
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
    <tr>
    <td>
    Revised Shipment Date:
    </td>
    <td>
  <asp:TextBox ID="txtRevisedShipmentt"    runat="server" CssClass="textbox" TabIndex="14" ></asp:TextBox>&nbsp;
  <cc1:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" EnableViewState="true"   runat="server"  TargetControlID="txtRevisedShipmentt" PopupButtonID="ImageButton3"/>
    <asp:ImageButton runat="Server" ID="ImageButton3" CausesValidation="false" ImageUrl="~/Images/calendar.jpg" AlternateText="Click here to display calendar" /> 
 <asp:Label ID="lblMMsg" CssClass="ErrorMsg" runat="server"  ></asp:Label>
    </td>
    </tr>
    <tr>
    <td>
    </td>
    <td>
         <asp:Button ID="btnUpdateRevisedShipmentDatee" runat="server"  CssClass="button" Text="Update"  />
                 
    </td>
    </tr>
     <tr>
    <td>
    </td>
    <td>
      <asp:Label ID="lblRevsedShipmentDate" CssClass="ErrorMsg" runat="server"  ></asp:Label>
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
	   PagerOtherPageCssClass="" PageSize="500" RecordCount="0" ShowFooter="True" SortedAscending="yes"
	    ForeColor="white" GridLines="Both"  >
 					
							<COLUMNS>
							<ASP:BOUNDCOLUMN HeaderText="POID"
									SortExpression="POID" DataField="POID" visible="False" >
                                <itemstyle horizontalalign="Left" />
								 <headerstyle width="02%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
							 
							<ASP:BOUNDCOLUMN visible="false" HeaderText="PoRefNO"
									 DataField="POrefNO" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="02%" horizontalalign="Left"  />
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
                            <ASP:TEMPLATECOLUMN HeaderText="Comments">
                                    <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
                                        <asp:TextBox ID="txtComments" Width="320" TextMode="MultiLine" runat="server"></asp:TextBox>
                                    </ITEMTEMPLATE>
                                    <headerstyle width="07%" />
								</ASP:TEMPLATECOLUMN>
							 <ASP:TEMPLATECOLUMN HeaderText="WIP">
                                    <itemstyle horizontalalign="Left" />
									<ITEMTEMPLATE>
                                    <asp:DropDownList id="cmbWIPProcess" CssClass="textbox" 
                                      OnSelectedIndexChanged="cmbWIPProcess_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                                    <asp:CheckBox id="chkWIPProcess" runat="server"></asp:CheckBox>
                                    </ITEMTEMPLATE>
                                    <headerstyle width="10%" horizontalalign="Left" />
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
