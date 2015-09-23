<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/_Admin.Master" AutoEventWireup="true" CodeBehind="Posts.aspx.cs" Inherits="BulaqCMS.Admin.Posts" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Container" runat="server">
    <h3 class="bulaq-header">يازمىلار <a href="Editor.aspx" class="btn btn-primary btn-xs">يېڭىدىن قوشۇش</a></h3>
    <div class="bulaq-header">
        <div class="btn-group btn-group-sm">
            <a class="btn btn-primary btn-sm" href="?view=all">بارلىق يازمىلار (<%:allCount %>)</a>
            <a class="btn btn-default btn-sm" href="?view=aprove">تەستىق كۈتىۋاتقان يازمىلار (<%:notApprovedCount %>)</a>
            <a class="btn btn-default btn-sm" href="?view=delflag">ئەخلەت يازمىلار (<%:delFlagCount %>)</a>
        </div>
        <div class="form-inline f-left">
            <input type="text" name="name" value="" class="form-control input-sm" placeholder="تىمىسىدىن ئىزدەپ باقامسىز؟" />
            <input type="button" name="name" value="ئىزدەش" class="btn btn-primary btn-sm" />
        </div>
    </div>
    <div>
        <table class="table table-bordered table-hover">
            <thead>
                <tr>
                    <th>تىما</th>
                    <th width="120">ئاپتۇر</th>
                    <th width="200">سەھىپىلەر</th>
                    <th width="200">خەتكۈچلەر</th>
                    <th width="70">ئىنكاس</th>
                    <th width="180">يوللانغان ۋاقىت</th>
                </tr>
            </thead>
            <tbody class="items-list">
                <%foreach (var post in postList)
                  {%>
                <tr class="tools-p">
                    <td>
                        <a href="#"><%:post.Title %></a>
                        <div class="tools clearfix">
                            <div class="btn-group">
                                <a href="Editor.aspx?mode=edit?pid=<%:post.ID %>" class="btn btn-primary btn-xs">تەھرىرلەش</a>
                                <%if(post.Approved) {%>
                                <input type="button" class="btn btn-warning btn-xs" name="name" value="تەستىقلىماسلىق" />
                                <%}else{ %>
                                <input type="button" class="btn btn-success btn-xs" name="name" value="تەستىقلاش" />
                                <%}if (post.DelFlag)
                                  { %>
                                <input type="button" class="btn btn-danger btn-xs" name="name" value="ئەخلەتلەش" /><%}
                                  else
                                  { %>
                                <input type="button" class="btn btn-danger btn-xs" name="name" value="مەڭگۈلۈك ئۆچۈرۈش" />
                                <input type="button" class="btn btn-info btn-xs" name="name" value="ئەسلىگە قايتۇرۇش" /><%} %>
                            </div>
                        </div>
                    </td>
                    <td><a href="?<%:CreateQueryString("author",post.AuthorID) %>"><%:post.Author.DisplayName %></a></td>
                    <td>
                        <%foreach (var cat in post.Categories)
                          {%>
                        <a href="?<%:CreateQueryString("cat",cat.ID) %>"><%:cat.Title %></a>&nbsp;
                        <% } %>
                    </td>
                    <td>
                        <%foreach (var tag in post.Tags)
                          { %>
                        <a href="?<%:CreateQueryString("tag",tag.ID) %>"><%:tag.Title %></a>&nbsp;
                          <% } %>
                    </td>
                    <td><a href="Comments.aspx?postid=<%:post.ID %>" class="badge"><%:post.CommentsCount %></a></td>
                    <td><%:post.CreateTime.ToString("yyyy-MM-dd HH:mm:ss") %></td>
                </tr>
                <%}%>
            </tbody>
        </table>
    </div>
    <ul class="pagination pagination-sm">
        <li class="disabled">
            <a href="#" aria-label="Previous">
                <span aria-hidden="true">&laquo;</span>
            </a>
        </li>
        <li class="active"><a href="#">1</a></li>
        <li><a href="#">2</a></li>
        <li><a href="#">3</a></li>
        <li><a href="#">4</a></li>
        <li><a href="#">5</a></li>
        <li>
            <a href="#" aria-label="Next">
                <span aria-hidden="true">&raquo;</span>
            </a>
        </li>
    </ul>
</asp:Content>

