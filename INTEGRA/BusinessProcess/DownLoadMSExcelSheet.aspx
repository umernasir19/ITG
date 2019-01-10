<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeBehind="DownLoadMSExcelSheet.aspx.vb" Inherits="Integra.DownLoadMSExcelSheet" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td>
                MS-Excel Type:
            </td>
            <td>
                <asp:UpdatePanel ID="upcmbYYear" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadComboBox ID="cmbYYear" runat="server" AutoPostBack="True" Skin="WebBlue">
                            <Items>
                                <telerik:RadComboBoxItem Value="0" Text="2015 Item Vise" />
                                <telerik:RadComboBoxItem Value="1" Text="2015 PO. Vise" />
                                <telerik:RadComboBoxItem Value="2" Text="2014 Item Vise" />
                                <telerik:RadComboBoxItem Value="3" Text="2014 PO. Vise" />
                                <telerik:RadComboBoxItem Value="4" Text="2013 Item Vise" />
                                <telerik:RadComboBoxItem Value="5" Text="2013 PO. Vise" />
                            </Items>
                        </telerik:RadComboBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <telerik:RadButton ID="btnsupplychn" runat="server" Text="Download Order Status"
                    Skin="WebBlue">
                </telerik:RadButton>
            </td>
        </tr>
    </table>
</asp:Content>
