<%@ Page Language="vb"  MasterPageFile="~/MasterPage.master"   AutoEventWireup="false" CodeBehind="CPChartHistoryView.aspx.vb" Inherits="Integra.CPChartHistoryView" %>
 <%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div style="vertical-align:top;  overflow:scroll ;width:100%; border-style:groove; ">
 <b>
 <table width="50%">
 <tr>
 <td>
 PO No.
 </td>
 <td>
  <asp:Label ID="lblPONO" runat="server"></asp:Label>
 </td>
 </tr>
 <tr>
  <td>
 Customer
 </td>
 <td>
 <asp:Label ID="lblCustomer" runat="server"></asp:Label>
 </td>
  </tr>
 
 <tr>
  <td>
 Style
 </td>
 <td>
 <asp:Label ID="lblStyle" runat="server"></asp:Label>
 </td>

 </tr>
  <tr>
  <td>
Shipment Date
 </td>
 <td>
 <asp:Label ID="lblShipemntDate" runat="server"></asp:Label>
 </td>
 
 </tr>
  <tr>
  <td>
Process
 </td>
 <td>
 <asp:Label ID="lblProcess" runat="server"></asp:Label>
 </td>
 
 </tr>
</table>
 </b>
 <table width="100%">
 <tr>
 <td>
  	<SMART:SMARTDATAGRID id="dgPurchaseOrder" runat="server" width="110%" OnSortCommand="SortByColumn"
	 OnPageIndexChanged="PageChanged" OnItemDataBound="DataBound" AllowPaging="True" AllowSorting="True"
	  AutoGenerateColumns="False" CellPadding="4" CssClass="table" PagerCurrentPageCssClass=""
	   PagerOtherPageCssClass="" PageSize="50" RecordCount="0" ShowFooter="True" SortedAscending="yes"
	    ForeColor="White">
 					 	<COLUMNS>
						  <ASP:BOUNDCOLUMN HeaderText="Activity Date"
							 DataField="CreationDatee" >
                             <itemstyle horizontalalign="Left" />
							 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
                               <ASP:BOUNDCOLUMN HeaderText="Quantity"
							 DataField="Quantity" >
                             <itemstyle horizontalalign="Left" />
							 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
                               <ASP:BOUNDCOLUMN HeaderText="Target Submission"
							 DataField="TargetSubmissionn" >
                             <itemstyle horizontalalign="Left" />
							 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
                               <ASP:BOUNDCOLUMN HeaderText="Ist Submission"
							 DataField="IstSubmissionn" >
                             <itemstyle horizontalalign="Left" />
							 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
                               <ASP:BOUNDCOLUMN HeaderText="DHL / FEDEX"
							 DataField="DHLorFEDEX" >
                             <itemstyle horizontalalign="Left" />
							 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
                               <ASP:BOUNDCOLUMN HeaderText="Feed Back Received"
							 DataField="FeedBackReceived" >
                             <itemstyle horizontalalign="Left" />
							 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
                               <ASP:BOUNDCOLUMN HeaderText="Revised Target"
							 DataField="RevisedTargett" >
                             <itemstyle horizontalalign="Left" />
							 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
                               <ASP:BOUNDCOLUMN HeaderText="Revised Submission"
							 DataField="RevisedSubmissionn" >
                             <itemstyle horizontalalign="Left" />
							 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
                               <ASP:BOUNDCOLUMN HeaderText="DHL / FEDEX"
							 DataField="DHLorFEDEX1" >
                             <itemstyle horizontalalign="Left" />
							 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
                               <ASP:BOUNDCOLUMN HeaderText="Feed Back Received"
							 DataField="FeedBackReceived1" >
                             <itemstyle horizontalalign="Left" />
							 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
                               <ASP:BOUNDCOLUMN HeaderText="Remarks"
							 DataField="Remarks" >
                             <itemstyle horizontalalign="Left" />
							 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
                              
                           </COLUMNS>
		 <PagerStyle CssClass="GridPagerStyle" Mode="NumericPages" HorizontalAlign="Right"    />
	        <AlternatingItemStyle CssClass="GridAlternativeRow" />
        <ItemStyle CssClass="GridRow" />
        <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
      </SMART:SMARTDATAGRID>
 </td>
 </tr>
 </table>
 </div> 

</asp:Content> 