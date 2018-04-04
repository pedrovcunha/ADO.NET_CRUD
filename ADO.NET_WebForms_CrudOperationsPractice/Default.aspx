<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADO.NET_WebForms_CrudOperationsPractice._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <h3>The project contains the following pages:</h3>
    <ul>
        <li>
            <h5><a href="StudentList.aspx">Student List Page</a></h5>
            This page lists all the students from the database and offers you the option to insert, edit or delete a student.
        </li>
        <li>
            <h5><a href="SaveStudent.aspx">Insert Student Page</a></h5>
          This page is used for editing or inserting a new student into database.
        </li>
    </ul>
    </div>

</asp:Content>
