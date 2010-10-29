<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="ViewPage<HomeViewModel>" %>
<%@ Import Namespace="FakeVader.Core.ViewModels"%>
<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <% foreach(var post in Model.Posts) { %>
    <div class="post">
      <h2 class="title"><%=Html.Encode(post.Title)%></h2>
      <p class="date"><%=Html.Encode(post.PublishDate) %></p>
		  <div class="entry">
			  <div class="entry-btm">
			    <%=post.Text %>
			  </div>
		  </div>
		  <div class="meta">
			  <p class="links"><a href="#" class="comments">Comments (0)</a> &nbsp;&nbsp;&nbsp; <a href="#" class="permalink"><%= post.Permalink %></a></p>
		  </div>
    </div>
    <% } %>
</asp:Content>
