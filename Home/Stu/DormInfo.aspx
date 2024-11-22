<%@ Page Title="Dormitory Information" Language="C#" MasterPageFile="~/Home/Stu/StuMaster.Master" AutoEventWireup="true" CodeBehind="DormInfo.aspx.cs" Inherits="Dormitory_Management_System.Home.Stu.DormInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .dorm-info-container {
            display: grid;
            grid-template-columns: 1fr 1fr;
            gap: 20px;
            max-width: 1000px;
            margin: 50px auto;
            padding: 30px;
            background-color: #f1f1f1;
            border-radius: 20px;
            box-shadow: 0 8px 16px rgba(0, 0, 0, 0.1);
            font-family: "Verdana", Geneva, Tahoma, sans-serif;
        }
        .dorm-info-header {
            grid-column: 1 / -1;
            text-align: center;
            color: #4A90E2;
            font-size: 2.5em;
            font-weight: bold;
            margin-bottom: 20px;
        }
        .dorm-detail {
            background-color: #ffffff;
            border-radius: 15px;
            padding: 20px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.05);
        }
        .dorm-detail h3 {
            color: #d35400;
            font-size: 1.4em;
            border-bottom: 2px solid #d35400;
            padding-bottom: 5px;
            margin-bottom: 15px;
        }
        .dorm-detail p {
            font-size: 1.1em;
            color: #555;
            line-height: 1.8;
        }
        .dorm-detail p strong {
            color: #2c3e50;
        }
        .qr-section {
            background-color: #ffffff;
            border-radius: 15px;
            padding: 40px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.05);
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
        }
        .qr-images {
            display: flex;
            gap: 20px;
            margin-bottom: 20px;
        }
        .qr-images img {
            max-width: 45%;
            height: auto;
        }
        .qr-section label {
            font-size: 1.1em;
            color: #333;
            text-align: center;
        }
        .btn-container {
            grid-column: 1 / -1;
            text-align: center;
            margin-top: 30px;
        }
        .dashboard-btn {
            display: inline-block;
            padding: 12px 25px;
            background-color: #e74c3c;
            color: #ffffff;
            font-size: 1em;
            text-decoration: none;
            border-radius: 10px;
            transition: background-color 0.3s ease;
        }
        .dashboard-btn:hover {
            background-color: #c0392b;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="StuMainContent" runat="server">
    <div class="dorm-info-container">
        <div class="dorm-info-header">Your Dormitory Information</div>
        
        <!-- Dormitory Information Section -->
        <div class="dorm-detail">
            <h3>Dormitory Details</h3>
            <p><strong>Dormitory Info:</strong> <asp:Label ID="DormInfoLabel" runat="server"></asp:Label></p>
            <p><strong>Student ID:</strong> <asp:Label ID="StuIDLabel" runat="server"></asp:Label></p>
            <p><strong>Electricity Fee:</strong> <asp:Label ID="EleFeeLabel" runat="server"></asp:Label></p>
        </div>

        <!-- QR Code Section -->
        <div class="qr-section">
            <div class="qr-images">
                <img src="<%= ResolveUrl("~/Assets/pic/person/EleFee.png") %>" alt="QR Code">
                <img src="<%= ResolveUrl("~/Assets/pic/person/EleFee02.png") %>" alt="QR Code">
            </div>
            <label>Please Scan the QR Code to Charge.</label>
        </div>

        <!-- Error Message Display -->
        <asp:Label ID="Errmsg" runat="server" ForeColor="Red"></asp:Label>

        <!-- Back to Dashboard Button -->
        <div class="btn-container">
            <a href="/Home/Stu/StuWelcome.aspx" class="dashboard-btn">Back to Dashboard</a>
        </div>
    </div>
</asp:Content>