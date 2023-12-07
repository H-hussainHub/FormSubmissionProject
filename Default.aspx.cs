using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace housing21Project
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
             {
                // Set the max attribute to yesterday's date
                txtDOB.Attributes["max"] = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
             }
        }      

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString.ToString()))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO UserDetails(Name, DateOfBirth, Telephone, Email) OUTPUT INSERTED.ID VALUES(@Name, @DOB, @Telephone, @Email)";
                        command.CommandType = CommandType.Text;

                        command.Parameters.AddWithValue("@Name", txtName.Text);
                        command.Parameters.AddWithValue("@DOB", txtDOB.Text);
                        command.Parameters.AddWithValue("@Telephone", txtTelephone.Text);
                        command.Parameters.AddWithValue("@Email", txtEmail.Text);

                        int newId = (int)command.ExecuteScalar();

                        // Display the new ID on the page
                        lblNewId.Text = "New Record ID: " + newId.ToString();
                    }
                    connection.Close();
                }
            }
            catch (SqlException sqlEx)
            {
                // Handle SQL-specific errors here
                lblErrorMessage.Text = "Database error: " + sqlEx.Message;
            }
            catch (Exception ex)
            {
                // Handle non-SQL errors here
                lblErrorMessage.Text = "An error occurred: " + ex.Message;
            }

        }
    }
}