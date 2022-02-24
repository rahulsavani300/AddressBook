<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="CityAddEdit.aspx.cs" Inherits="AdminPanel_City_CityAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h2>City Add Edit Page</h2>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <asp:Label ID="lblMessage" runat="server" EnableViewState="false" CssClass="alert-success" />   
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        Count  
                    </div>
                    <div class="col-md-8">
                        <asp:DropDownList ID="ddlCountryID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCountryID_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ErrorMessage="Select Country" ControlToValidate="ddlStateID" InitialValue="-1" CssClass="alert-danger " Display="None"  BorderStyle="Solid"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-4">
                        State  
                    </div>
                    <div class="col-md-8">
                        <asp:DropDownList ID="ddlStateID" runat="server" CssClass="form-control"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvState" runat="server" ErrorMessage="Select State" ControlToValidate="ddlStateID" InitialValue="-1" CssClass="alert-danger " Display="None"  BorderStyle="Solid"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-4">
                        City Name
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtCityName" runat="server" CssClass="form-control"/>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Enter Valid City Name" ControlToValidate="txtCityName" CssClass="alert-danger " Display="None"  BorderStyle="Solid"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-4">
                        STD Code
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtSTDCode" runat="server" CssClass="form-control"/>
                        <asp:RequiredFieldValidator ID="rfvSTD" runat="server" ErrorMessage="Enter STDCode" ControlToValidate="txtSTDCode" CssClass="alert-danger " Display="None"  BorderStyle="Solid"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-4">
                        Pin code
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtPincode" runat="server" CssClass="form-control"/>
                        <asp:RequiredFieldValidator ID="rfvPincode" runat="server" ErrorMessage="Enter Pincode" ControlToValidate="txtPincode" CssClass="alert-danger " Display="None"  BorderStyle="Solid"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
          
                    </div>
                    <div class="col-md-8">
                      <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" Text="Save" OnClick="btnSave_Click" />
                      <asp:HyperLink ID="hlCancel" runat="server" CssClass="btn btn-danger" Text="Cancel" NavigateUrl="~/AdminPanel/City/CityList.aspx" />
                    </div>
                </div>    
        <asp:ValidationSummary ID="vsCity" runat="server" BorderStyle="Solid" CssClass="alert-danger" />
        </div>
</asp:Content>

