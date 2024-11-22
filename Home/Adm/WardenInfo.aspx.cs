using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using System.Web;

namespace Dormitory_Management_System.Home.Adm {
    public partial class WardenInfo : System.Web.UI.Page {
        private string connectionString = "Data Source=XIII-2205041012\\CSC3170TEST01;Initial Catalog=CSC3170dmsDB;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                LoadWardenData();
            }
        }

        private void LoadWardenData(string searchKeyword = "") {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                try {
                    conn.Open();
                    string query = "SELECT * FROM WardenTbl";
                    if (!string.IsNullOrEmpty(searchKeyword)) {
                        query += " WHERE WarID LIKE @Search OR Name LIKE @Search OR DormInfo LIKE @Search";
                    }
                    SqlCommand cmd = new SqlCommand(query, conn);
                    if (!string.IsNullOrEmpty(searchKeyword)) {
                        cmd.Parameters.AddWithValue("@Search", "%" + searchKeyword + "%");
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    wardenTable.DataSource = dt;
                    wardenTable.DataBind();
                } catch (Exception ex) {
                    // Handle exceptions (e.g., log the error)
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e) {
            string searchKeyword = SearchTextBox.Text.Trim();
            LoadWardenData(searchKeyword);
        }

        protected void wardenTable_RowCommand(object sender, GridViewCommandEventArgs e) {
            if (e.CommandName == "EditWarden") {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = wardenTable.Rows[index];

                // Get all warden information
                var wardenData = new
                {
                    WarID = wardenTable.DataKeys[index].Value.ToString(),
                    Password = row.Cells[2].Text,
                    DutyBuilding = row.Cells[3].Text,
                    CreateDate = row.Cells[4].Text,
                };

                // Serialize data to JSON
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                string jsonData = jsSerializer.Serialize(wardenData);

                // Pass JSON data and table name as parameters to AdminEdit.aspx
                Response.Redirect($"AdminEdit.aspx?data={HttpUtility.UrlEncode(jsonData)}&table=WardenTbl");
            } else if (e.CommandName == "DeleteWarden") {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = wardenTable.Rows[index];
                string wardenId = wardenTable.DataKeys[index].Value.ToString();
                DeleteWarden(wardenId);
                LoadWardenData();
            }
        }

        private void DeleteWarden(string wardenId) {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                try {
                    conn.Open();
                    string query = "DELETE FROM WardenTbl WHERE WarID = @WarID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@WarID", wardenId);
                    cmd.ExecuteNonQuery();
                } catch (Exception ex) {
                    // Handle exceptions (e.g., log the error)
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }
    }
}
