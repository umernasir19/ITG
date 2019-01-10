<%@ Page Title="Size Range View" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="SizeRangeView_A.aspx.vb" Inherits="Integra.SizeRangeView_A" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" >
<tr>
 <td align="right">
 <asp:button id="btnAdd"  runat="server" CssClass="button" Text="ADD SIZE RANGE" width="140"></asp:button>
 </td>
 </tr>
<tr>
<td>                              
	<Smart:SMARTDATAGRID id="dgView"  Font-Size="15pt" runat="server" width="100%" 
												AllowSorting="True" AutoGenerateColumns="False" CellPadding="2" CssClass="table" 
										 PageSize="100"  
												ShowFooter="False"   ForeColor="white" GridLines="both">
														<COLUMNS>
							  <ASP:BOUNDCOLUMN visible="false" ItemStyle-HorizontalAlign="center" 
								  HeaderText="SizeRangeID"
									 DataField="SizeRangeID" >
							 	<headerstyle horizontalalign="center" width="2%" />
								</ASP:BOUNDCOLUMN>
								
								 
								 
									 <ASP:BOUNDCOLUMN visible="false" ItemStyle-HorizontalAlign="center"  
								  HeaderText="SizeDatabaseID"
									 DataField="SizeDatabaseID" >
							 	<headerstyle horizontalalign="center" width="2%" />
								</ASP:BOUNDCOLUMN>
							 
						 	     <ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="center"  
								  HeaderText="GENDER"
									 DataField="Gender" >
							 	<headerstyle horizontalalign="center" width="7%" />
								</ASP:BOUNDCOLUMN>
								
								   <ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="center"  
								  HeaderText="SIZE GROUP"
									 DataField="SizeGroup" >
							 	<headerstyle horizontalalign="center" width="7%" />
								</ASP:BOUNDCOLUMN>
								
								   <ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="center"  
								  HeaderText="SIZE RANGE"
									 DataField="SizeRange" >
							 	<headerstyle horizontalalign="center" width="7%" />
								</ASP:BOUNDCOLUMN>
								
								   <ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="center"  
								  HeaderText="SIZE"
									 DataField="Sizes" >
							 	<headerstyle horizontalalign="center" width="3%" />
								</ASP:BOUNDCOLUMN>
								
								   <ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="center"  
								  HeaderText="RATIO"
									 DataField="Ratio" >
							 	<headerstyle horizontalalign="center" width="3%" />
								</ASP:BOUNDCOLUMN>
								 <ASP:TEMPLATECOLUMN HeaderText="EDIT">
									<ITEMTEMPLATE>
    							  <asp:ImageButton id="lnkEdit" tooltip="Click here to edit"  ImageUrl="~/Images/editIcon.jpg" CommandName="Edit" runat="server"></asp:ImageButton>
        						 </ITEMTEMPLATE>
                                     <headerstyle width="2%" />
                                     <itemstyle horizontalalign="Center" />
								</ASP:TEMPLATECOLUMN>
                      
								    </COLUMNS>
                 <PagerStyle   Visible="False" CssClass="GridPagerStyle" Mode="NumericPages" HorizontalAlign="Right" />
                 <AlternatingItemStyle CssClass="GridAlternativeRow" />
                  <ItemStyle CssClass="GridRow" />
                 <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
				 </Smart:SMARTDATAGRID>				 
 </td>
 </tr>
 </table>
 
 
 
</asp:Content>


