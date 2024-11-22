<%@ Page Title="Personal Information" Language="C#" MasterPageFile="~/Home/Stu/StuMaster.Master" AutoEventWireup="true" CodeBehind="PersonalInfo.aspx.cs" Inherits="Dormitory_Management_System.Home.Stu.PersonalInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f7f6;
            margin: 0;
            padding: 0;
        }

        .content-wrapper {
            padding: 20px;
            background-color: #ffffff;
            border-radius: 10px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
            max-width: 900px;
            margin: 40px auto;
        }

        .profile-pic {
            width: 100px;
            height: 100px;
            border-radius: 50%;
            border: 4px solid #ccc;
            cursor: pointer;
            display: block;
            margin: 20px auto;
            transition: transform 0.3s ease;
        }

        .profile-pic:hover {
            transform: scale(1.05);
        }

        .profile-info {
            margin: 15px 0;
            display: flex;
            align-items: center;
        }

        .profile-info label {
            font-weight: bold;
            color: #333;
            flex: 1;
        }

        .profile-info span, .profile-info input {
            font-size: 1.1em;
            color: #555;
            flex: 2;
            text-align: right;
        }

        .btn-update, .btn-save {
            background-color: #007bff;
            color: white;
            padding: 12px 20px;
            border-radius: 5px;
            text-align: center;
            width: 200px;
            margin: 30px auto;
            display: block;
            text-decoration: none;
        }

        .btn-update:hover, .btn-save:hover {
            background-color: #0056b3;
        }

        .btn-save {
            background-color: #28a745;
        }

        .btn-save:hover {
            background-color: #218838;
        }

        .error-message {
            color: red;
            font-size: 1em;
            font-weight: bold;
            text-align: center;
            margin-bottom: 20px;
        }

        .editable-input {
            font-size: 1.1em;
            color: #555;
            padding: 5px;
            border: 1px solid #ccc;
            border-radius: 5px;
            width: 100%;
            text-align: right;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="StuMainContent" runat="server">
    <div class="content-wrapper">
        <!-- Error message label -->
        <asp:Label ID="Errmsg" runat="server" CssClass="error-message" />

        <!-- Profile Picture -->
        <asp:Image ID="imgProfile" runat="server" ImageUrl="~/Assets/pic/person/You.png" CssClass="profile-pic" />

        <!-- Student Information -->
        <div class="profile-info">
            <label>Name:</label>
            <asp:TextBox ID="txtName" runat="server" CssClass="editable-input" Visible="false"></asp:TextBox>
            <span><asp:Label ID="lblName" runat="server" Text=""></asp:Label></span>
        </div>
        <div class="profile-info">
            <label>Student ID:</label>
            <asp:TextBox ID="txtStudentID" runat="server" CssClass="editable-input" Visible="false" Enabled="false"></asp:TextBox>
            <span><asp:Label ID="lblStudentID" runat="server" Text=""></asp:Label></span>
        </div>
        <div class="profile-info">
            <label>Password:</label>
            <asp:TextBox ID="txtPWD" runat="server" CssClass="editable-input" Visible="false"></asp:TextBox>
            <span><asp:Label ID="lblPWD" runat="server" Text=""></asp:Label></span>
        </div>
        <div class="profile-info">
            <label>Dormitory:</label>
            <asp:TextBox ID="txtDormitory" runat="server" CssClass="editable-input" Visible="false" Enabled="false"></asp:TextBox>
            <span><asp:Label ID="lblDormitory" runat="server" Text=""></asp:Label></span>
        </div>
        <div class="profile-info">
            <label>Phone Number:</label>
            <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="editable-input" Visible="false"></asp:TextBox>
            <span><asp:Label ID="lblPhoneNumber" runat="server" Text=""></asp:Label></span>
        </div>
        <div class="profile-info">
            <label>Floor:</label>
            <asp:TextBox ID="txtFloor" runat="server" CssClass="editable-input" Visible="false" Enabled="false"></asp:TextBox>
            <span><asp:Label ID="lblFloor" runat="server" Text=""></asp:Label></span>
        </div>
        <div class="profile-info">
            <label>Building:</label>
            <asp:TextBox ID="txtBuilding" runat="server" CssClass="editable-input" Visible="false" Enabled="false"></asp:TextBox>
            <span><asp:Label ID="lblBuilding" runat="server" Text=""></asp:Label></span>
        </div>

        <!-- Update and Save Button -->
        <asp:Button ID="btnUpdate" runat="server" Text="Update Information" CssClass="btn-update" OnClick="btnUpdate_Click" />
        <asp:Button ID="btnSave" runat="server" Text="Save Information" CssClass="btn-save" OnClick="btnSave_Click" Visible="false" />
    </div>
</asp:Content>