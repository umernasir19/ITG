<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeBehind="HRMainAdd.aspx.vb" Inherits="Integra.HRMainAdd" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<style type ="text/css" >
.image{
width:120px;
height:120px;
margin:0 0 0 5px;
padding:0;
float:left;
}
.table{
width:725px;
/*height:258px;*/
margin:0 auto;
padding:0;
float:left;
background-color :White ;
border:0;
}
</style>
 <telerik:RadAjaxManager ID="radajax" runat="Server">
 <AjaxSettings>
 <telerik:AjaxSetting AjaxControlID="txtMiscAllowance">
 <UpdatedControls>
<telerik:AjaxUpdatedControl ControlID="txtGrossSum" /> 
     <telerik:AjaxUpdatedControl ControlID ="txtNetSalary" />
 </UpdatedControls>
 </telerik:AjaxSetting>
 </AjaxSettings>
 <AjaxSettings >
 <telerik:AjaxSetting AjaxControlID ="txtOtherAllowance">
 <UpdatedControls >
 <telerik:AjaxUpdatedControl ControlID ="txtGrossSum" />
      <telerik:AjaxUpdatedControl ControlID ="txtNetSalary" />
 </UpdatedControls>
 </telerik:AjaxSetting>
  </AjaxSettings>
  <AjaxSettings >
  <telerik:AjaxSetting AjaxControlID ="txtMobileAllowance" >
  <UpdatedControls >
   <telerik:AjaxUpdatedControl ControlID ="txtGrossSum" />
        <telerik:AjaxUpdatedControl ControlID ="txtNetSalary" />
  </UpdatedControls>
  </telerik:AjaxSetting>
  </AjaxSettings>
  <AjaxSettings >
  <telerik:AjaxSetting AjaxControlID ="txtConvAllowance">
  <UpdatedControls >
  <telerik:AjaxUpdatedControl ControlID ="txtGrossSum" />
       <telerik:AjaxUpdatedControl ControlID ="txtNetSalary" />
  </UpdatedControls>
  </telerik:AjaxSetting>
  </AjaxSettings>
  <AjaxSettings >
  <telerik:AjaxSetting AjaxControlID ="txtBasic">
  <UpdatedControls>
    <telerik:AjaxUpdatedControl ControlID ="txtGrossSum" />
     <telerik:AjaxUpdatedControl ControlID ="txtNetSalary" />
  </UpdatedControls>
  </telerik:AjaxSetting>
  </AjaxSettings>

 <AjaxSettings >
 <telerik:AjaxSetting AjaxControlID ="txtOther" >
 <UpdatedControls >
 <telerik:AjaxUpdatedControl ControlID ="txtNetSalary" />
 </UpdatedControls>
 </telerik:AjaxSetting>
 </AjaxSettings>
 <AjaxSettings >
 <telerik:AjaxSetting AjaxControlID ="txtTax">
 <UpdatedControls >
 <telerik:AjaxUpdatedControl ControlID ="txtNetSalary" />
 </UpdatedControls>
 </telerik:AjaxSetting>
 </AjaxSettings>
 <AjaxSettings >
 <telerik:AjaxSetting AjaxControlID ="txtEOBI">
 <UpdatedControls>
 <telerik:AjaxUpdatedControl ControlID ="txtNetSalary" />
 </UpdatedControls>
 </telerik:AjaxSetting>
 </AjaxSettings>
     </telerik:RadAjaxManager>


    <div class ="table">
<table>
          <%-- <telerik:RadTextBox ID="txtCNIC" Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>--%>
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;" 
              visible="true";>
                   <th colspan ="6" align="left"   style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080; width:600px;">Personal Profile</th>
                               
                    </tr>

             <tr>
      <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblHRCode" runat="server" Text="HR Code"></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
              <telerik:RadTextBox ID="txtHRCode" Runat="server" Skin="WebBlue" TabIndex="1">
                </telerik:RadTextBox>

            </td>
                <td style="height: 30px; width: 85px;"> </td>
                    <td style="height: 30px; width: 85px;"> </td>
                        <td style="height: 30px; width: 85px;"> </td>
                            <td style="height: 30px; width: 55px;"> </td>
      </tr>
            <tr>
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblFullName" runat="server" Text="Full Name"></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
              <telerik:RadTextBox ID="txtFullName" Runat="server" Skin="WebBlue" TabIndex="1">
                </telerik:RadTextBox>

            </td>
           
            <td style="width: 128px; height: 30px;">   <asp:FileUpload ID="imgEmployee" runat="server"/></td>
                <td style="height: 30px; width: 85px;"> </td>
                    <td style="height: 30px; width: 85px;"> </td>
                        <td style="height: 30px; width: 55px;"> </td>
            
        </tr>
       <tr>
        <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblSurname" runat="server" Text="Surname"></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtSurname" Runat="server" Skin="WebBlue" TabIndex="1">
                </telerik:RadTextBox>
            </td>
                <td style="height: 30px; width: 85px;"> </td>
                    <td style="height: 30px; width: 85px;"> </td>
                        <td style="height: 30px; width: 85px;"> </td>
                            <td style="height: 30px; width: 55px;"> </td>
       </tr>
        </table>
