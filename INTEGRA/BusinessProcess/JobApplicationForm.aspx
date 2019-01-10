<%@ Page Language="vb"   AutoEventWireup="false" CodeBehind="JobApplicationForm.aspx.vb" Inherits="Integra.JobApplicationForm" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
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
</head>
<body>
    <form id="form1" runat="server">
     <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>

    <div class ="table">
<table>
  
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;" 
              visible="true";>
                   <th colspan ="6" align="left"   style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080; width:600px;">Personal Profile</th>
                               
                    </tr>

             <tr>
      <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblApplied" runat="server" Text="Applied as:"></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
              <telerik:RadTextBox ID="txtApplied" Runat="server" Skin="WebBlue" TabIndex="1">
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
           <tr>
        <td style="width: 128px; height: 30px;">
                <asp:Label ID="Label4" runat="server" Text="Father Name"></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtFatherName" Runat="server" Skin="WebBlue" TabIndex="1">
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
                <asp:Label ID="Label1" runat="server" Text="City:"></asp:Label>
            </td>
           <td class="TopHeaderTd3"  >
           <telerik:RadTextBox ID="txtCity" Runat="server" Skin="WebBlue" 
                    TabIndex="4">
                </telerik:RadTextBox>
                </td> 
            <td class="style4">
                <asp:Label ID="lblCNIC" runat="server" Text="CNIC"></asp:Label>
            </td>
            <td style="width: 128px; height: 30px;">
                <%--'-------Heading Row--------'--%>
                <telerik:RadMaskedTextBox ID="txtCNIC" runat="server" Mask="#####-#######-#" 
                    TabIndex="11">
                </telerik:RadMaskedTextBox>

            </td>
        </tr>
            <tr>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="lblResidenceAddress" runat="server" Text="Residence Address"></asp:Label>
            </td>
           <td class="TopHeaderTd3" style="width: 365px; height: 30px;" colspan="4">
           <telerik:RadTextBox ID="txtResidenceAddressA" Runat="server" Skin="WebBlue" 
                   Width="700px" TabIndex="4">
                </telerik:RadTextBox>
                </td> 
        </tr>
            <tr>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            </td>
           <td class="TopHeaderTd3" style="width: 365px; height: 30px;" colspan="4">
           <telerik:RadTextBox ID="txtResidenceAddressB" Runat="server" Skin="WebBlue"   
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
             <td style="height: 30px; width: 128px;">
                <asp:Label ID="Label3" runat="server" Text="Gender"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
               <asp:UpdatePanel ID="UpdatePanel6" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                    <telerik:RadComboBox ID="cmbGender" Runat="server" AutoPostBack="True" 
                    Skin="WebBlue" TabIndex="10">
                    <Items>   
               <telerik:RadComboBoxItem Value="0" Text="Male"/>
                <telerik:RadComboBoxItem Value="1" Text="Female"/>            
                                  </Items>
                </telerik:RadComboBox>
                </ContentTemplate>
                 </asp:UpdatePanel>
            </td>
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
                <asp:Label ID="Label5" runat="server" Text="Institution"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtInstitution" Runat="server" Skin="WebBlue" 
                    TabIndex="20">
                </telerik:RadTextBox>
            </td>

            <td style="height: 30px; width: 85px;">
                <asp:Label ID="Label6" runat="server" Text="%age Marks"></asp:Label>
            </td>
            <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                <telerik:RadTextBox ID="txtmarks" Runat="server" Skin="WebBlue" 
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
        <th colspan ="5" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080;" >
        Last Job Particulars (if any)</th>
            </tr>
            <tr>
            <td class="style4">
                <asp:Label ID="lblOrganization" runat="server" Text="Organization"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
               <telerik:RadTextBox ID="txtOrganization" Runat="server" Skin="WebBlue" 
                    TabIndex="26" Width="300">
                </telerik:RadTextBox>
            </td>
         </tr>
          <tr>
            <td class="style4">
                <asp:Label ID="Label7" runat="server" Text="Location"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
               <telerik:RadTextBox ID="txtLocation" Runat="server" Skin="WebBlue" 
                    TabIndex="26"  Width="300">
                </telerik:RadTextBox>
            </td>
         </tr>
          <tr>
            <td class="style4">
                <asp:Label ID="Label8" runat="server" Text="Designation"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
               <telerik:RadTextBox ID="txtDesignationn" Runat="server" Skin="WebBlue" 
                    TabIndex="26"  Width="300">
                </telerik:RadTextBox>
            </td>
         </tr>
          <tr>
            <td class="style4">
                <asp:Label ID="Label9" runat="server" Text="Duration:(In Years)"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
               <telerik:RadTextBox ID="txtDuration" Runat="server" Skin="WebBlue" 
                    TabIndex="26"  Width="300">
                </telerik:RadTextBox>
            </td>
         </tr>
           <tr>
            <td class="style4">
                <asp:Label ID="Label10" runat="server" Text="Nature of Job:"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
               <telerik:RadTextBox ID="txtNatureofJob" Runat="server" Skin="WebBlue" 
                    TabIndex="26"  Width="300">
                </telerik:RadTextBox>
            </td>
         </tr>
          <tr>
            <td class="style4">
                <asp:Label ID="Label11" runat="server" Text="Per Month Salary (In Digits):"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
               <telerik:RadTextBox ID="txtPerMonthSalary" Runat="server" Skin="WebBlue" 
                    TabIndex="26" >
                </telerik:RadTextBox>
            </td>
         </tr>
         <tr>
            <td class="style4">
                <asp:Label ID="Label12" runat="server" Text="Reason for quitting:"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
               <telerik:RadTextBox ID="txtReasonforquitting" Runat="server" Skin="WebBlue" 
                    TabIndex="26"  Width="300">
                </telerik:RadTextBox>
            </td>
         </tr>
      <tr>
            <td class="style4">
                <asp:Label ID="Label13" runat="server" Text="Remarks:"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
               <telerik:RadTextBox ID="txtRemarks" Runat="server" Skin="WebBlue" 
                    TabIndex="26"  Width="300">
                </telerik:RadTextBox>
            </td>
         </tr>
     </table>
     <table>
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

    </form>
</body>
</html>