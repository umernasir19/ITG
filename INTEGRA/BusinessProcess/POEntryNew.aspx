<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="POEntryNew.aspx.vb" Inherits="Integra.POEntryNew" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function isNumericKey(e) {
            var charInp = window.event.keyCode;
            if (charInp > 31 && (charInp < 48 || charInp > 57)) {
                return false;
            }
            return true;
        }
        function isNumericKeyy(e) {
            var charInp = window.event.keyCode;
            if (charInp != 46 && (charInp < 48 || charInp > 57)) {
                return false;
            }
            return true;
        }
        function mathRoundForTaxes(source) {
            var txtBox = document.getElementById(source);
            var txt = txtBox.value;
            if (!isNaN(txt) && isFinite(txt) && txt.length != 0) {
                var rounded = Math.round(txt * 100) / 100;
                txtBox.value = rounded.toFixed(2);
            }
        }
        function NotZero(source) {
            var txtBox = document.getElementById(source);
            var txt = txtBox.value;
            if (txt == 0) {
                txtBox.value = 1;
            }
        }

        function selectOneside(val) { //here val is my dropdown ID
            var Dval = val.selectedIndex;
            if (Dval == "2") {
                val.selectedIndex = 0;
            }
        }
    </script>
    <div>
        <table width="100%">
            <%--'-------Heading Row--------'--%>
            <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
                visible="true">
                <th colspan="5" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                    color: #808080;">
                    Inq. / Purchase Order Information
                </th>
                <th align="right" style="font-family: Arial; font-size: 16PX; font-weight: bold;">
                    <asp:Label ID="lblPOTypeHeading" runat="server" Text="PO Type:"></asp:Label>
                    <asp:Label ID="lblPOType" runat="server"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                </th>
            </tr>
            <tr>
            <td style="width: 128px; height: 30px;">
                    <asp:Label ID="Label8" runat="server" Text="PO Number"></asp:Label>
                </td>
                <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                    <asp:TextBox ID="txtMasterPO" runat="server" AutoPostBack="true" CssClass="textbox" Width="190">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 128px; height: 30px;">
                    <asp:Label ID="lblPONO" runat="server" Text="Partial Delivery"></asp:Label>
                </td>
                <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                    <asp:TextBox ID="txtPONO" runat="server" AutoPostBack="true" CssClass="textbox" Width="190">
                    </asp:TextBox>
                </td>
                <td style="width: 128px; height: 30px;">
                    <asp:Label ID="Label1" runat="server" Text="Inq. Date" Visible ="false" ></asp:Label>
                </td>
                <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                    <%-- <asp:TextBox ID="InqDate" Width="100" runat="server" CssClass="textbox"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server" TargetControlID="InqDate"
                        PopupButtonID="ImageButton3" />
                    <asp:ImageButton runat="Server" ID="ImageButton3" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                        AlternateText="Click here to display calendar" />
                    <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="InqDate"
                        Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                        CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                        Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                    </cc1:MaskedEditExtender>--%>
                    <telerik:RadDatePicker ID="InqDate" runat="server" Culture="en-US" Visible ="false" >
                        <Calendar ID="Calendar1" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                            runat="server">
                        </Calendar>
                        <DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                            runat="server">
                        </DateInput>
                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                    </telerik:RadDatePicker>
                </td>
                <td style="width: 128px; height: 30px;">
                </td>
                <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                </td>
            </tr>
            <tr>
                <td style="width: 128px; height: 30px;">
                    <asp:Label ID="Label4" runat="server" Text="Inquiry Type"></asp:Label>
                </td>
                <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                    <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cmbStage" Width="110" runat="server" AutoPostBack="true">
                                <asp:ListItem Value="INITIAL" Text="INITIAL"></asp:ListItem>
                                <asp:ListItem Value="REPEAT" Text="REPEAT"></asp:ListItem>
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td style="width: 128px; height: 30px;">
                    <asp:Label ID="Label6" runat="server" Text="Inquiry Purpose"></asp:Label>
                </td>
                <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                    <asp:UpdatePanel ID="UpdatePanel5" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cmbEnquiryPurpose" Width="139px" runat="server" AutoPostBack="true">
                                <asp:ListItem Value="0">Select </asp:ListItem>
                                <asp:ListItem Value="1">Buying Meeting</asp:ListItem>
                                <asp:ListItem Value="2">General Meeting</asp:ListItem>
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td style="width: 128px; height: 30px;">
                    <asp:Label ID="Label7" runat="server" Text="Inquiry"></asp:Label>
                </td>
                <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                    <asp:UpdatePanel ID="UpcmbInquiry" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cmbInquiry" Width="150" runat="server">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td style="width: 128px; height: 30px;">
                    <asp:Label ID="lblPlacementdate" runat="server" Text="Recv. Date"></asp:Label>
                </td>
                <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
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
                    <telerik:RadDatePicker ID="txtPlacementDate" runat="server" Culture="en-US">
                        <Calendar ID="Calendar3" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                            runat="server">
                        </Calendar>
                        <DateInput ID="DateInput3" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                            runat="server">
                        </DateInput>
                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                    </telerik:RadDatePicker>
                </td>
                <td style="width: 128px; height: 30px;">
                    <asp:Label ID="lblShipmentDate" runat="server" Text="Shipment Date"></asp:Label>
                </td>
                <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
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
                    <telerik:RadDatePicker ID="txtShipmentDate" runat="server" Culture="en-US">
                        <Calendar ID="Calendar4" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                            runat="server">
                        </Calendar>
                        <DateInput ID="DateInput4" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                            runat="server">
                        </DateInput>
                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                    </telerik:RadDatePicker>
                </td>
            </tr>
            <tr>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="lblCustomerName" runat="server" Text="Customer"></asp:Label>
                </td>
                <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cmbCustomer" Width="190" runat="server" AutoPostBack="True">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td style="height: 30px; width: 85px;">
                    <asp:Label ID="lblBuyingDpt" runat="server" Text="Buying Dept."></asp:Label>
                </td>
                <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                    <asp:UpdatePanel ID="UpdcmbBuyingDept" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtEKNumber" Visible="false" runat="server" Width="120">
                            </asp:TextBox>
                            <asp:DropDownList ID="cmbBuyingDept" Width="120" runat="server">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td style="height: 30px; width: 87px;">
                    <asp:Label ID="lblCommission" Visible="false" runat="server" Text="Commission"></asp:Label>
                </td>
                <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                    <asp:TextBox ID="txtCommission" Visible="false" runat="server" Width="140" onchange="mathRoundForTaxes(this.id);"
                        onkeypress="return isNumericKeyy(event);">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="lblSupplier" runat="server" Text="Supplier"></asp:Label>
                </td>
                <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                    <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cmbSupplier" Width="190" runat="server" AutoPostBack="True">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td style="height: 30px; width: 85px;">
                    <asp:Label ID="lblLKZ" runat="server" Text="Supplier No."></asp:Label>
                    <%--'-------Heading Row--------'--%>
                </td>
                <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                    <asp:UpdatePanel ID="updLKZNo" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtLKZNo" runat="server" Width="120" ReadOnly="True">
                            </asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td style="height: 30px; width: 87px;">
                    <%--  <asp:Label ID="lblMerchant" runat="server" Text="Merchant"></asp:Label>--%>
                </td>
                <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                    <asp:UpdatePanel ID="UpdatePanel3" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cmbMerchant" Width="140" runat="server" AutoPostBack="false"
                                Visible="true">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;
                z-index: auto;" visible="true">
                <th colspan="6" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                    color: #808080;">
                    Order Specific Information
                </th>
            </tr>
            <tr>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="lblSeason" runat="server" Text="Season"></asp:Label>
                </td>
                <td style="width: 166px; height: 30px;">
                    <asp:TextBox ID="txtSeason" Visible="false" runat="server" Width="168">
                    </asp:TextBox>
                    <asp:DropDownList ID="cmbseason" runat="server">
                    </asp:DropDownList>
                </td>
                <td style="height: 30px; width: 85px;">
                    <asp:Label ID="lbltolerance" runat="server" Text="Tolerance(+/-) %"></asp:Label>
                </td>
                <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                    <asp:TextBox ID="txtTolerance" runat="server" Width="130" onkeypress="return isNumericKey(event);">
                    </asp:TextBox>
                </td>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="Label3" runat="server" Text="Status"></asp:Label>
                </td>
                <td style="width: 166px; height: 30px;">
                    <asp:UpdatePanel ID="upcmbStatus" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cmbStatus" onchange="selectOneside(this);" runat="server" AutoPostBack="True"
                                Width="168">
                                <asp:ListItem Value="0" Text="Booked" />
                                <asp:ListItem Value="1" Text="Shipped" />
                                <asp:ListItem Value="2" Text="Close" />
                                <asp:ListItem Value="3" Text="Cancel" />
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="lblShipmentMode" runat="server" Text="Shipment Mode"></asp:Label>
                </td>
                <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                    <asp:UpdatePanel ID="UpdatePanel7" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cmbShipmentMode" runat="server" AutoPostBack="True" Width="120">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="Label5" runat="server" Font-Italic="true" Text="Total Quantity:"></asp:Label>
                </td>
                <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                    <asp:TextBox ID="txtEnteredQty" Font-Italic="true" runat="server" Width="90" onkeypress="return isNumericKeyy(event);">
                    </asp:TextBox>
                </td>
            </tr>
            <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;
                z-index: auto;" visible="true">
                <th colspan="5" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                    color: #808080;">
                    Article Information
                </th>
                <th align="right" style="font-family: 'Times New Roman', Times, serif; font-size: 12px;
                    font-weight: bold; font-style: inherit; color: Black; font-variant: inherit;
                    padding-right: 20px;">
                    <asp:UpdatePanel ID="upAddMore" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnAddMore" runat="server" Text="Add Article"></asp:Button>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="upShowData" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnShowData" runat="server" Text="Show"></asp:Button>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </th>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdgAdditional" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <Smart:SmartDataGrid ID="dgAdditional" runat="server" Width="100%" AllowSorting="True"
                                AutoGenerateColumns="False" CellPadding="2" CssClass="table" PagerCurrentPageCssClass=""
                                PagerOtherPageCssClass="" PageSize="600" RecordCount="0" ShowFooter="False" SortedAscending="yes">
                                <Columns>
                                    <asp:BoundColumn HeaderText="Style" DataField="StyleNo">
                                        <HeaderStyle Width="10%" HorizontalAlign="center" />
                                        <HeaderStyle HorizontalAlign="center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Product Portfolio" DataField="ProductPortfolio">
                                        <HeaderStyle Width="10%" HorizontalAlign="center" />
                                        <HeaderStyle HorizontalAlign="center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Product Categories" DataField="ProductCategories">
                                        <HeaderStyle Width="10%" HorizontalAlign="center" />
                                        <HeaderStyle HorizontalAlign="center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Product Group" DataField="ProductGroup">
                                        <HeaderStyle Width="10%" HorizontalAlign="center" />
                                        <HeaderStyle HorizontalAlign="center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Construction" DataField="Blend">
                                        <HeaderStyle Width="10%" HorizontalAlign="center" />
                                        <HeaderStyle HorizontalAlign="center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="GSM" DataField="GSM">
                                        <HeaderStyle Width="10%" HorizontalAlign="center" />
                                        <HeaderStyle HorizontalAlign="center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Process Type" DataField="ProcessType">
                                        <HeaderStyle Width="10%" HorizontalAlign="center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Composition" DataField="Composition">
                                        <HeaderStyle Width="10%" HorizontalAlign="center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Name Of Brand" DataField="NameOfBrand">
                                        <HeaderStyle Width="10%" HorizontalAlign="center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="center" />
                                    </asp:BoundColumn>
                                </Columns>
                                <PagerStyle HorizontalAlign="NotSet" Visible="false" />
                                <AlternatingItemStyle CssClass="GridAlternativeRow" />
                                <ItemStyle CssClass="GridRow" />
                                <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                            </Smart:SmartDataGrid>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td style="height: 30px">
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:UpdatePanel ID="updgPurchaseOrder" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <Smart:SmartDataGrid ID="dgPurchaseOrder" runat="server" Width="100%" AllowSorting="True"
                                AutoGenerateColumns="False" CellPadding="2" CssClass="table" PagerCurrentPageCssClass=""
                                PagerOtherPageCssClass="" PageSize="600" RecordCount="0" ShowFooter="True" SortedAscending="yes">
                                <Columns>
                                    <asp:BoundColumn HeaderText="Detail ID" DataField="PurchaseOrderDetailID" Visible="False" />
                                    <asp:BoundColumn HeaderText="Style ID" DataField="StyleID" Visible="False" />
                                    <asp:BoundColumn HeaderText="StyleDetailID" DataField="StyleDetailID" Visible="False" />
                                    <asp:BoundColumn HeaderText="Style" DataField="Style">
                                        <HeaderStyle Width="10%" HorizontalAlign="center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Color Ref No." DataField="ColorRefNo">
                                        <HeaderStyle Width="10%" HorizontalAlign="center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="HS code" DataField="StyleDescription">
                                        <HeaderStyle Width="10%" HorizontalAlign="center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Colorway" DataField="Color">
                                        <HeaderStyle Width="10%" HorizontalAlign="center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Size" DataField="Size">
                                        <HeaderStyle Width="10%" HorizontalAlign="center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="center" />
                                    </asp:BoundColumn>
                                    <asp:TemplateColumn HeaderText="PO Quantity">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="center" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtQuantity" onkeypress="return isNumericKey(event);" runat="server"
                                                Width="70" CssClass="textbox" TabIndex="17"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="3%" HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="center" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Item Price">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRate" runat="server" Width="70" onchange="mathRoundForTaxes(this.id);"
                                                onkeypress="return isNumericKeyy(event);" CssClass="textbox" TabIndex="18"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="3%" HorizontalAlign="center" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="/">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="lnkCalculate" runat="server" CommandName="Calculate" BackColor="transparent"
                                                ImageUrl="~/Images/redCal.jpg" TabIndex="19" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="1%" HorizontalAlign="center" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Value">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtAmount" ReadOnly="True" runat="server" Width="70" CssClass="textbox"
                                                TabIndex="20"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="3%" HorizontalAlign="center" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Shipment Date">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <%--     <asp:TextBox ID="txtDetailShipmentDate" Width="80" runat="server" CssClass="textbox"
                                                TabIndex="21"></asp:TextBox>
                                            <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtDetailShipmentDate"
                                                PopupButtonID="ImageButton1" />
                                            <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                                                AlternateText="Click here to display calendar" />
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDetailShipmentDate"
                                                Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                                                CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                                                Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                                            </cc1:MaskedEditExtender>--%>
                                            <telerik:RadDatePicker ID="txtDetailShipmentDate" runat="server" Culture="en-US"
                                                Width="100px">
                                                <Calendar ID="Calendar4" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                                                    runat="server">
                                                </Calendar>
                                                <DateInput ID="DateInput4" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                                                    runat="server">
                                                </DateInput>
                                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                            </telerik:RadDatePicker>
                                        </ItemTemplate>
                                        <HeaderStyle Width="1%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Shipment Mode">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:DropDownList ID="cmbDetailShipmentMode" runat="server" AutoPostBack="True" Width="80">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Remarks">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRemarks" runat="server" Width="60" CssClass="textbox" TabIndex="22"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="1%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Action">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="lnkRemove" runat="server" CommandName="Remove" BackColor="transparent"
                                                ImageUrl="~/Images/RemoveIcon.png" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="3%" />
                                    </asp:TemplateColumn>
                                </Columns>
                                <PagerStyle HorizontalAlign="NotSet" Visible="false" />
                                <AlternatingItemStyle CssClass="GridAlternativeRow" />
                                <ItemStyle CssClass="GridRow" />
                                <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                            </Smart:SmartDataGrid>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td style="height: 30px; width: 128px;">
                    <asp:TextBox ID="txtPORefNo" Visible="false" runat="server" Width="22"></asp:TextBox>
                </td>
                <td style="width: 166px; height: 30px;">
                    <b>System Total Qty : </b>
                    <asp:UpdatePanel ID="upTxtTotalQty" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="TxtTotalQty" BackColor="#80BFFF" CssClass="textbox" ReadOnly="true"
                                runat="server" Width="80"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td style="height: 30px; width: 85px;">
                </td>
                <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                    <b>System Total Value: </b>
                    <asp:UpdatePanel ID="uptxtTotalAmount" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtTotalAmount" BackColor="#80BFFF" CssClass="textbox" ReadOnly="true"
                                runat="server" Width="80"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td style="height: 30px; width: 85px;">
                </td>
                <td align="right">
                    <asp:UpdatePanel ID="upbtnCalculate" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnCalculate" runat="server" ToolTip="Press To Calculate Value" Text="Calculate">
                            </asp:Button>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;
                z-index: auto;" visible="true">
                <th colspan="6" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                    color: #808080;">
                    Shipping And Payment Terms
                </th>
            </tr>
            <tr>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="lblPaymentTerms" runat="server" Text="Payment Terms"></asp:Label>
                </td>
                <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                    <asp:UpdatePanel ID="UpdatePanel10" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cmbPaymentTerms" runat="server" AutoPostBack="True" Width="120">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="lblDestinations" runat="server" Text="Destination"></asp:Label>
                </td>
                <td style="width: 166px; height: 30px;">
                    <asp:TextBox ID="txtDestination" runat="server" Width="120">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 30px; width: 85px;">
                    <asp:Label ID="lblCurrency" runat="server" Text="Currency"></asp:Label>
                </td>
                <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                    <asp:UpdatePanel ID="UpdatePanel11" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cmbCurrency" runat="server" AutoPostBack="True" Width="190">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td style="height: 30px; width: 87px;">
                    <asp:UpdatePanel ID="upLnkRate" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:LinkButton ID="lnkExchangeRate" runat="server" Text="Exchange Rate">
                            </asp:LinkButton>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td style="width: 166px; height: 30px;">
                    <asp:UpdatePanel ID="upBookedExchange" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtBookedExchangeRate" BackColor="#80BFFF" Text="1.33" runat="server"
                                ReadOnly="true" Width="70">
                            </asp:TextBox>
                            <asp:ImageButton ID="btnBookedExchangeRate" runat="server" ToolTip="Press This to Show Exchange Rate"
                                BackColor="transparent" ImageUrl="~/Images/redCal.jpg" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;
                z-index: auto;" visible="true">
                <th colspan="6" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                    color: #808080;">
                    Complaint Type
                </th>
            </tr>
            <br />
            <br />
            <tr style="height: 40px">
                <td style="height: 30px; width: 50px;">
                    <asp:TextBox ID="txtComplaintType" CssClass="textbox" TextMode="MultiLine" ReadOnly="false"
                        runat="server" Width="500px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <table width="100%">
            <%--'-------Heading Row--------'--%>
            <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;
                z-index: auto;" visible="true">
                <th colspan="3" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                    color: #808080;">
                    Reference & Attachment
                </th>
            </tr>
            <tr>
                <td style="height: 30px; width: 50px;">
                    <asp:Label ID="lblOriginalPO" runat="server" Text="Original Purchase Order"></asp:Label>
                    &nbsp;
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:CustomValidator ID="CustomValidator1" ForeColor="Red" runat="server" ControlToValidate="FileUpload1"
                        ClientValidationFunction="ValidateFileUpload" ErrorMessage="Please select valid pdf file"></asp:CustomValidator>
                    <script language="javascript" type="text/javascript">
                        function ValidateFileUpload(Source, args) {
                            var fuData = document.getElementById('<%= FileUpload1.ClientID %>');
                            var FileUploadPath = fuData.value;
                            if (FileUploadPath == '') {
                                // There is no file selected 
                                args.IsValid = false;
                            }
                            else {
                                var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();

                                if (Extension == "pdf") {
                                    args.IsValid = true; // Valid file type
                                }
                                else {
                                    args.IsValid = false; // Not valid file type
                                }
                            }
                        }
                    </script>
                </td>
            </tr>
            <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;
                z-index: auto;" visible="true">
                <th colspan="3" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                    color: #808080;">
                    Additional Information
                </th>
            </tr>
            <tr>
                <td style="height: 25px" colspan="3">
                    <asp:CheckBox ID="ChkTNA" runat="server" Font-Bold="True" Text="System will create time and action plan for this order. "
                        Enabled="False" />
                </td>
            </tr>
            <tr>
                <td align="right">
                </td>
                <td align="right">
                    <asp:Button ID="btnPrint" runat="server" Text="PDF"></asp:Button>&nbsp; &nbsp; &nbsp;
                    <asp:Button ID="btnPreview" runat="server" Text="Preview"></asp:Button>&nbsp; &nbsp;
                    &nbsp;
                    <asp:Button ID="btnSave" runat="server" Text="Save"></asp:Button>
                </td>
                <td>
                    &nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel"></asp:Button>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <telerik:RadDatePicker ID="txtShipmentDatee" runat="server" Culture="en-US" Visible="false">
                    <Calendar ID="Calendar2" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                        runat="server">
                    </Calendar>
                    <DateInput ID="DateInput2" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        runat="server">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </tr>
        </table>
    </div>
</asp:Content>
