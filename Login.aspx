<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Demo_shoppingSite.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table align="center" 
            style="height: 307px; width: 475px; background-color: #5f98f3;" >
            <tr>
                <td colspan="2" align="center">
                    <h2>Login Page</h2></td>
               

            </tr>
            <tr>
               <td align="center" colspan="2">
                   <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/user.png" />
               </td>
               </tr>
            <tr>
                <td align="center" style="width:50%">
                    <b>Email ID :</b></td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Height="39px" Width="219px" 
                        BackColor="#5F98F3" TextMode="Email"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" style="width:50%">
                    <b>Password :</b></td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Height="39px" Width="219px" 
                        BackColor="#5F98F3" TextMode="Password"></asp:TextBox><br /><br /><br />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="Button1" runat="server" Height="34px" Text="Login" 
                        Width="109px" BackColor="#5F98F3" Font-Bold="True" Font-Size="Large" 
                        onclick="Button1_Click" /><br /><br /><br />
                   </td>
                
            </tr>
        
            <tr>
            
                
            
                <td colspan="2" align="center">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/newuser.png" />
                    <asp:Label ID="Label1" runat="server" Text="New User/Kaydol:" Font-Bold="True"></asp:Label>
                    
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Register.aspx">TIKLAYINIZ</asp:HyperLink>
                    </td>
                
            </tr>
            
        </table>
    
    </div>
    </form>
</body>
</html>
