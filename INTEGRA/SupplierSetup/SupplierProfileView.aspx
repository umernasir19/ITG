<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeBehind="SupplierProfileView.aspx.vb" Inherits="Integra.SupplierProfileView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%--<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    </telerik:RadCodeBlock>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="dgSupplier">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="dgSupplier" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>--%>
     <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" EnableAJAX="true" runat="server">
        <ClientEvents OnRequestStart="onRequestStart" OnResponseEnd="onResponseEnd" />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="dgSupplier">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="dgSupplier" LoadingPanelID="RadAjaxLoadingPanel1" />
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
                $find('<%=dgSupplier.ClientID %>').get_masterTableView().showFilterItem();
            }
            function hideFilterItem() {
                $find('<%=dgSupplier.ClientID %>').get_masterTableView().hideFilterItem();
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

    
                  <table width="100%">
                  <tr>
                  <td align="right">
                     <telerik:RadButton ID="RadButton1" runat="server" Skin="WebBlue"  Text="Supplier Profile"> 
                            </telerik:RadButton>
                  </td>
                  </tr>
                  <tr>
                  <td>
                   <telerik:RadGrid ID="dgSupplier" runat="server" AllowPaging="True" AllowSorting="True"
                            AllowFilteringByColumn="true"  CellSpacing="0" GridLines="Horizontal" AutoGenerateColumns="False"
                            Skin="WebBlue" PageSize="200" OnSortCommand="dgSupplier_SortCommand"
                        OnPageIndexChanged="dgSupplier_PageIndexChanged" ShowStatusBar="True"
                        StatusBarSettings-ReadyText="Loading">
                        <ClientSettings AllowDragToGroup="True">
                        </ClientSettings>
                        <AlternatingItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" />
                        <GroupingSettings CaseSensitive="false"></GroupingSettings>
                        <MasterTableView AutoGenerateColumns="false" AllowFilteringByColumn="True" ShowFooter="True"
                            TableLayout="Auto" DataKeyNames="VenderLibraryID" GroupLoadMode="Client">
                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                            </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%"
                                        HeaderText="ID" SortExpression="VenderLibraryID" DataField="VenderLibraryID" Display="false">
                                        <HeaderStyle Width="5%"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn DataField="VenderName" HeaderText="Name" UniqueName="VenderName"   AllowFiltering="true"
                                    FilterControlWidth="80px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="lnkEdit" Font-Underline ="false" Text='<%#Eval("VenderName") %>' Enabled="true" NavigateUrl='<%# "SupplierProfile.aspx?lVenderLibraryID=" &amp; DataBinder.Eval(Container.DataItem,"VenderLibraryID")%>'
                                                runat="server"></asp:HyperLink>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                     <telerik:GridBoundColumn DataField="VenderCode" HeaderText="Supplier Code" UniqueName="VenderCode" FilterControlWidth="80px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false" AllowFiltering="true" >
                                    </telerik:GridBoundColumn>
                                     <telerik:GridBoundColumn DataField="SupplierCategoryName" HeaderText="Supplier Category" UniqueName="SupplierCategoryName"   FilterControlWidth="80px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false" AllowFiltering="true" >
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="City" HeaderText="City" UniqueName="City" ShowFilterIcon="false" AllowFiltering="false" >
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PhoneNumber" HeaderText="Phone No" UniqueName="PhoneNumber"     ShowFilterIcon="false" AllowFiltering="false" >
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn HeaderText="Certificate"  ShowFilterIcon="false" AllowFiltering="false" Display="false" >
                                    <ItemTemplate>
                                        <asp:DropDownList ID="cmbCertificate" runat="server" Width="170">
                                        </asp:DropDownList>
                                        <asp:Label ID="lblCertificate" runat="server" ></asp:Label>
                                    </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                
                                </Columns>
                                <NestedViewTemplate>
                                    <div class="carBackground">
                                       
                                        <div style="float: right; width: 50%">
                                            <div class="carTitle">
                                                <%# Eval("VenderName")%>
                                                <%# Eval("City")%>
                                            </div>
                                            <hr class="lineSeparator" />
                                            <table width="100%" class="carInfo">
                                                <tr>
                                                    <td>
                                                        <strong>Supplier Code:</strong>
                                                        <%# Eval("VenderCode")%>
                                                    </td>
                                                    <tr>
                                                        <td>
                                                            <strong>Address:</strong>
                                                            <%# Eval("Address1")%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <strong></strong>
                                                            <%# Eval("Address2")%>
                                                        </td>
                                                    </tr>
                                            </table>
                                        </div>
                                        <div style="clear: both">
                                        </div>
                                    </div>
                                </NestedViewTemplate>
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