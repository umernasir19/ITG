<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeBehind="TrackingPanel.aspx.vb" Inherits="Integra.TrackingPanel" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" EnableAJAX="true" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
        <ClientEvents OnRequestStart="onRequestStart" OnResponseEnd="onResponseEnd" />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="dgWipTracking">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="dgWipTracking" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="dgInspectionTracking">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="dgInspectionTracking" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" BackgroundPosition="Bottom"
        Width="80%">
        <asp:Image ID="Image1" runat="server" AlternateText="Loading..." ImageUrl="~/Images/loading12.gif" />
    </telerik:RadAjaxLoadingPanel>
<table  >
<tr   >
  <td  >
                <asp:Label ID="lblNationality" runat="server" Text="Tracking Type"></asp:Label>
            </td>
            <td  >
         
                    <telerik:RadComboBox ID="cmbTracking" Runat="server" AutoPostBack="True" 
                    Skin="WebBlue" TabIndex="3">
                     <Items>   
                      <telerik:RadComboBoxItem Value="0" Text="Please Select.."/>
                <telerik:RadComboBoxItem Value="1" Text="WIP Tracking"/>
                 <telerik:RadComboBoxItem Value="2" Text="Inspection Tracking"/>
                   </Items>
                </telerik:RadComboBox>
            
            </td>
<td></td>
<td></td>
</tr>
<tr  >
 <td  >
                <asp:Label ID="lblStartDate" runat="server" Text="From Date"></asp:Label>
            </td>
            <td   >
                <telerik:RadDatePicker ID="txtStartDate" runat="server" Culture="en-US">
<Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>

<DateInput ID="DateInput1" runat ="server"  DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
</td> 
 
<td></td>
</tr>
<tr  >
 <td  >
                <asp:Label ID="lblEnddate" runat="server" Text="To Date"></asp:Label>
            </td>
            <td >
                <telerik:RadDatePicker ID="txtEndDate" runat="server" Culture="en-US">
<Calendar ID="Calendar2" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>

<DateInput ID="DateInput2" runat ="server"  DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
</td> 
 
<td></td>
</tr>
<tr  >
<td></td>
<td> <telerik:RadButton ID="btnTracking" runat="server" Text="Search" 
                    Skin="WebBlue">
                </telerik:RadButton> </td>
<td></td>
<td></td>
</tr>
  <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;" 
              visible="true";>
            <th  colspan ="6" align="left"   style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080;"  >
           <asp:Label ID="lblHeading" runat="server"  ></asp:Label>
          </th>
         </tr>
</table> 
<table width="100%">

<tr>
 <td align="right">
 </td>
 </tr>
<tr><td colspan="6">
	   
        <telerik:RadGrid ID="dgWipTracking" runat="server" CellSpacing="0" AutoGenerateColumns="False"   
                        Skin="WebBlue" AllowFilteringByColumn="True" AllowPaging="True" AllowSorting="True"
                        GridLines="None" ShowGroupPanel="True" PageSize="15" OnSelectedIndexChanged="dgWipTracking_PageIndexChanged"
                       ShowStatusBar="true" StatusBarSettings-ReadyText="Loading" OnSortCommand="dgWipTracking_SortCommand"  Height="550px" Width="930px">
                        <ClientSettings AllowDragToGroup="True">
                        </ClientSettings>
                        <AlternatingItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" />
                        <GroupingSettings CaseSensitive="false"></GroupingSettings>
                        <MasterTableView ShowFooter="True" TableLayout="Auto">
            <Columns>            
            <telerik:GridBoundColumn HeaderText="WIPChartId" DataField="WIPChartId" Display ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="2%" HorizontalAlign="Left" Font-Size="Smaller"  />
            </telerik:GridBoundColumn>  
             
               <telerik:GridBoundColumn HeaderText="PO No." DataField="PONO" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
               <telerik:GridBoundColumn HeaderText="Supplier" DataField="VenderName" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>

             <telerik:GridBoundColumn HeaderText="Customer" DataField="CustomerName" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn HeaderText="Marchant" DataField="UserName" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Placement Date" DataField="PlacementDate" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>   

               <telerik:GridBoundColumn HeaderText="Shipment Date" DataField="shipmentdate" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>   
           
              <telerik:GridBoundColumn HeaderText="Style No" DataField="StyleNo" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                       
                 <telerik:GridBoundColumn HeaderText="Article" DataField="Article" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>

              <telerik:GridBoundColumn HeaderText="Size" DataField="sizerange" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>

                 <telerik:GridBoundColumn HeaderText="Colorway" DataField="Colorway" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                  
            <telerik:GridBoundColumn HeaderText="PO Qty" DataField="Quantity" AllowFiltering="false" Aggregate="Sum" FooterText=" " FooterStyle-Font-Bold="true" FooterStyle-Font-Names="Calibri"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>

              <telerik:GridBoundColumn HeaderText="WIP Process" DataField="ProcessName" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
