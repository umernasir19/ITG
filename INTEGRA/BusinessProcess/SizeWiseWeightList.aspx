<%@ Page Title="Size Wise Weight List" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="SizeWiseWeightList.aspx.vb" Inherits="Integra.SizeWiseWeightList" %>
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
                Sr No
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
           




         
            <tr>
                <td>
                    Cust. Color
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtCustColor" runat="server" ReadOnly="True"></asp:TextBox>
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
             <asp:UpdatePanel ID="uddgStyleAssortment" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                <Smart:SmartDataGrid ID="dgStyleAssortment" runat="server" Width="100%" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                    PageSize="1000" ShowFooter="True" ForeColor="white" GridLines="both">
                    <Columns>
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="SizeWiseWeightListDtlID"
                            DataField="SizeWiseWeightListDtlID" visible="false" />
                      
                         <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="SizeRangeId"
                            DataField="SizeRangeId" visible="false" />
                               <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="SizeDatabaseId"
                            DataField="SizeDatabaseId" visible="false" />
                               <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="StyleAssortmentDetailID"
                            DataField="StyleAssortmentDetailID" visible="false" />
                               <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="StyleAssortmentMasterID"
                            DataField="StyleAssortmentMasterID" visible="false" />
                               <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="CuttingProDetailID"
                            DataField="CuttingProDetailID" visible="false" />
                               <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="CuttingProMasterID"
                            DataField="CuttingProMasterID" visible="false" />
                               <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Joborderid"
                            DataField="Joborderid" visible="false" />
                                 <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="JoborderDetailid"
                            DataField="JoborderDetailid" visible="false" />


            
   <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="12%" HeaderText="Color"
                            DataField="buyercolor">
                            <headerstyle width="10%" horizontalalign="center" />
                        </asp:BOUNDCOLUMN>

                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="12%" HeaderText="Size"
                            DataField="Size">
                            <headerstyle width="10%" horizontalalign="center" />
                        </asp:BOUNDCOLUMN>

                               <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="12%" HeaderText="Qty"
                            DataField="Qty">
                            <headerstyle width="10%" horizontalalign="center" />
                        </asp:BOUNDCOLUMN>
                      
                          <asp:TEMPLATECOLUMN HeaderText="Extra">
                            <itemtemplate>
<asp:textbox   id="txtExtra" AutoPostBack ="true"  OnTextChanged="txtExtra_TextChanged" style="text-align: center; width :50px;" CssClass="textbox"  runat="server" ReadOnly ="false"  ></asp:textbox> 
                        </itemtemplate>
                            <headerstyle width="4%" horizontalalign="center" />
                            <itemstyle horizontalalign="Center" />
                        </asp:TEMPLATECOLUMN>

                            <asp:TEMPLATECOLUMN HeaderText="Total Qty">
                            <itemtemplate>
<asp:textbox   id="txtTotalQty" style="text-align: center; width :100px;" CssClass="textbox"  runat="server" ReadOnly ="false"  ></asp:textbox> 
                        </itemtemplate>
                            <headerstyle width="4%" horizontalalign="center" />
                            <itemstyle horizontalalign="Center" />
                        </asp:TEMPLATECOLUMN>


                        <asp:TEMPLATECOLUMN HeaderText="Dimension">
                            <itemtemplate>
<asp:textbox   id="txtDimension" OnTextChanged="txtDimension_TextChanged" AutoPostBack ="true" style="text-align: center; width :100px;" CssClass="textbox"  runat="server" ReadOnly ="false"  ></asp:textbox> 
                        </itemtemplate>
                            <headerstyle width="4%" horizontalalign="center" />
                            <itemstyle horizontalalign="Center" />
                        </asp:TEMPLATECOLUMN>

                         <asp:TEMPLATECOLUMN HeaderText="Weight">
                            <itemtemplate>
