<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BulaqCMS.Admin.Login" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" style="height: 100%">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>ئالتۇن بۇلاق</title>
    <meta name="keywords" content="Bulaq.Net" />
    <meta name="description" content="" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no" />
    <link href="/Content/bootstrap.css" rel="stylesheet" />
    <link href="/Content/bootstrap-rtl.css" rel="stylesheet" />
    <link href="/Content/bootstrap-theme-rtl.css" rel="stylesheet" />
    <script src="/Scripts/jquery-2.1.4.js"></script>
    <script src="/Scripts/bootstrap-rtl.js"></script>
</head>
<body dir="rtl" class="container" style="padding-top: 100px">
    <form style="max-width: 400px; margin: 0 auto" id="frm" method="post">
        <div style="margin: 0 auto;">
            <div class="text-center">
                <div style="border: 1px solid #ccc; padding: 10px; border-radius: 50%; width: 220px; margin: 0 auto 20px;">
                    <img src="http://www.nurqut.net/ud/uc_server/data/avatar/000/00/90/61_avatar_big.jpg" alt="Alternate Text" class="img-circle" />
                </div>
            </div>
            <div class="form-group">
                <label>كىرىش ئىسمىڭىز :</label>
                <input type="text" name="UserName" value="" class="form-control text-right" dir="ltr" placeholder="كىرىش ئىسمىڭىز ياكى ئىلخەت" />
            </div>
            <div class="form-group">
                <label>پارول :</label>
                <input type="password" name="Password" value="" class="form-control" placeholder="پارول" />
            </div>
            <div class="form-group">
                <label>تەستىق كود :</label>
                <div class="row">
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                        <input type="text" name="ValidateCode" value="" class="form-control" placeholder="تەستىق كود" />
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4 col-lg-offset-2 col-md-offset-2 col-sm-offset-2 col-xs-offset-2">
                        <img src="/admin/ImageCode.ashx" alt="Alternate Text" class="form-control" style="padding: 0; cursor: pointer" />
                    </div>
                </div>
            </div>
            <div class="checkbox">
                <label>
                    <input type="checkbox" name="name" value="" />
                    ئەستە ساقلىسۇن
                </label>
            </div>
            <div class="form-group">
                <input type="button" name="name" value="كىرىش" class="btn btn-primary btn-block" />
            </div>
        </div>
    </form>
    <div class="navbar navbar-fixed-bottom navbar-default">
        <div class="container-fluid">
            <div class="navbar-header">
                <div class="navbar-brand"><a target="_blank" href="http://www.bulaq.net">Bulaq</a> تا قۇرغىنىڭىزغا رەھمەت</div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $('#frm img').click(function () {
            $(this).attr('src', '/admin/imagecode.ashx?' + Math.random())
        })
        $('#frm input[type=button]').click(function () {
            $.ajax({
                type: 'post',
                dataType: 'json',
                url: '',
                data: $('#frm').serialize(),
                success: function (d) {
                    if (d['result'] == 'ok' || d['error'] == 'online') window.location.href = <%=new HtmlString(hasUrl ? "'" + url + "'" : "'main.aspx'")%>;
                    else alert(d['error'])
                }
            })
        })
    </script>
</body>
</html>
