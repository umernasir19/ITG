<%@ Page Title="PO Return" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="POReturnNew.aspx.vb" Inherits="Integra.POReturnNew" %>

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
        <tr style="border-bottom-style: solid; height: 50px; border-bottom-color: #00509F;
            border-bottom-width: thin;" visible="true">
            <th colspan="6" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                PO Return
            </th>
        </tr>
    </table>
    <br />


    <table>

     <tr style="height: 30px;">
            <td style="height: 35px">
                <div class="txt" style="width: 125px;">
                    IGP No.
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                    <asp:TextBox ID="txtIGPNo" CssClass="textbox" Width="120" ReadOnly="true" runat="server"
                        Style="text-transform: uppercase; margin-left: 9px;"></asp:TextBox>
                </div>
            </td>
            <td style="height: 35px">
                <div class="txt" style="width: 125px; margin-left: 123px;">
                    Date:
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                    <asp:TextBox ID="txtPOReceiveDate" CssClass="textbox" Width="120" ReadOnly="true" runat="server"
                        Style="text-transform: uppercase; margin-left: 10px;"></asp:TextBox>
                </div>
                <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtPOReceiveDate"
                    PopupButtonID="ImageButton1" />
                <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                    AlternateText="Click here to display calendar" Style="margin-left: 3px;" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtPOReceiveDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>
            </td>
        </tr>
        <tr>
              <td style="height: 35px">
                <div class="txt" style="width: 125px;">
                    Supplier:
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                    <asp:DropDownList ID="cmbPartyname" runat="server" AutoPostBack="true" Enabled ="false"  CssClass="combo"
                        Width="195px" Style="margin-left: 9px;">
                    </asp:DropDownList>
                </div>
            </td>
            <td style="height: 35px">
                <div class="txt" style="width: 125px; margin-left: 123px;">
                    PO No:
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 0px;">
                    <asp:DropDownList ID="cmbPONo" runat="server" AutoPostBack="true" Enabled ="false" CssClass="combo"
                        Width="195px" Style="margin-left: 19px;" OnSelectedIndexChanged="cmbPONo_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
               </table><table>
        <tr>
              <td style="height: 35px">
                <div class="txt" style="width: 125px;">
                    Season:
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                  
                
                  <asp:DropDownList ID="CMBSeason" runat="server" AutoPostBack="true" CssClass="combo"
                              Enabled ="false"      Width="150px" Style="margin-left: 10px; margin-top: 9px;">
                                </asp:DropDownList>
                </div>
            </td>
            <td style="height: 35px">
                <div class="txt" style="width: 125px; margin-left: 124px;">
                   Sr No:
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                 <asp:DropDownList ID="CMBSrNo" runat="server" AutoPostBack="false" CssClass="combo"
                                    Width="150px" Style="margin-left: 10px; margin-top: 9px;" Enabled ="false">
                                </asp:DropDownList>
                </div>
            </td>
        </tr>
        </table><table>
        <tr>
        <td style="height: 35px">
                <div class="txt" style="width: 125px;">
                    <asp:Label ID="lblFabItem" runat="server" Width="120" Visible="true" Text=""></asp:Label>
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                    <asp:DropDownList ID="cmbFabric" AutoPostBack="true" CssClass="combo" Width="195"
                        Style="margin-left: 10px;" Enabled ="false"  runat="server" TabIndex="0">
                    </asp:DropDownList>
                </div>
            </td>
          
          <td style="height: 35px">
                <div class="txt" style="width: 125px; margin-left: 124px;">
                 Delivery Date:
                </div>
            </td>

             <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                    <asp:TextBox ID="txtDeliveryDate" CssClass="textbox" Width="120" ReadOnly="true" runat="server"
                        Style="text-transform: uppercase; margin-left: 10px;"></asp:TextBox>

                     <%--      <asp:DropDownList ID="CMB" AutoPostBack="true" CssClass="combo" Width="120"
                        Style="margin-left: -87px;" runat="server" TabIndex="0">
                    </asp:DropDownList>--%>
                </div>
            </td>
        </tr>
        <tr>
         <td style="height: 35px">
                <div class="txt" style="width: 125px; margin-left: 0px;">
                 Total Qty:
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                    <asp:TextBox ID="txtTotalQty" CssClass="textbox" Width="120" ReadOnly="true" runat="server"
                        Style="text-transform: uppercase; margin-left: 10px;"></asp:TextBox>
                </div>
          
            </td>

           <td style="height: 35px">
                <div class="txt" style="width: 125px; margin-left: 124px;">
                 Style:
                </div>
            </td>
            <td style="height: 35px">
                  <div class="text_box" style="width: 130px; margin-left: 10px;">
                    <asp:DropDownList ID="cmbStyle" AutoPostBack="true" CssClass="combo" Width="120"
                        Style="margin-left: 10px;" runat="server" Enabled ="false"  TabIndex="0">
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
        <tr>

            <td style="height: 35px">
                <div class="txt" style="width: 125px;">
                 Party DC No:      
                </div>
            </td>
            <td style="height: 35px">
            

                  <div class="text_box" style="width: 130px; margin-left: 10px;">
                    <asp:TextBox ID="txtpartDCNo" ReadOnly ="true"  CssClass="textbox" Width="120" runat="server" Style="margin-left: 9px;"></asp:TextBox>
                </div>


            </td>
             <asp:Panel ID="PnlGodownCmb" runat="server" Visible="true">
            <td style="height: 35px">
                <div class="txt" style="width: 125px; margin-left: 124px;">
                   Godown :
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style=" margin-left: 10px;">
                    <asp:DropDownList ID="cmbLocation" runat="server" AutoPostBack="false" CssClass="combo"
                        Width="120px" Style="margin-left: 11px;" Enabled ="false" >
                    </asp:DropDownList>
                    
                </div>  
                <asp:ImageButton ID="BtnAdd" runat="server" Enabled ="false"  ImageUrl="~/Images/AddButton.jpg" Style="margin-left: 93px;
                            width: 19px;" />
               </td>         
                          
               
            </asp:Panel>
                <asp:Panel ID="PnlGodowntxt" runat="server" Visible="false">
             <td style="height: 35px">
                <div class="txt" style="width: 125px; margin-left: 123px;">
                   Godown :
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                    <asp:TextBox ID="txtGodown" CssClass="textbox" Width="195" runat="server" Style="margin-left: 9px;">
                    </asp:TextBox>
                        </div>
                 <asp:ImageButton ID="BtnSaveGodown" runat="server" ImageUrl="~/Images/SaveButton.jpg"
                            Style="margin-left:77px; width: 19px;" />
            </td>
            </asp:Panel>
        </tr>


       
    </table>
    <br />
  


        <table style="width: 100%">
            <tr style="height: 100px;">
                <td>
                  <asp:UpdatePanel ID="uddgPORecDetail" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>

                    <Smart:SmartDataGrid ID="dgPORecDetail" runat="server" Width="100%" OnSortCommand="SortByColumn"
                        OnPageIndexChanged="PageChanged" OnItemDataBound="DataBound" AllowPaging="True"
                        AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                        PageSize="100" ShowFooter="True" ForeColor="white" GridLines="both">
                        <Columns>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="ID"
                                DataField="POReturnIDD" Visible="false" />
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="ID"
                                DataField="PORecvDetailID" Visible="false" />
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="ID"
                                DataField="PODetailID" Visible="false" />
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="2%" HeaderText="ItemID"
                                DataField="ItemidD" Visible="false" />
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="PO Type"
                                DataField="ContractType">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Style"
                                DataField="Style">
                                <HeaderStyle HorizontalAlign="center" Width="4%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Item Name"
                                DataField="Itemname">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Quality"
                                DataField="Quality">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Recv Qty"
                                DataField="RecvQty">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Pre.Return"
                                DataField="PreReturnQty">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Rem.QTY"
                                DataField="BalanceQty">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                            </asp:BoundColumn>
                                <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="05%" HeaderText="Return Qty.">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtReturnQty" CssClass="textbox" Width="80" runat="server" OnTextChanged="txtReturnQty_TextChanged"
                                    AutoPostBack="true" onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                             
         
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="05%" HeaderText="Dc No"
                                Visible="true">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDcNo" CssClass="textbox" Width="100" style=" text-transform :uppercase ;" runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                          
                        
                             <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="05%" HeaderText="Remarks">
                                <ItemTemplate>
                                    <asp:TextBox ID="TXTRemarks" CssClass="textbox" style=" text-transform :uppercase ;" Width="80" runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                           

                        </Columns>
                    </Smart:SmartDataGrid>
                       </ContentTemplate>
                        </asp:UpdatePanel>
                </td>
            </tr>
        </table>


    <br />
    

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
                <asp:Label ID="lblPODetailID" runat="server" Visible="false"></asp:Label>
                 <asp:Label ID="lblAuditorStatus" runat="server" Visible="false"></asp:Label>
                  <asp:Label ID="lblAuditorID" runat="server" Visible="false"></asp:Label>
            </td>
        </tr>
    </table>

  
</asp:Content>
