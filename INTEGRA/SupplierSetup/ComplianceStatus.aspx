<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="ComplianceStatus.aspx.vb" Inherits="Integra.ComplianceStatus" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <telerik:RadAjaxManager ID="RadAjaxManager1" EnableAJAX="true" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
         <ClientEvents OnRequestStart="onRequestStart" OnResponseEnd = "onResponseEnd"  /> 
    </telerik:RadAjaxManager>
   <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" BackgroundPosition="Bottom" Width="80%">
    <asp:Image ID="Image1" runat="server" AlternateText="Loading..." 
                ImageUrl="~/Images/loading12.gif" />
   </telerik:RadAjaxLoadingPanel> 
<div>
<table width="100%">
<tr>
<td>
  <asp:UpdatePanel ID="upcmbAction" UpdateMode="Conditional" runat="server">
 <ContentTemplate> 
   <telerik:RadGrid ID="dgComplianceStatus" runat="server" CellSpacing="0"
       AutoGenerateColumns="False"
                        Skin="WebBlue" AllowFilteringByColumn="True" AllowPaging="True" AllowSorting="True"
                        GridLines="None" ShowGroupPanel="True" PageSize="20" OnSortCommand="dgComplianceStatus_SortCommand" 
                       ShowStatusBar="true" StatusBarSettings-ReadyText="Loading" OnPageIndexChanged="dgComplianceStatus_PageIndexChanged"
                        Height="643px" Width="930px">
                        <ClientSettings AllowDragToGroup="True">
                        </ClientSettings>
                        <AlternatingItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" />
                        <GroupingSettings CaseSensitive="false"></GroupingSettings>
                        <MasterTableView ShowFooter="True" TableLayout="Auto">
                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                            </ExpandCollapseColumn>
            <Columns>            
<telerik:GridBoundColumn DataField="VenderLibraryID" HeaderText="VenderLibraryID" Display="false">
</telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="CertificateID" HeaderText="CertificateID" Display="false"></telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="Supplier" HeaderText="Supplier" AllowFiltering="false" ShowFilterIcon="false" FilterDelay="2000" AndCurrentFilterFunction="StartsWith" FilterControlWidth="120px">
</telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="Certificate" HeaderText="Compliance" AllowFiltering="false" ShowFilterIcon="false" FilterDelay="2000" AndCurrentFilterFunction="StartsWith" FilterControlWidth="120px">
</telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="Validity" HeaderText="Validity" AllowFiltering="false"></telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="Status" HeaderText="Status" AllowFiltering="false" ShowFilterIcon="false" FilterDelay="2000" AndCurrentFilterFunction="StartsWith" FilterControlWidth="120px"></telerik:GridBoundColumn>
   <telerik:GridTemplateColumn HeaderText ="View"  Display="true" AllowFiltering="false">
                <ItemTemplate >
                <asp:LinkButton ID="lnEdit"  runat ="server" CommandName ="ViewCertificate"  Text="View" ></asp:LinkButton>
                </ItemTemplate>
                </telerik:GridTemplateColumn>
           </Columns>
      <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                            <PagerStyle PageSizeControlType="RadComboBox" AlwaysVisible="true">
                            </PagerStyle>
                        </MasterTableView>
                        <StatusBarSettings ReadyText="Loading"></StatusBarSettings>
                        <FilterItemStyle Font-Size="XX-Small" />
                        <GroupingSettings ShowUnGroupButton="true" />
                        <HeaderStyle Font-Names="Microsoft Sans Serif" />
                        <ItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" Wrap="False" />
                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                        <ClientSettings Scrolling-ScrollHeight="1200px" EnableRowHoverStyle="true" Scrolling-AllowScroll="True">
                            <Scrolling AllowScroll="true" EnableVirtualScrollPaging="false" />
                            <Selecting AllowRowSelect="True" />
                        </ClientSettings>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
            </telerik:RadGrid>
 </ContentTemplate>
 </asp:UpdatePanel> 
  
</td>
</tr>
</table>
     
</div>

</asp:Content>


