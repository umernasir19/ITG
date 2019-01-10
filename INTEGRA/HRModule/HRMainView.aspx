<%@ Page Language="vb"  MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeBehind="HRMainView.aspx.vb" Inherits="Integra.HRMainView" %>
 <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <table width="100%">
<tr>
 <td align="right">
 </td>
 </tr>
 <tr>
<td align ="right" ><telerik:RadButton ID="btnAdd" runat="server"  Text="Add Employee" Skin="WebBlue"> </telerik:RadButton></td>
</tr>
<tr><td>
	    <telerik:RadGrid ID="dgHRModule" runat="server" CellSpacing="0"  AutoGenerateColumns="false"  Skin="WebBlue"  Visible="true" PageSize="50">
            <MasterTableView>
            <Columns>            
            <telerik:GridBoundColumn HeaderText="HRID" DataField="HRID" Display ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left"  />
            </telerik:GridBoundColumn>  
            <telerik:GridBoundColumn HeaderText="ECP Code" DataField="ECPCode" >
           <ItemStyle HorizontalAlign="Left" Width ="50px" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>  
              <telerik:GridBoundColumn HeaderText="Principal Group" DataField="PrincipalGroup">
            <ItemStyle HorizontalAlign="Left" Width="30px" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
             <telerik:GridBoundColumn HeaderText="HK Code" DataField="HKCode">
            <HeaderStyle Width="10%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn> 
            <telerik:GridBoundColumn HeaderText="HR Code" DataField="HRCode" >
           <ItemStyle HorizontalAlign="Left" Width ="50px" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>                
             <telerik:GridBoundColumn HeaderText="Name" DataField="EmployeeName" >
           <ItemStyle HorizontalAlign="Left" Width ="50px" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>   
           <telerik:GridBoundColumn HeaderText="Cell No" DataField="EmployeeCellNo">
            <HeaderStyle Width="10%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn> 
            <telerik:GridBoundColumn HeaderText="Date Of Joining" DataField="DateOfJoiningg">
            <ItemStyle HorizontalAlign="Left"  Width="30px"  />
            <HeaderStyle Width="10%" HorizontalAlign="Left"  />
            </telerik:GridBoundColumn>       
            <telerik:GridBoundColumn HeaderText="Total Leave" DataField="TotalLeaveGranted" >
            <ItemStyle HorizontalAlign="Left"  Width="30px"/>
            <HeaderStyle Width="10%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>   
            <telerik:GridBoundColumn HeaderText="Leave Availed" DataField="TotalLeaveAvailed" >
            <ItemStyle HorizontalAlign="Left"  Width="30px"/>
            <HeaderStyle Width="10%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>    
             <telerik:GridBoundColumn HeaderText="Balance" DataField="BalanceLeave" >
            <ItemStyle HorizontalAlign="Left"  Width="30px"/>
            <HeaderStyle Width="10%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>    
              <telerik:GridBoundColumn HeaderText="CNIC" DataField="CNIC" >
            <ItemStyle HorizontalAlign="Left"  Width="30px"/>
            <HeaderStyle Width="10%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>    
              <telerik:GridBoundColumn HeaderText="PasPort" DataField="PasPort" >
            <ItemStyle HorizontalAlign="Left"  Width="30px"/>
            <HeaderStyle Width="10%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>    
             <telerik:GridBoundColumn HeaderText="Driving Licence" DataField="DrivingLicence" >
            <ItemStyle HorizontalAlign="Left"  Width="30px"/>
            <HeaderStyle Width="10%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>                        
                  <telerik:GridTemplateColumn HeaderText ="View"  Display="true">
                  <ItemStyle HorizontalAlign="Left"  Width="30px"  />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
                <ItemTemplate >
                <asp:LinkButton ID="lnView"  runat ="server" CommandName ="EDIT" HeaderText ="View" Text="Edit" ></asp:LinkButton>
                </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
            </MasterTableView>
            <ClientSettings EnableRowHoverStyle="false" EnablePostBackOnRowClick="false">
<Selecting AllowRowSelect="false" EnableDragToSelectRows="false" />
 </ClientSettings>
            </telerik:RadGrid>
</td>			
</tr> 
</table>
 </asp:Content> 
 