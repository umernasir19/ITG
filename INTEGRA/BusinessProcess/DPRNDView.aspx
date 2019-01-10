﻿<%@ Page Title="RND View" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="DPRNDView.aspx.vb" Inherits="Integra.DPRNDView" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" EnableAJAX="true" runat="server">
        <ClientEvents OnRequestStart="onRequestStart" OnResponseEnd="onResponseEnd" />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="dgECPSampling">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="dgECPSampling" LoadingPanelID="RadAjaxLoadingPanel1" />
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
                $find('<%=dgRND.ClientID %>').get_masterTableView().showFilterItem();
            }
            function hideFilterItem() {
                $find('<%=dgRND.ClientID %>').get_masterTableView().hideFilterItem();
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
            <tr>
                <td align="right">
                    <telerik:RadButton ID="btnAddSampling" runat="server" Text="Add RND" Skin="WebBlue">
                    </telerik:RadButton>
                </td>
            </tr>
            <tr>
                <td>
                <div style="width :920PX; overflow :scroll ;">
                    <telerik:RadGrid ID="dgRND" runat="server" CellSpacing="0" AutoGenerateColumns="False"
                        Skin="WebBlue"  AllowFilteringByColumn="True" AllowPaging="True" GridLines="None"
                        ShowGroupPanel="True" PageSize="50" OnSortCommand="dgRND_SortCommand" OnPageIndexChanged="dgRND_PageIndexChanged"
                        ShowStatusBar="True" StatusBarSettings-ReadyText="Loading">
                   <%--      <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                        </MasterTableView>
                        <ClientSettings EnableRowHoverStyle="false" EnablePostBackOnRowClick="false">
                            <Selecting AllowRowSelect="true" EnableDragToSelectRows="true" />
                        </ClientSettings>
                        <HeaderStyle Font-Names="Microsoft Sans Serif" />
                        <ItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" />
                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>--%>
                        <ClientSettings AllowDragToGroup="True">
                        </ClientSettings>
                        <AlternatingItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" />
                        <GroupingSettings CaseSensitive="false"></GroupingSettings>
                        <MasterTableView AutoGenerateColumns="false" AllowFilteringByColumn="True" ShowFooter="True"
                            TableLayout="Auto" DataKeyNames="DPRNDID" GroupLoadMode="Client">
                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                            </ExpandCollapseColumn>
                            
                            <Columns>
                                <telerik:GridBoundColumn HeaderText="DPRNDID" DataField="DPRNDID" Display="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>

                                 <telerik:GridTemplateColumn ShowFilterIcon="false" HeaderText="S.No" AllowFiltering="false" >
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="1%" HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <%# Container.DataSetIndex+1 %>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>


                                <telerik:GridBoundColumn HeaderText="Program Date" DataField="CreatDatee" UniqueName="CreatDatee" AllowFiltering="true"
                                    FilterControlWidth="70px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                     <telerik:GridBoundColumn HeaderText="Program Time" Visible ="true"  DataField="CreationTime" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="10%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                             
                              <telerik:GridBoundColumn HeaderText="Con Date" UniqueName="ConDate" DataField="ConDate" AllowFiltering="true"
                                    FilterControlWidth="30px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="1000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="3%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                              

                               

                                <telerik:GridBoundColumn HeaderText="Buyer" DataField="Buyer" AllowFiltering="true"
                                    FilterControlWidth="30px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Style" DataField="Style" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="10%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="DAL No" DataField="DalNo" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="10%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Supplier Ref. No." DataField="SupplierArtNo"
                                    AllowFiltering="true" FilterControlWidth="50px" AutoPostBackOnFilter="false"
                                    CurrentFilterFunction="StartsWith" FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="10%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Fabric Quality" DataField="FabricQuality" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="20%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Quantity" DataField="Quantity" AllowFiltering="false"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="3%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="AllowToGGT" DataField="AllowToGGT" Display="false"
                                    AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="1%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Allow To GGT" DataField="Status" ItemStyle-Font-Bold="true"
                                    ItemStyle-Font-Size="Larger" ItemStyle-ForeColor="Blue" Display="true" AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="4%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Status" DataField="GGTStatuss" ItemStyle-Font-Bold="true"
                                    ItemStyle-Font-Size="Larger" ItemStyle-ForeColor="Blue" Display="true" AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="4%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Consum" DataField="Consumption" ItemStyle-Font-Bold="true"
                                    ItemStyle-Font-Size="Larger" ItemStyle-ForeColor="Red" Display="true" AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="View" AllowFiltering="false" Display="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="3%" HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnView" runat="server" CommandName="Update" HeaderText="View"
                                            Text="Edit"></asp:LinkButton>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="View" UniqueName="View" AllowFiltering="false"
                                    Display="true">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="lnkEdit" Font-Underline="false" Text="Update" Enabled="true" NavigateUrl='<%# "DPRND.aspx?lDPRNDID=" &amp; DataBinder.Eval(Container.DataItem,"DPRNDID")%>'
                                            runat="server"></asp:HyperLink>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%"
                                    AllowFiltering="false" HeaderText="PDF" Visible="true">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="lnkPDF" ToolTip="Click here to download PDF" ImageUrl="~/Images/pdfIcon.png"
                                            CommandName="PDF" runat="server"></asp:ImageButton>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridButtonColumn UniqueName="DeleteColumn" HeaderText="Delete" Text="" CommandName="Delete"
                                    ConfirmTextFormatString="Are You Sure You want to Delete Record" HeaderStyle-Width="5%"
                                    ButtonType="ImageButton">
                                </telerik:GridButtonColumn>

                                      <telerik:GridBoundColumn HeaderText="DigitalSignature" DataField="DigitalSignature" ItemStyle-Font-Bold="true"
                                    ItemStyle-Font-Size="Larger" ItemStyle-ForeColor="Red" Display="false" AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>

                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                        </MasterTableView>
                        <ClientSettings EnableRowHoverStyle="false" EnablePostBackOnRowClick="false">
                            <Selecting AllowRowSelect="true" EnableDragToSelectRows="true" />
                        </ClientSettings>
                        <HeaderStyle Font-Names="Microsoft Sans Serif" />
                        <ItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" />
                        
                        <PagerStyle PageSizeControlType="RadComboBox" Position ="TopAndBottom"  ></PagerStyle>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                    </telerik:RadGrid></div> 
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
