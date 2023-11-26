using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4Final.InstructorInfo
{
    public partial class Instructor : System.Web.UI.Page
    {
        KarateDataContext dbcon;
        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\bmedu\\OneDrive\\Desktop\\CSCI 213\\KarateSchool(1).mdf\";Integrated Security=True;Connect Timeout=30";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count != 0)
            {
                if (HttpContext.Current.Session["userType"].ToString().Trim() == "member")
                {
                    Session.Clear();
                    Session.RemoveAll();
                    Session.Abandon();
                    Session.Abandon();
                    FormsAuthentication.SignOut();
                    Response.Redirect("Logon.aspx", true);
                }

            }
            dbcon = new KarateDataContext(conn);

            int id = (int)HttpContext.Current.Session["userID"];
            var fnameQ = (from x in dbcon.Instructors
                          where x.InstructorID == id
                          select x.InstructorFirstName);
            var lnameQ = (from x in dbcon.Instructors
                          where x.InstructorID == id
                          select x.InstructorLastName);
            string fname = fnameQ.First().ToString();
            string lname = lnameQ.First().ToString();
            instructorLabel.Text = fname + " " + lname;

            var instructorQuery = (from x in dbcon.Sections
                                   where x.Instructor_ID == id
                                   join y in dbcon.Members on x.Member_ID equals y.Member_UserID
                                   select new
                                   {
                                       x.SectionName,
                                       y.MemberFirstName,
                                       y.MemberLastName
                                   });
            InstructorGridView.DataSource = instructorQuery;
            InstructorGridView.DataBind();
        }
    }
}