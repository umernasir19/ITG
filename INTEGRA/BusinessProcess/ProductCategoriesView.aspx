<%@ Page Language="vb"  MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeBehind="ProductCategoriesView.aspx.vb" Inherits="Integra.ProductCategoriesView" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <table width="100%">
 	<tr>
 <td align="right">
 
     <telerik:RadButton ID="btnAdd" runat="server" Text="Add Product Categories"  width="180" Skin="WebBlue">
                    </telerik:RadButton>
 </td>
 </tr>
<tr><td  >
	<SMART:SMARTDATAGRID id="dgPurchaseOrder" runat="server" width="100%" OnSortCommand="SortByColumn"
	 OnPageIndexChanged="PageChanged" OnItemDataBound="DataBound" AllowPaging="True" AllowSorting="True"
	  AutoGenerateColumns="False" CellPadding="4" CssClass="table" PagerCurrentPageCssClass=""
	   PagerOtherPageCssClass="" PageSize="18" RecordCount="0" ShowFooter="True"  
	    ForeColor="White">
 					
							<COLUMNS>
                             <ASP:BOUNDCOLUMN HeaderText="ProductCategoriesID"
									 DataField="ProductCategoriesID" Visible="false ">
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="20%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
							 <ASP:BOUNDCOLUMN HeaderText="Product Portfolio"
									 DataField="ProductPortfolio" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="20%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
									<ASP:BOUNDCOLUMN HeaderText="Product Categories"
									DataField="ProductCategories" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="20%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>



                            <ASP:TEMPLATECOLUMN HeaderText="Edit" Visible ="true" >
                                    <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
<asp:HyperLink id="lnkEdit" Runat="server" NavigateUrl='<%# "ProductCategoriesEntry.aspx?lProductCategoriesID=" &amp; DataBinder.Eval(Container.DataItem,"ProductCategoriesID")%>' Enabled="true">
											Edit
										</asp:HyperLink> 
</ITEMTEMPLATE>
                                    <headerstyle width="10%" />
								</ASP:TEMPLATECOLUMN>
                            
                                   <ASP:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="01%" HeaderText="EDIT" Visible="false" >
									<ITEMTEMPLATE>																	
										<asp:ImageButton id="lnkEdit1" tooltip="Click here to edit"  ImageUrl="~/Images/editIcon.jpg" CommandName="Edit" runat="server"></asp:ImageButton>
									</ITEMTEMPLATE>
								</ASP:TEMPLATECOLUMN>

                                <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="REMOVE"  visible="true">
                            <itemtemplate>									 								
										<asp:ImageButton id="lnkRemove" tooltip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png" OnClientClick="return confirm('OK to Delete?');" CommandName="Remove" runat="server"  ></asp:ImageButton>
									</itemtemplate>
                        </asp:TEMPLATECOLUMN>


							 </COLUMNS>
		 <PagerStyle CssClass="GridPagerStyle" Mode="NumericPages" HorizontalAlign="Right"    />
	        <AlternatingItemStyle CssClass="GridAlternativeRow" />
        <ItemStyle CssClass="GridRow" />
        <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                                                  
						</SMART:SMARTDATAGRID></td>
						
						
</tr>
 
</table>


 </asp:Content> 
