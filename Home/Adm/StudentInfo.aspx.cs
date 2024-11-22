using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using System.Web;

namespace Dormitory_Management_System.Home.Adm {
    public partial class StudentInfo : System.Web.UI.Page {
        private string connectionString = "Data Source=XIII-2205041012\\CSC3170TEST01;Initial Catalog=CSC3170dmsDB;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                LoadStudentData();
            }
        }

        private void LoadStudentData(string searchKeyword = "") {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                try {
                    conn.Open();
                    string query = "SELECT * FROM StudentTbl";
                    if (!string.IsNullOrEmpty(searchKeyword)) {
                        query += " WHERE StuID LIKE @Search OR Name LIKE @Search OR DormInfo LIKE @Search";
                    }
                    SqlCommand cmd = new SqlCommand(query, conn);
                    if (!string.IsNullOrEmpty(searchKeyword)) {
                        cmd.Parameters.AddWithValue("@Search", "%" + searchKeyword + "%");
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    studentTable.DataSource = dt;
                    studentTable.DataBind();
                } catch (Exception ex) {
                    // Handle exceptions (e.g., log the error)
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e) {
            string searchKeyword = SearchTextBox.Text.Trim();
            LoadStudentData(searchKeyword);
        }

        protected void studentTable_RowCommand(object sender, GridViewCommandEventArgs e) {
            if (e.CommandName == "EditStudent") {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = studentTable.Rows[index];

                // Get all student information
                var studentData = new
                {
                    StuID = studentTable.DataKeys[index].Value.ToString(),
                    Password = row.Cells[2].Text,
                    Floor = row.Cells[3].Text,
                    Building = row.Cells[4].Text,
                    TelNumber = row.Cells[5].Text,
                    DormInfo = row.Cells[6].Text,
                    CreateDate = row.Cells[7].Text,
                    isVisited = row.Cells[8].Text,
                    Name = row.Cells[9].Text
                };

                // Serialize data to JSON
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                string jsonData = jsSerializer.Serialize(studentData);

                // Pass JSON data and table name as parameters to AdminEdit.aspx
                Response.Redirect($"AdminEdit.aspx?data={HttpUtility.UrlEncode(jsonData)}&table=StudentTbl");
            } else if (e.CommandName == "DeleteStudent") {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = studentTable.Rows[index];
                string studentId = studentTable.DataKeys[index].Value.ToString();
                DeleteStudent(studentId);
                LoadStudentData();
            }
        }

        private void DeleteStudent(string studentId) {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                try {
                    conn.Open();
                    string query = "DELETE FROM StudentTbl WHERE StuID = @StuID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StuID", studentId);
                    cmd.ExecuteNonQuery();
                } catch (Exception ex) {
                    // Handle exceptions (e.g., log the error)
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }
    }
}
