<%@ Page Title="Fabric Consumption Entry" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="FabricConsumption.aspx.vb" Inherits="Integra.FabricConsumption" %>

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
    <div class="main_container">
        <br />
        <asp:Panel ID="pnlHalfPortion" runat="server" Enabled="true" Visible="true">
            <table width ="100%">
                <tr>
                    <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                        font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                        bgcolor="Silver">
                        FABRIC CONSUMPTION ENTRY
                    </th>
                </tr>
                </table> 
                      <table>
                <tr style="height: 30px;">
                    <td style="width: 180px;">
                        Type:
                    </td>
                    <td style="width: 160px;">
                    
                                <asp:DropDownList ID="cmbType" AutoPostBack="true" CssClass="combo" Width="133" runat="server"
                                    TabIndex="0">
                                </asp:DropDownList>
                        
                    </td>
                    <td>
                        Date:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCreationDate" CssClass="textbox" Width="129" runat="server" AutoPostBack="false"
                            Style="text-transform: uppercase;"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtCreationDate"
                            PopupButtonID="ImageButton1" />
                        <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" ImageUrl="~/Images/callendar.JPG"
                            AlternateText="Click here to display calendar" />
                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtCreationDate"
                            Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                            CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                            Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                        </cc1:MaskedEditExtender>
                    </td>
                </tr>
                  <tr>
                                <td style="width: 128px; height: 30px;">
                                    <asp:Label ID="Label21" runat="server" Text="Allow To GGT" Font-Bold="True" ForeColor="#336699"></asp:Label>
                                </td>
                                <td style="height: 30px; width: 128px;">
                                    <asp:CheckBox ID="ckhAllowToggtFromFStore" runat="server" Visible="false" Style="margin-left: -4px;" />
                                    <asp:CheckBox ID="ckhAllowToggtFromMerch" runat="server" Visible="false" Style="margin-left: -4px;" />
                                </td>
                            </tr>
                <tr style="height: 30px;">
                    <td>
                        Sr.No:
                    </td>
                    <td>
                        <asp:TextBox ID="txtSrNo" CssClass="textbox" AutoPostBack="true" runat="server" Style="width: 150px;
                            text-transform: uppercase;"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="10"
                            CompletionSetCount="12" ContextKey="SearchSRNoForFabricConsupmtion" EnableCaching="true"
                            MinimumPrefixLength="1" ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx"
                            TargetControlID="txtSrNo" />
                    </td>

                      <td>
                        Season:
                    </td>
                    <td>
                     
                      <telerik:RadComboBox ID="CMBSeason" runat="server" AutoPostBack="false" Skin="WebBlue">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td>
                        Buyer
                    </td>
                    <td>
                        <telerik:RadComboBox ID="cmbBuyer" runat="server" AutoPostBack="false" Skin="WebBlue">
                        </telerik:RadComboBox>
                    </td>
                    <td>
                        Style No:
                    </td>
                    <td>
                        <asp:TextBox ID="txtStyle" CssClass="textbox" runat="server" AutoPostBack="true"
                            Style="width: 150px; text-transform: uppercase;"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="10"
                            CompletionSetCount="12" ContextKey="SearchStyleNo" EnableCaching="true" MinimumPrefixLength="1"
                            ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtStyle" />
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td>
                        Description:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDesc" CssClass="textbox" runat="server" Style="width: 212px;
                            text-transform: uppercase;"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td>
                        Dal No:
                    </td>
                    <td>
                   <%--  <asp:TextBox ID="txtDalNoO" CssClass="textbox" runat="server" AutoPostBack="true"
                            Style="width: 150px; text-transform: uppercase;"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="autoComplete1" runat="server" CompletionInterval="10"
                            CompletionSetCount="12" ContextKey="SearchDalNo" EnableCaching="true" MinimumPrefixLength="1"
                            ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtDalNoO" />
                        <asp:Label ID="lblFabricMstId" runat="server" Text="0" Visible="false"></asp:Label>--%>
                        <asp:TextBox ID="txtDalNoO" CssClass="textbox" runat="server" AutoPostBack="true"
                            Style="width: 150px; text-transform: uppercase;"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="autoComplete1" runat="server" CompletionInterval="10"
                            CompletionSetCount="12" ContextKey="SearchDalRefNoFromFStore" EnableCaching="true" MinimumPrefixLength="1"
                            ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtDalNoO" />
                        <asp:Label ID="lblFabricMstId" runat="server" Text="0" Visible="false"></asp:Label>
                    </td>
                    <td>
                        Supplier
                    </td>
                    <td>
                        <telerik:RadComboBox ID="cmbSupplier" runat="server" AutoPostBack="false" Skin="WebBlue">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td>
                        Fabric Construction:
                    </td>
                    <td>
                        <asp:TextBox ID="txtfabricCons" TextMode="MultiLine" runat="server" Style="width: 220px;
                            text-transform: uppercase;"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td>
                        Finished Fabric Width:
                    </td>
                    <td>
                        <asp:TextBox ID="txtFabricwidth" CssClass="textbox" runat="server" Style="width: 150px;
                            text-transform: uppercase;"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td>
                        Shrinkage Approx:
                    </td>
                    <td>
                        <asp:TextBox ID="txtShrinkageApprox" CssClass="textbox" runat="server" Style="width: 150px;
                            text-transform: uppercase;"></asp:TextBox>
                    </td>
                </tr>
                <%--      <tr style="height: 30px;">
                        <td>
                            Sizes:
                        </td>
                        <td>
                            <asp:TextBox ID="txtsize" CssClass="textbox" runat="server" Style="width: 150px;
                                text-transform: uppercase;"></asp:TextBox>
                        </td>
                    </tr>--%>
                <tr style="height: 30px;">
                    <td>
                        Ratio:
                    </td>
                    <td>
                        <asp:TextBox ID="txtratio" CssClass="textbox" runat="server" Style="width: 150px;
                            text-transform: uppercase;"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td>
                        Total:
                    </td>
                    <td>
                        <asp:TextBox ID="txttotal" CssClass="textbox" runat="server" Style="width: 150px;
                            text-transform: uppercase;"></asp:TextBox>
                    </td>
                </tr>
                <%--   <tr style="height: 30px;">
                        <td>
                            Marker Length with Mtrs:
                        </td>
                        <td>
                            <asp:TextBox ID="txtmarkerlength" CssClass="textbox" runat="server" Style="width: 150px;
                                text-transform: uppercase;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height: 30px;">
                        <td>
                            Shrinkage:
                        </td>
                        <td>
                            <asp:TextBox ID="txtshrinkage" CssClass="textbox" runat="server" Style="width: 150px;
                                text-transform: uppercase;"></asp:TextBox>
                        </td>
                    </tr>--%>
            </table>
        </asp:Panel>
        <table>
            <%-- <tr style="height: 30px;">
                    <td>
                        New Inquiry Consumption:
                    </td>
                    <td>
                        <asp:TextBox ID="txtInqConsmp" CssClass="textbox" runat="server" Style="width: 150px;
                            text-transform: uppercase;"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td>
                        Other Consumption Per Piece:
                    </td>
                    <td>
                        <asp:TextBox ID="txtOtherConsmp" CssClass="textbox" runat="server" Style="width: 150px;
                            text-transform: uppercase;"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td>
                        Actual Consumption Per Piece:
                    </td>
                    <td>
                        <asp:TextBox ID="txtActualConsmp" CssClass="textbox" runat="server" Style="width: 150px;
                            text-transform: uppercase;"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td>
                        Mesh Per Piece:
                    </td>
                    <td>
                        <asp:TextBox ID="txtMesh" CssClass="textbox" runat="server" Style="width: 150px;
                            text-transform: uppercase;"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td>
                        Patch Pocket Per Piece:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPatchPocket" CssClass="textbox" runat="server" Style="width: 150px;
                            text-transform: uppercase;"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td>
                        Piping Per Piece:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPiping" CssClass="textbox" runat="server" Style="width: 150px;
                            text-transform: uppercase;"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td>
                        Contrast Fabric Per Piece:
                    </td>
                    <td>
                        <asp:TextBox ID="txtContrastFab" CssClass="textbox" runat="server" Style="width: 150px;
                            text-transform: uppercase;"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td>
                        Inside Belt Fabric:
                    </td>
                    <td>
                        <asp:TextBox ID="txtInsideBeltFab" CssClass="textbox" runat="server" Style="width: 150px;
                            text-transform: uppercase;"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td>
                        Pocket Lining Piece:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPocketlining" CssClass="textbox" runat="server" Style="width: 150px;
                            text-transform: uppercase;"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td>
                        Other:
                    </td>
                    <td>
                        <asp:TextBox ID="txtOther" CssClass="textbox" runat="server" Style="width: 150px;
                            text-transform: uppercase;"></asp:TextBox>
                    </td>
                </tr>--%>
            <tr>
                <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                    font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                    bgcolor="Silver">
                    Style Detail
                </th>
            </tr>
            <tr>
                <td style="height: 30px; width: 180px;">
                    <asp:Label ID="Label16" runat="server" Text="Description"></asp:Label>
                </td>
                <td style="width: 235px; height: 30px;">
                    <telerik:RadTextBox ID="txtStyleDescription" Style="text-transform: uppercase;" runat="server"
                        Width="105px" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
                <td style="height: 30px; width: 150px;" colspan="2">
                </td>
                <td style="width: 166px; height: 30px;">
                </td>
            </tr>
            <tr>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="lblSizes" runat="server" Text="Sizes"></asp:Label>
                </td>
                <td style="width: 150px; height: 30px;">
                    <telerik:RadTextBox ID="txtSizes" Style="text-transform: uppercase;" runat="server"
                        Width="105px" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="Label18" runat="server" Text="Width"></asp:Label>
                </td>
                <td style="width: 166px; height: 30px;">
                    <telerik:RadTextBox ID="txtStyleWidth" Width="105px" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="lblShrink" runat="server" Text="Shrinkage Length"></asp:Label>
                </td>
                <td style="width: 150px; height: 30px;">
                    <telerik:RadTextBox ID="txtShrink" Width="105px" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="Label19" runat="server" Text="Shrinkage Width"></asp:Label>
                </td>
                <td style="width: 166px; height: 30px;">
                    <telerik:RadTextBox ID="txtShrinkageWidth" Width="105px" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="lblMarket" runat="server" Text="Marker Length With Size"></asp:Label>
                </td>
                <td style="width: 150px; height: 30px;">
                    <telerik:RadTextBox ID="txtMarketLength" Width="105px" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
                <td style="height: 30px; width: 128px;">
                    <%--     <asp:Label ID="Label17" runat="server" Text="Price"></asp:Label>--%>
                </td>
                <td style="width: 166px; height: 30px;">
                    <%--  <telerik:radnumerictextbox id="txtStylePrice" width="105px" runat="server" skin="WebBlue"
                            type="Number" numberformat-decimaldigits="2">
                </telerik:radnumerictextbox>--%>
                </td>
            </tr>
            <tr>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="lblCons" runat="server" Text="Con. Per/Pcs"></asp:Label>
                </td>
                <td style="width: 300px; height: 30px;">
                    <telerik:RadNumericTextBox ID="txtConsumption" Width="105px" runat="server" Skin="WebBlue"
                        Type="Number" NumberFormat-DecimalDigits="2">
                    </telerik:RadNumericTextBox>
                    <telerik:RadComboBox ID="cmbUnit" runat="server" Enabled ="true" Visible="TRUE" Width="60px" AutoPostBack="false"
                        Skin="WebBlue">
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="lblOtherDtl" runat="server" Text="Other Detail"></asp:Label>
                </td>
                <td style="width: 150px; height: 30px;">
                    <telerik:RadTextBox ID="txtOtherDtl" Style="text-transform: uppercase;" runat="server"
                        Skin="WebBlue" TextMode="MultiLine">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadButton ID="BtnStyleDetail" runat="server" Width="100px" Text="Add Style Detail"
                        Skin="WebBlue">
                    </telerik:RadButton>
                    <asp:Label ID="lblDPRNDStyleDetailID" runat="server" Text="0" Visible="FALSE"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <telerik:RadGrid ID="DgStyleDetail" runat="server" CellSpacing="0" AutoGenerateColumns="false"
                        Skin="WebBlue" Visible="true" PageSize="50" AllowAutomaticDeletes="false">
                        <MasterTableView>
                            <Columns>
                                <telerik:GridBoundColumn HeaderText="FabricConsumptionDetailID" DataField="FabricConsumptionDetailID"
                                    Display="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="1%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Des." DataField="Description" Display="true">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="8%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Size" DataField="Size" Display="true">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="8%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Width" DataField="StyleWidth" Display="true">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Shrinkage Length" DataField="ShrinkageLength">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Shrinkage Width" DataField="ShrinkageWidth">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Marker Length With Size" DataField="MarkerLengthWithSize">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="8%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                              <%--  <telerik:GridBoundColumn HeaderText="Price" DataField="Price" Display="true">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>--%>
                                <telerik:GridBoundColumn HeaderText="Con. Per Pcs" DataField="ConsumptionPerPcs">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Other Detail" DataField="OtherDetail">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="10%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="ConsumptionUnitid" DataField="ConsumptionUnitid"
                                    Display="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="10%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Unit" DataField="Unit">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="10%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="Edit" UniqueName="Edit" AllowFiltering="false">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="lnkEdit" ToolTip="Click here to edit" ImageUrl="~/Images/editIcon.jpg"
                                            CommandName="Edit" runat="server"></asp:ImageButton>
                                    </ItemTemplate>
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridButtonColumn UniqueName="DeleteColumn" Text="" CommandName="Delete" Visible ="false" 
                                    ConfirmTextFormatString="Are You Sure You want to Delete Record" HeaderStyle-Width="5%"
                                    ButtonType="ImageButton">
                                </telerik:GridButtonColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
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
            <tr style="height: 30px;">
                <td>
                    Prepared By:
                </td>
                <td>
                    <asp:TextBox ID="txtPrepared1" CssClass="textbox" runat="server" Style="width: 250px;
                        text-transform: uppercase;"></asp:TextBox>
                </td>
                <td>
                </td>
                <td>
                    Director:
                </td>
                <td>
                    <asp:TextBox ID="txtPrepared2" CssClass="textbox" runat="server" Style="width: 250px;
                        text-transform: uppercase;"></asp:TextBox>
                </td>
            </tr>
            <tr style="height: 30px;">
                <td>
                    Pattern Master:
                </td>
                <td>
                    <asp:TextBox ID="txtPrepared3" CssClass="textbox" runat="server" Style="width: 250px;
                        text-transform: uppercase;"></asp:TextBox>
                </td>
                <td>
                </td>
                <td>
                    G.M:
                </td>
                <td>
                    <asp:TextBox ID="txtPrepared4" CssClass="textbox" runat="server" Style="width: 250px;
                        text-transform: uppercase;"></asp:TextBox>
                </td>
            </tr>
            <tr style="height: 30px;">
                <td>
                    Auditor:
                </td>
                <td>
                    <asp:TextBox ID="txtPrepared5" CssClass="textbox" runat="server" Style="width: 250px;
                        text-transform: uppercase;"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnSave" runat="server" Skin="WebBlue" Text="Save" Font-Bold="True"
                        Font-Names="Calibri" Font-Size="Medium" Height="30px" Width="120px" CausesValidation="true"
                        Visible="true" Style="margin-left: 320px;"></asp:Button>
                </td>
                <td>
                    <asp:Button ID="btncancel" runat="server" Skin="WebBlue" Text="Cancel" Font-Bold="True"
                        Font-Names="Calibri" Font-Size="Medium" Height="30px" Width="110px" Visible="true"
                        Style="margin-left: 10px;"></asp:Button>
                </td>
            </tr>
            <tr>
            <td>
            <asp:Label ID ="lblidd" runat ="server" Visible ="false"></asp:Label> 
            </td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="lblAllowToGgtFromFstore" runat="server" Visible="false"></asp:Label>
                </td>
            </tr>

               <tr>
                <td>
                    <asp:Label ID="lblAllowToGgtFromMerch" runat="server" Visible="false"></asp:Label>
                </td>
            </tr>
        </table>
        <table >
        <tr>
        <td>
          <asp:TextBox ID="txtEntryDate" CssClass="textbox" Width="129" runat="server" AutoPostBack="false"
                            Style="text-transform: uppercase;" Visible="false" ></asp:TextBox>
        </td>
        </tr>
        </table>
        <table>
        <tr>
         <td>
                    <asp:Label ID="lblTaskNo" runat="server" Visible="false"></asp:Label>
                </td>

                <td>
                    <asp:Label ID="lblProirty" runat="server" Visible="false"></asp:Label>
                </td>
        </tr>

        <tr>
            <td align="center">
              <asp:Label ID ="lblUserId" runat ="server" Visible ="false" Text="0"></asp:Label>
            </td>
        </tr>

        </table>
    </div>
</asp:Content>
