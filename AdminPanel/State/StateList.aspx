<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBook.master" AutoEventWireup="true" CodeFile="StateList.aspx.cs" Inherits="AdminPanel_State_StateList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="container">
             <div class="row">
                    <div class="col-md-12 container">
                        <h2>State List</h2>
                    </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="gvState" CssClass="table table-hover " runat="server" AutoGenerateColumns="false" OnRowCommand="gvState_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="StateID" HeaderText="ID" />
                            
                            <asp:BoundField DataField="CountryName" HeaderText="Country Name" />
                            <asp:BoundField DataField="StateName" HeaderText="State Name" />
                            <asp:BoundField DataField="StateCode" HeaderText="StateCode" />
                            <asp:BoundField DataField="CreationDate" HeaderText="CreationDate" />

                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("StateID").ToString() %>' />             
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:HyperLink ID="hlEdit" runat="server" Text="Edit" CssClass="btn btn-warning" NavigateUrl='<%# "~/AdminPanel/State/StateAddEdit.aspx?StateID=" +Eval("StateID").ToString() %>'></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:HyperLink ID="hlAdd" runat="server" CssClass="btn btn-success" NavigateUrl="~/AdminPanel/State/StateAddEdit.aspx">Add State</asp:HyperLink>
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </div>
            </div>
      </div>
</asp:Content>

