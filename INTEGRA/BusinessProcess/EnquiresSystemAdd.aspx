<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="EnquiresSystemAdd.aspx.vb" Inherits="Integra.EnquiresSystemAdd" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
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
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Enquiries
            </th>
        </tr>
        <tr style="height: 34px">
            <td>
                Creation date
            </td>
            <td>
                <asp:TextBox ID="txtTodaydate" Width="100" runat="server" CssClass="textbox" ReadOnly="true"
                    enable="false"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender4" Format="dd/MM/yyyy" runat="server" TargetControlID="txtTodaydate"
                    PopupButtonID="ImageButton10" />
                <asp:ImageButton runat="Server" ID="ImageButton10" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                    AlternateText="Click here to display calendar" Visible="false" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txtTodaydate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>
            </td>
            <td>
              
                Enquiry purpose
            </td>
            <td>
                <asp:DropDownList ID="cmbEnquiryPurpose" Width="139px" runat="server" AutoPostBack="false"
                       >
                    <asp:ListItem Value="0">Select </asp:ListItem>
                    <asp:ListItem Value="1">Buying Meeting </asp:ListItem>
                     <asp:ListItem Value="1">Confirmed Style Enq.  </asp:ListItem>
                </asp:DropDownList>
            </td>
           
           
            <td>
                Enquire Type
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbEnquireType" runat="server" AutoPostBack="true"  
                            Width="149px" ToolTip="Select source of original sample">
                            <asp:ListItem Value="0" Text="Initial" />
                            <asp:ListItem Value="1" Text="Repeat" />
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr style="height: 34px">
            <td>
                Style No.
            </td>
            <td>
                <asp:TextBox ID="txtStyleNo" CssClass="textbox" runat="server"></asp:TextBox>
            </td>
            <td>
                Customer
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel6" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbCustomer" AutoPostBack="TRUE" runat="server" Width="140"
                            ToolTip="select Customer">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
 <td>
               Buying Dept. 
            </td>
            <td>
             <asp:UpdatePanel ID="UpcmbBuyingDept" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbBuyingDept" AutoPostBack="TRUE" runat="server" Width="140" ToolTip="select Brand">
                        </asp:DropDownList>
                   
                    </ContentTemplate>
                </asp:UpdatePanel>
              
            </td>




           
        </tr>



        <tr>
            <td>
                Buyer
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatecmbBuyerName" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbBuyer" AutoPostBack="TRUE" runat="server" Width="149px" ToolTip="select Buyer">
                        </asp:DropDownList>
                        <asp:TextBox ID="txtBuyer" CssClass="textbox" runat="server" Visible="false"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                Brand
            </td>
            <td>
              <asp:UpdatePanel ID="UpcmbBrand" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbBrand" AutoPostBack="false" runat="server" Width="140" ToolTip="select Brand">
                        </asp:DropDownList>
                        <asp:TextBox ID="txtBrand" CssClass="textbox" runat="server" Visible="false"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
              
            </td>
            <td>
               Supplier 
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
              <asp:DropDownList ID="cmbSupplier" AutoPostBack="false" runat="server" Width="148px"
                    ToolTip="select Supplier">
                </asp:DropDownList>
              
            </td>
        </tr>
        <tr style="height: 34px">
            <td>
              Recv. Date  
            </td>

            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
              <asp:TextBox ID="txtRecvDate" Width="100" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server" TargetControlID="txtRecvDate"
                    PopupButtonID="ImageButton3" />
                <asp:ImageButton runat="Server" ID="ImageButton3" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                    AlternateText="Click here to display calendar" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtRecvDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="DMY" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>
              
            </td>
            <td>
               Ex Factory Date 
            </td>
            <td>
              <asp:TextBox ID="txtExFactoryDate" Width="100" runat="server" CssClass="textbox"></asp:TextBox>
                <%--   <cc1:CalendarExtender ID="CalendarExtender4" Format="dd/MM/yyyy" runat="server" TargetControlID="txtExFactoryDate"
                    PopupButtonID="ImageButton4" />
                <asp:ImageButton runat="Server" ID="ImageButton4" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                    AlternateText="Click here to display calendar" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txtExFactoryDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>--%>
               
            </td>
            <td>
             Season  
            </td>
            <td>
             <asp:DropDownList ID="cmbSeason" runat="server" Width="148px" ToolTip="select Season">
                </asp:DropDownList>
             
            </td>
        </tr>
        <tr>
            <td>
                Styling Source 
            </td>
            <td>
               <asp:UpdatePanel ID="UpdatePanel3" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbStyleSource" runat="server" AutoPostBack="false"  
                            Width="148px" ToolTip="Select source of original sample">
                            <asp:ListItem Value="0" Text="Technical sheet" />
                            <asp:ListItem Value="1" Text="Buyer sample" />
                            <asp:ListItem Value="2" Text="GIA Offer Sample" />
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:TextBox ID="txtStylingSource" CssClass="textbox" runat="server" Width="192px"
                    Visible="false"></asp:TextBox>
              
            </td>
            <td>
               Product Category 
            </td>
            <td>
              <asp:DropDownList ID="cmbProductCategory" runat="server" AutoPostBack="false" CssClass="dd"
                    Width="308px" ToolTip="Select Product Category">
                </asp:DropDownList>
                <asp:TextBox ID="txtStyleDesc" CssClass="textbox" runat="server" Visible="false"
                    Text="na"></asp:TextBox>
               
            </td>
            <td>
                Purchase Order
            </td>
            <td>
                <asp:DropDownList ID="cmbPOStatus" runat="server" AutoPostBack="false"  
                    Width="150" ToolTip="Select PO Status">
                    <asp:ListItem Value="1" Text="Pending" />
                    <asp:ListItem Value="2" Text="Received" />
                    <asp:ListItem Value="3" Text="Cancelled" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Product Consumer Grp
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel12" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbProductConsumerGrp" Width="148px" runat="server" AutoPostBack="true"
                             ToolTip="Select product consumer">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>Style Description
            </td>
            <td>
             <asp:TextBox ID="txtSpecialInstruction" CssClass="textbox" runat="server" Visible="true"
                    TextMode="MultiLine" Width="311px"></asp:TextBox>
            </td>
          <td>
          Enquiry Confirm Date
          </td>
           <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <asp:TextBox ID="txtEnquiryConfirmDate" Width="100" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender5" Format="dd/MM/yyyy" runat="server" TargetControlID="txtEnquiryConfirmDate"
                    PopupButtonID="ImageButton888" />
                <asp:ImageButton runat="Server" ID="ImageButton888" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                    AlternateText="Click here to display calendar" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtEnquiryConfirmDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="DMY" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>
            </td>
        </tr>
    </table>
    <asp:Panel ID="PictueWork" runat="server" Visible="true">
        <table width="100%">
            <tr>
                <td style="width: 98px;">
                    Picture:
                </td>
                <td style="width: 150px;">
                    <asp:FileUpload ID="FileUpload2" runat="server" style="margin-left: 28px;" ToolTip="select jpg file to attach and press upload" />
                </td>
                <td style="width: 98px;">
                    <asp:Button ID="btnUploadNew" CssClass="button" runat="server" Text="Upload" Visible="true"  style="margin-left: 8px;"/>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpPic" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <asp:LinkButton ID="lnkFIlePicture" Text="Show Picture" Style="margin-left: 8px;"
                                runat="server" Visible="false"> </asp:LinkButton>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <asp:UpdatePanel ID="upAtrilce" runat="server" ChildrenAsTriggers="true">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                        font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                        bgcolor="Silver">
                        Article Description
                    </th>
                </tr>
                <tr style="height: 34px">
                    <td>
                        Colorways
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="txtColorways" runat="server"></asp:TextBox>
                    </td>
                    
                    <td>
                        Quantity
                    </td>
                    <td >
                        <asp:TextBox ID="txtMOQ" runat="server" style="    margin-left: -40px;"></asp:TextBox>
                    </td>
                   
                    <td>
                        Buyer Target Price
                    </td>

                    <td colspan="1">
                        <asp:TextBox ID="txtBuyerTargetPrice" runat="server" onkeypress="return isNumericKeyy(event);"
                            Width="50" style=" margin-left: -42px;"></asp:TextBox>
                        <asp:DropDownList ID="cmbBuyerPriceUnit" Width="70" CssClass="dd" runat="server" ToolTip="select currency">
                            <asp:ListItem Value="0" Text="Dollar"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Euro"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Pounds"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                 <td>
                        Price
                    </td>
                    <td>
                        <asp:TextBox ID="txtPrice" runat="server" onkeypress="return isNumericKeyy(event);"
                            Width="100"></asp:TextBox>
                        <asp:DropDownList ID="cmbCurrency" Width="100" CssClass="dd" runat="server" ToolTip="select currency">
                            <asp:ListItem Value="0" Text="Dollar"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Euro"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Pounds"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        Fabric Type
                    </td>
                    <td style="width: 125px">
                        <asp:TextBox ID="txtFabric" runat="server" style="    margin-left: -40px;"></asp:TextBox>
                    </td>
                     <td>
                         Construction
                    </td>
                    <td style="width: 125px">
                         <asp:TextBox ID="txtFabricDetail" runat="server"    style="    margin-left: -42px;"></asp:TextBox>
                    </td>
                </tr>
              <tr style="height: 34px">
                    <td>
                        Compostion
                    </td>
                     <td style="width: 125px">
                        <asp:TextBox ID="txtcompostion" runat="server"></asp:TextBox>
                    </td>
                    
                    <td>
                        Weight
                    </td>
                    <td >
                        <asp:TextBox ID="txtweight" runat="server" style="    margin-left: -40px;"></asp:TextBox>
                    </td>
                   
                    <td>
                        
                    </td>

                    <td colspan="1">
                       
                    </td>
                    <td>
                    </td>
                </tr>
                <tr style="height:70px">
                 <td>
                        Remarks
                    </td>
                    <td>
                        <asp:TextBox ID="txtFabricRemarks" runat="server" Width="303px" TextMode="MultiLine" ></asp:TextBox>
                    </td>
                    <td>
                  
                    </td>
                    <td colspan="2">
                    
                    </td>
                    <td></td>
                   </tr>
                   <tr>
                       <td>
                       </td>
                       <tr>
                       <td>
                       </td>
                       <td></td>
                           <td>
                               <asp:Button ID="btnAddDetail" runat="server" CssClass="button" 
                                   Text="Add More" />
                           </td>
                       </tr>
                   </tr>
            </table>
            <br />
            <table width="100%">
                <tr>
                    <td>
                        <Smart:SmartDataGrid ID="dgEnqDetail" runat="server" Width="100%" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="2" CssClass="table" PagerCurrentPageCssClass=""
                            PagerOtherPageCssClass="" PageSize="600" RecordCount="0" ShowFooter="True" SortedAscending="yes">
                            <Columns>
                                <asp:BoundColumn HeaderText="Detail ID" DataField="EnquiriesSystemDetailID" Visible="false" />
                                <asp:BoundColumn HeaderText="Colorways" DataField="Colorways">
                                    <HeaderStyle Width="10%" HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Quantity " DataField="MOQ">
                                    <HeaderStyle Width="10%" HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:BoundColumn>

                                 <asp:BoundColumn HeaderText="Buyer Target Price" DataField="BuyerTargetPrice">
                                    <HeaderStyle Width="10%" HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:BoundColumn>
                                  <asp:BoundColumn HeaderText="Buyer Price Unit" DataField="BuyerTargetPriceUnit">
                                    <HeaderStyle Width="10%" HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:BoundColumn>

                                <asp:BoundColumn HeaderText="Price" DataField="Price">
                                    <HeaderStyle Width="10%" HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Price Unit" DataField="PriceUnit">
                                    <HeaderStyle Width="10%" HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Fabric Type" DataField="Fabric">
                                    <HeaderStyle Width="10%" HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Construction" DataField="Construction">
                                    <HeaderStyle Width="10%" HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Compostion" DataField="Compostion">
                                    <HeaderStyle Width="10%" HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Weight" DataField="Weight">
                                    <HeaderStyle Width="10%" HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Fabric Remarks" DataField="FabricRemarks">
                                    <HeaderStyle Width="10%" HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:BoundColumn>
                                  
                                <asp:TemplateColumn HeaderText="Action">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="lnkRemove" runat="server" CommandName="Remove" BackColor="transparent"
                                            ImageUrl="~/Images/RemoveIcon.png" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <table width="100%">
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Supplier Action Plan
            </th>
        </tr>
        <tr style="height: 6px">
            <td style="width: 78px;">
                <%--Requirement--%>
            </td>
            <td style="width: 214px;">
                <asp:DropDownList ID="cmbRequirement" AutoPostBack="false" runat="server" Width="156px"
                    ToolTip="select Requirement" Visible="false">
                </asp:DropDownList>
            </td>
            <td>
                <%-- Deadline--%>
            </td>
            <%--    <td class="TopHeaderTable3" style="width: 166px; height: 30px;">--%>
            <td>
                <asp:TextBox ID="txtCrDate" Width="100" runat="server" CssClass="textbox" Visible="false"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="txtCrDate"
                    PopupButtonID="ImageButton2" />
                <asp:ImageButton runat="Server" ID="ImageButton2" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                    AlternateText="Click here to display calendar" Visible="false" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtCrDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr style="height: 0px">
            <td style="width: 78px;">
                Fabric
            </td>
            <td style="width: 214px;">
                <asp:TextBox ID="txtFabricDate" Width="100" runat="server" CssClass="textbox"></asp:TextBox>
                <%--   <cc1:CalendarExtender ID="CalendarExtender6" Format="dd/MM/yyyy" runat="server" TargetControlID="txtFabricDate"
                            PopupButtonID="ImageButton4" />
                        <asp:ImageButton runat="Server" ID="ImageButton4" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                            AlternateText="Click here to display calendar" />
                        <cc1:MaskedEditExtender ID="MaskedEditExtender6" runat="server" TargetControlID="txtFabricDate"
                            Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                            CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                            Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                        </cc1:MaskedEditExtender>--%>
            </td>
            <td>
                Price
            </td>
            <%--    <td class="TopHeaderTable3" style="width: 166px; height: 30px;">--%>
            <td>
                <asp:TextBox ID="txtPriceDate" Width="100" runat="server" CssClass="textbox"></asp:TextBox>
                <%--  <cc1:CalendarExtender ID="CalendarExtender5" Format="dd/MM/yyyy" runat="server" TargetControlID="txtPriceDate"
                            PopupButtonID="ImageButton1" />
                        <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                            AlternateText="Click here to display calendar" />
                        <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtPriceDate"
                            Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                            CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                            Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                        </cc1:MaskedEditExtender>--%>
            </td>
            <td>
                Proto Sample
            </td>
            <td>
                <asp:TextBox ID="txtProtoSamplDate" Width="100" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender7" Format="dd/MM/yyyy" runat="server" TargetControlID="txtProtoSamplDate"
                    PopupButtonID="ImageButton5" />
                <asp:ImageButton runat="Server" ID="ImageButton5" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                    AlternateText="Click here to display calendar" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender7" runat="server" TargetControlID="txtProtoSamplDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>
            </td>
        </tr>
        <tr style="height: 66px">
            <td style="width: 78px;">
                Lab Dip
            </td>
            <td style="width: 214px;">
                <asp:TextBox ID="txtLabDipDate" Width="100" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender8" Format="dd/MM/yyyy" runat="server" TargetControlID="txtLabDipDate"
                    PopupButtonID="ImageButton6" />
                <asp:ImageButton runat="Server" ID="ImageButton6" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                    AlternateText="Click here to display calendar" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender8" runat="server" TargetControlID="txtLabDipDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>
            </td>
            <td>
                Photo Sample
            </td>
            <%--    <td class="TopHeaderTable3" style="width: 166px; height: 30px;">--%>
            <td>
                <asp:TextBox ID="txtPhotoSampleDate" Width="100" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender9" Format="dd/MM/yyyy" runat="server" TargetControlID="txtPhotoSampleDate"
                    PopupButtonID="ImageButton7" />
                <asp:ImageButton runat="Server" ID="ImageButton7" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                    AlternateText="Click here to display calendar" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender9" runat="server" TargetControlID="txtPhotoSampleDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>
            </td>
            <td>
                Sealer Sample
            </td>
            <td>
                <asp:TextBox ID="txtSellerDate" Width="100" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender10" Format="dd/MM/yyyy" runat="server"
                    TargetControlID="txtSellerDate" PopupButtonID="ImageButton8" />
                <asp:ImageButton runat="Server" ID="ImageButton8" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                    AlternateText="Click here to display calendar" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender10" runat="server" TargetControlID="txtSellerDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>
            </td>
        </tr>
        <tr>
            <td>
                Remarks
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtRemarksSupplier" TextMode="MultiLine" Width="311px" runat="server"
                    CssClass="textbox"></asp:TextBox>
            </td>
            <td>
            </td>
            <td>
                <asp:Label ID="lblLEnqSupplierACPID" runat="server" Text="0" Visible="false"></asp:Label>
                <asp:Label ID="lblLEnqCustomerACPID" runat="server" Text="0" Visible="false"></asp:Label>
                <asp:Button ID="btncr" CssClass="button" runat="server" Text="Add More" Visible="false" />
            </td>
        </tr>
    </table>
    <br />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="true">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td>
                        <Smart:SmartDataGrid ID="dgCPReq" runat="server" Width="100%" AllowSorting="True"
                            Visible="false" AutoGenerateColumns="False" CellPadding="2" CssClass="table"
                            PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="600" RecordCount="0"
                            ShowFooter="True" SortedAscending="yes">
                            <Columns>
                                <asp:BoundColumn HeaderText="Detail ID" DataField="EnquiriesSystemCPRID" Visible="false" />
                                <asp:BoundColumn HeaderText="Detail ID" DataField="CPRequirmentID" Visible="false" />
                                <asp:BoundColumn HeaderText="Requirement" DataField="CPRequirement">
                                    <HeaderStyle Width="10%" HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Deadline" DataField="CPRDate">
                                    <HeaderStyle Width="10%" HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Remarks" DataField="Remarks">
                                    <HeaderStyle Width="10%" HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="Dispatch Date">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtDispatcDate" Width="100" runat="server" CssClass="textbox"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="txtDispatcDate"
                                            PopupButtonID="btndispatchdate" />
                                        <asp:ImageButton runat="Server" ID="btndispatchdate" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                                            AlternateText="Click here to display calendar" />
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtDispatcDate"
                                            Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                                            CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                                            Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                                        </cc1:MaskedEditExtender>
                                    </ItemTemplate>
                                    <HeaderStyle Width="3%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Action">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="lnkRemove" runat="server" CommandName="Remove" BackColor="transparent"
                                            ImageUrl="~/Images/RemoveIcon.png" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <table width="100%">
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Buyer Action Plan
            </th>
        </tr>
        <tr style="height: 6px">
            <td style="width: 78px;">
                <%-- Requirement--%>
            </td>
            <td style="width: 214px;">
                <asp:DropDownList ID="cmbrequirmentBuyer" AutoPostBack="false" runat="server" Width="156px"
                    ToolTip="select Requirement" Visible="false">
                </asp:DropDownList>
            </td>
            <td>
                <%--      Date--%>
            </td>
            <%--    <td class="TopHeaderTable3" style="width: 166px; height: 30px;">--%>
            <td>
                <asp:TextBox ID="txtCrBDate" Width="100" runat="server" CssClass="textbox" Visible="false"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtCrBDate"
                    PopupButtonID="btnCrBDate" />
                <asp:ImageButton runat="Server" ID="btnCrBDate" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                    AlternateText="Click here to display calendar" Visible="false" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtCrBDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr style="height: 0px">
            <td style="width: 78px;">
                Tech Pack
            </td>
            <td style="width: 214px;">
                <asp:TextBox ID="txtTechPackDate" Width="100" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender11" Format="dd/MM/yyyy" runat="server"
                    TargetControlID="txtTechPackDate" PopupButtonID="ImageButton9" />
                <asp:ImageButton runat="Server" ID="ImageButton9" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                    AlternateText="Click here to display calendar" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender11" runat="server" TargetControlID="txtTechPackDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>
            </td>
            <td>
                Original Sample
            </td>
            <%--    <td class="TopHeaderTable3" style="width: 166px; height: 30px;">--%>
            <td>
                <asp:TextBox ID="txtOriginalSampleDate" Width="100" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender12" Format="dd/MM/yyyy" runat="server"
                    TargetControlID="txtOriginalSampleDate" PopupButtonID="ImageButton11" />
                <asp:ImageButton runat="Server" ID="ImageButton11" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                    AlternateText="Click here to display calendar" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender12" runat="server" TargetControlID="txtOriginalSampleDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>
            </td>
            <td>
                MOQ
            </td>
            <td>
                <asp:TextBox ID="txtMOQDate" Width="100" runat="server" CssClass="textbox"></asp:TextBox>
                <%--  <cc1:CalendarExtender ID="CalendarExtender13" Format="dd/MM/yyyy" runat="server" TargetControlID="txtMOQDate"
                            PopupButtonID="ImageButton12" />
                        <asp:ImageButton runat="Server" ID="ImageButton12" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                            AlternateText="Click here to display calendar" />
                        <cc1:MaskedEditExtender ID="MaskedEditExtender13" runat="server" TargetControlID="txtMOQDate"
                            Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                            CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                            Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                        </cc1:MaskedEditExtender>--%>
            </td>
        </tr>
        <tr style="height: 0px">
            <td style="width: 78px;">
                Cad/Artwork
            </td>
            <td style="width: 214px;">
                <asp:TextBox ID="txtCadArtworkDate" Width="100" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender14" Format="dd/MM/yyyy" runat="server"
                    TargetControlID="txtCadArtworkDate" PopupButtonID="ImageButton13" />
                <asp:ImageButton runat="Server" ID="ImageButton13" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                    AlternateText="Click here to display calendar" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender14" runat="server" TargetControlID="txtCadArtworkDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>
            </td>
            <td>
                Purchase Order
            </td>
            <%--    <td class="TopHeaderTable3" style="width: 166px; height: 30px;">--%>
            <td>
                <asp:TextBox ID="txtPurchaseOrderDate" Width="100" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender15" Format="dd/MM/yyyy" runat="server"
                    TargetControlID="txtPurchaseOrderDate" PopupButtonID="ImageButton14" />
                <asp:ImageButton runat="Server" ID="ImageButton14" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                    AlternateText="Click here to display calendar" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender15" runat="server" TargetControlID="txtPurchaseOrderDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                Remarks
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtRemarksBuyer" TextMode="MultiLine" Width="311px" runat="server"
                    CssClass="textbox"></asp:TextBox>
            </td>
            <td>
            </td>
            <td>
                <asp:Button ID="btnByerCRPAdd" CssClass="button" runat="server" Text="Add More" Visible="false" />
            </td>
        </tr>
    </table>
    <br />
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" ChildrenAsTriggers="true">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td>
                        <Smart:SmartDataGrid ID="dgCPReqBuyer" runat="server" Width="100%" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="2" CssClass="table" PagerCurrentPageCssClass=""
                            PagerOtherPageCssClass="" PageSize="600" RecordCount="0" ShowFooter="True" SortedAscending="yes"
                            Visible="false">
                            <Columns>
                                <asp:BoundColumn HeaderText="Detail ID" DataField="EnquiriesSystemCPRBuyerID" Visible="false" />
                                <asp:BoundColumn HeaderText="Detail ID" DataField="CPRequirmentBID" Visible="false" />
                                <asp:BoundColumn HeaderText="Requirement" DataField="CPRequirementB">
                                    <HeaderStyle Width="10%" HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Date" DataField="CPRBDate">
                                    <HeaderStyle Width="10%" HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Remarks" DataField="RemarksB">
                                    <HeaderStyle Width="10%" HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="Action">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="lnkRemove" runat="server" CommandName="Remove" BackColor="transparent"
                                            ImageUrl="~/Images/RemoveIcon.png" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <asp:UpdatePanel ID="UpdatePanel5" runat="server" ChildrenAsTriggers="true">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                        font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                        bgcolor="Silver">
                        Attachment
                    </th>
                </tr>
                <tr style="height: 34px">
                    <td>
                        File Name
                    </td>
                    <td>
                        <asp:TextBox ID="txtFileName" CssClass="textbox" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        File Description
                    </td>
                    <td>
                        <asp:TextBox ID="txtFileDescription" CssClass="textbox" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        File Upload
                    </td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnUpload" CssClass="button" runat="server" Text="Add More" />
                    </td>
                </tr>
            </table>
            <br />
            <table width="100%">
                <tr>
                    <td align="center">
                        <asp:Label ID="lblErrorMsg" runat="server" CssClass="ErrorMsg"></asp:Label>
                    </td>
                </tr>
                <tr style="height: 35px;">
                    <td>
                        <asp:UpdatePanel ID="UpdgFileInfo" runat="server">
                            <ContentTemplate>
                                <Smart:SmartDataGrid ID="dgFileInfo" runat="server" Width="100%" AllowPaging="True"
                                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                                    PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="15" RecordCount="0"
                                    ShowFooter="True" SortedAscending="yes" ForeColor="White">
                                    <Columns>
                                        <asp:BoundColumn HeaderText="EnquiresImageDetailID" DataField="EnquiresImageDetailID"
                                            Visible="false">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="EnquiriesSystemID" DataField="EnquiriesSystemID" Visible="false">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="FileName" DataField="FileNameWr">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="File Description" DataField="FileDescription">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:TemplateColumn HeaderText="File Name">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkFIle" CommandName="DownloadFile" Text='<% #Eval("FileName") %>'
                                                    runat="server"> </asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle Width="10%" />
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="" Visible="false">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Image ID="Image1" Visible="true" runat="server" Height="70" Width="150" />
                                            </ItemTemplate>
                                            <HeaderStyle Width="7%" />
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="Remove">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="lnkRemove" OnClientClick="return confirm('OK to Delete?');"
                                                    ToolTip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png"
                                                    CommandName="Remove" runat="server"></asp:ImageButton>
                                            </ItemTemplate>
                                            <HeaderStyle Width="2%" HorizontalAlign="Center" />
                                        </asp:TemplateColumn>
                                    </Columns>
                                    <PagerStyle CssClass="GridPagerStyle" Mode="NumericPages" HorizontalAlign="Right" />
                                    <AlternatingItemStyle CssClass="GridAlternativeRow" />
                                    <ItemStyle CssClass="GridRow" />
                                    <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                                </Smart:SmartDataGrid>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
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
