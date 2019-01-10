<%@ Page Language="vb"  MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeBehind="LoanView.aspx.vb" Inherits="Integra.LoanView" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <table width="100%">
<tr>
 <td align="right">
 </td>
 </tr>
 <tr>
<td align ="right" >   <telerik:RadButton ID="btnAdd" runat="server" Text="Process For Loan"   Skin="WebBlue">
                </telerik:RadButton></td>
</tr>
<tr><td>
	    <telerik:RadGrid ID="dgLoanView" runat="server" CellSpacing="0"  AutoGenerateColumns="false"  Skin="WebBlue"  Visible="true" PageSize="50">
            <MasterTableView>
            <Columns>            
            <telerik:GridBoundColumn HeaderText="LoanMasterID" DataField="LoanMasterID" Display ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left"  />
            </telerik:GridBoundColumn>  
            <telerik:GridBoundColumn HeaderText="Name" DataField="EmployeeName">
           <ItemStyle HorizontalAlign="Left" Width ="50px" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>  
            <telerik:GridBoundColumn HeaderText="NIC No" DataField="NICNo">
           <ItemStyle HorizontalAlign="Left" Width ="50px" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>  
            <telerik:GridBoundColumn HeaderText="Principal Amount" DataField="PrincipalAmount"  DataFormatString="{0:#,##0;(#,##0);0}">
           <ItemStyle HorizontalAlign="Left" Width ="50px" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>  
              <telerik:GridBoundColumn HeaderText="Installment Amount" DataField="InstallmentAmount"  DataFormatString="{0:#,##0;(#,##0);0}">
            <ItemStyle HorizontalAlign="Left" Width="30px" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
             <telerik:GridBoundColumn HeaderText="Period" DataField="TotalInstallmenMonth">
            <HeaderStyle Width="10%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn> 
            <telerik:GridBoundColumn HeaderText="Year" DataField="InstallmentYearFrom" >
           <ItemStyle HorizontalAlign="Left" Width ="50px" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>    
              <telerik:GridBoundColumn HeaderText="Status" DataField="Statuss" >
           <ItemStyle HorizontalAlign="Left" Width ="50px" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>                
             
                <telerik:GridTemplateColumn HeaderText ="View"  Display="true">
                  <ItemStyle HorizontalAlign="Left"  Width="30px"  />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
                <ItemTemplate >
                <asp:LinkButton ID="lnView"  runat ="server" CommandName ="EDIT" HeaderText ="View" Text="Edit" ></asp:LinkButton>
                </ItemTemplate>
                </telerik:GridTemplateColumn> 
                 <telerik:GridTemplateColumn HeaderText ="PDF"  Display="true">
              <ItemStyle HorizontalAlign="Left"  Width="7px"  />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
                <ItemTemplate >
                <asp:LinkButton ID="lnViewPdf"  runat ="server" CommandName ="PDF" HeaderText ="PDF" Text="PDF" ></asp:LinkButton>
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
 