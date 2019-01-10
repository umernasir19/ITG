<%@ Page Language="vb" MasterPageFile="~/MasterPage.master"  AutoEventWireup="false" CodeBehind="MasterOrderForSupplier.aspx.vb" Inherits="Integra.MasterOrderForSupplier" %>
 
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" EnableAJAX="true" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
       <ClientEvents OnRequestStart="onRequestStart" OnResponseEnd = "onResponseEnd"  /> 
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="dgMasterOrderForSupplier">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="dgMasterOrderForSupplier"  />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
     <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" BackgroundPosition="Bottom" Width="80%">
      <asp:Image ID="Image1" runat="server" AlternateText="Loading..." 
                ImageUrl="~/Images/loading12.gif" />
    </telerik:RadAjaxLoadingPanel>
     <telerik:RadCodeBlock runat="server" ID="radCodeBlock">
        <script type="text/javascript">
            function showFilterItem() {
                $find('<%=dgMasterOrderForSupplier.ClientID %>').get_masterTableView().showFilterItem();
            }
            function hideFilterItem() {
                $find('<%=dgMasterOrderForSupplier.ClientID %>').get_masterTableView().hideFilterItem();
            }        
        </script>
    </telerik:RadCodeBlock>
    <div>
    <table style="width: 100%;">
      <tr>
      <td align="left">
        <label for="RadioButtonList1">Show filtering item</label>
        <asp:RadioButtonList runat="server" ID="RadioButtonList1" RepeatDirection="Horizontal">
            <asp:ListItem Text="Yes" Selected="True" onclick="showFilterItem()"></asp:ListItem>
            <asp:ListItem Text="No" onclick="hideFilterItem()"></asp:ListItem>
        </asp:RadioButtonList>
      </td>
    <td align="right">
   <asp:UpdatePanel ID="upcmbAction" UpdateMode="Conditional" runat="server">
  <ContentTemplate>
    <telerik:RadComboBox ID="cmbAction" Runat="server" AutoPostBack="True"  Skin="WebBlue">
    <Items>
     <telerik:RadComboBoxItem  Value="0" Text="Select Action"/>
    <telerik:RadComboBoxItem  Value="1" Text="Create ICR"/>
    <telerik:RadComboBoxItem   Value ="2" Text="Create Invoice"/>
    </Items>
 </telerik:RadComboBox>
     </ContentTemplate>
  </asp:UpdatePanel>
    </td>
    </tr>
           <tr>
        <td colspan="6">
        
            <telerik:RadGrid ID="dgMasterOrderForSupplier" runat="server" CellSpacing="0" 
                AutoGenerateColumns="False"  Skin="WebBlue" AllowFilteringByColumn ="True" 
                AllowPaging="True" AllowSorting="True" GridLines="None" 
                ShowGroupPanel="True" PageSize="15"
             ShowStatusBar="True" OnSortCommand="dgMasterOrderForSupplier_SortCommand" OnPageIndexChanged="dgMasterOrderForSupplier_PageIndexChanged" 
                StatusBarSettings-ReadyText="Loading" Height="633px" Width="930px" >
                 <ClientSettings AllowDragToGroup="True">