</div>
<div class="image"> <table><tr><td>    <asp:Image ID="Image2" runat="server"   Width="100" /></td></tr></table></div>

           <%-- 
            <tr>
      <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblHRCode" runat="server" Text="HR Code"></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
              <telerik:RadTextBox ID="txtHRCode" Runat="server" Skin="WebBlue" TabIndex="1">
                </telerik:RadTextBox>

            </td>
      </tr>
            <tr>
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblFullName" runat="server" Text="Full Name"></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
              <telerik:RadTextBox ID="txtFullName" Runat="server" Skin="WebBlue" TabIndex="1">
                </telerik:RadTextBox>

            </td>
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblSurname" runat="server" Text="Surname"></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtSurname" Runat="server" Skin="WebBlue" TabIndex="1">
                </telerik:RadTextBox>
            </td>
            <td style="width: 128px; height: 30px;">   <asp:FileUpload ID="imgEmployee" runat="server"/></td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">   
                                 <asp:Image ID="Image2" runat="server"   Width="100" />
          </td>
            
        </tr>
            <tr>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="lblDateofBirth" runat="server" Text="Date of Birth"></asp:Label>
            </td>
          <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadDatePicker ID="txtDateOfBirth" runat="server" Culture="en-US" 
                    TabIndex="2" MinDate="1111-01-01">
<Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>
<DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="2"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="2"></DatePopupButton>
                </telerik:RadDatePicker>

            </td>
                 
            <td style="height: 30px; width: 85px;">
                <asp:Label ID="lblNationality" runat="server" Text="Nationality"></asp:Label>
            </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                 <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                    <telerik:RadComboBox ID="cmbNationality" Runat="server" AutoPostBack="True" 
                    Skin="WebBlue" TabIndex="3">
                     <Items>   
                <telerik:RadComboBoxItem Value="0" Text="Pakistani"/>
                 <telerik:RadComboBoxItem Value="1" Text="German"/>
                   </Items>
                </telerik:RadComboBox>
                </ContentTemplate>
                 </asp:UpdatePanel>
            </td>
            <td style="height: 30px; width: 87px;">     </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;"> </td>
        </tr>
            <tr>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="lblResidenceAddress" runat="server" Text="Residence Address"></asp:Label>
            </td>
           <td class="TopHeaderTd3" style="width: 365px; height: 30px;" colspan="5">
           <telerik:RadTextBox ID="txtResidenceAddress" Runat="server" Skin="WebBlue" 
                   Width="618px" TabIndex="4">
                </telerik:RadTextBox>
                </td> 
        </tr>
            <tr>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            </td>
           <td class="TopHeaderTd3" style="width: 365px; height: 30px;" colspan="5">
           <telerik:RadTextBox ID="txtResidenceAddress2" Runat="server" Skin="WebBlue"   
                   Width="618px" TabIndex="5">
                </telerik:RadTextBox>
                </td> 
        </tr>         
            <tr>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="lblResidencePhoneNo" runat="server" Text="Residence Phone No"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtResidencePhoneNo" Runat="server" Skin="WebBlue" 
                    TabIndex="6">
                </telerik:RadTextBox>
            </td>

            <td style="height: 30px; width: 85px;">
                <asp:Label ID="lblCellNo" runat="server" Text="Cell No"></asp:Label>
            </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                <telerik:RadTextBox ID="txtCellNo" Runat="server" Skin="WebBlue" TabIndex="7">
                </telerik:RadTextBox>
            </td>
             <td style="height: 30px; width: 85px;"> </td>
            <td style="height: 30px; width: 85px;">  </td>        
               
        </tr>
            <tr>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="lblEmergencyContactNo" runat="server" Text="Emergency Contact No"></asp:Label>
            </td>
              <td class="TopHeaderTd3" style="width: 165px; height: 30px;"> 
               <telerik:RadTextBox ID="txtEmergencyContactNo" Runat="server" Skin="WebBlue" 
                      TabIndex="8">
                </telerik:RadTextBox>
                </td> 
            <td style="height: 30px; width: 85px;">
                <asp:Label ID="lblNexttokin" runat="server" Text="Next to kin"></asp:Label>
            </td>
             <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
           <telerik:RadTextBox ID="txtNexttokin" Runat="server" Skin="WebBlue" TabIndex="9">
                </telerik:RadTextBox>
                </td> 
            <td style="height: 30px; width: 87px;"></td>
             <td class="TopHeaderTd3" style="width: 165px; height: 30px;"></td> 
        </tr>
            <tr>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="lblMaternalStatus" runat="server" Text="Marital Status"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
               <asp:UpdatePanel ID="UpdatePanel5" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                    <telerik:RadComboBox ID="cmbMaternalStatus" Runat="server" AutoPostBack="True" 
                    Skin="WebBlue" TabIndex="10">
                    <Items>   
               <telerik:RadComboBoxItem Value="0" Text="Unmarried"/>
                <telerik:RadComboBoxItem Value="1" Text="Married"/>            
                  <telerik:RadComboBoxItem Value="2" Text="Widow"/>
                 </Items>
                </telerik:RadComboBox>
                </ContentTemplate>
                 </asp:UpdatePanel>
            </td>
            <td style="height: 30px; width: 85px;"></td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;"> </td>
            <td style="height: 30px; width: 87px;">     </td>
           <td class="TopHeaderTd3" style="width: 165px; height: 30px;"> </td>     
              
        </tr> --%>
          <%--'-------Heading Row--------'--%>
     <table border="0" cellpadding="0" cellspacing="0">
          <tr>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="lblDateofBirth" runat="server" Text="Date of Birth"></asp:Label>
            </td>
          <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadDatePicker ID="txtDateOfBirth" runat="server" Culture="en-US" 
                    TabIndex="2" MinDate="1111-01-01">
<Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>
<DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="2"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="2"></DatePopupButton>
                </telerik:RadDatePicker>

            </td>
                 
            <td style="height: 30px; width: 85px;">
                <asp:Label ID="lblNationality" runat="server" Text="Nationality"></asp:Label>
            </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                 <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                    <telerik:RadComboBox ID="cmbNationality" Runat="server" AutoPostBack="True" 
                    Skin="WebBlue" TabIndex="3">
                     <Items>   
                <telerik:RadComboBoxItem Value="0" Text="Pakistani"/>
                 <telerik:RadComboBoxItem Value="1" Text="German"/>
                   </Items>
                </telerik:RadComboBox>
                </ContentTemplate>
                 </asp:UpdatePanel>
            </td>
            <td style="height: 30px; width: 87px;">     </td>
            
        </tr>
            <tr>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="lblResidenceAddress" runat="server" Text="Residence Address"></asp:Label>
            </td>
           <td class="TopHeaderTd3" style="width: 365px; height: 30px;" colspan="4">
           <telerik:RadTextBox ID="txtResidenceAddress" Runat="server" Skin="WebBlue" 
                   Width="700px" TabIndex="4">
                </telerik:RadTextBox>
                </td> 
        </tr>
            <tr>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            </td>
           <td class="TopHeaderTd3" style="width: 365px; height: 30px;" colspan="4">
           <telerik:RadTextBox ID="txtResidenceAddress2" Runat="server" Skin="WebBlue"   
                   Width="700px" TabIndex="5">
                </telerik:RadTextBox>
                </td> 
        </tr>         
            <tr>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="lblResidencePhoneNo" runat="server" Text="Residence Phone No"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtResidencePhoneNo" Runat="server" Skin="WebBlue" 
                    TabIndex="6">
                </telerik:RadTextBox>
            </td>

            <td style="height: 30px; width: 85px;">
                <asp:Label ID="lblCellNo" runat="server" Text="Cell No"></asp:Label>
            </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                <telerik:RadTextBox ID="txtCellNo" Runat="server" Skin="WebBlue" TabIndex="7">
                </telerik:RadTextBox>
            </td>
             <td style="height: 30px; width: 85px;"> </td>
                 
               
        </tr>
            <tr>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="lblEmergencyContactNo" runat="server" Text="Emergency Contact No"></asp:Label>
            </td>
              <td class="TopHeaderTd3" style="width: 165px; height: 30px;"> 
               <telerik:RadTextBox ID="txtEmergencyContactNo" Runat="server" Skin="WebBlue" 
                      TabIndex="8">
                </telerik:RadTextBox>
                </td> 
            <td style="height: 30px; width: 85px;">
                <asp:Label ID="lblNexttokin" runat="server" Text="Next to kin"></asp:Label>
            </td>
             <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
           <telerik:RadTextBox ID="txtNexttokin" Runat="server" Skin="WebBlue" TabIndex="9">
                </telerik:RadTextBox>
                </td> 
            <td style="height: 30px; width: 87px;"></td>
             
        </tr>
            <tr>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="lblMaternalStatus" runat="server" Text="Marital Status"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
               <asp:UpdatePanel ID="UpdatePanel5" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                    <telerik:RadComboBox ID="cmbMaternalStatus" Runat="server" AutoPostBack="True" 
                    Skin="WebBlue" TabIndex="10">
                    <Items>   
               <telerik:RadComboBoxItem Value="0" Text="Unmarried"/>
                <telerik:RadComboBoxItem Value="1" Text="Married"/>            
                  <telerik:RadComboBoxItem Value="2" Text="Widow"/>
                 </Items>
                </telerik:RadComboBox>
                </ContentTemplate>
                 </asp:UpdatePanel>
            </td>
            <td style="height: 30px; width: 85px;"></td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;"> </td>
            <td style="height: 30px; width: 87px;">     </td>
                
              
        </tr>



            <tr  style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin; z-index: auto;" 
              visible="true";>
        
            <th colspan ="5" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080;">Key Identification</th>
                   
            </tr>
            <tr>
            <td class="style4">
                <asp:Label ID="lblCNIC" runat="server" Text="CNIC"></asp:Label>
            </td>
            <td style="width: 128px; height: 30px;">
                <%--'-------Heading Row--------'--%>
                <telerik:RadMaskedTextBox ID="txtCNIC" runat="server" Mask="#####-#######-#" 
                    TabIndex="11">
                </telerik:RadMaskedTextBox>

            </td>

            <td style="height: 30px; width: 85px;">
                <asp:Label ID="lblValidity" runat="server" Text="Validity"></asp:Label>
            </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                   <telerik:RadDatePicker ID="txtCNICValidity" runat="server" Culture="en-US" 
                       TabIndex="12" MinDate="1111-01-01">
