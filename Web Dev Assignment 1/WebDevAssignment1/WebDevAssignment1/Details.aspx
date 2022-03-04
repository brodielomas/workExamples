<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="WebDevAssignment1.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPBody" runat="server">
    <div class="row">
        <div class="col-10 offset-1">
            <asp:Repeater ID="Repeater2" runat="server" DataSourceID="DetailSource">
                <ItemTemplate>
                    <div class="row" style="margin-top: 50px">
                        <div class="col-4">
                            <img src="<%# Eval("image") %>" alt="<%# Eval("title") %>" class="fullImage" /></img>
                        </div>
                        <div class="col-6">
                            <div class="row"> 
                                <div class="col-8">
                                    <p class="titleDetail"><%# Eval("item_ID")%>. <%# Eval("title") %></p>
                                </div>
                                <div class="col-4">
                                    <p class="timeNeeded">Time needed: <%# Eval("timeCommitment") %></p>
                                </div>
                            </div>
                            <div class="row">
                                <p class="longDesc"><%# Eval("longDesc") %></p>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <asp:SqlDataSource ID="DetailSource" runat="server" ConnectionString="<%$ ConnectionStrings:ThingsDB1ConnectionString %>" 
            SelectCommand="SELECT [item_ID], [title], [timeCommitment], [image], [longDesc] FROM [Things]"></asp:SqlDataSource>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPScript" runat="server">
</asp:Content>
