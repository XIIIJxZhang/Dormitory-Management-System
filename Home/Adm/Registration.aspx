<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Adm/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Dormitory_Management_System.Home.Adm.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AdminMainContent" runat="server">
    <div class="container">
        <div class="row">
            <!-- Main Content Area -->
            <div class="col-lg-6 offset-lg-3 p-5">
                <!-- Header -->
                <h1 class="text-center mb-4">Register an Account</h1>
                <!-- Form Fields -->
                <div class="form-group mb-3 d-flex">
                    <div class="flex-grow-1 me-2" style="width: 50%;">
                        <label for="idNum" class="form-label fw-bold">ID Num</label>
                        <input type="text" class="form-control" placeholder="Enter your ID" runat="server" id="usrIDRe"/>
                    </div>
                    <div class="flex-grow-1 me-2" style="width: 50%;">
                        <label for="name" class="form-label fw-bold">Your name</label>
                        <input type="text" class="form-control" placeholder="Enter your Name" runat="server" id="usrNameRe"/>
                    </div>
                </div>
                <div class="form-group mb-3 d-flex">
                    <div class="flex-grow-1 me-2">
                        <label for="floor" class="form-label fw-bold">Floor</label>
                        <input type="text" class="form-control" placeholder="Floor" runat="server" id="usrFloorRe"/>
                    </div>
                    <div class="flex-grow-1">
                        <label for="building" class="form-label fw-bold">Building</label>
                        <input type="text" class="form-control" placeholder="Building" runat="server" id="usrBuildingRe"/>
                    </div>
                    <div class="flex-grow-1">
                        <label for="dormInfo" class="form-label fw-bold">DormInfo</label>
                        <input type="text" class="form-control" placeholder="DormInfo" runat="server" id="usrDormRe"/>
                    </div>
                </div>
                <div class="form-group mb-3">
                    <label for="password" class="form-label fw-bold">Password</label>
                    <input type="text" class="form-control" placeholder="Password" runat="server" id="usrPasswordRe"/>
                </div>
                <div class="form-group mb-3">
                    <label for="tel" class="form-label fw-bold">TelNumber</label>
                    <input type="text" class="form-control" placeholder="TelNumber" runat="server" id="usrTelRe"/>
                </div>
                <div class="form-group mb-3">
                    <div class="d-flex align-items-center">
                        <div class="form-check me-3" style="margin-left:10px;">
                            <input type="radio" name="role" id="idenStu" class="form-check-input" runat="server"/>
                            <label for="student" class="form-check-label">Student</label>
                        </div>
                        <div class="form-check me-3" style="margin-left:15px;">
                            <input type="radio" name="role" id="idenTut" class="form-check-input" runat="server"/>
                            <label for="tutor" class="form-check-label">Tutor</label>
                        </div>
                        <div class="form-check" style="margin-left:15px;">
                            <input type="radio" name="role" id="idenWar" class="form-check-input" runat="server"/>
                            <label for="warden" class="form-check-label">Warden</label>
                        </div>
                        <div class="form-check" style="margin-left:15px;">
                            <input type="radio" name="role" id="idenAdmin" class="form-check-input" runat="server"/>
                            <label for="admin" class="form-check-label">Administrator</label>
                        </div>
                    </div>
                </div>
                <div class="text-center mt-4">
                    <asp:Label runat="server" ID="Errmsg" class="text-danger"/>
                    <button type="button" id="CreateBtn" runat="server" onserverclick="CreateBtn_Click" class="btn btn-primary w-100" style="font-size: 1.25rem;">CREATE ACCOUNT</button>
                </div>
                <div class="text-center mt-2">
                    <small>By signing up to our service, you agree to <a href="https://muse.cuhk.edu.cn/page/15" class="text-decoration-none">Muse College Motto</a>.</small>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
