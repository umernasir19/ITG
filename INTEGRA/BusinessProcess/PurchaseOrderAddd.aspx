<%@ Page Language="vb" MasterPageFile="~/MasterPage.master"  AutoEventWireup="false" CodeBehind="PurchaseOrderAddd.aspx.vb" Inherits="Integra.PurchaseOrderAddd"  %>
 <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
  
  
    
       <div>
    <table style="width: 100%;">
          <%--'-------Heading Row--------'--%>
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;" 
              visible="true";>
        
            <th colspan ="5" align="left"   style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080;" > Purchase Order Information</th>
               <th  align="right" style="font-family: Arial; font-size: 16PX; font-weight: bold;">
                <asp:Label ID="lblPOTypeHeading" runat="server" Text="PO Type:" ></asp:Label>
                <asp:Label ID="lblPOType" runat="server" ></asp:Label>
                 <asp:Label ID="Label2" runat="server"  Text="" ></asp:Label>
                           </th>  
        </tr>
      
        <tr>
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblPONO" runat="server" Text="PO Number"></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
              <telerik:RadTextBox ID="txtPONO" Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>

            </td>
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblPlacementdate" runat="server" Text="Placement Date"></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadDatePicker ID="txtPlacementdate" runat="server" Culture="en-US">
<Calendar runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>

<DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>


            </td>
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblShipmentDate" runat="server" Text="Shipment Date"></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
            
              <telerik:RadDatePicker ID="txtShipmentdatee" runat="server" Culture="en-US">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" runat="server"></Calendar>

<DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" runat="server"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
              </telerik:RadDatePicker>

              
              </td>
            
        </tr>
        <tr>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="lblCustomerName" runat="server" Text="Customer"></asp:Label>
            </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                    <telerik:RadComboBox ID="cmbCustomer" Runat="server" AutoPostBack="True" 
                    Skin="WebBlue">
                </telerik:RadComboBox>
                </ContentTemplate>
                 </asp:UpdatePanel>
                </td> 
                 
            <td style="height: 30px; width: 85px;">
                <asp:Label ID="lblBuyingDpt" runat="server" Text="Buying Dept."></asp:Label>
            </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                <telerik:RadTextBox ID="txtEKNumber" Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
            </td>
            <td style="height: 30px; width: 87px;">
                <asp:Label ID="lblCommission" runat="server" Text="Commission"></asp:Label>
            </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
             <%--   <telerik:RadTextBox ID="txtCommission" Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>--%>

                <telerik:RadNumericTextBox ID="txtCommission" runat="server" Skin="WebBlue">
                <NumberFormat ZeroPattern="n" decimaldigits="2"></NumberFormat>
                </telerik:RadNumericTextBox>


            </td>
        </tr>
          <tr>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="lblSupplier" runat="server" Text="Supplier"></asp:Label>
            </td>
           <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
             <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                    <telerik:RadComboBox ID="cmbSupplier" Runat="server" AutoPostBack="True" 
                    Skin="WebBlue">
                </telerik:RadComboBox>
                   </ContentTemplate>
                 </asp:UpdatePanel>
                
                </td> 
            <td style="height: 30px; width: 85px;">
       
   <asp:Label ID="lblLKZ" runat="server" Text="LKZ No." ></asp:Label>
                <%--'-------Heading Row--------'--%>
            </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                 <asp:UpdatePanel ID="updLKZNo" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                <telerik:RadTextBox ID="txtLKZNo" Runat="server" Skin="WebBlue" ReadOnly="True">
                </telerik:RadTextBox>
                     </ContentTemplate>
                 </asp:UpdatePanel>
            </td>
            <td style="height: 30px; width: 87px;">
                <asp:Label ID="lblMerchant" runat="server" Text="Merchant"></asp:Label>
            </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
              <asp:UpdatePanel ID="UpdatePanel3" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                    <telerik:RadComboBox ID="cmbMerchant" Runat="server" AutoPostBack="True" 
                    Skin="WebBlue">
                </telerik:RadComboBox>
                 </ContentTemplate>
                 </asp:UpdatePanel>
            </td>
        </tr>
          <%--  <asp:Label ID="lblExchangeRate" runat="server" Text="Exchange Rate"></asp:Label>--%>
        <tr  style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin; z-index: auto;" 
              visible="true";>
            <th colspan="6" align="left"  style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080;" >Product Information</th>
        </tr>
       <tr>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="lblSeason" runat="server" Text="Season"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtSeason" Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
            </td>
            <td style="height: 30px; width: 85px;">
                <asp:Label ID="lbltolerance" runat="server" Text="Tolerance(+/-) %"></asp:Label>
            </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                <telerik:RadTextBox ID="txtTolerance" Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
            </td>
             <td style="height: 30px; width: 85px;">
                <asp:Label ID="Label1" runat="server" Text="Composition"></asp:Label>
            </td>
            <td>
             <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
              <telerik:RadComboBox ID="cmbComposition" Runat="server" AutoPostBack="True" Skin="WebBlue">
              <Items>
              <telerik:RadComboBoxItem Value="0" Text="CMIA" />
              <telerik:RadComboBoxItem Value="1" Text="Oragnic" />
              <telerik:RadComboBoxItem Value="2" Text="100 % Cotton" />
              <telerik:RadComboBoxItem Value="3" Text="Cotton Polyester" />
              <telerik:RadComboBoxItem Value="4" Text="Polystic Cotton" />
              <telerik:RadComboBoxItem Value="5" Text="Tensil" />
              <telerik:RadComboBoxItem Value="6" Text="Bambu" />
              <telerik:RadComboBoxItem Value="7" Text="Micro Fibric" />
              <telerik:RadComboBoxItem Value="8" Text="Viscos-Cotton" />
              <telerik:RadComboBoxItem Value="9" Text="Viscos-Polyester" />
              <telerik:RadComboBoxItem Value="10" Text="Viscos-Elasthane" />
              <telerik:RadComboBoxItem Value="11" Text="100 % Polyester" />
              <telerik:RadComboBoxItem Value="12" Text="Leather-Cow/Buffalo" />
              <telerik:RadComboBoxItem Value="13" Text="Leather-Sheep" />
              <telerik:RadComboBoxItem Value="14" Text="Others" />
               </Items>
                </telerik:RadComboBox> 
                     </ContentTemplate>
                 </asp:UpdatePanel>           
            </td>             
        </tr>
         <tr>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="lblProductPortfolio" runat="server" Text="Product Portfolio"></asp:Label>
            </td>
              <td class="TopHeaderTd3" style="width: 165px; height: 30px;"> 
              <asp:UpdatePanel ID="updProductGroup" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                    <telerik:RadComboBox ID="cmbProductGroup" Runat="server" AutoPostBack="True" 
                    Skin="WebBlue">
                </telerik:RadComboBox>
                </ContentTemplate>
                 </asp:UpdatePanel>
                </td> 
            <td style="height: 30px; width: 85px;">
                <asp:Label ID="lblProductCategory" runat="server" Text="Product Category"></asp:Label>
            </td>
             <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
            <asp:UpdatePanel ID="updProductCategroy" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                    <telerik:RadComboBox ID="cmbProductCategroy" Runat="server" AutoPostBack="True" 
                    Skin="WebBlue">
                </telerik:RadComboBox>
                 </ContentTemplate>
                 </asp:UpdatePanel>
              
                </td> 
            <td style="height: 30px; width: 87px;">
                <asp:Label ID="lblProductGroup" runat="server" Text="Product Group"></asp:Label>
            </td>
             <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
               <asp:UpdatePanel ID="UpdatePanel5" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                    <telerik:RadComboBox ID="cmbDesign" Runat="server" AutoPostBack="True" 
                    Skin="WebBlue">
                </telerik:RadComboBox>
                   </ContentTemplate>
                 </asp:UpdatePanel>
                </td> 
        </tr>
        <tr>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="lblBlend" runat="server" Text="Blend"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtBlend" Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
            </td>
            <td style="height: 30px; width: 85px;">
                <asp:Label ID="lblGSM" runat="server" Text="GSM"></asp:Label>
            </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                <telerik:RadTextBox ID="txtGSM" Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
            </td>
            <td style="height: 30px; width: 87px;">
                <asp:Label ID="lblProcessType" runat="server" Text="Process Type"></asp:Label>
            </td>
           <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
             <asp:UpdatePanel ID="UpdatePanel6" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                    <telerik:RadComboBox ID="cmbProcessType" Runat="server" AutoPostBack="True" 
                    Skin="WebBlue">
                </telerik:RadComboBox>
                     </ContentTemplate>
                 </asp:UpdatePanel>
                </td> 
        </tr>
           <tr>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="Label3" runat="server" Text="Status"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
          <asp:UpdatePanel ID="upcmbStatus" UpdateMode="Conditional" runat="server">
           <ContentTemplate>
           <telerik:RadComboBox ID="cmbStatus" Runat="server" AutoPostBack="True" Skin="WebBlue">
           <Items>
           <telerik:RadComboBoxItem Value="0" Text="Booked" />
           <telerik:RadComboBoxItem Value="1" Text="Shipped" />
           <telerik:RadComboBoxItem Value="2" Text="Close" />
           <telerik:RadComboBoxItem Value="3" Text="Cancel" />
           </Items>
           </telerik:RadComboBox>
            </ContentTemplate>
            </asp:UpdatePanel>
            </td>
          
        </tr>
          <%--'-------Heading Row--------'--%>
        <tr  style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin; z-index: auto;" 
              visible="true";>
        
            <th colspan ="5" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080;" > Product Specific&nbsp; Information</th>
                
        <th align="right" style="font-family: 'Times New Roman', Times, serif; font-size: 12px; font-weight: bold; font-style: inherit; color:Black; font-variant: inherit; padding-right:20px;">
              <asp:UpdatePanel ID="upAddMore" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
              <telerik:RadButton ID="btnAddMore" runat="server" Text="Add More" Skin="WebBlue"  >
                      </telerik:RadButton>
                      </ContentTemplate>
                 </asp:UpdatePanel>
                  <asp:UpdatePanel ID="upShowData" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                     <telerik:RadButton ID="btnShowData" runat="server" Text="Show" Skin="WebBlue">
                    </telerik:RadButton>
                      </ContentTemplate>
                 </asp:UpdatePanel>
              </th>             
              
        </tr>
            <tr>
        <td colspan="6">
           <asp:UpdatePanel ID="updgPurchaseOrder" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
         <telerik:RadGrid ID="dgPurchaseOrder" runat="server" CellSpacing="0" 
                AutoGenerateColumns="false"  Skin="WebBlue"  
                Visible="False" PageSize="50" OnDeleteCommand="dgPurchaseOrder_DeleteCommand">
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
            
            <telerik:GridBoundColumn HeaderText="PODetailID" DataField="PurchaseOrderDetailID" >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>      
             <telerik:GridBoundColumn HeaderText="StyleID" DataField="StyleID" >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>   
            <telerik:GridBoundColumn HeaderText="Style" DataField="Style">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
               <telerik:GridBoundColumn HeaderText="Article No" DataField="Article">
            <HeaderStyle Width="15%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>   
            <telerik:GridBoundColumn HeaderText="Article Description" DataField="ArticleDescription" >
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>                   
            <telerik:GridBoundColumn HeaderText="Colorway" DataField="Color">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Size" DataField="Size">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
               <telerik:GridTemplateColumn HeaderText="Item Price" >
            <ItemTemplate>
                  <telerik:RadTextBox ID="txtRate" width="60"  Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
            </ItemTemplate>
             </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn HeaderText="PO Quantity" >
            <ItemTemplate>
            <%--      <telerik:RadTextBox ID="txtQuantity" width="60"  Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>--%>
                <telerik:RadNumericTextBox ID="txtQuantity" width="60"  Runat="server" Skin="WebBlue">
                <NumberFormat ZeroPattern="n" decimaldigits="0"></NumberFormat>
                </telerik:RadNumericTextBox>
                
            </ItemTemplate>
             </telerik:GridTemplateColumn>
                   <telerik:GridTemplateColumn HeaderText="Value" >
            <ItemTemplate>
                  <telerik:RadTextBox ID="txtAmount" ReadOnly="true"  width="60"  Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>

            </ItemTemplate>
             </telerik:GridTemplateColumn>
                 
           
           <telerik:GridButtonColumn UniqueName="DeleteColumn" Text="" CommandName="Delete"  ConfirmTextFormatString="Are You Sure You want to Delete Record" HeaderStyle-Width="35px" ButtonType="ImageButton"></telerik:GridButtonColumn>
            
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
          </ContentTemplate>
                 </asp:UpdatePanel>
        </td>
        </tr>
          <tr>
            <td style="height: 30px; width: 128px;">
                <asp:TextBox ID="txtPORefNo"  Visible="false" runat="server" width="22"  ></asp:TextBox>
            </td>
            <td style="width: 166px; height: 30px;">
                Total Qty :  
                    <asp:UpdatePanel ID="upTxtTotalQty" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                <asp:TextBox ID="TxtTotalQty" BackColor="#80BFFF" CssClass="textbox"  ReadOnly="true" runat="server" width="60"  ></asp:TextBox>
                  </ContentTemplate>
                 </asp:UpdatePanel>
            </td>
            <td style="height: 30px; width: 85px;">
              
            </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
               Total Value:
                  <asp:UpdatePanel ID="uptxtTotalAmount" UpdateMode="Conditional" runat="server">
               <ContentTemplate>  
               <asp:TextBox ID="txtTotalAmount" BackColor="#80BFFF" CssClass="textbox" ReadOnly="true"  runat="server" width="60"  ></asp:TextBox> 
                 </ContentTemplate>
                 </asp:UpdatePanel>
            </td>
             <td style="height: 30px; width: 85px;">
               
            </td>
            <td align="right">
             <asp:UpdatePanel ID="upbtnCalculate" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
              <telerik:RadButton ID="btnCalculate" runat="server" ToolTip="Press To Calculate Value" Text="Calculate" Skin="WebBlue">
                    </telerik:RadButton>  
                       </ContentTemplate>
                 </asp:UpdatePanel>
            </td>             
        </tr>
 
          <%-- <AjaxSettings>
    <telerik:AjaxSetting AjaxControlID="btnAddNew">
    <UpdatedControls>
    <telerik:AjaxUpdatedControl ControlID="dgBuyerDetail" />
    </UpdatedControls>
    </telerik:AjaxSetting>
    </AjaxSettings>
   
    <AjaxSettings>
    <telerik:AjaxSetting AjaxControlID="dgBuyerDetail">
    <UpdatedControls>
    <telerik:AjaxUpdatedControl ControlID="dgBuyerDetail" LoadingPanelID="RadAjaxLoadingPanel1" />
    </UpdatedControls>
    </telerik:AjaxSetting>
    </AjaxSettings>--%>
        <tr  style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin; z-index: auto;" 
              visible="true";>
            <th colspan="6" align="left"  style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080;" >Shipping And Payment Terms</th>
        </tr>
              <tr>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="lblShipmentMode" runat="server" Text="Shipment Mode"></asp:Label>
            </td>
              <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                  <asp:UpdatePanel ID="UpdatePanel7" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                    <telerik:RadComboBox ID="cmbShipmentMode" Runat="server" AutoPostBack="True" 
                    Skin="WebBlue">
                </telerik:RadComboBox>
                     </ContentTemplate>
                 </asp:UpdatePanel>
                </td> 
            <td style="height: 30px; width: 85px;">
                <asp:Label ID="lblShippingTerm" runat="server" Text="Shipping Term"></asp:Label>
            </td>
             <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                 <asp:UpdatePanel ID="UpdatePanel8" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                    <telerik:RadComboBox ID="cmbShippingTerm" Runat="server" AutoPostBack="True" 
                    Skin="WebBlue">
                </telerik:RadComboBox>
                      </ContentTemplate>
                 </asp:UpdatePanel>
                </td> 
            <td style="height: 30px; width: 87px;">
                <asp:Label ID="lblDeliveryTerm" runat="server" Text="Delivery Term"></asp:Label>
            </td>
             <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
               <asp:UpdatePanel ID="UpdatePanel9" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                    <telerik:RadComboBox ID="cmbDelivertyTerm" Runat="server" AutoPostBack="True" 
                    Skin="WebBlue">
                </telerik:RadComboBox>
                       </ContentTemplate>
                 </asp:UpdatePanel>
                </td> 
        </tr>
        <tr>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="lblDestinations" runat="server" Text="Destination"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtDestination" Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
            </td>
            
             
        </tr>
                <tr>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="lblPaymentTerms" runat="server" Text="Payment Terms"></asp:Label>
            </td>
              <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                    <asp:UpdatePanel ID="UpdatePanel10" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                    <telerik:RadComboBox ID="cmbPaymentTerms" Runat="server" AutoPostBack="True" 
                    Skin="WebBlue">
                </telerik:RadComboBox>
                        </ContentTemplate>
                 </asp:UpdatePanel>
                </td> 
            <td style="height: 30px; width: 85px;">
                <asp:Label ID="lblCurrency" runat="server" Text="Currency"></asp:Label>
            </td>
             <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                <asp:UpdatePanel ID="UpdatePanel11" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                    <telerik:RadComboBox ID="cmbCurrency" Runat="server" AutoPostBack="True" 
                    Skin="WebBlue">
                </telerik:RadComboBox>
                          </ContentTemplate>
                 </asp:UpdatePanel>
                </td> 
            <td style="height: 30px; width: 87px;">
              <%--  <asp:Label ID="lblExchangeRate" runat="server" Text="Exchange Rate"></asp:Label>--%>
                  <asp:UpdatePanel ID="upLnkRate" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                 <asp:LinkButton ID="lnkExchangeRate" runat="server" Text="Exchange Rate" >
                 </asp:LinkButton>
                  </ContentTemplate>
                 </asp:UpdatePanel>
            </td>
             <td style="width: 166px; height: 30px;">
                 <asp:UpdatePanel ID="upBookedExchange" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                <telerik:RadTextBox ID="txtBookedExchangeRate"  BackColor="#80BFFF" Runat="server" Skin="WebBlue" 
                 ReadOnly="true" Width="70">
                </telerik:RadTextBox>

          <asp:ImageButton ID="btnBookedExchangeRate" runat="server" ToolTip="Press This to Show Exchange Rate" BackColor="transparent" ImageUrl="~/Images/redCal.jpg"  />
                      </ContentTemplate>
                 </asp:UpdatePanel>
            </td>
        </tr>
        <%--'-------Heading Row--------'--%>
        <tr  style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin; z-index: auto;" 
              visible="true";>
            <th colspan="6" align="left"  style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080;" ">Reference & Attachment</th>

        </tr>
        <tr>
         <td style="height: 30px; width: 50px;">
                <asp:Label ID="lblOriginalPO" runat="server" Text="Original Purchase Order"></asp:Label>
            </td>
         
         <td colspan="5" style="height: 25px">
                <asp:FileUpload ID="FileUpload1" runat="server" />
              <asp:CustomValidator ID="CustomValidator1"  ForeColor="Red"  runat="server"  ControlToValidate="FileUpload1"
 ClientValidationFunction="ValidateFileUpload" ErrorMessage="Please select valid pdf file"></asp:CustomValidator>
