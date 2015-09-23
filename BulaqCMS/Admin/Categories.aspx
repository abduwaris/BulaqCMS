<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/_Admin.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="BulaqCMS.Admin.Categories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Container" runat="server">

    <h3 class="bulaq-header">سەھىپىلەر</h3>
    <div class="row">
        <div class="col-sm-4">
            <p><strong><%:isEdit?"سەھىپە تەھرىرلەش":"يېڭىدىن سەھىپە قورۇش" %></strong></p>
            <i class="help-block">سەھىپە بىلەن خەتكۈچنىڭ پەرقى شۇكى سەھىپىلەر قاتلاملىق مۇناسىۋەتكە ئىگە ھەم سەھىپە ۋە سەھىپىلەر ئاستىدىكى بارلىق يازمىلارغا خالىغانچە ئۇسلۇب تەللىغىلى بۇلىدۇ.</i>
            <form>
                <div class="form-group" id="ctitle">
                    <label>نامى</label>
                    <input type="text" class="form-control input-sm" placeholder="نامى" name="Title" value="<%:isEdit?updateCat.Title:"" %>">
                    <i class="help-block" data-old="تور بېتىڭىزدە مۇشۇ نامدا كۆرسىتىلىدىغان بۇلۇپ يەككىلىككە ئىگە ئەمەس. ھەرقانداق ھەرىپ بەلگىلەرنى قوللايدۇ.">تور بېتىڭىزدە مۇشۇ نامدا كۆرسىتىلىدىغان بۇلۇپ يەككىلىككە ئىگە ئەمەس. ھەرقانداق ھەرىپ بەلگىلەرنى قوللايدۇ.</i>
                </div>
                <div class="form-group" id="cname">
                    <label>سەھىپە باشقا نامى</label>
                    <input type="text" class="form-control input-sm text-ltr" placeholder="سەھىپە باشقا نامى" name="Name" value="<%:isEdit?updateCat.Name:"" %>">
                    <i class="help-block" data-old="«سەھىپە باشقا نامى» بولسا ئۇلىنىش ئىچىدە ئىشلىتىلىدىغان نام بۇلۇپ يەككىلىككە ئىگە. بۇ URL ئۆلچىمىگە بوي سۇنىدىغان بۇلۇپ، پەقەت سان، لاتىنچە ھەرىپ، ئاستى سىزىق ۋە سىزىقتىلا تۈزىلىدۇ. ھەم ئاستى سىزىق ، سىزىقچىلار بىرگە كەلمەسلىكى، ھەم ئاخىرلاشماسلىقى،سان بىلەن باشلانماسلىقى كىرەك.مەسىلەن تۈۋەندىكىدەك بولسا بولمايدۇ.">«سەھىپە باشقا نامى» بولسا ئۇلىنىش ئىچىدە ئىشلىتىلىدىغان نام بۇلۇپ يەككىلىككە ئىگە. بۇ URL ئۆلچىمىگە بوي سۇنىدىغان بۇلۇپ، پەقەت سان، لاتىنچە ھەرىپ، ئاستى سىزىق ۋە سىزىقتىلا تۈزىلىدۇ. ھەم ئاستى سىزىق ، سىزىقچىلار بىرگە كەلمەسلىكى، ھەم ئاخىرلاشماسلىقى،سان بىلەن باشلانماسلىقى كىرەك.مەسىلەن تۈۋەندىكىدەك بولسا بولمايدۇ.</i>
                </div>
                <div class="form-group" id="cparent">
                    <label>تەۋەلىكى</label>
                    <select class="form-control input-sm" name="Parent" aria-selected="false">
                        <option value="0">سەھىپە ئايرىلمىغان</option>
                        <%:Options(Cats.Where(p=>p.ParentID==0).ToList(),0,isEdit,isEdit?updateCat.ParentID:0)%>
                    </select>
                    <i class="help-block" data-old="سەھىپىنىڭ خەتكۈچ بىلەن ئوخشىمايدىغان يىرى شۇكى، سەھىپە قاتلاملىق مۇناسىۋەتكە ئىگە. تاللىمىسىڭىزمۇ بۇلىدۇ.">سەھىپىنىڭ خەتكۈچ بىلەن ئوخشىمايدىغان يىرى شۇكى، سەھىپە قاتلاملىق مۇناسىۋەتكە ئىگە. تاللىمىسىڭىزمۇ بۇلىدۇ.</i>
                </div>
                <div class="form-group" id="ctemplate">
                    <label>سەھىپىە ئۇسلۇبى</label>
                    <select class="form-control input-sm" name="Template" aria-selected="false">
                        <option value="0">سۈكۈتتىكى ئۇسلۇب</option>
                    </select>
                    <i class="help-block" data-old="«سەھىپىە ئۇسلۇبى» ئارقىلىق مەزكور سەھىپە بېتىنىڭ ئۇسلۇبىنى تاللىيالايسىز. تاللانمىسا سىستىمىنىڭ تاللانغان ئۇسلۇبىنى ئىشلىتىدۇ.">«سەھىپىە ئۇسلۇبى» ئارقىلىق مەزكور سەھىپە بېتىنىڭ ئۇسلۇبىنى تاللىيالايسىز. تاللانمىسا سىستىمىنىڭ تاللانغان ئۇسلۇبىنى ئىشلىتىدۇ.</i>
                </div>
                <%--<div class="form-group">
                    <label>سەھىپىدىكى يازمىلار ئۇسلۇبى</label>
                    <select class="form-control input-sm" name="PostsTemplate">
                        <option value="value">سەھىپىدىكى يازمىلار ئۇسلۇبىنى تاللاڭ</option>
                        <option value="value">text</option>
                        <option value="value">text</option>
                        <option value="value">text</option>
                    </select>
                    <i class="help-block">«سەھىپىدىكى يازمىلار ئۇسلۇبى» ئارقىلىق مەزكور سەھىپە ئىچىدىكى بارلىق ئۇسلۇب تاللانمىغان يازمىلارغا كۆرسىتىش ئۇسلۇبى بىكىتەلەيسىز، ئەگەر تارماق سەھىپىدە ئۇسلۇب تاللانغان بولسا تارماق سەھىپىدىكى ئۇسلۇبنى ئاساس قىلىدۇ. ئۇسلۇب تاللاش تەرتىۋى ئىچىدىن تېشىغا ئاجىزلايدىغان بۇلۇپ، ھېچقانداق ئۇسلۇب تاللانمىغان بولسا سىستىمىنىڭ سۈكۈتتىكى تاللانغان ئۇسلۇبى ئاساس قىلىنىدۇ. بىر يازما بىر نەچچە سەھىپىگە تاللانغان بولسا، شۇلارنىڭ ئىچىدىكى ئۇسلۇب تاللانغان بىرىنچى سەھىپىنى ئاساس قىلىپ ئۇسلۇب بىكىتىدۇ.</i>
                </div>--%>
                <div class="form-group" id="cdes">
                    <label>چۈشەندۈرۈش</label>
                    <textarea class="form-control" rows="5" name="Des"><%:isEdit?updateCat.Des:"" %></textarea>
                    <i class="help-block" data-old="بۇ سەھىپە ئۈچۈن بىر ئىككى ئېغىز چۈشەندۈرۈش بىرىڭ. بۇ ئادەتتە كۆرسىتىلمىسىمۇ بىراق كۆرسىتىدىغان باش تىمىلار بار">بۇ سەھىپە ئۈچۈن بىر ئىككى ئېغىز چۈشەندۈرۈش بىرىڭ. بۇ ئادەتتە كۆرسىتىلمىسىمۇ بىراق كۆرسىتىدىغان باش تىمىلار بار</i>
                </div>
                <%if (isEdit)
                  { %>
                <input type="hidden" name="CatID" value="<%:updateCat.ID %>" />
                <%} %>

                <input type="hidden" name="Mode" value="<%:isEdit?"edit":"new" %>" />
                <button type="button" id="submit" class="btn btn-primary"><%:isEdit?"ئۆزگەرتىشلەرنى ساقلاش":"سەھىپە قوشۇش" %></button>
            </form>
        </div>
        <div class="col-sm-8">
            <div class="clearfix bulaq-header">
                <div class="form-inline f-left">
                    <input type="text" name="name" value="" class="form-control input-sm" placeholder="سەھىپىنى ئىزدەپ بېقىڭ" />
                    <input type="button" name="name" value="ئىزدەش" class="btn btn-primary btn-sm" />
                </div>
            </div>
            <table class="table table-hover table-striped table-bordered">
                <thead>
                    <tr>
                        <th>سەھىپە نامى</th>
                        <th width="180">سەھىپە باشقا نامى</th>
                        <th>سەھىپە چۈشەندۈرۈلۈشى</th>
                        <th width="80">يازما سانى</th>
                    </tr>
                </thead>
                <tbody class="items-list">
                    <%:Lists(Cats.Where(p=>p.ParentID==0).ToList(),0) %>
                    <%--<%foreach (var cat in Cats)
                      {%>
                    <tr>
                        <td class="tools-p"><%:cat.Title %>
                            <div class="tools">
                                <div class="btn-group">
                                    <a href="?mode=edit&cid=<%:cat.ID %>" class="btn btn-primary btn-xs">تەھرىرلەش</a>
                                    <input type="button" name="name" value="تىز تەھرىرلەش" class="btn btn-info btn-xs" />
                                    <input type="button" name="name" value="ئۆچۈرۈش" class="btn btn-danger btn-xs" />
                                    <input type="button" name="name" value="كۆرۈش" class="btn btn-default btn-xs" />
                                </div>
                            </div>
                        </td>
                        <td><%:cat.Name %></td>
                        <td><%:cat.Des %></td>
                        <td><a href="#" class="badge">15</a></td>
                    </tr>
                    <%} %>--%>
                </tbody>
            </table>
            <p class="help-block" >
                سەھىپە ئۆچۈرۈلسىمۇ، ئۇنىڭدىكى يازمىلار ئۆچۈرۈلمەيدۇ. بەلكى ئۆچۈرۈلگەن سەھىپىدىكى يازمىلار سەھىپە ئايرىلمىغان سەھىپىسىگە يۆتكىۋېتىلىدۇ.
            </p>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BeforeBody" runat="server">
    <script>
        var msgs = {
            'categoryid_null': 'ئۆزگەرتمەكچى بولغان سەھىپە مەۋجۇت ئەمەس!',
            'title_null': 'سەھىپە ئىسمى بوش قالمىسۇن!',
            'name_format': 'سەھىپە باشقا نامىدا خاتالىق بار، قايتا كىرگۈزۈڭ!',
            'category_null': 'ئۆزگەرتمەكچى بولغان سەھىپىنى تاپالمىدى!',
            'has_name': 'بۇ سەھىپە باشقا نامى بىلەن سەھىپە قورۇلۇپ بولغان!',
            'parent_filed': 'بۇ سەھىپە تەۋەلىكىنى تاپالمىدى! قايتا تاللاڭ!',
            'on_add_error': 'سەھىپە قوشۇشتا خاتالىق كۆرۈلدى!',
            'on_update_error': 'سەھىپىنى ئۆزگەرتىشتە خاتالىق كۆرۈلدى!',
            'on_delete_error': 'سەھىپىنى ئۆچۈرۈشتە خاتالىق كۆرۈلدى!'
        };
        $('#submit').click(function () {
            var frm = $(this).parent('form');
            $.ajax({
                type: 'post',
                dataType: 'json',
                url: 'Categories.aspx',
                data: frm.serialize(),
                success: function (d) {
                    if (d.result == 'ok') window.location.reload();
                    else if (d.result == 'no') {
                        var errors = d.errors;
                        errors.forEach(function (val, index) {
                            switch (val) {
                                case 'categoryid_null':
                                case 'category_null':
                                case 'title_null':
                                    _render('ctitle', msgs[val]);
                                    break;
                                case 'name_format':
                                case 'has_name': _render('cname', val[msgs]);
                                    break;
                                default: alert(msgs[val]);
                                    break;
                            }
                        })
                    }
                }, error: function () {
                    alert("Server Error Or Server Filed!");
                }
            });
        });

        function _render(id, msg) {
            $('#' + id).addClass('has-error').find('.help-block').html(msg).addClass('text-danger');
        }

        $('form .form-control').keypress(function () {
            if ($(this).parents('.form-group').hasClass('has-error')) $(this).parents('.form-group').removeClass('has-error');
            var _i = $(this).parents('.form-group').find('.help-block');
            _i.html(_i.attr('data-old'));
        });

        ///删除
        function _delete(cid) {
            if (!cid || cid <= 0) return;
            if (confirm('بۇ سەھىپىنى راستىنلا ئۆچۈرەمسىز؟')) {
                $.ajax({
                    type: 'post',
                    dataType: 'json',
                    url: '',
                    data: { 'CatID': cid, "Mode": 'delete' },
                    success: function (d, s) {
                        if (d.result == 'ok') window.location.reload();
                        else {
                            d.errors.forEach(function (val, index) {
                                alert(msgs[val]);
                            });
                        }
                    },
                    error: function (s) {
                        alert('Server Error Or Server Filed!');
                    }
                });
            }
        }
    </script>
</asp:Content>
