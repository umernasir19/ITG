<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="RequisitionerRequestApproval.aspx.vb" Inherits="Integra.RequisitionerRequestApproval" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <table width="100%">
 	<tr>
 <td align="right">
 
     <telerik:RadButton ID="cmdAdd" runat="server" Text="Booked Exchange Rate Add"  width="180" Skin="WebBlue" Visible= "false">
                    </telerik:RadButton>
 </td>
 </tr>
<tr><td>
	<SMART:SMARTDATAGRID id="dgApproval" runat="server" width="100%" 
	 AllowPaging="True" AllowSorting="True"
	  AutoGenerateColumns="False" CellPadding="4" CssClass="table" PagerCurrentPageCssClass=""
	   PagerOtherPageCssClass="" PageSize="15" RecordCount="0" ShowFooter="True" SortedAscending="yes"
	    ForeColor="white" GridLines="Both">
 					
							<COLUMNS>
							<ASP:BOUNDCOLUMN HeaderText="InventoryRequestMasterID"
								  DataField="InventoryRequestMasterID" visible="false" >
                                <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN visible="true" HeaderText="Requisitioner Name"
									 DataField="RequisitionerName" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
						
							
									<ASP:TEMPLATECOLUMN HeaderText="Approval">
                                    <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>

<asp:LinkButton id="lnkEdit" Runat="server" CommandName="Approval"   Enabled="true" Text="Approval">
											
										</asp:LinkButton> 
</ITEMTEMPLATE>
                                    <headerstyle width="10%" />
								</ASP:TEMPLATECOLUMN>
							</COLUMNS>
		 <PagerStyle CssClass="GridPagerStyle" Mode="NumericPages" HorizontalAlign="Right"    />
	        <AlternatingItemStyle CssClass="GridAlternativeRow" />
        <ItemStyle CssClass="GridRow" />
        <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                                                  
						</SMART:SMARTDATAGRID></td>
						
						
</tr>
 
</table>
    

 </asp:Content> 