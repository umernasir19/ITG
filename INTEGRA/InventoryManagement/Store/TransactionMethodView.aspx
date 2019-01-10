<%@ Page Title="Transaction Method View" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="TransactionMethodView.aspx.vb" Inherits="Integra.TransactionMethodView" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table  style="width: 100%">
<tr>
    
 <td style="width: 918px" align="right">
 <asp:button id="cmdAdd"  runat="server" CssClass="button" Text="Add Transaction Method " width="200"></asp:button>
 </td>
 </tr>
  <tr style="height: 5px"></tr>
<tr><td align="center" valign="top" style="width: 918px">
<table width="100%" >
<tr   >
<td  >                              
						<SMART:SMARTDATAGRID id="dgTransaction" runat="server" width="100%" OnSortCommand="SortByColumn" OnPageIndexChanged="PageChanged"
							OnItemDataBound="DataBound" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table" 
							PagerCurrentPageCssClass="" PagerOtherPageCssClass="" 
							PageSize="100" RecordCount="0" ShowFooter="True"  ForeColor="white" GridLines="None">
							<COLUMNS>
								<ASP:BOUNDCOLUMN HeaderText="ID"
								 DataField="TransactionMethodID" visible="False" >
                                    <headerstyle width="5%" />
                                    <itemstyle horizontalalign="Center" />
                                </ASP:BOUNDCOLUMN>
								 
								<ASP:BOUNDCOLUMN HeaderText="Item Name"
								 DataField="ItemName" >
							 	<headerstyle horizontalalign="Center" width="7%" />
                                    <itemstyle horizontalalign="Center" />
								</ASP:BOUNDCOLUMN>	
								<ASP:BOUNDCOLUMN  HeaderText="Transaction Method"
									  DataField="TransactionMethod" >
							 	<headerstyle horizontalalign="Center" width="7%" />
                                    <itemstyle horizontalalign="Center" />
								</ASP:BOUNDCOLUMN>
								 
								 <ASP:TEMPLATECOLUMN HeaderText="Edit">
									<ITEMTEMPLATE>
																	
 <asp:ImageButton id="lnkEdit" tooltip="Click here to edit"  ImageUrl="~/Images/editIcon.jpg" CommandName="Edit" runat="server"></asp:ImageButton>
									
</ITEMTEMPLATE>
                                     <headerstyle width="5%" />
                                     <itemstyle horizontalalign="Center" />
								</ASP:TEMPLATECOLUMN>
								 
							</COLUMNS>
                            <PagerStyle CssClass="GridPagerStyle" HorizontalAlign="Right" Mode="NumericPages" />
                            <AlternatingItemStyle CssClass="GridAlternativeRow" />
                            <ItemStyle CssClass="GridRow" />
                            <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
						</SMART:SMARTDATAGRID>
												</td>
	</tr>
			</table>
	</td></tr>
 
</table>

</asp:Content>
