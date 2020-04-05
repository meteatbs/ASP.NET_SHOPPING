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
    public partial class PlaceOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-I43AV94;Initial Catalog=Anil;Integrated Security=True");
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand("Insert into CardDetailss" + "(Fname,Lname,CardNo,ExpiryDate,CVV,BillingAddr) values (@Fname,@Lname,@CardNo,@ExpiryDate,@CVV,@BillingAddr)",sqlCon);
            cmd.Parameters.AddWithValue("@Fname",TextBox1.Text);
            cmd.Parameters.AddWithValue("@Lname",TextBox2.Text);
            cmd.Parameters.AddWithValue("@CardNo",TextBox3.Text);
            cmd.Parameters.AddWithValue("@ExpiryDate",TextBox4.Text);
            cmd.Parameters.AddWithValue("@CVV",TextBox5.Text);
            cmd.Parameters.AddWithValue("@BillingAddr",TextBox6.Text);

            cmd.ExecuteNonQuery();
            sqlCon.Close();
            Session["address"] = TextBox6.Text;
            Response.Redirect("Pdf_generate.aspx");
            Response.Redirect("<script>alert('Payment Made Succesfull');</script>");
           
            
        }
    }
}