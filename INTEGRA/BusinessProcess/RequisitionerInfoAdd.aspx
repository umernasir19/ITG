<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="RequisitionerInfoAdd.aspx.vb" Inherits="Integra.RequisitionerInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" EnableAJAX="true" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
        <ClientEvents OnRequestStart="onRequestStart" OnResponseEnd="onResponseEnd" />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="dgRequisitionerInfo">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="dgRequisitionerInfo" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
<div>
<table>
<tr >
<td class="ErrorMsg" width="925" style="height: 25px" align="center">
    <asp:Label ID="lblMsg" runat="server" Text="" Visible="false" ></asp:Label>
</td>
</tr>
</table>
<asp:Panel ID="pnlAll" runat ="server" Visible ="true"   >
<table width="100%">

<tr>
<td style="height: 25px">

<asp:Label id="lblDate" Text="Date:" runat ="server" Visible= "true"></asp:Label>
</td>
<td style="height: 25px">
<telerik:RadDatePicker ID="txtDate" runat="server" Skin="WebBlue">

<DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" 
            TabIndex="2"></DateInput>
</telerik:RadDatePicker>
</td>
<td style="height: 25px"></td>
<td style="left: 10px; height: 25px;">
<asp:Label id="lblApprovalDate" Text="Approval Date:" runat ="server" Visible= "false"></asp:Label>

</td>
<td style="height: 25px">
<telerik:RadDatePicker ID="txtApprovalDate" runat="server" Skin="WebBlue" Visible="false">
<DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"  
            TabIndex="2"></DateInput>

</telerik:RadDatePicker>
</td>
</tr>
<tr>
<td style="height: 25px">
<asp:Label id="lblRequisitionerName" Text="Name:" runat ="server" Visible= "true"></asp:Label>
 
</td>
<td style="height: 25px">
<telerik:RadTextBox ID="txtRequisitionerName" runat="server" Skin="WebBlue"></telerik:RadTextBox>
</td>
<td style="height: 25px">
 
</td>
<td>
<asp:Label id="lblApprovedBy" Text="Approved By:" runat ="server" Visible= "false"></asp:Label>
   </td>
<td>
    <telerik:RadTextBox ID="txtApprovedBy" runat="server" Skin="WebBlue" Visible="false"></telerik:RadTextBox></td>
</tr>
<tr>
<td style="height: 25px">
    <asp:Label id="lblDepartment" Text="Department :" runat ="server" Visible= "true"></asp:Label>
   
</td>
<td>
<telerik:RadTextBox ID="txtDepartment" runat="server"  Skin="WebBlue"></telerik:RadTextBox>
</td>
<td></td>
<td>
<asp:Label id="lblPriorityUrgentNormal" Text="Priority: Urgent/Normal" runat ="server" Visible= "false"></asp:Label>
  
</td>
<td>

    <asp:RadioButtonList ID="rdPriorityUrgentNormal" runat="server" align="left" 
        Height= "16px"  Width="100px" Font-Size="Small" Font-Names="arial" Visible= "false"
        AutoPostBack="false" RepeatDirection="Horizontal">
        <asp:ListItem Value="Urgent" >Urgent</asp:ListItem>
        <asp:ListItem Value="Normal" Selected="True">Normal</asp:ListItem>
    </asp:RadioButtonList>
</td>
</tr>
<tr>
<td style="height: 25px">
   
</td>
<td></td>
<td></td>
<td></td>
<td></td>
</tr>


</table>
 <div  style="vertical-align: top; height: 600px; overflow: auto; width: 920px; border-style: ridge;
                border-color: #d1cece;" visible="true" >
                
<table width="100%" >

<tr>
<td style="overflow:scroll; width:950px; height:200px;">
<telerik:RadGrid ID="dgRequisitionerInfo"  runat="server" CellSpacing="0" 
                AutoGenerateColumns="False"  Skin="WebBlue" AllowFilteringByColumn ="false" 
                AllowPaging="false" GridLines="None" 
                ShowGroupPanel="True" OnSortCommand="dgRequisitionerInfo_SortCommand" OnPageIndexChanged="dgRequisitionerInfo_PageIndexChanged"
             ShowStatusBar="True" 
                StatusBarSettings-ReadyText="Loading" >
                 <ClientSettings AllowDragToGroup="True">
                </ClientSettings>
              <AlternatingItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" />
               <GroupingSettings CaseSensitive="false"></GroupingSettings>
            <MasterTableView>
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>
<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
            <Columns>
                                               
															<telerik:GridBoundColumn HeaderText="InventoryDatabaseID" DataField="InventoryDatabaseID" Display="false" />
																				
                                                                                    <telerik:GridBoundColumn   HeaderText="ItemCode" DataField="ItemCode" HeaderStyle-Width ="70px" HeaderStyle-HorizontalAlign ="Center"  ItemStyle-HorizontalAlign ="Left" >
															    <itemstyle horizontalalign="Center" width="20%" />
															</telerik:GridBoundColumn> 													
															<telerik:GridBoundColumn   HeaderText="ItemDescription" DataField="ItemDescription"  HeaderStyle-Width ="50px" HeaderStyle-HorizontalAlign ="Center"  ItemStyle-HorizontalAlign ="Left" >
															    <itemstyle horizontalalign="Center" width="50%" />
															</telerik:GridBoundColumn> 
																<telerik:GridBoundColumn HeaderText="UnitPrice" DataField="UnitPrice"  visible="true" HeaderStyle-Width ="70px" HeaderStyle-HorizontalAlign ="Center"  ItemStyle-HorizontalAlign ="Left">
															    <itemstyle horizontalalign="Center" width="20%" />
															</telerik:GridBoundColumn> 
																
         <telerik:GridTemplateColumn HeaderText="Requisition"><itemstyle horizontalalign="Center" /> <ITEMTEMPLATE>
  
             <asp:CheckBox ID="chkRequisition" runat="server" AutoPostBack="true"></asp:CheckBox>
   </ITEMTEMPLATE>  <headerstyle horizontalalign="Center" width="7px" /> <ItemStyle horizontalalign="Center" />
     </telerik:GridTemplateColumn>
																	
								                               
								                          
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
<tr>
<%--<td align="center"><telerik:RadButton ID="btnSave" runat="server" Skin="WebBlue" Text="Save"></telerik:RadButton>
&nbsp;
<telerik:RadButton ID="btnCancel" runat="server" Skin="WebBlue" Text="Cancel"></telerik:RadButton></td>--%>
</tr>
</table>
</div>
<br />
<div align="center">
<table >
<td align="center"><telerik:RadButton ID="btnSave" runat="server" Skin="WebBlue" Text="Save"></telerik:RadButton>
&nbsp;
<telerik:RadButton ID="btnCancel" runat="server" Skin="WebBlue" Text="Cancel"></telerik:RadButton></td>
</table>
</div>
</asp:Panel>
</div>

</asp:Content>