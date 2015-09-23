<%@ Page Title="Abduaris" Language="C#" MasterPageFile="~/Admin/_Admin.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="BulaqCMS.Admin.Main" %>

<%--<asp:Content ID="Header" ContentPlaceHolderID="head" runat="server">
</asp:Content>--%>
<asp:Content ID="Container" ContentPlaceHolderID="Container" runat="server">
    <h3 class="bulaq-header">باشقۇرۇش سۇپىسى</h3>
    <div class="row">
        <div class="col-sm-6">
            <div class="panel panel-default">
                <div class="panel-heading">كۆز يۈگۈرتۈش</div>
                <div class="panel-body">
                    <ul class="list-group">
                        <li class="list-group-item">يازما :&nbsp;&nbsp;<a href="#">15</a> پارچە&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;تەستىق كۈتىۋاتقىنى :&nbsp;&nbsp;<a href="#">10</a> پارچە &nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp; ئەخلەت :&nbsp;&nbsp;<a href="#">8</a> پارچە</li>
                        <li class="list-group-item">ئىنكاس :&nbsp;&nbsp;<a href="#">15</a> پارچە&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;تەستىق كۈتىۋاتقىنى :&nbsp;&nbsp;<a href="#">10</a> پارچە &nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp; ئەخلەت :&nbsp;&nbsp;<a href="#">8</a> پارچە</li>
                        <li class="list-group-item">بەت :&nbsp;&nbsp;<a href="#">15</a> پارچە&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;بەت قېلىپى :&nbsp;&nbsp;<a href="#">10</a> پارچە</li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="col-sm-6">
            <div class="panel panel-primary">
                <div class="panel-heading">تىز ئارگىنال</div>
                <div class="panel-body">
                    <form>
                        <div class="form-group">
                            <input type="text" name="title" value="" placeholder="تىما" class="form-control" />
                        </div>
                        <div class="form-group">
                            <textarea class="form-control" rows="3" placeholder="نىمىنى ئويلاۋاتىسىز؟"></textarea>
                        </div>
                        <div class="form-group">
                            <input type="button" name="submit" value="ساقلاش" class="btn btn-primary" />
                        </div>

                    </form>
                </div>
            </div>
        </div>

        <div class="col-sm-6">
            <div class="panel panel-default">
                <div class="panel-heading">مۇلازىمىتىر ئۇچۇرلىرى</div>
                <div class="panel-body">
                    <ul class="list-group">
                        <li class="list-group-item">سىستىما :&nbsp;&nbsp;&nbsp;<span class="text-ltr">Windows NT 7.1 SP2</span></li>
                        <li class="list-group-item">مۇلازىمىتىر :&nbsp;&nbsp;&nbsp;<span class="text-ltr">Internet Infomation Service 8 (IIS8)</span></li>
                        <li class="list-group-item"><span class="text-ltr">.Net</span> نەشىرى :&nbsp;&nbsp;&nbsp;<span class="text-ltr">4.0.3309</span></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="col-sm-6">
            <div class="panel panel-default">
                <div class="panel-heading">Bulaq ئۇچۇرلىرى</div>
                <div class="panel-body">
                    <ul class="list-group">
                        <li class="list-group-item">ھازىرقى نەشىرى :&nbsp;&nbsp;&nbsp;<span class="text-ltr">1.1.1.0</span>&nbsp;&nbsp;&nbsp;
                            <button class="btn btn-danger btn-xs">1.2.0.0 نەشىرىگە يېڭىلاش</button></li>
                        <li class="list-group-item">نۆۋەتتىكى ئۇسلۇب :&nbsp;&nbsp;&nbsp;<span class="text-primary">يېشىل ئارال 2015</span>&nbsp;&nbsp;&nbsp;
                            <button class="btn btn-danger btn-xs">1.2 نەشىرىگە يېڭىلاش</button></li>
                        <li class="list-group-item">ئەڭ تۈۋەن <span class="text-ltr">.Net</span> نەشىر تەلىپى :&nbsp;&nbsp;&nbsp;<span class="text-ltr">4.0.3319</span></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="col-sm-6">
            <div class="panel panel-default">
                <div class="panel-heading">Bulaq خەۋەرلىرى</div>
                <div class="panel-body">
                    <ul class="list-group">
                        <li class="list-group-item"><a href="#">يېڭى نەشىردىكى Bulaq پات يېقىندا ئېلان قىلىنىدۇ.</a><time class="text-ltr f-left">2015-12-18 00:00:00</time></li>
                        <li class="list-group-item"><a href="#">يېڭى نەشىردىكى Bulaq پات يېقىندا ئېلان قىلىنىدۇ.</a></li>
                        <li class="list-group-item"><a href="#">يېڭى نەشىردىكى Bulaq پات يېقىندا ئېلان قىلىنىدۇ.</a></li>
                        <li class="list-group-item"><a href="#">يېڭى نەشىردىكى Bulaq پات يېقىندا ئېلان قىلىنىدۇ.</a></li>
                        <li class="list-group-item"><a href="#">يېڭى نەشىردىكى Bulaq پات يېقىندا ئېلان قىلىنىدۇ.</a></li>
                    </ul>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
