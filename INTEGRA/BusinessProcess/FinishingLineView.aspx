<%@ Page Title="" Language="vb" AutoEventWireup="false"  CodeBehind="FinishingLineView.aspx.vb" Inherits="Integra.FinishingLineView" %>
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
  <telerik:RadGrid ID="dgFinishingLineView" runat="server" CellSpacing="0" ShowFooter="true"  
        AutoGenerateColumns="false"  Skin="WebBlue"  Visible="true" PageSize="50"   >
            <MasterTableView>
            <Columns>            
            <telerik:GridBoundColumn HeaderText="FinishingLineID" DataField="FinishingLineID" Display ="false" AllowFiltering="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left"  />
            </telerik:GridBoundColumn> 
             <telerik:GridBoundColumn HeaderText="FinishingLineDetailID" DataField="FinishingLineDetailID" Display ="false" AllowFiltering="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left"  />
            </telerik:GridBoundColumn>  
              <telerik:GridBoundColumn  HeaderText="Week" DataField="Week"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left"  />
            </telerik:GridBoundColumn> 
              <telerik:GridBoundColumn HeaderText="Production Date" DataField="ProductionDates"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left"  />
            </telerik:GridBoundColumn>   
 <telerik:GridBoundColumn HeaderText="Washing" DataField="Washing"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left"  />
            </telerik:GridBoundColumn>  
            <telerik:GridBoundColumn HeaderText="Pressing" DataField="Pressing" AllowFiltering="false"   >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left"  />
            </telerik:GridBoundColumn>  

            <telerik:GridBoundColumn HeaderText="Packing" DataField="Packing" >
           <ItemStyle HorizontalAlign="Right" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" Wrap="false"  />
            </telerik:GridBoundColumn>  

            <telerik:GridBoundColumn HeaderText="Ready To Inspect" DataField="ReadyToInspect">
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="10%" HorizontalAlign="Left"  />
            </telerik:GridBoundColumn>  
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