<Calendar ID="Calendar3" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>
<DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="12"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="12"></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
             <td style="height: 30px; width: 85px;"> 
                   <asp:FileUpload ID="imgCNIC" runat="server" /> 
             </td>
             
        </tr>
            <tr>
            <td class="style4">
                <asp:Label ID="lblPassport" runat="server" Text="Passport"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtPassport" Runat="server" Skin="WebBlue" 
                    TabIndex="13">
                </telerik:RadTextBox>
            </td>

            <td style="height: 30px; width: 85px;">
                <asp:Label ID="lblValidity2" runat="server" Text="Validity"></asp:Label>
            </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
            <telerik:RadDatePicker ID="txtPassportValidity" runat="server" Culture="en-US" 
                    TabIndex="14" MinDate="1111-01-01">
<Calendar ID="Calendar4" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>
<DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" 
                    TabIndex="14"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="14"></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
             <td style="height: 30px; width: 85px;">   <asp:FileUpload ID="imgPassport" runat="server" /> </td>
                
               
        </tr>
            <tr>
            <td class="style4">
                <asp:Label ID="lblDrivingLicense" runat="server" Text="Driving License"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtDrivingLicense" Runat="server" Skin="WebBlue" 
                    TabIndex="15">
                </telerik:RadTextBox>
            </td>

            <td style="height: 30px; width: 85px;">
                <asp:Label ID="lblDrivingLicenseValidity" runat="server" Text="Validity"></asp:Label>
            </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
              <telerik:RadDatePicker ID="txtDrivingLicenseValidity" runat="server" 
                    Culture="en-US" TabIndex="16" MinDate="1111-01-01">
<Calendar ID="Calendar5" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>
<DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="16"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="16"></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
             <td style="height: 30px; width: 85px;">   <asp:FileUpload ID="ImgDrivingLicense" runat="server" /> </td>
                  
               
        </tr>
            <tr>
            <td class="style4">
                <asp:Label ID="lblNTNNo" runat="server" Text="NTN No"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtNTNNo" Runat="server" Skin="WebBlue" TabIndex="17">
                </telerik:RadTextBox>
            </td>
            <td style="height: 30px; width: 85px;"> </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;"> </td>
             <td style="height: 30px; width: 85px;"> </td>
          
               
        </tr>
            <tr>
            <td class="style4">
                <asp:Label ID="lblInsurancePolicy" runat="server" Text="Insurance Policy"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtInsurancePolicy" Runat="server" Skin="WebBlue" 
                    TabIndex="18">
                </telerik:RadTextBox>
            </td>

            <td style="height: 30px; width: 85px;">
                <asp:Label ID="lblInsurancePolicyValidity" runat="server" Text="Validity"></asp:Label>
            </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
              <telerik:RadDatePicker ID="txtInsurancePolicyValidity" runat="server" 
                    Culture="en-US" TabIndex="19" MinDate="1111-01-01">
<Calendar ID="Calendar6" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>
<DateInput DisplayDateFormat="dd/MM/yyyy" runat="server" DateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="19"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="19"></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
             <td style="height: 30px; width: 85px;"> </td>
      </tr>
           <%--'-------Heading Row--------'--%>
           <tr  style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin; z-index: auto;" 
              visible="true";>
       <th colspan ="5" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080;" >Education & Skills</th>
       </tr>
           <tr>
            <td class="style4">
                <asp:Label ID="lblLastDegree" runat="server" Text="Last Degree"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtLastDegree" Runat="server" Skin="WebBlue" 
                    TabIndex="20">
                </telerik:RadTextBox>
            </td>

            <td style="height: 30px; width: 85px;">
                <asp:Label ID="lblYear" runat="server" Text="Year"></asp:Label>
            </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                <telerik:RadTextBox ID="txtLastDegreeYear" Runat="server" Skin="WebBlue" 
                    TabIndex="21">
                </telerik:RadTextBox>
            </td>
             <td style="height: 30px; width: 85px;"> </td>
            </tr>
           <tr>
            <td class="style4">
                <asp:Label ID="lblLanguages" runat="server" Text="Languages"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                 <telerik:RadComboBox ID="cmbLanguages" Runat="server" 
         CheckBoxes="True" Skin="WebBlue" TabIndex="22">
         <Items>
              <telerik:RadComboBoxItem Value="0" Text="German" />
              <telerik:RadComboBoxItem Value="1" Text="English" />
              <telerik:RadComboBoxItem Value="2" Text="French" />
              <telerik:RadComboBoxItem Value="3" Text="Italian" />
              <telerik:RadComboBoxItem Value="4" Text="Spanish" />
              <telerik:RadComboBoxItem Value="5" Text="Portuguese" />
              <telerik:RadComboBoxItem Value="6" Text="Chinese" />
              <telerik:RadComboBoxItem Value="7" Text="Korean" />
              <telerik:RadComboBoxItem Value="8" Text="Vietnames" />
              <telerik:RadComboBoxItem Value="9" Text="Urdu" />
              </Items>
              </telerik:RadComboBox>
            </td>
            <td style="height: 30px; width: 85px;"> </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;"> </td>
             <td style="height: 30px; width: 85px;"> </td>
           </tr>
           <tr>
            <td class="style4">
                <asp:Label ID="lblTechnicalSkills" runat="server" Text="Technical Skills"></asp:Label>
            </td>
             <td class="TopHeaderTd3" style="width: 365px; height: 30px;" colspan="5">
           <telerik:RadTextBox ID="txtTechnicalSkills" Runat="server" Skin="WebBlue" 
                     Width="700px" TabIndex="23">
                </telerik:RadTextBox>
                </td> 
           </tr>
           <tr>
            <td class="style4">
                <asp:Label ID="lblComputerSkills" runat="server" Text="Computer Skills"></asp:Label>
            </td>
           <td class="TopHeaderTd3" style="width: 365px; height: 30px;" colspan="5">
           <telerik:RadTextBox ID="txtComputerSkills" Runat="server" Skin="WebBlue" 
                   Width="700px" TabIndex="24">
                </telerik:RadTextBox>
                </td>
       </tr>
     <%--'-------Heading Row--------'--%>
        <tr  style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin; z-index: auto;" 
              visible="true";>
        <th colspan ="5" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080;" >Organizational Profile</th>
            </tr>
            <tr>
            <td class="style4">
                <asp:Label ID="lblDateofJoining" runat="server" Text="Date of Joining"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
               <telerik:RadDatePicker ID="txtDateofJoining" runat="server" Culture="en-US" 
                    TabIndex="25" MinDate="1111-01-01">
