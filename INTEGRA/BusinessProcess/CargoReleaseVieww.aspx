<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="CargoReleaseVieww.aspx.vb" Inherits="Integra.CargoReleaseVieww" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <telerik:RadAjaxManager ID="RadAjaxManager1" EnableAJAX="true" runat="server" >
   <ClientEvents OnRequestStart="onRequestStart" OnResponseEnd="onResponseEnd" />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="dgCargo" >
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="dgCargo"  LoadingPanelID="RadAjaxLoadingPanel1" />
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
                $find('<%=dgCargo.ClientID %>').get_masterTableView().showFilterItem();
            }
            function hideFilterItem() {
                $find('<%=dgCargo.ClientID %>').get_masterTableView().hideFilterItem();
            }        
        </script>
    </telerik:RadCodeBlock>
    <div>
        <label for="RadioButtonList1">Show filtering item</label>
        <asp:RadioButtonList runat="server" ID="RadioButtonList1" RepeatDirection="Horizontal">
            <asp:ListItem Text="Yes" Selected="True" onclick="showFilterItem()"></asp:ListItem>
            <asp:ListItem Text="No" onclick="hideFilterItem()"></asp:ListItem>
        </asp:RadioButtonList>
    </div>
<div>
<table width="100%">
<tr>
<td align="right">
<telerik:RadButton ID="btnCheckCurrency" runat="server" Skin="WebBlue" Text="Checking Currency"></telerik:RadButton>
&nbsp;<telerik:RadButton ID="btnAddShipment" runat="server" Skin="WebBlue" Text="Add Shipment"></telerik:RadButton>
</td>
</tr>
<tr>
<td>
<telerik:RadGrid ID="dgCargo" runat="server" CellSpacing="0" 
                AutoGenerateColumns="False"  Skin="WebBlue" AllowFilteringByColumn ="True" 
                AllowPaging="True" GridLines="None" 
                ShowGroupPanel="True" PageSize="50" OnPageIndexChanged="dgCargo_PageIndexChanged" 
        OnSortCommand="dgCargo_SortCommand"  ShowStatusBar="True" 
                StatusBarSettings-ReadyText="Loading" >
                 <ClientSettings AllowDragToGroup="True">
                </ClientSettings>
                 <GroupingSettings CaseSensitive="false"></GroupingSettings>
                   <AlternatingItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" /> <MasterTableView>
<MasterTableView>
<Columns>
<telerik:GridBoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="Shipment NO"
									SortExpression="CargoID" DataField="CargoID"  Display="False">
								 <headerstyle width="10%" horizontalalign="Left"  />
							</telerik:GridBoundColumn>
													
								<telerik:GridBoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="Invoice NO"
									SortExpression="InvoiceNo" DataField="InvoiceNo" ShowFilterIcon="false" FilterControlWidth="70px" FilterDelay="2000" CurrentFilterFunction="StartsWith" >
								 <headerstyle width="15%" horizontalalign="Left"  />
							</telerik:GridBoundColumn>
								<telerik:GridBoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="Shipment Date[ETD]"
									SortExpression="InvoiceDateF" DataField="InvoiceDateF" ShowFilterIcon="false" FilterControlWidth="70px" FilterDelay="2000" CurrentFilterFunction="StartsWith">
								 <headerstyle width="15%" horizontalalign="Left"  />
							</telerik:GridBoundColumn>
								<telerik:GridBoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="Invoice Value"
									SortExpression="InvoiceValue" DataField="InvoiceValue" AllowFiltering="false"  >
								 <headerstyle width="15%" horizontalalign="Left"  />
							</telerik:GridBoundColumn>
								<telerik:GridBoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="Mode"
									SortExpression="Terms" DataField="Terms" ShowFilterIcon="false" FilterControlWidth="70px" FilterDelay="2000" CurrentFilterFunction="StartsWith" >
								 <headerstyle width="15%" horizontalalign="Left"  />
							</telerik:GridBoundColumn>
						
							<telerik:GridTemplateColumn HeaderText="View" AllowFiltering="false">
                                    <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
<asp:HyperLink id="lnkEdit" Runat="server" NavigateUrl='<%# "CargoRelease.aspx?IcargoID=" &amp; DataBinder.Eval(Container.DataItem,"CargoID")%>' Enabled="true">
											View
										</asp:HyperLink> 
</ITEMTEMPLATE>
                                    <headerstyle width="10%" />
								</telerik:GridTemplateColumn>
								
								<telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="Inspection Certificate" Visible="False">
									<ITEMTEMPLATE>
										<asp:HyperLink id="lnkDirectRelease"  NavigateUrl='<%# "..\Reports/Report.aspx?lcargorId=" &amp; DataBinder.Eval(Container.DataItem,"CargoID")&"&ReportName=DirectRelease"%>' Runat="server">
											Inspection Certificate
										</asp:HyperLink>
									</ITEMTEMPLATE>
								</telerik:GridTemplateColumn>
								<telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="Cargo Release" Visible="False">
									<ITEMTEMPLATE>
										<asp:HyperLink id="lnkCargoRelease" Enabled="False" NavigateUrl='<%# "..\Reports/Report.aspx?lcargorId=" &amp; DataBinder.Eval(Container.DataItem,"CargoID")&"&ReportName=CagroRelease"%>' Runat="server">
											Cargo Release
										</asp:HyperLink>
									</ITEMTEMPLATE>
								</telerik:GridTemplateColumn>
								<telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="Shipment Confirmation" Visible="False">
									<ITEMTEMPLATE>
										<asp:HyperLink id="lnkConfirmation" Enabled="False" NavigateUrl='<%# "..\Reports/Report.aspx?lcargorId=" &amp; DataBinder.Eval(Container.DataItem,"CargoID")&"&ReportName=Confirmation"%>' Runat="server">
											Shipment Confirmation
										</asp:HyperLink>
									</ITEMTEMPLATE>
								</telerik:GridTemplateColumn>
</Columns>
</MasterTableView>
<ClientSettings AllowGroupExpandCollapse="True" EnableRowHoverStyle="true" ReorderColumnsOnClient="True" AllowDragToGroup="True"
                AllowColumnsReorder="True">
                <Selecting AllowRowSelect="True" />
            </ClientSettings>
              <GroupingSettings ShowUnGroupButton="true" />
             <HeaderStyle Font-Names="Microsoft Sans Serif" />
                <ItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" Wrap="False" />
<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
<StatusBarSettings ReadyText="Loading"></StatusBarSettings>
<FilterMenu EnableImageSprites="False" Skin="WebBlue"></FilterMenu>
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
