<%@ Page   Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" 
CodeBehind="StyleAssortmentBarCodeView.aspx.vb" Inherits="Integra.StyleAssortmentBarCodeView" 
 title="Style Assortment BarCode View" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<style>
.FixedHeaderOfGV
{
    font-weight: bold;
    font-size: 8pt;
    color: white;
    font-style: normal;
    font-family: Verdana;
    background-color: #838b83;
    text-align: center;
    height: 28px;
}
.FixedHeaderOfGV td
{
	text-align:center;
	border:1px solid black;
}

.GridHeaderStyle
{
	display:none;
}
table .GridRow td, FixedHeaderOfGV td
{
	width:69px !important;
}
</style>

  <table >
        <tr>

                       
            
</tr>
 </table><br />

<table>
  <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="6" align="left" style="font-family:Century Gothic ; font-size: 16PX; font-weight: bold;
                color:Blue ">
             <marquee >Searching Criteria For Brand,Buyer,Style,SrNo,Season,Color</marquee>
            </th>
        </tr>
</table>
<br />
<table>
<tr>
<td>
        Season
        </td>
<td>
<asp:DropDownList ID="cmbSeason" Width="160" CssClass="combo" AutoPostBack="TRUE"
                            runat="server" Style="margin-left: 9px; height: 28px;">
                        </asp:DropDownList></td>
        <td>
        Searching
        </td>
        <td align="right" >
          <asp:TextBox CssClass="textbox" ID="txtSearch" AutopostBack="true"  style="height :20px; margin-left: 10px;" runat="server" ReadOnly="false" ></asp:TextBox>
           <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="10"
                                        CompletionSetCount="12" ContextKey="SearchingFromStyleAssormentForBarCodeView" EnableCaching="true" MinimumPrefixLength="1"
                                        ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtSearch" />

        </td>
            
        </tr>
</table>
<br />
<table>
<tr>

        <td>
        Color
        </td>
        <td align="right" >
          <asp:TextBox CssClass="textbox" ID="txtColor" AutopostBack="true"  style="height :20px; margin-left: 22px;" runat="server" ReadOnly="false" ></asp:TextBox>
           <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" CompletionInterval="10"
                                        CompletionSetCount="12" ContextKey="SearchingBarCodeViewColorVise" EnableCaching="true" MinimumPrefixLength="1"
                                        ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtColor" />

        </td>
</tr>
</table>
<br />
<table>


<table>
<tr class="FixedHeaderOfGV">
	<td width="75px">SEASON</td>
	<td width="75px">CUSTOMER</td>
	<td width="72px">BRAND</td>
	<td width="76px">Sr NO</td>
	<td width="73px">SHIP</td>
	<td width="78px">STYLE</td>
	<td width="76px">CUS.COLOR</td>
	<td width="76px">Total Color Qty</td>
	<td width="74px">Total Cutting Qty</td>
	<td width="76px">Size</td>
	<td width="74px">Line Planing</td>
	<td width="75px">Barcode.</td>
    <%--<td width="69px">Extra Barcode.</td>--%>
</tr>

</table>



<tr   >



