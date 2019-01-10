<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="ConfirmedOrderSamplingReq.aspx.vb" Inherits="Integra.ConfirmedOrderSamplingReq" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
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
   
    </script>
    <table width="100%">
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="6" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                Confirmed Order Sampling Requiremnet
            </th>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td colspan="2">
            </td>
            <td>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                Customer :
            </td>
            <td>
                <asp:UpdatePanel ID="UpcmbCustomer" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbCustomer" Width="150" AutoPostBack="true" CssClass="dd"
                            runat="server">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                Buying Dept
            </td>
            <td>
                <asp:UpdatePanel ID="UpcmbBuyingDept" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbBuyingDept" Width="137" AutoPostBack="true" CssClass="dd"
                            runat="server">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                Buyer Name
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatecmbBuyerName" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbBuyerName" Width="150" AutoPostBack="true" CssClass="dd"
                            runat="server">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                Brand
            </td>
            <td>
                <asp:UpdatePanel ID="UpcmbBrand" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbBrand" Width="150" AutoPostBack="true" CssClass="dd" runat="server">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                Season
            </td>
            <td>
                <asp:UpdatePanel ID="UpcmbSeason" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbSeason" Width="150" AutoPostBack="true" CssClass="dd" runat="server">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                Style No
            </td>
            <td>
                <asp:UpdatePanel ID="UpStyleNo" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbStyle" Width="150" AutoPostBack="true" CssClass="dd" runat="server">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                Design Name
            </td>
            <td>
                <asp:UpdatePanel ID="UpDesignName" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtDesignName" CssClass="textbox" Width="130" runat="server"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                Style Description
            </td>
            <td>
                <asp:UpdatePanel ID="UptxtStyleDescription" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtStyleDescription" CssClass="textbox" Width="215" runat="server"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                Supplier
            </td>
            <td>
                <asp:UpdatePanel ID="UpSupplier" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbsupplier" Width="150" AutoPostBack="false" CssClass="dd"
                            runat="server">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                Sample Type
            </td>
            <td>
                <asp:UpdatePanel ID="UpcmbSample" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbSample" runat="server" AutoPostBack="false" Width="149px"
                            ToolTip="Select">
                            <asp:ListItem Value="Initial" Text="Initial" />
                            <asp:ListItem Value="Repeat" Text="Repeat" />
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr style="height: 34px;">
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
                <asp:UpdatePanel ID="Upadd" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnAddSample" CssClass="button" Width="100" runat="server" Text="Add Sample" />
                        <asp:Button ID="btnAddMoreSample" CssClass="button" Width="150px" runat="server"
                            Visible="false" Text="Add more Sample" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <div style="vertical-align: top; overflow: auto; width: 920px; border-style: groove;">
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpUpbtndgSampleDetail" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <Smart:SmartDataGrid ID="dgSampleDetail" runat="server" Width="120%" AllowSorting="True"
                                AutoGenerateColumns="False" CellPadding="4" CssClass="table" PagerCurrentPageCssClass=""
                                PagerOtherPageCssClass="" PageSize="15" RecordCount="0" ShowFooter="True" SortedAscending="yes"
                                ForeColor="White">
                                <Columns>
                                    <asp:BoundColumn HeaderText="SamplingDetailID" DataField="SamplingDetailID" Visible="false">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:TemplateColumn HeaderText="Sample Type">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:DropDownList ID="cmbSampleType" CssClass="dd" Width="100" runat="server">
                                                <asp:ListItem>Lab Dips Sample</asp:ListItem>
                                                <asp:ListItem>Photo Sample</asp:ListItem>
                                                <asp:ListItem>Fit Sample</asp:ListItem>
                                                <asp:ListItem>Sealer Sample</asp:ListItem>
                                                 <asp:ListItem>Wash Test</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <HeaderStyle Width="8%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="F.Type">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:DropDownList ID="cmbFabricType" CssClass="dd" Width="110px" runat="server">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <HeaderStyle Width="7%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="No of Pieces" Visible="true">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtNoofPieces" Width="50" ReadOnly="false" onkeypress="return isNumericKeyy(event);"
                                                CssClass="textbox" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="4%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Color">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtColor" Width="80" ReadOnly="false" CssClass="textbox" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="7%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Size">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtSize" Width="50px" CssClass="textbox" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="4%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Dead Line">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtDeadLine" CssClass="textbox" Width="70px" runat="server"></asp:TextBox>
                                            <cc1:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server" TargetControlID="txtDeadLine"
                                                PopupButtonID="ImageButton3" />
                                            <asp:ImageButton runat="Server" ID="ImageButton3" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                                                AlternateText="Click here to display calendar" />
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtDeadLine"
                                                Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="DMY" CultureDatePlaceholder="/"
                                                CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                                                Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                                            </cc1:MaskedEditExtender>
                                        </ItemTemplate>
                                        <HeaderStyle Width="7%" />
                                    </asp:TemplateColumn>
                                      <asp:TemplateColumn HeaderText="Sup. Est Date">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtSupEstdate" CssClass="textbox" Width="70px" runat="server"></asp:TextBox>
                                            <cc1:CalendarExtender ID="CalendarExtender10" Format="dd/MM/yyyy" runat="server" TargetControlID="txtSupEstdate"
                                                PopupButtonID="ImageButton10" />
                                            <asp:ImageButton runat="Server" ID="ImageButton10" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                                                AlternateText="Click here to display calendar" />
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender10" runat="server" TargetControlID="txtSupEstdate"
                                                Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="DMY" CultureDatePlaceholder="/"
                                                CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                                                Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                                            </cc1:MaskedEditExtender>
                                        </ItemTemplate>
                                        <HeaderStyle Width="7%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Received Date">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtReceivedDate" CssClass="textbox" Width="70px" runat="server"></asp:TextBox>
                                            <cc1:CalendarExtender ID="CalendarExtender4" Format="dd/MM/yyyy" runat="server" TargetControlID="txtReceivedDate"
                                                PopupButtonID="ImageButton4" />
                                            <asp:ImageButton runat="Server" ID="ImageButton4" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                                                AlternateText="Click here to display calendar" />
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txtReceivedDate"
                                                Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="DMY" CultureDatePlaceholder="/"
                                                CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                                                Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                                            </cc1:MaskedEditExtender>
                                        </ItemTemplate>
                                        <HeaderStyle Width="7%" />
                                    </asp:TemplateColumn>
                                     <asp:TemplateColumn HeaderText="No of Pcs Received">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtNoofPcsRecvd" onkeypress="return isNumericKeyy(event);" Width="50"
                                                CssClass="textbox" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="5%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Dispatched Date">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtDispatchedDate" CssClass="textbox" Width="70px" runat="server"></asp:TextBox>
                                            <cc1:CalendarExtender ID="CalendarExtender5" Format="dd/MM/yyyy" runat="server" TargetControlID="txtDispatchedDate"
                                                PopupButtonID="ImageButton5" />
                                            <asp:ImageButton runat="Server" ID="ImageButton5" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                                                AlternateText="Click here to display calendar" />
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtDispatchedDate"
                                                Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="DMY" CultureDatePlaceholder="/"
                                                CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                                                Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                                            </cc1:MaskedEditExtender>
                                        </ItemTemplate>
                                        <HeaderStyle Width="7%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="No of Pcs Dis">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtNoofPcsDis" onkeypress="return isNumericKeyy(event);" Width="50"
                                                CssClass="textbox" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="5%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Submission">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:DropDownList ID="cmbSubmission" Width="60" runat="server">
                                                <asp:ListItem>1st</asp:ListItem>
                                                <asp:ListItem>2nd</asp:ListItem>
                                                <asp:ListItem>3rd</asp:ListItem>
                                                <asp:ListItem>4th</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <HeaderStyle Width="6%" />
                                    </asp:TemplateColumn>
                                         <asp:TemplateColumn HeaderText="Comments Received Date">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCommentsReceived" CssClass="textbox" Width="70px" runat="server"></asp:TextBox>
                                            <cc1:CalendarExtender ID="CalendarExtender6" Format="dd/MM/yyyy" runat="server" TargetControlID="txtCommentsReceived"
                                                PopupButtonID="ImageButton6" />
                                            <asp:ImageButton runat="Server" ID="ImageButton6" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                                                AlternateText="Click here to display calendar" />
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender6" runat="server" TargetControlID="txtCommentsReceived"
                                                Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="DMY" CultureDatePlaceholder="/"
                                                CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                                                Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                                            </cc1:MaskedEditExtender>
                                        </ItemTemplate>
                                        <HeaderStyle Width="7%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Status">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:DropDownList ID="cmbStatus" Width="100px" runat="server">
                                                <asp:ListItem>--</asp:ListItem>
                                                <asp:ListItem>Approved</asp:ListItem>
                                                <asp:ListItem>Rejected</asp:ListItem>
                                                <asp:ListItem>Revised</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <HeaderStyle Width="8%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Remarks">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtSampleRemarks" CssClass="textbox" Width="175px" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Sample Location">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtSampleLocation" CssClass="textbox" Width="80" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="6%" />
                                    </asp:TemplateColumn>
                                    <asp:BoundColumn HeaderText="RejConSample" DataField="RejConSample" Visible="false">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="1%" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:TemplateColumn HeaderText="Remove" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="lnkRemove" ToolTip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png"
                                                CommandName="RemoveProduct" runat="server"></asp:ImageButton>
                                        </ItemTemplate>
                                        <HeaderStyle Width="2%" HorizontalAlign="Center" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="" Visible="true">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkUpdate" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="2%" HorizontalAlign="Center" />
                                    </asp:TemplateColumn>
                                </Columns>
                                <PagerStyle CssClass="GridPagerStyle" Mode="NumericPages" HorizontalAlign="Right" />
                                <AlternatingItemStyle CssClass="GridAlternativeRow" />
                                <ItemStyle CssClass="GridRow" />
                                <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                            </Smart:SmartDataGrid>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
    <table width="100%">
        <tr>
            <td align="center">
                <asp:Button ID="btnSave" CssClass="button" runat="server" Text="Save" />
                &nbsp;
                <asp:Button ID="btnCancel" CssClass="button" runat="server" Text="Cancel" />
            </td>
        </tr>
    </table>
</asp:Content>
