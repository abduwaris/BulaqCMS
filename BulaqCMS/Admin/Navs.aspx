<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/_Admin.Master" AutoEventWireup="true" CodeBehind="Navs.aspx.cs" Inherits="BulaqCMS.Admin.Navs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <style>
        .navs-list {
            margin-bottom: 20px;
        }

        .navs-list-item {
            display: block;
            vertical-align: top;
            line-height: 40px;
            margin-top: 10px;
            border: 1px solid #ddd;
            padding-right: 5px;
            /*width: 400px;*/
            cursor: pointer;
        }

            .navs-list-item:hover:not(.navs-list-item-haschild) {
                background-color: #f5f5f5;
            }

            .navs-list-item:hover > .navs-list-item-tools {
                display: block;
            }

            .navs-list-item:last-child {
                border-bottom-width: 1px;
            }

        .navs-list-item-tools {
            float: left;
            display: none;
        }


        .navs-list-item-tools-item {
            float: right;
            height: 40px;
            width: 40px;
            line-height: 40px;
            text-align: center;
            cursor: pointer;
        }

            .navs-list-item-tools-item .glyphicon {
                color: #666;
            }

            .navs-list-item-tools-item:hover {
                background: #ddd;
            }

            .navs-list-item-tools-item.nav-delete .glyphicon {
                color: #b92c28;
            }

            .navs-list-item-tools-item.nav-delete:hover {
                background: #b92c28;
            }

                .navs-list-item-tools-item.nav-delete:hover .glyphicon, .navs-list-item-tools-item.nav-visible:hover .glyphicon {
                    color: #fff;
                }

            .navs-list-item-tools-item.nav-visible .glyphicon {
                color: green;
            }

            .navs-list-item-tools-item.nav-visible:hover {
                background: green;
            }

        .navs-list-item.navs-list-item-haschild {
            padding-right: 40px;
            border-width: 0;
        }

            .navs-list-item.navs-list-item-haschild .navs-list {
                margin-bottom: 0;
            }

        .tab-content {
            padding: 10px 0;
        }

        .add-link, .add-tag {
            display: inline-block;
            height: 100%;
            cursor: pointer;
        }

            .add-link:hover, .add-tag:hover {
                color: #0094ff;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Container" runat="server">
    <h3 class="bulaq-header">تىزىملىكلەر</h3>
    <div class="bulaq-header">
        <div class="form-inline">
            <%--<input type="text" name="name" value="" class="form-control input-sm" placeholder="تىزىملىكلەر">--%>
            <select class="form-control input-sm">
                <%foreach (var navG in navGroups)
                  {%>
                <%:Html(string.Format("<option{0} value=\"{1}\">{2}</option>", navG.ID == navGroup.ID ? " selected=\"selected\"" : "", navG.Name, navG.Title))%>
                <%} %>
            </select>
            <input type="button" name="name" value="سۈزۈش" class="btn btn-primary btn-sm">
            <a class="btn btn-default btn-sm" href="#">تىزىملىك قورۇش</a>
        </div>
    </div>
    <%--<script>
        $(function () {
            Confirm('ھېچقانداق تىزىملىك تېپىلمىدى! تىزىملىك قۇرۇش بېتىگە كىرىپ تىزىملىك قورۇڭ!', 'تىزىملىك قۇرۇش ئەسكەرتىشى', function () { location.href = 'NavGroup.aspx'; }, function () { location.href = 'NavGroup.aspx'; });
        });
    </script>--%>
    <div class="row">
        <div class="col-sm-5">
            <div>
                <!-- Nav tabs -->
                <ul class="nav nav-tabs" role="tablist">
                    <li role="presentation" class="active"><a href="#from-links" aria-controls="from-links" role="tab" data-toggle="tab">ئۇلانما</a></li>
                    <li role="presentation"><a href="#from-categories" aria-controls="from-categories" role="tab" data-toggle="tab">سەھىپە</a></li>
                    <li role="presentation"><a href="#from-tags" aria-controls="from-tags" role="tab" data-toggle="tab">خەتكۈچ</a></li>
                    <li role="presentation"><a href="#from-posts" aria-controls="from-posts" role="tab" data-toggle="tab">يازما</a></li>
                    <li role="presentation"><a href="#from-pages" aria-controls="from-pages" role="tab" data-toggle="tab">بەت</a></li>
                    <li role="presentation"><a href="#from-custom" aria-controls="from-custom" role="tab" data-toggle="tab">ئىختىيارى</a></li>
                </ul>

                <!-- Tab panes -->
                <div class="tab-content">
                    <div role="tabpanel" class="tab-pane active" id="from-links">
                        <%if (allLinks.Count > 0)
                          { %>
                        <table class="table table-hover">
                            <%foreach (var link in allLinks)
                              {%>
                            <tr>
                                <td><%:link.Title %></td>
                                <td width="40"><span data-linkid="<%:link.ID %>" class="add-link glyphicon glyphicon-plus"></span></td>
                            </tr>
                            <% } %>
                        </table>
                        <%} %>
                    </div>
                    <div role="tabpanel" class="tab-pane" id="from-categories">
                        <%:CreateCategories() %>
                    </div>
                    <div role="tabpanel" class="tab-pane" id="from-tags">
                        <%if (allTags.Count > 0)
                          { %>
                        <table class="table table-hover">
                            <%foreach (var tag in allTags)
                              {%>
                            <tr>
                                <td><%:tag.Title %></td>
                                <td width="40"><span data-tagid="<%:tag.ID %>" class="add-tag glyphicon glyphicon-plus"></span></td>
                            </tr>
                            <% } %>
                        </table>
                        <%} %>
                    </div>
                    <div role="tabpanel" class="tab-pane" id="from-posts">
                        <table class="table table-hover">
                            <tr>
                                <td>يېڭى ئۇلانما</td>
                                <td width="40"><span class="glyphicon glyphicon-plus"></span></td>
                            </tr>
                            <tr>
                                <td>يېڭى ئۇلانما</td>
                                <td width="40"><span class="glyphicon glyphicon-plus"></span></td>
                            </tr>
                            <tr>
                                <td>يېڭى ئۇلانما</td>
                                <td width="40"><span class="glyphicon glyphicon-plus"></span></td>
                            </tr>
                            <tr>
                                <td>يېڭى ئۇلانما</td>
                                <td width="40"><span class="glyphicon glyphicon-plus"></span></td>
                            </tr>
                            <tr>
                                <td>يېڭى ئۇلانما</td>
                                <td width="40"><span class="glyphicon glyphicon-plus"></span></td>
                            </tr>
                            <tr>
                                <td>يېڭى ئۇلانما</td>
                                <td width="40"><span class="glyphicon glyphicon-plus"></span></td>
                            </tr>
                            <tr>
                                <td>يېڭى ئۇلانما</td>
                                <td width="40"><span class="glyphicon glyphicon-plus"></span></td>
                            </tr>
                            <tr>
                                <td>يېڭى ئۇلانما</td>
                                <td width="40"><span class="glyphicon glyphicon-plus"></span></td>
                            </tr>
                            <tr>
                                <td>يېڭى ئۇلانما</td>
                                <td width="40"><span class="glyphicon glyphicon-plus"></span></td>
                            </tr>
                            <tr>
                                <td>يېڭى ئۇلانما</td>
                                <td width="40"><span class="glyphicon glyphicon-plus"></span></td>
                            </tr>
                            <tr>
                                <td>يېڭى ئۇلانما</td>
                                <td width="40"><span class="glyphicon glyphicon-plus"></span></td>
                            </tr>
                            <tr>
                                <td>يېڭى ئۇلانما</td>
                                <td width="40"><span class="glyphicon glyphicon-plus"></span></td>
                            </tr>
                            <tr>
                                <td>يېڭى ئۇلانما</td>
                                <td width="40"><span class="glyphicon glyphicon-plus"></span></td>
                            </tr>
                            <tr>
                                <td>يېڭى ئۇلانما</td>
                                <td width="40"><span class="glyphicon glyphicon-plus"></span></td>
                            </tr>
                        </table>
                        <ul class="pagination pagination-sm">
                            <li><a href="?page=1">1</a></li>
                            <li><a href="?page=1">2</a></li>
                            <li><a href="?page=1">3</a></li>
                            <li><a href="?page=1">4</a></li>
                            <li><a href="?page=1">5</a></li>
                            <li><a href="?page=1">6</a></li>
                            <li><a href="?page=1">7</a></li>
                            <li><a href="?page=1">8</a></li>
                        </ul>
                    </div>
                    <div role="tabpanel" class="tab-pane" id="from-pages">
                        <table class="table table-hover">
                            <tr>
                                <td>يېڭى ئۇلانما</td>
                                <td width="40"><span class="glyphicon glyphicon-plus"></span></td>
                            </tr>
                            <tr>
                                <td>يېڭى ئۇلانما</td>
                                <td width="40"><span class="glyphicon glyphicon-plus"></span></td>
                            </tr>
                            <tr>
                                <td>يېڭى ئۇلانما</td>
                                <td width="40"><span class="glyphicon glyphicon-plus"></span></td>
                            </tr>
                            <tr>
                                <td>يېڭى ئۇلانما</td>
                                <td width="40"><span class="glyphicon glyphicon-plus"></span></td>
                            </tr>
                            <tr>
                                <td>يېڭى ئۇلانما</td>
                                <td width="40"><span class="glyphicon glyphicon-plus"></span></td>
                            </tr>
                            <tr>
                                <td>يېڭى ئۇلانما</td>
                                <td width="40"><span class="glyphicon glyphicon-plus"></span></td>
                            </tr>
                            <tr>
                                <td>يېڭى ئۇلانما</td>
                                <td width="40"><span class="glyphicon glyphicon-plus"></span></td>
                            </tr>
                            <tr>
                                <td>يېڭى ئۇلانما</td>
                                <td width="40"><span class="glyphicon glyphicon-plus"></span></td>
                            </tr>
                            <tr>
                                <td>يېڭى ئۇلانما</td>
                                <td width="40"><span class="glyphicon glyphicon-plus"></span></td>
                            </tr>
                            <tr>
                                <td>يېڭى ئۇلانما</td>
                                <td width="40"><span class="glyphicon glyphicon-plus"></span></td>
                            </tr>
                            <tr>
                                <td>يېڭى ئۇلانما</td>
                                <td width="40"><span class="glyphicon glyphicon-plus"></span></td>
                            </tr>
                            <tr>
                                <td>يېڭى ئۇلانما</td>
                                <td width="40"><span class="glyphicon glyphicon-plus"></span></td>
                            </tr>
                            <tr>
                                <td>يېڭى ئۇلانما</td>
                                <td width="40"><span class="glyphicon glyphicon-plus"></span></td>
                            </tr>
                            <tr>
                                <td>يېڭى ئۇلانما</td>
                                <td width="40"><span class="glyphicon glyphicon-plus"></span></td>
                            </tr>
                        </table>
                    </div>
                    <div role="tabpanel" class="tab-pane" id="from-custom">ئىختىيارى</div>
                </div>

            </div>
        </div>
        <div class="col-sm-7">
            <div class="bulaq-header clearfix">
                <%:navGroup.Title %>
                <div class="form-inline f-left">
                    <a class="btn btn-info btn-sm" href="#">كۆچۈرۈش</a>
                    <a class="btn btn-danger btn-sm" href="#">ئۆچۈرۈش</a>
                </div>
            </div>
            <%:CreateNavs() %>

            <%--<ul class="navs-list">
                <li class="navs-list-item">سالام دۇنيا
                    <ul class="navs-list-item-tools clearfix">
                        <li class="navs-list-item-tools-item" data-to="right" data-nav="2"><span class="glyphicon glyphicon-arrow-right"></span></li>
                        <li class="navs-list-item-tools-item" data-to="up" data-nav="2"><span class="glyphicon glyphicon-arrow-up"></span></li>
                        <li class="navs-list-item-tools-item" data-to="down" data-nav="2"><span class="glyphicon glyphicon-arrow-down"></span></li>
                        <li class="navs-list-item-tools-item" data-to="left" data-nav="2"><span class="glyphicon glyphicon-arrow-left"></span></li>
                        <li class="navs-list-item-tools-item" data-to="left" data-nav="2"><span class="glyphicon glyphicon-chevron-down"></span></li>
                    </ul>
                </li>
                <li class="navs-list-item">سالام دۇنيا
                    <ul class="navs-list-item-tools clearfix">
                        <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-up"></span></li>
                        <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-down"></span></li>
                        <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-right"></span></li>
                        <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-left"></span></li>
                    </ul>
                </li>
                <li class="navs-list-item">سالام دۇنيا
                    <ul class="navs-list-item-tools clearfix">
                        <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-up"></span></li>
                        <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-down"></span></li>
                        <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-right"></span></li>
                        <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-left"></span></li>
                    </ul>
                </li>
                <li class="navs-list-item navs-list-item-haschild">
                    <ul class="navs-list">
                        <li class="navs-list-item">سالام دۇنيا
                            <ul class="navs-list-item-tools clearfix">
                                <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-up"></span></li>
                                <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-down"></span></li>
                                <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-right"></span></li>
                                <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-left"></span></li>
                            </ul>
                        </li>
                        <li class="navs-list-item navs-list-item-haschild">
                            <ul class="navs-list">
                                <li class="navs-list-item">سالام دۇنيا
                                    <ul class="navs-list-item-tools clearfix">
                                        <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-up"></span></li>
                                        <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-down"></span></li>
                                        <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-right"></span></li>
                                        <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-left"></span></li>
                                    </ul>
                                </li>
                                <li class="navs-list-item">سالام دۇنيا
                                    <ul class="navs-list-item-tools clearfix">
                                        <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-up"></span></li>
                                        <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-down"></span></li>
                                        <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-right"></span></li>
                                        <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-left"></span></li>
                                    </ul>
                                </li>
                                <li class="navs-list-item">سالام دۇنيا
                                    <ul class="navs-list-item-tools clearfix">
                                        <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-up"></span></li>
                                        <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-down"></span></li>
                                        <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-right"></span></li>
                                        <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-left"></span></li>
                                    </ul>
                                </li>
                            </ul>
                        </li>
                        <li class="navs-list-item">سالام دۇنيا
                            <ul class="navs-list-item-tools clearfix">
                                <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-up"></span></li>
                                <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-down"></span></li>
                                <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-right"></span></li>
                                <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-left"></span></li>
                            </ul>
                        </li>
                    </ul>
                </li>
                <li class="navs-list-item">سالام دۇنيا
                    <ul class="navs-list-item-tools clearfix">
                        <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-up"></span></li>
                        <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-down"></span></li>
                        <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-right"></span></li>
                        <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-left"></span></li>
                    </ul>
                </li>
                <li class="navs-list-item">سالام دۇنيا
                    <ul class="navs-list-item-tools clearfix">
                        <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-up"></span></li>
                        <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-down"></span></li>
                        <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-right"></span></li>
                        <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-left"></span></li>
                    </ul>
                    s
                </li>
                <li class="navs-list-item">سالام دۇنيا
                    <ul class="navs-list-item-tools clearfix">
                        <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-up"></span></li>
                        <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-down"></span></li>
                        <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-right"></span></li>
                        <li class="navs-list-item-tools-item"><span class="glyphicon glyphicon-arrow-left"></span></li>
                    </ul>
                </li>
            </ul>--%>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BeforeBody" runat="server">
    <script>

        var navGroupName = '<%:navGroup.Name%>';

        var msgs = {
            'server_error': 'مۇلازىمىتىردا خاتالىق كۆرۈلدى!',
            'navgroup_null': 'تىزىملىك مەۋجۇت ئەمەس!',
            'link_null': 'ئۇلانما مەۋجۇت ئەمەس ياكى يۇشۇرۇن ھالەتتە!',
            'on_link_to_nav_error': 'ئۇلانمىدىن تىزىملىك قۇرۇشتا خاتالىق كۆرۈلدى!',
            'category_null': 'سەھىپە مەۋجۇت ئەمەس!',
            'on_category_to_nav_error': 'سەھىپىدىن تىزىملىك قۇرۇشتا خاتالىق كۆرۈلدى!',
            'tag_null': 'خەتكۈچ مەۋجۇت ئەمەس!',
            'on_tag_to_nav_error': 'خەتكۈچتىن تىزىملىك قۇرۇشتا خاتالىق كۆرۈلدى!',
            '': '',
            '': '',
            '': '',
            '': '',
            '': '',
            '': '',
        };

        ///处理
        function _post(_action, objectId) {
            if (!objectId || objectId <= 0) return;
            $.post('Navs.aspx', { 'action': _action, 'NavGroup': navGroupName, 'ObjectID': objectId }, function (d) {
                if (d.result == 'ok') alertTip('تىزىملىك قۇرۇلدى!', function () { location.reload(); });
                else {
                    alertTip(msgs[d['error']], 'danger');
                }
            }, 'json').error(function () { alertTip(msgs.server_error, 'danger') });
        }

        //添加链接
        $('.add-link').click(function () {
            var linkId = $(this).attr('data-linkid');
            _post('from-link-nav', linkId);
        });

        //添加文章专辑
        $('.add-category').click(function () {
            var catId = $(this).attr('data-categoryid');
            _post('from-category-nav', catId);
        });

        //添加标签
        $('.add-tag').click(function () {
            var tagId = $(this).attr('data-tagid');
            _post('from-tag-nav', tagId);
        });


        ///移动
        $('.navs-list-item-tools-item[data-moveto]').click(function () {
            var moveto = $(this).attr('data-moveto');
            var navId = $(this).attr('data-nav');
            if (moveto != 'up' && moveto != 'down' && moveto != 'in' && moveto != 'out') return;
            if (!navId || navId <= 0) return;
            _post('move_' + moveto, navId);

        });

        //删除
        $('.nav-delete').click(function () {
            var navId = $(this).attr('data-nav');
            _post('delete', navId);
        })

    </script>
</asp:Content>
