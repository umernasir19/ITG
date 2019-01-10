<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LeadTimeApprovalSheetPopup.aspx.vb" Inherits="Integra.LeadTimeApprovalSheetPopup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 <link href= "../App_Themes/Blue/StyleSheet.css" rel="stylesheet" />
 
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
         </asp:ScriptManager>
     <div>
     <table width="100%">
     
 <tr>
             <th colspan ="5" align="left"   style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080;" >
             Lead Time Approval Sheet</th>
 </tr>
 <tr>
 <td align="center">
     <asp:Label ID="lblMsg" runat="server" CssClass="Errormsg" Font-Bold="True" 
         Font-Names="Arial" Font-Size="Small" ForeColor="#00CC66"></asp:Label>
 </td>
 </tr>
           <tr>
        <td colspan="6">
        <asp:UpdatePanel ID="UpdatePanel3" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
            <telerik:RadGrid ID="dgLeadTimeApprovalSheet" runat="server" CellSpacing="0" 
                AutoGenerateColumns="False"  Skin="WebBlue" AllowFilteringByColumn ="True" 
                AllowPaging="True" GridLines="None" 
                ShowGroupPanel="false" PageSize="50" OnSortCommand="dgLeadTimeApprovalSheet_SortCommand"
                 OnPageIndexChanged="dgLeadTimeApprovalSheet_PageIndexChanged"
             ShowStatusBar="True" 
                StatusBarSettings-ReadyText="Loading" >
                 <ClientSettings AllowDragToGroup="True">
                </ClientSettings>
              <AlternatingItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" />
               <GroupingSettings CaseSensitive="false"></GroupingSettings>
            <MasterTableView  AutoGenerateColumns="false"  AllowFilteringByColumn="True"
            ShowFooter="True" TableLayout="Auto" DataKeyNames="POID" GroupLoadMode="Client">
            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>
<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
            <Columns>            
            <telerik:GridBoundColumn HeaderText="POID" DataField="POID" Display ="false" AllowFiltering ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn>
               <telerik:GridBoundColumn HeaderText="Entry Date" DataField="CreationDate" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="4%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>
             <telerik:GridBoundColumn HeaderText="Customer" DataField="CustomerName" AllowFiltering ="false"  FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                    FilterDelay="3000" ShowFilterIcon="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>      
             <telerik:GridBoundColumn HeaderText="Dept" DataField="EKNumber" AllowFiltering ="false" Display="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn>
             <telerik:GridBoundColumn HeaderText="Supplier" DataField="VenderName" AllowFiltering ="false"  FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                    FilterDelay="3000" ShowFilterIcon="false">
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn>
              <telerik:GridBoundColumn HeaderText="Merchant" DataField="UserName" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>  
              <telerik:GridBoundColumn HeaderText="PO No." DataField="PONO" AllowFiltering ="false" FilterControlWidth="65px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                    FilterDelay="4000" ShowFilterIcon="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>    
              <telerik:GridBoundColumn HeaderText="PO. Qty" DataField="Quantity" DataFormatString="{0:#,##0;(#,##0);0}" DataType="System.Decimal" AllowFiltering ="false" Aggregate="Sum" FooterText=" " FooterStyle-Font-Bold="true" FooterStyle-Font-Names="Calibri">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="4%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>  
            <telerik:GridBoundColumn HeaderText="PO. Value" DataField="Value" AllowFiltering ="false" Display="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>
           <telerik:GridBoundColumn HeaderText="Placement" DataField="PlacementDate" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>   
             <telerik:GridBoundColumn HeaderText="Shipment" DataField="ShipmentDate" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>   
               <telerik:GridBoundColumn HeaderText="MarchandID" DataField="MarchandID" Display ="false" AllowFiltering ="false" >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="2%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn>
              <telerik:GridBoundColumn HeaderText="Type" DataField="POtype" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>    
            <telerik:GridBoundColumn HeaderText="Lead Time" DataField="timespame" AllowFiltering ="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="3%" HorizontalAlign="Left" Font-Size="Smaller"/>
            </telerik:GridBoundColumn>           
            <telerik:GridTemplateColumn  HeaderText="Action"  AllowFiltering ="false">
              <itemstyle horizontalalign="Center" />
               <HeaderStyle Width="5%" HorizontalAlign="Center" Font-Size="Smaller"/>
				<ITEMTEMPLATE>
   <asp:LinkButton ID="lnkApprove"  runat ="server" CommandName ="Approved" HeaderText ="View" Text="Approved" ></asp:LinkButton>
        </ITEMTEMPLATE>
   <headerstyle width="5%" />
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
         </ContentTemplate>
                 </asp:UpdatePanel>
        </td>
        </tr>
    </table>    
    </div>
    </form>
</body>
</html>
