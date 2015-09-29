<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/_Admin.Master" AutoEventWireup="true" CodeBehind="NavGroup.aspx.cs" Inherits="BulaqCMS.Admin.NavGroup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Container" runat="server">
    <h3 class="bulaq-header">تىزىملىكلەر</h3>
    <div class="row">
        <div class="col-sm-4">
            <p><strong>تىزىملىك <%:isEdit?"تەھرىرلەش":"قوشۇش" %></strong></p>
            <form id="frm-navgroup-edit">
                <div class="form-group">
                    <label>تىزىملىك نامى</label>
                    <input type="text" class="form-control input-sm" placeholder="تىزىملىك نامى" name="Title" value="<%:updateGroup.Title??"" %>">
                    <%--<i class="help-block">تور بېتىڭىزدە مۇشۇ نامدا كۆرسىتىلىدىغان بۇلۇپ يەككىلىككە ئىگە ئەمەس. ھەرقانداق ھەرىپ بەلگىلەرنى قوللايدۇ.</i>--%>
                </div>
                <div class="form-group">
                    <label>تىزىملىك باشقا نامى</label>
                    <input type="text" class="form-control input-sm text-ltr" placeholder="تىزىملىك باشقا نامى" name="Name" value="<%:updateGroup.Name??"" %>">
                    <i class="help-block">تىزىملىك باشقا نامى يەككىلىككە ئىگە! تىزىملىكلەرنى گۇرۇپپىلاش ئۈچۈن ئىشلىتىلىدۇ!</i>

                </div>

                <div class="form-group">
                    <label>چۈشەندۈرۈش</label>
                    <textarea class="form-control" rows="5" placeholder="تىزىملىك ئۈچۈن چۈشەندۈرۈش بىرىڭ" name="Des"><%:updateGroup.Des??"" %></textarea>
                    <%--<i class="help-block">بۇ خەتكۈچ ئۈچۈن بىر ئىككى ئېغىز چۈشەندۈرۈش بىرىڭ. بۇ ئادەتتە كۆرسىتىلمىسىمۇ بىراق كۆرسىتىدىغان باش تىمىلار بار.</i>--%>
                </div>
                <input type="hidden" name="Mode" value="<%:isEdit?"edit":"new" %>" />
                <input type="hidden" name="NavGroupID" value="<%:updateGroup.ID %>" />
                <button type="button" name="submit" class="btn btn-primary"><%:isEdit?"ئۆزگەرتىشلەرنى ساقلاش":"تىزىملىك قورۇش" %></button>
            </form>
        </div>
        <div class="col-sm-8">
            <div class="clearfix bulaq-header">
                <div class="form-inline f-left">
                    <input type="text" name="name" value="" class="form-control input-sm" placeholder="تىزىملىكنى ئىزدەپ بېقىڭ" />
                    <input type="button" name="name" value="ئىزدەش" class="btn btn-primary btn-sm" />
                </div>
            </div>
            <table class="table table-hover">
                <thead>
                    <tr>
                        <th width="200">تىزىملىك نامى</th>
                        <th width="200">تىزىملىك باشقا نامى</th>
                        <th>تىزىملىك چۈشەندۈرۈلۈشى</th>
                        <th width="120">تىزىملىك سانى</th>
                    </tr>
                </thead>
                <tbody class="items-list">
                    <%foreach (var group in allGroups)
                      {%>
                    <tr class="tools-p">
                        <td><%:group.Title %></td>
                        <td>
                            <span class="text-ltr"><%:group.Name %></span>
                        </td>
                        <td>
                            <div class="tools">
                                <div class="btn-group">
                                    <a href="?mode=edit&navgroup=<%:group.Name %>" class="btn btn-primary btn-xs">تەھرىرلەش</a>
                                    <input type="button" name="name" value="ئۆچۈرۈش" class="btn btn-danger btn-xs" />
                                    <a href="Navs.aspx?navgroup=<%:group.Name %>" class="btn btn-default btn-xs">كۆرۈش</a>
                                </div>
                            </div>
                        </td>
                        <td class="text-center"><a href="Navs.aspx?navgroup=<%:group.Name %>" class="badge"><%:group.NavsCount %></a></td>
                    </tr>
                    <%} %>
                </tbody>
            </table>
            <p class="help-block">
                تىزىملىك سەھىپىسىنىڭ ئۆچۈرۈلىشى ئۇنىڭدىكى تىزىملىكلەرگە تەسىر قىلىدۇ.
            </p>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BeforeBody" runat="server">
    <script>

        var msgs = {
            'save_changes': 'ئۆزگەرتىشلەر ساقلاندى!',
            'server_error': 'مۇلازمىتىردا خاتالىق كۆرۈلدى!',
            'group_null': 'ئۆزگەرتمەكچى بولغان تىزىملىكنى تاپالمىدى!',
            'name_null': 'تىزىملىك باشقا نامى بوش قالمىسۇن!',
            'name_format': 'تىزىملىك باشقا نامىدا خاتالىق بار!',
            'has_name': 'بۇ باشقا نامدا تىزىملىك قۇرۇلغان! باشقا نام بىرىڭ!',
            'title_null': 'تىزىملىك بامى بوش قالمىسۇن!',
            'on_edit_error': 'تىزىملىكنى ئۆزگەرتىشتە خاتالىق كۆرۈلدى!',
            'on_add_error': 'تىزىملىك قوشۇشتا خاتالىق كۆرۈلدى!'
        };

        $('#frm-navgroup-edit button[name=submit]').click(function () {
            var frm = $('#frm-navgroup-edit');
            $.post('NavGroup.aspx', frm.serialize(), function (d) {
                if (d['result'] == 'ok') alertTip(msgs.save_changes, function () { location.href = location.pathname; });
                else {
                    alertTip(msgs[d['error']], 'danger');
                }
            }, 'json').error(function () { alertTip(msgs.server_error, 'danger'); });
        })
    </script>
</asp:Content>
