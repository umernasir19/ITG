<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="FabricCalculation.aspx.vb" Inherits="Integra.FabricCalculation" %>

<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr style="border-bottom-style: solid; height: 50px; border-bottom-color: #00509F;
            border-bottom-width: thin;" visible="true">
            <th colspan="6" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                Fabric Calculation Sheet
            </th>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td>
                <div class="txt" style="width: 125px; margin-left: 0px; height: 19px;">
                    Order Con Date:
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                    <asp:TextBox ID="txtOrderConsumptionDate" CssClass="textbox" Width="120" runat="server"
                        Style="text-transform: uppercase; margin-left: 0px;"></asp:TextBox>
                </div>
                <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtOrderConsumptionDate"
                    PopupButtonID="ImageButton1" />
                <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" ImageUrl="~/Images/callendar.JPG"
                    AlternateText="Click here to display calendar" Style="margin-left: 0px;" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtOrderConsumptionDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>
            </td>
           <td>
                <div class="txt" style="width: 125px; margin-left: 115px; height: 19px; margin-top: 6px;">
                    Buyer
                </div>
            </td>
            <td>
                <div style="margin-left: 10px; margin-right: 0px;">
                    <telerik:RadComboBox ID="cmbBuyer" runat="server" AutoPostBack="false" Skin="WebBlue">
                    </telerik:RadComboBox>
                </div>
            </td>
        </tr>
    </table>
     <table>
        <tr style="height: 34px;">
            <td style="height: 35px">
                <div class="txt" style="width: 125px; margin-left: 0px; height: 19px;">
                    DAL No/Code
                </div>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <div class="text_box" style="width: 130px; margin-left: 0px;">
                    <asp:TextBox CssClass="textbox" ID="txtDALNo" AutoPostBack="true" Style="margin-left: 10px;"
                        runat="server" ReadOnly="false"></asp:TextBox>
                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender9" runat="server" CompletionInterval="10"
                        CompletionSetCount="12" ContextKey="ItemFromJobOrderNew" EnableCaching="true"
                        MinimumPrefixLength="1" ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx"
                        TargetControlID="txtDALNo" />
                </div>
            </td>
            <td>
                <div class="txt" style="width: 125px; margin-left: 111px; height: 19px; margin-top: 6px;">
                    Construnction
                </div>
            </td>
            <td>
                <div class="text_box" style="margin-left: 10px; margin-right: 0px;">
                    <asp:TextBox CssClass="textbox" ID="txtConstrunctionn" TextMode ="MultiLine"  AutoPostBack="true" Style="width: 326px;
                        margin-left: 2px;" runat="server" ReadOnly="true"></asp:TextBox>
                </div>
            </td>
        </tr>
    </table>
   
    
     <table width="100%">
        <tr style="border-bottom-style: solid; height: 50px; border-bottom-color: #00509F;
            border-bottom-width: thin;" visible="true">
            <th colspan="6" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                
            </th>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td>
                <div class="txt" style="width: 125px; margin-left: 0px; height: 19px;">
                    Contract #:
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 0px;">
                    <asp:TextBox ID="TXTContract" CssClass="textbox" ReadOnly="false" runat="server"
                        Style="margin-left: 10px;"></asp:TextBox>
                </div>
            </td>
            <td style="height: 35px">
                <div class="txt" style="width: 125px; margin-left: 136px; height: 19px;">
                    Price:
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                    <asp:TextBox ID="txtPrice" CssClass="textbox" ReadOnly="false" runat="server" Style="margin-left: 0px;"
                        AutoPostBack="false" onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td style="height: 35px">
                <div class="txt" style="width: 125px; margin-left: 0px; height: 19px;">
                    Booked:
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                    <asp:TextBox ID="txtBooked" CssClass="textbox" ReadOnly="false" runat="server" Style="margin-left: 0px;"
                        AutoPostBack="false" onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                </div>
            </td>
             <td>
                <div class="txt" style="width: 125px; margin-left: 137px; height: 19px;">
                    Delivery Date:
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                    <asp:TextBox ID="txtDeliveryDate" CssClass="textbox" Width="120" runat="server" Style="text-transform: uppercase;
                        margin-left: 0px;"></asp:TextBox>
                </div>
                <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="txtDeliveryDate"
                    PopupButtonID="ImageButton2" />
                <asp:ImageButton runat="Server" ID="ImageButton2" CausesValidation="false" ImageUrl="~/Images/callendar.JPG"
                    AlternateText="Click here to display calendar" Style="margin-left: 0px;" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtDeliveryDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>
            </td>
        </tr>
    </table>

     <br />
    <table>
        <tr style="height: 55px;">
            <td>
                <asp:Button ID="btnAddNew" runat="server" Skin="WebBlue" ToolTip="Click here To Save data." Text="Add" 
                    CssClass="btn btn-outline btn-success" Width="120px" CausesValidation="true"
                    Style="margin-left: 589px;"></asp:Button>

         

            </td>
        </tr>
    </table>
     <br />
    <table style="width: 100%">
        <tr style="height: 100px;">
            <td>
                <Smart:SmartDataGrid ID="dgContract" runat="server" Width="100%" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                    PageSize="20" ShowFooter="True" ForeColor="white" GridLines="both">
                    <Columns>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="FabCalContractDtlID"
                            DataField="FabCalContractDtlID" Visible="false" />
                      
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Contract"
                            DataField="Contract">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Price"
                            DataField="Price">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Booked"
                            DataField="Booked">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Delivery Date"
                            DataField="DeliveryDate">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                        </asp:BoundColumn>
                    </Columns>
                </Smart:SmartDataGrid>
            </td>
        </tr>
    </table>
    <br />
   <table width="100%">
        <tr style="border-bottom-style: solid; height: 50px; border-bottom-color: #00509F;
            border-bottom-width: thin;" visible="true">
            <th colspan="6" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                Detail Section
            </th>
        </tr>
    </table>

    <table>
        <tr>
            <td>
                <div class="txt" style="width: 125px; margin-left: 0px; margin-top: 3px; height: 19px;">
                    Season
                </div>
            </td>
            <td>
                <div style="margin-left: 10px; margin-right: 0px;">
                    <telerik:RadComboBox ID="cmbSeason" runat="server" AutoPostBack="true" Skin="WebBlue">
                    </telerik:RadComboBox>
                </div>
            </td>
            <td>
                <div class="txt" style="width: 125px; margin-left: 107px; height: 19px;">
                    Sr No
                </div>
            </td>
            <td>
                <div style="margin-left: 11px; margin-right: 0px;">
                    <telerik:RadComboBox ID="cmbSrNo" runat="server" AutoPostBack="true" Skin="WebBlue">
                    </telerik:RadComboBox>
                </div>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <div class="txt" style="width: 125px; margin-left: 0px; height: 19px;">
                    Order No
                </div>
            </td>
            <td>
                <div class="text_box" style="margin-left: 10px; margin-right: 0px;">
                    <asp:TextBox ID="txtORDERNO" CssClass="textbox" ReadOnly="true" runat="server" Style="margin-left: 0px;"
                        AutoPostBack="false"></asp:TextBox></div>
            </td>
            <td>
                <div class="txt" style="width: 125px; margin-left: 223px; height: 19px;">
                    Style
                </div>
            </td>
            <td>
                <div style="margin-left: 11px; margin-right: 0px;">
                    <telerik:RadComboBox ID="cmbStyle" runat="server" AutoPostBack="true" Skin="WebBlue">
                    </telerik:RadComboBox>
                </div>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <div class="txt" style="width: 125px; margin-left: 0px; height: 19px;">
                    Model
                </div>
            </td>
            <td>
                <div class="text_box" style="margin-left: 10px; margin-right: 0px;">
                    <asp:TextBox ID="txtModel" CssClass="textbox" ReadOnly="true" runat="server" Style="margin-left: 0px;"
                        AutoPostBack="false"></asp:TextBox></div>
            </td>
            <td>
                <div class="txt" style="width: 125px; margin-left: 223px; height: 19px;">
                    Description
                </div>
            </td>
            <td>
                <div class="text_box" style="margin-left: 11px; margin-right: 0px;">
                    <asp:TextBox ID="txtDescription" CssClass="textbox" ReadOnly="true" runat="server"
                        Style="margin-left: 0px;" AutoPostBack="false"></asp:TextBox></div>
            </td>
        </tr>
    </table>
     <table>
        <tr>
            <td style="height: 35px">
                <div class="txt" style="width: 125px; margin-left: 0px; height: 19px;">
                    Fabric Supplier:
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                    <asp:TextBox ID="txtFabricSupplier" CssClass="textbox" ReadOnly="true" runat="server"
                        Style=" margin-left: 0px;" AutoPostBack="true" onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                </div>
            </td>
             <td>
                <div class="txt" style="width: 125px; margin-left: 138px; height: 19px;">
                    Color
                </div>
            </td>
            <td>
                <div class="text_box" style="margin-left: 11px; margin-right: 0px;">
                    <asp:TextBox ID="txtColor" CssClass="textbox" ReadOnly="true" runat="server"
                        Style="margin-left: 0px;" AutoPostBack="false"></asp:TextBox></div>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <div class="txt" style="width: 125px; margin-left: 0px; height: 19px;">
                    Size
                </div>
            </td>
            <td>
                <div class="text_box" style="margin-left: 10px; margin-right: 0px;">
                    <asp:TextBox ID="txtSize" CssClass="textbox" ReadOnly="true" runat="server" Style="margin-left: 0px;"
                        AutoPostBack="false"></asp:TextBox></div>
            </td>
            <td>
                <div class="txt" style="width: 125px; margin-left: 223px; height: 19px;">
                    Total Quantity
                </div>
            </td>
            <td>
                <div class="text_box" style="margin-left: 11px; margin-right: 0px;">
                    <asp:TextBox ID="txtTotalQuantity" Width="80px" CssClass="textbox" ReadOnly="true"
                        runat="server" Style="margin-left: 0px;" AutoPostBack="false"></asp:TextBox></div>
            </td>
            <td>
                <div class="text_box" style="margin-left: 48px; margin-right: 0px;">
                    <asp:TextBox ID="txtExtraQuantity" Width="80px" CssClass="textbox" ReadOnly="true"
                        runat="server" Style="margin-left: -11px;" AutoPostBack="false"></asp:TextBox></div>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <div class="txt" style="width: 125px; margin-left: 0px; height: 19px;">
                    Percent Ratio
                </div>
            </td>
            <td>
                <div class="text_box" style="margin-left: 10px; margin-right: 0px;">
                    <asp:TextBox ID="txtPercentRatio" CssClass="textbox" ReadOnly="true" runat="server"
                        Style="margin-left: 0px;" AutoPostBack="false"></asp:TextBox></div>
            </td>
            <td>
                <div class="txt" style="width: 125px; margin-left: 223px; height: 19px;">
                    Master Average
                </div>
            </td>
            <td>
                <div class="text_box" style="margin-left: 11px; margin-right: 0px;">
                    <asp:TextBox ID="txtConOne" Width="80px" CssClass="textbox" ReadOnly="true" runat="server"
                        Style="margin-left: 0px;" AutoPostBack="false"></asp:TextBox></div>
            </td>
            <td>
                <div class="text_box" style="margin-left: 48px; margin-right: 0px;">
                    <asp:TextBox ID="txtConTwo" Width="80px" CssClass="textbox" ReadOnly="true" runat="server"
                        Style="margin-left: -11px;" AutoPostBack="false"></asp:TextBox></div>
            </td>
            <td>
                <div class="text_box" style="margin-left: 48px; margin-right: 0px;">
                    <asp:TextBox ID="txtConThree" Width="80px" CssClass="textbox" ReadOnly="true" runat="server"
                        Style="margin-left: -22px;" AutoPostBack="false"></asp:TextBox></div>
            </td>
            <td>
                <div class="text_box" style="margin-left: 48px; margin-right: 0px;">
                    <asp:TextBox ID="txtConfour" Width="80px" CssClass="textbox" ReadOnly="false" runat="server"
                        Style="margin-left: -33px;" AutoPostBack="false"></asp:TextBox></div>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <div class="txt" style="width: 125px; margin-left: 0px; height: 19px; margin-top: 6px;">
                    Stock
                </div>
            </td>
            <td>
                <div style="margin-left: 10px; margin-right: 0px;">
                    <asp:TextBox ID="txtStock" CssClass="textbox" ReadOnly="false" runat="server" Style="margin-left: 0px;"
                        AutoPostBack="false" onkeypress="return isNumericKeyy(event);" Text ="0"></asp:TextBox></div>
            </td>
            <td style="height: 35px">
                <div class="txt" style="width: 125px; margin-left: 107px; height: 19px;">
                    Order:
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                    <asp:TextBox ID="txtOrder" CssClass="textbox" ReadOnly="false" runat="server" Style="margin-left: 0px;"
                        AutoPostBack="false" onkeypress="return isNumericKeyy(event);" Text ="0"></asp:TextBox>
                </div>
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr style="height: 55px;">
            <td>
                <asp:Button ID="btnAdd" runat="server" Skin="WebBlue" Text="Add Detail" 
                     Width="120px" CausesValidation="true" CssClass="btn btn-outline btn-success"
                    Style="margin-left: 588px;"></asp:Button>
            </td>
        </tr>
    </table>
    <br />
    <table style="width: 100%">
        <tr style="height: 100px;">
            <td>
                <Smart:SmartDataGrid ID="dgDetail" runat="server" Width="100%" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                    PageSize="20" ShowFooter="True" ForeColor="white" GridLines="both">
                    <Columns>
                      <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="FabCalDtlId"
                            DataField="FabCalDtlId" Visible="false" />
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="JobOrderId"
                            DataField="JobOrderId" Visible="false" />
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="JobOrderDetailId"
                            DataField="JobOrderDetailId" Visible="false" />
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="SeasonDatabaseId"
                            DataField="SeasonDatabaseId" Visible="false" />
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Sr No"
                            DataField="Srno">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Order No"
                            DataField="ORDERNO">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Color"
                            DataField="Color">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Model"
                            DataField="MODEL">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Description"
                            DataField="DESCRIPTION">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Sizes"
                            DataField="SIZES">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Percent Ratio"
                            DataField="ExtraQty">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Est Con"
                            DataField="EstCon">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Order Con"
                            DataField="OrderCon">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Act Con"
                            DataField="ActCon">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Final Con"
                            DataField="FinalCon">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Actul Pcs"
                            DataField="Actlpcs">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Mul Percnt"
                            DataField="MulPercnt">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Total Pcs"
                            DataField="TotalPcs">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Fabric Req"
                            DataField="FabricReq">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Total Requirement"
                            DataField="TotalRequirement">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                        </asp:BoundColumn>
                    </Columns>
                </Smart:SmartDataGrid>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <table width="100%">
        <tr style="height: 30px;">
            <td align="center">
                <asp:Button ID="btnCancel" CssClass="btn btn-outline btn-danger" runat="server" Text="Cancel"
                    Width="120px" />
                <asp:Button ID="btnSave" ToolTip="Click here To Save data." CssClass="btn btn-outline btn-success"
                    runat="server" Text="Save" Width="120px" />
            </td>
            <td>
                <asp:Label ID="lblFabricCaluctaionDtlID" runat="server" Visible="false"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblFabricCaluctaionContractDtlID" runat="server" Visible="false"></asp:Label>
            </td>
             <td>
                <asp:Label ID="lblItemId" runat="server" Visible="false"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
