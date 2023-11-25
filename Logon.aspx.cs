using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4Final
{
    public partial class Logon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string nUserName = Login1.UserName;
            string nPassword = Login1.Password;


            HttpContext.Current.Session["nUserName"] = nUserName;
            HttpContext.Current.Session["uPass"] = nPassword;


            /*
             * 
             * commenting this all out until database is received from Brayden, should be simple to sync up
             *  
            // Search for the current User, validate UserName and Password
            _AspNetUsers_ myUser = (from x in dbcon._AspNetUsers_s
                                    where x.AspUserName == HttpContext.Current.Session["nUserName"].ToString()
                                    && x.AspUserPassword == HttpContext.Current.Session["uPass"].ToString()
                                    select x).First();

            if (myUser != null)
            {
                //Add UserID and User type to the Session
                HttpContext.Current.Session["userID"] = myUser.AspUserId;
                HttpContext.Current.Session["userType"] = myUser.AspUserType;

            }
            if (myUser != null && HttpContext.Current.Session["userType"].ToString().Trim() == "administrator")
            {

                FormsAuthentication.RedirectFromLoginPage(HttpContext.Current.Session["nUserName"].ToString(), true);

                Response.Redirect("~/AdministratorInfo/Administrator.aspx");
            }
            else if (myUser != null && HttpContext.Current.Session["userType"].ToString().Trim() == "instructor")
            {

                FormsAuthentication.RedirectFromLoginPage(HttpContext.Current.Session["nUserName"].ToString(), true);

                Response.Redirect("~/InstructorInfo/Instructor.aspx");
            }
            else if (myUser != null && HttpContext.Current.Session["userType"].ToString().Trim() == "member")
            {

                FormsAuthentication.RedirectFromLoginPage(HttpContext.Current.Session["nUserName"].ToString(), true);

                Response.Redirect("~/MemberInfo/Member.aspx");
            }
            else
                Response.Redirect("Logon.aspx", true);
            */

        }
    }
}
