<%@ Page Title="Style Assortment Entry" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="StyleAssortmentEntry.aspx.vb" Inherits="Integra.StyleAssortmentEntry" %>
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
        <tr>
            <td>
                <b>Basic Information </b>
            </td>
        </tr>
        <tr>
            <td>
                Merchandiser
            </td>
            <td>
                <asp:TextBox CssClass="textbox" ID="txtMarchand" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                Date
            </td>
            <td>
                <asp:TextBox ID="txtCreationDate" CssClass="textbox" Width="120" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtCreationDate"
                    PopupButtonID="ImageButton1" />
                <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
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
            <td>
                Style
            </td>
            <td>
                <asp:TextBox CssClass="textbox" ID="txtStyle" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                PO No
            </td>
            <td>
                <asp:TextBox CssClass="textbox" ID="txtJobNo" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Season
            </td>
            <td>
                <asp:TextBox CssClass="textbox" ID="txtSeason" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                Customer
            </td>
            <td>
                <asp:TextBox CssClass="textbox" ID="txtCustomer" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Brand
            </td>
            <td>
                <asp:TextBox CssClass="textbox" ID="txtBrand" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                Cust. PO
            </td>
            <td>
                <asp:TextBox CssClass="textbox" ID="txtCustPo" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Item Desc.
            </td>
            <td>
                <asp:TextBox CssClass="textbox" ID="txtItem" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                GSM
            </td>
            <td>
                <asp:TextBox CssClass="textbox" ID="txtGSM" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Fabric Quality
            </td>
            <td>
                <asp:TextBox CssClass="textbox" ID="txtContent" runat="server" ReadOnly="True"></asp:TextBox>
            </td>

             <td>
                Quantity
            </td>
            <td>
                <asp:TextBox ID="txtQuantity" CssClass="textbox" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <b>Statistics </b>
            </td>
        </tr>
        <tr>
            <td>
                Price
            </td>
            <td>
                <asp:TextBox ID="txtPrice" CssClass="textbox" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
           




         <td>
              Extra  Qty %
            </td>
            <td>
                <asp:TextBox ID="txtExtaQty" CssClass="textbox" runat="server" AutoPostBack ="true"  ReadOnly="false"  onkeypress="return isNumericKey(event);"></asp:TextBox>
            </td>
            <tr>
                <td>
                    Cust. Color
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtCustColor" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td>
                    <asp:CheckBox ID="chkLabDipapprovalbycustomer" runat="server" visible="false"></asp:CheckBox>
                </td>
                <%--<td>
                    Required Lab Dip approval by customer
                </td>--%>
            </tr>
            <tr>
                <td>
                    <b>Assortment </b>
                </td>
            </tr>
            <tr>
                <td>
                    Gender
                </td>
                <td>
                    <asp:DropDownList ID="cmbGender" Width="135" AutoPostBack="true" CssClass="combo"
                        runat="server">
                    </asp:DropDownList>
                    <asp:LinkButton ID="LinkAddGender" runat="server" Visible="true">Add Gender</asp:LinkButton>
                    <asp:ImageButton ID="btnGenderShow" runat="server" BackColor="transparent" ToolTip="Click here to show data."
                        ImageUrl="~/Images/redCal.jpg" Width="15px" />
                </td>
                <td>
                    Size Range
                </td>
                <td>
                    <asp:DropDownList ID="cmbSizeRange" Width="135" CssClass="combo" AutoPostBack="true"
                        runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Break
                </td>
                <td>
                    <asp:DropDownList ID="cmbBreak" Width="135" CssClass="combo" AutoPostBack="true"
                        runat="server">
                    </asp:DropDownList>
                </td>
                <td colspan="3">
                    <asp:Panel runat="server" ID="pnlAssort" Visible="false">
                        <table>
                            <tr>
                                <td>
                                    Ratio QTY
                                </td>
                                <td>
                                    <asp:TextBox CssClass="textbox" ID="txtRatioQty" Width="60px" runat="server" AutoPostBack="true"
                                        Style="margin-left: 61px;" ReadOnly="false"></asp:TextBox>
                                </td>
                                <td>
                                    Assorted QTY
                                </td>
                                <td>
                                    <asp:TextBox CssClass="textbox" ID="txtAssortedQty" Style="margin-left: 8px;" Width="60px"
                                        runat="server" ReadOnly="True"></asp:TextBox>
                                </td>

                              

                            </tr>
                           
                        </table>


                    </asp:Panel>
                </td>
            </tr>
            
    </table>
    <table>
     <tr>
                              <td align ="left" >
                                
                                  <asp:Button ID="btnDeleteAssortment" Visible ="false"  style=" margin-left: 666px;  Width:108px" runat="server" CssClass="button"  Text="Delete All Size">
                </asp:Button>
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
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="StyleAssortmentDetailID"
                            DataField="StyleAssortmentDetailID" visible="false" />
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="SizeRangeID"
                            DataField="SizeRangeID" visible="false" />
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="SizeDatabaseID"
                            DataField="SizeDatabaseID" visible="false" />
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="12%" HeaderText="Size"
                            DataField="Sizes">
                            <headerstyle width="10%" horizontalalign="center" />
                        </asp:BOUNDCOLUMN>
                        <asp:TEMPLATECOLUMN HeaderText="Ratio">
                            <itemtemplate>
