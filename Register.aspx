<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Demo_shoppingSite.Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
       
   
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table align="center" 
            style="width: 750px; height: 600px; background-color: #5f98f3; margin-bottom: 162px;" >
            <tr>
                <td colspan="2" align="center">
                    <h2>Registration Page</h2></td>
                
            </tr>
            <tr>
                <td style="width:50%">
                   <b>First Name:</b></td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Height="39px" Width="252px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="TextBox1" ErrorMessage="First Name is Empty" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="TextBox1" ErrorMessage="Only Characters is required" 
                        ForeColor="Red" ValidationExpression="^[A-Za-z]*$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="width:50%">
                    Last<b> Name</b> :</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Height="39px" Width="252px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="TextBox2" ErrorMessage="Last Name is empty" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ControlToValidate="TextBox2" ErrorMessage="Only Characters is required" 
                        ForeColor="Red" ValidationExpression="^[A-Za-z]*$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="width:50%">
                  <b>Email_ID :</b> </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Height="39px" Width="252px" 
                        TextMode="Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="TextBox3" ErrorMessage="Email ID is empty" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width:50%">
                    Gender :</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="47px" Width="251px">
                        <asp:ListItem>Select Gender</asp:ListItem>
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                        <asp:ListItem>Other</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="DropDownList1" ErrorMessage="Gender is Empty" 
                        ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width:50%">
                    Address : </td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server" Height="39px" Width="252px" 
                        TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="TextBox4" ErrorMessage="Address is Empty" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width:50%">
                    Phone Number : </td>
                <td>
                    <asp:TextBox ID="TextBox5" runat="server" Height="39px" Width="252px" 
                        TextMode="Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="TextBox5" ErrorMessage="Phone Number is Empty" 
                        ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                        ControlToValidate="TextBox5" ErrorMessage="Invalid Phone Number" 
                        ForeColor="Red" ValidationExpression="^(0|[1-9]\d*)$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="width:50%">
                    Password : </td>
                <td>
                    <asp:TextBox ID="TextBox6" runat="server" Height="39px" Width="252px" 
                        TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ControlToValidate="TextBox6" ErrorMessage="Password is Empty" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width:50%">
                   <b>Confirm Password :</b> </td>
                <td>
                    <asp:TextBox ID="TextBox7" runat="server" Height="39px" Width="252px" 
                        TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                        ControlToValidate="TextBox7" ErrorMessage="Confir Password is Empty" 
                        ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" 
                        ControlToCompare="TextBox6" ControlToValidate="TextBox7" 
                        ErrorMessage="Password is not match" ForeColor="Red"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="Button1" runat="server" Text="Register" Font-Bold="True" 
                        Font-Size="Large" Height="56px" Width="162px" onclick="Button1_Click" />
                </td>
                <tr>
                <td colspan="2">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                </td>
                </tr>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </td>
                
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
