<%@ Page Language="vb" MasterPageFile="~/MasterPage.master"   AutoEventWireup="false" CodeBehind="CPChartView.aspx.vb" Inherits="Integra.CPChartView" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" >
        function isNumericKey(e) {
            var charInp = window.event.keyCode;
            if (charInp > 31 && (charInp < 48 || charInp > 57)) {
                return false;
            }
            return true;
        }
        function isNumericKeyy(e) {
            var charInp = window.event.keyCode;
            if (charInp != 46 && (charInp < 48 || charInp > 57)) {
                return false;
            }
            return true;
        }
        function mathRoundForTaxes(source) {
            var txtBox = document.getElementById(source);
            var txt = txtBox.value;
            if (!isNaN(txt) && isFinite(txt) && txt.length != 0) {
                var rounded = Math.round(txt * 100) / 100;
                txtBox.value = rounded.toFixed(2);
            }
        }
        function NotZero(source) {
            var txtBox = document.getElementById(source);
            var txt = txtBox.value;
            if (txt == 0) {
                txtBox.value = 1;
            }
        }

        function selectOneside(val) { //here val is my dropdown ID
            var Dval = val.selectedIndex;
            if (Dval == "2") {
                val.selectedIndex = 0;
            }
        }
    </script>
  <div style="vertical-align:top;  overflow:scroll ;width:100%; border-style:groove; ">
 <b>
 <table width="40%">
 <tr>
 <td>
 PO No.
 </td>
 <td>
  <asp:Label ID="lblPONO" runat="server"></asp:Label>
 </td>
 </tr>
 <tr>
  <td>
 Customer
 </td>
 <td>
 <asp:Label ID="lblCustomer" runat="server"></asp:Label>
 </td>
  </tr>
 <tr>
  <td>
Supplier
 </td>
 <td>
 <asp:Label ID="lblSupplier" runat="server"></asp:Label>
 </td>
 </tr>
 <tr>
  <td>
 Style
 </td>
 <td>
 <asp:Label ID="lblStyle" runat="server"></asp:Label>
 </td>

 </tr>
  <tr>
  <td>
Shipment Date
 </td>
 <td>
 <asp:Label ID="lblShipemntDate" runat="server"></asp:Label>
 </td>
 
 </tr>
</table>
</b>
 <table width="100%">
 <tr>
 <td align="right">
 <asp:Button id="btnSaveAll" CssClass="button" runat="server" Text="Save"></asp:Button>
 </td>
 </tr>
  <tr>
 <td align="Center">
     <asp:Label ID="lblMssg" CssClass="ErrorMsg" runat="server" ></asp:Label>
 </td>
 </tr>
 </table> 
 <table width="100%">
 <tr>
 <td>
  	<SMART:SMARTDATAGRID id="dgPurchaseOrder" runat="server" width="120%" OnSortCommand="SortByColumn"
	 OnPageIndexChanged="PageChanged" OnItemDataBound="DataBound" AllowPaging="True" AllowSorting="True"
	  AutoGenerateColumns="False" CellPadding="4" CssClass="table" PagerCurrentPageCssClass=""
	   PagerOtherPageCssClass="" PageSize="50" RecordCount="0" ShowFooter="True" SortedAscending="yes"
	    ForeColor="White">
 					 	<COLUMNS>
							<ASP:BOUNDCOLUMN HeaderText="CPChartID"
								  DataField="CPChartID" visible="False" >
                                <itemstyle horizontalalign="Left" />
								 <headerstyle width="2%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
                            <ASP:BOUNDCOLUMN HeaderText="CPProcessID"
								  DataField="CPProcessID" visible="False" >
                                <itemstyle horizontalalign="Left" />
								 <headerstyle width="2%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
                            <ASP:BOUNDCOLUMN HeaderText="Process Name"
							 DataField="ProcessName" >
                             <itemstyle horizontalalign="Left" />
							 <headerstyle width="15%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
						  <ASP:TEMPLATECOLUMN HeaderText="Qty">
                                  <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
									  <asp:textbox id="txtQuantity" runat="server"  onkeypress="return isNumericKey(event);" width="20"  CssClass="textbox" ></asp:textbox>
									    </ITEMTEMPLATE>
                                         <headerstyle width="2%" />
							    	      </ASP:TEMPLATECOLUMN> 	                                                                                                        
							 <ASP:TEMPLATECOLUMN HeaderText="Target Submission">
                            <itemstyle horizontalalign="Center"  />
							 <ITEMTEMPLATE>
  <asp:TextBox ID="txtTargetSubmission" Width="70" runat="server" CssClass="textbox"></asp:TextBox>
<cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server"  
        TargetControlID="txtTargetSubmission" PopupButtonID="ImageButton2"  />
<asp:ImageButton runat="Server" ID="ImageButton2" CausesValidation="false"   ImageUrl="~/Images/calendar.JPG" AlternateText="Click here to display calendar" /> 
<cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server"  TargetControlID="txtTargetSubmission" Mask="99/99/9999" Century = "2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM" CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/" CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":" Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False" ></cc1:MaskedEditExtender>
 </ITEMTEMPLATE>
                                <headerstyle width="12%" />
							    </ASP:TEMPLATECOLUMN>
                                <ASP:TEMPLATECOLUMN HeaderText="Ist Submission">
                            <itemstyle horizontalalign="Center"  />
							 <ITEMTEMPLATE>
  <asp:TextBox ID="txtIstSubmission" runat="server" Width="70"  CssClass="textbox"></asp:TextBox>
