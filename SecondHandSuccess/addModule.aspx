<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="addModule.aspx.cs" Inherits="addModule" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="tabTitle" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="heading" runat="Server">
    My Modules
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="content" runat="Server">
    <asp:ListView ID="ListView1" runat="server" DataKeyNames="moduleCode" DataSourceID="SqlDataSource1" OnItemDataBound="ListView1_ItemDataBound" >
        
        
        <EmptyDataTemplate>
            <span>No data was returned.</span>
        </EmptyDataTemplate>
        
        <ItemTemplate>
            
            <asp:Panel ID="panel" runat="server" CssClass="yes" Width="70%" >
                <span> Module Code:
            <asp:Label ID="moduleCodeLabel" runat="server" Text='<%# Eval("moduleCode") %>' />
            <br />
            Name:
            <asp:Label ID="moduleNameLabel" runat="server" Text='<%# Eval("moduleName") %>' />
            <br />
            Lecturer:
            <asp:Label ID="moduleLecturerLabel" runat="server" Text='<%# Eval("moduleLecturer") %>' />
            
</span>
            </asp:Panel>
           
        </ItemTemplate>
        
    </asp:ListView>
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Table1]"></asp:SqlDataSource>

</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="end" runat="server">
</asp:Content>
