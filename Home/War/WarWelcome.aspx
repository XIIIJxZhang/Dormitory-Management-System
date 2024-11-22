<%@ Page Title="" Language="C#" MasterPageFile="~/Home/War/WarMaster.Master" AutoEventWireup="true" CodeBehind="WarWelcome.aspx.cs" Inherits="Dormitory_Management_System.Home.War.WarWelcome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.29.1/moment.min.js"></script>
<script type="text/javascript">
    function updateTime() {
        var now = moment().format('dddd, MMMM Do YYYY, h:mm:ss A');
        document.getElementById('datetime').innerHTML = now;
    }
    setInterval(updateTime, 1000);
</script>
<style>
    .main-container {
        position: absolute;
        top: 5.9px;
        left: 18%;
        height: 800px;
        background-image: url('<%= ResolveUrl("~/Assets/pic/welcome/bkg.png") %>');
        background-size: contain;
        background-position: center;
        background-repeat: no-repeat;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WarMainContent" runat="server">
    <div class="container text-center mt-5 main-container"">
    <div class="content-overlay" style="margin-top: 150px; margin-left: -25px; font-weight: bold;">
        <h1 style="font-weight: bold;">Welcome to the Dormitory Management System!</h1>
        <div class="mt-4">
            <h3 id="datetime" style="font-weight: bold;">Loading current date and time...</h3>
        </div>
        <div class="mt-4">
            <asp:Label ID="lblWeather" style="font-size: 25px;" runat="server" Text="Weather: Loading..."></asp:Label>
            <br />
            <asp:Label ID="lblTemperature" style="font-size: 25px;" runat="server" Text="Temperature: Loading..."></asp:Label>
        </div>
        <div class="mt-5">
            <h2 style="font-weight: bold;">Today's Summary</h2>
            <p style="font-weight: bold;">Manage your dormitory information, register new accounts, or simply explore the system's functionalities.</p>
        </div>
    </div>
</div>
</asp:Content>