<asp:textbox   CssClass="textbox" style="text-align: center; width :100px;" id="txtRatio" AutoPostBack="true" OnTextChanged="txtRatio_TextChanged"   onkeypress="return isNumericKey(event);" runat="server" ></asp:textbox> 
                        </itemtemplate>
                            <headerstyle width="4%" horizontalalign="center" />
                            <itemstyle horizontalalign="Center" />
                        </asp:TEMPLATECOLUMN>
                        <asp:TEMPLATECOLUMN HeaderText="Unit">
                            <itemtemplate>
<asp:dropdownlist id="cmbUnit"  style="text-align: center;" CssClass="combo"    runat="server" Width="135"   ></asp:dropdownlist>
                        </itemtemplate>
                            <headerstyle width="4%" horizontalalign="center" />
                            <itemstyle horizontalalign="Center" />
                        </asp:TEMPLATECOLUMN>
                        <asp:TEMPLATECOLUMN HeaderText="Ratio Qty">
                            <itemtemplate>
<asp:textbox   id="txtQty" style="text-align: center; width :100px;" CssClass="textbox" onkeypress="return isNumericKeyy(event);" runat="server" ReadOnly ="true"  ></asp:textbox> 
                        </itemtemplate>
                            <headerstyle width="4%" horizontalalign="center" />
                            <itemstyle horizontalalign="Center" />
                        </asp:TEMPLATECOLUMN>
                        <asp:TEMPLATECOLUMN HeaderText="Assorted Qty">
                            <itemtemplate>
<asp:textbox   id="txtAssortQty" style="text-align: center; width :100px;" CssClass="textbox" onkeypress="return isNumericKeyy(event);" AutoPostBack="true" OnTextChanged="txtAssortQty_TextChanged" runat="server" ></asp:textbox> 
                        </itemtemplate>
                            <headerstyle width="4%" horizontalalign="center" />
                            <itemstyle horizontalalign="Center" />
                        </asp:TEMPLATECOLUMN>

                         <asp:TEMPLATECOLUMN HeaderText="Extra Qty">
                            <itemtemplate>
<asp:textbox   id="txtExtra" style="text-align: center;width :100px;" CssClass="textbox" onkeypress="return isNumericKeyy(event);" runat="server" width="100px"></asp:textbox> 
                        </itemtemplate>
                            <headerstyle width="4%" horizontalalign="center" />
                            <itemstyle horizontalalign="Center" />
                        </asp:TEMPLATECOLUMN>
                        


                        <asp:TEMPLATECOLUMN HeaderText="Total Qty">
                            <itemtemplate>
<asp:textbox   id="txtBalanceQty" style="text-align: center; width :100px;" CssClass="textbox" onkeypress="return isNumericKeyy(event);" runat="server"  ></asp:textbox><%-- DataFormatString="{0:f0}"--%>
                        </itemtemplate>
                            <headerstyle width="4%" horizontalalign="center" />
                            <itemstyle horizontalalign="Center" />
                        </asp:TEMPLATECOLUMN>

                         <asp:TEMPLATECOLUMN HeaderText="LineNo" Visible ="false" >
                            <itemtemplate>
<asp:textbox   id="txtLineno" style="text-align: center; width :100px;" CssClass="textbox"   runat="server"  ></asp:textbox><%-- DataFormatString="{0:f0}"--%>
                        </itemtemplate>
                            <headerstyle width="4%" horizontalalign="center" />
                            <itemstyle horizontalalign="Center" />
                        </asp:TEMPLATECOLUMN>
                        
                        
                        <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="01%" HeaderText="Remove" Visible ="true" >
                            <itemtemplate>
<asp:ImageButton id="lnkRemove" tooltip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png" CommandName="Remove" runat="server"></asp:ImageButton>
						</itemtemplate>
                        </asp:TEMPLATECOLUMN>
                    </Columns>
                    <PagerStyle HorizontalAlign="NotSet" />
                </Smart:SmartDataGrid>
            </td>
        </tr>
    </table>

       <table>
    <tr>
    <td>
    <asp:Label ID="lblTotalAssort" runat ="server" style=" margin-left: 531px; font-weight: bold;" ></asp:Label>
   </td> <td>
<asp:Label ID="lblTotalQty" runat ="server" style=" margin-left: 249px; font-weight: bold;" ></asp:Label>
 </td>
   </tr>
    </table>


    <table width="100%">
        <tr>
            <td>
                <asp:Button ID="btnShowQty" runat="server" Visible="false" CssClass="button"></asp:Button>
            </td>
            <td align="right">
                <asp:CheckBox ID="chkEmbelishmentReq" runat="server" visible="false"></asp:CheckBox>
            </td>
            <%--<td>
                Embelishment required in this style
            </td>--%>
        </tr>
    </table>
    <br />
 <br />
    <table width="100%">
        <tr>
            <td align="center">
                <asp:Button ID="btnsave" runat="server" CssClass="button" Visible="false" Text="Save">
                </asp:Button>
                <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel"></asp:Button>
            </td>
        </tr>
           <tr>
            <td align="center">
              <asp:Label ID ="lblUserId" runat ="server" Visible ="false" Text="0"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

