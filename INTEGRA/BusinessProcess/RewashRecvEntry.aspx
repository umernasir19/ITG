<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="RewashRecvEntry.aspx.vb" Inherits="Integra.RewashRecvEntry" %>
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
    <table>
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="6" align="left" style="font-family: 'Calibri'; font-size: 17px; font-weight: bold;
                font-style: inherit; color: #336699; font-variant: inherit; height: 29px;" valign="bottom">
                Rewash Receive
            </th>
        </tr>
    </table>
    <table>
        
        <tr>
            <td style="width:100px;">
                Date
            </td>
            <td style="padding:5px;">
             <asp:UpdatePanel ID="upDate" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                <asp:TextBox ID="txtDate" Style="margin-left: 0px; width: 150px;" autopostback="true"
                    runat="server" Font-Size="8pt"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtDate"
                        PopupButtonID="ImageButton1" />
                    <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" ImageUrl="~/Images/callendar.jpg"
                        AlternateText="Click here to display calendar" Style="margin-left:0px; "  />
                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDate"
                        Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                        CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                        Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                    </cc1:MaskedEditExtender>
                        </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                Challan No
            </td>
            <td style="padding:5px;">
                 <asp:UpdatePanel ID="upChallanNo" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                <asp:TextBox ID="txtChallanNo" runat="server" Width="150px" CssClass="textbox" autopostback="true" Style="
                     height: 16px;"  ></asp:TextBox>
                     </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                Season
            </td>
            <td  style="padding:5px;">
                <asp:UpdatePanel ID="UpcmbSeason" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbSeason" runat="server" Skin="WebBlue" Width="150px" AutoPostBack="true">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                SR NO
            </td>
            <td  style="padding:5px;">
                <asp:UpdatePanel ID="UpcmbSrNo" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbSrNo" runat="server" Width="150px" Skin="WebBlue" AutoPostBack="true">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
             <td>
                Color
            </td>
            <td style="padding:5px;">
                <asp:UpdatePanel ID="UpcmbColor" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbColor" runat="server" Width="150px" Skin="WebBlue" AutoPostBack="true">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                Rewash Qty
            </td>
            <td  style="padding:5px;">
                <asp:TextBox ID="txtRewashQty" runat="server" Width="150px" CssClass="textbox" Style=" height: 16px;"  onkeypress="return isNumericKeyy(event);"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Remarks
            </td>
            <td style="padding:5px;">
                <asp:TextBox ID="txtRemarks" runat="server" Width="150px" CssClass="textbox" Style="height: 16px;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td style="padding:5px;">
                <asp:Button ID="btnCancel" ToolTip="Cancel" CssClass="btn btn-default"
                    runat="server" Text="Cancel" Width="70px"  />
                    <asp:Button ID="btnSave" ToolTip="Save" CssClass="btn btn-success"
                    runat="server" Text="Save"/>
            </td>
        </tr>
    </table>
</asp:Content>
