<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="QualityDepartmentHistory.aspx.vb" Inherits="Integra.QualityDepartmentHistory" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quality Department Inspection History Page</title>
     <link href= "../App_Themes/Blue/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <div>
           <table><tr><td style="height:5px;">
           
           </td></tr></table>
            <table>
           
 <tr>
            <td><asp:Label ID="lblPONo" runat="server" CssClass="labelNew" Font-Size="Medium"  ></asp:Label></td>            
            </tr>
             <tr>
            <td><asp:Label ID="lblCustomer" runat="server" CssClass="labelNew" Font-Size="Medium" ></asp:Label></td>            
            </tr>
             <tr>
            <td><asp:Label ID="lblVendor" runat="server" CssClass="labelNew" Font-Size="Medium" ></asp:Label></td>            
            </tr>
             <tr>
            <td><asp:Label ID="lblStyleNO" runat="server" CssClass="labelNew" Font-Size="Medium" ></asp:Label></td>            
            </tr>
            <tr>
            <td><asp:Label ID="lblArticle" runat="server" CssClass="labelNew" Font-Size="Medium" ></asp:Label></td>            
            </tr>
            
            </table>
            
            <table width="100%">
              <tr>
            <td align="center"><asp:Label ID="lblmsg" runat="server" CssClass="ErrorMsg" Font-Size="Medium"  ></asp:Label></td>            
            </tr>
            <tr>
            <td>
            <SMART:SMARTDATAGRID id="dgQDInspectionHistory" runat="server" width="100%" CssClass="tablemultigrid"  OnSortCommand="SortByColumn" OnPageIndexChanged="PageChanged" AutoGenerateColumns="False" CellPadding="3"   SortedAscending="yes" ForeColor="White" GridLines="both" PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="500" RecordCount="0" AllowPaging="True" AllowSorting="True" ShowFooter="True">
							<COLUMNS>
                               <ASP:BOUNDCOLUMN HeaderText="QDInspectionID"
								  DataField="QDInspectionID" visible="False" >
                                <itemstyle horizontalalign="Left" />
								 <headerstyle width="2%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
                            <ASP:BOUNDCOLUMN HeaderText="POID"
								  DataField="POID" visible="False" >
                                <itemstyle horizontalalign="Left" />
								 <headerstyle width="2%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
							<ASP:BOUNDCOLUMN HeaderText="PoDetailID"
								  DataField="PoDetailID" visible="False" >
                                <itemstyle horizontalalign="Left" />
								 <headerstyle width="2%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>

								<ASP:BOUNDCOLUMN HeaderText="Activity Date"   DataField="CreationDate" >
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
                                <ASP:TEMPLATECOLUMN  HeaderText="Edit">
							  <ITEMTEMPLATE>
						   <asp:HyperLink id="lnkEdiut" Tooltip="To Edit QD Inspection." Enabled ="true" NavigateUrl='<%# "QualityDepartmentPopupEdit.aspx?lPOID="& DataBinder.Eval(Container.DataItem,"POID")&"&lPODetailID="& DataBinder.Eval(Container.DataItem,"PoDetailID")&"&QDInspectionID="& DataBinder.Eval(Container.DataItem,"QDInspectionID")%>' Runat="server">Edit</asp:HyperLink>
							       </ITEMTEMPLATE>
						 </ASP:TEMPLATECOLUMN>
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
</form>
</body>
</html>
