<%@ Page Title="Costing Center" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="CostingCenter.aspx.vb" Inherits="Integra.CostingCenter" %>
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
         <tr class="heading"> 
     <td colspan="4">
                &nbsp;  <b>COSTING CENTER </b>
               </td>            </tr>
    </table>
    <table>
    <tr style="height: 35px;">
            <td>
              <div class="txt_newwww" style="width: 140px;">
                Category:
            </div> </td>
            <td>
                <asp:DropDownList ID="cmbCategory" runat="server" Width="125px" AutoPostBack="false"
                    CssClass="combo" style="margin-left: 10px;" >
                </asp:DropDownList>
            </td>
            </tr> 
            <tr style="height: 35px;">
            <td>
              <div class="txt_newwww" style="width: 140px;">
                Cost Center:
            </div> </td>
            <td>
            <div class="text_box" style="">
               <asp:textbox id="txtCost" runat="server" width="153" CssClass="textbox" style="margin-left: 10px;"  ></asp:textbox>
            </div> </td>
            </tr> 
           <tr>
           </tr>
<tr style="height: 35px;">
        <td>
            </td>
            <td align="center">
                <asp:Button ID="btnSave" CssClass="btn btn-outline btn-success" runat="server" Text="Save" style="margin-left: 208px;float: left;width: 70px;" />&nbsp; &nbsp;
                <asp:Button ID="btnCancel" CssClass="btn btn-outline btn-danger" runat="server" Text="Cancel" />
            </td>
        </tr>
 <%--<asp:Button ID="btnSave" Text="Save" Runat="server" Width="100" CssClass="button"></asp:Button> 
 <asp:Button ID="btnCancel" Text="Cancel" Runat="server" Width="100" CssClass="button" ></asp:Button> 
</td></tr>--%>
    </table>
</asp:Content>



