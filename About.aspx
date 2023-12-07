<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="housing21Project.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <h3>Mini Project</h3>
        <p>A standard webform in C# / asp.net with 5 fields, 4 of which will be collected on the page and the last of which should be an auto-incrementing ID. The form should collect name, date of birth, telephone number and email, before submitting the form. All fields should be validated and prevent erroneous data. The form should use custom CSS styling and be mobile responsive.
           The form should submit to a Microsoft SQL Server database. A second page with a table containing all rows in the database, with a button to export all rows to a CSV file..</p>
    </main>
</asp:Content>
