<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="CuttingProgramEntry.aspx.vb" Inherits="Integra.CuttingProgramEntry" %>

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
    <table width="100%">
        <tr style="height: 30px;" class="heading">
            <td>
                <b>Cutting Program </b>
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
    <tr>
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
            <td style="width:150px;">
                <div class="txt" style ="width :130px;">
                    PO No.</div>
            </td>
            <td style="width:250px;">   
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox CssClass="textbox" ID="txtSRNo" style="height :20px;" runat="server" ReadOnly="True"></asp:TextBox></div>
            </td>
            <td style="width:150px;">
                <div class="txt" style ="width :130px;">
                    Style</div>
            </td>
            <td> <div class="text_box" style="width: 130px;">
                <asp:TextBox CssClass="textbox" ID="txtStyle" style="height :20px;" runat="server" ReadOnly="True"></asp:TextBox></div>
            </td>
        </tr>
        <tr style ="height :34px;">
            <td>
                <div class="txt" style ="width :130px;">
                    Customer</div>
            </td>
            <td>
             <div class="text_box" style="width: 130px;">
                <asp:TextBox CssClass="textbox" ID="txtCustomer" style="height :20px;" runat="server" ReadOnly="True"></asp:TextBox>
                </div> 
            </td>
            <td>
                <div class="txt" style ="width :130px;">
                    Quantity</div>
            </td>
            <td>
             <div class="text_box" style="width: 130px;">
                <asp:TextBox ID="txtQuantity" CssClass="textbox"  style="height :20px;" runat="server" ReadOnly="True"></asp:TextBox>
                </div> 
            </td>
        </tr>
        <tr>
            <td>
                <div class="txt" style ="width :130px;">
                    Stitching Factory</div>
            </td>
            <td>
             <div class="text_box" style="width: 130px;">
                <asp:TextBox CssClass="textbox" ID="txtStitchingFactory" runat="server" ReadOnly="false" style="height :20px;" ></asp:TextBox>
                </div> 
            </td>
            <td>
                <div class="txt" style ="width :130px;">
                    Stitching Start</div>
            </td>
            <td> <div class="text_box" style="width: 130px;">
                <asp:TextBox ID="txtStitchingStart" CssClass="textbox" Width="120" runat="server" style="height :20px;"></asp:TextBox></div> 
                <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtStitchingStart"
                    PopupButtonID="ImageButton1" />
                <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                    AlternateText="Click here to display calendar" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtStitchingStart"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>
            </td>
        </tr>
        <tr style="height :34px;" >
            <td>
                <div class="txt" style ="width :130px;">
                    Fabric</div>
            </td>
            <td>
                <asp:TextBox CssClass="textbox" ID="txtFabricContent" runat="server" ReadOnly="True"
                    TextMode="MultiLine" Width="200px"></asp:TextBox>
            </td>
            <td>
                <div class="txt" style ="width :130px;">
                    Item Desc.</div>
            </td>
            <td> <div class="text_box" style="width: 130px;">
                <asp:TextBox CssClass="textbox" ID="txtItem" runat="server" ReadOnly="True" style="height :20px;" ></asp:TextBox></div> 
            </td>
        </tr>
        <tr style="height :34px;">
            <td>
                <div class="txt" style ="width :130px;">
                    Extra Qty %</div>
            </td>
            <td> <div class="text_box" style="width: 130px;">
                <asp:TextBox ID="txtExtaQty" CssClass="textbox" runat="server" AutoPostBack ="true"  ReadOnly="false" style="height :20px;" onkeypress="return isNumericKey(event);"></asp:TextBox>
            </div> </td>
            <td>
                <div class="txt" style ="width :130px;">
                    Color</div>
            </td>
            <td> <div class="text_box" style="width: 130px;">
                <asp:TextBox CssClass="textbox" ID="txtCustColor" runat="server" ReadOnly="True" style="height :20px;"></asp:TextBox>
                </div> 
            </td>
        </tr>

         <tr style="height :34px;">
            <td>
                <div class="txt" style ="width :130px;">
                   Pocket Lining Code</div>
            </td>
            <td> <div class="text_box" style="width: 130px;">
                     <asp:TextBox ID="txtPocketLiningCode" runat="server"  AutoPostBack ="true"  CssClass="textbox"  ></asp:TextBox>
                                   <cc1:AutoCompleteExtender ID="AutoCompleteExtender56" runat="server" CompletionInterval="10"
                                    CompletionSetCount="12" ContextKey="ItemFromJobOrder" EnableCaching="true"
                                    MinimumPrefixLength="1" ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx"
                                    TargetControlID="txtPocketLiningCode" />
                                    <asp:Label ID="lblPocketLiningID" runat="server" Width="10" Text ="0" Visible ="false"   ></asp:Label>
            </div> </td>
            <td>
                <div class="txt" style ="width :130px;">
                    Pocket Lining</div>
            </td>
            <td> <div class="text_box" style="width: 130px;">
                <asp:TextBox CssClass="textbox" ID="txtPocketLining" runat="server" ReadOnly="True" style="height :20px; width: 375px;"></asp:TextBox>
                </div> 
            </td>
        </tr>

         <tr>
            <td>
                <div class="txt" style ="width :130px;">
                   Other Fabric Code</div>
            </td>
            <td> <div class="text_box" style="width: 130px;">
                     <asp:TextBox ID="txtOtherFabricCode" runat="server"  AutoPostBack ="true"  CssClass="textbox"  ></asp:TextBox>
                                   <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="10"
                                    CompletionSetCount="12" ContextKey="ItemFromJobOrder" EnableCaching="true"
                                    MinimumPrefixLength="1" ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx"
                                    TargetControlID="txtOtherFabricCode" />
                                    <asp:Label ID="lblOtherFabricID" runat="server" Width="10" Text ="0" Visible ="false"   ></asp:Label>
            </div> </td>
            <td>
                <div class="txt" style ="width :130px;">
                    Other Fabric</div>
            </td>
            <td> <div class="text_box" style="width: 130px;">
                <asp:TextBox CssClass="textbox" ID="txtOtherFabric" runat="server" ReadOnly="True" style="height :20px; width: 375px;"></asp:TextBox>
                </div> 
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td>
                <Smart:SmartDataGrid ID="dgStyleAssortment" runat="server" Width="100%" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                    PageSize="1000" ShowFooter="True" ForeColor="white" GridLines="both">
                    <Columns>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="CuttingProDetailID"
                            DataField="CuttingProDetailID" Visible="false" />
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="StyleAssortmentDetailID"
                            DataField="StyleAssortmentDetailID" Visible="false" />
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="SizeRangeID"
                            DataField="SizeRangeID" Visible="false" />
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="SizeDatabaseID"
                            DataField="SizeDatabaseID" Visible="false" />
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="12%" HeaderText="Size"
                            DataField="Sizes">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="12%" HeaderText="Qty"
                            DataField="TotalQty"  DataFormatString="{0:f0}" >
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="01%" HeaderText="Remove"
                            Visible="false">
                            <ItemTemplate>
                                <asp:ImageButton ID="lnkRemove" ToolTip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png"
                                    CommandName="Remove" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                    <PagerStyle HorizontalAlign="NotSet" />
                </Smart:SmartDataGrid>
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td align="center">
                <asp:Button ID="btnsave" runat="server" CssClass="button" Visible="true" Text="Save">
                </asp:Button>
                <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel"></asp:Button>
                <asp:Label ID="lblCuttingProMasterID" runat="server" Text="0" Visible="false"></asp:Label>
            </td>
        </tr>
           <tr>
            <td align="center">
              <asp:Label ID ="lblUserId" runat ="server" Visible ="false" Text="0"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
