<%@ Page Language="vb"   AutoEventWireup="false" CodeBehind="TNAChartViewPDM.aspx.vb" Inherits="Integra.TNAChartViewPDM" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>TNAChart View PDM</title>

</head>
<body>
    <form id="form1" runat="server">
  <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"  >
    </asp:ScriptManager>
 
    <table width="100%">
<tr>
<td align="right"  >
    
    </td>

</tr>
           <tr style="height:40px;">
          <td valign ="top">
          
          <table>
      
        <tr  style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #00509F;" 
                  visible="true";>
        <td><asp:Label ID="lblBuyerHeading" runat="server" Text="BUYER: "></asp:Label>
        <asp:Label ID="lblBuyer" runat="server" ></asp:Label>
      
       </td>      
        </tr>
        <tr style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #00509F;" 
                  visible="true";>
        <td>
          <asp:Label ID="lblVendorH" runat="server" Text=" VENDOR: "></asp:Label>
        <asp:Label ID="lblVendor" runat="server"  ></asp:Label>
        </td>
        </tr>
        <tr style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #00509F;" 
                  visible="true";>
        <td>
         <asp:Label ID="lblPONOHeading" runat="server" Text=" PO No.:"></asp:Label><asp:Label ID="lblPONo" runat="server"  ></asp:Label>
        </td>
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
<td >
<asp:Label iD="lblMSG" runat="server" Font-Bold="True" Font-Names="Century Gothic" 
        Font-Size="Small" ForeColor="#FF3300"  ></asp:Label>
</td>
</tr> 
         </table>
          </td> 
     </tr>   
         <tr  >
         <td valign ="top" align="left"><telerik:RadButton ID="btnCustomise" runat="server" Text="Customize" Skin="WebBlue">  </telerik:RadButton></td>
        </tr> <tr>
         <td valign ="top" align="right">
          
           <telerik:RadButton ID="btnSave" runat="server" Text="Save All in 1 Go! " Skin="WebBlue">  </telerik:RadButton>
         
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
            
            <telerik:GridBoundColumn HeaderText="Detail ID" DataField="TNAChartID" Display ="false">
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="3%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="POID" DataField="POID"  Display ="false" >
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="3%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>            
            <telerik:GridBoundColumn HeaderText="ProcessID" DataField="ProcessID" Display ="false"  >
            <HeaderStyle Width="3%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>
            <telerik:GridTemplateColumn HeaderText="Select" Display ="true"   AllowFiltering ="false">
              <itemstyle horizontalalign="Center"  width="10" />
                        <ItemTemplate>
                            <asp:CheckBox id="chkSelect" runat="server" checked='<% #Eval("Selected") %>' ></asp:CheckBox>
                        </ItemTemplate>
                        <HeaderStyle Width="3%" HorizontalAlign="Left" Font-Size="Smaller"/>
                    </telerik:GridTemplateColumn>           
            <telerik:GridBoundColumn HeaderText="Process Route" DataField="Process">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>

            <telerik:GridBoundColumn HeaderText="Target Date" DataField="IdealDate">
            <ItemStyle HorizontalAlign="Center"  width="100" />
            <HeaderStyle Width="10%" HorizontalAlign="Center" />
            </telerik:GridBoundColumn>

            	<telerik:GridTemplateColumn HeaderText="Estimated Date" Display ="false"  >
                  <HeaderStyle Width="8%" HorizontalAlign="Center" Font-Size="Smaller" /> 
                            <itemstyle horizontalalign="Center"  />
							 <ITEMTEMPLATE>
    <telerik:RadDatePicker Visible ="false"  ID="txtEstimatedDate" runat="server" Culture="en-US"  text='<% #Eval("EstimatedDate") %>'  width="100">
<Calendar ID="Calendar1" Visible ="false"  runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>
<DateInput ID="DateInput1" Visible ="false"  DisplayDateFormat="dd/MM/yyyy" runat="server" DateFormat="dd/MM/yyyy" LabelWidth="30%"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl="" Visible ="false" ></DatePopupButton>
                        </telerik:RadDatePicker>  
                            </ITEMTEMPLATE>
                                <headerstyle width="7%" />
							    </telerik:GridTemplateColumn>
                            	<telerik:GridTemplateColumn HeaderText="Actual Date"    >
                                  <HeaderStyle Width="8%" HorizontalAlign="Center" Font-Size="Smaller" /> 
                            <itemstyle horizontalalign="Center"  />
							 <ITEMTEMPLATE>
    <telerik:RadDatePicker   ID="txtActualDate" runat="server" Culture="en-US"  text='<% #Eval("ActualDate") %>'  width="100">
