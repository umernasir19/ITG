<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Dashboard.aspx.vb" Inherits="Integra.Dashboard" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<script type="text/javascript">
<!--
    function MM_swapImgRestore() { //v3.0
        var i, x, a = document.MM_sr; for (i = 0; a && i < a.length && (x = a[i]) && x.oSrc; i++) x.src = x.oSrc;
    }
    function MM_preloadImages() { //v3.0
        var d = document; if (d.images) {
            if (!d.MM_p) d.MM_p = new Array();
            var i, j = d.MM_p.length, a = MM_preloadImages.arguments; for (i = 0; i < a.length; i++)
                if (a[i].indexOf("#") != 0) { d.MM_p[j] = new Image; d.MM_p[j++].src = a[i]; }
        }
    }

    function MM_findObj(n, d) { //v4.01
        var p, i, x; if (!d) d = document; if ((p = n.indexOf("?")) > 0 && parent.frames.length) {
            d = parent.frames[n.substring(p + 1)].document; n = n.substring(0, p);
        }
        if (!(x = d[n]) && d.all) x = d.all[n]; for (i = 0; !x && i < d.forms.length; i++) x = d.forms[i][n];
        for (i = 0; !x && d.layers && i < d.layers.length; i++) x = MM_findObj(n, d.layers[i].document);
        if (!x && d.getElementById) x = d.getElementById(n); return x;
    }

    function MM_swapImage() { //v3.0
        var i, j = 0, x, a = MM_swapImage.arguments; document.MM_sr = new Array; for (i = 0; i < (a.length - 2); i += 3)
            if ((x = MM_findObj(a[i])) != null) { document.MM_sr[j++] = x; if (!x.oSrc) x.oSrc = x.src; x.src = a[i + 2]; }
    }
