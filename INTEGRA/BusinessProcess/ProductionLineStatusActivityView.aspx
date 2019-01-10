<%@ Page Language="vb" AutoEventWireup="false"  MasterPageFile="~/MasterPage.master"  CodeBehind="ProductionLineStatusActivityView.aspx.vb" Inherits="Integra.ProductionLineStatusActivityView" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Charting" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
 <AjaxSettings>
 <telerik:AjaxSetting AjaxControlID="btnSave">
 <UpdatedControls>
 <telerik:AjaxUpdatedControl ControlID="dgProductionPlannedHistory" />
 <telerik:AjaxUpdatedControl ControlID="dgProductionLineStatusPlanning" />
 </UpdatedControls>
 </telerik:AjaxSetting>
 </AjaxSettings>
 </telerik:RadAjaxManager>
<div style="width:930px;">
<table style="width:930px;">
<tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;" 
              visible="true";>
        <th colspan ="8" align="left"
  
                
                style="font-family: 'Calibri'; font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit; height: 29px;" 
                valign="bottom"> PO Information
  </th>
        </tr>
        <tr>
        <td style="height: 31px; width: 93px;">
           
            <asp:Label ID="lblCustomer" runat="server" Text="Customer:" Font-Bold="True"></asp:Label>
           
            </td>
        <td class="TopHeaderTd3" style="width: 173px; height: 31px;">
              <telerik:RadTextBox ID="txtCustomer" Runat="server" Skin="WebBlue" 
                Width="150px" ReadOnly="True" BackColor="#80BFFF">
            </telerik:RadTextBox>
            </td>
        <td style="width: 104px; height: 31px;">
           
            <asp:Label ID="lblSupplir" runat="server" Text="Supplier:" Font-Bold="True"></asp:Label>
           
            </td>
        <td style="width: 160px; height: 31px;">
             <telerik:RadTextBox ID="txtSupplier" Runat="server" Skin="WebBlue" 
                Width="150px" ReadOnly="True" BackColor="#80BFFF">
            </telerik:RadTextBox>
            </td>
        <td style="width: 94px; height: 31px;">
           
            <asp:Label ID="lblPONO" runat="server" Text="PO No:" Font-Bold="True"></asp:Label>
           
            </td>
        <td style="height: 31px">
              <telerik:RadTextBox ID="txtPONO" Runat="server" Skin="WebBlue" 
                Width="150px" ReadOnly="True" BackColor="#80BFFF">
            </telerik:RadTextBox>
            </td>
        <td style="height: 31px; width: 49px;">
           
            <asp:Label ID="lblTodayDate" runat="server" Text="Today Date:" Font-Bold="True"></asp:Label>
           
            </td>
        <td style="height: 31px">
             <telerik:RadTextBox ID="txtTodayDate" Runat="server" Skin="WebBlue" 
                Width="90px" ReadOnly="True" BackColor="#80BFFF">
            </telerik:RadTextBox>
            </td>
        </tr>
          <tr>
        <td style="height: 25px">
        
            <asp:Label ID="lblPlacedOn" runat="server" Text="Placed On:" Font-Bold="True"></asp:Label>
           
        </td>
        <td style="height: 25px">
        
            <telerik:RadTextBox ID="txtPlacementDate" Runat="server" Skin="WebBlue" 
                Width="140px" ReadOnly="True" BackColor="#80BFFF">
            </telerik:RadTextBox>
        
        </td>
        <td style="height: 25px">
        
            <asp:Label ID="lblFOBDate" runat="server" Text="FOB Date:" Font-Bold="True"></asp:Label>
           
        </td>
        <td style="height: 25px; width: 160px;">
        
            <telerik:RadTextBox ID="txtShipmentDate" Runat="server" Skin="WebBlue" 
                Width="140px" ReadOnly="True" BackColor="#80BFFF">
            </telerik:RadTextBox>
        
        </td>
        <td style="height: 25px">
        
            <asp:Label ID="lblDaysLeft" runat="server" Text="Days Left:" Font-Bold="True"></asp:Label>
           
        </td>
        <td style="height: 25px">
        
            <telerik:RadTextBox ID="txtDaysLeft" Runat="server" Skin="WebBlue" 
                Width="100px" ReadOnly="True" BackColor="#80BFFF">
            </telerik:RadTextBox>
        
        </td>
        <td style="height: 25px; width: 49px;">
        
            &nbsp;</td>
        <td style="height: 25px">
        
            &nbsp;</td>
        </tr>
      
        <tr>
        <td colspan="8">
          <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
         <telerik:RadPanelBar runat="server" ID="ProductionPlanned" ExpandMode="MultipleExpandedItems"
                Width="100%" Skin="WebBlue" >
                <Items>
                <telerik:RadPanelItem Expanded="True" Text="Production Line Planned" Font-Size="Small" Font-Bold="true" runat="server" Selected="true">
                 <Items>
                  <telerik:RadPanelItem Value="ProductionLinePlanned" runat="server">
                    <ItemTemplate>
                    <div style="width:100%;">
                    <table width="100%">
                     <tr>
        <td style="height: 25px">
        
            <asp:Label ID="lblTotalLines" runat="server" Text="Total Lines:" 
                Font-Bold="True"></asp:Label>
           
        </td>
        <td>
        
            <telerik:RadTextBox ID="txtTotalLines" Runat="server" Skin="WebBlue" 
                Width="140px" ReadOnly="true" BackColor="#80BFFF" >
            </telerik:RadTextBox>
        
        </td>
        <td>
        
            <asp:Label ID="lblPlacedOn0" runat="server" Text="Production/Line:" 
                Font-Bold="True"></asp:Label>
           
        </td>
        <td style="width: 160px">
        
            <telerik:RadTextBox ID="txtProductionLine" Runat="server" Skin="WebBlue" 
                Width="140px" ReadOnly="true" BackColor="#80BFFF" >
            </telerik:RadTextBox>
        
        </td>
        <td>
        
            <asp:Label ID="lblProductionDay" runat="server" Text="Production/Day:" 
                Font-Bold="True"></asp:Label>
           
        </td>
        <td>
        
            <telerik:RadTextBox ID="txtProductionDay" Runat="server" Skin="WebBlue" 
                Width="140px" ReadOnly="True" BackColor="#80BFFF">
            </telerik:RadTextBox>
        
        </td>
        <td class="TopHeaderTd4" style="width: 49px">
        
            <asp:Label ID="lblDaysRequired" runat="server" Text="Days Required:" 
                Font-Bold="True"></asp:Label>
           
        </td>
        <td>
       
            <telerik:RadTextBox ID="txtDaysRequired" Runat="server" Skin="WebBlue" 
                Width="100px" ReadOnly="True" BackColor="#80BFFF">
            </telerik:RadTextBox>
        
        </td>
        </tr>
        <tr>
        <td style="height: 33px"></td>
        <td style="height: 33px"></td>
        <td style="height: 33px">
        
            <asp:Label ID="lblLineInitiated" runat="server" Text="Line Initiated On:" 
                Font-Bold="True"></asp:Label>
           
            </td>
        <td style="width: 160px; height: 33px;">
              <telerik:RadTextBox ID="txtLineInitiatedOn" Runat="server" Skin="WebBlue" 
                Width="130px" ReadOnly="True" BackColor="#80BFFF">
            </telerik:RadTextBox>
            </td>
        <td style="height: 33px">
        
            <asp:Label ID="lblLineClosing" runat="server" Text="Line Closing:" 
                Font-Bold="True"></asp:Label>
           
            </td>
        <td style="height: 33px">
               <telerik:RadTextBox ID="txtLineClosing" Runat="server" Skin="WebBlue" 
                Width="130px" ReadOnly="True" BackColor="#80BFFF">
            </telerik:RadTextBox>
            </td>
        <td class="TopHeaderTd4" style="width: 49px; height: 33px;"></td>
        <td style="height: 33px"></td>
        </tr>
                    </table>
                    </div>
                    </ItemTemplate>
                  </telerik:RadPanelItem>
                 </Items>
                </telerik:RadPanelItem>
                </Items>
                 <CollapseAnimation Duration="0" Type="None" />
                    <ExpandAnimation Duration="0" Type="None" />
                <ExpandAnimation Duration="0" Type="None" />
                <CollapseAnimation Duration="0" Type="None" />
                </telerik:RadPanelBar>
                 
         </telerik:RadAjaxPanel>
        </td>
        </tr>
        <tr>
        <td colspan="8">
           <telerik:RadChart ID="RadChart1" runat="server" DefaultType="Line" 
                AutoLayout="True" Width="918px" >
               <PlotArea>
                   <EmptySeriesMessage Visible="True">
                       <Appearance Visible="True">
                       </Appearance>
                   </EmptySeriesMessage>
               </PlotArea>
              </telerik:RadChart>
        </td>
         </tr>
          
        <tr>
        <td colspan="8">
         <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server">
          <telerik:RadPanelBar runat="server" ID="ActivityHistoryBar" ExpandMode="MultipleExpandedItems"
                Width="100%" Skin="WebBlue" >
                <Items>
                <telerik:RadPanelItem Expanded="False" Text="Production Activity History" Font-Size="13px" Font-Bold="true" runat="server" Selected="true">              
                 <Items>
                  <telerik:RadPanelItem Value="ProductionActivityHistory" runat="server">
                    <ItemTemplate>
                    <div style="width:100%;">
                    <table width="100%">
                     <tr>
                     <td>
                     <telerik:RadGrid ID="dgProductionPlannedHistory" runat="server" CellSpacing="0" 
                AutoGenerateColumns="false"  Skin="WebBlue"  
                Visible="True" PageSize="50" Width="100%">
            <MasterTableView>
            <Columns>
           
            <telerik:GridBoundColumn HeaderText="PLSD ID" DataField="PLSDID" Display="false">
            </telerik:GridBoundColumn>
               <telerik:GridBoundColumn HeaderText="Days" DataField="Days">
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn> 
            <telerik:GridBoundColumn HeaderText="Style No" DataField="StyleNo">
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn> 
              <telerik:GridBoundColumn HeaderText="Planned Date" DataField="PlannedDate">
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Planned" DataField="Planned">
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn> 
                <telerik:GridBoundColumn HeaderText="Produced" DataField="Produced">
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn> 
            </Columns>
            </MasterTableView>
            <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="false">
                                <Selecting AllowRowSelect="true" EnableDragToSelectRows="false" />
                            </ClientSettings>
            </telerik:RadGrid>
                 
                     </td>
                     </tr>
                     </table>
                     </div>
                     </ItemTemplate>
                     </telerik:RadPanelItem>
                 </Items>
                   </telerik:RadPanelItem>
                </Items>
                </telerik:RadPanelBar>
         </telerik:RadAjaxPanel>
        </td>
        </tr>
         <tr>
        <td colspan="8">
                    
        </td>
        </tr>
             <tr>
         <td colspan="8" align="right">
            <telerik:RadButton runat="server" ID="btnCancel" Text="Cancel" Skin="WebBlue"></telerik:RadButton>
            </td>
         </tr>
</table>
</div>
</asp:Content>