using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace housing21Project
{
    public partial class table : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }

        }
        private void BindData()
        {
            GridView1.DataSource = GetData();
            GridView1.DataBind();
        }
        private DataTable GetData()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString.ToString()))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM UserDetails";
                    command.CommandType = CommandType.Text;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
                connection.Close();
            }

            return dt;
        }


        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dt = GetData(); // Fetch the data again
            StringBuilder sb = new StringBuilder();

            // Add Header
            foreach (DataColumn column in dt.Columns)
            {
                sb.Append(column.ColumnName + ',');
            }
            sb.AppendLine();

            // Add Data
            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    sb.Append(row[column].ToString().Replace(",", ";") + ',');
                }
                sb.AppendLine();
            }

            // Send CSV to the browser
            Response.Clear();
            Response.ContentType = "text/csv";
            Response.AddHeader("Content-Disposition", "attachment;filename=ExportedData.csv");
            Response.Write(sb.ToString());
            Response.End();
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.TableSection = TableRowSection.TableHeader;

                e.Row.Cells[0].Attributes["scope"] = "ID";
                e.Row.Cells[1].Attributes["scope"] = "Name";
                e.Row.Cells[2].Attributes["scope"] = "DateOfBirth";
                e.Row.Cells[3].Attributes["scope"] = "Telephone";
                e.Row.Cells[4].Attributes["scope"] = "Email";
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Apply CSS classes to each row
                e.Row.CssClass = "table-row";

                e.Row.Cells[0].Attributes["data-label"] = "ID";
                e.Row.Cells[1].Attributes["data-label"] = "Name";
                e.Row.Cells[2].Attributes["data-label"] = "DateOfBirth";
                e.Row.Cells[3].Attributes["data-label"] = "Telephone";
                e.Row.Cells[4].Attributes["data-label"] = "Email";
            }
        }
    }
}