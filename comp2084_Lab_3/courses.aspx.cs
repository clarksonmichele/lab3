using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//add a reference so we can use EF for the database
using comp2084_Lab_3.Models;

namespace comp2084_Lab_3
{
    public partial class courses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //call the GetCourses function so you can populate the grid
            if (!IsPostBack)
            {
                GetCourses();
            }
        }

        protected void GetCourses()
        {
            //use EF to connect and get the list of courses
            using (DefaultConnection db = new DefaultConnection())
            {
                var Courses = from c in db.Courses
                              select c;

                //bind the courses query result to our grid
                grdCourses.DataSource = Courses.ToList();
                grdCourses.DataBind();
            }
        }
    }
}