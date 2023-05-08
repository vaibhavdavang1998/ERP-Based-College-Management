<%@ Page Title="" Language="C#" MasterPageFile="~/sanjeevanAdmin/MasterAdmin.master" AutoEventWireup="true" CodeFile="time-table.aspx.cs" Inherits="sanjeevanAdmin_time_table" %>
<%@ MasterType VirtualPath="~/sanjeevanAdmin/MasterAdmin.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <span class="space50"></span>
    <span class="space50"></span>
    <h2 class="pgTitle">Time Table</h2>
    <span class="space30"></span>
    
    <div class="formPanel">
        <span class="space20"></span>
        <h4 class="formTitle themeDarkBg">Add Time Table Photos</h4>
        <span class="titleLine"></span>
        <div class="pad_10">
            <div class="colorLightBlue">
                <span>Id :</span>
                <asp:Label ID="lblId" runat="server" Text="[New]"></asp:Label>
            </div>
            <span class="space10"></span>
            <span class="labelCap">Select year:*</span>
            <asp:DropDownList ID="ddrProduct" CssClass="cmbBox" runat="server" Width="600" AutoPostBack="true" OnSelectedIndexChanged="ddrProduct_SelectedIndexChanged" >
                <asp:ListItem Value="0"><-Select-></asp:ListItem>
            </asp:DropDownList>
            <span class="space10"></span>
            <span class="formLable dspBlk mrgBtm10">Photo:</span>
            <asp:FileUpload ID="fuImg" runat="server"  />
            <span class="space10"></span>
            <span class="space10"></span>

            <asp:Button ID="btnSubmit" runat="server" CssClass="buttonForm float_left mrgRgt10" Text="Submit" OnClick="btnSubmit_Click" />
            <div class="float_clear"></div>

            <span class="space20"></span>
        </div>
    </div>
    <span class="space15"></span>
    <%=photoMarkup %>

</asp:Content>

