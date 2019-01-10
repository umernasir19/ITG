<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="CargoRelease.aspx.vb" Inherits="Integra.CargoRelease" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<telerik:RadAjaxManager ID="radajax" runat="server">
<AjaxSettings>
<telerik:AjaxSetting AjaxControlID="btnArticleNoNew">
<UpdatedControls>
<telerik:AjaxUpdatedControl ControlID="dgCargo" />
</UpdatedControls>
</telerik:AjaxSetting>
<telerik:AjaxSetting AjaxControlID="btnAutoCalculate">
<UpdatedControls>
<telerik:AjaxUpdatedControl ControlID="lblmsg" />
<telerik:AjaxUpdatedControl ControlID="lblSystemValue" />
<telerik:AjaxUpdatedControl ControlID="lblReleaseQTY" />
<telerik:AjaxUpdatedControl ControlID="lblOk" />
</UpdatedControls>
</telerik:AjaxSetting>
</AjaxSettings>
</telerik:RadAjaxManager>
<div>
<table width="100%">
<tr>
<td style="height: 25px">
Invoice:
</td>
<td style="height: 25px">
<telerik:RadTextBox ID="txtInvoiceNo" runat="server" Skin="WebBlue"></telerik:RadTextBox>
</td>
<td style="height: 25px"></td>
<td style="left: 10px; height: 25px;">
Date:
</td>
<td style="height: 25px">
<telerik:RadDatePicker ID="txtInvoiceDate" runat="server" Skin="WebBlue"></telerik:RadDatePicker>
</td>
</tr>
<tr>
<td style="height: 25px">&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td></td>
<td></td>
</tr>
<tr>
<td style="height: 25px">
Invoice Value:
</td>
<td style="height: 25px">
<telerik:RadTextBox ID="txtInvoiceValue" runat="server" Skin="WebBlue"></telerik:RadTextBox>
</td>
<td style="height: 25px">
  <asp:DropDownList ID="cmbCurrency"  CssClass="forcapital" runat="server" Width="72px">
    <asp:ListItem>Dollar</asp:ListItem>
    <asp:ListItem>Euro</asp:ListItem>
    </asp:DropDownList>
</td>
<td>
</td>
<td>
</td>
</tr>
<tr>
<td style="height: 25px">
    Mode:
</td>
<td>
<telerik:RadTextBox ID="txtTerm" runat="server"  Skin="WebBlue"></telerik:RadTextBox>
</td>
<td></td>
<td>
    ETA: 
</td>
<td><telerik:RadDatePicker ID="txtETA" runat="server" Skin="WebBlue"></telerik:RadDatePicker></td>
</tr>
<tr>
<td style="height: 25px">
    Freight Term:
</td>
<td>
<telerik:RadTextBox ID="txtItemDesc" runat="server"  Skin="WebBlue"></telerik:RadTextBox>
</td>
<td>
</td>
<td>
</td>
<td></td>
</tr>
<tr>
<td style="height: 25px">
    Shipping Line:
</td>
<td>
<telerik:RadTextBox ID="txtShippingLine" runat="server"  Skin="WebBlue"></telerik:RadTextBox>
</td>
<td>
</td>
<td>
</td>
<td></td>
</tr>
<tr>
<td style="height: 25px">
    Forwarder:
</td>
<td>
<telerik:RadTextBox ID="txtForwarder" runat="server"  Skin="WebBlue"></telerik:RadTextBox>
</td>
<td>
</td>
<td>
</td>
<td></td>
</tr>
<tr>
<td style="height: 25px">
    MAWB:
</td>
<td>
<telerik:RadTextBox ID="txtMode" runat="server"  Skin="WebBlue"></telerik:RadTextBox>
</td>
<td>
</td>
<td>
</td>
<td></td>
</tr>
<tr>
<td style="height: 25px">
    Carrier Name:</td>
<td>
<telerik:RadTextBox ID="txtCarrierName" runat="server"  Skin="WebBlue"></telerik:RadTextBox>
</td>
<td>
</td>
<td>
</td>
<td></td>
</tr>
<tr>
<td style="height: 25px">
    Voyage/Flight:</td>
<td>
<telerik:RadTextBox ID="txtVoyageFlight" runat="server"  Skin="WebBlue"></telerik:RadTextBox>
</td>
<td>
</td>
<td>
</td>
<td></td>
</tr>
<tr>
<td style="height: 25px">
    BL / AWB NO:</td>
