<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/_Admin.Master" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs" Inherits="BulaqCMS.Admin.UserEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Container" runat="server">
    <%if (this.Mode == "edit")
      { %>
    <h3 class="bulaq-header">ئارخىپىم</h3>
    <div class="row">
        <div class="col-sm-4">
            <form>
                <div class="form-group">
                    <label>كىرىش ئىسمىڭىز</label>
                    <input type="text" class="form-control input-sm text-ltr" placeholder="كىرىش ئىسمىڭىز" readonly>
                    <i class="help-block">كىرىش ئىسمىڭىزنى خالىغانچە ئۆزگەرتەلمەيسىز.</i>
                </div>
                <div class="form-group" id="display_name">
                    <label>ئىسمىڭىز</label>
                    <input type="text" class="form-control input-sm" placeholder="ئىسمىڭىز" name="DisplayName">
                    <i class="help-block" data-old="بۇ بەلكىم تور بەتتە كۆرۈنۈشى مۇمكىن.">بۇ بەلكىم تور بەتتە كۆرۈنۈشى مۇمكىن.</i>
                </div>
                <div class="form-group" id="nice_name">
                    <label>تور تەخەللۇسىڭىز</label>
                    <input type="text" class="form-control input-sm" placeholder="تور تەخەللۇسىڭىز" name="NiceName" />
                    <i class="help-block" data-old="تور تەخەللۇسىڭىز بولسا سۈكۈتتىكى تور بەتتە كۈرۈنىدىغان ئىسىم.">تور تەخەللۇسىڭىز بولسا سۈكۈتتىكى تور بەتتە كۈرۈنىدىغان ئىسىم.</i>
                </div>
                <div class="form-group" id="show_name">
                    <label>قايسى ئىسىمنى كۆرسىتىسىز؟</label>
                    <select class="form-control input-sm" name="ShowName">
                        <option value="value">تور تەخەللۇس</option>
                        <option value="value">ئىسمىم</option>
                    </select>
                    <i class="help-block" data-old="بۇ سىزنىڭ تور بەتتە ئاشكارا كۈرۈنىدىغان ئىسمىڭىز.">بۇ سىزنىڭ تور بەتتە ئاشكارا كۈرۈنىدىغان ئىسمىڭىز.</i>
                </div>
                <div class="form-group" id="email">
                    <label>ئىلخەت</label>
                    <input type="text" class="form-control input-sm text-ltr" placeholder="ئىلخەت" name="Email" />
                    <i class="help-block" data-old="ئۆزگەرتمىسڭىز بوش قۇيۇڭ.">ئۆزگەرتمىسڭىز بوش قۇيۇڭ.</i>
                </div>
                <div class="form-group" id="password">
                    <label>پارول</label>
                    <input type="password" class="form-control input-sm" placeholder="پارول" name="Password" />
                    <i class="help-block" data-old="پارولنى ئۆزگەرتمەكچى بولسىڭىز يېڭى پارولنى كىرگۈزۈڭ. ئۆزگەرتمىسڭىز بوش قۇيۇڭ.">پارولنى ئۆزگەرتمەكچى بولسىڭىز يېڭى پارولنى كىرگۈزۈڭ. ئۆزگەرتمىسڭىز بوش قۇيۇڭ.</i>
                </div>
                <div class="form-group" id="confirm_password">
                    <label>يانا پارول</label>
                    <input type="password" class="form-control input-sm" placeholder="يانا پارول" name="ConfirmPassword" />
                    <i class="help-block" data-old="يېڭى پارولىڭىزنى قايتا كىرگۈزۈڭ.">يېڭى پارولىڭىزنى قايتا كىرگۈزۈڭ.</i>
                </div>
                <div class="form-group" id="resume">
                    <label>تەرجىمالىڭىز</label>
                    <textarea class="form-control" rows="5" placeholder="تەرجىمالىڭىز" name="Resume"></textarea>
                    <i class="help-block" data-old="ئۈزىڭىز ئۈچۈن چۈشەنچە بىرىڭ">ئۈزىڭىز ئۈچۈن چۈشەنچە بىرىڭ</i>
                </div>
                <input type="hidden" name="UserID" value="" />
                <input type="hidden" name="Mode" value="<%:this.Mode%>" />
                <button type="button" id="submit" class="btn btn-primary">ئۆزگەرتىشلەرنى ساقلاش</button>
            </form>
        </div>
    </div>
    <%}
      else //if (this.Mode == "new")
      { %>
    <h3 class="bulaq-header">يېڭى ئىشلەتكۈچى قوشۇش</h3>
    <div class="col-sm-4">
        <form>
            <div class="form-group" id="login_name">
                <label>ئىشلەتكۈچى نامى</label>
                <input type="text" name="LoginName" class="form-control input-sm" placeholder="ئىشلەتكۈچى نامى">
                <i class="help-block" data-old="<strong><code>*</code> تەلەپ قىلىنىدۇ.</strong> بۇ ئىسىم يەككىلىككە ئىگە بۇلۇپ، سىستىمىغا كىرىش ئۈچۈن ئىشلىتىدىغان نام. نام بىرىش ئۆلچىمىگە بويسۇنىدۇ.">
                    <strong><code>*</code> تەلەپ قىلىنىدۇ.</strong> بۇ ئىسىم يەككىلىككە ئىگە بۇلۇپ، سىستىمىغا كىرىش ئۈچۈن ئىشلىتىدىغان نام. نام بىرىش ئۆلچىمىگە بويسۇنىدۇ.
                </i>
            </div>
            <div class="form-group" id="email">
                <label>ئىلخەت ئادرىسى</label>
                <input type="email" class="form-control input-sm text-ltr" placeholder="ئىلخەت ئادرىسىنى كىرگۈزۈڭ" name="Email">
                <i class="help-block" data-old="<strong><code>*</code> تەلەپ قىلىنىدۇ.</strong> بۇ خىزمەتچىنىڭ ئۇچۇرلىرىنى قايتا بىكىتىش ئۈچۈن ئىشلىتىلىدۇ، يەككىلىككە ئىگە.">
                    <strong><code>*</code> تەلەپ قىلىنىدۇ.</strong> بۇ خىزمەتچىنىڭ ئۇچۇرلىرىنى قايتا بىكىتىش ئۈچۈن ئىشلىتىلىدۇ، يەككىلىككە ئىگە.
                </i>
            </div>
            <div class="form-group" id="display_name">
                <label>ئىسمى</label>
                <input type="text" class="form-control input-sm" placeholder="ئىشلەتكۈچى ئىسمى" name="DisplayName">
                <i class="help-block" data-old="بۇ ئىشلەتكۈچىنىڭ ئىسمىنى كۆرسىتىدۇ. ئادەتتە ھەقىقى ئىسمى بولسىمۇ بۇلىدۇ. ئىشلەتكۈچىنىڭ تەڭشىكىگە ئاساسەن بەلكىم تور يۈزىدە كۆرسىتىلىشى مۇمكىن.">بۇ ئىشلەتكۈچىنىڭ ئىسمىنى كۆرسىتىدۇ. ئادەتتە ھەقىقى ئىسمى بولسىمۇ بۇلىدۇ. ئىشلەتكۈچىنىڭ تەڭشىكىگە ئاساسەن بەلكىم تور يۈزىدە كۆرسىتىلىشى مۇمكىن.</i>
            </div>
            <div class="form-group" id="nice_name">
                <label>تور تەخەللۇسى</label>
                <input type="text" class="form-control input-sm" placeholder="تور تەخەللۇسى" name="NiceName">
                <i class="help-block" data-old="بۇ ئىشلەتكۈچىنىڭ تور يۈزىدە كۆرىنىدىغان سۈكۈتتىكى ئىسمى.">بۇ ئىشلەتكۈچىنىڭ تور يۈزىدە كۆرىنىدىغان سۈكۈتتىكى ئىسمى.</i>
            </div>
            <div class="form-group" id="website">
                <label>تور بىكەت</label>
                <input type="text" class="form-control input-sm text-ltr" placeholder="تور بىكەت" name="Website">
                <i class="help-block" data-old="بۇ ئىشلەتكۈچىنىڭ تور ئادرىسى ياكى مىكروبىلوگى، ياكى باشقا ئادرىسىنى كۆرسەتسىمۇ بۇلىدۇ.">بۇ ئىشلەتكۈچىنىڭ تور ئادرىسى ياكى مىكروبىلوگى، ياكى باشقا ئادرىسىنى كۆرسەتسىمۇ بۇلىدۇ.</i>
            </div>
            <div class="form-group" id="password">
                <label>پارول</label>
                <input type="password" class="form-control input-sm" placeholder="پارول" name="Password">
                <i class="help-block" data-old="<code>*</code> تەلەپ قىلىنىدۇ."><code>*</code> تەلەپ قىلىنىدۇ.</i>
            </div>
            <div class="form-group" id="confirm_password">
                <label>تەستىق پارول</label>
                <input type="password" class="form-control input-sm" placeholder="تەستىق پارول" name="ConfirmPassword">
                <i class="help-block" data-old="<code>*</code> تەلەپ قىلىنىدۇ."><code>*</code> تەلەپ قىلىنىدۇ.</i>
            </div>
            <input type="hidden" name="Mode" value="<%:this.Mode%>" />
            <button type="button" id="submit" class="btn btn-primary">يېڭى ئىشلەتكۈچى قوشۇش</button>
        </form>
    </div>

    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BeforeBody" runat="server">
    <script type="text/javascript">
        var msgs = {
            'email_null': 'ئىلخەت بوش قالمىسۇن!',
            'userid_null': 'بۇ ئەزا مەۋجۇت ئەمەس!',
            'email_format': 'ئىلخەت ئادرىسىدا خاتالىق بار!',
            'loginname_null': 'كىرىش ئىسمى بوش قالمىسۇن!',
            'loginname_format': 'كىرىش ئىسمىدا خاتالىق بار!',
            'password_null': 'پارول بوش قالمىسۇن!',
            'password_format': 'پارولدا خاتالىق بار! چوڭ كىچىك لاتىنچە ھەرىپ،سان ۋە سىزىقچىلاردىن تۈزۈلىدۇ.',
            'confirm_password': 'ئىككى قېتىم كىرگۈزگەن پارول ئوخشاش بولسۇن!',
            'website_format': 'تور ئادرىسىدا خاتالىق بار',
            'user_null': 'بۇ ئەزا مەۋجۇت ئەمەس!',
            'has_loginname': 'بۇ ئەزالىق نامى بىلەن تىزىملىتىپ بولغان! باشقا نامدا تىزىملىتىڭ!',
            'has_email': 'بۇ ئىلخەت ئادرىسى بىلەن تىزىملىتىپ بولغان! باشقا ئىلخەت بىلەن تىزىملىتىڭ!',
            'on_add_error': 'ئىشلەتكۈچى قوشۇشتا خاتالىق كۆرۈلدى!',
            'on_update_error': 'ئارخىپىڭىزنى ئۆزگەرتىشتە خاتالىق كۆرۈلدى',
            'nicename_null': 'تور تەخەللوسى بوش قالمىسۇن!'
        };
        $('#submit').click(function () {
            var frm = $(this).parents('form');
            var dt = frm.serialize();
            $.ajax({
                type: 'post',
                dataType: 'json',
                user: 'UserEdit.aspx',
                data: dt,
                success: function (d, s) {
                    if (d.result == 'ok') window.location.href = 'Users.aspx';
                    else if (d.result == 'no') {
                        var errors = d.errors;
                        errors.forEach(function (val, index) {
                            switch (val) {
                                case 'email_null':
                                case 'email_format':
                                case 'has_email': _render('email', msgs[val]);
                                    break;
                                case 'loginname_null':
                                case 'loginname_format':
                                case 'has_loginname': _render('login_name', msgs[val]);
                                    break;
                                case 'password_null':
                                case 'password_format': _render('password', msgs[val]);
                                    break;
                                case 'confirm_password': _render('confirm_password', msgs[val]);
                                    break;
                                case 'website_format': _render('website', msgs[val]);
                                    break;
                                case 'nicename_null': _render('nice_name', msgs[val]);
                                    break;
                                default: alert(msgs[val]);
                                    break;
                            }
                        });
                    }
                }, error: function () {
                    alert('Server Filed Or Server Error!');
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
    </script>
</asp:Content>
