<%@ Page Language="vb" MasterPageFile="~/MasterPage.master"  AutoEventWireup="false" CodeBehind="VAFapproval.aspx.vb" Inherits="Integra.VAFapproval" %>
 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <table width="100%">
 <tr>
 <td>
 Supplier
 </td>
 <td>
      <asp:UpdatePanel ID="UpcmbSupplier" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList CssClass="combo" style="margin-left: 15px;"  ID="cmbSupplier" Width="160" runat="server" AutoPostBack="True">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
 </td>
 <td>
 Supplier Code
 </td>
 <td>
    <asp:TextBox ID="txtCode"    runat="server"></asp:TextBox>
 </td>
 <td>
 Supplier Status
 </td>
 <td>
   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList CssClass="combo" style="margin-left: 15px;"  ID="cmbSupplierStatus" Width="110" runat="server" AutoPostBack="True">
                        <asp:ListItem Value="0" Text="Active"></asp:ListItem>
                         <asp:ListItem Value="1" Text="Deactive"></asp:ListItem>
                        <asp:ListItem Value="2" Text="No Decision"></asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
 </td>
 </tr>
 </table>
 <table width="100%">
 <tr>
 <td>
 Remarks
 </td>
 <td>
  <asp:TextBox ID="txtRemarks"  Width="600"  runat="server" TextMode="MultiLine"></asp:TextBox>
 </td>
 </tr>
 </table>
   <table width="100%">
        <tr>
       
        <td align="center">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" />
                       
                 &nbsp;
                       
                 <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" />
            </td>
           
        </tr>
    </table>
  </asp:Content> 
