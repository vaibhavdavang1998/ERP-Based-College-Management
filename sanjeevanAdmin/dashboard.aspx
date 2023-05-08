<%@ Page Title="" Language="C#" MasterPageFile="~/sanjeevanAdmin/MasterAdmin.master" AutoEventWireup="true" CodeFile="dashboard.aspx.cs" Inherits="sanjeevanAdmin_dashboard" %>
<%@ MasterType VirtualPath="~/sanjeevanAdmin/MasterAdmin.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <span class="space50"></span>
    <span class="space20"></span>
    <h2 class="pgTitle">Dashboard</h2>
    <span class="space20"></span>
    <span class="titleLine"></span>
    <span class="space30"></span>
    <h1 class="themeClrBlue size-extra-large">Sanjeevan Engineering and Technology Institute, panhala, kolhapur</h1>
    <span class="space30"></span>
    <div class="pad_10">
        <div class="box_200">
            <div class="pad_10">
                <div class="neo-box">
                    <a href="add-student.aspx" class="txtDecNone">
                        <span class="size-large themeClrBlue">Total Student</span>
                        <span class="space10"></span>
                        <span class="size-large themeClrBlue"><%=arrCounts[0] %></span>
                    </a>
                </div>
            </div>
        </div>
        <div class="box_200">
            <div class="pad_10">
                <div class="neo-box">
                    <a href="subject-master.aspx" class="txtDecNone">
                        <span class="size-large themeClrBlue">Total Subject</span>
                        <span class="space10"></span>
                        <span class="size-large themeClrBlue"><%=arrCounts[1] %></span>
                    </a>
                </div>
            </div>
        </div>
        <div class="box_200">
            <div class="pad_10">
                <div class="neo-box">
                    <a href="time-table.aspx" class="txtDecNone">
                        <span class="size-large themeClrBlue">Time table</span>
                        <span class="space10"></span>
                        <span class="size-large themeClrBlue"><%=arrCounts[2] %></span>
                    </a>
                </div>
            </div>
        </div>
        <div class="box_200">
            <div class="pad_10">
                <div class="neo-box">
                    <a href="#" class="txtDecNone">
                        <span class="size-large themeClrBlue">Total Event</span>
                        <span class="space10"></span>
                        <span class="size-large themeClrBlue"><%=arrCounts[3] %></span>
                    </a>
                </div>
            </div>
        </div>
        
    <div class="float_clear"></div>
    </div>

<span class="space50"></span>
</asp:Content>

