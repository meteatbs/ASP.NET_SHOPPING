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
     
    public partial class OrderStatus : System.Web.UI.Page
    {
        string str = "Data Source=DESKTOP-I43AV94;Initial Catalog=Anil;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
	{
		 if (Session["admin"]==null)
	{
		 Response.Redirect("Login.aspx");
	}
                TextBox1.Visible=false;
                Label1.Visible=false;
                Label2.Visible=false;
                DropDownList1.Visible=false;
                DropDownList2.Visible=false;
                Calendar2.Visible=false;
                Button2.Visible=false;

                DataSet year = new DataSet();
                year.ReadXml(Server.MapPath("~/Year.xml"));
                DropDownList2.DataTextField = "Number";
                DropDownList2.DataValueField = "Number";
                DropDownList2.DataSource = year;
                DropDownList2.DataBind();

                DataSet month = new DataSet();
                month.ReadXml(Server.MapPath("~/Month.xml"));
                DropDownList2.DataTextField = "Name";
                DropDownList2.DataValueField = "Number";
                DropDownList2.DataSource = month;
                DropDownList2.DataBind();



	}
           
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int year = int.Parse(DropDownList1.SelectedValue);
            int month = int.Parse(DropDownList2.SelectedValue);


            Calendar2.VisibleDate = new DateTime(year, month, 1);
            Calendar2.SelectedDate = new DateTime(year, month, 1);
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int year = int.Parse(DropDownList1.SelectedValue);
            int month = int.Parse(DropDownList2.SelectedValue);

            Calendar2.VisibleDate = new DateTime(year, month, 1);
            Calendar2.SelectedDate = new DateTime(year, month, 1);
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar2.Visible)
            {
                Label1.Visible = false;
                Label2.Visible = false;
                DropDownList1.Visible = false;
                DropDownList2.Visible = false;
            }
            else
            {
                TextBox1.Visible = true;
                Label1.Visible = true;
                Label2.Visible = true;
                DropDownList1.Visible = true;
                DropDownList2.Visible = true;
                Calendar2.Visible = true;
            }
            Button2.Visible = false;
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            TextBox1.Text = Calendar2.SelectedDate.ToShortDateString();
            Label1.Visible = false;
            Label2.Visible = false;
            DropDownList1.Visible = false;
            DropDownList2.Visible = false;
            Calendar2.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text=="")
            {
                lblError.Text = "Please Select Date";
            }
            else
            {
                SqlConnection sqlCon = new SqlConnection(str);
                sqlCon.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select orderid as OrderId,productname as ProductName,price as Price,quantity as Quantity,orderdate as OrderedDate from OrderDetails where orderdate='"+TextBox1.Text+"' and status='Pending'", sqlCon);
                DataSet ds = new DataSet();
                sda.Fill(ds, "OrderDetails");
                if (ds.Tables[0].Rows.Count==0)
                {
                     lblError.Text = "No record to display";
                }
                else
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    GridView1.Columns[0].Visible = true;
                    Button2.Visible = true;
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                string orderId = row.Cells[1].Text;
                RadioButton rb1 = (row.Cells[0].FindControl("RadioButton1") as RadioButton);
                RadioButton rb2 = (row.Cells[0].FindControl("RadioButton2") as RadioButton);
                string status;
                if (rb1.Checked)
                {
                    status = rb1.Text;
                }
                else
                {
                    status = rb2.Text;
                }
                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE OrderDetails SET status=@a where orderid=@b", con);
                cmd.Parameters.AddWithValue("@a", status);
                cmd.Parameters.AddWithValue("@b", orderId);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            lblError.Text = "Status updated succesfully";
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(str);
            sqlCon.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select orderid as OrderId,productname as ProductName,price as Price,quantity as Quantity,orderdate as OrderedDate,status as Status from OrderDetails", sqlCon);
            DataSet ds=new DataSet ();
            sda.Fill(ds,"OrderDetails");
            GridView1.DataSource=ds;
            GridView1.DataBind();
            GridView1.Columns[0].Visible=false;
            Button2.Visible=false;
        }
    }
}