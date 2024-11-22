using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dormitory_Management_System.Home.Stu {
    public partial class DormInfo : System.Web.UI.Page {
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
                LoadDormitoryInformation(userID);
            } else {
                // Show error if the user is not a student
                Errmsg.Text = "Invalid user type. You do not have permission to view this page.";
            }
        }

        private void LoadDormitoryInformation(string studentID) {
            try {
                // Query to get dormitory information for the student from DormTbl
                string query = $"SELECT DormInfo, StuID, EleFee FROM DormTbl WHERE StuID = {studentID}";
                DataTable dt = Con.GetData(query);

                if (dt.Rows.Count > 0) {
                    // Set dormitory information into the labels
                    DormInfoLabel.Text = dt.Rows[0]["DormInfo"].ToString();
                    StuIDLabel.Text = dt.Rows[0]["StuID"].ToString();
                    EleFeeLabel.Text = "¥" + dt.Rows[0]["EleFee"].ToString();
                } else {
                    Errmsg.Text = "Dormitory information not found.";
                }
            } catch (Exception ex) {
                Errmsg.Text = "Error loading dormitory information: " + ex.Message;
            }
        }
    }
}
