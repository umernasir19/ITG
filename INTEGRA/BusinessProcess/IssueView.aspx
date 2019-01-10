<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="IssueView.aspx.vb" Inherits="Integra.IssueView" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="6" align="left" style="font-family: Century Gothic; font-size: 16PX;
                font-weight: bold; color: Blue">
                <marquee>Searching Criteria For PONO,Fabric Code,Manual Challan No,Department</marquee>
            </th>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td style="width: 20%">
                <asp:TextBox ID="txtShowMe" runat="server" AutoPostBack="true" autocomplete="off"
                    Width="196px"> </asp:TextBox>
                <cc1:AutoCompleteExtender runat="server" ID="autoComplete1" TargetControlID="txtShowMe"
                    ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                    CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="GetPoIssuedSearching" />
            </td>
            <td style="width: 10%">
                <asp:UpdatePanel ID="btnSearchUPdate" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnSearch" Visible="false" runat="server" CssClass="button" Text="Search"
                            Width="80"></asp:Button>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click"></asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Button ID="btnAll" runat="server" CssClass="button" Text="Show All" Width="80"
                    Visible="false"></asp:Button>
            </td>
               <td>
            <div style=" margin-left: -25px; margin-top: -14px;">
                <asp:Button ID="btnshow" Visible="true"  runat="server" CssClass="button" Text="Show All Data"
                    Width="160" Style="margin-top: 14px; margin-left: 0px;"></asp:Button></div>
            </td>
        </tr>
    </table>
     <table>
        <tr>
            <td>
                        <asp:Label ID="Label4" runat="server" Font-Size="Medium" Style="margin-left: 0px; font-family: Calibri; font-size: 12PX; font-weight: bolder;
                        color: red" Text="Current Data Showing Last 30 Days."></asp:Label>
                    </td>
            <td>
                <asp:Button ID="cmdAdd" Visible="true"  runat="server" CssClass="button" Text="ADD Issue"
                    Width="160" Style="margin-top: 14px; margin-left: 589px;"></asp:Button>
            </td>
           
        </tr>
    </table>
    <table width="100%">
        <tr style="height: 5px">
        </tr>
        <tr>
            <td>
                <div style="overflow: scroll; width: 920px; ">
                    <Smart:SmartDataGrid ID="dgView" runat="server" Width="100%" AllowPaging="True" AllowSorting="True"
                        AutoGenerateColumns="False" OnSortCommand="SortByColumn" OnPageIndexChanged="PageChanged" CellPadding="4" CssClass="table" PageSize="1000" ShowFooter="True"
                        ForeColor="white" GridLines="both">
                        <Columns>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="IssueID"
                                DataField="IssueID" Visible="false" />
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="IssueDtlID"
                                DataField="IssueDtlID" Visible="false" />
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Date"
                                DataField="Date" Visible="true" />
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Item Name"
                                DataField="ItemName" Visible="true" />
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Item Code"
                                DataField="ItemCodee" Visible="true" />
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="4%" HeaderText="Department"
                                DataField="DeptDatabaseNamee" Visible="true" />
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="4%" HeaderText="Manual Challan No"
                                DataField="ManualChallanNo" Visible="true" />
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="PO NO" DataField="PONoo">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Recv Qty" DataField="RecvQtyy">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Issue Qty" DataField="IssueQty">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Balance" DataField="Balance"
                                Visible="false">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Remarks" DataField="Remarks">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" Visible="true" HeaderStyle-Width="02%"
                                HeaderText="EDIT">
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkEdit" ToolTip="Click here to edit" ImageUrl="~/Images/editIcon.jpg"
                                        CommandName="Edit" runat="server"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="PDF"
                                Visible="true">
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkPDF" ToolTip="Click here to download PDF" ImageUrl="~/Images/pdf_icon_small.gif"
                                        CommandName="PDF" runat="server"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="Return"
                                Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkReturn" ToolTip="Click here to Go Return" Text="Return" CommandName="Return"
                                        runat="server"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="REMOVE"
                                Visible="True">
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkRemove" ToolTip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png"
                                        CommandName="Remove" runat="server"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" Visible="false" HeaderText="AuditorStatus"
                                DataField="AuditorStatus">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                        </Columns>
                    </Smart:SmartDataGrid></div>
            </td>
        </tr>
    </table>
</asp:Content>
