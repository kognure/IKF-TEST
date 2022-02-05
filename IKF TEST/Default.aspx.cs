using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace IKF_TEST
{
    public partial class _Default : Page
    {
       SqlConnection con =new SqlConnection( @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Vivek\Demo.mdf;Integrated Security=True");
        private SqlCommand _sqlCommand;
        private SqlDataAdapter _sqlDataAdapter;
        DataSet _dtSet;
        int result = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindEmployeeData();

            }
            btnUpdate.Visible = false;
            btnAddEmployee.Visible = true;
        }
        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
              
                string message = string.Empty;
                foreach (ListItem item in list_skills.Items)
                {
                    if (item.Selected)
                    {
                        message += item.Text;
                    }
                }

                _sqlCommand = new SqlCommand("EMP_Add", con);
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlCommand.Parameters.AddWithValue("Perform", "Insert");
                _sqlCommand.Parameters.AddWithValue("Name", txt_name.Text);
                _sqlCommand.Parameters.AddWithValue("DOB", txtRFPIssueDate.Text);
                _sqlCommand.Parameters.AddWithValue("Designation", txt_designation.Text);
                _sqlCommand.Parameters.AddWithValue("Skills", list_skills.SelectedValue.ToString());

                con.Open();
                result=_sqlCommand.ExecuteNonQuery();
                con.Close();


                if (result > 0)
                {

                    ShowAlertMessage("Record Is Inserted Successfully");
                    BindEmployeeData();
                    ClearControls();
                }
                else
                {

                    ShowAlertMessage("Failed");
                }
            }
            catch (Exception ex)
            {

                ShowAlertMessage("Check your input data");

            }
            finally
            {
               
            }
        }

        protected void grvEmployee_RowEditing(object sender, GridViewEditEventArgs e)
        {
            btnAddEmployee.Visible = false;
            btnUpdate.Visible = true;

            int RowIndex = e.NewEditIndex;
            Label empid = (Label)grvEmployee.Rows[RowIndex].FindControl("lblEmpId");
            Session["EmpId"] = empid.Text;

            txt_name.Text = ((Label)grvEmployee.Rows[RowIndex].FindControl("lblName")).Text.ToString();
            txt_designation.Text = ((Label)grvEmployee.Rows[RowIndex].FindControl("lblDesignation")).Text.ToString();
            txtRFPIssueDate.Text = ((Label)grvEmployee.Rows[RowIndex].FindControl("lblDOB")).Text.ToString();
            list_skills.Text = ((Label)grvEmployee.Rows[RowIndex].FindControl("lblSkills")).Text.ToString();

        }


        protected void grvEmployee_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                
                Label id = (Label)grvEmployee.Rows[e.RowIndex].FindControl("lblEmpId");
                _sqlCommand =new SqlCommand( "Emp_Add",con);
                _sqlCommand.Parameters.AddWithValue("@Perform", "Delete");
                _sqlCommand.Parameters.AddWithValue("@EmpId", Convert.ToInt32(id.Text));
                _sqlCommand.Parameters.AddWithValue("Name", txt_name.Text);
                _sqlCommand.Parameters.AddWithValue("DOB", txtRFPIssueDate.Text);
                _sqlCommand.Parameters.AddWithValue("Designation", txt_designation.Text);
                _sqlCommand.Parameters.AddWithValue("Skills", list_skills.SelectedValue.ToString());
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                con.Open();
                int result = Convert.ToInt32(_sqlCommand.ExecuteNonQuery());
                con.Close();
                if (result > 0)
                {

                    ShowAlertMessage("Record Is Deleted Successfully");
                    grvEmployee.EditIndex = -1;
                    BindEmployeeData();
                    
                }
                else
                {
                    lblMessage.Text = "Failed";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    BindEmployeeData();
                    con.Close();
                }
            }
            catch (Exception ex)
            {

                ShowAlertMessage("Check your input data");
            }
            finally
            {
               
            }
        }

        protected void grvEmployee_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvEmployee.EditIndex = -1;
            BindEmployeeData();
        }

        protected void grvEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvEmployee.PageIndex = e.NewPageIndex;
            BindEmployeeData();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
               

                _sqlCommand = new SqlCommand("EMP_Add", con);
               
                    
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlCommand.Parameters.AddWithValue("@Perform","Update");
                _sqlCommand.Parameters.AddWithValue("@Name", txt_name.Text);
                _sqlCommand.Parameters.AddWithValue("@DOB", txtRFPIssueDate.Text);
                _sqlCommand.Parameters.AddWithValue("@Designation", txt_designation.Text);
                _sqlCommand.Parameters.AddWithValue("@Skills", list_skills.SelectedValue.ToString());
                _sqlCommand.Parameters.AddWithValue("@EmpId", Session["EmpId"]);
                con.Open();
               int result = _sqlCommand.ExecuteNonQuery();
                con.Close();
               
                if (result > 0)
                {
                    ShowAlertMessage("Record Is Updated Successfully");
                    grvEmployee.EditIndex = -1;
                    BindEmployeeData();
                    ClearControls();
                    con.Close();
                }
                else
                {
                    ShowAlertMessage("Failed");
                    con.Close();
                }
            }

            catch (Exception ex)
            {
                ShowAlertMessage("Check your input data");
            }
            finally
            {
               
            }
        }
      
        public void BindEmployeeData()
        {
            try
            {
               
                _sqlCommand =new SqlCommand("Emp_Add",con);
                con.Open();
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlCommand.Parameters.AddWithValue("@Perform", "Select");
                _sqlCommand.Parameters.AddWithValue("Name", txt_name.Text);
                _sqlCommand.Parameters.AddWithValue("DOB", txtRFPIssueDate.Text);
                _sqlCommand.Parameters.AddWithValue("Designation", txt_designation.Text);
                _sqlCommand.Parameters.AddWithValue("Skills", list_skills.SelectedValue.ToString());
                _sqlDataAdapter = new SqlDataAdapter(_sqlCommand);
                _dtSet = new DataSet();
                _sqlDataAdapter.Fill(_dtSet);
                grvEmployee.DataSource = _dtSet;
                grvEmployee.DataBind();
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Redirect("The Error is " + ex);
            }
            finally
            {
               
            }
        }
        private static void ShowAlertMessage(string error)
        {
            System.Web.UI.Page page = System.Web.HttpContext.Current.Handler as System.Web.UI.Page;
            if (page != null)
            {
                error = error.Replace("'", "\'");
                System.Web.UI.ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error + "');", true);
            }
        }

        public void ClearControls()
        {
            txtRFPIssueDate.Text = "";
            txt_designation.Text = "";
            txt_name.Text = "";
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

        }
    }
} 
   
