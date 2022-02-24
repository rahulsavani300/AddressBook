<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="ContactList.aspx.cs" Inherits="AdminPanel_Contact_ContactList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    
                <div class="row  ">
                        <div class="col-md-12 container">
                            <h2>Contact List</h2>
                        </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <asp:GridView ID="gvContact" runat="server" AutoGenerateColumns="false" OnRowCommand="gvContact_RowCommand"  >
                            <Columns>
                                <asp:BoundField DataField="ContactID" HeaderText="ID" />
                                <asp:TemplateField HeaderText="Photo">
                                    <ItemTemplate>
                                        <asp:Image runat="server" ID="imgContactPhotoPath" ImageUrl='<%# Eval("ContactPhotoPath") %>' Height="100px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:BoundField DataField="CountryName" HeaderText="Country Name" />
                                <asp:BoundField DataField="StateName" HeaderText="State Name" />
                                <asp:BoundField DataField="CityName" HeaderText="City Name" />
                                <asp:BoundField DataField="ContactCategoryName" HeaderText="Contact Category Name" />
                                <asp:BoundField DataField="ContactName" HeaderText="Contact Name" />
                                <asp:BoundField DataField="ContactNo" HeaderText="Contact No" />
                                <asp:BoundField DataField="WhatsAppNo" HeaderText="WhatsAppNo" />
                                <asp:BoundField DataField="BirthDate" HeaderText="Birthdate" />
                                <asp:BoundField DataField="Email" HeaderText="Email" />
                                <asp:BoundField DataField="Age" HeaderText="Age" />
                                <asp:BoundField DataField="Address" HeaderText="Address" />
                                <asp:BoundField DataField="BloodGroup" HeaderText="Bloodgroup" />
                                <asp:BoundField DataField="FacebookID" HeaderText="Facebook" />
                                <asp:BoundField DataField="LinkedINID" HeaderText="LinkedIN" />

                                <asp:BoundField DataField="CreationDate" HeaderText="Creation Date" />


                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactID").ToString() %>' />                             
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="hlEdit" runat="server" Text="Edit" CssClass="btn btn-warning" NavigateUrl='<%# "~/AdminPanel/Contact/ContactAddEdit.aspx?ContactID=" +Eval("ContactID").ToString() %>'></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="row ">
                    <div class="col-md-12">
                        <asp:HyperLink ID="hlAdd" runat="server" CssClass="btn btn-success" NavigateUrl="~/AdminPanel/Contact/ContactAddEdit.aspx">Add Contact</asp:HyperLink>
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
                </div>
     
</asp:Content>

