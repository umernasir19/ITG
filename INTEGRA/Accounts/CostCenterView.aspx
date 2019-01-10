<%@ Page Title="Cost Center View" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="CostCenterView.aspx.vb" Inherits="Integra.CostCenterView" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" >
<tr>
<td align="right">
<asp:button id="btndAdd"  runat="server" CssClass="button" Text="ADD Cost" width="150"></asp:button>
</td>
</tr>
<tr   >
<td  >     <br />                         
						<SMART:SMARTDATAGRID id="dgView" runat="server" width="100%" OnSortCommand="SortByColumn" OnPageIndexChanged="PageChanged"
							OnItemDataBound="DataBound" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table" 
							  PageSize="1000"   ShowFooter="True"  ForeColor="white" GridLines="both">
							<COLUMNS>
								<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="ID"
								  DataField="CostCenterID" visible="false" />
							  <ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="center"  HeaderText="Category"
									 DataField="Category" >
							 	<headerstyle horizontalalign="center" width="5%" />
								</ASP:BOUNDCOLUMN>
								 <ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="center"  HeaderText="Cost"
									 DataField="Cost" >
							 	<headerstyle horizontalalign="center" width="5%" />
								</ASP:BOUNDCOLUMN>
									
														   
								 <ASP:TEMPLATECOLUMN   ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="EDIT">
									<ITEMTEMPLATE>																	
										<asp:ImageButton id="lnkEdit" tooltip="Click here to edit"  ImageUrl="~/Images/editIcon.jpg" CommandName="Edit" runat="server"></asp:ImageButton>
									</ITEMTEMPLATE>
								</ASP:TEMPLATECOLUMN>
								 	 
							</COLUMNS>
						</SMART:SMARTDATAGRID>
												</td>
	</tr>
			</table>
</asp:Content>



