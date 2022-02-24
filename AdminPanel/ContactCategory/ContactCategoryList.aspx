<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="ContactCategoryList.aspx.cs" Inherits="AdminPanel_ContactCategory_ContactCategoryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="container">
                <div class="row">
                        <div class="col-md-12 container">
                            <h2>Contact Category List</h2>
                        </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <asp:GridView ID="gvContactCategory" runat="server" AutoGenerateColumns="false" OnRowCommand="gvContactCategory_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="ContactCategoryID" HeaderText="ID" />
                                <asp:BoundField DataField="ContactCategoryName" HeaderText="Contact Category Name" />
                                <asp:BoundField DataField="CreationDate" HeaderText="Creation Date" />

                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactCategoryID").ToString() %>' />                            
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="hlEdit" runat="server" Text="Edit" CssClass="btn btn-warning" NavigateUrl='<%# "~/AdminPanel/ContactCategory/ContactCategoryAddEdit.aspx?ContactCategoryID=" +Eval("ContactCategoryID").ToString() %>'></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:HyperLink ID="hlAdd" runat="server" CssClass="btn btn-success" NavigateUrl="~/AdminPanel/ContactCategory/ContactCategoryAddEdit.aspx">Add Contact Category</asp:HyperLink>
                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        </div>
                    </div>
        </div>
</asp:Content>

