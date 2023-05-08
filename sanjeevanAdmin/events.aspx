<%@ Page Title="" Language="C#" MasterPageFile="~/sanjeevanAdmin/MasterAdmin.master" AutoEventWireup="true" CodeFile="events.aspx.cs" Inherits="sanjeevanAdmin_events" %>
<%@ MasterType VirtualPath="~/sanjeevanAdmin/MasterAdmin.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <span class="space50"></span>
    <span class="space50"></span>
    <h2 class="pgTitle">Events</h2>
    <span class="space30"></span>
    
    <div class="formPanel">
        <h4 class="formTitle themeDarkBg">Add Events Photos</h4>
        <span class="titleLine"></span>
        <div class="pad_10">
            <div class="colorLightBlue">
                <span>Id :</span>
                <asp:Label ID="lblId" runat="server" Text="[New]"></asp:Label>
            </div>
            <span class="space10"></span>
            <span class="labelCap ">Image Title:*</span>
            <asp:TextBox ID="txtTitle" runat="server" CssClass="textBox" Width="600"></asp:TextBox>
            <span class="space10"></span>

            <span class="space10"></span>
            <span class="formLable dspBlk mrgBtm10">Select Photo:*</span>
            <asp:FileUpload ID="fuImg" runat="server"  />
            <span class="space10"></span>

            
            <asp:Button ID="btnSubmit" runat="server" CssClass="buttonForm float_left mrgRgt10" Text="Submit" OnClick="btnSubmit_Click" />
            <div class="float_clear"></div>

            <span class="space20"></span>
        </div>
    </div>
    <span class="space30"></span>
    <%=photoMarkup %>

</asp:Content>

