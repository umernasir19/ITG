<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="MainPageStore.aspx.vb" Inherits="Integra.MainPageStore" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    </script>
    <script src="Scripts/AC_RunActiveContent.js" type="text/javascript"></script>
    <script type="text/javascript">
        function createChart2() {
            $("#Chart2").kendoChart({

                theme: $(document).data("kendoSkin") || "default",
                dataSource: {
                    type: "odata",
                    transport: {
                        read: {
                            url: "../../Services/WcfDataService1.svc/AllianceSummaryPartnershipMixes"
                        }
                    },
                    sort: {
                        field: "Name",
                        dir: "asc"
                    }
                },
                title: {
                    text: "Partnership Mix"
                },
                legend: {
                    position: "bottom",
                    margin: 0
                },
                seriesDefaults: {
                    type: "pie"
                },
                series: [{
                    field: "Value",
                    categoryField: "Name"
                }],
                tooltip: {
                    visible: true,
                    format: "{0:N0}"
                },
                chartArea: { margin: 0 },
                plotArea: { margin: 0 }
            }).css({ height: "200px" });
        }
    </script>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="center" valign="middle" id="Td2" style="background-color: Transparent;
                color: Red; font-family: Verdana; font-weight: bold; height: 18px; width: 926px;"
                runat="server">
                <div class="left_side_container" style="margin-top: -21px; height: 510px;">
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
                <div class="center_container" style="height: 460px;">
                    <div style="margin-left: 13px; margin-top: -20px;">
                        <table>
                            <tr>
                                <td>
                                    <div style="width: 310px; font-family: Calibri; /* background-color: Silver; */
    border: 1px solid #9f9f9f; font-weight: bold; color: #3e3e3e; text-align: left; padding-top: 8px; padding: 8px 0 10px 10px;
                                        margin-bottom: 5px; border-radius: 5px 5px 0 0px; background: linear-gradient(#e2e2e2, #fff);
                                        font-size: 13px;">
                                        Purchasing Summary <a href="#" class="topbar-item-new ion-android-settings"></a>
                                        <asp:ImageButton ID="btnPurchasingSummary" Style="margin-left: 291px; margin-top: -15px;
                                            width: 16px;" ToolTip="Click here to View Chart" ImageUrl="~/Images/iconnnn.png"
                                            runat="server"></asp:ImageButton>
                                        <div class="msg-area" style="margin-top: 0px;">
                                            <div class="msg-new-1" style="margin-top: -13px; margin-left: 120px;">
                                                <div class="color-1">
                                                </div>
                                                Fabric
                                            </div>
                                            <div class="msg-new-2" style="margin-left: 168px; margin-top: -12px;">
                                                <div class="color-2">
                                                </div>
                                                Accessories
                                            </div>
                                        </div>
                                    </div>
                                    <div id="" style="margin-top: -6px; font-size: 10px">
                                        <telerik:RadHtmlChart runat="server" ID="Chart1" Height="203px" Width="320px" Skin="Silk"
                                            Style="font-family: Calibri; position: relative; border: 1px solid rgb(177, 177, 177);
                                            border-radius: 0px 0px 5px 5px; background: linear-gradient(rgb(232, 232, 232), rgb(255, 255, 255));">
                                            <PlotArea>
                                                <Series>
                                                    <telerik:BarSeries Name="Name" DataFieldY="Value1">
                                                        <TooltipsAppearance DataFormatString="#,###,##0" Visible="false" />
                                                        <LabelsAppearance DataFormatString="#,###,##0" Visible="true" />
                                                    </telerik:BarSeries>
                                                    <telerik:ColumnSeries DataFieldY="Value2" ColorField="blue">
                                                        <TooltipsAppearance DataFormatString="#,###,##0" Visible="false" />
                                                        <LabelsAppearance DataFormatString="#,###,##0" Visible="true" />
                                                    </telerik:ColumnSeries>
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
                                <td>
                                    <div style="margin-left: 33px; margin-top: 0px;">
                                        <div style="width: 310px; font-family: Calibri; border: 1px solid #9f9f9f; font-weight: bold;
                                            color: #3e3e3e; text-align: left; padding-top: 8px; padding: 8px 0 10px 10px;
                                            margin-bottom: 0px; border-radius: 5px 5px 0 0px; background: linear-gradient(#e2e2e2, #fff);
                                            font-size: 13px;">
                                            Stock Position <a href="#" class="topbar-item-new ion-android-settings"></a>
                                            <asp:ImageButton ID="BtnPartialCustomerChart" Style="margin-left: 291px; margin-top: -15px;
                                                width: 16px;" ToolTip="Click here to View Chart" ImageUrl="~/Images/iconnnn.png"
                                                runat="server"></asp:ImageButton>
                                            <div class="msg-area" style="margin-top: 0px;">
                                                <div class="msg-new-1" style="margin-top: -13px; margin-left: 76px;">
                                                    <div style="margin-left: -14px; width: 10px; height: 10px; float: left; margin: 0 5px 0 0;
                                                        background-color: rgb(22,94,150)">
                                                    </div>
                                                    Positive Amount
                                                </div>
                                                <div class="msg-new-2" style="margin-left: 163px; margin-top: -12px;">
                                                    <div style="margin-left: -10px; width: 10px; height: 10px; float: left; margin: 0 5px 0 0;
                                                        background-color: rgb(28,25,26)">
                                                    </div>
                                                    Negative Amount
                                                </div>
                                            </div>
                                        </div>
                                        <div style="margin-left: 0px;">
                                            <telerik:RadHtmlChart runat="server" ID="Chart2" Height="203px" Width="320px" Skin="Outlook"
                                                Style="font-family: Calibri; position: relative; border: 1px solid rgb(177, 177, 177);
                                                border-radius: 0px 0px 5px 5px; background: linear-gradient(rgb(232, 232, 232), rgb(255, 255, 255));">
                                                <PlotArea>
                                                    <Series>
                                                        <telerik:BarSeries Name="Name" DataFieldY="Value1">
                                                            <TooltipsAppearance DataFormatString="#,###,##0" Visible="true" />
                                                            <LabelsAppearance DataFormatString="#,###,##0" Visible="false" />
                                                        </telerik:BarSeries>
                                                        <telerik:ColumnSeries DataFieldY="Value2" ColorField="blue">
                                                            <TooltipsAppearance DataFormatString="#,###,##0" Visible="true" />
                                                            <LabelsAppearance DataFormatString="#,###,##0" Visible="false" />
                                                        </telerik:ColumnSeries>
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
                    <asp:Panel ID="mainpnl" runat="server" Visible="true">
                        <div style="margin: 0 0 0 14px;">
                            <table>
                                <tr>
                                    <td>
                                        <div style="width: 310px; margin-top: -1px; height: 16px; font-family: Calibri; border: 1px solid #9f9f9f;
                                            font-weight: bold; color: #3e3e3e; text-align: left; padding-top: 8px; padding: 8px 0 10px 10px;
                                            margin-bottom: 0px; border-radius: 5px 5px 0 0px; background: linear-gradient(#e2e2e2, #fff);
                                            font-size: 13px;">
                                            <asp:ImageButton ID="ImageButton1" Style="margin-left: 291px; margin-top: 1px; width: 16px;"
                                                ToolTip="Click here to View Chart" ImageUrl="~/Images/iconnnn.png" runat="server">
                                            </asp:ImageButton>
                                            <div style="margin-top: -16px;">
                                                Purchasing Detail Overview (Last 3 Months)</div>
                                        </div>
                                        <div style="overflow: scroll; height: 214px; width: 322PX;">
                                            <Smart:SmartDataGrid ID="dgView" runat="server" AllowPaging="false" AllowSorting="false"
                                                Width="100%" AutoGenerateColumns="False" CellPadding="4" CssClass="table" PageSize="6"
                                                ShowFooter="false" ForeColor="white" Visible="true" GridLines="both">
                                                <Columns>
                                                    <asp:BoundColumn ItemStyle-HorizontalAlign="center" Visible="false" HeaderStyle-BackColor="#04A4BD"
                                                        HeaderStyle-ForeColor="Black" HeaderText="CustomerID" DataField="CustomerID">
                                                        <HeaderStyle HorizontalAlign="center" Width="1%" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn ItemStyle-HorizontalAlign="left" HeaderStyle-BackColor="#128ca2"
                                                        ItemStyle-Font-Names="century gothic" ItemStyle-BackColor="#59cce0" HeaderStyle-ForeColor="Black"
                                                        ItemStyle-Font-Size="10px" HeaderText="Customer" DataField="CustomerName">
                                                        <HeaderStyle HorizontalAlign="center" Width="20%" Font-Size="10px" Font-Names="century gothic" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn ItemStyle-HorizontalAlign="right" HeaderStyle-BackColor="#128ca2"
                                                        ItemStyle-Font-Names="century gothic" DataFormatString="{0:#,##,###,0}" ItemStyle-BackColor="#59cce0"
                                                        HeaderStyle-ForeColor="Black" ItemStyle-Font-Size="10px" HeaderText="PO ($)"
                                                        DataField="POAmount">
                                                        <HeaderStyle HorizontalAlign="center" Width="8%" Font-Size="10px" Font-Names="century gothic" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn ItemStyle-HorizontalAlign="right" DataFormatString="{0:#,##,###,0}"
                                                        HeaderStyle-BackColor="#128ca2" ItemStyle-Font-Names="century gothic" ItemStyle-BackColor="#59cce0"
                                                        HeaderStyle-ForeColor="Black" ItemStyle-Font-Size="10px" HeaderText="Receive ($)"
                                                        DataField="ReceiveAmount">
                                                        <HeaderStyle HorizontalAlign="center" Width="8%" Font-Size="10px" Font-Names="century gothic" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn ItemStyle-HorizontalAlign="right" DataFormatString="{0:#,##,###,0}"
                                                        HeaderStyle-BackColor="#128ca2" ItemStyle-Font-Names="century gothic" ItemStyle-BackColor="#59cce0"
                                                        HeaderStyle-ForeColor="Black" ItemStyle-Font-Size="10px" HeaderText="Issue ($)"
                                                        DataField="IssueAmount">
                                                        <HeaderStyle HorizontalAlign="center" Width="8%" Font-Size="10px" Font-Names="century gothic" />
                                                    </asp:BoundColumn>
                                                </Columns>
                                            </Smart:SmartDataGrid>
                                        </div>
                                    </td>
                                    &nbsp;
                                    <td>
                                        <div style="margin-left: 0px;">
                                        </div>
                                    </td>
                                    <td>
                                        <div style="margin-left: 33px; margin-top: 2px;">
                                            <div style="width: 310px; height: 16px; font-family: Calibri; /* background-color: Silver;
                                                */
    border: 1px solid #9f9f9f; font-weight: bold; color: #3e3e3e; text-align: left; padding-top: 8px; padding: 8px 0 10px 10px;
                                                margin-bottom: 0px; border-radius: 5px 5px 0 0px; background: linear-gradient(#e2e2e2, #fff);
                                                font-size: 13px;">
                                                <a href="#" class="topbar-item-new ion-android-settings"></a>Supplier Performance
                                                Overview (Last 3 Months)
                                            </div>
                                            <div style="overflow: scroll; height: 214px; width: 322PX;">
                                                <Smart:SmartDataGrid ID="dgView2" runat="server" AllowPaging="false" AllowSorting="false"
                                                    Width="100%" AutoGenerateColumns="False" CellPadding="4" CssClass="table" PageSize="6"
                                                    ShowFooter="false" ForeColor="white" Visible="true" GridLines="both">
                                                    <Columns>
                                                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" Visible="false" HeaderStyle-BackColor="#1771a3"
                                                            HeaderStyle-ForeColor="Black" HeaderText="SupplierDatabaseId" DataField="SupplierDatabaseId">
                                                            <HeaderStyle HorizontalAlign="center" Width="1%" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn ItemStyle-HorizontalAlign="left" HeaderStyle-BackColor="#1771a3"
                                                            ItemStyle-Font-Names="century gothic" ItemStyle-BackColor="#bcd7f0" HeaderStyle-ForeColor="Black"
                                                            ItemStyle-Font-Size="10px" HeaderText="Supplier" DataField="SupplierName">
                                                            <HeaderStyle HorizontalAlign="center" Width="20%" Font-Size="10px" Font-Names="century gothic" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn ItemStyle-HorizontalAlign="right" HeaderStyle-BackColor="#1771a3"
                                                            ItemStyle-Font-Names="century gothic" ItemStyle-BackColor="#bcd7f0" HeaderStyle-ForeColor="Black"
                                                            ItemStyle-Font-Size="10px" HeaderText="Purchase Value" DataField="PurchaseValue">
                                                            <HeaderStyle HorizontalAlign="center" Width="8%" Font-Size="10px" Font-Names="century gothic" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#1771a3"
                                                            Visible="false" ItemStyle-Font-Names="century gothic" ItemStyle-BackColor="#bcd7f0"
                                                            HeaderStyle-ForeColor="Black" ItemStyle-Font-Size="10px" HeaderText="Avg Delivery"
                                                            DataField="AvgDelivery">
                                                            <HeaderStyle HorizontalAlign="center" Width="8%" Font-Size="10px" Font-Names="century gothic" />
                                                        </asp:BoundColumn>
                                                        <asp:TemplateColumn HeaderText="Avg Delivery" HeaderStyle-Font-Size="10px" ItemStyle-Font-Names="century gothic"
                                                            HeaderStyle-BackColor="#1771a3" HeaderStyle-ForeColor="Black">
                                                            <ItemStyle Width="10%" HorizontalAlign="center" BackColor="#bcd7f0"></ItemStyle>
                                                            <ItemTemplate>
                                                                <div style="margin-left: -42px;">
                                                                    <asp:Label ID="lblAvgDelivery" runat="server" Style="text-align: center;"></asp:Label></div>
                                                                &nbsp;
                                                                <div style="margin-left: 28px; margin-top: -21px;">
                                                                    <asp:ImageButton ID="img1" runat="server" Style="margin-left: 0px;" ImageUrl="~/Images/greenimage.png"
                                                                        Visible="true" /></div>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="10%" HorizontalAlign="Center" Font-Names="century gothic"></HeaderStyle>
                                                        </asp:TemplateColumn>
                                                    </Columns>
                                                </Smart:SmartDataGrid>
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
    <div style="margin-left: 254px; margin-top: 12px;">
        <table>
            <tr>
                <td>
                    <div style="width: 310px; font-family: Calibri; border: 1px solid #9f9f9f; font-weight: bold;
                        color: #3e3e3e; text-align: left; padding-top: 8px; padding: 8px 0 10px 10px;
                        margin-bottom: 0px; border-radius: 5px 5px 0 0px; background: linear-gradient(#e2e2e2, #fff);
                        font-size: 12px;">
                        Inventory Activity – SR Wise (Fabric Store - Last 2 Months) <a href="#" class="topbar-item-new ion-android-settings">
                        </a>
                    </div>
                    <div style="margin-left: 0px;">
                        <telerik:RadHtmlChart ID="Chart5" SeriesOrientation="Vertical" Height="203px" Width="320px"
                            runat="server" Transitions="true" Skin="Metro" Style="font-family: Calibri; position: relative;
                            border: 1px solid rgb(177, 177, 177); border-radius: 0px 0px 5px 5px; background: linear-gradient(rgb(232, 232, 232), rgb(255, 255, 255));">
                            <PlotArea>
                                <Series>
                                    <telerik:ColumnSeries DataFieldY="Value1" ColorField="red">
                                        <TooltipsAppearance DataFormatString="#,###,##0" Visible="true" />
                                        <LabelsAppearance DataFormatString="#,###,##0" Visible="false" />
                                    </telerik:ColumnSeries>
                                    <telerik:ColumnSeries DataFieldY="Value2" ColorField="blue">
                                        <TooltipsAppearance DataFormatString="#,###,##0" Visible="true" />
                                        <LabelsAppearance DataFormatString="#,###,##0" Visible="false" />
                                    </telerik:ColumnSeries>
                                    <telerik:ColumnSeries DataFieldY="Value3" ColorField="blue">
                                        <TooltipsAppearance DataFormatString="#,###,##0" Visible="true" />
                                        <LabelsAppearance DataFormatString="#,###,##0" Visible="false" />
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
                        <div class="msg-area">
                            <div class="msg-new-1" style="margin-left: 36PX;">
                                <div style="width: 10px; height: 10px; float: left; margin: 0 5px 0 0; background-color: rgb(100,187,228)">
                                </div>
                                PO
                            </div>
                            <div class="msg-new-2">
                                <div style="width: 10px; height: 10px; float: left; margin: 0 5px 0 0; background-color: rgb(89,175,107)">
                                </div>
                                Receive
                            </div>
                            <div class="msg-new-2">
                                <div style="width: 10px; height: 10px; float: left; margin: 0 5px 0 0; background-color: Yellow;">
                                </div>
                                Issue
                            </div>
                        </div>
                    </div>
                </td>
                &nbsp;
                <td>
                    <div style="margin-left: 33px; margin-top: 0px;">
                        <div style="width: 310px; font-family: Calibri; border: 1px solid #9f9f9f; font-weight: bold;
                            color: #3e3e3e; text-align: left; padding-top: 8px; padding: 8px 0 10px 10px;
                            margin-bottom: 0px; border-radius: 5px 5px 0 0px; background: linear-gradient(#e2e2e2, #fff);
                            font-size: 11px;">
                            Inventory Activity – SR Wise (Accessories Store - Last 2 Months) <a href="#" class="topbar-item-new ion-android-settings">
                            </a>
                        </div>
                        <div style="margin-left: 0px;">
                            <telerik:RadHtmlChart ID="Chart6" Height="203px" Width="320px" runat="server" Transitions="true"
                                Skin="Silk" Style="font-family: Calibri; position: relative; border: 1px solid rgb(177, 177, 177);
                                border-radius: 0px 0px 5px 5px; background: linear-gradient(rgb(232, 232, 232), rgb(255, 255, 255));">
                                <PlotArea>
                                    <Series>
                                        <telerik:ColumnSeries DataFieldY="Value1" ColorField="red">
                                            <TooltipsAppearance Visible="true" />
                                            <LabelsAppearance DataFormatString="#,###,##0" Visible="false" />
                                        </telerik:ColumnSeries>
                                        <telerik:ColumnSeries DataFieldY="Value2" ColorField="blue">
                                            <TooltipsAppearance Visible="true" />
                                            <LabelsAppearance DataFormatString="#,###,##0" Visible="false" />
                                        </telerik:ColumnSeries>
                                        <telerik:ColumnSeries DataFieldY="Value3" ColorField="blue">
                                            <TooltipsAppearance Visible="true" />
                                            <LabelsAppearance DataFormatString="#,###,##0" Visible="false" />
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
                            <div class="msg-area">
                                <div class="msg-new-1" style="margin-left: 37PX;">
                                    <div style="width: 10px; height: 10px; float: left; margin: 0 5px 0 0; background-color: rgb(78,184,203)">
                                    </div>
                                    PO
                                </div>
                                <div class="msg-new-2">
                                    <div style="width: 10px; height: 10px; float: left; margin: 0 5px 0 0; background-color: rgb(161,206,113)">
                                    </div>
                                    Receive
                                </div>
                                <div class="msg-new-2">
                                    <div style="width: 10px; height: 10px; float: left; margin: 0 5px 0 0; background-color: rgb(243,185,103)">
                                    </div>
                                    Issue
                                </div>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <table>
        <tr>
            <td>
                <div>
                    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <telerik:RadWindowManager ID="RadWindowManager1" ShowContentDuringLoad="true" VisibleStatusbar="false"
                                RegisterWithScriptManager="True" EnableShadow="True" ReloadOnShow="true" Height="730px"
                                Width="950px" runat="server">
                                <Windows>
                                    <telerik:RadWindow ID="rwCustomerInventory" Title="" runat="server" Modal="True"
                                        Behaviors="Move">
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
                                                                color: Silver;" Text="Stock Position"></asp:Label>
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
                                                            <telerik:RadComboBox ID="cmbCustomer" runat="server" CheckBoxes="True" Width="140"
                                                                Skin="WebBlue">
                                                            </telerik:RadComboBox>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div style="margin-left: 46PX; margin-top: -38px;">
                                                            <asp:Label ID="Label12" runat="server" Style="font-family: Century Gothic; font-size: 16px;
                                                                color: Black;" Text="Type:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <div style="margin-top: -38px; margin-left: 7px;">
                                                            <asp:DropDownList runat="server" ID="cmbType" Style="width: 140px">
                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                <asp:ListItem Value="1">Fabric Store</asp:ListItem>
                                                                <asp:ListItem Value="2">Accessories Store</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div style="margin-left: 46PX; margin-top: -38px;">
                                                            <asp:Label ID="Label13" runat="server" Style="font-family: Century Gothic; font-size: 16px;
                                                                color: Black;" Text="Season:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <div style="margin-top: -38px; margin-left: 7px;">
                                                            <asp:DropDownList ID="cmbSeason" runat="server" Width="120" AutoPostBack="true">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div style="margin-left: 48PX; margin-top: 0px;">
                                                            <asp:Label ID="Label1" runat="server" Style="font-family: Century Gothic; font-size: 16px;
                                                                color: Black;" Text="Sr No:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <div style="margin-top: 0px; margin-left: 7px;">
                                                            <telerik:RadComboBox ID="cmbSrNo" runat="server" CheckBoxes="True" Width="140" Skin="WebBlue">
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
                                                                Transitions="true" Skin="MetroTouch" Style="font-family: Calibri; position: relative;
                                                                border: 1px solid rgb(177, 177, 177); border-radius: 0px 0px 5px 5px; background: linear-gradient(rgb(232, 232, 232), rgb(255, 255, 255));">
                                                                <Legend>
                                                                    <Appearance Position="right">
                                                                        <TextStyle FontSize="10" Color="black" FontFamily="Courier New, sans-serif" />
                                                                    </Appearance>
                                                                </Legend>
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
                                RegisterWithScriptManager="True" EnableShadow="True" ReloadOnShow="true" Height="750px"
                                Width="955px" runat="server">
                                <Windows>
                                    <telerik:RadWindow ID="rwPurchasingDetail" Title="" runat="server" Modal="True" Behaviors="Move">
                                        <ContentTemplate>
                                            <table>
                                            </table>
                                            <br />
                                            <table width="100%">
                                                <tr>
                                                    <td align="left">
                                                        <div style="margin-left: 121px;">
                                                            <asp:Label ID="Label2" Style="margin-left: 275px;" runat="server" CssClass="ErrorMsg"
                                                                Visible="true"></asp:Label></div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table style="margin: 0 0 40px 10px;">
                                                <tr>
                                                    <td>
                                                        <div style="margin-left: 33px;">
                                                            <asp:Label ID="Label3" runat="server" Style="font-family: Garamond; font-size: 36PX;
                                                                color: Silver;" Text="Purchasing Detail"></asp:Label>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table>
                                                <tr>
                                                    <td>
                                                        <div style="margin-left: 46PX; margin-top: -38px;">
                                                            <asp:Label ID="Label4" runat="server" Style="font-family: Century Gothic; font-size: 16px;
                                                                color: Black;" Text="Customer:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <div style="margin-top: -38px; margin-left: 7px;">
                                                            <asp:DropDownList ID="cmbCustomerPurchasingDetail" runat="server" Width="120" AutoPostBack="true">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div style="margin-left: 48PX; margin-top: -38px;">
                                                            <asp:Label ID="Label8" runat="server" Style="font-family: Century Gothic; font-size: 16px;
                                                                color: Black;" Text="Sr No:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <div style="margin-top: -38px; margin-left: 7px;">
                                                            <telerik:RadComboBox ID="cmbSrNo2" runat="server" CheckBoxes="True" Width="140" Skin="WebBlue">
                                                            </telerik:RadComboBox>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <div style="margin-left: 46PX; margin-top: 0px;">
                                                            <asp:Label ID="Label16" runat="server" Style="font-family: Century Gothic; font-size: 16px;
                                                                color: Black;" Text="From:"></asp:Label>
                                                    </td>
                                                    <td valign="top">
                                                        <div style="margin-left: 44px;">
                                                            <telerik:RadDatePicker ID="txtDateFrom" runat="server" Culture="en-US">
                                                                <Calendar ID="Calendar3" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                                                                    runat="server">
                                                                </Calendar>
                                                                <DateInput ID="DateInput3" DisplayDateFormat="MM/dd/yyyy" DateFormat="MM/dd/yyyy"
                                                                    LabelWidth="40%" runat="server">
                                                                </DateInput>
                                                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                                            </telerik:RadDatePicker>
                                                        </div>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <div style="margin-left: 5PX; margin-top: 0px;">
                                                            <asp:Label ID="Label17" runat="server" Style="font-family: Century Gothic; font-size: 16px;
                                                                color: Black;" Text="To :"></asp:Label>
                                                    </td>
                                                    <td valign="top">
                                                        <div style="margin-left: 23px;">
                                                            <telerik:RadDatePicker ID="txtDateTo" runat="server" Culture="en-US">
                                                                <Calendar ID="Calendar4" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                                                                    runat="server">
                                                                </Calendar>
                                                                <DateInput ID="DateInput4" DisplayDateFormat="MM/dd/yyyy" DateFormat="MM/dd/yyyy"
                                                                    LabelWidth="40%" runat="server">
                                                                </DateInput>
                                                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                                            </telerik:RadDatePicker>
                                                        </div>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table>
                                                <tr>
                                                    <td align="center">
                                                        <div style="margin: 05px; margin-left: 814px;">
                                                            <telerik:RadButton ID="btnPurchasingDetailView" runat="server" CssClass="buttonTelerik2"
                                                                Text="View Chart" Skin="Glow">
                                                            </telerik:RadButton>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table>
                                                <tr>
                                                    <td>
                                                        <div style="overflow: scroll; height: 430px; width: 885px; margin-left: 13px;">
                                                            <Smart:SmartDataGrid ID="dgPartialGridView" runat="server" AllowPaging="false" AllowSorting="false"
                                                                Width="100%" AutoGenerateColumns="False" CellPadding="4" CssClass="table" PageSize="6"
                                                                ShowFooter="false" ForeColor="white" Visible="true" GridLines="both">
                                                                <Columns>
                                                                    <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD"
                                                                        HeaderStyle-ForeColor="Black" HeaderText="Item Name" DataField="ItemName">
                                                                        <HeaderStyle HorizontalAlign="center" Width="20%" />
                                                                    </asp:BoundColumn>
                                                                    <asp:BoundColumn ItemStyle-HorizontalAlign="center" DataFormatString="{0:#,##,###,0}"
                                                                        HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor="Black" HeaderText="PO Amount"
                                                                        DataField="POAmount">
                                                                        <HeaderStyle HorizontalAlign="center" Width="8%" />
                                                                    </asp:BoundColumn>
                                                                    <asp:BoundColumn ItemStyle-HorizontalAlign="center" DataFormatString="{0:#,##,###,0}"
                                                                        HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor="Black" HeaderText="Receive Amount"
                                                                        DataField="ReceiveAmount">
                                                                        <HeaderStyle HorizontalAlign="center" Width="8%" />
                                                                    </asp:BoundColumn>
                                                                    <asp:BoundColumn ItemStyle-HorizontalAlign="center" DataFormatString="{0:#,##,###,0}"
                                                                        HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor="Black" HeaderText="Issue Amount"
                                                                        DataField="IssueAmount">
                                                                        <HeaderStyle HorizontalAlign="center" Width="8%" />
                                                                    </asp:BoundColumn>
                                                                </Columns>
                                                            </Smart:SmartDataGrid>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <div style="margin-left: 449px;">
                                                            <asp:Label ID="lblPOAmount" runat="server" Font-Bold="true" Style="color: Red; font-size: small;"></asp:Label>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div style="margin-left: 110px;">
                                                            <asp:Label ID="lblRecvAmount" runat="server" Font-Bold="true" Style="color: Red;
                                                                font-size: small;"></asp:Label>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div style="margin-left: 92px;">
                                                            <asp:Label ID="lblIssueAmount" runat="server" Font-Bold="true" Style="color: Red;
                                                                font-size: small;"></asp:Label>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table>
                                                <tr>
                                                    <td align="center">
                                                        <div style="margin: 15px; margin-left: 834px;">
                                                            <telerik:RadButton ID="btnPurchasingDetail" runat="server" CssClass="buttonTelerik2"
                                                                Text=" Close " Skin="Glow">
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
                                RegisterWithScriptManager="True" EnableShadow="True" ReloadOnShow="true" Height="740px"
                                Width="955px" runat="server">
                                <Windows>
                                    <telerik:RadWindow ID="rwPurchasingSummary" Title="" runat="server" Modal="True"
                                        Behaviors="Move">
                                        <ContentTemplate>
                                            <table>
                                            </table>
                                            <br />
                                            <table width="100%">
                                                <tr>
                                                    <td align="left">
                                                        <div style="margin-left: 121px;">
                                                            <asp:Label ID="Label5" Style="margin-left: 275px;" runat="server" CssClass="ErrorMsg"
                                                                Visible="true"></asp:Label></div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table style="margin: 0 0 40px 10px;">
                                                <tr>
                                                    <td>
                                                        <div style="margin-left: 33px;">
                                                            <asp:Label ID="Label7" runat="server" Style="font-family: Garamond; font-size: 36PX;
                                                                color: Silver;" Text="Purchasing Summary"></asp:Label>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table>
                                                <tr>
                                                    <td>
                                                        <div style="margin-left: 46PX; margin-top: -38px;">
                                                            <asp:Label ID="Label11" runat="server" Style="font-family: Century Gothic; font-size: 16px;
                                                                color: Black;" Text="Store Type:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <div style="margin-top: -38px; margin-left: 7px;">
                                                            <asp:DropDownList ID="cmbStoreType" runat="server" Width="140" AutoPostBack="false">
                                                                <asp:ListItem Value="0">All</asp:ListItem>
                                                                <asp:ListItem Value="1">Fabric Store</asp:ListItem>
                                                                <asp:ListItem Value="2">Accessories Store</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div style="margin-left: 48PX; margin-top: -38px;">
                                                            <asp:Label ID="Label14" runat="server" Style="font-family: Century Gothic; font-size: 16px;
                                                                color: Black;" Text="Year:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <div style="margin-top: -38px; margin-left: 7px;">
                                                            <asp:DropDownList runat="server" ID="cmbYear" AutoPostBack="false" Style="width: 140px">
                                                                <asp:ListItem Value="0">All</asp:ListItem>
                                                                <asp:ListItem Value="2016">2016</asp:ListItem>
                                                                <asp:ListItem Value="2017">2017</asp:ListItem>
                                                                <asp:ListItem Value="2018">2018</asp:ListItem>
                                                                <asp:ListItem Value="2019">2019</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div style="margin-left: 48PX; margin-top: -38px;">
                                                            <asp:Label ID="Label15" runat="server" Style="font-family: Century Gothic; font-size: 16px;
                                                                color: Black;" Text="Month:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <div style="margin-top: -38px; margin-left: 7px;">
                                                            <asp:DropDownList runat="server" ID="cmbMonth" AutoPostBack="false" Style="width: 140px">
                                                                <asp:ListItem Value="0">All</asp:ListItem>
                                                                <asp:ListItem Value="1">JAN</asp:ListItem>
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
                                                        <div style="margin: 05px; margin-left: 814px;">
                                                            <telerik:RadButton ID="btnViewChartPurchaseSummary" runat="server" CssClass="buttonTelerik2"
                                                                Text="View Chart" Skin="Glow">
                                                            </telerik:RadButton>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table>
                                                <tr>
                                                    <td>
                                                        <div style="overflow: scroll; height: 430px; width: 885px; margin-left: 13px;">
                                                            <Smart:SmartDataGrid ID="dgPurchasingDetail" runat="server" AllowPaging="false" AllowSorting="false"
                                                                Width="100%" AutoGenerateColumns="False" CellPadding="4" CssClass="table" PageSize="6"
                                                                ShowFooter="false" ForeColor="white" Visible="true" GridLines="both">
                                                                <Columns>
                                                                    <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD"
                                                                        HeaderStyle-ForeColor="Black" HeaderText="Supplier" DataField="SupplierName">
                                                                        <HeaderStyle HorizontalAlign="center" Width="20%" />
                                                                    </asp:BoundColumn>
                                                                    <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD"
                                                                        HeaderStyle-ForeColor="Black" HeaderText="Qauntity" DataField="Qauntity">
                                                                        <HeaderStyle HorizontalAlign="center" Width="8%" />
                                                                    </asp:BoundColumn>
                                                                    <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD"
                                                                        HeaderStyle-ForeColor="Black" HeaderText="Amount" DataField="Amount">
                                                                        <HeaderStyle HorizontalAlign="center" Width="8%" />
                                                                    </asp:BoundColumn>
                                                                </Columns>
                                                            </Smart:SmartDataGrid>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <div style="margin-left: 556px;">
                                                            <asp:Label ID="lblQty" runat="server" Font-Bold="true" Style="color: Red; font-size: small;"></asp:Label>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div style="margin-left: 147px;">
                                                            <asp:Label ID="lblAmount" runat="server" Font-Bold="true" Style="color: Red; font-size: small;"></asp:Label>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table>
                                                <tr>
                                                    <td align="center">
                                                        <div style="margin: 15px; margin-left: 834px;">
                                                            <telerik:RadButton ID="btnCancelPurchaseSummary" runat="server" CssClass="buttonTelerik2"
                                                                Text=" Close " Skin="Glow">
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
                <asp:Label ID="lblUserId" runat="server" Visible="false"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
