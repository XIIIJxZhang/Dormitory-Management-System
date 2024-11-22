using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dormitory_Management_System.Home.Adm {
    public partial class AdminEdit : System.Web.UI.Page {
        private string connectionString = "Data Source=XIII-2205041012\\CSC3170TEST01;Initial Catalog=CSC3170dmsDB;Integrated Security=True";
        private Dictionary<string, string> originalData;
        private string tableName;

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                string jsonData = Request.QueryString["data"];
                tableName = Request.QueryString["table"];

                if (string.IsNullOrEmpty(jsonData) || string.IsNullOrEmpty(tableName)) {
                    Response.Write("<script>alert('No data or table information received. Data: " + jsonData + ", Table: " + tableName + "');</script>");
                    return;
                }

                try {
                    // Deserialize the data passed in the query string
                    JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                    originalData = jsSerializer.Deserialize<Dictionary<string, string>>(jsonData);
                    ViewState["OriginalData"] = originalData;
                    ViewState["TableName"] = tableName;
                } catch (Exception ex) {
                    Response.Write("<script>alert('Error parsing data: " + ex.Message + "');</script>");
                    return;
                }
            } else {
                originalData = (Dictionary<string, string>)ViewState["OriginalData"];
                tableName = (string)ViewState["TableName"];
            }

            GenerateDynamicFields(originalData);
        }

        private void GenerateDynamicFields(Dictionary<string, string> data) {
            if (data == null || data.Count == 0) {
                Response.Write("<script>alert('No data available to generate form fields.');</script>");
                return;
            }

            foreach (var entry in data) {
                // Create label
                Label lbl = new Label {
                    Text = entry.Key,
                    CssClass = "form-label fw-bold",
                    Style = { ["font-size"] = "1.25rem", ["margin-bottom"] = "0.5rem", ["display"] = "block" }
                };
                // Create textbox
                TextBox txt = new TextBox {
                    ID = "txt" + entry.Key,
                    Text = entry.Value.Trim(),
                    CssClass = "form-control w-50",
                    Style = { ["height"] = "2rem" }
                };
                // Add label and textbox to placeholder
                DynamicFormPlaceHolder.Controls.Add(lbl);
                DynamicFormPlaceHolder.Controls.Add(txt);
                DynamicFormPlaceHolder.Controls.Add(new Literal { Text = "<br /><br />" });
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(tableName)) {
                Response.Write("<script>alert('Table information is missing.');</script>");
                return;
            }

            string entityId = originalData.ContainsKey("StuID") ? originalData["StuID"] :
                              originalData.ContainsKey("TutID") ? originalData["TutID"] :
                              originalData.ContainsKey("DormInfo") ? originalData["DormInfo"] :
                              originalData.ContainsKey("WarID") ? originalData["WarID"] : "";

            if (!string.IsNullOrEmpty(entityId)) {
                SaveModifiedData(entityId);
            } else {
                Response.Write("<script>alert('No valid entity ID found in the data.');</script>");
            }
        }

        private void SaveModifiedData(string entityId) {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                try {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open) {
                        Response.Write("<script>alert('Database connected successfully.');</script>");
                    }

                    // Prepare the update query based on the selected table
                    string updateQuery = $"UPDATE {tableName} SET ";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    bool hasChanges = false;

                    foreach (Control control in DynamicFormPlaceHolder.Controls) {
                        if (control is TextBox txt) {
                            string columnName = txt.ID.Substring(3); // Remove "txt" prefix to get column name
                            string originalValue = originalData.ContainsKey(columnName) ? originalData[columnName].Trim() : "";

                            if (!txt.Text.Trim().Equals(originalValue, StringComparison.Ordinal)) {
                                // Only update fields that have been changed
                                updateQuery += columnName + " = @" + columnName + ", ";
                                cmd.Parameters.AddWithValue("@" + columnName, txt.Text.Trim());
                                hasChanges = true;
                            }
                        }
                    }

                    if (hasChanges) {
                        updateQuery = updateQuery.TrimEnd(',', ' ');
                        updateQuery += " WHERE " + GetEntityIdColumnName() + " = @EntityId";
                        cmd.CommandText = updateQuery;
                        cmd.Parameters.AddWithValue("@EntityId", entityId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0) {
                            Response.Write("<script>alert('Record updated successfully.');</script>");
                        } else {
                            Response.Write("<script>alert('No records were updated. Please check the provided data.');</script>");
                        }
                    } else {
                        Response.Write("<script>alert('No changes detected.');</script>");
                    }
                } catch (Exception ex) {
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
        }

        private string GetEntityIdColumnName() {
            switch (tableName) {
                case "StudentTbl":
                return "StuID";
                case "TutorTbl":
                return "TutID";
                case "DormTbl":
                return "DormInfo";
                case "WardenTbl":
                return "WarID";
                default:
                throw new InvalidOperationException("Unknown table name.");
            }
        }

        protected void ResetButton_Click(object sender, EventArgs e) {
            // Refresh the page to reset all changes
            Response.Redirect(Request.RawUrl);
        }

        protected void FinishedButton_Click(object sender, EventArgs e) {
            // Redirect back to the corresponding info page based on the table
            string redirectPage;
            switch (tableName) {
                case "StudentTbl":
                redirectPage = "StudentInfo.aspx";
                break;
                case "TutorTbl":
                redirectPage = "TutorInfo.aspx";
                break;
                case "DormTbl":
                redirectPage = "DormsInfo.aspx";
                break;
                case "WardenTbl":
                redirectPage = "WardenInfo.aspx";
                break;
                default:
                redirectPage = "DefaultPage.aspx";
                break;
            }
            Response.Redirect(redirectPage);
        }
    }
}
