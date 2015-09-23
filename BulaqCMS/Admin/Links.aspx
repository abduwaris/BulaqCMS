<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/_Admin.Master" AutoEventWireup="true" CodeBehind="Links.aspx.cs" Inherits="BulaqCMS.Admin.Links" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Container" runat="server">
    <h3 class="bulaq-header">ئۇلانمىلار  <a href="#" class="btn btn-primary btn-xs">يېڭىدىن قوشۇش</a></h3>
            <div class="bulaq-header">
                <div class="form-inline">
                    <div class="form-group">
                        <select class="form-control input-sm">
                            <option value="value">سەھىپىسىنى تاللاڭ</option>
                        </select>
                        <input type="button" name="name" value="سۈزۈش" class="btn btn-sm btn-primary"/>
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
                            <th>ئۇلانما نامى</th>
                            <th width="180">ئۇلانما باشقا نامى</th>
                            <th width="300">ئادرىسى</th>
                            <th>چۈشەندۈرۈلۈشى</th>
                            <th width="80">كۆرۈنۈش</th>
                        </tr>
                    </thead>
                    <tbody class="items-list">
                        <tr>
                            <td>پىروگىرامما</td>
                            <td>
                                <span class="text-ltr">program</span>
                            </td>
                            <td>
                                <a href="#">http://www.bulaq.net/logo.gif</a>
                            </td>
                            <td class="tools-p">
                                بۇ بىر سىناق سەھىپە، ساندانغا يېزىلمىغان.
                                <div class="tools">
                                    <div class="btn-group">
                                        <input type="button" name="name" value="تەھرىرلەش" class="btn btn-primary btn-xs" />
                                        <input type="button" name="name" value="تىز تەھرىرلەش" class="btn btn-info btn-xs" />
                                        <input type="button" name="name" value="ئۆچۈرۈش" class="btn btn-danger btn-xs" />
                                        <input type="button" name="name" value="كۆرۈش" class="btn btn-default btn-xs" />
                                    </div>
                                </div>
                            </td>
                            <td><a href="#" class="badge">يۇشۇرۇن</a></td>
                        </tr>
                        <tr>
                            <td>پىروگىرامما</td>
                            <td>
                                <span class="text-ltr">program</span>
                            </td>
                            <td>
                                <a href="#">http://www.bulaq.net/logo.gif</a>
                            </td>
                            <td class="tools-p">
                                بۇ بىر سىناق سەھىپە، ساندانغا يېزىلمىغان.
                                <div class="tools">
                                    <div class="btn-group">
                                        <input type="button" name="name" value="تەھرىرلەش" class="btn btn-primary btn-xs" />
                                        <input type="button" name="name" value="تىز تەھرىرلەش" class="btn btn-info btn-xs" />
                                        <input type="button" name="name" value="ئۆچۈرۈش" class="btn btn-danger btn-xs" />
                                        <input type="button" name="name" value="كۆرۈش" class="btn btn-default btn-xs" />
                                    </div>
                                </div>
                            </td>
                            <td><a href="#" class="badge">ئاشكارا</a></td>
                        </tr>
                        <tr>
                            <td>پىروگىرامما</td>
                            <td>
                                <span class="text-ltr">program</span>
                            </td>
                            <td>
                                <a href="#">http://www.bulaq.net/logo.gif</a>
                            </td>
                            <td class="tools-p">
                                بۇ بىر سىناق سەھىپە، ساندانغا يېزىلمىغان.
                                <div class="tools">
                                    <div class="btn-group">
                                        <input type="button" name="name" value="تەھرىرلەش" class="btn btn-primary btn-xs" />
                                        <input type="button" name="name" value="تىز تەھرىرلەش" class="btn btn-info btn-xs" />
                                        <input type="button" name="name" value="ئۆچۈرۈش" class="btn btn-danger btn-xs" />
                                        <input type="button" name="name" value="كۆرۈش" class="btn btn-default btn-xs" />
                                    </div>
                                </div>
                            </td>
                            <td><a href="#" class="badge">يۇشۇرۇن</a></td>
                        </tr>
                        <tr>
                            <td>پىروگىرامما</td>
                            <td>
                                <span class="text-ltr">program</span>
                            </td>
                            <td>
                                <a href="#">http://www.bulaq.net/logo.gif</a>
                            </td>
                            <td class="tools-p">
                                بۇ بىر سىناق سەھىپە، ساندانغا يېزىلمىغان.
                                <div class="tools">
                                    <div class="btn-group">
                                        <input type="button" name="name" value="تەھرىرلەش" class="btn btn-primary btn-xs" />
                                        <input type="button" name="name" value="تىز تەھرىرلەش" class="btn btn-info btn-xs" />
                                        <input type="button" name="name" value="ئۆچۈرۈش" class="btn btn-danger btn-xs" />
                                        <input type="button" name="name" value="كۆرۈش" class="btn btn-default btn-xs" />
                                    </div>
                                </div>
                            </td>
                            <td><a href="#" class="badge">ئاشكارا</a></td>
                        </tr>
                    </tbody>
                </table>
            </div>

            <p class="help-block">
                ئۇلانمىنى ئۆچۈرسىڭىز ئۇلانمىدىن تارتىپ ئىشلەتكەن تىزىملىكلەر ئىشلىمەسلىكى ھەم كۆرۈنمەسلىكى مۇمكىن. ئالاھىدە باغلىنىشى بولمىسىمۇ بىراق ئۇلانمىدىن تارتىپ ئىشلەتكەن ئەمەسمۇ.
            </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BeforeBody" runat="server">
</asp:Content>
