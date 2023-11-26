using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4Final.MemberInfo
{
    public partial class Member : System.Web.UI.Page
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

            // idk if this works
            int id = (int) HttpContext.Current.Session["userID"];
            var fnameQ = (from x in dbcon.Members
                          where x.Member_UserID == id
                          select x.MemberFirstName);
            var lnameQ = (from x in dbcon.Members
                          where x.Member_UserID == id
                          select x.MemberLastName);
            string fname = fnameQ.First().ToString();
            string lname = lnameQ.First().ToString();
            nameLabel.Text = fname + " " + lname;


            // table populating trying

            var tableQuery = (from x in dbcon.Sections
                              join y in dbcon.Members on x.Member_ID equals id
                              join i in dbcon.Instructors on x.Instructor_ID equals i.InstructorID
                              select new
                              {
                                  x.SectionName,
                                  x.SectionStartDate,
                                  i.InstructorFirstName,
                                  i.InstructorLastName,
                                  x.SectionFee
                              });
            MemberGridView.DataSource = tableQuery;
            MemberGridView.DataBind();
        }
    }
}