using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4Final.AdministratorInfo
{
    public partial class Administrator : System.Web.UI.Page
    {
        KarateDataContext dbcon;
        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\bmedu\\OneDrive\\Desktop\\CSCI 213\\KarateSchool(1).mdf\";Integrated Security=True;Connect Timeout=30";
        private void updateGridView()
        {
            dbcon = new KarateDataContext(conn);
            var memberQuery = (from x in dbcon.Members
                               select new
                               {
                                   x.MemberFirstName,
                                   x.MemberLastName,
                                   x.MemberPhoneNumber,
                                   x.MemberDateJoined,
                                   x.Member_UserID

                               });
            adminMemberGridView.DataSource = memberQuery;
            adminMemberGridView.DataBind();

            var instructorQuery = (from x in dbcon.Instructors
                                   select new
                                   {
                                       x.InstructorFirstName,
                                       x.InstructorLastName,
                                       x.InstructorID
                                   });
            adminInstructorGridView.DataSource = instructorQuery;
            adminInstructorGridView.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                updateGridView();
            }

        }

        protected void addMemberButton_Click(object sender, EventArgs e)
        {

            dbcon = new KarateDataContext(conn);

            NetUser user = new NetUser
            {
                UserName = netUserNameText.Text.Trim(),
                UserPassword = netUserPasswordText.Text.Trim(),
                UserType = netUserRadio.SelectedItem.ToString(),
            };
            dbcon.NetUsers.InsertOnSubmit(user);
            dbcon.SubmitChanges();

            int id = 0;
            var userID = from item in dbcon.NetUsers
                         where item.UserName == netUserNameText.Text.Trim()
                         select item.UserID;
            id = userID.First();

            Member member = new Member
            {
                Member_UserID = id,
                MemberFirstName = memberFirstText.Text,
                MemberLastName = memberLastText.Text,
                MemberDateJoined = DateTime.Now,
                MemberPhoneNumber = memberPhoneText.Text,
                MemberEmail = memberEmailText.Text
            };

            dbcon.Members.InsertOnSubmit(member);
            dbcon.SubmitChanges();
            updateGridView();

        }
        protected void addInstructorButton_Click(object sender, EventArgs e)
        {
            dbcon = new KarateDataContext(conn);
            try
            {
                NetUser user = new NetUser
                {
                    UserName = netUserNameText.Text.Trim(),
                    UserPassword = netUserPasswordText.Text.Trim(),
                    UserType = netUserRadio.SelectedItem.ToString(),
                };
                dbcon.NetUsers.InsertOnSubmit(user);
                dbcon.SubmitChanges();
                int id = 0;
                var userID = from item in dbcon.NetUsers
                             where item.UserName == netUserNameText.Text.Trim()
                             select item.UserID;
                id = userID.First();

                Instructor instructor = new Instructor
                {
                    InstructorID = id,
                    InstructorFirstName = instructorFirstText.Text,
                    InstructorLastName = instructorLastText.Text,
                    InstructorPhoneNumber = instructorPhoneText.Text
                };
                dbcon.Instructors.InsertOnSubmit(instructor);

                dbcon.SubmitChanges();


                updateGridView();
            }
            catch (Exception ex) { Console.WriteLine(ex + "Try fix and try again"); }
        }
        protected void deleteMemberButton_Click(object sender, EventArgs e)
        {
            if (adminMemberGridView.SelectedIndex > -1)
            {
                dbcon = new KarateDataContext(conn);

                var memberToDelete = from item in dbcon.Members
                                    where item.MemberFirstName == adminMemberGridView.SelectedRow.Cells[1].Text.Trim()       
                                    select item;

                var sectionToDelete = from item in dbcon.Sections
                                      where item.Member_ID == memberToDelete.First().Member_UserID
                                      select item;

                dbcon.Sections.DeleteOnSubmit(sectionToDelete.First());
                dbcon.Members.DeleteOnSubmit(memberToDelete.First());

                dbcon.SubmitChanges();
                updateGridView();
                adminMemberGridView.SelectedIndex = -1;
            
            }
        }

        protected void deleteInstructorButton_Click(object sender, EventArgs e)
        {
            if (adminInstructorGridView.SelectedIndex > -1)
            {
                dbcon = new KarateDataContext(conn);

                var instructorToDelete = from item in dbcon.Instructors
                                     where item.InstructorFirstName == adminInstructorGridView.SelectedRow.Cells[1].Text.Trim()
                                     select item;

                var sectionToDelete = from item in dbcon.Sections
                                      where item.Instructor_ID == instructorToDelete.First().InstructorID
                                      select item;

                dbcon.Sections.DeleteOnSubmit(sectionToDelete.First());
                dbcon.Instructors.DeleteOnSubmit(instructorToDelete.First());

                dbcon.SubmitChanges();
                updateGridView();
                adminInstructorGridView.SelectedIndex = -1;

            }
        }

        protected void addSectionButton_Click(object sender, EventArgs e)
        {
            dbcon = new KarateDataContext(conn);
            Section section = new Section
            {
                SectionName = sectionNameText.Text,
                SectionStartDate = Convert.ToDateTime(sectionDateText.Text),
                Member_ID = Convert.ToInt32(sectionMemberText.Text),
                Instructor_ID = Convert.ToInt32(sectionInstructorText.Text),
                SectionFee = Convert.ToDecimal(sectionFeeText.Text)
            };
            dbcon.Sections.InsertOnSubmit(section);
            dbcon.SubmitChanges();

        }
    }
}