<%@ Page Language="vb" MasterPageFile="~/MasterPage.master"  AutoEventWireup="false" CodeBehind="MasterOrderForSrManagement.aspx.vb" Inherits="Integra.MasterOrderForSrManagement" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
    <table style="width: 100%;">
           <tr>
        <td colspan="6">
        
            <telerik:RadGrid ID="dgMasterOrderForSrManagement" runat="server" CellSpacing="0" 
                AutoGenerateColumns="False"  Skin="WebBlue" AllowFilteringByColumn ="True" 
                AllowPaging="True" AllowSorting="True" GridLines="None" 
                ShowGroupPanel="True" PageSize="50"  >
                 <ClientSettings AllowDragToGroup="True">
                </ClientSettings>
                 <AlternatingItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" />
            <MasterTableView>
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>
<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
            <Columns>            
            <telerik:GridBoundColumn HeaderText="POID" DataField="POID" Display ="false" AllowFiltering ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn>           
            <telerik:GridBoundColumn HeaderText="Month" DataField="Month"  AllowFiltering ="false" >
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" /> 
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Customer" DataField="CustomerName" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Total Pos" DataField="TotalPos" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Booked Volume" DataField="bookQty" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>    
             <telerik:GridBoundColumn HeaderText="Shipped Volume" DataField="Squantity" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>    
            <telerik:GridBoundColumn HeaderText="Booked Value" DataField="BookedValue" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>        
               <telerik:GridBoundColumn HeaderText="Shipped Value" DataField="shipVal" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn> 
             <telerik:GridBoundColumn HeaderText="Booked Commission" DataField="BookComm" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>  
             <telerik:GridBoundColumn HeaderText="Shipped Commission" DataField="ShipComm" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>   
                <telerik:GridBoundColumn HeaderText="Claimed Pcs." DataField="ClaimedPcs" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>      
                    <telerik:GridBoundColumn HeaderText="Timely Shipped" DataField="TimelyShipPcs" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>   
              <telerik:GridBoundColumn HeaderText="Del Perfor" DataField="DelPerfor" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>  
           </Columns>
           <EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
            </MasterTableView>
        <HeaderStyle Font-Names="Microsoft Sans Serif" />
 <ItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" Wrap="False" />               
<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
<FilterMenu EnableImageSprites="False"></FilterMenu>            
            </telerik:RadGrid>
        
        </td>
        </tr>
    </table> 
    </div> 
</asp:Content> 