<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Project.Pages.Register" %>

<!DOCTYPE html>
<html lang="en">
    <head>
        <title>Register - PopItUp</title>

        <link rel="stylesheet" type="text/css" href="/Content/bootstrap.css">
        <link rel="stylesheet" type="text/css" href="/Content/bootstrap-multiselect.css">
        <link rel="stylesheet" type="text/css" href="/Content/Site.css">
        <script src="/Scripts/modernizr-2.8.3.js"></script>
    </head>

    <body>
        <nav class="navbar navbar-inverse" role="navigation">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-left" href="">
                        <img src="/Content/Images/logo.png">
                    </a>
                </div>
                <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                    <ul class="nav navbar-nav" id="mainmenu-left-bar">
                        <li>
                            <a href="/Home/Index">Home</a>
                        </li>
                        <li>
                            <a href="/Bars/Index">Bars</a>
                        </li>
                        <li>
                            <a href="/Events/Index">Evenementen</a>
                        </li>
                        
                        <li>
                            <a href="/Help">API</a>
                        </li>

                    </ul>
                    <ul class="nav navbar-nav navbar-right" id="mainmenu-right-bar">
                        <li>
                            <a href="/Account/Login">Login</a>
                        </li>
                        <li>
                            <a class="active" href="/Account/Register">Register</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
        <div class="page-wrap">
            <div class="container">
                <div class="row">
                    <div id="register_box">
                        <div id="login_box_header">
                            <h2>
                                Register
                            </h2>
                        </div>
                        <div id="login_box_content">
                            <form id="form1" runat="server">
                                <% if(IsPostBack) { %>
                                    <ul class="alert alert-danger" style="padding-left: 3rem;">
                                                     
                                        <asp:RequiredFieldValidator 
                                            ID="rfv_first_name" 
                                            ControlToValidate="txt_first_name" 
                                            runat="server" 
                                            ErrorMessage="<li>You forgot to enter your first name</li>" 
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                           
                                        <asp:RequiredFieldValidator 
                                            ID="rfv_last_name" 
                                            ControlToValidate="txt_last_name" 
                                            runat="server" 
                                            ErrorMessage="<li>You forgot to enter your last name</li>" 
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator> 
                                           
                                        <asp:RequiredFieldValidator 
                                            ID="rfv_username" 
                                            ControlToValidate="txt_username" 
                                            runat="server" 
                                            ErrorMessage="<li>You forgot to enter a username</li>" 
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                        
                                        <asp:RequiredFieldValidator 
                                            ID="rfv_email" 
                                            ControlToValidate="txt_email" 
                                            runat="server" 
                                            ErrorMessage="<li>You forgot to enter an email-address</li>" 
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                           
                                        <asp:RegularExpressionValidator 
                                            ID="rev_email" 
                                            runat="server" 
                                            Display="Dynamic"
                                            ControlToValidate="txt_email" 
                                            ErrorMessage="<li>Enter a valid email</li>" 
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                        </asp:RegularExpressionValidator>                                        
                                        
                                        <asp:CompareValidator 
                                            ID="CompareValidator1" 
                                            runat="server"
                                            Display="Dynamic" 
                                            ErrorMessage="<li>The passwords don't match</li>" 
                                            ControlToValidate="txt_password" 
                                            ControlToCompare="txt_confirm_password">
                                        </asp:CompareValidator>

                                        <asp:RequiredFieldValidator 
                                            ID="rfv_password" 
                                            ControlToValidate="txt_password" 
                                            runat="server" 
                                            ErrorMessage="<li>You forgot to enter a password</li>" 
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>  
                                           
                                        <asp:CustomValidator 
                                            ID="cv_email" 
                                            runat="server" 
                                            Display="Dynamic"
                                            OnServerValidate="EmailValidate" 
                                            ControlToValidate="txt_email" 
                                            ErrorMessage="<li>The email is already in use</li>">
                                        </asp:CustomValidator>                                     
                                        
                                        <asp:RequiredFieldValidator 
                                            ID="rfv_confirm_password" 
                                            ControlToValidate="txt_confirm_password" 
                                            runat="server" 
                                            ErrorMessage="<li>You forgot to enter a password</li>" 
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>                                        
                                    </ul>
                                <% } %>
                                    
                                <div class="form-group">
                                    <asp:Label ID="lbl_first_name" runat="server" Text="First name:"></asp:Label>
                                    <asp:TextBox ID="txt_first_name" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <asp:Label ID="lbl_last_name" runat="server" Text="Last name:"></asp:Label>
                                    <asp:TextBox ID="txt_last_name" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <asp:Label ID="lbl_username" runat="server" Text="Username:"></asp:Label>
                                    <asp:TextBox ID="txt_username" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <asp:Label ID="lbl_email" runat="server" Text="Email:"></asp:Label>
                                    <asp:TextBox ID="txt_email" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:Password></asp:Password>
                                </div>

                                <div class="form-group">
                                    <asp:Label ID="lbl_password" runat="server" Text="Password:"></asp:Label>
                                    <asp:TextBox ID="txt_password" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <asp:Label ID="lbl_confirm_password" runat="server" Text="Confirm Password"></asp:Label>
                                    <asp:TextBox ID="txt_confirm_password" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>

                                <asp:Button ID="login_button" CssClass="btn btn-default" runat="server" Text="Register" OnClick="login_button_Click" />
                            </form>
                        </div>
                    </div>
                </div>
            </div>
            <footer>
                <div class="container">
                    <div class="col-xs-4">
                        <h3>
                            PopItUp
                        </h3>
                        <ul>
                            <li>
                                <a href="/Home/Index">Home</a>
                            </li>
                            <li>
                                <a href="/Home/About">About</a>
                            </li>
                            <li>
                                <a href="/Account/login">Login</a>
                            </li>
                            <li>
                                <a href="/Account/register">Register</a>
                            </li>
                        </ul>
                    </div>
                    <div class="col-xs-4">
                        <h3>
                            Aanbod
                        </h3>
                        <ul>
                            <li>
                                <a href="/Bars/Index">Bars</a>
                            </li>        
                            <li>         
                                <a href="/Events/Index">Evenementen</a>
                            </li>     
                        </ul>
                    </div>
                    <div class="col-xs-4">
                        <h3>
                            sociale media
                        </h3>
                        <ul>
                            <li>
                                <a href="#">Facebook</a>
                            </li>
                            <li>
                                <a href="#">Youtube</a>
                            </li>
                            <li>
                                <a href="#">Instagram</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </footer>
         </div>
       

        <script src="/Scripts/jquery-3.1.1.js"></script>
        <script src="/Scripts/bootstrap.js"></script>
        <script src="/Scripts/respond.js"></script>
        <script src="/Scripts/bootstrap-multiselect.js"></script>
    </body>
</html>
