<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="JoborderDetailMovePopup.aspx.vb" Inherits="Integra.JoborderDetailMovePopup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Move Job Order Detail Data</title>

     <link type="text/css" rel="stylesheet" href="../App_Themes/Blue/NewCSS/NewStyle.css" />
    <link type="text/css" rel="stylesheet" href="../css/style.css" />
    <link type="text/css" rel="stylesheet" href="../App_Themes/Blue/StyleSheet.css" />
 
    <link type="text/css" rel="stylesheet" href="../css/VAF.css" />
   
    <link href="../css/buttons.css" rel="stylesheet" type="text/css" />



<link type="text/css" rel="stylesheet" href="../App_Themes/Blue/NewCSS/NewStyle.css" />
    <link type="text/css" rel="stylesheet" href="../css/style.css" />
    <link type="text/css" rel="stylesheet" href="../App_Themes/Blue/StyleSheet.css" />
    <link href="../StyleSheet.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript" src="../JavaScript/Maskdiv.js"></script>

    <script type="text/javascript" language="JavaScript" src="../scripts/Calender.js"></script>

    <script type="text/javascript" src="../scripts/thickbox.js"></script>

    <script type="text/javascript" src="../scripts/jquery.js"></script>

    <script type="text/javascript" language="JavaScript" src="../scripts/pupdate.js"></script>

    <link rel="stylesheet" href="../scripts/ThickBox.css" type="text/css" media="screen" />
    <link type="text/css" rel="stylesheet" href="../App_Themes/Blue/MenuCSS.css" />
    <link type="text/css" rel="stylesheet" href="../NewLayout.css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/sooperfish.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="../../Styles/sooperfish-theme-large.css"
        media="screen" />

    <script type="text/javascript" src="../../Jquery/jquery-1.4.2.min.js"></script>

    <script type="text/javascript" src="../../Jquery/jquery.easing-sooper.js"></script>

    <script type="text/javascript" src="../../Jquery/jquery.sooperfish.js"></script>

    <script type="text/javascript">
        function doResize() {
            document.getElementById("box-contents").style.height = (document.documentElement.clientHeight - 60) + "px";
        }
        window.onresize = doResize;
 
    </script>

    <script type="text/javascript">
        function RadioChecked(param) {
            {
                var frm = document.forms[0];
                for (i = 0; i < frm.length; i++) {
                    if (frm.elements[i].type == "radio") {
                        if (param != frm.elements[i].id) {
                            frm.elements[i].checked = false;
                        }
                    }

                }
            }

        }

    </script>

    <script type="text/javascript">

        function isNumericKey(e) {
            var charInp = window.event.keyCode;
            if (charInp > 31 && (charInp < 48 || charInp > 57)) {
                return false;
            }
            return true;
        }

        function NotZero(source) {
            var txtBox = document.getElementById(source);
            var txt = txtBox.value;
            if (txt == 0) {
                txtBox.value = 1;
            }
        }
        function isNumericKeyy(e) {
            var charInp = window.event.keyCode;
            if (charInp != 46 && (charInp < 48 || charInp > 57)) {
                return false;
            }
            return true;
        }
        function mathRoundForTaxes(source) {
            var txtBox = document.getElementById(source);
            var txt = txtBox.value;
            if (!isNaN(txt) && isFinite(txt) && txt.length != 0) {
                var rounded = Math.round(txt * 100) / 100;
                txtBox.value = rounded.toFixed(2);
            }
        } 
    </script>

</head>
<body style="background-color :White ;">

    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Services>
                <asp:ServiceReference Path="../Autocomplete.asmx" />
            </Services>
        </asp:ScriptManager>

        <table>
        <tr>
        <td >
        <asp:Label ID="Errormgs"  style=" margin-left: 93px;" CssClass="ErrorMsg"  runat="server" Visible="true" ForeColor="Red"  ></asp:Label>
        </td>
        </tr>

        </table>
        <br />
         <br />
        <table>
        <tr>
        
       
        <td>
                        Season Name
                    </td>
                    <td>
                        <asp:DropDownList ID="cmbSeasonName" Width="150" CssClass="combo" AutoPostBack="true"
                            runat="server">
                        </asp:DropDownList>
                       
                    </td>
  </tr>
   <tr>
        
       
        <td>
                        Sr No
                    </td>
                    <td>
                        <asp:DropDownList ID="CMBSRNo" Width="150" CssClass="combo" AutoPostBack="false"
                            runat="server">
                        </asp:DropDownList>
                       

                    </td>
  </tr>
        </table>
        <br />
        <table>
        <tr>
        <td>
        <asp:Button ID="btnSave" CssClass="button" runat="server" Text="Move" style="    margin-left: 104px;" />
        </td>
        <td>
         <asp:Button ID="btnCancell" CssClass="button" OnClientClick="window.close();" style="    margin-left: 104px;" Visible ="false"  runat="server" Text="Close" />
        
        </td>
        </tr>
        </table>






    </form>
</body>
</html>
