using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Demo_shoppingSite
{
    public partial class UpdateProduct : System.Web.UI.Page
    {

        string str = "Data Source=DESKTOP-I43AV94;Initial Catalog=Anil;Integrated Security=True";
        int Productid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["admin"]==null)
                {
                    Response.Redirect("Login.aspx");
                }
                ShowProduct();
            }
        }
        public void ShowProduct() {
            SqlConnection sqlCon = new SqlConnection(str);
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Product1", sqlCon);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

    

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowProduct();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            DropDownList1.SelectedValue = "Select Category";
            ShowProduct();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            int index = e.NewEditIndex;
            GridViewRow row = (GridViewRow)GridView1.Rows[index];
            Label productID = (Label)row.FindControl("Label1");
            Productid = int.Parse(productID.Text.ToString());
            SqlConnection sqlCon = new SqlConnection(str);
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Product1 where ProductId='" + Productid + "'", sqlCon);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int index = Productid;
            GridViewRow row = (GridViewRow)GridView1.Rows[index];

            FileUpload fu = (FileUpload)row.FindControl("FileUpload1");
            if (fu.HasFile)
            {
                Label productID = (Label)row.FindControl("Label1");
                TextBox pName = (TextBox)row.FindControl("TextBox1");
                TextBox pDesc = (TextBox)row.FindControl("TextBox2");
                TextBox pPrice = (TextBox)row.FindControl("TextBox3");
                TextBox pQuantity = (TextBox)row.FindControl("TextBox4");
                string pCategory = ((DropDownList)GridView1.Rows[e.RowIndex].Cells[6].FindControl("DropDownList2")).Text;

                fu.SaveAs(Server.MapPath("~/Images/") + Path.GetFileName(fu.FileName));
                String pImage = "Images/" + Path.GetFileName(fu.FileName);

                SqlConnection sqlcon = new SqlConnection(str);
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Product1 set Pname=@1,Pdesc=@2,Pimage=@3,Pprice=@4,Pquantity=@5,Pcategory=@6 where ProductId=@7", sqlcon);
                cmd.Parameters.AddWithValue("@1",pName.Text);
                cmd.Parameters.AddWithValue("@2",pDesc.Text);
                cmd.Parameters.AddWithValue("@3",pImage);
                cmd.Parameters.AddWithValue("@4",pPrice.Text);
                cmd.Parameters.AddWithValue("@5",pQuantity.Text);
                cmd.Parameters.AddWithValue("@6",pCategory);
                cmd.Parameters.AddWithValue("@7",productID.Text);
                cmd.ExecuteNonQuery();
               
                GridView1.EditIndex=-1;
                lblError.Text="Product Updated Succesfully";
                 sqlcon.Close();
                ShowProduct();
                DropDownList1.SelectedValue="Select Category";

            }
            else
	{
                lblError.Text="Please Select Product Image";
	}
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Cname = DropDownList1.SelectedValue.ToString();
            if (Cname=="Select Category")
            {
                ShowProduct();
            }
            else
            {
                SqlConnection sqlcon = new SqlConnection(str);
                SqlDataAdapter sda = new SqlDataAdapter("Select * from Product1 where Pcategory='" + Cname + "'", sqlcon);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
    }
}