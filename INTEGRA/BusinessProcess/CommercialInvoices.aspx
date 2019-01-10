<%@ Page Language="vb"    MasterPageFile="~/MasterPage.master"  AutoEventWireup="false" CodeBehind="CommercialInvoices.aspx.vb" Inherits="Integra.CommercialInvoices" %>
  <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <AjaxSettings>
    <telerik:AjaxSetting AjaxControlID="txtETD">
    <UpdatedControls>
    <telerik:AjaxUpdatedControl ControlID="txtETA" />
    </UpdatedControls>
    </telerik:AjaxSetting>
    </AjaxSettings>
    </telerik:RadAjaxManager>
 <div>
 
    <table  >
    
         <tr>
<td>
</td>
<td class="ErrorMsg">
    <asp:Label ID="lblInvoiceMSG" Visible="false" runat="server" ></asp:Label>
</td>
</tr>
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;" 
              visible="true";>
            <th  colspan ="6" align="left"   style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080;"  >Create Commercial Invoice </th>
         </tr>
         <tr>
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblInVoiceNo" runat="server" Text="Invoice No." 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td  style="width: 166px; height: 30px;">
              <telerik:RadTextBox ID="txtInvoiceNo" Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
                   </td>
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblInvoiceDate" runat="server" Text="Invoice Date" 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td class="style2">
                <telerik:RadDatePicker ID="txtInvoiceDate" runat="server" Culture="en-US">
<Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>
 <DateInput  runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>
 <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblShipmentMode" runat="server" Text="Shipment Mode"  Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 128px; height: 30px;">
                  <telerik:RadTextBox ID="txtShippingMode" Runat="server" Skin="WebBlue" 
                      ReadOnly="True" BackColor="#80BFFF">
                </telerik:RadTextBox>
                </td>
         </tr>
        <tr>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="lblCustomerName" runat="server" Text="Customer"  Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 128px; height: 30px;">
              <telerik:RadTextBox ID="txtCustomer" Runat="server" Skin="WebBlue"  
                    ReadOnly="True" BackColor="#80BFFF">
                </telerik:RadTextBox>
                </td> 
                 
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblBuyingDpt" runat="server" Text="Buying Dept."  Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td class="style2">
                <telerik:RadTextBox ID="txtButyingDept" Runat="server" Skin="WebBlue"  
                    ReadOnly="True" BackColor="#80BFFF">
                </telerik:RadTextBox>
            </td>
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblShippingTerm" runat="server" Text="Shipping Term"  Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td  style="width: 128px; height: 30px;">
               <telerik:RadTextBox ID="txtShippingTerm" Runat="server" Skin="WebBlue"  
                    ReadOnly="True" BackColor="#80BFFF">
                </telerik:RadTextBox>
             
                   </td>
        </tr>
        <%--'----Heading-----'--%>
         <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;" 
              visible="true";>
            <th  colspan ="6" align="left"   style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080;"  >Shipping Detail</th>
        </tr>
          <tr>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="lblBLAWBNo" runat="server" Text="BL/AWB No."  Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
           <td  style="width: 128px; height: 30px;">
                  <telerik:RadTextBox ID="txtBLAWBNo" Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
                                          
                </td> 
            <td style="width: 128px; height: 30px;">
       
   <asp:Label ID="lblMAWB" runat="server" Text="MAWB"  Font-Names="Calibri" Font-Size="Medium" ></asp:Label>
               </td>
            <td class="style2">
               
                <telerik:RadTextBox ID="txtMAWB" Runat="server" Skin="WebBlue" ReadOnly="false">
                </telerik:RadTextBox>
                       </td>
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblForwarder" runat="server" Text="Forwarder"  Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 128px; height: 30px;">
              <telerik:RadTextBox ID="txtForwarder" Runat="server" Skin="WebBlue" ReadOnly="false">
                </telerik:RadTextBox>
                  </td>
        </tr>
          <%--  <asp:Label ID="lblExchangeRate" runat="server" Text="Exchange Rate"></asp:Label>--%>
       
       <tr>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="ibiContainerSize" runat="server" Text="Container Size"  Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 128px; height: 30px;">
                <telerik:RadTextBox ID="txtContainerSize" Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
            </td>
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblConsolidation" runat="server" Text="Consolidation"  Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td class="style2">
                <telerik:RadTextBox ID="txtConsolidation" Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
            </td>
             <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblContainerNo" runat="server" Text="Container No."  Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
             <td style="width: 128px; height: 30px;">
                <telerik:RadTextBox ID="txtContainerNo" Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
            </td>             
        </tr>
         <tr>
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="Label1" runat="server" Text="Form-E Date"  Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 128px; height: 30px;">
                <telerik:RadDatePicker ID="txtCargoDate" runat="server" Culture="en-US">
