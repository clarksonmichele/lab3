﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


//reference db model so we can connect to server
using comp2084_Lab_3.Models;

namespace comp2084_Lab_3
{
    public partial class student_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if loading for the first time (not posting back), check for a url
            if (!IsPostBack)
            {
                //if we have an id in the url, look up the selected record
                if (!String.IsNullOrEmpty(Request.QueryString["StudentID"]))
                {
                    GetStudent();
                    pnlCourses.Visible = true;
                }
                else
                {
                    //adding a new student , so hide the courses because there aren't any yet
                    pnlCourses.Visible = false;
                }
            }
        }

        protected void GetStudent()
        {
            //look up the selected student and fill the form
            using (DefaultConnection db = new DefaultConnection())
            {
                //store the id from the url in a variable
                Int32 StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

                //look up the student
                Student stud = (from s in db.Students
                                where s.StudentID == StudentID
                                select s).FirstOrDefault();

                //pre populate the form fields
                txtLastName.Text = stud.LastName;
                txtFirstMidName.Text = stud.FirstMidName;
                txtEnrollmentDate.Text = stud.EnrollmentDate.ToString("dd-MM-yyyy");

                //populate the student courses grid
                var Enrollments = from en in db.Enrollments
                                  where en.StudentID == StudentID
                                  orderby en.Course.Title, en.Course.Credits
                                  select en;

                //bind to the grid
                grdCourses.DataSource = Enrollments.ToList();
                grdCourses.DataBind();
            }
        }

        protected void GetCourses()
        {
            //connect
            using (DefaultConnection db = new DefaultConnection())
            {
                //get Course list
                var Courses = from c in db.Courses
                              orderby c.Title
                              select c;

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //connect to server
            using (DefaultConnection db = new DefaultConnection())
            {
                //Create a new student_details in memory
                Student stud = new Student();

                Int32 StudentID = 0;

                //check for a url
                if (!String.IsNullOrEmpty(Request.QueryString["StudentID"]))
                {
                    //get the id from the url
                    StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

                    //look up the student
                    stud = (from s in db.Students
                            where s.StudentID == StudentID
                            select s).FirstOrDefault();
                }


                //Fill the properties of the new student
                stud.LastName = txtLastName.Text;
                stud.FirstMidName = txtFirstMidName.Text;
                stud.EnrollmentDate = Convert.ToDateTime(txtEnrollmentDate.Text);

                //add if we have no id in the url
                if (StudentID == 0)
                {
                    db.Students.Add(stud);
                }

                //save the new student
                db.SaveChanges();

                //redirect to the students list page
                Response.Redirect("students.aspx");
            }
        }
    }
}


