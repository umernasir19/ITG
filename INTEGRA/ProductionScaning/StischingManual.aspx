<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="StischingManual.aspx.vb"
    Inherits="Integra.StischingManual" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Stitching Scaning</title>
    <link type="text/css" rel="stylesheet" href="App_Themes/Blue/NewCSS/NewStyle.css" />
    <link type="text/css" rel="stylesheet" href="css/style.css" />
    <link type="text/css" rel="stylesheet" href="App_Themes/Blue/StyleSheet.css" />
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/sound.js">
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="margin: 0 auto; text-align: center; width: 714px;">
        <table style="width: 714px; border: 0px solid #000; font-family: Calibri; font-size: 30px;
            font-stretch: normal; font-style: normal; font-weight: bold;">
            <tr>
                <td>
                    <img src="../Images/sendtowash.jpg" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <br />
    <div style="margin: 0 auto; text-align: center; width: 714px; margin-top: -38px;">
        <table style="width: 714px; border: 2px solid #000; font-family: Calibri; font-size: 30px;
            font-stretch: normal; font-style: normal; font-weight: bold; color: #1307ED;">
            <tr>
                <td>
                    <asp:Label ID="lblJobNo" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="LalblStyle" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblStyleQty" runat="server" Style="color: red;"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblScanedPcs" runat="server" Style="color: green;"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div style="margin-left: 1005px;">
        <asp:Label ID="Label1" runat="server" Text="Counter:" Style="color: blue; font-weight: bold;"></asp:Label></div>
    <div style="margin-left: 1074px; margin-top: -24px;">
        <asp:Label ID="lblCounter" runat="server" Text="0" Style="font-size: x-large; font-family: Calibri;
            font-weight: bold; color: Red;"></asp:Label></div>
    <br />
    <br />
    <br />
    <br />
    <br />
    <div style="margin: 0 auto; text-align: center; width: 714px; margin-top: 36px;">
        <table width="100%">
            <tr>
                <td align="center">
                    <asp:Label ID="lblmsg" runat="server" Style="font-weight: bold; color: Red; font-size: 17px;"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="margin-left: -638px; margin-bottom: -31px;">
                        <asp:Label ID="Label2" runat="server" Text="Line No:" Style="font-weight: bold; color: Red;
                            font-size: 17px;"></asp:Label></div>
                    <div style="margin-left: -373px;">
                        <asp:DropDownList ID="cmbLineNo" runat="server" Font-Bold="true" Font-Size="Large"
                            Font-Names="century gothic" AutoPostBack="true" Height="25PX" Width="180px" Style="margin-left: 10px;
                            margin-top: 6px;">
                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                            <asp:ListItem Value="1" Text="A"></asp:ListItem>
                            <asp:ListItem Value="2" Text="B"></asp:ListItem>
                            <asp:ListItem Value="3" Text="C"></asp:ListItem>
                            <asp:ListItem Value="4" Text="D"></asp:ListItem>
                            <asp:ListItem Value="5" Text="E"></asp:ListItem>
                            <asp:ListItem Value="6" Text="F"></asp:ListItem>
                            <asp:ListItem Value="7" Text="G"></asp:ListItem>
                            <asp:ListItem Value="8" Text="H"></asp:ListItem>
                            <asp:ListItem Value="9" Text="I"></asp:ListItem>
                            <asp:ListItem Value="10" Text="J"></asp:ListItem>
                            <asp:ListItem Value="11" Text="K"></asp:ListItem>
                            <asp:ListItem Value="12" Text="L"></asp:ListItem>
                            <asp:ListItem Value="13" Text="M"></asp:ListItem>
                            <asp:ListItem Value="14" Text="N"></asp:ListItem>
                            <asp:ListItem Value="15" Text="O"></asp:ListItem>
                            <asp:ListItem Value="16" Text="P"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </td>
            </tr>
            <tr style="height: 40px;">
                <td style="height: 40px">
                    <table>
                        <tr>
                            <td align="left">
                                <asp:TextBox ID="txtBarcodee" Style="" runat="server"
                                    Width="256px" AutoPostBack="true" ReadOnly ="true" ></asp:TextBox>
                                     
                            </td>
                            <td>
                                <asp:TextBox ID="txtCreationDate" runat="server" CssClass="textbox"> </asp:TextBox>
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
                            <td align="right">
                                <asp:Button ID="BtnSAVEData" runat="server" Text="Save All Pcs" Style="margin-left: 10px;
                                    width: 198px;" Visible="false"></asp:Button>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <div style="width: 814px;">
                        <div id="controlHead" style="width: 706px;">
                        </div>
                        <div style="height: 180px; overflow: auto">
                            <asp:GridView ID="dgView" runat="server" Width="100%" AutoGenerateColumns="False"
                                BorderStyle="Solid">
                                <Columns>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStyleAssortmentBarCodeDetailID" runat="server" Text='<%# Bind("StyleAssortmentBarCodeDetailID") %>'></asp:Label>
                                            <asp:Label ID="lblJoborderid" runat="server" Text='<%# Bind("Joborderid") %>'></asp:Label>
                                            <asp:Label ID="lblJoborderDetailid" runat="server" Text='<%# Bind("JoborderDetailid") %>'></asp:Label>
                                            <asp:Label ID="lblStyleAssortmentMasterID" runat="server" Text='<%# Bind("StyleAssortmentMasterID") %>'></asp:Label>
                                            <asp:Label ID="lblSizeRangeID" runat="server" Text='<%# Bind("SizeRangeID") %>'></asp:Label>
                                            <asp:Label ID="lblSizeDatabaseID" runat="server" Text='<%# Bind("SizeDatabaseID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="BarCode" DataField="Code">
                                        <HeaderStyle HorizontalAlign="Center" Width="8%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Merchandiser" DataField="Merchandiser">
                                        <HeaderStyle Width="5%" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Sr No" DataField="JobNo">
                                        <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Total Style QTY" DataField="TotalOrderQty">
                                        <HeaderStyle HorizontalAlign="Center" Width="6%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Style" DataField="Style">
                                        <HeaderStyle HorizontalAlign="Center" Width="30%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Item" DataField="Item">
                                        <HeaderStyle HorizontalAlign="Center" Width="35%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Brand" DataField="Brand">
                                        <HeaderStyle HorizontalAlign="Center" Width="40%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Total Size QTY" DataField="TotalSizeQty">
                                        <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Size" DataField="Size">
                                        <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Line No" DataField="LineNumber">
                                        <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                </Columns>
                                <HeaderStyle BackColor="#66CCFF" />
                            </asp:GridView>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <table>
        <tr>
            <td align="LEFT">
            </td>
        </tr>
    </table>
    </form>
</body>
