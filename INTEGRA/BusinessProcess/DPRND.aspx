<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="DPRND.aspx.vb" Inherits="Integra.DPRND" %>

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
    <div>
        <asp:Panel ID="PanelFabric" runat="server" Enable="true">
            <table width="100%">
                <tr>
                    <td width="60%">
                        <table width="100%">
                            <tr>
                                <td style="width: 110px;">
                                    Creation Date
                                </td>
                                <td style="width: 110px;">
                                    <telerik:RadDatePicker ID="txtCreationDatee" runat="server" Culture="en-US" Width="100px">
                                        <Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                                        </Calendar>
                                        <DateInput ID="DateInput1" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                                            LabelWidth="40%">
                                        </DateInput>
                                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                    </telerik:RadDatePicker>
                                </td>
                                <td style="width: 128px; height: 30px;">
                                    <asp:Label ID="lblBuyer" runat="server" Text="Buyer"></asp:Label>
                                </td>
                                <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                                    <telerik:RadTextBox ID="txtBuyer" runat="server" Skin="WebBlue" Width="105px" Visible="false">
                                    </telerik:RadTextBox>
                                    <telerik:RadComboBox ID="cmbBuyer" EnableLoadOnDemand="true" Filter="StartsWith" runat="server" AutoPostBack="false" Skin="WebBlue">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 110px;">
                                    Creation Time
                                </td>
                                <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                                    <asp:TextBox ID="txtCreationTime" runat="server" autocomplete="off" ReadOnly="true"
                                        AutoPostBack="true" Style="margin-left: 0px; width: 100px;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 128px; height: 30px;">
                                    <asp:Label ID="Label21" runat="server" Text="Allow To GGT" Font-Bold="True" ForeColor="#336699"></asp:Label>
                                </td>
                                <td style="height: 30px; width: 128px;">
                                    <asp:CheckBox ID="ckhAllowToggt" runat="server" Visible="true" Style="margin-left: -4px;" />
                                </td>
                                <td style="width: 128px; height: 30px;">
                                    <asp:Label ID="Label23" runat="server" Text="Lock To GGT" Font-Bold="True" ForeColor="#336699"></asp:Label>
                                </td>
                                <td style="height: 30px; width: 128px;">
                                    <asp:CheckBox ID="chklocktoggt" runat="server" Visible="true" Style="margin-left: -4px;" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 85px; height: 30px;">
                                    <asp:Label ID="lblStyle" runat="server" Text="Style"></asp:Label>
                                </td>
                                <td style="width: 165px; height: 30px;">
                                    <asp:TextBox ID="txtStyle" runat="server" autocomplete="off" AutoPostBack="true"
                                        Style="margin-left: 0px; width: 150px;"></asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="10"
                                        CompletionSetCount="12" ContextKey="SearchStyleNo" EnableCaching="true" MinimumPrefixLength="1"
                                        ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtStyle" />
                                </td>
                                <td style="width: 87px; height: 30px;">
                                    <asp:Label ID="lblDept" runat="server" Text="Dept."></asp:Label>
                                </td>
                                <td style="height: 30px">
                                    <telerik:RadTextBox ID="txtDept" runat="server" Skin="WebBlue" Width="105px">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 30px; width: 87px;">
                                    <asp:Label ID="lblDalNo" runat="server" Text="DAL No."></asp:Label>
                                </td>
                                <td style="height: 30px">
                                    <%--  <telerik:RadTextBox ID="txtDalNo" Width="105px" runat="server" Skin="WebBlue">
                        </telerik:RadTextBox>--%>
                                    <asp:TextBox ID="txtDalNoO" runat="server" autocomplete="off" AutoPostBack="true"
                                        Style="margin-left: 0px; width: 150px;"></asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="autoComplete1" runat="server" CompletionInterval="10"
                                        CompletionSetCount="12" ContextKey="SearchDalNo" EnableCaching="true" MinimumPrefixLength="1"
                                        ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtDalNoO" />
                                    <asp:Label ID="lblFabricMstId" runat="server" Text="0" Visible="false"></asp:Label>
                                </td>
                                <td style="height: 30px; width: 85px;">
                                    <asp:Label ID="lblQTy" runat="server" Text="Quantity"></asp:Label>
                                </td>
                                <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                                    <telerik:RadNumericTextBox ID="txtQty" runat="server" Skin="WebBlue" Width="105px"
                                        Type="Number" NumberFormat-DecimalDigits="2">
                                    </telerik:RadNumericTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 30px; width: 128px;">
                                    <asp:Label ID="lblSize" runat="server" Text="Size"></asp:Label>
                                </td>
                                <td style="width: 166px; height: 30px;">
                                    <telerik:RadTextBox ID="txtSize" runat="server" Skin="WebBlue" Width="105px">
                                    </telerik:RadTextBox>
                                </td>
                                <td style="height: 30px; width: 128px;">
                                    <asp:Label ID="Label20" runat="server" Text="Buyer Ref#"></asp:Label>
                                </td>
                                <td style="width: 166px; height: 30px;">
                                    <telerik:RadTextBox ID="txtBuyerReferenceNo" ReadOnly="true" runat="server" Skin="WebBlue"
                                        Width="105px">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 30px; width: 128px;">
                                    <asp:Label ID="lblPattern" runat="server" Text="Pattern"></asp:Label>
                                </td>
                                <td style="width: 166px; height: 30px;">
                                    <telerik:RadTextBox ID="txtPatern" runat="server" Skin="WebBlue" Width="105px">
                                    </telerik:RadTextBox>
                                </td>
                                <td style="height: 30px; width: 128px;">
                                    <asp:Label ID="lblWidth" runat="server" Text="Width"></asp:Label>
                                </td>
                                <td style="width: 166px; height: 30px;">
                                    <telerik:RadTextBox ID="txtWidthCuteable" runat="server" Skin="WebBlue" Width="105px">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 30px; width: 128px;">
                                    <asp:Label ID="lblWashing" runat="server" Text="Washing Detail"></asp:Label>
                                </td>
                                <td style="width: 166px; height: 30px;">
                                    <telerik:RadTextBox ID="txtWasshDtl" runat="server" Skin="WebBlue" TextMode="MultiLine">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 30px; width: 128px;">
                                    <asp:Label ID="lblPocket" runat="server" Text="Pocket lining" Visible="true"></asp:Label>
                                </td>
                                <td style="width: 166px; height: 30px;">
                                    <telerik:RadTextBox ID="txtpocketLining" runat="server" Skin="WebBlue" Width="105px"
                                        Visible="true" Style="text-transform: uppercase;">
                                    </telerik:RadTextBox>
                                </td>
                                <td style="height: 30px; width: 128px;">
                                    <asp:Label ID="Label22" runat="server" Text="Thread"></asp:Label>
                                </td>
                                <td style="width: 166px; height: 30px;">
                                    <telerik:RadTextBox ID="txtThreads" Style="text-transform: uppercase;" runat="server"
                                        Skin="WebBlue" Width="105px">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 30px; width: 128px;">
                                    <asp:Label ID="Label12" runat="server" Text="Accessories"></asp:Label>
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
                                        <ContentTemplate>
                                            <telerik:RadComboBox ID="cmbACCESSORIES" EnableLoadOnDemand="true" Filter="StartsWith" runat="server" AutoPostBack="false" Skin="WebBlue">
                                            </telerik:RadComboBox>
                                            <telerik:RadTextBox ID="txtThread" runat="server" Visible="false" Skin="WebBlue"
                                                Width="105px">
                                            </telerik:RadTextBox>
                                      
                                            <asp:ImageButton ID="btnAddAccess" runat="server" ImageUrl="~/Images/Add.png" Style="height: 25px;
                                                margin-bottom: -9px;"></asp:ImageButton>
                                            <asp:ImageButton ID="btnSaveAccess" runat="server" ImageUrl="~/Images/SaveButton.jpg"
                                                Style="height: 25px; margin-bottom: -9px;" Visible="false"></asp:ImageButton>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 30px; width: 128px;">
                                    <asp:Label ID="Label14" runat="server" Text="Cons."></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="txtConsPer" runat="server" Visible="TRUE" Skin="WebBlue"
                                        Width="105px" Type="Number" NumberFormat-DecimalDigits="2">
                                    </telerik:RadNumericTextBox>
                                </td>
                                <td style="height: 30px; width: 128px;">
                                    <asp:Label ID="Label15" runat="server" Text="Price"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox ID="txtPrice" runat="server" Visible="TRUE" Skin="WebBlue"
                                        Width="105px" Type="Number" NumberFormat-DecimalDigits="2">
                                    </telerik:RadNumericTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 30px; width: 128px;">
                                    <asp:Label ID="Label13" runat="server" Text="Description"></asp:Label>
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtDescription" runat="server" Visible="TRUE" Skin="WebBlue"
                                        Width="250px">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadButton ID="btnAddAccessories" runat="server" Text="Add Accessories" Skin="WebBlue"
                                        Width="100px">
                                    </telerik:RadButton>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <telerik:RadGrid ID="dgAccess" runat="server" CellSpacing="0" AutoGenerateColumns="false"
                                        Skin="WebBlue" Visible="true" PageSize="50" AllowAutomaticDeletes="false" OnDeleteCommand="dgAccess_DeleteCommand">
                                        <MasterTableView>
                                            <Columns>
                                                <telerik:GridBoundColumn HeaderText="DPRNDAccessDetailID" DataField="DPRNDAccessDetailID"
                                                    Display="false">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="DPItemDatabaseID" DataField="DPItemDatabaseID"
                                                    Display="false">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="DPRNDID" DataField="DPRNDID" Display="false">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Item Name" DataField="ItemName">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="DESCRIPTION" DataField="DESCRIPTION">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="CONS." DataField="CONSPER">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn HeaderText="Price" DataField="Price" Display="true">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridButtonColumn UniqueName="DeleteColumn" Text="" CommandName="Delete"
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
                            <tr>
                                <td style="height: 30px; width: 128px;">
                                </td>
                                <td colspan="2" style="height: 30px; width: 128px;">
                                    <asp:FileUpload ID="FileUpload2" runat="server" />
                                </td>
                                <td>
                                    <asp:Button ID="btnUpload" runat="server" Style="width: 76px; margin-left: -50px;"
                                        Text="Upload" />
                                    <asp:UpdatePanel ID="UpPic" runat="server" ChildrenAsTriggers="true">
                                        <ContentTemplate>
                                            <asp:LinkButton ID="lnkFIlePicture" runat="server" Style="margin-left: 18px;" Text="Show Picture"
                                                Visible="false"> </asp:LinkButton>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 30px; width: 128px;">
                                    <asp:Label ID="Label11" runat="server" Text="Tech Pack"></asp:Label>
                                </td>
                                <td colspan="2" style="height: 30px; width: 128px;">
                                    <asp:FileUpload ID="FileUploadTechPack" runat="server" />
                                </td>
                                <td>
                                    <asp:Button ID="Button1" runat="server" Style="width: 76px; margin-left: -50px;"
                                        Text="Upload" />
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true">
                                        <ContentTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" Style="margin-left: 18px;" Text="Show Picture"
                                                Visible="false"> </asp:LinkButton>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 30px; width: 128px;">
                                    <asp:Label ID="lblRemarks" runat="server" Text="Remarks"></asp:Label>
                                </td>
                                <td style="width: 166px; height: 30px;">
                                    <telerik:RadTextBox ID="txtRemarks" Style="font-size: larger; text-transform: uppercase;"
                                        Font-Bold="true" runat="server" Skin="WebBlue" TextMode="MultiLine">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                </tr>
        </asp:Panel>
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Style Detail
            </th>
        </tr>
        <tr>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="Label16" runat="server" Text="Description"></asp:Label>
            </td>
            <td style="width: 150px; height: 30px;">
                <telerik:RadTextBox ID="txtStyleDescription" Style="text-transform: uppercase;" runat="server"
                    Width="105px" Skin="WebBlue">
                </telerik:RadTextBox>
            </td>
            <td style="height: 30px; width: 128px;" colspan="2">
                <asp:CheckBox ID="chkBodyFabric" runat="server" Font-Bold="True" Visible="true" Text="Is Body Fabric" />
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
                <asp:Label ID="Label17" runat="server" Text="Price"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadNumericTextBox ID="txtStylePrice" Width="105px" runat="server" Skin="WebBlue"
                    Type="Number" NumberFormat-DecimalDigits="2">
                </telerik:RadNumericTextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="lblCons" runat="server" Text="Consumption Per/Pcs"></asp:Label>
            </td>
            <td style="width: 150px; height: 30px;">
                <telerik:RadNumericTextBox ID="txtConsumption" Width="105px" runat="server" Skin="WebBlue"
                    Type="Number" NumberFormat-DecimalDigits="3">
                </telerik:RadNumericTextBox>
                <telerik:RadComboBox ID="cmbUnit" runat="server" Visible="false" Width="60px" AutoPostBack="false"
                    Skin="WebBlue">
                </telerik:RadComboBox>
            </td>
             <td style="height: 30px; width: 128px;" colspan="2">
              <asp:CheckBox ID="chkDigitalSignature" runat="server" Font-Bold="True" Visible="true" Text="Digital Signature" />
            </td>
              <td style="width: 166px; height: 30px;">
           
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
                <telerik:RadButton ID="BtnStyleDetail" runat="server" Width="130px" Text="Add Style Detail"
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
                            <telerik:GridBoundColumn HeaderText="DPRNDStyleDetailID" DataField="DPRNDStyleDetailID"
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
                            <telerik:GridBoundColumn HeaderText="Price" DataField="Price" Display="true">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Con. Per Pcs" DataField="ConsumptionPerPcs">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Other Detail" DataField="OtherDetail">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="10%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Is Body Fabric" DataField="IsBodyFabric" Display="false">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="1%" HorizontalAlign="Left" />
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
                            <telerik:GridTemplateColumn HeaderText="Is Body Fabric" UniqueName="IsBodyFabricc"
                                AllowFiltering="false">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server"></asp:CheckBox>
                                </ItemTemplate>
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Edit" UniqueName="Edit" AllowFiltering="false">
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkEdit" ToolTip="Click here to edit" ImageUrl="~/Images/editIcon.jpg"
                                        CommandName="Edit" runat="server"></asp:ImageButton>
                                </ItemTemplate>
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridButtonColumn UniqueName="DeleteColumn" Text="" CommandName="Delete"
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
        <tr>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="lblFabric" runat="server" Text="Fabric Price"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadNumericTextBox ID="txtFabricPrice" Width="105px" runat="server" Skin="WebBlue"
                    Type="Number" NumberFormat-DecimalDigits="2">
                </telerik:RadNumericTextBox>
            </td>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="Label6" runat="server" Text="Garment Price"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadNumericTextBox ID="txtGarmentPrice" Width="105px" runat="server" Skin="WebBlue"
                    Type="Number" NumberFormat-DecimalDigits="2">
                </telerik:RadNumericTextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 30px; width: 128px;">
            </td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
            <td colspan="2">
                <asp:Button ID="btnUploadGDP" runat="server" Style="width: 76px; margin-left: -50px;"
                    Text="Upload" />
                <asp:UpdatePanel ID="upgdp" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <asp:LinkButton ID="btnShowGdpImage" Text="Show Picture" Style="margin-left: 18px;"
                            runat="server" Visible="false"> </asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
            </td>
        </tr>
        </table> </td>
        <td width="40%">
            <asp:Panel ID="pnldd" runat="server" Enabled="true">
                <table width="100%" style="margin-top: -149px;">
                    <tr>
                        <td style="width: 85px; height: 30px;" align="left">
                            <asp:Label ID="Label1" runat="server" Text="Available Fabric"></asp:Label>
                        </td>
                        <td style="width: 165px; height: 30px;">
                            <telerik:RadTextBox ID="txtAvailFab" runat="server" Width="105px" Skin="WebBlue"
                                ReadOnly="true">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                            font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                            bgcolor="Silver">
                            Fabric Information
                        </th>
                    </tr>
                    <tr>
                        <td style="width: 87px; height: 30px;">
                            <asp:Label ID="Label2" runat="server" Text="Supplier Ref.No."></asp:Label>
                        </td>
                        <td style="height: 30px">
                            <telerik:RadTextBox ID="txtSupplierRef" runat="server" Skin="WebBlue" Width="175px"
                                ReadOnly="true">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 85px; height: 30px;" align="left">
                            <asp:Label ID="Label3" runat="server" Text="Supplier Name"></asp:Label>
                        </td>
                        <td style="width: 165px; height: 30px;">
                            <telerik:RadTextBox ID="txtSupplierName" runat="server" ReadOnly="true" Width="258px"
                                Skin="WebBlue">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 87px; height: 30px;">
                            <asp:Label ID="Label4" runat="server" Text="Quality"></asp:Label>
                        </td>
                        <td style="height: 30px">
                            <telerik:RadTextBox ID="txtQuality" runat="server" Skin="WebBlue" Width="258px" ReadOnly="true">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 85px; height: 30px;" align="left">
                            <asp:Label ID="Label5" runat="server" Text="Composition"></asp:Label>
                        </td>
                        <td style="width: 165px; height: 30px;">
                            <telerik:RadTextBox ID="txtComposition" runat="server" Width="258px" Skin="WebBlue"
                                ReadOnly="true">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 87px; height: 30px;">
                            <asp:Label ID="Label7" runat="server" Text="Colour"></asp:Label>
                        </td>
                        <td style="height: 30px">
                            <telerik:RadTextBox ID="txtColour" runat="server" Skin="WebBlue" Width="175px" ReadOnly="true">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 85px; height: 30px;" align="left">
                            <asp:Label ID="Label8" runat="server" Text="Width"></asp:Label>
                        </td>
                        <td style="width: 165px; height: 30px;">
                            <telerik:RadTextBox ID="txtWidth" runat="server" Width="175px" Skin="WebBlue" ReadOnly="true">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 87px; height: 30px;">
                            <asp:Label ID="Label9" runat="server" Text="Wash/Dye"></asp:Label>
                        </td>
                        <td style="height: 30px">
                            <telerik:RadTextBox ID="txtDye" runat="server" Skin="WebBlue" Width="175px" ReadOnly="true">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 85px; height: 30px;" align="left">
                            <asp:Label ID="Label10" runat="server" Text="Finish"></asp:Label>
                        </td>
                        <td style="width: 165px; height: 30px;">
                            <telerik:RadTextBox ID="txtFinish" runat="server" Width="175px" Skin="WebBlue" ReadOnly="true">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                </table>
        </td>
        </tr> </asp:Panel> </table>
        <table>
            <tr>
                <td>
                    <asp:CheckBox ID="ChkIsActive" runat="server" Font-Bold="True" Visible="false" Text="Is Active" />
                </td>
                <td>
                </td>
                <td colspan="2" align="right">
                    <telerik:RadButton ID="btnSave" runat="server" Text="Save" Skin="WebBlue">
                    </telerik:RadButton>
                </td>
                <td>
                    &nbsp;
                    <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" Skin="WebBlue">
                    </telerik:RadButton>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblAllowToGgt" runat="server" Visible="false"></asp:Label>
                </td>

                <td>
                    <asp:Label ID="lblTaskNo" runat="server" Visible="false"></asp:Label>
                </td>

                <td>
                    <asp:Label ID="lblProirty" runat="server" Visible="false"></asp:Label>
                </td>
                 <td>
                    <asp:Label ID="lblssssssss" runat="server" Visible="false" Text="0" ></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