<cc1:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server"  
        TargetControlID="txtIstSubmission" PopupButtonID="ImageButton3"  />
<asp:ImageButton runat="Server" ID="ImageButton3" CausesValidation="false"   ImageUrl="~/Images/calendar.JPG" AlternateText="Click here to display calendar" /> 
<cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server"  TargetControlID="txtIstSubmission" Mask="99/99/9999" Century = "2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM" CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/" CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":" Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False" ></cc1:MaskedEditExtender>
  </ITEMTEMPLATE>
                                <headerstyle width="12%" />
							    </ASP:TEMPLATECOLUMN>
                                  <ASP:TEMPLATECOLUMN HeaderText="DHL / FEDEX">
                                  <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
									  <asp:textbox id="txtDHLorFEDEX" runat="server" width="80"  CssClass="textbox" ></asp:textbox>
									    </ITEMTEMPLATE>
                                         <headerstyle width="10%" />
							    	      </ASP:TEMPLATECOLUMN> 
                                            <ASP:TEMPLATECOLUMN HeaderText="Feed Back Received">
                                  <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
									   <asp:DropDownList ID="cmbFeedBackReceived" width="60"  cssclass="textbox" 
                                         runat="server"  >
                                             <asp:ListItem Value ="0" Text ="--"></asp:ListItem>
                                         <asp:ListItem Value ="1" Text ="Pass"></asp:ListItem>
                                          <asp:ListItem Value ="2" Text ="Fail"></asp:ListItem>
                                         </asp:DropDownList>
									    </ITEMTEMPLATE>
                                         <headerstyle width="8%" />
							    	      </ASP:TEMPLATECOLUMN>    
                                            <ASP:TEMPLATECOLUMN HeaderText="Revised Target">
                            <itemstyle horizontalalign="Center"  />
							 <ITEMTEMPLATE>
  <asp:TextBox ID="txtRevisedTarget" runat="server" Width="70"  CssClass="textbox"></asp:TextBox>
<cc1:CalendarExtender ID="CalendarExtender4" Format="dd/MM/yyyy" runat="server"  
        TargetControlID="txtRevisedTarget" PopupButtonID="ImageButton4"  />
<asp:ImageButton runat="Server" ID="ImageButton4" CausesValidation="false"   ImageUrl="~/Images/calendar.JPG" AlternateText="Click here to display calendar" /> 
<cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server"  TargetControlID="txtRevisedTarget" Mask="99/99/9999" Century = "2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM" CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/" CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":" Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False" ></cc1:MaskedEditExtender>
  </ITEMTEMPLATE>
                                <headerstyle width="12%" />
							    </ASP:TEMPLATECOLUMN>
                                 <ASP:TEMPLATECOLUMN HeaderText="Revised Submission">
                            <itemstyle horizontalalign="Center"  />
							 <ITEMTEMPLATE>
  <asp:TextBox ID="txtRevisedSubmission" runat="server" Width="70"  CssClass="textbox"></asp:TextBox>
<cc1:CalendarExtender ID="CalendarExtender5" Format="dd/MM/yyyy" runat="server"  
        TargetControlID="txtRevisedSubmission" PopupButtonID="ImageButton5"  />
<asp:ImageButton runat="Server" ID="ImageButton5" CausesValidation="false"   ImageUrl="~/Images/calendar.JPG" AlternateText="Click here to display calendar" /> 
<cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server"  TargetControlID="txtRevisedSubmission" Mask="99/99/9999" Century = "2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM" CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/" CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":" Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False" ></cc1:MaskedEditExtender>
  </ITEMTEMPLATE>
                                <headerstyle width="12%" />
							    </ASP:TEMPLATECOLUMN>
  <ASP:TEMPLATECOLUMN HeaderText="DHL / FEDEX">
                                  <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
									  <asp:textbox id="txtDHLorFEDEX1" runat="server" width="80"  CssClass="textbox" ></asp:textbox>
									    </ITEMTEMPLATE>
                                         <headerstyle width="10%" />
							    	      </ASP:TEMPLATECOLUMN> 
                                             <ASP:TEMPLATECOLUMN HeaderText="Feed Back Received">
                                  <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
									   <asp:DropDownList ID="cmbFeedBackReceived1" width="60"  cssclass="textbox"  
                                        runat="server"  >
                                           <asp:ListItem Value ="0" Text ="--"></asp:ListItem>
                                         <asp:ListItem Value ="1" Text ="Pass"></asp:ListItem>
                                          <asp:ListItem Value ="2" Text ="Fail"></asp:ListItem>
                                        </asp:DropDownList>
									    </ITEMTEMPLATE>
                                         <headerstyle width="8%" />
							    	      </ASP:TEMPLATECOLUMN> 
                                         <ASP:TEMPLATECOLUMN HeaderText="Remarks / Amendment">
                                  <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
									  <asp:textbox id="txtRemarks" runat="server" width="110"  CssClass="textbox" ></asp:textbox>
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
     
                	<ASP:TEMPLATECOLUMN HeaderText="History"  >
                      <itemstyle horizontalalign="Center" />
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkHistory" CommandName="History" runat="server">History</asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
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
 </div> 
  </asp:Content> 