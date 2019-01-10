<%@ Page Title="" Language="vb" AutoEventWireup="false"  CodeBehind="StitchingStatusView.aspx.vb" Inherits="Integra.StitchingStatusView" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
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
 <telerik:RadGrid ID="dgStitchingStatusView" runat="server" CellSpacing="0"  AutoGenerateColumns="False" Skin="WebBlue"  PageSize="20" >
               <GroupingSettings CaseSensitive="false"></GroupingSettings>
            <MasterTableView>
            <ColumnGroups>
             <telerik:GridColumnGroup Name="Line1" HeaderText="Line 1 (L1)"
                        HeaderStyle-HorizontalAlign="Center">
                        <HeaderStyle HorizontalAlign="Center" Width="250px"></HeaderStyle>
                    </telerik:GridColumnGroup>
                    <telerik:GridColumnGroup Name="Line2" HeaderText="Line 2 (L2)"
                        HeaderStyle-HorizontalAlign="Center">
                        <HeaderStyle HorizontalAlign="Center" Width="250px"></HeaderStyle>
                    </telerik:GridColumnGroup>
                    <telerik:GridColumnGroup Name="Line3" HeaderText="Capacity/Day"
                        HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true">
                        <HeaderStyle HorizontalAlign="Center" Width="200px"></HeaderStyle>
                    </telerik:GridColumnGroup>
            </ColumnGroups>
            <Columns>
               <telerik:GridBoundColumn HeaderText="StitchingStatusDetailID"
                        DataField="StitchingStatusDetailID" Display="false" SortExpression="StitchingStatusDetailID">
                        <HeaderStyle Width="5px" />
                    </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="StitchingStatusID"
                        DataField="StitchingStatusID" Display="false" SortExpression="StitchingStatusID">
                        <HeaderStyle Width="5px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn ColumnGroupName="Line1"  HeaderText="Plan" DataField="L1Plan">
                        <HeaderStyle Width="5px" />
                    </telerik:GridBoundColumn>
                     <telerik:GridBoundColumn ColumnGroupName="Line1"  HeaderText="Actual" DataField="L1Actual">
                        <HeaderStyle Width="5px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn ColumnGroupName="Line2"  HeaderText="Plan" DataField="L2Plan">
                        <HeaderStyle Width="5px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn ColumnGroupName="Line2"  HeaderText="Actual" DataField="L2Actual">
                        <HeaderStyle Width="5px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn ColumnGroupName="Line3" HeaderText="Plan">
                    <ItemTemplate>
                    <asp:Label ID="lblPlan" runat="server" Font-Names="Calibri"></asp:Label>
                    </ItemTemplate>
                    </telerik:GridTemplateColumn>
                      <telerik:GridTemplateColumn ColumnGroupName="Line3" HeaderText="Actual">
                    <ItemTemplate>
                    <asp:Label ID="lblActual" runat="server" Font-Names="Calibri"></asp:Label>
                    </ItemTemplate>
                    </telerik:GridTemplateColumn>
            </Columns>
            </MasterTableView>
              </telerik:RadGrid>
</td>
</tr>
</table>
   </form>
</body>
</html>
