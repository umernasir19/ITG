<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="Issue.aspx.vb" Inherits="Integra.Issue" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
        <div class="header_columns">
            <div class="heading">
                ISSUE Entry</div>
            <br />
            <table>
                <tr style="height: 0px;">
                    <td>
                        <asp:Label ID="lblIMSItemId" runat="server" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 125px;">
                        <div class="txt" style="width: 125px;">
                            Challan No:</div>
                    </td>
                    <td style="width: 160px;">
                        <div class="text_box" style="width: 130px; margin-left: 10px;">
                            <asp:TextBox ID="TXTManualChallanNo" CssClass="textbox" runat="server" ReadOnly="false"
                                Style="height: 20px;"></asp:TextBox></div>
                    </td>
                </tr>
                <tr style="height: 30px;">
                    <td>
                        <div class="txt" style="width: 125px;">
                            Date:</div>
                    </td>
                    <td>
                        <div class="text_box" style="width: 130px; margin-left: 10px;">
                            <asp:TextBox ID="txtCreationDate" CssClass="textbox" Width="129" runat="server" AutoPostBack="false"
                                Style="text-transform: uppercase; margin-left: 0px; height: 20px; margin-top: 6px;"></asp:TextBox></div>
                        <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtCreationDate"
                            PopupButtonID="ImageButton1" />
                        <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" ImageUrl="~/Images/callendar.JPG"
                            AlternateText="Click here to display calendar" Style="margin-left: 142px; margin-top: -15px;" />
                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtCreationDate"
                            Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                            CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                            Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                        </cc1:MaskedEditExtender>
                    </td>
                    <td>
                    </td>
                    <td style="width: 118px;">
                        <div class="txt" style="width: 125px; margin-left: -125px;">
                            Already Issued:</div>
                    </td>
                    <td>
                        <div class="text_box" style="width: 120px; margin-left: 10px;">
                            <asp:TextBox ID="txtAlreadyIssued" CssClass="textbox" runat="server" ReadOnly="true"
                                Visible="true" Style="background-color: #6495ED; height: 20px; margin-left: -160px;"></asp:TextBox></div>
                    </td>
                </tr>
                <tr style="height: 34px;">
                    <td style="width: 118px;">
                        <div class="txt" style="width: 125px;">
                            <asp:Label ID="lblItemFab" runat="server" Text="" Visible="true"></asp:Label></div>
                    </td>
                    <td>
                        <asp:TextBox ID="txtItemCode" runat="server" autocomplete="off" AutoPostBack="true"
                            Style="margin-left: 11px; width: 153px;"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="10"
                            CompletionSetCount="12" ContextKey="ItemCodeForIssue" EnableCaching="true" MinimumPrefixLength="1"
                            ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtItemCode" />
                        <asp:Label ID="lblID" runat="server" Text="" Visible="false"></asp:Label>
                    </td>
                    <td id="tdShowMe" runat="server" visible="false">
                        <asp:TextBox ID="txtSearchItem" CssClass="textbox" runat="server" Visible="true"
                            AutoPostBack="true"></asp:TextBox>
                        <cc1:AutoCompleteExtender runat="server" ID="autoComplete1" TargetControlID="txtSearchItem"
                            ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                            CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="IMSItemm" />
                    </td>
                    <td style="width: 118px;">
                        <div class="txt" style="width: 125px;">
                            Receive Qty:</div>
                    </td>
                    <td style="width: 160px;">
                        <div class="text_box" style="width: 130px; margin-left: 10px;">
                            <asp:TextBox ID="txtReceive" CssClass="textbox" runat="server" Width="150px" ReadOnly="true"
                                Style="margin-left: 0px; height: 20px;"></asp:TextBox></div>
                    </td>
                    <td>
                    </td>
                    <td style="width: 118px;">
                        <div class="txt" style="width: 125px; margin-left: -112px;">
                            Issue:</div>
                    </td>
                    <td style="width: 160px;">
                        <div class="text_box" style="width: 130px; margin-left: 10px;">
                            <asp:TextBox ID="txtIssue" CssClass="textbox" runat="server" AutoPostBack="true"
                                Style="height: 20px; margin-left: -28px;" ReadOnly="false"></asp:TextBox></div>
                    </td>
                </tr>
                <tr style="height: 34px;">
                    <td id="tdPOLabel" runat="server" style="width: 118px;">
                        <div class="txt" style="width: 125px;">
                            PO NO#:</div>
                    </td>
                    <td id="tdcmbPONO" runat="server" style="width: 160px;">
                        <asp:DropDownList ID="cmbPoNo" AutoPostBack="True" CssClass="combo" Width="160px"
                            runat="server" Style="margin-left: 10px;" TabIndex="0">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 118px;">
                        <div class="txt" style="width: 125px;">
                            Department:</div>
                    </td>
                    <td style="width: 160px;">
                        <asp:DropDownList ID="cmbDept" AutoPostBack="false" CssClass="combo" Width="150px"
                            runat="server" TabIndex="0" Style="margin-left: 10px;">
                        </asp:DropDownList>
                    </td>
                    <td>
                    </td>
                </tr>
                 
       
        <tr>
              <td style="height: 35px">
                <div class="txt" style="width: 125px;">
                    Season:
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                  
                
                  <asp:DropDownList ID="CMBSeason" runat="server" AutoPostBack="true" CssClass="combo"
                                    Width="150px" Style="margin-left: 0px; margin-top:5px;">
                                </asp:DropDownList>
                </div>
            </td>
            <td style="height: 35px">
                <div class="txt" style="width: 125px; margin-left: 0px;">
                   Sr No:
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                 <asp:DropDownList ID="CMBSrNo" runat="server" AutoPostBack="false" CssClass="combo"
                                    Width="150px" Style="margin-left: 0px; margin-top:5px;">
                                </asp:DropDownList>
                </div>
            </td>
        </tr>
       
                <tr>
                    <td style="width: 125px; margin-left: -109px;">
                        <div id="tdRecv" runat="server" class="txt" style="width: 125px;">
                            Receiver:</div>
                    </td>
                    <td style="width: 160px;">
                        <div class="text_box" style="width: 130px; margin-left: 10px;">
                            <asp:TextBox ID="txtContractor" CssClass="textbox" runat="server" ReadOnly="false"
                                Style="height: 20px; margin-left: -1px;"></asp:TextBox></div>
                    </td>
                </tr>
                <tr style="height: 34px;">
                    <td>
                        <div class="txt" style="width: 125px;">
                            Remarks</div>
                    </td>
                    <td>
                        <div class="text_box" style="width: 130px; margin-left: 10px;">
                            <asp:TextBox ID="txtRemarks" CssClass="textbox" runat="server" Style="height: 20px;"></asp:TextBox></div>
                    </td>
                    <td style="width: 118px;">
                        <div class="txt" style="width: 125px;">
                            Entry Type:</div>
                    </td>
                    <td style="width: 160px;">
                        <div class="text_box" style="width: 130px; margin-left: 10px;">
                            <asp:TextBox ID="txtEntryType" CssClass="textbox" runat="server" ReadOnly="false"
                                Style="margin-left: 0px; height: 20px; width: 150px;"></asp:TextBox>
                        </div>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <asp:Panel ID="PnlGodownCmb" runat="server" Visible="true">
                        <td style="width: 118px;">
                            <div class="txt" style="width: 125px;">
                                Godown :
                            </div>
                        </td>
                        <td style="width: 160px;">
                            <div class="text_box" style="width: 130px; margin-left: 10px;">
                                <asp:DropDownList ID="cmbLocation" runat="server" AutoPostBack="false" CssClass="combo"
                                    Width="150px" Style="margin-left: 4px; margin-top: 9px;">
                                </asp:DropDownList>
                            </div>
                            <asp:ImageButton ID="BtnAddGodwn" runat="server" ImageUrl="~/Images/AddButton.jpg"
                                Style="margin-left: 168px; width: 19px; margin-top: -19px;" />
                        </td>
                    </asp:Panel>
                    <asp:Panel ID="PnlGodowntxt" runat="server" Visible="false">
                        <td style="width: 118px;">
                            <div class="txt" style="width: 125px;">
                                Godown :
                            </div>
                        </td>
                        <td style="width: 160px;">
                            <div class="text_box" style="width: 130px; margin-left: 10px;">
                                <asp:TextBox ID="txtGodown" CssClass="textbox" runat="server" ReadOnly="false" Style="margin-left: 0px;
                                    height: 20px; width: 150px;"></asp:TextBox>
                            </div>
                            <asp:ImageButton ID="BtnSaveGodown" runat="server" ImageUrl="~/Images/SaveButton.jpg"
                                Style="margin-left: 24px; width: 19px;" />
                        </td>
                    </asp:Panel>
                </tr>
                <tr>
                </tr>
                <tr>
                 <td style="width: 118px;">
                        <div class="txt" style="width: 125px; margin-left:0px; margin-top: 4px;">
                            Rate:</div>
                    </td>
                    <td style="width: 160px;">
                        <div class="text_box" style="width: 130px; margin-left: 0px;">
                            <asp:TextBox ID="txtRate" CssClass="textbox" runat="server" AutoPostBack="true"
                                Style="height: 20px; margin-left: 11px; margin-top: 4px;" ReadOnly="true"></asp:TextBox></div>
                    </td>


                 

                </tr>
                <tr>
                   <td style="width: 118px;">
                        <div class="txt" style="width: 125px; margin-left:0px; margin-top: 4px;">
                            Allow Sr No:</div>
                    </td>
                    <td style="width: 160px;">
                        <div class="text_box" style="width: 130px; margin-left: 0px; margin-top: 6PX;">
                             <asp:CheckBox ID="chkSrNo" runat="server" Checked="true"  Visible="true" Style=" margin-left: 13PX;     margin-top: 6PX;" /></div>
                    </td>
                </tr>


            </table>
            <table>
                <tr style="height: 55px;">
                    <td>
                        <asp:Button ID="btnAdd" runat="server" Skin="WebBlue" Text="Add Detail" Font-Bold="True"
                            Font-Names="Calibri" Font-Size="Medium" Height="30px" Width="120px" CausesValidation="true"
                            Style="margin-left: 355px;"></asp:Button>
                    </td>
                    <td>
                        <asp:Label ID="lblIssueDtlID" runat="server" Visible="false"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <table width="100%">
                <tr style="height: 30px;">
                    <td>
                        <Smart:SmartDataGrid ID="dgAdd" runat="server" Width="100%" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4" CssClass="table" PageSize="1000" ShowFooter="True"
                            ForeColor="white" GridLines="both">
                            <Columns>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="IssueDtlID"
                                    DataField="IssueDtlID" Visible="false" />
                                <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="ItemID"
                                    DataField="ItemID" Visible="false" />
                                <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="DeptDatabaseID"
                                    DataField="DeptDatabaseID" Visible="false" />
                                <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Item Name"
                                    DataField="ItemName">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Entry Type"
                                    DataField="EntryType">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Recv Qty"
                                    DataField="ReceiveQty">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="Issue QTY"
                                    DataField="IssueQty">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Department"
                                    DataField="Department">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Contractor"
                                    DataField="Contractor">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Remarks"
                                    DataField="Remarks">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                </asp:BoundColumn>


                                 <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="SeasonDatabaseID"
                                    DataField="SeasonDatabaseID" Visible="False" />
                                     <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="JobOrderID"
                                    DataField="JobOrderID" Visible="False" />
                                  <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Season"
                                    DataField="SeasonName">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                  <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Sr No"
                                    DataField="SrNoo">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                </asp:BoundColumn>


                                 <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="POID"
                                    DataField="POID" Visible="false" />
                                     <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="PO NO"
                                    DataField="PONO">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                </asp:BoundColumn>

                                 <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="Rate"
                                    DataField="Rate" Visible="false" />
                             

                                <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="EDIT">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="lnkEdit" ToolTip="Click here to edit" ImageUrl="~/Images/editIcon.jpg"
                                            CommandName="Edit" runat="server"></asp:ImageButton>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                            </Columns>
                        </Smart:SmartDataGrid>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnSave" runat="server" Skin="WebBlue" Text="Save" Font-Bold="True"
                        Font-Names="Calibri" Font-Size="Medium" Height="30px" Width="120px" CausesValidation="true"
                        Visible="true"></asp:Button>
                </td>
                <td>
                    <asp:Button ID="btnCancel" runat="server" Skin="WebBlue" Text="Cancel" Font-Bold="True"
                        Font-Names="Calibri" Font-Size="Medium" Height="30px" Width="110px" Visible="true"
                        Style="margin-left: 19px;"></asp:Button>
                </td>
                <td>
                    <asp:Label ID="lblAuditorStatus" runat="server" Visible="false"></asp:Label>
                      <asp:Label ID="lblAuditorID" runat="server" Visible="false"></asp:Label>
                      <asp:Label ID="lblUseriD" runat="server" Visible="false"></asp:Label>
                </td>
            </tr>
        
        </table>
    </div>
</asp:Content>