<td>
<telerik:RadTextBox ID="txtBillNo" runat="server"  Skin="WebBlue"></telerik:RadTextBox>
</td>
<td></td>
<td>
    ETD:</td>
<td>
<telerik:RadDatePicker ID="txtETD" runat="server" Skin="WebBlue"></telerik:RadDatePicker>
</td>
</tr>
<tr>
<td style="height: 25px">
    Shipment Date:</td>
<td>
<telerik:RadDatePicker ID="txtCargoDate" runat="server" Skin="WebBlue"></telerik:RadDatePicker>
</td>
<td></td>
<td>
    CBM:</td>
<td>
<telerik:RadTextBox ID="txtCBM" runat="server"  Skin="WebBlue"></telerik:RadTextBox>
</td>
</tr>
<tr>
<td style="height: 25px">
    Container No:</td>
<td>
<telerik:RadTextBox ID="txtContainer" runat="server"  Skin="WebBlue"></telerik:RadTextBox>
</td>
<td>&nbsp;</td>
<td>
    Container Size:</td>
<td>
    <telerik:RadComboBox ID="cmbContainerSize" runat="server" Skin="WebBlue">
    <Items>
    <telerik:RadComboBoxItem Text="20 FT" Value="0" />
     <telerik:RadComboBoxItem Text="40 FT Standard" Value="1" />
      <telerik:RadComboBoxItem Text="40 HC" Value="2" />
       <telerik:RadComboBoxItem Text="45 FT" Value="" />
        <telerik:RadComboBoxItem Text="Other" Value="" />
    </Items>
    </telerik:RadComboBox></td>
</tr>
<tr>
<td style="height: 25px">
    Consolidation:
</td>
<td>
    <telerik:RadComboBox ID="cmbConsolidation" runat="server" Skin="WebBlue">
        <Items>
            <telerik:RadComboBoxItem Text="FCL" Value="0" />
            <telerik:RadComboBoxItem Text="LCL" Value="1" />
                  </Items>
    </telerik:RadComboBox>
</td>
<td>
</td>
<td>
</td>
<td>
<telerik:RadTextBox ID="txtShippedExchangeRate" runat="server"  Skin="WebBlue" 
        Width="70px"></telerik:RadTextBox>
    </td>
</tr>
<tr>
<td style="height: 26px">
    POD-POA:</td>
<td colspan="8" style="height: 26px">
<telerik:RadTextBox ID="txtRemarks" runat="server"  Skin="WebBlue" Width="557px"></telerik:RadTextBox>
    </td>
<td style="height: 26px"></td>
<td style="height: 26px"></td>
<td style="height: 26px"></td>
</tr>
<tr >
<td>PO / Article:</td>
<td><asp:LinkButton ID="GetArticle" runat="server" >Select PO No. /Article</asp:LinkButton></td>
<td colspan="8"><telerik:RadButton ID="btnArticleNoNew" Text="Get Data" runat="server" 
        Skin="WebBlue"></telerik:RadButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <telerik:RadButton ID="btnAutoCalculate" Text="Auto Calculate" runat="server" 
        Skin="WebBlue"></telerik:RadButton></td>
        <td>&nbsp;</td>
</tr>
</table>
<table>
     <tr><td align="center"    style="width: 783px; height: 13px;" >
     <b>
     <asp:Label ID="lblmsg"  visible="false" runat="server" ></asp:Label>
     <asp:Label ID="lblSystemValue"  visible="false" runat="server" ></asp:Label></b>
     </td></tr>
     <tr>
<td align="center"   style="width: 783px; height: 13px;"><b>
<asp:Label ID="lblReleaseQTY"  visible="false" runat="server" ></asp:Label></b>
</td></tr>
<tr>
<td align="center"   style="width: 783px; height: 13px;"><b>
<asp:Label ID="lblOk"  visible="false" runat="server" ></asp:Label></b>

</td></tr>

