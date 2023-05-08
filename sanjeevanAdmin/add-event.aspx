<%@ Page Language="C#" AutoEventWireup="true" CodeFile="add-event.aspx.cs" Inherits="sanjeevanAdmin_add_event" %>
<%@ MasterType VirtualPath="~/sanjeevanAdmin/MasterAdmin.master" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <span class="space50"></span>
    <span class="space50"></span>
    <h2 class="pgTitle">Notice</h2>
    <span class="space30"></span>
    
    <div class="formPanel">
        <h4 class="formTitle themeDarkBg">Add Notice Photos</h4>
        <span class="titleLine"></span>
        <div class="pad_10">
            <div class="colorLightBlue">
                <span>Id :</span>
                <asp:Label ID="lblId" runat="server" Text="[New]"></asp:Label>
            </div>
            <span class="space10"></span>
            <span class="formLable dspBlk mrgBtm10">Select Photo:*</span>
            <asp:FileUpload ID="fuImg" runat="server"  />
            <span class="space10"></span>

            <span class="space10"></span>
            <span class="labelCap ">Image Title:*</span>
            <asp:TextBox ID="txtTitle" runat="server" CssClass="textBox" Width="600"></asp:TextBox>
            <span class="space10"></span>

            <asp:Button ID="btnSubmit" runat="server" CssClass="buttonForm float_left mrgRgt10" Text="Submit" OnClick="btnSubmit_Click" />
            <div class="float_clear"></div>

            <span class="space20"></span>
        </div>
    </div>
    <span class="space30"></span>
    <%=photoMarkup %>

</body>
</html>
