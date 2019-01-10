<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="VAFPanel.aspx.vb" Inherits="Integra.VAFPanel" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- <link type="text/css" rel="stylesheet" href="../css/VAF.css" />--%>
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
   
    <table width="100%">
        <tr class="heading">
            <td >
                &nbsp;Basic Information
            </td>
        </tr>
        <tr style="height:15px;"> <td> &nbsp;  </td></tr>
       </table>
    <table width="100%">
        <tr style="height:35px;">
            <td>
                <div class="txt" style="width: 140px;">
                    Company
                </div>
            </td>
            <td >
                <asp:UpdatePanel ID="UpcmbSupplier" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList CssClass="combo" style="margin-left: 15px;"  ID="cmbSupplier" Width="160" runat="server" AutoPostBack="True">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr style="height:35px;">
            <td>
                <div class="txt" style="width: 140px;">
                    Year Established
                </div>
            </td>
            <td>
                <asp:UpdatePanel ID="UpcmbYearEstablished" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList CssClass="combo" style="margin-left: 15px;"  ID="cmbYearEstablished" Width="160" AutoPostBack="true" runat="server">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <div class="txt" style="margin-left: 15px;">
                    Code
                </div>
            </td>
            <td class="text_box" style="height: 22px;margin-top: 4px;">
                
                    <asp:TextBox ID="txtCode" style="height: 21px; border: 1px solid #1e4463; margin-left: 15px;"   runat="server"></asp:TextBox>
                    </td>
                    <td colspan="3">
                               <asp:Label ID="Label1" runat="server" style="width: 140px; margin-left: 32px;"  text="(to be issued by GIA)" ></asp:Label>
                
            </td>

        </tr>
        <tr style="height:35px;">
            <td>
                <div class="txt" style="width: 140px;">
                    Corporate Address
                </div>
            </td>
            <td>
            <div class="text_box">
                    <asp:TextBox ID="txtCorporateAddress" style="height: 21px;width: 713px; border: 1px solid #1e4463; margin-left: 15px;" runat="server"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr style="height:35px;">
            <td>
                <div class="txt" style="width: 140px;">
                    Entity
                </div>
            </td>
            <td>
                <asp:UpdatePanel ID="UpCompany" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList CssClass="combo" style="margin-left: 15px;" ID="cmbCompany"    AutoPostBack="true" Width="160" runat="server">
                            <asp:ListItem Value="0" Text="Private"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Limited"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Public"></asp:ListItem>
                            <asp:ListItem Value="3" Text="Other"></asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <div class="txt" style="margin-left: 15px;">
                    Product Line
                </div>
            </td>
            <td>
            <table>
            <tr>
           
            <td><asp:UpdatePanel ID="UpcmbBusiness"  UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadComboBox ID="cmbBusiness" style="width:130px;" runat="server" CheckBoxes="True" Skin="WebBlue">
                        </telerik:RadComboBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UptxtBusiness" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                            
                            <asp:TextBox ID="txtBusiness" ToolTip="Click to add New Item" Width="80" 
                                runat="server" style="height: 21px; border: 1px solid #1e4463;border-radius:5px;"></asp:TextBox>
                               
                     
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
                <td>
                <asp:UpdatePanel ID="UpbtnAddBusiness" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                       <%-- <asp:Button ID="btnAddBusiness" runat="server" Width="20" CssClass="button" Text="?" />--%>
                        <asp:ImageButton ID="btnAddBusinessA" runat="server" ToolTip="Click to add in Dropdown" ImageUrl="~/Images/plus.jpg" />  
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpbtnSaveBusiness" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnSaveBusiness" runat="server" style="margin-left: 6px;" Width="61" CssClass="btn btn-outline btn-success" Text="Save" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                 </td>
                
            </tr>
            </table>
            
                
               
                  
            </td>
            <td>
                 <div class="txt" style="margin-left: 15px;">
                    Product Group
                </div>
            </td>
            <td>
            <table>
            <tr>
            <td>
                <asp:UpdatePanel ID="UpcmbProduct" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadComboBox ID="cmbProduct" style="width:130px;" runat="server" CheckBoxes="True" Skin="WebBlue">
                        </telerik:RadComboBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UptxtProduct" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        
                            <asp:TextBox ID="txtProduct" Width="70" style="height: 21px; border: 1px solid #1e4463;border-radius:5px;"  runat="server"></asp:TextBox>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
                
                <td>
               
                 <asp:UpdatePanel ID="UpbtnAddProduct" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                       <%-- <asp:Button ID="btnAddProduct" ToolTip="Click to dd New Item" runat="server" Width="20"
                            CssClass="button" Text="?" />--%>
                               <asp:ImageButton ID="btnAddProductA" runat="server" ToolTip="Click to add in Dropdown" ImageUrl="~/Images/plus.jpg" />  
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpbtnSaveProduct" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnSaveProduct" runat="server" Width="61" CssClass="btn btn-outline btn-success" Text="Save" style="margin-left: 10px;" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
                </tr>
                </table>
            </td>
        </tr>
          </table>
         <table>
          <tr style="height:15px;"> <td> &nbsp;  </td></tr>
        <tr >
            <td class="heading">
                Primary Contacts
            </td>
        </tr>
           <tr style="height:15px;"> <td> &nbsp;  </td></tr>
         </table>
         <table>
           <tr style="height:35px;">
            <td>
                <div class="txt" style="width: 140px;">
                 <span style="color:Red;">*</span>   Designation
                </div>
            </td>
            <td>
                <asp:UpdatePanel ID="UpcmbDesignation" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbDesignation" style="margin-left: 15px;" CssClass="combo" AutoPostBack="true" Width="160" runat="server">
                            <asp:ListItem Value="0" Text="President"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Marketing Ex."></asp:ListItem>
                            <asp:ListItem Value="2" Text="Direction Op."></asp:ListItem>
                            <asp:ListItem Value="3" Text="Compliance"></asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <div class="txt" style="margin-left: 22px;">
                    <span style="color:Red;">*</span> Name
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtName" style="height: 21px; border: 1px solid #1e4463;  margin-left: 15px;"  runat="server"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="txt" style="margin-left: 131px;">
                  <span style="color:Red;">*</span>   Phone No.
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtPhone" style="height: 21px; border: 1px solid #1e4463;  margin-left: 15px;" onkeypress="return isNumericKeyy(event);" 
                        runat="server"></asp:TextBox>
                </div>
            </td>
        </tr>
       <tr style="height:35px;">
            <td>
                <div class="txt" style="width: 140px;">
                  <span style="color:Red;">*</span>   Email
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtEmail" style="height: 21px; border: 1px solid #1e4463;  margin-left: 15px;"  runat="server"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="txt" style="margin-left: 22px;">
                   <span style="color:Red;">*</span>  Cell No.
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtCell" style="height: 21px; border: 1px solid #1e4463;  margin-left: 15px;" onkeypress="return isNumericKeyy(event);" 
                        runat="server"></asp:TextBox>
                </div>
            </td>
            <td>
            </td>
            <td>
                <asp:UpdatePanel ID="upbtnDetail" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnDetail" CssClass="btn btn-outline btn-success" style="margin-left: 51px;" runat="server" Text="Add Personnel"></asp:Button>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
            </table>
    <table width="100%">
     <tr style="height:10px;"> <td> &nbsp;  </td></tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdgPrimaryContact" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadGrid ID="dgPrimaryContact" runat="server" CellSpacing="0" AutoGenerateColumns="false"
                            Skin="WebBlue" Visible="False" PageSize="50">
                            <MasterTableView>
                                <Columns>
                                    <telerik:GridBoundColumn HeaderText="VAF_PrimaryContactID" DataField="VAF_PrimaryContactID">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Designation." DataField="Designation">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Name" DataField="Name">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Phone" DataField="Phone">
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Cell" DataField="Cell">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Email" DataField="Email">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridButtonColumn UniqueName="DeleteColumn" Text="" CommandName="Delete"
                                        ConfirmTextFormatString="Are You Sure You want to Delete Record" HeaderStyle-Width="2%"
                                        ButtonType="ImageButton">
                                    </telerik:GridButtonColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
          
           </table>
    <table width="100%">
     <tr style="height:15px;"> <td> &nbsp;  </td></tr>
        <tr>
            <td class="heading">
                HR Detail
            </td>
        </tr>
           <tr style="height:15px;"> <td> &nbsp;  </td></tr>
        </table>
        <table>
           <tr style="height:35px;">
            <td>
                <div class="txt" style="width: 140px;">
                    Total Worker
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtTotalWorker" style="height: 21px;margin-left: 15px; border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);"
                         runat="server"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="txt" style="margin-left: 151px;">
                    Female Staff
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtFemale" style="height: 21px;margin-left: 15px; border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);" 
                         runat="server"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="txt" style="margin-left: 132px;">
                    Male Staff
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtMale" style="height: 21px;margin-left: 15px; border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);" Width="60px"  
                        runat="server"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr style="height:35px;">
            <td>
                <div class="txt" style="width: 140px;">
                    Permanent Staff
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtPermanent" style="height: 21px;margin-left: 15px; border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);" 
                         runat="server"></asp:TextBox>
                </div>
            </td>
            <td>
                 <div class="txt" style="margin-left: 151px;">
                    No. of Shifts
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtNoofShifts" style="height: 21px;margin-left: 15px; border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);" 
                         runat="server"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="txt" style="margin-left: 132px;">
                    Timing
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtTiming" style="height: 21px;margin-left: 15px; border: 1px solid #1e4463;" Width="60"  runat="server"></asp:TextBox>
               </div>
                <asp:Label ID="Label2" runat="server" style="width: 107px;
