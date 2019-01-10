<%@ Page Language="vb"   MasterPageFile="~/MasterPage.master"  AutoEventWireup="false" CodeBehind="SamplingChart.aspx.vb" Inherits="Integra.SamplingChart" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
         <tr  style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #00509F;" 
                  visible="true";>
        <td><asp:Label ID="Label1" runat="server" Text="Style: "></asp:Label>
        <asp:Label ID="lblStyle" runat="server" Text=""></asp:Label>
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
                valign="bottom"> Sampling Module
  </th>
        </tr>
        <tr>
        <td>
           <telerik:RadButton ID="btnCustomized" runat="server" Text="Customized" Skin="WebBlue">  </telerik:RadButton>
        </td>
        </tr>
<tr>
<td>
      <telerik:RadGrid ID="dgTNASampling" runat="server" CellSpacing="0" 
                AutoGenerateColumns="false"  Skin="WebBlue"  
                Visible="true" Width="930px">
                  <AlternatingItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" />
            <MasterTableView>
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
            <Columns>
            
            <telerik:GridBoundColumn HeaderText="SampleTNAChartID" DataField="SampleTNAChartID" Display ="false">
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="3%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="StyleID" DataField="StyleID"  Display ="false" >
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="3%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>            
            <telerik:GridBoundColumn HeaderText="ProcessID" DataField="ProcessID" Display ="false"  >
            <HeaderStyle Width="3%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>
             <telerik:GridBoundColumn HeaderText="SelectedStatus" DataField="SelectedStatus" Display ="false"  >
            <HeaderStyle Width="3%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>
            <telerik:GridTemplateColumn HeaderText="Select" Display ="true"   AllowFiltering ="false">
              <itemstyle horizontalalign="Center"  width="10" />
                        <ItemTemplate>
                            <asp:CheckBox id="chkSelect" runat="server"  Checked='<% #Eval("Selected") %>' ></asp:CheckBox>
                        </ItemTemplate>
                        <HeaderStyle Width="3%" HorizontalAlign="Left" Font-Size="Smaller"/>
                    </telerik:GridTemplateColumn>           
            <telerik:GridBoundColumn HeaderText="Process" DataField="Process">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="7%" HorizontalAlign="center" /> 
            </telerik:GridBoundColumn>

            <telerik:GridBoundColumn HeaderText="Target Date" DataField="IdealDate">
            <ItemStyle HorizontalAlign="Left"  width="100" />
            <HeaderStyle Width="10%" HorizontalAlign="center" />
            </telerik:GridBoundColumn>

            	<telerik:GridTemplateColumn HeaderText="Estimated Date">
                  <HeaderStyle Width="8%" HorizontalAlign="Left" Font-Size="Smaller" /> 
                            <itemstyle horizontalalign="Center"  />
							 <ITEMTEMPLATE>
    <telerik:RadDatePicker ID="txtEstimatedDate" runat="server" Culture="en-US"  SelectedDate='<% #Eval("EstimatedDate") %>'  width="100">
<Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>
<DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" runat="server" DateFormat="dd/MM/yyyy" LabelWidth="30%"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                        </telerik:RadDatePicker>  
                            </ITEMTEMPLATE>
                                <headerstyle width="7%"  horizontalalign="Center"  />
							    </telerik:GridTemplateColumn>
 <telerik:GridTemplateColumn HeaderText="Submission"  AllowFiltering ="false">
                        <ItemTemplate>
                          <telerik:RadComboBox ID="cmbSubmission"  runat="server"  Skin="WebBlue" width="120" > 
                          <Items >
                            <telerik:RadComboBoxItem Text ="--"  Value ="0"/>
                          <telerik:RadComboBoxItem Text ="Ist Submission"  Value ="1" />
                          <telerik:RadComboBoxItem Text ="2nd Submission"  Value ="2" />
                          <telerik:RadComboBoxItem Text ="3rd Submission"  Value ="3"/>
                           <telerik:RadComboBoxItem Text ="4th Submission"  Value ="4"/>
                        
                          </Items>
                            </telerik:RadComboBox>
                         
                          </ItemTemplate>
                      <HeaderStyle Width="7%" HorizontalAlign="Center" Font-Size="Smaller" /> 
                        <ItemStyle HorizontalAlign="Left" />
             </telerik:GridTemplateColumn>
