<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeBehind="CustomerProfile.aspx.vb" Inherits="Integra.CustomerProfile" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">

        function ClearRadControls() {
            var radControl1TextBox = document.getElementById("=txtBuyingDept.ClientID " + "_text");
            var RadTextBox1 = document.getElementById("=txtBuyerName.ClientID  " + "_text");
            var RadTextBox2 = document.getElementById("=txtDesignation.ClientID  " + "_text");
            var RadTextBox3 = document.getElementById("=txtCellNo.ClientID  " + "_text");
            var RadTextBox4 = document.getElementById("=txtEmail.ClientID  " + "_text");
            radControl1TextBox.value = "";
            RadTextBox1.value = "";
            RadTextBox2.value = "";
            RadTextBox3.value = "";
            RadTextBox4.value = "";
        }
 
    </script>
    <div>
        <table width="100%">
            <tr>
                <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                    font-size: 20px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                    bgcolor="Silver">
                    Customer Information
                </th>
            </tr>
            <tr>
                <td style="width: 128px; height: 30px;">
                    <asp:Label ID="lblCustomerType" runat="server" Text="Customer Type"></asp:Label>
                </td>
                <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                    <telerik:RadComboBox ID="cmbCustomerType" runat="server" Skin="WebBlue">
                    </telerik:RadComboBox>
                </td>
                <td style="width: 85px; height: 30px;" align="left">
                    <asp:Label ID="lblCountry" runat="server" Text="Country"></asp:Label>
                </td>
                <td style="width: 165px; height: 30px;">
                    <telerik:RadComboBox ID="cmbCountry" runat="server" AutoPostBack="True" Skin="WebBlue">
                    </telerik:RadComboBox>
                </td>
                <td style="width: 87px; height: 30px;">
                    <asp:Label ID="lblGeoTerritory" runat="server" Text="Geographical Territory"></asp:Label>
                </td>
                <td style="height: 30px">
                    <telerik:RadComboBox ID="cmbGeoterritory" runat="server" Skin="WebBlue">
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td style="height: 30px; width: 87px;">
                    <asp:Label ID="lblParentGroup" runat="server" Text="Parent Group"></asp:Label>
                </td>
                <td style="height: 30px">
                    <telerik:RadComboBox ID="cmbParentGroup" runat="server" Skin="WebBlue">
                    </telerik:RadComboBox>
                </td>
                <td style="height: 30px; width: 85px;">
                    <asp:Label ID="lblCustomerName" runat="server" Text="Customer Name"></asp:Label>
                </td>
                <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                    <telerik:RadTextBox ID="txtShortName" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                    <asp:Label ID="Label4" runat="server" ForeColor="Red" Style="font-weight: bold;"
                        Text="*"></asp:Label>
                </td>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="lblShortName" runat="server" Text="Short Name"></asp:Label>
                </td>
                <td style="width: 166px; height: 30px;">
                    <telerik:RadTextBox ID="txtCustomerName" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                    <asp:Label ID="Label5" runat="server" ForeColor="Red" Style="font-weight: bold;"
                        Text="*"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="lblAddressLine1" runat="server" Text="Address Line 1"></asp:Label>
                </td>
                <td colspan="3">
                    <telerik:RadTextBox ID="txtAddress1" runat="server" Height="20px" Width="398px" Skin="WebBlue">
                    </telerik:RadTextBox>
                    <asp:Label ID="Label6" runat="server" ForeColor="Red" Style="font-weight: bold;"
                        Text="*"></asp:Label>
                </td>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="Label15" runat="server" Text="Extra QTy"></asp:Label>
                </td>
                <td style="width: 166px; height: 30px;">
                    <telerik:RadTextBox ID="txtExtraQty" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                    <asp:Label ID="lblExQTy" runat="server" ForeColor="Red" Style="font-weight: bold;"
                        Text="*"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="lblAddressLine2" runat="server" Text="Address Line 2"></asp:Label>
                </td>
                <td colspan="3">
                    <telerik:RadTextBox ID="txtAddress2" runat="server" Width="398px" Skin="WebBlue">
                    </telerik:RadTextBox>
                    <asp:Label ID="Label7" runat="server" ForeColor="Red" Style="font-weight: bold;"
                        Text="*"></asp:Label>
                </td>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="Label16" Visible ="false"  runat="server" Text="Buyer Ref No"></asp:Label>
                </td>
                <td style="width: 166px; height: 30px;">
                    <telerik:RadTextBox ID="txtBuyerReferenceNo" Visible ="false" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                    <asp:Label ID="Label17" runat="server" Visible ="false" ForeColor="Red" Style="font-weight: bold;"
                        Text="*"></asp:Label>
                </td>
            </tr>
            <tr runat="server" id="trCommission" visible="false">
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="Label3" runat="server" Text="Commission"></asp:Label>
                </td>
                <td style="height: 30px">
                   
                    <telerik:RadNumericTextBox MinValue="0" MaxValue="999999999" ID="txtCommission" runat="server"
                        NumberFormat-DecimalDigits="2">
                        <NumberFormat GroupSeparator="" DecimalDigits="2" />
                    </telerik:RadNumericTextBox>
                    <asp:Label ID="Label8" runat="server" ForeColor="Red" Style="font-weight: bold;"
                        Text="*"></asp:Label>
                </td>
                <td>
                </td>
                <td style="height: 30px">
                </td>
            </tr>
            <tr>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
                </td>
                <td style="height: 30px">
                    <telerik:RadTextBox ID="txtcity" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
                <td>
                    <asp:Label ID="lblWebAddress" runat="server" Text="Web Address"></asp:Label>
                </td>
                <td style="height: 30px">
                    <telerik:RadTextBox ID="txtWebsite" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="lblContactNo" runat="server" Text="Contact No."></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtContactNo" runat="server" Skin="Office2010Blue">
                    </telerik:RadTextBox>
                </td>
                <td style="width: 85px">
                    <asp:Label ID="lbFaxNo" runat="server" Text="Fax"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtFaxNo" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="Label18" runat="server" Text="ASSORTMENT"></asp:Label>
                </td>
                <td colspan="3">
                    <telerik:RadTextBox ID="txtASSORTMENT" runat="server" Style="text-transform: uppercase;"
                        Width="398px" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="Label19" runat="server" Text="NEGOTIATION"></asp:Label>
                </td>
                <td colspan="3">
                    <telerik:RadTextBox ID="txtNEGOTIATION" runat="server" Width="398px" Style="text-transform: uppercase;"
                        Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="Label20" runat="server" Text="PAYMENT TERMS"></asp:Label>
                </td>
                <td colspan="3">
                    <telerik:RadTextBox ID="txtPAYMENTTERMS" TextMode="MultiLine" Style="text-transform: uppercase;"
                        runat="server" Width="398px" Height="75px" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="Label21" runat="server" Text="REMARKS"></asp:Label>
                </td>
                <td colspan="3">
                    <telerik:RadTextBox ID="txtPAYMENTREMARKS" runat="server" Style="text-transform: uppercase;"
                        Width="398px" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td style="width: 110px;">
                    For account & risk
                </td>
                <td style="width: 110px;">
                    <telerik:RadTextBox ID="txtForaccountAndRisk" runat="server" Skin="WebBlue" Width="245px"
                        Visible="true" ReadOnly="false" Style="text-transform: uppercase; margin-left: 31px;"
                        TextMode="MultiLine">
                    </telerik:RadTextBox>
                </td>
                <td style="width: 110px;">
                </td>
                <td style="width: 110px;">
                    Notify party
                </td>
                <td style="width: 110px;">
                    <telerik:RadTextBox ID="txtNotifyparty" runat="server" Skin="WebBlue" Width="245px"
                        Visible="true" ReadOnly="false" Style="text-transform: uppercase; margin-top: 7px;"
                        TextMode="MultiLine">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 110px;">
                    Payment To
                </td>
                <td style="width: 110px;">
                    <telerik:RadTextBox ID="txtPaymentTo" runat="server" Skin="WebBlue" Width="245px"
                        Visible="true" ReadOnly="false" Style="text-transform: uppercase; margin-top: 7px;
                        margin-left: 31px;" TextMode="MultiLine">
                    </telerik:RadTextBox>
                </td>
                <td style="width: 110px;">
                </td>
                <td style="width: 110px;">
                    Consignee
                </td>
                <td style="width: 110px;">
                    <telerik:RadTextBox ID="txtConsignee" runat="server" Skin="WebBlue" Width="245px"
                        Visible="true" ReadOnly="false" Style="text-transform: uppercase; margin-top: 9px;"
                        TextMode="MultiLine">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr style="height: 34PX;">
                <td style="width: 110px;">
                    Brand and section
                </td>
                <td style="width: 110px;">
                    <telerik:RadTextBox ID="txtBrandandsection" runat="server" Skin="WebBlue" Width="160px"
                        Visible="true" ReadOnly="false" Style="text-transform: uppercase; margin-left: 31px;">
                    </telerik:RadTextBox>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="Label22" runat="server" Text="Payment Term."></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtPaymentTerm" runat="server" Skin="WebBlue">
                        <ClientEvents OnButtonClick="ClearRadControls" />
                    </telerik:RadTextBox>
                </td>
                <td>
                    <asp:Label ID="Label24" runat="server" Text="Port Of Loading"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtPortOfLoading" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="Label26" runat="server" Text="Final Destination"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtFinalDestination" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                    <asp:Label ID="Label27" runat="server" ForeColor="Red" Style="font-weight: bold;"
                        Text="*"></asp:Label>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                    font-size: 20px; font-weight: bold; font-style: inherit; color: #336699;" bgcolor="Silver">
                    Industry Type
                </th>
            </tr>
            <tr>
                <td style="height: 25px" colspan="6">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:CheckBox ID="ChkRetail" runat="server" Font-Bold="True" Text="Retail" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:CheckBox ID="ChkWholeSale" runat="server" Font-Bold="True" Text="Wholesale" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:CheckBox ID="ChkWareHouse" runat="server" Font-Bold="True" Text="Warehouse" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:CheckBox ID="ChkImporter" runat="server" Font-Bold="True" Text="Importer" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:CheckBox ID="chkMailOrder" runat="server" Font-Bold="True" Text=" Mail Order" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:CheckBox ID="chkCatalog" runat="server" Font-Bold="True" Text="Catalog" />
                </td>
            </tr>
            <tr>
                <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                    font-size: 20px; font-weight: bold; font-style: inherit; color: #336699;" bgcolor="Silver">
                    Buyer Information
                </th>
            </tr>
            <tr>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="lblBuyingDept" runat="server" Text="Buying Dept."></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtBuyingDept" runat="server" Skin="WebBlue">
                        <ClientEvents OnButtonClick="ClearRadControls" />
                    </telerik:RadTextBox>
                    <asp:Label ID="Label9" Visible ="false"  runat="server" ForeColor="Red" Style="font-weight: bold;"
                        Text="*"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblBuyerName" runat="server" Text="Buyer Name"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtBuyerName" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                    <%--<asp:Label ID="Label10" runat="server" ForeColor="Red" Style="font-weight: bold;"
                        Text="*"></asp:Label>--%>
                </td>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="lblBrand" runat="server" Text="Brand Name"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtBrandName" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                    <asp:Label ID="Label11" Visible ="false" runat="server" ForeColor="Red" Style="font-weight: bold;"
                        Text="*"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="lblDesignation" runat="server" Text="Designation"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtDesignation" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                    <asp:Label ID="LBL" Visible ="false" runat="server" ForeColor="Red" Style="font-weight: bold;" Text="*"></asp:Label>
                </td>
                <td style="width: 85px">
                    <asp:Label ID="lblCellNo" runat="server" Text="Cell No"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtCellNo" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                    <asp:Label ID="Label12" Visible ="false" runat="server" ForeColor="Red" Style="font-weight: bold;"
                        Text="*"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtEmail" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                    <asp:Label ID="Label13" Visible ="false" runat="server" ForeColor="Red" Style="font-weight: bold;"
                        Text="*"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Fax No"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtFaxNumber" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                    <asp:Label ID="Label14" Visible ="false" runat="server" ForeColor="Red" Style="font-weight: bold;"
                        Text="*"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    <telerik:RadButton ID="btnAddNew" runat="server" Text="Add More" Skin="WebBlue">
                    </telerik:RadButton>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <telerik:RadGrid ID="dgBuyerDetail" runat="server" CellSpacing="0" AutoGenerateColumns="false"
                        Skin="WebBlue" Visible="False" PageSize="50">
                        <MasterTableView>
                            <Columns>
                                <telerik:GridBoundColumn HeaderText="CustomerDetailID" DataField="CustomerDetailID"
                                    Display="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Buying Dept." DataField="DepartmentNo">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Buyer Name" DataField="Buyer_Name">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Brand Name" DataField="BrandName">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Designation" DataField="Designation">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Cell No" DataField="CellNo">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Email" DataField="Email">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Fax No" DataField="FaxNumber">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Contact_Type_ID" DataField="Contact_Type_ID"
                                    Display="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn UniqueName="DeleteColumn" Text="" CommandName="Delete"
                                    ConfirmTextFormatString="Are You Sure You want to Delete Record" HeaderStyle-Width="35px"
                                    ButtonType="ImageButton">
                                </telerik:GridButtonColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </td>
            </tr>
            <tr>
                <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                    font-size: 20px; font-weight: bold; font-style: inherit; color: #336699;" bgcolor="Silver">
                    Logistic Handling
                </th>
            </tr>
            <tr style="height: 35px;">
                <td>
                    Local Agent:
                </td>
                <td>
                    <telerik:RadTextBox ID="txtAgent" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
                <td>
                    Contact :
                </td>
                <td>
                    <telerik:RadTextBox ID="txtLogisticHandlingContact" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
                <td>
                    Address :
                </td>
                <td>
                    <telerik:RadTextBox ID="txtDescription" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr style="height: 35px;">
                <td>
                    Int. Agent:
                </td>
                <td>
                    <telerik:RadTextBox ID="txtIntAgent" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
                <td>
                    Contact :
                </td>
                <td>
                    <telerik:RadTextBox ID="txtIntContact" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
                <td>
                    Address :
                </td>
                <td>
                    <telerik:RadTextBox ID="txtIntAddress" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                    font-size: 20px; font-weight: bold; font-style: inherit; color: #336699;" bgcolor="Silver">
                    Financial Handling
                </th>
            </tr>
            <tr>
                <td>
                    Buyer's Bank Name:
                </td>
                <td>
                    <telerik:RadTextBox ID="txtBuyerBankName" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
                <td>
                    Address :
                </td>
                <td>
                    <telerik:RadTextBox ID="txtFinancialHandlingAddress" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
                <td>
                    Swift Code :
                </td>
                <td>
                    <telerik:RadTextBox ID="txtSwiftCodeIBAN" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr style="height: 15px;">
                <td>
                </td>
            </tr>
            <tr>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="Label2" runat="server" Text="Remarks:"></asp:Label>
                </td>
                <td colspan="3">
                    <telerik:RadTextBox ID="RadtxtRemarks" runat="server" Height="20px" Width="398px"
                        Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Bank Account N0:
                </td>
                <td>
                    <telerik:RadTextBox ID="TXTbANKaCCOUNTnO" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
                <td>
                    IBAN NO :
                </td>
                <td>
                    <telerik:RadTextBox ID="TXTIBANno" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 30px; width: 128px;">
                    &nbsp;
                </td>
                <td>
                    <asp:CheckBox ID="ChkIsActive" runat="server" Font-Bold="True" Text="Is Active" />
                </td>
                <td>
                </td>
                <td colspan="2" align="right">
                    <telerik:RadButton ID="btnSave" runat="server" Text="Save" Skin="WebBlue">
                    </telerik:RadButton>
                </td>
                <td>
                    &nbsp;
                    <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" Skin="WebBlue">
                    </telerik:RadButton>
                    &nbsp;
                </td>
            </tr>
           
        </table>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="cmbCountry">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="cmbCity" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
            
        </telerik:RadAjaxManager>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" />
    </div>
</asp:Content>
