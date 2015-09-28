<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/_Admin.Master" AutoEventWireup="true" CodeBehind="Links.aspx.cs" Inherits="BulaqCMS.Admin.Links" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Container" runat="server">
    <h3 class="bulaq-header">ئۇلانمىلار  <a href="link_editor.aspx?mode=new" class="btn btn-primary btn-xs">يېڭىدىن قوشۇش</a></h3>
    <div class="bulaq-header">
        <div class="form-inline">
            <div class="form-group">
                <select class="form-control input-sm" id="filter-group">
                    <option value="">سەھىپىسىنى تاللاڭ</option>
                    <%foreach (var group in linkGroups)
                      {%>
                    <option <%:Html(filter!=null && linkInGuids[filter]==group?"selected=\"selected\"":"") %> value="<%:linkInGuids.Count(p=>p.Value==group)>0?linkInGuids.First(p=>p.Value==group).Key:" " %>"><%:group %></option>
                    <%} %>
                </select>
                <input type="button" id="filter-btn" value="سۈزۈش" class="btn btn-sm btn-primary" />
            </div>
            <div class="f-left">
                <input type="text" name="name" value="" class="form-control input-sm" placeholder="ئۇلانما سەھىپىسىنى ئىزدەپ بېقىڭ" />
                <input type="button" name="name" value="ئىزدەش" class="btn btn-primary btn-sm" />
            </div>
        </div>

    </div>
    <div>
        <table class="table table-hover table-striped table-bordered">
            <thead>
                <tr>
                    <th width="360">ئۇلانما نامى</th>
                    <th width="180">ئۇلانما سەھىپىسى</th>
                    <th>ئادرىسى</th>
                    <th>چۈشەندۈرۈلۈشى</th>
                    <th width="80">كۆرۈنۈش</th>
                </tr>
            </thead>
            <tbody class="items-list">
                <%foreach (var link in allLinks)
                  {%>
                <tr class="tools-p">
                    <td><%:link.Title %>
                        <div class="tools">
                            <div class="btn-group">
                                <a href="link_editor.aspx?mode=edit&linkid=<%:link.ID %>" class="btn btn-primary btn-xs">تەھرىرلەش</a>
                                <%--<input type="button" name="name" value="تىز تەھرىرلەش" class="btn btn-info btn-xs" />--%>
                                <input type="button" name="name" value="ئۆچۈرۈش" class="btn btn-danger btn-xs" onclick="_deleteLink(<%:link.ID%>);" />
                                <%--<input type="button" name="name" value="كۆرۈش" class="btn btn-default btn-xs" />--%>
                            </div>
                        </div>

                    </td>
                    <td>
                        <span><a href="?group=<%:linkInGuids.Count(p=>p.Value==link.Name)>0?linkInGuids.FirstOrDefault(p=>p.Value==link.Name).Key:"" %>"><%:link.Name %></a></span>
                    </td>
                    <td>
                        <a class="text-ltr" href="<%:link.Url %>"><%:link.Url %></a>
                    </td>
                    <td><%:link.Des %>
                       
                    </td>
                    <td><a href="#" class="badge"><%:link.Visible?"ئاشكارا":"يۇشۇرۇن" %></a></td>
                </tr>
                <%} %>
            </tbody>
        </table>
    </div>

    <p class="help-block">
        ئۇلانمىنى ئۆچۈرسىڭىز ئۇلانمىدىن تارتىپ ئىشلەتكەن تىزىملىكلەر ئىشلىمەسلىكى ھەم كۆرۈنمەسلىكى مۇمكىن. ئالاھىدە باغلىنىشى بولمىسىمۇ بىراق ئۇلانمىدىن تارتىپ ئىشلەتكەن ئەمەسمۇ.
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BeforeBody" runat="server">
    <script>
        $('#filter-btn').click(function () {
            window.location.href = '?group=' + $('#filter-group').val();
        })
        var msgs = {
            'on_delete_error':'ئۇلانمىنى ئۆچۈرۈشتە خاتالىق كۆرۈلدى!',
            'link_null':'ئۇلانما مەۋجۇت ئەمەس!'
        };
        //删除
        function _deleteLink(linkId) {
            if(!linkId||typeof(linkId)!='number'|| linkId<=0) return;
            $.post('link_editor.aspx',{"Mode":'delete',"LinkID":linkid},function (d) {
                if(d.result=='ok') alertTip('ئۆزگەرتىشلەر ساقلاندى!',function(){window.location.reload()});
                else alertTip(msgs[d['error']],'danger');
            },'json').error(function(){alertTip('مۇلازىمىتىردا خاتالىق كۆرۈلدى!','danger')});
        }
    </script>
    
</asp:Content>
