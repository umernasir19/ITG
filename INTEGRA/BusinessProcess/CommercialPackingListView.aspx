<%@ Page Title="Commercial Packing List View" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="CommercialPackingListView.aspx.vb" Inherits="Integra.CommercialPackingListView" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">





<table width="100%">
        <tr>
            <td align="right">
                <telerik:RadButton ID="btnCreatePackingList" runat="server" Text="Create Packing List"
                    Skin="WebBlue">
                </telerik:RadButton>
            </td>
        </tr>
        </TABLE><br /><TABLE>
        <tr>
            <td>
            <div style=" width :930px;">
            <Smart:SmartDataGrid ID="dgPackingListView" runat="server" 
                    AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" width="100%" CssClass="table"
                    PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="500" RecordCount="0"
                    ShowFooter="True" sortedascending="yes" ForeColor="white" GridLines="both">
                    <Columns>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="CommercialPackingListMstid"
                            DataField="CommercialPackingListMstid" Visible="false">
                            <HeaderStyle Width="10%" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                           <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="cargoid"
                            DataField="cargoid" Visible="false">
                            <HeaderStyle Width="10%" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                           <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Invoice No"
                            DataField="InvoiceNo">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Sr No"
                            DataField="SrNo">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundColumn>
                
                     
                     <ASP:TEMPLATECOLUMN HeaderText="Edit" Visible ="true" >
                                    <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
<asp:HyperLink id="lnkEdit" Runat="server" NavigateUrl='<%# "CommercialPackingList.aspx?CommercialPackingListMstid=" &amp; DataBinder.Eval(Container.DataItem,"CommercialPackingListMstid")%>' Enabled="true">
											Edit
										</asp:HyperLink> 
</ITEMTEMPLATE>
                                    <headerstyle width="10%" />
								</ASP:TEMPLATECOLUMN>
                                    <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="7%" HeaderText="PDF"
                            Visible="true">
                            <ItemTemplate>
               
                                <asp:ImageButton ID="lnkPDF" ToolTip="Click here to download Report" ImageUrl="~/Images/pdfIcon.png"
                                    CommandName="PDF" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                    <PagerStyle HorizontalAlign="NotSet" />
                </Smart:SmartDataGrid>
</div> 


            </td>
        </tr>
    </table>
</asp:Content>

