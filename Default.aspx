<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <meta content="IE=edge" http-equiv="X-UA-Compatible" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1.0,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@300;400;500;700&display=swap" rel="stylesheet">
    <link href="sanjeevanAdmin/css/iAdmin.css" rel="stylesheet" />
    <link href="sanjeevanAdmin/css/generic.css" rel="stylesheet" />
     <link href="sanjeevanAdmin/css/toastr.min.css" rel="stylesheet" />

    <script src="sanjeevanAdmin/js/jquery-1.8.2.min.js"></script>
    <script src="sanjeevanAdmin/js/toastr.min.js"></script>
    <script src="sanjeevanAdmin/js/customscripts.js"></script>
</head>
<body>
    <span class="space30"></span>
        <div class="txtCenter width100">
            <img src="images/logo.png" class="logotxt"/>
        </div>
        <span class="space50"></span>
        <%--<span class="space30"></span>--%>
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div id="logWrap">
                        <div class="logBox " >
                            <div class="pad_15 ">
                                <h1 class="size-large clrPrimaryTxt wt-bold">Administrator Login</h1>
                                <span class="space30"></span>
                                <span class="captionLogin mrg_B_10">UserName</span>
                                <div class=" ">
                                    <asp:TextBox ID="txtUserName" runat="server" class="textBoxLogin"></asp:TextBox>
                                </div>
                                <span class="space30"></span>
                                <span class="captionLogin mrg_B_10">Password</span>
                                <div class=" ">
                                    <asp:TextBox ID="txtPwd" runat="server" class="textBoxLogin" TextMode="Password"></asp:TextBox>
                                </div>
                                <span class="space20"></span>
                                <asp:Button ID="cmdSign" runat="server" Text="Login" class="buttonFormLogin" 
                                onclick="cmdSign_Click"/>
                                <span class="space20"></span>
                                <%--<asp:Button ID="cmdSignUp" runat="server" Text="Sign Up" class="buttonFormLogin" 
                                onclick="cmdSignUp_Click"/>--%>
                                <div class="float_clear"></div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            </form>
</body>
</html>
