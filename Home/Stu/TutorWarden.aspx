<%@ Page Title="Tutor and Warden Information" Language="C#" MasterPageFile="~/Home/Stu/StuMaster.Master" AutoEventWireup="true" CodeBehind="TutorWarden.aspx.cs" Inherits="Dormitory_Management_System.Home.Stu.TutorWarden" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/Styles/TutorWarden.css" rel="stylesheet" type="text/css" />
    <style>
        .tutor-warden-container {
            max-width: 800px;
            margin: 0 auto;
            padding: 20px;
            background-color: #f9f9f9;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            font-family: Arial, sans-serif;
        }
        .section {
            margin-bottom: 30px;
        }
        .section h3 {
            color: #00796b;
            border-bottom: 2px solid #00796b;
            padding-bottom: 5px;
            margin-bottom: 15px;
        }
        p {
            font-size: 1.1em;
            line-height: 1.6;
            margin: 10px 0;
        }
        p strong {
            color: #004d40;
        }
        .tutor-warden-container h2 {
            text-align: center;
            color: #004d40;
            margin-bottom: 40px;
        }
        .btn-container {
            text-align: center;
        }
        .back-btn {
            display: inline-block;
            padding: 10px 20px;
            background-color: #00796b;
            color: #fff;
            text-decoration: none;
            border-radius: 5px;
            transition: background-color 0.3s;
        }
        .back-btn:hover {
            background-color: #004d40;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="StuMainContent" runat="server">
    <div class="tutor-warden-container">
        <h2>Your Tutor and Warden Information</h2>
        
        <!-- Tutor Information Section -->
        <div class="section">
            <h3>Your Tutor</h3>
            <p><strong>Tutor ID:</strong> <asp:Label ID="TutorID" runat="server"></asp:Label></p>
            <p><strong>Contact:</strong> <asp:Label ID="TutorContact" runat="server"></asp:Label></p>
            <p><strong>Duty Floor:</strong> <asp:Label ID="TutorFloor" runat="server"></asp:Label></p>
            <p><strong>Building:</strong> <asp:Label ID="TutorBuilding" runat="server"></asp:Label></p>
        </div>
        
        <!-- Warden Information Section -->
        <div class="section">
            <h3>Your Warden</h3>
            <p><strong>Warden ID:</strong> <asp:Label ID="WardenID" runat="server"></asp:Label></p>
            <p><strong>Contact:</strong> <asp:Label ID="WardenContact" runat="server"></asp:Label></p>
            <p><strong>Duty Building:</strong> <asp:Label ID="WardenBuilding" runat="server"></asp:Label></p>
        </div>

        <!-- Error Message Display -->
        <asp:Label ID="Errmsg" runat="server" ForeColor="Red"></asp:Label>
        
        <!-- Ensure user type is student -->
        <asp:Label ID="PermissionMessage" runat="server" ForeColor="Red"></asp:Label>

        <!-- Back Button -->
        <div class="btn-container">
            <a href="/Home/Stu/StuWelcome.aspx" class="back-btn">Back to Dashboard</a>
        </div>
    </div>
</asp:Content>
