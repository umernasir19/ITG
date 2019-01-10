<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeBehind="MasterOrderDetailsForMerchandisers.aspx.vb" Inherits="Integra.MasterOrderDetailsForMerchandisers" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" EnableAJAX="true" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
        <ClientEvents OnRequestStart="onRequestStart" OnResponseEnd="onResponseEnd" />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="dgMasterOrderForSupplyChain">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="dgMasterOrderForSupplyChain" />
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
                $find('<%=dgMasterOrderForSupplyChain.ClientID %>').get_masterTableView().showFilterItem();
            }
            function hideFilterItem() {
                $find('<%=dgMasterOrderForSupplyChain.ClientID %>').get_masterTableView().hideFilterItem();
            }        
        </script>
    </telerik:RadCodeBlock>
    <div>
        <label for="RadioButtonList1">
            Show filtering item</label>
        <asp:RadioButtonList runat="server" ID="RadioButtonList1" RepeatDirection="Horizontal">
            <asp:ListItem Text="Yes" Selected="True" onclick="showFilterItem()"></asp:ListItem>
            <asp:ListItem Text="No" onclick="hideFilterItem()"></asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <div>
        <table style="width: 100%;">
            <tr>
                <td align="right">
                        <asp:UpdatePanel ID="upcmbAction" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                    <telerik:RadComboBox ID="cmbAction" runat="server" AutoPostBack="True" Skin="WebBlue">
                        <Items>
                            <telerik:RadComboBoxItem Value="0" Text="Select Action" />
                            <telerik:RadComboBoxItem Value="1" Text="View Purchase Order" />
                            <telerik:RadComboBoxItem Value="2" Text="Download Original PO" />
                            <telerik:RadComboBoxItem Value="3" Text="View Milestone" />
                        </Items>
                    </telerik:RadComboBox>
                        </ContentTemplate>
                   </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <telerik:RadGrid ID="dgMasterOrderForSupplyChain" runat="server" CellSpacing="0"
                        AutoGenerateColumns="False" Skin="WebBlue" AllowFilteringByColumn="True" AllowPaging="True"
                        GridLines="None" AllowSorting="true" ShowGroupPanel="True" PageSize="15" OnSortCommand="dgMasterOrderForSupplyChain_SortCommand" OnPageIndexChanged="dgMasterOrderForSupplyChain_PageIndexChanged" ShowStatusBar="True" StatusBarSettings-ReadyText="Loading"
                        Height="623px" Width="930px">
                        <ClientSettings AllowDragToGroup="True">
                        </ClientSettings>
                        <GroupingSettings CaseSensitive="false"></GroupingSettings>
                        <AlternatingItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" />
                        <MasterTableView AutoGenerateColumns="false" AllowFilteringByColumn="True" ShowFooter="True"
                            TableLayout="Auto" DataKeyNames="POID" GroupLoadMode="Client">
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
                                <telerik:GridBoundColumn HeaderText="PODetailID" DataField="PODetailID" Display="false"
                                    AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="BusinessQuarter" Groupable="true" GroupByExpression="BusinessQuarter BusinessQuarter Group by BusinessQuarter"
                                    HeaderText="Quarter" UniqueName="BusinessQuarter" AutoPostBackOnFilter="false"
                                    AllowFiltering="true" ShowFilterIcon="false" FilterDelay="2000" AndCurrentFilterFunction="StartsWith"
                                    FilterControlWidth="40px">
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Month" GroupByExpression="ShipMonth ShipMonth Group by ShipMonth"
                                    DataField="ShipMonth" UniqueName="ShipMonth" AllowFiltering="true" ShowFilterIcon="false"
                                    FilterDelay="2000" AndCurrentFilterFunction="StartsWith" FilterControlWidth="30px">
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Week" DataField="ShipWeek" GroupByExpression="ShipWeek ShipWeek Group by ShipWeek"
                                    UniqueName="ShipWeek" AllowFiltering="true" ShowFilterIcon="false" FilterDelay="2000"
                                    AndCurrentFilterFunction="StartsWith" FilterControlWidth="40px">
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Customer" DataField="CustomerName" GroupByExpression="CustomerName CustomerName Group By CustomerName"
                                    UniqueName="CustomerName" AllowFiltering="true" ShowFilterIcon="false" FilterDelay="3000"
                                    AndCurrentFilterFunction="StartsWith" FilterControlWidth="50px">
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Supplier" DataField="VenderName" UniqueName="VenderName"
                                    GroupByExpression="VenderName VenderName Group By VenderName" AllowFiltering="true"
                                    ShowFilterIcon="false" FilterDelay="3000" AndCurrentFilterFunction="StartsWith"
                                    FilterControlWidth="40px">
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="ECP" DataField="ECPDivistion" UniqueName="ECPDivistion"
                                    GroupByExpression="ECPDivistion ECPDivistion Group By ECPDivistion" AllowFiltering="true"
                                    ShowFilterIcon="false" FilterDelay="3000" AndCurrentFilterFunction="StartsWith"
                                    FilterControlWidth="40px">
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Merchant" DataField="UserName" UniqueName="UserName"
                                    GroupByExpression="UserName UserName Group By UserName" AllowFiltering="true"
                                    ShowFilterIcon="false" FilterDelay="3000" AndCurrentFilterFunction="StartsWith"
                                    FilterControlWidth="50px">
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Season" DataField="Season" UniqueName="Season"
                                    AllowFiltering="true" GroupByExpression="Season Season Group By Season" ShowFilterIcon="false"
                                    FilterDelay="2000" AndCurrentFilterFunction="StartsWith" FilterControlWidth="30px">
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Dept." UniqueName="EKNumber" DataField="EKNumber"
                                    GroupByExpression="EKNumber EKNumber Group By EKNumber" AllowFiltering="true"
                                    ShowFilterIcon="false" FilterDelay="2000" AndCurrentFilterFunction="StartsWith"
                                    FilterControlWidth="30px">
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Left" />
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
                                <telerik:GridBoundColumn HeaderText="Composition" DataField="Composition" UniqueName="Composition"
                                    GroupByExpression="Composition Composition Group By Composition" AllowFiltering="true"
                                    ShowFilterIcon="false" FilterDelay="2000" AndCurrentFilterFunction="StartsWith"
                                    FilterControlWidth="70px">
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Style" DataField="StyleNo" UniqueName="StyleNo"
                                    AllowFiltering="true" GroupByExpression="StyleNo StyleNo Group By StyleNo" ShowFilterIcon="false"
                                    FilterDelay="2000" AndCurrentFilterFunction="StartsWith" FilterControlWidth="50px">
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="PO No." DataField="PONO" UniqueName="PONO" GroupByExpression="PONO PONO Group By PONO"
                                    AllowFiltering="true" ShowFilterIcon="false" FilterDelay="2000" AndCurrentFilterFunction="StartsWith"
                                    FilterControlWidth="50px">
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Placement" DataField="PlacementDate" GroupByExpression="PlacementDate PlacementDate Group by PlacementDate"
                                    UniqueName="PlacementDate" AllowFiltering="false">
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Article" UniqueName="Article" DataField="Article"
                                    GroupByExpression="Article Article Group By Article" AllowFiltering="true" ShowFilterIcon="false"
                                    FilterDelay="2000" AndCurrentFilterFunction="StartsWith" FilterControlWidth="40px">
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Colorway" DataField="Colorway" UniqueName="Colorway"
                                    GroupByExpression="Colorway Colorway Group By Colorway" AllowFiltering="false">
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Size" DataField="Size" UniqueName="Size" GroupByExpression="Size Size Group By Size"
                                    AllowFiltering="false">
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Unit Price" DataField="Rate" UniqueName="Rate" Aggregate="Avg" FooterAggregateFormatString="{0:###.##}" FooterStyle-Font-Bold="true" FooterStyle-Font-Names="Calibri" FooterText="Avg."
                                    GroupByExpression="Rate Rate Group By Rate" AllowFiltering="false">
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Qty" DataField="ItemQty" GroupByExpression="ItemQty ItemQty Group By ItemQty" Aggregate="Sum" FooterText=" " DataFormatString="{0:#,##0;(#,##0);0}" DataType="System.Decimal" FooterStyle-Font-Bold="true" FooterStyle-Font-Names="Calibri"
                                    UniqueName="ItemQty" AllowFiltering="true" ShowFilterIcon="false" FilterDelay="2000"
                                    AndCurrentFilterFunction="StartsWith" FilterControlWidth="40px">
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Item Value" DataField="ItemValue" UniqueName="ItemValue"
                                    GroupByExpression="ItemValue ItemValue Group By ItemValue" AllowFiltering="false">
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Shipment" DataField="ShipmentDate" GroupByExpression="ShipmentDate ShipmentDate Group By ShipmentDate"
                                    UniqueName="ShipmentDate" AllowFiltering="true" ShowFilterIcon="false" FilterDelay="2000"
                                    AndCurrentFilterFunction="StartsWith" FilterControlWidth="60px">
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Revised" DataField="Revised" GroupByExpression="Revised Revised Group By Revised"
                                    UniqueName="Revised" AllowFiltering="true" ShowFilterIcon="false" FilterDelay="2000"
                                    AndCurrentFilterFunction="StartsWith" FilterControlWidth="60px">
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Inspected" DataField="InspectedQty" UniqueName="InspectedQty" Aggregate="Sum" FooterText=" " DataFormatString="{0:#,##0;(#,##0);0}" DataType="System.Decimal" FooterStyle-Font-Bold="true" FooterStyle-Font-Names="Calibri"
                                    GroupByExpression="InspectedQty InspectedQty Group by InspectedQty" AllowFiltering="false">
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                  <telerik:GridBoundColumn HeaderText="Shipped Qty" DataField="ShippedQty" GroupByExpression="ShippedQty ShippedQty Group By ShippedQty"
                                    UniqueName="ShippedQty" AllowFiltering="true" ShowFilterIcon="false" FilterDelay="2000" Aggregate="Sum" FooterText=" " FooterStyle-Font-Bold="true" DataFormatString="{0:#,##0;(#,##0);0}" DataType="System.Decimal" FooterStyle-Font-Names="Calibri"
                                    AndCurrentFilterFunction="StartsWith" FilterControlWidth="50px">
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn HeaderText="Cancel Qty" DataField="POCancelQty" UniqueName="POCancelQty" Aggregate="Sum" FooterText=" " FooterStyle-Font-Bold="true" FooterStyle-Font-Names="Calibri"
                                    GroupByExpression="POCancelQty POCancelQty Group By POCancelQty" AllowFiltering="false">
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="ClaimQty" DataField="ClaimQty" UniqueName="ClaimQty" Aggregate="Sum" FooterText=" " FooterStyle-Font-Bold="true" FooterStyle-Font-Names="Calibri"
                                    GroupByExpression="ClaimQty ClaimQty Group By ClaimQty" AllowFiltering="false">
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Status" DataField="Status" GroupByExpression="Status Status Group By Status"
                                    UniqueName="Status" AllowFiltering="true" ShowFilterIcon="false" FilterDelay="2000"
                                    AndCurrentFilterFunction="StartsWith" FilterControlWidth="40px">
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Forecast(W)" DataField="ForecastWP" GroupByExpression="ForecastWP ForecastWP Group By ForecastWP"
                                    UniqueName="ForecastWp" AllowFiltering="true" ShowFilterIcon="false" FilterDelay="2000"
                                    AndCurrentFilterFunction="StartsWith" FilterControlWidth="50px">
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Actual(W)" DataField="ActualWp" GroupByExpression="ActualWp ActualWp Group By ActualWp"
                                    UniqueName="ActualWp" AllowFiltering="true" ShowFilterIcon="false" FilterDelay="2000"
                                    AndCurrentFilterFunction="StartsWith" FilterControlWidth="50px">
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Splitted" DataField="Splitted" GroupByExpression="Splitted Splitted Group By Splitted"
                                    UniqueName="Splitted" AllowFiltering="true" ShowFilterIcon="false" FilterDelay="2000"
                                    AndCurrentFilterFunction="StartsWith" FilterControlWidth="50px">
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                 <telerik:GridBoundColumn HeaderText="Final Status" DataField="FinalStatus" GroupByExpression="FinalStatus FinalStatus Group By FinalStatus"
                                    UniqueName="FinalStatus" AllowFiltering="true" ShowFilterIcon="false" FilterDelay="2000"
                                    AndCurrentFilterFunction="StartsWith" FilterControlWidth="50px">
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="Select" UniqueName="Select" AllowFiltering="false">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelect" runat="server"></asp:CheckBox>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                            <PagerStyle PageSizeControlType="RadComboBox" ></PagerStyle>
                        </MasterTableView>
                        <ClientSettings Scrolling-ScrollHeight="1200px" EnableRowHoverStyle="true" Scrolling-AllowScroll="True">
                            <Selecting AllowRowSelect="True" />
                        </ClientSettings>
                        <GroupingSettings ShowUnGroupButton="true" />
                        <HeaderStyle Font-Names="Microsoft Sans Serif" />
                        <ItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" Wrap="False" />
                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                        <StatusBarSettings ReadyText="Loading"></StatusBarSettings>
                        <FilterMenu EnableImageSprites="False" Skin="WebBlue">
                        </FilterMenu>
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
    </div>
    <script type="text/javascript">
        function openWin() {
            radopen("StyleView.aspx", "RadWindow1");
        }
    </script>
    <%-- Script For Loading Panel  --%>
    <script language="javascript" type="text/javascript">
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