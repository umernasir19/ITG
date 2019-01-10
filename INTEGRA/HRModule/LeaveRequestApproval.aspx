<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="LeaveRequestApproval.aspx.vb" Inherits="Integra.LeaveRequestApproval" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<telerik:RadAjaxManager ID="RadAjax" runat="server">
<AjaxSettings>
<telerik:AjaxSetting AjaxControlID="btnApproved">
<UpdatedControls>
<telerik:AjaxUpdatedControl ControlID="dgLeaveRequestApproval" />
</UpdatedControls>
</telerik:AjaxSetting>
<telerik:AjaxSetting AjaxControlID="btnRejected">
<UpdatedControls>
<telerik:AjaxUpdatedControl ControlID="dgLeaveRequestApproval" />
</UpdatedControls>
</telerik:AjaxSetting>
</AjaxSettings>
</telerik:RadAjaxManager>
<table width="100%">
<tr>
<td >
<asp:RadioButtonList runat="server" ID="RadioButtonList1" RepeatDirection="Horizontal" AutoPostBack="true">
                        <asp:ListItem Text="Pending" Selected="True" ></asp:ListItem>
                        <asp:ListItem Text="Approved" ></asp:ListItem>
                        <asp:ListItem Text="Rejected" ></asp:ListItem>
                    </asp:RadioButtonList>
</td>
<td>

</td>
</tr>
<tr>
<td align="right" colspan="2">
<telerik:RadButton ID="btnApproved" Text="Approved" Font-Bold="true" Skin="WebBlue" runat="server"></telerik:RadButton>
<telerik:RadButton ID="btnRejected" Text="Rejected" Font-Bold="true" Skin="WebBlue" runat="server"></telerik:RadButton>
</td>
</tr>
<tr>
<td colspan="2">
 <telerik:RadGrid ID="dgLeaveRequestApproval" runat="server" CellSpacing="0" 
                AutoGenerateColumns="false"  Skin="WebBlue"  
                Visible="True" PageSize="50" >
            <MasterTableView>
            <Columns>
           <telerik:GridBoundColumn HeaderText="LeaveRequestID" DataField="LeaveRequestID" Display="false" >
           <ItemStyle HorizontalAlign="Left"  />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
             <telerik:GridBoundColumn HeaderText="HRID" DataField="HRID" Display="false" >
           <ItemStyle HorizontalAlign="Left"  />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Employee Name" DataField="EmployeeName">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Total Leave" DataField="TotalLeaveGranted" >
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Avail Leave" DataField="TotalLeaveAvailed">
            <HeaderStyle Width="5%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>           
            <telerik:GridBoundColumn HeaderText="Requested" DataField="LeaveDays">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="From" DataField="LeaveFromm">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="To" DataField="LeaveToo">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
             <telerik:GridTemplateColumn HeaderText ="Reason"  Display="true" ItemStyle-Wrap="False">
                <ItemTemplate >
                    <asp:Label ID="lblReason" runat="server"  ></asp:Label>
                </ItemTemplate>
                </telerik:GridTemplateColumn>
             <telerik:GridTemplateColumn HeaderText="Remarks" >
            <ItemTemplate>
                  <telerik:RadTextBox ID="txtRemarks" width="300px"  Runat="server" Skin="WebBlue">
                  </telerik:RadTextBox>
                                  </ItemTemplate>
             <HeaderStyle Width="40%" HorizontalAlign="Left" />
             </telerik:GridTemplateColumn>
               <telerik:GridTemplateColumn HeaderText="Select" >
            <ItemTemplate>
                 <asp:CheckBox ID="chkApproved" runat="Server" />
            </ItemTemplate>
             <HeaderStyle Width="5%" HorizontalAlign="Left" />
             </telerik:GridTemplateColumn>
            </Columns>
            </MasterTableView>
              </telerik:RadGrid>
</td>
</tr>
</table>
</asp:Content>
