<%@ Page Title="Item Entry" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="ItemEntry.aspx.vb" Inherits="Integra.ItemEntry" %>

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

        function NotZero(source) {
            var txtBox = document.getElementById(source);
            var txt = txtBox.value;
            if (txt == 0) {
                txtBox.value = 1;
            }
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
    </script>
    <table>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td>
                            Item Class
                        </td>
                        <td>
                            <asp:DropDownList ID="cmbItemClassName" Width="310" runat="server" AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr runat="server" id="trdal" visible="false">
                        <td>
                            DAL No.
                        </td>
                        <td>
                            <asp:TextBox ID="txtDalNoO" runat="server" autocomplete="off" AutoPostBack="true"
                                Style="margin-left: 0px; width: 150px;"></asp:TextBox>
                            <cc1:AutoCompleteExtender ID="autoComplete1" runat="server" CompletionInterval="10"
                                CompletionSetCount="12" ContextKey="SearchDalNo" EnableCaching="true" MinimumPrefixLength="1"
                                ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtDalNoO" />
                            <asp:Label ID="lblFabricMstId" runat="server" Text="0" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr id="TrDalRefNo" runat="server" visible="false">
                        <td>
                            Dal Ref No
                        </td>
                        <td>
                            <asp:TextBox ID="txtDalRefNo" runat="server" autocomplete="off" AutoPostBack="true"
                                Style="margin-left: 0px; width: 150px; text-transform: uppercase;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Item Category
                        </td>
                        <td>
                            <asp:DropDownList ID="cmbItemCategory" Width="310" runat="server" AutoPostBack="true"
                                TabIndex="1">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Item Prefix
                        </td>
                        <td>
                            <asp:TextBox ID="txtItemPrefix" ReadOnly="true" CssClass="textbox" runat="server"
                                TabIndex="2"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Item Name
                        </td>
                        <td>
                            <asp:TextBox ID="txtItemName" CssClass="textbox" runat="server" TabIndex="3" Style="text-transform: uppercase;
                                width: 304px;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Item Status
                        </td>
                        <td>
                            <asp:DropDownList ID="cmbItemStatus" Width="310" runat="server" AutoPostBack="false">
                                <asp:ListItem Value="1">Sample</asp:ListItem>
                                <asp:ListItem Value="2">Fresh</asp:ListItem>
                                <asp:ListItem Value="3">Store</asp:ListItem>
                                <asp:ListItem Value="4">N/A</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Item Code
                        </td>
                        <td>
                            <asp:TextBox ID="txtItemCode" ReadOnly="true" CssClass="textbox" runat="server" TabIndex="4"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtItemCodePart" Visible="false" ReadOnly="true" CssClass="textbox"
                                runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Measuring Unit
                        </td>
                        <td>
                            <asp:UpdatePanel ID="upcmbMeasuringUnit" UpdateMode="Conditional" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="cmbMeasuringUnit" Width="137" runat="server" AutoPostBack="true"
                                        TabIndex="5">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Unit Rate
                        </td>
                        <td>
                            <asp:TextBox ID="txtUnitRate" onkeypress="return isNumericKeyy(event);" onchange="mathRoundForTaxes(this.id);"
                                CssClass="textbox" runat="server" TabIndex="6"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Opening Quantity
                        </td>
                        <td>
                            <asp:UpdatePanel ID="uptxtOpeningQuantity" UpdateMode="Conditional" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtOpeningQuantity" AutoPostBack="true" onkeypress="return isNumericKey(event);"
                                        CssClass="textbox" runat="server" TabIndex="7"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Opening Value
                        </td>
                        <td>
                            <asp:UpdatePanel ID="uptxtOpeningValue" UpdateMode="Conditional" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtOpeningValue" ReadOnly="true" onchange="mathRoundForTaxes(this.id);"
                                        onkeypress="return isNumericKeyy(event);" CssClass="textbox" runat="server" TabIndex="8"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdatePanel ID="upcmbCurrency" UpdateMode="Conditional" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="cmbCurrency" Width="137" runat="server" AutoPostBack="true"
                                        TabIndex="9">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Reorder Quantity
                        </td>
                        <td>
                            <asp:TextBox ID="txtReorderQuantity" onkeypress="return isNumericKey(event);" CssClass="textbox"
                                runat="server" TabIndex="10"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Max. Issue Quantity
                        </td>
                        <td>
                            <asp:TextBox ID="txtMaxIssueQuantity" onkeypress="return isNumericKey(event);" CssClass="textbox"
                                runat="server" TabIndex="11"></asp:TextBox>
                        </td>
                    </tr>
                    <%--  <asp:Panel ID="pnlNew" runat="server" Enabled="false" Visible="false" >--%>
                    <tr>
                        <td>
                            <asp:Label ID="lblQ" runat="server" Text="Quality" Visible="false"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtQualityForChange" CssClass="textbox" runat="server" TabIndex="12"
                                Visible="false" Style="width: 305px; text-transform: uppercase;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblComp" runat="server" Text="Composition" Visible="false"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCompForChange" CssClass="textbox" runat="server" Visible="false"
                                TabIndex="13" Style="width: 305px; text-transform: uppercase;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblW" runat="server" Text="Wash/Dye" Visible="false"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtWashForChange" CssClass="textbox" runat="server" Visible="false"
                                TabIndex="14" Style="text-transform: uppercase;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblF" runat="server" Text="Finish" Visible="false"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFinishForChange" CssClass="textbox" runat="server" Visible="false"
                                TabIndex="15" Style="text-transform: uppercase;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelShade" runat="server" Text="Shade" Visible="false"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtShade" CssClass="textbox" runat="server" Visible="false" TabIndex="15"
                                Style="text-transform: uppercase;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelColor" runat="server" Text="Color" Visible="false"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtColor" CssClass="textbox" runat="server" Visible="false" TabIndex="15"
                                Style="text-transform: uppercase;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label13" runat="server" Text="Width" Visible="false"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtWidthForItem" CssClass="textbox" runat="server" Visible="false"
                                TabIndex="15" Style="text-transform: uppercase;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label14" runat="server" Text="GSM Before Wash" Visible="false"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtGSMBeforeWashForItem" CssClass="textbox" runat="server" Visible="false"
                                TabIndex="15" Style="text-transform: uppercase;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label15" runat="server" Text="GSM After Wash" Visible="false"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtGSMAfterWashForItem" CssClass="textbox" runat="server" Visible="false"
                                TabIndex="15" Style="text-transform: uppercase;"></asp:TextBox>
                        </td>
                    </tr>
                    <%--</asp:Panel>--%>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" TabIndex="12" />&nbsp;
                            <asp:Button ID="BtnCancel" runat="server" CssClass="button" Text="Cancel" TabIndex="13" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="LBLMasterID" Visible="false" Text="0"></asp:Label>
                        </td>
                    </tr>
                </table>
                <td width="40%">
                    <asp:Panel ID="pnldd" runat="server" Enabled="true" Visible="false">
                        <table width="100%" style="margin-top: 25px;">
                            <tr>
                            </tr>
                            <tr>
                                <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                                    font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                                    bgcolor="Silver">
                                    Fabric Information
                                </th>
                            </tr>
                            <tr>
                                <td style="width: 87px; height: 30px;">
                                    <asp:Label ID="Label2" runat="server" Text="Supplier Ref.No."></asp:Label>
                                </td>
                                <td style="height: 30px">
                                    <telerik:RadTextBox ID="txtSupplierRef" runat="server" Skin="WebBlue" Width="175px"
                                        ReadOnly="true">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 85px; height: 30px;" align="left">
                                    <asp:Label ID="Label3" runat="server" Text="Supplier Name"></asp:Label>
                                </td>
                                <td style="width: 165px; height: 30px;">
                                    <telerik:RadTextBox ID="txtSupplierName" runat="server" ReadOnly="true" Width="258px"
                                        Skin="WebBlue">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 87px; height: 30px;">
                                    <asp:Label ID="Label4" runat="server" Text="Quality"></asp:Label>
                                </td>
                                <td style="height: 30px">
                                    <telerik:RadTextBox ID="txtQuality" runat="server" Skin="WebBlue" Width="258px" ReadOnly="true">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 85px; height: 30px;" align="left">
                                    <asp:Label ID="Label5" runat="server" Text="Composition"></asp:Label>
                                </td>
                                <td style="width: 165px; height: 30px;">
                                    <telerik:RadTextBox ID="txtComposition" runat="server" Width="258px" Skin="WebBlue"
                                        ReadOnly="true">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 87px; height: 30px;">
                                    <asp:Label ID="Label7" runat="server" Text="Colour"></asp:Label>
                                </td>
                                <td style="height: 30px">
                                    <telerik:RadTextBox ID="txtColour" runat="server" Skin="WebBlue" Width="175px" ReadOnly="true">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 85px; height: 30px;" align="left">
                                    <asp:Label ID="Label8" runat="server" Text="Width"></asp:Label>
                                </td>
                                <td style="width: 165px; height: 30px;">
                                    <telerik:RadTextBox ID="txtWidth" runat="server" Width="175px" Skin="WebBlue" ReadOnly="true">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 87px; height: 30px;">
                                    <asp:Label ID="Label1" runat="server" Text="GSM Bef.Wash"></asp:Label>
                                </td>
                                <td style="height: 30px">
                                    <telerik:RadTextBox ID="txtGSMBefWash" runat="server" Skin="WebBlue" Width="175px"
                                        ReadOnly="true">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 87px; height: 30px;">
                                    <asp:Label ID="Label6" runat="server" Text="GSM After Wash"></asp:Label>
                                </td>
                                <td style="height: 30px">
                                    <telerik:RadTextBox ID="txtGSMAfterWash" runat="server" Skin="WebBlue" Width="175px"
                                        ReadOnly="true">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 87px; height: 30px;">
                                    <asp:Label ID="Label11" runat="server" Text="Shrinkage"></asp:Label>
                                </td>
                                <td style="height: 30px">
                                    <telerik:RadTextBox ID="txtShrink" runat="server" Skin="WebBlue" Width="175px" ReadOnly="true">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 87px; height: 30px;">
                                    <asp:Label ID="Label12" runat="server" Text="Mill Shrinkage"></asp:Label>
                                </td>
                                <td style="height: 30px">
                                    <telerik:RadTextBox ID="txtMillShrink" runat="server" Skin="WebBlue" Width="175px"
                                        ReadOnly="true">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 87px; height: 30px;">
                                    <asp:Label ID="Label9" runat="server" Text="Wash/Dye"></asp:Label>
                                </td>
                                <td style="height: 30px">
                                    <telerik:RadTextBox ID="txtDye" runat="server" Skin="WebBlue" Width="175px" ReadOnly="true">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 85px; height: 30px;" align="left">
                                    <asp:Label ID="Label10" runat="server" Text="Finish"></asp:Label>
                                </td>
                                <td style="width: 165px; height: 30px;">
                                    <telerik:RadTextBox ID="txtFinish" runat="server" Width="175px" Skin="WebBlue" ReadOnly="true">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                        </table>
                </td>
        </tr>
        </asp:Panel> </td> </tr>
    </table>
</asp:Content>
