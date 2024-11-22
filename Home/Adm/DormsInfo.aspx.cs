using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using System.Web;

namespace Dormitory_Management_System.Home.Adm {
    public partial class DormsInfo : System.Web.UI.Page {
        private string connectionString = "Data Source=XIII-2205041012\\CSC3170TEST01;Initial Catalog=CSC3170dmsDB;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                LoadDormData();
            }
        }

        private void LoadDormData(string searchKeyword = "") {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                try {
                    conn.Open();
                    string query = "SELECT * FROM DormTbl";
                    if (!string.IsNullOrEmpty(searchKeyword)) {
                        query += " WHERE DormInfo LIKE @Search OR StuID LIKE @Search";
                    }
                    SqlCommand cmd = new SqlCommand(query, conn);
                    if (!string.IsNullOrEmpty(searchKeyword)) {
                        cmd.Parameters.AddWithValue("@Search", "%" + searchKeyword + "%");
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dormTable.DataSource = dt;
                    dormTable.DataBind();
                } catch (Exception ex) {
                    // Handle exceptions (e.g., log the error)
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e) {
            string searchKeyword = SearchTextBox.Text.Trim();
            LoadDormData(searchKeyword);
        }

        protected void dormTable_RowCommand(object sender, GridViewCommandEventArgs e) {
            if (e.CommandName == "EditDorm") {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dormTable.Rows[index];


                // Get all dorm information
                var dormData = new
                {
                    DormInfo = dormTable.DataKeys[index].Value.ToString(),
                    StuID = row.Cells[2].Text,
                    EleFee = row.Cells[3].Text,
                };

                // Serialize data to JSON
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                string jsonData = jsSerializer.Serialize(dormData);

                // Pass JSON data and table name as parameters to AdminEdit.aspx
                Response.Redirect($"AdminEdit.aspx?data={HttpUtility.UrlEncode(jsonData)}&table=DormTbl");
            } else if (e.CommandName == "DeleteDorm") {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = dormTable.Rows[index];
                string dormInfo = dormTable.DataKeys[index].Value.ToString();
                DeleteDorm(dormInfo);
                LoadDormData();
            }
        }

        private void DeleteDorm(string dormInfo) {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                try {
                    conn.Open();
                    string query = "DELETE FROM DormTbl WHERE DormInfo = @DormInfo";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@DormInfo", dormInfo);
                    cmd.ExecuteNonQuery();
                } catch (Exception ex) {
                    // Handle exceptions (e.g., log the error)
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }
    }
}