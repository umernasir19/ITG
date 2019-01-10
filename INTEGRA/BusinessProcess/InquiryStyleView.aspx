<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="InquiryStyleView.aspx.vb" Inherits="Integra.InquiryStyleView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="PnBuyingInq" runat="server">
        <table width="100%">
            <tr style="height: 34px;">
                <td>
                    Style
                </td>
                <td>
                    <div>
                        <asp:TextBox ID="txtsearchStyle" Style="margin-left: 0px; width: 209px;" runat="server"
                            AutoPostBack="true" autocomplete="off"></asp:TextBox>
                        <cc1:AutoCompleteExtender runat="server" ID="autoComplete1" TargetControlID="txtsearchStyle"
                            ServicePath="~/AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                            CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="INQStyle" />
                    </div>
                </td>
                <td>
                    Season
                    <asp:DropDownList ID="cmbSeason" runat="server" Width="156px" ToolTip="select Season"
                        AutoPostBack="true">
                    </asp:DropDownList>
                </td>
                <td align="right">
                    <asp:Button ID="btnAdd" runat="server" CssClass="button" Text="Add Buying Inq." Width="180">
                    </asp:Button>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:DropDownList ID="cmbSupplier" runat="server" Width="156px" ToolTip="select Supplier"
                        AutoPostBack="true" Visible="false">
                    </asp:DropDownList>
                </td>
                <td>
                </td>
                <td align="right">
                    <asp:Button ID="btnBlankReport" runat="server" CssClass="button" Text="Add General Inq."
                        Width="180" Visible="true"></asp:Button>
                </td>
            </tr>
            <tr>
                <td>
                   
                        <asp:LinkButton ID ="btnBlankreport23" runat ="server" >Blank Inq. Work sheet</asp:LinkButton>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td align="right">
                
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td>
                    <Smart:SmartDataGrid ID="dgPurchaseOrder" runat="server" Width="100%" OnSortCommand="SortByColumn"
                        OnPageIndexChanged="PageChanged" OnItemDataBound="DataBound" AllowPaging="True"
                        AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                        PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="100" RecordCount="0"
                        ShowFooter="True" sortedascending="yes" ForeColor="white" GridLines="both">
                        <Columns>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="InquiryStyleID"
                                DataField="InquiryStyleID" Visible="false">
                                <HeaderStyle Width="10%" HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Style No"
                                DataField="StyleNo">
                                <HeaderStyle Width="10%" HorizontalAlign="center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Design Name"
                                DataField="DesignName">
                                <HeaderStyle Width="10%" HorizontalAlign="center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Customer"
                                DataField="CustomerName">
                                <HeaderStyle Width="10%" HorizontalAlign="center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Recv. Date"
                                DataField="RecvDatee">
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
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="Import"
                                Visible="false">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lnkEdit23" Enabled="false" NavigateUrl='<%# "InquiriesEntry.aspx?InquiryStyleID=" &amp; DataBinder.Eval(Container.DataItem,"InquiryStyleID")%>'
                                        runat="server">
											To Style
                                    </asp:HyperLink>
                                    <br />
                                    <%--  <asp:HyperLink ID="HyperLink1" Enabled="true" NavigateUrl='<%# "EnquiresSystemAdd.aspx?EnquiriesSystemID=" &amp; DataBinder.Eval(Container.DataItem,"EnquiriesSystemID")&"&Type=Copy"%>'
                                    runat="server">
											Copy
                                </asp:HyperLink>--%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="Quotation"
                                Visible="false">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lnkEditComp" Enabled="true" NavigateUrl='<%# "InquiriesEntry.aspx?InquiryStyleID=" &amp; DataBinder.Eval(Container.DataItem,"InquiryStyleID")&"&Type=Costing"%>'
                                        runat="server">
											Comp. Costing
                                    </asp:HyperLink>
                                    <br />
                                    <%--  <asp:HyperLink ID="HyperLink1" Enabled="true" NavigateUrl='<%# "EnquiresSystemAdd.aspx?EnquiriesSystemID=" &amp; DataBinder.Eval(Container.DataItem,"EnquiriesSystemID")&"&Type=Copy"%>'
                                    runat="server">
											Copy
                                </asp:HyperLink>--%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="Action">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lnkEdit" Enabled="true" NavigateUrl='<%# "InquiriesEntry.aspx?InquiryStyleID=" &amp; DataBinder.Eval(Container.DataItem,"InquiryStyleID")%>'
                                        runat="server">
											View
                                    </asp:HyperLink>
                                    <br />
                                    <%--  <asp:HyperLink ID="HyperLink1" Enabled="true" NavigateUrl='<%# "EnquiresSystemAdd.aspx?EnquiriesSystemID=" &amp; DataBinder.Eval(Container.DataItem,"EnquiriesSystemID")&"&Type=Copy"%>'
                                    runat="server">
											Copy
                                </asp:HyperLink>--%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="PDF"
                                Visible="true">
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkPDF23" ToolTip="Click here to download PDF" ImageUrl="~/Images/pdfIcon.png"
                                        CommandName="PDF" runat="server"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                        <PagerStyle HorizontalAlign="NotSet" />
                    </Smart:SmartDataGrid>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <br />
    <asp:Panel ID="PnGeneralInq" runat="server">
        <table width="100%">
            <tr>
                <td>
                    <Smart:SmartDataGrid ID="dgView" runat="server" Width="100%" OnSortCommand="SortByColumnGeneral"
                        OnPageIndexChanged="PageChangedGeneral" OnItemDataBound="DataBoundGeneral" AllowPaging="True"
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
                                    <asp:HyperLink ID="lnkEdit1" Enabled="true" NavigateUrl='<%# "GeneralEnquiryEntry.aspx?GeneralInquiryMstID=" &amp; DataBinder.Eval(Container.DataItem,"GeneralInquiryMstID")%>'
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
                                    <asp:ImageButton ID="lnkPDF1" ToolTip="Click here to download PDF" ImageUrl="~/Images/pdfIcon.png"
                                        CommandName="PDF" runat="server"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                        <PagerStyle HorizontalAlign="NotSet" />
                    </Smart:SmartDataGrid>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
