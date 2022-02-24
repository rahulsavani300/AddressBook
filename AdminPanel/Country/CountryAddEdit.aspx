<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="CountryAddEdit.aspx.cs" Inherits="AdminPanel_Country_CountryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h2>Country Add Edit Page</h2>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <asp:Label ID="lblMessage" runat="server" EnableViewState="false" CssClass="alert-success" />   
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        Country Name  
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtCountryName" runat="server" CssClass="form-control"/>
                        <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ErrorMessage="Enter Country Name" ControlToValidate="txtCountryName" CssClass="alert-danger " Display="None"  BorderStyle="Solid"></asp:RequiredFieldValidator>

                    </div>
                    <div class="col-md-4">
                        Country Code  
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtCountryCode" runat="server" CssClass="form-control"/>
                        <asp:RequiredFieldValidator ID="rfvCountryCode" runat="server" ErrorMessage="Enter Country Code" ControlToValidate="txtCountryName" CssClass="alert-danger " Display="None"  BorderStyle="Solid"></asp:RequiredFieldValidator>

                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
          
                    </div>
                    <div class="col-md-8">
                      <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" Text="Save" OnClick="btnSave_Click" />
                      <asp:HyperLink ID="hlCancel" runat="server" CssClass="btn btn-danger" Text="cancel" NavigateUrl="~/AdminPanel/Country/CountryList.aspx" />
                    </div>
                </div>
        <asp:ValidationSummary ID="vsCountry" runat="server" BorderStyle="Solid" CssClass="alert-danger" />
    </div>
</asp:Content>

