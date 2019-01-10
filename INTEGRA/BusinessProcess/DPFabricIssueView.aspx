<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="DPFabricIssueView.aspx.vb" Inherits="Integra.DPFabricIssueView" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" EnableAJAX="true" runat="server">
        <ClientEvents OnRequestStart="onRequestStart" OnResponseEnd="onResponseEnd" />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="dgECPSampling">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="dgECPSampling" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <div>
        <table width="100%">
            <tr>
                <td align="right">
                    <telerik:RadButton ID="btnAddFabricIssue" runat="server" Text="Add Sample" Skin="WebBlue">
                    </telerik:RadButton>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadGrid ID="dgFabricIssue" runat="server" CellSpacing="0" AutoGenerateColumns="false"
                        Skin="WebBlue" Visible="true" PageSize="50" AllowAutomaticDeletes="false">
                        <MasterTableView>
                            <Columns>
                                <telerik:GridBoundColumn HeaderText="FabricIssueID" DataField="FabricIssueID" Display="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Date" DataField="CreationDatee">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Time" DataField="DPTime">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Issue No" DataField="IssueNo">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="DAL No" DataField="DALNO">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Style" DataField="Style">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="No. of Sample" DataField="NoofSample">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="10%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Total Fabric Req" DataField="TotalFabricReq">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="10%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Type" DataField="Type">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="View" AllowFiltering="false" Display="true">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="lnkEdit" Font-Underline="false" Text="Update" Enabled="true" NavigateUrl='<%# "DPFabricIssueAdd.aspx?lFabricIssueID=" &amp; DataBinder.Eval(Container.DataItem,"FabricIssueID")%>'
                                            runat="server"></asp:HyperLink>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%"
                                    HeaderText="PDF" Visible="true">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="lnkPDF" ToolTip="Click here to download PDF" ImageUrl="~/Images/pdfIcon.png"
                                            CommandName="PDF" runat="server"></asp:ImageButton>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridButtonColumn UniqueName="DeleteColumn" Visible="true" Text="Delete" CommandName="Delete"
                                    ConfirmTextFormatString="Are You Sure You want to Delete Record" HeaderStyle-Width="7%"
                                    ButtonType="ImageButton">
                                </telerik:GridButtonColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
    </div>
    <%-- Script For Loading Panel  --%>
</asp:Content>