<Calendar ID="Calendar1"   runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>
<DateInput ID="DateInput1"   DisplayDateFormat="dd/MM/yyyy" runat="server" DateFormat="dd/MM/yyyy" LabelWidth ="30%"></DateInput>
<DatePopupButton ImageUrl=""   HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
                                  
							    
                       </ITEMTEMPLATE>
                                <headerstyle width="7%" />
							 </telerik:GridTemplateColumn>
 
             <telerik:GridTemplateColumn HeaderText="Yield (%)"  AllowFiltering ="false">
                        <ItemTemplate>
                        <telerik:RadTextBox id="txtQuantityCmpltd" runat="server" CssClass="textbox" text='<% #Eval("QtyCompleted") %>' width="40"> </telerik:RadTextBox> 
                          </ItemTemplate>
                      <HeaderStyle Width="5%" HorizontalAlign="Center" Font-Size="Smaller" /> 
                        <ItemStyle HorizontalAlign="Left" />
             </telerik:GridTemplateColumn>

              <telerik:GridTemplateColumn HeaderText="Status"  AllowFiltering ="false">
                        <ItemTemplate>
                          <telerik:RadComboBox ID="cmbStatus"  cssclass="textbox" runat="server"  Skin="WebBlue" width="80" > 
                          <Items >
                          <telerik:RadComboBoxItem Text ="--"  Value ="0" />
                          <telerik:RadComboBoxItem Text ="Pending"  Value ="1" />
                          <telerik:RadComboBoxItem Text ="Completed"  Value ="2"/>
                          </Items>
                            </telerik:RadComboBox>
                         
                          </ItemTemplate>
                      <HeaderStyle Width="7%" HorizontalAlign="Center" Font-Size="Smaller" /> 
                        <ItemStyle HorizontalAlign="Center" />
             </telerik:GridTemplateColumn>

               <telerik:GridTemplateColumn HeaderText="Remarks"  AllowFiltering ="false">
                        <ItemTemplate>
                         <telerik:RadTextBox  id="txtRemarks" runat="server" width="130" CssClass="textbox" text='<% #Eval("Remarks") %>'></telerik:RadTextBox> 
                          </ItemTemplate>
                      <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" /> 
                        <ItemStyle HorizontalAlign="Left" />
             </telerik:GridTemplateColumn>
              <telerik:GridTemplateColumn HeaderText="/"  AllowFiltering ="false">
              <itemstyle horizontalalign="Center" width="3%"  />
                        <ItemTemplate>
                            <asp:Checkbox id="chkUpdate"  runat="server" Width ="10" ></asp:Checkbox> 
                        </ItemTemplate>
                            
                                <HeaderStyle Font-Names="Microsoft Sans Serif" />
                <ItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" Wrap="False" />
                          <ItemStyle HorizontalAlign="Left"  />                 
                    </telerik:GridTemplateColumn> 
                    
                     <telerik:GridTemplateColumn HeaderText="History"  AllowFiltering ="false" Display="false">
              <itemstyle horizontalalign="Center" />
                        <ItemTemplate>
                               <asp:HyperLink id="lnkEdit" Enabled ="true" NavigateUrl='<%# "TNAHistory.aspx?lProcessID="& DataBinder.Eval(Container.DataItem,"ProcessID")&"&lPOID="& DataBinder.Eval(Container.DataItem,"POID")%>' Runat="server">History</asp:HyperLink>
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
      <tr>
      <td>
      <asp:GridView ID="dgEFile" runat="server" AutoGenerateColumns="False" 
   CellPadding="4" Font-Size="Small" ForeColor="#333333" GridLines="both">
    <COLUMNS>
                               <asp:TemplateField HeaderText="S.No." >
                               <ItemTemplate>    
                                   <%# CType(Container, GridViewRow).RowIndex + 1 %>
                               </ItemTemplate>
                                     <itemstyle horizontalalign="center" />
                                <headerstyle width="5%" horizontalalign="center"  />
                            </asp:TemplateField>
							<ASP:BoundField HeaderText="CP Process"
									 DataField="Process" >
                                    <itemstyle horizontalalign="center" />
								 <headerstyle width="15%" horizontalalign="center"  />
							</ASP:BoundField>
								<ASP:BoundField HeaderText="Target Date" visible="false" 
									 DataField="IdealDate" >
                                    <itemstyle horizontalalign="center" />
								 <headerstyle width="8%" horizontalalign="center"  />
							</ASP:BoundField>
								<ASP:BoundField HeaderText="Estimated Date" visible="false" 
									 DataField="EstimatedDate" >
                                    <itemstyle horizontalalign="center" />
								 <headerstyle width="8%" horizontalalign="center"  />
							</ASP:BoundField>
									<ASP:BoundField HeaderText="Completion Date"  
									DataField="ActualDate" >
                                    <itemstyle horizontalalign="center" />
								 <headerstyle width="8%" horizontalalign="center"  />
							</ASP:BoundField>
							<ASP:BoundField HeaderText="Yield (%)"  visible="false" 
									 DataField="QtyCompleted" >
                                    <itemstyle horizontalalign="center" />
								 <headerstyle width="7%" horizontalalign="center"  />
							</ASP:BoundField>
							<ASP:BoundField HeaderText="Status"
									 DataField="Status" >
                                    <itemstyle horizontalalign="center" />
								 <headerstyle width="7%" horizontalalign="center"  />
							</ASP:BoundField>
							<ASP:BoundField HeaderText="Remarks"
									 DataField="Remarks" >
                                    <itemstyle horizontalalign="center" />
								 <headerstyle width="10%" horizontalalign="center"  />
							</ASP:BoundField> 									 
							</COLUMNS>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <EditRowStyle BackColor="#999999" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
      </asp:GridView>
      </td>
      </tr>
    </table>
  
    </form>
</body>
</html>
