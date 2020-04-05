<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pdf_generate.aspx.cs" Inherits="Demo_shoppingSite.Pdf_generate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="Download Invoice" 
            BackColor="Silver" Font-Bold="True" Font-Size="X-Large" Height="49px" 
            onclick="Button1_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" 
            Font-Size="X-Large" NavigateUrl="~/Default.aspx">Go to Home Page</asp:HyperLink>
        <asp:Panel ID="Panel1" runat="server">
        <table border="1">
        <tr>
        <td style="text-align:center">
        <h2 style="text-align:center">Retail Invoice</h2>
        </td>
        </tr>
         <tr>
        <td>
        Order No:
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br /><br />
        Order Date:
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>

        </td>
        </tr>
         <tr>
        <td>
        <table>
        <tr>
        <td>
        Buyer Address:<br />
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        </td>
        <td>
        Seller Adress:<br /><br />
        C.P Talao,Rd No.27, Behind sion garage,thane,maharasthra..
        </td>
        </tr>
        </table>
        </td>
        </tr>
         <tr>
        <td>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                Width="1000px">
                <Columns>
                    <asp:BoundField DataField="sno" HeaderText="SNo">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="productid" HeaderText="ProductId">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="productname" HeaderText="Product Name">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="quantity" HeaderText="Quantity">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="price" HeaderText="Price">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="totalprice" HeaderText="Total Price">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </td>
        </tr>
         <tr>
        <td>
        Grand Total:
            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        </td>
        </tr>
         <tr>
        <td align="center">
        This is a computer generated invoicce and doesn't required as signature
        </td>
        </tr>
        </table>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
