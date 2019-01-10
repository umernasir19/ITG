<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="CourierDetail.aspx.vb" Inherits="Integra.CourierDetail" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript">
    function isNumericKey(e) {
        var charInp = window.event.keyCode;
        if (charInp > 31 && (charInp < 48 || charInp > 57)) {
            return false;
        }
        return true;
    }
    function isNumericKeyy(e) {
        var charInp = window.event.keyCode;
        if (charInp != 46 && (charInp < 48 || charInp > 57)) {
            return false;
        }
        return true;
    }
   
    </script>
    <table width="100%">
        <tr>
            <th colspan="4" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                COURIER DETAIL
                         </th>
        </tr>
         <tr>
            <td style="width: 110px;">
                DCD.No.
            </td>
            <td style="width: 110px;">
                <asp:TextBox ID="txtDcdNo" runat="server" autocomplete="off" AutoPostBack="false"
                    Style="margin:5px; margin-left: 0px; width: 150px;"></asp:TextBox>
                    </td> 
                     </tr>
          
        <tr>
            <td style="width: 110px;">
                Export Reg.No.
            </td>
            <td style="width: 110px;">
                <asp:TextBox ID="txtExRegNo" runat="server"  autocomplete="off" AutoPostBack="false"
                    Style="margin:5px; margin-left: 0px; width: 150px; text-transform: uppercase;"></asp:TextBox>
                    </td> 
                      <td style="width: 110px;">
                NTN No.
            </td>
            <td style="width: 110px;">
                <asp:TextBox ID="txtNtnNo" runat="server" autocomplete="off" AutoPostBack="false"
                    Style="margin-left: 0px; width: 150px; text-transform: uppercase;"></asp:TextBox>
                    </td> 
         
           
            </tr>
            <tr>
                <td style="width: 110px;">
                Invoice No.
            </td>
            <td style="width: 110px;">
                <asp:TextBox ID="txtInvNo" runat="server" autocomplete="off" AutoPostBack="false"
                    Style=" margin: 5px; margin-left: 0px;  width: 150px; text-transform: uppercase; "></asp:TextBox>
                    </td> 
         
               <td style="width: 110px;">
               Date
               </td> 
            <td style="width: 110px;">
                <telerik:RadDatePicker ID="txtDatee" runat="server" Culture="en-US" Width="100px">
                    <Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                    </Calendar>
                    <DateInput ID="DateInput1" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
           <%-- <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblBuyer" runat="server" Text="Wash Recv.No."></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtWashRecvNo" runat="server" Skin="WebBlue" Width="105px" Visible="true" >
                </telerik:RadTextBox>
            </td>--%>
        </tr>
        <tr>
           <td style="width: 110px;">
                Account No.
            </td>
            <td style="width: 110px;">
                <asp:TextBox ID="txtAccountNo" runat="server" autocomplete="off" AutoPostBack="false"
                    Style="margin-left: 0px; width: 150px; text-transform: uppercase;"></asp:TextBox>
               
                <asp:Label ID="lblWashMstId" runat="server"  Visible="false"></asp:Label>
            </td>
           
             <td style="width: 110px;">
                Invoice Of
            </td>
            <td style="width: 110px;">
                <asp:TextBox ID="txtInvOf" runat="server" autocomplete="off" AutoPostBack="false"
                    Style="margin-left: 0px; width: 150px; text-transform: uppercase;"></asp:TextBox>
                 </td>
        </tr>
         <tr>
            <td style="width: 110px;">
                Shipped Per.
            </td>
            <td style="width: 110px;">
                 <asp:TextBox ID="txtShippedPer" runat="server" autocomplete="off" AutoPostBack="false"
                    Style="margin-left: 0px; width: 150px; text-transform: uppercase;"></asp:TextBox>
                 </td>
           
                     
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="Label2" runat="server" Text="From Karachi To"></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <asp:TextBox ID="txtFrmKhi" runat="server" autocomplete="off" AutoPostBack="false"
                    Style="margin-left: 0px; width: 150px; text-transform: uppercase;"></asp:TextBox>
                 </td>
            
        </tr>
        <tr>
            <td style="width: 110px;">
               Weight KG
            </td>
            <td style="width: 110px;">
               <asp:TextBox ID="txtWeight" runat="server" autocomplete="off" AutoPostBack="false"
                    Style="margin-left: 0px; width: 150px; text-transform: uppercase;"></asp:TextBox>
                 </td>
           
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="Label1" runat="server" Text="Courier Airway Bill No."></asp:Label>
            </td>
           <td style="width: 110px;">
                <telerik:RadTextBox ID="txtCourAirBillNo" runat="server" Skin="WebBlue" Width="105px" Visible="true" style="text-transform: uppercase;">
                </telerik:RadTextBox>
                    
            </td>
        </tr>
        <tr>
            <td style="width: 110px;">
                <asp:Label ID="Label3" runat="server" Text="Buyer Name"></asp:Label>
            </td>
            <td style="width: 110px;">
              <telerik:RadComboBox ID="cmbBuyerName" runat="server" AutoPostBack="true" Skin="WebBlue" >
                        </telerik:RadComboBox>
            </td>
            </tr>
            <tr>
            <td style="width: 128px; height: 30px;">
               Address
            </td>
          <td style="width: 110px;">
                <telerik:RadTextBox ID="txtAddress" runat="server" Skin="WebBlue" Width="379px" Visible="true" TextMode="MultiLine" style="text-transform: uppercase;" >
                </telerik:RadTextBox>
                    
            </td>
        </tr>
          <tr>
            <td style="width: 110px;">
               No.Of Packages
            </td>
            <td style="width: 110px;">
               <asp:TextBox ID="txtPackage" runat="server" autocomplete="off" AutoPostBack="false"
                    Style="margin-left: 0px; width: 150px; text-transform: uppercase;"></asp:TextBox>
                 </td>
           
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="Label4" runat="server" Text="Qty"></asp:Label>
            </td>
           <td style="width: 110px;">
                <telerik:RadTextBox ID="txtQty" runat="server" Skin="WebBlue" Width="70px" Visible="true" onkeypress="return isNumericKeyy(event);"  >
                </telerik:RadTextBox>
                    <asp:Label ID="Label7" runat="server" Text="Rate"></asp:Label>
                     <telerik:RadTextBox ID="txtRate" runat="server" Skin="WebBlue" Width="70px" AutoPostBack ="true"  Visible="true" onkeypress="return isNumericKeyy(event);"  >
                </telerik:RadTextBox>
            </td>

        </tr>
         <tr>
            <td style="width: 110px;">
               QTy.Type
            </td>
            <td style="width: 110px;">
               <asp:TextBox ID="txtQtyType" runat="server" autocomplete="off" AutoPostBack="false"
                    Style="margin-left: 0px; width: 150px; text-transform: uppercase;"></asp:TextBox>
                 </td>
           
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="Label5" runat="server" Text="Description"></asp:Label>
            </td>
           <td style="width: 110px;">
                <telerik:RadTextBox ID="txtDesc" runat="server" Skin="WebBlue" Width="105px" Visible="true" style=" text-transform: uppercase;" >
                </telerik:RadTextBox>
                    
            </td>
        </tr>
        <tr>
           
             <td style="width: 128px; height: 30px;">
               Converging Rate
            </td>
          <td style="width: 110px;">
                <telerik:RadTextBox ID="txtConvergRate" runat="server" Skin="WebBlue" Width="105px" Visible="true" onkeypress="return isNumericKeyy(event);" >
                </telerik:RadTextBox>
                    
            </td>
            </tr>  
         <tr>         
            <td style="width: 110px;">
               Amount
            </td>
            <td style="width: 110px;">
               <asp:TextBox ID="txtAmount" runat="server" autocomplete="off" AutoPostBack="false" onkeypress="return isNumericKeyy(event);"
                    Style="margin-left: 0px; width: 150px;"></asp:TextBox>
                 </td>
           
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="Label6" runat="server" Text="Currency"></asp:Label>
            </td>
           <td style="width: 110px;">
                    <telerik:RadComboBox ID="cmbCurrency" runat="server" AutoPostBack="true" Skin="WebBlue" >
                                          </telerik:RadComboBox>
                    
            </td>
        </tr>
         <asp:panel ID ="PnlRemarks" runat ="server" Visible ="false"  >
        <tr>
       
       

       <td style="width: 128px; height: 30px;">
               Buyer Comment
            </td>
          <td style="width: 110px;">
                <telerik:RadTextBox ID="txtBuyerComment" runat="server" Skin="WebBlue" Width="379px" Visible="true" TextMode="MultiLine" style="text-transform: uppercase;" >
                </telerik:RadTextBox>
                    
            </td>

              <td style="height: 30px; width: 90px;">

               Upload PDF
                                </td>
                                <td colspan="2" style="height: 30px; width: 128px;">
                                    <asp:FileUpload ID="FileUpload2" runat="server" />
                                </td>
                                <td>
                                    <asp:Button ID="btnUpload" runat="server" Style="width: 63px; margin-left: -57px;"
                                        Text="Upload" />
                                    <asp:UpdatePanel ID="UpPic" runat="server" ChildrenAsTriggers="true">
                                        <ContentTemplate>
                                            <asp:LinkButton ID="lnkFIlePicture" runat="server" Style="margin-left: -54px;" Text="Show PDF"
                                                Visible="false"> </asp:LinkButton>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td>
                                </td>


   
         </tr>
        <%-- <tr>
          <td style="width: 110px;">
     
              Delivery Date
               </td> 
            <td style="width: 110px;">
                <telerik:RadDatePicker ID="txtDeliveryDate" runat="server" Culture="en-US" Width="100px">
                    <Calendar ID="Calendar2" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                    </Calendar>
                    <DateInput ID="DateInput2" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
         </tr>--%>
              </asp:panel> 
        <tr>  
            <td style="width: 128px; height: 30px;">
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadButton ID="btnAdd" runat="server" Text="Add" Skin="WebBlue" Visible ="true">
                </telerik:RadButton>
            </td>
             <td class="TopHeaderTable3" style="width: 166px; height: 30px;" >
                <telerik:RadButton ID="btnAddMore" runat="server" Text="Add More" Skin="WebBlue" Visible ="false" >
                </telerik:RadButton>
            </td>
        </tr>
    </table><br />
    <table width ="100%">
        <tr>
            <td colspan="2">
                <telerik:RadGrid ID="dgCourier" runat="server" CellSpacing="0" AutoGenerateColumns="false"
                    Skin="WebBlue" Visible="False" PageSize="50" AllowAutomaticDeletes="false" >
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn HeaderText="DPCourierDtlId" DataField="DPCourierDtlId" Display="false">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="CurrencyID" DataField="CurrencyID" Display="false">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="No.Of Packages" DataField="NoOfPackage" Display="true">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                              <telerik:GridBoundColumn HeaderText="Quantity" DataField="Qty" Display="true">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                              <telerik:GridBoundColumn HeaderText="Rate" DataField="Rate" Display="true">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Qty.Type" DataField="QtyType">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                           
                            <telerik:GridBoundColumn HeaderText="Description" DataField="Desc">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>


                              <telerik:GridTemplateColumn HeaderText="Delivery Date" Visible ="false"  UniqueName="Select" AllowFiltering="false">
                                    <ItemTemplate>
                                        
                                         <telerik:RadDatePicker ID="txtDeliveryDate" runat="server" Culture="en-US" Width="100px">
                    <Calendar ID="Calendar2" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                    </Calendar>
                    <DateInput ID="DateInput2" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>


                                    </ItemTemplate>
                                     <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridTemplateColumn>


                          
                         
                                                  
                        
                            <telerik:GridBoundColumn HeaderText="ConvgRate" DataField="ConvergeRate" Display="false">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                             <telerik:GridBoundColumn HeaderText="Amount" DataField="Amount">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn UniqueName="DeleteColumn" Text="" CommandName="Delete"
                                ConfirmTextFormatString="Are You Sure You want to Delete Record" HeaderStyle-Width="5%"
                                ButtonType="ImageButton">
                            </telerik:GridButtonColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table><br />
    <table>
        <tr>
            <td>
            </td>
            <td colspan="2" align="right">
                <telerik:RadButton ID="btnSave" runat="server" Text="Save" Skin="WebBlue">
                </telerik:RadButton>
            </td>
        </tr>
    </table>
</asp:Content>
