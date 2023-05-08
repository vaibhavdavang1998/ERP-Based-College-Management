<%@ Page Title="" Language="C#" MasterPageFile="~/sanjeevanAdmin/MasterAdmin.master" AutoEventWireup="true" CodeFile="add-student.aspx.cs" Inherits="sanjeevanAdmin_add_student" %>
<%@ MasterType VirtualPath="~/sanjeevanAdmin/MasterAdmin.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            callCalendar();
        });
        function callCalendar() {

            $(<%=txtRegDate.ClientID%>).datepick({ dateFormat: 'dd/mm/yyyy' });
            $(<%=txtDOB.ClientID%>).datepick({ dateFormat: 'dd/mm/yyyy' });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <span class="space20"></span>
    <h2 class="pgTitle">Member Register</h2>
    <span class="space20"></span>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" OnLoad="UpdatePanel1_Load" >
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
                                <div class="w50">
                                    <span class="labelCap ">Registration Date:*</span>
                                <asp:TextBox ID="txtRegDate" runat="server" CssClass="textBox" placeholder="Click Here to open Calendar"></asp:TextBox>
                                    <span class="space10"></span>
                            </div>
                            

                             
                            <div class="w50 float_left extra_float">
                                <span class="space10"></span>
                                <span class="labelCap ">Year:*</span>
                                <asp:DropDownList ID="ddrYear" runat="server" CssClass="cmbBox" AutoPostBack="True" OnSelectedIndexChanged="ddrYear_SelectedIndexChanged"></asp:DropDownList>
                                <span class="space10"></span>
                            </div>
                            

                            
                            <div class="w50 float_left extra_float">
                                <span class="space10"></span>
                                <span class="labelCap ">Trade Name:*</span>
                                <asp:DropDownList ID="ddrTrade" runat="server" CssClass="cmbBox" ></asp:DropDownList>
                                <span class="space10"></span>
                            </div>
                            <div class="float_clear"></div>

                            <span class="space10"></span>
                            <span class="labelCap ">Student Name:*</span>
                            <asp:TextBox ID="txtName" runat="server" CssClass="textBox" MaxLength="50"></asp:TextBox>
                            <span class="space10"></span>

                            <span class="space10"></span>
                            <span class="labelCap ">Gender:*</span>
                            <asp:RadioButton ID="rdoMale" runat="server" GroupName="gender" Text="Male" CssClass="rdButton"/>
                            <asp:RadioButton ID="rdoFemale" runat="server" GroupName="gender" Text="Female" CssClass="rdButton"/>
                            <span class="space10"></span>

                            <span class="space10"></span>
                            <span class="labelCap ">Student Address:*</span>
                            <asp:TextBox ID="txtAddr" runat="server" CssClass="textBox" MaxLength="300"></asp:TextBox>
                            <span class="space10"></span>

                            <div class="w50 float_left extra_float">
                                <span class="space10"></span>
                                <span class="labelCap ">Mobile No:*</span>
                                <asp:TextBox ID="txtMobile" runat="server" CssClass="textBox" MaxLength="10"></asp:TextBox>
                                <span class="space10"></span>
                            </div>

                            <div class="w50 float_left extra_float">
                                <span class="space10"></span>
                                <span class="labelCap ">Whatsapp No:*</span>
                                <asp:TextBox ID="txtWaNo" runat="server" CssClass="textBox" MaxLength="10"></asp:TextBox>
                                <span class="space10"></span>
                            </div>
                            <div class="float_clear"></div>

                            <div class="w50 float_left extra_float">
                                <span class="space10"></span>
                                <span class="labelCap ">Parent Name:*</span>
                                <asp:TextBox ID="txtParentName" runat="server" CssClass="textBox" MaxLength="100"></asp:TextBox>
                                <span class="space10"></span>
                            </div>

                            <div class="w50 float_left extra_float">
                                <span class="space10"></span>
                                <span class="labelCap ">Occupation:*</span>
                                <asp:TextBox ID="txtOccupation" runat="server" CssClass="textBox"  MaxLength="100"></asp:TextBox>
                                <span class="space10"></span>
                            </div>
                            <div class="float_clear"></div>

                            <div class="w50 float_left extra_float">
                                <span class="space10"></span>
                                <span class="labelCap ">Cast:*</span>
                                <asp:TextBox ID="txtCast" runat="server" CssClass="textBox"  MaxLength="100"></asp:TextBox>
                                <span class="space10"></span>
                            </div>
                            <div class="w50 float_left extra_float">
                                <span class="space10"></span>
                                <span class="labelCap ">Blood Group:*</span>
                                <asp:DropDownList ID="ddrBlood" runat="server" CssClass="cmbBox" >
                                    <asp:ListItem Value="0"><- select -></asp:ListItem>
                                    <asp:ListItem Value="1">A+</asp:ListItem>
                                    <asp:ListItem Value="2">A-</asp:ListItem>
                                    <asp:ListItem Value="3">B+</asp:ListItem>
                                    <asp:ListItem Value="4">B-</asp:ListItem>
                                    <asp:ListItem Value="5">AB+</asp:ListItem>
                                    <asp:ListItem Value="6">AB-</asp:ListItem>
                                    <asp:ListItem Value="7">O+</asp:ListItem>
                                    <asp:ListItem Value="8">O-</asp:ListItem>
                                </asp:DropDownList>
                                <span class="space10"></span>
                            </div>
                            <div class="float_clear"></div>

                            <div class="w50 float_left extra_float">
                                <span class="space10"></span>
                                <span class="labelCap ">Birth Date:*</span>
                                <asp:TextBox ID="txtDOB" runat="server" CssClass="textBox"></asp:TextBox>
                                <span class="space10"></span>
                            </div>
                            <div class="w50 float_left extra_float">
                                <span class="space10"></span>
                                <span class="labelCap ">Age:*</span>
                                <asp:TextBox ID="txtAge" runat="server" CssClass="textBox"></asp:TextBox>
                                <span class="space10"></span>
                            </div>
                            <div class="float_clear"></div>

                            <span class="space10"></span>
                            <span class="labelCap ">Email Id:</span>
                            <asp:TextBox ID="txtEmailId" runat="server" CssClass="textBox"></asp:TextBox>
                            <span class="space10"></span>

                            <span class="space10"></span>
                            <span class="labelCap ">State:</span>
                            <asp:TextBox ID="txtState" runat="server" CssClass="textBox"></asp:TextBox>
                            <span class="space10"></span>

                            <span class="space10"></span>
                            <span class="labelCap ">Nationality:</span>
                            <asp:TextBox ID="txtNationality" runat="server" CssClass="textBox"></asp:TextBox>
                            <span class="space10"></span>

                            <span class="space10"></span>
                            <span class="labelCap ">Extra Activity:</span>
                            <asp:CheckBox ID="Chkpresident" Text=" President" CssClass="chkList display_Blk" runat="server" />
                            <asp:CheckBox ID="ChkclassReprentive" Text=" Class Reprentive" CssClass="chkList display_Blk" runat="server" />
                            <asp:CheckBox ID="ChkeventOrganizer" Text=" Event Organizer" CssClass="chkList display_Blk" runat="server" />
                            <asp:CheckBox ID="Chktreasurer" Text=" Treasurer" CssClass="chkList display_Blk" runat="server" />
                            <asp:CheckBox ID="Chkvolunteer" Text=" Volunteer" CssClass="chkList display_Blk" runat="server" />
                            <asp:CheckBox ID="ChkotherSocial" Text=" Other Social" CssClass="chkList display_Blk" runat="server" />

                           

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
                    <div class="scroll">
                    <div class="formPanel">
                        <asp:GridView ID="gvMemberReg" runat="server" AutoGenerateColumns="False" CssClass="gvApp" GridLines="None" OnRowDataBound="gvMemberReg_RowDataBound">
                            <RowStyle CssClass="row" />
                            <AlternatingRowStyle CssClass="alt" />
                            <Columns>
                                <asp:BoundField DataField="studentId">
                                    <HeaderStyle CssClass="HideCol" />
                                    <ItemStyle CssClass="HideCol" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="mGender">
                                    <HeaderStyle CssClass="HideCol" />
                                    <ItemStyle CssClass="HideCol" />
                                </asp:BoundField>
                                <asp:BoundField DataField="studentName" HeaderText="Name">
                                    <ItemStyle Width="30%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="mobileNo" HeaderText="Mobile No">
                                    <ItemStyle Width="10%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Gender">
                                    <ItemStyle Width="10%" />
                                    <ItemTemplate>
                                        <asp:Literal ID="litGender" runat="server"></asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="birthDate" HeaderText="Birth Date">
                                    <ItemStyle Width="10%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="tradeName" HeaderText="Trade Name">
                                    <ItemStyle Width="10%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="yearName" HeaderText="Year">
                                    <ItemStyle Width="10%" />
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
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="float_clear"></div>
</asp:Content>

