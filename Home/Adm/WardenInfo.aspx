<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Adm/AdminMaster.Master" AutoEventWireup="true" CodeBehind="WardenInfo.aspx.cs" Inherits="Dormitory_Management_System.Home.Adm.WardenInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="AdminMainContent" runat="server">
    <!-- Necessary scripts -->
    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.21/js/jquery.dataTables.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.bundle.min.js"></script>

    <section class="Hui-article-box">
        <!-- Navigation bar -->
        <nav class="breadcrumb bg-light p-3" style="margin: 10px 0 0 0; border-radius: 0px; position: absolute; top: 68px; left: 18%; width: 50%;">
            <i class="fas fa-home"></i> Home
            <span class="mx-2">&gt; &gt;</span>
            Administrator
            <span class="mx-2">&gt; &gt;</span>
            Warden Info
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
                    <asp:GridView ID="wardenTable" runat="server" AutoGenerateColumns="False" DataKeyNames="WarID"
                        CssClass="table table-striped table-bordered table-hover" GridLines="None" OnRowCommand="wardenTable_RowCommand">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="WarID" HeaderText="WarID" ReadOnly="True" />
                            <asp:BoundField DataField="Password" HeaderText="Password" />
                            <asp:BoundField DataField="DutyBuilding" HeaderText="DutyBuilding" />
                            <asp:BoundField DataField="CreateDate" HeaderText="CreateDate" DataFormatString="{0:yyyy/MM/dd HH:mm:ss}" />
                            <asp:TemplateField HeaderText="Info">
                                <ItemTemplate>
                                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="EditWarden" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-primary btn-sm ml-2" />
                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="DeleteWarden" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-sm ml-2" OnClientClick="return confirm('Are you sure you want to delete this warden?');" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </article>
        </div>
    </section>
</asp:Content>
