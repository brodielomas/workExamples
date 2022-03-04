<%@ Page Title="WebFormTraditional" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebDevAssignment1.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPBody" runat="server">
    <div class="row">
        <div class="col-10 offset-1">
            <h2 class="text-center mainHeading"><br>Fun Things To Do In Quarantine!<br/></h2>
            <h3 class="text-center underHeading">Traditional Web Form</h3>
            <div class="row">
                <asp:Repeater ID="RThings" runat="server" DataSourceID="SDSThings1">
                    <ItemTemplate>
                        <div class="col-3" style="margin-top: 50px;">
                            <p class="titleMain text-center"><%# Eval("item_ID") %>. 
                                <a href="Details.aspx" target="_blank" class="linkGreen"><%# Eval("title") %></a></p>
                            <img src="<%# Eval("image") %>" alt="<%# Eval("title") %>" class="thumbnail"></img>
                            <p class="shortDesc text-center"><%# Eval("shortDesc") %></p>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate></FooterTemplate>
                </asp:Repeater>
            </div>

            <asp:SqlDataSource ID="SDSThings1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ThingsDB1ConnectionString %>" 
                SelectCommand="SELECT [title], [image], [shortDesc], [item_ID] FROM [Things] ORDER BY [item_ID]"></asp:SqlDataSource>
            
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPScript" runat="server">
</asp:Content>
