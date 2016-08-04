<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MissionManage.aspx.cs" Inherits="TimerManage.Manage" %>

<%@ Import Namespace="CST.ProjectFramework.Common.Extension" %>
<%@ Import Namespace="TimerManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <title>任务管理</title>
    <link href="style/bootstrap.css" rel="stylesheet" />
    <link href="style/MissionManageStyle.css" rel="stylesheet" />
    <link href="style/jquery.datetimepicker.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.11.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery.datetimepicker.full.min.js"></script>
    <script src="Scripts/MissionManageScript.min.js"></script>
    
</head>
<body>
    <form id="form1" runat="server">


        <%--查看任务详细信息模态框--%>
        <div class="fade modal" id="missionDetail" data-backdrop="static">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title ">任务详情</h4>
                    </div>
                    <div class="modal-body  missionid_json">
                        <div class="overridediv ">
                            <div class="loader"></div>
                            <h2 class="datainfo">数据加载中...</h2>
                        </div>

                        <p class="spantext pad ">任务信息</p>
                        <div class="col-lg-10  col-lg-offset-1 column" style="float: none">
                            <dl class="dl-horizontal">
                                <dt>任务名称：
                                </dt>
                                <dd>
                                    <p class="detail_missionname"></p>
                                </dd>
                                <dt>任务组名：
                                </dt>
                                <dd>
                                    <p class="detail_groupname"></p>
                                </dd>
                                <dt>任务状态：
                                </dt>
                                <dd>
                                    <p class="detail_missionstate"></p>
                                </dd>
                                <dt>SQL语句：
                                </dt>
                                <dd>
                                    <p class="detail_sqlstr"></p>
                                </dd>
                                <dt>时间表达式：
                                </dt>
                                <dd>
                                    <p class="detail_timecorn"></p>
                                </dd>
                                <dt>开始时间：
                                </dt>
                                <dd>
                                    <p class="detail_begintime"></p>
                                </dd>
                                <dt>结束时间：
                                </dt>
                                <dd>
                                    <p class="detail_endtime"></p>
                                </dd>
                                <dt>执行次数：
                                </dt>
                                <dd>
                                    <p class="detail_repeatcount"></p>
                                </dd>
                                <dt>任务注释：
                                </dt>
                                <dd>
                                    <p class="detail_missionexplain"></p>
                                </dd>
                                <dt>任务日志：
                                </dt>
                                <dd>
                                    <a class="detail_missionexplain">点击下载
                                    </a>
                                </dd>
                            </dl>



                        </div>
                        <hr class="pad" />
                        <p class="spantext pad ">任务操作</p>
                        <div class="col-lg-10  col-lg-offset-1 column mission_operate" style="float: none">
                            <div class="btn-group btn-group-justified" role="group">

                                <a href="#" runat="server" class="btn btn-primary missionstate1 missionstate4  " onserverclick="btnAddJob_Click">
                                    <i class="glyphicon glyphicon-ok-sign"></i>
                                    执行任务
                                </a>
                                <a href="#" runat="server" class="btn btn-primary missionstate3 missionstate2 missionstate4" onserverclick="btnPauseJob_Click">
                                    <i class=" glyphicon glyphicon-pause"></i>
                                    暂停
                                </a>
                                <a href="#" runat="server" class="btn btn-primary missionstate2 missionstate1 missionstate4" onserverclick="btnPauseResume_Click">
                                    <i class="   glyphicon glyphicon-repeat"></i>
                                    重启
                                </a>
                                <a href="#" runat="server" class="btn btn-primary missionstate2 missionstate4" onserverclick="btnStopJob_Click">
                                    <i class="glyphicon glyphicon-exclamation-sign"></i>
                                    停止
                                </a>

                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <a class="btn btn-default" data-dismiss="modal">关闭</a>


                    </div>
                </div>
            </div>
        </div>

        <%--添加任务模态框--%>
        <div class="modal fade" data-backdrop="static" id="RegistModal" tabindex="-1">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header ">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span
                                aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title text" id="myModalLabel">任务添加</h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-horizontal">
                            <p class="spantext">*必填项*</p>
                            <%--任务名称--%>
                            <div class="form-group">
                                <label for="txtAddMissionName" class="col-lg-2 col-lg-offset-2 control-label">任务名称</label>
                                <div class="col-lg-6">
                                    <asp:TextBox ID="txtAddMissionName" runat="server" class="form-control" placeholder="新增任务的名称，不可重复"></asp:TextBox>
                                </div>

                            </div>
                            <%--任务组--%>
                            <div class="form-group username">
                                <label for="txtAddGroupName" class="col-lg-2 col-lg-offset-2 control-label">任务组</label>
                                <div class="col-lg-6">
                                    <asp:TextBox ID="txtAddGroupName" runat="server" class="form-control" placeholder="当前任务所属小组名称"></asp:TextBox>
                                </div>

                            </div>
                            <%--SQL语句--%>
                            <div class="form-group">
                                <label for="txtAddSqlStr" class="col-lg-2 col-lg-offset-2 control-label">SQL语句</label>
                                <div class="col-lg-6">
                                    <asp:TextBox ID="txtAddSqlStr" runat="server" class="form-control" placeholder="请输入定时操作的SQL语句"
                                        TextMode="MultiLine"></asp:TextBox>
                                </div>

                            </div>
                            <%--定时控制--%>
                            <div class="form-group">
                                <label for="txtAddTimeCorn" class="col-lg-2 col-lg-offset-2 control-label">定时控制</label>
                                <div class="col-lg-6">
                                    <asp:TextBox ID="txtAddTimeCorn" runat="server" class="form-control" placeholder="任务定时执行的时间调度表达式（corn）"></asp:TextBox>
                                </div>

                            </div>
                            <%--任务开始时间--%>
                            <div class="form-group">
                                <label for="txtAddMissionStartTime" class="col-lg-2 col-lg-offset-2 control-label">开始时间</label>
                                <div class="col-lg-6">
                                    <asp:TextBox ID="txtAddMissionStartTime" runat="server" class="form-control  start_end_time" placeholder="请输入任务开始时间"></asp:TextBox>
                                </div>

                            </div>
                            <%--任务结束时间--%>
                            <div class="form-group">
                                <label for="txtAddMissionEndTime" class="col-lg-2 col-lg-offset-2 control-label">结束时间</label>
                                <div class="col-lg-6">
                                    <asp:TextBox ID="txtAddMissionEndTime" runat="server" class="form-control start_end_time" placeholder="任务结束的时间"></asp:TextBox>
                                </div>
                            </div>

                            <hr class="pad" />
                            <p class="spantext pad ">其他信息</p>
                            <%--执行次数--%>
                            <div class="form-group">
                                <label for="txtAddRepeatCount" class="col-lg-2 col-lg-offset-2 control-label">执行次数</label>
                                <div class="col-lg-6">
                                    <asp:TextBox ID="txtAddRepeatCount" runat="server" class="form-control" placeholder="任务循环执行次数，可空"></asp:TextBox>
                                </div>
                            </div>
                            <%--任务释义--%>
                            <div class="form-group">
                                <label for="TXTAddMissionExplain" class="col-lg-2 col-lg-offset-2 control-label">任务注释</label>
                                <div class="col-lg-6">
                                    <asp:TextBox ID="txtAddMissionExplain" runat="server" class="form-control" placeholder="任务备注：当前任务功能以及时间表达式的含义" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">


                        <a class="btn  btn-info" id="btnRegists" runat="server" onserverclick="btnRegist_Click">添加任务　</a>
                        <a id="btnMissionBeginNows" class="btn btn-primary" onserverclick="btnMissionBeginNow_Click" runat="server">添加并立即执行</a>
                    </div>

                </div>
            </div>
        </div>


        <%--编辑任务模态框--%>
        <div class="modal fade" id="missionEditModal" data-backdrop="static">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header ">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span
                                aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title text">任务编辑</h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-horizontal">

                            <%--任务名称--%>
                            <div class="form-group">
                                <label for="txtEditMissionName" class="col-lg-2 col-lg-offset-2 control-label">任务名称</label>
                                <div class="col-lg-6">
                                    <asp:TextBox ID="txtEditMissionName" runat="server" class="form-control" placeholder="新增任务的名称，不可重复"></asp:TextBox>
                                </div>

                            </div>
                            <%--任务组--%>
                            <div class="form-group username">
                                <label for="txtEditGroupName" class="col-lg-2 col-lg-offset-2 control-label">任务组</label>
                                <div class="col-lg-6">
                                    <asp:TextBox ID="txtEditGroupName" runat="server" class="form-control" placeholder="当前任务所属小组名称"></asp:TextBox>
                                </div>

                            </div>
                            <%--SQL语句--%>
                            <div class="form-group">
                                <label for="txtEditSqlStr" class="col-lg-2 col-lg-offset-2 control-label">SQL语句</label>
                                <div class="col-lg-6">
                                    <asp:TextBox ID="txtEditSqlStr" runat="server" class="form-control" placeholder="请输入定时操作的SQL语句"
                                        TextMode="MultiLine"></asp:TextBox>
                                </div>

                            </div>
                            <%--定时控制--%>
                            <div class="form-group">
                                <label for="txtEditTimeCorn" class="col-lg-2 col-lg-offset-2 control-label">定时控制</label>
                                <div class="col-lg-6">
                                    <asp:TextBox ID="txtEditTimeCorn" runat="server" class="form-control" placeholder="任务定时执行的时间调度表达式（corn）"></asp:TextBox>
                                </div>

                            </div>
                            <%--任务开始时间--%>
                            <div class="form-group">
                                <label for="txtEditMissionStartTime" class="col-lg-2 col-lg-offset-2 control-label">开始时间</label>
                                <div class="col-lg-6">
                                    <asp:TextBox ID="txtEditMissionStartTime" runat="server" class="form-control  start_end_time" placeholder="请输入任务开始时间"></asp:TextBox>
                                </div>

                            </div>
                            <%--任务结束时间--%>
                            <div class="form-group">
                                <label for="txtEditMissionEndTime" class="col-lg-2 col-lg-offset-2 control-label">结束时间</label>
                                <div class="col-lg-6">
                                    <asp:TextBox ID="txtEditMissionEndTime" runat="server" class="form-control start_end_time" placeholder="任务结束的时间"></asp:TextBox>
                                </div>
                            </div>

                            <hr class="pad" />
                            <p class="spantext pad ">其他信息</p>
                            <%--执行次数--%>
                            <div class="form-group">
                                <label for="txtEditRepeatCount" class="col-lg-2 col-lg-offset-2 control-label">执行次数</label>
                                <div class="col-lg-6">
                                    <asp:TextBox ID="txtEditRepeatCount" runat="server" class="form-control" placeholder="任务循环执行次数，可空"></asp:TextBox>
                                </div>
                            </div>
                            <%--任务释义--%>
                            <div class="form-group">
                                <label for="txtEditMissionExplain" class="col-lg-2 col-lg-offset-2 control-label">任务注释</label>
                                <div class="col-lg-6">
                                    <asp:TextBox ID="txtEditMissionExplain" runat="server" class="form-control" placeholder="任务备注：当前任务功能以及时间表达式的含义" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">


                        <a class="btn  btn-info" id="A1" runat="server" onserverclick="btnMissionEdit_Click">修改任务　</a>
                        <a id="A2" class="btn btn-primary" onserverclick="btnMissionBeginNow_Click" runat="server">修改并执行</a>
                    </div>

                </div>
            </div>
        </div>

        <%--页面主体--%>
        <div class="row">
            <div class="col-lg-10 col-lg-offset-1 ">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="col-lg-6 ">
                            <h2>定时任务管理</h2>
                        </div>


                    </div>
                    <%--检索项--%>
                    <div id="biao" class="panel-body">
                        <div class="col-lg-6 ho1">
                            <div class="form-horizontal " role="form">
                                <div class="form-group">
                                    <div class="col-sm-3">
                                        <label for="inputEmail3" class="control-label">任务名称：</label>
                                    </div>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtMissionName" class="form-control" runat="server" placeholder="需要检索的任务名称"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-3">
                                        <label for="ddlState" class="control-label">任务状态：</label>
                                    </div>
                                    <div class="col-sm-9">

                                        <asp:DropDownList ID="ddlState" class="form-control" runat="server">
                                            <asp:ListItem Value="0">全部</asp:ListItem>
                                            <asp:ListItem Value="1">正在运行</asp:ListItem>
                                            <asp:ListItem Value="2">未运行</asp:ListItem>
                                            <asp:ListItem Value="3">暂停状态</asp:ListItem>
                                            <asp:ListItem Value="4">已停止</asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-6 ho2">
                            <div class="form-horizontal" role="form">
                                <div class="form-group">
                                    <div class="col-sm-3">
                                        <label for="txtGroupName" class="control-label">任务组名：</label>
                                    </div>
                                    <div class="col-sm-9">

                                        <asp:TextBox ID="txtGroupName" class="form-control" runat="server" placeholder="需要检索的任务组名"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-3">
                                        <label for="txtStartTime" class="control-label">创建时间：</label>
                                    </div>
                                    <div class="col-sm-4" style="padding-right: 0;">

                                        <asp:TextBox ID="txtStartTime" class="form-control start_end_time" runat="server" placeholder="开始时间"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-1">
                                        <label for="txtEndTime" class="control-label">至</label>
                                    </div>
                                    <div class="col-sm-4" style="padding-left: 0;">
                                        <asp:TextBox ID="txtEndTime" class="form-control  start_end_time" runat="server" placeholder="截止时间"></asp:TextBox>
                                    </div>
                                </div>


                            </div>
                        </div>
                    </div>

                    <%--数据列表--%>
                    <div class="fixed-table-toolbar">

                        <%--下拉菜单--%>
                        <div class="pull-left search">
                            当前每页显示<asp:DropDownList CssClass="ddl" ID="countDDL" runat="server" AutoPostBack="True" OnSelectedIndexChanged="countDDL_SelectedIndexChanged">
                                <asp:ListItem> 10</asp:ListItem>
                                <asp:ListItem>20</asp:ListItem>
                                <asp:ListItem>50</asp:ListItem>
                                <asp:ListItem>100</asp:ListItem>
                            </asp:DropDownList>条记录
                        </div>

                        <%--按钮组--%>
                        <div class="columns btn-group  pull-right">

                            <div class="btn-group">
                                <a class="btn btn-primary" data-toggle="modal" data-target="#RegistModal"><i class=" glyphicon glyphicon-plus icon-refresh"></i>&nbsp;添加任务　</a>

                                <a class="btn btn-primary" runat="server" onserverclick="btnSearch_Click"><i class=" glyphicon glyphicon-search icon-refresh"></i>&nbsp;搜索任务　</a>

                                <a title="刷新" name="refresh" runat="server" onserverclick="btnF5_Click" class="btn btn-primary"><i class="glyphicon glyphicon-refresh icon-refresh"></i></a>
                            </div>
                        </div>

                        <%--数据列表--%>
                        <div class=" fixed-table-container">
                            <div class="fixed-table-header">
                                <table></table>
                            </div>
                            <div class="fixed-table-body">
                                <table class="table table-hover  ">
                                    <thead>
                                        <tr>
                                            <th class="text-center  headorder" data-type="num">序号<span></span></th>
                                            <th class="text-center goodsname headgoodsname" data-type="str">任务名称<span></span></th>
                                            <th class="text-center headusername username" data-type="str">组名<span></span></th>
                                            <th class="text-center headsql  goodsdetail" data-type="str">SQL语句<span></span></th>
                                            <th class="text-center price">时间表达式</th>
                                            <th class="text-center states headstates" data-type="str">任务状态<span></span></th>
                                            <th class="text-center time times headtimes" data-type="time">创建时间<span class=""></span></th>
                                            <th class="text-center">操作</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="Repeatergoods" runat="server">
                                            <HeaderTemplate></HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td class="text-center"><%#Eval("rowId") %></td>

                                                    <td class="text-center goodsname ">
                                                        <a data-toggle="modal" data-target="#missionDetail" data-missionid="<%#Eval("Id") %>" class="a_getdetail"><%#   Eval("MissionName").ToString().Length>8?Eval("MissionName").ToString().Substring(0,8)+"..":Eval("MissionName").ToString()%></a>
                                                    </td>
                                                    <td class="text-center username"><%#Eval("GroupName ") %></td>
                                                    <td class="text-center goodsdetail">
                                                        <p data-toggle="tooltip" data-placement="right" title="SQL详情：<%#Eval("SqlStr")%>">
                                                            <%#   Eval("SqlStr").ToString().Length>20?Eval("SqlStr").ToString().Substring(0,20)+"..":Eval("SqlStr").ToString()%>
                                                        </p>
                                                    </td>


                                                    <td class="text-centerphnum">
                                                        <%--<%#Eval(" TimeCorn") %>--%>
                                                        <p data-toggle="tooltip" style="text-align: center" data-placement="right" title="表达式详情：<%#Eval("TimeCorn")%>"><%#Eval("TimeCorn").ToString().Length>15?Eval("TimeCorn").ToString().Substring(0,15)+"..":Eval("TimeCorn").ToString()%></p>

                                                    </td>
                                                    <td class="text-center price">
                                                        <%#Eval("StateString") %> 
                                                    </td>
                                                    <td class="text-center time"><%#Eval(" CreateTime") %></td>
                                                    <td class="text-center "><a class="no-padding a_editdetail" data-toggle="modal" data-target="#missionEditModal" data-missionid="<%#Eval("Id") %>" class="a_getdetail" title="修改任务信息"><span class="glyphicon glyphicon-pencil"></span></a>
                                                        <asp:LinkButton ID="LinkButtonDelete" title="删除任务信息" runat="server" CommandArgument='<%#Eval("ID") %>'
                                                            OnCommand="Delete" OnClientClick='<%#  "if (!confirm(\"你确定要删除任务：" + Eval("MissionName").ToString() + "吗?\")) return false;"%>'>
                                                        <span class="glyphicon glyphicon-trash"></span>
                                                        </asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <tr>
                                                    <td colspan="100" style="padding-bottom: 0">共有<b><%#Webpagerecord %> </b>条任务信息        
                                                                 <div class="pager pagination-sm pull-right" style="margin: 0">
                                                                     <nav>
                                                                         <ul class="pagination pagination-sm" style="margin-left: auto; margin-right: auto; padding: 0; margin: 0;">
                                                                             <li>
                                                                                 <asp:LinkButton ID="lnkUpPage" runat="server" Enabled="<%# Webpageindex>1%>" OnCommand="Goup"><span aria-hidden="true">&laquo;</span></asp:LinkButton>
                                                                             </li>
                                                                             <li>
                                                                                 <asp:LinkButton ID="pagejian2" runat="server" Text='<%# Webpageindex -2%>' Visible='<%# Webpageindex -2 > 0%>'
                                                                                     OnCommand="GOjian2"></asp:LinkButton>
                                                                             </li>
                                                                             <li>
                                                                                 <asp:LinkButton ID="pagejian1" runat="server" Text='<%# Webpageindex -1%>' Visible='<%# Webpageindex -1 > 0%>'
                                                                                     OnCommand="GOjian1"></asp:LinkButton>
                                                                             </li>
                                                                             <li class=" active"><a href="#"><%# Webpageindex%></a>
                                                                             <li>
                                                                                 <asp:LinkButton ID="lnkjia1" runat="server" Text='<%# Webpageindex +1%>' Visible='<%# Webpageindex +1 <=WebPageCount%>'
                                                                                     OnCommand="GOjia1"></asp:LinkButton>
                                                                             </li>
                                                                             <li>
                                                                                 <asp:LinkButton ID="lnkjia2" runat="server" Text='<%# Webpageindex+2%>' Visible='<%# Webpageindex +2<=WebPageCount%>'
                                                                                     OnCommand="GOjia2"></asp:LinkButton>
                                                                             </li>
                                                                             <li>
                                                                                 <asp:LinkButton ID="lnkNextPage" runat="server" Enabled="<%# WebPageCount-Webpageindex>0%>"
                                                                                     OnCommand="Gonp"><span aria-hidden="true">&raquo;</span></asp:LinkButton>
                                                                             </li>
                                                                         </ul>
                                                                     </nav>
                                                                 </div>
                                                    </td>
                                                </tr>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%--用来存储隐藏的任务ID--%>
        <asp:TextBox ID="txtHiddenText" runat="server" class="hidden"></asp:TextBox>




    </form>
</body>
</html>
