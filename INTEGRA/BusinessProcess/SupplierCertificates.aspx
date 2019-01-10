<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SupplierCertificates.aspx.vb" Inherits="Integra.SupplierCertificates" %>
 <%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
   <link href= "../App_Themes/Blue/StyleSheet.css" rel="stylesheet" />
   <link href="../StyleSheet/StyleSheet.css" rel="stylesheet" type="text/css" />
  <script language="javascript" type="text/javascript" src="../JavaScript/Maskdiv.js"></script>
  <script type="text/javascript"  language="JavaScript" src="../scripts/Calender.js"></script>
  <script type="text/javascript" src="../scripts/thickbox.js"></script>
  <script type="text/javascript" src="../scripts/jquery.js"></script>
  <script type="text/javascript"  language="JavaScript" src="scripts/pupdate.js"></script>
  <link rel="stylesheet" href="../scripts/ThickBox.css" type="text/css" media="screen" />
  <link type="text/css" rel="stylesheet" href="../App_Themes/Blue/MenuCSS.css" />  
  <link type="text/css" rel="stylesheet" href="../StyleSheet/NewLayout.css" />
  <link rel="stylesheet" type="text/css" href="styles.css" /> 
</head>
<body>
    <form id="form1" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>  
       
    <table width="100%">
    <tr>
    <td></td>
    <td class="ErrorMsg">
        <asp:Label ID="lblmsg" runat="server"  ></asp:Label>
    </td>
    </tr>
    <tr>
    <td class="labelNew">
    Vendor
    </td>
    <td>
      <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                    <telerik:RadComboBox ID="cmbVendor" Runat="server" AutoPostBack="True" 
                    Skin="WebBlue">
                </telerik:RadComboBox>
                </ContentTemplate>
                 </asp:UpdatePanel>
    </td>
    </tr>
    <tr>
    <td class="labelNew">
    Certificate Name
    </td>
    <td>
       <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                    <telerik:RadComboBox ID="cmbCertificate" Runat="server" AutoPostBack="True" 
                    Skin="WebBlue">
                </telerik:RadComboBox>
                </ContentTemplate>
                 </asp:UpdatePanel>
    </td>
    </tr>
    <tr>
    <td class="labelNew">
     Certificate 
    </td>
    <td>
     <asp:FileUpload ID="FileUpload1" runat="server" />
  <asp:CustomValidator ID="CustomValidator1"  ForeColor="Red"  runat="server"  ControlToValidate="FileUpload1"
 ClientValidationFunction="ValidateFileUpload" ErrorMessage="Please select valid pdf file"></asp:CustomValidator>
<script language="javascript" type="text/javascript">
    function ValidateFileUpload(Source, args) {
        var fuData = document.getElementById('<%= FileUpload1.ClientID %>');
        var FileUploadPath = fuData.value;
        if (FileUploadPath == '') {
            // There is no file selected 
            args.IsValid = false;
        }
        else {
            var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();
            if (Extension == "pdf") {
                args.IsValid = true; // Valid file type
            }
            else {
                args.IsValid = false; // Not valid file type
            }
        }
    }
</script>
    </td>
    </tr>
    <tr>
    <td class="labelNew">
     Certificate Expiry:
    </td>
    <td>
       <telerik:RadDatePicker ID="txtExpiryDate" runat="server" Culture="en-US">
<Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>
<DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" runat="server" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
    
    </td>
    </tr>
    <tr>
    <td align="right">
     
    </td>
    <td>
       <telerik:RadButton ID="btnSave" runat="server" Text="Upload Certificate" 
                    Skin="WebBlue">
                </telerik:RadButton>
    </td>
    </tr>
    </table>
    <table width="100%">
    <%--    <telerik:RadGrid ID="dgComplianceStatus" runat="server" CellSpacing="0" 
                AutoGenerateColumns="false"  Skin="WebBlue"  
                  PageSize="50">
                     <MasterTableView>
            <Columns>
            <telerik:GridBoundColumn DataField="VenderLibraryID" HeaderText="VenderLibraryID" Display="false">
</telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="CertificateID" HeaderText="CertificateID" Display="false"></telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="Supplier" HeaderText="Supplier" AllowFiltering="false" ShowFilterIcon="false" FilterDelay="2000" AndCurrentFilterFunction="StartsWith" FilterControlWidth="120px">
</telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="Certificate" HeaderText="Compliance" AllowFiltering="false" ShowFilterIcon="false" FilterDelay="2000" AndCurrentFilterFunction="StartsWith" FilterControlWidth="120px">
</telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="Validity" HeaderText="Validity" AllowFiltering="false"></telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="Status" HeaderText="Status" AllowFiltering="false" ShowFilterIcon="false" FilterDelay="2000" AndCurrentFilterFunction="StartsWith" FilterControlWidth="120px"></telerik:GridBoundColumn>
   <telerik:GridTemplateColumn HeaderText ="View"  Display="true" AllowFiltering="false">
                <ItemTemplate >
                <asp:LinkButton ID="lnEdit"  runat ="server" CommandName ="ViewCertificate"  Text="View" ></asp:LinkButton>
                </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
            </MasterTableView>
            <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="false">
                                <Selecting AllowRowSelect="true" EnableDragToSelectRows="false" />
                            </ClientSettings>
        </telerik:RadGrid>--%>

<asp:UpdatePanel ID="upcmbAction" runat="server">
     <ContentTemplate>
 
     	<SMART:SMARTDATAGRID id="dgComplianceStatuss" runat="server" width="100%"  
	  AllowPaging="True" AllowSorting="True"
	  AutoGenerateColumns="False" CellPadding="4" CssClass="table" PagerCurrentPageCssClass=""
	   PagerOtherPageCssClass="" PageSize="500" RecordCount="0" ShowFooter="True" SortedAscending="yes"
	    ForeColor="white" GridLines="Both"  >
 					
							<COLUMNS>
                            <ASP:BOUNDCOLUMN HeaderText="VenderLibraryID"
								  DataField="VenderLibraryID" visible="False" >
                                <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
							<ASP:BOUNDCOLUMN HeaderText="CertificateID"
								  DataField="CertificateID" visible="False" >
                                <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
						 
				         	<ASP:BOUNDCOLUMN HeaderText="Supplier"
									 DataField="Supplier">
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
								
								<ASP:BOUNDCOLUMN HeaderText="Compliance"
									 DataField="Certificate">
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN HeaderText="Validity"
									 DataField="Validity">
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN HeaderText="Status"
									 DataField="Status">
                                    <itemstyle horizontalalign="Left" />
								 <headerstyle width="10%" horizontalalign="Left"  />
							</ASP:BOUNDCOLUMN>
							 	<ASP:TEMPLATECOLUMN HeaderText="View">
                                    <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
                                    <asp:LinkButton id="lnkEditiew" CommandName="Edit" runat="server">View</asp:LinkButton>
                                    </ITEMTEMPLATE>
                                    <headerstyle width="07%" />
								</ASP:TEMPLATECOLUMN>
							 		 
								</COLUMNS>
		 <PagerStyle CssClass="GridPagerStyle" Mode="NumericPages" HorizontalAlign="Right"    />
	        <AlternatingItemStyle CssClass="GridAlternativeRow" />
        <ItemStyle CssClass="GridRow" />
        <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
 	</SMART:SMARTDATAGRID>
     
          </ContentTemplate>
    </asp:UpdatePanel>
    </table>
    </form>
</body>
</html>
