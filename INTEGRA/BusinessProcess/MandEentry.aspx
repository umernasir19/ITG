<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="MandEentry.aspx.vb" Inherits="Integra.MandEentry" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .tooltip
        {
            position: relative;
            display: inline-block;
            cursor: pointer;
            border-bottom: 1px dotted black;
        }
        .tooltip .tooltiptext
        {
            visibility: hidden;
            width: 180px;
            background-color: #555;
            color: #fff;
            text-align: left;
            padding: 10px 10px 10px 10px;
            border-radius: 6px;
            position: absolute;
            z-index: 1;
            bottom: 125%;
            left: -108%;
            margin-left: -60px;
            opacity: 0;
            transition: opacity 0.3s;
            z-index: 9000000000000;
        }
        
        .tooltip .tooltiptext::after
        {
            content: "";
            position: absolute;
            top: 100%;
            left: 50%;
            margin-left: -5px;
            border-width: 5px;
            border-style: solid;
            border-color: #555 transparent transparent transparent;
        }
        
        .tooltip:hover .tooltiptext
        {
            visibility: visible;
            opacity: 1;
        }
    </style>

        <table style="width: 930px;">
            <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
                visible="true">
                <th colspan="5" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                    color: #808080;">
                    Machine & Equipment (M&E) Input Interface
                </th>
            </tr>
        </table>
        <br />
        <table width="">
            <tr>
                <td style="height: 30px; width: 140px;">
             
                    <asp:Label ID="lblCustomerType" runat="server" Text="Tag No:" Style="margin-right: 44px;"></asp:Label>
                </td>
                <td class="TopHeaderTable3" style="width: 206px; height: 30px;">
                   <div style=" margin-left: 2px;">
                    <telerik:RadTextBox ID="txtTagNo" runat="server" Skin="WebBlue" Width="140" Style="text-transform: uppercase;">
                    </telerik:RadTextBox></div>
                </td>
                <td style="width: 110px; height: 30px;" align="left">
                    <asp:Label ID="lblCountry" runat="server" Text="Brand:"></asp:Label>
                </td>
                <td style="height: 30px; width: 186px;">
                    <telerik:RadTextBox ID="txtBrands" runat="server" Skin="WebBlue" Width="140" Style="text-transform: uppercase;">
                    </telerik:RadTextBox>
                </td>
                <td style="height: 30px; width: 150px">
                    <asp:Label ID="lblGeoTerritory" runat="server" Text="Model:" Style="margin-left: 10px;
                        margin-right: 10px;"></asp:Label>
                </td>
                <td style="height: 30px">
                    <telerik:RadTextBox ID="txtModel" runat="server" Skin="WebBlue" Width="140" Style="text-transform: uppercase;">
                    </telerik:RadTextBox>
                </td>
            </tr>
        </table>
        <br />
        <table width="100%">
            <tr>
                <td style="height: 30px; width: 140px;">
                    <asp:Label ID="lblAddressLine1" runat="server" Text="ME Name:"></asp:Label>
                </td>
                <td colspan="3">
                    <div style="">
                        <telerik:RadTextBox ID="txtName" runat="server" Height="20px" Width="790px" Skin="WebBlue"
                            Style="text-transform: uppercase;">
                        </telerik:RadTextBox></div>
                </td>
            </tr>
        </table>
        <br />
        <table width="104%">
            <tr>
                <td style="height: 30px; width: 140px;">
                    <asp:Label ID="lblAddressLine2" runat="server" Text="Description:"></asp:Label>
                </td>
                <td colspan="3">
                    <div style="">
                        <telerik:RadTextBox ID="txtDescription" runat="server" Width="790px" Skin="WebBlue"
                            Style="text-transform: uppercase;">
                        </telerik:RadTextBox></div>
                </td>
            </tr>
        </table>
           <table width="">
            <tr>
                <td style="height: 30px; width: 140px;">
             
                    <asp:Label ID="Label16" runat="server" Text="Department:" Style="margin-right: 44px;"></asp:Label>
                </td>
                <td class="TopHeaderTable3" style="width: 206px; height: 30px;">
                   <div style=" margin-left: 2px;">
                   
                          <telerik:RadComboBox ID="CMBDepartment" DropDownAutoWidth="Enabled" runat="server" AutoPostBack="false" Width="140" Skin="WebBlue">
                        </telerik:RadComboBox>
                    
                    </div>
                </td>
                <td style="width: 110px; height: 30px;" align="left">
                    <asp:Label ID="Label17" runat="server" Text="Unit:"></asp:Label>
                </td>
                <td style="height: 30px; width: 186px;">
                    <telerik:RadComboBox ID="cmbUnit" runat="server" AutoPostBack="false" Width="140" Skin="WebBlue">
                        </telerik:RadComboBox>
                </td>
                <td style="height: 30px; width: 150px">
                  
                </td>
                <td style="height: 30px">
                  
                </td>
            </tr>
        </table>
        <br />
        <table style="width: 100%;">
            <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
                visible="true">
                <th colspan="5" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                    color: #808080;">
                    Setup Details
                </th>
            </tr>
        </table>
        <br />
        <table width="%">
            <tr>
                <td style="height: 30px; width: 140px;">
                    <asp:Label ID="lblContactNo" runat="server" Text="Gross Wt:" Style=""></asp:Label>
                </td>
                <td style="width: 206px;">
                    <telerik:RadNumericTextBox ID="txtGrossWt" Width="140" Skin="Office2010Blue" AutoPostBack="true"
                        runat="server" Type="Number" NumberFormat-DecimalDigits="2">
                    </telerik:RadNumericTextBox>
                    <br />
                    <div style="     margin-left: 49px;">
                    <asp:Label ID="Label1" runat="server" ForeColor="Gray" Text="(In Kg)"></asp:Label></div>
                </td>
                <td style="width: 110px">
               
                    <asp:Label ID="lbFaxNo" runat="server" Text="Dimension:" Style=""></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtDimension" Width="140" runat="server" Skin="WebBlue" Style="text-transform: uppercase;">
                    </telerik:RadTextBox>
                    <br /> <div style=" margin-left: 11px;">
                    <asp:Label ID="Label122" runat="server" ForeColor="Gray" Text="(L X W X H In meter)"></asp:Label></div>
                </td>
                <td style="width: 110px">
                 <div style=" margin-left: 48px;">
                    <asp:Label ID="Label5" runat="server" Text="Energy Consumption:" Style=""></asp:Label></div>
                </td>
                <td> <div style="     margin-left: 66px; margin-bottom: -12px;">
                    <telerik:RadTextBox ID="txtKWHConsumptionn" Width="140" runat="server" Skin="WebBlue"
                        Style="text-transform: uppercase;">
                    </telerik:RadTextBox></div>
                    <br />
                     <div style=" margin-left: 84px;">
                    <asp:Label ID="Label6" runat="server" ForeColor="Gray" Text="(In Kilo Watt Hour)"></asp:Label></div>
                </td>
            </tr>
        </table>
        <br />
        <table width="%">
            <tr>
                <td style="height: 30px; width: 140px;">
                    <asp:Label ID="Label2" runat="server" Text="Operational Cost:" Style=""></asp:Label>
                </td>
                <td style="width: 206px;">
                    <telerik:RadTextBox ID="txtOperationalCostt" Width="140" runat="server" Skin="Office2010Blue"
                        Style="text-transform: uppercase;">
                    </telerik:RadTextBox>
                    <br />
                    <div style="     margin-left: 31px;"> 
                    <asp:Label ID="Label3" runat="server" ForeColor="Gray" Text="(In Per Hour)"></asp:Label></div>
                </td>
                <td style="width: 110px">
                    <td style="width: 110px">
                    <div style=" margin-left: -111px;">
                        <asp:Label ID="Label8" runat="server" Text="ME Health Rating:" Style=""></asp:Label></div>
                    </td>
                    <td>
                     <div style=" margin-left: -108px; margin-bottom: -17px;">
                        <telerik:RadNumericTextBox ID="txtHealthRate" Width="140" AutoPostBack="true" runat="server"
                            Skin="WebBlue" Type="Number" NumberFormat-DecimalDigits="2">
                        </telerik:RadNumericTextBox></div>
                        <br />
                         <div style=" margin-left: -95px;     margin-top: 5px;">
                        <asp:Label ID="Label9" runat="server" ForeColor="Gray" Text="(Min=0 & Max=9.00)"></asp:Label></div>
                    </td>

                    <td style="width: 110px">
             
                </td>
                <td> 
                </td>

            </tr>
        </table>
        <br />
        <table style="width: 100%;">
            <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
                visible="true">
                <th colspan="5" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                    color: #808080;">
                    Financials & Procurement
                </th>
            </tr>
        </table>
        <br />
        <table width="%">
            <tr>
                <td style="height: 30px; width: 140px;">
                    <asp:Label ID="Label4" runat="server" Text="Purchased Date:" Style=""></asp:Label>
                </td>
                <td style="width: 206px;">
                    <telerik:RadDatePicker ID="txtPurchaseDate" runat="server" Culture="en-US" Width="140">
                        <Calendar ID="Calendar2" runat="server" NavigationNextToolTip="" FastNavigationPrevToolTip=""
                            NavigationPrevToolTip="" FastNavigationNextToolTip="" ShowDayCellToolTips="false"
                            UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                        </Calendar>
                        <DateInput ID="DateInput2" DisplayDateFormat="dd/MM/yyyy" runat="server" DateFormat="dd/MM/yyyy"
                            LabelWidth="30%">
                        </DateInput>
                        <DatePopupButton ImageUrl="" HoverImageUrl="" ToolTip=""></DatePopupButton>
                    </telerik:RadDatePicker>
                    <br />
                 
                </td>
                <td style="width: 110px">
                    <asp:Label ID="Label10" runat="server" Text="Purchased Price:" Style=""></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtPurchasedPricee" Width="140" runat="server" Skin="WebBlue"
                        Style="text-transform: uppercase;">
                    </telerik:RadTextBox>
                    <br />
                      <div style="     margin-left: 37px;">
                    <asp:Label ID="Label11" runat="server" ForeColor="Gray" Text="(In Pak Rs.)"></asp:Label></div>
                </td>
                <td style="width: 110px">
                <div style=" margin-left: 47px;">
                    <asp:Label ID="Label12" runat="server" Text="Depriciation Period:" Style=""></asp:Label></div>
                </td>
                <td>
                <div style=" margin-left: 79px;">
                    <telerik:RadTextBox ID="txtDepreciationPeriodd" Width="140" runat="server" Skin="WebBlue"
                        Style="text-transform: uppercase;">
                    </telerik:RadTextBox></div>
                    <br />
                     <div style="     margin-left: 107px; margin-bottom: -12px; margin-top: -12px;">
                    <asp:Label ID="Label13" runat="server" ForeColor="Gray" Text="(In No.of Years)"></asp:Label></div>
                </td>
            </tr>
        </table>
        <br />
        <table width="%">
            <tr>
                <td style="height: 30px; width: 140px;">
                    <asp:Label ID="Label14" runat="server" Text="Warranty Claimable:" Style=""></asp:Label>
                </td>
                <td style="width: 206px;">
                    <telerik:RadTextBox ID="txtWarrantyClaimable" Width="140" runat="server" Skin="Office2010Blue"
                        Style="text-transform: uppercase;">
                    </telerik:RadTextBox>
            </tr>
        </table>
        <br />

         <asp:Panel ID="pnlcertificate" runat="server" Visible ="false"  >
        <table style="width: 100%;">
            <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
                visible="true">
                <th colspan="5" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                    color: #808080;">
                    Attachment
                </th>
            </tr>
        </table>
        <br />

                 <br />
            <table width="100%">
                <tr>
                    <td>
                    </td>
                    <td class="ErrorMsg">
                        <asp:Label ID="Label7" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px;">
                        Document:
                    </td>
                    <td style="width: 246px;">
                        <div style="margin-left: 40px;">
                        
                            <telerik:RadComboBox ID="cmbCertificate" Width="140" 
                                runat="server" Skin="WebBlue">
                            </telerik:RadComboBox>
                        </div>
                    </td>
                    <td style="line-height: 8px; width: 105px;">
                        Upload Document:
                    </td>
                    <td>
                    <div style=" margin-left: 4px; margin-bottom: -12px;">
                        <asp:FileUpload ID="FileUpload1" runat="server" /></div>
                        <asp:CustomValidator ID="CustomValidator4" ForeColor="Red" runat="server" ControlToValidate="FileUpload1"
                            ClientValidationFunction="ValidateFileUpload" ErrorMessage="Please select valid pdf file"></asp:CustomValidator>
                        <script language="javascript" type="text/javascript">
                            function ValidateFileUpload(Source, args) {
                                var fuData = document.getElementById('<%= FileUpload1.ClientID %>');
                                var FileUploadPath = fuData.value;
                                if (FileUploadPath == '') {
                                    args.IsValid = false;
                                }
                                else {
                                    var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();
                                    if (Extension == "pdf") {
                                        args.IsValid = true; 
                                    }
                                    else {
                                        args.IsValid = false; 
                                    }
                                }
                            }
                        </script>
                    </td>
                </tr>
                <tr style="height: 40px;">
                    <td class="">
                        <asp:Label ID="Label15" runat="server" Text="Description:"></asp:Label>
                    </td>
                    <td>
                        <div style="margin-left: 40px;">
                            <asp:TextBox ID="txtDescriptionAttachment" Width="140px" runat="server"></asp:TextBox>
                        </div>
                    </td>
                    <td>
                    </td>
                    <td>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <telerik:RadButton ID="btnAddCertificate" runat="server" CssClass="buttonTelerik"
                            Text="Add Document" Skin="Glow" Style="float: right;">
                        </telerik:RadButton>
                    </td>
                </tr>
            </table>
            <br />
            <table width="100%">
                <tr>
                    <td>
                        <Smart:SmartDataGrid ID="dgCertificate" runat="server" Width="100%" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="2" CssClass="table" PagerCurrentPageCssClass=""
                            PagerOtherPageCssClass="" PageSize="800" RecordCount="0" ShowFooter="True" sortedascending="yes">
                            <Columns>
                              <asp:BoundColumn HeaderText="AttachmentID" DataField="AttachmentID"
                                    Visible="False" />
                                <asp:BoundColumn HeaderText="AttachmentListID" DataField="AttachmentListID"
                                    Visible="False" />
                                <asp:BoundColumn HeaderText="MEID" DataField="MEID" Visible="False" />
                                <asp:TemplateColumn HeaderText="Document">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" CommandName="ViewCertificate" Text='<%#Eval("AttachmentName") %>'
                                            runat="server"> </asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </asp:TemplateColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="15%" HeaderText="Description"
                                    DataField="Description">
                                    <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="15%" HeaderText="Uploaded By"
                                    DataField="UserName">
                                    <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="15%" HeaderText="Date"
                                    DataField="CreationDatee">
                                    <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="Remove">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton1" runat="server" OnClientClick="return confirm('Are you sure you want to delete this record?');"
                                            CommandName="Remove" BackColor="transparent" ImageUrl="~/Images/RemoveIcon.png" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="05%" />
                                </asp:TemplateColumn>
                            </Columns>
                            <PagerStyle Visible="False" CssClass="GridPagerStyle" Mode="NumericPages" HorizontalAlign="Right" />
                            <AlternatingItemStyle CssClass="GridAlternativeRow" />
                            <ItemStyle CssClass="GridRow" />
                            <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                        </Smart:SmartDataGrid>
                    </td>
                </tr>
            </table>
            </asp:Panel> 

        <table>
        <tr>
            <td style="height: 30px; width: 128px;">
                &nbsp;
            </td>
            <td>
            </td>
            <td>
                <div style="margin-left: 518px;">
                    <telerik:RadButton ID="btnSave" runat="server" CssClass="buttonTelerik" Text="Save"
                        Skin="Glow" Visible="true">
                    </telerik:RadButton>
                </div>
            </td>
            <td>
                &nbsp;
                <div style="margin-left: 19px;">
                    <telerik:RadButton ID="btnCancel" CssClass="buttonTelerik" runat="server" Text="Cancel"
                        Visible="true" Skin="Glow">
                    </telerik:RadButton>
                </div>
                &nbsp;
            </td>
        </tr>
    </table>
   
</asp:Content>
