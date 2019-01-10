<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeBehind="PackingListAdd.aspx.vb" Inherits="Integra.PackingListAdd" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
    <AjaxSettings>
    <telerik:AjaxSetting AjaxControlID="txtStartSeriesNo">
    <UpdatedControls>
    <telerik:AjaxUpdatedControl ControlID="txtEndSeriesNo" />
    </UpdatedControls>
    </telerik:AjaxSetting>
    </AjaxSettings>
    <AjaxSettings>
    <telerik:AjaxSetting AjaxControlID="txtTotalCarton">
    <UpdatedControls>
    <telerik:AjaxUpdatedControl ControlID="txtEndSeriesNo" />
    </UpdatedControls>
    </telerik:AjaxSetting>
    </AjaxSettings>
     <AjaxSettings>
    <telerik:AjaxSetting AjaxControlID="cmbInvoiceNo">
    <UpdatedControls>
    <telerik:AjaxUpdatedControl ControlID="cmbPONO" />
    </UpdatedControls>
    </telerik:AjaxSetting>
    </AjaxSettings>
     <AjaxSettings>
    <telerik:AjaxSetting AjaxControlID="cmbPONO">
    <UpdatedControls>
    <telerik:AjaxUpdatedControl ControlID="cmbArticleNo" />
    </UpdatedControls>
    </telerik:AjaxSetting>
    </AjaxSettings>
      <AjaxSettings>
    <telerik:AjaxSetting AjaxControlID="cmbArticleNo">
    <UpdatedControls>
    <telerik:AjaxUpdatedControl ControlID="cmbSizes" />
    </UpdatedControls>
    </telerik:AjaxSetting>
    </AjaxSettings>
      <AjaxSettings>
    <telerik:AjaxSetting AjaxControlID="cmbSizes">
    <UpdatedControls>
    <telerik:AjaxUpdatedControl ControlID="txtQuantity" />
    <telerik:AjaxUpdatedControl ControlID="lblCommecialQuantity" />
    </UpdatedControls>
    </telerik:AjaxSetting>
  <telerik:AjaxSetting AjaxControlID="txtCartonSeriesEnd">
  <UpdatedControls>
  <telerik:AjaxUpdatedControl ControlID="lblValidation" />
  </UpdatedControls>
  </telerik:AjaxSetting>
  <telerik:AjaxSetting AjaxControlID="txtCartonSeriesStart">
  <UpdatedControls>
  <telerik:AjaxUpdatedControl ControlID="lblValidate" />
  </UpdatedControls>
  </telerik:AjaxSetting>
  
    </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"/>
    <script language="javascript" type="text/javascript">
        function OnClientSelectedIndexChanged(sender, eventArgs) {
            var item = eventArgs.get_item();
            sender.disable();
        }
