﻿<%@ Page Title="Currency View" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="CurrencyView.aspx.vb" Inherits="Integra.CurrencyView" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<table  width="800" >
<tr><td style="height:5px;"></td></tr>
<tr>
<td align ="right" >

<asp:button id="btnCurrency" runat="server"  Text="Add Currency" Font-Bold="True" 
        Font-Names="Calibri" Font-Size="Medium" Height="30px" Width="165px"></asp:button>

</td>
</tr>
<tr>
<td align="left" valign="top">
<table style="width: 928px" >
<tr><td>
<SMART:SMARTDATAGRID id="dgCurrency" runat="server" width="100%" OnSortCommand="SortByColumn" OnPageIndexChanged="PageChanged"
OnItemDataBound="DataBound" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4"
 CssClass="table" PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="200" RecordCount="0"
  ShowFooter="True"  ForeColor="white" GridLines="both">
													<COLUMNS>
													<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left"   
								HeaderText="Auto ID" DataField="IMSCurrencyID"  visible="False" >
								  <itemstyle horizontalalign="Center" />
								 <headerstyle width="4%" horizontalalign="Center"  />
								 </ASP:BOUNDCOLUMN> 
								 <ASP:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="4%" HeaderText="S No.">
								<ITEMTEMPLATE>
							<asp:Label ID="lblSNo" runat="server" >					
							 </asp:Label>
							  <itemstyle horizontalalign="Center" />
								 <headerstyle width="4%" horizontalalign="Center"  />
									 </ITEMTEMPLATE>
								</ASP:TEMPLATECOLUMN>						
													
								
								<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="Currency"
								 DataField="CurrencyName"  >
									 <itemstyle horizontalalign="Center" />
								 <headerstyle width="15%" horizontalalign="Center"  />
								 </ASP:BOUNDCOLUMN> 
							 								
								<ASP:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="5%" HeaderText="Edit">
								 <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
										<asp:ImageButton id="lnkEdit" tooltip="Click here to edit Currency"  ImageUrl="~/Images/editIcon.jpg"  CommandName="Edit"  Runat="server"></asp:ImageButton>
										</ITEMTEMPLATE>
								</ASP:TEMPLATECOLUMN>
								<ASP:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="5%" HeaderText="Remove">
								 <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
										 <asp:ImageButton id="lnkRemove" tooltip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png" CommandName="Remove" runat="server"></asp:ImageButton>
										</ITEMTEMPLATE>
								</ASP:TEMPLATECOLUMN>
							</COLUMNS>
						</SMART:SMARTDATAGRID>
						</td>
</tr>

</table>
</td></tr>


</table>
</asp:Content>


