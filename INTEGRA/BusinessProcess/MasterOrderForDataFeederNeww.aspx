﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="MasterOrderForDataFeederNeww.aspx.vb" Inherits="Integra.MasterOrderForDataFeederNeww" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" EnableAJAX="true" runat="server">
        <ClientEvents OnRequestStart="onRequestStart" OnResponseEnd="onResponseEnd" />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="dgMasterOrderForDataFeeder">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="dgMasterOrderForDataFeeder" LoadingPanelID="RadAjaxLoadingPanel1" />
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
                $find('<%=dgMasterOrderForDataFeeder.ClientID %>').get_masterTableView().showFilterItem();
            }
            function hideFilterItem() {
                $find('<%=dgMasterOrderForDataFeeder.ClientID %>').get_masterTableView().hideFilterItem();
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
        <table width="100%">
            <tr style="height: 34px">
                <td style ="width: 70px;">
                   <b>PO No.</b> 
                </td>
                <td>
                    <asp:TextBox ID="txtPONO" Style="margin-left: 0px; width: 209px;border-radius: 5px; height: 20px;" runat="server"
                        AutoPostBack="true" autocomplete="off" CssClass ="text_box"></asp:TextBox>
                    <asp:Label ID="lblpoid" runat="server" Text="0" Visible="false"></asp:Label>
                    <cc1:autocompleteextender runat="server" id="autoComplete1" targetcontrolid="txtPONO"
                        servicepath="~/AutoComplete.asmx" servicemethod="GetCompletionList" minimumprefixlength="1"
                        completioninterval="10" enablecaching="true" completionsetcount="12" contextkey="INSPPO" />
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table width="100%">
            <tr>
                <td align="right">
                    <telerik:RadButton ID="btnAddOrder" runat="server" Text="Place a PO" Skin="WebBlue">
                    </telerik:RadButton>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <telerik:RadGrid ID="dgMasterOrderForDataFeeder" runat="server" CellSpacing="0" AutoGenerateColumns="False"
                        Skin="WebBlue" AllowFilteringByColumn="True" AllowPaging="True" GridLines="None"
                        AllowSorting="true" ShowGroupPanel="True" PageSize="50" OnSortCommand="dgMasterOrderForDataFeeder_SortCommand"
                        OnPageIndexChanged="dgMasterOrderForDataFeeder_PageIndexChanged" ShowStatusBar="True"
                        StatusBarSettings-ReadyText="Loading">
                        <ClientSettings AllowDragToGroup="True">
                        </ClientSettings>
                        <AlternatingItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" />
                        <GroupingSettings CaseSensitive="false"></GroupingSettings>
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
                                <telerik:GridBoundColumn HeaderText="Entry Date" DataField="CreationDate" AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Customer" DataField="CustomerName" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Dept" DataField="EKNumber" AllowFiltering="false"
                                    Display="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Supplier" DataField="VenderName" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="LKZ" DataField="LKZ" AllowFiltering="false"
                                    Display="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="ECP" DataField="ECPDivistion" AllowFiltering="false"
                                    Display="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Merchant" DataField="UserName" AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Season" DataField="Season" AllowFiltering="false"
                                    Display="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Destination" DataField="Destination" AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="PO No." DataField="PONO" AllowFiltering="true"
                                    FilterControlWidth="65px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="PO Qty" DataField="POQuantity" DataFormatString="{0:#,##0;(#,##0);0}"
                                    DataType="System.Decimal" AllowFiltering="false" Aggregate="Sum" FooterText=" "
                                    FooterStyle-Font-Bold="true" FooterStyle-Font-Names="Calibri">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Tolerance" DataField="Tolerance" AllowFiltering="false"
                                    Display="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="PO Value" DataField="POValue" AllowFiltering="false"
                                    Display="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Placement" DataField="PlacementDate" AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Shipment" DataField="ShipmentDate" AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Revised" DataField="LastRev" AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="Action" AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Center" Font-Size="Smaller" />
                                    <ItemTemplate>
                                        <asp:HyperLink ID="lnkEdit" runat="server" NavigateUrl='<%# "POEntryNew.aspx?lPOId=" &amp; DataBinder.Eval(Container.DataItem,"POId")%>'
                                            Enabled="true" __designer:wfdid="w1">
										Edit
                                        </asp:HyperLink>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Action" AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Center" Font-Size="Smaller" />
                                    <ItemTemplate>
                                        <asp:HyperLink ID="lnkCopy" runat="server" NavigateUrl='<%# "POEntryNew.aspx?lPOId=" &amp; DataBinder.Eval(Container.DataItem,"POId")&"&Type=Copy"%>'
                                            Enabled="true" __designer:wfdid="w1">
										Copy
                                        </asp:HyperLink>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Milestone" AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Center" Font-Size="Smaller" />
                                    <ItemTemplate>
                                        <asp:HyperLink ID="lnkTnaEditt" runat="server" NavigateUrl='<%# "TNAChartView.aspx?POID=" &amp; DataBinder.Eval(Container.DataItem,"POId")%>'
                                            Enabled="true" __designer:wfdid="w1">
										Milestone
                                        </asp:HyperLink>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Customer CP" AllowFiltering="false" Visible="false">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Center" Font-Size="Smaller" />
                                    <ItemTemplate>
                                        <asp:HyperLink ID="lnkcuEdit" runat="server" NavigateUrl='<%# "CPChartViewNew.aspx?POID=" &amp; DataBinder.Eval(Container.DataItem,"POId")%>'
                                            Enabled="true" __designer:wfdid="w1">
										Customer CP
                                        </asp:HyperLink>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                        </MasterTableView>
                        <ClientSettings AllowGroupExpandCollapse="True" EnableRowHoverStyle="true" ReorderColumnsOnClient="True"
                            AllowDragToGroup="True" AllowColumnsReorder="True">
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