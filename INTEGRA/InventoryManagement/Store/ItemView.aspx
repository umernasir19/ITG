<%@ Page Title="Item View" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="ItemView.aspx.vb" Inherits="Integra.ItemView" %>

<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td style="width: 110px;">
                Item Cat.Name
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <asp:TextBox CssClass="textbox" ID="txtItemCatForPdf" AutoPostBack="true" Style="height: 18px;
                    margin-left: 10px;" runat="server" ReadOnly="false"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender11" runat="server" CompletionInterval="10"
                    CompletionSetCount="12" ContextKey="CategoryName" EnableCaching="true" MinimumPrefixLength="1"
                    ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtItemCatForPdf" />
            </td>
            <td style="width: 110px;">
                Item Code
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <asp:TextBox CssClass="textbox" ID="txtItemCodeForPdf" AutoPostBack="true" Style="height: 20px;
                    margin-left: 10px;" runat="server" ReadOnly="false"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender10" runat="server" CompletionInterval="10"
                    CompletionSetCount="12" ContextKey="CodeForAstore" EnableCaching="true" MinimumPrefixLength="1"
                    ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtItemCodeForPdf" />
            </td>
        </tr>
        <tr>
            <td style="width: 110px;">
                Item Name
            </td>
            <td>
                <asp:TextBox CssClass="textbox" ID="txtItemNameForPdf" AutoPostBack="true" Style="height: 20px;
                    margin-left: 10px;" runat="server" ReadOnly="false"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender9" runat="server" CompletionInterval="10"
                    CompletionSetCount="12" ContextKey="ItemNameFStore" EnableCaching="true" MinimumPrefixLength="1"
                    ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtItemNameForPdf" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblItemCateID" runat="server" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <tr>
                    <td>
                        <asp:Button ID="btnPdff" runat="server" CssClass="button" Text="Download  PDF" Width="120"
                            Style="height: 17px; margin-left: 0px; color: Blue;" Visible="true"></asp:Button>
                    </td>
                </tr>
    </table>
    <br />
    <table>
        <tr>
            <td align="right">
                <asp:Button ID="cmdAdd" runat="server" CssClass="button" Text="Add Item" Width="200"
                    Style="margin-left: 732px;"></asp:Button>
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
        </tr>
        <tr>
            <td>
                Item Name
            </td>
            <td align="right">
                <asp:TextBox CssClass="textbox" ID="txtItemNameFStore" AutoPostBack="true" Style="height: 20px;
                    margin-left: 10px;" runat="server" ReadOnly="false"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="10"
                    CompletionSetCount="12" ContextKey="ItemNameFStore" EnableCaching="true" MinimumPrefixLength="1"
                    ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtItemNameFStore" />
            </td>
            <asp:Panel ID="pnlItemQuality" runat="server" Visible="false">
                <td>
                    Item Quality
                </td>
                <td align="right">
                    <asp:TextBox CssClass="textbox" ID="txtItemQualityFStore" AutoPostBack="true" Style="height: 20px;
                        margin-left: 10px;" runat="server" ReadOnly="false"></asp:TextBox>
                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="10"
                        CompletionSetCount="12" ContextKey="ItemQualityFStore" EnableCaching="true" MinimumPrefixLength="1"
                        ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtItemQualityFStore" />
                </td>
            </asp:Panel>
            <td>
                Shade
            </td>
            <td align="right">
                <asp:TextBox CssClass="textbox" ID="txtShade" AutoPostBack="true" Style="height: 20px;
                    margin-left: 10px;" runat="server" ReadOnly="false"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" CompletionInterval="10"
                    CompletionSetCount="12" ContextKey="ShadeForAstore" EnableCaching="true" MinimumPrefixLength="1"
                    ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtShade" />
            </td>
            <td>
                Code
            </td>
            <td align="right">
                <asp:TextBox CssClass="textbox" ID="txtCode" AutoPostBack="true" Style="height: 20px;
                    margin-left: 10px;" runat="server" ReadOnly="false"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" CompletionInterval="10"
                    CompletionSetCount="12" ContextKey="CodeForAstore" EnableCaching="true" MinimumPrefixLength="1"
                    ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtCode" />
            </td>
        </tr>
        <asp:Panel ID="pnlDalwise" runat="server" Visible="true">
            <tr>
                <td>
                    Dal No
                </td>
                <td align="right">
                    <asp:TextBox CssClass="textbox" ID="txtDalNo" AutoPostBack="true" Style="height: 18px;
                        margin-left: 10px;" runat="server" ReadOnly="false"></asp:TextBox>
                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender5" runat="server" CompletionInterval="10"
                        CompletionSetCount="12" ContextKey="DalNoForFstore" EnableCaching="true" MinimumPrefixLength="1"
                        ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtDalNo" />
                </td>
                <td>
                    Dal Ref.No
                </td>
                <td align="right">
                    <asp:TextBox CssClass="textbox" ID="txtDalRefNo" AutoPostBack="true" Style="height: 18px;
                        margin-left: 10px;" runat="server" ReadOnly="false"></asp:TextBox>
                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender6" runat="server" CompletionInterval="10"
                        CompletionSetCount="12" ContextKey="DalRefForFstore" EnableCaching="true" MinimumPrefixLength="1"
                        ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtDalRefNo" />
                </td>
            </tr>
        </asp:Panel>
        <asp:Panel ID="pnlitemcat" runat="server" Visible="true">
            <tr>
                <td>
                    Item Category
                </td>
                <td align="right">
                    <asp:TextBox CssClass="textbox" ID="txtItemCat" AutoPostBack="true" Style="height: 18px;
                        margin-left: 10px;" runat="server" ReadOnly="false"></asp:TextBox>
                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender7" runat="server" CompletionInterval="10"
                        CompletionSetCount="12" ContextKey="CategoryName" EnableCaching="true" MinimumPrefixLength="1"
                        ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtItemCat" />
                </td>
                <td>
                    Item Class Name
                </td>
                <td align="right">
                    <asp:TextBox CssClass="textbox" ID="txtItemClass" AutoPostBack="true" Style="height: 20px;
                        text-transform: uppercase; margin-left: 10px;" runat="server" ReadOnly="false"></asp:TextBox>
                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender8" runat="server" CompletionInterval="10"
                        CompletionSetCount="12" ContextKey="ClassNameForItemCategory" EnableCaching="true"
                        MinimumPrefixLength="1" ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx"
                        TargetControlID="txtItemClass" />
                </td>
            </tr>
        </asp:Panel>
    </table>
    <br />
    <table>
        <tr>
            <td>
                <div style="width: 920PX; overflow: scroll;">
                    <Smart:SmartDataGrid ID="dgItemView" runat="server" Width="100%" OnSortCommand="SortByColumn"
                        OnPageIndexChanged="PageChanged" OnItemDataBound="DataBound" AllowPaging="true"
                        AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="tableNew"
                        PageSize="50" ShowFooter="True" ForeColor="black" Height="300PX" GridLines="both">
                        <Columns>
                            <asp:BoundColumn HeaderText="ID" DataField="IMSItemID" Visible="False">
                                <HeaderStyle Width="1%" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="S.No">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="1%" HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <%# Container.DataSetIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn HeaderText="CHART OF ACCOUNT" DataField="ItemCodee">
                                <HeaderStyle HorizontalAlign="Center" Width="2%" />
                                <ItemStyle HorizontalAlign="Center" Width="2%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="ITEM NAME" DataField="ItemName">
                                <HeaderStyle HorizontalAlign="Center" Width="2%" />
                                <ItemStyle HorizontalAlign="Center" Width="2PX" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Dal No" DataField="DalNo">
                                <HeaderStyle HorizontalAlign="Center" Width="2%" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Dal Ref No" DataField="DalRefNo">
                                <HeaderStyle HorizontalAlign="Center" Width="2%" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="ITEM QUALITY" DataField="ItemQuality">
                                <HeaderStyle HorizontalAlign="Center" Width="3%" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Item Class Name" DataField="ItemClassName">
                                <HeaderStyle HorizontalAlign="Center" Width="3%" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Item Category Name" DataField="ItemCategoryName">
                                <HeaderStyle HorizontalAlign="Center" Width="3%" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="SHADE" Visible="TRUE" DataField="Shade">
                                <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="COLOR" Visible="false" DataField="Color">
                                <HeaderStyle HorizontalAlign="Center" Width="7%" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="UNIT RATE" DataField="UnitRate">
                                <HeaderStyle HorizontalAlign="Center" Width="3%" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="OPEN QTY" DataField="OpeningQuantity">
                                <HeaderStyle HorizontalAlign="Center" Width="3%" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="UNIT" DataField="Symbol">
                                <HeaderStyle HorizontalAlign="Center" Width="3%" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="CUR" DataField="CurrencyName">
                                <HeaderStyle HorizontalAlign="Center" Width="3%" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="OPEN VALUE" DataField="OpeningValue">
                                <HeaderStyle HorizontalAlign="Center" Width="3%" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="WIDTH" DataField="Width">
                                <HeaderStyle HorizontalAlign="Center" Width="1%" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkEdit" ToolTip="Click here to edit" ImageUrl="~/Images/editIcon.jpg"
                                        CommandName="Edit" runat="server"></asp:ImageButton>
                                </ItemTemplate>
                                <HeaderStyle Width="2%" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="PDF" Visible="TRUE">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkPDF" CommandName="PDF" ToolTip="Click here to view PDF "
                                        ImageUrl="~/Images/pdf_icon_small.gif" runat="server" Style="height: 15px;">
                                    </asp:ImageButton>
                                </ItemTemplate>
                                <HeaderStyle Width="2%" HorizontalAlign="Center" />
                            </asp:TemplateColumn>
                        </Columns>
                        <PagerStyle CssClass="GridPagerStyle" HorizontalAlign="Right" Mode="NumericPages"
                            Position="TopAndBottom" />
                        <AlternatingItemStyle CssClass="GridAlternativeRow" />
                        <ItemStyle CssClass="GridRow" />
                        <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                    </Smart:SmartDataGrid>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
