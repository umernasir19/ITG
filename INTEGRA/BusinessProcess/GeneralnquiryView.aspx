<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="GeneralnquiryView.aspx.vb" Inherits="Integra.GeneralnquiryView" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <table width="100%">
        <tr style="height: 34px;">
                        
            <td></td>
              <td align="right">
                <asp:Button ID="btnBlankReport" runat="server" CssClass="button" Text="Add Repeat Inquiry" Width="180">
                </asp:Button>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td>
                <Smart:SmartDataGrid ID="dgView" runat="server" Width="100%" OnSortCommand="SortByColumn"
                    OnPageIndexChanged="PageChanged" OnItemDataBound="DataBound" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                    PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="100" RecordCount="0"
                    ShowFooter="True" sortedascending="yes" ForeColor="white" GridLines="both">
                    <Columns>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="GeneralInquiryMstID"
                            DataField="GeneralInquiryMstID" Visible="false">
                            <HeaderStyle Width="10%" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Style No"
                            DataField="StyleNo">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Customer"
                            DataField="CustomerName">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Buyer"
                            DataField="BuyerName">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Recv. Date"
                            DataField="InqRecvDatee">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Brand"
                            DataField="BrandName">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Season"
                            DataField="Season">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="View">
                            <ItemTemplate>
                                <asp:HyperLink ID="lnkEdit" Enabled="true" NavigateUrl='<%# "GeneralEnquiryEntry.aspx?GeneralInquiryMstID=" &amp; DataBinder.Eval(Container.DataItem,"GeneralInquiryMstID")%>'
                                    runat="server">
											View
                                </asp:HyperLink>
                               <%-- <br />
                                <asp:HyperLink ID="HyperLink1" Enabled="true" NavigateUrl='<%# "EnquiresSystemAdd.aspx?GeneralInquiryMstID=" &amp; DataBinder.Eval(Container.DataItem,"GeneralInquiryMstID")&"&Type=Copy"%>'
                                    runat="server">
											Copy
                                </asp:HyperLink>--%>
                                <%--  <br />
                                        <asp:HyperLink id="HyperLink1" Runat="server" NavigateUrl='<%# "EnquiresSystemAdd.aspx?EnquiriesSystemID=" &amp; DataBinder.Eval(Container.DataItem,"EnquiriesSystemID")&"&Type=Copy%>' Enabled="true">
											Copy
										</asp:HyperLink>--%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="PDF"
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
