<%@ Page Language="vb"  MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeBehind="SMCView.aspx.vb" Inherits="Integra.SMCView" %>
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
    <table width="100%">
  
 <tr>
    
    <td colspan ="5" align ="right" ><telerik:RadButton ID="btnAdd" runat="server" Text="Add SMC"   Skin="WebBlue">
                </telerik:RadButton></td></tr>
 <tr>
 <td>
    <telerik:RadGrid ID="dgSMC" runat="server" CellSpacing="0"  AutoGenerateColumns="false"  Skin="WebBlue"  Visible="true" PageSize="50">
            <MasterTableView>
            <Columns>  
            <telerik:GridBoundColumn HeaderText="POID" DataField="POID" Display ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left"  />
            </telerik:GridBoundColumn>
             <telerik:GridBoundColumn HeaderText="Customer" DataField="CustomerName" Display ="true"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left"  />
            </telerik:GridBoundColumn>
             <telerik:GridBoundColumn HeaderText="Supplier" DataField="VenderName" Display ="true"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left"  />
            </telerik:GridBoundColumn>
             <telerik:GridBoundColumn HeaderText="PO No" DataField="PONO" Display ="true"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left"  />
            </telerik:GridBoundColumn>
             <telerik:GridBoundColumn HeaderText="Placement Date" DataField="PlacementDate" >
           <ItemStyle HorizontalAlign="Left" Width ="50px" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn> 
            <telerik:GridBoundColumn HeaderText="Del Date" DataField="ShipmentDate" >
           <ItemStyle HorizontalAlign="Left" Width ="50px" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>  
              
             <telerik:GridTemplateColumn HeaderText ="PDF"  Display="false">
                <ItemTemplate >
                <asp:LinkButton ID="lnViewPdf"  runat ="server" CommandName ="PDF" HeaderText ="PDF" Text="PDF" ></asp:LinkButton>
                </ItemTemplate>
                </telerik:GridTemplateColumn>
               <telerik:GridTemplateColumn HeaderText ="View"  Display="true">
                  <ItemStyle HorizontalAlign="Left"  Width="30px"  />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
                <ItemTemplate >
                <asp:LinkButton ID="lnView"  runat ="server" CommandName ="EDIT" HeaderText ="View" Text="Edit" ></asp:LinkButton>
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