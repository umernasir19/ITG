<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="StyleDatabaseEntry.aspx.vb" Inherits="Integra.StyleDatabaseEntry" %>

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
   
    </script>
    <table width="100%">
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Style Database
            </th>
        </tr>
    </table>
    <table width="50%">
        <tr style="height: 35px;">
            <td width="118">
                Created by
            </td>
            <td>
                <asp:TextBox ID="txtCreatedBy" CssClass="textbox" Width="123" ReadOnly="true" runat="server"></asp:TextBox>
            </td>
            <td>
                Created On
            </td>
            <td>
                <asp:TextBox ID="txtCreatedOn" Width="80" CssClass="textbox" ReadOnly="true" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Style Information
            </th>
        </tr>
        <tr>
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel8" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:RadioButtonList ID="rbnSelect" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                            OnSelectedIndexChanged="rbnSelect_SelectedIndexChanged">
                            <asp:ListItem Value="0">Show Enquiry Style</asp:ListItem>
                            <asp:ListItem Value="1" Selected="True">Show Normal Style</asp:ListItem>
                        </asp:RadioButtonList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                Style No:
            </td>
            <td>
                <asp:UpdatePanel ID="UpStyleNo" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtStyleNo" CssClass="textbox" Width="130" AutoPostBack="true" runat="server"></asp:TextBox>
                        <asp:DropDownList ID="cmbStyleNoo" Width="150" AutoPostBack="true" CssClass="dd"
                            runat="server">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                Special Line
            </td>
            <td>
                <asp:UpdatePanel ID="UpCoreLine" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtCoreLine" CssClass="textbox" Width="144" runat="server" Visible="false"></asp:TextBox>
                        <asp:DropDownList ID="cmbSpecialLine" Width="144px" CssClass="dd" runat="server">
                            <asp:ListItem Value="Y">Y</asp:ListItem>
                            <asp:ListItem>N</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                Customer
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
        </tr>
        <tr style="height: 35px;">
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
                Style Source
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbStyleSource" runat="server" AutoPostBack="true" CssClass="dd"
                            Width="150" ToolTip="Select source of original sample">
                            <asp:ListItem Value="0" Text="Technical sheet" />
                            <asp:ListItem Value="1" Text="Buyer sample" />
                            <asp:ListItem Value="2" Text="GIA Offer Sample" />
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr style="height: 35px;">
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
                <%-- <asp:TextBox ID="txtBuyerName" CssClass="textbox" runat="server"></asp:TextBox>--%>
                <asp:UpdatePanel ID="UpdatecmbBuyerName" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbBuyerName" Width="150" AutoPostBack="true" CssClass="dd"
                            runat="server">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
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
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
                <asp:UpdatePanel ID="UpFabFinish" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Product Information
            </th>
        </tr>
        <tr style="height: 35px;">
            <td>
                Product Portfolio
            </td>
            <td>
                <asp:UpdatePanel ID="UpcmbProductPortfolio" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList Width="140" ID="cmbProductPortfolio" AutoPostBack="true" CssClass="dd"
                            runat="server">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                Product Category
            </td>
            <td>
                <asp:UpdatePanel ID="UpcmbProductCategory" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbProductCategory" Width="140" AutoPostBack="true" CssClass="dd"
                            runat="server">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                Product Consumer Grp
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel12" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbProductConsumerGrp" Width="140" runat="server" AutoPostBack="true"
                            CssClass="dd" ToolTip="Select product consumer">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                Lining
            </td>
            <td>
                <asp:UpdatePanel ID="UpLining" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbLining" Width="144px" CssClass="dd" runat="server">
                            <asp:ListItem Value="Y">Y</asp:ListItem>
                            <asp:ListItem>N</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                <asp:UpdatePanel ID="Uplblpack" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblpack" runat="server" Text="Pack"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel6" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbPack" AutoPostBack="true" CssClass="dd" Width="100" runat="server">
                            <asp:ListItem Text="1 Pc Set" Value="0"></asp:ListItem>
                            <asp:ListItem Text="2 Pc Set" Value="1"></asp:ListItem>
                            <asp:ListItem Text="3 Pc Set" Value="2"></asp:ListItem>
                            <asp:ListItem Text="4 Pc Set" Value="3"></asp:ListItem>
                            <asp:ListItem Text="5 Pc Set" Value="4"></asp:ListItem>
                            <asp:ListItem Text="6 Pc Set" Value="5"></asp:ListItem>
                            <asp:ListItem Text="7 Pc Set" Value="6"></asp:ListItem>
                            <asp:ListItem Text="8 Pc Set" Value="7"></asp:ListItem>
                            <asp:ListItem Text="9 Pc Set" Value="8"></asp:ListItem>
                            <asp:ListItem Text="10 Pc Set" Value="9"></asp:ListItem>
                            <asp:ListItem Text="11 Pc Set" Value="10"></asp:ListItem>
                            <asp:ListItem Text="12 Pc Set" Value="11"></asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
            </td>
            <td>
                <asp:UpdatePanel ID="Upadd" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnAddProduct" CssClass="button" Width="100" runat="server" Text="Add Product" />
                        <asp:Button ID="btnAddMoreProduct" CssClass="button" Width="100" runat="server" Visible="false"
                            Text="Add Product" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <div style="vertical-align: top; overflow: auto; width: 920px; border-style: groove;">
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpUpbtnAutoComplete" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <Smart:SmartDataGrid ID="dgProductinfo" runat="server" Width="100%" AllowPaging="False"
                                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                                PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="15" RecordCount="0"
                                ShowFooter="True" SortedAscending="yes" ForeColor="White">
                                <Columns>
                                    <asp:BoundColumn HeaderText="SproductID" DataField="SproductID" Visible="false">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="ProductPortfolioID" DataField="ProductPortfolioID" Visible="false">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="ProductCategoriesID" DataField="ProductCategoriesID"
                                        Visible="false">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="ProductConsumerID" DataField="ProductConsumerID" Visible="false">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Product Con. Group" DataField="ProductConsumerGroup"
                                        Visible="false">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:TemplateColumn HeaderText="Pack" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtPack" Text='<% #Eval("Pack") %>' Width="50" ReadOnly="true" CssClass="textbox"
                                                runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Base Row">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRow" Text='<% #Eval("RowNo") %>' Width="50" ReadOnly="true" CssClass="textbox"
                                                runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Item">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtItem" Text='<% #Eval("Item") %>' Width="100px" CssClass="textbox"
                                                runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="HS Code">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtHSCode" CssClass="textbox" Width="60" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="F.Type">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:DropDownList ID="cmbFabricType" CssClass="dd" Width="80" runat="server">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText=" Fab. Finish">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:DropDownList ID="cmbFabFinish" Width="80" CssClass="dd" runat="server">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="F.Cons">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtFCons" CssClass="textbox" Width="80" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="F.Comp.">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:DropDownList ID="cmbFComp" Width="180px" runat="server">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="F.Wt.">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtFWt" onkeypress="return isNumericKeyy(event);" CssClass="textbox"
                                                Width="50" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Unit">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:DropDownList ID="cmbFWtUnit" Width="80" runat="server">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Garment Wt.">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtGarmentWt" onkeypress="return isNumericKeyy(event);" Width="50"
                                                CssClass="textbox" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Unit">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:DropDownList ID="cmbGarmentWtUnit" Width="80" CssClass="dd" runat="server">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Color" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtColor" CssClass="textbox" Width="60" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Lin.Type">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:DropDownList ID="cmbLiningType" CssClass="dd" Width="80" runat="server">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Lin.Cons">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtLiningCons" CssClass="textbox" Width="80" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Lin.Comp.">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:DropDownList ID="cmbLinigComp" Width="180px" runat="server">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Lining Wt.">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtLiningWt" onkeypress="return isNumericKeyy(event);" Width="50"
                                                CssClass="textbox" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateColumn>
                                    <asp:BoundColumn HeaderText="Lining" DataField="Lining" Visible="true">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:TemplateColumn HeaderText="Remarks">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRemarks" CssClass="textbox" Width="80" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Remove">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="lnkRemove" ToolTip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png"
                                                CommandName="RemoveProduct" runat="server"></asp:ImageButton>
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
                <td valign="top">
                    <asp:UpdatePanel ID="UpbtnAutoComplete" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnAutoComplete" CssClass="button" Width="100" runat="server" Text="Auto Comp." />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
    <table width="100%">
        <br />
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Colour Information
            </th>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel9" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr style="height: 35px;">
                    <td>
                        Color Ref. No.
                    </td>
                    <td>
                        <asp:TextBox ID="txtColorRefNo" CssClass="textbox" Width="100" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Color
                    </td>
                    <td>
                        <asp:TextBox ID="txtColorway" CssClass="textbox" Width="100" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Size Range
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpcmbSizeRange" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="cmbSizeRange" Width="120" AutoPostBack="true" CssClass="dd"
                                    runat="server">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr style="height: 35px;">
                    <td>
                        <asp:UpdatePanel ID="Uplblitem" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                                <asp:Label runat="server" ID="lblitem" Text="Base Item"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpcmbBaseItem" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="cmbBaseItem" Width="100" AutoPostBack="true" CssClass="dd"
                                    runat="server">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        Price
                    </td>
                    <td>
                        <asp:TextBox ID="txtPrice" onkeypress="return isNumericKeyy(event);" CssClass="textbox"
                            Width="100" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="cmbCurrency" Width="100" CssClass="dd" runat="server" ToolTip="select currency">
                            <asp:ListItem Value="0" Text="Dollar"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Euro"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Pounds"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="btnAddColor" CssClass="button" runat="server" Text="Add Color" />
                    </td>
                    <td align="right">
                        <div>
                            <asp:Button ID="btnHide" CssClass="button" runat="server" Visible="false" Text="Hide" />
                            <asp:Button ID="btnShow" CssClass="button" runat="server" Visible="false" Text="Show" />
                        </div>
                    </td>
                </tr>
            </table>
            <asp:Panel ID="PnlColor" runat="server" Visible="true">
                <table width="100%">
                    <tr>
                        <td>
                            <telerik:RadGrid ID="dgColor" runat="server" AutoGenerateColumns="false" Skin="WebBlue"
                                CellSpacing="0">
                                <MasterTableView>
                                    <Columns>
                                        <telerik:GridBoundColumn HeaderText="StyleDetailID" Display="false" DataField="StyleDetailID">
                                            <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderText="StyleID" Display="false" DataField="StyleID">
                                            <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderText="Item Row" DataField="BaseRow" UniqueName="BaseRow">
                                            <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderText="Color Ref No." DataField="ColorRefNo">
                                            <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderText="Color" DataField="Colorway">
                                            <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderText="SizeRange" DataField="SizeRange">
                                            <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderText="Size" DataField="Sizes">
                                            <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderText="Size" Display="false" DataField="SizeRange">
                                            <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderText="Price" DataField="Price">
                                            <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderText="Currency" DataField="PriceUnit">
                                            <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <table width="100%">
        <br />
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Accessories Detail
            </th>
        </tr>
    </table>
    <table width="100%">
        <tr style="height: 35px;">
            <td>
                Accessories
            </td>
            <td>
                <asp:UpdatePanel ID="UpcmbAccessories" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbAccessories" Width="140" AutoPostBack="true" CssClass="dd"
                            runat="server">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                Accessories Description
            </td>
            <td>
                <asp:UpdatePanel ID="UptxtAccessoriesDescription" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtAccessoriesDescription" Width="100" CssClass="textbox" runat="server"
                            ToolTip="input accessories type"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                Source:
            </td>
            <td>
                <asp:UpdatePanel ID="UpcmbSource" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbSource" Width="80" runat="server" CssClass="dd" ToolTip="select source of accessories">
                            <asp:ListItem Value="0" Text="Local"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Import"></asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdatePanel ID="upbtnAddAccessories" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnAddAccessories" CssClass="button" Width="130" runat="server" Text="Add Accessories" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td>
                <asp:UpdatePanel ID="Updgacss" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadGrid ID="dgAcces" runat="server" AutoGenerateColumns="false" Skin="WebBlue"
                            CellSpacing="0">
                            <MasterTableView>
                                <Columns>
                                    <telerik:GridBoundColumn HeaderText="SAID" Display="false" DataField="SAID">
                                        <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="StyleID" Display="false" DataField="StyleID">
                                        <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="AccessoriesID" Display="false" DataField="AccessoriesID">
                                        <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="AccessoriesName" DataField="AccessoriesName">
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="AccessoriesDescription" DataField="AccessoriesDescription">
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Source" DataField="Source">
                                        <HeaderStyle Width="10%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridButtonColumn UniqueName="DeleteColumn" Text="Delete" CommandName="Delete"
                                        ConfirmTextFormatString="Are You Sure You want to Delete Record" HeaderStyle-Width="5%"
                                        ButtonType="ImageButton">
                                    </telerik:GridButtonColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr style="height: 38px;">
            <td style="width: 90px;">
                Embell.
            </td>
            <td>
                <asp:UpdatePanel ID="UpcmbEmbell" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbEmbell" Width="140" AutoPostBack="true" CssClass="dd" runat="server">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
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
        </br>
    </table>
    <table width="100%">
        <tr style="height: 28px;">
            <td>
                Dimensional Stablity
            </td>
            <td valign="top">
                L: +/-&nbsp;&nbsp;
                <asp:TextBox ID="txtAcceptableDimensionalL" Width="50" CssClass="textbox" runat="server"
                    ToolTip="input stability test "></asp:TextBox>
                &nbsp;&nbsp;&nbsp; W:+/-&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtAcceptableDimensionalW" Width="50" CssClass="textbox" runat="server"
                    ToolTip="input stability test "></asp:TextBox>
            </td>
        </tr>
        <tr style="height: 28px;">
            <td>
                Rubbing Fastness:
            </td>
            <td valign="top">
                Wet &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtRubbingFastnessWet" Width="50" CssClass="textbox" runat="server"
                    ToolTip="input rubbing fastness test "></asp:TextBox>
                &nbsp;&nbsp;&nbsp; Dry &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtRubbingFastnessDry" Width="50" CssClass="textbox" runat="server"
                    ToolTip="input rubbing fastness test "></asp:TextBox>
            </td>
        </tr>
        <tr style="height: 28px;">
            <td>
                Type of Dyes:
            </td>
            <td>
                <asp:DropDownList ID="cmbTypeOfDyes" Width="200" AutoPostBack="true" CssClass="dd"
                    runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 28px;">
            <td>
                Type of Print
            </td>
            <td>
                <asp:DropDownList ID="cmbTypeOfPrint" Width="200" AutoPostBack="true" CssClass="dd"
                    runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 28px;">
            <td>
                Type of Washing
            </td>
            <td>
                <asp:DropDownList ID="cmbTypeOfWashing" Width="200" AutoPostBack="true" CssClass="dd"
                    runat="server">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Washing Symbols
            </th>
        </tr>
    </table>
    </br>
    <table width="100%">
        <tr style="height: 28px;">
            <td style="width: 265px;">
                Degree of Colour Fst:
            </td>
            <td valign="top">
                <asp:DropDownList ID="cmbdegree1" Width="50px" CssClass="dd" runat="server" ToolTip="Degree of Colour Fst Symbol">
                </asp:DropDownList>
                <asp:DropDownList ID="cmbdegree2" Visible="false" Width="50px" CssClass="dd" runat="server"
                    ToolTip="Degree of Colour Fst Symbol">
                </asp:DropDownList>
                <asp:DropDownList ID="cmbdegree3" Visible="false" Width="50px" CssClass="dd" runat="server"
                    ToolTip="Degree of Colour Fst Symbol">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 28px;">
            <td>
                Bleaching:
            </td>
            <td valign="top">
                <asp:DropDownList ID="cmbBleachingSymbol" Width="50px" CssClass="dd" runat="server"
                    placeholder="Symbol">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 28px;">
            <td>
                Ironing:
            </td>
            <td>
                <asp:DropDownList ID="cmbIroningSymbol" Width="105px" CssClass="dd" runat="server"
                    placeholder="Symbol">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 28px;">
            <td>
                Dry Cleaning:
            </td>
            <td>
                <asp:DropDownList ID="cmbDryCleaning" Width="50px" CssClass="dd" runat="server" placeholder="Symbol">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 28px;">
            <td>
                Tumble Dry
            </td>
            <td>
                <asp:DropDownList ID="cmbTumbleDry" Width="50px" CssClass="dd" runat="server" placeholder="Symbol">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 28px;">
            <td>
                Buyer’s Technical Comments for QA check
            </td>
            <td>
                <asp:TextBox ID="txtBuyerTechComment" Width="440px" CssClass="textbox" TextMode="MultiLine"
                    runat="server" ToolTip="Comments"></asp:TextBox>
            </td>
        </tr>
    </table>
    </br>
    <table width="100%">
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Packing Detail
            </th>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td>
                <table width="80%">
                    <tr style="height: 28px;">
                        <td>
                            Carton Type:
                        </td>
                        <td>
                            &nbsp;
                            <asp:TextBox ID="txtCartonType" Width="100" CssClass="textbox" runat="server" ToolTip="input carton type "></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height: 28px;">
                        <td>
                            Carton Size :
                        </td>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td>
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
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="cmbCartonSizeUnitID" Width="80" CssClass="dd" runat="server"
                                                    AutoPostBack="True" ToolTip="input quanity per pack and select dropdown">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="height: 28px;">
                        <td>
                            Approx Qty/Carton
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        &nbsp;
                                        <asp:TextBox ID="txtQtyCarton" Width="50" onkeypress="return isNumericKeyy(event);"
                                            CssClass="textbox" runat="server" ToolTip="input quantity per carton"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdcmbQtyCartonUnit" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="cmbQtyCartonUnit" runat="server" AutoPostBack="True" Width="80"
                                                    CssClass="dd" ToolTip="input quanity per Carton and select dropdown" Visible="false">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="height: 28px;">
                        <td>
                            Qty/Pack
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        &nbsp;
                                        <asp:TextBox ID="txtQtyPack" Width="50" onkeypress="return isNumericKeyy(event);"
                                            CssClass="textbox" runat="server" ToolTip="input quantity per carton"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel7" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="cmbQtyPackUnit" runat="server" AutoPostBack="True" Width="80"
                                                    CssClass="dd" ToolTip="input quanity per pack and select dropdown">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="height: 28px;">
                        <td>
                            Poly Bag Size:
                        </td>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td>
                                        L
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPolyBagSizeL" Width="50" onkeypress="return isNumericKeyy(event);"
                                            CssClass="textbox" runat="server" ToolTip="input numbers to define poly bag size and dimension"></asp:TextBox>
                                    </td>
                                    <td>
                                        W
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPolyBagSizeW" Width="50" CssClass="textbox" onkeypress="return isNumericKeyy(event);"
                                            runat="server" ToolTip="input numbers to define poly bag size and dimension"></asp:TextBox>
                                    </td>
                                    <td>
                                        Flap
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPolyBagSizeFlap" onkeypress="return isNumericKeyy(event);" Width="50"
                                            CssClass="textbox" runat="server" ToolTip="input numbers to define poly bag size and dimension"></asp:TextBox>
                                    </td>
                                    <td>
                                        Unit
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="cmbPolyBagSizeUnitID" runat="server" AutoPostBack="true" CssClass="dd"
                                                    Width="80" ToolTip="input quanity per pack and select dropdown">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="height: 28px;">
                        <td>
                            Inlay Card Size/Folding Board:
                        </td>
                        <td>
                            &nbsp;
                            <asp:TextBox ID="txtInlayCardSize" Width="50" CssClass="textbox" runat="server" ToolTip="input YES in capslock if inlay card required else NO in capslock"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height: 28px;">
                        <td>
                            Packed Pc. Sz
                        </td>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td>
                                        L
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPackedPcSzL" Width="50" onkeypress="return isNumericKeyy(event);"
                                            CssClass="textbox" runat="server" ToolTip="input packed piece of garments dimension in numbers"></asp:TextBox>
                                    </td>
                                    <td>
                                        W
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPackedPcSzW" Width="50" onkeypress="return isNumericKeyy(event);"
                                            CssClass="textbox" runat="server" ToolTip="input packed piece of garments dimension in numbers"></asp:TextBox>
                                    </td>
                                    <td>
                                        Unit
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="cmbPackedPcUnitID" runat="server" AutoPostBack="true" CssClass="dd"
                                                    Width="80" ToolTip="input quanity per pack and select dropdown">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="height: 28px;">
                        <td>
                            Approx Gross Weight of Carton:
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        &nbsp;
                                        <asp:TextBox ID="txtGrossWeightofCarton" onkeypress="return isNumericKeyy(event);"
                                            Width="50" CssClass="textbox" runat="server" ToolTip="input gross weight of carton"></asp:TextBox>
                                    </td>
                                    <td>
                                        Unit
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdcmbGrossWeightCartonUnit" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="cmbGrossWeightCartonUnit" runat="server" AutoPostBack="true"
                                                    CssClass="dd" Width="80" ToolTip="input Gross Weight of Carton and select dropdown"
                                                    Visible="true">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="height: 28px;">
                        <td>
                            Poly Bag Sticker Size
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        L
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPolyBagStickerSizeL" onkeypress="return isNumericKeyy(event);"
                                            Width="50" CssClass="textbox" runat="server" ToolTip="input size of stickers"></asp:TextBox>
                                    </td>
                                    <td>
                                        W
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPolyBagStickerSizeW" onkeypress="return isNumericKeyy(event);"
                                            Width="50" CssClass="textbox" runat="server" ToolTip="input size of stickers"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblH" runat="server" Visible="false" Text="H"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPolyBagStickerSizeH" onkeypress="return isNumericKeyy(event);"
                                            Width="50" CssClass="textbox" runat="server" ToolTip="input size of stickers"
                                            Visible="false" Text="0.00"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblUnit" runat="server" Visible="false" Text="Unit"></asp:Label>
                                    </td>
                                    <td>
                                        Unit
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel5" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="cmbPolyBagStickerSizeUnitID" runat="server" AutoPostBack="true"
                                                    CssClass="dd" Width="80" Visible="TRUE" ToolTip="input quanity per pack and select dropdown">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="right">
                <table width="20%">
                    <tr>
                        <td>
                            <asp:Image ID="imgExtra" runat="server" Style="height: 250px; width: 220px;" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:Panel ID="panCompalinType" runat="server" Visible="false">
        <table width="100%">
            <tr>
                <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                    font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                    bgcolor="Silver">
                    Complaint Type
                </th>
            </tr>
        </table>
    </asp:Panel>
    <table width="100%">
        <tr style="height: 38px;">
            <td colspan="8">
                <asp:TextBox ID="txtInsetComplainttype" Width="924" CssClass="textbox" runat="server"
                    Visible="true"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Attachment
            </th>
        </tr>
        <tr style="height: 35px;">
            <td>
                File Type
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel10" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbFileType" runat="server" AutoPostBack="true" CssClass="dd"
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
                <asp:FileUpload ID="FileUpload1" runat="server" ToolTip="select jpg file to attach and press upload" />
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
        <tr style="height: 35px;">
            <td>
                <asp:UpdatePanel ID="UpdgFileInfo" runat="server">
                    <ContentTemplate>
                        <Smart:SmartDataGrid ID="dgFileInfo" runat="server" Width="100%" AllowPaging="True"
                            AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                            PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="15" RecordCount="0"
                            ShowFooter="True" SortedAscending="yes" ForeColor="White">
                            <Columns>
                                <asp:BoundColumn HeaderText="TableID" DataField="TableID" Visible="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="StyleID" DataField="StyleID" Visible="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Creation Date" DataField="Creationdatee">
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
                                <asp:TemplateColumn HeaderText="" Visible="false">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" Visible="true" runat="server" Height="70" Width="150" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="7%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Remove">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="lnkRemove" OnClientClick="return confirm('OK to Delete?');"
                                            ToolTip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png"
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
