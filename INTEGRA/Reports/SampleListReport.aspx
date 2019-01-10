<%@ Page Title="Sample List Report" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="SampleListReport.aspx.vb" Inherits="Integra.SampleListReport" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
 <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table  >
<tr style="border-bottom-style: solid; height :50px; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="6" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                Sample List Sheet
            </th>
        </tr>
          <tr>
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblDal" runat="server" Text="DAL No"></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtDal" runat="server" Skin="WebBlue" Width="105px" Visible="false">
                </telerik:RadTextBox>
                <telerik:RadComboBox ID="cmbDal" runat="server" AutoPostBack="true" Skin="WebBlue">
                </telerik:RadComboBox>
            </td>
        </tr>
          <tr>


         <td style="width: 110px;">
                Style.
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadComboBox ID="cmbStyle" runat="server" AutoPostBack="true" Skin="WebBlue"
                    >
                </telerik:RadComboBox>
            </td>




              <td style="width: 110px;">
                Description.
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadComboBox ID="cmbDescription" runat="server" AutoPostBack="true" Skin="WebBlue"
                    >
                </telerik:RadComboBox>
            </td>




       </tr>     
 <tr>
<td >
   
    <asp:Label ID="lblForm" runat="server" Text="From :"></asp:Label>
   </td>
<td  valign="top">
<telerik:RadDatePicker ID="txtDateFrom" runat="server" Culture="en-US">
<Calendar ID="Calendar1" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" runat="server"></Calendar>
<DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" runat="server"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
</telerik:RadDatePicker>
 

</td>
   <td  >
        </td>

<td  >

    <asp:Label ID="lblTo" runat="server" Text="To :"></asp:Label>
</td>

<td  valign="top">
<telerik:RadDatePicker ID="txtDateTo" runat="server" Culture="en-US">
<Calendar ID="Calendar2" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" runat="server"></Calendar>
<DateInput ID="DateInput2" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" runat="server"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
</telerik:RadDatePicker>
  
</td>
<td>      
    </td>
    <td>
    </td>
</tr>
 <tr>
  <td style="height: 10px"></td>
  </tr>
  
 <tr>
  <td style="height: 10px"></td>
  </tr>
<td ></td>
<tr>
<td></td>
<td  >
  <telerik:RadButton ID="btnGetReport" runat="server" Text="Download Report" Skin="WebBlue"  >
  </telerik:RadButton></td>
</tr>

</table> 
 
</asp:Content> 





