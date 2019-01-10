<%@ Page Title="User Setup" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="UserSetup.aspx.vb" Inherits="Integra.UserSetup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table>
        <tr style="border-bottom-style: solid; height: 50px; border-bottom-color: #00509F;
            border-bottom-width: thin;" visible="true">
            <th colspan="1" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                User Setup
            </th>
        </tr>
        </table><table>

        <tr>
            <td style="width: 110px;">
                Designation.
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadComboBox ID="cmbDesignation" runat="server" AutoPostBack="true" Skin="WebBlue">
                </telerik:RadComboBox>
            </td>

            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                 <telerik:RadTextBox ID="txtDepartment" ReadOnly ="true"  style="text-transform :uppercase ;" runat="server" Skin="WebBlue" Width="160px">
                                    </telerik:RadTextBox>
            </td>
            </tr>


        <tr>
            <td style="width: 110px;">
                User Id.
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtUserId" style="text-transform :uppercase ;" runat="server" Skin="WebBlue" Width="160px">
                                    </telerik:RadTextBox>
            </td>
            </tr>
            <tr>
            <td style="width: 110px;">
                Password.
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtPassword" style="text-transform :uppercase ;" runat="server" Skin="WebBlue" Width="160px">
                                    </telerik:RadTextBox>
            </td>
            </tr>


            </table> 

            <br />
           
         
            <table  align ="center" >
             <tr>
                                <td>
                                    <telerik:RadButton ID="btnSave" runat="server" Text="Save" Skin="WebBlue"
                                        Width="100px" Visible ="true" >
                                    </telerik:RadButton>
                                </td>
                                <td>
                                    <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" Skin="WebBlue"
                                        Width="100px" Visible ="true" >
                                    </telerik:RadButton>
                                </td>

                                 <td>
                                    <asp:Label ID ="lblRMUserId" runat ="server" Visible ="false" Text ="0"
                                    ></asp:Label> 
                                </td>
                            </tr>
            </table>

</asp:Content>


