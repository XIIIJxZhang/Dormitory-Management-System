<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Adm/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminEdit.aspx.cs" Inherits="Dormitory_Management_System.Home.Adm.AdminEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Keeping the original project's CSS classes and styles -->
    <link rel="stylesheet" href="/Content/style.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminMainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <!-- Main Content Area -->
            <div class="col-md-10 offset-md-1 p-5" style="background-color: #fff; border-radius: 10px; box-shadow: 0 0 15px rgba(0, 0, 0, 0.1);">
                <!-- Header -->
                <h1 style="text-align: center; font-size: 2rem;">Information Edit</h1>
                <!-- Dynamic Form Fields -->
                <asp:PlaceHolder ID="DynamicFormPlaceHolder" runat="server"></asp:PlaceHolder>
                <div class="d-flex justify-content-between mt-4" style="margin-left: 1rem;">
                    <asp:Button ID="SaveButton" Text="Save" runat="server" CssClass="btn btn-success" OnClick="SaveButton_Click" />
                    <asp:Button ID="ResetButton" Text="Reset" runat="server" CssClass="btn btn-warning" OnClick="ResetButton_Click" />
                    <asp:Button ID="FinishedButton" Text="Finished" runat="server" CssClass="btn btn-primary" OnClick="FinishedButton_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
