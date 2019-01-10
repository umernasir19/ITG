<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="FabricTypeView.aspx.vb" Inherits="Integra.FabricTypeView" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%">
 	<tr>
 <td align="right">
 
     <asp:Button ID="btnAdd" runat="server" Text="Add Fabric Type"  width="180" Skin="WebBlue">
                    </asp:Button>
 </td>
 </tr>
<tr><td  >
	 <Smart:SmartDataGrid ID="dgPurchaseOrder" runat="server" Width="100%" AllowPaging="False"
                                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                                PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="15" RecordCount="0"
                                ShowFooter="True" SortedAscending="yes" ForeColor="White">
 					
							<Columns>
                            <ASP:BOUNDCOLUMN HeaderText="FabricTypeID"
									 DataField="FabricTypeID" visible="false" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="20%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
							 <ASP:BOUNDCOLUMN HeaderText="Fabric Type"
									 DataField="FabricType" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="20%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
								 <ASP:TemplateColumn HeaderText="Edit" >
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Center"  />
                                    <ItemTemplate>
                                        <asp:HyperLink ID="lnkEdit" runat="server" NavigateUrl='<%# "FabricTypeEntry.aspx?lFabricTypeID=" &amp; DataBinder.Eval(Container.DataItem,"FabricTypeID")%>'
                                            Enabled="true">
										Edit
                                        </asp:HyperLink>
                                    </ItemTemplate>
                                   
                                </ASP:TemplateColumn>
                               <ASP:TemplateColumn HeaderText="REMOVE" >
                                 <ItemStyle HorizontalAlign="Center" />
                                 <HeaderStyle Width="5%" HorizontalAlign="Center"  />
                                <itemtemplate>									 								
										<asp:ImageButton id="lnkRemove" tooltip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png" OnClientClick="return confirm('OK to Delete?');" CommandName="Remove" runat="server"  ></asp:ImageButton>
									</itemtemplate>
                                      </ASP:TemplateColumn>
							 </Columns>
		 <PagerStyle CssClass="GridPagerStyle" Mode="NumericPages" HorizontalAlign="Right"    />
	        <AlternatingItemStyle CssClass="GridAlternativeRow" />
        <ItemStyle CssClass="GridRow" />
        <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                                                  
						</Smart:SmartDataGrid>
                        
                        
                        </td>
						
						
</tr>
 
</table>

</asp:Content>
