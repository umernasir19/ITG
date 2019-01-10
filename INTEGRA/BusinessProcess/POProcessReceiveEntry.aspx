<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="POProcessReceiveEntry.aspx.vb" Inherits="Integra.POProcessReceiveEntry" %>
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
            <td style="height: 35px">
                <b>Process Receive </b>
            </td>
        </tr>
        <tr style="height: 30px;">
            <td style="height: 35px">
                <div class="txt" style="width: 125px;">
                    IGP No.
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                    <asp:TextBox ID="txtIGPNo" CssClass="textbox" Width="120" ReadOnly="true" runat="server"
                        Style="text-transform: uppercase; margin-left: -2px; height: 22px;"></asp:TextBox>
                </div>
            </td>
            <td style="height: 35px">
                <div class="txt" style="width: 125px; margin-left: 90px;">
                    Date:
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                    <asp:TextBox ID="txtPOReceiveDate" CssClass="textbox" Width="120" runat="server"
                        Style="text-transform: uppercase; margin-left: 0px;"></asp:TextBox>
                </div>
                <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtPOReceiveDate"
                    PopupButtonID="ImageButton1" />
                <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                    AlternateText="Click here to display calendar" Style="margin-left: 0px;" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtPOReceiveDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>
            </td>
        </tr>
            </TABLE>
         <table>

        <tr>
         <td style="height: 35px">
                <div class="txt" style="width: 125px;">
                    Supplier:
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 0px;">
                    <asp:DropDownList ID="cmbPartyname" runat="server" AutoPostBack="true" CssClass="combo"
                        Width="195px" Style="margin-left: 7px; height: 22px;">
                    </asp:DropDownList>
                </div>
            </td>
            

            <td style="height: 35px">
                <div class="txt" style="width: 125px; margin-left: 100px;">
                    Process No:
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                    <asp:DropDownList ID="cmbPONo" runat="server" AutoPostBack="true" CssClass="combo"
                        Width="195px" Style="margin-left: 0px; height: 22px;" OnSelectedIndexChanged="cmbPONo_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
           </TABLE>
         <table>
        <tr>
           <td style="height: 35px">
                <div class="txt" style="width: 125px;">
                    <asp:Label ID="lblFabItem" runat="server" Width="120" Visible="true" Text=""></asp:Label>
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                    <asp:DropDownList ID="cmbFabric" AutoPostBack="true" CssClass="combo" Width="120"
                        Style="margin-left: 0px; height: 22px;" runat="server" TabIndex="0">
                    </asp:DropDownList>
                </div>
            </td>



            <td style="height: 35px">
                <div class="txt" style="width: 125px; margin-left: 90px;">
                 Delivery Date:
                </div>
            </td>
             <td style="height: 35px">
              <div class="text_box" style="width: 130px; margin-left: 10px;">
                    <asp:TextBox ID="txtDeliveryDate" CssClass="textbox" Width="120" ReadOnly="true" runat="server"
                        Style="text-transform: uppercase; margin-left: 0px; height: 22px;"></asp:TextBox>
                </div>
            </td>




               

        </tr>
        </TABLE>

        <table>
        <tr>
              <td style="height: 35px">
                <div class="txt" style="width: 125px;">
                    Season:
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                  
                
                  <asp:DropDownList ID="CMBSeason" runat="server" AutoPostBack="true" CssClass="combo"
                                    Width="150px" Style="margin-left:0px; margin-top: 3px;">
                                </asp:DropDownList>
                </div>
            </td>
            <td style="height: 35px">
                <div class="txt" style="width: 125px; margin-left: 90px;">
                   Sr No:
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                 <asp:DropDownList ID="CMBSrNo" runat="server" AutoPostBack="false" CssClass="combo"
                                    Width="150px" Style="margin-left: 0px; margin-top: 4px;">
                                </asp:DropDownList>
                </div>
            </td>
        </tr>
        </table>


         <table>
        <tr>
         

               <td style="height: 35px">
                <div class="txt" style="width: 125px; margin-left: 0px;">
                 Total Qty:
                </div>
            </td>
            <td style="height: 35px;  margin-left: 4px;">
                <div class="text_box" style="width: 130px; margin-left: 0px;">
                    <asp:TextBox ID="txtTotalQty" CssClass="textbox" Width="120" ReadOnly="true" runat="server"
                        Style="text-transform: uppercase; margin-left: 9px; height: 22px;"></asp:TextBox>
                </div>
          
            </td>

            <td style="height: 35px">
                <div class="txt" style="width: 125px; margin-left: 100px;">
                    Style:
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 0px;">
                    <asp:DropDownList ID="cmbStyle" AutoPostBack="true" CssClass="combo" Width="120"
                        Style="margin-left: 10px; height: 22px;" runat="server" TabIndex="0">
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
           </TABLE>
         <table >
        <tr>
            
          <asp:Panel ID="PnlGodownCmb" runat="server" Visible="true">
                <td style="height: 35px">
                    <div class="txt" style="width: 125px; margin-left: 0px;">
                        Godown :
                    </div>
                </td>
                <td style="height: 35px">
                    <div class="text_box" style="margin-left: 0px;">
                        <asp:DropDownList ID="cmbLocation" runat="server" AutoPostBack="false" CssClass="combo"
                            Width="120px" Style="margin-left: 8px; height: 22px;">
                        </asp:DropDownList>
                    </div>
                    <asp:ImageButton ID="BtnAdd" runat="server" ImageUrl="~/Images/AddButton.jpg" Style="margin-left: 88px;
                        width: 19px;" />
                </td>
            </asp:Panel>
            <asp:Panel ID="PnlGodowntxt" runat="server" Visible="false">
                <td style="height: 35px">
                    <div class="txt" style="width: 125px; margin-left: 0px;">
                        Godown :
                    </div>
                </td>
                <td style="height: 35px">
                    <div class="text_box" style="width: 130px; margin-left: 10px;">
                        <asp:TextBox ID="txtGodown" CssClass="textbox" Width="120px" runat="server" Style="margin-left: 0px; height: 22px;">
                        </asp:TextBox>
                    </div>
                    <asp:ImageButton ID="BtnSaveGodown" runat="server" ImageUrl="~/Images/SaveButton.jpg"
                        Style="margin-left: 0px; width: 19px;" />
                </td>
            </asp:Panel>

             <td style="height: 35px">
                <div class="txt" style="width: 125px; margin-left: 78px;">
                    Party DC No.
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                    <asp:TextBox ID="txtpartDCNo" CssClass="textbox" Width="120" ReadOnly="false" runat="server"
                        Style="text-transform: uppercase; margin-left: 0px; height: 22px;"></asp:TextBox>
                </div>
            </td>             
         
        </tr>
     
    </table>
    <asp:Panel ID="pnlReceivedData" Visible="false" runat="server">
        <table style="width: 100%">
            <tr style="height: 100px;">
                <td>
                    <Smart:SmartDataGrid ID="dgPORecDetail" runat="server" Width="100%" OnSortCommand="SortByColumn"
                        OnPageIndexChanged="PageChanged" OnItemDataBound="DataBound" AllowPaging="True"
                        AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                        PageSize="20" ShowFooter="True" ForeColor="white" GridLines="both">
                        <Columns>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="ID"
                                DataField="POProcessRecvDetailID" Visible="false" />
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="ID"
                                DataField="ProcessOrderDtlID" Visible="false" />
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="PO Type"
                                DataField="ContractType">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Style"
                                DataField="Style">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Item Name"
                                DataField="ItemName">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Quality"
                                DataField="Quality">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="PO.QTY"
                                DataField="POQTY">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Pre.Rec"
                                DataField="RecvQtyinBag">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Rem.QTY"
                                DataField="RemainingQty">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="05%" HeaderText="Fresh Qty.">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtfreshQty" CssClass="textbox" Width="80" runat="server" OnTextChanged="txtfreshQty_TextChanged"
                                    AutoPostBack="true" onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                                <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="05%" HeaderText="B-Quality">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtBQualityQty" CssClass="textbox" Width="80" runat="server" OnTextChanged="txtBQualityQty_TextChanged"
                                    AutoPostBack="true" onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="05%" HeaderText="Now Received">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtReceivedQty" CssClass="textbox" Width="80" runat="server" onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="05%" HeaderText="Vehicle No"
                                Visible="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtVehicleNo" CssClass="textbox" Width="100" runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="05%" HeaderText="Factory Location"
                                Visible="false">
                                <ItemTemplate>
                                    <asp:DropDownList ID="cmbOfficeLocation" CssClass="combo" Width="100" runat="server"
                                        TabIndex="0" Visible="false">
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Receive Date">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtReceiveDate" CssClass="textbox" Width="80" runat="server" Style="text-transform: uppercase;"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="txtReceiveDate"
                                        PopupButtonID="ImageButton3" />
                                    <asp:ImageButton runat="Server" ID="ImageButton3" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                                        AlternateText="Click here to display calendar" />
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtReceiveDate"
                                        Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                                        CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                                        Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                                    </cc1:MaskedEditExtender>
                                </ItemTemplate>
                                <HeaderStyle Width="8%" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="05%" HeaderText="Lot No">
                                <ItemTemplate>
                                    <asp:TextBox ID="TXTLotNo" CssClass="textbox" Width="80" runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="05%" HeaderText="No Of Roll">
                                <ItemTemplate>
                                    <asp:TextBox ID="TXTNoOfRoll" CssClass="textbox" Width="80" runat="server" onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="2%" HeaderText="ItemID"
                                DataField="ItemID" Visible="false" />
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="2%" HeaderText="PORate"
                                DataField="PORate" Visible="false" />
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="2%" HeaderText="ReturnQtyy"
                                DataField="ReturnQtyy" Visible="false" />
                        </Columns>
                    </Smart:SmartDataGrid>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <table width="100%">
        <tr>
            <td align="center">
                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-outline btn-success"
                    Text="Cancel" Width="100" Visible="false"></asp:Button>
                &nbsp; &nbsp;
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-outline btn-success" Text="Save"
                    Width="100" Visible="false"></asp:Button>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPOID" runat="server" Visible="false"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
