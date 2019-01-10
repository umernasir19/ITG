<%@ Page Language="vb"  MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeBehind="LoginedUserView.aspx.vb" Inherits="Integra.LoginedUserView" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<table>
<tr>
 <td  >
        
                             <asp:Label ID="Label1" runat="server" Text="Search Type " 
                    Font-Names="Calibri" Font-Size="Medium">                    
                    </asp:Label>
 
                        </td>
                    <td align="left" >
                    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
 <telerik:RadComboBox ID="cmbSearchType" Runat="server" AutoPostBack="True" Skin="WebBlue">
 <Items>
 <telerik:RadComboBoxItem Value="0" Text="By User Name" />
  <telerik:RadComboBoxItem Value="1" Text="By Department" />
   <telerik:RadComboBoxItem Value="2" Text="By Date" />
  </Items>
 </telerik:RadComboBox> 
     </ContentTemplate>
 </asp:UpdatePanel>
   </td>
</tr>
  <tr>
                    <td  >
                          <asp:UpdatePanel ID="uplblUserName" UpdateMode="Conditional" runat="server">
  <ContentTemplate>
                              <asp:Label ID="lblUserName" runat="server" Text="User Name" 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                         </ContentTemplate>
 </asp:UpdatePanel>
                        </td>
                    <td align="left" >
                    
  <asp:UpdatePanel ID="upcmbUserName" UpdateMode="Conditional" runat="server">
  <ContentTemplate>
 <telerik:RadComboBox ID="cmbUserName" Runat="server" AutoPostBack="True" Skin="WebBlue">
  </telerik:RadComboBox> 
     </ContentTemplate>
 </asp:UpdatePanel>
  </td>
        </tr>   <tr>              
                    <td  >
                                              <asp:UpdatePanel ID="uplblDepartment" UpdateMode="Conditional" runat="server">
  <ContentTemplate>
                                <asp:Label ID="lblDepartment" runat="server" Text="Department" 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                         </ContentTemplate>
 </asp:UpdatePanel>
                        </td>
                    <td align="left" >
                      <asp:UpdatePanel ID="upcmbDepartment" UpdateMode="Conditional" runat="server">
  <ContentTemplate>
 <telerik:RadComboBox ID="cmbDepartment" Runat="server" AutoPostBack="True" Skin="WebBlue">
  </telerik:RadComboBox> 
     </ContentTemplate>
 </asp:UpdatePanel>
  </td>   </tr>
                  
                   <tr>
                    <td  >
                                              <asp:UpdatePanel ID="uplblFrom" UpdateMode="Conditional" runat="server">
  <ContentTemplate>
                         <asp:Label ID="lblFrom" runat="server" Text="From" 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                         </ContentTemplate>
 </asp:UpdatePanel>
                        </td>
               <td  valign="top">
 <asp:UpdatePanel ID="uptxtDateFrom" UpdateMode="Conditional" runat="server">
  <ContentTemplate>
<telerik:RadDatePicker ID="txtDateFrom" runat="server" Culture="en-US">
<Calendar ID="Calendar1" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" runat="server"></Calendar>
<DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" runat="server"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
</telerik:RadDatePicker>
      </ContentTemplate>
 </asp:UpdatePanel>
</td>
   <td align="left" style="width:20px;">
                    </td>
        
                    <td align="left" >
   <asp:UpdatePanel ID="uplblTo" UpdateMode="Conditional" runat="server">
  <ContentTemplate>
                          <asp:Label ID="lblTo" runat="server" Text="To" 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
    </ContentTemplate>
 </asp:UpdatePanel>
                        </td>
                    <td  valign="top">
  <asp:UpdatePanel ID="uptxtDateTo" UpdateMode="Conditional" runat="server">
  <ContentTemplate>
<telerik:RadDatePicker ID="txtDateTo" runat="server" Culture="en-US">
<Calendar ID="Calendar2" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" runat="server"></Calendar>
<DateInput ID="DateInput2" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" runat="server"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
</telerik:RadDatePicker>
        </ContentTemplate>
 </asp:UpdatePanel>
</td>
                </tr>
                <tr>
                <td>
                 </td>
                <td>
                 <telerik:RadButton ID="btnSreach" runat="server" Text="Search" Skin="WebBlue"  >
                   </telerik:RadButton>
                
                </td>
                             
                </tr>
</table>

<table width="100%">
                 <tr>
                
  <td  align="right"  >
                  <asp:UpdatePanel ID="upLnkCurrentMonthy" UpdateMode="Conditional" runat="server">
                   <ContentTemplate>
                 <asp:LinkButton ID="LnkCurrentMonth" runat="server">Current Month TIME STAMP</asp:LinkButton>  
               </ContentTemplate>
               </asp:UpdatePanel>
  </tr>
                 
</table>
<table width="100%">
 	 <tr>
       <td  align="right"  >
         
                <asp:LinkButton ID="lnkPrint" runat="server">Print TIME STAMP</asp:LinkButton>
             
                </td>
     </tr>
<tr><td>
	    <telerik:RadGrid ID="dgLoginedUser" runat="server" CellSpacing="0"  AutoGenerateColumns="false" 
         Skin="WebBlue"  Visible="true" PageSize="50">
            <AlternatingItemStyle Font-Names="Microsoft Sans Serif" />
            <MasterTableView>
            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>
            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
            <Columns>            
             
             <telerik:GridBoundColumn HeaderText="User Name" DataField="UserName" >
           <ItemStyle HorizontalAlign="Left" Width ="50px" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" Font-Size="Smaller"  />
            </telerik:GridBoundColumn>   
            <telerik:GridBoundColumn HeaderText="Department" DataField="ECPDivistion">
            <ItemStyle HorizontalAlign="Left" Width="30px" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
               <telerik:GridBoundColumn HeaderText="Login Time" DataField="LoginTime">
            <HeaderStyle Width="15%" HorizontalAlign="Left" Font-Size="Smaller"  /> 
            </telerik:GridBoundColumn>   
            <telerik:GridBoundColumn HeaderText="Logined Date" DataField="LoginedDate" >
            <ItemStyle HorizontalAlign="Left"  Width="30px"/>
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" /> 
            </telerik:GridBoundColumn>                   
          
           </Columns>
<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
            </MasterTableView>
            <ClientSettings EnableRowHoverStyle="false" EnablePostBackOnRowClick="false">
            <Selecting AllowRowSelect="true" EnableDragToSelectRows="true" />
            </ClientSettings>
            <HeaderStyle Font-Names="Microsoft Sans Serif" />
            <ItemStyle Font-Names="Microsoft Sans Serif" />
            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
           <FilterMenu EnableImageSprites="False"></FilterMenu>
            </telerik:RadGrid>
  
        </td>
</tr>
 </table>
</asp:Content> 