<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="CityList.aspx.cs" Inherits="AdminPanel_City_CityList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="container">
                <div class="row">
                        <div class="col-md-12 container">
                            <h2>City List</h2>
                        </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <asp:GridView ID="gvCity" runat="server" OnRowCommand="gvCity_RowCommand" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="CityID" HeaderText="ID" />
                                <asp:BoundField DataField="CountryName" HeaderText="Country Name" />
                                <asp:BoundField DataField="StateName" HeaderText="State Name" />
                                <asp:BoundField DataField="CityName" HeaderText="City Name" />
                                <asp:BoundField DataField="STDCode" HeaderText="STDCode" />
                                <asp:BoundField DataField="Pincode" HeaderText="Pincode" />
                                <asp:BoundField DataField="CreationDate" HeaderText="CreationDate" />


                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("CityID").ToString() %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="hlEdit" runat="server" Text="Edit" CssClass="btn btn-warning" NavigateUrl='<%# "~/AdminPanel/City/CityAddEdit.aspx?CityID=" +Eval("CityID").ToString() %>'></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <asp:HyperLink ID="hlAdd" runat="server" CssClass="btn btn-success" NavigateUrl="~/AdminPanel/City/CityAddEdit.aspx">Add City</asp:HyperLink>
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
                </div>
        </div>
</asp:Content>

