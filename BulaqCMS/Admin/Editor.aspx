﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/_Admin.Master" AutoEventWireup="true" CodeBehind="Editor.aspx.cs" Inherits="BulaqCMS.Admin.Editor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link href="/Admin/Content/Editor/themes/default/css/umeditor.css" rel="stylesheet" />
    <script src="/Admin/Scripts/Editor/umeditor.config.js"></script>
    <script src="Scripts/Editor/umeditor.min.js"></script>
    <script src="Scripts/Editor/lang/zh-cn/zh-cn.js"></script>
    <style>
        .panel[data-slidable] .panel-heading {
            cursor: pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Container" runat="server">
    <h3 class="bulaq-header"><%:isEdit?"يازما تەھرىرلەش":"يېڭى يازما قوشۇش" %></h3>
    <div class="row">
        <div class="col-sm-9">
            <form id="frm-editor">
                <div class="form-group">
                    <input type="text" id="post_title" name="Title" value="<%:isEdit?UpdatePosts.Title:"" %>" class="form-control input-lg" placeholder="يازما تىمىسىنى بۇ يەرگە يېزىڭ" />
                </div>
                <div class="form-inline" style="margin-bottom: 10px; <%: isEdit?"":"display: none"%>" id="post_name">
                    <div class="form-group">
                        <span class="text-ltr"><code>http://localhost:8080/p/</code>
                            <input type="text" <%:Html(isEdit?"name=\"Name\"":"") %> data-name="Name" value="<%:isEdit?UpdatePosts.Name:"" %>" class="form-control input-sm" />
                        </span>
                    </div>
                    <div class="form-group">
                        <button type="button" class="btn btn-primary btn-xs btn-rename">&nbsp;<span class="glyphicon glyphicon-ok"></span>&nbsp;</button>
                    </div>
                    <div class="form-group">
                        <input type="button" name="name" value="ئۇلانمىلارنى تەڭشەش" class="btn btn-default btn-xs" />
                    </div>
                    <div class="form-group">
                        <input type="button" name="name" value="يازمىنى كۆرۈپ بېقىش" class="btn btn-default btn-xs" />
                    </div>
                </div>
                <div class="form-group">
                    <textarea class="form-control" name="Content" style="height: 400px;" id="postContent"><%:isEdit?UpdatePosts.Content:"" %></textarea>
                </div>
                <div class="form-group" id="post_hiddens">
                    <input type="hidden" name="Mode" value="<%:isEdit?"edit":"new" %>" />
                    <input type="hidden" name="PostID" value="<%:isEdit?UpdatePosts.ID:0 %>" />
                    <input type="hidden" name="Visible" value="<%:isEdit?UpdatePosts.VisibleState:1 %>" />
                    <input type="hidden" name="Approved" value="<%:isEdit&&UpdatePosts.Approved?"true":"false" %>" />
                    <input type="hidden" name="Image" value="<%:isEdit?UpdatePosts.PostImage??"":"" %>" />
                    <input type="hidden" name="Practice" value="<%:isEdit&&UpdatePosts.Practice?"true":"false" %>" />
                    <input type="button" name="submit" value="ساقلاش" class="btn btn-primary btn-lg" />
                    <%foreach (var cat in PostInCats)
                      {%>
                    <input type="hidden" name="Categories" value="<%:cat.CategoryID %>" />
                    <%}
                      foreach (var tag in postTags)
                      {%>
                    <input type="hidden" name="Tags" value="<%:tag.ID %>" />
                    <%}%>
                </div>
            </form>
        </div>
        <div class="col-sm-3">
            <form id="practice_set">
                <div class="panel panel-default" data-slidable>
                    <div class="panel-heading">ئىلان قىلىش</div>
                    <div class="panel-body">
                        <div class="radio">
                            <label>
                                <input type="radio" name="Practice" value="true" <%:Html((isEdit&&UpdatePosts.Practice)||!isEdit?"checked=\"checked\"":"") %> />
                                ئارگىنال ساقلاش
                            </label>
                        </div>
                        <div class="radio">
                            <label>
                                <input type="radio" name="Practice" value="false" <%:Html(isEdit&&!UpdatePosts.Practice?"checked=\"checked\"":"") %> />
                                ئىلان قىلىش
                            </label>
                        </div>
                    </div>
                    <div class="panel-footer clearfix">
                        <input type="hidden" name="Mode" value="practice" />
                        <input type="button" name="submit" value="ئۆزگەرتىشلەرنى ساقلاش" class="btn btn-primary btn-sm f-right" />
                        <input type="button" name="delflag" data-value="true" value="ئەخلەت ساندۇقىغا يۆتكەش" class="btn btn-danger btn-sm f-left" />
                    </div>
                </div>
            </form>

            <form id="visible_set">
                <div class="panel panel-default" data-slidable>
                    <div class="panel-heading">ئوقۇش</div>
                    <div class="panel-body">
                        <div class="radio">
                            <label>
                                <input type="radio" name="Visible" value="1" <%:Html(!isEdit||(isEdit&&UpdatePosts.VisibleState==1)?"checked=\"checked\"":"") %> />
                                ھەممىگە كۆرسىتىلسۇن
                            </label>
                        </div>
                        <div class="radio">
                            <label>
                                <input type="radio" name="Visible" value="2" <%:Html(isEdit&&UpdatePosts.VisibleState==2?"checked=\"checked\"":"") %> />
                                توردىكىلەرگە كۆرۈنسۇن
                            </label>
                        </div>
                        <div class="radio">
                            <label>
                                <input type="radio" name="Visible" value="3" <%:Html(isEdit&&UpdatePosts.VisibleState==3?"checked=\"checked\"":"") %> />
                                شەخسىي
                            </label>
                        </div>
                        <div class="radio">
                            <label>
                                <input type="radio" name="Visible" value="4" <%:Html(isEdit&&UpdatePosts.VisibleState==4?"checked=\"checked\"":"") %> />
                                يۇشۇرۇن
                            </label>
                        </div>
                    </div>
                    <div class="panel-footer clearfix">
                        <input type="button" name="submit" value="ساقلاش" class="btn btn-primary btn-sm f-right" />
                    </div>
                </div>
            </form>

            <form id="categorieas_set">
                <div class="panel panel-default" data-slidable>
                    <div class="panel-heading">سەھىپىلەر</div>
                    <div class="panel-body" style="max-height: 200px; overflow-y: scroll">
                        <%foreach (var cat in Cats)
                          {%>
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" <%:Html(PostInCats.Select(p=>p.CategoryID).Contains(cat.ID)?"checked=\"checked\"":"") %> name="Categories" value="<%:cat.ID %>" />
                                <%:cat.Title %>
                            </label>
                        </div>
                        <%} %>
                    </div>
                    <div class="panel-footer">
                        <input type="button" name="submit" value="ساقلاش" class="btn btn-primary btn-sm" />
                    </div>
                </div>
            </form>
            <div class="panel panel-default" data-slidable>
                <div class="panel-heading">خەتكۈچلەر</div>
                <div class="panel-body">
                    <div class="form-inline">
                        <div class="post-tags" id="post_tags">
                            <%if (isEdit)
                              {
                                  foreach (var tag in postTags)
                                  {%>
                            <div class="form-group">
                                <input type="hidden" name="Tag" value="<%:tag.ID %>" />
                                <i onclick="deleteTag(<%:string.Format("{0},{1}",UpdatePosts.ID,tag.ID) %>)" class="form-control input-sm"><%:tag.Title %><span class="glyphicon glyphicon-remove remove-tag-icon"></span></i>
                            </div>
                            <% }
                              } %>
                            <div class="form-group" id="new_tag_box">
                                <input type="text" id="new_tag_inp" class="form-control input-sm" placeholder="يېڭى خەتكۈچ" style="width: 120px;">
                            </div>
                        </div>

                    </div>
                    <a href="#" class="btn btn-link">ئاۋات خەتكۈچلەرنى تاللاش</a>
                </div>
                <div class="panel-footer">
                    <input type="button" name="name" value="ساقلاش" class="btn btn-primary btn-sm" />
                </div>
            </div>
            <div class="panel panel-default" data-slidable>
                <div class="panel-heading">سۈرەت</div>
                <div class="panel-body">
                    <div class="text-center">
                        <img src="http://tohpikar.com/temp/home/images/tohpikar_logo.png" alt="" style="height: auto; width: 100%" />
                    </div>
                    <div class="text-center" style="margin-top: 10px; margin-bottom: 10px">
                        <input type="button" name="name" value="media ئامبىرىدىن رەسىم تاللاش" class="btn btn-default btn-sm" />
                    </div>

                    <div class="row" style="margin-left: 0;">
                        <div class="col-sm-10">
                            <input type="text" name="name" value="" class="form-control input-sm text-ltr" placeholder="رەسىم تۇلۇق ئادرىسى" />
                        </div>
                        <div class="col-sm-2">
                            <input type="button" name="name" value="بولدى" class="btn btn-primary btn-sm" />
                        </div>
                    </div>
                </div>
                <div class="panel-footer">
                    <input type="button" name="name" value="ساقلاش" class="btn btn-primary btn-sm" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BeforeBody" runat="server">


    <script type="text/javascript">
        var editor = UM.getEditor('postContent');



        $('.panel[data-slidable] .panel-heading').click(function () {
            var pan = $(this).parents('.panel').get(0);
            if (!pan) return;
            pan = $(pan);
            var mod = $(pan).attr('slide');
            if (mod == 'up')
                pan.attr('slide', 'down').find('.panel-body').add(pan.find('.panel-footer')).slideDown(500);
            else
                pan.attr('slide', 'up').find('.panel-body').add(pan.find('.panel-footer')).slideUp(500);
        });

        var msgs = {
            'offline': 'سىز توردا ئەمەس، كىرگەندىن كىيىن ساقلىيالايسىز!',
            'on_new_error': 'يازمىنى يوللاشتا خاتالىق كۆرۈلدى!',
            'title_null': 'يازما ماۋزوسى بوش قالمىسۇن!',
            'on_update_error': 'ئۆزگەرتىشتە خاتالىق كۆرۈلدى!',
            'post_null': 'ئۆزگەرتمەكچى بولغان يازمىنى تاپالمىدى!',
            'on_rename_error': 'يازما باشقا نامىنى ئۆزگەرتىشتە خاتالىق كۆرۈلدى!',
            'has_name': 'يازما باشقا نامى مەۋجۇت! باشقا نام بىرىڭ!',
            'name_format': 'يازما باشقا نامىدا خاتالىق بار! قايتا نام بىرىڭ!',
            'name_null': 'يازما باشقا نامى بوش قالمىسۇن!',
            'ok': 'ئۆزگەرتىشلەر ساقلاندى!',
            'on_delflag_error': 'يازمىنى ئۆچۈرۈشتە خاتالىق كۆرۈلدى!',
            'data_null': 'ئۇچۇرلاردا خاتالىق بار!',
            'on_practice_error': 'ئارگىنال ساقلاشتا خاتالىق كۆرۈلدى!',
            'on_visible_error': 'يازما ھقۇقۇقى تەڭشەشتە خاتالىق بار!',
            'on_delete_error': 'يازمىنى ئۆچۈرۈشتە خاتالىق كۆرۈلدى!',
            'on_approve_error': 'يازمىنى تەستىقلاشتا خاتالىق كۆرۈلدى!',
            '': '',
            '': '',
            '': '',
            'server_error': 'مۇلازىمىتىردا خاتالىق كۆرۈلدى!',
        };

        //发表文章
        $('#post_title').blur(function () {
            var tit = $(this).val();
            if (!tit || tit.trim().length <= 0) return;
            var mode = $('#frm-editor input[name=Mode]').val();
            if (mode != 'new') return;
            _post(true);
        });

        //提交
        $('#frm-editor input[name=submit]').click(function () {
            _post(false);
        });

        //提交
        function _post(isNew) {
            var frm = $('#frm-editor');
            $.post('Editor.aspx', frm.serialize(), function (d) {
                if (d['result'] == 'ok') {
                    //设置文章
                    if (!isNew) {
                        alertTip(msgs.ok);
                    }
                    frm.find('input[name=PostID]').val(d.res.post_id);
                    if (isNew) {
                        frm.find('input[data-name=Name]').attr("name", 'Name');
                        $('#post_name').slideDown();
                    }
                    frm.find('input[name=Name]').val(d.res.post_name);
                    frm.find('input[name=Mode]').val('edit');
                    //删除所有分类
                    frm.find('input[name=Categories]').remove();
                    frm.find('input[name=Tags]').remove();
                    //添加新分类,新标签
                    modeCategories(d.res.cats);
                    modeTags(d.res.tags);

                } else if (d['error'] == 'offline') {
                    alertTip('سىز تېخى كىرمىدىڭىز، كىرگەندىن كىيىن قايتا سىناپ بېقىڭ!', 'danger');
                } else {

                }
            }, 'json').error(function () { });
        }

        //别名修改
        $('#post_name .btn-rename').click(function () {
            var postId = $('#frm-editor input[name=PostID]').val();
            if (!postId || postId <= 0) return;
            var nname = $('#post_name input[name=Name]').val();
            if (!nname || (typeof nname).toLowerCase() != 'string' || nname.length <= 0) return;
            var d = { 'Mode': 'rename', 'PostID': postId, 'Name': nname };
            _submitPost(d);
        });

        //提交
        function _submitPost(data, okFn, errorFn) {
            $.post('Editor.aspx', data, function (d) {
                if (d['result'] == 'ok') {
                    alertTip(msgs.ok);
                    if (typeof okFn == 'function') okFn(d);
                } else {
                    alertTip(msgs[d['error']], 'danger');
                    if (typeof errorFn == 'function') errorFn(d.error);
                }
            }, 'json').error(function () { alertTip(msgs['server_error'], 'danger') });

        }

        //修改practice
        $('#practice_set input[name=submit]').click(function () {
            //alert($('#practice_set').serialize());
            var frm = $('#frm-editor');
            var pid = frm.find('input[name=PostID]').val();
            if (!pid || pid <= 0) return;
            var data = $('#practice_set').serialize();
            data += '&PostID=' + pid;
            _submitPost(data);
        });

        //删除
        $('#practice_set input[name=delflag]').click(function () {
            var _this = $(this);
            var val = $(this).attr('data-value');
            if (!val || (val != 'true' && val != 'false')) return;
            var frm = $('#frm-editor');
            var pid = frm.find('input[name=PostID]').val();
            if (!pid || pid <= 0) return;
            var data = 'Mode=delflag';
            data += '&PostID=' + pid;
            data += '&DelFlag=' + val;
            _submitPost(data, function (d) {
                _this.removeClass(val == 'true' ? 'btn-danger' : 'btn-info').addClass(val == 'true' ? 'btn-info' : 'btn-danger').attr('data-value', val == 'true' ? 'false' : 'true').val(val == 'true' ? 'ئەخلەت ساندۇقىدىن چىقىرىش' : 'ئەخلەت ساندۇقىغا يۆتكەش');
            });
        });

        //显示
        $('#visible_set input[name=submit]').click(function () {
            var frm = $('#frm-editor');
            var pid = frm.find('input[name=PostID]').val();
            if (!pid || pid <= 0) return;
            var _thisFrm = $('#visible_set');
            var data = _thisFrm.serialize();
            data += '&Mode=visible';
            data += '&PostID=' + pid;
            _submitPost(data);
        });

        //文章分类
        $('#categorieas_set input[name=submit]').click(function () {
            var frm = $('#frm-editor');
            var pid = frm.find('input[name=PostID]').val();
            if (!pid || pid <= 0) return;
            var _thisFrm = $('#categorieas_set');
            var data = _thisFrm.serialize();
            data += '&Mode=categories';
            data += '&PostID=' + pid;
            _submitPost(data, function (d) {
                modeCategories(d.res.cats);
            })
        });

        //标签
        $('#new_tag_inp').keypress(function (e) {
            var c = e['charCode'];
            if (c == 61 || c == 92 || c == 47 || c == 58 || c == 38 || c == 35 || c == 63) return;



            if (c == 13 /*|| e['charCode'] == 115*/) {
                //调教标签
                //  = 61
                //  \  92
                // /  47
                // :   58
                //  &  38
                //  #  35
                //   ?  63
                var val = $(this).val().replace(/[\?#&:/\\=]/, '').trim();
                if (!val || val.length <= 0) return;
                var frm = $('#frm-editor');
                var pid = frm.find('input[name=PostID]').val();
                //newTag($(this).val());
                $(this).val('');
                if (!pid || pid <= 0) return;
                var data = { 'Mode': 'newtag', 'NewTag': val, 'PostID': pid };
                _submitPost(data, function (d) {
                    // modeTags(d.res.tags);
                    var tag_id = d.res.tag_id;
                    //添加到集合中
                    if ($('#post_hiddens input[name=Tags]').filter('[value="' + tag_id + '"]').length <= 0) {
                        $('#post_hiddens').append('<input name="Tags" type="hidden" value="' + tag_id + '">');
                    }
                    //添加到
                    //<div class="form-group">
                    //            <input type="hidden" name="name" value="tags-0" />
                    //            <i class="form-control input-sm">پىروگىراممىلار<span class="glyphicon glyphicon-remove remove-tag-icon"></span></i>
                    //       </div>
                    if ($('#post_tags input[name=Tag]').filter('[value="' + tag_id + '"]').length <= 0) {
                        var htm = '<div class="form-group"><input type="hidden" name="Tag" value="'
                            + tag_id
                            + '" /><i class="form-control input-sm">'
                        + val
                        + '<span class="glyphicon glyphicon-remove remove-tag-icon"></span></i></div>';
                        var htm = $(htm);
                        htm.find('i').click(function () {
                            deleteTag(pid, tag_id);
                        })
                        $('#new_tag_box').before(htm);
                    }
                }, function (error) {

                });
                return false;
            }
        })

        //删除标签
        function deleteTag(postId, tagId) {
            if (!postId || postId <= 0 || !tagId || tagId <= 0) return;
            var data = { 'Mode': 'deletetag', 'TagID': tagId, 'postId': postId };
            _submitPost(data, function (d) {
                $('#frm-editor input[name=Tags]').filter('[value=' + tagId + ']').remove();
                $('#post_tags input[name=Tag]').filter('[value=' + tagId + ']').parents('.form-group').remove();
            });
        }

        //处理文章分类
        function modeCategories(cats) {
            var hid = $('#post_hiddens');
            var catsBox = $('#categorieas_set');
            catsBox.find('input[name=Categories]:checkbox').each(function (index, el) {
                $(el).get(0).checked = false;
            });
            for (var i = 0; i < cats.length; i++) {
                hid.append('<input type="hidden" name="Categories" value="' + cats[i] + '" />');
                catsBox.find('input[name=Categories]:checkbox').filter('[value=' + cats[i] + ']').get(0).checked = true;
            }
        }

        //处理标签类
        function modeTags(tags) {
            var hid = $('#post_hiddens');
            //删除
            hid.find('input[name=Tags]').remove();
            //添加
            for (var i = 0; i < tags.length; i++) {
                hid.append('<input type="hidden" name="Tags" value="' + tags[i] + '" />');
            }
        }

        //新的标签
        function newTag(tagStr) {

        }

        //点击分类选择框
        $('#categorieas_set input[name=Categories]').click(function () {
            var ck = $(this).get(0);
            if (!ck || ck.tagName.toLowerCase() != 'input' || $(this).attr('type').toLowerCase() != 'checkbox') return;
            var box = $('#post_hiddens');
            if (ck.checked) {
                //添加
                if (box.find('input[name=Categories]').filter('[value=' + $(this).val() + ']').length <= 0) {
                    box.append('<input type="hidden" name="Categories" value="' + $(this).val() + '" />');
                }
            } else {
                //删除
                box.find('input[name=Categories]').filter('[value=' + $(this).val() + ']').remove();
            }
        });
        //点击Visible
        $('#visible_set input[name=Visible]:radio').click(function () {
            $('#post_hiddens input[name=Visible]').val($(this).val());
        });
    </script>



</asp:Content>

