<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="OfferDevSampleRecvFromSupplierView.aspx.vb" Inherits="Integra.OfferDevSampleRecvFromSupplierView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr style="height: 34px;">
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td align="right">
                <asp:Button ID="btnAdd" runat="server" CssClass="button" Text="Add Offer Development Sample"
                    Width="215px"></asp:Button>
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td>
                <Smart:Smartdatagrid id="dgPurchaseOrder" runat="server" width="100%" onsortcommand="SortByColumn"
                    onpageindexchanged="PageChanged" onitemdatabound="DataBound" allowpaging="True"
                    allowsorting="True" autogeneratecolumns="False" cellpadding="4" cssclass="table"
                    pagercurrentpagecssclass="" pagerotherpagecssclass="" pagesize="100" recordcount="0"
                    showfooter="True" sortedascending="yes" forecolor="white" gridlines="both">
                    <Columns>
                    
                     <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="SamplingMasterID"
                            DataField="SamplingMasterID" Visible="false">
                            <HeaderStyle Width="10%" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="InquiryStyleID"
                            DataField="InquiryStyleID" Visible="false">
                            <HeaderStyle Width="10%" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Style No"
                            DataField="StyleNo">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Design Name"
                            DataField="DesignName" Visible="false">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Customer"
                            DataField="CustomerName">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundColumn>
                     
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Brand"
                            DataField="Brand">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Season"
                            DataField="Season">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundColumn>
                       
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="Action">
                            <ItemTemplate>
                                <asp:HyperLink ID="lnkEdit" Enabled="true" NavigateUrl='<%# "OfferDevSampleRecvFromSupplier.aspx?SamplingMasterID=" &amp; DataBinder.Eval(Container.DataItem,"SamplingMasterID")%>'
                                    runat="server">
											View
                                </asp:HyperLink>
                                <br />
                               
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <%--<asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="PDF"
                            Visible="true">
                            <ItemTemplate>
                                <asp:ImageButton ID="lnkPDF" ToolTip="Click here to download PDF" ImageUrl="~/Images/pdfIcon.png"
                                    CommandName="PDF" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>--%>
                    </Columns>
                    <PagerStyle HorizontalAlign="NotSet" />
                </Smart:Smartdatagrid>
            </td>
        </tr>
    </table>
</asp:Content>
