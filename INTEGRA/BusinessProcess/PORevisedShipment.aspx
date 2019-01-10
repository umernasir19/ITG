<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PORevisedShipment.aspx.vb" Inherits="Integra.PORevisedShipment" %>
  <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PO Revised Shipment Date</title>
   <link href= "../App_Themes/Blue/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <div>
    <table style="width: 100%;">
          <%--'-------Heading Row--------'--%>
           <tr style="height:30px;">
          <td valign ="top" >
          <table>
       <tr  style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #00509F;" 
                  visible="true";>
        <td><asp:Label ID="lblPONOHeading" runat="server" Text="PO No. "></asp:Label><asp:Label ID="lblPONO" runat="server"  ></asp:Label>/<asp:Label ID="lblProductPortfolio" runat="server"  ></asp:Label>/<asp:Label ID="lblProductCategories" runat="server" ></asp:Label> </td>
       </tr>
         </table>
         </td>    
         <td valign ="top" >
       <table>
       <tr>
        <td> 
            </td>
        </tr>
         </table>
         </td>         
          </tr>
          <%--Main Table Rows and Column--%>
          <tr style="height :70px;">
          <td style="width: 503px" valign="middle" >
         <table>
       <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"  visible="true";>
        <th colspan ="5" align="left"   style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080;" > Purchase Order Detail</th>
        </tr>
         </table>
         </td>
         <td valign="middle" >
        <table>
          <tr  style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"  visible="true";>
          <th colspan ="5" align="left"   style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080;" > Buyer Information</th>
        </tr>     
            </table>
       </td>
          </tr>
          <tr>
    <td style="width: 503px">
    <table>
    <tr>
     <td style="width: 38px"></td>
    </tr>
    <tr>
     <td style="width: 38px"></td>
    </tr>
    <tr>
    <td style="width: 38px"></td>
    <td style="width: 153px; height :20px; font-family: Calibri; font-size: 14px; font-weight: bold; color: #808080;"    
            align="right"> Season Name </td>
            <td  style="width: 10px">    
            </td>
    <td style="width: 280px;">
                <asp:Label ID="lblSeason" CssClass="labelNew" runat="server" Text=""></asp:Label>
            </td>
    </tr>
        <tr>
        <td style="width: 38px"></td>
    <td style="width: 153px; height :20px; font-family: Calibri; font-size: 14px; font-weight: bold; color: #808080;"     
                align="right">Order Type </td>  <td  style="width: 10px">    
            </td>
    <td style="width: 280px; height :20px;">
                <asp:Label ID="lblOrderType" CssClass="labelNew" runat="server" Text=""></asp:Label>
                            </td>
    </tr>
  <%--      <tr>
        <td style="width: 38px"></td>
    <td style="width: 153px; height :20px; font-family: Calibri; font-size: 14px; font-weight: bold; color: #808080;"     
                align="right" valign ="top" >Brief Order Description</td>   <td  style="width: 10px">    
            </td>
        <td style="width: 280px; height: 54px;">
                <asp:Label ID="lblBriefOrderDescription" CssClass="labelNew" runat="server" Text=""></asp:Label>
            </td>
    </tr>--%>
      <tr>
        <td style="width: 38px"></td>
    <td style="width: 153px; height :20px; font-family: Calibri; font-size: 14px; font-weight: bold; color: #808080;"      
              align="right" >Order Placement Date</td>   <td  style="width: 10px">    
            </td>
        <td style="width: 280px; height: 20px;">
                <asp:Label ID="lblPlacementDate" CssClass="labelNew" runat="server" Text=""></asp:Label>
            </td>
    </tr>
    <tr>
        <td style="width: 38px"></td>
    <td style="width: 153px; height :20px; font-family: Calibri; font-size: 14px; font-weight: bold; color: #808080;"     
            align="right" >Shipment Date</td>   <td  style="width: 10px">    
            </td>
        <td style="width: 280px; height: 20px;">
                <asp:Label ID="lblShipmentDate" CssClass="labelNew" runat="server" Text=""></asp:Label>
            </td>
    </tr>
    <tr>
        <td style="width: 38px"></td>
    <td style="width: 153px; height :20px; font-family: Calibri; font-size: 14px; font-weight: bold; color: #808080;"     
            align="right" >Lead Time Margin</td>   <td  style="width: 10px">    
            </td>
        <td style="width: 280px; height: 20px;">
                <asp:Label ID="lblLeadTimeMargin" CssClass="labelNew" runat="server" Text=""></asp:Label>
            </td>
    </tr>
      <tr>
        <td style="width: 38px"></td>
    <td style="width: 153px; height :20px; font-family: Calibri; font-size: 14px; font-weight: bold; color: #808080;"    
              align="right" >Transaction should be in</td>   <td  style="width: 10px">    
            </td>
        <td style="width: 280px; height: 20px;">
                <asp:Label ID="lblTransactionshouldbein" CssClass="labelNew" runat="server" Text=""></asp:Label>
            </td>
    </tr>
    <tr>
        <td style="width: 38px"></td>
    <td style="width: 153px; height :20px; font-family: Calibri; font-size: 14px; font-weight: bold; color: #808080;"  
            align="right" >Tolerance</td>   <td  style="width: 10px">    
            </td>
        <td style="width: 280px; height: 20px;">
                <asp:Label ID="lblTolerance" CssClass="labelNew" runat="server" Text=""></asp:Label>
            </td>
    </tr>
      
      <tr>
        <td style="width: 38px"></td>
    <td style="width: 153px; height :20px; font-family: Calibri; font-size: 14px; font-weight: bold; color: #FF0000;"  
            align="right" >Revised Shipment Date</td>   <td  style="width: 10px">    
            </td>
        <td style="width: 280px; height: 20px;">
             
    <telerik:RadDatePicker ID="txtRevisedShipment" runat="server" Culture="en-US" >
<Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>
<DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" runat="server" DateFormat="dd/MM/yyyy"  ></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
                   <asp:Label ID="lblMMsg" CssClass="ErrorMsg" runat="server"  ></asp:Label>
            </td>
    </tr>
      <tr>
        <td style="width: 38px"></td>
    <td style="width: 153px; height :20px; font-family: Calibri; font-size: 14px; font-weight: bold; color: #808080;"  
            align="right" > </td>   <td  style="width: 10px">    
            </td>
        <td style="width: 280px; height: 20px;">
               <telerik:RadButton ID="btnUpdateRevisedShipmentDate" runat="server" Text="Update" Skin="WebBlue">
                    </telerik:RadButton>

            </td>
    </tr>
      <tr>
        <td style="width: 38px"></td>
    <td style="width: 153px; height :20px; font-family: Calibri; font-size: 14px; font-weight: bold; color: #808080;"  
            align="right" > </td>   <td  style="width: 10px">    
            </td>
        <td style="width: 280px; height: 20px;">
                <asp:Label ID="lblRevsedShipmentDate" CssClass="ErrorMsg" runat="server"  ></asp:Label>

            </td>
    </tr>
    </table>
    </td>
     <td valign ="top" >
    <table>
    <tr>
     <td> <asp:Label ID="lblMr" CssClass="labelNew" runat="server" Text="Mr."></asp:Label></td>
    </tr>
    <tr>
    <td>
          <asp:Label ID="lblEknumber" CssClass="labelNew" runat="server" ></asp:Label>
            </td>
    </tr>
    <tr>
     <td> <asp:Label ID="lblCustomer" CssClass="labelNew" runat="server"  ></asp:Label></td>
    </tr>
    <tr  style="height :40px;"><td></td></tr>
    
    </table>
     <table>
      
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"  visible="true";>
        <th colspan ="5" align="left"   style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080;" >Supplier Information</th>
      
        </tr>
         </table>
          <table>
    <tr>
     <td>   </td>
    </tr>
    <tr>
     <td> <asp:Label ID="lblSupplier" runat="server" CssClass="labelNew"></asp:Label></td>
    </tr>
    <tr>
    <td>
          <asp:Label ID="lblSupplierDesignation" runat="server" CssClass="labelNew"></asp:Label>
            </td>
    </tr>
    <tr>
     <td> <asp:Label ID="lblShortname" runat="server" CssClass="labelNew"></asp:Label></td>
    </tr>
   <tr>
     <td> <asp:Label ID="lblLKZNo" runat="server" CssClass="labelNew"></asp:Label></td>
    </tr>
    <tr>
     <td>   </td>
    </tr>
    </table>
     <table>
      
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"  visible="true";>
        <th colspan ="5" align="left"   style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080;" > Merchandiser Information</th>
      
        </tr>
         </table>
        <table>
    <tr>
     <td>   </td>
    </tr>
    <tr>
     <td> <asp:Label ID="lblMerchant" runat="server" CssClass="labelNew"></asp:Label></td>
    </tr>
    <tr>
    <td>
          <asp:Label ID="lblMerchantDesignation" runat="server" CssClass="labelNew"></asp:Label>
            </td>
    </tr>
    <tr>
     <td> <asp:Label ID="lblECPDivision" runat="server" CssClass="labelNew"></asp:Label></td>
    </tr>  
    
    </table>
    </td>
    </tr>
   <tr style="height :50px; border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"  visible="true";>
   <td valign="middle">
    <table>      
        <tr>
        <th colspan ="5" align="left"   style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080;"> Items to be sourced</th>
         </tr>
         </table>
   </td>
    <td valign="middle">
        <table>
          <tr  >
          <th colspan ="5" align="left"   style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080;" ></th>
        </tr>     
            </table>
       </td>
   </tr>
            <tr>
        <td colspan="6">
        
        <telerik:RadGrid ID="dgPurchaseOrder" runat="server" CellSpacing="0" 
                AutoGenerateColumns="false"  Skin="WebBlue"  
                Visible="False" PageSize="50">
            <MasterTableView>
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
               <telerik:GridBoundColumn HeaderText="PO Quantity" DataField="Quantity">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
               <telerik:GridBoundColumn HeaderText="Item Price" DataField="Rate">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
               <telerik:GridBoundColumn HeaderText="Value" DataField="Amount">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
            </Columns>
            </MasterTableView>
            <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="false">
                                <Selecting AllowRowSelect="true" EnableDragToSelectRows="false" />
                            </ClientSettings>
            </telerik:RadGrid>
         </td>
        </tr>
         <tr style="height :50px; border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"  visible="true";>
   <td valign="middle">
    <table>
      
        <tr>
        <th colspan ="5" align="left"   style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080;" >Delivery Schedule</th>
      
        </tr>
         </table>
   </td>
   </tr>
   <tr style="height :20px;">
   <td valign ="top" >
    <table>      
        <tr>
        <th colspan ="5" align="left"   style="font-family: Arial; font-size: 12PX; font-weight: bold; color: #808080;" ></th>
      
        </tr>
         </table>
         </td>  
         <td  valign ="top">
          <table>      
        <tr>
        <th colspan ="5" align="left"   style="font-family: Arial; font-size: 12PX; font-weight: bold; color: #808080;" ></th>
          </tr>
         </table>
   </td>
   </tr>
   <tr>    
   <td>
   <table>
    <tr>
        <td style="width: 38px"></td>
    <td style="width: 224px; height :20px; font-family: Calibri; font-size: 14px; font-weight: bold; color: #808080;"     
            align="right" >Delivery1</td>   <td  style="width: 10px">    
            </td>
         <td> <asp:Label ID="lblDeliveryDate" runat="server" CssClass="labelNew"></asp:Label></td>
    </tr>
    <tr>
    <td style="width: 38px"></td>
      <td class="TopHeaderTd3" style="width: 224px"> </td>  <td  style="width: 10px">    
            </td>
    <td style="width: 153px; height :20px; font-family: Calibri; font-size: 14px; font-weight: bold; color:Black;"     
            align="center" >Total Scheduled </td> 
    </tr>
   </table>
   </td>
   <td>
    <table>
    <tr>
        <td style="width: 38px"></td>
    <td style="width: 58px; height :20px; font-family: Calibri; font-size: 14px; font-weight: bold; color: #808080;"     
            align="right" ></td> 
         <td> </td>
    </tr>
    <tr>
  <td style="width: 50px; height :20px; font-family: Calibri; font-size: 14px; font-weight: bold; color: black;" > <asp:Label ID="lblTotalQty" runat="server" Text=""></asp:Label></td>
  <td style="width: 50px; height :20px; font-family: Calibri; font-size: 14px; font-weight: bold; color: black;" > <asp:Label ID="lblTotalAmount" runat="server" Text=""></asp:Label></td>
  <td style="width: 58px; height :20px; font-family: Calibri; font-size: 14px; font-weight: bold; color: black;"> <asp:Label ID="lblDestination" runat="server" Text=""></asp:Label></td>
  <td style="width: 50px; height :20px; font-family: Calibri; font-size: 14px; font-weight: bold; color: black;" > <asp:Label ID="lblDeliveryMode" runat="server" Text=""></asp:Label></td> 
   <td style="width: 120px; height :20px;" > </td> 
    </tr>
   </table>
   </td>
   </tr>
    <tr style="height :80px; border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"  visible="true";>
   <td valign="bottom">
    <table>
      
        <tr>
        <th colspan ="5" align="left"   style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080;" >Shipping & Payment Terms</th>
      
        </tr>
         </table>
   </td>
   </tr>
    <tr style="height :40px;">
   <td valign ="bottom" >
   <table>
   <tr>
        <td style="width: 38px"></td>
    <td style="width: 153px; height :20px; font-family: Calibri; font-size: 14px; font-weight: bold; color: #808080;"  
            align="right" >Shipping Terms</td>   <td  style="width: 10px">    
            </td>
        <td style="width: 328px; height: 20px;">
                <asp:Label ID="lblShippingTerms" runat="server" CssClass="labelNew"></asp:Label>
            </td>
    </tr>
   </table>
   </td>
    <td valign ="bottom">
   <table>
   <tr>
        <td style="width: 38px"></td>
    <td style="width: 153px;"> </td> 
        <td style="width: 153px; height :20px; font-family: Calibri; font-size: 14px; font-weight: bold; color: #88C4FF; text-decoration: none;" >         
            </td>
    </tr>
   </table>
   </td>
   </tr>
     <tr style="height :40px;">
   <td valign ="bottom" >
   <table>
   <tr>
        <td style="width: 38px"></td>
    <td style="width: 192px; height :20px; font-family: Calibri; font-size: 14px; font-weight: bold; color: #808080;"  
            align="right" >Preferred Payment Terms</td>   <td  style="width: 10px">    
            </td>
        <td style="width: 328px; height: 20px;">
                <asp:Label ID="lblPreferredPaymentTerms" runat="server" CssClass="labelNew"></asp:Label>
            </td>
    </tr>
   </table>
   </td>
   </tr>
    </table>
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
    </form>
</body>
</html>
