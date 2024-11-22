using System;
using System.Web.UI;

namespace Dormitory_Management_System.Home {
    public partial class Logout : Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                Session.Clear();
                Session.Abandon();
            }
        }

        protected void BtnReLogin_Click(object sender, EventArgs e) {
            // Add JavaScript to ensure the redirection works
            string script = "window.location.href = '/Home/Login.aspx';";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", script, true);
        }
    }
}