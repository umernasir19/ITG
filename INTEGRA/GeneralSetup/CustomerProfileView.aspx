<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeBehind="CustomerProfileView.aspx.vb" Inherits="Integra.CustomerProfileView" %>
   
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <link href="../StyleSheet/MyClass.css" rel="stylesheet" type="text/css" />
           <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    </telerik:RadCodeBlock>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <table width="100%">
        <tr>
            <td align="right">
                <telerik:RadButton ID="btnAddCustomer" runat="server" Text="Add Customer" Skin="WebBlue">
                </telerik:RadButton>
            </td>
        </tr>


        <tr>
            <td>
                <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" AllowSorting="True"
                    AllowFilteringByColumn="false" CellSpacing="0" GridLines="Horizontal" AutoGenerateColumns="False"
                    Skin="WebBlue" Width="930px" PageSize="20">
                    <MasterTableView>
                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                        <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%"
                                HeaderText="ID" SortExpression="CustomerID" DataField="CustomerID" Display="false">
                                <HeaderStyle Width="5%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%"
                                HeaderText="CustomerName"  DataField="CustomerName" Display="false">
                                <HeaderStyle Width="5%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                
                            </telerik:GridBoundColumn>

                            <telerik:GridTemplateColumn DataField="CustomerName" HeaderText="Name" UniqueName="CustomerName">
                              
                                <ItemTemplate>
                                    <asp:HyperLink ID="lnkEdit" Font-Underline="false" Text='<%#Eval("CustomerName") %>'
                                        Enabled="true" NavigateUrl='<%# "CustomerProfile.aspx?lCustomerID=" &amp; DataBinder.Eval(Container.DataItem,"CustomerID")%>'
                                        runat="server"></asp:HyperLink>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="Parent" HeaderText="Parent Group" UniqueName="ParentGroup">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Territory" HeaderText="Geo Territory" UniqueName="GeoTerritory">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Country" HeaderText="Country" UniqueName="Country">
                            </telerik:GridBoundColumn>
                              <telerik:GridBoundColumn DataField="Commission" HeaderText="Commission" UniqueName="Commission">
                            </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="View" AllowFiltering="false" Display="True">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lnkEdit" Font-Underline="false" Text="Update" Enabled="true" CommandName="EDIT"
                                        NavigateUrl='<%# "CustomerProfile.aspx?lCustomerID=" &amp; DataBinder.Eval(Container.DataItem,"CustomerID")%>'
                                        runat="server"></asp:HyperLink>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                   
                        <PagerStyle PageSizeControlType="RadComboBox" AlwaysVisible="True"></PagerStyle>
                    </MasterTableView>
                    <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="false">
                        <Selecting AllowRowSelect="true" EnableDragToSelectRows="false" />
                    </ClientSettings>
                    <PagerStyle PageSizeControlType="RadComboBox" AlwaysVisible="True" EnableSEOPaging="True">
                    </PagerStyle>
                    <FilterMenu EnableImageSprites="False">
                    </FilterMenu>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
</asp:Content>
