using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADONET_Practice.Data;


namespace ADO.NET_WebForms_CrudOperationsPractice {
    public partial class StudentList : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!Page.IsPostBack) {
                LoadStudents();
            }
        }
        
        /// <summary>
        /// Load the database students into rptStudents
        /// </summary>
        private void LoadStudents() {
            StudentManager studentManager = new StudentManager();
         

            rptStudents.DataSource = studentManager.GetStudents();
            rptStudents.DataBind();
        }


        /// <summary>
        /// Item command event that is responsible for handling Edit and Delete commands
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptStudents_ItemCommand(object source, RepeaterCommandEventArgs e) {
            if (e.CommandName == "Edit") {
                Response.Redirect("SaveStudent.aspx?id=" + e.CommandArgument.ToString());
            } else if (e.CommandName == "Delete") {
                StudentManager studentManager = new StudentManager();
                studentManager.DeleteStudent(Convert.ToInt32(e.CommandArgument.ToString()));
                LoadStudents();
            }
        }

        protected void btnAddNewStudent_Click(object sender, EventArgs e) {
            Response.Redirect("SaveStudent.aspx");
        }



    }
}