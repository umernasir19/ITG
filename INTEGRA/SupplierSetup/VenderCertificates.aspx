<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="VenderCertificates.aspx.vb" Inherits="Integra.VenderCertificates" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 <link href= "../App_Themes/Blue/StyleSheet.css" rel="stylesheet" />
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
            if (Extension == "pdf") 
            {
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
<DateInput DisplayDateFormat="dd/MM/yyyy" runat="server" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>
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
    </form>
</body>
</html>
