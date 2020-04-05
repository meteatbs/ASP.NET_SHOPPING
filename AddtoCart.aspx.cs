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
    public partial class AddtoCart : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-I43AV94;Initial Catalog=Anil;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                
                //Adding product to gridview
                Session["addproduct"] = "false";
                DataTable dt = new DataTable();
                DataRow dr;
                dt.Columns.Add("sno");
                dt.Columns.Add("pid");
                dt.Columns.Add("pname");
                dt.Columns.Add("pimage");
                dt.Columns.Add("pdesc");
                dt.Columns.Add("pprice");
                dt.Columns.Add("pquantity");
                dt.Columns.Add("pcategory");
                dt.Columns.Add("ptotalprice");

                if (Request.QueryString["id"] != null)
                {
                    if (Session["buyitems"] == null)
                    {
                        dr = dt.NewRow();
                        

                        SqlDataAdapter da = new SqlDataAdapter("select * from Product1 where ProductId=" + Request.QueryString["id"], sqlCon);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        dr["sno"] = 1;
                        dr["pid"] = ds.Tables[0].Rows[0]["ProductId"].ToString();
                        dr["pname"] = ds.Tables[0].Rows[0]["Pname"].ToString();
                        dr["pimage"] = ds.Tables[0].Rows[0]["Pimage"].ToString();
                        dr["pdesc"] = ds.Tables[0].Rows[0]["Pdesc"].ToString();
                        dr["pprice"] = ds.Tables[0].Rows[0]["Pprice"].ToString();
                        dr["pquantity"] = Request.QueryString["quantity"];
                        dr["pcategory"] = ds.Tables[0].Rows[0]["Pcategory"].ToString();

                        int price = Convert.ToInt32(ds.Tables[0].Rows[0]["pprice"].ToString());
                        int Quantity = Convert.ToInt32(Request.QueryString["quantity"].ToString());
                        int TotalPrice = price * Quantity;
                        dr["ptotalprice"] = TotalPrice;

                        dt.Rows.Add(dr);
                        sqlCon.Open();
                        SqlCommand cmd=new SqlCommand ("Insert into CartDetails values('"+dr["sno"]+"','"+dr["pid"]+"','"+dr["pname"]+"','"+dr["pdesc"]+"','"+dr["pimage"]+"','"+dr["pprice"]+"','"+dr["pquantity"]+"','"+dr["pcategory"]+"','"+Session["username"].ToString()+"')",sqlCon);
                        cmd.ExecuteNonQuery();
                        sqlCon.Close();



                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["buyitems"] = dt;
                        Button1.Enabled = true;

                        GridView1.FooterRow.Cells[6].Text = "Total Amount";
                        GridView1.FooterRow.Cells[7].Text = grandtotal().ToString();
                        Response.Redirect("AddtoCart.aspx");


                    }
                    else
                    {
                        dt = (DataTable)Session["buyitems"];
                        int sr;
                        sr = dt.Rows.Count;

                        dr = dt.NewRow();
                        SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-I43AV94;Initial Catalog=Anil;Integrated Security=True");
                        SqlDataAdapter da = new SqlDataAdapter("select * from Product1 where ProductId=" + Request.QueryString["id"], sqlCon);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        dr["sno"] = sr + 1;
                        dr["pid"] = ds.Tables[0].Rows[0]["ProductId"].ToString();
                        dr["pname"] = ds.Tables[0].Rows[0]["Pname"].ToString();
                        dr["pimage"] = ds.Tables[0].Rows[0]["Pimage"].ToString();
                        dr["pdesc"] = ds.Tables[0].Rows[0]["Pdesc"].ToString();
                        dr["pprice"] = ds.Tables[0].Rows[0]["Pprice"].ToString();
                        dr["pquantity"] = Request.QueryString["quantity"];
                        dr["pcategory"] = ds.Tables[0].Rows[0]["Pcategory"].ToString();

                        int price = Convert.ToInt32(ds.Tables[0].Rows[0]["pprice"].ToString());
                        int Quantity = Convert.ToInt32(Request.QueryString["quantity"].ToString());
                        int TotalPrice = price * Quantity;
                        dr["ptotalprice"] = TotalPrice;

                        dt.Rows.Add(dr);

                        sqlCon.Open();
                        SqlCommand cmd = new SqlCommand("Insert into CartDetails values('" + dr["sno"] + "','" + dr["pid"] + "','" + dr["pname"] + "','" + dr["pdesc"] + "','" + dr["pimage"] + "','" + dr["pprice"] + "','" + dr["pquantity"] + "','" + dr["pcategory"] + "','" + Session["username"].ToString() + "')", sqlCon);
                        cmd.ExecuteNonQuery();
                        sqlCon.Close();

                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        Session["buyitems"] = dt;
                        Button1.Enabled = true;

                        GridView1.FooterRow.Cells[6].Text = "Total Amount";
                        GridView1.FooterRow.Cells[7].Text = grandtotal().ToString();
                        Response.Redirect("AddtoCart.aspx");
                    }
                }
                else
                {
                    dt = (DataTable)Session["buyitems"];
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    if (GridView1.Rows.Count > 0)
                    {
                        GridView1.FooterRow.Cells[6].Text = "Total Amount";
                        GridView1.FooterRow.Cells[7].Text = grandtotal().ToString();
                    }
                }

            }
            string OrderDate = DateTime.Now.ToShortDateString();
            Session["Orderdate"] = OrderDate;
            orderid();
        }

            //Calculating Final Price satır sayısı kadar priceları topla
            public int grandtotal(){
            DataTable dt=new DataTable ();
                dt=(DataTable)Session["buyitems"];
                int nrow=dt.Rows.Count;
                int i=0;
                int totalprice=0;
                while (i<nrow){
                totalprice=totalprice+Convert.ToInt32(dt.Rows[i]["ptotalprice"].ToString());
                    i=i+1;
                }
                return totalprice;
            }
            // 3.Generating Unique Order Id.
        public void orderid()
        {
            String alpha ="abCdefghIjklmNopqrStuvwXyz123456789";
            Random r=new Random ();
            char[] myArray=new char[5];
            for (int i = 0; i < 5; i++)
			{
			 myArray[i]=alpha[(int)(35*r.NextDouble())];
			}
            String orderid;
            orderid ="Order_Id:"+ DateTime.Now.Hour.ToString()+DateTime.Now.ToString()+DateTime.Now.ToString()
                +DateTime.Now.Month.ToString()+DateTime.Now.Year.ToString()+new string(myArray)+DateTime.Now.Minute.ToString()
                +DateTime.Now.Second.ToString();
            Session["Orderid"]=orderid;

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["buyitems"];

            for (int i = 0; i<=dt.Rows.Count-1 ; i++)
            {
                int sr;
                int sr1;
                string qdata;
                string dtdata;
                sr=Convert.ToInt32(dt.Rows[i]["sno"].ToString());
                TableCell cell=GridView1.Rows[e.RowIndex].Cells[0];
                qdata=cell.Text;
                dtdata=sr.ToString();
                sr1=Convert.ToInt32(qdata);
                TableCell prID = GridView1.Rows[e.RowIndex].Cells[1];

                if (sr==sr1)
	{
		 
                    dt.Rows[i].Delete();
                    dt.AcceptChanges();
                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("DELETE top (1) from CartDetails where ProductId='" + prID.Text + "'and Email='" + Session["username"] + "'", sqlCon);
                    cmd.ExecuteNonQuery();
                    sqlCon.Close();
                    //Item has been deleted from shopping cart
                    break;

	}
            }
            //5. Setting sNo. after deleting row item from cart for other cells
            for (int i = 0; i <=dt.Rows.Count; i++)
            {
                dt.Rows[i - 1]["sno"] = i;
                dt.AcceptChanges();
            }
            Session["buyitems"] = dt;
            Response.Redirect("AddtoCart.aspx");

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["buyitems"];
            for (int i = 0; i <=dt.Rows.Count-1 ; i++)
            {
                SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-I43AV94;Initial Catalog=Anil;Integrated Security=True");
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("insert into OrderDetails(orderid,sno,productid,productname,price,quantity,orderdate,status) values('" + Session["Orderid"] + "',"
                    + dt.Rows[i]["sno"] + "," + dt.Rows[i]["pid"] + ",'" + dt.Rows[i]["pname"] + "'," + dt.Rows[i]["pprice"] + "," + dt.Rows[i]["pquantity"] +
                ",'" + Session["Orderdate"] + "','Pending')", sqlCon);

                cmd.ExecuteNonQuery();
                sqlCon.Close();
                
            }
            //If Session is Null Redirecting to login else Placing the order
            if (Session["username"]==null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (GridView1.Rows.Count.ToString()=="0")
                {
                    Response.Write("<script>alert('Your cart is empty. you cannot place an order');</script>");
                }
                else
                {
                    Response.Redirect("PlaceOrder.aspx");
                }
            }
        }
        public void clearCart() {
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand("Delete from CartDetails where Email='" + Session["username"] + "'", sqlCon);
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            Response.Redirect("AddtoCart.aspx");
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["buyitems"] = null;
            clearCart();
        }
    }
}