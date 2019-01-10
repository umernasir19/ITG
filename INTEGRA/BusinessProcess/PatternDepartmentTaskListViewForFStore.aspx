<%@ Page Title="Pattern Department Task List View" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="PatternDepartmentTaskListViewForFStore.aspx.vb" Inherits="Integra.PatternDepartmentTaskListViewForFStore" %>
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
                    <telerik:RadButton ID="btnAddSampling"  Visible ="true" runat="server" Text="Add Task" Skin="WebBlue">
                    </telerik:RadButton>
                </td>
            </tr>
           <br />
            <tr>
                <td>
                <div style="width :920PX; overflow :scroll ;">
                    <telerik:RadGrid ID="dgRND" runat="server" CellSpacing="0" AutoGenerateColumns="False"
                        Skin="WebBlue"  AllowFilteringByColumn="True" AllowPaging="True" GridLines="None"
                        ShowGroupPanel="True" PageSize="50" OnSortCommand="dgRND_SortCommand" OnPageIndexChanged="dgRND_PageIndexChanged"
                        ShowStatusBar="True" StatusBarSettings-ReadyText="Loading">
                 
                        <ClientSettings AllowDragToGroup="True">
                        </ClientSettings>
                        <AlternatingItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" />
                        <GroupingSettings CaseSensitive="false"></GroupingSettings>
                        <MasterTableView AutoGenerateColumns="false" AllowFilteringByColumn="True" ShowFooter="True"
                            TableLayout="Auto" DataKeyNames="PATTERNDEPARTMENTTASKLISTMstid" GroupLoadMode="Client">
                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                            </ExpandCollapseColumn>
                            
                         <Columns>
                                <telerik:GridBoundColumn HeaderText="PATTERNDEPARTMENTTASKLISTMstid" DataField="PATTERNDEPARTMENTTASKLISTMstid" Display="false" ItemStyle-Font-Bold="true"  ItemStyle-Font-Names ="Calibri" ItemStyle-Font-Size ="Medium" ItemStyle-ForeColor="Blue">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                   <telerik:GridTemplateColumn ShowFilterIcon="false" HeaderText="S.No" AllowFiltering="false" ItemStyle-Font-Bold="true"  ItemStyle-Font-Names ="Calibri" ItemStyle-Font-Size ="Medium" ItemStyle-ForeColor="Blue" >
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="1%" HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <%# Container.DataSetIndex+1 %>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
<telerik:GridBoundColumn HeaderText="Task No" DataField="TaskNo" AllowFiltering="false" ItemStyle-Font-Bold="true"  ItemStyle-Font-Names ="Calibri" ItemStyle-Font-Size ="Medium" ItemStyle-ForeColor="Blue"
                                    
                                    FilterControlWidth="70px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="center" />
                                    <HeaderStyle Width="20%" HorizontalAlign="Center" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>

                                 <telerik:GridBoundColumn HeaderText="Type" DataField="FabricConsumptionType" AllowFiltering="false"
                                    FilterControlWidth="50px" ItemStyle-Font-Bold="true"  ItemStyle-Font-Names ="Calibri" ItemStyle-Font-Size ="Medium" ItemStyle-ForeColor="Blue"
                                    AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="20%" HorizontalAlign="Center" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>


                                <telerik:GridBoundColumn HeaderText="Date" DataField="CreationDate" AllowFiltering="false"
                                    FilterControlWidth="70px" ItemStyle-Font-Bold="true" ItemStyle-Font-Names ="Calibri" ItemStyle-Font-Size ="Medium" ItemStyle-ForeColor="Blue" 
                                      AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="20%" HorizontalAlign="Center" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>



                                <telerik:GridBoundColumn HeaderText="Date Time Stamp" DataField="DateTimeStampp" AllowFiltering="false" Visible ="false" 
                                    FilterControlWidth="70px" ItemStyle-Font-Bold="true"  ItemStyle-Font-Names ="Calibri" ItemStyle-Font-Size ="Medium" ItemStyle-ForeColor="Blue"
                                      AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="20%" HorizontalAlign="Center" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn HeaderText="Priority" DataField="Priority" AllowFiltering="true" Visible ="false" 
                                    FilterControlWidth="50px" ItemStyle-Font-Bold="true"  ItemStyle-Font-Names ="Calibri" ItemStyle-Font-Size ="Medium" ItemStyle-ForeColor="Blue"
                                    AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="20%" HorizontalAlign="Center" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>

                                   <telerik:GridBoundColumn HeaderText="Style" DataField="Style" AllowFiltering="false"
                                    FilterControlWidth="50px" ItemStyle-Font-Bold="true"  ItemStyle-Font-Names ="Calibri"  
                                    ItemStyle-Font-Size="Large" ItemStyle-ForeColor="Blue" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="20%" HorizontalAlign="Center" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>

                                 <telerik:GridBoundColumn HeaderText="Sr No" DataField="SRNO" AllowFiltering="false"
                                    FilterControlWidth="50px" ItemStyle-Font-Bold="true"  ItemStyle-Font-Names ="Calibri"  
                                    ItemStyle-Font-Size="Large" ItemStyle-ForeColor="Blue" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="20%" HorizontalAlign="Center" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                           

                                 <telerik:GridBoundColumn HeaderText="Buyer" DataField="Buyer" AllowFiltering="false"
                                    FilterControlWidth="50px" ItemStyle-Font-Bold="true"  ItemStyle-Font-Names ="Calibri"  
                                    ItemStyle-Font-Size="Large" ItemStyle-ForeColor="Blue" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="20%" HorizontalAlign="Center" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>

                                    <telerik:GridBoundColumn HeaderText="User" DataField="UserName" AllowFiltering="false"
                                    FilterControlWidth="50px" ItemStyle-Font-Bold="true"  ItemStyle-Font-Names ="Calibri"  
                                    ItemStyle-Font-Size="Large" ItemStyle-ForeColor="Red" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="20%" HorizontalAlign="Center" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>



                                   <telerik:GridTemplateColumn HeaderText="View" UniqueName="View" AllowFiltering="false"
                                        Display="false">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="lnkEdit" Font-Underline="false" Text="Update" Enabled="true" NavigateUrl='<%# "PatternDepartmentTaskListEntry.aspx?lPATTERNDEPARTMENTTASKLISTMstid=" &amp; DataBinder.Eval(Container.DataItem,"PATTERNDEPARTMENTTASKLISTMstid")&"&Status=F"%>'
                                                runat="server" style="font-family :Calibri ; font-size :medium ; color :Green ;" Font-Bold ="true"></asp:HyperLink>
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


