<%@ Page Title="Dormitory Information" Language="C#" MasterPageFile="~/Home/Adm/AdminMaster.Master" AutoEventWireup="true" CodeBehind="DormsInfo.aspx.cs" Inherits="Dormitory_Management_System.Home.Adm.DormsInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Additional styles or scripts if needed -->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="AdminMainContent" runat="server">
    <section class="Hui-article-box">
        <!-- Navigation bar -->
        <nav class="breadcrumb bg-light p-3" style="margin: 10px 0 0 0; border-radius: 0px; position: absolute; top: 68px; left: 18%; width: 50%;">
            <i class="fas fa-home"></i> Home
            <span class="mx-2">&gt;&gt;</span>
            Administrator
            <span class="mx-2">&gt;&gt;</span>
            Dorm Info
        </nav>

        <div class="Hui-article" style="overflow: hidden; margin-top: 60px;">
            <article class="cl pd-20">
                <!-- Search section -->
                <div class="d-flex justify-content-between align-items-center mb-3">
                    <div class="ml-auto">
                        <label>Search:
                            <asp:TextBox ID="SearchTextBox" runat="server" CssClass="form-control form-control-sm" placeholder="Enter keyword..."/>
                        </label>
                        <asp:Button ID="SearchButton" runat="server" Text="Search" OnClick="SearchButton_Click" CssClass="btn btn-primary btn-sm ml-2" />
                    </div>
                </div>
                <!-- Table section -->
                <div class="table-responsive mt-4">
                    <asp:GridView ID="dormTable" runat="server" AutoGenerateColumns="False" DataKeyNames="DormInfo"
                        CssClass="table table-striped table-bordered table-hover" GridLines="None" OnRowCommand="dormTable_RowCommand">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="DormInfo" HeaderText="DormInfo" ReadOnly="True" />
                            <asp:BoundField DataField="StuID" HeaderText="Student ID" />
                            <asp:BoundField DataField="EleFee" HeaderText="Electricity Fee(¥)" />
                            <asp:TemplateField HeaderText="Info">
                                <ItemTemplate>
                                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="EditDorm" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-primary btn-sm ml-2" />
                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="DeleteDorm" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-sm ml-2" OnClientClick="return confirm('Are you sure you want to delete this dorm information?');" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </article>
        </div>
    </section>
</asp:Content>
