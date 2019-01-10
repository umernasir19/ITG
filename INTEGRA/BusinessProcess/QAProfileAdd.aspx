<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="QAProfileAdd.aspx.vb" Inherits="Integra.QAProfileAdd" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                QA Profile
            </th>
        </tr>
        <tr>
            <td>
                Name
            </td>
            <td>
                <asp:DropDownList ID="cmbName" runat="server" Width="140px" ToolTip="Select Name">
                </asp:DropDownList>
            </td>
            <td>
                Title
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <asp:DropDownList ID="cmbTitle" AutoPostBack="true" runat="server" Width="180">
                    <asp:ListItem Value="0">Team Leader</asp:ListItem>
                    <asp:ListItem Value="1">Q.A</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
            </td>
        </tr>
        <tr>
            <td>
                Area Of Expertise
            </td>
            <td>
                <asp:DropDownList ID="cmbAreaOFExpertise" runat="server" Width="140">
                </asp:DropDownList>
            </td>
            <td>
                Level
            </td>
            <td>
                <asp:DropDownList ID="cmbLevel" AutoPostBack="true" runat="server" Width="140">
                    <asp:ListItem Value="0">Trainee</asp:ListItem>
                    <asp:ListItem Value="1">Trained</asp:ListItem>
                    <asp:ListItem Value="2">All Rounder</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Factory
            </td>
            <td>
                <asp:DropDownList ID="cmbFactory" AutoPostBack="true" runat="server" Width="180">
                </asp:DropDownList>
            </td>
            <td>
                Location
            </td>
            <td>
                <asp:TextBox ID="txtLocation" CssClass="textbox" runat="server"></asp:TextBox>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                Deputed Date From
            </td>
            <td>
                <asp:TextBox ID="txtQAStartDate" Width="100" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server" TargetControlID="txtQAStartDate"
                    PopupButtonID="ImageButton3" />
                <asp:ImageButton runat="Server" ID="ImageButton3" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                    AlternateText="Click here to display calendar" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtQAStartDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>
            </td>
            <td>
                Deputed Date To
            </td>
            <td>
                <asp:TextBox ID="txtQAEndDate" Width="100" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtQAEndDate"
                    PopupButtonID="ImageButton1" />
                <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                    AlternateText="Click here to display calendar" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtQAEndDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
                <asp:Button ID="btnAddDetail" CssClass="button" runat="server" Text="Add More" />
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td>
                <Smart:SmartDataGrid ID="dgViewQA" runat="server" Width="100%" AllowPaging="False"
                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                    PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="15" RecordCount="0"
                    ShowFooter="True" SortedAscending="yes" ForeColor="White">
                    <Columns>
                        <asp:BoundColumn HeaderText="QADetailID" DataField="QADetailID" Visible="False">
                            <ItemStyle HorizontalAlign="Left" />
                            <HeaderStyle Width="2%" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Factory" DataField="Factory">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Location" DataField="Location">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Deputed Date From " DataField="StartDateQA">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Deputed Date To " DataField="EndDateQA">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                           <asp:BoundColumn HeaderText="FactoryID" DataField="FactoryID" Visible ="false" >
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="Action" Visible="true">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:ImageButton ID="lnkRemove" runat="server" CommandName="Remove" BackColor="transparent"
                                    ImageUrl="~/Images/RemoveIcon.png" Visible="false" />
                            </ItemTemplate>
                            <HeaderStyle Width="3%" />
                        </asp:TemplateColumn>

                    </Columns>
                    <PagerStyle HorizontalAlign="NotSet" Visible="false" />
                    <AlternatingItemStyle CssClass="GridAlternativeRow" />
                    <ItemStyle CssClass="GridRow" />
                    <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                </Smart:SmartDataGrid>
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td align="center">
                <asp:Button ID="btnSave" CssClass="button" runat="server" Text="Save" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancel" CssClass="button" runat="server" Text="Cancel" />
            </td>
        </tr>
    </table>
</asp:Content>
