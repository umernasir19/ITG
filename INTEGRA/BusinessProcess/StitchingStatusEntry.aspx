<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeBehind="StitchingStatusEntry.aspx.vb" Inherits="Integra.StitchingStatusEntry" %>
 <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <table>
    <tr>
      <td style="height: 30px; width: 128px;"    >
                <asp:Label ID="lblCustomerName" runat="server" Text="Customer"></asp:Label>
            </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
              
                    <telerik:RadComboBox ID="cmbCustomer" Runat="server" AutoPostBack="True" 
                    Skin="WebBlue"  OnSelectedIndexChanged="cmbCustomer_SelectedIndexChanged" >
                       <DefaultItem Text="Select Customer.." Value="0" />
                </telerik:RadComboBox>
                  <telerik:RadTextBox ID="txtcustomer" ReadOnly="true"  BackColor="#FFFFFF" Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
              
                </td> 
                 <td style="height: 30px; width: 128px;"  >
                <asp:Label ID="lblSupplier" runat="server" Text="Supplier"></asp:Label>
            </td>
           <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
            
                    <telerik:RadComboBox ID="cmbSupplier" Runat="server" AutoPostBack="True" 
                    Skin="WebBlue" OnSelectedIndexChanged="cmbSupplier_SelectedIndexChanged"  >
                       <DefaultItem Text="Select Supplier.." Value="0" />
                </telerik:RadComboBox>
                  <telerik:RadTextBox ID="txtsupplier" ReadOnly="true"  BackColor="#FFFFFF" Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
                
                
                </td> 
                 <td style="height: 30px; width: 128px;"  >
                <asp:Label ID="lblPONO" runat="server" Text="PO No."></asp:Label>
            </td>
           <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
           
                    <telerik:RadComboBox ID="cmbPONo" Runat="server" AutoPostBack="True" 
                    Skin="WebBlue" OnSelectedIndexChanged="cmbPONo_SelectedIndexChanged" >
                      <DefaultItem Text="Select PO No.." Value="0" />
                </telerik:RadComboBox>
                   <telerik:RadTextBox ID="txtPONO" ReadOnly="true"  BackColor="#FFFFFF" Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
                  </td> 
                 <td style="height: 30px; width: 128px;"  >
                <asp:Label ID="Label1" runat="server" Text="Style No."></asp:Label>
            </td>
           <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
           
                    <telerik:RadComboBox ID="cmbStyleNo" Runat="server" AutoPostBack="True" 
                    Skin="WebBlue" >
                      <DefaultItem Text="Select Style No.." Value="0" />
                </telerik:RadComboBox>
                 <telerik:RadTextBox ID="txtStyleNo" ReadOnly="true"  BackColor="#FFFFFF" Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
                  </td> 
    </tr>
    <tr>
      <td style="height: 30px; width: 128px;">
                <asp:Label ID="Label2" runat="server" Text="Style Qty"></asp:Label>
            </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
          
                  <telerik:RadTextBox ID="txtStyleQty" ReadOnly="true" BackColor="#FFFFFF" Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
              
                </td> 
                 <td style="height: 30px; width: 128px;">
                <asp:Label ID="Label3" runat="server" Text="Delivery Date"></asp:Label>
            </td>
           <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
           
                  <telerik:RadTextBox ID="txtDeliveryDate" ReadOnly="true" BackColor="#FFFFFF" Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
                
                
                </td> 
                 <td style="height: 30px; width: 128px;">
                <asp:Label ID="Label4" runat="server" Text="Cutting Status"></asp:Label>
            </td>
           <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
           <telerik:RadTextBox ID="txtCuttingStatus" ReadOnly="true" BackColor="#FFFFFF" Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
                  </td> 
                
    </tr>
     <tr>
      <td style="height: 30px; width: 128px;">
                <asp:Label ID="Label5" runat="server" Text="Select Line(s)"></asp:Label>
            </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
          
              <telerik:RadComboBox ID="cmbSelectLine" Runat="server" 
                 CheckBoxes="True" Skin="WebBlue">
                 <Items>
                 <telerik:RadComboBoxItem  Checked ="true" Value="0" Text="L1" />
                 <telerik:RadComboBoxItem Checked="true" Value="1" Text="L2" />
                 <telerik:RadComboBoxItem Value="2" Text="L3" />
                 <telerik:RadComboBoxItem Value="3" Text="L4" />
                 <telerik:RadComboBoxItem Value="4" Text="L5" />
                 <telerik:RadComboBoxItem Value="5" Text="L6" />
                 <telerik:RadComboBoxItem Value="6" Text="L7" />
                 <telerik:RadComboBoxItem Value="7" Text="L8" />
                 <telerik:RadComboBoxItem Value="8" Text="L9" />
                 <telerik:RadComboBoxItem Value="9" Text="L10" />
                 <telerik:RadComboBoxItem Value="10" Text="L11" />
                 <telerik:RadComboBoxItem Value="11" Text="L12" />
                 <telerik:RadComboBoxItem Value="12" Text="L13" />
                 <telerik:RadComboBoxItem Value="13" Text="L14" />
                 <telerik:RadComboBoxItem Value="14" Text="L15" />
                <telerik:RadComboBoxItem Value="15" Text="L16" />
                <telerik:RadComboBoxItem Value="16" Text="L17" />
                <telerik:RadComboBoxItem Value="17" Text="L18" />
                <telerik:RadComboBoxItem Value="18" Text="L19" />
                <telerik:RadComboBoxItem Value="19" Text="L20" />
                <telerik:RadComboBoxItem Value="20" Text="L21" />
                <telerik:RadComboBoxItem Value="21" Text="L22" />
                <telerik:RadComboBoxItem Value="22" Text="L23" />
                <telerik:RadComboBoxItem Value="23" Text="L24" />
                <telerik:RadComboBoxItem Value="24" Text="L25" />
               </Items>
                </telerik:RadComboBox>
              
                </td> 
                 <td style="height: 30px; width: 128px;">
                <asp:Label ID="Label6" runat="server" Text="Line initiate Dt"></asp:Label>
            </td>
           <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
           
             <telerik:RadDatePicker ID="txtLineinitiateDt" runat="server" Culture="en-US"   width="100">
