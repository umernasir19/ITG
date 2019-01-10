<%@ Page Language="vb"  MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeBehind="ComplainDatabaseEntry.aspx.vb" Inherits="Integra.ComplainDatabaseEntry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
<tr>
<td>
Claim No.
</td>
<td>
    <asp:TextBox ID="txtClaimNo" CssClass="textbox" runat="server"></asp:TextBox>
</td>
<td>
Reclamation Type
</td>
<td>
    <asp:DropDownList ID="cmbReclamationType" CssClass="textbox" runat="server">
    </asp:DropDownList>
</td>
<td>
ANZ No
</td>
<td>
 <asp:TextBox ID="txtANZNo" CssClass="textbox" runat="server"></asp:TextBox>
</td>
<td>
Inspector Name
</td>
<td>
  <asp:TextBox ID="txtInspectorName" CssClass="textbox" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>
Customer 
</td>
<td>
  <asp:DropDownList ID="cmbCustomer" CssClass="textbox" runat="server" AutoPostBack="true">
    </asp:DropDownList>
</td>
<td>
Dept
</td>
<td>
  <asp:DropDownList ID="cmbDept" CssClass="textbox" runat="server" AutoPostBack="true">
    </asp:DropDownList>
</td>
<td>
Supplier
</td>
<td>
  <asp:DropDownList ID="cmbSupplier" CssClass="textbox" runat="server" AutoPostBack="true">
    </asp:DropDownList>
</td>
 
</tr>
<tr>
<td>
Season 
</td>
<td>
  <asp:DropDownList ID="cmbSeason" CssClass="textbox" runat="server" AutoPostBack="true">
    </asp:DropDownList>
</td>
<td>
PO No
</td>
<td>
  <asp:DropDownList ID="cmbPONO" CssClass="textbox" runat="server" AutoPostBack="true">
    </asp:DropDownList>
</td>
<td>
Art No.
</td>
<td>
  <asp:DropDownList ID="cmbArticleNo" CssClass="textbox" runat="server" AutoPostBack="true">
    </asp:DropDownList>
</td>
 
</tr>
</table>
<table width="100%">
<tr>
<td>
 <SMART:SMARTDATAGRID id="dgArticle" runat="server" width="100%"   AllowPaging="True" AllowSorting="True"
                             AutoGenerateColumns="False" CellPadding="4" CssClass="table" PagerCurrentPageCssClass=""
                              PagerOtherPageCssClass="" PageSize="15" RecordCount="0" ShowFooter="True" SortedAscending="yes" ForeColor="white" GridLines="Both">
							<COLUMNS>
                            	<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="ComplainDatabaseDetailID"
								  DataField="ComplainDatabaseDetailID"  visible="False">
								 <headerstyle width="1%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
							<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="POID"
								  DataField="POID"  visible="False">
								 <headerstyle width="1%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
                            	<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="PodetailID"
								  DataField="PodetailID"  visible="False">
								 <headerstyle width="1%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
                            	<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="15%" HeaderText="Article"
								 DataField="Article"  >
								 <headerstyle width="10%" horizontalalign="Center"  />
							</ASP:BOUNDCOLUMN>	

							<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="15%" HeaderText="Sizes"
								 DataField="sizerange"  >
								 <headerstyle width="10%" horizontalalign="Center"  />
							</ASP:BOUNDCOLUMN>	
                           <ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="15%" HeaderText="Quantity"
								 DataField="Quantity"  >
								 <headerstyle width="10%" horizontalalign="Center"  />
							</ASP:BOUNDCOLUMN>						
						 
                             <ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="15%" HeaderText="Shipped Qty"
								 DataField="ShipQty"  >
								 <headerstyle width="10%" horizontalalign="Center"  />
							</ASP:BOUNDCOLUMN>	
                              <ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="15%" HeaderText="Inline"
								 DataField="Inline"  >
								 <headerstyle width="10%" horizontalalign="Center"  />
							</ASP:BOUNDCOLUMN>	
                               <ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="15%" HeaderText="FRI"
								 DataField="FRI"  >
								 <headerstyle width="10%" horizontalalign="Center"  />
							</ASP:BOUNDCOLUMN>	
                               <ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="15%" HeaderText="FRI QD Name"
								 DataField="FRIQDName"  >
								 <headerstyle width="10%" horizontalalign="Center"  />
							</ASP:BOUNDCOLUMN>	
                             <ASP:TEMPLATECOLUMN HeaderText="Fault Pcs">
                                    <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
                                        <asp:TextBox ID="txtFaultPcs" Text="0" Width="50" CssClass="textbox" runat="server"></asp:TextBox>
                                    </ITEMTEMPLATE>
                                    <headerstyle width="07%" />
								</ASP:TEMPLATECOLUMN>
							  </COLUMNS>
							<PagerStyle  HorizontalAlign="NotSet"    />
						</SMART:SMARTDATAGRID>
</td>
</tr>
</table>
<table width="100%">
<tr>
<td>
Main Defect
</td>
</tr>
<tr>
<td>
Defect Code
</td>
<td>
  <asp:DropDownList ID="cmbDefectCode" CssClass="textbox" runat="server">
    </asp:DropDownList>
</td>
</tr>
</table>
<table width="100%">
<tr>
<td>
Defect 
<td>
<asp:TextBox ID="txtDefect" CssClass="textbox" runat="server"></asp:TextBox>
</td></td>
</tr>
</table>
<table width="100%">
<tr>
<td>
Current Status
</td>
<td>
  <asp:DropDownList ID="cmbCurrentStatus" CssClass="textbox" runat="server">
    </asp:DropDownList>
</td>
</tr>
</table>
<table width="100%">
<tr>
<td>
Important Notes For Supplier From Euro Centra:
</td>
</tr>
<tr>
<td>
<asp:TextBox ID="txtNotes" CssClass="textbox" runat="server"></asp:TextBox>
</td>
</tr>
</table>
<table width="100%">
        <tr>
        
        <td align="center">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" />
                          
                 &nbsp;&nbsp;
                          
                 <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" />
            </td>
             
        </tr>
    </table>
</asp:Content> 