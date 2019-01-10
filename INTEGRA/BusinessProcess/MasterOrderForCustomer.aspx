<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeBehind="MasterOrderForCustomer.aspx.vb" Inherits="Integra.MasterOrderForCustomer" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" EnableAJAX="true" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
        <ClientEvents OnRequestStart="onRequestStart" OnResponseEnd="onResponseEnd" />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="dgMasterOrderForCustomer">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="dgMasterOrderForCustomer" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" BackgroundPosition="Bottom"
        Width="80%">
        <asp:Image ID="Image1" runat="server" AlternateText="Loading..." ImageUrl="~/Images/loading12.gif" />
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadCodeBlock runat="server" ID="radCodeBlock">
        <script type="text/javascript">
            function showFilterItem() {
                $find('<%=dgMasterOrderForCustomer.ClientID %>').get_masterTableView().showFilterItem();
            }
            function hideFilterItem() {
                $find('<%=dgMasterOrderForCustomer.ClientID %>').get_masterTableView().hideFilterItem();
            }        
        </script>
    </telerik:RadCodeBlock>
    <div>
        <table style="width: 100%;">
                <tr>
                
              <td align="right">
      
                  </td>         
            </tr>
             <tr>
                <td align="right">

                    <asp:UpdatePanel ID="upcmbAction" UpdateMode="Conditional" runat="server">
                     <ContentTemplate>
                         <asp:ImageButton ID="imgReset" ToolTip="Click here to reset below sheet at default position." ImageUrl="~/Images/refresh_btn.png"  runat="server">
                  </asp:ImageButton>
                    <telerik:RadComboBox ID="cmbAction" runat="server" AutoPostBack="True" Skin="WebBlue" Width="190">
                        <Items>
                            <telerik:RadComboBoxItem Value="0" Text="Select Action" />
                            <telerik:RadComboBoxItem Value="1" Text="Order(s) delayed at Yarn Proc." />
                            <telerik:RadComboBoxItem Value="2" Text="Order(s) delayed at Fabric Proc." />
                            <telerik:RadComboBoxItem Value="3" Text="Order(s) delayed at Cutting" />
                             <telerik:RadComboBoxItem Value="4" Text="Order(s) under packing stage" />
                             <telerik:RadComboBoxItem Value="5" Text="Order Released" />
                       </Items>
                    </telerik:RadComboBox>
                 </ContentTemplate>
                 </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                 <asp:UpdatePanel ID="updgMasterOrderForCustomer" UpdateMode="Conditional" runat="server">
                     <ContentTemplate>
                    <telerik:RadGrid ID="dgMasterOrderForCustomer" runat="server" CellSpacing="0" AutoGenerateColumns="False"
                        Skin="WebBlue" AllowFilteringByColumn="True" AllowPaging="True" AllowSorting="True"
                        GridLines="None" ShowGroupPanel="true" PageSize="50" OnSortCommand="dgMasterOrderForCustomer_SortCommand" ShowStatusBar="true" 
                        StatusBarSettings-ReadyText="Loading" Width="930px" OnPageIndexChanged="dgMasterOrderForCustomer_PageIndexChanged">
                       <ClientSettings AllowDragToGroup="True">
                        </ClientSettings>
                        <AlternatingItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" />
                        <GroupingSettings CaseSensitive="false"></GroupingSettings>
                        <MasterTableView ShowFooter="True" TableLayout="Auto">
                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                            </ExpandCollapseColumn>
                          <Columns>
                                <telerik:GridBoundColumn HeaderText="POID" DataField="POID" Display="false" AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                              
                              <telerik:GridBoundColumn HeaderText="Supplier" DataField="VenderName" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Merchant" DataField="UserName" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Product Categories" DataField="ProductCategories"
                                    GroupByExpression="ProductCategories ProductCategories group By ProductCategories"
                                    UniqueName="ProductCategories" AllowFiltering="true" ShowFilterIcon="false" FilterDelay="2000"
                                    AndCurrentFilterFunction="StartsWith" FilterControlWidth="50px">
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Product Group" DataField="ProductGroup" UniqueName="ProductGroup"
                                    GroupByExpression="ProductGroup ProductGroup Group By ProductGroup" AllowFiltering="true"
                                    ShowFilterIcon="false" FilterDelay="2000" AndCurrentFilterFunction="StartsWith"
                                    FilterControlWidth="40px">
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                               
  <telerik:GridTemplateColumn  HeaderText="PO No."  AllowFiltering ="false">
                                    <itemstyle horizontalalign="Left" />
                                      <HeaderStyle Width="5%" HorizontalAlign="Center" Font-Size="Smaller"/>
									<ITEMTEMPLATE>
 <a   href="javascript:openPopup('PurchaseOrderPreviewPopup.aspx?lPOID=<%# Eval("POID") %>')">  <%# Eval("PONO") %> </a>									
									 </ITEMTEMPLATE>
                                    <headerstyle width="10%" />
								</telerik:GridTemplateColumn > 
                                <telerik:GridBoundColumn HeaderText="Placement" DataField="PlacementDate" AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="PO Qty" DataField="POQuantity" AllowFiltering="false"  DataFormatString="{0:#,##0;(#,##0);0}" DataType="System.Decimal" Aggregate="Sum" FooterText=" " FooterStyle-Font-Bold="true" FooterStyle-Font-Names="Calibri">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                 
                                <telerik:GridBoundColumn HeaderText="Value" DataField="BookedValue" AllowFiltering="false" >
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="10%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn HeaderText="Shipment" DataField="Shipmentdate" AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn HeaderText="Revised" DataField="Revised" AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="WIP Status" DataField="WIPStatus" AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
   <telerik:GridTemplateColumn  HeaderText="WIP Detail"  AllowFiltering ="false">
                                    <itemstyle horizontalalign="Left" />
                                      <HeaderStyle Width="5%" HorizontalAlign="Center" Font-Size="Smaller"/>
									<ITEMTEMPLATE>
 <a   href="javascript:openPopupD('ProductionTracking.aspx?lPOID=<%# Eval("POID") %>')">
     <asp:Image ID="Image2" ImageUrl="~/Images/Finishing_new.png" runat="server" />
    </a>									
									 </ITEMTEMPLATE>
                                    <headerstyle width="10%" />
								</telerik:GridTemplateColumn > 
                            </Columns>
                              <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                            <PagerStyle PageSizeControlType="RadComboBox" AlwaysVisible="true">
                            </PagerStyle>
                        </MasterTableView>
                        <StatusBarSettings ReadyText="Loading"></StatusBarSettings>
                        <FilterItemStyle Font-Size="XX-Small" />
                        <GroupingSettings ShowUnGroupButton="true" />
                        <HeaderStyle Font-Names="Microsoft Sans Serif" />
                        <ItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" Wrap="False" />
                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                        <ClientSettings Scrolling-ScrollHeight="800px" EnableRowHoverStyle="true" Scrolling-AllowScroll="True">
                            <Scrolling AllowScroll="true" EnableVirtualScrollPaging="false" />
                            <Selecting AllowRowSelect="True" />
                        </ClientSettings>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                    </telerik:RadGrid>
                         </ContentTemplate>
                 </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
    <%-- Script For Loading Panel  --%>
    <script language="javascript" type="text/javascript">
        function openPopup(strOpen) {
            //alert(strOpen);
            open(strOpen, "Info", "left=12, top=30, height=600, width=980, status=no , resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no");
        }
        function openPopupD(strOpen) {
            //alert(strOpen);
            open(strOpen, "Info", "left=92, top=70, height=550, width=400, status=no , resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no");
        }
        function onRequestStart(sender, arguments) {

            grayOut(true, "")
        }
        function onResponseEnd(sender, arguments) {

            grayOut(false, "")
        }

        function grayOut(vis, options) {
            var optionsoptions = options || {};
            var zindex = options.zindex || 50;
            var opacity = options.opacity || 70;
            var opaque = (opacity / 100);
            //Setting the color   
            var bgcolor = options.bgcolor || 'White';
            var dark = document.getElementById('darkenScreenObject');
            if (!dark) {
                // The dark layer doesn't exist, it's never been created.  So we'll     
                // create it here and apply some basic styles.      
                var tbody = document.getElementsByTagName("body")[0];
                var tnode = document.createElement('div');
                tnode.style.position = 'absolute';
                tnode.style.top = '0px';
                tnode.style.left = '0px';
                tnode.style.overflow = 'hidden';
                tnode.style.display = 'none';
                tnode.id = 'darkenScreenObject';
                tbody.appendChild(tnode);
                dark = document.getElementById('darkenScreenObject');
            }

            if (vis) {
                var pageWidth = '100%';
                var pageHeight = '100%';
                dark.style.opacity = opaque;
                dark.style.MozOpacity = opaque;
                dark.style.filter = 'alpha(opacity=' + opacity + ')';
                dark.style.zIndex = zindex;
                dark.style.backgroundColor = bgcolor;
                dark.style.width = pageWidth;
                dark.style.height = pageHeight;
                dark.style.display = 'block';
            }
            else {
                dark.style.display = 'none';
            }
        }   
    </script>
    <%-- Script End --%>
</asp:Content>
