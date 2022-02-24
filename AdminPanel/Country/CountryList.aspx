<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="CountryList.aspx.cs" Inherits="AdminPanel_Country_CountryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="container">
                <div class="row">
                        <div class="col-md-12 container">
                            <h2>Country List</h2>
                        </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <asp:GridView ID="gvCountry" CssClass="table table-hover" runat="server" AutoGenerateColumns="false" OnRowCommand="gvCountry_RowCommand"  >
                            <Columns>
                                <asp:BoundField DataField="CountryID" HeaderText="ID" />
                                <asp:BoundField DataField="CountryName" HeaderText="Country Name" />
                                <asp:BoundField DataField="CountryCode" HeaderText="Country Code" />
                                <asp:BoundField DataField="CreationDate" HeaderText="Creation Date" />


                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("CountryID").ToString() %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="hlEdit" runat="server" Text="Edit" CssClass="btn btn-warning" NavigateUrl='<%# "~/AdminPanel/Country/CountryAddEdit.aspx?CountryID=" +Eval("CountryID").ToString() %>'></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <asp:HyperLink ID="hlAdd" runat="server" CssClass="btn btn-success" NavigateUrl="~/AdminPanel/Country/CountryAddEdit.aspx">Add Country</asp:HyperLink>
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
                </div>
        </div>
</asp:Content>

