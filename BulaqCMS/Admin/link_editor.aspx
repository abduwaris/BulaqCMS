<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/_Admin.Master" AutoEventWireup="true" CodeBehind="link_editor.aspx.cs" Inherits="BulaqCMS.Admin.link_editor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Container" runat="server">
    <h3 class="bulaq-header"><%:isEdit?"ئۇلانما تەھرىرلەش":"يېڭى ئۇلانما قوشۇش" %><%if (isEdit)
                                                                                    { %>  <a href="link_editor.aspx?mode=new" class="btn btn-primary btn-xs">يېڭىدىن قوشۇش</a><%} %></h3>
    <div class="row">
        <div class="col-sm-9">
            <form>
                <div class="form-group">
                    <label>نامى</label>
                    <input type="text" class="form-control input-sm" placeholder="نامى" value="<%:isEdit?UpdateLinks.Title:"" %>" name="Title">
                    <i class="help-block">تور بېتىڭىزدە مۇشۇ نامدا كۆرسىتىلىدىغان بۇلۇپ يەككىلىككە ئىگە ئەمەس. ھەرقانداق ھەرىپ بەلگىلەرنى قوللايدۇ.</i>
                </div>
                <%--<div class="form-group">
                            <label>ئۇلانما باشقا نامى</label>
                            <input type="text" class="form-control input-sm text-ltr" placeholder="ئۇلانما باشقا نامى">
                            <i class="help-block">
                                «ئۇلانما باشقا نامى» بولسا ئۇلىنىش ئىچىدە ئىشلىتىلىدىغان نام بۇلۇپ، يەككلىلىككە ئىگە.
                            </i>
                        </div>--%>
                <div class="form-group">
                    <label>ئۇلانما ئادرىسى</label>
                    <input type="text" name="Url" value="<%:isEdit?UpdateLinks.Url:"" %>" class="form-control input-sm text-ltr" placeholder="ئۇلانما ئادرىسى" />
                    <i class="help-block">سىرتقى ئۇلىنىش قىلىش ئۈچۈن <code class="text-ltr">http://</code> ياكى <code class="text-ltr">https://</code> بىلەن باشلاپ يېزىڭ. مەسىلەن <code class="text-ltr">http://www.bulaq.net</code> دىگەندەك. مۇشۇنداق بولغاندا ئىچكى ئۇلىنىشلار بىلەن تۇقۇنۇشۇپ قالمايدۇ. قالغانلىرى تور كۆرگۈچنىڭ قانداق ئانالىز قىلىشىغا باغلىق.
                    </i>
                </div>
                <div class="form-group">
                    <label>چۈشەندۈرۈش</label>
                    <textarea name="Des" class="form-control" rows="5" placeholder="ئۇلانما ئۈچۈن چۈشەندۈرۈش بىرىڭ"><%:isEdit?UpdateLinks.Des:"" %></textarea>
                    <i class="help-block">بۇ ئۇلانما ئۈچۈن بىر ئىككى ئېغىز چۈشەندۈرۈش بىرىڭ.</i>
                </div>
                <input type="hidden" name="LinkID" value="<%:isEdit?UpdateLinks.ID:0 %>" />
                <input type="hidden" name="Mode" value="<%:isEdit?"edit":"new" %>" />
                <button type="button" id="link_edit_submit" class="btn btn-primary"><%:isEdit?"ئۆزگەرتىشلەرنى ساقلاش":"ئۇلانما قوشۇش" %></button>
            </form>
        </div>
        <div class="col-sm-3">
            <form>
                <div class="panel panel-default">
                    <div class="panel-heading">ئۇلانما سەھىپىسى</div>
                    <div class="panel-body">
                        <div class="form-group">
                            <select class="form-control input-sm" name="LinkGroups">
                                <option value=" ">ئۇلانما سەھىپىسىنى تاللاڭ</option>
                                <%foreach (var group in linkGroups)
                                  {%>
                                <option <%:Html(isEdit&&UpdateLinks.Name==group?"selected=\"selected\"":"") %> value="<%:group %>"><%:group %></option>
                                <%}%>
                            </select>
                        </div>
                        <div class="form-group" id="create_linkgroup_box" style="display: none">
                            <div class="row" style="margin-left: 15px">
                                <div class="col-sm-10">
                                    <input type="text" id="create_linkgroup_txt" value="" class="form-control input-sm" placeholder="سەھىپە نامى" />
                                </div>
                                <div class="col-sm-2">
                                    <input id="create_linkgroup_btn" type="button" value="قۇرۇش" class="btn btn-default btn-sm" />
                                </div>
                            </div>
                        </div>
                        <input id="show_linkgroup_btn" type="button" name="name" value="يېڭىدىن سەھىپە قورۇش" class="btn btn-default btn-sm btn-block" />
                        <i class="help-block text-justify">«ئۇلانما سەھىپىسى» بولسا ئۇلانمىلارنى پەرقلەندۈرۈش ئۈچۈن ئىشلىتىلىدىغان گۇرۇپپىلاش شەكلى بۇلۇپ، تاللانسىمۇ تاللانمىسىمۇ بۇلىدۇ. ئىھتىياجىڭىزغا قاراپ تاللاش تاللىماسلىقنى بىكىتسىڭىز بۇلىدۇ.</i>
                    </div>
                    <div class="panel-footer">
                        <input type="hidden" name="LinkID" value="<%:isEdit?UpdateLinks.ID:0 %>" />
                        <input type="hidden" name="Mode" value="linkgroup" />
                        <input type="button" value="ساقلاش" id="link_group_save" class="btn btn-primary btn-sm" />
                    </div>
                </div>
            </form>

            <form>
                <div class="panel panel-default">
                    <div class="panel-heading">كۆرسىتىش</div>
                    <div class="panel-body">
                        <div class="radio">
                            <label>
                                <input type="radio" name="Visible" value="true" <%:Html(isEdit&&UpdateLinks.Visible?"checked=\"checked\"":"checked=\"checked\"") %>>
                                كۆرسىتىلسۇن
                            </label>
                        </div>
                        <div class="radio">
                            <label>
                                <input type="radio" name="Visible" value="false" <%:Html(isEdit&&!UpdateLinks.Visible?"checked=\"checked\"":"") %>>
                                يۇشۇرۇن
                            </label>
                        </div>
                        <i class="help-block text-justify">ئۇلانمىنىڭ كۆرسىتىش كۆرسەتمەسلىكىنى بەلگىلەيدۇ!</i>
                    </div>
                    <div class="panel-footer">
                        <input type="hidden" name="LinkID" value="<%:isEdit?UpdateLinks.ID:0 %>" />
                        <input type="hidden" name="Mode" value="visible" />
                        <input type="button" id="visibleSave" value="ساقلاش" class="btn btn-primary btn-sm">
                    </div>
                </div>
            </form>

            <form>
                <div class="panel panel-default">
                    <div class="panel-heading">ئوبيېكت</div>
                    <div class="panel-body">
                        <div class="radio">
                            <label>
                                <input type="radio" name="Target" value="1" <%:Html(isEdit&&UpdateLinks.Target==1?"checked=\"checked\"":"checked=\"checked\"") %>>
                                <code class="text-ltr">_none</code>&nbsp;&nbsp;&nbsp;ئوخشاش كۆزنەك ياكى بەتكۈچ.
                            </label>
                        </div>
                        <div class="radio">
                            <label>
                                <input type="radio" name="Target" value="2" <%:Html(isEdit&&UpdateLinks.Target==2?"checked=\"checked\"":"") %>>
                                <code class="text-ltr">_blank</code>&nbsp;&nbsp;&nbsp;يېڭى كۆزنەك ياكى بەتكۈچ.
                            </label>
                        </div>
                        <div class="radio">
                            <label>
                                <input type="radio" name="Target" value="2" <%:Html(isEdit&&UpdateLinks.Target==3?"checked=\"checked\"":"") %>>
                                <code class="text-ltr">_top</code>&nbsp;&nbsp;&nbsp;نۆۋەتتىكى كۆزنەك ياكى بەتكۈچ، رامكىسىز.
                            </label>
                        </div>
                        <div class="radio">
                            <label>
                                <input type="radio" name="Target" value="4" <%:Html(isEdit&&UpdateLinks.Target==4?"checked=\"checked\"":"") %>>
                                <code class="text-ltr">_self</code>&nbsp;&nbsp;&nbsp;ئوخشاش كۆزنەك ياكى بەتكۈچ.
                            </label>
                        </div>
                        <div class="radio">
                            <label>
                                <input type="radio" name="Target" value="5" <%:Html(isEdit&&UpdateLinks.Target==5?"checked=\"checked\"":"") %>>
                                <code class="text-ltr">_parent</code>&nbsp;&nbsp;&nbsp;ئوخشاش كۆزنەك ياكى بەتكۈچنىڭ ئاتا بەتكۈچى ياكى كۆزنىكى.
                            </label>
                        </div>

                        <i class="help-block text-justify">«ئوبيېكت» بولسا ئۇلانمىنىڭ قايسى شەكىلدە ئېچىلىدىغانلىقىنى كۆرسىتىدۇ.
                        </i>
                    </div>
                    <div class="panel-footer">
                        <input type="hidden" name="LinkID" value="<%:isEdit?UpdateLinks.ID:0 %>" />
                        <input type="hidden" name="Mode" value="target" />
                        <input type="button" id="targetSave" value="ساقلاش" class="btn btn-primary btn-sm">
                    </div>
                </div>
            </form>
            <div class="panel panel-default">
                <div class="panel-heading">سۈرەت</div>
                <div class="panel-body">
                    <div class="text-center">
                        <img src="<%:isEdit?UpdateLinks.Image:"" %>" alt="<%:isEdit?UpdateLinks.Image:"" %>" style="height: auto; width: 100%" />
                    </div>
                    <div class="text-center" style="margin-top: 10px; margin-bottom: 10px">
                        <input type="button" name="name" value="media ئامبىرىدىن رەسىم تاللاش" class="btn btn-default btn-sm" />
                    </div>

                    <div class="row" style="margin-left: 0;">
                        <div class="col-sm-10">
                            <input type="text" name="name" value="<%:isEdit?UpdateLinks.Image:"" %>" class="form-control input-sm text-ltr" placeholder="رەسىم تۇلۇق ئادرىسى" />
                        </div>
                        <div class="col-sm-2">
                            <input type="button" name="name" value="بولدى" class="btn btn-primary btn-sm" />
                        </div>
                    </div>
                    <i class="help-block text-justify">«سۈرەت» بولسا ئۇلانما ئۈچۈن تور بەتتە كۆرسىتىلىدىغان رەسىم بۇلۇپ، سۈرەت تاللانمىسا ياكى تۈۋەندىكى ئادرىس قۇرۇق بولسا سىستىما تەمىنلىگەن سۈكۈتتىكى سۈرەتنى ئىشلىتىدۇ. تور بېتىڭىزدە سۈرەتنىڭ نۇرمال كۆرۈنۈشى ئۈچۈن سۈرەتنى Media ئامبىرىدىن تاللاڭ.
                    </i>
                </div>
                <div class="panel-footer">
                    <input type="button" name="name" value="ساقلاش" class="btn btn-primary btn-sm" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BeforeBody" runat="server">
    <script>

        var msgs = {
            'title_null': 'ئۇلانما نامىنى كىرگۈزۈڭ!',
            'url_null': 'ئۇلانما ئادرىسىنى كىرگۈزۈڭ!',
            'url_format': 'ئۇلانما ئادرىسىدا خاتالىق بار!',
            'on_add_link_error': 'ئۇلانما قوشۇشتا خاتالىق كۆرۈلدى!',
            'link_null': 'ئۇلانما مەۋجۇت ئەمەس!',
            'on_update_link_error': 'ئۇلانمىنى ئۆزگەرتىشتە خاتالىق كۆرۈلدى!',
            'group_null': 'ئۇلانما سەھىپىسى بوش قالمىسۇن!',
            'on_group_name_error': 'يېڭى ئۇلانما سەھىپىسى قوشۇشتا خاتالىق كۆرۈلدى!',
            'server_error': 'سىستىمىدا خاتالىق كۆرۈلدى!',
            'on_target_error': 'ئوبيېكتنى ساقلاشتا خاتالىق كۆرۈلدى!',
            'on_visible_error': 'ئۇلانما كۆرۈنۈشىنى ئۆزگەرتىشتە خاتالىق كۆرۈلدى!'
        };

        //创建连接
        $('#link_edit_submit').click(function () {
            var frm = $(this).parents('form');
            $.post('link_editor.aspx', frm.serialize(), function (d) {
                if (d['result'] == 'ok') {
                    alertTip('ئۇلانما ساقلاندى!', function () { window.location.href = 'links.aspx'; })
                } else {
                    if (d['error'] == 'offline') alertTip('سىز تېخى كىرمىدىڭىز، كىرگەندىن كىيىن مەشغۇلات قىلالايسىز!', 'danger', function () { location.href = 'login.aspx?url=' + encodeURIComponent(location.href); });
                    else alertTip(msgs[d['error']], 'danger');
                }
            }, 'json').error(function () {
                alertTip('مۇلازىمىتىردا خاتالىق كۆرۈلدى!', 'danger');
            });
        })

        //显示创建连接组
        $('#show_linkgroup_btn').click(function () {
            var frm = $(this).parents('form');
            var linkId = frm.find('input[name=LinkID]').val();
            if (!linkId || linkId <= 0) return;
            //显示
            $(this).slideUp(300);
            $('#create_linkgroup_box').slideDown(300);
        });

        //创建分组
        $('#create_linkgroup_btn').click(function () {
            var inp = $('#create_linkgroup_txt').val();
            var frm = $(this).parents('form');
            var linkId = frm.find('input[name=LinkID]').val();
            if (!inp || inp.trim() == '' || !linkId || linkId <= 0) {
                //隐藏
                $('#create_linkgroup_box').slideUp(300);
                $('#show_linkgroup_btn').slideDown(300);
            } else {
                $.post('link_editor.aspx', { "Mode": 'linkgroup_add', "LinkID": linkId, "GroupName": inp.trim() }, function (d) {
                    if (d.result == 'ok') {
                        //设置
                        var res = d['res'];
                        var groups = res.groups;
                        var group = res.group;
                        var htm = '<option value=" ">ئۇلانما سەھىپىسىنى تاللاڭ</option>';
                        for (var i = 0; i < groups.length; i++) {
                            htm += '<option' + (group == groups[i] ? ' selected="selected"' : ' ') + ' value="' + groups[i] + '">' + groups[i] + '</option>';
                        }
                        frm.find('select[name=LinkGroups]').html(htm);
                        $('#create_linkgroup_box').slideUp(300);
                        $('#show_linkgroup_btn').slideDown(300);
                        alertTip('ئۆزگەرتىشلەر ساقلاندى!');
                    }
                    else {
                        alertTip(msgs[d['error']], 'danger');
                    }
                }, 'json').error(function () { alertTip(msgs.server_error, 'danger'); });
            }
        });


        //保存分组
        $('#link_group_save').click(function () {
            var frm = $(this).parents('form');
            $.post('link_editor.aspx', frm.serialize(), function (d) {
                if (d['result'] == 'ok') alertTip('ئۆزگەرتىشلەر ساقلاندى!');
                else {
                    if (d['error'] == 'offline') alertTip('سىز توردا ئەمەس، كىرگەندىن كىيىن مەشغۇلات قىلالايسىز!', 'danger', function () { location.href = 'login.aspx?url=' + encodeURIComponent(location.href); });
                    else alertTip(msgs[d['error']], 'danger');
                }
            }, 'json');
        });

        //打开方式保存
        $('#targetSave').click(function () {
            var frm = $(this).parents('form');
            var linkId = frm.find('input[name=LinkID]').val();
            if (!linkId || linkId <= 0) return;
            $.post('link_editor.aspx', frm.serialize(), function (d) {
                if (d.result == 'ok') alertTip('ئۆزگەرتىشلەر ساقلاندى!');
                else alertTip(msgs[d['error']], 'danger');
            }, 'json').error(function () { alertTip(msgs.server_error, 'danger'); });
        });

        ///是否显示
        $('#visibleSave').click(function () {
            frm = $(this).parents('form');
            var linkId = frm.find('input[name=LinkID]').val();
            if (!linkId || linkId <= 0) return;
            $.post('link_editor.aspx', frm.serialize(), function (d) {
                if (d['result'] == 'ok') alertTip('ئۆزگەرتىشلەر ساقلاندى!');
                else alertTip(msgs[d['error']]);
            }, 'json').error(function () { alertTip(msgs.server_error, 'danger') });
        })
    </script>
</asp:Content>
