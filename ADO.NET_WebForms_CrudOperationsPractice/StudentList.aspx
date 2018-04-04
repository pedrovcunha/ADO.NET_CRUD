<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentList.aspx.cs" Inherits="ADO.NET_WebForms_CrudOperationsPractice.StudentList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                <h1 class="title">Student List</h1>

    <asp:Repeater ID="rptStudents" runat="server" OnItemCommand="rptStudents_ItemCommand">
        <HeaderTemplate>
            <table>
                <tr>
                    <th>ID</th>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>E-mail</th>
                    <th>Phone Number</th>
                    <th>Address</th>
                    <th>Volunteer School-ID</th>
                    <th>Availability-ID</th>
                    <th>&nbsp;</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("StudentID") %></td>
                <td><%#Eval("FirstName") %></td>
                <td><%#Eval("LastName") %></td>
                <td><%#Eval("Email") %></td>
                <td><%#Eval("PhoneNumber") %></td>
                <td><%#Eval("Address") %></td>
                <td><%#Eval("VolunteerSchoolID") %></td>
                <td><%#Eval("VolunteerAvailabilityID") %></td>
                <td>
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" CommandArgument='<%#Eval("StudentID") %>' />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%#Eval("StudentID") %>' OnClientClick="return confirm('Are you sure?');" />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>

    <asp:Button ID="btnAddNewStudent" runat="server" Text="Add New Student" OnClick="btnAddNewStudent_Click" />
        </div>
    </form>
</body>
</html>
