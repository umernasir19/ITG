﻿<%@ Page Language="vb"  MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeBehind="MasterOrderForCelio.aspx.vb" Inherits="Integra.MasterOrderForCelio" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" EnableAJAX="true" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
        <ClientEvents OnRequestStart="onRequestStart" OnResponseEnd="onResponseEnd" />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="dgMasterOrderForMerchandiser">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="dgMasterOrderForMerchandiser" />
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
                $find('<%=dgMasterOrderForMerchandiser.ClientID %>').get_masterTableView().showFilterItem();
            }
            function hideFilterItem() {
                $find('<%=dgMasterOrderForMerchandiser.ClientID %>').get_masterTableView().hideFilterItem();
            }        
        </script>
    </telerik:RadCodeBlock>
    <div>
        <table style="width: 100%;">
            <tr>
                <td align="left">
                    <label for="RadioButtonList1">
                        Show filtering item</label>
                    <asp:RadioButtonList runat="server" ID="RadioButtonList1" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Yes" Selected="True" onclick="showFilterItem()"></asp:ListItem>
                        <asp:ListItem Text="No" onclick="hideFilterItem()"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td align="right">
                      <asp:UpdatePanel ID="upcmbAction" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                    <telerik:RadComboBox ID="cmbAction" runat="server" AutoPostBack="True" Skin="WebBlue">
                        <Items>
                            <telerik:RadComboBoxItem Value="0" Text="Select Action" />
                            <telerik:RadComboBoxItem Value="1" Text="Proceed to CP" />
                        </Items>
                    </telerik:RadComboBox>
                         </ContentTemplate>
                          </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <telerik:RadGrid ID="dgMasterOrderForMerchandiser" runat="server" CellSpacing="0"
                        AutoGenerateColumns="False" Skin="WebBlue" AllowFilteringByColumn="True" AllowPaging="True"
                        AllowSorting="true" GridLines="None" ShowGroupPanel="true" PageSize="15" ShowStatusBar="true"
                        StatusBarSettings-ReadyText="Loading" OnSortCommand="dgMasterOrderForMerchandiser_SortCommand"
                        OnPageIndexChanged="dgMasterOrderForMerchandiser_PageIndexChanged" Height="606px"
                        Width="930px">
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
                                     <telerik:GridBoundColumn HeaderText="Customer" DataField="CustomerName" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="4000" ShowFilterIcon="false"   >
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn HeaderText="Merchant" DataField="Username" FilterControlWidth="50px"
                                    AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith" FilterDelay="4000"
                                    ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Supplier" DataField="VenderName" FilterControlWidth="50px"
                                    AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith" FilterDelay="4000"
                                    ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="LKZ" Display="false" DataField="LKZ" AllowFiltering="false"
                                    FilterControlWidth="30px" AutoPostBackOnFilter="false" CurrentFilterFunction="equalto"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Season" DataField="Season" FilterControlWidth="30px"
                                    AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith" FilterDelay="4000"
                                    ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                             
                                <telerik:GridBoundColumn HeaderText="Shp.Date" AllowFiltering="false" DataField="ShipmentDate"
                                    FilterControlWidth="30px" AutoPostBackOnFilter="false" CurrentFilterFunction="equalto"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Style No" DataField="StyleNo" FilterControlWidth="50px"
                                    AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith" FilterDelay="4000"
                                    ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="PO No" DataField="PONO" FilterControlWidth="50px"
                                    AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith" FilterDelay="4000"
                                    ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                  <telerik:GridBoundColumn HeaderText="Qty" AllowFiltering="false" DataField="ItemQty"  Aggregate="Sum" FooterText=" " DataFormatString="{0:#,##0;(#,##0);0}" DataType="System.Decimal" FooterStyle-Font-Bold="true" FooterStyle-Font-Names="Calibri"
                                    FilterControlWidth="30px" AutoPostBackOnFilter="false" CurrentFilterFunction="equalto"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                              
                          
                                <telerik:GridBoundColumn HeaderText="Revised" AllowFiltering="false" DataField="LastRev"
                                    FilterControlWidth="30px" AutoPostBackOnFilter="false" CurrentFilterFunction="equalto"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                              
                                 <telerik:GridTemplateColumn HeaderText="Select" AllowFiltering="false">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelected" AutoPostBack="false" runat="server" />
                            		  </ItemTemplate>
                                         <HeaderStyle Width="2%" HorizontalAlign="center" Font-Size="Smaller" />
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                            <PagerStyle PageSizeControlType="RadComboBox" AlwaysVisible="true"></PagerStyle>
                        </MasterTableView>
                        <StatusBarSettings ReadyText="Loading"></StatusBarSettings>
                        <FilterItemStyle Font-Size="XX-Small" />
                        <GroupingSettings ShowUnGroupButton="true" />
                        <HeaderStyle Font-Names="Microsoft Sans Serif" />
                        <ItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" Wrap="False" />
                        <ClientSettings Scrolling-ScrollHeight="1200px" EnableRowHoverStyle="true" Scrolling-AllowScroll="True">
                            <Scrolling AllowScroll="true" EnableVirtualScrollPaging="false" />
                            <Selecting AllowRowSelect="True" />
                        </ClientSettings>
                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
    </div>
    <%-- Script For Loading Panel  --%>
    <script language="javascript" type="text/javascript">
        function openPopup(strOpen) {
            //alert(strOpen);
            open(strOpen, "Info", "left=50, top=30, height=600, width=720, status=no , resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no");
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