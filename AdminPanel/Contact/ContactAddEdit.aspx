<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="ContactAddEdit.aspx.cs" Inherits="AdminPanel_Contact_ContactAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h2>Contact Add Edit Page</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="lblMessage" runat="server" EnableViewState="False" CssClass="alert-success " />
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                Country 
            </div>
            <div class="col-md-8">
                <asp:DropDownList ID="ddlCountryID" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlCountryID_SelectedIndexChanged"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCountry" runat="server" InitialValue="-1" ErrorMessage="Select Country" ControlToValidate="ddlCountryID" CssClass="alert-danger " Display="None" BorderStyle="Solid"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                State
            </div>
            <div class="col-md-8">
                <asp:DropDownList ID="ddlStateID" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlStateID_SelectedIndexChanged" ></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvState" runat="server" InitialValue="-1" ErrorMessage="Select State " ControlToValidate="ddlStateID" CssClass="alert-danger " Display="None" BorderStyle="Solid"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                City
            </div>
            <div class="col-md-8">
                <asp:DropDownList ID="ddlCityID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCityID_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCity" runat="server" InitialValue="-1" ErrorMessage="Select City " ControlToValidate="ddlCityID" CssClass="alert-danger " Display="None" BorderStyle="Solid"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                ContactCategory
            </div>
            <div class="col-md-8">
                <asp:DropDownList ID="ddlContactCategoryID" runat="server" CssClass="form-control"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvContactCategory" runat="server" InitialValue="-1" ErrorMessage="Select Contact Category " ControlToValidate="ddlContactCategoryID" CssClass="alert-danger " Display="None" BorderStyle="Solid"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                Contact Photo
            </div>
            <div class="col-md-8">
                <asp:FileUpload ID="fuContactPhotoPath" runat="server" />
                <asp:RequiredFieldValidator ID="rfvPhotoUpload" runat="server" ErrorMessage="Select Contact Photo " ControlToValidate="fuContactPhotoPath" CssClass="alert-danger " Display="None" BorderStyle="Solid"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                Contact Name
            </div>
            <div class="col-md-8">
                <asp:TextBox ID="txtContactName" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Enter Valid Name" ControlToValidate="txtContactName" CssClass="alert-danger " Display="None" BorderStyle="Solid"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                Contact No
            </div>
            <div class="col-md-8">
                <asp:TextBox ID="txtContactNo" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvContactNo" runat="server" ErrorMessage="Enter Valid No" ControlToValidate="txtContactNo" CssClass="alert-danger " Display="None" BorderStyle="Solid"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                Whatsapp  No
            </div>
            <div class="col-md-8">
                <asp:TextBox ID="txtWhatsapp" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvWhatsapp" runat="server" ErrorMessage="Enter Whatsapp No" ControlToValidate="txtWhatsapp" CssClass="alert-danger " Display="None" BorderStyle="Solid"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                BirthDate
            </div>
            <div class="col-md-8">
                <asp:TextBox ID="txtBirthdate" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvBirth" runat="server" ErrorMessage="Enter Birthdate" ControlToValidate="txtBirthdate" CssClass="alert-danger " Display="None" BorderStyle="Solid"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                Email
            </div>
            <div class="col-md-8">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Enter Email" ControlToValidate="txtEmail" CssClass="alert-danger " Display="None" BorderStyle="Solid"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                Age
            </div>
            <div class="col-md-8">
                <asp:TextBox ID="txtAge" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvAge" runat="server" ErrorMessage="Enter Age" ControlToValidate="txtAge" CssClass="alert-danger " Display="None" BorderStyle="Solid"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                Address
            </div>
            <div class="col-md-8">
                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ErrorMessage="Enter Address" ControlToValidate="txtAddress" CssClass="alert-danger " Display="None" BorderStyle="Solid"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                BloodGroup
            </div>
            <div class="col-md-8">
                <asp:TextBox ID="txtBloodGroup" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvBlood" runat="server" ErrorMessage="Enter BloodGroup" ControlToValidate="txtBloodGroup" CssClass="alert-danger " Display="None" BorderStyle="Solid"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                Facebook
            </div>
            <div class="col-md-8">
                <asp:TextBox ID="txtFacebook" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvFacebook" runat="server" ErrorMessage="Enter Facebook ID " ControlToValidate="txtAddress" CssClass="alert-danger " Display="None" BorderStyle="Solid"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                LinkedIN
            </div>
            <div class="col-md-8">
                <asp:TextBox ID="txtLinkedIN" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvLinkedin" runat="server" ErrorMessage="Enter LinkedIN ID " ControlToValidate="txtLinkedIN" CssClass="alert-danger " Display="None" BorderStyle="Solid"></asp:RequiredFieldValidator>
            </div>

        </div>
        <div class="row">
            <div class="col-md-4">
            </div>
            <div class="col-md-8">
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" Text="Save" OnClick="btnSave_Click" />
                <asp:HyperLink ID="hlCancel" runat="server" CssClass="btn btn-danger" Text="Cancel" NavigateUrl="~/AdminPanel/Contact/ContactList.aspx" />
            </div>
        </div>
        <asp:ValidationSummary ID="vsContact" runat="server" CssClass="alert-danger " BorderStyle="Solid" DisplayMode="BulletList" />
    </div>
</asp:Content>

