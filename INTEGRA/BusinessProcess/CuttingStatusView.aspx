<%@ Page Language="vb"  AutoEventWireup="false" CodeBehind="CuttingStatusView.aspx.vb" Inherits="Integra.CuttingStatusView" %>
    <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
 
</head>
<body>
    <form id="form1" runat="server">
    
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
 
<table width="100%">
 
<tr>
<td>
     <telerik:RadGrid ID="dgCuttingStatusView" runat="server" CellSpacing="0" ShowFooter="true"  OnPageIndexChanged="dgCuttingStatusView_PageIndexChanged" OnSortCommand="dgCuttingStatusView_SortCommand"  
        AutoGenerateColumns="false"  Skin="WebBlue"  Visible="true" PageSize="50"  AllowFilteringByColumn="true" >
            <MasterTableView>
            <Columns>            
            <telerik:GridBoundColumn HeaderText="CuttingStatusID" DataField="CuttingStatusID" Display ="false" AllowFiltering="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left"  />
            </telerik:GridBoundColumn>  
              <telerik:GridBoundColumn  HeaderText="Week" DataField="Week" ShowFilterIcon="false" AllowFiltering="false"  CurrentFilterFunction="EqualTo" FilterDelay="1000" FilterControlWidth="40px" >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left"  />
            </telerik:GridBoundColumn> 
              <telerik:GridBoundColumn HeaderText="Style No." DataField="StyleNo" ShowFilterIcon="false" CurrentFilterFunction="EqualTo" AllowFiltering="false" FilterDelay="1000" FilterControlWidth="70px" >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left"  />
            </telerik:GridBoundColumn>   
 <telerik:GridBoundColumn HeaderText="Input Date" DataField="InputDates" AllowFiltering="false"  ShowFilterIcon="false" CurrentFilterFunction="EqualTo" FilterDelay="1000" FilterControlWidth="80px"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left"  />
            </telerik:GridBoundColumn>  
                          <telerik:GridBoundColumn HeaderText="Lot No." DataField="LotNo" AllowFiltering="false"   >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left"  />
            </telerik:GridBoundColumn>  

            <telerik:GridBoundColumn HeaderText="Input Qty(M)" DataField="InputQty" DataFormatString="{0:#,##0;(#,##0.00);0}"   DataType="System.Decimal" AllowFiltering="false" Aggregate="Sum" FooterAggregateFormatString="{0:###,##}"  FooterText=" " FooterStyle-Font-Bold="true" FooterStyle-Font-Names="Calibri" >
           <ItemStyle HorizontalAlign="Right" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" Wrap="false"  />
            </telerik:GridBoundColumn>  

            <telerik:GridBoundColumn HeaderText="Output Date" DataField="OutputDates" AllowFiltering="false"  FilterControlWidth="80px" FilterDelay="1000" ShowFilterIcon="false" CurrentFilterFunction="EqualTo" >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="10%" HorizontalAlign="Left"  />
            </telerik:GridBoundColumn>  
              <telerik:GridBoundColumn HeaderText="Consumption" AllowFiltering="false"  DataField="Consumption" ShowFilterIcon="false" CurrentFilterFunction="EqualTo" FilterDelay="1000" FilterControlWidth="50px" >
           <ItemStyle HorizontalAlign="Right" />
            <HeaderStyle Width="5%" HorizontalAlign="Left"  />
            </telerik:GridBoundColumn>  
            <telerik:GridBoundColumn HeaderText="Output Qty(Pcs)" DataField="OutputQty" DataFormatString="{0:#,##0;(#,##0.00);0}"   DataType="System.Decimal" AllowFiltering="false" Aggregate="Sum" FooterAggregateFormatString="{0:###,##}" FooterText=" " FooterStyle-Font-Bold="true" FooterStyle-Font-Names="Calibri" >
           <ItemStyle HorizontalAlign="Right" />
            <HeaderStyle Width="15%" HorizontalAlign="Left"  />
            </telerik:GridBoundColumn>  
                   <%--<telerik:GridTemplateColumn  HeaderText="Action"  AllowFiltering ="false">
                                    <itemstyle horizontalalign="Center" />
                                      <HeaderStyle Width="5%" HorizontalAlign="Center" Font-Size="Smaller"/>
									<ITEMTEMPLATE>
<asp:HyperLink id="lnkEdit" Runat="server" NavigateUrl='<%# "CuttingStatus.aspx?CuttingStatusID=" &amp; DataBinder.Eval(Container.DataItem,"CuttingStatusID")%>' Enabled="true" __designer:wfdid="w1">
										Edit
										</asp:HyperLink> 
</ITEMTEMPLATE>
                                    <headerstyle width="10%" />
								</telerik:GridTemplateColumn >--%>
            </Columns>
              <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                            <PagerStyle PageSizeControlType="RadComboBox" AlwaysVisible="true">
                            </PagerStyle>
            </MasterTableView>
            <ClientSettings EnableRowHoverStyle="True" EnablePostBackOnRowClick="false">
<Selecting  EnableDragToSelectRows="false" />
 <Selecting AllowRowSelect="True" />
 </ClientSettings>
    <HeaderStyle Font-Names="Microsoft Sans Serif" />
 <ItemStyle  Wrap="False" />
            </telerik:RadGrid>
</td>
</tr>
</table>
 
   </form>
</body>
</html>