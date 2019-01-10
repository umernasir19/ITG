<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="PerformaInvoiceAdd.aspx.vb" Inherits="Integra.PerformaInvoiceAdd" %>
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
</asp:Content>
