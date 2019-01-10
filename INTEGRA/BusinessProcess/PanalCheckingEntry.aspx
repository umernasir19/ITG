<%@ Page Title="Panal Checking Entry" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="PanalCheckingEntry.aspx.vb" Inherits="Integra.PanalCheckingEntry" %>

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
     function isNumericKeyy(e) {
         var charInp = window.event.keyCode;
         if (charInp != 46 && (charInp < 48 || charInp > 57)) {
             return false;
         }
         return true;
     }
 
    </script>
    <table>
        <tr>
            <td>
                Season
            </td>
            <td>
                <asp:DropDownList ID="cmbSeason" Width="150" CssClass="combo" AutoPostBack="true"
                    runat="server" Style="margin-top: 5px; margin-left: 60px;">
                </asp:DropDownList>
            </td>

            <td>
                Date
            </td>
            <td>
                <asp:TextBox ID="txtDate" Style="margin-left: 94px; text-align: center; width: 150px;"
                    runat="server" Font-Size="8pt"></asp:TextBox>
                <div class="icon" align="center">
                    <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtDate"
                        PopupButtonID="ImageButton1" />
                    <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" ImageUrl="~/Images/callendar.jpg"
                        AlternateText="Click here to display calendar" Style="margin-left: 246px; margin-top: -20px;" />
                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDate"
                        Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                        CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                        Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                    </cc1:MaskedEditExtender>
                </div>
            </td>

        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td>
                Sr NO
            </td>
            <td>
                <asp:DropDownList ID="CMBsRnO" Width="150" CssClass="combo"  AutoPostBack="true" runat="server"
                    Style="margin-left: -310px; margin-left: 12px;">
                </asp:DropDownList>
                     <%--<asp:TextBox ID="txtSRNO" runat="server" autocomplete="off" AutoPostBack="true"
                                        Style="margin-left: 13px; width: 150px;"></asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="10"
                                        CompletionSetCount="12" ContextKey="SearchSRNO" EnableCaching="true" MinimumPrefixLength="1"
                                        ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtSRNO" />--%>

            </td>
            <asp:Label ID ="lblSrID" runat ="server"  Visible ="false" ></asp:Label>
            <asp:Label ID ="lblDtlIDwhenEdit" runat ="server"  Visible ="false" Text ="0" ></asp:Label>
            <td>
                Color
            </td>
            <td>
            <asp:DropDownList ID="cmbColor" Width="150" CssClass="combo"  runat="server"
                    Style="margin-left: -310px; margin-left: 12px;">
                </asp:DropDownList>
                                    <%--<asp:TextBox ID="txtColor" runat="server" autocomplete="off" AutoPostBack="true"
                                        Style="margin-left: 13px; width: 150px;"></asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="10"
                                        CompletionSetCount="12" ContextKey="SearchColor" EnableCaching="true" MinimumPrefixLength="1"
                                        ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtColor" />--%>

            </td>
            <asp:Label ID ="Label1" runat ="server"  Visible ="true" ></asp:Label>
        </tr>
        <tr>
            <td>
                Rang No #
            </td>
            <td>
                <asp:TextBox ID="txtRangNo" runat="server" Width="150px" CssClass="textbox" Style="margin-right: -164px;
                    margin-left: 12px; height: 16px; margin-top: 6px;"></asp:TextBox>
            </td>
            <td style="width: 110px;">
                Panal Qty
            </td>
            <td>
                <asp:TextBox ID="txtPanalQty" runat="server" Width="150px" CssClass="textbox" Style="margin-right: -164px;
                    margin-left: 12px; height: 16px;"  onkeypress="return isNumericKeyy(event);"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Rejection Qty #
            </td>
            <td>
                <asp:TextBox ID="txtRejectionQty" runat="server" Width="150px" CssClass="textbox"
                    Style="margin-right: -164px; margin-left: 12px; height: 16px; margin-top: 6px;"  onkeypress="return isNumericKeyy(event);"></asp:TextBox>
            </td>
            <td style="width: 110px;">
                Remarks
            </td>
            <td>
                <asp:TextBox ID="txtRemarks" runat="server" Width="150px" CssClass="textbox" Style="margin-right: -164px;
                    margin-left: 12px; height: 16px;"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <table>
        <tr>
            <td>
                <asp:Button ID="btnAdd" ToolTip="Click here To Add data." CssClass="btn btn-outline btn-success"
                    runat="server" Text="Add" Width="120px" Style="margin-left: 374px;" />
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td>
            <div style=" width :930px;" >
                <Smart:SmartDataGrid ID="dgPanalEntry" runat="server" Width="100%" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="2" CssClass="table" PagerCurrentPageCssClass=""
                    PagerOtherPageCssClass="" PageSize="300" RecordCount="0" ShowFooter="True" SortedAscending="yes">
                    <Columns>
                        <asp:BoundColumn HeaderText="PanalDtlID" DataField="PanalDtlID" Visible="false" />
                        <asp:BoundColumn HeaderText="JobOrderID" DataField="JobOrderID" Visible="false" />
                        <asp:BoundColumn HeaderText="SR NO" DataField="SRNO" Visible="true">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:BoundColumn>
                           <asp:BoundColumn HeaderText="Color" DataField="Color" Visible="true">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Date" DataField="Date" Visible="true">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Rang No" DataField="RangNo" Visible="true">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Panal Qty" DataField="PanalQty" Visible="true">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Rejection Qty" DataField="RejectionQty" Visible="true">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Remarks" DataField="Remarks" Visible="true">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="EDIT">
                            <ItemTemplate>
                                <asp:ImageButton ID="lnkEdit" ToolTip="Click here to edit" ImageUrl="~/Images/editIcon.jpg"
                                    CommandName="Edit" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="Remove"
                        visible="false">
                        <itemtemplate>									 								
									<asp:ImageButton id="lnkRemove" tooltip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png" CommandName="Remove" runat="server"></asp:ImageButton>
								</itemtemplate>
                    </asp:TEMPLATECOLUMN>
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
    <br />
    <table>
        <tr>
            <td>
                <asp:Button ID="btnSave" ToolTip="Click here To Save data." CssClass="btn btn-outline btn-success"
                    runat="server" Text="Save" Width="120px" Visible ="false"  Style="margin-left: 0px;" />
            </td>
             <td>
                <asp:Button ID="btnCancel" ToolTip="Click here To Cancel data." CssClass="btn btn-outline btn-success"
                    runat="server" Text="Cancel" Width="120px" Style="margin-left: 0px;" />
            </td>
        </tr>
        <tr>
            <td align="center">
              <asp:Label ID ="lblUserId" runat ="server" Visible ="false" Text="0"></asp:Label>
            </td>
        </tr>

    </table>
</asp:Content>
