using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Demo_shoppingSite
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-I43AV94;Initial Catalog=Anil;Integrated Security=True");
            if (FileUpload1.HasFile)
            {
                string filename = FileUpload1.PostedFile.FileName;
                string filepath = "Images/" + FileUpload1.FileName;
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Images/") + filename);
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Product1 values ('"+TextBox1.Text+"','"+TextBox2.Text+"','"+TextBox3.Text+"','"+filepath+"','"+TextBox4.Text+"')",sqlCon);
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                Response.Redirect("Default.aspx");

            }
        }
    }
}