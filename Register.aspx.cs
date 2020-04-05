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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-I43AV94;Initial Catalog=Anil;Integrated Security=True");
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand("insert into Register" + "(Fname,Lname,Email,Gender,Address,Phone,Password) values(@Fname,@Lname,@Email,@Gender,@Address,@Phone,@Password)", sqlCon);
            cmd.Parameters.AddWithValue("@Fname",TextBox1.Text);
            cmd.Parameters.AddWithValue("@Lname", TextBox2.Text);
            cmd.Parameters.AddWithValue("@Email", TextBox3.Text);
            cmd.Parameters.AddWithValue("@Gender",DropDownList1.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@Address", TextBox4.Text);
            cmd.Parameters.AddWithValue("@Phone", TextBox5.Text);
            cmd.Parameters.AddWithValue("@Password", TextBox6.Text);
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            Label1.Text = "Registered Succesfully!";
        }
    }
}