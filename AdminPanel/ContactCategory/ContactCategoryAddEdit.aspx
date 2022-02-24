<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="ContactCategoryAddEdit.aspx.cs" Inherits="AdminPanel_ContactCategory_ContactCategoryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h2>ContactCategory Add Edit Page</h2>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <asp:Label ID="lblMessage" runat="server" EnableViewState="false" CssClass="alert-success" />   
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        Contact Category Name   
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtContactCategory" runat="server" CssClass="form-control"/>
                        <asp:RequiredFieldValidator ID="rfvContactCategory" runat="server" ErrorMessage="Enter ContactCategory Name " ControlToValidate="txtContactCategory" CssClass="alert-danger " Display="None"  BorderStyle="Solid"></asp:RequiredFieldValidator>

                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
          
                    </div>
                    <div class="col-md-8">
                      <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" Text="Save" OnClick="btnSave_Click" />
                      <asp:HyperLink ID="hlCancel" runat="server" CssClass="btn btn-danger" Text="cancel" NavigateUrl="~/AdminPanel/ContactCategory/ContactCategoryList.aspx" />
                    </div>
                </div>
        <asp:ValidationSummary ID="vsContactCategory" runat="server" BorderStyle="Solid" CssClass="alert-danger" />
    </div>
</asp:Content>

