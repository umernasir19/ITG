<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="TNAChartNew.aspx.vb" Inherits="Integra.TNAChartNew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
   <tr  style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #00509F;" 
                  visible="true";>
        <td><asp:Label ID="lblBuyerHeading" runat="server" Text="Buyer: "></asp:Label>
        <asp:Label ID="lblBuyer" runat="server" ></asp:Label>
        <asp:Label ID="lblVendorH" runat="server" Text=" Vendor: "></asp:Label>
        <asp:Label ID="lblVendor" runat="server"  ></asp:Label>
        <asp:Label ID="lblPONOHeading" runat="server" Text=" PO No.:"></asp:Label><asp:Label ID="lblPONo" runat="server"  ></asp:Label></td>      
        </tr>
        <tr>
        <td>
        </td>
        </tr>
        <tr>
        <td>
        <asp:Label iD="lblMSG" CssClass="ErrorMsg"   runat="server"  ></asp:Label>
        </td>
        </tr>
        <tr>
        <td valign ="top" align="right">
         <telerik:RadButton ID="btnSave" runat="server" Text="Save All in 1 Go! " Skin="WebBlue">  </telerik:RadButton>
        </td>
        </tr>
 <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;" 
              visible="true";>
        <th colspan ="6" align="left"
             style="font-family: 'Calibri'; font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit; height: 29px;" 
                valign="bottom"> Critical Shell
  </th>
        </tr>
<tr>
<td>
      <telerik:RadGrid ID="dgTNACriticalPath" runat="server" CellSpacing="0" 
                AutoGenerateColumns="false"  Skin="WebBlue"  
                Visible="true" Width="930px">
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
            <telerik:GridTemplateColumn HeaderText="Select" Display ="false"   AllowFiltering ="false">
              <itemstyle horizontalalign="Center"  width="10" />
                        <ItemTemplate>
                            <asp:CheckBox id="chkSelect" runat="server"  Checked='<% #Eval("Selected") %>' ></asp:CheckBox>
                        </ItemTemplate>
                        <HeaderStyle Width="3%" HorizontalAlign="Left" Font-Size="Smaller"/>
                    </telerik:GridTemplateColumn>           
            <telerik:GridBoundColumn HeaderText="Process Route" DataField="Process">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>

            <telerik:GridBoundColumn HeaderText="Target Date" DataField="IdealDate">
            <ItemStyle HorizontalAlign="Left"  width="100" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>

            	<telerik:GridTemplateColumn HeaderText="Estimated Date">
                  <HeaderStyle Width="8%" HorizontalAlign="Left" Font-Size="Smaller" /> 
                            <itemstyle horizontalalign="Center"  />
							 <ITEMTEMPLATE>
    <telerik:RadDatePicker ID="txtEstimatedDate" runat="server" Culture="en-US"  SelectedDate='<% #Eval("DateEstemated") %>'  width="100">
<Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>
<DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" runat="server" DateFormat="dd/MM/yyyy" LabelWidth="30%"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                        </telerik:RadDatePicker>  
                            </ITEMTEMPLATE>
                                <headerstyle width="7%" />
							    </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Parameter"  AllowFiltering ="false">
                        <ItemTemplate>
                         <telerik:RadTextBox  id="txtParameter" runat="server" width="90"   Text='<% #Eval("Parameter") %>'></telerik:RadTextBox> 
                          </ItemTemplate>
                      <HeaderStyle Width="10%" HorizontalAlign="Left" Font-Size="Smaller" /> 
                        <ItemStyle HorizontalAlign="Left" />
             </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Unit"  AllowFiltering ="false">
                        <ItemTemplate>
                         <telerik:RadTextBox  id="txtParameterUnit" runat="server" width="60"  Text='<% #Eval("ParameterUnit") %>'></telerik:RadTextBox> 
                          </ItemTemplate>
                      <HeaderStyle Width="10%" HorizontalAlign="Left" Font-Size="Smaller" /> 
                        <ItemStyle HorizontalAlign="Left" />
             </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Total Capacity/Day"  AllowFiltering ="false">
                        <ItemTemplate>
                         <telerik:RadTextBox  id="txtTotalCapacity" runat="server" width="90"  Text='<% #Eval("TotalCapacity") %>'></telerik:RadTextBox> 
                          </ItemTemplate>
                      <HeaderStyle Width="10%" HorizontalAlign="Left" Font-Size="Smaller" /> 
                        <ItemStyle HorizontalAlign="Left" />
             </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Unit"  AllowFiltering ="false">
                        <ItemTemplate>
                         <telerik:RadTextBox  id="txtCapacityUnit" runat="server" width="40" Text='<% #Eval("CapacityUnit") %>'></telerik:RadTextBox> 
                          </ItemTemplate>
                      <HeaderStyle Width="10%" HorizontalAlign="Left" Font-Size="Smaller" /> 
                        <ItemStyle HorizontalAlign="Left" />
             </telerik:GridTemplateColumn>
               <telerik:GridTemplateColumn HeaderText="Required"  AllowFiltering ="false">
                        <ItemTemplate>
                         <telerik:RadTextBox  id="txtRequired" runat="server" width="90" CssClass="textbox" Text='<% #Eval("Required") %>'></telerik:RadTextBox> 
                          </ItemTemplate>
                      <HeaderStyle Width="10%" HorizontalAlign="Left" Font-Size="Smaller" /> 
                        <ItemStyle HorizontalAlign="Left" />
             </telerik:GridTemplateColumn>
               <telerik:GridTemplateColumn HeaderText="Unit"  AllowFiltering ="false">
                        <ItemTemplate>
                         <telerik:RadTextBox  id="txtRequiredUnit" runat="server" width="40"   Text='<% #Eval("RequiredUnit") %>'></telerik:RadTextBox> 
                          </ItemTemplate>
                      <HeaderStyle Width="10%" HorizontalAlign="Left" Font-Size="Smaller" /> 
                        <ItemStyle HorizontalAlign="Left" />
             </telerik:GridTemplateColumn>
                            	<telerik:GridTemplateColumn HeaderText="Actual Date">
                                  <HeaderStyle Width="8%" HorizontalAlign="Left" Font-Size="Smaller" /> 
                            <itemstyle horizontalalign="Center"  />
							 <ITEMTEMPLATE>
    <telerik:RadDatePicker ID="txtActualDate" runat="server" Culture="en-US"  SelectedDate='<% #Eval("ActualDate") %>'  width="100">
<Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>
<DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" runat="server" DateFormat="dd/MM/yyyy" LabelWidth ="30%"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
                                  
							    
                       </ITEMTEMPLATE>
                                <headerstyle width="7%" />
							 </telerik:GridTemplateColumn>
 
             <telerik:GridTemplateColumn HeaderText="Submission"  AllowFiltering ="false">
                        <ItemTemplate>
                        <telerik:RadTextBox id="txtQuantityCmpltd" runat="server"   Text='<% #Eval("QtyCompleted") %>' width="40"> </telerik:RadTextBox> 
                          </ItemTemplate>
                      <HeaderStyle Width="5%" HorizontalAlign="Left" Font-Size="Smaller" /> 
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
                      <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" /> 
                        <ItemStyle HorizontalAlign="Left" />
             </telerik:GridTemplateColumn>

               <telerik:GridTemplateColumn HeaderText="Remarks"  AllowFiltering ="false">
                        <ItemTemplate>
                         <telerik:RadTextBox  id="txtRemarks" runat="server" width="130" Text='<% #Eval("Remarks") %>'></telerik:RadTextBox> 
                          </ItemTemplate>
                      <HeaderStyle Width="15%" HorizontalAlign="Left" Font-Size="Smaller" /> 
                        <ItemStyle HorizontalAlign="Left" />
             </telerik:GridTemplateColumn>
              <telerik:GridTemplateColumn HeaderText="/"  AllowFiltering ="false">
              <itemstyle horizontalalign="Center" />
                        <ItemTemplate>
                            <asp:Checkbox id="chkUpdate"  runat="server" Width ="10" ></asp:Checkbox> 
                        </ItemTemplate>
                            
                                <HeaderStyle Font-Names="Microsoft Sans Serif" />
                <ItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" Wrap="False" />
                          <ItemStyle HorizontalAlign="Left"  width="5" />                 
                    </telerik:GridTemplateColumn> 
                    
                     <telerik:GridTemplateColumn HeaderText="History"  AllowFiltering ="false">
              <itemstyle horizontalalign="Center" />
                        <ItemTemplate>
                               <asp:HyperLink id="lnkEdit" Enabled ="true" NavigateUrl='<%# "TNAHistory.aspx?lProcessID="& DataBinder.Eval(Container.DataItem,"ProcessID")&"&lPOID="& DataBinder.Eval(Container.DataItem,"POID")%>' Runat="server">History</asp:HyperLink>
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
       <ClientSettings Scrolling-AllowScroll="True" EnableRowHoverStyle="true" Scrolling-ScrollHeight="480px"></ClientSettings>
                <ItemStyle Font-Names="Microsoft Sans Serif" Font-Size="X-Small" Wrap="False" />