</script>

 <div>
    <table align="center"  style="width: 100%;">
          <%--'-------Heading Row--------'--%>
         
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;" 
              visible="true";>
        <th colspan ="6" align="left"
  
                
                style="font-family: 'Calibri'; font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit; height: 29px;" 
                valign="bottom"> Create Packing List
  </th>
        </tr>
        <tr>
        <td style="width: 92px; height: 39px;" >
        <asp:Label ID="Label1" runat="server" Text="PL No."  Font-Names="Calibri" Font-Size="Medium"></asp:Label>
        </td>
        <td style="height: 39px; width: 195px" >
              <telerik:RadTextBox ID="txtPackingListNo" Runat="server" Skin="WebBlue" >
              </telerik:RadTextBox>
        
        </td>
         <td  style="width: 92px; height: 39px;"  >
                <asp:Label ID="lblInvoiceNo" runat="server" Text="Invoice No." 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
             </td>
                   <td style="height: 39px" >
             <telerik:RadComboBox ID="cmbInvoiceNo" runat="server" Skin="WebBlue" AutoPostBack="true" onclientselectedindexchanged="OnClientSelectedIndexChanged">
         <DefaultItem Text="Select Invoice No" />
                 </telerik:RadComboBox>
                       <telerik:RadTextBox ID="txtInvoiceNo" Runat="server" ReadOnly="True" 
                           Width="150px">
                       </telerik:RadTextBox>
              </td>
       <td  style="width: 92px; height: 39px;" >
                <asp:Label ID="Label4" runat="server" Text="PO No."  Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="height: 39px">
            
               <telerik:RadComboBox ID="cmbPONO" runat="server" Skin="WebBlue" AutoPostBack="true" OnSelectedIndexChanged="cmbPONO_SelectedIndexChanged" onclientselectedindexchanged="OnClientSelectedIndexChanged">
               <DefaultItem Text="Select PO No" />
                </telerik:RadComboBox>
                <telerik:RadTextBox ID="txtPONO" Runat="server" ReadOnly="True">
                </telerik:RadTextBox>
                </td></tr>   
     <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;" 
              visible="true";>
          <th colspan ="6" align="left"
  
              
              
              style="font-family: 'Calibri'; font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit; height: 35px;" 
              valign="bottom">  Carton Description
  </th>
             
        </tr>
      
        <tr>
            <td style="width: 92px; height: 39px">
                <asp:Label ID="lblTotalCarton" runat="server" Text="Total Carton" 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 195px; height: 39px;" >
              <telerik:RadTextBox ID="txtTotalCarton" Runat="server" Skin="WebBlue" AutoPostBack="true">
                </telerik:RadTextBox>

            </td>
            <td style="height: 39px" >
                <asp:Label ID="lblGrossWeight" runat="server" Text="Gross Weight" 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
         <td style="height: 39px" >
         <telerik:RadComboBox ID="cmbWeightUOM" runat="server" Width="60px" Skin="WebBlue">
            <Items>
            <telerik:RadComboBoxItem Text="KG" Value="0" />
            </Items>
            </telerik:RadComboBox>
              <telerik:RadTextBox ID="txtGrossWeight" Runat="server" Skin="WebBlue" Width="100px">
                </telerik:RadTextBox>

            </td>
          
            <td style="height: 39px" >
                <asp:Label ID="lblNetWeigth" runat="server" Text="Net Weigth" 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
         <td style="height: 39px; width: 180px;" >
              <telerik:RadTextBox ID="txtNetWeigth" Runat="server" Skin="WebBlue" Width="100px">
                </telerik:RadTextBox>

            </td>
        </tr>
        <tr>
            <td style="width: 92px; height: 62px" >
                <asp:Label ID="lblStartSeriesNo" runat="server" Text="Start Series"  Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 195px; height: 62px;" >
                         <telerik:RadTextBox ID="txtStartSeriesNo" Runat="server" Skin="WebBlue" AutoPostBack="true">
                </telerik:RadTextBox>
                    </td> 
                 
            <td style="height: 62px">
                <asp:Label ID="lblEndSeriesNo" runat="server" Text="End Series"  Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="height: 62px" >
                <telerik:RadTextBox ID="txtEndSeriesNo" Runat="server" Skin="WebBlue" 
                    ReadOnly="True" >
                </telerik:RadTextBox>
            </td>
            <td></td>
            <td >
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/box.jpg" Height="48px" 
                    Width="70px"></asp:Image>
            </td>
        </tr>
             <tr>
            <td style="width: 92px; height: 35px">
                <asp:Label ID="lblL" runat="server" Text="Lenght" 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 195px; height: 35px;" >
               <telerik:RadComboBox ID="cmblenghtUOM" runat="server" Width="60px" 
                    Skin="WebBlue" Height="10px">
                <Items>
                <telerik:RadComboBoxItem Text="CM" Value="0" />
                <telerik:RadComboBoxItem Text="M" Value="1" />
                </Items>
            </telerik:RadComboBox>

              &nbsp;<telerik:RadTextBox ID="txtLenght" Runat="server" Skin="WebBlue" Width="100px" 
                    Height="21px">
                </telerik:RadTextBox>
               
            </td>
            <td style="height: 35px" >
             
                <asp:Label ID="lblW" runat="server" Text="Width" 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
             
            </td>
            <td style="height: 35px; width: 180px;" >
              <telerik:RadTextBox ID="txtWidth" Runat="server" Skin="WebBlue" Width="100px">
                </telerik:RadTextBox>

            </td>
         <td style="height: 35px"  >
                <asp:Label ID="lblHeight" runat="server" Text="Height" 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                 </td>
            <td style="height: 35px" >
              <telerik:RadTextBox ID="txtHeight" Runat="server" Skin="WebBlue" Width="100px">
                </telerik:RadTextBox>

            </td>
         <td style="height: 35px"  >
                 </td>
        </tr>
        
          <%--'-------Heading Row--------'--%>
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;" 
              visible="true";>
         <th colspan ="6" align="left"
  
                
                style="font-family: 'Calibri'; font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit; height: 41px;" 
                valign="bottom">  Carton Specific Information  
  </th>
             
        </tr>
       
   
        <tr>
        <td style="width: 92px" >
        <asp:Label ID="lblSeriesStart" runat="server" Text="Carton Series Start" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
        </td>
        <td style="width: 195px" >
        <telerik:RadTextBox ID="txtCartonSeriesStart" Runat="server" Skin="WebBlue" AutoPostBack="true" OnTextChanged="txtCartonSeriesStart_TextChanged"></telerik:RadTextBox>
          <asp:Label ID="lblValidate" runat="server" ForeColor="Red"></asp:Label>
        </td>
        <td >
        <asp:Label ID="lblSeriesEnd" runat="server" Text="Carton Series End" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
        </td>
        <td>
         <telerik:RadTextBox ID="txtCartonSeriesEnd" Runat="server" Skin="WebBlue" AutoPostBack="true"></telerik:RadTextBox>
        
            <asp:Label ID="lblvalidation" runat="server" ForeColor="Red"></asp:Label>
        
        </td>
        <td >
            <asp:Label ID="Label5" runat="server" Text="Qty allowed:" ForeColor="Maroon"></asp:Label>
                       </td>
            <td>
             <asp:Label ID="lblCommecialQuantity" runat="server" Font-Bold="True" 
                    ForeColor="Maroon" ></asp:Label>
            </td>
        </tr>
        <tr>
         <td style="height: 38px; width: 92px;" >
         <asp:Label ID="lblArticleno" runat="server" Text="Article No." Font-Names="Calibri" Font-Size="Medium"></asp:Label>
        </td>
        <td style="height: 38px; width: 195px;" >
        <telerik:RadComboBox ID="cmbArticleNo" Runat="server" Skin="WebBlue" AutoPostBack="true" OnSelectedIndexChanged="cmbArticleNo_SelectedIndexChanged">
        <DefaultItem Text="Select Article" />
        </telerik:RadComboBox>
        </td>
        <td style="height: 38px" >
         <asp:Label ID="lblSizes" runat="server"  Text="Sizes" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
        </td>
        <td style="height: 38px">
            <telerik:RadComboBox ID="cmbSizes" runat="server" Skin="WebBlue" AutoPostBack="true" OnSelectedIndexChanged="cmbSizes_SelectedIndexChanged">
            <DefaultItem Text="Select Sizes" />
           
            </telerik:RadComboBox>
        </td>
            <td style="height: 38px">
                <asp:Label ID="lblquantity" runat="server" Text="Quantity" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="height: 38px">
                <telerik:RadTextBox ID="txtQuantity" runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
        <td colspan="5" rowspan="2">
         <telerik:RadGrid ID="dgPackingListDetail" runat="server" CellSpacing="0" 
                AutoGenerateColumns="false"  Skin="WebBlue"  
                Visible="False" PageSize="50" OnDeleteCommand="dgPackingListDetail_DeleteCommand">
            <MasterTableView>
            <Columns>

            <telerik:GridBoundColumn HeaderText="PackingListDetailID." DataField="PackingListDetailID" Display="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="PODetailID" DataField="PODetailID" Display="false"></telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Carton Series Start" DataField="CartonSeriesStart" >
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn DataField="POID" HeaderText="POID" Display="false">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Carton Series End" DataField="CartonSeriesEnd">
            <HeaderStyle Width="15%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>           
            <telerik:GridBoundColumn HeaderText="Article No" DataField="Article">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Size" DataField="SizeRange">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Quantity" DataField="Quantity">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>         
            <telerik:GridButtonColumn UniqueName="DeleteColumn" Text="Delete" CommandName="Delete" ButtonType="ImageButton"></telerik:GridButtonColumn>
            </Columns>
            </MasterTableView>
            
            </telerik:RadGrid>
        </td>
            
            <td style="height: 35px">
                &nbsp;&nbsp;
                <asp:LinkButton ID="lnkAddexisting" runat="server" Text="Add into existing carton"></asp:LinkButton>
                <br />
                <br />
