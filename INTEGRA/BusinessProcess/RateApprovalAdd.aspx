<%@ Page Title="Rate Approval for Negotiation" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="RateApprovalAdd.aspx.vb" Inherits="Integra.RateApprovalAdd" %>
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
    function TABLE1_onclick() {

    }

    </script>
       <table width="100%">
      <tr class="heading">
            <td>
                &nbsp; <b>RATE APPROVAL FOR NEGOTIATION</b>:-
            </td>
        </tr>
    </table><br />
      <table >
             <tr style="height: 35px;">
            <td>
                <div class="txt_newwww" style="width: 140px; margin-left: 0px;">
                   DATED :
                </div>
            </td>
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtInvDate" Width ="138px" CssClass="textbox" runat="server" Style="margin-left: 0px;
                        height: 20px;" ReadOnly="false" AutoPostBack="false"></asp:TextBox>
                     </div>   
                     </td>


                     </tr> 
                     <tr style="height: 35px;">
                      <td>
                <div class="txt_newwww" style="width: 140px; margin-left: 0px;">
                   INVOICE #
                </div>
            </td>
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtInvNo" Width ="138px" CssClass="textbox" runat="server" Style="margin-left: 0px;
                        height: 20px;" ReadOnly="false" AutoPostBack="false"></asp:TextBox>
                     </div>   
                     </td>
            <td>
                <div class="txt_newwww" style="width: 140px; margin-left: 133px; margin-top: -49px;">
                   BUYERS :
                </div>
            </td>
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtBuyer" Width ="138px" CssClass="textbox" TextMode ="MultiLine"  runat="server" Style="margin-left:0px; margin-top: -34px;
                        height: 20px;" ReadOnly="false" AutoPostBack="false"></asp:TextBox>
                     </div>   
                     </td>


                     </tr> 
                       <tr style="height: 35px;">
                      <td>
                <div class="txt_newwww" style="width: 140px; margin-left: 0px;">
                   AMOUNT #
                </div>
            </td>
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtAmount" Width ="138px" CssClass="textbox" runat="server" Style="margin-left: 0px;
                        height: 20px;" ReadOnly="false" AutoPostBack="false"></asp:TextBox>
                     </div>   
                     </td>
            <td>
                <div class="txt_newwww" style="width: 140px; margin-left: 133px;">
                   TERMS :
                </div>
            </td>
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtterms" Width ="138px" CssClass="textbox" runat="server" Style="margin-left: 0px;
                        height: 20px;" ReadOnly="false" AutoPostBack="false"></asp:TextBox>
                     </div>   
                     </td>

                     </tr> 
                       <tr style="height: 35px;">
                      <td>
                <div class="txt_newwww" style="width: 140px; margin-left: 0px;">
                   PKR :
                </div>
            </td>
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtPkr" Width ="138px" CssClass="textbox" runat="server" Style="margin-left: 0px;
                        height: 20px;" ReadOnly="false" AutoPostBack="false"></asp:TextBox>
                     </div>   
                     </td>
                     </tr> 

                     </table><table>
                     <tr>
                      <asp:Panel ID="PnlFROM1" runat="server" Visible="true">
                    <td>
                        <div class="txt_newwww" style="width: 140px; margin-left: 0px;">
                           FROM #
                        </div>
                    </td>
                    <td>
                        <asp:DropDownList ID="cmbfrom" Width="138" CssClass="combo" AutoPostBack="true"
                            runat="server" Style=" margin-left: 2px;">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:ImageButton ID="BtnAddFROM" runat="server" ImageUrl="~/Images/AddButton.jpg" Style="margin-left: 0px;
                            width: 19px;" />
                    </td>
                </asp:Panel>
                <asp:Panel ID="PnlFROM2" runat="server" Visible="false">
                    <td style="width: 150px;">
                        <div class="txt_newwww" style="width: 140px; margin-left: 0px;">
                           FROM #
                        </div>
                    </td>
                    <td>
                        <div class="text_box" style="">
                            <asp:TextBox ID="txtAddFROM" runat="server" Width="132px" CssClass="textbox" Style="margin-right: 0px;
                                margin-left: -5px; height: 22px;"></asp:TextBox>
                        </div>
                        <asp:ImageButton ID="BtnSaveFROM" runat="server" ImageUrl="~/Images/SaveButton.jpg"
                            Style="margin-left: 87px; width: 19px;" />
                    </td>
                </asp:Panel>
              




            <td>
                <div class="txt_newwww" style="width: 140px; margin-left:20px;">
                   FINAL@ :
                </div>
            </td>
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtFinal" Width ="94px" CssClass="textbox" runat="server" Style="margin-left: 0px;
                        height: 20px;" ReadOnly="false" AutoPostBack="false"></asp:TextBox>
                     </div>   
                     </td>


                     </tr> 
                       </table><table>
                       <tr style="height: 35px;">
                      <td >
                <div class="txt_newwww" style="width: 140px; margin-left: 0px;">
                   BANKER #
                </div>
            </td>
            <td style ="width :1px;">
                <div style="">
                        <asp:DropDownList ID="cmbBank" Width="138" CssClass="combo" AutoPostBack="false"
                            runat="server" Style=" margin-left: 0px; height: 25px;">
                        </asp:DropDownList>
                                  
                     </div>   
                     </td>
            <td>
                <div class="txt_newwww" style="width: 140px; margin-left: 41px;">
                   RATE@ :
                </div>
            </td>
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtRate" Width ="100" CssClass="textbox" runat="server" Style="margin-left: 0px;
                        height: 20px;" ReadOnly="false" AutoPostBack="false"></asp:TextBox>
                     </div>   
                     </td>


                     </tr> 
                     </table> <br />
                      <table width="100%">
      <tr >
            <td>
            <asp:Button ID="btnAdd" ToolTip="Click here To ADD." CssClass="btn btn-outline btn-success"
                    runat="server" Text="ADD" Width="120px" />
            </td>
        </tr>
    </table><br />
     <table width="50%">
        <tr>
            <td>
            <div style ="">
                <Smart:SmartDataGrid ID="dgDetail" runat="server" ForeColor="white" CssClass="table"
                    Width="100%" ShowFooter="True" PageSize="20" CellPadding="2" GridLines="both"
                    AutoGenerateColumns="False" AllowSorting="True">
                    <PagerStyle Mode="NumericPages" CssClass="GridPagerStyle" HorizontalAlign="Center"
                        Visible="False"></PagerStyle>
                    <AlternatingItemStyle CssClass="GridAlternativeRow"></AlternatingItemStyle>
                    <ItemStyle CssClass="GridRow"></ItemStyle>
                    <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center"></HeaderStyle>
                    <Columns>
                        <asp:BoundColumn DataField="RateApproveDtlID" ItemStyle-HorizontalAlign="center" HeaderText="Detail ID" Visible="false">
                        </asp:BoundColumn>
                          <asp:BoundColumn DataField="BankID" HeaderText="Detail ID" Visible="false">
                        </asp:BoundColumn>
                         <asp:BoundColumn DataField="Banker" ItemStyle-HorizontalAlign="center" HeaderText="Banker" Visible="true">
                        </asp:BoundColumn>
                         <asp:BoundColumn DataField="Rate" ItemStyle-HorizontalAlign="center" HeaderText="Rate" Visible="true">
                        </asp:BoundColumn>
                                        
                    </Columns>
                </Smart:SmartDataGrid>
                </div>
            </td>
        </tr>
     
    </table><br />
       <table width="50%">
        <tr style="height: 30px;">
            <td align="center">
                <asp:Button ID="btnCancel" CssClass="btn btn-outline btn-danger" runat="server" Text="Cancel"
                    Width="120px" Visible ="false"  />
                <asp:Button ID="btnSave" ToolTip="Click here To Print." CssClass="btn btn-outline btn-success"
                    runat="server" Text="Print" Width="120px" />
            </td>
        </tr>
    </table>
</asp:Content>