<asp:textbox   id="txtWeight" AutoPostBack="true"  OnTextChanged="txtWeight_TextChanged" style="text-align: center; width :100px;" CssClass="textbox" onkeypress="return isNumericKeyy(event);" runat="server" ReadOnly ="false"  ></asp:textbox> 
                        </itemtemplate>
                            <headerstyle width="4%" horizontalalign="center" />
                            <itemstyle horizontalalign="Center" />
                        </asp:TEMPLATECOLUMN>


                          <asp:TEMPLATECOLUMN HeaderText="Pcs Per Carton">
                            <itemtemplate>
<asp:textbox   id="txtPcsPerCarton" OnTextChanged="txtPcsPerCarton_TextChanged" AutoPostBack ="true"  style="text-align: center; width :100px;" CssClass="textbox" onkeypress="return isNumericKeyy(event);" runat="server" ReadOnly ="false"  ></asp:textbox> 
                        </itemtemplate>
                            <headerstyle width="4%" horizontalalign="center" />
                            <itemstyle horizontalalign="Center" />
                        </asp:TEMPLATECOLUMN>
                          <asp:TEMPLATECOLUMN HeaderText="Weight Per Piece">
                            <itemtemplate>
<asp:textbox   id="txtWeightPerPiece" style="text-align: center; width :100px;" CssClass="textbox" onkeypress="return isNumericKeyy(event);" runat="server" ReadOnly ="false"  ></asp:textbox> 
                        </itemtemplate>
                            <headerstyle width="4%" horizontalalign="center" />
                            <itemstyle horizontalalign="Center" />
                        </asp:TEMPLATECOLUMN>
                           <asp:TEMPLATECOLUMN HeaderText="No Of Carton">
                            <itemtemplate>
<asp:textbox   id="txtNoOfCarton" style="text-align: center; width :100px;" CssClass="textbox" onkeypress="return isNumericKeyy(event);" runat="server" ReadOnly ="true"  ></asp:textbox> 
                        </itemtemplate>
                            <headerstyle width="4%" horizontalalign="center" />
                            <itemstyle horizontalalign="Center" />
                        </asp:TEMPLATECOLUMN>

                          <asp:TEMPLATECOLUMN HeaderText="Balance">
                            <itemtemplate>
<asp:textbox   id="txtBalance" style="text-align: center; width :100px;" CssClass="textbox" onkeypress="return isNumericKeyy(event);" runat="server" ReadOnly ="true"  ></asp:textbox> 
                        </itemtemplate>
                            <headerstyle width="4%" horizontalalign="center" />
                            <itemstyle horizontalalign="Center" />
                        </asp:TEMPLATECOLUMN>

                        <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="01%" HeaderText="Remove" Visible ="false" >
                            <itemtemplate>
<asp:ImageButton id="lnkRemove" tooltip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png" CommandName="Remove" runat="server"></asp:ImageButton>
						</itemtemplate>
                        </asp:TEMPLATECOLUMN>
                    </Columns>
                    <PagerStyle HorizontalAlign="NotSet" />
                </Smart:SmartDataGrid>
                  </ContentTemplate>
                        </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td>
                <asp:Button ID="btnShowQty" runat="server" Visible="false" CssClass="button"></asp:Button>
            </td>
           
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td align="center">
                <asp:Button ID="btnsave" runat="server" CssClass="button" Visible="false" Text="Save">
                </asp:Button>
                <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel"></asp:Button>
            </td>
        </tr>
    </table>
    <table>
    <tr>
    <td>
    <asp:Label ID ="lblid" runat ="server" Visible ="false" Text ="0"></asp:Label>
    </td>
    </tr>
    <tr>

          

            <td>
             <asp:TextBox ID="txtShipNo" runat="server" Visible ="false"  CssClass="forcapital" ReadOnly ="true"  AutoPostBack="false" Width="150px" style=" margin-left: 15px;"></asp:TextBox>
            </td>


           
            </tr> 
    </table>
</asp:Content>


