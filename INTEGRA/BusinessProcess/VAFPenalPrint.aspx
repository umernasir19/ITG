<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="VAFPenalPrint.aspx.vb" Inherits="Integra.VAFPenalPrint" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Vaf Panel Print</title>
    <link type="text/css" rel="stylesheet" href="../App_Themes/Blue/NewCSS/NewStyle.css" />
    <link type="text/css" rel="stylesheet" href="../App_Themes/Blue/StyleSheet.css" />
    <link href="../StyleSheet/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="JavaScript" src="../scripts/pupdate.js"></script>
    <link rel="stylesheet" href="../scripts/ThickBox.css" type="text/css" media="screen" />
    <link type="text/css" rel="stylesheet" href="../App_Themes/Blue/MenuCSS.css" />
    <link type="text/css" rel="stylesheet" href="../StyleSheet/NewLayout.css" />
    <link type="text/css" rel="stylesheet" href="../css/VAF.css" />
    <link type="text/css" rel="stylesheet" href="../css/buttons.css" />
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
    <script type="text/javascript">


        function Print() {
            //var btn=document.getElementById('Print1').id
            //btn.style.Display="none";

            document.getElementById("Print1").style.visibility = "hidden";
            window.print();
            alert('btn')
        }


    </script>
</head>
<body style="background-color: White;">
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager2" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All"
        EnableRoundedCorners="False"></telerik:RadFormDecorator>
    <telerik:RadToolTipManager runat="server" ID="ToolTipManager" AutoTooltipify="true"
        Position="TopRight">
    </telerik:RadToolTipManager>
    <div style="text-align: right;">
        <input id="Print1" type="button" value=" Print this page " cssclass="btn btn-outline btn-success"
            onclick="Print();" />
    </div>
    <table width="100%">
        <tr class="headingReport">
            <td>
                &nbsp;Basic Information
            </td>
        </tr>
        <tr style="height: 15px;">
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr style="height: 35px;">
            <td>
                <div class="txt_newwww" style="width: 140px;">
                    Company
                </div>
            </td>
            <td>
                <asp:DropDownList CssClass="combo" Style="margin-left: 13px;" readonly="true" ID="cmbSupplier"
                    Width="160" runat="server" AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                <div class="txt_newwww" style="width: 140px;">
                    Year Established
                </div>
            </td>
            <td>
                <asp:DropDownList CssClass="combo" Style="margin-left: 13px;" readonly="true" ID="cmbYearEstablished"
                Width="160" AutoPostBack="true" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                <div class="txt_newwww" style="margin-left: 17px;">
                    Code
                </div>
            </td>
            <td class="text_box" style="height: 22px; margin-top: 4px;">
                <asp:TextBox ID="txtCode" Style="height: 21px; border: 1px solid #1e4463; margin-left: 10px;"
                    ReadOnly="true" runat="server"></asp:TextBox>
            </td>
            <td colspan="3">
                <asp:Label ID="Label1" runat="server" Style="width: 140px; margin-left: 45px;" Text="(to be issued by ECP)"></asp:Label>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                <div class="txt_newwww" style="width: 140px;">
                    Corporate Address
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtCorporateAddress" Style="height: 21px; width: 713px; border: 1px solid #1e4463;
                        margin-left: 13px;" ReadOnly="true" runat="server"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                <div class="txt_newwww" style="width: 140px;">
                    Entity
                </div>
            </td>
            <td>
                <asp:UpdatePanel ID="UpCompany" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList CssClass="combo" Style="margin-left: 13px;" ID="cmbCompany" readonly="true"
                            AutoPostBack="true" Width="160" runat="server">
                            <asp:ListItem Value="0" Text="Private"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Limited"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Public"></asp:ListItem>
                            <asp:ListItem Value="3" Text="Other"></asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <div class="txt_newwww" style="margin-left: 15px;">
                    Product Line
                </div>
            </td>
            <td>
                <table>
                    <tr>
                        <td>
                            <telerik:RadComboBox ID="cmbBusiness" Style="width: 130px;" readonly="true" runat="server"
                                CheckBoxes="True" Skin="WebBlue">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <div class="txt_newwww" style="margin-left: 56px; width: 122px;">
                    Product Group
                </div>
            </td>
            <td>
                <telerik:RadComboBox ID="cmbProduct" Style="width: 130px;" runat="server" CheckBoxes="True"
                    Skin="WebBlue">
                </telerik:RadComboBox>
            </td>
        </tr>
    </table>
    <table>
        <tr style="height: 15px;">
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="headingReport">
                Primary Contacts
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr style="height: 10px;">
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdgPrimaryContact" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadGrid ID="dgPrimaryContact" runat="server" CellSpacing="0" AutoGenerateColumns="false"
                            Skin="WebBlue" Visible="False" PageSize="50">
                            <MasterTableView>
                                <Columns>
                                    <telerik:GridBoundColumn HeaderText="VAF_PrimaryContactID" DataField="VAF_PrimaryContactID">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Designation." DataField="Designation">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Name" DataField="Name">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Phone" DataField="Phone">
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Cell" DataField="Cell">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Email" DataField="Email">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridButtonColumn UniqueName="DeleteColumn" Text="" CommandName="Delete"
                                        ConfirmTextFormatString="Are You Sure You want to Delete Record" HeaderStyle-Width="2%"
                                        Display="false" ButtonType="ImageButton">
                                    </telerik:GridButtonColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr style="height: 15px;">
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="headingReport">
                HR Detail
            </td>
        </tr>
    </table>
    <table>
        <tr style="height: 35px;">
            <td>
                <div class="txt_newwww" style="width: 140px;">
                    Total Worker
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtTotalWorker" Style="height: 21px; margin-left: 15px; border: 1px solid #1e4463;"
                        onkeypress="return isNumericKeyy(event);" runat="server" ReadOnly="true"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="txt_newwww" style="margin-left: 151px;">
                    Female Staff
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtFemale" ReadOnly="true" Style="height: 21px; margin-left: 15px;
                        border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);" runat="server"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="txt_newwww" style="margin-left: 150px;">
                    Male Staff
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtMale" ReadOnly="true" Style="height: 21px; margin-left: 15px;
                        border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);" Width="60px"
                        runat="server"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                <div class="txt_newwww" style="width: 140px;">
                    Permanent Staff
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtPermanent" ReadOnly="true" Style="height: 21px; margin-left: 15px;
                        border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);" runat="server"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="txt_newwww" style="margin-left: 151px;">
                    No. of Shifts
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtNoofShifts" ReadOnly="true" Style="height: 21px; margin-left: 15px;
                        border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);" runat="server"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="txt_newwww" style="margin-left: 150px;">
                    Timing
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtTiming" ReadOnly="true" Style="height: 21px; margin-left: 15px;
                        margin-top: 8px; border: 1px solid #1e4463;" Width="60" runat="server"></asp:TextBox>
                </div>
            </td>
        </tr>
    </table>
    <table>
        <tr style="height: 15px;">
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="headingReport">
                HR Breakdown
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr style="height: 10px;">
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdgHRBreakdown" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadGrid ID="dgHRBreakdown" runat="server" CellSpacing="0" AutoGenerateColumns="false"
                            Skin="WebBlue" Visible="False" PageSize="50">
                            <MasterTableView>
                                <Columns>
                                    <telerik:GridBoundColumn HeaderText="VAF_HRBreakdownID" DataField="VAF_HRBreakdownID">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="DeptID" DataField="DeptID">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Department" DataField="Department">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Total No. of Employee" DataField="No">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridButtonColumn UniqueName="DeleteColumn" Text="" CommandName="Delete"
                                        ConfirmTextFormatString="Are You Sure You want to Delete Record" HeaderStyle-Width="2%"
                                        Display="false" ButtonType="ImageButton">
                                    </telerik:GridButtonColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr style="height: 15px;">
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="headingReport">
                Capacities
            </td>
        </tr>
    </table>
    <table>
        <tr style="height: 35px;">
            <td>
                <div class="txt_newwww" style="width: 140px;">
                    Fabric Stock
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtFabricStock" ReadOnly="true" Style="height: 21px; margin-left: 15px;
                        border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);" Width="80"
                        runat="server"></asp:TextBox></div>
                <asp:DropDownList CssClass="combo" Style="margin-left: 55px;" ID="cmbFabricStockUnit"
                    Width="55" runat="server">
                    <asp:ListItem Value="0" Text="KG"></asp:ListItem>
                    <asp:ListItem Value="1" Text="MT"></asp:ListItem>
                    <asp:ListItem Value="2" Text="M"></asp:ListItem>
                    <asp:ListItem Value="3" Text="Nos"></asp:ListItem>
                    <asp:ListItem Value="4" Text="PCs"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <div class="txt_newwww" style="width: 155px; margin-left: 20px;">
                    Prod.Capacity/month
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtProdcapacitymonth" ReadOnly="true" Style="height: 21px; margin-left: 15px;
                        border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);" Width="80"
                        runat="server"></asp:TextBox></div>
                <asp:DropDownList CssClass="combo" Style="margin-left: 55px;" ID="cmbProdcapacitymonthUnit"
                    Width="55" runat="server">
                    <asp:ListItem Value="0" Text="KG"></asp:ListItem>
                    <asp:ListItem Value="1" Text="MT"></asp:ListItem>
                    <asp:ListItem Value="2" Text="M"></asp:ListItem>
                    <asp:ListItem Value="3" Text="Nos"></asp:ListItem>
                    <asp:ListItem Value="4" Text="PCs"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <div class="txt_newwww" style="width: 170px; margin-left: 15px;">
                    Cutting capacity/month
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtCuttingcapacitymonth" ReadOnly="true" Style="height: 21px; margin-left: 15px;
                        border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);" Width="55"
                        runat="server"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                <div class="txt_newwww" style="width: 140px;">
                    Washing Capacity
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtwashingcapacity" ReadOnly="true" Style="height: 21px; margin-left: 15px;
                        border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);" Width="80"
                        runat="server"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="txt_newwww" style="width: 155px; margin-left: 20px;">
                    No of lines
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtNooflines" ReadOnly="true" Style="height: 21px; margin-left: 15px;
                        border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);" Width="80"
                        runat="server"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="txt_newwww" style="width: 170px; margin-left: 15px;">
                    No of machine/line
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtNoofmachineline" ReadOnly="true" Style="height: 21px; margin-left: 15px;
                        border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);" Width="55"
                        runat="server"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                <div class="txt_newwww" style="width: 140px;">
                    SAM/SMV
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtSAMSMV" ReadOnly="true" Style="height: 21px; margin-left: 15px;
                        border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);" Width="80"
                        runat="server"></asp:TextBox>
                </div>
            </td>
        </tr>
    </table>
    <table>
        <tr style="height: 15px;">
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="headingReport">
                General Information
            </td>
        </tr>
        <tr style="height: 15px;">
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <table>
        <tr style="height: 35px;">
            <td>
                <div class="txt_newwww" style="width: 220px;">
                    Company coverd Area (sq. m)
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtCompanycoverdArea" ReadOnly="true" Style="height: 21px; margin-left: 15px;
                        border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);" Width="80"
                        runat="server"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="txt_newwww" style="width: 150px; margin-left: 70px;">
                    Factory Area (sq. m)
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtFactoryArea" ReadOnly="true" Style="height: 21px; margin-left: 15px;
                        border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);" Width="80"
                        runat="server"></asp:TextBox>
                </div>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr style="height: 15px;">
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="headingReport">
                Annual turnover last 3 years <span style="color: red;">in USD</span>
            </td>
        </tr>
        <tr style="height: 15px;">
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td colspan="6">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblYear1" Font-Underline="true" Style="margin-left: 1px;" Font-Bold="true"
                                runat="server"></asp:Label>
                        </td>
                        <td>
                            <div class="text_box">
                                <asp:TextBox ID="txtAnnualturnover1" ReadOnly="true" Style="height: 21px; margin-left: 14px;
                                    border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);" Width="80"
                                    runat="server"></asp:TextBox>
                            </div>
                        </td>
                        <td>
                            <asp:Label ID="lblYear2" Font-Bold="true" Style="margin-left: 63px;" Font-Underline="true"
                                runat="server"></asp:Label>
                        </td>
                        <td>
                            <div class="text_box">
                                <asp:TextBox ID="txtAnnualturnover2" ReadOnly="true" Style="height: 21px; margin-left: 10px;
                                    border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);" Width="80"
                                    runat="server"></asp:TextBox>
                            </div>
                        </td>
                        <td>
                            <asp:Label ID="lblYear3" Font-Bold="true" Style="margin-left: 58px;" Font-Underline="true"
                                runat="server"></asp:Label>
                        </td>
                        <td>
                            <div class="text_box">
                                <asp:TextBox ID="txtAnnualturnover3" ReadOnly="true" Style="height: 21px; margin-left: 10px;
                                    border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);" Width="80"
                                    runat="server"></asp:TextBox>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="height: 5px;">
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <div class="txt_newwww" style="width: 295px;">
                    Total Annual Shipments (volume) globally
                </div>
            </td>
            <td align="right">
                <div class="text_box">
                    <asp:TextBox ID="txtTotalAnnualShipmentsvolumeglobally" ReadOnly="true" Style="height: 21px;
                        margin-left: 15px; border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);"
                        Width="80" runat="server"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="txt_newwww" style="margin-left: 65px; width: 270px;">
                    Total Annual Shipments to the Europe
                </div>
            </td>
            <td align="right">
                <div class="text_box">
                    <asp:TextBox ID="txtTotalAnnualShipmentstothevolumeEurope" ReadOnly="true" Style="height: 21px;
                        margin-left: 15px; border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);"
                        Width="80" runat="server"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr style="height: 5px;">
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <b>Note: put figures in Pcs. </b>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr style="height: 15px;">
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="headingReport">
                Please list Top 5 Customers for last fiscal year based on turnover
            </td>
        </tr>
        <tr style="height: 15px;">
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr style="height: 10px;">
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdgTopCustomer" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadGrid ID="dgTopCustomer" runat="server" CellSpacing="0" AutoGenerateColumns="false"
                            Skin="WebBlue" Visible="False" PageSize="50">
                            <MasterTableView>
                                <Columns>
                                    <telerik:GridBoundColumn HeaderText="VAF_TopCustomerID" DataField="VAF_TopCustomerID">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Country_id" DataField="Country_id">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Name" DataField="CustomerName">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Country" DataField="CustomerCountry">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="% of Business" DataField="CustomerPercentOfBuss">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Product made for customer" DataField="CustomerProduct">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridButtonColumn UniqueName="DeleteColumn" Text="" CommandName="Delete"
                                        ConfirmTextFormatString="Are You Sure You want to Delete Record" HeaderStyle-Width="2%"
                                        Display="false" ButtonType="ImageButton">
                                    </telerik:GridButtonColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr style="height: 15px;">
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="headingReport">
                Do you have conceptual design staff?
            </td>
        </tr>
        <tr style="height: 15px;">
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <asp:DropDownList CssClass="combo" ID="cmbConceptualDesign" Width="50" runat="server">
                    <asp:ListItem Value="0" Text="No"></asp:ListItem>
                    <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td align="right">
                <div class="txt_newwww" style="margin-left: 15px;">
                    If yes, is it
                </div>
            </td>
            <td>
                <asp:CheckBox ID="chkInHouse" Text="In-House" Style="margin-left: -79px;" raedonly="false"
                    runat="server" />
            </td>
            <td>
                <asp:CheckBox ID="chkNumberOfInHouseDesigners" Style="margin-left: -173px;" raedonly="false"
                    Text="Number of in-house designers" runat="server" />
            </td>
            <td>
                <div class="txt_newwww" style="margin-left: -156px;">
                    Location:
                </div>
                <div class="text_box">
                    <asp:TextBox ID="txtInHouseLocation" ReadOnly="true" Style="height: 21px; margin-left: -29px;
                        border: 1px solid #1e4463;" Width="80" runat="server"></asp:TextBox></div>
            </td>
        </tr>
        <tr style="height: 4px;">
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:CheckBox ID="chkContracted" Text="Contracted" raedonly="false" Style="margin-left: 140px;"
                    runat="server" />
            </td>
            <td>
                <asp:CheckBox ID="chkNumberOfOutsideDesigners" raedonly="false" Style="margin-left: 18px;"
                    Text="Number of outside designers" runat="server" />
            </td>
            <td>
                <div class="txt_newwww" style="margin-left: 35px;">
                    Location:
                </div>
                <div class="text_box">
                    <asp:TextBox ID="txtContractedLocation" ReadOnly="true" Style="height: 21px; margin-left: 16px;
                        border: 1px solid #1e4463;" Width="80" runat="server"></asp:TextBox>
                </div>
            </td>
        </tr>
    </table>
    <table>
        <tr style="height: 15px;">
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="headingReport">
                Do you have sampling department
            </td>
        </tr>
        <tr style="height: 15px;">
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <asp:DropDownList CssClass="combo" ID="cmbSampling" Width="50" runat="server">
                    <asp:ListItem Value="0" Text="No"></asp:ListItem>
                    <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td align="right">
                <div class="txt_newwww" style="margin-left: 20px; width: 121px;">
                    No. of Machine
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtNoOfMachineSampling" ReadOnly="true" Style="height: 21px; margin-left: 15px;
                        border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);" Width="50"
                        runat="server"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="txt_newwww" style="margin-left: 42px; width: 134px;">
                    Capacity (pc/day)
                </div>
            </td>
            <td align="center">
                <div class="text_box">
                    <asp:TextBox ID="txtCapacitySampling" ReadOnly="true" Style="height: 21px; margin-left: 15px;
                        border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);" Width="80"
                        runat="server"></asp:TextBox>
                </div>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr style="height: 15px;">
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="headingReport">
                Product Development related information (pls. tick checkbox if you have)
            </td>
        </tr>
        <tr style="height: 15px;">
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td style=" width: 131px;">
                <div class="txt_newwww">
                    PD Info:
                </div>
            </td>
            <td>
                <telerik:RadComboBox ID="cmbPD" runat="server" Width="195" CheckBoxes="True" Skin="WebBlue">
                </telerik:RadComboBox>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr style="height: 15px;">
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="headingReport">
                Pre-Treatment Specialities
            </td>
        </tr>
        <tr style="height: 15px;">
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td align="right" style=" width: 131px;">
                <div class="txt_newwww">
                    Speciality
                </div>
                  </td>
                <td>
                    <telerik:RadComboBox ID="cmbPreTreatmentSpeciality" runat="server" Width="195" CheckBoxes="True"
                        Skin="WebBlue">
                    </telerik:RadComboBox>
                </td>
        </tr>
    </table>
    <table width="100%">
        <tr style="height: 15px;">
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="headingReport">
                Machine / technical
            </td>
        </tr>
        <tr style="height: 15px;">
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdgMachineTechnical" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadGrid ID="dgMachineTechnical" runat="server" CellSpacing="0" AutoGenerateColumns="false"
                            Skin="WebBlue" Visible="False" PageSize="50">
                            <MasterTableView>
                                <Columns>
                                    <telerik:GridBoundColumn HeaderText="VAF_MachineTechnicalID" DataField="VAF_MachineTechnicalID">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Machine" DataField="Machine">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Width (Cm)" DataField="WidthinCM">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Meter/day" DataField="MeterPerday">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Model" DataField="Model">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Year" DataField="Year">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Type" DataField="Type">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridButtonColumn UniqueName="DeleteColumn" Text="" CommandName="Delete"
                                        ConfirmTextFormatString="Are You Sure You want to Delete Record" HeaderStyle-Width="2%"
                                        Display="false" ButtonType="ImageButton">
                                    </telerik:GridButtonColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr style="height: 15px;">
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="headingReport">
                Dyeing Specialities
            </td>
        </tr>
        <tr style="height: 15px;">
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td align="right">
                <div class="txt_newwww" style="margin-right: 15px;">
                    Speciality
                </div>
            </td>
            <td>
                <table>
                    <tr>
                        <td>
                            <telerik:RadComboBox ID="cmbDyeingSpeciality" runat="server" CheckBoxes="True" Skin="WebBlue">
                            </telerik:RadComboBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr style="height: 15px;">
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="headingReport">
                Embellishment Specialities (Capacity Per Week)
            </td>
        </tr>
        <tr style="height: 15px;">
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr style="height: 10px;">
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdgEmbellishmentSpecialities" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadGrid ID="dgEmbellishmentSpecialities" runat="server" CellSpacing="0"
                            AutoGenerateColumns="false" Skin="WebBlue" Visible="False" PageSize="50">
                            <MasterTableView>
                                <Columns>
                                    <telerik:GridBoundColumn HeaderText="VAF_EmbellishmentSpecialitiesID" DataField="VAF_EmbellishmentSpecialitiesID">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Capabilities" DataField="Capabilities">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Volume" DataField="Volume">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Unit" DataField="Unit">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="No. of Mac." DataField="NoofMac">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridButtonColumn UniqueName="DeleteColumn" Text="" CommandName="Delete"
                                        ConfirmTextFormatString="Are You Sure You want to Delete Record" HeaderStyle-Width="2%"
                                        Display="false" ButtonType="ImageButton">
                                    </telerik:GridButtonColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr style="height: 15px;">
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="headingReport">
                Stitching Line Machine Strength
            </td>
        </tr>
        <tr style="height: 15px;">
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr style="height: 10px;">
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdgStitchingLineMachine" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadGrid ID="dgStitchingLineMachine" runat="server" CellSpacing="0" AutoGenerateColumns="false"
                            Skin="WebBlue" Visible="False" PageSize="50">
                            <MasterTableView>
                                <Columns>
                                    <telerik:GridBoundColumn HeaderText="VAF_StitchingLineMachineID" DataField="VAF_StitchingLineMachineID">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Machine" DataField="Machine">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Total Machine" DataField="MachineTotal">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridButtonColumn UniqueName="DeleteColumn" Text="" CommandName="Delete"
                                        ConfirmTextFormatString="Are You Sure You want to Delete Record" HeaderStyle-Width="2%"
                                        Display="false" ButtonType="ImageButton">
                                    </telerik:GridButtonColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            function itemOpened(s, e) {
                if ($telerik.isIE8) {
                    // Fix an IE 8 bug that causes the list bullets to disappear (standards mode only)
                    $telerik.$("li", e.get_item().get_element())
                        .each(function () { this.style.cssText = this.style.cssText; });
                }
            }
        </script>
    </telerik:RadScriptBlock>
    </form>
</body>
<script type="text/javascript" language="JavaScript" src="JavaScript/writing.js"></script>
</html>
