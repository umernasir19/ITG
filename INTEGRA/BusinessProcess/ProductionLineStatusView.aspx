<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeBehind="ProductionLineStatusView.aspx.vb" Inherits="Integra.ProductionLineStatusView" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
<table>
<tr>
<td>
This module is designed on the request of <b> Mr. Norbert </b>. The said module can track line status instantly.   
</td>
</tr>
<tr>
<td>
 With the result one can conclude if entire order will deliver on FOB Date.  
</td>
</tr>
<tr>
<td align="right">
<telerik:RadButton ID="btnProductionEntry" runat="server" Text="Add Production Entry" Skin="WebBlue">
        </telerik:RadButton>
</td>
</tr>
<tr>
<td>
Following is just a demo entry to show how system will work. Please click on “View” at graph mode.  
</td>
</tr>
<tr>
<td>
<telerik:RadGrid ID="dgProductionStatus" runat="server" AllowPaging="True" GridLines="Horizontal"  Skin="WebBlue" Width="930px" AutoGenerateColumns="false">
<MasterTableView>
<Columns>
<telerik:GridBoundColumn DataField="PLSEID" HeaderText="PLSE ID" Display="false"></telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="POID" HeaderText="POID" Display="false">
</telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="PONO" HeaderText="PONO">
</telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="Aliass" HeaderText="Customer">
</telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="ShortName" HeaderText="Supplier">
</telerik:GridBoundColumn>
<telerik:GridTemplateColumn AllowFiltering="false" 
                        HeaderText="Edit">
                        
                        <ItemTemplate>
                          
                            <asp:HyperLink ID="lnkEdit" runat="server" NavigateUrl='<%# "ProductionLineStatusEntry.aspx?lPLSEID=" &amp; DataBinder.Eval(Container.DataItem,"PLSEID")%>'
                                Enabled="true" Font-Underline="false">
											Edit
                            </asp:HyperLink>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn AllowFiltering="false" 
                        HeaderText="View Stitching Mode">
                        
                        <ItemTemplate>
                          
                            <asp:HyperLink ID="lnkEdit" runat="server" NavigateUrl='<%# "ProductionLineStatusPlanning.aspx?lPLSEID=" &amp; DataBinder.Eval(Container.DataItem,"PLSEID")%>'
                                Enabled="true" Font-Underline="false">
											View
                            </asp:HyperLink>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                      <telerik:GridTemplateColumn AllowFiltering="false" 
                        HeaderText="View Graph Mode">
                        
                        <ItemTemplate>
                          
                            <asp:HyperLink ID="lnkEdit" runat="server" NavigateUrl='<%# "ProductionLineStatusActivityView.aspx?lPLSEID=" &amp; DataBinder.Eval(Container.DataItem,"PLSEID")%>'
                                Enabled="true" Font-Underline="false">
											View
                            </asp:HyperLink>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
</Columns>
  <PagerStyle PageSizeControlType="RadComboBox"   Mode="NextPrevAndNumeric"></PagerStyle>
</MasterTableView>
 <ClientSettings EnableRowHoverStyle="true" >
             <Selecting AllowRowSelect="True"  />
            </ClientSettings>
</telerik:RadGrid>
</td>
</tr>
</table>
</div>
</asp:Content>
