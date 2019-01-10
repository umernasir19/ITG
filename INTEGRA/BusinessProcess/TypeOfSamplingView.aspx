<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeBehind="TypeOfSamplingView.aspx.vb" Inherits="Integra.TypeOfSamplingView" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="!00%">
<tr>
<td align="right">
   <telerik:RadButton ID="BtnAdd" runat="server" Text="Add Sampling Type" Skin="WebBlue">
                </telerik:RadButton>
</td>
</tr>
 <tr>
<td>
 <telerik:RadGrid ID="dgTypeOfSamplingView" runat="server" CellSpacing="0" 
                AutoGenerateColumns="false"  Skin="WebBlue"  
                Visible="true">
                  <AlternatingItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" />
            <MasterTableView>
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
            <Columns>
            
            <telerik:GridBoundColumn HeaderText="TypeOfSamplingID" DataField="TypeOfSamplingID" Display ="false">
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="3%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
           <telerik:GridBoundColumn HeaderText="Type" DataField="TypeName">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>
 <telerik:GridTemplateColumn HeaderText="Action"  AllowFiltering ="false" >
              <itemstyle horizontalalign="Center" />
                        <ItemTemplate>
                               <asp:HyperLink id="lnkEdit" ToolTip ="Click Here to Edit Type Of Samplig." Enabled ="true" NavigateUrl='<%# "TypeOfSamplingEntry.aspx?ITypeOfSamplingID="& DataBinder.Eval(Container.DataItem,"TypeOfSamplingID")%>' Runat="server">Edit</asp:HyperLink>
                        </ItemTemplate>
                        <HeaderStyle Width="1%" HorizontalAlign="Left" Font-Size="Smaller"/>
                    </telerik:GridTemplateColumn> 
</Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
            </MasterTableView>
       <HeaderStyle Font-Names="Microsoft Sans Serif" />
                <ItemStyle Font-Names="Microsoft Sans Serif" Font-Size="X-Small" Wrap="False" />
<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
<FilterMenu EnableImageSprites="False"></FilterMenu>
 </telerik:RadGrid>
</td> 
</tr>
</table>
</asp:Content> 