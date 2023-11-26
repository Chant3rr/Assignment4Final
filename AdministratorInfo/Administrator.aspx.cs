using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4Final.AdministratorInfo
{
    public partial class Administrator : System.Web.UI.Page
    {
        KarateDataContext dbcon;
        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\jacks\\Desktop\\VS CLASS\\assignment 4\\Assignment4Final\\App_Data\\KarateSchool1.mdf\";Integrated Security=True;Connect Timeout=30";

        protected void Page_Load(object sender, EventArgs e)
        {
            dbcon = new KarateDataContext(conn);

            int id = (int)HttpContext.Current.Session["userID"];
            /*
            var fnameQ = (from x in dbcon.Instructors
                          where x.InstructorID == id
                          select x.InstructorFirstName);
            var lnameQ = (from x in dbcon.Instructors
                          where x.InstructorID == id
                          select x.InstructorLastName);
            string fname = fnameQ.First().ToString();
            string lname = lnameQ.First().ToString();
            instructorLabel.Text = fname + " " +x` lname;
            */

            var memberQuery = (from x in dbcon.Members
                               select new
                               {
                                   x.MemberFirstName,
                                   x.MemberLastName,
                                   x.MemberPhoneNumber,
                                   x.MemberDateJoined

                               });
            adminMemberGridView.DataSource = memberQuery;
            adminMemberGridView.DataBind();

            var instructorQuery = (from x in dbcon.Instructors
                                   select new
                                   {
                                       x.InstructorFirstName,
                                       x.InstructorLastName
                                   });
            adminInstructorGridView.DataSource = instructorQuery;
            adminInstructorGridView.DataBind();
        }
    }
}