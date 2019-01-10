<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeBehind="MasterOrderForLogistic.aspx.vb" Inherits="Integra.MasterOrderForLogistic" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="dgMasterOrderForLogistic">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="dgMasterOrderForLogistic" LoadingPanelID="RadAjaxLoadingPanel1" />
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
                $find('<%=dgMasterOrderForLogistic.ClientID %>').get_masterTableView().hideFilterItem();
            }
            function showFilterItem() {
                $find('<%=dgMasterOrderForLogistic.ClientID %>').get_masterTableView().showFilterItem();
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
        <td colspan="6">
        
            <telerik:RadGrid ID="dgMasterOrderForLogistic" runat="server" CellSpacing="0" 
                AutoGenerateColumns="False"  Skin="WebBlue" AllowFilteringByColumn ="True" 
                AllowPaging="True" AllowSorting="True" GridLines="None" 
                ShowGroupPanel="True" PageSize="15" OnSortCommand="dgMasterOrderForLogistic_SortCommand" ShowStatusBar="true" 
                StatusBarSettings-ReadyText="Loading" Height="535px" Width="930px" OnPageIndexChanged="dgMasterOrderForLogistic_PageIndexChanged">
                 <ClientSettings AllowDragToGroup="True" >                
                </ClientSettings>
                <AlternatingItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" />
                  <GroupingSettings CaseSensitive="false"></GroupingSettings>
            <MasterTableView  ShowFooter="True" TableLayout="Auto">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>
<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
            <Columns>            
            <telerik:GridBoundColumn HeaderText="POID" DataField="POID" Display ="false" AllowFiltering ="false">
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn>
             <telerik:GridBoundColumn HeaderText="QTR" DataField="Quarter" AllowFiltering ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn> 
             <telerik:GridBoundColumn HeaderText="Month" DataField="Month" AllowFiltering ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn> 
            <telerik:GridBoundColumn HeaderText="Week" DataField="Week" AllowFiltering ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn>          
              <telerik:GridBoundColumn HeaderText="Customer" DataField="CustomerName" AllowFiltering ="true"  FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                    FilterDelay="3000" ShowFilterIcon="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn> 
             <telerik:GridBoundColumn HeaderText="Supplier" DataField="VenderName" AllowFiltering ="true"  FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                    FilterDelay="3000" ShowFilterIcon="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn> 
              <telerik:GridBoundColumn HeaderText="ECP" DataField="ECPDivistion" AllowFiltering ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn> 
             <telerik:GridBoundColumn HeaderText="Merchant" DataField="UserName" AllowFiltering ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn> 
          <telerik:GridBoundColumn HeaderText="Season" DataField="Season" AllowFiltering ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn> 
             <telerik:GridBoundColumn HeaderText="Dept." DataField="EKNumber" AllowFiltering ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn> 
             <telerik:GridBoundColumn HeaderText="StyleNo" DataField="StyleNo" AllowFiltering ="true"  FilterControlWidth="65px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                    FilterDelay="4000" ShowFilterIcon="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn> 
              <telerik:GridBoundColumn HeaderText="PONO" DataField="PONO" AllowFiltering ="true"  FilterControlWidth="65px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                    FilterDelay="4000" ShowFilterIcon="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn> 
              <telerik:GridBoundColumn HeaderText="Placement" DataField="PlacementDate" AllowFiltering ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn>             
              <telerik:GridBoundColumn HeaderText="Article" DataField="Article" AllowFiltering ="true"  FilterControlWidth="65px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                    FilterDelay="4000" ShowFilterIcon="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn>  
            <telerik:GridBoundColumn HeaderText="Colorway" DataField="Colorway" AllowFiltering ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn> 
             <telerik:GridBoundColumn HeaderText="Size" DataField="Size" AllowFiltering ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn> 
             <telerik:GridBoundColumn HeaderText="Unit Price" DataField="Rate" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn> 
             <telerik:GridBoundColumn HeaderText="ItemQty" DataField="ItemQty" AllowFiltering ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn> 
             <telerik:GridBoundColumn HeaderText="Item Value" DataField="ItemValue" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>  
             <telerik:GridBoundColumn HeaderText="ShipmentDate" DataField="ShipmentDate" AllowFiltering ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn> 
              <telerik:GridBoundColumn HeaderText="Revised" DataField="LastRev" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>   
             <telerik:GridBoundColumn HeaderText="Inspected Qty" DataField="InspectedQty" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn> 
            <telerik:GridBoundColumn HeaderText="Shipped Qty" DataField="ShippedQty" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>            
           <telerik:GridBoundColumn HeaderText="Last Status" DataField="Status" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>                               
            </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
<PagerStyle PageSizeControlType="RadComboBox" AlwaysVisible="true"></PagerStyle>
            </MasterTableView>
             <StatusBarSettings ReadyText="Loading"></StatusBarSettings>
              <FilterItemStyle Font-Size="XX-Small" />
                        <GroupingSettings ShowUnGroupButton="true" />
         <HeaderStyle Font-Names="Microsoft Sans Serif" />
           <ClientSettings AllowGroupExpandCollapse="True" Scrolling-ScrollHeight="1200px" EnableRowHoverStyle="true" Scrolling-AllowScroll="True" ReorderColumnsOnClient="True" AllowDragToGroup="True"
                AllowColumnsReorder="True">
                            <Scrolling AllowScroll="true" EnableVirtualScrollPaging="false" />
                            <Selecting AllowRowSelect="True" />
                        </ClientSettings>
 <ItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" Wrap="False" />
<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
<FilterMenu EnableImageSprites="False"></FilterMenu>
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