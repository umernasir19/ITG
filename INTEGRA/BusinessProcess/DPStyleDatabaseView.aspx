﻿<%@ Page Title="Style Database View" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="DPStyleDatabaseView.aspx.vb" Inherits="Integra.DPStyleDatabaseView" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



<telerik:RadWindowManager ID="RadWindowManager2" runat="server">
    </telerik:RadWindowManager>
    <telerik:RadAjaxManager ID="RadAjaxManager2" EnableAJAX="true" runat="server">
        <ClientEvents OnRequestStart="onRequestStart" OnResponseEnd="onResponseEnd" />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="dgECPSampling">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="dgECPSampling" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" runat="server" BackgroundPosition="Bottom"
        Width="80%">
        <asp:Image ID="Image2" runat="server" AlternateText="Loading..." ImageUrl="~/Images/loading12.gif" />
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadCodeBlock runat="server" ID="radCodeBlock1">
        <script type="text/javascript">
            function showFilterItem() {
                $find('<%=dgStyleDatabase.ClientID %>').get_masterTableView().showFilterItem();
            }
            function hideFilterItem() {
                $find('<%=dgStyleDatabase.ClientID %>').get_masterTableView().hideFilterItem();
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
                    <telerik:RadButton ID="btnStyleDatabase" runat="server" Text="Add Style" Skin="WebBlue">
                    </telerik:RadButton>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadGrid ID="dgStyleDatabase" runat="server" CellSpacing="0" AutoGenerateColumns="False"
                        Skin="WebBlue" AllowFilteringByColumn="True" AllowPaging="True" GridLines="None"
                        ShowGroupPanel="True" PageSize="50" OnSortCommand="dgStyleDatabase_SortCommand" OnPageIndexChanged="dgStyleDatabase_PageIndexChanged"
                        ShowStatusBar="True" StatusBarSettings-ReadyText="Loading">
                        <ClientSettings AllowDragToGroup="True">
                        </ClientSettings>
                        <AlternatingItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" />
                        <GroupingSettings CaseSensitive="false"></GroupingSettings>
                        <MasterTableView AutoGenerateColumns="false" AllowFilteringByColumn="True" ShowFooter="True"
                            TableLayout="Auto" DataKeyNames="DPStyleDatabaseId" GroupLoadMode="Client">
                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                            </ExpandCollapseColumn>
                           <Columns>
                                <telerik:GridBoundColumn HeaderText="DPStyleDatabaseId" DataField="DPStyleDatabaseId" Display="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Style Date" AllowFiltering="false" DataField="StyleDatee">
                                    <HeaderStyle Width="9%" HorizontalAlign="center" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Style Code" DataField="StyleCode" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="20%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>

                                                  <telerik:GridBoundColumn HeaderText="Style Name" DataField="StyleName" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="20%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn HeaderText="Description" DataField="Description" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="20%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                               
                                                   <telerik:GridBoundColumn HeaderText="Estimated Time Req" DataField="EstimatedTimeReq" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="20%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                                           

                        <telerik:GridTemplateColumn HeaderText="View" UniqueName="View" AllowFiltering="false" Display="True">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lnkEdit" Font-Underline="false" Text="Update" Enabled="true" CommandName="EDIT"
                                        NavigateUrl='<%# "DPStyleDatabase.aspx?DPStyleDatabaseId=" &amp; DataBinder.Eval(Container.DataItem,"DPStyleDatabaseId")%>'
                                        runat="server"></asp:HyperLink>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>


                                   <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="PDF"
                            Visible="true" AllowFiltering="false">
                            <ItemTemplate>
                                <asp:ImageButton ID="lnkPDF" ToolTip="Click here to download PDF" ImageUrl="~/Images/pdfIcon.png"
                                    CommandName="PDF" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>



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