<Calendar ID="Calendar2" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>
<DateInput ID="DateInput2" DisplayDateFormat="dd/MM/yyyy" runat="server" DateFormat="dd/MM/yyyy" LabelWidth ="30%"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
 </telerik:RadDatePicker>
                
                </td> 
                 <td style="height: 30px; width: 128px;">
                <asp:Label ID="Label7" runat="server" Text="Line Exit Dt"></asp:Label>
            </td>
           <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
         <telerik:RadDatePicker ID="txtLineExitDt" runat="server" Culture="en-US"   width="100">
<Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>
<DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" runat="server" DateFormat="dd/MM/yyyy" LabelWidth ="30%"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
 </telerik:RadDatePicker>
                  </td> 
                  <td>
                     <telerik:RadTextBox ID="txtPOID" Width="05" ReadOnly="true" BackColor="#FFFFFF" Runat="server" Skin="WebBlue">
                </telerik:RadTextBox> 
                  </td>
                  <td>
                   <telerik:RadButton ID="btnGenerateColumn" runat="server" Text="Generate Column"   Skin="WebBlue">
                </telerik:RadButton>
                      &nbsp;<telerik:RadButton ID="btnUpdateBelowEntries" runat="server" Text="Update Below Entries"   Skin="WebBlue">
                </telerik:RadButton>
                  
                  </td>
                
    </tr>
 </table>
 <table width="100%">
 <tr>
 <td>
     <telerik:RadGrid ID="dgStitchingStatus" runat="server" CellSpacing="0" 
                AutoGenerateColumns="false"  Skin="WebBlue"  
                Visible="False" PageSize="50" >
             <AlternatingItemStyle Font-Names="Microsoft Sans Serif" />
            <MasterTableView>
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
                    Visible="True">
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                    Visible="True">
                </ExpandCollapseColumn>
            <Columns>
          <telerik:GridBoundColumn HeaderText="StitchingStatusDetailID" DataField="StitchingStatusDetailID" Display ="false" >
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="StitchingStatusID" DataField="StitchingStatusID" Display ="false" >
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn> 
           <%-- <telerik:GridBoundColumn HeaderText="Production Dt"   DataField="Dates"   >
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="13%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>--%>
              <telerik:GridTemplateColumn HeaderText="Production Dt" >
            <ItemTemplate>
 <telerik:RadDatePicker ID="txtProductionDt" Enabled = "False" SelectedDate ='<% #Eval("Dates") %>'   runat="server" Culture="en-US"   width="100">
 <DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" runat="server" DateFormat="dd/MM/yyyy" LabelWidth ="30%"></DateInput>
 </telerik:RadDatePicker>
             </ItemTemplate>
              <ItemStyle Width="05%" HorizontalAlign="Left" />
             </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn HeaderText="Day Status" >
            <ItemTemplate>
               <telerik:RadComboBox ID="cmbDayStatus" Width="70" Runat="server" 
                    Skin="WebBlue">
                   <Items>
                   <telerik:RadComboBoxItem Value="0" Text="On" />
                    <telerik:RadComboBoxItem Value="1" Text="Off" />
                   </Items>
                </telerik:RadComboBox>
             </ItemTemplate>
              <ItemStyle Width="05%" HorizontalAlign="Left" />
             </telerik:GridTemplateColumn>
               <telerik:GridTemplateColumn HeaderText="L1-Plan" >
            <ItemTemplate>
                 <telerik:RadTextBox ID="txtL1Plan"    width="80"  Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
             </ItemTemplate>
              <ItemStyle Width="10%" HorizontalAlign="Left" />
             </telerik:GridTemplateColumn>
             <telerik:GridTemplateColumn HeaderText="L1-Actual" >
            <ItemTemplate>
                <telerik:RadTextBox ID="txtL1Actual"   width="80"  Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
             </ItemTemplate>
             </telerik:GridTemplateColumn>
         
                <telerik:GridTemplateColumn HeaderText="L2-Plan" >
            <ItemTemplate>
                  <telerik:RadTextBox ID="txtL2Plan"   width="80"  Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
             </ItemTemplate>
             <ItemStyle Width="10%" HorizontalAlign="Left" />
             </telerik:GridTemplateColumn>
                   <telerik:GridTemplateColumn HeaderText="L2-Actual" >
                  <ItemTemplate>
                  <telerik:RadTextBox ID="txtL2Actual"   width="80"  Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
               </ItemTemplate>
               <ItemStyle Width="10%" HorizontalAlign="Left" />
             </telerik:GridTemplateColumn>
                   <telerik:GridTemplateColumn HeaderText=" " >
                  <ItemTemplate>
                 
               </ItemTemplate>
               <ItemStyle Width="50%" HorizontalAlign="Left" />
             </telerik:GridTemplateColumn>
            
             </Columns>
                <EditFormSettings>
                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                    </EditColumn>
                </EditFormSettings>
                <PagerStyle PageSizeControlType="RadComboBox" />
            </MasterTableView>
            <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="false">
                                <Selecting AllowRowSelect="true" EnableDragToSelectRows="false" />
                            </ClientSettings>
             <HeaderStyle Font-Names="Microsoft Sans Serif" />
             <ItemStyle Font-Names="Microsoft Sans Serif" />
             <PagerStyle PageSizeControlType="RadComboBox" />
             <FilterMenu EnableImageSprites="False">
             </FilterMenu>
            </telerik:RadGrid>
 </td>
 </tr>
  <tr>
 <td align="right">
    <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel"   Skin="WebBlue">
     </telerik:RadButton>
 </td>
 </tr>
 </table>
</asp:Content> 