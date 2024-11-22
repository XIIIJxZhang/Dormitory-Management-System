using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using System.Web;

namespace Dormitory_Management_System.Home.Adm {
    public partial class TutorInfo : System.Web.UI.Page {
        private string connectionString = "Data Source=XIII-2205041012\\CSC3170TEST01;Initial Catalog=CSC3170dmsDB;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                LoadTutorData();
            }
        }

        private void LoadTutorData(string searchKeyword = "") {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                try {
                    conn.Open();
                    string query = "SELECT * FROM TutorTbl";
                    if (!string.IsNullOrEmpty(searchKeyword)) {
                        query += " WHERE TutID LIKE @Search OR DutyFloor LIKE @Search OR Building LIKE @Search";
                    }
                    SqlCommand cmd = new SqlCommand(query, conn);
                    if (!string.IsNullOrEmpty(searchKeyword)) {
                        cmd.Parameters.AddWithValue("@Search", "%" + searchKeyword + "%");
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    tutorTable.DataSource = dt;
                    tutorTable.DataBind();
                } catch (Exception ex) {
                    // Handle exceptions (e.g., log the error)
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e) {
            string searchKeyword = SearchTextBox.Text.Trim();
            LoadTutorData(searchKeyword);
        }

        protected void tutorTable_RowCommand(object sender, GridViewCommandEventArgs e) {
            if (e.CommandName == "EditTutor") {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = tutorTable.Rows[index];

                // Get all tutor information
                var tutorData = new
                {
                    TutID = tutorTable.DataKeys[index].Value.ToString(),
                    Password = row.Cells[2].Text,
                    DutyFloor = row.Cells[3].Text,
                    Building = row.Cells[4].Text,
                    CreateDate = row.Cells[5].Text
                };

                // Serialize data to JSON
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                string jsonData = jsSerializer.Serialize(tutorData);

                // Pass JSON data and table name as parameters to AdminEdit.aspx
                Response.Redirect($"AdminEdit.aspx?data={HttpUtility.UrlEncode(jsonData)}&table=TutorTbl");
            } else if (e.CommandName == "DeleteTutor") {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = tutorTable.Rows[index];
                string tutorId = tutorTable.DataKeys[index].Value.ToString();
                DeleteTutor(tutorId);
                LoadTutorData();
            }
        }

        private void DeleteTutor(string tutorId) {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                try {
                    conn.Open();
                    string query = "DELETE FROM TutorTbl WHERE TutID = @TutID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TutID", tutorId);
                    cmd.ExecuteNonQuery();
                } catch (Exception ex) {
                    // Handle exceptions (e.g., log the error)
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }
    }
}