<Calendar ID="Calendar2" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>
<DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="25"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="25"></DatePopupButton>
                </telerik:RadDatePicker>
            </td>

            <td style="height: 30px; width: 85px;">
                <asp:Label ID="lblPostedat" runat="server" Text="Posted at"></asp:Label>
            </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                <telerik:RadTextBox ID="txtPostedat" Runat="server" Skin="WebBlue" 
                    TabIndex="26">
                </telerik:RadTextBox>
            </td>
               <td style="height: 30px; width: 85px;">  </td>
               
        </tr>
            <tr>
             <td class="style4">
              <asp:Label ID="lblDesignation" runat="server" Text="Designation"></asp:Label>
              </td>
            <td style="height: 30px; width: 85px;"> 
            <telerik:RadTextBox ID="txtDesignation" Runat="server" Skin="WebBlue" TabIndex="27">
                </telerik:RadTextBox>
             </td>        
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="lblPrincipalGroup" runat="server" Text="Principal Group"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtPrincipalGroup" Runat="server" Skin="WebBlue" 
                    TabIndex="28">
                </telerik:RadTextBox>
            </td>
   <td style="height: 30px; width: 85px;">  </td>        
       </tr>
        <tr>
         <td class="style4">
                <asp:Label ID="lblECPCode" runat="server" Text="ECP Code"></asp:Label>
            </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                <telerik:RadTextBox ID="txtECPCode" Runat="server" Skin="WebBlue" TabIndex="29">
                </telerik:RadTextBox>
            </td>
             <td style="height: 30px; width: 85px;">
                <asp:Label ID="lblHKCode" runat="server" Text="HK Code"></asp:Label>
              </td>
            <td style="height: 30px; width: 85px;">
               <telerik:RadTextBox ID="txtHKCode" Runat="server" Skin="WebBlue" TabIndex="30" >
                </telerik:RadTextBox>
              </td>
                 <td style="height: 30px; width: 85px;">  </td>
        </tr>
            <tr>
            <td class="style4">
                <asp:Label ID="lblBankAccountNo" runat="server" Text="Bank Account No"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtBankAccountNo" Runat="server" Skin="WebBlue" 
                    TabIndex="31">
                </telerik:RadTextBox>
            </td>
            <td style="height: 30px; width: 85px;">   </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;">   </td>
                  <td style="height: 30px; width: 85px;">  </td>    
               
        </tr>

         <%--'-------Heading Row--------'--%>
         <tr  style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin; z-index: auto;" 
              visible="true";>
        
            <th colspan ="3" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080;" >Payroll & Package</th>
                     <th colspan ="3" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080;">Deduction</th>    
            </tr>
            <tr>
            <td class="style4">
                <asp:Label ID="lblBasic" runat="server" Text="Basic"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
             <%-- <telerik:RadNumericTextBox ID="txtBasic" Runat="server" Skin="WebBlue" 
                    AutoPostBack="true"  TabIndex="32"  Value="0.00">
              <NumberFormat ZeroPattern="n" ></NumberFormat>
                  </telerik:RadNumericTextBox>--%>
                   <telerik:RadTextBox ID="txtBasic" Runat="server" Skin="WebBlue" TabIndex="32"  AutoPostBack="true" >
                </telerik:RadTextBox>
            </td>
          <td style="height: 30px; width: 85px;">
                <asp:Label ID="lblEOBI" runat="server" Text="EOBI"></asp:Label>
            </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;">

               <%-- <telerik:RadNumericTextBox ID="txtEOBI" Runat="server" Skin="WebBlue" 
                    AutoPostBack="true" TabIndex="38" >
               <NumberFormat ZeroPattern="n"></NumberFormat>
                </telerik:RadNumericTextBox>--%>
                 <telerik:RadTextBox ID="txtEOBI" Runat="server" Skin="WebBlue" TabIndex="38"  AutoPostBack="true" >
                </telerik:RadTextBox>
            </td>
                 <td style="height: 30px; width: 85px;">  </td> 
            </tr>
            <tr>
            <td class="style4">
                <asp:Label ID="lblConvAllowance" runat="server" Text="Conv. Allowance"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <%--<telerik:RadNumericTextBox ID="txtConvAllowance" Runat="server" Skin="WebBlue" 
                    AutoPostBack="true" TabIndex="33">
                 <NumberFormat ZeroPattern="n"></NumberFormat>
                </telerik:RadNumericTextBox>--%>
                <telerik:RadTextBox ID="txtConvAllowance" Runat="server" Skin="WebBlue" TabIndex="33"  AutoPostBack="true" >
                </telerik:RadTextBox>
            </td>
             <td style="height: 30px; width: 85px;">
                <asp:Label ID="lblTax" runat="server" Text="Tax"></asp:Label>
            </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
               <%-- <telerik:RadNumericTextBox ID="txtTax" Runat="server" Skin="WebBlue" 
                    AutoPostBack="true" TabIndex="39" Value="0.00">
            <NumberFormat ZeroPattern="n"></NumberFormat>
                </telerik:RadNumericTextBox>--%>
                 <telerik:RadTextBox ID="txtTax" Runat="server" Skin="WebBlue" TabIndex="39"   AutoPostBack="true">
                </telerik:RadTextBox>
            </td>
                  <td style="height: 30px; width: 85px;">  </td> 
             </tr>
            <tr>
            <td class="style4">
                <asp:Label ID="lblMobileAllowance" runat="server" Text="Mobile Allowance"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
               <%-- <telerik:RadNumericTextBox ID="txtMobileAllowance" Runat="server" 
                    Skin="WebBlue" AutoPostBack="true" TabIndex="34" Value="0.00">
              <NumberFormat ZeroPattern="n"></NumberFormat>
                </telerik:RadNumericTextBox>--%>
                 <telerik:RadTextBox ID="txtMobileAllowance" Runat="server" Skin="WebBlue" TabIndex="33"  AutoPostBack="true" >
                </telerik:RadTextBox>
            </td>
            <td style="height: 30px; width: 85px;"> 
             <asp:Label ID="lblOther" runat="server" Text="Other"></asp:Label>
              </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;">  
          <%--  <telerik:RadNumericTextBox ID="txtOther" Runat="server" Skin="WebBlue" 
                    AutoPostBack ="true" TabIndex="40" Value="0.00">
           <NumberFormat ZeroPattern="n"></NumberFormat>
                </telerik:RadNumericTextBox>--%>
                <telerik:RadTextBox ID="txtOther" Runat="server" Skin="WebBlue" TabIndex="40"  AutoPostBack="true">
                </telerik:RadTextBox>
             </td>
                  <td style="height: 30px; width: 85px;">  </td> 
             </tr>
            <tr>
            <td class="style4">
                <asp:Label ID="lblOtherAllowance" runat="server" Text="Other Allowance"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
               <%-- <telerik:RadNumericTextBox ID="txtOtherAllowance" Runat="server" Skin="WebBlue" 
                    AutoPostBack="true" TabIndex="35" Value="0.00">
               <NumberFormat ZeroPattern="n"></NumberFormat>
                </telerik:RadNumericTextBox>--%>

                 <telerik:RadTextBox ID="txtOtherAllowance" Runat="server" Skin="WebBlue" TabIndex="35"  AutoPostBack="true" >
                </telerik:RadTextBox>
            </td>
            <td style="height: 30px; width: 85px;"> </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;"> </td>
                <td style="height: 30px; width: 85px;">  </td>       
             </tr>
            <tr>
            <td class="style4">
                <asp:Label ID="lblMiscAllowance" runat="server" Text="Misc Allowance"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
               <%-- <telerik:RadNumericTextBox ID="txtMiscAllowance" Runat="server" Skin="WebBlue" 
                    AutoPostBack="true" TabIndex="36" Value="0.00">
                  <NumberFormat ZeroPattern="n"></NumberFormat>
                </telerik:RadNumericTextBox>--%>
                <telerik:RadTextBox ID="txtMiscAllowance" Runat="server" Skin="WebBlue" TabIndex="36"  AutoPostBack="true">
                </telerik:RadTextBox>
            </td>
            <td style="height: 30px; width: 85px;">    </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;">   </td>
                  
                 <td style="height: 30px; width: 85px;">  </td> 
        </tr>
            <tr>
            <td class="style4">
                <asp:Label ID="lblGrossSum" runat="server" Text="Gross Sum"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <%--<telerik:RadNumericTextBox ID="txtGrossSum" Runat="server" Skin="WebBlue" 
                    ReadOnly="True" TabIndex="37" Value="0.00">
                 <NumberFormat ZeroPattern="n"></NumberFormat>
                </telerik:RadNumericTextBox>--%>
                 <telerik:RadTextBox ID="txtGrossSum" Runat="server" Skin="WebBlue" TabIndex="37"  AutoPostBack="true">
                </telerik:RadTextBox>
            </td>
            <td style="height: 30px; width: 85px;"> 
             <asp:Label ID="lblNetSalary" runat="server" Text="Net Salary"></asp:Label>
              </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;">  
           <%-- <telerik:RadNumericTextBox ID="txtNetSalary" Runat="server" Skin="WebBlue" 
                    ReadOnly="True" TabIndex="41" Value="0.00">
            <NumberFormat ZeroPattern="n"></NumberFormat>
                </telerik:RadNumericTextBox>--%>
                 <telerik:RadTextBox ID="txtNetSalary" Runat="server" Skin="WebBlue" TabIndex="41"  AutoPostBack="true">
                </telerik:RadTextBox>
             </td>
                 
                  <td style="height: 30px; width: 85px;">  </td>
        </tr>

          <%--'-------Heading Row--------'--%>
            <tr  style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin; z-index: auto;" 
              visible="true";>
        
            <th colspan ="5" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080;" >Leave Management</th>
            </tr>
            <tr>
            <td class="style4">
                <asp:Label ID="lblFiscalYear" runat="server" Text="Fiscal Year"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtLeaveFiscalYear" Runat="server" Skin="WebBlue" 
                    TabIndex="42">
                </telerik:RadTextBox>
            </td>

            <td style="height: 30px; width: 85px;">
                <asp:Label ID="lblLeaveGranted" runat="server" Text="Leave Granted"></asp:Label>
            </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                <telerik:RadTextBox ID="txtLeaveGranted" Runat="server" Skin="WebBlue" 
                    TabIndex="43">
                </telerik:RadTextBox>

               <%-- <telerik:RadNumericTextBox ID="txtLeaveGranted" Runat="server" Skin="WebBlue" TabIndex="43"  Value="0.00">
              <NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>
                  </telerik:RadNumericTextBox>--%>
            </td>
                   
                 <td style="height: 30px; width: 85px;">  </td> 
        </tr>
            <tr>
            <td class="style4"> 
             <asp:Label ID="lblLeaveAvailed" runat="server" Text="Leave Availed"></asp:Label>
               </td>
            <td style="height: 30px; width: 85px;"> 
             <telerik:RadTextBox ID="txtLeaveAvailed" Runat="server" Skin="WebBlue" 
                    TabIndex="44" >
                </telerik:RadTextBox>
               
                </td>  
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="lblMedicalLeave" runat="server" Text="Medical Leave"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtMedicalLeave" Runat="server" Skin="WebBlue" 
                    TabIndex="45"  >
                </telerik:RadTextBox>
            </td>
             <td style="height: 30px; width: 85px;">  </td>
            </tr>
        <tr>
         <td class="style4">
                <asp:Label ID="lblCasualLeave" runat="server" Text="Casual Leave"></asp:Label>
            </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                <telerik:RadTextBox ID="txtCasualLeave" Runat="server" Skin="WebBlue" 
                    TabIndex="46" >
                </telerik:RadTextBox>
                 
            </td>
        </tr>
            <tr>
            <td class="style4">
                <asp:Label ID="lblInstruction" runat="server" Text="Instruction"></asp:Label>
            </td>
           <td class="TopHeaderTd3" style="width: 365px; height: 30px;" colspan="5">
           <telerik:RadTextBox ID="txtInstruction" Runat="server" Skin="WebBlue"   
                   Width="700px" TabIndex="46" >
                </telerik:RadTextBox>
                </td>                  
       </tr>
        <%--'-------Heading Row--------'--%>
         <tr  style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin; z-index: auto;" 
              visible="true";>
        
            <th colspan ="5" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080;" >Health & Safety Management</th>
            </tr>
            <tr>
            <td class="style4">
                <asp:Label ID="lblBloodGroup" runat="server" Text="Blood Group"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtBloodGroup" Runat="server" Skin="WebBlue" 
                    TabIndex="47">
                </telerik:RadTextBox>
            </td>
            <td style="height: 30px; width: 85px;"> 
              <asp:Label ID="lblEyeSight" runat="server" Text="Eye Sight"></asp:Label>
            </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;"> 
             <telerik:RadTextBox ID="txtEyeSight" Runat="server" Skin="WebBlue" TabIndex="48">
                </telerik:RadTextBox>
            </td>
         </tr>
            <tr>
            <td class="style4">
               <asp:Label ID="lblAllergic" runat="server" Text="Allergic"></asp:Label>
              </td>
            <td style="height: 30px; width: 85px;"> 
             <telerik:RadTextBox ID="txtAllergic" Runat="server" Skin="WebBlue" TabIndex="49">
                </telerik:RadTextBox>
             </td>    
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="lblSugarLevel" runat="server" Text="Sugar Level"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                    <telerik:RadComboBox ID="cmbSugarLevel" Runat="server" AutoPostBack="True" 
                    Skin="WebBlue" TabIndex="50">
                   <Items>
                 <telerik:RadComboBoxItem Value="0" Text="Normal"/>                     
                <telerik:RadComboBoxItem Value="1" Text="High"/>
                 <telerik:RadComboBoxItem Value="2" Text="Low"/>
                 </Items>
                </telerik:RadComboBox>
                </ContentTemplate>
                 </asp:UpdatePanel>
            </td>
         </tr>
        <tr>
         <td class="style4"> 
              <asp:Label ID="lblBloodPressure" runat="server" Text="Blood Pressure"></asp:Label>
            </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;"> 
            <asp:UpdatePanel ID="UpdatePanel3" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                    <telerik:RadComboBox ID="cmbBloodPressure" Runat="server" AutoPostBack="True" 
                    Skin="WebBlue" TabIndex="51">
                     <Items>   
                      <telerik:RadComboBoxItem Value="0" Text="Normal"/>
                <telerik:RadComboBoxItem Value="1" Text="High"/>
                 <telerik:RadComboBoxItem Value="2" Text="Low"/>
                 </Items>
                </telerik:RadComboBox>
                </ContentTemplate>
                 </asp:UpdatePanel>
            </td>
             <td style="height: 30px; width: 85px;">
               <asp:Label ID="lblIsSmoke" runat="server" Text="Is Smoke"></asp:Label>
              </td>
            <td style="height: 30px; width: 85px;"> 
              <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                    <telerik:RadComboBox ID="cmbIsSmoke" Runat="server" AutoPostBack="True" 
                    Skin="WebBlue" TabIndex="52">
                    <Items>   
                <telerik:RadComboBoxItem Value="0" Text="Yes"/>
                 <telerik:RadComboBoxItem Value="1" Text="No"/>
                 </Items>
                </telerik:RadComboBox>
                </ContentTemplate>
                 </asp:UpdatePanel>
             </td> 
        </tr>
            <tr>
            <td class="style4">
                <asp:Label ID="lblFamilyDoctorContact" runat="server" Text="Family Doctor Contact"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtFamilyDoctorContact" Runat="server" Skin="WebBlue" 
                    TabIndex="53">
                </telerik:RadTextBox>
            </td>
            <td style="height: 30px; width: 85px;"> 
              <asp:Label ID="lblDoctorName" runat="server" Text="Doctor Name"></asp:Label>
            </td>
            <td class="TopHeaderTd3" style="width: 250px; height: 30px;" colspan="3"> 
             <telerik:RadTextBox ID="txtFaimalyDoctorName" Runat="server" Skin="WebBlue"  
                    Width="400px" TabIndex="54">
                </telerik:RadTextBox>
            </td> 
        </tr>
            <tr>
            <td class="style4">
                <asp:Label ID="lblLastDentalCheckup" runat="server" Text="Last Dental Checkup"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                  <telerik:RadDatePicker ID="txtLastDentalCheckup" runat="server" Culture="en-US" 
                      TabIndex="55" MinDate="1111-01-01">
