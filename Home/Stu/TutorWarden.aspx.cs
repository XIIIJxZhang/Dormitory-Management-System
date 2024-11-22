using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dormitory_Management_System.Home.Stu {
    public partial class TutorWarden : System.Web.UI.Page {
        Models.Functions Con;

        protected void Page_Load(object sender, EventArgs e) {
            Con = new Models.Functions();

            // Check if the user is logged in by looking for the "UserID" session
            if (Session["UserID"] == null || Session["UserType"] == null) {
                // Redirect to login page if the user is not logged in
                Response.Redirect("/Home/Login.aspx");
                return;
            }

            string userID = Session["UserID"].ToString();
            string userType = Session["UserType"].ToString();

            // Ensure the user type is "Student"
            if (userType == "Student") {
                LoadTutorInformation(userID);
                LoadWardenInformation(userID);
            } else {
                // Show error if the user is not a student
                PermissionMessage.Text = "Invalid user type. You do not have permission to view this page.";
            }
        }

        private void LoadTutorInformation(string studentID) {
            try {
                // Query to get tutor information for the student from StudentTbl and TutorTbl
                string query = $@"
                SELECT t.TutID, t.DutyFloor, t.Building 
                FROM StudentTbl s
                JOIN TutorTbl t ON s.Floor = t.DutyFloor AND s.Building = t.Building
                WHERE s.StuID = {studentID}";
                DataTable dt = Con.GetData(query);

                if (dt.Rows.Count > 0) {
                    // Set Tutor information into the labels
                    TutorID.Text = dt.Rows[0]["TutID"].ToString();
                    TutorContact.Text = $"{TutorID.Text}@link.cuhksz.edu.cn";  // Set contact as tutID@link.cuhksz.edu.cn
                    TutorFloor.Text = dt.Rows[0]["DutyFloor"].ToString();
                    TutorBuilding.Text = dt.Rows[0]["Building"].ToString();
                } else {
                    Errmsg.Text = "Tutor information not found.";
                }
            } catch (Exception ex) {
                Errmsg.Text = "Error loading tutor information: " + ex.Message;
            }
        }


        private void LoadWardenInformation(string studentID) {
            try {
                // Query to get warden information for the student from StudentTbl and WardenTbl
                string query = $@"
                    SELECT w.WarID, w.DutyBuilding 
                    FROM StudentTbl s
                    JOIN WardenTbl w ON s.Building = w.DutyBuilding
                    WHERE s.StuID = {studentID}";
                DataTable dt = Con.GetData(query);

                if (dt.Rows.Count > 0) {
                    // Set Warden information into the labels
                    WardenID.Text = dt.Rows[0]["WarID"].ToString();
                    //WardenName.Text = "Warden Name Here";  // Replace with actual warden name field if available
                    WardenContact.Text = $"{WardenID.Text}@link.cuhksz.edu.cn";  // Set contact as tutID@link.cuhksz.edu.cn
                    WardenBuilding.Text = dt.Rows[0]["DutyBuilding"].ToString();
                } else {
                    Errmsg.Text = "Warden information not found.";
                }
            } catch (Exception ex) {
                Errmsg.Text = "Error loading warden information: " + ex.Message;
            }
        }
    }
}
