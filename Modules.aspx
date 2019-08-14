<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Modules.aspx.cs" Inherits="Modules" %>
<asp:Content ID="Content1" ContentPlaceHolderID="tabTitle" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="heading" runat="Server">
    <link href="SecondHandSuccess/moduleStyle.css" rel="stylesheet" type="text/css" />

    My Modules
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="content" runat="Server">
    <asp:ListView ID="tableModule" runat="server" DataKeyNames="moduleCode" DataSourceID="SqlDataSource1" OnItemDataBound="ListView1_ItemDataBound">
        <EditItemTemplate>
            <span style="">moduleCode:
            <asp:Label ID="moduleCodeLabel1" runat="server" Text='<%# Eval("moduleCode") %>' />
            <br />
            moduleName:
            <asp:TextBox ID="moduleNameTextBox" runat="server" Text='<%# Bind("moduleName") %>' />
            <br />
            moduleLecturer:
            <asp:TextBox ID="moduleLecturerTextBox" runat="server" Text='<%# Bind("moduleLecturer") %>' />
            <br />
            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
            <br /><br /></span>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <span>No data was returned.</span>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <span style="">moduleCode:
            <asp:TextBox ID="moduleCodeTextBox" runat="server" Text='<%# Bind("moduleCode") %>' />
            <br />moduleName:
            <asp:TextBox ID="moduleNameTextBox" runat="server" Text='<%# Bind("moduleName") %>' />
            <br />moduleLecturer:
            <asp:TextBox ID="moduleLecturerTextBox" runat="server" Text='<%# Bind("moduleLecturer") %>' />
            <br />
            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
            <br /><br /></span>
        </InsertItemTemplate>
        <ItemTemplate>
            <asp:Panel ID="panelModule" runat="server" CssClass="classPanelModule" Width="70%">
                <div id ="innerLeftModule" runat="server" class="LeftModule">
                     <span style="">Module Code:
            <asp:Label ID="moduleCodeLabel" runat="server" Text='<%# Eval("moduleCode") %>' />
            <br />
            Name:
            <asp:Label ID="moduleNameLabel" runat="server" Text='<%# Eval("moduleName") %>' />
            <br />
           Lecturer:
            <asp:Label ID="moduleLecturerLabel" runat="server" Text='<%# Eval("moduleLecturer") %>' />
           <br />
                         <br />
                         <br />
                </div>
                <div id="innerRightModule" runat="server" class="classRightModule">
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                </div>   
            </asp:Panel>
            
<br /><br /></span>
        </ItemTemplate>
        <LayoutTemplate>
            <div id="itemPlaceholderContainer" runat="server" style="">
                <span runat="server" id="itemPlaceholder" />
            </div>
            <div style="">
            </div>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <span style="">moduleCode:
            <asp:Label ID="moduleCodeLabel" runat="server" Text='<%# Eval("moduleCode") %>' />
            <br />
            moduleName:
            <asp:Label ID="moduleNameLabel" runat="server" Text='<%# Eval("moduleName") %>' />
            <br />
            moduleLecturer:
            <asp:Label ID="moduleLecturerLabel" runat="server" Text='<%# Eval("moduleLecturer") %>' />
            <br />
            <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
<br /><br /></span>
        </SelectedItemTemplate>
    </asp:ListView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:SecondHandSuccessConnectionString %>" DeleteCommand="DELETE FROM [MODULE] WHERE [moduleCode] = @original_moduleCode AND [moduleName] = @original_moduleName AND [moduleLecturer] = @original_moduleLecturer" InsertCommand="INSERT INTO [MODULE] ([moduleCode], [moduleName], [moduleLecturer]) VALUES (@moduleCode, @moduleName, @moduleLecturer)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [MODULE]" UpdateCommand="UPDATE [MODULE] SET [moduleName] = @moduleName, [moduleLecturer] = @moduleLecturer WHERE [moduleCode] = @original_moduleCode AND [moduleName] = @original_moduleName AND [moduleLecturer] = @original_moduleLecturer">
        <DeleteParameters>
            <asp:Parameter Name="original_moduleCode" Type="String" />
            <asp:Parameter Name="original_moduleName" Type="String" />
            <asp:Parameter Name="original_moduleLecturer" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="moduleCode" Type="String" />
            <asp:Parameter Name="moduleName" Type="String" />
            <asp:Parameter Name="moduleLecturer" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="moduleName" Type="String" />
            <asp:Parameter Name="moduleLecturer" Type="String" />
            <asp:Parameter Name="original_moduleCode" Type="String" />
            <asp:Parameter Name="original_moduleName" Type="String" />
            <asp:Parameter Name="original_moduleLecturer" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
        
        

</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="end" runat="server">
</asp:Content>


