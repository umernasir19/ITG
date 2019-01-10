<%@ Page Title="Export DashBoard" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="ExportDashBoard.aspx.vb" Inherits="Integra.ExportDashBoard" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<br />
<table >


<tr>
<td>
<b>
Export Dashboard 
</b>
 </td>
</tr>
</table>

<br />
<table>

<tr>

<td>
<asp:Button ID="btnCertificate"  runat="server" CssClass="button" text="Supp/Ben Certificate" Width="160px" style=" margin-left: 7px;" Visible="true"  />
</td>

<td>
<asp:Button ID="btnGSP"  runat="server" CssClass="button" text="GSP" Width="160px" style=" margin-left: 7px;" Visible="true"  />
</td>

<td>
<asp:Button ID="BtnITPerforma"  runat="server" CssClass="button" text="I.T PROFORMA" Width="160px" style=" margin-left: 7px;" Visible="true"  />
</td>


</tr>
</table>
<br />
<table>
<tr>

<td>
<asp:Button ID="btnBuyerCover"  runat="server" CssClass="button" text="Buyer Covering" Width="160px" style=" margin-left: 7px;" Visible="true"  />
</td>

<td>
<asp:Button ID="btnPREGMAco"  runat="server" CssClass="button" text="PREGMA-CO" Width="160px" style=" margin-left: 7px;" Visible="true"  />
</td>

<td>
<asp:Button ID="btnbankCovering"  runat="server" CssClass="button" text="Bank Covering" Width="160px" style=" margin-left: 7px;" Visible="true"  />
</td>


</tr>
</table>
<br />
<table>
<tr>

<td>
<asp:Button ID="btnMailRealization"  runat="server" CssClass="button" text="Mail Realization" Width="160px" style=" margin-left: 7px;" Visible="true"  />
</td>

<td>
<asp:Button ID="btnRateNEGO"  runat="server" CssClass="button" text="Rate-NEGO" Width="160px" style=" margin-left: 7px;" Visible="true"  />
</td>

<td>
<asp:Button ID="btnShipmentInfoAcc"  runat="server" CssClass="button" text="Shipment-Info-Acc" Width="160px" style=" margin-left: 7px;" Visible="true"  />
</td>


</tr>
</table>
</asp:Content>
