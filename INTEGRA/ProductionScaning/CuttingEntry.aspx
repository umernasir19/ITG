<%@ Page Title="Cutting" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="CuttingEntry.aspx.vb" Inherits="Integra.CuttingEntry" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="6" align="left" style="font-family: 'Calibri'; font-size: 17px; font-weight: bold;
                font-style: inherit; color: #336699; font-variant: inherit; height: 29px;" valign="bottom">
                Cutting
            </th>
        </tr>
    </table>
    <table>
        <tr>
            <td style="width: 92px; height: 39px;">
                <asp:Label ID="Label1" runat="server" Text="Season" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="height: 39px; width: 195px">
                <asp:UpdatePanel ID="UpcmbSeason" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <telerik:RadComboBox ID="cmbSeason" runat="server" Skin="WebBlue" AutoPostBack="true">
                        </telerik:RadComboBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                Date
            </td>
            <td>
                <asp:TextBox ID="txtDate" Style="margin-left: 0px; text-align: center; width: 150px;"
                    runat="server" Font-Size="8pt"></asp:TextBox>
                <div class="icon" align="center">
                    <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtDate"
                        PopupButtonID="ImageButton1" />
                    <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" ImageUrl="~/Images/callendar.jpg"
                        AlternateText="Click here to display calendar" Style="margin-left: 156px; margin-top: -20px;" />
                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDate"
                        Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                        CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                        Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                    </cc1:MaskedEditExtender>
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 92px; height: 39px;">
                <asp:Label ID="lblSRNO" runat="server" Text="Sr No" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="height: 39px">
                <asp:UpdatePanel ID="UpcmbSrNo" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <telerik:RadComboBox ID="cmbSrNo" runat="server" Skin="WebBlue" AutoPostBack="true">
                        </telerik:RadComboBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
             <td style="width: 92px; height: 39px;">
                <asp:Label ID="Label4" runat="server" Text="Color" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="height: 39px">
                <asp:UpdatePanel ID="UpcmbColor" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <telerik:RadComboBox ID="cmbColor" runat="server" Skin="WebBlue" AutoPostBack="true">
                        </telerik:RadComboBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>





        <td style="width: 92px; height: 39px;">
                <asp:Label ID="Label9" runat="server" Text="Style" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="height: 39px">
                <asp:UpdatePanel ID="UptxtStyle" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <telerik:RadTextBox ID="txtStyle" runat="server" Skin="WebBlue" ReadOnly="true">
                        </telerik:RadTextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>





           
            <td style="width: 92px; height: 39px;">
                <asp:Label ID="Label2" runat="server" Text="Total Quantity" Font-Names="Calibri"
                    Font-Size="Medium"></asp:Label>
            </td>
            <td style="height: 39px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <telerik:RadNumericTextBox ID="txtTotalQuantity" ReadOnly="true" runat="server" Skin="WebBlue"
                            Width="100px" Type="Number" NumberFormat-DecimalDigits="2">
                        </telerik:RadNumericTextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 92px; height: 39px;">
                <asp:Label ID="Label10" runat="server" Text="Already Cut" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="height: 39px">
                <asp:UpdatePanel ID="UpAlreadyCut" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <telerik:RadNumericTextBox ID="txtAlreadyCut" runat="server" ReadOnly="true" Skin="WebBlue"
                            Width="100px" Type="Number" NumberFormat-DecimalDigits="2">
                        </telerik:RadNumericTextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 92px; height: 39px;">
                <asp:Label ID="Label3" runat="server" Text="Today Cut" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="height: 39px">
                <asp:UpdatePanel ID="UptxtTodayQty" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <telerik:RadNumericTextBox ID="txtTodayQty" AutoPostBack="true" runat="server" Skin="WebBlue"
                            Width="100px" Type="Number" NumberFormat-DecimalDigits="2">
                        </telerik:RadNumericTextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 92px; height: 39px;">
                <asp:Label ID="Label5" runat="server" Text="Today Issue" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="height: 39px">
                <asp:UpdatePanel ID="UpTXTTodayIssue" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <telerik:RadNumericTextBox ID="TXTTodayIssue" runat="server" Skin="WebBlue" Width="100px"
                            Type="Number" NumberFormat-DecimalDigits="2">
                        </telerik:RadNumericTextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td valign="middle" style="width: 60px; height: 70px;">
                <telerik:RadButton ID="btnADD" runat="server" Text="ADD" Skin="WebBlue" Width="70px">
                </telerik:RadButton>
            </td>
        </tr>
    </table>
    <asp:Label ID ="lblDtlIDwhenEdit" runat ="server"  Visible ="false" Text="0" ></asp:Label>
    <br />
    <table>
        <tr>
            <td>
                <div style="width: 930px;">
                    <Smart:SmartDataGrid ID="dgPanalEntry" runat="server" Width="100%" AllowSorting="True"
                        AutoGenerateColumns="False" CellPadding="2" CssClass="table" PagerCurrentPageCssClass=""
                        PagerOtherPageCssClass="" PageSize="300" RecordCount="0" ShowFooter="True" SortedAscending="yes">
                        <Columns>
                            <asp:BoundColumn HeaderText="TodayCuttingDtlID" DataField="TodayCuttingDtlID" Visible="false" />
                            <asp:BoundColumn HeaderText="JobOrderID" DataField="JobOrderID" Visible="false" />
                            <asp:BoundColumn HeaderText="JobOrderDetailID" DataField="JobOrderDetailID" Visible="false" />
                               <asp:BoundColumn HeaderText="SeasonDatabaseID" DataField="SeasonDatabaseID" Visible="false" />
                            <asp:BoundColumn HeaderText="Date" DataField="CuttingDate" Visible="true">
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Season" DataField="Season" Visible="true">
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="SR NO" DataField="SRNO" Visible="true">
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Color" DataField="Color" Visible="true">
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Style" DataField="Style" Visible="true">
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Today Cut" DataField="TodayCut" Visible="true">
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Today Issue" DataField="TodayIssue" Visible="true">
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                            </asp:BoundColumn>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="EDIT">
                            <ItemTemplate>
                                <asp:ImageButton ID="lnkEdit" ToolTip="Click here to edit" ImageUrl="~/Images/editIcon.jpg"
                                    CommandName="Edit" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="Remove"
                                Visible="false">
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkRemove" ToolTip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png"
                                        CommandName="Remove" runat="server"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                        <PagerStyle Visible="False" CssClass="GridPagerStyle" Mode="NumericPages" HorizontalAlign="Right" />
                        <AlternatingItemStyle CssClass="GridAlternativeRow" />
                        <ItemStyle CssClass="GridRow" />
                        <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                    </Smart:SmartDataGrid></div>
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td valign="middle" style="width: 60px; height: 70px;">
                <telerik:RadButton ID="btnSave" runat="server" Text="Save" Skin="WebBlue" Width="70px">
                </telerik:RadButton>
            </td>
            <td valign="middle" style="width: 60px; height: 70px;">
                <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" Skin="WebBlue" Width="70px">
                </telerik:RadButton>
            </td>
        </tr>
        <tr>
        <td>
        <asp:Label ID ="lblUserId" runat ="server"  Visible ="false" Text="0" ></asp:Label>
        </td>
        </tr>
    </table>
</asp:Content>