<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
<FilterMenu EnableImageSprites="False"></FilterMenu>
 </telerik:RadGrid>
</td>
</tr>
 <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;" 
              visible="true";>
        <th colspan ="6" align="left"
  
                
                style="font-family: 'Calibri'; font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit; height: 29px;" 
                valign="bottom"> Production Shell
  </th>
        </tr>
        <tr>
        <td>
              <telerik:RadGrid ID="dgTNAProductionStatus" runat="server" CellSpacing="0" 
                AutoGenerateColumns="false"  Skin="WebBlue"  
                Visible="true" Width="930px" Height="640px">
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
            <telerik:GridTemplateColumn HeaderText="Select" Display ="false"   AllowFiltering ="false">
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
            <ItemStyle HorizontalAlign="Left"  width="100" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>

            	<telerik:GridTemplateColumn HeaderText="Estimated Date">
                  <HeaderStyle Width="8%" HorizontalAlign="Left" Font-Size="Smaller" /> 
                            <itemstyle horizontalalign="Center"  />
							 <ITEMTEMPLATE>
    <telerik:RadDatePicker ID="txtEstimatedDate" runat="server" Culture="en-US" SelectedDate='<% #Eval("DateEstemated") %>'  width="100">
<Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>
<DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" runat="server" DateFormat="dd/MM/yyyy" LabelWidth="30%"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                        </telerik:RadDatePicker>  
                            </ITEMTEMPLATE>
                                <headerstyle width="7%" />
							    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Parameter"  AllowFiltering ="false">
                        <ItemTemplate>
                         <telerik:RadTextBox  id="txtParameter" runat="server" width="90" CssClass="textbox" Text='<% #Eval("Parameter") %>'></telerik:RadTextBox> 
                          </ItemTemplate>
                      <HeaderStyle Width="10%" HorizontalAlign="Left" Font-Size="Smaller" /> 
                        <ItemStyle HorizontalAlign="Left" />
             </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Unit"  AllowFiltering ="false">
                        <ItemTemplate>
                         <telerik:RadTextBox  id="txtParameterUnit" runat="server" width="60" CssClass="textbox" Text='<% #Eval("ParameterUnit") %>'></telerik:RadTextBox> 
                          </ItemTemplate>
                      <HeaderStyle Width="10%" HorizontalAlign="Left" Font-Size="Smaller" /> 
                        <ItemStyle HorizontalAlign="Left" />
             </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Total Capacity/Day"  AllowFiltering ="false">
                        <ItemTemplate>
                         <telerik:RadTextBox  id="txtTotalCapacity" runat="server" width="90" CssClass="textbox" Text='<% #Eval("TotalCapacity") %>'></telerik:RadTextBox> 
                          </ItemTemplate>
                      <HeaderStyle Width="10%" HorizontalAlign="Left" Font-Size="Smaller" /> 
                        <ItemStyle HorizontalAlign="Left" />
             </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Unit"  AllowFiltering ="false">
                        <ItemTemplate>
                         <telerik:RadTextBox  id="txtCapacityUnit" runat="server" width="40" CssClass="textbox" Text='<% #Eval("CapacityUnit") %>'></telerik:RadTextBox> 
                          </ItemTemplate>
                      <HeaderStyle Width="10%" HorizontalAlign="Left" Font-Size="Smaller" /> 
                        <ItemStyle HorizontalAlign="Left" />
             </telerik:GridTemplateColumn>
               <telerik:GridTemplateColumn HeaderText="Required"  AllowFiltering ="false">
                        <ItemTemplate>
                         <telerik:RadTextBox  id="txtRequired" runat="server" width="90" CssClass="textbox" Text='<% #Eval("Required") %>'></telerik:RadTextBox> 
                          </ItemTemplate>
                      <HeaderStyle Width="10%" HorizontalAlign="Left" Font-Size="Smaller" /> 
                        <ItemStyle HorizontalAlign="Left" />
             </telerik:GridTemplateColumn>
               <telerik:GridTemplateColumn HeaderText="Unit"  AllowFiltering ="false">
                        <ItemTemplate>
                         <telerik:RadTextBox  id="txtRequiredUnit" runat="server" width="40" CssClass="textbox" Text='<% #Eval("RequiredUnit") %>'></telerik:RadTextBox> 
                          </ItemTemplate>
                      <HeaderStyle Width="10%" HorizontalAlign="Left" Font-Size="Smaller" /> 
                        <ItemStyle HorizontalAlign="Left" />
             </telerik:GridTemplateColumn>
                            	<telerik:GridTemplateColumn HeaderText="Actual Date">
                                  <HeaderStyle Width="8%" HorizontalAlign="Left" Font-Size="Smaller" /> 
                            <itemstyle horizontalalign="Center"  />
							 <ITEMTEMPLATE>
    <telerik:RadDatePicker ID="txtActualDate" runat="server" Culture="en-US"  SelectedDate='<% #Eval("ActualDate") %>'  width="100">
<Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>
<DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" runat="server" DateFormat="dd/MM/yyyy" LabelWidth ="30%"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
                                  
							    
                       </ITEMTEMPLATE>
                                <headerstyle width="7%" />
							 </telerik:GridTemplateColumn>
 
             <telerik:GridTemplateColumn HeaderText="Yield (%)"  AllowFiltering ="false">
                        <ItemTemplate>
                        <telerik:RadTextBox id="txtQuantityCmpltd" runat="server" CssClass="textbox" Text='<% #Eval("QtyCompleted") %>' width="40"> </telerik:RadTextBox> 
                          </ItemTemplate>
                      <HeaderStyle Width="5%" HorizontalAlign="Left" Font-Size="Smaller" /> 
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
                      <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" /> 
                        <ItemStyle HorizontalAlign="Left" />
             </telerik:GridTemplateColumn>

               <telerik:GridTemplateColumn HeaderText="Remarks"  AllowFiltering ="false">
                        <ItemTemplate>
                         <telerik:RadTextBox  id="txtRemarks" runat="server" width="130" CssClass="textbox" Text='<% #Eval("Remarks") %>'></telerik:RadTextBox> 
                          </ItemTemplate>
                      <HeaderStyle Width="15%" HorizontalAlign="Left" Font-Size="Smaller" /> 
                        <ItemStyle HorizontalAlign="Left" />
             </telerik:GridTemplateColumn>
              <telerik:GridTemplateColumn HeaderText="/"  AllowFiltering ="false">
              <itemstyle horizontalalign="Center" />
                        <ItemTemplate>
                            <asp:Checkbox id="chkUpdate"  runat="server" Width ="10" ></asp:Checkbox> 
                        </ItemTemplate>
                            
                                <HeaderStyle Font-Names="Microsoft Sans Serif" />
                <ItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" Wrap="False" />
                          <ItemStyle HorizontalAlign="Left"  width="5" />                 
                    </telerik:GridTemplateColumn> 
                    
                     <telerik:GridTemplateColumn HeaderText="History"  AllowFiltering ="false">
              <itemstyle horizontalalign="Center" />
                        <ItemTemplate>
                               <asp:HyperLink id="lnkEdit" Enabled ="true" NavigateUrl='<%# "TNAHistory.aspx?lProcessID="& DataBinder.Eval(Container.DataItem,"ProcessID")&"&lPOID="& DataBinder.Eval(Container.DataItem,"POID")%>' Runat="server">History</asp:HyperLink>
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
         <ClientSettings Scrolling-AllowScroll="True" EnableRowHoverStyle="true" Scrolling-ScrollHeight="500px"></ClientSettings>
                <ItemStyle Font-Names="Microsoft Sans Serif" Font-Size="X-Small" Wrap="False" />
<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
<FilterMenu EnableImageSprites="False"></FilterMenu>
 </telerik:RadGrid>
        </td>
        </tr>
</table>
</asp:Content>
