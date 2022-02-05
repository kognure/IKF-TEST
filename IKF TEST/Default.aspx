<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IKF_TEST._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


    

    <table align="center">
        <tr>
            <td colspan="3" align="center" class="auto-style1">
                <strong style="font-style: oblique;font-size:18px;">Employee Information</strong>
            </td>
        </tr>
        <tr>

            <td style="text-align: center">
                <br /><br />
                <asp:Label runat="server" Text="Enter Name"></asp:Label>
                <asp:TextBox runat="server" ID="txt_name" placeholder="Enter Name" ValidationGroup="add" CssClass="validate[required]"></asp:TextBox>
                <br /><br />
            </td>
        </tr>

        <tr>
            
            <td style="text-align: center">
                <asp:Label runat="server" Text="Enter DOB"></asp:Label>
              <asp:TextBox ID="txtRFPIssueDate" runat="server" Class="form-control" autocomplete="off" ValidationGroup="add" CssClass="validate[required]"></asp:TextBox>
             <cc1:CalendarExtender ID="calendarextender1" PopupButtonID="txtRFPIssueDate" runat="server" TargetControlID="txtRFPIssueDate"
            Format="dd-MMM-yyyy" Animated="true" CssClass="Calendar"></cc1:CalendarExtender>
                <br /><br />
            </td>
        </tr>
        <tr>

            <td style="text-align: center">
                 <asp:Label runat="server" Text="Enter Designation"></asp:Label>
                <asp:TextBox runat="server" ID="txt_designation" placeholder="Enter Designation" ValidationGroup="add"></asp:TextBox>
                <br /><br />
            </td>
        </tr>
        <tr>

            <td style="text-align: center">
                
                 <asp:Label runat="server" Text="Skills"></asp:Label>
                <asp:ListBox runat="server" ID="list_skills" SelectionMode="Multiple" Height="36px" Width="128px">
                    <asp:ListItem Text="C#" Value="C#" />
                    <asp:ListItem Text="Java" Value="Java" />
                    <asp:ListItem Text="Asp.Net" Value="Asp.Net" />
                    <asp:ListItem Text="Python" Value="Python" />
                    <asp:ListItem Text="Php" Value="Php" />
                </asp:ListBox>

               <br /><br />
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:Button runat="server" ID="btnAddEmployee" Text="Add" OnClick="btnAddEmployee_Click" class="button button4" ValidationGroup="add" />
                <asp:Button runat="server" ID="btnUpdate" Text="Update" class="button button4" OnClick="btnUpdate_Click" />
                <asp:Button runat="server" ID="btnReset" Text="Reset" class="button button4" OnClick="btnReset_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <br />
                <asp:Label runat="server" ID="lblMessage"></asp:Label>
                <br />
                <br />

            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="grvEmployee" runat="server" AllowPaging="true" CellPadding="2" EnableModelValidation="True"
                    ForeColor="red" GridLines="Both" ItemStyle-HorizontalAlign="center" EmptyDataText="There Is No Records In Database!" AutoGenerateColumns="false" Width="1100px"
                    HeaderStyle-ForeColor="blue" OnPageIndexChanging="grvEmployee_PageIndexChanging" OnRowCancelingEdit="grvEmployee_RowCancelingEdit" OnRowDeleting="grvEmployee_RowDeleting" OnRowEditing="grvEmployee_RowEditing">
                    <HeaderStyle CssClass="DataGridFixedHeader" />
                    <RowStyle CssClass="grid_item" />
                    <AlternatingRowStyle CssClass="grid_alternate" />
                    <FooterStyle CssClass="DataGridFixedHeader" />
                    <Columns>
                        <asp:TemplateField HeaderText="EmpId">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblEmpId" Text='<%# Eval("EmpId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FirstName">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblName" Text='<%#Eval("Name") %>'></asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DOB">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblDOB" Text='<%#Eval("DOB") %>'></asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Designation">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblDesignation" Text='<%#Eval("Designation") %>'></asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Skills">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblSkills" Text='<%#Eval("Skills") %>'></asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>

                       
                        <asp:TemplateField HeaderText="Update">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="btnEdit" Text="Edit" CommandName="Edit" ToolTip="Click here to Edit the record" />
                            </ItemTemplate>

                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="btnDelete" Text="Delete" CommandName="Delete" OnClientClick="return confirm('Are You Sure You want to Delete the Record?');" ToolTip="Click here to Delete the record" />
                                </span>  
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>
            </td>
        </tr>
    </table>

</asp:Content>
