<%@ Page Title="Table Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="table.aspx.cs" Inherits="housing21Project.table" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  <link href="Styles/table.css" rel="stylesheet" type="text/css" />
  
    <h2 class="text-center">User Details</h2>

   <asp:GridView ID="GridView1" runat="server" OnRowCreated="GridView1_RowCreated" AutoGenerateColumns="True" UseAccessibleHeader="true"></asp:GridView>

    <div class="d-flex justify-content-end mt-3">
       <asp:Button ID="btnExport" CssClass="btn btn-primary btn-block" runat="server" Text="Export to CSV" onclick="btnExport_Click" />
    </div> 

</asp:Content>