//-->
</script>
<head id="Head1" runat="server">
    <link href="css/V3screen.css" rel="stylesheet" type="text/css" media="screen" />
    <title>DIGITAL APPAREL B2B-INTEGRA ERP- Login Page</title>
    <script type='text/javascript'>        if (typeof (lpUnit) == 'undefined') var lpUnit = 'SL-Portal'; var lpMTagConfig = { 'lpServer': 'sales.liveperson.net', 'lpNumber': '12703439', 'lpProtocol': (document.location.toString().indexOf('index.html') == 0) ? 'https' : 'http', 'lpTagLoaded': false, 'lpTagSrv': 'sr2.liveperson.net', 'pageStartTime': (new Date()).getTime() };</script>
    <script type="text/javascript">

        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-22553883-8']);
        _gaq.push(['_setDomainName', '.softlayer.com']);
        _gaq.push(['_setAllowHash', false]);
        _gaq.push(['_setAllowLinker', true]);
        _gaq.push(['_setAllowAnchor', true]);
        _gaq.push(['_trackPageview']);
        _gaq.push(['b._setAccount', 'UA-13288544-1']);
        _gaq.push(['b._setDomainName', '.softlayer.com']);
        _gaq.push(['b._setAllowHash', false]);
        _gaq.push(['b._setAllowLinker', true]);
        _gaq.push(['b._setAllowAnchor', true]);
        _gaq.push(['b._trackPageview']);

        (function () {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();
    
    </script>
</head>
<body id="newLoginPage" onload="MM_preloadImages('images/button-tabs/btn_h.png')">
    <form id="dd" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <img src="images/layout/ECPlogoNew.png" alt="SoftLayer(R)" id="login-logo" />
    <div id="content-container">
        <div id="content-box">
            <div id="login-box-header">
                <p id="content-box-title">
                    Login Department</p>
            </div>
            <div id="login-box">
                <div class="message">
                    <asp:Label ID="lblErrorMsg" runat="server" Text=""></asp:Label></div>
                <form method="post" id="loginform" name="loginform">
                <div class="login-box-row">
                    <label for="user_username" class="login-box-label">
                        Department</label>
                   <asp:DropDownList ID="cmbDepartment" Width="150" CssClass="combo" AutoPostBack="FALSE"
                            runat="server">
                             <asp:ListItem Value="1" Text="Select"></asp:ListItem>
                              <asp:ListItem Value="2" Text="Merchandising"></asp:ListItem>
                        <asp:ListItem Value="3" Text="Fabric Store"></asp:ListItem>
                         <asp:ListItem Value="4" Text="R.N.D"></asp:ListItem>
                         <asp:ListItem Value="5" Text="G.G.T"></asp:ListItem>
                          <asp:ListItem Value="6" Text="Production"></asp:ListItem>
                        <%--  <asp:ListItem Value="7" Text="Export"></asp:ListItem>--%>
                        </asp:DropDownList>
                </div>
              
                <div id="login-buttton-containter">
                    <telerik:RadButton ID="btnLogin" runat="server" Text="Go To Department" Skin="WebBlue">
                    </telerik:RadButton>
                </div>
                <div id="login-buttton-containter_2">
                   
                </div>
                </form>
            </div>
        </div>
    </div>
    <div class="errorMessages">
        <div class="footer_txt">
            <div class="txxxt">
                <span>Powered by :</span></div>
            <div class="txxxt_2">
                <a href="http://itg.net.pk/" target="_blank">
                    <img src="images/layout/footer_img.png" alt="" /></a></div>
        </div>
    </div>
    <div class="print-info">
    </div>
    <script type="text/javascript">

        if (typeof SoftLayer == "undefined") {
            var SoftLayer =
                {
                    Controllers: {}
                };
        }

        if (typeof SoftLayer.Controllers['User'] == "undefined") {
            SoftLayer.Controllers['User'] = {};
        }

        if (typeof SoftLayer.Controllers['User']['login'] == "undefined") {
            SoftLayer.Controllers['User']['login'] = {};
        }
        $(function () {
            $("#loginform").submit(function () {
                return handleLogin();
            });
        });

        function handleLogin() {
            if ($('#user_username').val() != "" && $('#user_password').val() != "") {
                return true;
            }
            else {
                alert('Please enter a valid username and password.');
            }
            return false;
        }

        function Popup(url, window_name, window_width, window_height) {
            settings = "toolbar=no,location=no,directories=no," +
            "status=no,menubar=no,scrollbars=no," +
            "resizable=yes,width=" + window_width + ",height=" + window_height;
            NewWindow = window.open(url, window_name, settings);
        }
        function Image2_onclick() {

        }

    </script>
    <table width="100%">
        <tr>
            <td>
                <Smart:SmartDataGrid ID="dgknitsemail" Font-Size="15pt" runat="server" Width="100%"
                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="2" CssClass="table"
                    PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="10000" RecordCount="0"
                    ShowFooter="False" ForeColor="white">
                    <Columns>
                        <asp:BoundColumn Visible="false" ItemStyle-HorizontalAlign="center" HeaderText="POID"
                            DataField="POID">
                            <HeaderStyle HorizontalAlign="center" Width="2%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn Visible="True" ItemStyle-HorizontalAlign="center" HeaderText="SR NO."
                            DataField="pono">
                            <HeaderStyle HorizontalAlign="center" Width="2%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn Visible="True" ItemStyle-HorizontalAlign="center" HeaderText="STYLE"
                            DataField="Style">
                            <HeaderStyle HorizontalAlign="center" Width="2%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="SUPPLIER" DataField="vendername">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="CUSTOMER" DataField="customername">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="MERCHANDISER" DataField="Marchand">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="DUE PROCESS TOMORROW"
                            DataField="Process">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="PROCESS DATE" DataField="Targetdate">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Processid" DataField="TNAProcessID"
                            Visible="false">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Status" DataField="Status"
                            Visible="false">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                    </Columns>
                    <PagerStyle Visible="False" CssClass="GridPagerStyle" Mode="NumericPages" HorizontalAlign="Right" />
                    <AlternatingItemStyle CssClass="GridAlternativeRow" />
                    <ItemStyle CssClass="GridRow" />
                    <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                </Smart:SmartDataGrid>
            </td>
        </tr>
        <tr>
            <td>
                <Smart:SmartDataGrid ID="dgemailAdmin" Font-Size="15pt" runat="server" Width="100%"
                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="2" CssClass="table"
                    PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="10000" RecordCount="0"
                    ShowFooter="False" ForeColor="white">
                    <Columns>
                        <asp:BoundColumn Visible="false" ItemStyle-HorizontalAlign="center" HeaderText="POID"
                            DataField="POID">
                            <HeaderStyle HorizontalAlign="center" Width="2%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn Visible="True" ItemStyle-HorizontalAlign="center" HeaderText="SR NO."
                            DataField="pono">
                            <HeaderStyle HorizontalAlign="center" Width="2%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn Visible="True" ItemStyle-HorizontalAlign="center" HeaderText="STYLE"
                            DataField="Style">
                            <HeaderStyle HorizontalAlign="center" Width="2%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="SUPPLIER" DataField="vendername">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="CUSTOMER" DataField="customername">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="MERCHANDISER" DataField="Marchand">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="DUE PROCESS" DataField="Process">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="PROCESS DATE" DataField="Targetdate">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="NO. OF REMINDER"
                            DataField="NewNoofReminder" Visible="TRUE">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Processid" DataField="TNAProcessID"
                            Visible="false">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Status" DataField="Status"
                            Visible="false">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                    </Columns>
                    <PagerStyle Visible="False" CssClass="GridPagerStyle" Mode="NumericPages" HorizontalAlign="Right" />
                    <AlternatingItemStyle CssClass="GridAlternativeRow" />
                    <ItemStyle CssClass="GridRow" />
                    <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                </Smart:SmartDataGrid>
            </td>
        </tr>
        <tr>
            <td>
                <Smart:SmartDataGrid ID="dgemail3rem" Font-Size="15pt" runat="server" Width="100%"
                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="2" CssClass="table"
                    PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="10000" RecordCount="0"
                    ShowFooter="False" ForeColor="white">
                    <Columns>
                        <asp:BoundColumn Visible="false" ItemStyle-HorizontalAlign="center" HeaderText="POID"
                            DataField="POID">
                            <HeaderStyle HorizontalAlign="center" Width="2%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn Visible="True" ItemStyle-HorizontalAlign="center" HeaderText="SR NO."
                            DataField="pono">
                            <HeaderStyle HorizontalAlign="center" Width="2%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn Visible="True" ItemStyle-HorizontalAlign="center" HeaderText="STYLE"
                            DataField="Style">
                            <HeaderStyle HorizontalAlign="center" Width="2%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="SUPPLIER" DataField="vendername">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="CUSTOMER" DataField="customername">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="MERCHANDISER" DataField="Marchand">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="DUE PROCESS" DataField="Process">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="PROCESS DATE" DataField="Targetdate">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="NO. OF REMINDER"
                            DataField="NewNoofReminder" Visible="TRUE">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Processid" DataField="TNAProcessID"
                            Visible="false">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Status" DataField="Status"
                            Visible="false">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                    </Columns>
                    <PagerStyle Visible="False" CssClass="GridPagerStyle" Mode="NumericPages" HorizontalAlign="Right" />
                    <AlternatingItemStyle CssClass="GridAlternativeRow" />
                    <ItemStyle CssClass="GridRow" />
                    <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                </Smart:SmartDataGrid>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
