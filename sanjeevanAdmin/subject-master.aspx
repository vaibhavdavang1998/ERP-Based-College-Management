<%@ Page Title="" Language="C#" MasterPageFile="~/sanjeevanAdmin/MasterAdmin.master" AutoEventWireup="true" CodeFile="subject-master.aspx.cs" Inherits="sanjeevanAdmin_subject_master" %>
<%@ MasterType VirtualPath="~/sanjeevanAdmin/MasterAdmin.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <span class="space50"></span>
    <span class="space20"></span>
    <h2 class="pgTitle">Add Subject</h2>
    <span class="space20"></span>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div class="col_50p">
                <div class="pad_10">
                    <div class="formPanel">

                        <h4 class="formTitle themeDarkBg"><%=pgTitle %></h4>
                        <span class="titleLine"></span>
                        <div class="pad_10" style="position: relative">
                            <div style="display: none">
                                <span>Id :</span>
                                <asp:Label ID="lblId" runat="server" Text="[New]"></asp:Label>
                            </div>

                            <span class="space10"></span>
                            <span class="labelCap ">Year:*</span>
                            <asp:DropDownList ID="ddrYear" runat="server" CssClass="cmbBox" AutoPostBack="true" OnSelectedIndexChanged="ddrYear_SelectedIndexChanged"></asp:DropDownList>
                            <span class="space10"></span>


                            <span class="space10"></span>
                            <span class="labelCap ">Subject Name:*</span>
                            <asp:TextBox ID="txtName" runat="server" CssClass="textBox" MaxLength="30"></asp:TextBox>
                            <span class="space10"></span>

                            
                            <span class="space20"></span>
                            <asp:Button ID="btnSave" runat="server" CssClass="buttonForm float_left mrgRgt10" Text="Save Info" OnClick="btnSave_Click" />
                            <asp:Button ID="btnDelete" runat="server" CssClass="addNew float_left mrgRgt10" Text="Delete" OnClientClick="return confirm('Are your sure you want to delete this?');" OnClick="btnDelete_Click" />
                            <asp:Button ID="btnReset" runat="server" CssClass="addNew float_left " Text="Reset" OnClick="btnReset_Click" />
                            <div class="float_clear"></div>
                            <span class="space30"></span>
                        </div>

                    </div>
                </div>
            </div>

            <div class="col_50p">
                <div class="pad_10">
                    <div class="formPanel">
                        <asp:GridView ID="gvBooth" runat="server" AutoGenerateColumns="False" CssClass="gvApp" GridLines="None" OnRowDataBound="gvBooth_RowDataBound">
                            <RowStyle CssClass="row" />
                            <AlternatingRowStyle CssClass="alt" />
                            <Columns>
                                <asp:BoundField DataField="subjectId">
                                    <HeaderStyle CssClass="HideCol" />
                                    <ItemStyle CssClass="HideCol" />
                                </asp:BoundField>
                                <asp:BoundField DataField="subjectName" HeaderText="Subject Name">
                                    <ItemStyle Width="40%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="yearName" HeaderText="Year">
                                    <ItemStyle Width="40%" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <ItemStyle Width="20%" />
                                    <ItemTemplate>
                                        <asp:Literal ID="litAnch" runat="server"></asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <span class="warning">No Data to Display</span>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="float_clear"></div>
</asp:Content>