<Scrolling AllowScroll="True" ScrollHeight="1200px"></Scrolling>
                </ClientSettings>
                 <GroupingSettings CaseSensitive="false"></GroupingSettings>
            <AlternatingItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" />
            <MasterTableView ShowFooter="True" TableLayout="Auto">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
            <Columns>            
            <telerik:GridBoundColumn HeaderText="POID" DataField="POID" Display ="false" AllowFiltering ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn>  
           <telerik:GridBoundColumn HeaderText="PODetailID" DataField="PODetailID" Display ="false" AllowFiltering ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn>            
            <telerik:GridBoundColumn HeaderText="Destination" DataField="Destination"  AllowFiltering ="false" >
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" /> 
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Customer" DataField="CustomerName" AllowFiltering ="true" FilterControlWidth="70px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                    FilterDelay="4000" ShowFilterIcon="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Dept" DataField="EKNumber" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="ECP Contact" DataField="UserName" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>    
            <telerik:GridBoundColumn HeaderText="Product Catergory" DataField="ProductCategories" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>    
             <telerik:GridBoundColumn HeaderText="Style Number" DataField="StyleNo" AllowFiltering ="true" FilterControlWidth="70px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                    FilterDelay="4000" ShowFilterIcon="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>    
            <telerik:GridBoundColumn HeaderText="PO Number" DataField="PONO" AllowFiltering ="true" FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                    FilterDelay="4000" ShowFilterIcon="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>        
            <telerik:GridBoundColumn HeaderText="Received Date" DataField="PlacementDate" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn> 
             <telerik:GridBoundColumn HeaderText="Article Number" DataField="Article" AllowFiltering ="true" FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                    FilterDelay="4000" ShowFilterIcon="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>  
             <telerik:GridBoundColumn HeaderText="Colorway" DataField="Colorway" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>   
                <telerik:GridBoundColumn HeaderText="Size" DataField="size" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>      
                   
              <telerik:GridBoundColumn HeaderText="Unit Price" DataField="Rate" AllowFiltering ="false" Aggregate="Avg" FooterAggregateFormatString="{0:###.##}" FooterStyle-Font-Bold="true" FooterStyle-Font-Names="Calibri" FooterText="Avg.">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn> 
              <telerik:GridBoundColumn HeaderText="Article Qty." DataField="ItemQty" AllowFiltering ="false" Aggregate="Sum" FooterText=" " FooterStyle-Font-Bold="true" FooterStyle-Font-Names="Calibri">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn> 
                <telerik:GridBoundColumn HeaderText="Inspected Qty" DataField="InspectedQty" AllowFiltering ="false" Aggregate="Sum" FooterText=" " FooterStyle-Font-Bold="true" FooterStyle-Font-Names="Calibri">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn> 
                <telerik:GridBoundColumn HeaderText="Claim Qty" DataField="ClaimQty" AllowFiltering ="false" Aggregate="Sum" FooterText=" " FooterStyle-Font-Bold="true" FooterStyle-Font-Names="Calibri">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn> 
            <telerik:GridBoundColumn HeaderText="Shipment Date" DataField="ShipmentDate" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn> 
            <telerik:GridBoundColumn HeaderText="Week" DataField="ShipWeek" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn> 
             <telerik:GridBoundColumn HeaderText="Shipment Mode" DataField="ShipmentMode" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn> 
             <telerik:GridBoundColumn HeaderText="Currency" DataField="Currency" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn> 
              <telerik:GridBoundColumn HeaderText="Shipment Term" DataField="ShipmentTerm" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Actual WIP" DataField="ActualWp" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn> 
              <telerik:GridBoundColumn HeaderText="ICR" DataField="ICR" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn> 
              <telerik:GridBoundColumn HeaderText="P/L" DataField="PL" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn> 
             <telerik:GridBoundColumn HeaderText="Invoice" DataField="InvoiceNo" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>
            <telerik:GridTemplateColumn HeaderText="Select" UniqueName="Select" AllowFiltering ="false">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server"></asp:CheckBox>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
            </Columns>
    <EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>

<PagerStyle PageSizeControlType="RadComboBox" AlwaysVisible="true"></PagerStyle>
            </MasterTableView>
            <StatusBarSettings ReadyText="Loading"></StatusBarSettings>
            <GroupingSettings ShowUnGroupButton="true" />
              <HeaderStyle Font-Names="Microsoft Sans Serif" />
                <ItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" Wrap="False" />
              <ClientSettings Scrolling-ScrollHeight="1200px" EnableRowHoverStyle="true"
                            Scrolling-AllowScroll="True">
                            <Scrolling AllowScroll="true" EnableVirtualScrollPaging="false" />
                            <Selecting AllowRowSelect="True" />
                        </ClientSettings>
<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

<FilterMenu EnableImageSprites="False"></FilterMenu>
            
            </telerik:RadGrid>
        
        </td>
        </tr>
    </table> 
    </div> 
       <%-- Script For Loading Panel  --%>
     <script language ="javascript" type ="text/javascript" >
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
