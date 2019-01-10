<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="StyleDatabaseEntry1.aspx.vb" Inherits="Integra.StyleDatabaseEntry1" %>

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
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Style Information
            </th>
        </tr>
        <tr>
            <td>
                Style No:
            </td>
            <td>
                <telerik:RadTextBox ID="txtStyleNo" runat="server" Skin="WebBlue" Width="150px" 
                    ToolTip="Input style number as provided by the customer. Check Size Range Drop Down, if not found first put size range before ">
                </telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtStyleNo"
                    Display="Dynamic" ErrorMessage="*" Font-Bold="True" Font-Size="Small" ForeColor="Red"
                    SetFocusOnError="True" ToolTip="Style No can't be empty"></asp:RequiredFieldValidator>
            </td>
            <td>
                Customer Name:
            </td>
            <td>
                <telerik:RadComboBox ID="cmbBuyer" runat="server" Skin="WebBlue" AutoPostBack="true"
                    Width="150px" ToolTip="Select customer from dropdown list">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td>
                Style Description:
            </td>
            <td colspan="3">
                <telerik:RadTextBox ID="txtStyleName" runat="server" Skin="WebBlue" 
                    Width="426px" ToolTip="In Capital letter write style description ">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td>
                Product Portfolio:
            </td>
            <td>
                <%--<telerik:RadComboBox ID="cmbPOType" Runat="server" Skin="WebBlue" Width="150px">--%>
                <asp:UpdatePanel ID="updProductPortfolio" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbProductPortfolio" OnSelectedIndexChanged="cmbProductPortfolio_SelectedIndexChanged"
                            runat="server" AutoPostBack="True" Width="168" 
                            ToolTip="Select Product Portfolio">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                Product Category
            </td>
            <td>
                <%--  <telerik:RadTextBox ID="txtMaterialComp" runat="server" Skin="WebBlue" Width="150px">--%>
                <asp:UpdatePanel ID="updProductCategroy" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbProductCategroy" runat="server" AutoPostBack="True" 
                            Width="130" ToolTip="Select Product Category">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                Fabric Group
            </td>
            <td>
                <%--  <telerik:RadTextBox ID="txtMaterialComp" runat="server" Skin="WebBlue" Width="150px">--%>
                <asp:UpdatePanel ID="UpdatePanel5" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbProductGroup" runat="server" Width="140" 
                            AutoPostBack="True" ToolTip="Select Fabric Group ">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>              
            </td>
            <td>
                <asp:TextBox ID="txtBlend" runat="server" Width="168" Visible ="false" >
                </asp:TextBox>
            </td>
            <td>
                Weight
            </td>
            <td>
                <asp:TextBox ID="txtGSM" runat="server" onkeypress="return isNumericKeyy(event);"
                    Width="40" ToolTip="Input weight in numbers along with unit in caps lock"></asp:TextBox>
                Unit
                <asp:TextBox ID="txtWeightUnit" runat="server" Width="40">
                </asp:TextBox>
            </td>
            <td>
                Process Type
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel6" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbProcessType" runat="server" Width="140" 
                            AutoPostBack="True" ToolTip="Select Process type">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                Composition
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbComposition" runat="server" AutoPostBack="True" 
                            Width="140" ToolTip="Select Composition">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                Source of Original Sample
            </td>
            <td>
                <%--  <asp:TextBox ID="txtOriginalSample" CssClass="textbox" runat="server"></asp:TextBox>--%>
                <asp:UpdatePanel ID="UpdatePanel3" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbOriginalSample" runat="server" AutoPostBack="True" 
                            Width="140" ToolTip="Select source of original sample">
                            <asp:ListItem Value="0" Text="Technical sheet" />
                            <asp:ListItem Value="1" Text="Buyer sample" />
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                Product Consumer
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel12" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbProductConsumer" runat="server" AutoPostBack="True" 
                            Width="100" ToolTip="Select product consumer">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                Season
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel9" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbSeason" runat="server" AutoPostBack="True" Width="140" 
                            ToolTip="Select season">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <%--    <asp:TextBox ID="txtSeason" CssClass="textbox" runat="server"></asp:TextBox>--%>
            </td>
            <td>
                <%-- Buying Dept--%>
                Name of Brand
            </td>
            <td>
                <asp:TextBox ID="txtNameOfBrand" CssClass="textbox" runat="server" 
                    ToolTip="Input Brand name in caps lock"></asp:TextBox>
                <asp:DropDownList ID="cmbBuyingDept" Visible="false" AutoPostBack="true" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Colour Information
            </th>
        </tr>
        <tr>
            <td>
                Color Ref No.:
            </td>
            <td>
                <telerik:RadTextBox ID="txtArticle" Width="150px" runat="server" Skin="WebBlue" 
                    ToolTip="Input color reference number" />
            </td>
            <td>
                Fabric Construction:
            </td>
            <td>
                <telerik:RadTextBox ID="txtFabricConst" Width="150px" runat="server" 
                    Skin="WebBlue"  ToolTip="Input fabric construction in caps lock" />
            </td>
        </tr>
        <tr>
            <td>
                HS code:
            </td>
            <td>
                <telerik:RadTextBox ID="txtArticleDescription" Width="150px" runat="server" 
                    Skin="WebBlue" ToolTip="Input HS Code alpha numeric allowed">
                </telerik:RadTextBox>
            </td>
            <td>
                Colorway:
            </td>
            <td>
                <telerik:RadTextBox ID="txtColorway" runat="server" Width="150px" 
                    Skin="WebBlue" ToolTip="input color way in caps lock" />
            </td>
        </tr>
        <tr>
            <td>
                <%--  Size:--%>
                Size Range:
            </td>
            <td>
                <telerik:RadTextBox ID="txtSizeRange" Visible="false" runat="server" Width="150px"
                    Skin="WebBlue" 
                    ToolTip="input size range (help: if not available you can take any default and later you can change it) " />
                <asp:DropDownList ID="cmbSizeRange" runat="server" 
                    ToolTip="input size range (help: if not available you can take any default and later you can change it) ">
                </asp:DropDownList>
            </td>
            <td>
                Price:
            </td>
            <td>
                <telerik:RadTextBox ID="txtPrice" Width="50" onkeypress="return isNumericKeyy(event);"
                    runat="server" Skin="WebBlue" ToolTip="input price in numeric " />
                &nbsp; Currency:&nbsp;&nbsp;
                <asp:DropDownList ID="cmbPriceUnit" runat="server" ToolTip="select currency">
                    <asp:ListItem Value="0" Text="Dollar"></asp:ListItem>
                    <asp:ListItem Value="1" Text="Euro"></asp:ListItem>
                    <asp:ListItem Value="2" Text="Pounds"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td align="right" colspan="2">
                <telerik:RadButton ID="btnAddMore" runat="server" Text="Add More" Skin="WebBlue"
                    OnClick="btnAddMore_Click">
                </telerik:RadButton>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <telerik:RadGrid ID="dgArticle" OnDeleteCommand="dgArticle_DeleteCommand" runat="server"
                    AutoGenerateColumns="false" Skin="WebBlue" CellSpacing="0">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn HeaderText="StyleDetailID" Display="false" DataField="StyleDetailID">
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="StyleID" Display="false" DataField="StyleID">
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Color Ref No." DataField="Article">
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                <ColumnValidationSettings EnableRequiredFieldValidation="true">
                                    <RequiredFieldValidator ForeColor="Red" ErrorMessage="This field is required"></RequiredFieldValidator>
                                </ColumnValidationSettings>
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Fabric Const." DataField="FabricConst">
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="HS code" DataField="ArticleDescription">
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Colorway" DataField="Colorway">
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Size" DataField="SizeRange">
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Price" DataField="Price">
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Currency" DataField="PriceUnit">
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridClientDeleteColumn ConfirmTextFields="Article" ConfirmTextFormatString="Are You Sure You want to Delete Details for Article {0}?"
                                HeaderStyle-Width="5%" ButtonType="ImageButton">
                            </telerik:GridClientDeleteColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Fabric Detail
            </th>
        </tr>
        <tr>
            <td>
                Fabric
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtFabric" CssClass="textbox" runat="server" 
                            ToolTip="input fabric. By default it loaded product portfolio you choose above. You can change as per your need "></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                Fabric Type:
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtFabricType" CssClass="textbox" runat="server" 
                            ToolTip="input fabric type. By default it loaded product group you choose above. You can change as per your need"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
               
            </td>
            <td>
                <asp:TextBox ID="txtFabricConstruction" CssClass="textbox" runat="server" Visible ="false" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Fabric Weight:
            </td>
            <td>
                <asp:TextBox ID="txtFabricWeight" onkeypress="return isNumericKeyy(event);" Width="50"
                    CssClass="textbox" runat="server" 
                    ToolTip="Input fabric weight. By default it loaded weight above you given with unit "></asp:TextBox>
                &nbsp; Unit&nbsp;&nbsp;
                <asp:TextBox ID="txtFabricWeightUnit" Width="80" CssClass="textbox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Garment Weight:
            </td>
            <td>
                <asp:TextBox ID="txtGarmentWeight" CssClass="textbox" onkeypress="return isNumericKeyy(event);"
                    Width="50" runat="server" ToolTip="input garments weight "></asp:TextBox>
                &nbsp; Unit&nbsp;&nbsp;
                <asp:TextBox ID="txtGarmentWeightUnit" Width="80" CssClass="textbox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Pc. Weight:
            </td>
            <td>
                <asp:TextBox ID="txtPcWeight" CssClass="textbox" onkeypress="return isNumericKeyy(event);"
                    Width="50" runat="server" ToolTip="input pc weight"></asp:TextBox>
                &nbsp; Unit&nbsp;&nbsp;
                <asp:TextBox ID="txtPcWeightUnit" Width="80" CssClass="textbox" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Accessories Detail
            </th>
        </tr>
        <tr>
            <td>
                Acces.
            </td>
            <td>
                <asp:TextBox ID="txtAcces" CssClass="textbox" runat="server" 
                    ToolTip="input accessories name"></asp:TextBox>
            </td>
            <td>
                Acces. Type
            </td>
            <td>
                <asp:TextBox ID="txtAccesType" CssClass="textbox" runat="server" 
                    ToolTip="input accessories type"></asp:TextBox>
            </td>
            <td>
                Source:
            </td>
            <td>
                <asp:DropDownList ID="cmbSource" runat="server" 
                    ToolTip="select source of accessories">
                    <asp:ListItem Value="0" Text="Local"></asp:ListItem>
                    <asp:ListItem Value="1" Text="Import"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btnAddDetail" CssClass="button" runat="server" Text="Add Detail" />
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td>
                <telerik:RadGrid ID="dgAcces" OnDeleteCommand="dgAcces_DeleteCommand" runat="server"
                    AutoGenerateColumns="false" Skin="WebBlue" CellSpacing="0">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn HeaderText="SAID" Display="false" DataField="SAID">
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="StyleID" Display="false" DataField="StyleID">
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Accessories" DataField="Accessories">
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="AccesType" DataField="AccesType">
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Source" DataField="Source">
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridClientDeleteColumn ConfirmTextFields="Access" ConfirmTextFormatString="Are You Sure You want to Delete "
                                HeaderStyle-Width="5%" ButtonType="ImageButton">
                            </telerik:GridClientDeleteColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Packing Detail
            </th>
        </tr>
        <tr>
            <td>
                Carton Type:
            </td>
            <td>
                <asp:TextBox ID="txtCartonType" CssClass="textbox" runat="server" 
                    ToolTip="input carton type "></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Carton Size :
            </td>
            <td align="right">
                L
            </td>
            <td>
                <asp:TextBox ID="txtCartonSizeL" Width="50" onkeypress="return isNumericKeyy(event);"
                    CssClass="textbox" runat="server" ToolTip="input carton size in numbers"></asp:TextBox>
            </td>
            <td>
                W
            </td>
            <td>
                <asp:TextBox ID="txtCartonSizeW" onkeypress="return isNumericKeyy(event);" Width="50"
                    CssClass="textbox" runat="server" ToolTip="input carton size in numbers"></asp:TextBox>
            </td>
            <td>
                H
            </td>
            <td>
                <asp:TextBox ID="txtCartonSizeH" onkeypress="return isNumericKeyy(event);" Width="50"
                    CssClass="textbox" runat="server" ToolTip="input carton size in numbers"></asp:TextBox>
            </td>
            <td>
                Unit
                <asp:TextBox ID="txtCartonSizeUnit" Width="80" CssClass="textbox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Qty/Carton
            </td>
            <td>
                <asp:TextBox ID="txtQtyCarton" Width="50" onkeypress="return isNumericKeyy(event);"
                    CssClass="textbox" runat="server" ToolTip="input quantity per carton"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Qty/Pack
            </td>
            <td>
                <asp:TextBox ID="txtQtyPack" Width="50" onkeypress="return isNumericKeyy(event);"
                    CssClass="textbox" runat="server" ToolTip="input quantity per carton"></asp:TextBox>
                <asp:UpdatePanel ID="UpdatePanel7" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbQtyPack" runat="server" AutoPostBack="True" Width="50" 
                            ToolTip="input quanity per pack and select dropdown">
                            <asp:ListItem Value="0" Text="pcs" />
                            <asp:ListItem Value="1" Text="pks" />
                            <asp:ListItem Value="2" Text="sets" />
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                Poly Bag Size:
            </td>
            <td align="right">
                L
            </td>
            <td>
                <asp:TextBox ID="txtPolyBagSizeL" Width="50" onkeypress="return isNumericKeyy(event);"
                    CssClass="textbox" runat="server" 
                    ToolTip="input numbers to define poly bag size and dimension"></asp:TextBox>
            </td>
            <td>
                W
            </td>
            <td>
                <asp:TextBox ID="txtPolyBagSizeW" Width="50" onkeypress="return isNumericKeyy(event);"
                    runat="server" 
                    ToolTip="input numbers to define poly bag size and dimension"></asp:TextBox>
            </td>
            <td>
                Flap
            </td>
            <td>
                <asp:TextBox ID="txtPolyBagSizeFlap" onkeypress="return isNumericKeyy(event);" Width="50"
                    CssClass="textbox" runat="server" 
                    ToolTip="input numbers to define poly bag size and dimension"></asp:TextBox>
            </td>
            <td>
                Unit
                <asp:TextBox ID="txtPolyBagSizeUnit" Width="80" CssClass="textbox" runat="server"></asp:TextBox>
            </td>
            <tr>
                <td>
                    Inlay Card Size/Folding Board:
                </td>
                <td>
                    <asp:TextBox ID="txtInlayCardSize" Width="50" CssClass="textbox" runat="server" 
                        ToolTip="input YES in capslock if inlay card required else NO in capslock"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Packed Pc. Sz
                </td>
                <td align="right">
                    L
                </td>
                <td>
                    <asp:TextBox ID="txtPackedPcSzL" Width="50" onkeypress="return isNumericKeyy(event);"
                        CssClass="textbox" runat="server" 
                        ToolTip="input packed piece of garments dimension in numbers"></asp:TextBox>
                </td>
                <td>
                    W
                </td>
                <td>
                    <asp:TextBox ID="txtPackedPcSzW" Width="50" onkeypress="return isNumericKeyy(event);"
                        CssClass="textbox" runat="server" 
                        ToolTip="input packed piece of garments dimension in numbers"></asp:TextBox>
                </td>
                <td>
                    H
                </td>
                <td>
                    <asp:TextBox ID="txtPackedPcSzH" onkeypress="return isNumericKeyy(event);" Width="50"
                        CssClass="textbox" runat="server" 
                        ToolTip="input packed piece of garments dimension in numbers"></asp:TextBox>
                </td>
                <tr>
                    <td>
                        Gross Weight of Carton:
                    </td>
                    <td>
                        <asp:TextBox ID="txtGrossWeightofCarton" onkeypress="return isNumericKeyy(event);"
                            Width="50" CssClass="textbox" runat="server" 
                            ToolTip="input gross weight of carton"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Poly Bag Sticker Size
                    </td>
                    <td align="right">
                        L
                    </td>
                    <td>
                        <asp:TextBox ID="txtPolyBagStickerSizeL" onkeypress="return isNumericKeyy(event);"
                            Width="50" CssClass="textbox" runat="server" 
                            ToolTip="input size of stickers"></asp:TextBox>
                    </td>
                    <td>
                        W
                    </td>
                    <td>
                        <asp:TextBox ID="txtPolyBagStickerSizeW" onkeypress="return isNumericKeyy(event);"
                            Width="50" CssClass="textbox" runat="server" 
                            ToolTip="input size of stickers"></asp:TextBox>
                    </td>
                </tr>
    </table>
    <table width="100%">
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Testing Detail
            </th>
        </tr>
        <tr>
            <td>
                Acceptable Dimensional Stablity
            </td>
            <td valign="top">
                L: +/-&nbsp;&nbsp;
                <asp:TextBox ID="txtAcceptableDimensionalL" Width="50" CssClass="textbox" 
                    runat="server" ToolTip="input stability test "></asp:TextBox>
                &nbsp;&nbsp;&nbsp; W:+/-&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtAcceptableDimensionalW" Width="50" CssClass="textbox" 
                    runat="server" ToolTip="input stability test "></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Rubbing Fastness:
            </td>
            <td valign="top">
                Wet &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtRubbingFastnessWet" onkeypress="return isNumericKeyy(event);"
                    Width="50" CssClass="textbox" runat="server" 
                    ToolTip="input rubbing fastness test "></asp:TextBox>
                &nbsp;&nbsp;&nbsp; Dry &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtRubbingFastnessDry" onkeypress="return isNumericKeyy(event);"
                    Width="50" CssClass="textbox" runat="server" 
                    ToolTip="input rubbing fastness test "></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Type of Dyes:
            </td>
            <td>
                <asp:TextBox ID="txtTypeofDyes" CssClass="textbox" runat="server" 
                    ToolTip="input type of dyes"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Type of Print
            </td>
            <td>
                <asp:TextBox ID="txtTypeofPrint" CssClass="textbox" runat="server" 
                    ToolTip="input print type"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Type of Washing
            </td>
            <td>
                <asp:TextBox ID="txtTypeofWashing" CssClass="textbox" runat="server" 
                    ToolTip="input washing parameter"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Fabric Finish:
            </td>
            <td>
                <asp:TextBox ID="txtFabricFinish" CssClass="textbox" runat="server" 
                    ToolTip="input fabric finished as defined by buyer"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td>
                File Type
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel10" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbFileType" runat="server" AutoPostBack="True" 
                            Width="120" ToolTip="select file type you wish to upload ">
                            <asp:ListItem Value="0" Text="Picture" />
                            <asp:ListItem Value="1" Text="Size Chart" />
                            <asp:ListItem Value="2" Text="Care Label" />
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                Picture:
            </td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" 
                    ToolTip="select jpg file to attach and press upload" />
            </td>
            <td>
                <asp:Button ID="btnUpload1" CssClass="button" runat="server" Text="Upload" />
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td align="center">
                <asp:Label ID="lblErrorMsg" runat="server" CssClass="ErrorMsg"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>
                        <Smart:SmartDataGrid ID="dgFileInfo" runat="server" Width="100%" AllowPaging="True"
                            AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                            PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="15" RecordCount="0"
                            ShowFooter="True" SortedAscending="yes" ForeColor="White">
                            <Columns>
                                <asp:BoundColumn HeaderText="TableID" DataField="TableID" Visible="False">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="StyleID" DataField="StyleID" Visible="False">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Creation Date" DataField="CreationDate">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Type" DataField="FileType">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="File Name">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkFIle" CommandName="DownloadFile" Text='<% #Eval("FileName") %>'
                                            runat="server"> </asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Remove">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="lnkRemove" ToolTip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png"
                                            CommandName="Remove" runat="server"></asp:ImageButton>
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
