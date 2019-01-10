<%@ Page Title="Role Setup" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="RoleSetup.aspx.vb" Inherits="Integra.RoleSetup" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table>
        <tr style="border-bottom-style: solid; height: 50px; border-bottom-color: #00509F;
            border-bottom-width: thin;" visible="true">
            <th colspan="1" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                Role Setup
            </th>
        </tr>
        </table><table>

        <tr>
            <td style="width: 110px;">
                Department.
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadComboBox ID="cmbDepartment" runat="server" AutoPostBack="false" Skin="WebBlue">
                </telerik:RadComboBox>
            </td>
            </tr>

            </table> 
            <br />
            <table>

        <tr>
            <td style="width: 110px;">
                Designation.
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtDesignation" style="text-transform :uppercase ;" runat="server" Skin="WebBlue" Width="160px">
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
                            </tr>
            </table>

</asp:Content>

