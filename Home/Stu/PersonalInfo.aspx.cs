using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dormitory_Management_System.Home.Stu {
    public partial class PersonalInfo : Page {
        Models.Functions Con;

        // Declare TextBox controls
        protected TextBox txtName;
        protected TextBox txtStudentID;
        protected TextBox txtPWD;
        protected TextBox txtDormitory;
        protected TextBox txtPhoneNumber;
        protected TextBox txtFloor;
        protected TextBox txtBuilding;

        protected void Page_Load(object sender, EventArgs e) {
            // Ensure the user is logged in
            if (Session["UserID"] == null || Session["UserType"] == null) {
                // If no login information is found, redirect to login page
                Response.Redirect("~/Home/Login.aspx");
                return;
            }

            string userID = Session["UserID"].ToString();
            string userType = Session["UserType"].ToString();

            Con = new Models.Functions();

            if (!IsPostBack) {
                LoadUserInfo(userID, userType);
            }
        }

        private void LoadUserInfo(string userID, string userType) {
            try {
                // If the user type is "Student", fetch user data from StudentTbl
                if (userType == "Student") {
                    string query = $"SELECT * FROM StudentTbl WHERE StuID = '{userID}'";
                    DataTable dt = Con.GetData(query);

                    if (dt.Rows.Count > 0) {
                        var user = dt.Rows[0];
                        lblName.Text = user["Name"].ToString(); // Student name
                        lblStudentID.Text = user["StuID"].ToString(); // Student ID
                        lblDormitory.Text = user["DormInfo"].ToString(); // Dormitory info
                        lblPhoneNumber.Text = user["TelNumber"].ToString(); // Phone number
                        lblFloor.Text = user["Floor"].ToString(); // Floor info
                        lblBuilding.Text = user["Building"].ToString(); // Building info
                        lblPWD.Text = user["Password"].ToString();
                    } else {
                        Errmsg.Text = "User information not found!";
                    }
                } else {
                    // If the user is not a student, show an error or handle accordingly
                    Errmsg.Text = "Current user does not have permission to view this information.";
                }
            } catch (Exception ex) {
                Errmsg.Text = "An error occurred while loading user information: " + ex.Message;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e) {
            // Replace labels with textboxes for editing
            MakeEditable(lblName, txtName, true);
            MakeEditable(lblStudentID, txtStudentID, false); // Student ID is not editable
            MakeEditable(lblPWD, txtPWD, true);
            MakeEditable(lblDormitory, txtDormitory, false); // Dormitory info is not editable
            MakeEditable(lblPhoneNumber, txtPhoneNumber, true);
            MakeEditable(lblFloor, txtFloor, false); // Floor info is not editable
            MakeEditable(lblBuilding, txtBuilding, false); // Building info is not editable

            // Show Save button
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }

        protected void btnSave_Click(object sender, EventArgs e) {
            try {
                string userID = Session["UserID"].ToString();

                // Get updated values or retain original values if not modified
                string updatedName = string.IsNullOrWhiteSpace(txtName.Text) ? lblName.Text : txtName.Text;
                string updatedPWD = string.IsNullOrWhiteSpace(txtPWD.Text) ? lblPWD.Text : txtPWD.Text;
                string updatedPhoneNumber = string.IsNullOrWhiteSpace(txtPhoneNumber.Text) ? lblPhoneNumber.Text : txtPhoneNumber.Text;

                // Update query
                string query = $"UPDATE StudentTbl SET Name = '{updatedName}', Password = '{updatedPWD}', TelNumber = '{updatedPhoneNumber}' WHERE StuID = '{userID}'";
                Con.SetData(query);

                // Pop up success message and redirect
                ClientScript.RegisterStartupScript(this.GetType(), "updateSuccess", "alert('Information updated successfully!'); window.location='PersonalInfo.aspx';", true);
            } catch (Exception ex) {
                Errmsg.Text = "An error occurred while updating user information: " + ex.Message;
            }
        }

        private void MakeEditable(Label label, TextBox textBox, bool editable = true) {
            textBox.Text = label.Text;
            textBox.Visible = true;
            textBox.Enabled = editable;
            label.Visible = false;
        }
    }
}
