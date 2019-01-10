<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeBehind="MainPage.aspx.vb" Inherits="Integra.MainPage" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/styleee.css" rel="stylesheet" type="text/css" />
    <link href="http://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css" rel="stylesheet"
        type="text/css" />
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
    <script src="Scripts/AC_RunActiveContent.js" type="text/javascript"></script>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="center" valign="middle" id="Td2" style="background-color: Transparent;
                color: Red; font-family: Verdana; font-weight: bold; height: 18px; width: 926px;"
                runat="server">
                <div class="left_side_container" style="margin-top: -21px; height: 774px;">
                    <div style="height: 2px;">
                    </div>
                    <div class="side_contener">
                        <asp:FileUpload ID="FileUpload" runat="server" Visible="false" Style="margin-left: 0px;
                            margin-top: -6px; margin-right: 0px;" />
                        <div class="photo">
                            <asp:Image ID="Image1" runat="server" />
                        </div>
                        <div class="name">
                            <div class="name_txt">
                                Name:</div>
                            <div class="name_txt" style="margin-left: -21px; margin-top: 1px;">
                                <asp:Label ID="lblName" runat="server" Style="text-transform: uppercase; font-size: 11px;"
                                    Width="160px"></asp:Label>
                            </div>
                        </div>
                        <div class="name">
                            <div class="name_txt">
                                Designation:</div>
                            <div class="name_txt" style="margin-left: -21px; margin-top: 1px;">
                                <asp:Label ID="lblDesig" runat="server" Width="160px" Style="text-transform: uppercase;
                                    font-size: 11px;"></asp:Label>
                            </div>
                        </div>
                        <div class="name">
                            <div class="name_data">
                                <asp:Label ID="lblDivision" runat="server" Font-Size="Small" Width="98px" Visible="False"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="center_container">
                    <asp:Panel ID="pnlChart" runat="server" Visible="false">
                        <div style="margin-left: 13px; margin-top: -20px;">
                            <table>
                                <tr>
                                    <td>
                                        <div style="width: 310px; font-family: Calibri; /* background-color: Silver; */
    border: 1px solid #9f9f9f; font-weight: bold; color: #3e3e3e; text-align: left; padding-top: 8px; padding: 8px 0 10px 10px;
                                            margin-bottom: 5px; border-radius: 5px 5px 0 0px; background: linear-gradient(#e2e2e2, #fff);
                                            font-size: 13px;">
                                            Booked Orders (2018)
                                            <%--<a href="#" class="topbar-item-new ion-android-settings"></a>--%>
                                            <asp:ImageButton ID="BtnPartialCustomerChart" Style="margin-left: 291px; margin-top: -15px;
                                                width: 16px;" ToolTip="Click here to View Chart" ImageUrl="~/Images/iconnnn.png"
                                                runat="server"></asp:ImageButton>
                                        </div>
                                        <div id="" style="margin-top: -6px; font-size: 10px">
                                            <telerik:RadHtmlChart ID="Chart1" Height="203px" Width="320px" runat="server" Transitions="true"
                                                Skin="Office2007" class="fs" Style="font-family: Calibri; position: relative;
                                                border: 1px solid rgb(177, 177, 177); border-radius: 0 0 5px 5px; background: linear-gradient(#e8e8e8, #fff);">
                                                <Legend>
        <Appearance Position="right">
            <TextStyle FontSize="8" Color="black" FontFamily="Courier New, sans-serif" />
        </Appearance>
    </Legend>
                                                <PlotArea>
                                                    <Series>
                                                        <telerik:PieSeries StartAngle="0" DataFieldY="Value"  NameField="Name" ExplodeField="true">
                                                            <TooltipsAppearance BackgroundColor="AliceBlue" DataFormatString="#,###,##0%" />
                                                            <LabelsAppearance DataFormatString="#,###,##0%" Visible="true" Position="Circle" />
                                                        </telerik:PieSeries>
                                                    </Series>
                                                </PlotArea>
                                                <ChartTitle Text="">
                                                    <Appearance Align="left" Position="Top">
                                                        <TextStyle Bold="true" FontSize="14px"></TextStyle>
                                                    </Appearance>
                                                </ChartTitle>
                                            </telerik:RadHtmlChart>
                                        </div>
                                    </td>
                                    <td>
                                        <div style="margin-left: 33px;">
                                            <div style="width: 310px; font-family: Calibri; /* background-color: Silver; */
    border: 1px solid #9f9f9f; font-weight: bold; color: #3e3e3e; text-align: left; padding-top: 8px; padding: 8px 0 10px 10px;
                                                margin-bottom: 0px; border-radius: 5px 5px 0 0px; background: linear-gradient(#e2e2e2, #fff);
                                                font-size: 13px;">
                                                Total No. of Samples (2018) <%--<a href="#" class="topbar-item-new ion-android-settings">
                                                </a>--%>


                                                  <asp:ImageButton ID="btnTotalSample" Style="margin-left: 291px; margin-top: -15px;
                                                width: 16px;" ToolTip="Click here to View Chart" ImageUrl="~/Images/iconnnn.png"
                                                runat="server"></asp:ImageButton>
                                            </div>
                                            <div style="margin-left: 0px;">
                                                <telerik:RadHtmlChart runat="server" ID="Chart2" Height="203px" Width="320px" Skin="Default"
                                                    Style="font-family: Calibri; position: relative; border: 1px solid rgb(177, 177, 177);
                                                    border-radius: 0px 0px 5px 5px; background: linear-gradient(rgb(232, 232, 232), rgb(255, 255, 255));">
                                                    <PlotArea>
                                                        <Series>
                                                            <telerik:BarSeries Name="Name" DataFieldY="Value">
                                                                <TooltipsAppearance DataFormatString="#,###,##0" />
                                                                <LabelsAppearance DataFormatString="#,###,##0" Visible="true" />
                                                            </telerik:BarSeries>
                                                        </Series>
                                                        <XAxis DataLabelsField="Name">
                                                        </XAxis>
                                                        <YAxis>
                                                            <LabelsAppearance Visible="false" RotationAngle="35" DataFormatString="#,###,##0" />
                                                        </YAxis>
                                                    </PlotArea>
                                                    <Legend>
                                                        <Appearance Visible="false" />
                                                    </Legend>
                                                    <ChartTitle Text="">
                                                        <Appearance>
                                                            <TextStyle Bold="true" FontSize="16px"></TextStyle>
                                                        </Appearance>
                                                    </ChartTitle>
                                                </telerik:RadHtmlChart>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div style="margin-left: 13px;">
                            <table>
                                <tr>
                                    <td>
                                        <div style="width: 310px; font-family: Calibri; /* background-color: Silver; */
    border: 1px solid #9f9f9f; font-weight: bold; color: #3e3e3e; text-align: left; padding-top: 8px; padding: 8px 0 10px 10px;
                                            margin-bottom: 0px; border-radius: 5px 5px 0 0px; background: linear-gradient(#e2e2e2, #fff);
                                            font-size: 13px;">
                                            Total Booked - PCS (2018) <%--<a href="#" class="topbar-item-new ion-android-settings"></a>--%>
                                       
                                        <asp:ImageButton ID="btnTotalBooked" Style="margin-left: 291px; margin-top: -15px;
                                                width: 16px;" ToolTip="Click here to View Chart" ImageUrl="~/Images/iconnnn.png"
                                                runat="server"></asp:ImageButton>
                                        </div>
                                        <div style="margin-left: 0px;">
                                            <telerik:RadHtmlChart ID="Chart3" Height="203px" Width="320px" runat="server" Transitions="true"
                                                Skin="Office2010Blue" Style="font-family: Calibri; position: relative; border: 1px solid rgb(177, 177, 177);
                                                border-radius: 0px 0px 5px 5px; background: linear-gradient(rgb(232, 232, 232), rgb(255, 255, 255));">
                                                <PlotArea>
                                                    <Series>
                                                        <telerik:BarSeries Name="Name" DataFieldY="Value">
                                                            <TooltipsAppearance DataFormatString="#,###,##0" />
                                                            <LabelsAppearance DataFormatString="#,###,##0" Visible="true" />
                                                        </telerik:BarSeries>
                                                    </Series>
                                                    <XAxis DataLabelsField="Name">
                                                    </XAxis>
                                                    <YAxis>
                                                        <LabelsAppearance Visible="false" RotationAngle="35" DataFormatString="#,###,##0" />
                                                    </YAxis>
                                                </PlotArea>
                                                <Legend>
                                                    <Appearance Visible="false" />
                                                </Legend>
                                                <ChartTitle Text="">
                                                    <Appearance>
                                                        <TextStyle Bold="true" FontSize="16px"></TextStyle>
                                                    </Appearance>
                                                </ChartTitle>
                                            </telerik:RadHtmlChart>
                                        </div>
                                    </td>
                                    &nbsp;
                                    <td>
                                        <div style="margin-left: 33px; margin-top: 1px;">
                                            <div style="width: 310px; font-family: Calibri; /* background-color: Silver; */
    border: 1px solid #9f9f9f; font-weight: bold; color: #3e3e3e; text-align: left; padding-top: 8px; padding: 8px 0 10px 10px;
                                                margin-bottom: 0px; border-radius: 5px 5px 0 0px; background: linear-gradient(#e2e2e2, #fff);
                                                font-size: 13px;">
                                                Total Turnover (2018)<%--<a href="#" class="topbar-item-new ion-android-settings"></a>--%>

                                                  <asp:ImageButton ID="BtnViewTotalTurnover" Style="margin-left: 291px; margin-top: -15px;
                                                width: 16px;" ToolTip="Click here to View Chart" ImageUrl="~/Images/iconnnn.png"
                                                runat="server"></asp:ImageButton>

                                            </div>
                                            <div style="margin-left: 0px;">
                                                <telerik:RadHtmlChart runat="server" ID="Chart4" Width="320px" Height="203px" Transitions="true"
                                                    Skin="Bootstrap" Style="font-family: Calibri; position: relative; border: 1px solid rgb(177, 177, 177);
                                                    border-radius: 0px 0px 5px 5px; background: linear-gradient(rgb(232, 232, 232), rgb(255, 255, 255));">
                                                    <PlotArea>
                                                        <Series>
                                                            <telerik:BarSeries Name="Name" DataFieldY="Value">
                                                                <TooltipsAppearance DataFormatString="$#,###,##0" />
                                                                <LabelsAppearance DataFormatString="$#,###,##0" Visible="true" />
                                                            </telerik:BarSeries>
                                                        </Series>
                                                        <XAxis DataLabelsField="Name">
                                                        </XAxis>
                                                        <YAxis>
                                                            <LabelsAppearance Visible="false" RotationAngle="35" DataFormatString="#,###,##0" />
                                                        </YAxis>
                                                    </PlotArea>
                                                    <Legend>
                                                        <Appearance Visible="false" />
                                                    </Legend>
                                                    <ChartTitle Text="">
                                                        <Appearance>
                                                            <TextStyle Bold="true" FontSize="16px"></TextStyle>
                                                        </Appearance>
                                                    </ChartTitle>
                                                </telerik:RadHtmlChart>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="Panel1" runat="server" Visible="FALSE">
                        <div style="margin: 0 0 0 14px;">
                            <table>
                                <tr>
                                    <td>
                                        <div style="width: 310px; font-family: Calibri; border: 1px solid #9f9f9f; font-weight: bold;
                                            color: #3e3e3e; text-align: left; padding-top: 8px; padding: 8px 0 10px 10px;
                                            margin-bottom: 0px; border-radius: 5px 5px 0 0px; background: linear-gradient(#e2e2e2, #fff);
                                            font-size: 13px;">
                                            Order Status Winter-18 <a href="#" class="topbar-item-new ion-android-settings">
                                            </a>
                                        </div>
                                        <div>
                                            <telerik:RadHtmlChart ID="Chart5" Height="203px" Width="320px" runat="server" Transitions="true"
                                                Skin="WebBlue" Style="font-size: smaller; font-family: Calibri; position: relative;
                                                border: 1px solid rgb(177, 177, 177); border-radius: 0px 0px 5px 5px; background: linear-gradient(rgb(232, 232, 232), 
                                            rgb(255, 255, 255));">
                                                <PlotArea>
                                                    <Series>
                                                        <telerik:ColumnSeries DataFieldY="Value" ColorField="red">
                                                            <TooltipsAppearance DataFormatString="#,###,##0" />
                                                            <LabelsAppearance DataFormatString="#,###,##0" Visible="true" />
                                                        </telerik:ColumnSeries>
                                                    </Series>
                                                    <XAxis DataLabelsField="Name">
                                                        <TitleAppearance Text="">
                                                            <TextStyle Margin="10" />
                                                        </TitleAppearance>
                                                        <MajorGridLines Visible="false" />
                                                        <MinorGridLines Visible="false" />
                                                    </XAxis>
                                                    <YAxis>
                                                        <TitleAppearance Text="">
                                                            <TextStyle Margin="10" />
                                                        </TitleAppearance>
                                                        <MinorGridLines Visible="false" />
                                                    </YAxis>
                                                </PlotArea>
                                                <Legend>
                                                    <Appearance Position="Bottom" />
                                                </Legend>
                                                <ChartTitle Text="">
                                                    <Appearance Align="Center" Position="Top">
                                                        <TextStyle Bold="true" FontSize="16px"></TextStyle>
                                                    </Appearance>
                                                </ChartTitle>
                                            </telerik:RadHtmlChart>
                                        </div>
                                    </td>
                                    &nbsp;
                                    <td>
                                        <div style="margin-left: 0px;">
                                        </div>
                                    </td>
                                    <td>
                                        <div style="margin-left: 33px;">
                                            <div style="width: 310px; font-family: Calibri; /* background-color: Silver; */
    border: 1px solid #9f9f9f; font-weight: bold; color: #3e3e3e; text-align: left; padding-top: 8px; padding: 8px 0 10px 10px;
                                                margin-bottom: 0px; border-radius: 5px 5px 0 0px; background: linear-gradient(#e2e2e2, #fff);
                                                font-size: 13px;">
                                                Apparel Business Turnover in 2018 (in USD) <a href="#" class="topbar-item-new ion-android-settings">
                                                </a>
                                            </div>
                                            <div>
                                                <telerik:RadHtmlChart ID="Chart6" Height="203px" Width="320px" runat="server" Transitions="true"
                                                    Skin="Silk" Style="font-family: Calibri; position: relative; border: 1px solid rgb(177, 177, 177);
                                                    border-radius: 0px 0px 5px 5px; background: linear-gradient(rgb(232, 232, 232), rgb(255, 255, 255));">
                                                    <PlotArea>
                                                        <Series>
                                                            <telerik:ColumnSeries DataFieldY="Value1" ColorField="red">
                                                                <TooltipsAppearance DataFormatString="#,###,##0" />
                                                                <LabelsAppearance DataFormatString="#,###,##0" Visible="true" />
                                                            </telerik:ColumnSeries>
                                                            <telerik:ColumnSeries DataFieldY="Value2" ColorField="blue">
                                                                <TooltipsAppearance DataFormatString="#,###,##0" />
                                                                <LabelsAppearance DataFormatString="#,###,##0" Visible="true" />
                                                            </telerik:ColumnSeries>
                                                        </Series>
                                                        <XAxis DataLabelsField="Name">
                                                            <TitleAppearance Text="">
                                                                <TextStyle Margin="10" />
                                                            </TitleAppearance>
                                                            <MajorGridLines Visible="false" />
                                                            <MinorGridLines Visible="false" />
                                                        </XAxis>
                                                        <YAxis>
                                                            <TitleAppearance Text="">
                                                                <TextStyle Margin="10" />
                                                            </TitleAppearance>
                                                            <MinorGridLines Visible="false" />
                                                        </YAxis>
                                                    </PlotArea>
                                                    <Legend>
                                                        <Appearance Position="Bottom" />
                                                    </Legend>
                                                    <ChartTitle Text="">
                                                        <Appearance Align="Center" Position="Top">
                                                            <TextStyle Bold="true" FontSize="16px"></TextStyle>
                                                        </Appearance>
                                                    </ChartTitle>
                                                </telerik:RadHtmlChart>
                                            </div>
                                        </div>
                                    </td>
                                    &nbsp;
                                    <td>
                                        <div style="margin-left: 12px;">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
                </div>
            </td>
        </tr>
        <tr valign="top">
            <td style="width: 930px">
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <div>
                    <asp:UpdatePanel ID="UpdatePanel7" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <telerik:RadWindowManager ID="RadWindowManager8" ShowContentDuringLoad="true" VisibleStatusbar="false"
                                RegisterWithScriptManager="True" EnableShadow="True" ReloadOnShow="true" Height="700px"
                                Width="943px" runat="server">
                                <Windows>
                                    <telerik:RadWindow ID="rw1" Title="" runat="server" Modal="True" Behaviors="Move">
                                        <ContentTemplate>
                                            <table>
                                            </table>
                                            <br />
                                            <table width="100%">
                                                <tr>
                                                    <td align="left">
                                                        <div style="margin-left: 89px;">
                                                            <asp:Label ID="lblErrorMsg" Style="margin-left: 275px;" runat="server" CssClass="ErrorMsg"
                                                                Visible="true"></asp:Label></div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <br />
                                            <table style="margin: 0 0 40px 10px;">
                                                <tr>
                                                    <td>
                                                        <div style="margin-left: 28px;">
                                                            <img src="Images/medal.png" /></div>
                                                    </td>
                                                    <td>
                                                        <div style="margin-left: 33px;">
                                                            <asp:Label ID="Label8" runat="server" Style="font-family: Garamond; font-size: 36PX;
                                                                color: Silver;" Text="Work hard in silence, let your <br> success by your noise."></asp:Label>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <div style="margin-left: 12PX; margin-top: -21px;">
                                                            <asp:Label ID="Label214" runat="server" Style="font-family: Century Gothic; font-size: 22px;
                                                                color: Black;" Text="Dear"></asp:Label>&nbsp;
                                                            <asp:Label ID="lblUserName" runat="server" Style="font-family: Century Gothic; font-size: 22px;
                                                                color: Black;" Text=""></asp:Label>
                                                            <asp:Label ID="Label2" runat="server" Style="font-family: Century Gothic; font-size: 22px;
                                                                color: Black;" Text=","></asp:Label>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table>
                                                <tr>
                                                    <td>
                                                        <div style="margin-left: 14PX;">
                                                            <asp:Label ID="Label218" runat="server" Style="font-family: Century Gothic; font-size: 22px;
                                                                color: Black;" Text="You have learnt a number of skills  as proven to be best user of your Integra software. System recommended to rate you as excellent Integra user."></asp:Label></div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div style="margin-left: 14PX;">
                                                            <asp:Label ID="Label1" runat="server" Style="font-family: Century Gothic; font-size: 22px;
                                                                color: Black;" Text=""></asp:Label></div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table>
                                                <tr>
                                                    <td>
                                                        <div style="margin-left: 14PX;">
                                                            <asp:Label ID="Label3" runat="server" Style="font-family: Century Gothic; font-size: 22px;
                                                                color: Black;" Text="You get a chance to recognize in Integra network of global users. This will equally give you advantage in your resume."></asp:Label></div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div style="margin-left: 14PX;">
                                                            <asp:Label ID="Label4" runat="server" Style="font-family: Century Gothic; font-size: 22px;
                                                                color: Black;" Text=""></asp:Label></div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table>
                                                <tr>
                                                    <td>
                                                        <div style="margin-left: 14PX;">
                                                            <asp:Label ID="Label5" runat="server" Style="font-family: Century Gothic; font-size: 22px;
                                                                color: Black;" Text="By clicking any one of below best fit answer, you will be placed in best software users verified list. Additionally you get a chance to be Integra brand ambassador."></asp:Label></div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div style="margin-left: 14PX;">
                                                            <asp:Label ID="Label7" runat="server" Style="font-family: Century Gothic; font-size: 22px;
                                                                color: Black;" Text=""></asp:Label></div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <br />
                                            <table>
                                                <tr>
                                                    <td>
                                                        <div style="margin-left: 11px;">
                                                            <asp:RadioButtonList ID="rblmsg1" Style="font-family: Century Gothic; font-size: 18px;"
                                                                runat="server" AutoPostBack="false" RepeatDirection="vertical" RepeatLayout="Flow"
                                                                Font-Bold="false" ForeColor="Black">
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table>
                                                <tr>
                                                    <td align="center">
                                                        <div style="margin: 15px; margin-left: 697px;">
                                                            <telerik:RadButton ID="btnPI8Save" runat="server" CssClass="buttonTelerik2" Text=" Save "
                                                                Skin="Glow">
                                                            </telerik:RadButton>
                                                            &nbsp;
                                                            <telerik:RadButton ID="btnPI8Cancel" runat="server" CssClass="buttonTelerik2" Text="Cancel"
                                                                Skin="Glow">
                                                            </telerik:RadButton>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table>
                                                <tr>
                                                    <td>
                                                        <div style="margin-left: 623PX;">
                                                            <asp:Label ID="Label11" runat="server" Style="font-family: Arial; font-size: 10PX;
                                                                color: Silver;" Text="You may cancel, if you don't wish to see this notification again."></asp:Label></div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </telerik:RadWindow>
                                </Windows>
                            </telerik:RadWindowManager>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <asp:Label ID="lblUserId" runat="server" Visible="false"></asp:Label>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <div>
                    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <telerik:RadWindowManager ID="RadWindowManager1" ShowContentDuringLoad="true" VisibleStatusbar="false"
                                RegisterWithScriptManager="True" EnableShadow="True" ReloadOnShow="true" Height="700px"
                                Width="943px" runat="server">
                                <Windows>
                                    <telerik:RadWindow ID="rwCustomer" Title="" runat="server" Modal="True" Behaviors="Move">
                                        <ContentTemplate>
                                            <table>
                                            </table>
                                            <br />
                                            <table width="100%">
                                                <tr>
                                                    <td align="left">
                                                        <div style="margin-left: 89px;">
                                                            <asp:Label ID="Label6" Style="margin-left: 275px;" runat="server" CssClass="ErrorMsg"
                                                                Visible="true"></asp:Label></div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table style="margin: 0 0 40px 10px;">
                                                <tr>
                                                    <td>
                                                        <div style="margin-left: 33px;">
                                                            <asp:Label ID="Label9" runat="server" Style="font-family: Garamond; font-size: 36PX;
                                                                color: Silver;" Text="Booked Orders (2018)"></asp:Label>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table>
                                                <tr>
                                                    <td>
                                                        <div style="margin-left: 46PX; margin-top: -38px;">
                                                            <asp:Label ID="Label10" runat="server" Style="font-family: Century Gothic; font-size: 16px;
                                                                color: Black;" Text="Customer:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <div style="margin-top: -38px; margin-left: 7px;">
                                                            <telerik:RadComboBox ID="cmbCustomer" runat="server" CheckBoxes="FALSE" Width="140"
                                                                Skin="WebBlue" AutoPostBack="true" >
                                                            </telerik:RadComboBox>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div style="margin-left: 46PX; margin-top: -38px;">
                                                            <asp:Label ID="Label12" runat="server" Style="font-family: Century Gothic; font-size: 16px;
                                                                color: Black;" Text="Sr No:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <div style="margin-top: -38px; margin-left: 7px;">
                                                             <telerik:RadComboBox ID="cmbSrNoo" runat="server" CheckBoxes="true" Width="140"
                                                                Skin="WebBlue">
                                                            </telerik:RadComboBox>
                                                        </div>
                                                    </td>
                                                    
                                                </tr>
                                            </table>
                                            <table>
                                                <tr>
                                                    <td align="center">
                                                        <div style="margin: 05px; margin-left: 809px;">
                                                            <telerik:RadButton ID="btnViewChart" runat="server" CssClass="buttonTelerik2" Text="View Chart"
                                                                Skin="Glow">
                                                            </telerik:RadButton>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <div style="margin-left: 17px; margin-top: 4px;">
                                                            <telerik:RadHtmlChart ID="CustomerFilterChart" Height="430px" Width="875px" runat="server"
                                                                Transitions="true" Skin="Metro" class="fs" Style="font-family: Calibri; position: relative;
                                                                border: 1px solid rgb(177, 177, 177); border-radius: 0 0 5px 5px; background: linear-gradient(#e8e8e8, #fff);">
                                                                <PlotArea>
                                                                    <Series>
                                                                        <telerik:PieSeries StartAngle="140" DataFieldY="Value" NameField="Name" ExplodeField="true">
                                                                            <TooltipsAppearance BackgroundColor="AliceBlue" DataFormatString="#,###,##0%" />
                                                                            <LabelsAppearance DataFormatString="#,###,##0%" Visible="true" />
                                                                        </telerik:PieSeries>
                                                                    </Series>
                                                                </PlotArea>
                                                                <ChartTitle Text="">
                                                                    <Appearance Align="left" Position="Top">
                                                                        <TextStyle Bold="true" FontSize="14px"></TextStyle>
                                                                    </Appearance>
                                                                </ChartTitle>
                                                            </telerik:RadHtmlChart>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table>
                                                <tr>
                                                    <td align="center">
                                                        <div style="margin: 15px; margin-left: 834px;">
                                                            <telerik:RadButton ID="btnCancel" runat="server" CssClass="buttonTelerik2" Text=" Close "
                                                                Skin="Glow">
                                                            </telerik:RadButton>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </telerik:RadWindow>
                                </Windows>
                            </telerik:RadWindowManager>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </td>
        </tr>
    </table>




    <table>
        <tr>
            <td>
                <div>
                    <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <telerik:RadWindowManager ID="RadWindowManager2" ShowContentDuringLoad="true" VisibleStatusbar="false"
                                RegisterWithScriptManager="True" EnableShadow="True" ReloadOnShow="true" Height="500px"
                                Width="942px" runat="server">
                                <Windows>
                                    <telerik:RadWindow ID="rwTotalBooked" Title="" runat="server" Modal="True" Behaviors="Move">
                                        <ContentTemplate>
                                            <table>
                                            </table>
                                            <br />
                                            <table width="100%">
                                                <tr>
                                                    <td align="left">
                                                        <div style="margin-left: 89px;">
                                                            <asp:Label ID="Label13" Style="margin-left: 275px;" runat="server" CssClass="ErrorMsg"
                                                                Visible="true"></asp:Label></div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table style="margin: 0 0 40px 10px;">
                                                <tr>
                                                    <td>
                                                        <div style="margin-left: 33px;">
                                                            <asp:Label ID="Label14" runat="server" Style="font-family: Garamond; font-size: 36PX;
                                                                color: Silver;" Text="Total Booked - PCS"></asp:Label>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table>
                                                <tr>
                                                    <td>
                                                        <div style="margin-left: 46PX; margin-top: -38px;">
                                                            <asp:Label ID="Label15" runat="server" Style="font-family: Century Gothic; font-size: 16px;
                                                                color: Black;" Text="Season:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <div style="margin-top: -38px; margin-left: 7px;">
                                                          <asp:DropDownList ID="cmbSeason" runat="server" Width="120" AutoPostBack="true">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div style="margin-left: 46PX; margin-top: -38px;">
                                                            <asp:Label ID="Label16" runat="server" Style="font-family: Century Gothic; font-size: 16px;
                                                                color: Black;" Text="Sr No:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <div style="margin-top: -38px; margin-left: 7px;">
                                                             <telerik:RadComboBox ID="cmbSRNOOo" runat="server" CheckBoxes="true" Width="140"
                                                                Skin="WebBlue">
                                                            </telerik:RadComboBox>
                                                        </div>
                                                    </td>

                                                    
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div style="margin-left: 46PX; margin-top: 0px;">
                                                            <asp:Label ID="Label17" runat="server" Style="font-family: Century Gothic; font-size: 16px;
                                                                color: Black;" Text="Year:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <div style="margin-top: 0px; margin-left: 7px;">
                                                          <asp:DropDownList ID="cmbYear" runat="server" Width="120" AutoPostBack="FALSE">
                                                                <asp:ListItem>All</asp:ListItem>
                                                               <asp:ListItem>2017</asp:ListItem>
                    <asp:ListItem>2018</asp:ListItem>
                    <asp:ListItem>2019</asp:ListItem>
                    <asp:ListItem>2020</asp:ListItem>
                    <asp:ListItem>2021</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div style="margin-left: 46PX; margin-top: 0px;">
                                                            <asp:Label ID="Label18" runat="server" Style="font-family: Century Gothic; font-size: 16px;
                                                                color: Black;" Text="Month:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <div style="margin-top:0px; margin-left: 7px;">
                                                             <asp:DropDownList ID="cmbMonth" runat="server" Width="120" AutoPostBack="FALSE">
                                                                <asp:ListItem Value="0" >All</asp:ListItem>
                                                                <asp:ListItem Value="1" >JAN</asp:ListItem>
                    <asp:ListItem Value="2">FEB</asp:ListItem>
                    <asp:ListItem Value="3">MAR</asp:ListItem>
                    <asp:ListItem Value="4">APR</asp:ListItem>
                    <asp:ListItem Value="5">MAY</asp:ListItem>
                    <asp:ListItem Value="6">JUN</asp:ListItem>
                    <asp:ListItem Value="7">JUL</asp:ListItem>
                    <asp:ListItem Value="8">AUG</asp:ListItem>
                    <asp:ListItem Value="9">SEP</asp:ListItem>
                    <asp:ListItem Value="10">OCT</asp:ListItem>
                    <asp:ListItem Value="11">NOV</asp:ListItem>
                    <asp:ListItem Value="12">DEC</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>

                                                    
                                                </tr>
                                            </table>
                                            <table>
                                                <tr>
                                                    <td align="center">
                                                        <div style="margin: 05px; margin-left: 809px;">
                                                            <telerik:RadButton ID="btnTotalBookedd" runat="server" CssClass="buttonTelerik2" Text="View Chart"
                                                                Skin="Glow">
                                                            </telerik:RadButton>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <div style="margin-left: 17px; margin-top: 4px;">
                                                               <telerik:RadHtmlChart ID="chartPartiall" Height="200px" Width="875px" runat="server" Transitions="true"
                                                Skin="Windows7" Style="font-family: Calibri; position: relative; border: 1px solid rgb(177, 177, 177);
                                                border-radius: 0px 0px 5px 5px; background: linear-gradient(rgb(232, 232, 232), rgb(255, 255, 255));">
                                                <PlotArea>
                                                    <Series>
                                                        <telerik:BarSeries Name="Name" DataFieldY="Value">
                                                            <TooltipsAppearance DataFormatString="#,###,##0" />
                                                            <LabelsAppearance DataFormatString="#,###,##0" Visible="true" />
                                                        </telerik:BarSeries>
                                                    </Series>
                                                    <XAxis DataLabelsField="Name">
                                                    </XAxis>
                                                    <YAxis>
                                                        <LabelsAppearance Visible="false" RotationAngle="35" DataFormatString="#,###,##0" />
                                                    </YAxis>
                                                </PlotArea>
                                                <Legend>
                                                    <Appearance Visible="false" />
                                                </Legend>
                                                <ChartTitle Text="">
                                                    <Appearance>
                                                        <TextStyle Bold="true" FontSize="16px"></TextStyle>
                                                    </Appearance>
                                                </ChartTitle>
                                            </telerik:RadHtmlChart>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table>
                                                <tr>
                                                    <td align="center">
                                                        <div style="margin: 15px; margin-left: 834px;">
                                                            <telerik:RadButton ID="btnTotalBookedCancel" runat="server" CssClass="buttonTelerik2" Text=" Close "
                                                                Skin="Glow">
                                                            </telerik:RadButton>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </telerik:RadWindow>
                                </Windows>
                            </telerik:RadWindowManager>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </td>
        </tr>
    </table>



    <table>
        <tr>
            <td>
                <div>
                    <asp:UpdatePanel ID="UpdatePanel3" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <telerik:RadWindowManager ID="RadWindowManager3" ShowContentDuringLoad="true" VisibleStatusbar="false"
                                RegisterWithScriptManager="True" EnableShadow="True" ReloadOnShow="true" Height="500px"
                                Width="942px" runat="server">
                                <Windows>
                                    <telerik:RadWindow ID="rwTotalTurnover" Title="" runat="server" Modal="True" Behaviors="Move">
                                        <ContentTemplate>
                                            <table>
                                            </table>
                                            <br />
                                            <table width="100%">
                                                <tr>
                                                    <td align="left">
                                                        <div style="margin-left: 89px;">
                                                            <asp:Label ID="Label19" Style="margin-left: 275px;" runat="server" CssClass="ErrorMsg"
                                                                Visible="true"></asp:Label></div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table style="margin: 0 0 40px 10px;">
                                                <tr>
                                                    <td>
                                                        <div style="margin-left: 33px;">
                                                            <asp:Label ID="Label20" runat="server" Style="font-family: Garamond; font-size: 36PX;
                                                                color: Silver;" Text="Total Turnover"></asp:Label>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table>
                                                <tr>
                                                    <td>
                                                        <div style="margin-left: 46PX; margin-top: -38px;">
                                                            <asp:Label ID="Label21" runat="server" Style="font-family: Century Gothic; font-size: 16px;
                                                                color: Black;" Text="Season:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <div style="margin-top: -38px; margin-left: 7px;">
                                                          <asp:DropDownList ID="cmSeasonTotalTurnover" runat="server" Width="120" AutoPostBack="true">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div style="margin-left: 46PX; margin-top: -38px;">
                                                            <asp:Label ID="Label22" runat="server" Style="font-family: Century Gothic; font-size: 16px;
                                                                color: Black;" Text="Sr No:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <div style="margin-top: -38px; margin-left: 7px;">
                                                             <telerik:RadComboBox ID="cmSrNoTotalTurnover" runat="server" CheckBoxes="true" Width="140"
                                                                Skin="WebBlue">
                                                            </telerik:RadComboBox>
                                                        </div>
                                                    </td>

                                                    
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div style="margin-left: 46PX; margin-top: 0px;">
                                                            <asp:Label ID="Label23" runat="server" Style="font-family: Century Gothic; font-size: 16px;
                                                                color: Black;" Text="Year:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <div style="margin-top: 0px; margin-left: 7px;">
                                                          <asp:DropDownList ID="cmbYearTotalTurnover" runat="server" Width="120" AutoPostBack="FALSE">
                                                                <asp:ListItem>All</asp:ListItem>
                                                               <asp:ListItem>2017</asp:ListItem>
                    <asp:ListItem>2018</asp:ListItem>
                    <asp:ListItem>2019</asp:ListItem>
                    <asp:ListItem>2020</asp:ListItem>
                    <asp:ListItem>2021</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div style="margin-left: 46PX; margin-top: 0px;">
                                                            <asp:Label ID="Label24" runat="server" Style="font-family: Century Gothic; font-size: 16px;
                                                                color: Black;" Text="Month:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <div style="margin-top:0px; margin-left: 7px;">
                                                             <asp:DropDownList ID="cmbMonthTotalTurnover" runat="server" Width="120" AutoPostBack="FALSE">
                                                                <asp:ListItem Value="0" >All</asp:ListItem>
                                                                <asp:ListItem Value="1" >JAN</asp:ListItem>
                    <asp:ListItem Value="2">FEB</asp:ListItem>
                    <asp:ListItem Value="3">MAR</asp:ListItem>
                    <asp:ListItem Value="4">APR</asp:ListItem>
                    <asp:ListItem Value="5">MAY</asp:ListItem>
                    <asp:ListItem Value="6">JUN</asp:ListItem>
                    <asp:ListItem Value="7">JUL</asp:ListItem>
                    <asp:ListItem Value="8">AUG</asp:ListItem>
                    <asp:ListItem Value="9">SEP</asp:ListItem>
                    <asp:ListItem Value="10">OCT</asp:ListItem>
                    <asp:ListItem Value="11">NOV</asp:ListItem>
                    <asp:ListItem Value="12">DEC</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>

                                                    
                                                </tr>
                                            </table>
                                            <table>
                                                <tr>
                                                    <td align="center">
                                                        <div style="margin: 05px; margin-left: 809px;">
                                                            <telerik:RadButton ID="ViewTotalTurnover" runat="server" CssClass="buttonTelerik2" Text="View Chart"
                                                                Skin="Glow">
                                                            </telerik:RadButton>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <div style="margin-left: 17px; margin-top: 4px;">
                                                        <telerik:RadHtmlChart runat="server" ID="ChartTotalTurnover" Height="200px" Width="875px"  Transitions="true"
                                                    Skin="MetroTouch" Style="font-family: Calibri; position: relative; border: 1px solid rgb(177, 177, 177);
                                                    border-radius: 0px 0px 5px 5px; background: linear-gradient(rgb(232, 232, 232), rgb(255, 255, 255));">
                                                 
                                                 
                                                    <PlotArea>
                                                        <Series>
                                                            <telerik:BarSeries Name="Name" DataFieldY="Value">
                                                                <TooltipsAppearance DataFormatString="$#,###,##0" />
                                                                <LabelsAppearance DataFormatString="$#,###,##0" Visible="true" />
                                                            </telerik:BarSeries>
                                                        </Series>
                                                        <XAxis DataLabelsField="Name">
                                                        </XAxis>
                                                        <YAxis>
                                                            <LabelsAppearance Visible="false" RotationAngle="35" DataFormatString="#,###,##0" />
                                                        </YAxis>
                                                    </PlotArea>
                                                    <Legend>
                                                        <Appearance Visible="false" />
                                                    </Legend>
                                                    <ChartTitle Text="">
                                                        <Appearance>
                                                            <TextStyle Bold="true" FontSize="16px"></TextStyle>
                                                        </Appearance>
                                                    </ChartTitle>
                                                </telerik:RadHtmlChart>

                                                        
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table>
                                                <tr>
                                                    <td align="center">
                                                        <div style="margin: 15px; margin-left: 834px;">
                                                            <telerik:RadButton ID="CancelTotalTurnover" runat="server" CssClass="buttonTelerik2" Text=" Close "
                                                                Skin="Glow">
                                                            </telerik:RadButton>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </telerik:RadWindow>
                                </Windows>
                            </telerik:RadWindowManager>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </td>
        </tr>
    </table>



    <table>
        <tr>
            <td>
                <div>
                    <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <telerik:RadWindowManager ID="RadWindowManager4" ShowContentDuringLoad="true" VisibleStatusbar="false"
                                RegisterWithScriptManager="True" EnableShadow="True" ReloadOnShow="true" Height="500px"
                                Width="942px" runat="server">
                                <Windows>
                                    <telerik:RadWindow ID="rwTotalNoofSamples" Title="" runat="server" Modal="True" Behaviors="Move">
                                        <ContentTemplate>
                                            <table>
                                            </table>
                                            <br />
                                            <table width="100%">
                                                <tr>
                                                    <td align="left">
                                                        <div style="margin-left: 89px;">
                                                            <asp:Label ID="Label25" Style="margin-left: 275px;" runat="server" CssClass="ErrorMsg"
                                                                Visible="true"></asp:Label></div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table style="margin: 0 0 40px 10px;">
                                                <tr>
                                                    <td>
                                                        <div style="margin-left: 33px;">
                                                            <asp:Label ID="Label26" runat="server" Style="font-family: Garamond; font-size: 36PX;
                                                                color: Silver;" Text="Total No. of Samples"></asp:Label>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table>
                                                <tr>
                                                    <td>
                                                        <div style="margin-left: 46PX; margin-top: -38px;">
                                                            <asp:Label ID="Label27" runat="server" Style="font-family: Century Gothic; font-size: 16px;
                                                                color: Black;" Text="Supplier:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <div style="margin-top: -38px; margin-left: 7px;">
                                                        <telerik:RadComboBox ID="cmbSupplierSamples" DropDownAutoWidth ="Enabled"  runat="server" CheckBoxes="true" Width="220"
                                                                Skin="WebBlue">
                                                            </telerik:RadComboBox>
                                                        </div>
                                                    </td>
                                                   
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div style="margin-left: 46PX; margin-top: 0px;">
                                                            <asp:Label ID="Label29" runat="server" Style="font-family: Century Gothic; font-size: 16px;
                                                                color: Black;" Text="Year:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <div style="margin-top: 0px; margin-left: 7px;">
                                                          <asp:DropDownList ID="cmbYearTotalNoofSamples" runat="server" Width="120" AutoPostBack="FALSE">
                                                                <asp:ListItem>All</asp:ListItem>
                                                               <asp:ListItem>2017</asp:ListItem>
                    <asp:ListItem>2018</asp:ListItem>
                    <asp:ListItem>2019</asp:ListItem>
                    <asp:ListItem>2020</asp:ListItem>
                    <asp:ListItem>2021</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div style="margin-left: 46PX; margin-top: 0px;">
                                                            <asp:Label ID="Label30" runat="server" Style="font-family: Century Gothic; font-size: 16px;
                                                                color: Black;" Text="Month:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <div style="margin-top:0px; margin-left: 7px;">
                                                             <asp:DropDownList ID="cmbMonthTotalNoofSamples" runat="server" Width="120" AutoPostBack="FALSE">
                                                                <asp:ListItem Value="0" >All</asp:ListItem>
                                                                <asp:ListItem Value="1" >JAN</asp:ListItem>
                    <asp:ListItem Value="2">FEB</asp:ListItem>
                    <asp:ListItem Value="3">MAR</asp:ListItem>
                    <asp:ListItem Value="4">APR</asp:ListItem>
                    <asp:ListItem Value="5">MAY</asp:ListItem>
                    <asp:ListItem Value="6">JUN</asp:ListItem>
                    <asp:ListItem Value="7">JUL</asp:ListItem>
                    <asp:ListItem Value="8">AUG</asp:ListItem>
                    <asp:ListItem Value="9">SEP</asp:ListItem>
                    <asp:ListItem Value="10">OCT</asp:ListItem>
                    <asp:ListItem Value="11">NOV</asp:ListItem>
                    <asp:ListItem Value="12">DEC</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>

                                                    
                                                </tr>
                                            </table>
                                            <table>
                                                <tr>
                                                    <td align="center">
                                                        <div style="margin: 05px; margin-left: 809px;">
                                                            <telerik:RadButton ID="btnTotalNoofSamples" runat="server" CssClass="buttonTelerik2" Text="View Chart"
                                                                Skin="Glow">
                                                            </telerik:RadButton>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <div style="margin-left: 17px; margin-top: 4px;">
                                                        <telerik:RadHtmlChart runat="server" ID="ChartTotalNoofSamples" Height="200px" Width="875px"  Transitions="true"
                                                    Skin="BlackMetroTouch" Style="font-family: Calibri; position: relative; border: 1px solid rgb(177, 177, 177);
                                                    border-radius: 0px 0px 5px 5px; background: linear-gradient(rgb(232, 232, 232), rgb(255, 255, 255));">
                                                 
                                                 
                                                    <PlotArea>
                                                        <Series>
                                                            <telerik:BarSeries Name="Name" DataFieldY="Value">
                                                                <TooltipsAppearance DataFormatString="#,###,##0" />
                                                                <LabelsAppearance DataFormatString="#,###,##0" Visible="true" />
                                                            </telerik:BarSeries>
                                                        </Series>
                                                        <XAxis DataLabelsField="Name">
                                                        </XAxis>
                                                        <YAxis>
                                                            <LabelsAppearance Visible="false" RotationAngle="35" DataFormatString="#,###,##0" />
                                                        </YAxis>
                                                    </PlotArea>
                                                    <Legend>
                                                        <Appearance Visible="false" />
                                                    </Legend>
                                                    <ChartTitle Text="">
                                                        <Appearance>
                                                            <TextStyle Bold="true" FontSize="16px"></TextStyle>
                                                        </Appearance>
                                                    </ChartTitle>
                                                </telerik:RadHtmlChart>

                                                        
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table>
                                                <tr>
                                                    <td align="center">
                                                        <div style="margin: 15px; margin-left: 834px;">
                                                            <telerik:RadButton ID="btnCancelbtnTotalNoofSamples" runat="server" CssClass="buttonTelerik2" Text=" Close "
                                                                Skin="Glow">
                                                            </telerik:RadButton>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </telerik:RadWindow>
                                </Windows>
                            </telerik:RadWindowManager>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
