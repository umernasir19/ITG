<%@ Page Title="Shipment Form View" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="ShipmentFormView.aspx.vb" Inherits="Integra.ShipmentFormView" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%">
        <tr>
            <td align="right">
                <asp:Button ID="btnAdd" runat="server" CssClass="button" Text="Add Shipment" Width="180">
                </asp:Button>
            </td>
        </tr>
        </table><br /><table  width="100%">
        <tr>
            <td>
                <Smart:SmartDataGrid ID="dgPurchaseOrder" runat="server" Width="100%" 
                    AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                    PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="500" RecordCount="0"
                    ShowFooter="True" sortedascending="yes" ForeColor="white" GridLines="both">
                    <Columns>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="Shipmentid"
                            DataField="Shipmentid" Visible="false">
                            <HeaderStyle Width="10%" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                          <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="Cargoid"
                            DataField="Cargoid" Visible="false">
                            <HeaderStyle Width="10%" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                          <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Invoice No"
                            DataField="InvoiceNo">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundColumn>
                           <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="LCNO No"
                            DataField="LCNO">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundColumn>
                          <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Buyer"
                            DataField="Buyer">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundColumn>
                          <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Invoice Amount"
                            DataField="InvoiceAmount">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundColumn>

                           <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Ex Factory Date"
                            DataField="ExFactoryDatee">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundColumn>

                           <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Expected Pay Rcv Date"
                            DataField="ExpectedPayRcvDatee">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundColumn>

                     
	<ASP:TEMPLATECOLUMN HeaderText="Edit" Visible ="true" >
                                    <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
<asp:HyperLink id="lnkEdit" Runat="server" NavigateUrl='<%# "ShipmentFormEntry.aspx?Shipmentid=" &amp; DataBinder.Eval(Container.DataItem,"Shipmentid")%>' Enabled="true">
											Edit
										</asp:HyperLink> 
</ITEMTEMPLATE>
                                    <headerstyle width="10%" />
								</ASP:TEMPLATECOLUMN>

  <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="Custom Packing List"
                            Visible="false">
                            <ItemTemplate>
                              
                                <asp:ImageButton ID="lnkPDF" ToolTip="Click here to download PDF" ImageUrl="~/Images/pdfIcon.png"
                                    CommandName="PDF" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>

                    </Columns>
                    <PagerStyle HorizontalAlign="NotSet" />
                </Smart:SmartDataGrid>
            </td>
        </tr>
    </table>
</asp:Content>

