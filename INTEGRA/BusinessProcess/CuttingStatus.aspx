<%@ Page  MasterPageFile="~/MasterPage.master" Language="vb" AutoEventWireup="false" CodeBehind="CuttingStatus.aspx.vb" Inherits="Integra.CuttingStatus" %>
    <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManager ID="ajaxMan" runat="server">
<AjaxSettings>
<telerik:AjaxSetting AjaxControlID="txtConsumption1">
<UpdatedControls>
<telerik:AjaxUpdatedControl ControlID="txtOutputQty1" />
</UpdatedControls>
</telerik:AjaxSetting>
<telerik:AjaxSetting AjaxControlID="txtConsumption">
<UpdatedControls>
<telerik:AjaxUpdatedControl ControlID="txtOutputQty" />
</UpdatedControls>
</telerik:AjaxSetting>
</AjaxSettings>
</telerik:RadAjaxManager>
 <table>
    <tr>
      <td style="height: 30px; width: 128px;">
                <asp:Label ID="lblCustomerName" runat="server" Text="Customer"></asp:Label>
            </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
              
                    <telerik:RadComboBox ID="cmbCustomer" Runat="server" AutoPostBack="True" 
                    Skin="WebBlue"  OnSelectedIndexChanged="cmbCustomer_SelectedIndexChanged" >
                       <DefaultItem Text="Select Customer.." Value="0" />
                </telerik:RadComboBox>
                  <telerik:RadTextBox ID="txtcustomer" BackColor="#80BFFF" Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
              
                </td> 
                 <td style="height: 30px; width: 128px;">
                <asp:Label ID="lblSupplier" runat="server" Text="Supplier"></asp:Label>
            </td>
           <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
            
                    <telerik:RadComboBox ID="cmbSupplier" Runat="server" AutoPostBack="True" 
                    Skin="WebBlue" OnSelectedIndexChanged="cmbSupplier_SelectedIndexChanged"  >
                       <DefaultItem Text="Select Supplier.." Value="0" />
                </telerik:RadComboBox>
                  <telerik:RadTextBox ID="txtsupplier" BackColor="#80BFFF" Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
                
                
                </td> 
                 <td style="height: 30px; width: 128px;">
                <asp:Label ID="lblPONO" runat="server" Text="PO No."></asp:Label>
            </td>
           <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
           
                    <telerik:RadComboBox ID="cmbPONo" Runat="server" AutoPostBack="True" 
                    Skin="WebBlue" OnSelectedIndexChanged="cmbPONo_SelectedIndexChanged" >
                      <DefaultItem Text="Select PO No.." Value="0" />
                </telerik:RadComboBox>
                   <telerik:RadTextBox ID="txtPONO" BackColor="#80BFFF" Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
                  </td> 
                  <td>
                     <telerik:RadTextBox ID="txtPOID" Width="05"   Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
                  </td>
    </tr>
 </table>
 <table width="100%">
 <tr>
 <td>
     <asp:Label ID="lblApproval" runat="server" ></asp:Label>
 </td>
 </tr>
 <tr>
 <td>
    <telerik:RadGrid ID="dgCuttingStatus" runat="server" CellSpacing="0" 
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
             <telerik:GridBoundColumn HeaderText="CuttingStatusDetailID" DataField="CuttingStatusDetailID" Display ="false" >
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="CuttingStatusID" DataField="CuttingStatusID" Display ="false" >
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
              <telerik:GridTemplateColumn HeaderText="Style No." >
            <ItemTemplate>
                 <telerik:RadComboBox ID="cmbStyleNo" Runat="server" AutoPostBack="True" 
                    Skin="WebBlue" Width="100px">
                      <DefaultItem Text="Select Style No.." Value="0" />
                </telerik:RadComboBox>
            </ItemTemplate>
             </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn HeaderText="Input Date" >
            <ItemTemplate>
       <telerik:RadDatePicker ID="txtInputDate" runat="server" Culture="en-US"   width="100">
<Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>
<DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" runat="server" DateFormat="dd/MM/yyyy" LabelWidth ="30%"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
             </ItemTemplate>
             </telerik:GridTemplateColumn>
               <telerik:GridTemplateColumn HeaderText="Lot No." >
            <ItemTemplate>
                 <telerik:RadTextBox ID="txtLotNo"    width="60"  Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
             </ItemTemplate>
             </telerik:GridTemplateColumn>
             <telerik:GridTemplateColumn HeaderText="Input Qty (M)" >
            <ItemTemplate>
                 <telerik:RadNumericTextBox ID="txtInputQty" width="60"  Runat="server"  
                     Skin="WebBlue" >
                <NumberFormat ZeroPattern="n" decimaldigits="0"></NumberFormat>
                </telerik:RadNumericTextBox>
             </ItemTemplate>
             </telerik:GridTemplateColumn>
              <telerik:GridTemplateColumn HeaderText="Output Date" >
            <ItemTemplate>
            <telerik:RadDatePicker ID="txtOutputDate" runat="server" Culture="en-US"   width="100">
<Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>
<DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" runat="server" DateFormat="dd/MM/yyyy" LabelWidth ="30%"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
             </ItemTemplate>
             </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Consumption" >
            <ItemTemplate>
                 <telerik:RadNumericTextBox ID="txtConsumption" width="60"   Runat="server" AutoPostBack="true" 
                     Skin="WebBlue" ontextchanged="txtConsumption_TextChanged">
                <NumberFormat  decimaldigits="2"></NumberFormat>
                </telerik:RadNumericTextBox>
             </ItemTemplate>
             </telerik:GridTemplateColumn>
                   <telerik:GridTemplateColumn HeaderText="Output Qty(Pcs)" >
                  <ItemTemplate>
                  <telerik:RadNumericTextBox ID="txtOutputQty"   width="60"  Runat="server" Skin="WebBlue">
                <NumberFormat ZeroPattern="n" decimaldigits="0"></NumberFormat>
                </telerik:RadNumericTextBox>
               </ItemTemplate>
             </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Remarks" >
                  <ItemTemplate>
                  <telerik:RadTextBox ID="txtRemarks" width="120"  Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
               </ItemTemplate>
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
   <telerik:RadButton ID="btnAdd" runat="server" Text="Add Detail"   Skin="WebBlue">
                </telerik:RadButton>
 </td>
 </tr>
 <tr>
 <td>
    <telerik:RadGrid ID="dgCuttingDetail" runat="server" CellSpacing="0" 
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
             <telerik:GridBoundColumn HeaderText="CuttingStatusDetailID" DataField="CuttingStatusDetailID" Display ="false" >
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="CuttingStatusID" DataField="CuttingStatusID" Display ="false" >
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Style No." DataField="StyleNo" Display ="true"  >
            <HeaderStyle Width="3%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>
            <telerik:GridTemplateColumn HeaderText="Input Date" >
            <ItemTemplate>
       <telerik:RadDatePicker ID="txtInputDate" runat="server" Culture="en-US"  SelectedDate ='<% #Eval("InputDate") %>'    width="100">
<Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>
<DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" runat="server" DateFormat="dd/MM/yyyy" LabelWidth ="30%"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
             </ItemTemplate>
             </telerik:GridTemplateColumn>
               <telerik:GridTemplateColumn HeaderText="Lot No." >
            <ItemTemplate>
                 <telerik:RadTextBox ID="txtLotNo"    width="60" text='<% #Eval("LotNo") %>'   Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
             </ItemTemplate>
             </telerik:GridTemplateColumn>
             <telerik:GridTemplateColumn HeaderText="Input Qty (M)" >
            <ItemTemplate>
                 <telerik:RadNumericTextBox ID="txtInputQty" width="60" text='<% #Eval("InputQty") %>'   Runat="server" Skin="WebBlue">
                <NumberFormat ZeroPattern="n" decimaldigits="0"></NumberFormat>
                </telerik:RadNumericTextBox>
             </ItemTemplate>
             </telerik:GridTemplateColumn>
              <telerik:GridTemplateColumn HeaderText="Output Date" >
            <ItemTemplate>
            <telerik:RadDatePicker ID="txtOutputDate" runat="server" Culture="en-US" SelectedDate ='<% #Eval("OutputDate") %>'    width="100">
<Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>
<DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" runat="server" DateFormat="dd/MM/yyyy" LabelWidth ="30%"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
             </ItemTemplate>
             </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Consumption" >
            <ItemTemplate>
                 <telerik:RadTextBox ID="txtConsumption1" width="60" 
                     text='<% #Eval("Consumption") %>'   Runat="server" Skin="WebBlue" 
                     ontextchanged="txtConsumption1_TextChanged" AutoPostBack="true">
               
                </telerik:RadTextBox>
             </ItemTemplate>
             </telerik:GridTemplateColumn>
                   <telerik:GridTemplateColumn HeaderText="Output Qty(Pcs)" >
                  <ItemTemplate>
                  <telerik:RadNumericTextBox ID="txtOutputQty1"   width="60" text='<% #Eval("OutputQty") %>'   Runat="server" Skin="WebBlue">
                <NumberFormat ZeroPattern="n" decimaldigits="0"/>
                </telerik:RadNumericTextBox>
               </ItemTemplate>
             </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Remarks" >
                  <ItemTemplate>
                  <telerik:RadTextBox ID="txtRemarks"    width="120" text='<% #Eval("Remarks") %>'   Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
               </ItemTemplate>
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
 <td align="center">
    <telerik:RadButton ID="btnSave" runat="server" Text="Save"   Skin="WebBlue">
                </telerik:RadButton>
     &nbsp;
     <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel"   Skin="WebBlue">
     </telerik:RadButton>
 </td>
 </tr>
 </table>


 </asp:Content>
