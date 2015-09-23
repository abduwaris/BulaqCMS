<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/_Admin.Master" AutoEventWireup="true" CodeBehind="EditCategories.aspx.cs" Inherits="BulaqCMS.Admin.EditCategories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Container" runat="server">
    <h3 class="bulaq-header">سەھىپە تەھرىرلەش</h3>
            <i class="help-block">سەھىپە بىلەن خەتكۈچنىڭ پەرقى شۇكى سەھىپىلەر قاتلاملىق مۇناسىۋەتكە ئىگە ھەم سەھىپە ۋە سەھىپىلەر ئاستىدىكى بارلىق يازمىلارغا خالىغانچە ئۇسلۇب تەللىغىلى بۇلىدۇ.</i>
            <div class="row">
                <div class="col-lg-4 col-md-5 col-sm-6 col-xs-12">
                    <form>
                        <div class="form-group">
                            <label>نامى</label>
                            <input type="text" class="form-control input-sm" placeholder="نامى" name="Title">
                            <i class="help-block">تور بېتىڭىزدە مۇشۇ نامدا كۆرسىتىلىدىغان بۇلۇپ يەككىلىككە ئىگە ئەمەس. ھەرقانداق ھەرىپ بەلگىلەرنى قوللايدۇ.</i>
                        </div>
                        <div class="form-group">
                            <label>سەھىپە باشقا نامى</label>
                            <input type="text" class="form-control input-sm text-ltr" placeholder="سەھىپە باشقا نامى" name="Name">
                            <i class="help-block">
                                «سەھىپە باشقا نامى» بولسا ئۇلىنىش ئىچىدە ئىشلىتىلىدىغان نام بۇلۇپ يەككىلىككە ئىگە. بۇ URL ئۆلچىمىگە بوي سۇنىدىغان بۇلۇپ، پەقەت سان، لاتىنچە ھەرىپ، ئاستى سىزىق ۋە سىزىقتىلا تۈزىلىدۇ. ھەم ئاستى سىزىق ، سىزىقچىلار بىرگە كەلمەسلىكى، ھەم ئاخىرلاشماسلىقى،سان بىلەن باشلانماسلىقى كىرەك.مەسىلەن تۈۋەندىكىدەك بولسا بولمايدۇ.<br />
                                123abc,a_-,a__b,a--b
                            </i>
                        </div>
                        <div class="form-group">
                            <label>تەۋەلىكى</label>
                            <select class="form-control input-sm" name="Parent">
                                <option value="value">تەۋەلىكىنى تاللاڭ</option>
                                <option value="value">text</option>
                                <option value="value">text</option>
                                <option value="value">text</option>
                            </select>
                            <i class="help-block">سەھىپىنىڭ خەتكۈچ بىلەن ئوخشىمايدىغان يىرى شۇكى، سەھىپە قاتلاملىق مۇناسىۋەتكە ئىگە. تاللىمىسىڭىزمۇ بۇلىدۇ.</i>
                        </div>
                        <div class="form-group">
                            <label>سەھىپىە ئۇسلۇبى</label>
                            <select class="form-control input-sm" name="Template">
                                <option value="value">سەھىپە ئۇسلۇبىنى تاللاڭ</option>
                                <option value="value">text</option>
                                <option value="value">text</option>
                                <option value="value">text</option>
                            </select>
                            <i class="help-block">«سەھىپىە ئۇسلۇبى» ئارقىلىق مەزكور سەھىپە بېتىنىڭ ئۇسلۇبىنى تاللىيالايسىز. تاللانمىسا سىستىمىنىڭ تاللانغان ئۇسلۇبىنى ئىشلىتىدۇ.</i>
                        </div>
                        <div class="form-group">
                            <label>سەھىپىدىكى يازمىلار ئۇسلۇبى</label>
                            <select class="form-control input-sm" name="PostsTemplate">
                                <option value="value">سەھىپىدىكى يازمىلار ئۇسلۇبىنى تاللاڭ</option>
                                <option value="value">text</option>
                                <option value="value">text</option>
                                <option value="value">text</option>
                            </select>
                            <i class="help-block">«سەھىپىدىكى يازمىلار ئۇسلۇبى» ئارقىلىق مەزكور سەھىپە ئىچىدىكى بارلىق ئۇسلۇب تاللانمىغان يازمىلارغا كۆرسىتىش ئۇسلۇبى بىكىتەلەيسىز، ئەگەر تارماق سەھىپىدە ئۇسلۇب تاللانغان بولسا تارماق سەھىپىدىكى ئۇسلۇبنى ئاساس قىلىدۇ. ئۇسلۇب تاللاش تەرتىۋى ئىچىدىن تېشىغا ئاجىزلايدىغان بۇلۇپ، ھېچقانداق ئۇسلۇب تاللانمىغان بولسا سىستىمىنىڭ سۈكۈتتىكى تاللانغان ئۇسلۇبى ئاساس قىلىنىدۇ. بىر يازما بىر نەچچە سەھىپىگە تاللانغان بولسا، شۇلارنىڭ ئىچىدىكى ئۇسلۇب تاللانغان بىرىنچى سەھىپىنى ئاساس قىلىپ ئۇسلۇب بىكىتىدۇ.</i>
                        </div>
                        <div class="form-group">
                            <label>چۈشەندۈرۈش</label>
                            <textarea class="form-control" rows="5" name="Des"></textarea>
                            <i class="help-block">بۇ سەھىپە ئۈچۈن بىر ئىككى ئېغىز چۈشەندۈرۈش بىرىڭ. بۇ ئادەتتە كۆرسىتىلمىسىمۇ بىراق كۆرسىتىدىغان باش تىمىلار بار</i>
                        </div>
                        <button type="submit" class="btn btn-primary">يېڭىلاش</button>
                    </form>

                </div>
            </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BeforeBody" runat="server">
</asp:Content>
