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
    public partial class students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //call the GetStudents function to populate the grid
            if (!IsPostBack)
            {
                GetStudents();
            }
        }

        protected void GetStudents()
        {
            //use EF to connect and get the list of students
            using (DefaultConnection db = new DefaultConnection())
            {
                var stud = from s in db.Students
                           select s;

                //bind the students query result to our grid
                grdStudents.DataSource = stud.ToList();
                grdStudents.DataBind();
            }
        }

        // protected void grdStudents_PageIndexChanging(object sender, GridViewPageEventArgs e)
        // {
        //set the NewPageIndex and repopulate the grid
        //grdStudents.PageIndex = e.NewPageIndex;
        // GetStudents();
        // }

        protected void grdStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Store which row was clicked
            Int32 selectedRow = e.RowIndex;

            //get the selected StudentID using the grid's Data collection
            Int32 StudentID = Convert.ToInt32(grdStudents.DataKeys[selectedRow].Values["StudentID"]);

            //connect
            using (DefaultConnection db = new DefaultConnection())
            {
                Student stud = (from s in db.Students
                                where s.StudentID == StudentID
                                select s).FirstOrDefault();
                //delete
                db.Students.Remove(stud);
                db.SaveChanges();

                //refresh the grid
                GetStudents();
            }
        }
    }
}
