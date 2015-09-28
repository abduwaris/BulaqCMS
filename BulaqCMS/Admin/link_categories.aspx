<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/_Admin.Master" AutoEventWireup="true" CodeBehind="link_categories.aspx.cs" Inherits="BulaqCMS.Admin.link_categories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Container" runat="server">
    <h3 class="bulaq-header">ئۇلانما سەھىپىللىرى</h3>
    <div class="row">
        <div class="col-sm-4">
            <p><strong>يېڭىدىن ئۇلانما سەھىپىسى قوشۇش</strong></p>
            <i class="help-block">ئۇلانما سەھىپىللىرى ئادەتتە ئۇلانمىلارنى پەرقلەندۈرۈش ئۈچۈن گۇرۇپپىلاشنى كۆرسىتىدۇ. ئۇلانما سەھىپىسىنى قۇرمايمۇ ئۇلانما قۇرغىلى بۇلىدۇ.</i>
            <form>
                <div class="form-group">
                    <label>نامى</label>
                    <input type="text" class="form-control input-sm" placeholder="نامى">
                    <i class="help-block">تور بېتىڭىزدە مۇشۇ نامدا كۆرسىتىلىدىغان بۇلۇپ يەككىلىككە ئىگە ئەمەس. ھەرقانداق ھەرىپ بەلگىلەرنى قوللايدۇ.</i>
                </div>
                <div class="form-group">
                    <label>ئۇلانما سەھىپىسى باشقا نامى</label>
                    <input type="text" class="form-control input-sm text-ltr" placeholder="ئۇلانما سەھىپىسى باشقا نامى">
                    <i class="help-block">«ئۇلانما سەھىپىسى باشقا نامى» بولسا ئۇلىنىش ئىچىدە ئىشلىتىلىدىغان نام بۇلۇپ، يەككلىلىككە ئىگە.
                    </i>
                </div>

                <div class="form-group">
                    <label>چۈشەندۈرۈش</label>
                    <textarea class="form-control" rows="5" placeholder="ئۇلانما سەھىپىسى ئۈچۈن چۈشەندۈرۈش بىرىڭ"></textarea>
                    <i class="help-block">بۇ ئۇلانما سەھىپىسى ئۈچۈن بىر ئىككى ئېغىز چۈشەندۈرۈش بىرىڭ.</i>
                </div>
                <button type="submit" class="btn btn-primary">قوشۇش</button>
            </form>
        </div>
        <div class="col-sm-8">
            <div class="clearfix bulaq-header">
                <div class="form-inline f-left">
                    <input type="text" name="name" value="" class="form-control input-sm" placeholder="ئۇلانما سەھىپىسىنى ئىزدەپ بېقىڭ" />
                    <input type="button" name="name" value="ئىزدەش" class="btn btn-primary btn-sm" />
                </div>
            </div>
            <table class="table table-hover table-striped table-bordered">
                <thead>
                    <tr>
                        <th>ئۇلانما سەھىپىسى نامى</th>
                        <th width="180">ئۇلانما سەھىپىسى باشقا نامى</th>
                        <th>چۈشەندۈرۈلۈشى</th>
                        <th width="100">ئۇلانمىلار</th>
                    </tr>
                </thead>
                <tbody class="items-list">
                    <tr>
                        <td>پىروگىرامما</td>
                        <td>
                            <span class="text-ltr">program/mybaby</span>
                        </td>
                        <td class="tools-p">بۇ بىر سىناق سەھىپە، ساندانغا يېزىلمىغان.
                                    <div class="tools">
                                        <div class="btn-group">
                                            <input type="button" name="name" value="تەھرىرلەش" class="btn btn-primary btn-xs" />
                                            <input type="button" name="name" value="تىز تەھرىرلەش" class="btn btn-info btn-xs" />
                                            <input type="button" name="name" value="ئۆچۈرۈش" class="btn btn-danger btn-xs" />
                                            <input type="button" name="name" value="كۆرۈش" class="btn btn-default btn-xs" />
                                        </div>
                                    </div>
                        </td>
                        <td><a href="#" class="badge">15</a></td>
                    </tr>
                    <tr>
                        <td>پىروگىرامما</td>
                        <td>program</td>
                        <td class="tools-p">بۇ بىر سىناق سەھىپە، ساندانغا يېزىلمىغان.
                                    <div class="tools">
                                        <div class="btn-group">
                                            <input type="button" name="name" value="تەھرىرلەش" class="btn btn-primary btn-xs" />
                                            <input type="button" name="name" value="تىز تەھرىرلەش" class="btn btn-info btn-xs" />
                                            <input type="button" name="name" value="ئۆچۈرۈش" class="btn btn-danger btn-xs" />
                                            <input type="button" name="name" value="كۆرۈش" class="btn btn-default btn-xs" />
                                        </div>
                                    </div>
                        </td>
                        <td><a href="#" class="badge">15</a></td>
                    </tr>
                    <tr>
                        <td>پىروگىرامما</td>
                        <td>program</td>
                        <td class="tools-p">بۇ بىر سىناق سەھىپە، ساندانغا يېزىلمىغان.
                                    <div class="tools">
                                        <div class="btn-group">
                                            <input type="button" name="name" value="تەھرىرلەش" class="btn btn-primary btn-xs" />
                                            <input type="button" name="name" value="تىز تەھرىرلەش" class="btn btn-info btn-xs" />
                                            <input type="button" name="name" value="ئۆچۈرۈش" class="btn btn-danger btn-xs" />
                                            <input type="button" name="name" value="كۆرۈش" class="btn btn-default btn-xs" />
                                        </div>
                                    </div>
                        </td>
                        <td><a href="#" class="badge">15</a></td>
                    </tr>
                    <tr>
                        <td class="tools-p">بۇ بىر سىناق سەھىپە، ساندانغا يېزىلمىغان.
                                    <div class="tools">
                                        <div class="btn-group">
                                            <input type="button" name="name" value="تەھرىرلەش" class="btn btn-primary btn-xs" />
                                            <input type="button" name="name" value="تىز تەھرىرلەش" class="btn btn-info btn-xs" />
                                            <input type="button" name="name" value="ئۆچۈرۈش" class="btn btn-danger btn-xs" />
                                            <input type="button" name="name" value="كۆرۈش" class="btn btn-default btn-xs" />
                                        </div>
                                    </div>
                        </td>
                        <td>program</td>
                        <td>بۇ بىر سىناق سەھىپە، ساندانغا يېزىلمىغان.</td>
                        <td><a href="#" class="badge">15</a></td>
                    </tr>
                </tbody>
            </table>
            <p class="help-block">
                ئۇلانما سەھىپىسنىڭ ئۆچۈرۈلىشى ئۇنىڭدىكى ئۇلانمىلارغا تەسىر قىلمايدۇ.
            </p>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BeforeBody" runat="server">
</asp:Content>
