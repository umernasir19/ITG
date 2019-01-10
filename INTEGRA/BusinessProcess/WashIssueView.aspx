<%@ Page Title="Wash Issue View" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="WashIssueView.aspx.vb" Inherits="Integra.WashIssueView" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" BackgroundPosition="Bottom"
        Width="80%">
        <asp:Image ID="Image1" runat="server" AlternateText="Loading..." ImageUrl="~/Images/loading12.gif" />
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadCodeBlock runat="server" ID="radCodeBlock">
        <script type="text/javascript">
            function showFilterItem() {
                $find('<%=dgWashIssue.ClientID %>').get_masterTableView().showFilterItem();
            }
            function hideFilterItem() {
                $find('<%=dgWashIssue.ClientID %>').get_masterTableView().hideFilterItem();
            }        
        </script>
    </telerik:RadCodeBlock>
    <div>
        <label for="RadioButtonList1">
            Show filtering item</label>
        <asp:RadioButtonList runat="server" ID="RadioButtonList1" RepeatDirection="Horizontal">
            <asp:ListItem Text="Yes" Selected="True" onclick="showFilterItem()"></asp:ListItem>
            <asp:ListItem Text="No" onclick="hideFilterItem()"></asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <table width="100%">
        <tr>
            <td align="right">
                <telerik:RadButton ID="btnAddWashIssue" runat="server" Text="Add Wash Issue" Skin="WebBlue">
                </telerik:RadButton>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadGrid ID="dgWashIssue" runat="server" CellSpacing="0" AutoGenerateColumns="False"
                    Skin="WebBlue" AllowFilteringByColumn="True" AllowPaging="True" GridLines="None"
                    ShowGroupPanel="True" PageSize="50" OnSortCommand="dgWashIssue_SortCommand" OnPageIndexChanged="dgWashIssue_PageIndexChanged"
                    ShowStatusBar="True" StatusBarSettings-ReadyText="Loading">
                    <ClientSettings AllowDragToGroup="True">
                    </ClientSettings>
                    <AlternatingItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" />
                    <GroupingSettings CaseSensitive="false"></GroupingSettings>
                    <MasterTableView AutoGenerateColumns="false" AllowFilteringByColumn="True" ShowFooter="True"
                        TableLayout="Auto" DataKeyNames="WashMstID" GroupLoadMode="Client">
                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                        <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn HeaderText="WashMstID" DataField="WashMstID" Display="false">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="2%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Issue Date" AllowFiltering="false" DataField="IssueDatee">
                                <HeaderStyle Width="9%" HorizontalAlign="center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Wash Issue No" DataField="WashIssueNo" AllowFiltering="true"
                                FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                FilterDelay="3000" ShowFilterIcon="false">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="20%" HorizontalAlign="Left" Font-Size="Smaller" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Sample Recv Qty" DataField="SampleRecvQty" AllowFiltering="true"
                                FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                FilterDelay="3000" ShowFilterIcon="false">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="20%" HorizontalAlign="Left" Font-Size="Smaller" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Issue To Wash" DataField="IssueQty" AllowFiltering="true"
                                FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                FilterDelay="3000" ShowFilterIcon="false">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="20%" HorizontalAlign="Left" Font-Size="Smaller" />
                            </telerik:GridBoundColumn>
                            <%--  <telerik:GridBoundColumn HeaderText="Issue Qty" DataField="IssueQty" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="10%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                              

                               <telerik:GridBoundColumn HeaderText="Receive Time" DataField="ReceiveTime" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="10%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>--%>
                            <telerik:GridTemplateColumn HeaderText="View" UniqueName="View" AllowFiltering="false" Display="True">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lnkEdit" Font-Underline="false" Text="Update" Enabled="true" CommandName="EDIT"
                                        NavigateUrl='<%# "WashIssueAdd.aspx?WashMstID=" &amp; DataBinder.Eval(Container.DataItem,"WashMstID")%>'
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
                        </Columns>
                        <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                            </EditColumn>
                        </EditFormSettings>
                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                    </MasterTableView>
                    <ClientSettings EnableRowHoverStyle="false" EnablePostBackOnRowClick="false">
                        <Selecting AllowRowSelect="true" EnableDragToSelectRows="true" />
                    </ClientSettings>
                    <HeaderStyle Font-Names="Microsoft Sans Serif" />
                    <ItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" />
                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                    <FilterMenu EnableImageSprites="False">
                    </FilterMenu>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
</asp:Content>
