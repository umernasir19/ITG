<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="CPChartViewNew.aspx.vb" Inherits="Integra.CPChartViewNew" %>
 <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
    <table style="width: 100%;">
          <%--'-------Heading Row--------'--%>
          <tr>

    <td   align="right"  >
    <asp:LinkButton ID="lnkReport" runat="server" CausesValidation="false"      >Print Customer CP</asp:LinkButton>
    </td>

</tr>
<tr>
<td align="right"  >
     <asp:LinkButton ID="lnkHistory" runat="server" CausesValidation="false"   >Print Customer CP History</asp:LinkButton>
    </td>

</tr>
           <tr style="height:40px;">
          <td valign ="top">
          
          <table>
      
        <tr  style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #00509F;" 
                  visible="true";>
        <td><asp:Label ID="lblBuyerHeading" runat="server" Text="Buyer: "></asp:Label>
        <asp:Label ID="lblBuyer" runat="server" ></asp:Label>
        <asp:Label ID="lblVendorH" runat="server" Text=" Vendor: "></asp:Label>
        <asp:Label ID="lblVendor" runat="server"  ></asp:Label>
        <asp:Label ID="lblPONOHeading" runat="server" Text=" PO No.:"></asp:Label><asp:Label ID="lblPONo" runat="server"  ></asp:Label></td>      
        </tr>
          </table>
        </td>    
        </tr>  
        <tr style="height:20px;">
          <td valign ="top" >
          <table> 
          <tr>
<td>
 
</td>
<td>
<asp:Label iD="lblMSG" CssClass="ErrorMsg"   runat="server"  ></asp:Label>
</td>
</tr> 
         </table>
          </td> 
     </tr>   
         <tr  >
         <td valign ="top" align="right">
          
           <telerik:RadButton ID="btnSave" runat="server" Text="Save All in 1 Go! " Skin="WebBlue"   >  </telerik:RadButton>
         
         </td>         
          </tr>
           <tr>
        <td colspan="6">
        
            <telerik:RadGrid ID="dgTNAChart" runat="server" CellSpacing="0" 
                AutoGenerateColumns="false"  Skin="WebBlue"  
                Visible="true">
                  <AlternatingItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" />
            <MasterTableView>
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
            <Columns>
            
            <telerik:GridBoundColumn HeaderText="Detail ID" DataField="CPChartID" Display ="false">
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="3%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="POID" DataField="POID"  Display ="false" >
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="3%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>            
            <telerik:GridBoundColumn HeaderText="CPProcessID" DataField="CPProcessID" Display ="false"  >
            <HeaderStyle Width="3%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>
                      
            <telerik:GridBoundColumn HeaderText="Process Route" DataField="CPProcess">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>

            

            	<telerik:GridTemplateColumn HeaderText="Expected Date">
                  <HeaderStyle Width="8%" HorizontalAlign="Left" Font-Size="Smaller" /> 
                            <itemstyle horizontalalign="Center"  />
							 <ITEMTEMPLATE>
    <telerik:RadDatePicker ID="txtExpectedDate" runat="server" Culture="en-US"     width="100">
<Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>
<DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" runat="server" DateFormat="dd/MM/yyyy" LabelWidth="30%"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                        </telerik:RadDatePicker>  
                            </ITEMTEMPLATE>
                                <headerstyle width="7%" />
							    </telerik:GridTemplateColumn>
                            	<telerik:GridTemplateColumn HeaderText="Actual Date">
                                  <HeaderStyle Width="8%" HorizontalAlign="Left" Font-Size="Smaller" /> 
                            <itemstyle horizontalalign="Center"  />
							 <ITEMTEMPLATE>
    <telerik:RadDatePicker ID="txtActualDate" runat="server" Culture="en-US"     width="100">
<Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>
<DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" runat="server" DateFormat="dd/MM/yyyy" LabelWidth ="30%"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
                                  
							    
                       </ITEMTEMPLATE>
                                <headerstyle width="7%" />
							 </telerik:GridTemplateColumn>
 
          

              <telerik:GridTemplateColumn HeaderText="/"  AllowFiltering ="false">
              <itemstyle horizontalalign="Center" />
                        <ItemTemplate>
                            <asp:Checkbox id="chkUpdate"  runat="server" Width ="10" ></asp:Checkbox> 
                        </ItemTemplate>
                            
                                <HeaderStyle Font-Names="Microsoft Sans Serif" />
                <ItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" Wrap="False" />
                          <ItemStyle HorizontalAlign="Left"  width="5%" />                 
                    </telerik:GridTemplateColumn> 
            
              
                    
                     <telerik:GridTemplateColumn HeaderText="History"  AllowFiltering ="false">
              <itemstyle horizontalalign="Center" />
                        <ItemTemplate>
                               <asp:HyperLink id="lnkEdit" Enabled ="true" NavigateUrl='<%# "CPChartViewHistory.aspx?lCPProcessID="& DataBinder.Eval(Container.DataItem,"CPProcessID")&"&lPOID="& DataBinder.Eval(Container.DataItem,"POID")%>' Runat="server">History</asp:HyperLink>
                        </ItemTemplate>
                        <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller"/>
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
    
   
    </div>
</asp:Content>
