<%@ Page Title="WebFormModelBinding" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebDevAssignment1.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPBody" runat="server">
    <div class="row">
        <div class="col-10 offset-1">
            <h2 class="text-center mainHeading"><br>Fun Things To Do In Quarantine!<br/></h2>
            <h3 class="text-center underHeading">Model Binding Web Form</h3>
            <div class="row">
                <asp:Repeater ID="RThings2" runat="server" ItemType="WebDevAssignment1.Models.Thing" SelectMethod="RThings2_GetData">
                    <ItemTemplate>
                        <div class="col-3 " style="margin-top: 50px;">
                            <p class="titleMain text-center"><%# Item.item_ID %>. 
                                <a href="Details.aspx" target="_blank" class="linkGreen"><%# Item.title %></a></p>
                            <img src="<%# Item.image %>" alt="<%# Item.title %>" class="thumbnail"></img>
                            <p class="shortDesc text-center"><%# Item.shortDesc %></p>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate></FooterTemplate>
                </asp:Repeater>
            </div>
         </div>
      </div>

    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPScript" runat="server">
</asp:Content>
