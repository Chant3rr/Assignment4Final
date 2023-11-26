<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Administrator.aspx.cs" Inherits="Assignment4Final.AdministratorInfo.Administrator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td style="height: 21px">Hello   ,
                <asp:Label ID="adminLabel" runat="server"></asp:Label>
            </td>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="adminMemberGridView" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">
                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                    <Columns>
                        <asp:CheckBoxField />
                    </Columns>
                    <FooterStyle BackColor="Tan" />
                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                    <SortedAscendingCellStyle BackColor="#FAFAE7" />
                    <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                    <SortedDescendingCellStyle BackColor="#E1DB9C" />
                    <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                </asp:GridView>
                <asp:GridView ID="adminInstructorGridView" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">
                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                    <Columns>
                        <asp:CheckBoxField />
                    </Columns>
                    <FooterStyle BackColor="Tan" />
                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                    <SortedAscendingCellStyle BackColor="#FAFAE7" />
                    <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                    <SortedDescendingCellStyle BackColor="#E1DB9C" />
                    <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                </asp:GridView>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>MemberFirst&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; MemberLast&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; MemberPhone#&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; MemberEmail</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="memberFirstText" runat="server"></asp:TextBox>
                <asp:TextBox ID="memberLastText" runat="server"></asp:TextBox>
                <asp:TextBox ID="memberPhoneText" runat="server"></asp:TextBox>
                <asp:TextBox ID="memberEmailText" runat="server"></asp:TextBox>
                <asp:Button ID="addMemberButton" runat="server" Text="Add New Member" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="deleteMemberButton" runat="server" Text="Delete Selected Member" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <br />InstructorFirst&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; InstructorLast&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; InstructorPhone#</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="instructorFirstText" runat="server"></asp:TextBox>
                <asp:TextBox ID="instructorLastText" runat="server"></asp:TextBox>
                <asp:TextBox ID="instructorPhoneText" runat="server"></asp:TextBox>
                <asp:Button ID="addInstructorButton" runat="server" Text="Add New Instructor" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="deleteInstructorButton" runat="server" Text="Delete Selected Instructor" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <br />SectionName&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SectionStartDate&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; InstructorID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; MemberID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SectionFee</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="sectionNameText" runat="server"></asp:TextBox>
                <asp:TextBox ID="sectionDateText" runat="server"></asp:TextBox>
                <asp:TextBox ID="sectionInstructorText" runat="server"></asp:TextBox>
                <asp:TextBox ID="sectionMemberText" runat="server"></asp:TextBox>
                <asp:TextBox ID="sectionFeeText" runat="server"></asp:TextBox>
                <asp:Button ID="addSectionButton" runat="server" Text="Add New Section" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
