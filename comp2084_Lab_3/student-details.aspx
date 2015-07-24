<%@ Page Title="Student Details" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="student-details.aspx.cs" Inherits="comp2084_Lab_3.student_details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Student Details</h1>
    <h5>All fields are required</h5>

    <div class="form-group">
        <label for="txtLastName" class="col-sm-2">Last Name: *</label>
        <asp:TextBox runat="server" ID="txtLastName" required MaxLength="50" />
    </div>
    <div class="form-group">
        <label for="txtFirstMidName" class="col-sm-2">First Name: *</label>
        <asp:TextBox runat="server" ID="txtFirstMidName" required MaxLength="50" />
    </div>
    <div class="form-group">
        <label for="txtEnrollmentDate" class="col-sm-2">Enrollment Date:</label>
        <asp:TextBox runat="server" ID="txtEnrollmentDate" required TextMode="Date" />
        <asp:RangeValidator runat="server" ID="RangeValidator1" ErrorMessage="Please enter a date between 1950-01-01 and 2020-12-31" 
            ControlToValidate="txtEnrollmentDate" CssClass="label label-danger" Type="Date"
            MinimumValue="1950-01-01" MaximumValue="2020-12-31"></asp:RangeValidator>
    </div>
    <div class="col-sm-offset-2">
        <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
    </div>

    <asp:Panel ID="pnlCourses" runat="server" >
        <h2>Courses</h2>
        <asp:GridView ID="grdCourses" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover" >
            <Columns>
                <asp:BoundField DataField="Course.Title" HeaderText="Title" />
                <asp:BoundField DataField="Course.Credits" HeaderText="Credits" />
            </Columns>
        </asp:GridView>
    </asp:Panel>


</asp:Content>

