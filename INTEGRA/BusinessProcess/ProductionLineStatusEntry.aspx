<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeBehind="ProductionLineStatusEntry.aspx.vb" Inherits="Integra.ProductionLineStatusEntry" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
 <AjaxSettings>
 <telerik:AjaxSetting AjaxControlID="cmbCustomer">
 <UpdatedControls>
 <telerik:AjaxUpdatedControl ControlID="cmbSupplier" />
 </UpdatedControls>
 </telerik:AjaxSetting>
 <telerik:AjaxSetting AjaxControlID="cmbSupplier">
 <UpdatedControls>
 <telerik:AjaxUpdatedControl ControlID="cmbPONO" />
 </UpdatedControls>
 </telerik:AjaxSetting>
 <telerik:AjaxSetting AjaxControlID="cmbPONO">
 <UpdatedControls>
 <telerik:AjaxUpdatedControl ControlID="txtShipmentDate" />
 <telerik:AjaxUpdatedControl ControlID="txtPlacementDate" />
 <telerik:AjaxUpdatedControl ControlID="txtDaysLeft" />
 <telerik:AjaxUpdatedControl ControlID="txtTodayDate" />
  <telerik:AjaxUpdatedControl ControlID="txtBookedQuantity" />
 <telerik:AjaxUpdatedControl ControlID="lblTotalLines" />
 <telerik:AjaxUpdatedControl ControlID="txtTotalLines" />
 <telerik:AjaxUpdatedControl ControlID="lblProductionLine" />
 <telerik:AjaxUpdatedControl ControlID="txtProductionLine" />
 <telerik:AjaxUpdatedControl ControlID="lblProductionDay" />
 <telerik:AjaxUpdatedControl ControlID="txtProductionDay" />
 <telerik:AjaxUpdatedControl ControlID="lblDaysRequired" />
 <telerik:AjaxUpdatedControl ControlID="txtDaysRequired" />
 <telerik:AjaxUpdatedControl ControlID="lblLineInitiated" />
 <telerik:AjaxUpdatedControl ControlID="cmbLineInitiatedOn" />
 <telerik:AjaxUpdatedControl ControlID="lblLineClosing" />
 <telerik:AjaxUpdatedControl ControlID="cmbLineClosing" />
 <telerik:AjaxUpdatedControl ControlID="btnSave" />
 <telerik:AjaxUpdatedControl ControlID="dgPurchaseOrder" />
 </UpdatedControls>
 </telerik:AjaxSetting>
 <telerik:AjaxSetting AjaxControlID="txtTotalLines">
 <UpdatedControls>
 <telerik:AjaxUpdatedControl ControlID="txtProductionDay" />
 </UpdatedControls>
 </telerik:AjaxSetting>
 <telerik:AjaxSetting AjaxControlID="txtProductionLine">
 <UpdatedControls>
 <telerik:AjaxUpdatedControl ControlID="txtProductionDay" />
 </UpdatedControls>
 </telerik:AjaxSetting>
 <telerik:AjaxSetting AjaxControlID="cmbLineInitiatedOn">
 <UpdatedControls>
 <telerik:AjaxUpdatedControl ControlID="txtDaysRequired" />
 </UpdatedControls>
 </telerik:AjaxSetting>
 <telerik:AjaxSetting AjaxControlID="cmbLineClosing">
 <UpdatedControls>
 <telerik:AjaxUpdatedControl ControlID="txtDaysRequired" />
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
         <telerik:RadTextBox ID="txtCustomerID" Runat="server" Skin="WebBlue" 
                Width="30px" ReadOnly="True">
            </telerik:RadTextBox>
                     <telerik:RadComboBox ID="cmbCustomer" Runat="server" Skin="WebBlue" 
                AutoPostBack="true" Width="140px">
                <DefaultItem Text="Select Customer" />
                 </telerik:RadComboBox>
                  <telerik:RadTextBox ID="txtCustomer" Runat="server" Skin="WebBlue" 
                Width="140px" ReadOnly="True" BackColor="#80BFFF">
            </telerik:RadTextBox>
                      </td>
        <td style="width: 104px; height: 31px;">
           
            <asp:Label ID="lblSupplir" runat="server" Text="Supplier:" Font-Bold="True"></asp:Label>
           
            </td>
        <td style="width: 160px; height: 31px;">
         <telerik:RadTextBox ID="txtSuplierID" Runat="server" Skin="WebBlue" 
                Width="30px" ReadOnly="True">
            </telerik:RadTextBox>
            <telerik:RadComboBox ID="cmbSupplier" Runat="server" Skin="WebBlue" 
                AutoPostBack="true" OnSelectedIndexChanged="cmbSupplier_SelectedIndexChanged" 
                Width="140px">
                 <DefaultItem Text="Select Supplier" />
                      </telerik:RadComboBox>
           <telerik:RadTextBox ID="txtSupplier" Runat="server" Skin="WebBlue" 
                Width="140px" ReadOnly="True" BackColor="#80BFFF">
            </telerik:RadTextBox>
            </td>
        <td style="width: 94px; height: 31px;">
           
            <asp:Label ID="lblPONO" runat="server" Text="PO No:" Font-Bold="True"></asp:Label>
           
            </td>
        <td style="height: 31px">
         <telerik:RadTextBox ID="txtPOID" Runat="server" Skin="WebBlue" 
                Width="30px" ReadOnly="True">
            </telerik:RadTextBox>
            <telerik:RadComboBox ID="cmbPONO" Runat="server" Skin="WebBlue" 
                AutoPostBack="true" Width="140px" OnSelectedIndexChanged="cmbPONO_SelectedIndexChanged" >
                 <DefaultItem Text="Select PO No" />
                   </telerik:RadComboBox>
        <telerik:RadTextBox ID="txtPONO" Runat="server" Skin="WebBlue" 
                Width="140px" ReadOnly="True" BackColor="#80BFFF">
            </telerik:RadTextBox>
            </td>
        <td style="height: 31px; width: 49px;">
           
            <asp:Label ID="lblTodayDate" runat="server" Text="Today Date:" Font-Bold="True"></asp:Label>
           
            </td>
        <td style="height: 31px">
             <telerik:RadTextBox ID="txtTodayDate" Runat="server" Skin="WebBlue" 
                Width="110px" ReadOnly="True">
            </telerik:RadTextBox>
            </td>
        </tr>
          <tr>
        <td style="height: 25px">
        
            <asp:Label ID="lblPlacedOn" runat="server" Text="Placed On:" Font-Bold="True"></asp:Label>
           
        </td>
        <td style="height: 25px">
        
            <telerik:RadTextBox ID="txtPlacementDate" Runat="server" Skin="WebBlue" 
                Width="140px" ReadOnly="True">
            </telerik:RadTextBox>
        
        </td>
        <td style="height: 25px">
        
            <asp:Label ID="lblFOBDate" runat="server" Text="FOB Date:" Font-Bold="True"></asp:Label>
           
        </td>
        <td style="height: 25px; width: 160px;">
        
            <telerik:RadTextBox ID="txtShipmentDate" Runat="server" Skin="WebBlue" 
                Width="140px" ReadOnly="True">
            </telerik:RadTextBox>
        
        </td>
        <td style="height: 25px">
        
            <asp:Label ID="lblDaysLeft" runat="server" Text="Days Left:" Font-Bold="True"></asp:Label>
           
        </td>
        <td style="height: 25px">
        
            <telerik:RadTextBox ID="txtDaysLeft" Runat="server" Skin="WebBlue" 
                Width="100px" ReadOnly="True">
            </telerik:RadTextBox>
        
        </td>
        <td style="height: 25px; width: 49px;">
        
            <asp:Label ID="lblBookedQuantity" runat="server" Text="Booked Quantity" 
                Font-Bold="True"></asp:Label>
           
              </td>
        <td style="height: 25px">
        
            <telerik:RadTextBox ID="txtBookedQuantity" Runat="server" Skin="WebBlue" 
                Width="110px" ReadOnly="True">
            </telerik:RadTextBox>
        
              </td>
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
                Width="140px" AutoPostBack="true">
            </telerik:RadTextBox>
        
        </td>
        <td>
        
            <asp:Label ID="lblProductionLine" runat="server" Text="Production/Line:" 
                Font-Bold="True"></asp:Label>
           
        </td>
        <td style="width: 160px">
        
            <telerik:RadTextBox ID="txtProductionLine" Runat="server" Skin="WebBlue" 
                Width="140px" AutoPostBack="true">
            </telerik:RadTextBox>
        
        </td>
        <td>
        
            <asp:Label ID="lblProductionDay" runat="server" Text="Production/Day:" 
                Font-Bold="True"></asp:Label>
           
        </td>
        <td>
        
            <telerik:RadTextBox ID="txtProductionDay" Runat="server" Skin="WebBlue" 
                Width="140px" ReadOnly="True">
            </telerik:RadTextBox>
        
        </td>
        <td class="TopHeaderTd4" style="width: 49px">
        
            <asp:Label ID="lblDaysRequired" runat="server" Text="Days Required:" 
                Font-Bold="True"></asp:Label>
           
        </td>
        <td>
       
            <telerik:RadTextBox ID="txtDaysRequired" Runat="server" Skin="WebBlue" 
                Width="100px" ReadOnly="True">
            </telerik:RadTextBox>
        
        </td>
        </tr>
        <tr>
        <td style="height: 25px"></td>
        <td></td>
        <td>
        
            <asp:Label ID="lblLineInitiated" runat="server" Text="Line Initiated On:" 
                Font-Bold="True"></asp:Label>
           
            </td>
        <td style="width: 160px">
            <telerik:RadDatePicker ID="cmbLineInitiatedOn" Runat="server" Width="110px" 
                Skin="WebBlue" AutoPostBack="true">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" Skin="WebBlue"></Calendar>

<DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>
            </td>
        <td>
        
            <asp:Label ID="lblLineClosing" runat="server" Text="Line Closing:" 
                Font-Bold="True"></asp:Label>
           
            </td>
        <td>
            <telerik:RadDatePicker ID="cmbLineClosing" Runat="server" Width="110px" 
                Skin="WebBlue" AutoPostBack="true">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" Skin="WebBlue"></Calendar>

<DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>
            </td>
        <td class="TopHeaderTd4" style="width: 49px"></td>
        <td></td>
        </tr>
          <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;" 
              visible="true";>
        <th colspan ="8" align="left"
  
                
                style="font-family: 'Calibri'; font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit; height: 29px;" 
                valign="bottom"> Style Information
  </th>
        </tr>
        <tr>
        <td colspan="8">
        <asp:UpdatePanel ID="updgPurchaseOrder" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
     <telerik:RadGrid ID="dgPurchaseOrder" runat="server" CellSpacing="0" 
                AutoGenerateColumns="false"  Skin="WebBlue"  
                Visible="True" PageSize="50" Width="100%">
            <MasterTableView>
            <Columns>
           
            <telerik:GridBoundColumn HeaderText="PLSD ID" DataField="PLSDID" Display="false">
            
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Style No" DataField="StyleNo">
           <ItemStyle HorizontalAlign="Left"  />
            <HeaderStyle Width="20%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn> 
            <telerik:GridBoundColumn HeaderText="Booked Qty" DataField="BookedQuantity"  HeaderStyle-Width = "50px">
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle  Width="20%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>      
                 <telerik:GridTemplateColumn HeaderText="Booked Lines" >
                 <HeaderStyle  Width="20%" />
            <ItemTemplate>
                  <telerik:RadNumericTextBox ID="txtBookedLines" width="60"  Runat="server" Skin="WebBlue" >
                  <NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>
                </telerik:RadNumericTextBox>
            </ItemTemplate>
             </telerik:GridTemplateColumn>
           <telerik:GridTemplateColumn HeaderText="Select">
           <HeaderStyle  Width="20%" />
           <ItemTemplate>
                 <asp:CheckBox id="chkSelected" Checked="true" AutoPostBack="false" runat="server" />							
         </ItemTemplate>
             </telerik:GridTemplateColumn>
             
            </Columns>
            </MasterTableView>
            <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="false">
                                <Selecting AllowRowSelect="true" EnableDragToSelectRows="false" />
                            </ClientSettings>
            </telerik:RadGrid>
                      </ContentTemplate>
           </asp:UpdatePanel>
        </td>
        </tr>
        <tr>
        <td></td>
        <td></td>
        <td></td>
        <td style="width: 160px"></td>
        <td></td>
        <td></td>
        <td class="TopHeaderTd4" style="width: 49px">
            <telerik:RadButton ID="btnSave" runat="server" Text="Save" Skin="WebBlue">
            </telerik:RadButton>
            </td>
        <td>
            <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" Skin="WebBlue">
            </telerik:RadButton>
            </td>
        </tr>

</table>

</div>
</asp:Content>
