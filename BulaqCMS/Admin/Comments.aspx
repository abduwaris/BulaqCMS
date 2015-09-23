<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/_Admin.Master" AutoEventWireup="true" CodeBehind="Comments.aspx.cs" Inherits="BulaqCMS.Admin.Comments" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Container" runat="server">
    <h3 class="bulaq-header">ئىنكاسلار</h3>
    <div class="bulaq-header">
        <div class="btn-group btn-group-sm">
            <a class="btn btn-<%:view=="all"?"primary":"default" %> btn-sm" href="?view=all">ھەممە (<%:allCount %>)</a>
            <a class="btn btn-<%:view=="notaproved"?"primary":"default" %> btn-sm" href="?view=notaproved">تەستىق كۈتىۋاتقان (<%:allCount-aprovedCount %>)</a>
            <a class="btn btn-<%:view=="aproved"?"primary":"default" %> btn-sm" href="?view=aproved">تەستىقلانغان (<%:aprovedCount %>)</a>
            <a class="btn btn-<%:view=="delflag"?"primary":"default" %> btn-sm" href="?view=delflag">ئەخلەت خەت قېلىنغان (<%:delFlagCount %>)</a>
            <a class="btn btn-<%:view=="recycle"?"primary":"default" %> btn-sm" href="?view=recycle">ئەخلەت (<%:recycleCount %>)</a>
        </div>
        <div class="form-inline f-left">
            <input type="text" name="name" value="" class="form-control input-sm" placeholder="تىمىسىدىن ئىزدەپ باقامسىز؟" />
            <input type="button" name="name" value="ئىزدەش" class="btn btn-primary btn-sm" />
        </div>
    </div>
    <div>
        <table class="table table-bordered">
            <thead>
                <tr>
                    <th width="200">ئاپتۇر</th>
                    <th>ئىنكاس</th>
                    <th width="200">ماس يازما</th>
                </tr>
            </thead>
            <tbody class="items-list">
                <%foreach (var com in nowComments)
                  { %>
                <tr>
                    <td>
                        <div><strong><%:com.AuthorName %></strong></div>
                        <div><a class="text-ltr" href="?<%:CreateQueryString("email",com.Email) %>"><%:com.Email %></a></div>
                        <div><a class="text-ltr" href="<%:com.Url %>"><%:com.Url %></a></div>
                    </td>
                    <td class="tools-p">
                        <i class="help-block">يوللانغان ۋاقتى: <span class="text-ltr"><%:com.WriteTime.ToString("yyyy-MM-dd HH:mm:ss") %></span></i>
                        <p>
                            <%:new HtmlString(com.Content) %>
                        </p>
                        <div class="tools">
                            <div class="btn-group">
                                <%if (!com.Approved)
                                  { %>
                                <input type="button" class="btn btn-default btn-xs" name="name" value="تەستىقلاش" />
                                <% }%>
                                <input type="button" class="btn btn-info btn-xs" name="name" value="جاۋاب" />
                                <input type="button" class="btn btn-primary btn-xs" name="name" value="تەھرىرلەش" />
                                <%if (com.DelFlag)
                                  { %>
                                <input type="button" class="btn btn-success btn-xs" name="name" value="ئەخلەت بەلگىسىنى ئېلىۋېتىش" />
                                <%}
                                  else
                                  { %>
                                <input type="button" class="btn btn-warning btn-xs" name="name" value="ئەخلەتلەش" />
                                <%}
                                  if (com.IsInRecycle)
                                  {%>
                                <input type="button" class="btn btn-success btn-xs" name="name" value="ئەسلىگە قايتۇرۇش" />
                                <%}
                                  else
                                  { %>
                                <input type="button" class="btn btn-danger btn-xs" name="name" value="ئۆچۈرۈش" />
                                <%} %>
                            </div>
                        </div>
                    </td>
                    <td><a href="?<%:CreateQueryString("postid",com.PostID) %>"><%:com.Posts.Title %></a></td>
                </tr>
                <%} %>
            </tbody>
        </table>
    </div>
    <ul class="pagination pagination-sm">
        <li <%:new HtmlString(pageIndex==1?"class=\"disabled\"":"" )%>>
            <a <%:pageIndex>1?new HtmlString(string.Format("href=\"?{0}\"", CreateQueryString("page",pageIndex-1))):new HtmlString("") %> aria-label="Previous">
                <span aria-hidden="true">&laquo;</span>
            </a>
        </li>
        <%for (int i = 1; i <= pageCount; i++)
          {%>
        <li <%:new HtmlString(pageIndex==i?"class=\"active disabled\"":"") %>><a <%:pageIndex!=i?new HtmlString(string.Format("href=\"?{0}\"",CreateQueryString("page",i))):new HtmlString("") %>><%:i %></a></li>
        <%} %>
        <li <%:new HtmlString(pageIndex==pageCount?"class=\"disabled\"":"" )%>>
            <a <%:pageIndex<pageCount?new HtmlString(string.Format("href=\"?{0}\"", CreateQueryString("page",pageIndex-1))):new HtmlString("") %> aria-label="Next">
                <span aria-hidden="true">&raquo;</span>
            </a>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BeforeBody" runat="server">
</asp:Content>
