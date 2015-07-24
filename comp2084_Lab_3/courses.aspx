<%@ Page Title="Courses" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="courses.aspx.cs" Inherits="comp2084_Lab_3.courses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h1>Courses</h1>
    <h5>All the fields are required</h5>

    <a href="course-details.aspx">Add a Course</a>

    <asp:GridView ID="grdCourses" runat="server" CssClass="table table-striped table-hover" 
        AutoGenerateColumns="false" >
        
        <Columns>
            <asp:BoundField DataField="CourseID" HeaderText="CourseID" />
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:BoundField DataField="Credits" HeaderText="Credits" />
            <asp:BoundField DataField="Department.Name" HeaderText="Department" />
            <asp:HyperLinkField HeaderText="Edit" NavigateUrl="course-details.aspx" Text="Edit" 
             DataNavigateUrlFormatString="course-details.aspx?CourseID={0}" DataNavigateUrlFields="CourseID" />
        </Columns>

    </asp:GridView>
</asp:Content>
