<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeBehind="ChartOfAccountEntry.aspx.vb" Inherits="Integra.ChartOfAccountEntry" %>
 <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <telerik:RadAjaxManager ID="radajaxmanager" runat ="server" >
 <AjaxSettings >
 <telerik:AjaxSetting AjaxControlID ="cmbAccountGroup">
 <UpdatedControls >
 <telerik:AjaxUpdatedControl ControlID ="cmbAccountSubGroup" />
 </UpdatedControls>
 </telerik:AjaxSetting>
 </AjaxSettings>
 </telerik:RadAjaxManager>
 <div>
 
    <table  >
    
         <tr>
<td>
</td>
<td class="ErrorMsg">
     
</td>
</tr>
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;" 
              visible="true";>
            <th  colspan ="6" align="left"   style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080;"  >Create Chart of Account </th>
         </tr>
         <tr>
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblAccountGroup" runat="server" Text="Account Group" 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td  style="width: 166px; height: 30px;">
                   <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                      <telerik:RadComboBox ID="cmbAccountGroup" Runat="server" AutoPostBack="True" 
                    Skin="WebBlue">
                </telerik:RadComboBox>
                   </ContentTemplate>
                 </asp:UpdatePanel>
                   </td>
                   </tr>
                   <tr>
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblAccountSubGroup" runat="server" Text="Account Sub Group" 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td class="style2">
               <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                  <telerik:RadComboBox ID="cmbAccountSubGroup" Runat="server" AutoPostBack="True" 
                    Skin="WebBlue">
                </telerik:RadComboBox>
                      </ContentTemplate>
                 </asp:UpdatePanel>
            </td>
          
         </tr>
        <tr>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="lblAccountType" runat="server" Text="Account Type"  Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 128px; height: 30px;">
              <telerik:RadTextBox ID="txtAccountType" Runat="server" Skin="WebBlue"  >
                </telerik:RadTextBox>
                </td> 
                 
            <td style="width: 128px; height: 30px;">
               
            </td>
            <td class="style2">
                
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