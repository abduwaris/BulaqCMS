<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/_Admin.Master" AutoEventWireup="true" CodeBehind="Tags.aspx.cs" Inherits="BulaqCMS.Admin.Tags" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Container" runat="server">
    <h3 class="bulaq-header">خەتكۈچلەر</h3>
    <div class="row">
        <div class="col-sm-4">
            <p><strong><%:isEdit?"خەتكۈچ تەھرىرلەش":"يېڭىدىن خەتكۈچ قوشۇش" %></strong></p>
            <i class="help-block">خەتكۈچنىڭ سەھىپىدىن پەرقى شۇكى خەتكۈچلەرگە ئۇسلۇب تاللىغىلى بولمايدۇ، ھەم خەتكۈچ قاتلاملىق مۇناسىۋەتكە ئىگە ئەمەس.</i>
            <form id="frm-tags-edit">
                <div class="form-group">
                    <label>نامى</label>
                    <input type="text" class="form-control input-sm" placeholder="نامى" name="Title" value="<%:updateTag.Title??"" %>">
                    <i class="help-block">تور بېتىڭىزدە مۇشۇ نامدا كۆرسىتىلىدىغان بۇلۇپ يەككىلىككە ئىگە ئەمەس. ھەرقانداق ھەرىپ بەلگىلەرنى قوللايدۇ.</i>
                </div>
                <div class="form-group">
                    <label>خەتكۈچ باشقا نامى</label>
                    <input type="text" class="form-control input-sm text-ltr" placeholder="خەتكۈچ باشقا نامى" name="Name" value="<%:updateTag.Name %>">
                    <i class="help-block">«خەتكۈچ باشقا نامى» بولسا ئۇلىنىش ئىچىدە ئىشلىتىلىدىغان نام بۇلۇپ يەككىلىككە ئىگە. بۇ URL ئۆلچىمىگە بوي سۇنىدىغان بۇلۇپ، پەقەت سان، لاتىنچە ھەرىپ، ئاستى سىزىق ۋە سىزىقتىلا تۈزىلىدۇ. ھەم ئاستى سىزىق ، سىزىقچىلار بىرگە كەلمەسلىكى، ھەم ئاخىرلاشماسلىقى،سان بىلەن باشلانماسلىقى كىرەك.مەسىلەن تۈۋەندىكىدەك بولسا بولمايدۇ.<br />
                    </i>
                </div>

                <div class="form-group">
                    <label>چۈشەندۈرۈش</label>
                    <textarea class="form-control" rows="5" placeholder="خەتكۈچ ئۈچۈن چۈشەندۈرۈش بىرىڭ" name="Des"><%:updateTag.Des %></textarea>
                    <i class="help-block">بۇ خەتكۈچ ئۈچۈن بىر ئىككى ئېغىز چۈشەندۈرۈش بىرىڭ. بۇ ئادەتتە كۆرسىتىلمىسىمۇ بىراق كۆرسىتىدىغان باش تىمىلار بار.</i>
                </div>
                <input type="hidden" name="Mode" value="<%:isEdit?"edit":"new" %>" />
                <input type="hidden" name="TagID" value="<%:isEdit?updateTag.ID:0 %>" />
                <button type="button" name="submit" class="btn btn-primary"><%:isEdit?"ئۆزگەرتىشلەرنى ساقلاش":"خەتكۈچ قوشۇش" %></button>
            </form>
        </div>
        <div class="col-sm-8">
            <div class="clearfix bulaq-header">
                <div class="form-inline f-left">
                    <input type="text" name="name" value="" class="form-control input-sm" placeholder="خەتكۈچنى ئىزدەپ بېقىڭ" />
                    <input type="button" name="name" value="ئىزدەش" class="btn btn-primary btn-sm" />
                </div>
            </div>
            <table class="table table-hover table-striped table-bordered">
                <thead>
                    <tr>
                        <th>خەتكۈچ نامى</th>
                        <th width="180">خەتكۈچ باشقا نامى</th>
                        <th>خەتكۈچ چۈشەندۈرۈلۈشى</th>
                        <th width="80">يازما سانى</th>
                    </tr>
                </thead>
                <tbody class="items-list">
                    <%foreach (var tag in allTags)
                      {%>
                    <tr class="tools-p">
                        <td><%:tag.Title %></td>
                        <td>
                            <span class="text-ltr"><%:tag.Name %></span>
                        </td>
                        <td><%:tag.Des %>
                            <div class="tools">
                                <div class="btn-group">
                                    <a href="?mode=edit&tagid=<%:tag.ID %>" class="btn btn-primary btn-xs">تەھرىرلەش</a>
                                    <input type="button" name="name" value="ئۆچۈرۈش" onclick="_deleteTag(<%:tag.ID%>);" class="btn btn-danger btn-xs" />
                                    <a href="/Tag/<%:tag.Name %>" class="btn btn-default btn-xs">كۆرۈش</a>
                                </div>
                            </div>
                        </td>
                        <td><a href="Posts.aspx?tag=<%:tag.ID %>" class="badge"><%:tag.PostsCount %></a></td>
                    </tr>
                    <%} %>
                </tbody>
            </table>
            <p class="help-block">
                خەتكۈچنىڭ ئۆچۈرۈلىشى ئۇنىڭدىكى يازمىلارغا تەسىر قىلمايدۇ.
           
            </p>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BeforeBody" runat="server">
    <script>

        var msgs = {
            'name_format': 'خەتكۈچ باشقا نامىدا خاتالىق بار!',
            'title_null': 'خەتكۈچ نامى بوش قالمىسۇن!',
            'tag_null': 'خەتكۈچ مەۋجۇت ئەمەس!',
            'on_update_error': 'خەتكۈچنى ئۆزگەرتىشتە خاتالىق كۆرۈلدى!',
            'on_add_error': 'خەتكۈچنى قوشۇشتا خاتالىق كۆرۈلدى! قايتا سىناپ بېقىڭ!',
            'has_title': 'بۇ نامدىكى خەتكۈچ مەۋجۇت! باشقا نام بىرىڭ.',
            'has_name': 'خەتكۈچ باشقا نامى مەۋجۇت! باشقا نام بىرىڭ.',
            'offline': 'سىز تېخى كىرمىدىڭىز! كىرگەندىن كىيىن مەشغۇلات قىلالايسىز!',
            'on_delete_error': 'خەتكۈچنى ئۆچۈرۈشتە خاتالىق بار!'
        };

        //提交
        $('#frm-tags-edit button[name=submit]').click(function () {
            var frm = $('#frm-tags-edit');
            var tit = frm.find('input[name=Title]');
            if (!tit || tit.val().trim() == '') {
                tit.parents('.form-group').addClass('has-error');
                var hi = tit.siblings('.help-block');
                hi.data('old-txt', hi.html());
                hi.html('خەتكۈچ ماۋزوسى بوش قالمىسۇن');
                return;
            }
            //添加 
            $.post('tags.aspx', frm.serialize(), function (d) {
                if (d.result == 'ok') alertTip('خەتكۈچ ساقلاندى!', function () { window.location.href = location.pathname });
                else {
                    alertTip(msgs[d['error']], 'danger', function () { window.location.href = d['error'] == 'offline' ? 'Login.aspx?url=' + encodeURIComponent(location.href) : location.pathname });
                }
            }, 'json');
        });


        //删除
        function _deleteTag(tagId) {
            if (!tagId || typeof tagId != 'number') return;
            Confirm('بۇ خەتكۈچنى راستىنلا مەڭگۈلۈك ئۆچۈرەمسىز؟', 'خەتكۈچ ئۆچۈرۈش ئەسكەرتمىسى', function () {
                $.post('Tags.aspx', { 'Mode': 'delete', 'TagID': tagId }, function (d) {
                    if (d.result == 'ok') alertTip('خەتكۈچ ئۆچۈرۈلدى!', 'success', function () { window.location.href = location.pathname; });
                    else {
                        alertTip(msgs[d['error']], 'danger', d['error'] == 'offline' ? function () { window.location.href = 'Login.aspx?url=' + encodeURIComponent(location.href); } : null);
                    }
                }, 'json');
            });
        }

    </script>
</asp:Content>
