<%@ Page Title="Panal Checking View" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="PanalCheckingView.aspx.vb" Inherits="Integra.PanalCheckingView" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table width="100%">
        <tr>
            <td align="right">
                <asp:Button ID="btnAdd" runat="server" CssClass="button" Text="Add Panal Entry" Width="180">
                </asp:Button>
            </td>
        </tr>
        </table><br /><table  width="100%">
        <tr>
            <td>
                <Smart:SmartDataGrid ID="dgView" runat="server" Width="100%" 
                    AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                    PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="500" RecordCount="0"
                    ShowFooter="True" sortedascending="yes" ForeColor="white" GridLines="both">
                    <Columns>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="PanalMstid"
                            DataField="PanalMstid" Visible="false">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundColumn>
                          <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Date"
                            DataField="CreationDatee" Visible="true">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundColumn>
                           <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Season"
                            DataField="SeasonName">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundColumn>
                       
                     
	<ASP:TEMPLATECOLUMN HeaderText="Edit" Visible ="true" >
                                    <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
<asp:HyperLink id="lnkEdit" Runat="server" NavigateUrl='<%# "PanalCheckingEntry.aspx?PanalMstid=" &amp; DataBinder.Eval(Container.DataItem,"PanalMstid")%>' Enabled="true">
											Edit
										</asp:HyperLink> 
</ITEMTEMPLATE>
                                    <headerstyle width="10%" />
								</ASP:TEMPLATECOLUMN>

  <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="PDF"
                            Visible="true">
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

