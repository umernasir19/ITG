<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="AccChecklistEntry.aspx.vb" Inherits="Integra.AccChecklistEntry" %>

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
    <asp:Panel ID="pnlCopy" runat="server" Visible="false">
        <table>
            <tr>
                <td>
                    <div class="txt_newwww" style="width: 100px;">
                        Season
                    </div>
                </td>
                <td>
                    <div style="">
                        <asp:DropDownList Style="margin-left: 0px" ID="cmbSeason" runat="server" Width="139px"
                            AutoPostBack="true" CssClass="combo" OnSelectedIndexChanged="cmbSeason_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </td>
                <td>
                    <div class="txt_newwww" style="width: 100px;">
                        PO No.
                    </div>
                </td>
                <td>
                    <div style="">
                        <asp:DropDownList Style="margin-left: 5px" ID="CMBSRNO" runat="server" Width="139px"
                            AutoPostBack="true" CssClass="combo" OnSelectedIndexChanged="CMBSRNO_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </td>
                <td>
                    <div class="txt_newwww" style="width: 100px;">
                        Color
                    </div>
                </td>
                <td>
                    <div style="">
                        <asp:DropDownList Style="margin-left: 5px" ID="cmbColor" runat="server" Width="139px"
                            AutoPostBack="false" CssClass="combo">
                        </asp:DropDownList>
                    </div>
                </td>
            </tr>
        </table>
        <br />
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnCopy" CssClass="btn btn-outline btn-success" runat="server" Text="Copy All Access"
                        Style="margin-left: 0px;" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <table width="100%">
        <tr style="height: 30px;" class="heading">
            <td>
                <b>Accessories Check List</b>
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td>
                <div class="txt" style="width: 130px;">
                    Date</div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtDate" CssClass="textbox" Width="120" runat="server" Style="height: 20px;"></asp:TextBox></div>
                <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtDate"
                    PopupButtonID="ImageButton1" />
                <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                    AlternateText="Click here to display calendar" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>
            </td>
            <td>
                <div class="txt" style="width: 130px; margin-top: -4px;">
                    Revised Date</div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtRevisedDate" CssClass="textbox" Width="120" runat="server" Style="height: 20px;"></asp:TextBox></div>
                <cc1:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server" TargetControlID="txtRevisedDate"
                    PopupButtonID="ImageButton3" />
                <asp:ImageButton runat="Server" ID="ImageButton3" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                    AlternateText="Click here to display calendar" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtRevisedDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;">
                <div class="txt" style="width: 130px;">
                    Season.</div>
            </td>
            <td style="width: 250px;">
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox CssClass="textbox" ID="txtSeason" Style="height: 20px;" runat="server"
                        ReadOnly="True"></asp:TextBox></div>
            </td>
            <td style="width: 150px; visibility: hidden;">
                <div class="txt" style="width: 130px;">
                    Style</div>
            </td>
            <td>
                <div class="text_box" style="width: 130px; visibility: hidden;">
                    <asp:TextBox CssClass="textbox" ID="TextBox2" Text="0" Style="height: 20px;" runat="server"
                        ReadOnly="True"></asp:TextBox></div>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;">
                <div class="txt" style="width: 130px;">
                    PO No.</div>
            </td>
            <td style="width: 250px;">
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox CssClass="textbox" ID="txtSRNo" Style="height: 20px;" runat="server"
                        ReadOnly="True"></asp:TextBox></div>
            </td>
            <td style="width: 150px;">
                <div class="txt" style="width: 130px;">
                    Style</div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox CssClass="textbox" ID="txtStyle" Style="height: 20px;" runat="server"
                        ReadOnly="True"></asp:TextBox></div>
            </td>
        </tr>
        <tr style="height: 34px;">
            <td>
                <div class="txt" style="width: 130px;">
                    Customer</div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox CssClass="textbox" ID="txtCustomer" Style="height: 20px;" runat="server"
                        ReadOnly="True"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="txt" style="width: 130px;">
                    Quantity</div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtQuantity" CssClass="textbox" Style="height: 20px;" runat="server"
                        ReadOnly="True"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <%--       <div class="txt" style="width: 130px;">
                    Stitching Factory</div>--%>
            </td>
            <td>
                <%--   <div class="text_box" style="width: 130px;">
                    <asp:TextBox CssClass="textbox" ID="txtStitchingFactory" runat="server" ReadOnly="false"
                        Style="height: 20px;"></asp:TextBox>
                </div>--%>
            </td>
        </tr>
        <tr style="height: 34px;">
            <td>
                <div class="txt" style="width: 130px;">
                    Fabric</div>
            </td>
            <td>
                <asp:TextBox CssClass="textbox" ID="txtFabricContent" runat="server" ReadOnly="True"
                    TextMode="MultiLine" Width="200px"></asp:TextBox>
            </td>
            <td>
                <div class="txt" style="width: 130px;">
                    Item Desc.</div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox CssClass="textbox" ID="txtItem" runat="server" ReadOnly="True" Style="height: 20px;"></asp:TextBox></div>
            </td>
        </tr>
        <tr>
            <td>
                <div class="txt" style="width: 130px;">
                    Color</div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox CssClass="textbox" ID="txtCustColor" runat="server" ReadOnly="True"
                        Style="height: 20px;"></asp:TextBox>
                </div>
            </td>
            <td>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                </div>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlAccessSection" runat="server" Visible="true" Enabled="TRUE">
        <table width="100%">
            <tr class="heading">
                <td>
                    &nbsp; <b>Joborder Accessoriese Section </b>
                </td>
            </tr>
        </table>
        <table>
            <tr style="height: 45px;">
                <td>
                    <div class="txt_newwww" style="width: 100px;">
                        Assort Color
                    </div>
                </td>
                <td>
                    <div style="">
                        <asp:UpdatePanel ID="udpcmbAssortColor" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:DropDownList Style="margin-left: 5px" ID="cmbAssortColor" runat="server" Width="139px"
                                    AutoPostBack="true" CssClass="combo" OnSelectedIndexChanged="cmbAssortColor_SelectedIndexChanged1">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>
                <td>
                    <div class="txt_newwww" style="width: 85px;">
                        Assort QTY
                    </div>
                </td>
                <td>
                    <div style="">
                        <asp:UpdatePanel ID="udptxtdtlAssortQty" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtdtlAssortQty" runat="server" Width="70px" ReadOnly="true" CssClass="textbox"
                                    Style="margin-left: 5px;"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
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
            <tr style="height: 45px; display: none;">
                <td>
                    <div class="txt_newwww" style="width: 100px;">
                        Description
                    </div>
                </td>
                <td>
                    <div class="text_box" style="">
                        <asp:TextBox ID="txtDescription" runat="server" Width="295px" CssClass="textbox"
                            Style="height: 22px; margin-left: -538px; text-transform: uppercase;"></asp:TextBox>
                    </div>
                </td>
                <td>
                </td>
                <td>
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
        <table>
            <tr style="height: 45px;">
                <td>
                    <div class="txt_newwww" style="width: 100px;">
                        Item Cl.
                    </div>
                </td>
                <td>
                    <div class="txt_newwww" style="width: 100px;">
                        Access Cat.
                    </div>
                </td>
                <td>
                    <div class="txt_newwww" style="width: 150px;">
                        Access Name
                    </div>
                </td>
                <td>
                    <div class="txt_newwww" style="width: 75px;">
                        Usage/Pc
                    </div>
                </td>
                <td>
                    <div class="txt_newwww" style="width: 65px;">
                        Total
                    </div>
                </td>
                <td>
                    <div class="txt_newwww" style="width: 50px;">
                        Per %
                    </div>
                </td>
                <td>
                    <div class="txt_newwww" style="width: 80px;">
                        Order Qty
                    </div>
                </td>
                <td>
                    <div class="txt_newwww" style="width: 247px;">
                        Remarks
                    </div>
                </td>
            </tr>
            <tr style="height: 45px;">
                <td>
                    <div>
                        <asp:UpdatePanel ID="udpddlItemClass" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlItemClass" Width="100" CssClass="combo" AutoPostBack="true"
                                    runat="server" Style="">
                                </asp:DropDownList>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlItemClass" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </td>
                <td>
                    <div>
                        <asp:UpdatePanel ID="udpcmbAccessorieseType" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:DropDownList ID="cmbAccessorieseType" Width="100" CssClass="combo" AutoPostBack="true"
                                    runat="server" Style="">
                                </asp:DropDownList>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="cmbAccessoriese" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </td>
                <td>
                    <div style="">
                        <asp:UpdatePanel ID="udpcmbAccessoriese" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:DropDownList ID="cmbAccessoriese" Width="150" CssClass="combo" AutoPostBack="false"
                                    runat="server" Style="">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>
                <td>
                    <div class="text_box" style="">
                        <asp:UpdatePanel ID="udptxtPerPcsAvg" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtPerPcsAvg" runat="server" Width="76px" onkeypress="return isNumericKeyy(event);"
                                    CssClass="textbox" AutoPostBack="true" OnTextChanged="txtPerPcsAvg_TextChanged"
                                    Style="height: 22px;"></asp:TextBox>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="txtQty" EventName="TextChanged"></asp:AsyncPostBackTrigger>
                                <asp:AsyncPostBackTrigger ControlID="txtOrderQty" EventName="TextChanged"></asp:AsyncPostBackTrigger>
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </td>
                <td>
                    <div class="text_box" style="">
                        <asp:UpdatePanel ID="udptxtQty" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtQty" runat="server" Width="69px" onkeypress="return isNumericKeyy(event);"
                                    CssClass="textbox" Style="height: 22px;" AutoPostBack="true" OnTextChanged="txtQty_TextChanged"></asp:TextBox>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="txtOrderQty" EventName="TextChanged"></asp:AsyncPostBackTrigger>
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </td>
                <td>
                    <div class="text_box" style="">
                        <asp:UpdatePanel ID="udptxtPercentage" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtPercentage" runat="server" onkeypress="return isNumericKeyy(event);"
                                    AutoPostBack="true" Width="50px" CssClass="textbox" Style="height: 22px;"></asp:TextBox>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="txtQty" EventName="TextChanged" />
                                <asp:AsyncPostBackTrigger ControlID="txtOrderQty" EventName="TextChanged"></asp:AsyncPostBackTrigger>
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </td>
                <td>
                    <div class="text_box" style="">
                        <asp:UpdatePanel ID="UptxtOrderQty" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtOrderQty" runat="server" onkeypress="return isNumericKeyy(event);"
                                    AutoPostBack="true" Width="79px" CssClass="textbox" Style="height: 22px;"></asp:TextBox>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="txtQty" EventName="TextChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </td>
                <td>
                    <div class="text_box" style="">
                        <asp:TextBox ID="txtRemarks" runat="server" Width="250px" CssClass="textbox" Style="height: 22px;"></asp:TextBox>
                    </div>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr style="height: 45px;">
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnAddAccessoriese" CssClass="btn btn-outline btn-success" runat="server"
                        Text="Add Access" Style="margin-left: -115px;" />
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td>
                    <div id="dvidgAccCheckList" style="width: 930px; overflow: scroll">
                        <Smart:SmartDataGrid ID="dgAccCheckList" runat="server" Width="100%" AllowPaging="True"
                            AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                            PageSize="1000" ShowFooter="True" ForeColor="white" GridLines="both">
                            <Columns>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="AccCheckListDetailID"
                                    DataField="AccCheckListDetailID" Visible="false" />
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Description" DataField="Description"
                                    Visible="false">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="ITEM CODE.">
                                    <ItemStyle Width="2%" HorizontalAlign="Left"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtItemCode" runat="server" Width="140" AutoPostBack="true" CssClass="textbox"
                                            OnTextChanged="txtItemCode_TextChanged"></asp:TextBox>
                                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender56" runat="server" CompletionInterval="10"
                                            CompletionSetCount="12" ContextKey="CodeForAstore" EnableCaching="true" MinimumPrefixLength="1"
                                            ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtItemCode" />
                                        <asp:Label ID="lblItemID" runat="server" Width="10" Text="0" Visible="false"></asp:Label>
                                        <asp:Label ID="lblItemCategoryID" runat="server" Width="10" Text="0" Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="1%" HorizontalAlign="Center"></HeaderStyle>
                                </asp:TemplateColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="ItemClassName" DataField="ItemClassName"
                                    Visible="true">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Access. Cat." DataField="ItemCategoryName">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Accessoriese Name"
                                    DataField="ItemName" Visible="true">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Usage/PC" DataField="UsagePC">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Total" DataField="Total">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Percent" DataField="Percent">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Order Qty" DataField="OrderQty">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Remarks" DataField="Remarks">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="CalQTy" Visible="FALSE"
                                    DataField="CalQTy">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Assorted Size" DataField="AssortSize"
                                    Visible="true">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="StyleAssortmentDetailID"
                                    DataField="StyleAssortmentDetailID" Visible="FALSE">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="IMSItemClassID" DataField="IMSItemClassID"
                                    Visible="FALSE">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <%--   <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="IMSItemCategoryID"
                                    DataField="IMSItemCategoryID" Visible="true">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                               <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="ItemId" DataField="IMSItemId"
                                    Visible="true">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>--%>
                                <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="01%" HeaderText="EDIT"
                                    Visible="true">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="lnkEditAcc" ToolTip="Click here to edit" ImageUrl="~/Images/editIcon.jpg"
                                            CommandName="Edit" runat="server"></asp:ImageButton>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="Delete"
                                    Visible="true">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="lnkRemove" ToolTip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png"
                                            CommandName="Delete" runat="server"></asp:ImageButton>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                            </Columns>
                        </Smart:SmartDataGrid>
                    </div>
                </td>
            </tr>
        </table>
        <br />
        <table width="100%">
            <tr class="heading">
                <td>
                    &nbsp; <b>Zipper Section</b>
                </td>
            </tr>
        </table>
        <table>
            <tr style="height: 45px;">
                <td>
                    <div class="txt_newwww" style="width: 100px;">
                        Assort Color
                    </div>
                </td>
                <td>
                    <div style="">
                        <asp:UpdatePanel ID="UpcmbAssortColorZipper" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:DropDownList Style="margin-left: 5px" ID="cmbAssortColorZipper" runat="server"
                                    Width="139px" AutoPostBack="true" CssClass="combo" OnSelectedIndexChanged="cmbAssortColorZipper_SelectedIndexChanged1">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>
                <td>
                    <div class="txt_newwww" style="width: 85px;">
                        Assort QTY
                    </div>
                </td>
                <td>
                    <div style="">
                        <asp:UpdatePanel ID="UptxtAssortQTYZipper" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtAssortQTYZipper" runat="server" Width="70px" ReadOnly="true"
                                    CssClass="textbox" Style="margin-left: 5px;"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
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
            <tr style="height: 45px; display: none;">
                <td>
                    <div class="txt_newwww" style="width: 100px;">
                        Description
                    </div>
                </td>
                <td>
                    <div class="text_box" style="">
                        <asp:TextBox ID="txtDescriptionZipper" runat="server" Width="295px" CssClass="textbox"
                            Style="height: 22px; margin-left: -538px; text-transform: uppercase;"></asp:TextBox>
                    </div>
                </td>
                <td>
                </td>
                <td>
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
        <table>
            <tr style="height: 45px;">
                <td>
                    <div class="txt_newwww" style="width: 100px;">
                        Item Cl.
                    </div>
                </td>
                <td>
                    <div class="txt_newwww" style="width: 100px;">
                        Zipper Cat
                    </div>
                </td>
                <td>
                    <div class="txt_newwww" style="width: 150px;">
                        Zipper Name
                    </div>
                </td>
                <td>
                    <div class="txt_newwww" style="width: 75px;">
                        Usage/Pc
                    </div>
                </td>
                <td>
                    <div class="txt_newwww" style="width: 65px;">
                        Total
                    </div>
                </td>
                <td>
                    <div class="txt_newwww" style="width: 50px;">
                        Per %
                    </div>
                </td>
                <td>
                    <div class="txt_newwww" style="width: 80px;">
                        Order Qty
                    </div>
                </td>
                <td>
                    <div class="txt_newwww" style="width: 140px;">
                        Zipper sizes
                    </div>
                </td>
                <td>
                    <div class="txt_newwww" style="width: 160px;">
                        Remarks
                    </div>
                </td>
            </tr>
            <tr style="height: 45px;">
                <td>
                    <div>
                        <asp:UpdatePanel ID="upddlItemClass2" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlItemClass2" Width="100" CssClass="combo" AutoPostBack="true"
                                    runat="server" Style="">
                                </asp:DropDownList>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlItemClass2" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </td>
                <td>
                    <div>
                        <asp:UpdatePanel ID="UpcmbZipperCat" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:DropDownList ID="cmbZipperCat" Width="100" CssClass="combo" AutoPostBack="true"
                                    runat="server" Style="">
                                </asp:DropDownList>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="cmbAccessoriese" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </td>
                <td>
                    <div style="">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:DropDownList ID="cmbZipperNameZipper" Width="150" CssClass="combo" AutoPostBack="false"
                                    runat="server" Style="">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>
                <td>
                    <div class="text_box" style="">
                        <asp:UpdatePanel ID="UptxtPerPcsAvgZipper" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtPerPcsAvgZipper" onkeypress="return isNumericKeyy(event);" runat="server"
                                    Width="76px" CssClass="textbox" AutoPostBack="true" OnTextChanged="txtPerPcsAvgZipper_TextChanged"
                                    Style="height: 22px;"></asp:TextBox>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="txtQtyZipper" EventName="TextChanged"></asp:AsyncPostBackTrigger>
                                <asp:AsyncPostBackTrigger ControlID="txtOrderQtyZipper" EventName="TextChanged">
                                </asp:AsyncPostBackTrigger>
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </td>
                <td>
                    <div class="text_box" style="">
                        <asp:UpdatePanel ID="UptxtQtyZipper" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtQtyZipper" onkeypress="return isNumericKeyy(event);" runat="server"
                                    Width="69px" CssClass="textbox" Style="height: 22px;" AutoPostBack="true" OnTextChanged="txtQtyZipper_TextChanged"></asp:TextBox>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="txtOrderQtyZipper" EventName="TextChanged">
                                </asp:AsyncPostBackTrigger>
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </td>
                <td>
                    <div class="text_box" style="">
                        <asp:UpdatePanel ID="UptxtPercentageZipper" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtPercentageZipper" onkeypress="return isNumericKeyy(event);" runat="server"
                                    AutoPostBack="true" Width="50px" CssClass="textbox" Style="height: 22px;"></asp:TextBox>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="txtQtyZipper" EventName="TextChanged" />
                                <asp:AsyncPostBackTrigger ControlID="txtAssortQTYZipper" EventName="TextChanged">
                                </asp:AsyncPostBackTrigger>
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </td>
                <td>
                    <div class="text_box" style="">
                        <asp:UpdatePanel ID="UptxtOrderQtyZipper" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtOrderQtyZipper" onkeypress="return isNumericKeyy(event);" runat="server"
                                    AutoPostBack="true" Width="79px" CssClass="textbox" Style="height: 22px;"></asp:TextBox>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="txtQtyZipper" EventName="TextChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </td>
                <td>
                    <div class="text_box" style="">
                        <asp:TextBox ID="txtColorZippersizes" runat="server" Width="138px" CssClass="textbox"
                            Style="height: 22px;"></asp:TextBox>
                    </div>
                </td>
                <td>
                    <div class="text_box" style="">
                        <asp:TextBox ID="txtRemarksZipper" runat="server" Width="162px" CssClass="textbox"
                            Style="height: 22px;"></asp:TextBox>
                    </div>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr style="height: 45px;">
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnAddZipper" CssClass="btn btn-outline btn-success" runat="server"
                        Text="Add Zipper" Style="margin-left: -115px;" />
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td>
                    <div id="Div2" style="width: 930px; overflow: scroll">
                        <Smart:SmartDataGrid ID="dgZipper" runat="server" Width="100%" AllowPaging="True"
                            AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                            PageSize="1000" ShowFooter="True" ForeColor="white" GridLines="both">
                            <Columns>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="ZipperCheckListDetailID"
                                    DataField="ZipperCheckListDetailID" Visible="FALSE" />
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Description" DataField="Description"
                                    Visible="false">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="ITEM CODE.">
                                    <ItemStyle Width="2%" HorizontalAlign="Left"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtItemCodeForZipper" runat="server" Width="140" AutoPostBack="true"
                                            CssClass="textbox" OnTextChanged="txtItemCodeForZipper_TextChanged"></asp:TextBox>
                                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender56" runat="server" CompletionInterval="10"
                                            CompletionSetCount="12" ContextKey="CodeForAstoreZipper" EnableCaching="true"
                                            MinimumPrefixLength="1" ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx"
                                            TargetControlID="txtItemCodeForZipper" />
                                        <asp:Label ID="lblItemID" runat="server" Width="10" Text="0" Visible="false"></asp:Label>
                                        <asp:Label ID="lblItemCategoryID" runat="server" Width="10" Text="0" Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="1%" HorizontalAlign="Center"></HeaderStyle>
                                </asp:TemplateColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="ItemClassName" DataField="ItemClassName"
                                    Visible="true">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Zipper Cat." DataField="ItemCategoryName">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Zipper Name" DataField="ItemName"
                                    Visible="true">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Usage/PC" DataField="UsagePC">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Total" DataField="Total">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Percent" DataField="Percent">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Order Qty" DataField="OrderQty">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Remarks" DataField="Remarks">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="CalQTy" Visible="FALSE"
                                    DataField="CalQTy">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Assorted Size" DataField="AssortSize"
                                    Visible="true">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="StyleAssortmentDetailID"
                                    DataField="StyleAssortmentDetailID" Visible="FALSE">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Zipper Sizes" DataField="ColorZippersizes"
                                    Visible="true">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="IMSItemClassID" DataField="IMSItemClassID"
                                    Visible="FALSE">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <%--   <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="IMSItemCategoryID"
                                    DataField="IMSItemCategoryID" Visible="true">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                               <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="ItemId" DataField="IMSItemId"
                                    Visible="true">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>--%>
                                <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="01%" HeaderText="EDIT"
                                    Visible="true">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="lnkEditAcc" ToolTip="Click here to edit" ImageUrl="~/Images/editIcon.jpg"
                                            CommandName="Edit" runat="server"></asp:ImageButton>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="Delete"
                                    Visible="true">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="lnkRemove" ToolTip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png"
                                            CommandName="Delete" runat="server"></asp:ImageButton>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                            </Columns>
                        </Smart:SmartDataGrid>
                    </div>
                </td>
            </tr>
        </table>
        <br />
        <table width="100%">
            <tr class="heading">
                <td>
                    &nbsp; <b>Threads Section</b>
                </td>
            </tr>
        </table>
        <br />
        <table>
            <tr>
                <td>
                    <div class="txt_newwww">
                        Find Threads
                    </div>
                </td>
                <td>
                    <div class="text_box" style="">
                        <asp:UpdatePanel ID="UpThreadsCode" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="TXTThreadsCode" runat="server" Width="178px" CssClass="textbox"
                                    AutoPostBack="true" Style="height: 22px;"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="10"
                                    CompletionSetCount="12" ContextKey="SearchAccessThread" EnableCaching="true"
                                    MinimumPrefixLength="1" ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx"
                                    TargetControlID="TXTThreadsCode" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>
                <td>
                    <asp:Label ID="lblAccItemID" runat="server" Visible="false"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <table width="100%">
            <tr style="height: 45px;">
                <td style="width: 110px; display: none;">
                    <div class="txt_newwww" style="width: 100px;">
                        Desc.
                    </div>
                </td>
                <td style="width: 110px;">
                    <div class="txt_newwww" style="width: 100px;">
                        Color
                    </div>
                </td>
                <td style="width: 85px;">
                    <div class="txt_newwww" style="width: 75px;">
                        JP Shade #
                    </div>
                </td>
                <td style="width: 75px;">
                    <div class="txt_newwww" style="width: 65px;">
                        JP Code
                    </div>
                </td>
                <td style="width: 75px;">
                    <div class="txt_newwww" style="width: 65px;">
                        Count
                    </div>
                </td>
                <td style="width: 112px;">
                    <div class="txt_newwww" style="width: 105px;">
                        Mtr/1Con/Tube
                    </div>
                </td>
                <td style="width: 75px;">
                    <div class="txt_newwww" style="width: 65px;">
                        Order Qty
                    </div>
                </td>
                <td style="width: 75px;">
                    <div class="txt_newwww" style="width: 65px;">
                        Per %
                    </div>
                </td>
                <td style="width: 65px;">
                    <div class="txt_newwww" style="width: 55px;">
                        Qty pcs
                    </div>
                </td>
                <td style="width: 75px;">
                    <div class="txt_newwww" style="width: 65px;">
                        Consmp.
                    </div>
                </td>
                <td style="width: 75px;">
                    <div class="txt_newwww" style="width: 60px;">
                        R.Cones
                    </div>
                </td>
            </tr>
            <tr style="height: 34px;">
                <td style="display: none;">
                    <div class="text_box" style="">
                        <asp:UpdatePanel ID="UptxtDesc" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtDesc" runat="server" Text="N/A" Width="99px" CssClass="textbox"
                                    AutoPostBack="false" Style="height: 22px;"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>
                <td>
                    <div class="text_box" style="">
                        <asp:UpdatePanel ID="UpTxtThreadColor" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtThreadColor" runat="server" Width="99px" CssClass="textbox" AutoPostBack="false"
                                    Style="height: 22px;"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>
                <td>
                    <div class="text_box" style="">
                        <asp:UpdatePanel ID="UptxtJPShade" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtJPShade" runat="server" Width="76px" CssClass="textbox" Style="height: 22px;"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>
                <td>
                    <div class="text_box" style="">
                        <asp:UpdatePanel ID="UptxtJPCode" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtJPCode" runat="server" Width="69px" CssClass="textbox" Style="height: 22px;"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>
                <td>
                    <div class="text_box" style="">
                        <asp:UpdatePanel ID="UptxtCount" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtCount" runat="server" AutoPostBack="false" Width="69px" CssClass="textbox"
                                    Style="height: 22px;"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>
                <td>
                    <div class="text_box" style="">
                        <asp:UpdatePanel ID="UptxtMtrCon" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtMtrCon" runat="server" AutoPostBack="true" Width="105px" CssClass="textbox"
                                    Style="height: 22px;"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>
                <td>
                    <div class="text_box" style="">
                        <asp:UpdatePanel ID="UptxtOrderQtyForThread" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtOrderQtyForThread" runat="server" AutoPostBack="true" Width="69px"
                                    CssClass="textbox" Style="height: 22px;"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>
                <td>
                    <div class="text_box" style="">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtPerForThread" runat="server" AutoPostBack="true" Width="69px"
                                    CssClass="textbox" Style="height: 22px;"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>
                <td>
                    <div class="text_box" style="">
                        <asp:UpdatePanel ID="UptxtThreadQtyPcs" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtThreadQtyPcs" runat="server" AutoPostBack="true" Width="59px"
                                    CssClass="textbox" Style="height: 22px;"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>
                <td>
                    <div class="text_box" style="">
                        <asp:UpdatePanel ID="UptxtCons" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtCons" runat="server" AutoPostBack="true" Width="69px" CssClass="textbox"
                                    Style="height: 22px;"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>
                <td>
                    <div class="text_box" style="">
                        <asp:UpdatePanel ID="UptxtCones" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:TextBox ID="txtCones" Text="0" runat="server" AutoPostBack="false" Width="61px"
                                    ReadOnly="true" CssClass="textbox" Style="height: 22px;"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>
                <td>
                </td>
            </tr>
            <tr style="height: 45px;">
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnAddThread" CssClass="btn btn-outline btn-success" runat="server"
                        Text="Add" Style="margin-left: -115px;" />
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td>
                    <div id="Div1" style="width: 930px; overflow: scroll">
                        <Smart:SmartDataGrid ID="dgAccCheckListThread" runat="server" Width="100%" AllowPaging="True"
                            AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                            PageSize="1000" ShowFooter="True" ForeColor="white" GridLines="both">
                            <Columns>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="ThreadCheckListID"
                                    DataField="ThreadCheckListID" Visible="false" />
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Description" DataField="Description"
                                    Visible="false">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Color" DataField="ThreadColor">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="JP Shade #" DataField="JPShade"
                                    Visible="true">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="JP Code" DataField="JPCode">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Count" DataField="Count">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Mtr/1Con/Tube" DataField="Mtr1con">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Order Qty" DataField="OrderQtyForThread">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="% Per" DataField="PerForThread">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Qty Pcs" DataField="ThreadQtyPcs">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Consmp" DataField="Consumption">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="R.Cones" Visible="True"
                                    DataField="RCones">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="ItemID" Visible="false"
                                    DataField="ItemID">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="ItemCode" Visible="True"
                                    DataField="ItemCodee">
                                    <HeaderStyle HorizontalAlign="center" Width="5%" />
                                </asp:BoundColumn>
                                <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="01%" HeaderText="EDIT"
                                    Visible="true">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="lnkEditAcc" ToolTip="Click here to edit" ImageUrl="~/Images/editIcon.jpg"
                                            CommandName="Edit" runat="server"></asp:ImageButton>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="Delete"
                                    Visible="true">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="lnkRemove" ToolTip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png"
                                            CommandName="Delete" runat="server"></asp:ImageButton>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                            </Columns>
                        </Smart:SmartDataGrid>
                    </div>
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td align="right">
                    <asp:Button ID="btnsave" CssClass="btn btn-outline btn-success" runat="server" Text="Save"
                        Visible="true" Width="120px" />
                    <asp:Button ID="btnCancel" CssClass="btn btn-outline btn-danger" runat="server" Text="Cancel"
                        Visible="true" Width="120px" />
                    <asp:Label ID="lblAccCheclistMstId" runat="server" Text="0" Visible="false"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblThreadCheckListID" runat="server" Text="0" Visible="false"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblAccCheclistMstIdForEdit" runat="server" Text="0" Visible="false"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblZipperCheclistMstIdForEdit" runat="server" Text="0" Visible="false"></asp:Label>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
