<%@ Page Language="vb"  MasterPageFile="~/MasterPage.master"  AutoEventWireup="false" CodeBehind="BookedExchangeView.aspx.vb" Inherits="Integra.BookedExchangeView" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <table width="100%">
 	<tr>
 <td align="right">
 
     <telerik:RadButton ID="cmdAdd" runat="server" Text="Booked Exchange Rate Add"  width="180" Skin="WebBlue">
                    </telerik:RadButton>
 </td>
 </tr>
<tr><td  >
	<SMART:SMARTDATAGRID id="dgBookedRate" runat="server" width="100%" OnSortCommand="SortByColumn"
	 OnPageIndexChanged="PageChanged" OnItemDataBound="DataBound" AllowPaging="True" AllowSorting="True"
	  AutoGenerateColumns="False" CellPadding="4" CssClass="table" PagerCurrentPageCssClass=""
	   PagerOtherPageCssClass="" PageSize="15" RecordCount="0" ShowFooter="True" SortedAscending="yes"
	    ForeColor="white" GridLines="Both">
 					
							<COLUMNS>
							<ASP:BOUNDCOLUMN HeaderText="BookedExchangeRateID"
								  DataField="BookedExchangeRateID" visible="False" >
                                <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN visible="true" HeaderText="Rate Month"
									 DataField="MonthRate" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
							<ASP:BOUNDCOLUMN visible="true" HeaderText="Exchange Rate"
									 DataField="BookedExchangeRate" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
							<ASP:BOUNDCOLUMN visible="true" HeaderText="Currency"
									 DataField="Currency" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
									<ASP:TEMPLATECOLUMN HeaderText="Edit" Visible ="true" >
                                    <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
<asp:HyperLink id="lnkEdit" Runat="server" NavigateUrl='<%# "BookedExchange.aspx?lBookedExchangeRateID=" &amp; DataBinder.Eval(Container.DataItem,"BookedExchangeRateID")%>' Enabled="true">
											Edit
										</asp:HyperLink> 
</ITEMTEMPLATE>
                                    <headerstyle width="10%" />
								</ASP:TEMPLATECOLUMN>





                                 <ASP:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="01%" HeaderText="EDIT" Visible = "false" >
									<ITEMTEMPLATE>																	
										<asp:ImageButton id="lnkEdit1" tooltip="Click here to edit"  ImageUrl="~/Images/editIcon.jpg" CommandName="Edit" runat="server"></asp:ImageButton>
									</ITEMTEMPLATE>
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