<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeBehind="StyleDatabase.aspx.vb" Inherits="Integra.StyleDatabase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server" ShowChooser="false">
    </telerik:RadSkinManager>
    <div>
        <h2>
            Please fill the required fields to Create your New Style
        </h2>
        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" EnableAJAX="False" HorizontalAlign="NotSet">
            <telerik:RadPanelBar runat="server" ID="RadPanelBar1" ExpandMode="SingleExpandedItem"
                Width="100%" Skin="WebBlue">
                <Items>
                    <telerik:RadPanelItem Expanded="True" Text="Style Information" runat="server" Selected="true">
                        <Items>
                            <telerik:RadPanelItem Value="StyleInformation" runat="server">
                                <ItemTemplate>
                                    <div>
                                        <table cellspacing="2" style="width: 550px; height: 120px">
                                            <caption>
                                                <hr class="lineSeparator" style="margin: 12px 0 12px 0" />
                                                <tr>
                                                    <td>
                                                        Style No:
                                                    </td>
                                                    <td>
                                                        <telerik:RadTextBox ID="txtStyleNo" runat="server" Skin="WebBlue" Width="150px">
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
                                                            Width="150px">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Style Description:
                                                    </td>
                                                    <td colspan="3">
                                                        <telerik:RadTextBox ID="txtStyleName" runat="server" Skin="WebBlue" Width="426px">
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
                                                                <asp:DropDownList ID="cmbProductPortfolio" OnSelectedIndexChanged="cmbProductPortfolio_SelectedIndexChanged" runat="server" AutoPostBack="True" Width="168">
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
                                                                <asp:DropDownList ID="cmbProductCategroy" runat="server" AutoPostBack="True" Width="130">
                                                                </asp:DropDownList>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                    <td>
                                                        Product Group
                                                    </td>
                                                    <td>
                                                        <%--  <telerik:RadTextBox ID="txtMaterialComp" runat="server" Skin="WebBlue" Width="150px">--%>
                                                        <asp:UpdatePanel ID="UpdatePanel5" UpdateMode="Conditional" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="cmbProductGroup" runat="server" Width="140" AutoPostBack="True">
                                                                </asp:DropDownList>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Blend
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtBlend" runat="server" Width="168">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        GSM
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtGSM" runat="server" Width="130">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        Process Type
                                                    </td>
                                                    <td>
                                                        <asp:UpdatePanel ID="UpdatePanel6" UpdateMode="Conditional" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="cmbProcessType" runat="server" Width="140" AutoPostBack="True">
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
                                                                <asp:DropDownList ID="cmbComposition" runat="server" AutoPostBack="True" Width="140">
                                                                    <asp:ListItem Value="0" Text="CMIA" />
                                                                    <asp:ListItem Value="1" Text="Oragnic" />
                                                                    <asp:ListItem Value="2" Text="100 % Cotton" />
                                                                    <asp:ListItem Value="3" Text="Cotton Polyester" />
                                                                    <asp:ListItem Value="4" Text="Polystic Cotton" />
                                                                    <asp:ListItem Value="5" Text="Tensil" />
                                                                    <asp:ListItem Value="6" Text="Bambu" />
                                                                    <asp:ListItem Value="7" Text="Micro Fibric" />
                                                                    <asp:ListItem Value="8" Text="Viscos-Cotton" />
                                                                    <asp:ListItem Value="9" Text="Viscos-Polyester" />
                                                                    <asp:ListItem Value="10" Text="Viscos-Elasthane" />
                                                                    <asp:ListItem Value="11" Text="100 % Polyester" />
                                                                    <asp:ListItem Value="12" Text="Leather-Cow/Buffalo" />
                                                                    <asp:ListItem Value="13" Text="Leather-Sheep" />
                                                                    <asp:ListItem Value="14" Text="Others" />
                                                                </asp:DropDownList>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <caption>
                                                    <hr class="lineSeparator" style="margin: 12px 0 12px 0" />
                                                    <tr>
                                                        <td align="right" colspan="4">
                                                            <telerik:RadButton ID="btnSave" runat="server" OnClick="btnSave_Click" Skin="WebBlue"
                                                                Text="Save" Width="100px">
                                                            </telerik:RadButton>
                                                            <telerik:RadButton ID="btnCancelStyle" runat="server" OnClick="btnCancelStyle_Click"
                                                                Skin="WebBlue" Text="Cancel" Width="100px" />
                                                        </td>
                                                    </tr>
                                                </caption>
                                                </tr>
                                            </caption>
                                        </table>
                                    </div>
                                </ItemTemplate>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelItem>
                    <telerik:RadPanelItem Enabled="false" Text="Article Information" runat="server">
                        <Items>
                            <telerik:RadPanelItem Value="ArticleInformation" runat="server">
                                <ItemTemplate>
                                    <div>
                                        <table cellspacing="4" style="width: 550px; height: 150px">
                                            <tr>
                                                <td>
                                                    Article:
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="txtArticle" Width="150px" runat="server" Skin="WebBlue" />
                                                </td>
                                                <td>
                                                    Article Description:
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="txtArticleDescription" Width="150px" runat="server" Skin="WebBlue">
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Colorway:
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="txtColorway" runat="server" Width="150px" Skin="WebBlue" />
                                                </td>
                                                <td>
                                                    Size:
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="txtSizeRange" runat="server" Width="150px" Skin="WebBlue" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Price:
                                                </td>
                                                <td>
                                                    <telerik:RadTextBox ID="txtPrice" runat="server" Width="150px" Skin="WebBlue" />
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
                                                                <telerik:GridBoundColumn HeaderText="Article" DataField="Article">
                                                                    <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                                                    <ColumnValidationSettings EnableRequiredFieldValidation="true">
                                                                        <RequiredFieldValidator ForeColor="Red" ErrorMessage="This field is required"></RequiredFieldValidator>
                                                                    </ColumnValidationSettings>
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn HeaderText="Article Description" DataField="ArticleDescription">
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
                                                                <telerik:GridClientDeleteColumn ConfirmTextFields="Article" ConfirmTextFormatString="Are You Sure You want to Delete Details for Article {0}?"
                                                                    HeaderStyle-Width="35px" ButtonType="ImageButton">
                                                                </telerik:GridClientDeleteColumn>
                                                            </Columns>
                                                        </MasterTableView>
                                                    </telerik:RadGrid>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" align="right">
                                                    <hr class="lineSeparator" style="margin: 12px 0 15px 0" />
                                                    <telerik:RadButton ID="btnSaveArticle" runat="server" Skin="WebBlue" Text="Save"
                                                        Width="100px" OnClick="btnSaveArticle_Click">
                                                    </telerik:RadButton>
                                                    <telerik:RadButton ID="btnCancelArticle" runat="server" Skin="WebBlue" Text="Cancel"
                                                        Width="100px" OnClick="btnCancelArticle_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </ItemTemplate>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelItem>
                </Items>
                <CollapseAnimation Duration="0" Type="None" />
                <ExpandAnimation Duration="0" Type="None" />
                <ExpandAnimation Duration="0" Type="None" />
                <CollapseAnimation Duration="0" Type="None" />
            </telerik:RadPanelBar>
        </telerik:RadAjaxPanel>
    </div>
</asp:Content>
