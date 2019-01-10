<%@ Page Title="JV View" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="JVView.aspx.vb" Inherits="Integra.JVView" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td>
                <table>
                    <tr>
                        <td style="width: 10%">
                            Show Me:
                        </td>
                        <td style="width: 20%">
                            <asp:TextBox ID="txtShowMe" runat="server" CssClass="textbox" AutoPostBack="true"
                                autocomplete="off" Width="140px" ToolTip="Voucher No"> </asp:TextBox>
                            <cc1:AutoCompleteExtender runat="server" ID="autoComplete1" TargetControlID="txtShowMe"
                                ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                                CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="tblJVMst" />
                        </td>
                        <td style="width: 54%">
                            <%-- <asp:UpdatePanel id="btnSearchUPdate" UpdateMode="Conditional"   runat="server">
                        <ContentTemplate>--%>
                            <asp:Button ID="btnSearch" runat="server" Width="80" Text="Filter" Visible="false"
                                CssClass="button" OnClick="btnSearch_Click"></asp:Button>
                            <%--</ContentTemplate> 
                           <triggers>
<asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="txtShowMe" EventName="TextChanged"></asp:AsyncPostBackTrigger>
</triggers>
                        </asp:UpdatePanel>--%>
                        </td>
                        <td style="width: 50%" align="right">
                            <asp:Button ID="cmdAdd" runat="server" CssClass="button" Text="ADD JOURNAL VOUCHER"
                                Width="170px"></asp:Button>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 918px" align="right">
            </td>
        </tr>
        <tr style="height: 5px">
        </tr>
        <tr>
            <td>
                <%--    <asp:UpdatePanel ID="udpGrid"   runat="server" >
                                    <ContentTemplate>--%>
                <Smart:SmartDataGrid ID="dgView" runat="server" Width="100%" OnSortCommand="SortByColumn"
                    OnPageIndexChanged="PageChanged" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                    CellPadding="4" CssClass="table" PageSize="1000" ShowFooter="True" ForeColor="white"
                    GridLines="both">
                    <Columns>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="tblJVMstID"
                            DataField="tblJVMstID" Visible="false" />
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Voucher  Date" DataField="VoucherDate">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Voucher  No" DataField="VoucherNo">
                            <HeaderStyle HorizontalAlign="center" Width="12%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Description" DataField="Description">
                            <HeaderStyle HorizontalAlign="center" Width="25%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="DB" DataField="Debit"
                            DataFormatString="{0:0,0.0}">
                            <HeaderStyle HorizontalAlign="center" Width="6%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="CR" DataField="Credit"
                            DataFormatString="{0:0,0.0}">
                            <HeaderStyle HorizontalAlign="center" Width="6%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Balance" DataField="Balance"
                            DataFormatString="{0:0,0.0}">
                            <HeaderStyle HorizontalAlign="center" Width="6%" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="EDIT"
                            Visible="true">
                            <ItemTemplate>
                                <asp:ImageButton ID="lnkEdit" ToolTip="Click here to edit" ImageUrl="~/Images/editIcon.jpg"
                                    CommandName="Edit" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="REMOVE"
                            Visible="true">
                            <ItemTemplate>
                                <asp:ImageButton ID="lnkRemove" ToolTip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png"
                                    CommandName="Remove" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="PDF"
                            Visible="true">
                            <ItemTemplate>
                                <asp:ImageButton ID="lnkPDF" ToolTip="Click here to download PDF" ImageUrl="~/Images/pdf_icon_small.gif"
                                    CommandName="PDF" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </Smart:SmartDataGrid>
                <%-- </ContentTemplate>
                         </asp:UpdatePanel>--%>
            </td>
        </tr>
    </table>
</asp:Content>
