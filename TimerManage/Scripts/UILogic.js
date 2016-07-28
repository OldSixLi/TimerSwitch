$(isExistLoginCode);  //判断登录名是否相同 shui
$(OrgDisclaimerLogic);
$(OrgRegisterCheckBoxList);
$(dialog);
$(ShowDialog);
$(isExistOrgCode);
$(isExistOrgCodeUpdate);
$(FunctionAdd);
$(isExistusersCode);   //判断用户名是否相同 shui //$(appentToDialog);//给服务器控件添加属性
//免责声明下一步
function OrgDisclaimerLogic() {
    $("#OrgDisclaimerCheckBoxNextStep").click(function () {
        if ($("#OrgDisclaimerCheckBox").attr("checked") != true) {
            $("#OrgDisclaimerCheckBoxNextStep").enable = false;
            return false;
        }
    });
} //注册服务类型选择
function OrgRegisterCheckBoxList() {
    //点击选择按钮
    $("#OrgServiceType").focus(function () {
        $("#OrgRegServiceTypeList").show();
    });
//    $(".CheckBoxListCancel").click(function () {
//        $("#OrgRegServiceTypeList").hide();
//    });
    $(".CheckBoxListConfirm").click(function () {
        $("#OrgRegServiceTypeList").hide();
    });
    $(".CheckBoxListCancel").click(function () { 
        $("#OrgRegServiceTypeList").hide();
       $(".txtForCheckBoxListAdd").val("");         $(".txtForCheckBoxListAdd").focus();
       var checkedList = $("input[type='checkbox']").attr("checked", true);
       for (var i = 0; i < checkedList.length; i++) {
            $(checkedList).attr("checked",false)
        }
    }); }
//功能点增加
function FunctionAdd() {
    $("#btnFunAdd").click(function () {
        $("#divFunctionAdd").show();
    });
} function dialog() {     $("#NewRole").click(function () {
        var roleID = $("#roleIDTip").html();
        var result = window.showModalDialog("NewRoleModal.aspx?id=" + roleID);
        if(result!="undefine")
        alert(result);
    });
} function ShowDialog() {
    $("#newRoleFunctionID").click(function () {
        $(".allPage").show();
    });
} //组织注册判断是否已存在同名的组织机构代码 
function isExistOrgCode() {
    $("#OrgCode").blur(function () {
        var orgCode = $(this).val();
        if (orgCode != "") {
            var isExist = OrgRegisterTest.IsExistOrgCode(orgCode).value;
            if (isExist == true) {
                alert("已存在同名组织代码，请重新输入");
                $(this).val("");
                $(this).focus();
                $(this).parent().next("td").find(".validateAllRight").hide();
            } 
        }
    });
}
$(isExistOldOrgCode);
//企业注册判断是否已存在同名的组织机构代码
function isExistOldOrgCode() {
    $("#ComCode").blur(function () {
        var orgCode = $(this).val();
        if (orgCode != "") {
          //  var isExist = ComRegisterTest.IsExistOrgCode(orgCode).value;
            var isExistOld = ComRegisterTest.IsExistOldOrgCode(orgCode).value;
            if (isExistOld) {
                alert("企业机构代码已经存在，请重新输入！");
                $(this).val("");
                $(this).focus();
                $(this).parent().next("td").find(".validateAllRight").hide();
            }
        }
    });
} //用户注册判断是否已存在同名的用户名称  shui
function isExistusersCode() {
    $("#txtUserLogin").blur(function () {
        var loginCode = $(this).val();
        if (loginCode != "") {
            var isExists = UsersAdd.isExistusersCode(loginCode).value;
            if (isExists == true) {
                alert("已存在同名登录名，请重新输入");
                $(this).val("");
                $(this).focus();
                $(this).parent().next("td").find(".validateAllRight").hide();
            } 
        }
    });
} //组织注册判断是否已存在同名的登录名称  shui
function isExistLoginCode() {
    $("#loginCode").blur(function () {
        var loginCode = $(this).val();
        if (loginCode != "") {
            var isExists = OrgRegisterTest.IsExistLoginCode(loginCode).value;
            if (isExists == true) {
                alert("已存在同名登录名，请重新输入");
                $(this).val("");
                $(this).focus();
                $(this).parent().next("td").find(".validateAllRight").hide();
            }
        }
    });
}
$(isExistComLoginCode);
//企业注册判断是否已存在同名的登录名称  shui
function isExistComLoginCode() {
    $("#ComLoginCode").blur(function () {
        var loginCode = $(this).val();
        if (loginCode != "") {
            var isExists = ComRegisterTest.IsExistLoginCode(loginCode).value;
            if (isExists == true) {
                alert("已存在同名登录名，请重新输入");
                $(this).val("");
                $(this).focus();
                $(this).parent().next("td").find(".validateAllRight").hide();
            }
        }
    });
} $(isExistAffixName);
//判断上传图片时是否存在相同的附件名称
function isExistAffixName() {     $("#ShowItemName").blur(function () {
        var AffixName = $(this).val();
        var orgid = $("#guidTip").html();
        if (AffixName != "") {
            var isExists = CompanyShowInfoModal.IsExistAffixName(AffixName,orgid).value;
            if (isExists == true) {
                alert("已存在相同附件名称，请重新输入");
                $(this).val("");
                $(this).focus();
                $(this).parent().next("td").find(".validateAllRight").hide();
            }
        }
    });
} function isExistOrgCodeUpdate() {
    $("#OrgCodeUpdate").blur(function () {
        var orgCodeUpdate = $(this).val();
        var OrgCode = $("#orgCodeTip").html();
        var isExist = OrgInfoUpdate.IsExistOrgCode(orgCodeUpdate, OrgCode).value;
        if (isExist == true) {
            alert("已存在同名组织代码，请重新输入");
            $(this).focus();
        }
    });
}
