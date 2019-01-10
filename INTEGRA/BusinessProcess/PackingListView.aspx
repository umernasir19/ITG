<%@ Page Language="vb"  MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeBehind="PackingListView.aspx.vb" Inherits="Integra.PackingListView" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table width="100%">
    <tr>
    <td align="right">
      <telerik:RadButton ID="btnCreatePackingList" runat="server" Text="Create Packing List" Skin="WebBlue">
        </telerik:RadButton>
    </td>
    </tr>
    <tr>
    <td>
      <telerik:RadGrid ID="dgPackingListView" runat="server" AutoGenerateColumns="false"
       AllowFilteringByColumn="false" Width="100%" Skin="WebBlue">
          <MasterTableView>
            <Columns>
             <telerik:GridBoundColumn HeaderText="PackingListID" DataField="PackingListID" Display="false" >
                        <HeaderStyle Width="5px" />
                    </telerik:GridBoundColumn>
                     <telerik:GridBoundColumn HeaderText="Packing List No" DataField="PackingListNo" ShowFilterIcon="false" FilterControlWidth="60px">
                       
                    </telerik:GridBoundColumn>
                     <telerik:GridBoundColumn HeaderText="Invoice No" DataField="InvoiceNo" ShowFilterIcon="false" FilterControlWidth="60px">
                      
                    </telerik:GridBoundColumn>
                      <telerik:GridBoundColumn HeaderText="Total Carton" DataField="TotalCarton" ShowFilterIcon="false" FilterControlWidth="60px">
                      
                    </telerik:GridBoundColumn>
          <telerik:GridBoundColumn HeaderText="Gross Weight" DataField="GrossUM" ShowFilterIcon="false" FilterControlWidth="60px">
                                
                    </telerik:GridBoundColumn> 
                    
                      <telerik:GridBoundColumn HeaderText="Net Weight" DataField="NetWeight" ShowFilterIcon="false" FilterControlWidth="60px">
                            
                    </telerik:GridBoundColumn>
                     <telerik:GridBoundColumn HeaderText="Total Quantity" DataField="TotalQTY" ShowFilterIcon="false" FilterControlWidth="60px">
                            
                    </telerik:GridBoundColumn>
                       <telerik:GridTemplateColumn HeaderText ="PDF"  Display="true">
                <ItemTemplate >
                <asp:LinkButton ID="lnViewPdf"  runat ="server" CommandName ="PDF" HeaderText ="PDF" Text="PDF" ></asp:LinkButton>
                </ItemTemplate>
                </telerik:GridTemplateColumn>
                     <telerik:GridTemplateColumn AllowFiltering="false" 
                        HeaderText="Edit Packing List">
                        
                        <ItemTemplate>
                          
                            <asp:HyperLink ID="lnkEdit" runat="server" NavigateUrl='<%# "PackingListAdd.aspx?lPackingListID=" &amp; DataBinder.Eval(Container.DataItem,"PackingListID")%>'
                                Enabled="true" Font-Underline="false">
											Edit
                            </asp:HyperLink>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
            </Columns>
            </MasterTableView>
                     <ClientSettings EnableRowHoverStyle="false" EnablePostBackOnRowClick="false">
<Selecting AllowRowSelect="false" EnableDragToSelectRows="false" />
 <Selecting AllowRowSelect="True" />
 </ClientSettings>
    <HeaderStyle Font-Names="Microsoft Sans Serif" />
 <ItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" Wrap="False" />
        </telerik:RadGrid>
          </td>
    </tr>
         </table>
</asp:Content> 