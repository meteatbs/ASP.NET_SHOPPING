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
    public partial class Add_Productt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["admin"] == null)
                {
                    Response.Redirect("Login.aspx");
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-I43AV94;Initial Catalog=Anil;Integrated Security=True");
            if (imageUpload.HasFile)
            {
                string filename = imageUpload.PostedFile.FileName;
                string filepath = "Images/" + imageUpload.FileName;
                imageUpload.PostedFile.SaveAs(Server.MapPath("~/Images/") + filename);
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Product1 VALUES('" + txtName.Text + "','" + txtDesc.Text + "','" + filepath + "','" + txtPrice.Text + "','" + txtQuantity.Text + "','" + DropDownList1.SelectedItem.Text + "')", sqlCon);
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                lblError.Text = "Product Added Succesfully";
                Response.Redirect("Add_Productt.aspx");
            }

        }
    }
}