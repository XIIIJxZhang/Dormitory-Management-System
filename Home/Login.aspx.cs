using System;
using System.Data;
using System.Web;
using System.Web.UI;

namespace Dormitory_Management_System.Home {

    public partial class Login : System.Web.UI.Page {

        Models.Functions Con;
        int tmpIden = -1;  // 初始值为 -1，表示未设置

        protected void Page_Load(object sender, EventArgs e) {
            Con = new Models.Functions();
        }

        protected void LoginBtn_Click(object sender, EventArgs e) {
            string userID = usrIDIn.Value.Trim();
            string password = usrPwdIn.Value.Trim();
            bool keepMeLoggedIn = rememberMe.Checked;

            if (string.IsNullOrEmpty(userID) || string.IsNullOrEmpty(password)) {
                Errmsg.Text = "Please enter both ID number and password.";
                return;
            }

            string userType = GetUserType(userID);
            if (userType == "Invalid") {
                Errmsg.Text = "Invalid ID number format.";
                return;
            }

            try {
                // SQL Query to check if the user exists in the corresponding table.
                string query = $"SELECT * FROM {GetTableName(userType)} WHERE {GetIdColumnName(userType)} = '{userID}' AND Password = '{password}'";
                DataTable dt = Con.GetData(query);

                if (dt.Rows.Count > 0) {
                    // User exists, proceed with login
                    Session["UserID"] = userID;
                    Session["UserType"] = userType;

                    // 获取用户的 IdenState 值
                    tmpIden = Convert.ToInt32(dt.Rows[0]["IdenState"]);

                    // If "Keep me logged in" checkbox is checked, set a cookie
                    if (keepMeLoggedIn) {
                        HttpCookie userCookie = new HttpCookie("UserLogin");
                        userCookie["UserID"] = userID;
                        userCookie["UserType"] = userType;
                        userCookie.Expires = DateTime.Now.AddDays(30);
                        Response.Cookies.Add(userCookie);
                    }

                    // Trigger frontend JavaScript for animations and transitions with a 3-second delay
                    ClientScript.RegisterStartupScript(this.GetType(), "LoginSuccess", "handleLoginSuccess();", true);

                    // Set a 3-second delay for redirect
                    ClientScript.RegisterStartupScript(this.GetType(), "RedirectDelay", "setTimeout(function() { window.location.href = '" + GetRedirectUrl() + "'; }, 2500);", true);
                } else {
                    Errmsg.Text = "Invalid ID number or password. Please try again.";
                }
            } catch (Exception ex) {
                Errmsg.Text = "An error occurred during login: " + ex.Message;
            }
        }

        // Helper method to get the appropriate redirect URL based on tmpIden
        private string GetRedirectUrl() {
            switch (tmpIden) {
                case 0:  // Student
                return "/Home/Stu/StuWelcome.aspx";
                case 1:  // Tutor
                return "/Home/Tut/TutWelcome.aspx";
                case 2:  // Warden
                return "/Home/War/WarnWelcome.aspx";
                case 3:  // Admin
                return "/Home/Adm/AdminWelcome.aspx";
                default:
                return "Login.aspx";  // Default to error page if tmpIden is invalid
            }
        }



        private string GetUserType(string userID) {
            if (userID.Length == 2) {
                return "Admin";
            } else if (userID.Length == 3) {
                return "Warden";
            } else if (userID.Length == 4) {
                return "Tutor";
            } else if (userID.Length >= 5) {
                return "Student";
            } else {
                return "Invalid";
            }
        }

        private string GetTableName(string userType) {
            switch (userType) {
                case "Admin":
                return "AdminTbl";
                case "Warden":
                return "WardenTbl";
                case "Tutor":
                return "TutorTbl";
                case "Student":
                return "StudentTbl";
                default:
                return string.Empty;
            }
        }

        private string GetIdColumnName(string userType) {
            switch (userType) {
                case "Admin":
                return "AdID";
                case "Warden":
                return "WardenID";
                case "Tutor":
                return "TutID";
                case "Student":
                return "StuID";
                default:
                return string.Empty;
            }
        }


        protected void ResetBtn_Click(object sender, EventArgs e) {
            // Clear the input fields
            usrIDIn.Value = string.Empty;
            usrPwdIn.Value = string.Empty;

            // Uncheck the "Keep me logged in" checkbox
            rememberMe.Checked = false;

            // Clear any error message
            Errmsg.Text = string.Empty;
        }


    }
}
