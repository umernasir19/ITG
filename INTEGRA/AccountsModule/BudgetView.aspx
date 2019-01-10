<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="BudgetView.aspx.vb" Inherits="Integra.BudgetView" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%">
 <tr>
    <td align="right">
     <telerik:RadButton ID="btnAdd" runat="server" Text="Create Budget" Skin="WebBlue">
                    </telerik:RadButton>
       
    </td>
    </tr>
<tr>
<td>
        <smart:smartdatagrid id="dgPurchaseOrder" runat="server" width="100%" OnSortCommand="SortByColumn"
	 OnPageIndexChanged="PageChanged" OnItemDataBound="DataBound" AllowPaging="True" AllowSorting="True"
	  AutoGenerateColumns="False" CellPadding="4" CssClass="table" PagerCurrentPageCssClass=""
	   PagerOtherPageCssClass="" PageSize="15" RecordCount="0" ShowFooter="True" SortedAscending="yes"
	    ForeColor="White">
 					
							<COLUMNS>
							<ASP:BOUNDCOLUMN HeaderText="BudgetCreateMasterId"
							  DataField="BudgetCreateMasterId" visible="False" >
                                <itemstyle horizontalalign="Left" />
								 <headerstyle width="2%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
                            	<ASP:BOUNDCOLUMN HeaderText="Month"
							  DataField="Month"  >
                                <itemstyle horizontalalign="Left" />
								 <headerstyle width="2%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
                            	<ASP:BOUNDCOLUMN HeaderText="Remittance ($)"
							  DataField="Remittance"   >
                                <itemstyle horizontalalign="Left" />
								 <headerstyle width="2%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
								 
						 <ASP:TEMPLATECOLUMN HeaderText="PDF">
                                        <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
								  	<asp:ImageButton id="lnkPDF" tooltip="Click here to download PDF"
                                     ImageUrl="~/Images/pdf_icon_small.gif" CommandName="PDF" runat="server"></asp:ImageButton>
										 </ITEMTEMPLATE>
										 <headerstyle width="2%" horizontalalign="Center"  />
								</ASP:TEMPLATECOLUMN>
                                	 <ASP:TEMPLATECOLUMN HeaderText="Remove">
                                        <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
								  	<asp:ImageButton id="lnkDelete" tooltip="Click here to Delete Budget"
                                     ImageUrl="~/Images/RemoveIcon.png" CommandName="Delete" runat="server"></asp:ImageButton>
										 </ITEMTEMPLATE>
										 <headerstyle width="2%" horizontalalign="Center"  />
								</ASP:TEMPLATECOLUMN>
							
							 </COLUMNS>
		 <PagerStyle CssClass="GridPagerStyle" Mode="NumericPages" HorizontalAlign="Right"    />
	        <AlternatingItemStyle CssClass="GridAlternativeRow" />
        <ItemStyle CssClass="GridRow" />
        <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                                                  
						</smart:smartdatagrid>
</td>
</tr>
</table>

</asp:Content>