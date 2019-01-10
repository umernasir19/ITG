<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/DeversaMaster.master"
    CodeBehind="D_StyleLibraryMainView.aspx.vb" Inherits="Integra.D_StyleLibraryMainView" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" style="background-color: #dce2e4;">
        <tr>
            <td>
                <asp:DataList ID="DataList1" RepeatColumns="4" runat="server" Width="100%">
                    <ItemTemplate>
                        <div class="image_area">
                            <asp:HyperLink ID="hyplink" runat="server" NavigateUrl='<%#string.Format("D_StyleLibraryView.aspx?DstyleID={0}", Eval("DstyleID")) %>'
                                ToolTip="Click to view details of this style">
                                <div class="hide_image">
                                </div>
                                <div class="image">
                                    <div class="hide_image">
                                        <img src="img/teaserSize_L_fastview_Overlay.png" /></div>
                                    <asp:Image ID="imgForntThumbnail" ImageUrl='<%# Bind("Thumbnail_Fornt_List") %>'
                                        runat="server" />
                                </div>
                                <div class="title">
                                    <asp:Label ID="lblStyle" runat="server" Text='<%# Bind("Style") %>'></asp:Label></div>
                                <div class="price">
                                    <asp:Label ID="lblPrice" runat="server" Text='<%# Bind("Price") %>'></asp:Label></div>
                            </asp:HyperLink>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
        <tr>
            <td style="height: 20px">
            </td>
        </tr>
    </table>
</asp:Content>
