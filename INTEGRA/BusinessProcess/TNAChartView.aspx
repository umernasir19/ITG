<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeBehind="TNAChartView.aspx.vb" Inherits="Integra.TNAChartView" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table style="width: 100%">
            <%--'-------Heading Row--------'--%>
          
            <tr>
                <td align="right">
                    <asp:LinkButton ID="lnkReport" runat="server" CausesValidation="false">Print Milestone</asp:LinkButton>
                    <asp:LinkButton ID="lnkReportCustomer" runat="server" Visible="false" CausesValidation="false">Print Customer Version</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:LinkButton ID="lnkHistory" runat="server" CausesValidation="false">Print Milestone History</asp:LinkButton>
                    <asp:LinkButton ID="lnkHistoryCustomer" Visible="false" runat="server" CausesValidation="false">Print Customer Version History</asp:LinkButton>
                </td>
            </tr>
            <tr style="height: 40px;">
                <td valign="top">
                    <table>
                        <tr style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #00509F;"
                            visible="true">
                            <td>
                                <asp:Label ID="lblBuyerHeading" runat="server" Text="Buyer: "></asp:Label>
                                <asp:Label ID="lblBuyer" runat="server"></asp:Label>
                                <asp:Label ID="lblVendorH" runat="server" Text=" Vendor: "></asp:Label>
                                <asp:Label ID="lblVendor" runat="server"></asp:Label>
                                <asp:Label ID="lblPONOHeading" runat="server" Text=" SR No.:"></asp:Label><asp:Label
                                    ID="lblPONo" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr style="height: 20px;">
                <td valign="top">
                    <table>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="lblMSG" CssClass="ErrorMsg" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            </table><table>
            <tr>
                <td style="width: 128px; height: 30px;">
                    <asp:Label ID="Label1" runat="server" Text="Production Status" Width="130px"></asp:Label>
                </td>
                <td style="width: 128px; height: 30px;">
                    <asp:TextBox ID="txtProductionstatus" runat="server" CssClass="textbox" TextMode="Multiline"
                        Style="border: 1px Solid #848284; width: 460px; margin-left: 0px;"></asp:TextBox>
                </td>
            </tr>
             </table><table>
            <tr  style ="height :34px;">
                <td>
                    <telerik:RadButton ID="btnNotApplicable" runat="server" Text="Not Applicable" Skin="WebBlue">
                    </telerik:RadButton>
                    <telerik:RadButton ID="btnSave" runat="server" Text="Save All in 1 Go! " Skin="WebBlue">
                    </telerik:RadButton>
                </td>
            </tr>
            <tr>
                <td valign="top" align="left">
                    <telerik:RadButton ID="btnCheckAll" runat="server" Text="Check All" Skin="WebBlue" VISIBLE="false" >
                    </telerik:RadButton>
                </td>
            </tr>
           </table>
        <table>
            <tr>
                <td>
                   <div style="width: 930px;">
                    <telerik:RadGrid ID="dgTNAChart" runat="server" CellSpacing="0" AutoGenerateColumns="false"
                        Skin="WebBlue" Visible="true" Width="100%">
                        <AlternatingItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" />
                        <MasterTableView>
                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn HeaderText="Detail ID" DataField="TNAChartID" Display="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="1%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="POID" DataField="POID" Display="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="1%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="ProcessID" DataField="ProcessID" Display="false">
                                    <HeaderStyle Width="1%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="Select" Display="false" AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Center" Width="10" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelect" runat="server" Checked='<% #Eval("Selected") %>'></asp:CheckBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="3%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn HeaderText="Process Route" DataField="Process">
                                    <ItemStyle HorizontalAlign="Left" Width="10px" />
                                    <HeaderStyle Width="25%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Target Date" DataField="IdealDate">
                                    <ItemStyle HorizontalAlign="Left" Width="100" />
                                    <HeaderStyle Width="10%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="Estimated Date">
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <telerik:RadDatePicker ID="txtEstimatedDate" runat="server" Culture="en-US" Width="100px" Enabled="true">
                                            <Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" Enabled ="true">
                                            </Calendar>
                                            <DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" runat="server" DateFormat="dd/MM/yyyy"
                                                LabelWidth="30%">
                                            </DateInput>
                                            <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                        </telerik:RadDatePicker>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Color" AllowFiltering="false" Display ="false" >
                                    <ItemTemplate>
                                        <telerik:RadComboBox ID="cmbColor" CssClass="textbox" runat="server" Skin="WebBlue"
                                            Width="110px">
                                        </telerik:RadComboBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Actual Date">
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <telerik:RadDatePicker ID="txtActualDate" runat="server" Culture="en-US" Width="100px">
                                            <Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                                            </Calendar>
                                            <DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" runat="server" DateFormat="dd/MM/yyyy"
                                                LabelWidth="30%">
                                            </DateInput>
                                            <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                        </telerik:RadDatePicker>
                                    </ItemTemplate>
                                    <HeaderStyle Width="5%" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Yield (%)" AllowFiltering="false">
                                    <ItemTemplate>
                                        <telerik:RadTextBox ID="txtQuantityCmpltd" runat="server" CssClass="textbox" Text='<% #Eval("QtyCompleted") %>'
                                            Width="40">
                                        </telerik:RadTextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="3%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Status" AllowFiltering="false">
                                    <ItemTemplate>
                                        <telerik:RadComboBox ID="cmbStatus" CssClass="textbox" runat="server" Skin="WebBlue"
                                            Width="80px">
                                            <Items>
                                                <telerik:RadComboBoxItem Text="--" Value="0" />
                                                <telerik:RadComboBoxItem Text="Pending" Value="1" />
                                                <telerik:RadComboBoxItem Text="Completed" Value="2" />
                                            </Items>
                                        </telerik:RadComboBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="6%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Remarks" AllowFiltering="false">
                                    <ItemTemplate>
                                        <telerik:RadTextBox ID="txtRemarks" runat="server" Width="130px" CssClass="textbox"
                                            Text='<% #Eval("Remarks") %>'>
                                        </telerik:RadTextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="/" AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkUpdate" runat="server" Width="10"></asp:CheckBox>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Names="Microsoft Sans Serif" />
                                    <ItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Width="5" />
                                    <HeaderStyle Width="2%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="History" AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:HyperLink ID="lnkEdit" Enabled="true" NavigateUrl='<%# "TNAHistory.aspx?lProcessID="& DataBinder.Eval(Container.DataItem,"ProcessID")&"&lPOID="& DataBinder.Eval(Container.DataItem,"POID")%>'
                                            runat="server">History</asp:HyperLink>
                                    </ItemTemplate>
                                    <HeaderStyle Width="2%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                        </MasterTableView>
                        <HeaderStyle Font-Names="Microsoft Sans Serif" />
                        <%--      <ItemStyle Font-Names="Microsoft Sans Serif" Font-Size="X-Small" Wrap="False" />--%>
                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                    </telerik:RadGrid>
                  </div>
                </td>
            </tr>
              <tr>
                <td style="width: 128px; height: 30px;">
                    <asp:Label ID="Label2" runat="server" Text="Placement Date" Width="130px" Visible="false"></asp:Label>
                    <telerik:RadDatePicker ID="txtPlacementDate" runat="server" Culture="en-US" Width="120px"
                        Visible="false" Enabled ="false">
                        <Calendar ID="Calendar2" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                            runat="server">
                        </Calendar>
                        <DateInput ID="DateInput2" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                            runat="server">
                        </DateInput>
                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                    </telerik:RadDatePicker>
                </td>
            </tr>
            <tr>
                <td style="width: 128px; height: 30px;">
                    <asp:Label ID="lblShipmentdate" runat="server" Text="Shipment Date" Width="130px" Visible="false"></asp:Label>
                    <%-- <asp:TextBox ID="txtPlacementDate" Width="100" runat="server" CssClass="textbox"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="txtPlacementDate"
                        PopupButtonID="ImageButton2" />
                    <asp:ImageButton runat="Server" ID="ImageButton2" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                        AlternateText="Click here to display calendar" />
                    <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtPlacementDate"
                        Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                        CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                        Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                    </cc1:MaskedEditExtender>--%>
                    <asp:Label ID="lblPlacementDate" runat="server" Text="" Width="130px" Visible="false"></asp:Label>
                    <asp:TextBox ID="txtShipmentDate" Width="94px" runat="server" CssClass="textbox"
                        Enabled="false" Visible ="false" ></asp:TextBox>
                    <telerik:RadDatePicker ID="txtShipmentDatee" runat="server" Culture="en-US" Width="120px"
                        Visible="false" Enabled ="false" >
                        <Calendar ID="Calendar3" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                            runat="server">
                        </Calendar>
                        <DateInput ID="DateInput3" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                            runat="server">
                        </DateInput>
                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                    </telerik:RadDatePicker>
                </td>
            </tr>
            <tr>
                <td style="width: 128px; height: 30px;">
                    <asp:Label ID="lblReviseShipmentDate" runat="server" Text="Revise Shipment Date"
                        Width="130px" Visible="false"></asp:Label>
                    <%--<asp:TextBox ID="txtShipmentDate" Width="120" runat="server" CssClass="textbox"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtShipmentDate"
                        PopupButtonID="ImageButton1" />
                    <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                        AlternateText="Click here to display calendar" />
                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtShipmentDate"
                        Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                        CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                        Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                    </cc1:MaskedEditExtender>--%>
                    <telerik:RadDatePicker ID="txtReviseShipmentDate" runat="server" Culture="en-US" Visible="false"
                        Width="120px">
                        <Calendar ID="Calendar4" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                            runat="server">
                        </Calendar>
                        <DateInput ID="DateInput4" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                            runat="server">
                        </DateInput>
                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                    </telerik:RadDatePicker>
                    <telerik:RadButton ID="RadBtnUpdateTNA" runat="server" Text="Update TNA" Skin="WebBlue" Visible="false">
                    </telerik:RadButton>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Lblerror" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
