<%@ Page Language="vb" MasterPageFile="~/MasterPage.master"  AutoEventWireup="false" CodeBehind="DebitNoteView.aspx.vb" Inherits="Integra.DebitNoteView" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <table width="100%">
 <tr>
    <td align="right">
     <telerik:RadButton ID="btnAdd" runat="server" Text="Create Debit Note" Skin="WebBlue">
                    </telerik:RadButton>
       
    </td>
    </tr>
 <tr>
 <td>
 <SMART:SMARTDATAGRID id="dgPurchaseOrder" runat="server" width="100%" OnSortCommand="SortByColumn"
	 OnPageIndexChanged="PageChanged" OnItemDataBound="DataBound" AllowPaging="True" AllowSorting="True"
	  AutoGenerateColumns="False" CellPadding="4" CssClass="table" PagerCurrentPageCssClass=""
	   PagerOtherPageCssClass="" PageSize="15" RecordCount="0" ShowFooter="True" SortedAscending="yes"
	    ForeColor="White">
 					
							<COLUMNS>
							<ASP:BOUNDCOLUMN HeaderText="DebitNoteID"
							  DataField="DebitNoteID" visible="False" >
                                <itemstyle horizontalalign="Left" />
								 <headerstyle width="2%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
                            	<ASP:BOUNDCOLUMN HeaderText="CommissionMonth"
							  DataField="CommissionMonth" visible="False" >
                                <itemstyle horizontalalign="Left" />
								 <headerstyle width="2%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
                            	<ASP:BOUNDCOLUMN HeaderText="CommissionYear"
							  DataField="CommissionYear" visible="False" >
                                <itemstyle horizontalalign="Left" />
								 <headerstyle width="2%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN HeaderText="Customer"
									 DataField="CustomerNamePart" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
								 <ASP:TEMPLATECOLUMN HeaderText="DN Month">
                                    <itemstyle horizontalalign="Left" />
									<ITEMTEMPLATE>
                              <asp:Label id="DNMonth" runat="server" ></asp:Label>
                                    </ITEMTEMPLATE>
                                    <headerstyle width="10%" horizontalalign="Left" />
								</ASP:TEMPLATECOLUMN>
							 <ASP:BOUNDCOLUMN HeaderText="Currency"
									 DataField="Currency" >
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN HeaderText="Amount"
									 DataField="Totalvaluee">
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
						 <ASP:TEMPLATECOLUMN HeaderText="PDF">
                                        <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
								  	<asp:ImageButton id="lnkPDF" tooltip="Click here to download PDF" ImageUrl="~/Images/pdf_icon_small.gif" CommandName="PDF" runat="server"></asp:ImageButton>
										 </ITEMTEMPLATE>
										 <headerstyle width="2%" horizontalalign="Center"  />
								</ASP:TEMPLATECOLUMN>
							
							 </COLUMNS>
		 <PagerStyle CssClass="GridPagerStyle" Mode="NumericPages" HorizontalAlign="Right"    />
	        <AlternatingItemStyle CssClass="GridAlternativeRow" />
        <ItemStyle CssClass="GridRow" />
        <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                                                  
						</SMART:SMARTDATAGRID>
 </td>
 </tr>
 </table>
 
 </asp:Content>