<telerik:GridTemplateColumn HeaderText="Actual Date">
                                  <HeaderStyle Width="8%" HorizontalAlign="Left" Font-Size="Smaller" /> 
                            <itemstyle horizontalalign="Center"  />
							 <ITEMTEMPLATE>
    <telerik:RadDatePicker ID="txtActualDate" runat="server" Culture="en-US"  text='<% #Eval("ActualDate") %>'  width="100">
<Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>
<DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" runat="server" DateFormat="dd/MM/yyyy" LabelWidth ="30%"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
                                  
							    
                       </ITEMTEMPLATE>
                                <headerstyle width="7%" HorizontalAlign="Center"/>
							 </telerik:GridTemplateColumn>

 <telerik:GridTemplateColumn HeaderText="Status"  AllowFiltering ="false">
                        <ItemTemplate>
                          <telerik:RadComboBox ID="cmbStatus"  runat="server"  Skin="WebBlue" width="165" > 
                          <Items >
                             <telerik:RadComboBoxItem Text ="--"  Value ="0"/>
                          <telerik:RadComboBoxItem Text ="Recieved from Supplier"  Value ="1" />
                          <telerik:RadComboBoxItem Text ="Approved(ECP)"  Value ="2" />
                          <telerik:RadComboBoxItem Text ="Rejected(ECP)"  Value ="3"/>
                           <telerik:RadComboBoxItem Text ="Sent to Buyer"  Value ="4"/>
                            <telerik:RadComboBoxItem Text ="Buyer Accept"  Value ="5"/>
                             <telerik:RadComboBoxItem Text ="Buyer Reject"  Value ="6"/>
                           
                          </Items>
                            </telerik:RadComboBox>
                         
                          </ItemTemplate>
                      <HeaderStyle Width="7%" HorizontalAlign="Center" Font-Size="Smaller" /> 
                        <ItemStyle HorizontalAlign="Left" />
             </telerik:GridTemplateColumn>
                               
               <telerik:GridTemplateColumn HeaderText="Remarks"  AllowFiltering ="false">
                        <ItemTemplate>
                         <telerik:RadTextBox  id="txtRemarks" runat="server" width="130" CssClass="textbox" Text='<% #Eval("Remarks") %>'></telerik:RadTextBox> 
                          </ItemTemplate>
                      <HeaderStyle Width="15%" HorizontalAlign="Center" Font-Size="Smaller" /> 
                        <ItemStyle HorizontalAlign="Left" />
             </telerik:GridTemplateColumn>
              <telerik:GridTemplateColumn HeaderText="/"  AllowFiltering ="false">
              <itemstyle horizontalalign="Center" />
                        <ItemTemplate>
                            <asp:Checkbox id="chkUpdate"  runat="server" Width ="10" ></asp:Checkbox> 
                        </ItemTemplate>
                            
                                <HeaderStyle Font-Names="Microsoft Sans Serif" />
                <ItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" Wrap="False" />
                          <ItemStyle HorizontalAlign="Left"  width="3" />  
                            <HeaderStyle Width="3%" HorizontalAlign="Center" Font-Size="Smaller" />                
                    </telerik:GridTemplateColumn> 

                <telerik:GridTemplateColumn HeaderText="History"  AllowFiltering ="false">
              <itemstyle horizontalalign="Center" />
                        <ItemTemplate>
                               <asp:HyperLink id="lnkEdit" Enabled ="true" NavigateUrl='<%# "SamplingChartHistory.aspx?lProcessID="& DataBinder.Eval(Container.DataItem,"ProcessID")&"&StyleID="& DataBinder.Eval(Container.DataItem,"StyleID")%>' Runat="server">History</asp:HyperLink>
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
         <ClientSettings Scrolling-AllowScroll="True" EnableRowHoverStyle="true" Scrolling-ScrollHeight="400px"></ClientSettings>
                <ItemStyle Font-Names="Microsoft Sans Serif" Font-Size="X-Small" Wrap="False" />
<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
<FilterMenu EnableImageSprites="False"></FilterMenu>
 </telerik:RadGrid>
        </td>
        </tr>
</table>
</asp:Content>