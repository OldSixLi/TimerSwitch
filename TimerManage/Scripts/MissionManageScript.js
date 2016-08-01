
$(function ()
{
    //初始化时间控件
    $('.start_end_time').datetimepicker();

    //初始化悬浮气泡控件
    $("[data-toggle='tooltip']").tooltip();

    //点击任务链接后Modal显示任务的具体内容
    $(".a_getdetail").click(function ()
    {
        var id = $(this).attr("data-missionid");
        $("#txtHiddenText").val(id);
        var path = "Ajax/GetMissionDetail.ashx?missionid=" + id;
        //alert(path);
        //开始执行异步操作
        $.ajax({
            url: path,
            beforeSend: function ()
            {
                $('.overridediv').css('display', 'block');
            },
            datatype: 'json',
            success: function (jsons)
            {
                if (jsons)
                {
                    var json = JSON.parse(jsons);
                    $(".detail_missionname").html(json.MissionName);
                    $(".detail_groupname").html(json.GroupName);
                    $(".detail_sqlstr").html(json.SqlStr);
                    $(".detail_timecorn").html(json.TimeCorn);
                    $(".detail_repeatcount").html(json.RepeatCount + "次");
                    $(".detail_begintime").html(renderTime(json.StartTime));
                    $(".detail_endtime").html(renderTime(json.EndTime));
                    $(".detail_missionexplain").html(json.MissionExplain);
                    $(".detail_missionstate").html(json.StateString);
                    var statenum = json.MissionState;
                    $('.mission_operate a').removeClass('disabled');


                    $('.missionstate' + statenum).addClass('disabled');
                    var xianshi = setTimeout(function ()
                    {
                        $('.overridediv').css('display', 'none');
                    }, 2000);

                } else
                {
                    $(".missionid_json").html('未知错误，数据无法显示！');
                }

            }
        });
    });

    //修改按钮
    $(".a_editdetail").click(function ()
    {
        var id = $(this).attr("data-missionid");
        $("#txtHiddenText").val(id);
        var path = "Ajax/GetMissionDetail.ashx?missionid=" + id;
        //alert(path);
        //开始执行异步操作
        $.ajax({
            url: path,
            beforeSend: function ()
            {
                $('.overridediv').css('display', 'block');
            },
            datatype: 'json',
            success: function (jsons)
            {
                if (jsons)
                {
                    var json = JSON.parse(jsons);
                    $("#txtEditMissionName").val(json.MissionName);
                    $("#txtEditGroupName").val(json.GroupName);
                    $("#txtEditSqlStr").html(json.SqlStr);
                    $("#txtEditTimeCorn").val(json.TimeCorn);
                    $("#txtEditRepeatCount").val(json.RepeatCount);
                    $("#txtEditMissionStartTime").val(renderTime(json.StartTime));
                    $("#txtEditMissionEndTime").val(renderTime(json.EndTime));
                    $("#txtEditMissionExplain").val(json.MissionExplain);
                    //var statenum = json.MissionState;
                    //$('.mission_operate a').removeClass('disabled');

                    //$('.missionstate' + statenum).addClass('disabled');
                    var xianshi = setTimeout(function ()
                    {
                        $('.overridediv').css('display', 'none');
                    }, 200000);

                } else
                {
                    $(".missionid_json").html('未知错误，数据无法显示！');
                }

            }
        });
    });
});

$(function ()
{
    var isdesc = false;//定义一个全局变量，用来确定升序还是降序

    $("thead .headsql,.headgoodsname,.headusername,.headorder,.headtimes,.headstates").click(function ()
    {
        //  点击列表的表头进行排序
        $(this).parent().find('span').removeClass();//删除所有图标
        $(this).find('span').addClass('glyphicon');//仅为当前项目添加图标

        //添加正序或倒序图标
        if (!isdesc)
        {
            isdesc = true;
            $(this).find('span').removeClass('glyphicon-chevron-down').addClass('glyphicon-chevron-up').attr("title", "升序");
        } else
        {
            isdesc = false;
            $(this).find('span').removeClass('glyphicon-chevron-up').addClass('glyphicon-chevron-down').attr("title", "降序");
        }
        var trlength = $('.fixed-table-container tr').length - 2;
        var colunindex = $(this).index();//当前TH的序号
        //获取需要进行比对的数据行（去除表头和最后一行）
        var tablearr = $.makeArray($('tbody tr:lt(' + trlength + ')'));

        //排序规则三种：1、时间；2、字符串；3、数字
        if ($(this).attr("data-type") === "time")
        {
            tablearr.sort(function (a, b)
            {
                return isdesc ? timescompare($(a).find('td').eq(colunindex).text(), $(b).find('td').eq(colunindex).text()) : timescompare($(b).find('td').eq(colunindex).text(), $(a).find('td').eq(colunindex).text());
            });
        }
        else if ($(this).attr("data-type") === "str")
        {
            tablearr.sort(function (a, b)
            {
                var avalue = $(a).find('td').eq(colunindex).text();
                var bvalue = $(b).find('td').eq(colunindex).text();
                return isdesc ? avalue.localeCompare(bvalue) : bvalue.localeCompare(avalue);
            });
        }
        else if ($(this).attr("data-type") === "num")
        {
            tablearr.sort(function (a, b)
            {
                var avalue = parseInt($(a).find('td').eq(colunindex).text());
                var bvalue = parseInt($(b).find('td').eq(colunindex).text());
                return isdesc ? avalue - bvalue : bvalue - avalue;
            });

        }
        //重新添加到页面中
        var tbody = $("<tbody></tbody>").append($(tablearr));
        $('tbody').prepend($(tbody).html());
    });
});


function renderTime(date)
{
    var da = new Date(parseInt(date.replace("/Date(", "").replace(")/", "").split("+")[0]));
    var month = "", dates = "", hours = "", minutes = "", seconds = "";

    month = (da.getMonth() + 1) < 10 ? "0" + (da.getMonth() + 1) : da.getMonth() + 1;
    hours = da.getHours() < 10 ? "0" + da.getHours() : da.getHours();
    seconds = da.getSeconds() < 10 ? "0" + da.getSeconds() : da.getSeconds();
    minutes = da.getMinutes() < 10 ? "0" + da.getMinutes() : da.getMinutes();
    dates = da.getDate() < 10 ? "0" + da.getDate() : da.getDate();

    return da.getFullYear() + "-" + month + "-" + dates + " " + hours + ":" + minutes + ":" + seconds;
}


//时间比较函数（直接提取数字进行比较）
function timescompare(a, b)
{
    return a.replace(/[^0-9]+/g, '') - b.replace(/[^0-9]+/g, '');
}