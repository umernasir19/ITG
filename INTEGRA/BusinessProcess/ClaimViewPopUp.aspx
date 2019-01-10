<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeBehind="ClaimViewPopUp.aspx.vb" Inherits="Integra.ClaimViewPopUp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>

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
               <telerik:GridBoundColumn HeaderText="PO No." DataField="PONO" >
           <ItemStyle HorizontalAlign="Left" Width ="50px" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn> 
             <telerik:GridBoundColumn HeaderText="Customer" DataField="Aliass" >
           <ItemStyle HorizontalAlign="Left" Width ="50px" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn> 
             <telerik:GridBoundColumn HeaderText="Supplier" DataField="ShortName" >
           <ItemStyle HorizontalAlign="Left" Width ="50px" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn> 
              <telerik:GridBoundColumn HeaderText="Claim No" DataField="ClaimNo">
            <ItemStyle HorizontalAlign="Left"  Width="30px"  />
            <HeaderStyle Width="10%" HorizontalAlign="Left"  />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Claim Pcs" DataField="ClaimPcs" >
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
            </telerik:GridBoundColumn> --%>
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
            </Columns>
              <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                            <PagerStyle PageSizeControlType="RadComboBox" AlwaysVisible="true">
                            </PagerStyle>
            </MasterTableView>
            <ClientSettings EnableRowHoverStyle="false" EnablePostBackOnRowClick="false">
<Selecting AllowRowSelect="false" EnableDragToSelectRows="false" />
 <Selecting AllowRowSelect="True" />
 </ClientSettings>
         <HeaderStyle Font-Names="Microsoft Sans Serif" />
             <ItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif"  />
            </telerik:RadGrid>
    </div>
   </asp:Content> 