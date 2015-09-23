<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/_Admin.Master" AutoEventWireup="true" CodeBehind="Editor.aspx.cs" Inherits="BulaqCMS.Admin.Editor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link href="/Admin/Content/Editor/themes/default/css/umeditor.css" rel="stylesheet" />
    <script src="/Admin/Scripts/Editor/umeditor.config.js"></script>
    <script src="Scripts/Editor/umeditor.min.js"></script>
    <script src="Scripts/Editor/lang/zh-cn/zh-cn.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Container" runat="server">
    <h3 class="bulaq-header">يېڭى يازما قوشۇش</h3>
    <div class="row">
        <div class="col-sm-9">
            <form action="/" method="post">
                <div class="form-group">
                    <input type="text" name="title" value="" class="form-control input-lg" placeholder="يازما تىمىسىنى بۇ يەرگە يېزىڭ" />
                </div>
                <div class="form-inline" style="margin-bottom: 10px">
                    <div class="form-group">
                        <span class="text-ltr"><code>http://localhost:8080/p/</code>
                            <input type="text" name="name" value="" class="form-control input-sm" />
                        </span>
                    </div>
                    <div class="form-group">
                        <input type="button" name="name" value="ئۇلانمىلارنى تەڭشەش" class="btn btn-default btn-xs" />
                    </div>
                    <div class="form-group">
                        <input type="button" name="name" value="يازمىنى كۆرۈپ بېقىش" class="btn btn-default btn-xs" />
                    </div>
                </div>
                <div class="form-group">
                    <textarea class="form-control" style="height:400px;" id="postContent"></textarea>
                </div>
                <div class="form-group">
                    <input type="button" name="submit" value="ساقلاش" class="btn btn-primary btn-lg" />
                </div>
            </form>
        </div>
        <div class="col-sm-3">
            <div class="panel panel-default">
                <div class="panel-heading">ئىلان قىلىش</div>
                <div class="panel-body">
                    <div class="clearfix">
                        <input type="button" name="name" value="ئارگىنال ساقلاش" class="btn btn-sm btn-success f-right" />
                        <a href="#" class="btn btn-sm btn-default f-left">كۆرۈپ بېقىش</a>
                    </div>
                    <div class="radio">
                        <label>
                            <input type="radio" name="visible" value="1" />
                            ھەممىگە كۆرسىتىلسۇن
                        </label>
                    </div>
                    <div class="radio">
                        <label>
                            <input type="radio" name="visible" value="2" />
                            توردىكىلەرگە كۆرۈنسۇن
                        </label>
                    </div>
                    <div class="radio">
                        <label>
                            <input type="radio" name="visible" value="3" />
                            شەخسىي
                        </label>
                    </div>
                    <div class="radio">
                        <label>
                            <input type="radio" name="visible" value="4" />
                            يۇشۇرۇن
                        </label>
                    </div>
                </div>
                <div class="panel-footer clearfix">
                    <input type="button" name="name" value="ئىلان قىلىش" class="btn btn-primary btn-sm f-right" />
                    <input type="button" name="name" value="ئەخلەت ساندۇقىغا يۆتكەش" class="btn btn-danger btn-sm f-left" />
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">سەھىپىلەر</div>
                <div class="panel-body" style="max-height: 200px; overflow-y: scroll">
                    <div class="checkbox">
                        <label>
                            <input type="checkbox" name="name" value="true" />
                            پىروگىراممىلار
                        </label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <input type="checkbox" name="name" value="true" />
                            پىروگىراممىلار
                        </label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <input type="checkbox" name="name" value="true" />
                            پىروگىراممىلار
                        </label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <input type="checkbox" name="name" value="true" />
                            پىروگىراممىلار
                        </label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <input type="checkbox" name="name" value="true" />
                            پىروگىراممىلار
                        </label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <input type="checkbox" name="name" value="true" />
                            پىروگىراممىلار
                        </label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <input type="checkbox" name="name" value="true" />
                            پىروگىراممىلار
                        </label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <input type="checkbox" name="name" value="true" />
                            پىروگىراممىلار
                        </label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <input type="checkbox" name="name" value="true" />
                            پىروگىراممىلار
                        </label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <input type="checkbox" name="name" value="true" />
                            پىروگىراممىلار
                        </label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <input type="checkbox" name="name" value="true" />
                            پىروگىراممىلار
                        </label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <input type="checkbox" name="name" value="true" />
                            پىروگىراممىلار
                        </label>
                    </div>
                </div>
                <div class="panel-footer">
                    <input type="button" name="name" value="ساقلاش" class="btn btn-primary btn-sm" />
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">خەتكۈچلەر</div>
                <div class="panel-body">
                    <div class="form-inline">
                        <div class="form-group">
                            <input type="email" class="form-control input-sm" placeholder="خەتكۈچلەر">
                        </div>
                        <div class="form-group">
                            <input type="button" name="name" value="قوشۇش" class="btn btn-default btn-sm" />
                        </div>
                        <div>
                            <i>كۆپ خەتكۈچلەرنى پەش بىلەن ئايرىپ يېزىڭ</i>
                        </div>
                        <div class="post-tags">
                            <div class="form-group">
                                <input type="hidden" name="name" value="tags-0" />
                                <i class="form-control input-sm">پىروگىراممىلار<span class="glyphicon glyphicon-remove remove-tag-icon"></span></i>
                            </div>
                            <div class="form-group">
                                <input type="hidden" name="name" value="tags-0" />
                                <i class="form-control input-sm">پىروگىراممىلار<span class="glyphicon glyphicon-remove remove-tag-icon"></span></i>
                            </div>
                            <div class="form-group">
                                <input type="hidden" name="name" value="tags-0" />
                                <i class="form-control input-sm">پىروگىراممىلار<span class="glyphicon glyphicon-remove remove-tag-icon"></span></i>
                            </div>
                            <div class="form-group">
                                <input type="hidden" name="name" value="tags-0" />
                                <i class="form-control input-sm">پىروگىراممىلار<span class="glyphicon glyphicon-remove remove-tag-icon"></span></i>
                            </div>
                        </div>
                    </div>
                    <a href="#" class="btn btn-link">ئاۋات خەتكۈچلەرنى تاللاش</a>
                </div>
                <div class="panel-footer">
                    <input type="button" name="name" value="ساقلاش" class="btn btn-primary btn-sm" />
                </div>
            </div>
            <div class="panel panel-default">
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
    </script>
</asp:Content>