<td  >                              
					<div id="div1" runat="server" style="overflow: scroll; width: 930px; height: 600px; "> 
						<SMART:SMARTDATAGRID id="dgView" runat="server"   width="100%" OnSortCommand="SortByColumn" OnPageIndexChanged="PageChanged"
							 AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"  CellPadding="4"  
							 PageSize="1000000"  ShowFooter="True" ShowHeader ="true"   ForeColor="white" GridLines="both" >
							<COLUMNS>
							<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="0%" HeaderText="StyleAssortmentMasterID"
								  DataField="StyleAssortmentMasterID" visible="false" />
								<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="0%" HeaderText="JobOrderId"
								  DataField="JobOrderId" visible="false" />
								  <ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="0%" HeaderText="JoborderDetailid"
								  DataField="JoborderDetailid" visible="false" />
							 <ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="0%" HeaderText="SEASON"
								  DataField="SeasonName" >
							 	<headerstyle horizontalalign="center" width="9.1%" />
								</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="0%" HeaderText="CUSTOMER"
									 DataField="CustomerName" >
							 	<headerstyle horizontalalign="center" width="9%" />
								</ASP:BOUNDCOLUMN>
								 	<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="0%" HeaderText="BRAND"
									 DataField="Brand" >
							 	<headerstyle horizontalalign="center" width="9%" />
								</ASP:BOUNDCOLUMN>
									<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="0%" HeaderText="Sr NO"
									 DataField="SRNO" >
							 	<headerstyle horizontalalign="center" width="5%" />
								</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="0%" HeaderText="SHIP"
									 DataField="StyleShipmentDatee" >
							 	<headerstyle horizontalalign="center" width="9%" />
								</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="0%" HeaderText="STYLE"
									 DataField="Style" >
							 	<headerstyle horizontalalign="center" width="9%" />
								</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="0%" HeaderText="CUS.COLOR"
									 DataField="BuyerColor" >
							 	<headerstyle horizontalalign="center" width="9%" />
								</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="0%" HeaderText="Total Color Qty"
									 DataField="Quantity" >
							 	<headerstyle horizontalalign="center" width="9%" />
								</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="0%" HeaderText="Assort Qty"
									 DataField="Sizeqty" >
							 	<headerstyle horizontalalign="center" width="9%" />
								</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="0%" HeaderText="Size"
									 DataField="Size" >
							 	<headerstyle horizontalalign="center" width="5%" />
								</ASP:BOUNDCOLUMN>


                                <ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="0%" HeaderText="From"
									 DataField="Fromm" Visible="false" >
							 	<headerstyle horizontalalign="center" width="5%" />
								</ASP:BOUNDCOLUMN>

                                <ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="0%" HeaderText="To"
									 DataField="Too"  Visible="false">
							 	<headerstyle horizontalalign="center" width="5%" />
								</ASP:BOUNDCOLUMN>
								
								
								
								 <ASP:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%"   HeaderText="Line Planing" visible="true">
									<ITEMTEMPLATE>																	
										<asp:ImageButton id="lnkEdit" tooltip="Click here to create Assortment"  ImageUrl="~/Images/dashicon.png" CommandName="StyleAssortmanr" runat="server"></asp:ImageButton>
										<asp:ImageButton id="lnkOk" tooltip="Click here to Edit Assortment"  ImageUrl="~/Images/Ok.JPG"  CommandName="Edit" runat="server"></asp:ImageButton>
									</ITEMTEMPLATE>
								</ASP:TEMPLATECOLUMN>
								  <ASP:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="FAB." visible="false">
									<ITEMTEMPLATE>																	
										<asp:ImageButton id="lnkCreateFab" tooltip="Click here to create Fabrication"   ImageUrl="~/Images/dashicon.png" CommandName="FABRICATION" runat="server"></asp:ImageButton>
									<asp:ImageButton id="lnkEditFab" tooltip="Click here to Edit Fabrication"   ImageUrl="~/Images/Ok.JPG"  CommandName="FABRICATIONEdit" runat="server"></asp:ImageButton>
									</ITEMTEMPLATE>
								</ASP:TEMPLATECOLUMN>
  <ASP:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="Barcode." visible="true">
									<ITEMTEMPLATE>																	
										<asp:ImageButton id="lnkBarcode" tooltip="Click here to Download Barcode"  ImageUrl="~/Images/pdf_icon_small.gif" CommandName="Barcode" runat="server"></asp:ImageButton>
									</ITEMTEMPLATE>
								</ASP:TEMPLATECOLUMN>
								<ASP:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="Extra Barcode." visible="false">
									<ITEMTEMPLATE>																	
										<asp:ImageButton id="lnkExtraBarcode" tooltip="Click here to Download Extra Barcode"  ImageUrl="~/Images/pdf_icon_small.gif" CommandName="ExtraBarcode" runat="server"></asp:ImageButton>
									</ITEMTEMPLATE>
								</ASP:TEMPLATECOLUMN>
								
	 <ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="1%" HeaderText="StyleAssortmentdetailID"
									 DataField="StyleAssortmentdetailID" visible="false">
							 	<headerstyle horizontalalign="center" width="1%" />
								</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="1%" HeaderText="DownloadBit"
								  DataField="DownloadBit" visible="false" />
							</COLUMNS>
						</SMART:SMARTDATAGRID>
						</div> 
												</td>
	</tr>
			</table>
</asp:Content>

