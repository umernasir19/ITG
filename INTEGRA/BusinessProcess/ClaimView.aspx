<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeBehind="ClaimView.aspx.vb" Inherits="Integra.ClaimView" %>
 <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <table width="100%">
<tr>
 <td align="right">
 </td>
 </tr>
 <tr>
<td align ="right" ><telerik:RadButton ID="btnAdd" runat="server"  Text="Add Claim" Skin="WebBlue"> </telerik:RadButton></td>
</tr>
<tr><td>
	    <telerik:RadGrid ID="dgPOClaimView" runat="server" CellSpacing="0"  AutoGenerateColumns="false" 
         Skin="WebBlue"  Visible="true" PageSize="50">
          <AlternatingItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" />
            <MasterTableView>
            <Columns>            
            <telerik:GridBoundColumn HeaderText="POClaimID" DataField="POClaimID" Display ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left"  />
            </telerik:GridBoundColumn>                
             <telerik:GridBoundColumn HeaderText="Activity Date" DataField="CreationDatee" >
           <ItemStyle HorizontalAlign="Left" Width ="50px" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>   
               <telerik:GridBoundColumn HeaderText="Claim Date" DataField="ClaimDatee" >
           <ItemStyle HorizontalAlign="Left" Width ="50px" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>   
               <telerik:GridBoundColumn HeaderText="Claim No" DataField="ClaimNo">
            <ItemStyle HorizontalAlign="Left"  Width="30px"  />
            <HeaderStyle Width="10%" HorizontalAlign="Left"  />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Claim Pcs" DataField="ClaimPcs">
            <ItemStyle HorizontalAlign="Left" Width="30px" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
               <telerik:GridBoundColumn HeaderText="Claim Amount" DataField="ClaimAmount">
            <HeaderStyle Width="10%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>   
            <telerik:GridBoundColumn HeaderText="Currency" DataField="Currency" >
            <ItemStyle HorizontalAlign="Left"  Width="30px"/>
            <HeaderStyle Width="10%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>                  
           
            <%-- <telerik:GridBoundColumn HeaderText="Claim Reason" DataField="ClaimReason">
            <ItemStyle HorizontalAlign="Left"  Width="30px"  />
            <HeaderStyle Width="20%" HorizontalAlign="Left"  />
            </telerik:GridBoundColumn>--%>
                          
                 <telerik:GridTemplateColumn HeaderText ="Claim Reason"  Display="true">
                <ItemTemplate >
                    <asp:Label ID="lblClaimReason" runat="server"  ></asp:Label>
                </ItemTemplate>
                </telerik:GridTemplateColumn>
                            
                 <telerik:GridTemplateColumn HeaderText ="PDF"  Display="true">
                <ItemTemplate >
                <asp:LinkButton ID="lnViewPdf"  runat ="server" CommandName ="PDF" HeaderText ="PDF" Text="PDF" ></asp:LinkButton>
                </ItemTemplate>
                </telerik:GridTemplateColumn>
               <telerik:GridTemplateColumn HeaderText ="View"  Display="true">
                  <ItemStyle HorizontalAlign="Left"  Width="30px"  />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
                <ItemTemplate >
                <asp:LinkButton ID="lnView"  runat ="server" CommandName ="EDIT" HeaderText ="View" Text="Edit" ></asp:LinkButton>
                </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>

            </MasterTableView>
             <HeaderStyle Font-Names="Microsoft Sans Serif" />
             <ItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif"  />
          <ClientSettings EnableRowHoverStyle="false" EnablePostBackOnRowClick="false">
<Selecting AllowRowSelect="false" EnableDragToSelectRows="false" />
 <Selecting AllowRowSelect="True" />
 </ClientSettings>
    
            </telerik:RadGrid>
                        
 
  </td>			
</tr> 

</table>
 </asp:Content> 
 