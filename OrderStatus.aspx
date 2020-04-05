<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="OrderStatus.aspx.cs" Inherits="Demo_shoppingSite.OrderStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center" class="navbar" style="height:auto">
<div align="right">
    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Show All Order List</asp:LinkButton>
    &nbsp;
    </div>
    <b>Select Date:</b>
    <asp:TextBox ID="TextBox1" runat="server" Font-Bold="True" Width="122px"></asp:TextBox>
    <asp:ImageButton ID="ImageButton1" runat="server" Height="30px" 
        ImageUrl="~/Images/calendaricon.png" onclick="ImageButton1_Click" />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Year:" Font-Bold="True"></asp:Label>&nbsp;
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
        onselectedindexchanged="DropDownList1_SelectedIndexChanged">
    </asp:DropDownList>&nbsp;
    <asp:Label ID="Label2" runat="server" Text="Month:" Font-Bold="True"></asp:Label>&nbsp;
    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
        onselectedindexchanged="DropDownList2_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    
    <asp:Calendar ID="Calendar2" runat="server" 
        onselectionchanged="Calendar2_SelectionChanged" BackColor="White" 
        BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" 
        Font-Size="9pt" ForeColor="Black" Height="250px" NextPrevFormat="ShortMonth" 
        Width="330px">
        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" 
            Height="8pt" />
        <DayStyle BackColor="#CCCCCC" />
        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
        <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" 
            Font-Size="12pt" ForeColor="White" Height="12pt" />
        <TodayDayStyle BackColor="#999999" ForeColor="White" />
    </asp:Calendar>
    <asp:Button ID="Button1" runat="server" Text="Click" CssClass="button" 
        Font-Bold="True" Height="39px" Width="72px" onclick="Button1_Click" />
    <br />
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    <br />
    <asp:GridView ID="GridView1" runat="server" 
        onrowdatabound="GridView1_RowDataBound" CellPadding="4" 
        ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField HeaderText="Order Status">
                <ItemTemplate>
                    <asp:RadioButton ID="RadioButton1" runat="server" Checked="True" 
                        GroupName="Ostatus" Text="Pending" />
                    &nbsp;<asp:RadioButton ID="RadioButton2" runat="server" GroupName="Ostatus" 
                        Text="Completed" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>
    <br />
    <asp:Button ID="Button2" runat="server" Text="Update Status" Font-Bold="True" 
        Height="37px" Width="136px" CssClass="button" onclick="Button2_Click" />
    <br /><br />
    </div>
</asp:Content>
