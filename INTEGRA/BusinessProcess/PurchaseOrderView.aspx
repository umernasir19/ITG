<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"  CodeBehind="PurchaseOrderView.aspx.vb" Inherits="Integra.PurchaseOrderView" %>
  <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    </telerik:RadCodeBlock>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <div class="main-wrapper">
        <div class="aaa">
            &nbsp;</div>
        <div class="inner">
            <!--working area-->
            <div>
                <div style="margin-top: 10px; height: 10px;">
                    &nbsp;</div>
                <div style="margin-left: 6px;">
                    <telerik:RadButton ID="btnAddPurchaseorder" runat="server" Text="Add Purchaseorder" Skin="WebBlue">
                    </telerik:RadButton>

                      <telerik:RadButton ID="btnWIP" runat="server" Text="WIP" Skin="WebBlue">
                    </telerik:RadButton>

                         <telerik:RadButton ID="btnInspection" runat="server" Text="Inspection" Skin="WebBlue">
                    </telerik:RadButton>

                   <telerik:RadButton ID="btnPoRevised" runat="server" Text="Revised Shipment" Skin="WebBlue">
                    </telerik:RadButton>

                      <telerik:RadButton ID="btnSpilt" runat="server" Text="Spilt Shipment" Skin="WebBlue">
                    </telerik:RadButton>
                    <div style="margin-top: 10px;">
                


                    </div>
                </div>
            </div>
        </div>
        <!--close inner-wrapper-->
    </div>
    <!--close main-wrapper-->
</asp:Content>
