<%@ Page Title="Style Database" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="DPStyleDatabase.aspx.vb" Inherits="Integra.DPStyleDatabase" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function isNumericKey(e) {
            var charInp = window.event.keyCode;
            if (charInp > 31 && (charInp < 48 || charInp > 57)) {
                return false;
            }
            return true;
        }
        function isNumericKeyy(e) {
            var charInp = window.event.keyCode;
            if (charInp != 46 && (charInp < 48 || charInp > 57)) {
                return false;
            }
            return true;
        }
   
    </script>
    <table>
        <tr>
            <th colspan="" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Style Database
            </th>
        </tr>
    </table>
    <table>
        <tr>
            <td style="height: 30px; width: 0px;">
                <asp:Label ID="Label14" runat="server" Text="Style Code"></asp:Label>
            </td>
            <td style="width: 110px; height: 30px;">
                <telerik:RadTextBox ID="txtStyleCode" runat="server" AutoPostBack="false" ReadOnly="false"
                    Skin="WebBlue" Width="105px" input="Number">
                </telerik:RadTextBox>
            </td>
            <td>

              <telerik:RadComboBox ID="cmbOurStyle" runat="server" AutoPostBack="true" Skin="WebBlue">
               <Items>
        <telerik:RadComboBoxItem Text="Our Style" Value="Our Style" />
             <telerik:RadComboBoxItem Text="Buyer Style" Value="Buyer Style" />
      
    </Items>
                                    </telerik:RadComboBox>


               
            </td>
            <td>
                <asp:CheckBox ID="chkIsActive" runat="server" Visible ="false" ></asp:CheckBox>
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </td>
        </tr>

        <tr>
            <td style="height: 30px; width: 62px;">
                <asp:Label ID="Label2" runat="server" Text="Date"></asp:Label>
            </td>
            <td style="width: 200px; height: 30px;">
                <telerik:RadDatePicker ID="txtStyleDate" runat="server" Culture="en-US" Width="">
                    <Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                    </Calendar>
                    <DateInput ID="DateInput1" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="20%">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td style="width: 166px; height: 30px;" colspan="4">
                <telerik:RadTextBox ID="txtCompanyName" style="text-transform :uppercase ;" runat="server" AutoPostBack="false" ReadOnly="false"
                    Skin="WebBlue" Width="200px" input="Number">
                </telerik:RadTextBox>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
         <asp:panel ID ="pnlBuyer" runat ="server" Visible ="true" >
         <tr>
        
            <td style="height: 30px; width: 0px;">
                <asp:Label ID="Label7" runat="server" Text="Buyer"></asp:Label>
            </td>
            <td style="width: 110px; height: 30px;">
                <telerik:RadComboBox ID="cmbBuyer" runat="server" AutoPostBack="true" Skin="WebBlue"  >
              </telerik:RadComboBox>
            </td>
      
            </tr>
         <tr>

          <td style="height: 30px; width: 0px;">
                <asp:Label ID="Label8" runat="server" Text="Buyer Ref #"></asp:Label>
            </td>
            <td style="width: 110px; height: 30px;">
                <telerik:RadTextBox ID="txtBuyerReferenceNo" runat="server" AutoPostBack="false" ReadOnly="false"
                    Skin="WebBlue" Width="162px" input="Number"  >
                </telerik:RadTextBox>
            </td>
                 

        </tr>
         </asp:panel>
        <tr>
            <td style="height: 30px; width: 10px;">
                <asp:Label ID="Label3" runat="server" Text="Description"></asp:Label>
            </td>
            <td style="width: 185px; height: 30px;" colspan="3">
                <telerik:RadTextBox ID="txtDescription"  runat="server" AutoPostBack="false" ReadOnly="false"
                    Skin="WebBlue" Width="400px" input="Number" Style="width: 304px; text-transform :uppercase ;">
                </telerik:RadTextBox>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 30px; width: 10px;">
                <asp:Label ID="Label4" runat="server" Text="Estimated Time Required"></asp:Label>
            </td>
            <td style="width: 300px; height: 30px;" colspan="3">
                <telerik:RadTextBox ID="txtEstTimeReq" runat="server" AutoPostBack="false" ReadOnly="false"
                    Skin="WebBlue" Width="100px" input="Number" Style="width: 100px;">
                </telerik:RadTextBox>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <table>
     <tr>

        

           
            <td style="height: 40px; width: 300px;">
             <asp:Label ID="Label5" runat="server" Text="Front Picture"></asp:Label>
              
            </td>

             <td style="">
             <asp:Label ID="Label6" runat="server" Text="Back Picture"></asp:Label>
              
                </td>
            </tr>
    </table>
    <table>
        <tr>

         <td>
           
                                <asp:Image ID="Image1" Visible="true" runat="server" Height="176px" Width="228px"
                                    Style="margin-left: 2px; margin-top: 15px;" />
            </td>


             <td>
             <asp:Image ID="Image2" Visible="true" runat="server" Height="176px" Width="228px"
                                    Style="margin-left: 64px; margin-top: 15px;" />
            </td>
        </tr>

        </table><table>

       <tr>

            <td style="height: 40px; width: 295px;">
                <asp:FileUpload ID="FileUpload" runat="server" />
           
                <asp:Button ID="btnUpload" runat="server" Style="width: 70px; margin-left: -54px;"
                    Text="Upload" />
              <%--  <asp:UpdatePanel ID="UpPic" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFIlePicture" runat="server" Style="margin-left: 18px;" Text="Show Picture"
                            Visible="false"> </asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>--%>
            </td>

           
            <td>
                <asp:FileUpload ID="FileUpload2" runat="server" />
            
                <asp:Button ID="btnUpload2" runat="server" Style="width: 76px; margin-left: -52px;"
                    Text="Upload" />
            <%--    <asp:UpdatePanel ID="UpPic2" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFIlePicture2" runat="server" Style="margin-left: 18px;" Text="Show Picture"
                            Visible="false"> </asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>--%>
            </td>
           </tr>
    </table>
    <table>
        <tr>
            <td colspan="3" align="right">
                <telerik:RadButton ID="btnSave" runat="server" Text="Save" Skin="WebBlue">
                </telerik:RadButton>
            </td>
            <td>
                <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" Skin="WebBlue">
                </telerik:RadButton>
            </td>
        </tr>
        <tr>
            <td align="center">
              <asp:Label ID ="lblUserId" runat ="server" Visible ="false" Text="0"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
