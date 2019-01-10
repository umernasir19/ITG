<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="QAProfileView.aspx.vb" Inherits="Integra.QAProfileView" %>
  <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
  <%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%">
<tr>
<td align="left">
                <asp:LinkButton ID="lnkPrint" runat="server" Text="Click here to Download PDF"></asp:LinkButton>
            </td>
<td align="right">
                <asp:Button ID="btnAdd" runat="server" CssClass="button" Text="Add QA Profile" Width="180">
                </asp:Button>

</td>
</tr>
</table>
<br />
<table width="100%">
        <tr>
            <td>
                <Smart:SmartDataGrid ID="dgQA" runat="server" Width="100%" OnSortCommand="SortByColumn"
                    OnPageIndexChanged="PageChanged" OnItemDataBound="DataBound" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                    PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="100" RecordCount="0"
                    ShowFooter="True" sortedascending="yes" ForeColor="white" GridLines="both">
                    <Columns>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="QAMstID"
                            DataField="QAMstID" Visible="false">
                            <HeaderStyle Width="10%" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                         <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="QAID"
                            DataField="QAID" Visible="false">
                            <HeaderStyle Width="10%" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                           <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="FactoryID"
                            DataField="FactoryID" Visible="false">
                            <HeaderStyle Width="10%" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Name"
                            DataField="QAName">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Area Of Experties"
                            DataField="QAAreasofExp">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Factory"
                            DataField="Factory">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Location"
                            DataField="Location">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <ASP:TEMPLATECOLUMN HeaderText="Edit" Visible ="true" >
                                    <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
<asp:HyperLink id="lnkEdit" Runat="server" NavigateUrl='<%# "QAProfileAdd.aspx?lQAMstID=" &amp; DataBinder.Eval(Container.DataItem,"QAMstID")%>' Enabled="true">
											Edit
										</asp:HyperLink> 
</ITEMTEMPLATE>
                                    <headerstyle width="10%" />
								</ASP:TEMPLATECOLUMN>
                           <%--     <asp:HyperLink ID="lnkEdit" Enabled="true" NavigateUrl='<%# "EnquiresSystemAdd.aspx?EnquiriesSystemID=" &amp; DataBinder.Eval(Container.DataItem,"EnquiriesSystemID")%>'
                                    runat="server">
											View
                                </asp:HyperLink>
                                <br />
                                <asp:HyperLink ID="HyperLink1" Enabled="true" NavigateUrl='<%# "EnquiresSystemAdd.aspx?EnquiriesSystemID=" &amp; DataBinder.Eval(Container.DataItem,"EnquiriesSystemID")&"&Type=Copy"%>'
                                    runat="server">
											Copy
                                </asp:HyperLink>--%>
                                <%--  <br />
                                        <asp:HyperLink id="HyperLink1" Runat="server" NavigateUrl='<%# "EnquiresSystemAdd.aspx?EnquiriesSystemID=" &amp; DataBinder.Eval(Container.DataItem,"EnquiriesSystemID")&"&Type=Copy%>' Enabled="true">
											Copy
										</asp:HyperLink>--%>
                          <%--  </ItemTemplate>
                        </asp:TemplateColumn>--%>
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
