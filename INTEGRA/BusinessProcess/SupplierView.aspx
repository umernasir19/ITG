<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="SupplierView.aspx.vb" Inherits="Integra.SupplierView" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:Panel ID ="mainpnl" runat ="server" Visible ="false"  >
<table>
  <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="6" align="left" style="font-family:Century Gothic ; font-size: 16PX; font-weight: bold;
                color:Blue ">
             <marquee >Searching Criteria For Supplier Code,Supplier,Category</marquee>
            </th>
        </tr>
</table>
<br />
<table>
<tr>
        <td>
        Search
        </td>
        <td align="right" >
          <asp:TextBox CssClass="textbox" ID="txtSearch" AutopostBack="true"  style="height :20px; margin-left: 10px;" runat="server" ReadOnly="false" ></asp:TextBox>
           <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="10"
                                        CompletionSetCount="12" ContextKey="SearchingFromRNDSupplierView" EnableCaching="true" MinimumPrefixLength="1"
                                        ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtSearch" />

        </td>
            
        </tr>
</table>
</asp:Panel>
<br />
 <table  width="100%" >
 <tr>
 <td align ="right" > 
<asp:button id="cmdAdd" runat="server" Width="100"  Text="Add Supplier"  CssClass="button"></asp:button>
 
 </td>
</tr>
 
<tr><td>
<SMART:SMARTDATAGRID id="dgSupplierDataBase" runat="server" width="100%" OnSortCommand="SortByColumn" OnPageIndexChanged="PageChanged"
 OnItemDataBound="DataBound" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4"
  CssClass="table"  PageSize="200"  
  ShowFooter="True" SortedAscending="yes" ForeColor="white" GridLines="both">
													<COLUMNS>
													<ASP:BOUNDCOLUMN HeaderText="IMSSupplierId"
									SortExpression="SupplierDatabaseId" DataField="SupplierDatabaseId" visible="False" >
                                <itemstyle horizontalalign="Left" />
								 <headerstyle width="2%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
								 <ASP:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="4%" HeaderText="S No.">
								<ITEMTEMPLATE>
							<asp:Label ID="lblSNo" runat="server" >					
							 </asp:Label>
							  <itemstyle horizontalalign="Center" />
								 <headerstyle width="4%" horizontalalign="Center"  />
									 </ITEMTEMPLATE>
								</ASP:TEMPLATECOLUMN>						
								
								<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="SUPPLIER CODE"
								 DataField="SupplierCode"  >
									 <itemstyle horizontalalign="Center" />
								 <headerstyle width="15%" horizontalalign="Center"  />
								 </ASP:BOUNDCOLUMN> 
								<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="SUPPLIER"
				                 DataField="SupplierName"  >
									<itemstyle horizontalalign="Center" />
								 <headerstyle width="15%" horizontalalign="Center"  />
								 </ASP:BOUNDCOLUMN> 								
								<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="CONTACT NO."
								  DataField="TelephoneNo"  >
									<itemstyle horizontalalign="Center" />
								 <headerstyle width="15%" horizontalalign="Center"  />
								 </ASP:BOUNDCOLUMN>
								 	<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="CAT."
								  DataField="SupplierCategory"  >
									<itemstyle horizontalalign="Center" />
								 <headerstyle width="15%" horizontalalign="Center"  />
								 </ASP:BOUNDCOLUMN> 										
								<ASP:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="5%" HeaderText="EDIT">
								 <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
										<asp:ImageButton id="lnkEdit" tooltip="Click here to edit Supplier"  ImageUrl="~/Images/editIcon.jpg"  CommandName="Edit"  Runat="server"></asp:ImageButton>
										</ITEMTEMPLATE>
								</ASP:TEMPLATECOLUMN>
								 
								<ASP:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="5%" HeaderText="REMOVE">
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
</asp:Content>
