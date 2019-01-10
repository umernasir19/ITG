<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="ProductionLineStatusPlanning.aspx.vb" Inherits="Integra.ProductionLineStatusPlanning" %>
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
                Width="140px" ReadOnly="True" BackColor="#80BFFF">
            </telerik:RadTextBox>
            </td>
        <td style="width: 104px; height: 31px;">
           
            <asp:Label ID="lblSupplir" runat="server" Text="Supplier:" Font-Bold="True"></asp:Label>
           
            </td>
        <td style="width: 160px; height: 31px;">
             <telerik:RadTextBox ID="txtSupplier" Runat="server" Skin="WebBlue" 
                Width="140px" ReadOnly="True" BackColor="#80BFFF">
            </telerik:RadTextBox>
            </td>
        <td style="width: 94px; height: 31px;">
           
            <asp:Label ID="lblPONO" runat="server" Text="PO No:" Font-Bold="True"></asp:Label>
           
            </td>
        <td style="height: 31px">
              <telerik:RadTextBox ID="txtPONO" Runat="server" Skin="WebBlue" 
                Width="100px" ReadOnly="True" BackColor="#80BFFF">
            </telerik:RadTextBox>
            </td>
        <td style="height: 31px; width: 49px;">
           
            <asp:Label ID="lblTodayDate" runat="server" Text="Today Date:" Font-Bold="True"></asp:Label>
           
            </td>
        <td style="height: 31px">
             <telerik:RadTextBox ID="txtTodayDate" Runat="server" Skin="WebBlue" 
                Width="100px" ReadOnly="True" BackColor="#80BFFF">
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
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;" 
              visible="true";>
        <th colspan ="8" align="left"
  
                
                style="font-family: 'Calibri'; font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit; height: 29px;" 
                valign="bottom"> Production Line Planned
  </th>
        </tr>
        <tr>
        <td style="height: 25px">
        
            <asp:Label ID="lblTotalLines" runat="server" Text="Total Lines:" 
                Font-Bold="True"></asp:Label>
           
        </td>
        <td>
        
            <telerik:RadTextBox ID="txtTotalLines" Runat="server" Skin="WebBlue" 
                Width="100px" ReadOnly="true" BackColor="#80BFFF" >
            </telerik:RadTextBox>
        
        </td>
        <td>
        
            <asp:Label ID="lblPlacedOn0" runat="server" Text="Production/Line:" 
                Font-Bold="True"></asp:Label>
           
        </td>
        <td style="width: 160px">
        
            <telerik:RadTextBox ID="txtProductionLine" Runat="server" Skin="WebBlue" 
                Width="100px" ReadOnly="true" BackColor="#80BFFF" >
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
                Width="100px" ReadOnly="True" BackColor="#80BFFF">
            </telerik:RadTextBox>
            </td>
        <td style="height: 33px">
        
            <asp:Label ID="lblLineClosing" runat="server" Text="Line Closing:" 
                Font-Bold="True"></asp:Label>
           
            </td>
        <td style="height: 33px">
               <telerik:RadTextBox ID="txtLineClosing" Runat="server" Skin="WebBlue" 
                Width="100px" ReadOnly="True" BackColor="#80BFFF">
            </telerik:RadTextBox>
            </td>
        <td class="TopHeaderTd4" style="width: 49px; height: 33px;"></td>
        <td style="height: 33px"></td>
        </tr>
         <tr>
        <td colspan="8">
                    <telerik:RadGrid ID="dgProductionLineStatusPlanning" runat="server" CellSpacing="0" 
                AutoGenerateColumns="false"  Skin="WebBlue"  
                Visible="True" PageSize="50" Width="100%">
            <MasterTableView>
            <Columns>
           
            <telerik:GridBoundColumn HeaderText="PLSD ID" DataField="PLSDID" Display="false">
            
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Style No" DataField="StyleNo" >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn> 
            <telerik:GridBoundColumn HeaderText="Booked Qty" DataField="BookedQuantity" >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Booked Lines" DataField="BookedLines" HeaderStyle-Width ="15">
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>      
                 <telerik:GridTemplateColumn HeaderText="Stitched So Far" >
            <ItemTemplate>
                  <telerik:RadNumericTextBox ID="txtStitchedSoFar" width="100"  Runat="server" Skin="WebBlue">
                 <NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>
                </telerik:RadNumericTextBox>
            </ItemTemplate>
             <HeaderStyle Width="10%" HorizontalAlign="Left" />
             </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn HeaderText="Date" >
            <ItemTemplate >
                  <telerik:RadComboBox ID="cmbDate" width="120"  Runat="server" Skin="WebBlue">
                </telerik:RadComboBox>
            </ItemTemplate>
             <HeaderStyle Width="10%" HorizontalAlign="Left" />
             </telerik:GridTemplateColumn>
                         <telerik:GridBoundColumn HeaderText="Balance Qty" DataField="BalanceQty">
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
 
            </Columns>
            </MasterTableView>
            <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="false">
                                <Selecting AllowRowSelect="true" EnableDragToSelectRows="false" />
                            </ClientSettings>
            </telerik:RadGrid>
                     
        </td>
        </tr>
        <tr>
        <td style="height: 40px"></td>
        <td style="height: 40px"></td>
        <td style="height: 40px"></td>
        <td style="width: 160px; height: 40px;"></td>
        <td style="height: 40px"></td>
        <td style="height: 40px"></td>
        <td class="TopHeaderTd4" style="width: 49px; height: 40px;">
            <telerik:RadButton ID="btnSave" runat="server" Text="Save" Skin="WebBlue">
            </telerik:RadButton>
            </td>
        <td style="height: 40px">
            <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" Skin="WebBlue">
            </telerik:RadButton>
            </td>
        </tr>
          <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;" 
              visible="true";>
        <th colspan ="8" align="left"
  
                
                style="font-family: 'Calibri'; font-size: 22px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit; height: 29px;" 
                valign="bottom"> Production Activity History 
  </th>
        </tr>
         <tr>
        <td colspan="8">
                    <telerik:RadGrid ID="dgProductionPlannedHistory" runat="server" CellSpacing="0" 
                AutoGenerateColumns="false"  Skin="WebBlue"  
                Visible="True" PageSize="50" Width="100%">
            <MasterTableView>
            <Columns>
           
            <telerik:GridBoundColumn HeaderText="PLSD ID" DataField="PLSDID" Display="false">
            
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Style No" DataField="StyleNo">
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn> 
                  <telerik:GridBoundColumn HeaderText="Stitched So Far" DataField="StitchedQty">
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn> 
             <telerik:GridBoundColumn HeaderText="Activity Date" DataField="CreationDate">
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Date" DataField="StitchedDate">
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
</asp:Content>