<Calendar ID="Calendar7" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>
<DateInput DisplayDateFormat="dd/MM/yyyy" runat="server" DateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="55"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="55"></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td style="height: 30px; width: 85px;"> 
              <asp:Label ID="lblEmployeeLastVacationDate" runat="server" Text="Employee Last Vacation Date"></asp:Label>
              </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;"> 
             <telerik:RadDatePicker ID="txtEmployeeLastVacationDate" runat="server" 
                    Culture="en-US" TabIndex="56" MinDate="1111-01-01">
<Calendar ID="Calendar9" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>
<DateInput DisplayDateFormat="dd/MM/yyyy" runat="server" DateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="56"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="56"></DatePopupButton>
                </telerik:RadDatePicker>
              </td>
              </tr>
              <tr>
             <td class="style4">
               <asp:Label ID="lblLastPhysicalCheckup" runat="server" Text="Last Physical Checkup"></asp:Label>
              </td>
            <td style="height: 30px; width: 85px;"> 
              <telerik:RadDatePicker ID="txtLastPhysicalCheckup" runat="server" Culture="en-US" 
                    TabIndex="57" MinDate="1111-01-01">
<Calendar ID="Calendar8" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>
<DateInput DisplayDateFormat="dd/MM/yyyy" runat="server" DateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="57"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="57"></DatePopupButton>
                </telerik:RadDatePicker>
             </td>        
        </tr>
         <tr>
            <td valign ="top" class="style4">
                <asp:Label ID="lblCriticalDiagonasis" runat="server" Text="Critical Diagonasis"></asp:Label>
            </td>
           <td class="TopHeaderTd3" style="width: 365px; height: 30px;" colspan="5">
           <telerik:RadTextBox ID="txtCriticalDiagonasis" Runat="server" Skin="WebBlue" 
                   height="60px"   Width="700px" TextMode ="MultiLine" TabIndex="58" >
                </telerik:RadTextBox>
                </td>                  
         </tr>
          <tr>
        <td class="style5"></td>
        </tr>
     <tr>
       <td colspan="2" align="right"></td>
            <td colspan="2" align="right">
                <telerik:RadButton ID="btnSave" runat="server" Text="Save" 
                    Skin="WebBlue" TabIndex="59">
                </telerik:RadButton>
        </td>
                <td>&nbsp;
                <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" 
                 Skin="WebBlue" TabIndex="60">
                </telerik:RadButton>
             &nbsp;</td>
             <td></td>
           </tr>     
     </table>
  </asp:Content> 