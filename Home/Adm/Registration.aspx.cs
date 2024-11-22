using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dormitory_Management_System.Home.Adm {
    public partial class Registration : System.Web.UI.Page {
        Models.Functions Con;

        protected void Page_Load(object sender, EventArgs e) {
            Con = new Models.Functions();
            if (!IsPostBack) {
                CreateBtn.ServerClick += new EventHandler(CreateBtn_Click);
                bool isConnected = Con.TestConnection();
                if (isConnected) {
                    Errmsg.Text = "Database connected successfully!";
                } else {
                    Errmsg.Text = "Failed to connect to the database.";
                }
            }
        }

        protected void CreateBtn_Click(object sender, EventArgs e) {
            try {
                // Input validation
                if (string.IsNullOrEmpty(usrIDRe.Value)) {
                    Errmsg.Text = "Please Enter Your Name !!!";
                    return;
                } else if (string.IsNullOrEmpty(usrFloorRe.Value)) {
                    Errmsg.Text = "Please Enter Your Floor !!!";
                    return;
                } else if (string.IsNullOrEmpty(usrBuildingRe.Value)) {
                    Errmsg.Text = "Please Enter Your Building !!!";
                    return;
                } else if (string.IsNullOrEmpty(usrDormRe.Value) && idenStu.Checked) {
                    Errmsg.Text = "Please Enter Your Dorm Number !!!";
                    return;
                } else if (string.IsNullOrEmpty(usrPasswordRe.Value)) {
                    Errmsg.Text = "Password Should Not Be Empty !!!";
                    return;
                } else if (string.IsNullOrEmpty(usrTelRe.Value) && idenStu.Checked) {
                    Errmsg.Text = "Please Enter Your Telephone Number !!!";
                    return;
                } else if (!idenStu.Checked && !idenTut.Checked && !idenWar.Checked && !idenAdmin.Checked) {
                    Errmsg.Text = "Please Verify Your Identity !!!";
                    return;
                }

                // Handle Student Registration
                if (idenStu.Checked) {
                    string insertQuery = $"INSERT INTO StudentTbl (StuID, Password, Floor, Building, DormInfo, TelNumber, IdenState, CreateDate, Name) " +
                                         $"VALUES ('{usrIDRe.Value}', '{usrPasswordRe.Value}', '{usrFloorRe.Value}', '{usrBuildingRe.Value}', '{usrDormRe.Value}', '{usrTelRe.Value}', 0, '{DateTime.Now}', '{usrNameRe.ValidateRequestMode}')";

                    Con.SetData(insertQuery);
                }
                // Handle Tutor Registration
                else if (idenTut.Checked) {

                    string tmpInfo = usrBuildingRe.Value + usrFloorRe.Value;

                    string insertQuery = $"INSERT INTO TutorTbl ( FloorInfo, DutyFloor, TutID, Password, Building, IdenState, CreateDate) " +
                                         $"VALUES ('{tmpInfo}', {usrFloorRe.Value}', '{usrIDRe.Value}', '{usrPasswordRe.Value}', '{usrBuildingRe.Value}', 1, '{DateTime.Now}')";

                    Con.SetData(insertQuery);
                }
                // Handle Warden Registration
                else if (idenWar.Checked) {
                    string insertQuery = $"INSERT INTO WardenTbl (DutyBuilding, WarID, Password, IdenState, CreateDate) " +
                                         $"VALUES ('{usrBuildingRe.Value}', '{usrIDRe.Value}', '{usrPasswordRe.Value}', 1, '{DateTime.Now}')";

                    Con.SetData(insertQuery);
                }
                // Handle Administrator Registration
                else if (idenAdmin.Checked) {

                    string insertQuery = $"INSERT INTO AdminTbl (AdID, Password, IdenState, CreateDate) " +
                                         $"VALUES ('{usrIDRe.Value}', '{usrPasswordRe.Value}', 4, '{DateTime.Now}')";

                    Con.SetData(insertQuery);
                }

                Errmsg.Text = "Account created successfully!";


            } catch (Exception exc) {
                Errmsg.Text = "An error occurred: " + exc.Message;
            }
        }

    }
}
