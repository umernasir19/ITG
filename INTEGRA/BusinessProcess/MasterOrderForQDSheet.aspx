<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeBehind="MasterOrderForQDSheet.aspx.vb" Inherits="Integra.MasterOrderForQDSheet" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="dgMasterOrderForQD">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="dgMasterOrderForQD" LoadingPanelID="RadAjaxLoadingPanel1" />
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
            function hideFilterItem() {
                $find('<%=dgMasterOrderForQD.ClientID %>').get_masterTableView().hideFilterItem();
            }
            function showFilterItem() {
                $find('<%=dgMasterOrderForQD.ClientID %>').get_masterTableView().showFilterItem();
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
                        <asp:ListItem Text="Yes" Selected="true" onclick="showFilterItem()"></asp:ListItem>
                        <asp:ListItem Text="No" onclick="hideFilterItem()"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td align="right">
                   <asp:UpdatePanel ID="upcmbAction" UpdateMode="Conditional" runat="server">
                     <ContentTemplate>
                    <telerik:RadComboBox ID="cmbAction" runat="server" AutoPostBack="True" Skin="WebBlue">
                        <Items>
                            <telerik:RadComboBoxItem Value="0" Text="Select Action" />
                            <telerik:RadComboBoxItem Value="1" Text="Create Inspection" />
                            <telerik:RadComboBoxItem Value="2" Text="View PO" />
                        </Items>
                    </telerik:RadComboBox>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <telerik:RadGrid ID="dgMasterOrderForQD" runat="server" CellSpacing="0" AutoGenerateColumns="False"
                        Skin="WebBlue" AllowFilteringByColumn="True" AllowPaging="True" AllowSorting="True" ShowFooter="true"
                        GridLines="None" ShowGroupPanel="True" PageSize="15" OnSortCommand="dgMasterOrderForQD_SortCommand" ShowStatusBar="true" 
                        StatusBarSettings-ReadyText="Loading" Height="615px" Width="930px" OnPageIndexChanged="dgMasterOrderForQD_PageIndexChanged">
                        <ClientSettings AllowDragToGroup="True">
                        <Scrolling AllowScroll="True" ScrollHeight="1200px"></Scrolling>
                        </ClientSettings>
                           <GroupingSettings CaseSensitive="false"></GroupingSettings>
                        <AlternatingItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" />
                        <MasterTableView>
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
                                
                                <telerik:GridBoundColumn HeaderText="Week" DataField="ShipWeek" AllowFiltering="false" Display="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Customer" DataField="CustomerName" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Supplier" DataField="VenderName" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="ECP" DataField="ECPDivistion" AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Merchant" DataField="UserName" AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Season" DataField="Season" AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Dept." DataField="EKNumber"  AllowFiltering="false" >
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Product Group" DataField="ProductGroup" AllowFiltering="false" Visible ="false" >
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Composition" DataField="Composition" AllowFiltering="false"  Visible ="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                       
                     <telerik:GridBoundColumn HeaderText="PO NO." DataField="PONO" AllowFiltering="true"
                                    FilterControlWidth="65px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn> 

                               <%-- <telerik:GridTemplateColumn  HeaderText="PO No."  AllowFiltering ="false">
                                    <itemstyle horizontalalign="Left" />
                                      <HeaderStyle Width="5%" HorizontalAlign="Center" Font-Size="Smaller"/>
									<ITEMTEMPLATE>
                                     <a   href="javascript:openPopup('QualityDepartmentPopup.aspx?lPOID=<%# Eval("POID") %>')">  <%# Eval("PONO") %> </a>									
										 </ITEMTEMPLATE>
                                    <headerstyle width="10%" />
								</telerik:GridTemplateColumn > --%>
                         
                               
                                <telerik:GridBoundColumn HeaderText="Item Qty" DataField="ItemQty" AllowFiltering="false" Aggregate="Sum" FooterText=" " FooterStyle-Font-Bold="true" FooterStyle-Font-Names="Calibri">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                             <telerik:GridBoundColumn HeaderText="Claim Qty" DataField="ClaimQty" AllowFiltering="false" Aggregate="Sum" FooterText=" " FooterStyle-Font-Bold="true" FooterStyle-Font-Names="Calibri">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Shipment Date" DataField="ShipmentDate" AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="WIP Status" DataField="ActualWp" AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Final Pass Qty" DataField="InspectedQty" AllowFiltering="false" Aggregate="Sum" FooterText=" " FooterStyle-Font-Bold="true" FooterStyle-Font-Names="Calibri">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                                               <telerik:GridTemplateColumn HeaderText="Select" UniqueName="Select" AllowFiltering="false">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelected" runat="server"></asp:CheckBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Small" />
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                            <PagerStyle PageSizeControlType="RadComboBox" Mode="NextPrevAndNumeric" AlwaysVisible="true" ></PagerStyle>
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
                        <PagerStyle PageSizeControlType="RadComboBox" Mode="NextPrevAndNumeric" 
                            AlwaysVisible="True" ></PagerStyle>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
    </div>
    <%-- Script For Loading Panel  --%>
    <script language="javascript" type="text/javascript">
        function openPopup(strOpen) 
        {
            //alert(strOpen);
            open(strOpen, "Info", "left=12, top=30, height=600, width=980, status=no , resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no");
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
