<%@ Page Language="vb"  MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeBehind="SMCAdd.aspx.vb" Inherits="Integra.SMCAdd" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <telerik:RadAjaxManager ID="ajaxMan" runat="server">
<AjaxSettings>
<telerik:AjaxSetting AjaxControlID="cmbCustomer">
<UpdatedControls>
<telerik:AjaxUpdatedControl ControlID="cmbSupplier" /> 
</UpdatedControls>
</telerik:AjaxSetting>
<telerik:AjaxSetting AjaxControlID="cmbSupplier">
<UpdatedControls>
<telerik:AjaxUpdatedControl ControlID="cmbPONo" />
</UpdatedControls>
</telerik:AjaxSetting>
<telerik:AjaxSetting AjaxControlID="cmbPONo">
<UpdatedControls>
<telerik:AjaxUpdatedControl ControlID="dgSMC" />
</UpdatedControls>
</telerik:AjaxSetting>
</AjaxSettings>
<AjaxSettings >
<telerik:AjaxSetting AjaxControlID ="txtSMCPercentage">
<UpdatedControls>
<telerik:AjaxUpdatedControl ControlID ="txtSMCUSD" />
</UpdatedControls>
</telerik:AjaxSetting>
</AjaxSettings>
</telerik:RadAjaxManager>
    <div>
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
                      <telerik:RadTextBox ID="txtcustomer" ReadOnly="true" BackColor="#80BFFF" Runat="server" Skin="WebBlue">
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
                   <telerik:RadTextBox ID="txtsupplier"  ReadOnly="true" BackColor="#80BFFF" Runat="server" Skin="WebBlue">
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
                   <telerik:RadTextBox ID="txtPONO"  ReadOnly="true"  BackColor="#80BFFF" Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
                  </td> 
                  
                  </tr>
 </table>
 <table width="100%">
  
 <tr>
    
    <td colspan ="5" align ="right" ><telerik:RadButton ID="btnSave" runat="server" Text="Save"   Skin="WebBlue">
                </telerik:RadButton></td></tr>
 <tr>
 <td>
    <telerik:RadGrid ID="dgSMC" runat="server" CellSpacing="0"  AutoGenerateColumns="false"  Skin="WebBlue"  Visible="true" PageSize="50">
            <MasterTableView>
            <Columns>   
             <telerik:GridBoundColumn HeaderText="SMCID" DataField="SMCID" Display ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left"  />
            </telerik:GridBoundColumn>         
            <telerik:GridBoundColumn HeaderText="POID" DataField="POID" Display ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left"  />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="PODetailID" DataField="PODetailID" Display ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left"  />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="StyleID" DataField="StyleID" Display ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left"  />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="StyleDetailID" DataField="StyleDetailID" Display ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left"  />
            </telerik:GridBoundColumn>
             
             <telerik:GridBoundColumn HeaderText="ShipedQuantity" DataField="ShipedQuantity" Display ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left"  />
            </telerik:GridBoundColumn>
            
            <telerik:GridBoundColumn HeaderText="Style No" DataField="StyleNo" Display ="true"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left"  />
            </telerik:GridBoundColumn>
                            
             <telerik:GridBoundColumn HeaderText="Article" DataField="Article" >
           <ItemStyle HorizontalAlign="Left" Width ="50px" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn> 

             <telerik:GridBoundColumn HeaderText="Color" DataField="Colorway" >
           <ItemStyle HorizontalAlign="Left" Width ="50px" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn> 
               <telerik:GridBoundColumn HeaderText="Quantity" DataField="Quantity" >
           <ItemStyle HorizontalAlign="Left" Width ="50px" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn> 
             <telerik:GridBoundColumn HeaderText="FOB Price" DataField="FOBPrice" >
           <ItemStyle HorizontalAlign="Left" Width ="50px" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
            
            <telerik:GridBoundColumn HeaderText="Del Date" DataField="ShipmentDate" >
           <ItemStyle HorizontalAlign="Left" Width ="50px" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>  

            <telerik:GridTemplateColumn HeaderText="B2b Status" >
            <ItemTemplate>
                 <telerik:RadTextBox ID="txtB2BStatus"    width="60"  Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
             </ItemTemplate>
             </telerik:GridTemplateColumn>

              <telerik:GridTemplateColumn HeaderText="SMC Account Status" >
            <ItemTemplate>
             <telerik:RadComboBox ID="CmbSMCType" Runat="server" AutoPostBack="True" 
                    Skin="WebBlue" Width="60px">
                    <Items>
                    <telerik:RadComboBoxItem  Text="%" Value="0" />
                        <telerik:RadComboBoxItem  Text="Cent" Value="1" />
                    </Items>
              </telerik:RadComboBox>
                 <telerik:RadNumericTextBox ID="txtSMCPercentage" width="40"  Runat="server"  
                     AutoPostBack="true"   Skin="WebBlue" ontextchanged="txtSMCPercentage_TextChanged">
                <NumberFormat  decimaldigits="2" ></NumberFormat>
                </telerik:RadNumericTextBox>
                
             </ItemTemplate>
             </telerik:GridTemplateColumn>
              
                <telerik:GridBoundColumn HeaderText="PO Status" DataField="POStatus" >
           <ItemStyle HorizontalAlign="Left" Width ="50px" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>

             <telerik:GridBoundColumn HeaderText="Turn over / USD" DataField="TurnoverUSD" >
           <ItemStyle HorizontalAlign="Left" Width ="50px" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>  
              
              <telerik:GridTemplateColumn HeaderText="SMC/USD" >
            <ItemTemplate>            
                 <telerik:RadNumericTextBox ID="txtSMCUSD"    width="60"  Runat="server" Skin="WebBlue">
                  <NumberFormat  decimaldigits="2"></NumberFormat>
                </telerik:RadNumericTextBox>
             </ItemTemplate>
             </telerik:GridTemplateColumn>
            </Columns>
              <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                            <PagerStyle PageSizeControlType="RadComboBox" AlwaysVisible="true">
                            </PagerStyle>
            </MasterTableView>
            <ClientSettings EnableRowHoverStyle="false" EnablePostBackOnRowClick="false">
<Selecting AllowRowSelect="false" EnableDragToSelectRows="false" />
 <Selecting AllowRowSelect="True" />
 </ClientSettings>
    <HeaderStyle Font-Names="Microsoft Sans Serif" />
 <ItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" Wrap="False" />
            </telerik:RadGrid>
             </td>
 </tr>
 </table>
    </div>
   </asp:Content> 