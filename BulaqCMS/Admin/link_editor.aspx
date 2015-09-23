<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/_Admin.Master" AutoEventWireup="true" CodeBehind="link_editor.aspx.cs" Inherits="BulaqCMS.Admin.link_editor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Container" runat="server">
    <h3 class="bulaq-header">يېڭى ئۇلانما قوشۇش</h3>
            <div class="row">
                <div class="col-sm-9">
                    <form>
                        <div class="form-group">
                            <label>نامى</label>
                            <input type="text" class="form-control input-sm" placeholder="نامى">
                            <i class="help-block">تور بېتىڭىزدە مۇشۇ نامدا كۆرسىتىلىدىغان بۇلۇپ يەككىلىككە ئىگە ئەمەس. ھەرقانداق ھەرىپ بەلگىلەرنى قوللايدۇ.</i>
                        </div>
                        <div class="form-group">
                            <label>ئۇلانما باشقا نامى</label>
                            <input type="text" class="form-control input-sm text-ltr" placeholder="ئۇلانما باشقا نامى">
                            <i class="help-block">
                                «ئۇلانما باشقا نامى» بولسا ئۇلىنىش ئىچىدە ئىشلىتىلىدىغان نام بۇلۇپ، يەككلىلىككە ئىگە.
                            </i>
                        </div>
                        <div class="form-group">
                            <label>ئۇلانما ئادرىسى</label>
                            <input type="text" name="name" value=" " class="form-control input-sm text-ltr" placeholder="ئۇلانما ئادرىسى" />
                            <i class="help-block">
                                سىرتقى ئۇلىنىش قىلىش ئۈچۈن <code class="text-ltr">http://</code> ياكى <code class="text-ltr">https://</code> بىلەن باشلاپ يېزىڭ. مەسىلەن <code class="text-ltr">http://www.bulaq.net</code> دىگەندەك. مۇشۇنداق بولغاندا ئىچكى ئۇلىنىشلار بىلەن تۇقۇنۇشۇپ قالمايدۇ. قالغانلىرى تور كۆرگۈچنىڭ قانداق ئانالىز قىلىشىغا باغلىق.
                            </i>
                        </div>
                        <div class="form-group">
                            <label>چۈشەندۈرۈش</label>
                            <textarea class="form-control" rows="5" placeholder="ئۇلانما ئۈچۈن چۈشەندۈرۈش بىرىڭ"></textarea>
                            <i class="help-block">بۇ ئۇلانما ئۈچۈن بىر ئىككى ئېغىز چۈشەندۈرۈش بىرىڭ.</i>
                        </div>
                        <button type="submit" class="btn btn-primary">قوشۇش</button>
                    </form>
                </div>
                <div class="col-sm-3">
                    <div class="panel panel-default">
                        <div class="panel-heading">ئۇلانما سەھىپىسى</div>
                        <div class="panel-body">
                            <div class="form-group">
                                <select class="form-control input-sm">
                                    <option value="value">ئۇلانما سەھىپىسىنى تاللاڭ</option>
                                </select>
                            </div>
                            <div class="row form-group" style="margin-left:0;">
                                <div class="col-sm-10">
                                    <input type="text" name="name" value="" class="form-control input-sm" placeholder="سەھىپە نامى" />
                                </div>
                                <div class="col-sm-2">
                                    <input type="button" name="name" value="قۇرۇش" class="btn btn-default btn-sm" />
                                </div>
                            </div>
                            <input type="button" name="name" value="يېڭىدىن سەھىپە قورۇش" class="btn btn-default btn-sm btn-block" />
                            <i class="help-block text-justify">
                                «ئۇلانما سەھىپىسى» بولسا ئۇلانمىلارنى پەرقلەندۈرۈش ئۈچۈن ئىشلىتىلىدىغان گۇرۇپپىلاش شەكلى بۇلۇپ، تاللانسىمۇ تاللانمىسىمۇ بۇلىدۇ. ئىھتىياجىڭىزغا قاراپ تاللاش تاللىماسلىقنى بىكىتسىڭىز بۇلىدۇ.
                            </i>
                        </div>
                        <div class="panel-footer">
                            <input type="button" name="name" value="ساقلاش" class="btn btn-primary btn-sm" />
                        </div>
                    </div>

                    <div class="panel panel-default">
                        <div class="panel-heading">ئوبيېكت</div>
                        <div class="panel-body">
                            <div class="radio">
                                <label>
                                    <input type="radio" name="visible" value="1">
                                    <code class="text-ltr">_blank</code>&nbsp;&nbsp;&nbsp;يېڭى كۆزنەك ياكى بەتكۈچ.
                                </label>
                            </div>
                            <div class="radio">
                                <label>
                                    <input type="radio" name="visible" value="2">
                                    <code class="text-ltr">_top</code>&nbsp;&nbsp;&nbsp;نۆۋەتتىكى كۆزنەك ياكى بەتكۈچ، رامكىسىز.
                                </label>
                            </div>
                            <div class="radio">
                                <label>
                                    <input type="radio" name="visible" value="3">
                                    <code class="text-ltr">_self</code>&nbsp;&nbsp;&nbsp;ئوخشاش كۆزنەك ياكى بەتكۈچ.
                                </label>
                            </div>
                            <div class="radio">
                                <label>
                                    <input type="radio" name="visible" value="3">
                                    <code class="text-ltr">_parent</code>&nbsp;&nbsp;&nbsp;ئوخشاش كۆزنەك ياكى بەتكۈچنىڭ ئاتا بەتكۈچى ياكى كۆزنىكى.
                                </label>
                            </div>
                            <div class="radio">
                                <label>
                                    <input type="radio" name="visible" value="3">
                                    <code class="text-ltr">_none</code>&nbsp;&nbsp;&nbsp;ئوخشاش كۆزنەك ياكى بەتكۈچ.
                                </label>
                            </div>
                            <i class="help-block text-justify">
                                «ئوبيېكت» بولسا ئۇلانمىنىڭ قايسى شەكىلدە ئېچىلىدىغانلىقىنى كۆرسىتىدۇ.
                            </i>
                        </div>
                        <div class="panel-footer">
                            <input type="button" name="name" value="ساقلاش" class="btn btn-primary btn-sm">
                        </div>
                    </div>

                    <div class="panel panel-default">
                        <div class="panel-heading">سۈرەت</div>
                        <div class="panel-body">
                            <div class="text-center">
                                <img src="http://tohpikar.com/temp/home/images/tohpikar_logo.png" alt="" style="height:auto;width:100%" />
                            </div>
                            <div class="text-center" style="margin-top:10px;margin-bottom:10px">
                                <input type="button" name="name" value="media ئامبىرىدىن رەسىم تاللاش" class="btn btn-default btn-sm" />
                            </div>

                            <div class="row" style="margin-left:0;">
                                <div class="col-sm-10">
                                    <input type="text" name="name" value="" class="form-control input-sm text-ltr" placeholder="رەسىم تۇلۇق ئادرىسى" />
                                </div>
                                <div class="col-sm-2">
                                    <input type="button" name="name" value="بولدى" class="btn btn-primary btn-sm" />
                                </div>
                            </div>
                            <i class="help-block text-justify">
                                «سۈرەت» بولسا ئۇلانما ئۈچۈن تور بەتتە كۆرسىتىلىدىغان رەسىم بۇلۇپ، سۈرەت تاللانمىسا ياكى تۈۋەندىكى ئادرىس قۇرۇق بولسا سىستىما تەمىنلىگەن سۈكۈتتىكى سۈرەتنى ئىشلىتىدۇ. تور بېتىڭىزدە سۈرەتنىڭ نۇرمال كۆرۈنۈشى ئۈچۈن سۈرەتنى Media ئامبىرىدىن تاللاڭ.
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
</asp:Content>