margin-left: 37px;margin-top: 8px;" Text=" (Based on 24hour)" Width="60px"></asp:Label>
               
            </td>
        </tr>
           </table>
        <table>
         <tr style="height:15px;"> <td> &nbsp;  </td></tr>
        <tr>
            <td class="heading">
                HR Breakdown
            </td>
        </tr>
           <tr style="height:15px;"> <td> &nbsp;  </td></tr>
        </table>
        <table>
           <tr style="height:35px;">
            <td>
                 <div class="txt" style="width: 140px;">
                    Dept.
                </div>
            </td>
            <td>
            <table> <tr>
            <td><asp:UpdatePanel ID="UpcmbDept" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList CssClass="combo" style="margin-left: 15px;" ID="cmbDept" AutoPostBack="true" runat="server">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UptxtDeptMore" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtDeptMore" style="width: 74px;height: 21px;margin-left: 12px;border: 1px solid rgb(30, 68, 99);border-radius: 5px;" Width="80"  runat="server"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel></td>
             <td> <asp:UpdatePanel ID="UpbtnAddDept" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnAddDept" runat="server" style="margin-left: 19px;" Width="56" CssClass="btn btn-outline btn-success" Text="Save" />
                    </ContentTemplate>
                </asp:UpdatePanel></td>
            </tr></table>
                
               
            </td>
            <td>
                 <div class="txt" style="width: 180px;margin-left: 15px;">
                    Total No. of Employee
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtNo"  style="height: 21px;margin-left: 15px; border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);" 
                        runat="server"></asp:TextBox>
                </div>
            </td>
            <td>
                <asp:UpdatePanel ID="UpbtnAddList" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnAddList" style="margin-left: 170px;" runat="server" CssClass="btn btn-outline btn-success" Text="Add to list" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
         </table>
    <table width="100%">
     <tr style="height:10px;"> <td> &nbsp;  </td></tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdgHRBreakdown" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadGrid ID="dgHRBreakdown" runat="server" CellSpacing="0" AutoGenerateColumns="false"
                            Skin="WebBlue" Visible="False" PageSize="50">
                            <MasterTableView>
                                <Columns>
                                    <telerik:GridBoundColumn HeaderText="VAF_HRBreakdownID" DataField="VAF_HRBreakdownID">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="DeptID" DataField="DeptID">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Department" DataField="Department">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Total No. of Employee" DataField="No">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridButtonColumn UniqueName="DeleteColumn" Text="" CommandName="Delete"
                                        ConfirmTextFormatString="Are You Sure You want to Delete Record" HeaderStyle-Width="2%"
                                        ButtonType="ImageButton">
                                    </telerik:GridButtonColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        
          </table>
    <table width="100%">
      <tr style="height:15px;"> <td> &nbsp;  </td></tr>
        <tr>
            <td class="heading">
                Capacities
            </td>
        </tr>
          <tr style="height:15px;"> <td> &nbsp;  </td></tr>
        </table>

        <table>
         <tr style="height:35px;">
            <td>
                 <div class="txt" style="width: 140px;">
                    Fabric Stock
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtFabricStock" style="height: 21px;margin-left: 15px; border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);" Width="80"
                         runat="server"></asp:TextBox></div>
                <asp:DropDownList CssClass="combo" style="margin-left: 55px;" ID="cmbFabricStockUnit" Width="55" runat="server">
                    <asp:ListItem Value="0" Text="KG"></asp:ListItem>
                    <asp:ListItem Value="1" Text="MT"></asp:ListItem>
                    <asp:ListItem Value="2" Text="M"></asp:ListItem>
                    <asp:ListItem Value="3" Text="Nos"></asp:ListItem>
                    <asp:ListItem Value="4" Text="PCs"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                 <div class="txt" style="width: 155px;margin-left: 20px;">
                    Prod.Capacity/month
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtProdcapacitymonth" style="height: 21px;margin-left: 15px; border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);"
                        Width="80"  runat="server"></asp:TextBox></div>
                <asp:DropDownList CssClass="combo" style="margin-left: 55px;" ID="cmbProdcapacitymonthUnit" Width="55" runat="server">
                    <asp:ListItem Value="0" Text="KG"></asp:ListItem>
                    <asp:ListItem Value="1" Text="MT"></asp:ListItem>
                    <asp:ListItem Value="2" Text="M"></asp:ListItem>
                    <asp:ListItem Value="3" Text="Nos"></asp:ListItem>
                    <asp:ListItem Value="4" Text="PCs"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                 <div class="txt" style="width: 170px; margin-left:15px;">
                    Cutting capacity/month
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtCuttingcapacitymonth" style="height: 21px;margin-left: 15px; border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);"
                        Width="55"  runat="server"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr style="height:35px;">
            <td>
                 <div class="txt" style="width: 140px;">
                    Washing Capacity
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtwashingcapacity" style="height: 21px; margin-left:15px; border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);" Width="80"
                         runat="server"></asp:TextBox>
                </div>
            </td>
            <td>
                 <div class="txt" style="width: 155px;margin-left: 20px;">
                    No of lines
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtNooflines" style="height: 21px;margin-left: 15px; border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);" Width="80"
                         runat="server"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="txt" style="width: 170px;margin-left: 15px;">
                    No of machine/line
                </div>
            </td>
            <td>
                <div class="text_box"> 
                    <asp:TextBox ID="txtNoofmachineline" style="height: 21px;margin-left: 15px; border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);" Width="55"
                         runat="server"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr style="height:35px;">
            <td>
                 <div class="txt" style="width: 140px;">
                    SAM/SMV
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtSAMSMV" style="height: 21px;margin-left: 15px; border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);" Width="80"
                         runat="server"></asp:TextBox>
                </div>
            </td>
        </tr>
           </table>
        <table>
         <tr style="height:15px;"> <td> &nbsp;  </td></tr>
        <tr>
            <td class="heading">
                General Information
            </td>
        </tr>
           <tr style="height:15px;"> <td> &nbsp;  </td></tr>
        </table>
        <table>
           <tr style="height:35px;">
            <td>
                <div class="txt" style="width:220px;">
                    Company coverd Area (sq. m)
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtCompanycoverdArea" style="height: 21px;margin-left: 15px; border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);"
                        Width="80"  runat="server"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="txt" style="width:150px;margin-left: 70px;">
                    Factory Area (sq. m)
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtFactoryArea" style="height: 21px;margin-left: 15px; border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);" Width="80"
                         runat="server"></asp:TextBox>
                </div>
            </td>
        </tr>
        
    </table>
    <table width="100%">
     <tr style="height:15px;"> <td> &nbsp;  </td></tr>
        <tr>
            <td  class="heading">
               Annual turnover last 3 years <span style="color: red;">in USD</span>  
            </td>
        </tr>
         <tr style="height:15px;"> <td> &nbsp;  </td></tr>
        </table>
    <table>
        <tr>           
            <td colspan="6">
            <table>
            <tr>
            <td> <asp:Label ID="lblYear1" Font-Underline="true" style="margin-left: 1px;" Font-Bold="true" runat="server"></asp:Label></td>
            <td><div class="text_box">
                   
                    <asp:TextBox ID="txtAnnualturnover1" style="height: 21px;margin-left: 14px; border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);" Width="80"
                         runat="server"></asp:TextBox>
                </div></td>
            <td> <asp:Label ID="lblYear2" Font-Bold="true"   style="margin-left: 63px;" Font-Underline="true" runat="server"></asp:Label></td>
            <td> <div class="text_box">
                   
                    <asp:TextBox ID="txtAnnualturnover2" style="height: 21px;margin-left: 10px; border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);" Width="80"
                         runat="server"></asp:TextBox>
                </div></td>
            <td> <asp:Label ID="lblYear3" Font-Bold="true" style="margin-left: 58px;" Font-Underline="true" runat="server"></asp:Label></td>
            <td> <div class="text_box">
                   
                    <asp:TextBox ID="txtAnnualturnover3" style="height: 21px;margin-left: 10px; border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);" Width="80"
                         runat="server"></asp:TextBox>
                </div></td>
            </tr>
            </table>

                
            </td>
            
        </tr>
        
         <tr style="height:5px;"> <td> &nbsp;  </td></tr> 
        <tr>
            <td>
                <div class="txt" style="width: 295px;">
                    Total Annual Shipments (volume) globally
                </div>
            </td>
            <td align="right">
                <div class="text_box">
                    <asp:TextBox ID="txtTotalAnnualShipmentsvolumeglobally" style="height: 21px;margin-left: 15px; border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);"
                        Width="80"  runat="server"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="txt" style="margin-left: 65px;width: 270px;">
                    Total Annual Shipments to the Europe
                </div>
            </td>
            <td align="right">
                <div class="text_box">
                    <asp:TextBox ID="txtTotalAnnualShipmentstothevolumeEurope" style="height: 21px;margin-left: 15px; border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);"
                        Width="80"  runat="server"></asp:TextBox>
                </div>
            </td>
        </tr>
         <tr style="height:5px;"> <td> &nbsp;  </td></tr> 
        <tr> <td>
                <b>Note: put figures in Pcs. </b>
            </td></tr>
                </table>
    <table width="100%">
     <tr style="height:15px;"> <td> &nbsp;  </td></tr>
        <tr>
             <td  class="heading">
                 Please list Top 5 Customers for last fiscal year based  on turnover  
            </td>
        </tr>
           <tr style="height:15px;"> <td> &nbsp;  </td></tr>
    </table>
    <table width="100%">
        <tr style="height:35px;">
            <td>
                <div class="txt">
                    Name
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtCustomerName" Width="100" style="height: 21px;margin-left: -287px; border: 1px solid #1e4463;"  runat="server"></asp:TextBox></div>
            </td>
            <td>
                <div class="txt" style="width: 195px;margin-left: -332px;">
                    Country
                </div>
            </td>
            <td>
                <asp:UpdatePanel ID="UpcmbCustomerCountry" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList CssClass="combo" ID="cmbCustomerCountry" Width="120" style="margin-left:-123px;" AutoPostBack="true" runat="server">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
       <tr style="height:35px;">
            <td>
                <div class="txt">
                    % of Buss.
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtCustomerPercentOfBuss" style="height: 21px;margin-left: -288px;; border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);"
                        Width="100"  runat="server"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="txt" style="width: 198px;margin-left:-334px;">
                    Product made for customer
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtCustomerProduct" style="height: 21px;margin-left: -123px; border: 1px solid #1e4463;" Width="120"  runat="server"></asp:TextBox></div>
            
             <asp:UpdatePanel ID="UpbtnAddGrid" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnAddGrid" runat="server" CssClass="btn btn-outline btn-success" style="margin-left: -18px;float: left;" Text="Add to grid" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
             
        </tr>
           </table>
    <table width="100%">
     <tr style="height:10px;"> <td> &nbsp;  </td></tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdgTopCustomer" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadGrid ID="dgTopCustomer" runat="server" CellSpacing="0" AutoGenerateColumns="false"
                            Skin="WebBlue" Visible="False" PageSize="50">
                            <MasterTableView>
                                <Columns>
                                    <telerik:GridBoundColumn HeaderText="VAF_TopCustomerID" DataField="VAF_TopCustomerID">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Country_id" DataField="Country_id">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Name" DataField="CustomerName">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Country" DataField="CustomerCountry">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="% of Business" DataField="CustomerPercentOfBuss">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Product made for customer" DataField="CustomerProduct">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridButtonColumn UniqueName="DeleteColumn" Text="" CommandName="Delete"
                                        ConfirmTextFormatString="Are You Sure You want to Delete Record" HeaderStyle-Width="2%"
                                        ButtonType="ImageButton">
                                    </telerik:GridButtonColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
         
          </table>
    <table width="100%">
     <tr style="height:15px;"> <td> &nbsp;  </td></tr>
        <tr>
            <td class="heading">
                Do you have conceptual design staff?
            </td>
              </tr>
                 <tr style="height:15px;"> <td> &nbsp;  </td></tr>
            </table>
            <table>
                <tr>
        <td>
                <asp:DropDownList CssClass="combo" ID="cmbConceptualDesign" Width="50" runat="server">
                    <asp:ListItem Value="0" Text="No"></asp:ListItem>
                    <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td align="right">
                <div class="txt" style="margin-left: 15px;">
                    If yes, is it
                </div>
            </td>
            <td>
                <asp:CheckBox ID="chkInHouse" Text="In-House" style="margin-left: -79px;" runat="server" />
            </td>
            <td>
                <asp:CheckBox ID="chkNumberOfInHouseDesigners" style="margin-left: -173px;" Text="Number of in-house designers"
                    runat="server" />
            </td>
            <td>
               <div class="txt" style="margin-left: -156px;">
                    Location:
                </div>
                <div class="text_box">
                    <asp:TextBox ID="txtInHouseLocation" style="height: 21px;margin-left: -29px; border: 1px solid #1e4463;" Width="80"  runat="server"></asp:TextBox></div>
            </td>
        </tr>
        <tr style="height:4px;"> <td> &nbsp;  </td></tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:CheckBox ID="chkContracted" Text="Contracted" style="margin-left: 140px;" runat="server" />
            </td>
            <td>
                <asp:CheckBox ID="chkNumberOfOutsideDesigners" style="margin-left: 18px;" Text="Number of outside designers"
                    runat="server" />
            </td>
            <td>
                <div class="txt" style="margin-left: 35px;">
                    Location:
                </div>
                <div class="text_box">
                    <asp:TextBox ID="txtContractedLocation" style="height: 21px;margin-left: 16px; border: 1px solid #1e4463;" Width="80"  runat="server"></asp:TextBox>
                </div>
            </td>
        </tr>
          </table>
        <table>
         <tr style="height:15px;"> <td> &nbsp;  </td></tr>
        <tr>

            <td class="heading">
                Do you have sampling department
            </td>
              </tr>
                 <tr style="height:15px;"> <td> &nbsp;  </td></tr>
              </table>
                <table>
                    <tr>
        <td>
                <asp:DropDownList CssClass="combo" ID="cmbSampling" Width="50" runat="server">
                    <asp:ListItem Value="0" Text="No"></asp:ListItem>
                    <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td align="right">
                <div class="txt" style="margin-left: 20px;width: 121px;">
                    No. of Machine
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtNoOfMachineSampling" style="height: 21px;margin-left: 15px; border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);"
                        Width="50"  runat="server"></asp:TextBox>
                </div>
            </td>
            <td>
               <div class="txt" style="margin-left: 42px;width: 134px;">
                    Capacity (pc/day)
                </div>
            </td>
            <td align="center">
                <div class="text_box">
                    <asp:TextBox ID="txtCapacitySampling" style="height: 21px;margin-left: 15px; border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);" Width="80"
                         runat="server"></asp:TextBox>
                </div>
            </td>
        </tr>
           </table>
    <table width="100%">
     <tr style="height:15px;"> <td> &nbsp;  </td></tr>
        <tr>
            <td class="heading">
                Product Development related information (pls. tick checkbox if you have)
            </td>
        </tr>
           <tr style="height:15px;"> <td> &nbsp;  </td></tr>
    </table>
    <table width="100%">
        <tr>
            <td >
                <div class="txt">
                    PD Info:
                </div>
            </td>
            <td >
            <table>
            <tr>
            <td>
            
                <asp:UpdatePanel ID="UpcmbPD" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadComboBox ID="cmbPD" runat="server" Width="195" CheckBoxes="True" Skin="WebBlue">
                        </telerik:RadComboBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
                 <asp:UpdatePanel ID="UptxtPDinfo" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                    
                        <asp:TextBox ID="txtPDinfo"  runat="server" style="width: 128px;height: 21px;border: 1px solid rgb(30, 68, 99);border-radius: 5px; margin-left: -135px;"></asp:TextBox>
                         
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
                <td>
                <asp:UpdatePanel ID="UpbtnAddPD" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                     <%--   <asp:Button ID="btnAddPD" ToolTip="Click to dd New Item" runat="server" Width="20"
                            CssClass="button" Text="?" />--%>
                                 <asp:ImageButton ID="btnAddPDA" ToolTip="Click to add in Dropdown" runat="server" ImageUrl="~/Images/plus.jpg" />  
                    </ContentTemplate>
                </asp:UpdatePanel>
                 <asp:UpdatePanel ID="UpbtnSavePD" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnSavePD" runat="server" Width="62px" CssClass="btn btn-outline btn-success" Text="Save" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                 </td>
                
            </tr>
            </table>
            </td>
            <td style ="width :495px;">&nbsp;</td>
             <td></td>
        </tr>
           </table>
    <table width="100%">
     <tr style="height:15px;"> <td> &nbsp;  </td></tr>
        <tr>
            <td class="heading">
                      Pre-Treatment Specialities
              
            </td>
        </tr>
           <tr style="height:15px;"> <td> &nbsp;  </td></tr>
    </table>
    <table width="100%">
        <tr>
            <td align="right">
                <div class="txt">
                    Speciality
                </div>
            </td>
            <td align="left">
            <table>
            <tr>
            <td>
           
                <asp:UpdatePanel ID="UpcmbPreTreatmentSpeciality" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadComboBox ID="cmbPreTreatmentSpeciality"  runat="server" Width="195" CheckBoxes="True"
                            Skin="WebBlue">
                        </telerik:RadComboBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
                 <asp:UpdatePanel ID="UptxtPreTreatmentSpeciality" UpdateMode="Conditional" runat="server">
                    <ContentTemplate> 
                     
                        <asp:TextBox ID="txtPreTreatmentSpeciality"   runat="server" style="width: 128px;height: 21px;border: 1px solid rgb(30, 68, 99);border-radius: 5px; margin-left: -135px;"></asp:TextBox>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
                 </td>
                <td>
                <asp:UpdatePanel ID="UpbtnAddPreTreatmentSpeciality" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                       <%-- <asp:Button ID="btnAddPreTreatmentSpeciality" ToolTip="Click to dd New Item" runat="server"
                            Width="20" CssClass="button" Text="?" />--%>
                             <asp:ImageButton ID="btnAddPreTreatmentSpecialityA" runat="server" ToolTip="Click to add in Dropdown" ImageUrl="~/Images/plus.jpg" />  
                    </ContentTemplate>
                </asp:UpdatePanel>
                 <asp:UpdatePanel ID="UpbtnSavePreTreatmentSpeciality" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnSavePreTreatmentSpeciality" runat="server" Width="62px" CssClass="btn btn-outline btn-success"
                            Text="Save" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                 </td>
                
            </tr>
            </table>
            </td>
             <td style ="width :495px;">&nbsp;</td>
             <td></td>
        </tr>
           </table>
    <table width="100%">
     <tr style="height:15px;"> <td> &nbsp;  </td></tr>
        <tr>
            <td class="heading">
                Machine / technical
            </td>
        </tr>
         <tr style="height:15px;"> <td> &nbsp;  </td></tr>
        </table>
        <table>
           <tr style="height:35px;">
            <td align="right">
                <div class="txt">
                    Machine
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtMachine" style="height: 21px;margin-left: 15px; border: 1px solid #1e4463;" Width="80"  runat="server"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="txt" style="margin-left: 70px;">
                    Width (Cm)
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtWidth" style="height: 21px;margin-left: 15px; border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);" Width="80" 
                        runat="server"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="txt" style="margin-left: 70px;">
                    Meter/day
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtMeter" style="height: 21px;margin-left: 15px; border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);" Width="120"
                         runat="server"></asp:TextBox>
                </div>
            </td>
        </tr>
      <tr style="height:35px;">
            <td align="right">
                <div class="txt">
                    Model No.
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtModel" style="height: 21px;margin-left: 15px; border: 1px solid #1e4463;" Width="80"  runat="server"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="txt" style="margin-left: 70px;">
                    Year
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtYear" style="height: 21px;margin-left: 15px; border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);" Width="80" 
                        runat="server"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="txt" style="margin-left: 71px;">
                    Type
                </div>
            </td>
            <td>
                <asp:UpdatePanel ID="UpcmbType" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList CssClass="combo" ID="cmbType" Width="120" style="margin-left: 15px;" AutoPostBack="true" runat="server">
                            <asp:ListItem Value="0" Text="Owned"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Contracted"></asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
                 <asp:UpdatePanel ID="UpbtnAddMachineTechnical" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnAddMachineTechnical" runat="server" CssClass="btn btn-outline btn-success" style="margin-left: 155px;margin-top: -23px;" Text="Add to grid" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
          </table>
    <table width="100%">
     <tr style="height:10px;"> <td> &nbsp;  </td></tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdgMachineTechnical" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadGrid ID="dgMachineTechnical" runat="server" CellSpacing="0" AutoGenerateColumns="false"
                            Skin="WebBlue" Visible="False" PageSize="50">
                            <MasterTableView>
                                <Columns>
                                    <telerik:GridBoundColumn HeaderText="VAF_MachineTechnicalID" DataField="VAF_MachineTechnicalID">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Machine" DataField="Machine">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Width (Cm)" DataField="WidthinCM">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Meter/day" DataField="MeterPerday">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Model" DataField="Model">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Year" DataField="Year">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Type" DataField="Type">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridButtonColumn UniqueName="DeleteColumn" Text="" CommandName="Delete"
                                        ConfirmTextFormatString="Are You Sure You want to Delete Record" HeaderStyle-Width="2%"
                                        ButtonType="ImageButton">
                                    </telerik:GridButtonColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
          
           </table>
    <table width="100%">
     <tr style="height:15px;"> <td> &nbsp;  </td></tr>
        <tr>
            <td class="heading">
                Dyeing Specialities
            </td>
        </tr>
           <tr style="height:15px;"> <td> &nbsp;  </td></tr>
        </table>

        <table>
           <tr>
            <td align="right">
                <div class="txt" style="margin-right: 15px;">
                    Speciality
                </div>
            </td>
            <td>
            <table>
            <tr>
            <td>
            
                <asp:UpdatePanel ID="UpcmbDyeingSpeciality" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadComboBox ID="cmbDyeingSpeciality" runat="server" CheckBoxes="True" Skin="WebBlue">
                        </telerik:RadComboBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
                 <asp:UpdatePanel ID="UptxtDyeingSpecialit" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>  
                        <asp:TextBox ID="txtDyeingSpecialit" Width="80"  runat="server" style="width: 128px;height: 21px;border: 1px solid rgb(30, 68, 99);border-radius: 5px;"></asp:TextBox>
                      
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
                <td>
                <asp:UpdatePanel ID="UpbtnAddDyeingSpecialit" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                       <%-- <asp:Button ID="btnAddDyeingSpecialit" ToolTip="Click to dd New Item" runat="server"
                            Width="20" CssClass="button" Text="?" />--%>
                              <asp:ImageButton ID="btnAddDyeingSpecialitA" runat="server" ToolTip="Click to add in Dropdown" ImageUrl="~/Images/plus.jpg" />  
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpbtnSaveDyeingSpecialit" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnSaveDyeingSpecialit" runat="server" Width="62px" CssClass="btn btn-outline btn-success"
                            Text="Save" style="margin-left: 18px;" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                 </td>
                
            </tr>
            </table>
            </td>
        </tr>
           </table>
    <table width="100%">
     <tr style="height:15px;"> <td> &nbsp;  </td></tr>
        <tr>
            <td class="heading">
                Embellishment Specialities (Capacity Per Week)
            </td>
        </tr>
         <tr style="height:15px;"> <td> &nbsp;  </td></tr>
        </table>

        <table>
           <tr>
            <td align="right">
                <div class="txt">
                    Capabilities
                </div>
            </td>
            <td>
            <table>
            <tr>
            <td><asp:UpdatePanel ID="UpcmbCapabilities" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList CssClass="combo" style="margin-left: 15px;" ID="cmbCapabilities" AutoPostBack="true" runat="server">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel></td>
            <td> <asp:UpdatePanel ID="UptxtCapabilities" runat="server">
                    <ContentTemplate> <div class="text_box">
                        <asp:TextBox ID="txtCapabilities" style="width: 62px;height: 21px;border: 1px solid rgb(30, 68, 99);margin-left: 12px;border-radius:5px;" Width="80"  runat="server"></asp:TextBox>
                        </div> 
                    </ContentTemplate>
                </asp:UpdatePanel></td>
            <td>  <asp:UpdatePanel ID="UpbtnSaveCapabilities" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnSaveCapabilities" runat="server" style="margin-left: 40px; margin-right: 32px;" Width="56px" CssClass="btn btn-outline btn-success"
                            Text="Save" />
                    </ContentTemplate>
                </asp:UpdatePanel></td>
            </tr>
            </table>
                
               
              
            </td>
            <td>
                <div class="txt" style="margin-left: -25px;">
                    Volume
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtVolume" style="height: 21px;margin-left: 15px; border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);" Width="80"
                         runat="server"></asp:TextBox></div>
                <asp:DropDownList CssClass="combo" ID="cmbVolumeUnit" style="margin-left: 56px;" Width="55" runat="server">
                    <asp:ListItem Value="0" Text="M"></asp:ListItem>
                    <asp:ListItem Value="1" Text="Nos"></asp:ListItem>
                    <asp:ListItem Value="2" Text="PCs"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <div class="txt" style="margin-left: 20px;">
                    No. of Mac.
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtNoofMac" style="height: 21px;margin-left: 15px; border: 1px solid #1e4463;" onkeypress="return isNumericKeyy(event);" Width="86"
                         runat="server"></asp:TextBox></div>
                         <asp:UpdatePanel ID="UpbtnAddEmbellishmentSpecialities" UpdateMode="Conditional"
                    runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnAddEmbellishmentSpecialities" runat="server" style="margin-left: 120px;margin-top: -23px;" CssClass="btn btn-outline btn-success"
                            Text="Add to grid" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
           </table>
    <table width="100%">
     <tr style="height:10px;"> <td> &nbsp;  </td></tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdgEmbellishmentSpecialities" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadGrid ID="dgEmbellishmentSpecialities" runat="server" CellSpacing="0"
                            AutoGenerateColumns="false" Skin="WebBlue" Visible="False" PageSize="50">
                            <MasterTableView>
                                <Columns>
                                    <telerik:GridBoundColumn HeaderText="VAF_EmbellishmentSpecialitiesID" DataField="VAF_EmbellishmentSpecialitiesID">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Capabilities" DataField="Capabilities">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Volume" DataField="Volume">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Unit" DataField="Unit">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="No. of Mac." DataField="NoofMac">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridButtonColumn UniqueName="DeleteColumn" Text="" CommandName="Delete"
                                        ConfirmTextFormatString="Are You Sure You want to Delete Record" HeaderStyle-Width="2%"
                                        ButtonType="ImageButton">
                                    </telerik:GridButtonColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
         
           </table>
    <table width="100%">
     <tr style="height:15px;"> <td> &nbsp;  </td></tr>
        <tr>
            <td class="heading">
                Stitching Line Machine Strength
            </td>
        </tr>
           <tr style="height:15px;"> <td> &nbsp;  </td></tr>
        </table>
         

        <table>
          <tr>
            <td align="right">
                <div class="txt">
                    Machine
                </div>
            </td>
            <td>
            <table>
            <tr>
            <td> <asp:UpdatePanel ID="UpdcmbMachine" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList CssClass="combo" style="margin-left: 15px;" ID="cmbMachine" AutoPostBack="true" runat="server">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel></td>
            <td> <asp:UpdatePanel ID="UptxtMachineName" runat="server">
                    <ContentTemplate>
                        <div class="text_box">
                            <asp:TextBox ID="txtMachineName" style="width: 68px;height: 21px; border-radius:5px;border: 1px solid rgb(30, 68, 99);margin-left: 12px;" Width="80"  runat="server"></asp:TextBox>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel></td>
            <td> <asp:UpdatePanel ID="UpbtnSaveMachine" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnSaveMachine" runat="server"  style="margin-left: 50px; width:56px;margin-right: 32px;" CssClass="btn btn-outline btn-success" Text="Save" />
                    </ContentTemplate>
                </asp:UpdatePanel></td>
            </tr>
            </table>
               
               
               
            </td>
            <td>
                <div class="txt" style="margin-left: -21px;">
                    Total Machine
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtMachineTotal" style="height: 21px;margin-left: 15px; border: 1px solid #1e4463;" Width="86" onkeypress="return isNumericKeyy(event);"
                         runat="server"></asp:TextBox></div>
                <asp:UpdatePanel ID="UpbtnAddStitchingLineMachine" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnAddStitchingLineMachine" runat="server" style="margin-left: 120px;margin-top: -23px;" CssClass="btn btn-outline btn-success" Text="Add to grid" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table width="100%">
     <tr style="height:10px;"> <td> &nbsp;  </td></tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdgStitchingLineMachine" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadGrid ID="dgStitchingLineMachine" runat="server" CellSpacing="0" AutoGenerateColumns="false"
                            Skin="WebBlue" Visible="False" PageSize="50">
                            <MasterTableView>
                                <Columns>
                                    <telerik:GridBoundColumn HeaderText="VAF_StitchingLineMachineID" DataField="VAF_StitchingLineMachineID">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Machine" DataField="Machine">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Total Machine" DataField="MachineTotal">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridButtonColumn UniqueName="DeleteColumn" Text="" CommandName="Delete"
                                        ConfirmTextFormatString="Are You Sure You want to Delete Record" HeaderStyle-Width="2%"
                                        ButtonType="ImageButton">
                                    </telerik:GridButtonColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
         
          </table>
    <table width="100%">
     <tr style="height:15px;"> <td> &nbsp;  </td></tr>
        <tr>
            <td class="heading">
                Compliances Information
            </td>
        </tr>
           <tr style="height:15px;"> <td> &nbsp;  </td></tr>
        </table>

        <table>
         <tr>
            <td>
                <asp:UpdatePanel ID="upCertificate" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkSocialCompliances" runat="server">
       <div class="Link">    Social Compliances</div>
                        </asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
           </table>
    <table>
        <tr>
        <td style="width :370px;"></td>
        <td align="center">
               <asp:Button ID="btnSave" runat="server" style="width:70px;" CssClass="btn btn-outline btn-success" Text="Save" />
               
                           </td>
            <td align="center">
                 <asp:Button ID="btnCancel" runat="server"  CssClass="btn btn-outline btn-danger" Text="Cancel" />
            </td>
            <td style="width :200px;"></td>
        </tr>
    </table>
 
</asp:Content>
