<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add_Product.aspx.cs" Inherits="Demo_shoppingSite.Add_Product" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   
<div class="navbar" style="border-width:3px;border-color:#333333;height:auto">
<table style="width:700px; height:390px;background-color:#5f98f3;" align="center">
<tr>
<td align="center" width="50%" colspan="2">
<h1>Adding Product</h1><hr />
</td>

</tr>

<tr>
<td align="center" width="50%"><h3>Category:</h3>
</td>
<td width="50%">
    <asp:DropDownList ID="DropDownList1" runat="server" 
        DataSourceID="SqlDataSource1" DataTextField="CategoryName" 
        DataValueField="CategoryName">
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ErrorMessage="Category is Mandatory" ControlToValidate="DropDownList1" 
        Display="Dynamic" InitialValue="Select" ForeColor="Red">*</asp:RequiredFieldValidator>
</td>
</tr>



<tr>
<td align="center" width="50%">
<h3>Product Name:</h3>
</td>
<td  width="50%">
<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="txtName" Display="Dynamic" 
        ErrorMessage="Product Name is Mandatory" ForeColor="Red">*</asp:RequiredFieldValidator>
</td>
</tr>

<tr>
<td align="center" width="50%"><h3>Product Desc:</h3>
</td>
<td  width="50%">
<asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ControlToValidate="txtDesc" Display="Dynamic" 
        ErrorMessage="Product Desc is Mandatory" ForeColor="Red">*</asp:RequiredFieldValidator>
</td>
</tr>

<tr>
<td align="center" width="50%"><h3>Image:</h3>
</td>
<td  width="50%">
    <asp:FileUpload ID="imageUpload" runat="server" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
        ErrorMessage="Image is Mandatory" ControlToValidate="imageUpload" 
        Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator></td>
</tr>



<tr>
<td align="center" width="50%"><h3>Product Price:</h3>
</td>
<td  width="50%">
<asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
        ErrorMessage="Price is Mandatory" ControlToValidate="txtPrice" 
        Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ErrorMessage="Price is invalid" ControlToValidate="txtPrice" ForeColor="Red" 
        ValidationExpression="[0-9]*">*</asp:RegularExpressionValidator>
</td>
</tr>

<tr>
<td align="center" width="50%"><h3>Product Quantity:</h3>
</td>
<td  width="50%">
<asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
        ErrorMessage="Quantity is Mandatory" ControlToValidate="txtQuantity" 
        Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
        ErrorMessage="Quantity is Invalid" ControlToValidate="txtQuantity" 
        Display="Dynamic" ForeColor="Red" ValidationExpression="[0-9]*">*</asp:RegularExpressionValidator>
</td>
</tr>

<tr>
<td align="center" width="50%" colspan="2">
    <asp:Button ID="btnSubmit" runat="server" Text="Add" Font-Bold="True" 
        ForeColor="Black" Height="36px" onclick="Button1_Click" Width="88px" />
        <br />
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
</td>

</tr>

  <tr>
  <td align="center" colspan="2">
      <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" 
          HeaderText="Fix the following Error" />
  </td>
  </tr>
<tr>
<td>
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>

</tr>
</table>
</div>
<div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AnilConnectionString %>" 
        SelectCommand="SELECT * FROM [Category]"></asp:SqlDataSource>
</div>
    </form>
</body>
</html>
