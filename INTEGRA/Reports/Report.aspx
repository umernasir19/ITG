<%@ Page Language="vb" MasterPageFile="~/MasterPage.master"  AutoEventWireup="false" CodeBehind="Report.aspx.vb" Inherits="Integra.Report" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
 <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Panel ID="Panel3" runat="server" Height="555px" Style="left: 2px; position: relative;
            top: 0px; z-index: 102;" Width="770px" ScrollBars="Both">
            &nbsp;<CR:CrystalReportViewer ID="CRViewer" runat="server" AutoDataBind="true" 
                Style="position: absolute; z-index: 111; left: 0px; top: 0px;" HasDrillUpButton="False"  BorderColor="Silver"  DisplayBottomToolbar="False" DisplayGroupTree="False" EnableDrillDown="False" HasToggleGroupTreeButton="False" HasViewList="False"  HasZoomFactorList="False" Width="350px" />
        </asp:Panel>
</asp:Content> 
