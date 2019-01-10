<%@ Page Title="Item Category View" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="ItemCategoryView.aspx.vb" Inherits="Integra.ItemCategoryView" %>

<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                Item Class Name
            </td>
            <td align="right">
                <asp:TextBox CssClass="textbox" ID="txtItemClassName" AutoPostBack="true" Style="height: 20px;
                    text-transform: uppercase; margin-left: 10px;" runat="server" ReadOnly="false"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="10"
                    CompletionSetCount="12" ContextKey="ClassNameForItemCategory" EnableCaching="true"
                    MinimumPrefixLength="1" ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx"
                    TargetControlID="txtItemClassName" />
            </td>
            <td>
                Item Category Name
            </td>
            <td align="right">
                <asp:TextBox CssClass="textbox" ID="txtCategoryName" AutoPostBack="true" Style="height: 20px;
                    text-transform: uppercase; margin-left: 10px;" runat="server" ReadOnly="false"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="10"
                    CompletionSetCount="12" ContextKey="CategoryName" EnableCaching="true" MinimumPrefixLength="1"
                    ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtCategoryName" />
            </td>
        </tr>
    </table>
    <table style="width: 100%">
        <tr>
            <td style="width: 918px" align="right">
                <asp:LinkButton ID="lnkPrint" runat="server" Visible="false">Click here for Print</asp:LinkButton>
                <asp:Button ID="cmdAdd" runat="server" CssClass="button" Text="Add Item Category "
                    Width="200"></asp:Button>
            </td>
        </tr>
        <tr style="height: 5px">
        </tr>
        <tr>
            <td align="center" valign="top" style="width: 918px">
                <table width="100%">
                    <tr>
                        <td>
                            <Smart:SmartDataGrid ID="dgItemCategory" runat="server" Width="100%" OnSortCommand="SortByColumn"
                                OnPageIndexChanged="PageChanged" OnItemDataBound="DataBound" AllowPaging="True"
                                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                                PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="100" RecordCount="0"
                                ShowFooter="True" ForeColor="white" GridLines="vertical">
                                <Columns>
                                    <asp:BoundColumn HeaderText="ID" DataField="IMSItemCategoryID" Visible="False">
                                        <HeaderStyle Width="5%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Item Class Name" DataField="ItemClassName">
                                        <HeaderStyle HorizontalAlign="Center" Width="7%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Item Category Name" DataField="ItemCategoryName">
                                        <HeaderStyle HorizontalAlign="Center" Width="7%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Item Category Code" DataField="ItemCategoryCode">
                                        <HeaderStyle HorizontalAlign="Center" Width="7%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:TemplateColumn HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="lnkEdit" ToolTip="Click here to edit" ImageUrl="~/Images/editIcon.jpg"
                                                CommandName="Edit" runat="server"></asp:ImageButton>
                                        </ItemTemplate>
                                        <HeaderStyle Width="5%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateColumn>
                                </Columns>
                                <PagerStyle CssClass="GridPagerStyle" HorizontalAlign="Right" Mode="NumericPages" />
                                <AlternatingItemStyle CssClass="GridAlternativeRow" />
                                <ItemStyle CssClass="GridRow" />
                                <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                            </Smart:SmartDataGrid>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
