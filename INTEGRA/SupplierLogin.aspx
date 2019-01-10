<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SupplierLogin.aspx.vb" Inherits="SupplierLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="css/login.css" rel="stylesheet" type="text/css" />
</head>

<body>
  <form id="form1" runat="server">
<script type="text/javascript" >


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

<div class="main_container">
    <div class="bg_image">
        <div class="login_area">
            <div class="heading">
                LOGIN</div>
                <div class="heading"> 
    <asp:Label ID="lblErrorMsg"  ForeColor="Red" runat="server"  ></asp:Label>
</div>
            <div class="line">
                <div class="txt">
                    User Name</div>
                <div class="txt_box">
                    <asp:textbox id="txtUserCode" runat="server"></asp:textbox>
                </div>
            </div>
            <div class="line">
                <div class="txt">
                    Password</div>
                <div class="txt_box">
                    <asp:textbox id="txtPassword" runat="server" textmode="Password"></asp:textbox>
                </div>
            </div>
            <div class="forget">
                <a href="#">Forget Password ?</a></div>
            <div class="login">
                      <asp:ImageButton ID="btnLogin" runat="server"  ImageUrl="images/login.png" />
                 
        </div>
        <div class="register_area" >
        <div class="lbl_message"> <asp:label id="lblmsg" forecolor="Red" runat="server"></asp:label></div>        
            <div class="left_area">
                <div class="heading_2">
                    CREATE AN ACCOUNT
                  
                </div>
                
                <div class="line_2">
                    <div class="txt_2">
                        First Name</div>
                    <div class="txt_box_2">
                        <asp:textbox id="txtFirstName" runat="server"></asp:textbox>
                    </div>
                </div>
                <div class="line_2">
                    <div class="txt_2">
                        Last Name</div>
                    <div class="txt_box_2">
                        <asp:textbox id="txtLastName" runat="server"></asp:textbox>
                    </div>
                </div>
                <div class="line_2">
                    <div class="txt_2">
                        Company Name</div>
                    <div class="txt_box_2">
                        <asp:textbox id="txtCompanyName" runat="server"></asp:textbox>
                    </div>
                </div>
            </div>
            <div class="right_area">
                <div class="heading_2">
                </div>
                 
                <div class="line_2">
                    <div class="txt_2">
                        Email</div>
                    <div class="txt_box_2">
                        <asp:textbox id="txtEmail" runat="server"></asp:textbox>
                    </div>
                </div>
                <div class="line_2">
                    <div class="txt_2">
                        Phone No</div>
                    <div class="txt_box_2">
                        <asp:textbox id="txtPhoneNo" onkeypress="return isNumericKeyy(event);" runat="server"></asp:textbox>
                    </div>
                </div>
                <div class="line_2">
                    <div class="txt_2">
                       <%-- ECP Code--%></div>
                    <div class="txt_box_3">
                        <asp:textbox id="txtExisting" runat="server" Visible ="false" ></asp:textbox>
                    </div>
                    <div class="register">
                      <asp:ImageButton ID="btnregister" runat="server"  ImageUrl="images/register.png" />
                      
                </div>
            </div>
        </div>
    </div>
    <div class="txt_footer">
        Developed and Maintain by<br />
        <a href="http://itg.net.pk/" target="_blank">ITG (Pvt) Ltd.</a>
    </div>
</div>
 
</form> 
</body>
</html>

