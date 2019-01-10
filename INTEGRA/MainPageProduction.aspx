<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="MainPageProduction.aspx.vb" Inherits="Integra.MainPageProduction" %>
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
                                        Production Status <a href="#" class="topbar-item-new ion-android-settings"></a>
                                        <asp:ImageButton ID="btnPurchasingSummary" Style="margin-left: 291px; margin-top: -15px;
                                            width: 16px;" ToolTip="Click here to View Chart" ImageUrl="~/Images/iconnnn.png"
                                            runat="server"></asp:ImageButton>
                                    </div>
                                                    <div style="overflow: scroll; height: 214px; width: 322PX; margin-top: -5px;">
                                                <Smart:SmartDataGrid ID="dgView2" runat="server" AllowPaging="false" AllowSorting="false"
                                                    Width="100%" AutoGenerateColumns="False" CellPadding="4" CssClass="table" PageSize="6"
                                                    ShowFooter="false" ForeColor="white" Visible="true" GridLines="both">
                                                    <Columns>
                                                   
                                                        <asp:BoundColumn ItemStyle-HorizontalAlign="left" HeaderStyle-BackColor="#c3a4e5"
                                                            ItemStyle-Font-Names="century gothic" ItemStyle-BackColor="#70f6f6" HeaderStyle-ForeColor="Black"
                                                            ItemStyle-Font-Size="10px" HeaderText="Sr No" DataField="SRNO">
                                                            <HeaderStyle HorizontalAlign="center" Width="10%" Font-Size="10px" Font-Names="century gothic" />
                                                        </asp:BoundColumn>
                                                         <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#c3a4e5"
                                                            ItemStyle-Font-Names="century gothic" ItemStyle-BackColor="#70f6f6" HeaderStyle-ForeColor="Black"
                                                            ItemStyle-Font-Size="10px" HeaderText="Booking" DataField="Booking">
                                                            <HeaderStyle HorizontalAlign="center" Width="4%" Font-Size="10px" Font-Names="century gothic" />
                                                        </asp:BoundColumn>
                                                             <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#c3a4e5"
                                                            ItemStyle-Font-Names="century gothic" ItemStyle-BackColor="#70f6f6" HeaderStyle-ForeColor="Black"
                                                            ItemStyle-Font-Size="10px" HeaderText="Offline" DataField="Offlinee">
                                                            <HeaderStyle HorizontalAlign="center" Width="4%" Font-Size="10px" Font-Names="century gothic" />
                                                        </asp:BoundColumn>
                                                       
                                                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#c3a4e5"
                                                            Visible="true" ItemStyle-Font-Names="century gothic" ItemStyle-BackColor="#70f6f6"
                                                            HeaderStyle-ForeColor="Black" ItemStyle-Font-Size="10px" HeaderText="Washing"
                                                            DataField="Washing">
                                                            <HeaderStyle HorizontalAlign="center" Width="4%" Font-Size="10px" Font-Names="century gothic" />
                                                        </asp:BoundColumn>
                                                          <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#c3a4e5"
                                                            Visible="true" ItemStyle-Font-Names="century gothic" ItemStyle-BackColor="#70f6f6"
                                                            HeaderStyle-ForeColor="Black" ItemStyle-Font-Size="10px" HeaderText="Finishing"
                                                            DataField="Finishing">
                                                            <HeaderStyle HorizontalAlign="center" Width="4%" Font-Size="10px" Font-Names="century gothic" />
                                                        </asp:BoundColumn>
                                                     
                                                    </Columns>
                                                </Smart:SmartDataGrid>
                                            </div>
                                </td>
                                <td>
                                    <div style="margin-left: 33px; margin-top: -11px;">
                                        <div style="width: 310px; font-family: Calibri; /* background-color: Silver; */
    border: 1px solid #9f9f9f; font-weight: bold; color: #3e3e3e; text-align: left; padding-top: 8px; padding: 8px 0 10px 10px;
                                            margin-bottom: 0px; border-radius: 5px 5px 0 0px; background: linear-gradient(#e2e2e2, #fff);
                                            font-size: 13px;">
                                             <a href="#" class="topbar-item-new ion-android-settings"></a>
                                            <asp:ImageButton ID="BtnPartialCustomerChart" Style="margin-left: 291px; margin-top: -15px;
                                                width: 16px;" ToolTip="Click here to View Chart" ImageUrl="~/Images/iconnnn.png"
                                                runat="server"></asp:ImageButton>
                                        </div>
                                        <div style="margin-left: 0px;">



                                              <telerik:RadHtmlChart ID="Chart2" Height="203px" Width="320px" runat="server" Transitions="true"
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
                                                </div>
                                        </div>
                                        <div style="overflow: scroll; height: 214px; width: 322PX;">
                                            <Smart:SmartDataGrid ID="dgVieww" runat="server" AllowPaging="false" AllowSorting="false"
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
                                                        ItemStyle-Font-Names="century gothic" DataFormatString="{0:#,##,###,0}" ItemStyle-BackColor="#59cce0" HeaderStyle-ForeColor="Black"
                                                        ItemStyle-Font-Size="10px" HeaderText="PO ($)" DataField="POAmount">
                                                        <HeaderStyle HorizontalAlign="center" Width="8%" Font-Size="10px" Font-Names="century gothic" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn ItemStyle-HorizontalAlign="right" DataFormatString="{0:#,##,###,0}" HeaderStyle-BackColor="#128ca2"
                                                        ItemStyle-Font-Names="century gothic" ItemStyle-BackColor="#59cce0" HeaderStyle-ForeColor="Black"
                                                        ItemStyle-Font-Size="10px" HeaderText="Receive ($)" DataField="ReceiveAmount">
                                                        <HeaderStyle HorizontalAlign="center" Width="8%" Font-Size="10px" Font-Names="century gothic" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn ItemStyle-HorizontalAlign="right" DataFormatString="{0:#,##,###,0}" HeaderStyle-BackColor="#128ca2"
                                                        ItemStyle-Font-Names="century gothic" ItemStyle-BackColor="#59cce0" HeaderStyle-ForeColor="Black"
                                                        ItemStyle-Font-Size="10px" HeaderText="Issue ($)" DataField="IssueAmount">
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
                                                <a href="#" class="topbar-item-new ion-android-settings"></a>
                                            </div>
                                            <div style="overflow: scroll; height: 214px; width: 322PX;">
                                                <Smart:SmartDataGrid ID="dgVieww2" runat="server" AllowPaging="false" AllowSorting="false"
                                                    Width="100%" AutoGenerateColumns="False" CellPadding="4" CssClass="table" PageSize="6"
                                                    ShowFooter="false" ForeColor="white" Visible="true" GridLines="both">
                                                    <Columns>
                                                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" Visible="false" HeaderStyle-BackColor="#c3a4e5"
                                                            HeaderStyle-ForeColor="Black" HeaderText="SupplierDatabaseId" DataField="SupplierDatabaseId">
                                                            <HeaderStyle HorizontalAlign="center" Width="1%" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn ItemStyle-HorizontalAlign="left" HeaderStyle-BackColor="#c3a4e5"
                                                            ItemStyle-Font-Names="century gothic" ItemStyle-BackColor="#bcd7f0" HeaderStyle-ForeColor="Black"
                                                            ItemStyle-Font-Size="10px" HeaderText="Supplier" DataField="SupplierName">
                                                            <HeaderStyle HorizontalAlign="center" Width="20%" Font-Size="10px" Font-Names="century gothic" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn ItemStyle-HorizontalAlign="right" HeaderStyle-BackColor="#c3a4e5"
                                                            ItemStyle-Font-Names="century gothic" ItemStyle-BackColor="#bcd7f0" HeaderStyle-ForeColor="Black"
                                                            ItemStyle-Font-Size="10px" HeaderText="Purchase Value" DataField="PurchaseValue">
                                                            <HeaderStyle HorizontalAlign="center" Width="8%" Font-Size="10px" Font-Names="century gothic" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#c3a4e5"
                                                            Visible="false" ItemStyle-Font-Names="century gothic" ItemStyle-BackColor="#bcd7f0"
                                                            HeaderStyle-ForeColor="Black" ItemStyle-Font-Size="10px" HeaderText="Avg Delivery"
                                                            DataField="AvgDelivery">
                                                            <HeaderStyle HorizontalAlign="center" Width="8%" Font-Size="10px" Font-Names="century gothic" />
                                                        </asp:BoundColumn>
                                                        <asp:TemplateColumn HeaderText="Avg Delivery" HeaderStyle-Font-Size="10px" ItemStyle-Font-Names="century gothic"
                                                            HeaderStyle-BackColor="#c3a4e5" HeaderStyle-ForeColor="Black">
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
    <div style="margin-left: 13px; margin-top: 12px;">
        <table>
            <tr>
                <td>
                    <div style="width: 910px; margin-top: 20px; font-family: Calibri; /* background-color: Silver;
                        */
    border: 1px solid #9f9f9f; font-weight: bold; color: #3e3e3e; text-align: left; padding-top: 8px;
                        padding: 8px 0 10px 10px; margin-bottom: 5px; border-radius: 5px 5px 0 0px; background: linear-gradient(#e2e2e2, #fff);
                        font-size: 13px; margin-left: ;">
                        Date Wise Offline <a href="#" class="topbar-item-new ion-android-settings">
                        </a>
                       <div class="msg-area" style="margin-top: 0px;">
                           
                            <div class="msg-new-2" style="margin-left: 324px; margin-top: -12px;">
                                <div class="color-6">
                                </div>
                                DAL 1
                            </div>
                            <div class="msg-new-2" style="margin-left: 386px; margin-top: -12px;">
                                <div class="color-1">
                                </div>
                                DAL 2
                            </div>
                        </div>
                    </div>


                    <div id="Div1" style="margin-top: -6px; font-size: 10px; margin-left: 0px; overflow: scroll;
                        width: 922px;">
                        <telerik:RadHtmlChart ID="Chart3"  Height="300px"  runat="server"
                            Transitions="true" Skin="Office2010Blue" Style=" font-size: smaller;
                            font-family: Calibri; position: relative; border: 1px solid rgb(177, 177, 177);
                            border-radius: 0px 0px 5px 5px; background: linear-gradient(rgb(232, 232, 232), 
                                            rgb(255, 255, 255));">
                            <PlotArea>
                                <Series>
                                    <telerik:ColumnSeries DataFieldY="Value1">
                                        <TooltipsAppearance DataFormatString="#,###,##0" />
                                        <LabelsAppearance DataFormatString="#,###,##0" Visible="true" />
                                    </telerik:ColumnSeries>
                                    <telerik:ColumnSeries DataFieldY="Value2">
                                        <TooltipsAppearance DataFormatString="#,###,##0" />
                                        <LabelsAppearance DataFormatString="#,###,##0" Visible="true"  />
                                    </telerik:ColumnSeries>
                                    <telerik:ColumnSeries DataFieldY="Value3">
                                        <TooltipsAppearance DataFormatString="#,###,##0" />
                                        <LabelsAppearance DataFormatString="#,###,##0" Visible="true"   />
                                    </telerik:ColumnSeries>
                                </Series>

                                 <XAxis DataLabelsField="Date"   AxisCrossingValue="90" Color="Black"  MajorTickType="Outside" MinorTickType="Outside" Reversed="true" >
                                                               <LabelsAppearance DataFormatString="{0}"  RotationAngle="45" />
                                                             <%--  <MajorGridLines Color="#EFEFEF" Width="1" />
                                                               <MinorGridLines Color="Black" Width="1" />
                                                               <TitleAppearance Position="Center" RotationAngle="0"  Text="Date" />   --%>                                              
                                                        </XAxis>


                              <%--  <XAxis DataLabelsField="Date">
                                    <TitleAppearance Text="">
                                        <TextStyle Margin="10" />
                                    </TitleAppearance>
                                    <MajorGridLines Visible="false" />
                                    <MinorGridLines Visible="false" />
                                </XAxis>--%>
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
            </tr>
        </table>
    </div>
    <table>
        <tr>
            <td>
                <asp:Label ID="lblUserId" runat="server" Visible="false"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
