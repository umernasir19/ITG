<%@ Page Language="vb"  MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeBehind="MasterOrderForSampling.aspx.vb" Inherits="Integra.MasterOrderForSampling" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" EnableAJAX="true" runat="server" >
   <ClientEvents OnRequestStart="onRequestStart" OnResponseEnd="onResponseEnd" />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="dgMasterOrderForDataFeeder" >
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="dgMasterOrderForDataFeeder"  LoadingPanelID="RadAjaxLoadingPanel1" />
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
        <label for="RadioButtonList1">Show filtering item</label>
        <asp:RadioButtonList runat="server" ID="RadioButtonList1" RepeatDirection="Horizontal">
            <asp:ListItem Text="Yes" Selected="True" onclick="showFilterItem()"></asp:ListItem>
            <asp:ListItem Text="No" onclick="hideFilterItem()"></asp:ListItem>
        </asp:RadioButtonList>
    </div>
<div>
    <table width="100%">
 
           <tr>
        <td colspan="6">
        
            <telerik:RadGrid ID="dgMasterOrderForDataFeeder" runat="server" CellSpacing="0" 
                AutoGenerateColumns="False"  Skin="WebBlue" AllowFilteringByColumn ="True" 
                AllowPaging="True" GridLines="None" 
                ShowGroupPanel="True" PageSize="50" OnSortCommand="dgMasterOrderForDataFeeder_SortCommand" OnPageIndexChanged="dgMasterOrderForDataFeeder_PageIndexChanged"
             ShowStatusBar="True" 
                StatusBarSettings-ReadyText="Loading" >
                 <ClientSettings AllowDragToGroup="True">
                </ClientSettings>
              <AlternatingItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" />
               <GroupingSettings CaseSensitive="false"></GroupingSettings>
            <MasterTableView  AutoGenerateColumns="false"  AllowFilteringByColumn="True"
            ShowFooter="True" TableLayout="Auto" DataKeyNames="StyleID" GroupLoadMode="Client">
            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>
<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
            <Columns>            
            <telerik:GridBoundColumn HeaderText="StyleID" DataField="StyleID" Display ="false" AllowFiltering ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn>
               <telerik:GridBoundColumn HeaderText="Entry Date" DataField="CreationDate" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>
             <telerik:GridBoundColumn HeaderText="Customer" DataField="CustomerName" AllowFiltering ="true"  FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                    FilterDelay="3000" ShowFilterIcon="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>      
            <telerik:GridBoundColumn HeaderText="Style No." DataField="styleno" AllowFiltering ="true" FilterControlWidth="65px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                    FilterDelay="4000" ShowFilterIcon="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>    
              
          
             <telerik:GridBoundColumn HeaderText="Product Group" DataField="productgroup" AllowFiltering ="false" Display="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>
           <telerik:GridBoundColumn HeaderText="Style Name" DataField="stylename" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>   
                <telerik:GridBoundColumn HeaderText="Material Composition" DataField="materialcomposition" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>      
             <telerik:GridTemplateColumn  HeaderText="Action"  AllowFiltering ="false">
                                    <itemstyle horizontalalign="Center" />
                                      <HeaderStyle Width="5%" HorizontalAlign="Center" Font-Size="Smaller"/>
									<ITEMTEMPLATE>
<asp:HyperLink id="lnkEdit" Runat="server" NavigateUrl='<%# "SamplingChart.aspx?StyleID=" &amp; DataBinder.Eval(Container.DataItem,"StyleID")%>' Enabled="true" __designer:wfdid="w1">
										Sampling
										</asp:HyperLink> 
</ITEMTEMPLATE>
                                    <headerstyle width="10%" />
								</telerik:GridTemplateColumn >
                              
            </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
 <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
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