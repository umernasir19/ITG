<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="DPFabricIssueAdd.aspx.vb" Inherits="Integra.DPFabricIssueAdd" %>

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
        <table width="100%">
            <tr>
                <td width="60%">
                    <table width="100%">
                        <tr>
                            <td style="height: 30px; width: 87px;">
                                <asp:Label ID="lblDalNo" runat="server" Text="DAL No."></asp:Label>
                            </td>
                            <td style="height: 30px">
                                <asp:TextBox ID="txtDalNoO" runat="server" autocomplete="off" AutoPostBack="true"
                                    Style="margin-left: 0px; width: 150px;"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="autoComplete1" runat="server" CompletionInterval="10"
                                    CompletionSetCount="12" ContextKey="SearchDalNo" EnableCaching="true" MinimumPrefixLength="1"
                                    ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtDalNoO" />
                                <asp:Label ID="lblFabricMstId" runat="server" Text="0" Visible="false"></asp:Label>
                            </td>
                            <td style="height: 30px; width: 85px;">
                                <asp:Label ID="Label6" runat="server" Text="Style No."></asp:Label>
                            </td>
                            <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                                <asp:UpdatePanel ID="UpcmbStyleNo" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>
                                        <telerik:RadComboBox ID="cmbStyleNo" runat="server" AutoPostBack="True" Skin="WebBlue">
                                        </telerik:RadComboBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                                bgcolor="Silver">
                                Issue
                            </th>
                        </tr>
                        <tr>
                            <td style="height: 30px; width: 128px;">
                                <asp:Label ID="lblSize" runat="server" Text="Creation Date"></asp:Label>
                            </td>
                            <td style="width: 166px; height: 30px;">
                                <telerik:RadDatePicker ID="txtCreationDatee" runat="server" Culture="en-US" Width="100px">
                                    <Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                                    </Calendar>
                                    <DateInput ID="DateInput1" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                                        LabelWidth="40%">
                                    </DateInput>
                                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                </telerik:RadDatePicker>
                            </td>
                            <td style="height: 30px; width: 80px;">
                                <asp:Label ID="lblPocket" runat="server" Text="Time"></asp:Label>
                            </td>
                            <td style="width: 166px; height: 30px;">

                                <telerik:RadTextBox ID="txtTimeCurrent" runat="server" AutoPostBack ="false" ReadOnly ="true"  Skin="WebBlue" Width="105px" >
                                </telerik:RadTextBox>
                             <telerik:RadComboBox ID="CmbTime" runat="server" AutoPostBack="True" Skin="WebBlue" Visible ="false" >
                                        </telerik:RadComboBox>

                                <%--   <telerik:RadTextBox ID="txtpocketLining" runat="server" Skin="WebBlue" Width="105px">
                                </telerik:RadTextBox>--%>
                               <%-- <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" UpdatePanelsRenderMode="Inline">
                                    <AjaxSettings>
                                        <telerik:AjaxSetting AjaxControlID="ConfiguratorPanel1">
                                            <UpdatedControls>
                                                <telerik:AjaxUpdatedControl ControlID="RadTimePicker1" LoadingPanelID="RadAjaxLoadingPanel1">
                                                </telerik:AjaxUpdatedControl>
                                                <telerik:AjaxUpdatedControl ControlID="ConfiguratorPanel1"></telerik:AjaxUpdatedControl>
                                            </UpdatedControls>
                                        </telerik:AjaxSetting>
                                        <telerik:AjaxSetting AjaxControlID="RadTimePicker1">
                                            <UpdatedControls>
                                                <telerik:AjaxUpdatedControl ControlID="ConfiguratorPanel1"></telerik:AjaxUpdatedControl>
                                            </UpdatedControls>
                                        </telerik:AjaxSetting>
                                    </AjaxSettings>
                                </telerik:RadAjaxManager>--%>
                            </td>
                        </tr>
                         <tr>
                            <td style="height: 30px; width: 128px;">
                                <asp:Label ID="Label14" runat="server" Text="Issue No"></asp:Label>
                            </td>
                            <td style="width: 166px; height: 30px;">
                                <telerik:RadTextBox ID="txtIsssueNo" runat="server" AutoPostBack ="false" ReadOnly ="true"  Skin="WebBlue" Width="105px"
                                    input="Number">
                                </telerik:RadTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 30px; width: 128px;">
                                <asp:Label ID="lblPattern" runat="server" Text="No. Of Sample"></asp:Label>
                            </td>
                            <td style="width: 166px; height: 30px;">
                                <telerik:RadNumericTextBox ID="txtNoofSample" runat="server" AutoPostBack ="true"  Skin="WebBlue" Width="105px"
                                     Type="Number" NumberFormat-DecimalDigits ="2">
                                </telerik:RadNumericTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 30px; width: 128px;">
                                <asp:Label ID="lblWashing" runat="server" Text="Fabric Cons Req. for (1)Pcs"></asp:Label>
                            </td>
                            <td style="width: 166px; height: 30px;">
                                <telerik:RadNumericTextBox ID="txtFabReq" runat="server" AutoPostBack ="true" Skin="WebBlue"  Type="Number" NumberFormat-DecimalDigits ="2">
                                </telerik:RadNumericTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 30px; width: 100px;">
                                <asp:Label ID="lblThread" runat="server" Text="Total Fabric"></asp:Label>
                            </td>
                            <td style="width: 166px; height: 30px;">
                                <telerik:RadNumericTextBox ID="txtTotalFabric" ReadOnly ="true"  runat="server" Skin="WebBlue"   Type="Number" NumberFormat-DecimalDigits ="2">
                                </telerik:RadNumericTextBox>
                            </td>
                              <td style="height: 30px; width: 0px;">
                                <asp:Label ID="Label15" runat="server" Text="Mtr"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 30px; width: 128px;">
                                <asp:Label ID="lblWidth" runat="server" Text="Time Req. for (1)Pcs"></asp:Label>
                            </td>
                            <td style="width: 166px; height: 30px;">
                                <telerik:RadNumericTextBox ID="txttimeReq1Pcs" AutoPostBack ="true" runat="server" Skin="WebBlue" Width="105px"  Type="Number" NumberFormat-DecimalDigits ="2">
                                </telerik:RadNumericTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 30px; width: 128px;">
                                <asp:Label ID="Label11" runat="server" Text="No. of Worker(s)"></asp:Label>
                            </td>
                            <td style="width: 166px; height: 30px;">
                                <telerik:RadNumericTextBox ID="txtnoofworker" AutoPostBack ="true" runat="server" Skin="WebBlue" Width="105px"  Type="Number" NumberFormat-DecimalDigits ="2">
                                </telerik:RadNumericTextBox>
                            </td>
                            <td style="height: 30px; width: 50px;">
                                <asp:Label ID="Label12" runat="server" Text="Worker"></asp:Label>
                            </td>
                            <td style="width: 220px; height: 30px;" >
                                <asp:UpdatePanel ID="UpcmbWorker" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>
                                        <telerik:RadComboBox ID="cmbWorker" runat="server" AutoPostBack="false" Skin="WebBlue">
                                        </telerik:RadComboBox>
                                        <telerik:RadTextBox ID="txtWorker" runat="server" Width="100px" Skin="WebBlue" Visible="false">
                                        </telerik:RadTextBox>
                                        <%--      <telerik:RadButton ID="btnAddCom" runat="server" Text="Save" Skin="WebBlue">
                                <image imageurl="~/Images/Add.png"></image>
                            </telerik:RadButton>--%>
                                        <asp:ImageButton ID="btnAddWorker" runat="server" ImageUrl="~/Images/Add.png" Style="height: 25px;
                                            margin-bottom: -9px;"></asp:ImageButton>
                                        <asp:ImageButton ID="btnSaveWorker" runat="server" ImageUrl="~/Images/SaveButton.jpg"
                                            Style="height: 25px; margin-bottom: -9px;" Visible="false"></asp:ImageButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            
                        </tr>

                         <tr>
                            <td style="height: 30px; width: 128px;">
                                <asp:Label ID="Label16" runat="server" Text="Rem Fabric"></asp:Label>
                            </td>
                            <td style="width: 166px; height: 30px;">
                              <asp:UpdatePanel ID="upTxtRemFabric" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>
                                <telerik:RadNumericTextBox ID="TxtRemFabric" AutoPostBack ="true" runat="server" Skin="WebBlue" Width="105px"  Type="Number" NumberFormat-DecimalDigits ="2">
                                </telerik:RadNumericTextBox>
                                   </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            
                            </tr> 



                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td align="center" style="width: 150px; height: 30px;">
                                <telerik:RadButton ID="btnAddDetail" runat="server" Text="Add Grid" Skin="WebBlue">
                                </telerik:RadButton>
                            </td>
                        </tr>
                        <tr>
                            <td colspan ="2" >
                                <telerik:RadGrid ID="dgWorker" runat="server" CellSpacing="0" AutoGenerateColumns="false"
                                    Skin="WebBlue" Visible="False" PageSize="50" AllowAutomaticDeletes="false" OnDeleteCommand="dgWorker_DeleteCommand">
                                    <MasterTableView>
                                        <Columns>
                                            <telerik:GridBoundColumn HeaderText="FabricIssueWorkerDtlId" DataField="FabricIssueWorkerDtlId" Display="false">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="WorkerID" DataField="WorkerID" Display ="false" >
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="Worker Name" DataField="WorkerName">
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
                            <td></td>
                              <td></td>
                        </tr>
                        <tr>
                            <td style="height: 30px; width: 128px;">
                                <asp:Label ID="Label13" runat="server" Text="Total Time Req."></asp:Label>
                            </td>


                            <td style="width: 166px; height: 30px;">
                            <asp:UpdatePanel ID="UptxtTotaltimereq" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>
                                     
                                  
                                <telerik:RadNumericTextBox ID="txtTotaltimereq" ReadOnly ="true" runat="server" Skin="WebBlue" Width="105px">
                                </telerik:RadNumericTextBox>
                                  </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 30px; width: 128px;">
                                <asp:Label ID="lblRemarks" runat="server" Text="Remarks"></asp:Label>
                            </td>
                            <td style="width: 166px; height: 30px;" colspan="3">
                                <telerik:RadTextBox ID="txtRemarks" style="text-transform :uppercase ;" runat="server" Skin="WebBlue" TextMode="MultiLine"
                                    Width="300px">
                                </telerik:RadTextBox>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="40%">
                    <table width="100%" style="margin-top: 35px;">
                        <tr>
                            <td style="width: 85px; height: 30px;" align="left">
                                <asp:Label ID="Label1" runat="server" Text="Available Fabric"></asp:Label>
                            </td>
                            <td style="width: 165px; height: 30px;">
                                <telerik:RadTextBox ID="txtAvailFab" runat="server" Width="105px" Skin="WebBlue" ReadOnly="false">
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
            </tr>
        </table>
        <table >
            <tr>
                <td>
                    <asp:CheckBox ID="ChkIsActive" runat="server" Font-Bold="True" Visible="false" Text="Is Active" />
                </td>
                <td>
                </td>
                <td colspan="2" align="right">
                    <telerik:RadButton ID="btnSave" runat="server" Text="Issue" Skin="WebBlue">
                    </telerik:RadButton>
                </td>
                <td>
                 <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" Skin="WebBlue">
                    </telerik:RadButton>
                    
                </td>
                <td>
                <asp:Label id="LblBalnceQty" runat="server" Text =""></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
