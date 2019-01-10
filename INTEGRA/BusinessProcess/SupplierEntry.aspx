<%@ Page Title="Supplier Entry" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="SupplierEntry.aspx.vb" Inherits="Integra.SupplierEntry" %>

<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr class="heading">
            <td colspan="4">
                &nbsp;SUPPLIER ENTRY FORM
            </td>
        </tr>
        <tr style="height: 10px;">
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr style="height: 15px;">
            <td>
                <div class="txt_newwww" style="width: 140px;">
                    Supplier Name
                </div>
            </td>
            <td>
                <div class="text_box" style="margin-left: 10px;">
                    <asp:TextBox ID="txtSupplierName" placeholder=" Supplier Name" CssClass="textbox"
                        runat="server" Width="350px" AutoPostBack="true" Style="margin-left: -404px;"></asp:TextBox>
                    <asp:TextBox ID="txtAccountCode" placeholder="Account Code" CssClass="textbox" runat="server"
                        Width="150px" Style="margin-top: -20px; margin-left: -39px;"></asp:TextBox>
                    <cc1:AutoCompleteExtender runat="server" ID="autoComplete1" TargetControlID="txtSupplierName"
                        ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                        CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="TblSuppliernew" />
                </div>
            </td>
        </tr>

          <asp:panel ID ="pnl1" runat ="server" Visible ="true" >
        <tr style="height: 35px;">
            <td>
                <div class="txt_newwww" style="width: 140px;">
                    Supplier Category
                </div>
            </td>
            <td>
               
                    <asp:DropDownList ID="cmbSupplierCategory" placeholder=" Supplier Category" Font-Size="14px"
                        CssClass="combo" Visible="True" AutoPostBack="true" runat="server" Width="228px"
                        Height="23px" BackColor="#f5f6f5" Style="margin-left: -393px;">
                    </asp:DropDownList>
                    <asp:TextBox ID="txtSupplierCode" runat="server" Visible="false"></asp:TextBox>
                    <asp:ImageButton ID="btnAddSupplierCate" runat="server" Visible="True" ImageUrl="~/Images/Add.png"
                        Style="height: 25px; margin-bottom: -9px;" CausesValidation="false"></asp:ImageButton>
            
          
            </td>
         
        </tr>  
        

      </asp:panel> 

         <asp:panel ID ="pnl2" runat ="server" Visible ="false" >
 <tr style="height: 35px;">
            <td>
                <div class="txt_newwww" style="width: 140px;">
                    Supplier Category
                </div>
            </td>
            <td>
             
                  
                        <asp:TextBox ID="txtSupplierCategory" placeholder="" CssClass="textbox" runat="server"
                            Width="70px" AutoPostBack="false" Visible="true" Style="margin-left: -391px;"></asp:TextBox>  

                         
                        <asp:TextBox ID="txtShortName" placeholder="" CssClass="textbox" runat="server" Width="70px"
                            AutoPostBack="false" Visible="true" Style=" margin-left: -507;"></asp:TextBox>
             
                    <asp:ImageButton ID="btnSaveSupplierCate" CausesValidation="false" runat="server"
                        ImageUrl="~/Images/SaveButton.jpg" Style="height: 25px; margin-bottom: 0px;"
                        Visible="true"></asp:ImageButton>    
            </td>
           
        </tr>

          </asp:panel> 





        <tr style="height: 35px;">
            <td>
                <div class="txt_newwww" style="width: 140px;">
                    Address
                </div>
            </td>
            <td>
                <div class="text_box" style="margin-left: 10px;">
                    <asp:TextBox ID="txtAddress" CssClass="textbox" placeholder=" Supplier Address" runat="server"
                        Width="350px" Style="margin-left: -404px;">  </asp:TextBox>
                </div>
            </td>
        </tr>
        <tr style="height: 35px; display:none;">
            <td>
                <div class="txt_newwww" style="width: 140px;">
                    Phone
                </div>
            </td>
            <td>
                <div class="text_box" style="margin-left: 10px;">
                    <asp:TextBox ID="txtPhone" CssClass="textbox" Text="N/A" placeholder=" Supplier Phone" runat="server"
                        Style="margin-left: -404px;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                        ControlToValidate="txtPhone" Style="color: Red; font-size: large;"></asp:RequiredFieldValidator>
                </div>
            </td>
        </tr>
        <tr style="height: 35px; display:none;">
            <td>
                <div class="txt_newwww" style="width: 140px;">
                    Fax</div>
            </td>
            <td>
                <div class="text_box" style="margin-left: 10px;">
                    <asp:TextBox ID="txtFax" CssClass="textbox" Text="N/A" placeholder=" Supplier Fax" runat="server"
                        Style="margin-left: -404px;"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                <div class="txt_newwww" style="width: 140px;">
                    Email Address
                </div>
            </td>
            <td>
                <div class="text_box" style="margin-left: 10px;">
                    <asp:TextBox ID="txtEmailAddress" CssClass="textbox" placeholder=" Supplier  Email Address"
                        runat="server" Width="350px" Style="margin-left: -404px;">                  
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                        ControlToValidate="txtEmailAddress" Style="color: Red; font-size: large;"></asp:RequiredFieldValidator>
                </div>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                <div class="txt_newwww" style="width: 140px;">
                    Contact Person
                </div>
            </td>
            <td>
                <div class="text_box" style="margin-left: 10px;">
                    <asp:TextBox ID="txtContactPerson" CssClass="textbox" placeholder=" Supplier    Contact Person"
                        runat="server" Width="225px" Style="margin-left: -404px;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                        ControlToValidate="txtContactPerson" Style="color: Red; font-size: large;"></asp:RequiredFieldValidator>
                </div>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                <div class="txt_newwww" style="width: 140px;">
                    Cell No.
                </div>
            </td>
            <td>
                <div class="text_box" style="margin-left: 10px;">
                    <asp:TextBox ID="txtCellNo" CssClass="textbox" placeholder=" Supplier  Cell No."
                        runat="server" Width="225px" Style="margin-left: -404px;"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                <div>
                    <asp:Button ID="btnAddDetail" runat="server" Text="Add Detail" CssClass="btn btn-outline btn-success" />
                </div>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td>
                <Smart:SmartDataGrid ID="dgSupplierDetail" runat="server" Width="100%" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                    PageSize="15" ShowFooter="True" SortedAscending="yes" ForeColor="white" GridLines="both">
                    <Columns>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="SupplierDatabaseDetailId"
                            DataField="SupplierDatabaseDetailId" Visible="False" />
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Contact Person"
                            DataField="ContactPerson">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="15%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="25%" HeaderText="Cell No."
                            DataField="CellNumber">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="15%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="5%" HeaderText="Remove">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:ImageButton ID="lnkRemove" ToolTip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png"
                                    CommandName="Remove" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </Smart:SmartDataGrid>
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td align="center">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-outline btn-success"
                    CausesValidation="false"></asp:Button>
                <%-- </td><td>--%>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-outline btn-danger"  CausesValidation="false">
                </asp:Button>
            </td>
        </tr>
            <tr>
            <td align="center">
              <asp:Label ID ="lblUserId" runat ="server" Visible ="false" Text="0"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
