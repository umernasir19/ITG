<%@ Page Title="Job Order Database Entry" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="JobOrderDatabaseEntry.aspx.vb" Inherits="Integra.JobOrderDatabaseEntry" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
        function TABLE1_onclick() {

        }

    </script>
    <table width="100%">
        <tr>
            <td>
                <asp:ImageButton ID="lnkprint" Style="border-width: 0px; margin-left: 786px; margin-top: -28px;"
                    ToolTip="Click here to Print Job Order." ImageUrl="~/Images/print.png" runat="server"
                    Visible="false"></asp:ImageButton>
                <asp:ImageButton ID="Inkprint2" Style="border-width: 0px; margin-left: 836px; margin-top: -48px;"
                    ToolTip="Click here to Print Assortment." ImageUrl="~/Images/print.png" runat="server"
                    Visible="false"></asp:ImageButton>
            </td>
        </tr>
        <tr class="heading">
            <td>
                &nbsp; <b>Fundamental Section </b>:
            </td>
        </tr>
    </table>
    <table>
        <tr style="height: 10px;">
            <td>
            </td>
        </tr>
    </table>
    <asp:TextBox ID="txtJobOrderNo" Enabled="false" CssClass="textbox" Visible="false"
        runat="server" Style="width: 148px; margin-left: 8px;" ReadOnly="false"></asp:TextBox>
    <table id="TABLE3" onclick="return TABLE1_onclick()">
        <tr style="height: 35px;">
            <td>
                <div class="txt_newwww" style="width: 140px;">
                    PO No.
                </div>
            </td>
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtPONo" Width="148px" CssClass="textbox" runat="server" Style="margin-left: 7px;
                        height: 20px;" ReadOnly="false" AutoPostBack="false"></asp:TextBox>
                </div>
            </td>
            <asp:Panel ID="Panel3" runat="server" Visible="true">
                <td>
                    <div class="txt_newwww" style="width: 140px; margin-left: 174px;">
                        PO Ref No.
                    </div>
                </td>
                <td>
                    <div class="text_box" style="">
                        <asp:TextBox ID="txtPORefNo" Width="156px" CssClass="textbox" runat="server" Style="margin-left: 7px;
                            height: 20px;" ReadOnly="false" AutoPostBack="false"></asp:TextBox>
                    </div>
                </td>
            </asp:Panel>
        </tr>
    </table>
    <table id="TABLE1" onclick="return TABLE1_onclick()">
        <tr style="height: 35px;">
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtSrNo" Visible="false" Width="50px" CssClass="textbox" runat="server"
                        onkeypress="return isNumericKeyy(event);" Style="margin-left: 7px; height: 20px;"
                        ReadOnly="false" AutoPostBack="true"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtSrNoTwo" Width="50px" Visible="false" CssClass="textbox" runat="server"
                        Style="margin-left: 16px; height: 20px;" ReadOnly="false" AutoPostBack="true"></asp:TextBox>
                    <asp:Label ID="lbloldSR" runat="server" Visible="false"></asp:Label></div>
            </td>
            <asp:Panel ID="PnlSeasonCmb" runat="server" Visible="true">
                <td>
                    <div class="txt_newwww" style="width: 140px; margin-left: -90px;">
                        Season
                    </div>
                </td>
                <td>
                    <asp:DropDownList ID="cmbSeason" Width="150" CssClass="combo" AutoPostBack="true"
                        runat="server" Style="margin-left: -310px; margin-left: 8px;">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:ImageButton ID="BtnAdd" Visible="false" runat="server" ImageUrl="~/Images/AddButton.jpg"
                        Style="margin-left: 5px; width: 19px;" />
                </td>
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server" Visible="false">
                <td style="width: 150px;">
                    <div class="txt_newwww" style="width: 140px; margin-left: -90px;">
                        Season
                    </div>
                </td>
                <td>
                    <div class="text_box" style="">
                        <asp:TextBox ID="txtSeason" runat="server" Width="150px" CssClass="textbox" Style="margin-right: -164px;
                            margin-left: 8px; height: 22px;"></asp:TextBox>
                    </div>
                    <asp:ImageButton ID="BtnSaveSeason" runat="server" ImageUrl="~/Images/SaveButton.jpg"
                        Style="margin-left: 120px; width: 19px;" />
                </td>
            </asp:Panel>
        </tr>
    </table>
    <asp:Panel ID="PanelAll" runat="server" Enabled="true">
        <table id="TABLE9" onclick="return TABLE1_onclick()">
            <tr style="height: 35px;">
                <td>
                    <div class="txt_newwww" style="width: 140px;">
                        Supplier.
                    </div>
                </td>
                <td>
                    <div class="text_box" style="">
                        <asp:DropDownList ID="cmbSupplier" Width="150" CssClass="combo" AutoPostBack="false"
                            runat="server" Style="width: 148px; margin-left: 8px;">
                            <asp:ListItem Value="1" Text="E&M Textile"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </td>
                <asp:Panel ID="pnlCustomer" runat="server" Visible="true">
                    <td>
                        <div class="txt_newwww" style="width: 140px; margin-left: 174px;">
                            Customer.
                        </div>
                    </td>
                    <td>
                        <div class="text_box" style="">
                            <asp:DropDownList ID="cmbCustomer" Width="150" CssClass="combo" AutoPostBack="false"
                                runat="server" Style="margin-left: -310px; margin-left: 12px;">
                            </asp:DropDownList>
                        </div>
                    </td>
                </asp:Panel>
            </tr>
        </table>
        <table id="TABLE2" onclick="return TABLE1_onclick()">
            <tr style="height: 35px;">
                <td>
                    <div class="txt_newwww" style="width: 140px;">
                        Vendor PO.
                    </div>
                </td>
                <td>
                    <div class="text_box" style="">
                        <asp:TextBox ID="txtCustomerOrder" CssClass="textbox" runat="server" Style="width: 148px;
                            margin-left: 9px;"></asp:TextBox>
                    </div>
                </td>
                <asp:Panel ID="PnlBrand1" runat="server" Visible="true">
                    <td>
                        <div class="txt_newwww" style="width: 140px; margin-left: 174px;">
                            Brand
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:DropDownList ID="cmbBrand" Width="150" CssClass="combo" AutoPostBack="false"
                                runat="server" Style="margin-left: -310px; margin-left: 12px;">
                            </asp:DropDownList>
                        </div>
                    </td>
                    <td>
                        <asp:ImageButton ID="BtnAddBrand" runat="server" ImageUrl="~/Images/AddButton.jpg"
                            Style="margin-left: 5px; width: 19px;" />
                    </td>
                    <td>
                    </td>
                </asp:Panel>
                <asp:Panel ID="PnlBrand2" runat="server" Visible="false">
                    <td>
                        <div class="txt_newwww" style="width: 140px; margin-left: 174px;">
                            Brand
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:TextBox ID="txtBrandSave" runat="server" Width="150px" CssClass="textbox" Style="margin-right: -164px;
                                margin-left: 12px;"></asp:TextBox>
                        </div>
                    </td>
                    <td>
                        <asp:ImageButton ID="BtnBrandSave" runat="server" ImageUrl="~/Images/SaveButton.jpg"
                            Style="margin-left: 167px; width: 19px;" />
                    </td>
                    <td>
                    </td>
                </asp:Panel>
            </tr>
        </table>
        <table width="100%" id="TABLE4" onclick="return TABLE1_onclick()">
            <tr>
                <td style="width: 150px;">
                    <div class="txt_newwww" style="width: 140px;">
                        PO Date
                    </div>
                </td>
                <td>
                    <div class="text_box">
                        <asp:TextBox ID="txtOrderRecvDate" Style="text-align: center; width: 100px;" runat="server"
                            Font-Size="8pt"></asp:TextBox></div>
                    <div class="icon" align="center">
                        <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtOrderRecvDate"
                            PopupButtonID="ImageButton1" />
                        <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" ImageUrl="~/Images/callendar.jpg"
                            AlternateText="Click here to display calendar" Style="margin-left: -592px;" />
                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtOrderRecvDate"
                            Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                            CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                            Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                        </cc1:MaskedEditExtender>
                    </div>
                </td>
                <td>
                    <div class="txt_newwww" style="width: 140px; margin-left: -569px;">
                        Ship Date
                    </div>
                </td>
                <td>
                    <div class="text_box" style="margin-left: -310px;">
                        <asp:TextBox ID="txtShipmentDate" Style="text-align: center; width: 100px; margin-left: -105px;"
                            runat="server" Font-Size="8pt"></asp:TextBox></div>
                    <div class="icon" align="center">
                        <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="txtShipmentDate"
                            PopupButtonID="ImageButton2" />
                        <asp:ImageButton runat="Server" ID="ImageButton2" Style="margin-left: -595px;" CausesValidation="false"
                            ImageUrl="~/Images/callendar.jpg" AlternateText="Click here to display calendar" />
                        <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtShipmentDate"
                            Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                            CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                            Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                        </cc1:MaskedEditExtender>
                    </div>
                </td>
            </tr>
        </table>
        <table id="TABLE5" onclick="return TABLE1_onclick()">
            <tr style="height: 35px;">
                <td>
                    <div class="txt_newwww" style="width: 140px; margin-right: 8px;">
                        Currency
                    </div>
                </td>
                <td>
                    <asp:DropDownList ID="cmbCurrency" Width="150" CssClass="combo" AutoPostBack="false"
                        runat="server">
                    </asp:DropDownList>
                </td>
               
                <asp:Panel ID="Panel3Add" runat="server" Visible="false">
                    <td>
                        <div class="txt_newwww" style="width: 140px; margin-left: 61px;">
                            Payment Method
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:DropDownList ID="cmbPayMode" Width="150" CssClass="combo" AutoPostBack="false"
                                runat="server" Style="margin-left: -310px; margin-left: 12px;">
                            </asp:DropDownList>
                        </div>
                    </td>
                    <td>
                        <asp:ImageButton ID="ImageButtonAddPaympde" runat="server" ImageUrl="~/Images/AddButton.jpg"
                            Style="margin-left: 5px; width: 19px;" />
                    </td>
                    <td>
                    </td>
                </asp:Panel>
                <asp:Panel ID="Panel4Save" runat="server" Visible="false">
                    <td>
                        <div class="txt_newwww" style="width: 140px; margin-left: 61px;">
                            Payment Method
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:TextBox ID="txtPayMode" runat="server" Width="150px" CssClass="textbox" Style="margin-right: -164px;
                                margin-left: 12px;"></asp:TextBox>
                        </div>
                    </td>
                    <td>
                        <asp:ImageButton ID="ImageButtonSavePayMode" runat="server" ImageUrl="~/Images/SaveButton.jpg"
                            Style="margin-left: 167px; width: 19px;" />
                    </td>
                    <td>
                    </td>
                </asp:Panel>
            
            </tr>
        </table>
        <table id="TABLE6" onclick="return TABLE1_onclick()">
            <tr style="height: 35px;">
                <asp:Panel ID="PnlShipmentMode1" runat="server" Visible="true">
                    <td>
                        <div class="txt_newwww" style="width: 140px;">
                            Ship Schedule
                        </div>
                    </td>
                    <td>
                        <asp:DropDownList ID="cmbShipMode" Width="150" CssClass="combo" AutoPostBack="FALSE"
                            runat="server" Style="margin-left: 9px;">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:ImageButton ID="BtnAddShipMode" runat="server" Style="margin-left: 5px; width: 19px;"
                            ImageUrl="~/Images/AddButton.jpg" Visible="true" />
                    </td>
                </asp:Panel>
                <asp:Panel ID="PnlShipmentMode2" runat="server" Visible="False">
                    <td>
                        <div class="txt_newwww" style="width: 140px;">
                            Ship Schedule
                        </div>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSaveShipmentMode" runat="server" Width="150px" CssClass="textbox"
                            Style="margin-right: -43px; margin-left: 8px;"></asp:TextBox>
                        <asp:ImageButton ID="BtnSaveShipmentMode" runat="server" Style="margin-left: 41px;
                            width: 19px;" ImageUrl="~/Images/SaveButton.jpg" />
                    </td>
                </asp:Panel>
                <asp:Panel ID="pnlPortOrigin1" runat="server" Visible="true">
                    <td>
                    </td>
                    <td>
                        <asp:DropDownList ID="cmbOrigin" runat="server" Enabled="false" AutoPostBack="true"
                            CssClass="combo" Style="margin-left: 13px; width: 150PX;" Visible="false">
                            <asp:ListItem Value="1" Text="Port of origin"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Airport of origin"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </asp:Panel>
                <asp:Panel ID="pnlPortOrigin2" runat="server" Visible="false">
                    <td>
                        <div class="txt_newwww" style="width: 140px; margin-left: 35px;">
                        </div>
                    </td>
                    <td>
                        <div>
                        </div>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </asp:Panel>
            </tr>
        </table>
        <table id="TABLE8" onclick="return TABLE1_onclick()">
            <tr>
                <asp:Panel ID="PnlPortDestination1" runat="server" Visible="true">
                    <td>
                        <div class="txt_newwww" style="width: 140px;">
                            Delivery Method.
                        </div>
                    </td>
                    <div style="margin-left: -310px;">
                        <td>
                            <asp:DropDownList ID="cmbPortOrigin" Width="150" CssClass="combo" AutoPostBack="false"
                                runat="server" Style="margin-left: -85px;" Visible="TRUE">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:ImageButton ID="BtnAddPort" runat="server" ImageUrl="~/Images/AddButton.jpg"
                                Style="margin-left: 5px; width: 19px;" Visible="TRUE" />
                        </td>
                    </div>
                </asp:Panel>
                <asp:Panel ID="PnlPortDestination2" runat="server" Visible="false">
                    <td>
                        <div class="txt_newwww" style="width: 140px;">
                            Delivery Method.
                        </div>
                    </td>
                    <div style="margin-left: -310px;">
                        <td>
                            <asp:TextBox ID="txtPortOrigin" runat="server" Width="120px" CssClass="textbox" Style="margin-right: -43px;
                                margin-left: -84px" Visible="TRUE"></asp:TextBox>
                        </td>
                        <td>
                            <asp:ImageButton ID="btnsavePort" runat="server" ImageUrl="~/Images/SaveButton.jpg"
                                Style="margin-left: 45px; width: 19px;" Visible="TRUE" />
                        </td>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlPortLoad1" runat="server" Visible="true">
                    <td>
                        <div class="txt_newwww" style="width: 140px; margin-left: 35px;">
                            Payment Terms
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:DropDownList ID="cmbPortLoad" Width="150" CssClass="combo" AutoPostBack="false"
                                runat="server" Style="margin-left: -310px; margin-left: 12px;" Visible="true">
                            </asp:DropDownList>
                        </div>
                    </td>
                    <td>
                        <asp:ImageButton ID="btnAddPortLoad" runat="server" ImageUrl="~/Images/AddButton.jpg"
                            Style="margin-left: 5px; width: 19px;" Visible="true" />
                    </td>
                    <td>
                    </td>
                </asp:Panel>
                <asp:Panel ID="pnlPortLoad2" runat="server" Visible="false">
                    <td>
                        <div class="txt_newwww" style="width: 140px; margin-left: 35px;">
                            Payment Terms
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:TextBox ID="txtPortLoad" runat="server" Width="150px" CssClass="textbox" Style="margin-right: -164px;
                                margin-left: 12px;"></asp:TextBox>
                        </div>
                    </td>
                    <td>
                        <asp:ImageButton ID="btnSavePortLoad" runat="server" ImageUrl="~/Images/SaveButton.jpg"
                            Style="margin-left: 167px; width: 19px;" />
                    </td>
                    <td>
                    </td>
                </asp:Panel>
            </tr>
            <tr style="height: 34px;">
                <asp:Panel ID="pnlDeliveryTerm1" runat="server" Visible="true">
                    <td style="width: 235px;">
                        <div class="txt_newwww" style="width: 140px; margin-left: 0px;">
                            <asp:Label ID="Label2" runat="server" Text="Delivery Term"></asp:Label>
                        </div>
                    </td>
                    <td>
                        <asp:DropDownList ID="cmbDeliveryTerm" Width="150" CssClass="combo" AutoPostBack="false"
                            runat="server" Style="margin-left: -85px;">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:ImageButton ID="btnAddDeliveryTerm" runat="server" ImageUrl="~/Images/AddButton.jpg"
                            Style="margin-left: 5px; width: 19px;" Visible="true" />
                    </td>
                </asp:Panel>
                <asp:Panel ID="pnlDeliveryTerm2" runat="server" Visible="false">
                    <td style="width: 235px;">
                        <div class="txt_newwww" style="width: 140px; margin-left: 0px;">
                            <asp:Label ID="Label3" runat="server" Text="Delivery Term"></asp:Label>
                        </div>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDeliveryTerm" runat="server" Width="150px" CssClass="textbox"
                            Style="margin-left: -85px;"></asp:TextBox>
                    </td>
                    <td>
                        <asp:ImageButton ID="btnSaveDeliveryTerm" runat="server" ImageUrl="~/Images/SaveButton.jpg"
                            Style="margin-left: 0px; width: 19px;" />
                    </td>
                </asp:Panel>
            </tr>
        </table>
        <table id="TABLE7" onclick="return TABLE1_onclick()">
            <tr style="height: 35px;">
                <td>
                    <div class="txt_newwww" style="width: 140px;">
                        Shipping Instruction
                    </div>
                </td>
                <td colspan="4">
                    <div class="text_box" style="">
                        <asp:TextBox ID="txtShippingInstruction" TextMode="MultiLine" runat="server" Style="width: 537px;
                            text-transform: uppercase;"></asp:TextBox>
                    </div>
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td>
                    <asp:Panel ID="pnlBusinessandCertificationData" runat="server" Font-Names="verdana"
                        Font-Size="9" GroupingText="Compliance Section" Visible="false">
                        <div style="vertical-align: top; height: 100px; overflow: auto;">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <div class="txt_newwww" style="width: 200px;">
                                            <b>Certification Required </b>
                                        </div>
                                    </td>
                                    <td align="left">
                                        <asp:LinkButton ID="certificate" CausesValidation="false" runat="server" Font-Size="8"
                                            Text="Select Certificate"></asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnGetCertificate" runat="server" CssClass="btn btn-outline btn-success"
                                            Width="70px" Text="Show" TabIndex="23" />
                                    </td>
                                </tr>
                            </table>
                            <table width="100%">
                                <tr>
                                    <td>
                                        <asp:Repeater ID="rpCertificate" runat="server">
                                            <HeaderTemplate>
                                                <table width="100%">
                                                    <tr>
                                                        <td align="left" style="width: 130px; font-family: Verdana; color: white; font-size: x-small;">
                                                            Certificate Name
                                                        </td>
                                                        <td align="left" style="width: 90px; font-family: Verdana; color: white; font-size: x-small;">
                                                            Expire Date
                                                        </td>
                                                    </tr>
                                                </table>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <table width="100%">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblCertificateID" Width="150" Visible="false" runat="server" Text='<%#Eval("CertificateID") %>'></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblSupplierCertificateID" Width="150" Visible="false" runat="server"
                                                                Text='<%#Eval("SupplierCertificateID") %>'></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblCertificateName" Width="150" runat="server" Text='<%#Eval("Certificate") %>'></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblcertificateExpire" Width="150" runat="server" Text='<%#Eval("CertificateExpire") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
                </td>
                <td>
                    <asp:Panel ID="Panel1" runat="server" Font-Names="verdana" Font-Size="9" GroupingText="Compliance Section"
                        Visible="false">
                        <div style="vertical-align: top; height: 100px; overflow: auto;">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <div class="txt_newwww" style="width: 150px;">
                                            <b>Test Required </b>
                                        </div>
                                    </td>
                                    <td align="left">
                                        <asp:LinkButton ID="LinkButton1" CausesValidation="false" runat="server" Font-Size="8"
                                            Text="Select Test Req."></asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-outline btn-success" Width="70px"
                                            Text="Show" TabIndex="23" />
                                    </td>
                                </tr>
                            </table>
                            <table width="100%">
                                <tr>
                                    <td>
                                        <asp:Repeater ID="rptTestRequired" runat="server">
                                            <HeaderTemplate>
                                                <table width="100%">
                                                    <tr>
                                                        <td align="left" style="width: 130px; font-family: Verdana; color: white; font-size: x-small;">
                                                            Test Req Name
                                                        </td>
                                                        <td align="left" style="width: 90px; font-family: Verdana; color: white; font-size: x-small;">
                                                            Geographic Territory
                                                        </td>
                                                    </tr>
                                                </table>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <table>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblTestingDatabaseID" Width="150" Visible="false" runat="server" Text='<%#Eval("TestingDatabaseID") %>'></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblTESTREQUIREMENTS" Width="150" Visible="true" runat="server" Text='<%#Eval("TESTREQUIREMENTS") %>'></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblGeographicTerritory" Width="150" runat="server" Text='<%#Eval("GeographicTerritory") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <table width="100%">
            <tr class="heading">
                <td>
                    &nbsp; <b>Style/Article Section </b>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:LinkButton ID="LnkItemDatabase" CausesValidation="false" runat="server" Font-Size="7"
                        Visible="false" Style="margin-left: 99px;" Text="ADD Item"></asp:LinkButton>
                    <asp:ImageButton ID="btnShow" runat="server" BackColor="transparent" ToolTip="Click here to show data."
                        ImageUrl="~/Images/redCal.jpg" Visible="false" />
                </td>
            </tr>
        </table>
        <br />
        <table>
            <tr>
                <td id="Td2" align="center" runat="server" style="background-color: Transparent;
                    color: Red; font-family: Verdana; font-weight: bold; height: 18px; width: 926px;">
                    <asp:Label ID="lblErrorMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <table width="100%">
            <tr>
                <td>
                    <div style="overflow: scroll; width: 930px;">
                        <Smart:SmartDataGrid ID="dgJobOrderDetail" runat="server" ForeColor="white" CssClass="table"
                            Width="100%" ShowFooter="True" PageSize="20" CellPadding="2" GridLines="both"
                            AutoGenerateColumns="False" AllowSorting="True">
                            <PagerStyle Mode="NumericPages" CssClass="GridPagerStyle" HorizontalAlign="Right"
                                Visible="False"></PagerStyle>
                            <AlternatingItemStyle CssClass="GridAlternativeRow"></AlternatingItemStyle>
                            <ItemStyle CssClass="GridRow"></ItemStyle>
                            <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center"></HeaderStyle>
                            <Columns>
                                <asp:BoundColumn DataField="JoborderDetailid" HeaderText="Detail ID" Visible="false">
                                </asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="Style/Article No">
                                    <ItemStyle Width="5%" HorizontalAlign="Left"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtStyle" runat="server" Width="65" CssClass="textbox" AutoPostBack="false"
                                            Style="text-transform: uppercase;"></asp:TextBox>
                                        <asp:ImageButton ID="imgSyleAdd" runat="server" ToolTip="Click here to Add Style."
                                            CommandName="AddStyle" Visible="false" ImageUrl="~/Images/AddButton.jpg" Style="width: 18px;
                                            margin-top: -17px; margin-left: 66px;" />
                                        <asp:Label ID="lblDPRNDid" runat="server" Text="0" Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="6%" HorizontalAlign="Center"></HeaderStyle>
                                </asp:TemplateColumn>
                                <%--Location Visible False--%>
                                <asp:TemplateColumn HeaderText="Location" Visible="false">
                                    <ItemStyle Width="5%" HorizontalAlign="Left"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtModelRefNo" Text="N/A" runat="server" Width="90" Style="text-transform: uppercase;"
                                            CssClass="textbox"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="4%" HorizontalAlign="Center"></HeaderStyle>
                                </asp:TemplateColumn>
                                 <asp:TemplateColumn HeaderText="Parent Cd">
                                    <ItemStyle Width="5%" HorizontalAlign="Left"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtParentCd" runat="server" Width="90" Style="text-transform: uppercase;"
                                            CssClass="textbox"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="4%" HorizontalAlign="Center"></HeaderStyle>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="ITEM" Visible="false">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:DropDownList ID="cmbItem" Width="200" CssClass="textbox" Font-Size="8pt" runat="server">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <HeaderStyle Width="16%" HorizontalAlign="Center"></HeaderStyle>
                                </asp:TemplateColumn>
                                <%--Kashi Item DESC Add Plus Button--%>
                                <asp:TemplateColumn HeaderText="ITEM DESC.">
                                    <ItemStyle Width="5%" HorizontalAlign="Left"></ItemStyle>
                                    <ItemTemplate>

                        <asp:DropDownList ID="cmbItemDesc" CssClass="textbox" Width="140" Font-Size="8pt"
                                            runat="server">
                                        </asp:DropDownList>
                    
                        <%--<asp:ImageButton ID="BtnAddItemDesc" runat="server" Style="margin-left: 5px; width: 19px;"
                            ImageUrl="~/Images/AddButton.jpg" Visible="true" />--%>
                        <asp:ImageButton ID="lnkBtnAddItemDesc" ImageUrl="~/Images/AddButton.jpg"
                                            CommandName="AddITMDesc" Style="width: 19px; margin-top: 0px;" runat="server"></asp:ImageButton>
                    
                
                
                    
                        <asp:TextBox ID="txtSaveItemDesc" runat="server" Visible="false" Width="150px" CssClass="textbox"
                            ></asp:TextBox>                        
                        <%--<asp:ImageButton ID="BtnSaveItemDesc" runat="server" Style="margin-left: 41px;
                            width: 19px;" ImageUrl="~/Images/SaveButton.jpg" />--%>
                        <asp:ImageButton ID="lnkBtnSaveItemDesc" Visible="false" ImageUrl="~/Images/SaveButton.jpg"
                                            CommandName="SaveITMDesc" Style="width: 19px; margin-top: 0px;" runat="server"></asp:ImageButton>
                
         
                                    </ItemTemplate>
                                    <HeaderStyle Width="7%" HorizontalAlign="Center"></HeaderStyle>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="ITEM CODE." Visible="false">
                                    <ItemStyle Width="5%" HorizontalAlign="Left"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtItemCode" runat="server" Width="100" AutoPostBack="true" CssClass="textbox"
                                            OnTextChanged="txtItemCode_TextChanged"></asp:TextBox>
                                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender56" runat="server" CompletionInterval="10"
                                            CompletionSetCount="12" ContextKey="ItemFromJobOrder" EnableCaching="true" MinimumPrefixLength="1"
                                            ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtItemCode" />
                                        <asp:Label ID="lblItemID" runat="server" Width="10" Text="0" Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="7%" HorizontalAlign="Center"></HeaderStyle>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="FABRIC QUALITY" Visible="false">
                                    <ItemStyle Width="5%" HorizontalAlign="Left"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtContent" runat="server" Width="170px" CssClass="textbox" TextMode="MultiLine"
                                            ReadOnly="true"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="7%" HorizontalAlign="Center"></HeaderStyle>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="FABRIC QUALITY BUYER" Visible="false">
                                    <ItemStyle Width="5%" HorizontalAlign="Left"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtContentforBuyer" runat="server" TextMode="MultiLine" Width="170px"
                                            CssClass="textbox"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="7%" HorizontalAlign="Center"></HeaderStyle>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="GSM Bef. Wash" Visible="false">
                                    <ItemStyle Width="5%" HorizontalAlign="Left"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtGSM" runat="server" Width="60" CssClass="textbox"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="7%" HorizontalAlign="Center"></HeaderStyle>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="GSM After Wash" Visible="false">
                                    <ItemStyle Width="5%" HorizontalAlign="Left"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtGSMAfter" runat="server" Width="50" CssClass="textbox"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="7%" HorizontalAlign="Center"></HeaderStyle>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="COLOR CODE">
                                    <ItemStyle Width="5%" HorizontalAlign="Left"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtColorCode" runat="server" Width="80" CssClass="textbox"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="7%" HorizontalAlign="Center"></HeaderStyle>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="BUYER COLOR">
                                    <ItemStyle Width="5%" HorizontalAlign="Left"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtBuyerColorName" runat="server" Width="80" CssClass="textbox"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="7%" HorizontalAlign="Center"></HeaderStyle>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="QTY">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtQuantity" onkeypress="return isNumericKeyy(event);" runat="server"
                                            Width="40" CssClass="textbox" AutoPostBack="true" OnTextChanged="txtQuantity_TextChanged"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="7%" HorizontalAlign="Center"></HeaderStyle>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="UOM">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:DropDownList ID="cmbUOM" CssClass="textbox" Width="40" Font-Size="8pt" runat="server">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <HeaderStyle Width="6%" HorizontalAlign="Center"></HeaderStyle>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="RATE">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtUnitPrice" AutoPostBack="true" OnTextChanged="txtUnitPrice_TextChanged"
                                            onkeypress="return isNumericKeyy(event);" runat="server" Width="40" CssClass="textbox"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="6%" HorizontalAlign="Center"></HeaderStyle>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgcalculate" Visible="false" runat="server" ToolTip="Click here to calculate quantity & value."
                                            CommandName="Calculate" ImageUrl="~/Images/redCal.jpg" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="1%"></HeaderStyle>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="AMOUNT">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtAmount" ReadOnly="True" runat="server" Width="50" CssClass="textbox"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="5%" HorizontalAlign="Center"></HeaderStyle>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="SHIPMENT">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtStyleShipmentDate" runat="server" CssClass="textbox" Width="70px"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" PopupButtonID="imgEstimatedDater"
                                            TargetControlID="txtStyleShipmentDate" Format="dd/MM/yyyy" EnableViewState="true"
                                            PopupPosition="Bottomright">
                                        </cc1:CalendarExtender>
                                        <asp:ImageButton ID="imgEstimatedDater" runat="Server" ImageUrl="~/Images/calendar.jpg"
                                            AlternateText="Click here to display calendar"></asp:ImageButton>
                                        <cc1:MaskedEditExtender ID="reqDateMask" runat="server" TargetControlID="txtStyleShipmentDate"
                                            AutoComplete="False" UserDateFormat="DayMonthYear" Enabled="True" CultureTimePlaceholder=":"
                                            CultureThousandsPlaceholder="," CultureDecimalPlaceholder="." CultureDatePlaceholder="/"
                                            CultureDateFormat="YMD" CultureCurrencySymbolPlaceholder="" CultureAMPMPlaceholder="AM;PM"
                                            MaskType="Date" Century="2000" Mask="99/99/9999">
                                        </cc1:MaskedEditExtender>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" HorizontalAlign="Center"></HeaderStyle>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Remove">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="lnkRemove" ToolTip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png"
                                            CommandName="Remove" runat="server"></asp:ImageButton>
                                    </ItemTemplate>
                                    <HeaderStyle Width="1%" HorizontalAlign="Center"></HeaderStyle>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Move" Visible="false">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkMove" OnCheckedChanged="UpdateStatus" AutoPostBack="true" runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="2%" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateColumn>
                            </Columns>
                        </Smart:SmartDataGrid>
                    </div>
                </td>
            </tr>
            <tr style="height: 45px;">
                <td align="left">
                    <asp:Button ID="vtnSameStyle" CssClass="btn btn-outline btn-success" runat="server"
                        Width="140" Text="Add Same Style" Style="float: left;" />
                    <asp:Button ID="btnAddMore" CssClass="btn btn-outline btn-success" runat="server"
                        Width="160" Text="Add Different Style" Style="float: left;" />
                    <asp:Button ID="btnAddDetail" CssClass="btn btn-outline btn-success" runat="server"
                        Text="Add Items" />
                    <div class="txt_newwww" style="width: 80px; margin-left: 127px;">
                        Total Qty:
                    </div>
                    <div class="text_box">
                        <asp:TextBox ID="TxtTotalQty" ReadOnly="True" CssClass="textbox" runat="server" Width="60"
                            Style="margin-left: 7px; margin-top: 1px;"></asp:TextBox>
                    </div>
                    <div class="txt_newwww" style="width: 90px; margin-left: 50px;">
                        Total Value:
                    </div>
                    <div class="text_box">
                        <asp:TextBox ID="txtTotalAmount" ReadOnly="True" CssClass="textbox" runat="server"
                            Width="60" Style="margin-left: 5px; margin-top: 1px;"></asp:TextBox>
                    </div>
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td align="right">
                </td>
            </tr>
        </table>
    </asp:Panel>
    <table width="100%">
        <tr style="height: 30px;">
            <td align="center">
                <asp:Button ID="btnCancel" CssClass="btn btn-outline btn-danger" runat="server" Text="Cancel"
                    Width="120px" />
                <asp:Button ID="btnSave" ToolTip="Click here To Save data." CssClass="btn btn-outline btn-success"
                    runat="server" Text="Save" Width="120px" />
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <asp:TextBox ID="txtShipmentDatee" runat="server" Width="150px" CssClass="textbox"
                    Style="margin-right: -164px; margin-left: 12px; height: 22px;" Visible="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblShipmentStatus" runat="server" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lblUserId" runat="server" Visible="false" Text="0"></asp:Label>
                <asp:Label ID="lblRecvDate" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lblShipmentDate" runat="server" Visible="false"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