</table>
<table width="100%">
<tr>
<td>
<telerik:RadGrid ID="dgCargo"  runat="server" CellSpacing="0" 
                AutoGenerateColumns="false"  Skin="WebBlue"  
                Visible="False" PageSize="50">
              <AlternatingItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" />
            <MasterTableView>
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>
<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
            <Columns>
                                                          <telerik:GridBoundColumn HeaderText="PO No." DataField="PONO" />
															<telerik:GridBoundColumn HeaderText="POID" DataField="POID" Display="False" />
															<telerik:GridBoundColumn HeaderText="Style ID" DataField="StyleID" Display="False" />
																<telerik:GridBoundColumn HeaderText="Customer" DataField="CustomerName" />
																	<telerik:GridBoundColumn HeaderText="Supplier" DataField="SupplierName" />
																	
															<telerik:GridBoundColumn HeaderText="Style No" DataField="StyleNo"  >
															    <itemstyle horizontalalign="Center" width="40%" />
															</telerik:GridBoundColumn> 
																<telerik:GridBoundColumn HeaderText="Article" DataField="Article"  visible="true" >
															    <itemstyle horizontalalign="Center" width="40%" />
															</telerik:GridBoundColumn> 
																<telerik:GridBoundColumn HeaderText="Color" DataField="Colorway"  visible="true" >
															    <itemstyle horizontalalign="Center" width="40%" />
															</telerik:GridBoundColumn> 
																	<telerik:GridBoundColumn HeaderText="Size" DataField="SizeRange"  visible="true" >
															    <itemstyle horizontalalign="Center" width="40%" />
															</telerik:GridBoundColumn>
															<telerik:GridBoundColumn HeaderText="PO Quantity" DataField="Quantity"  />
															<telerik:GridBoundColumn HeaderText="Shipped Quantity" DataField="ShippedQty"  />
														<telerik:GridTemplateColumn HeaderText="Release Quantity">
                                                                <itemstyle horizontalalign="Center" />
									                        <ITEMTEMPLATE>
										                    <asp:textbox id="txtReleaseQuantity" runat="server" width="60" CssClass="textbox" ReadOnly="true" text='<%#Eval("ReleaseQuantity") %>' ></asp:textbox>
                                                                
</ITEMTEMPLATE>
                                                                <headerstyle width="10%" />
								                            </telerik:GridTemplateColumn>
								                            <telerik:GridBoundColumn HeaderText="Cartons" DataField="Cartons"  >
															    <itemstyle horizontalalign="Center" width="40%" />
															</telerik:GridBoundColumn>
															  <telerik:GridBoundColumn HeaderText="Shipped Rate" DataField="ShippedRate"  >
															    <itemstyle horizontalalign="Center" width="40%" />
															</telerik:GridBoundColumn>
								                 
								                      <telerik:GridTemplateColumn HeaderText="ID" Display="False">
                                                                <itemstyle horizontalalign="Center" />
									                        <ITEMTEMPLATE>
										                   <asp:Label ID="lblID" runat="server" CssClass="label" text='<%#Eval("POID")%>'></asp:Label>
                                                                
</ITEMTEMPLATE>
                                                                <headerstyle width="10%" />
								                            </telerik:GridTemplateColumn>
								                              <telerik:GridBoundColumn HeaderText="CustomerID" DataField="CustomerID" Display="False" />
								                            <telerik:GridBoundColumn HeaderText="Vendorid" DataField="Vendorid" Display="False" />
								                             <telerik:GridBoundColumn HeaderText="POPOID" DataField="POPOID" Display="False"  />
								                               <telerik:GridBoundColumn HeaderText="Currency" DataField="Currency"  />
								                               
								                               <telerik:GridTemplateColumn HeaderText="Remove">
                                                                 <itemstyle horizontalalign="Center" />
									                        <ITEMTEMPLATE>
										                   <asp:ImageButton runat="server" CommandName="Remove"  BackColor="transparent" ImageUrl="~/Images/Remove.png"  />
									                     
</ITEMTEMPLATE> 
									                     <headerstyle width="15%" />
								                            </telerik:GridTemplateColumn>
</Columns>
 <EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
            </MasterTableView>
             <HeaderStyle Font-Names="Microsoft Sans Serif" />
 <ItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif"  />
            <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="False">
 <Selecting AllowRowSelect="true" EnableDragToSelectRows="false" />
 </ClientSettings>
<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
<FilterMenu EnableImageSprites="False"></FilterMenu>
            </telerik:RadGrid>
</td>
</tr>
<tr>
<td align="center"><telerik:RadButton ID="btnSave" runat="server" Skin="WebBlue" Text="Save"></telerik:RadButton>
&nbsp;
<telerik:RadButton ID="btnCancel" runat="server" Skin="WebBlue" Text="Cancel"></telerik:RadButton></td>
</tr>
</table>
</div>
</asp:Content>
