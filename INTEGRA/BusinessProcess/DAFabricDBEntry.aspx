<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="DAFabricDBEntry.aspx.vb" Inherits="Integra.DAFabricDBEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="6" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                Fabric Database
            </th>
        </tr>
        <tr>
            <td align="center" style="width: 100px; height: 30px;">
                <asp:Label ID="lblEntryDate" runat="server" Text="Creation Date" Font-Names="Calibri"
                    Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadDatePicker ID="txtCreationDate" runat="server" Culture="en-US" Width="100px">
                    <Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                    </Calendar>
                    <DateInput ID="DateInput1" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 128px; height: 30px;">
                <asp:Label ID="Label8" runat="server" Text="DAL No." Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtDALNo" runat="server" Width="100px" Skin="WebBlue" Display="True"
                    AutoPostBack="true">
                </telerik:RadTextBox>
            </td>
            <td>
                <asp:Label ID="LBL1" runat="server" Text="Please Enter Dal No at least 5 Decimal Digits"
                    Style="margin-left: 0px; font-family: Calibri; font-size: 16PX; font-weight: bolder;
                    color: BLUE" Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtFabricCode" runat="server" Width="100px" Skin="WebBlue"
                    Visible="false">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 128px; height: 30px;">
                <asp:Label ID="Label21" runat="server" Text="Onz" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtonz" runat="server" Width="100px" Skin="WebBlue" Display="True">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 128px; height: 30px;">
                <asp:Label ID="Label1" runat="server" Text="Supplier Art No:" Font-Names="Calibri"
                    Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtSupplier" runat="server" Width="100px" Skin="WebBlue">
                </telerik:RadTextBox>
            </td>
            <td align="center" style="width: 128px; height: 30px;">
                <asp:Label ID="lblSupplier" runat="server" Text="Supplier Name" Font-Names="Calibri"
                    Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtPartyAccount" CssClass="textbox" AutoPostBack="true" autocomplete="off"
                            runat="server"></asp:TextBox>
                        <cc1:AutoCompleteExtender runat="server" ID="autoComplete1" TargetControlID="txtPartyAccount"
                            ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                            CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="TblPartyforInvoice" />
                        <asp:Label ID="lblPartyid" runat="server" Visible="false"></asp:Label>
                        <telerik:RadTextBox ID="txtSupplierName" runat="server" Width="100px" Skin="WebBlue"
                            Visible="false">
                        </telerik:RadTextBox>
                        <asp:ImageButton ID="btnAddSuuplier" runat="server" ImageUrl="~/Images/Add.png" Style="height: 25px;
                            margin-bottom: -9px;"></asp:ImageButton>
                        <asp:ImageButton ID="BtnSaveSupplier" runat="server" ImageUrl="~/Images/SaveButton.jpg"
                            Style="height: 25px; margin-bottom: -9px;" Visible="false"></asp:ImageButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 128px; height: 30px;">
                <asp:Label ID="Label2" runat="server" Text="Fabric Quality" Font-Names="Calibri"
                    Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtFabricQuality" TextMode="MultiLine" runat="server" Width="300px"
                    Skin="WebBlue" AutoPostBack="true">
                </telerik:RadTextBox>
            </td>
            <td align="center" style="width: 128px; height: 30px;">
                <asp:Label ID="Label3" runat="server" Text="Colour" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtcolour" runat="server" Width="100px" Skin="WebBlue">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 128px; height: 30px;">
                <asp:Label ID="Label20" runat="server" Text="Type" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 200px; height: 30px;">
                <asp:UpdatePanel ID="UpType" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadComboBox ID="cmbType" EnableLoadOnDemand="true" Filter="StartsWith"  runat="server" AutoPostBack="true" Skin="WebBlue"
                            OnSelectedIndexChanged="cmbType_SelectedIndexChanged">
                        </telerik:RadComboBox>
                        <telerik:RadTextBox ID="txtType" runat="server" Width="100px" Skin="WebBlue" Visible="false">
                        </telerik:RadTextBox>
                        <asp:ImageButton ID="btnAddType" runat="server" ImageUrl="~/Images/Add.png" Style="height: 25px;
                            margin-bottom: -9px;"></asp:ImageButton>
                        <asp:ImageButton ID="BtnSaveType" runat="server" ImageUrl="~/Images/SaveButton.jpg"
                            Style="height: 25px; margin-bottom: -9px;" Visible="false"></asp:ImageButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td align="center" style="width: 128px; height: 30px;">
            </td>
            <td style="width: 200px; height: 30px;">
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 128px; height: 30px;">
                <asp:Label ID="Label4" runat="server" Text="Composition" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 200px; height: 30px;">
                <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtCompositionn" runat="server" AutoPostBack="true" Width="300px"
                            Skin="WebBlue" Visible="true">
                        </asp:TextBox>
                        <asp:TextBox ID="txtCompositionnAdd" runat="server" AutoPostBack="false" Width="300px"
                            Skin="WebBlue" Visible="false">
                        </asp:TextBox>
                        <asp:Label ID="lblCompositionID" runat="server" Visible="false" Text="0"></asp:Label>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="10"
                            CompletionSetCount="12" ContextKey="CompositionForFDB" EnableCaching="true" MinimumPrefixLength="1"
                            ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtCompositionn" />
                        <telerik:RadComboBox ID="cmbComposition" runat="server" AutoPostBack="true" Skin="WebBlue"
                            OnSelectedIndexChanged="cmbComposition_SelectedIndexChanged" Visible="false">
                        </telerik:RadComboBox>
                        <asp:ImageButton ID="btnAddComp" runat="server" ImageUrl="~/Images/Add.png" Style="height: 25px;
                            margin-bottom: -9px;"></asp:ImageButton>
                        <asp:ImageButton ID="btnSaveComp" runat="server" ImageUrl="~/Images/SaveButton.jpg"
                            Style="height: 25px; margin-bottom: -9px;" Visible="false"></asp:ImageButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td align="center" style="width: 128px; height: 30px;">
                <asp:Label ID="Label5" runat="server" Text="Dye" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 200px; height: 30px;">
                <telerik:RadTextBox ID="txtdyewash" runat="server" Width="100px" Skin="WebBlue" Visible="false">
                </telerik:RadTextBox>
                <asp:TextBox ID="cmbDyeWash" CssClass="textbox" AutoPostBack="true" autocomplete="off"
                    runat="server"></asp:TextBox>
                <cc1:AutoCompleteExtender runat="server" ID="AutoCompleteExtender3" TargetControlID="cmbDyeWash"
                    ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                    CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="DyeWash" />
                <asp:Label ID="lblDyeWash" runat="server" Visible="false"></asp:Label>
                <asp:ImageButton ID="btnAddDye" runat="server" ImageUrl="~/Images/Add.png" Style="height: 25px;
                    margin-bottom: -9px;"></asp:ImageButton>
                <asp:ImageButton ID="BtnSaveDye" runat="server" ImageUrl="~/Images/SaveButton.jpg"
                    Style="height: 25px; margin-bottom: -9px;" Visible="false"></asp:ImageButton>
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 128px; height: 30px;">
                <asp:Label ID="Label6" runat="server" Text="Finish" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 200px; height: 30px;">
                <asp:UpdatePanel ID="UpFinishGSM" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtFinishGSMm" runat="server" Width="300px" Skin="WebBlue" Visible="true"
                            AutoPostBack="true">
                        </asp:TextBox>
                        <asp:TextBox ID="txtFinishGSMmAdd" runat="server" AutoPostBack="false" Width="300px"
                            Skin="WebBlue" Visible="false">
                        </asp:TextBox>
                        <asp:Label ID="lblFinishGSMID" runat="server" Visible="false" Text="0"></asp:Label>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="10"
                            CompletionSetCount="12" ContextKey="FinishGSMForFDB" EnableCaching="true" MinimumPrefixLength="1"
                            ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtFinishGSMm" />
                        <telerik:RadComboBox ID="cmbFinishGSM" runat="server" AutoPostBack="true" Skin="WebBlue"
                            OnSelectedIndexChanged="cmbFinishGSM_SelectedIndexChanged" Visible="false">
                        </telerik:RadComboBox>
                        <asp:ImageButton ID="btnAddFinish" runat="server" ImageUrl="~/Images/Add.png" Style="height: 25px;
                            margin-bottom: -9px;"></asp:ImageButton>
                        <asp:ImageButton ID="btnSaveFinish" runat="server" ImageUrl="~/Images/SaveButton.jpg"
                            Style="height: 25px; margin-bottom: -9px;" Visible="false"></asp:ImageButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td align="center" style="width: 128px; height: 30px;">
                <asp:Label ID="Label7" runat="server" Text="Fabric Width" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtFabricWidth" runat="server" Width="100px" Skin="WebBlue">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 128px; height: 30px;">
                <asp:Label ID="Label9" runat="server" Text="Fabric Name" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <asp:UpdatePanel ID="Upfabricname" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadTextBox ID="txtfabricname" AutoPostBack="true" runat="server" Width="300px"
                            Skin="WebBlue" Display="True" TextMode="MultiLine">
                        </telerik:RadTextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 128px; height: 30px;">
                <asp:Label ID="Label18" runat="server" Text="GSM Bef. Wash " Font-Names="Calibri"
                    Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtBefWashGSM" runat="server" Width="100px" Skin="WebBlue">
                </telerik:RadTextBox>
            </td>
            <td align="center" style="width: 128px; height: 30px;">
                <asp:Label ID="Label10" runat="server" Text="GSM After Wash" Font-Names="Calibri"
                    Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtAfterwashGSM" runat="server" Width="100px" Skin="WebBlue">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 128px; height: 30px;">
                <asp:Label ID="Label11" runat="server" Text="Shrinkage" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtShrinkage" runat="server" Width="100px" Skin="WebBlue">
                </telerik:RadTextBox>
            </td>
            <td align="center" style="width: 128px; height: 30px;">
                <asp:Label ID="Label19" runat="server" Text="Mill Shrinkage" Font-Names="Calibri"
                    Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtMillShrinkage" runat="server" Width="100px" Skin="WebBlue">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 128px; height: 30px;">
                <asp:Label ID="Label16" runat="server" Text="O/P Qty" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadNumericTextBox ID="txtopqty" runat="server" Width="100px" Skin="WebBlue"
                    Type="Number" NumberFormat-DecimalDigits="2">
                </telerik:RadNumericTextBox>
            </td>
            <td align="center" style="width: 128px; height: 30px;">
                <asp:Label ID="Label17" runat="server" Text="Purchase Qty" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadNumericTextBox ID="txtpurchaseQty" runat="server" Width="100px" Skin="WebBlue"
                    Type="Number" NumberFormat-DecimalDigits="2">
                </telerik:RadNumericTextBox>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td align="center" style="width: 181px; height: 30px;">
                <asp:Label ID="Label12" runat="server" Text="General Remarks" Font-Names="Calibri"
                    Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 200px; height: 30px;" colspan="2">
                <telerik:RadTextBox ID="txtGeneralRemarks" runat="server" Width="295px" Skin="WebBlue"
                    TextMode="MultiLine">
                </telerik:RadTextBox>
            </td>
            <td align="center" style="width: 128px; height: 30px;">
                <asp:Label ID="Label23" runat="server" Text="Shade" Font-Names="Calibri" Font-Size="Medium"
                    Style="margin-left: -287px;"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtShade" runat="server" Width="100px" Skin="WebBlue" Style="margin-left: -119px;">
                </telerik:RadTextBox>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="6" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                Fabric Pricing History
            </th>
        </tr>
        <tr>
            <td align="center" style="width: 83px; height: 30px;">
                <asp:Label ID="Label13" runat="server" Text="Price in (Rs.)" Font-Names="Calibri"
                    Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadNumericTextBox ID="txtPrice" runat="server" Width="100px" Skin="WebBlue"
                    Type="Number" NumberFormat-DecimalDigits="2">
                </telerik:RadNumericTextBox>
            </td>
            <td align="center" style="width: 100px; height: 30px;">
                <asp:Label ID="Label14" runat="server" Text="Pricing Date" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadDatePicker ID="txtPricingDate" runat="server" Culture="en-US" Width="100px">
                    <Calendar ID="Calendar2" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                    </Calendar>
                    <DateInput ID="DateInput2" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td align="center" style="width: 150px; height: 30px;">
                <asp:Label ID="Label15" runat="server" Text="Price Remarks (if any)" Font-Names="Calibri"
                    Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 200px; height: 30px;" colspan="2">
                <telerik:RadTextBox ID="txtPriceRemarks" runat="server" Width="565px" Skin="WebBlue"
                    TextMode="MultiLine">
                </telerik:RadTextBox>
            </td>
            <td>
            </td>
            <td align="center" style="width: 150px; height: 30px;">
                <telerik:RadButton ID="btnAddDetail" runat="server" Text="Add Grid" Width="70px"
                    Skin="WebBlue">
                </telerik:RadButton>
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td>
                <telerik:RadGrid ID="dgFaricDtl" runat="server" CellSpacing="0" AutoGenerateColumns="false"
                    Skin="WebBlue" Visible="False" PageSize="50" AllowAutomaticDeletes="false" OnDeleteCommand="dgFaricDtl_DeleteCommand">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn HeaderText="FabricDBDtlId" DataField="FabricDBDtlId" Display="false">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Price" DataField="Price">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Pricing Date" DataField="PricingDate">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Pricing Remarks" DataField="PricingRemarks">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Confirm Price" DataField="ConfirmPrice" Display="false">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="" UniqueName="Select" AllowFiltering="false">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server"></asp:CheckBox>
                                </ItemTemplate>
                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridButtonColumn UniqueName="DeleteColumn" Text="" CommandName="Delete"
                                ConfirmTextFormatString="Are You Sure You want to Delete Record" HeaderStyle-Width="5%"
                                ButtonType="ImageButton">
                            </telerik:GridButtonColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td>
            </td>
            <td style="width: 800px;">
            </td>
            <td align="right">
                <telerik:RadButton ID="btnSave" runat="server" Text="Save" Skin="WebBlue" Width="55px">
                </telerik:RadButton>
                <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" Skin="WebBlue">
                </telerik:RadButton>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lblUserId" runat="server" Visible="false" Text="0"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
