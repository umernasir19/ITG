<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeBehind="Claim.aspx.vb" Inherits="Integra.Claim" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">
        function OnClientSelectedIndexChanged(sender, eventArgs) {
            var item = eventArgs.get_item();
            sender.disable();
        }
    </script>
    <telerik:RadAjaxManager ID="radajaxmanager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cmbCustomer">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cmbBuyingDept" />
                    <telerik:AjaxUpdatedControl ControlID="cmbSupplier" />
                    <telerik:AjaxUpdatedControl ControlID="cmbCustomer" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cmbBuyingDept">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cmbSupplier" />
                    <telerik:AjaxUpdatedControl ControlID="cmbBuyingDept" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cmbSupplier">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cmbPONo" />
                    <telerik:AjaxUpdatedControl ControlID="cmbSupplier" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cmbSeason">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cmbPONo" />
                    <telerik:AjaxUpdatedControl ControlID="cmbSeason" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cmbPONo">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="dgClaim" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnCalculate">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txtTotalClaimPcs" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <div>
        <table style="width: 100%;" align="center">
            <tr>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="lblCustomerName" runat="server" Text="Customer"></asp:Label>
                </td>
                <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                    <telerik:RadComboBox ID="cmbCustomer" runat="server" AutoPostBack="True" Skin="WebBlue"
                        OnSelectedIndexChanged="cmbCustomer_SelectedIndexChanged" OnClientSelectedIndexChanged="OnClientSelectedIndexChanged">
                        <%--<DefaultItem Text="Select Customer.." Value="0" />--%>
                    </telerik:RadComboBox>
                    <telerik:RadTextBox ID="txtcustomer" BackColor="#80BFFF" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="Label3" runat="server" Text="Dept."></asp:Label>
                </td>
                <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                    <telerik:RadComboBox ID="cmbBuyingDept" runat="server" AutoPostBack="true" Skin="WebBlue"
                        OnSelectedIndexChanged="cmbBuyingDept_SelectedIndexChanged" OnClientSelectedIndexChanged="OnClientSelectedIndexChanged">
                        <%-- <DefaultItem Text="Select BuyingDept.." Value="0" />--%>
                    </telerik:RadComboBox>
                </td>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="lblSupplier" runat="server" Text="Supplier"></asp:Label>
                </td>
                <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                    <telerik:RadComboBox ID="cmbSupplier" runat="server" AutoPostBack="True" Skin="WebBlue"
                        OnSelectedIndexChanged="cmbSupplier_SelectedIndexChanged" OnClientSelectedIndexChanged="OnClientSelectedIndexChanged">
                        <%--   <DefaultItem Text="Select Supplier.." Value="0" />--%>
                    </telerik:RadComboBox>
                    <telerik:RadTextBox ID="txtsupplier" BackColor="#80BFFF" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="Label4" runat="server" Text="Season"></asp:Label>
                </td>
                <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                    <telerik:RadComboBox ID="cmbSeason" runat="server" AutoPostBack="true" Skin="WebBlue"
                        OnSelectedIndexChanged="cmbSeason_SelectedIndexChanged" OnClientSelectedIndexChanged="OnClientSelectedIndexChanged">
                         <DefaultItem Text="Select Season" Value="0" />
                    </telerik:RadComboBox>
                </td>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="lblPONO" runat="server" Text="PO No."></asp:Label>
                </td>
                <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                    <telerik:RadComboBox ID="cmbPONo" runat="server" AutoPostBack="True" Skin="WebBlue"
                        OnSelectedIndexChanged="cmbPONo_SelectedIndexChanged" OnClientSelectedIndexChanged="OnClientSelectedIndexChanged">
                        <DefaultItem Text="Select PO No.." Value="0" />
                    </telerik:RadComboBox>
                    <telerik:RadTextBox ID="txtPONO" BackColor="#80BFFF" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <telerik:RadGrid ID="dgClaim" runat="server" CellSpacing="0" AutoGenerateColumns="false"
                        Skin="WebBlue" Visible="False" PageSize="50">
                        <AlternatingItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" />
                        <MasterTableView>
                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn HeaderText="POClaimDetailID" DataField="POClaimDetailID"
                                    Display="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="StyleID" DataField="StyleID" Display="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="StyleDetailID" DataField="StyleDetailID" Display="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="POClaimDetailID" DataField="POClaimDetailID"
                                    Display="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="PODetailID" DataField="PODetailID" Display="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Style No" DataField="StyleNo">
                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Article" DataField="Article">
                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Colorway" DataField="Colorway">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Size" DataField="SizeRange">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="PO Quantity" DataField="POQuantity">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="Claim Pcs">
                                    <ItemTemplate>
                                        <telerik:RadNumericTextBox ID="txtClaimPcs" Width="60" runat="server" Skin="WebBlue"
                                            onChange="txtChanged" AutoPostBack="true">
                                            <NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>
                                        </telerik:RadNumericTextBox>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Select" UniqueName="Select" AllowFiltering="false">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelect" runat="server" OnCheckedChanged="CheckedChanged" AutoPostBack="true">
                                        </asp:CheckBox>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                        </MasterTableView>
                        <HeaderStyle Font-Names="Microsoft Sans Serif" />
                        <ItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" />
                        <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                            <Selecting AllowRowSelect="true" EnableDragToSelectRows="false" />
                        </ClientSettings>
                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                    </telerik:RadGrid>
                </td>
            </tr>
            <tr>
                <td style="width: 128px; height: 30px;">
                    <asp:Label ID="Label6" runat="server" Text="Nature of Claim"></asp:Label>
                </td>
                <td class="TopHeaderTable3" style="width: 120px; height: 30px;">
                    <telerik:RadComboBox ID="cmbNatureofClaim" runat="server" AutoPostBack="false" Skin="WebBlue">
                    </telerik:RadComboBox>
                </td>
                <td style="width: 128px; height: 30px;">
                </td>
                <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                </td>
                <td colspan="3" align="right">
                    <telerik:RadButton ID="btnCalculate" runat="server" Text="Calculate" AutoPostBack="true"
                        Skin="WebBlue">
                    </telerik:RadButton>
                </td>
            </tr>
            <tr>
                <td style="width: 128px; height: 30px;">
                    <asp:Label ID="lblTotalClaimPcs" runat="server" Text="Total Claim Pcs"></asp:Label>
                </td>
                <td class="TopHeaderTable3" style="width: 120px; height: 30px;">
                    <telerik:RadTextBox ID="txtTotalClaimPcs" runat="server" Skin="WebBlue" ReadOnly="True"
                        BackColor="#80BFFF">
                    </telerik:RadTextBox>
                </td>
                <td style="width: 128px; height: 30px;">
                    <asp:Label ID="lblCreationDate" runat="server" Text="Claim Date"></asp:Label>
                </td>
                <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                    <telerik:RadDatePicker ID="txtClaimDate" runat="server" Culture="en-US">
                        <Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                        </Calendar>
                        <DateInput runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                            LabelWidth="40%">
                        </DateInput>
                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                    </telerik:RadDatePicker>
                </td>
                <td colspan="3" align="right">
                </td>
            </tr>
            <tr>
                <td style="width: 128px; height: 30px;">
                    <asp:Label ID="lblClaimAmount" runat="server" Text="Claim Amount"></asp:Label>
                </td>
                <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                    <telerik:RadTextBox ID="txtClaimAmount" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
                <td style="height: 30px; width: 85px;">
                    <asp:Label ID="lblCurrency" runat="server" Text="Currency"></asp:Label>
                </td>
                <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                    <asp:UpdatePanel ID="UpdatePanel11" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <telerik:RadComboBox ID="cmbCurrency" runat="server" AutoPostBack="True" Skin="WebBlue">
                                <%--    <DefaultItem Text="Dollar" Value="0" />--%>
                            </telerik:RadComboBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td style="width: 128px; height: 30px;">
                    <asp:Label ID="lblClaimNo" runat="server" Text="Claim No"></asp:Label>
                </td>
                <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                    <telerik:RadTextBox ID="txtClaimNo" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 128px; height: 30px;">
                    <asp:Label ID="Label2" runat="server" Text="Settle Amount"></asp:Label>
                </td>
                <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                    <telerik:RadTextBox ID="txtSettleAmountt" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
                  <td style="height: 30px; width: 85px;">
                    
                </td>
                <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                    
                </td>
                  <td style="width: 128px; height: 30px;">
                    <asp:Label ID="Label7" runat="server" Text="Job No"></asp:Label>
                </td>
                <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                    <telerik:RadTextBox ID="txtJobNo" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
            </tr>
        </table>
        <table style="width: 100%;" align="center">
            <tr valign="top">
                <td style="width: 81px; height: 30px;">
                    <asp:Label ID="Label1" runat="server" Text="Claim Reason"></asp:Label>
                </td>
                <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                    <telerik:RadTextBox ID="txtclaimReason" runat="server" Skin="WebBlue" TextMode="MultiLine"
                        Width="479px">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr valign="top" style="height: 34px;">
                <td style="width: 81px; height: 30px;">
                    <asp:Label ID="Label5" runat="server" Text="Remarks"></asp:Label>
                </td>
                <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                    <telerik:RadTextBox ID="txtremarks" runat="server" Skin="WebBlue" TextMode="MultiLine"
                        Width="479px">
                    </telerik:RadTextBox>
                </td>
            </tr>
        </table>
        <table style="width: 100%;" align="center">
            <tr>
                <td colspan="2" align="right">
                </td>
                <td colspan="4" align="right">
                    <telerik:RadButton ID="btnSave" runat="server" Text="Save" Skin="WebBlue">
                    </telerik:RadButton>
                    &nbsp; &nbsp; &nbsp;
                    <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" Skin="WebBlue">
                    </telerik:RadButton>
                </td>
                <%--   <td colspan="3" align="right"></td>--%>
            </tr>
        </table>
    </div>
</asp:Content>