<telerik:GridBoundColumn HeaderText="WIP Activity" DataField="CreationDate" AllowFiltering="false"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
             
                            
            </Columns>
            </MasterTableView>
              <StatusBarSettings ReadyText="Loading"></StatusBarSettings>
                        <FilterItemStyle Font-Size="XX-Small" />
                        <GroupingSettings ShowUnGroupButton="true" />
                        <HeaderStyle Font-Names="Microsoft Sans Serif" />
                        <ItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" Wrap="False" />
                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                        <ClientSettings Scrolling-ScrollHeight="1200px" EnableRowHoverStyle="true" Scrolling-AllowScroll="True">
                            <Scrolling AllowScroll="true" EnableVirtualScrollPaging="false" />
                            <Selecting AllowRowSelect="True" />
                        </ClientSettings>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                    </telerik:RadGrid>
                        
 
  </td>			
</tr> 
<tr><td colspan="6">
	  
        <telerik:RadGrid ID="dgInspectionTracking" runat="server" CellSpacing="0" AutoGenerateColumns="False"   
                        Skin="WebBlue" AllowFilteringByColumn="True" AllowPaging="True" AllowSorting="True"
                        GridLines="None" ShowGroupPanel="True" PageSize="15" OnSelectedIndexChanged="dgInspectionTracking_PageIndexChanged"
                       ShowStatusBar="true" StatusBarSettings-ReadyText="Loading" OnSortCommand="dgInspectionTracking_SortCommand"  Height="550px" Width="930px">
                        <ClientSettings AllowDragToGroup="True">
                        </ClientSettings>
                        <AlternatingItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" />
                        <GroupingSettings CaseSensitive="false"></GroupingSettings>
                        <MasterTableView ShowFooter="True" TableLayout="Auto">
            <Columns>            
               <telerik:GridBoundColumn HeaderText="QDInspectionID" DataField="QDInspectionID" Display ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="2%" HorizontalAlign="Left" Font-Size="Smaller"  />
            </telerik:GridBoundColumn>  
             
               <telerik:GridBoundColumn HeaderText="PO No." DataField="PONO" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>

               <telerik:GridBoundColumn HeaderText="Supplier" DataField="VenderName" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>

               <telerik:GridBoundColumn HeaderText="Customer" DataField="CustomerName" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>

                
                                  <telerik:GridBoundColumn HeaderText="Placement Date" DataField="PlacementDate" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>   

               <telerik:GridBoundColumn HeaderText="Shipment Date" DataField="shipmentdate" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>   
                                          
                <telerik:GridBoundColumn HeaderText="Dept." DataField="eknumber" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>   
                                
               <telerik:GridBoundColumn HeaderText="Season" DataField="Season" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>           
           
               <telerik:GridBoundColumn HeaderText="Style No" DataField="StyleNo" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                       
               <telerik:GridBoundColumn HeaderText="Article" DataField="Article" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>

               <telerik:GridBoundColumn HeaderText="Size" DataField="sizerange" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>

               <telerik:GridBoundColumn HeaderText="Colorway" DataField="Colorway" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                  
               <telerik:GridBoundColumn HeaderText="PO Qty" DataField="OrderQty" AllowFiltering="false" Aggregate="Sum" FooterText=" " FooterStyle-Font-Bold="true" FooterStyle-Font-Names="Calibri"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>

              <telerik:GridBoundColumn HeaderText="Inspected Qty" DataField="InspectedQty" AllowFiltering="false" Aggregate="Sum" FooterText=" " FooterStyle-Font-Bold="true" FooterStyle-Font-Names="Calibri"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                  <telerik:GridBoundColumn HeaderText="QD Name" DataField="UserName" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                     <telerik:GridBoundColumn HeaderText="Activity Date" DataField="CreationDate" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                 <telerik:GridBoundColumn HeaderText="Inspection Date" DataField="InspectionDate" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
               <telerik:GridBoundColumn HeaderText="Insp. Type" DataField="InsType" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>

                                  <telerik:GridBoundColumn HeaderText="Insp. Status" DataField="InspStatus" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="4000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                            
            </Columns>
            </MasterTableView>
              <StatusBarSettings ReadyText="Loading"></StatusBarSettings>
                        <FilterItemStyle Font-Size="XX-Small" />
                        <GroupingSettings ShowUnGroupButton="true" />
                        <HeaderStyle Font-Names="Microsoft Sans Serif" />
                        <ItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" Wrap="False" />
                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                        <ClientSettings Scrolling-ScrollHeight="1200px" EnableRowHoverStyle="true" Scrolling-AllowScroll="True">
                            <Scrolling AllowScroll="true" EnableVirtualScrollPaging="false" />
                            <Selecting AllowRowSelect="True" />
                        </ClientSettings>
                        <FilterMenu EnableImageSprites="False">
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