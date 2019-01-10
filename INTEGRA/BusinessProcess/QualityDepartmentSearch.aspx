<%@ Page Language="vb" AutoEventWireup="false"  MasterPageFile="~/MasterPage.master"  CodeBehind="QualityDepartmentSearch.aspx.vb" Inherits="Integra.QualityDepartmentSearch" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table width="100%">
             
              <tr>
              <td>
              
              </td>
              <td>
                  <asp:Label ID="lblMsg" runat="server"  CssClass="ErrorMsg"></asp:Label>
              
              </td>
              </tr>
              <tr>
              <td  >
              QD :
              </td>
              <td align="left">
                  <asp:DropDownList ID="cmbQD"  AutoPostBack="true" runat="server" Width="144px">
                  </asp:DropDownList>
              </td>
              </tr>
           <tr>
<td   valign="top">
   
    <asp:Label ID="lblForm" runat="server" Text="From :"></asp:Label>
   </td>
<td class="NormalBoldText"  valign="top">

<asp:TextBox ID="txtDateFrom" runat="server" CssClass="textbox" Width="90px" TabIndex="2"></asp:TextBox>
    <cc1:calendarextender ID="CalendarExtender3" Format="dd/MM/yyyy" 
        EnableViewState="true"   runat="server"  TargetControlID="txtDateFrom" 
        PopupButtonID="ImageButton2"/>
<asp:ImageButton runat="Server" CausesValidation="false" ID="ImageButton2" ImageUrl="~/Images/calendar.jpg" AlternateText="Click here to display calendar" /> 
 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtDateFrom"  CssClass="ErrorMsg" Runat="server" ErrorMessage="Required!!!" Font-Bold="True" ></asp:RequiredFieldValidator>
</td>
   <td class="NormalBoldText">
        </td>

<td  valign="top">

    <asp:Label ID="lblTo" runat="server" Text="To :"></asp:Label>
</td>

<td class="NormalBoldText" valign="top">

 <asp:TextBox ID="txtDateTo" runat="server" CssClass="textbox" Width="90px"  TabIndex="2"></asp:TextBox>&nbsp;
	<cc1:calendarextender ID="CalendarExtender1" Format="dd/MM/yyyy" 
        EnableViewState="true"   runat="server"  TargetControlID="txtDateTo" 
        PopupButtonID="ImageButton1"/>
<asp:ImageButton runat="Server" CausesValidation="false"  ID="ImageButton1" ImageUrl="~/Images/calendar.jpg" AlternateText="Click here to display calendar" /> 

	<asp:RequiredFieldValidator ID="Rfvpo" ControlToValidate="txtDateTo"  CssClass="ErrorMsg" Runat="server" ErrorMessage="Required!!!" Font-Bold="True" ></asp:RequiredFieldValidator>
	   
</td>
<td>      
    </td>
    <td>
    </td>
</tr>
              <tr>
              <td></td>
              <td>
                  <asp:Button ID="btnSearch" CssClass="button" runat="server" Text="Search" />
              </td>
                <td>
               
              </td>
              </tr>
              
</table> 
    <div style="vertical-align:top; height: 352px; overflow:auto;width:770px; border-style:groove; border-color:Navy;">
<table width="100%">
<tr><td>
	 <SMART:SMARTDATAGRID id="dgPurchaseOrder" runat="server" width="100%" CssClass="tablemultigrid" 
      OnSortCommand="SortByColumn" OnPageIndexChanged="PageChanged" AutoGenerateColumns="False" CellPadding="3"
         SortedAscending="yes" ForeColor="White" GridLines="both" PagerCurrentPageCssClass=""
          PagerOtherPageCssClass="" PageSize="1000" RecordCount="0" AllowPaging="True" AllowSorting="True" ShowFooter="True">
							<COLUMNS>
								<ASP:BOUNDCOLUMN HeaderText="Activity Date"   DataField="CreationDate" >
                                    <headerstyle horizontalalign="Left" width="10%" />
                                    <itemstyle horizontalalign="Left" />
                                </ASP:BOUNDCOLUMN>
                                	<ASP:BOUNDCOLUMN HeaderText="PO. No"   DataField="PONo" >
                                    <headerstyle horizontalalign="Left" width="10%" />
                                    <itemstyle horizontalalign="Left" />
                                </ASP:BOUNDCOLUMN>
                                	<ASP:BOUNDCOLUMN HeaderText="customer"   DataField="customerName" >
                                    <headerstyle horizontalalign="Left" width="10%" />
                                    <itemstyle horizontalalign="Left" />
                                </ASP:BOUNDCOLUMN>
                                	<ASP:BOUNDCOLUMN HeaderText="Supplier"   DataField="VenderName" >
                                    <headerstyle horizontalalign="Left" width="10%" />
                                    <itemstyle horizontalalign="Left" />
                                </ASP:BOUNDCOLUMN>
                                	<ASP:BOUNDCOLUMN HeaderText="Style"   DataField="styleNo" >
                                    <headerstyle horizontalalign="Left" width="10%" />
                                    <itemstyle horizontalalign="Left" />
                                </ASP:BOUNDCOLUMN>
                                	<ASP:BOUNDCOLUMN HeaderText="Article"   DataField="Article" >
                                    <headerstyle horizontalalign="Left" width="10%" />
                                    <itemstyle horizontalalign="Left" />
                                </ASP:BOUNDCOLUMN>
                                
                                
                                <ASP:BOUNDCOLUMN HeaderText="QD Name"  DataField="Username" >
                                     <headerstyle horizontalalign="Left" width="12%" />
                                    <itemstyle horizontalalign="Left" />
                                </ASP:BOUNDCOLUMN>
                                <ASP:BOUNDCOLUMN HeaderText="Inspection Date"  DataField="InspectionDate" >
                                     <headerstyle horizontalalign="Left" width="14%" />
                                    <itemstyle horizontalalign="Left" />
                                </ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN HeaderText="Inspected Qty"   DataField="InspectedQty" >
                                   <headerstyle horizontalalign="Left" width="14%" />
                                    <itemstyle horizontalalign="Left" />
                                </ASP:BOUNDCOLUMN>
								
								<ASP:BOUNDCOLUMN HeaderText="Insp. Type"  DataField="InspectionStatus" >
                                     <headerstyle horizontalalign="Left" width="10%" />
                                    <itemstyle horizontalalign="Left" />
                                </ASP:BOUNDCOLUMN>
                                	<ASP:BOUNDCOLUMN HeaderText="Insp. Status"  DataField="InspStatus" >
                                     <headerstyle horizontalalign="Left" width="10%" />
                                    <itemstyle horizontalalign="Left" />
                                </ASP:BOUNDCOLUMN>
                                <ASP:BOUNDCOLUMN HeaderText="QD Remarks"   DataField="Remarks" >
                                     <headerstyle horizontalalign="Left" width="60%" />
                                    <itemstyle horizontalalign="Left" />
                                </ASP:BOUNDCOLUMN>
						    </COLUMNS>
                <PagerStyle CssClass="GridPagerStyle" HorizontalAlign="Right" Mode="NumericPages" />
                <AlternatingItemStyle CssClass="GridAlternativeRow" />
                <ItemStyle CssClass="GridRow" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
               			</SMART:SMARTDATAGRID>
		
		
		</td>
		
		
						
						
</tr>
</table>
</div> 
</asp:Content> 