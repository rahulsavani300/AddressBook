<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="StateAddEdit.aspx.cs" Inherits="AdminPanel_State_StateAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h2>State Add Edit Page</h2>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <asp:Label ID="lblMessage" runat="server" EnableViewState="false" CssClass="alert-success" />   
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        Country  
                    </div>
                    <div class="col-md-8">
                        <asp:DropDownList ID="ddlCountryID" runat="server" CssClass="form-control"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ErrorMessage="Enter Country" ControlToValidate="ddlCountryID" InitialValue="-1" CssClass="alert-danger " Display="None"  BorderStyle="Solid"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-4">
                        State Name
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtStateName" runat="server" CssClass="form-control"/>
                        <asp:RequiredFieldValidator ID="rfvState" runat="server" ErrorMessage="Enter State Name" ControlToValidate="txtStateName" CssClass="alert-danger " Display="None"  BorderStyle="Solid"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-4">
                        State code
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtStateCode" runat="server" CssClass="form-control"/>
                        <asp:RequiredFieldValidator ID="rfvStateCode" runat="server" ErrorMessage="Enter State Code" ControlToValidate="txtStateName" CssClass="alert-danger " Display="None"  BorderStyle="Solid"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
          
                    </div>
                    <div class="col-md-8">
                      <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" Text="Save" OnClick="btnSave_Click" />
                      <asp:HyperLink ID="hlCancel" runat="server" CssClass="btn btn-danger" Text="Cancel" NavigateUrl="~/AdminPanel/State/StateList.aspx" />
                    </div>
                </div>
        <asp:ValidationSummary ID="vsState" runat="server" BorderStyle="Solid" CssClass="alert-danger" />
         </div>
</asp:Content>