<Calendar ID="Calendar2" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>

<DateInput  DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
                </td>
             <td style="width: 128px; height: 30px;">
                <asp:Label ID="Label2" runat="server" Text="ETD"  Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td class="style2">
                <telerik:RadDatePicker ID="txtETD" runat="server" Culture="en-US" AutoPostBack="true">
<Calendar ID="Calendar3" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>

<DateInput  DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
                 </td>
             <td style="width: 128px; height: 30px;">
                <asp:Label ID="Label3" runat="server" Text="ETA"  Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 128px; height: 30px;">
                <telerik:RadDatePicker ID="txtETA" runat="server" Culture="en-US">
<Calendar ID="Calendar4" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>

<DateInput runat="server"  DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
        </tr>
       <tr>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="lblCarrierName" runat="server" Text="Carrier Name"  Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 128px; height: 30px;">
                <telerik:RadTextBox ID="txtCarrierName" Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
            </td>
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblVoyageFlight" runat="server" Text="Voyage/Flight"  Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td class="style2">
                <telerik:RadTextBox ID="txtVoyageFlight" Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
            </td>
             <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblPODPOA" runat="server" Text="POD-POA"  Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
             <td  style="width: 128px; height: 30px;">
            <telerik:RadTextBox ID="txtPODPOA" Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
              
                   </td>             
        </tr>
          <%--'-------Heading Row--------'--%>
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin; height: 30px;" 
              visible="true";>
        
            <th  colspan ="5" align="left"   style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080;"  > Product Specific Information</th>
                
        <th align="right" style="font-family: 'Times New Roman', Times, serif; font-size: 12px; font-weight: bold; font-style: inherit; color:Black; font-variant: inherit; padding-right:20px;">
               <asp:UpdatePanel ID="upAddMore" UpdateMode="Conditional" runat="server">
                 <ContentTemplate>
                  <telerik:RadButton ID="btnAddMore" runat="server" Text="Add More..." Skin="WebBlue">
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
                Visible="False" PageSize="50" Width="100%">
            <MasterTableView>
            <Columns>
              <telerik:GridBoundColumn HeaderText="CommercialInvoiceDetailID" DataField="CommercialInvoiceDetailID" Display="false" >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
               <telerik:GridBoundColumn HeaderText="POID" DataField="POID" Display="false" >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn> 
            <telerik:GridBoundColumn HeaderText="PODetailID" DataField="PODetailID"  Display="false" >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>      
               <telerik:GridBoundColumn HeaderText="Style" DataField="Style">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
             <telerik:GridBoundColumn HeaderText="PO No." DataField="PONO">
            <HeaderStyle Width="7%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>
               <telerik:GridBoundColumn HeaderText="Article No." DataField="Article">
            <HeaderStyle Width="10%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>   
             <telerik:GridBoundColumn HeaderText="Size" DataField="Size">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Colorway" DataField="Color">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>
             <telerik:GridBoundColumn HeaderText="Booked Qty" DataField="Quantity">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
               <telerik:GridTemplateColumn HeaderText="Item Price" >
            <ItemTemplate>
                  <telerik:RadTextBox ID="txtRate" width="60"  Runat="server" Skin="WebBlue" ReadOnly="true"  >
                </telerik:RadTextBox>
            </ItemTemplate>
             </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn HeaderText="Quantity" >
            <ItemTemplate>
            <%--      <telerik:RadTextBox ID="txtQuantity" width="60"  Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>--%>
                <telerik:RadNumericTextBox ID="txtQuantity" width="60"  Runat="server" Skin="WebBlue" >
                <NumberFormat ZeroPattern="n" decimaldigits="0"></NumberFormat>
                </telerik:RadNumericTextBox>
                
            </ItemTemplate>
             </telerik:GridTemplateColumn>
             <telerik:GridTemplateColumn HeaderText="UOM" >
            <ItemTemplate>
                  <telerik:RadTextBox ID="txtUOM" width="60"  Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
            </ItemTemplate>
             </telerik:GridTemplateColumn>
                   <telerik:GridTemplateColumn HeaderText="Value" >
            <ItemTemplate>
                  <telerik:RadTextBox ID="txtAmount" ReadOnly="true"  width="60"  Runat="server" Skin="WebBlue" >
                </telerik:RadTextBox>

            </ItemTemplate>
             </telerik:GridTemplateColumn>
            <telerik:GridClientDeleteColumn ConfirmTextFields="StyleNo" ConfirmTextFormatString="Are You Sure You want to Delete Details for Style {0}?" HeaderStyle-Width="35px" ButtonType="ImageButton">
            </telerik:GridClientDeleteColumn>

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
        </table>

    <table  >
          <tr> 
              <td align ="right"  style="height: 30px; width: 500px;">
                     <telerik:RadTextBox ID="txtCurrency" Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
            </td>
            <td align ="right"  style="height: 30px; width: 180px; font-family: Calibri;">Total Qty:
                 <asp:UpdatePanel ID="upTxtTotalQty" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                <asp:TextBox ID="txttotalQTY" BackColor="#80BFFF" ReadOnly="true" runat="server" width="75px"  ></asp:TextBox>
           </ContentTemplate>
           </asp:UpdatePanel>

            </td>           
                       
            <td  colspan ="6" align ="center"  style="width: 170px; height: 30px;font-family: Calibri;">
                     Total Value:</td>
                     <td align ="right">

                      <asp:Label ID="lblCurrency" runat="server" Text=""></asp:Label>
                           <asp:UpdatePanel ID="uptxtTotalAmount" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
             <asp:TextBox ID="txtTotalAmount" BackColor="#80BFFF" ReadOnly="true"  runat="server" 
                      width="70px"></asp:TextBox> 
        </ContentTemplate>
           </asp:UpdatePanel>
                      </td>
                      
                       
        </tr>
           </table> 
           <table >
    <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin; z-index: auto;" 
              visible="true";>
         
            <th colspan ="6" align="left" 
                style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080; font-family: Calibri;height: 30px; width: 268435648px;">Comments</th>
          
            <th align="right" 
                style="font-family: 'Times New Roman', Times, serif; font-size: 12px; font-weight: bold; font-style: inherit; color:Black; font-variant: inherit; padding-right:20px; height: 30px;">
             <asp:UpdatePanel ID="upbtnCalculate" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                <telerik:RadButton ID="btnCalculate" runat="server" ToolTip="Press To Calculate Value" Text="Calculate" Skin="WebBlue" Width ="60px">
                    </telerik:RadButton>  
           </ContentTemplate>
           </asp:UpdatePanel>
              </th>                
              </tr> 
                </table> 

    <table >        
           <tr>
            
            <telerik:RadTextBox ID="txtComments" Runat="server" Skin="WebBlue" 
                   TextMode ="MultiLine" Width ="650px" Height ="40px" >
                </telerik:RadTextBox>
           
        </tr>
    
     </table>
     <table >
     <tr>
     <td valign ="middle"  style="width: 650px; height: 57px;"></td>
     <td valign ="middle" style="width: 60px; height: 57px;">
     <telerik:RadButton ID="btnSave" runat="server" Text="Save " Skin="WebBlue">
                    </telerik:RadButton>
     </td>
     <td valign ="middle" style="width: 60px; height: 57px;">
     <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" Skin="WebBlue">
                    </telerik:RadButton>
     </td>
     <td valign ="middle" style="width: 60px; height: 57px;">
     
     </td>
     </tr>
     <tr><td>
     
 
     </td></tr>
   </table> 
      </div> 
</asp:Content> 
   
