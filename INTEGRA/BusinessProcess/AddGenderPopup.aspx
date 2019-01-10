<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddGenderPopup.aspx.vb" Inherits="Integra.WebForm1" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Add Gender Popup Page</title>
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
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Services>
                <asp:ServiceReference Path="../Autocomplete.asmx" />
            </Services>
        </asp:ScriptManager>
        <table width="100%">
            <tr>
                <asp:Panel ID="PnlAddGender1" runat="server" Visible="true">
                    <td>
                        Gender
                    </td>
                    <td>
                        <asp:DropDownList ID="cmbGender" Width="150" CssClass="combo" AutoPostBack="true"
                            runat="server">
                        </asp:DropDownList>
                        <asp:ImageButton ID="BtnAddGender" runat="server" ImageUrl="~/Images/AddButton.jpg"
                            Style="margin-left: 7px; width: 19px;" />
                    </td>
                </asp:Panel>
                <asp:Panel ID="PnlAddGender2" runat="server" Visible="false">
                    <td>
                        Gender
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddGender" runat="server" Width="150px" CssClass="textbox"></asp:TextBox>
                        <asp:ImageButton ID="BtnSaveGender" runat="server" ImageUrl="~/Images/SaveButton.jpg"
                            Style="margin-left: 7px; width: 19px;" />
                    </td>
                </asp:Panel>
            </tr>
           
            <tr>
                <td>
                    Size Range
                </td>
                <td>
                    <asp:TextBox ID="txtSizeRange" CssClass="textbox" Width="280" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <asp:Panel ID="PnlSizes1" runat="server" Visible="true">
                    <td>
                        Sizes
                    </td>
                    <td>
                        <asp:DropDownList ID="cmbSizes" Width="150" CssClass="combo" AutoPostBack="FALSE"
                            runat="server">
                        </asp:DropDownList>
                        <asp:ImageButton ID="BtnAddSizes" runat="server" ImageUrl="~/Images/AddButton.jpg"
                            Style="margin-left: 7px; width: 19px;" />
                    </td>
                </asp:Panel>
                <asp:Panel ID="PnlSizes2" runat="server" Visible="false">
                    <td>
                        Sizes
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddSizes" runat="server" Width="150px" CssClass="textbox"></asp:TextBox>
                        <asp:ImageButton ID="BtnSaveSizes" runat="server" ImageUrl="~/Images/SaveButton.jpg"
                            Style="margin-left: 7px; width: 19px;" />
                    </td>
                </asp:Panel>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnAddDeatil" CssClass="button" runat="server" Text="Add Detail" />
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td>
                    <Smart:SmartDataGrid ID="dgView" Font-Size="15pt" runat="server" Width="100%" AllowSorting="True"
                        AutoGenerateColumns="False" CellPadding="2" CssClass="table" PageSize="100" ShowFooter="False"
                        ForeColor="white" GridLines="both">
                        <Columns>
                            <asp:BOUNDCOLUMN visible="false" ItemStyle-HorizontalAlign="center" HeaderText="SizeRangeDetailID"
                                DataField="SizeRangeDetailID">
                                <headerstyle horizontalalign="center" width="2%" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN visible="false" ItemStyle-HorizontalAlign="center" HeaderText="SizeDatabaseID"
                                DataField="SizeDatabaseID">
                                <headerstyle horizontalalign="center" width="2%" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="SIZE" DataField="Sizes">
                                <headerstyle horizontalalign="center" width="7%" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="RATIO" DataField="Ratio">
                                <headerstyle horizontalalign="center" width="7%" />
                            </asp:BOUNDCOLUMN>
                        </Columns>
                        <PagerStyle Visible="False" CssClass="GridPagerStyle" Mode="NumericPages" HorizontalAlign="Right" />
                        <AlternatingItemStyle CssClass="GridAlternativeRow" />
                        <ItemStyle CssClass="GridRow" />
                        <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                    </Smart:SmartDataGrid>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnSave" CssClass="button" runat="server" Text="Save" />&nbsp; &nbsp;
                    <asp:Button ID="BtnCancel" runat="server" CssClass="button" Text="Close" OnClientClick="window.close();"
                        TabIndex="13" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