<script language="javascript" type="text/javascript">
    function ValidateFileUpload(Source, args) {
        var fuData = document.getElementById('<%= FileUpload1.ClientID %>');
        var FileUploadPath = fuData.value;
        if (FileUploadPath == '') {
            // There is no file selected 
            args.IsValid = false;
        }
        else {
            var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();

            if (Extension == "pdf") {
                args.IsValid = true; // Valid file type
            }
            else {
                args.IsValid = false; // Not valid file type
            }
        }
    }
</script>
            </td>
        </tr>  
        <tr  style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin; z-index: auto;" 
              visible="true";>
            <th colspan="6" align="left"  style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080;" >Additional Information</th>
        </tr>
        <tr>
            <td style="height: 25px" colspan="6">
                   <asp:CheckBox 
                    ID="ChkTNA" runat="server" Font-Bold="True" 
                       Text="System will create time and action plan for this order. " 
                       Enabled="False" />
                    </td>                     
                   </tr>
                <tr>
                <td style="height: 25px" colspan="6">
                <asp:CheckBox ID="chkMGTPOCopy" runat="server"  Enabled="False"  Font-Bold="True" 
                              Text="1st Copy: MGT" />
                 </td>
                 </tr>
                <tr>
                <td style="height: 25px" colspan="6">
                <asp:CheckBox ID="chkMerchantPOCopy" runat="server"  Enabled="False"  Font-Bold="True" Text="2nd Copy: Merchant" />
                              </td>
                              </tr>
                <tr>
                <td style="height: 25px" colspan="6">
                <asp:CheckBox  ID="chkQDPoCopy" runat="server"  Enabled="False"  Font-Bold="True" Text="3rd Copy: QD" />
            </td>
     
           </tr>                    
       <tr>
       <td colspan="3" align="right"></td>
            <td colspan="2" align="right">
              <telerik:RadButton ID="btnPreview" runat="server" Text="Preview" 
                 Skin="WebBlue"> 
                </telerik:RadButton>&nbsp; &nbsp; &nbsp;
         
                <telerik:RadButton ID="btnSave" runat="server" Text="Save" 
                    Skin="WebBlue">
                </telerik:RadButton>
       
            </td>
                <td>&nbsp;
                <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" 
                 Skin="WebBlue">
                </telerik:RadButton>
             &nbsp;</td>
           </tr>          
     </table>
      <telerik:RadProgressManager ID="RadProgressManager1" runat="server" />
        <telerik:RadProgressArea ID="RadProgressArea1" runat="server" 
           ProgressIndicators="FilesCountBar, FilesCountPercent, TimeElapsed, TimeEstimated" 
           Skin="WebBlue" Height="149px" />  
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
    <AjaxSettings>
    <telerik:AjaxSetting AjaxControlID="cmbCountry">
    <UpdatedControls>
    <telerik:AjaxUpdatedControl ControlID="cmbCity" />
    </UpdatedControls>
    </telerik:AjaxSetting>
    </AjaxSettings>
     </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"/>
    </div>

    <table>
    <tr>
    <td>
      <telerik:RadBarcode runat="server" Visible="false" ID="RadBarcode1" Type="QRCode" Width="371px" Height="371px"
                 OutputType="EmbeddedPNG"   >
      <QRCodeSettings DotSize="0" ECI="None"  Mode="Byte"  ErrorCorrectionLevel="L" Version="7"   />
     </telerik:RadBarcode>
    </td>
    </tr>
     
    </table>
   

</asp:Content>