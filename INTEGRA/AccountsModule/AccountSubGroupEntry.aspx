﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="AccountSubGroupEntry.aspx.vb" Inherits="Integra.AccountSubGroupEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
 
    <table  >
    
         <tr>
<td>
</td>
<td class="ErrorMsg">
    <asp:Label ID="lblMSG" Visible="false" runat="server" ></asp:Label>
</td>
</tr>
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;" 
              visible="true";>
            <th  colspan ="6" align="left"   style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080;"  >Create Account SubGroup </th>
         </tr>
         <tr>
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblAccountSubGroup" runat="server" Text="Account Sub Group" 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td  style="width: 166px; height: 30px;">
                   <telerik:RadTextBox ID="txtAccountSubGroup" Runat="server" Skin="WebBlue"  >
                </telerik:RadTextBox>
                   </td>
            <td style="width: 128px; height: 30px;">
                &nbsp;</td>
            <td class="style2">
               <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
                 </asp:UpdatePanel>
            </td>
          
         </tr>
           <tr>
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblAccountGroup" runat="server" Text="Account Group" 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td  style="width: 166px; height: 30px;">
                   <asp:UpdatePanel ID="UpdatePanel3" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                      <telerik:RadComboBox ID="cmbAccountSubGroup" Runat="server" AutoPostBack="True" 
                    Skin="WebBlue">
                </telerik:RadComboBox>
                   </ContentTemplate>
                 </asp:UpdatePanel>
                   </td>
            <td style="width: 128px; height: 30px;">
                &nbsp;</td>
            <td class="style2">
               <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                 </asp:UpdatePanel>
            </td>
          
         </tr>
      
  <tr>
  <td></td>
  <td>
     <telerik:RadButton ID="btnSave" runat="server" Text="Save" Skin="WebBlue">
                    </telerik:RadButton>
  
  </td>
  <td>
     <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" Skin="WebBlue">
                    </telerik:RadButton>
  </td>
  </tr>
 
        </table>

 
      </div> 
</asp:Content>