&nbsp;&nbsp;
                <asp:LinkButton ID="lnkAddother" runat="server" Text="Add into another carton"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style="height: 31px">
                &nbsp;&nbsp;
                </td>
        </tr>
        <tr>
          <td style="width: 92px">
         <asp:Label ID="lblArticleno0" runat="server" Text="Comments" Font-Names="Calibri" 
                  Font-Size="Medium"></asp:Label>
            </td>
            <td colspan="5" style="height: 60px">
                <telerik:RadTextBox ID="txtComments" runat="server" Skin="WebBlue" TextMode="MultiLine"
                    Width="534px" Height="40px">
                </telerik:RadTextBox>
            </td>
        </tr>
    </table>
     <table align="center"  style="width: 100%;">
     <tr>
     <td valign ="middle">
         <br />
         </td>
     <td valign ="middle" style="width: 60px; height: 70px;">
     <telerik:RadButton ID="btnSave" runat="server" Text="Save" Skin="WebBlue">
                    </telerik:RadButton>
     </td>
     <td valign ="middle" style="width: 60px; height: 70px;">
     <telerik:RadButton ID="btnCancle" runat="server" Text="Cancle" Skin="WebBlue">
                    </telerik:RadButton>
     </td>
     <td valign ="middle" style="width: 60px; height: 70px;">
         &nbsp;</td>
     </tr>
     </table>
   
    </div>
</asp:Content> 