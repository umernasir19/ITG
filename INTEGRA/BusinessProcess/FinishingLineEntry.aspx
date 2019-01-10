<%@ Page Language="vb"  MasterPageFile="~/MasterPage.master"  AutoEventWireup="false" CodeBehind="FinishingLineEntry.aspx.vb" Inherits="Integra.FinishingLineEntry" %>
 <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <table>
    <tr>
      <td style="height: 30px; width: 128px;"    >
                <asp:Label ID="lblCustomerName" runat="server" Text="Customer"></asp:Label>
            </td>
            <td class="TopHeaderTd3" style="width: 145px; height: 30px;">
              
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
           <td class="TopHeaderTd3" style="width: 145px; height: 30px;">
            
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
           <td class="TopHeaderTd3" style="width: 145px; height: 30px;">
           
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
           <td class="TopHeaderTd3" style="width: 145px; height: 30px;">
           
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
            <td class="TopHeaderTd3" style="width: 145px; height: 30px;">
          
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
                <asp:Label ID="Label4" runat="server" Text="Stitched"></asp:Label>
            </td>
           <td class="TopHeaderTd3" style="width: 145px; height: 30px;">
           <telerik:RadTextBox ID="txtStitched" ReadOnly="true" BackColor="#FFFFFF" Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
                  </td> 
                
    </tr>
     <tr>
  
                 <td style="height: 30px; width: 128px;">
                <asp:Label ID="Label6" runat="server" Text="Line initiate Dt"></asp:Label>
            </td>
           <td class="TopHeaderTd3" style="width: 145px; height: 30px;">
           
             <telerik:RadDatePicker ID="txtLineinitiateDt" runat="server" Culture="en-US"   width="100">
<Calendar ID="Calendar2" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>
<DateInput ID="DateInput2" DisplayDateFormat="dd/MM/yyyy" runat="server" DateFormat="dd/MM/yyyy" LabelWidth ="30%"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
 </telerik:RadDatePicker>
                
                </td> 
                 <td style="height: 30px; width: 128px;">
                <asp:Label ID="Label7" runat="server" Text="Line Exit Dt"></asp:Label>
            </td>
           <td class="TopHeaderTd3" style="width: 145px; height: 30px;">
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
     <telerik:RadGrid ID="dgFinishingLine" runat="server" CellSpacing="0" 
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
          <telerik:GridBoundColumn HeaderText="FinishingLineDetailID" DataField="FinishingLineDetailID" Display ="false" >
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="FinishingLineID" DataField="FinishingLineID" Display ="false" >
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn> 
 
              <telerik:GridTemplateColumn HeaderText="Production Dt" >
            <ItemTemplate>
 <telerik:RadDatePicker ID="txtProductionDt" Enabled = "False" Font-Bold="true" SelectedDate ='<% #Eval("Dates") %>'  runat="server" Culture="en-US"   width="100">
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
               <telerik:GridTemplateColumn HeaderText="Washing" >
            <ItemTemplate>
                 <telerik:RadTextBox ID="txtWashing"    width="80"  Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
             </ItemTemplate>
              <ItemStyle Width="10%" HorizontalAlign="Left" />
             </telerik:GridTemplateColumn>
             <telerik:GridTemplateColumn HeaderText="Pressing" >
            <ItemTemplate>
                <telerik:RadTextBox ID="txtPressing"   width="80"  Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
             </ItemTemplate>
             </telerik:GridTemplateColumn>
         
                <telerik:GridTemplateColumn HeaderText="Packing" >
            <ItemTemplate>
                  <telerik:RadTextBox ID="txtPacking"   width="80"  Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
             </ItemTemplate>
             <ItemStyle Width="10%" HorizontalAlign="Left" />
             </telerik:GridTemplateColumn>
                   <telerik:GridTemplateColumn HeaderText="Ready to Inspectl" >
                  <ItemTemplate>
                  <telerik:RadTextBox ID="txtReadyToInspect"   width="80"  Runat="server" Skin="WebBlue">
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