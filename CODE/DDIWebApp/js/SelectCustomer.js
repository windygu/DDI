function GetCustomerInfo() {
    var customerval = "'0'";
    var customertxt = "";
    var listboxs = $(window.top.art.dialog({ id: 'customerSelect' }).data.iframe.document).find("input:checked");
    if (listboxs.size() == 0) return false;
    listboxs.each(function() {
        var val = $(this).attr("value");
        var txt = $(this).attr("txt");
        customertxt = customertxt + "," + txt;
        customerval = customerval + ",'" + val + "'";
    });
    $("#txtCustomerName").val(customertxt);
    $("#txtCustomerCode").val(customerval)
}

//供应商查询选择
function searchCustomerSelect(CustomerType) {

    window.top.art.dialog({ title: '供应商列表', id: 'customerSelect', iframe: 'hospital/EInvoic/Select/SelectCustomer.aspx?CustomerType=' + CustomerType, lock: true }, function() { GetCustomerInfo(); });

}

//选择一个商业公司
function GetCustomerInfoOne(objname, objcode) {
    var customerval = "'0'";
    var customertxt = "";
    var listboxs = $(window.top.art.dialog({ id: 'customerSelectOne' }).data.iframe.document).find("input:checked");
    if (listboxs.size() == 0) return false;
    listboxs.each(function() {
        var val = $(this).attr("value");
        var txt = $(this).attr("title");
        customertxt = txt;
        customerval = val;
    });
    if (objname == "" || objcode == "") {
        $("#txtCustomerName").val(customertxt);
        $("#hfCustomerCode").val(customerval);

        $("#txtCustomerName").css("display", "");
        $("#txtCustomerName").attr("readonly", "true");
    } else {
        $("#" + objname).val(customertxt);
        $("#" + objcode).val(customerval);
    }
}

//供应商选择单选
function searchCustomerSelectOne(objname, objcode) {

    window.top.art.dialog({ title: '供应商、配送商列表', id: 'customerSelectOne', iframe: 'hospital/EInvoic/Select/SelectCustomerOne.aspx', lock: true }, function() { GetCustomerInfoOne(objname, objcode); });
}

//厂家
function makerSelect(objname, objcode) {
    window.top.art.dialog({ title: '厂家信息', id: 'makerSelect', iframe: 'maker/makerInfo/makerSelectList.aspx', lock: true }, function() { GetSelectedMaker(objname, objcode); });
}
function GetSelectedMaker(objname, objcode) {
    var strname = "";
    var strcode = "";
    var listboxs = $(window.top.art.dialog({ id: 'makerSelect' }).data.iframe.document).find("input:checked");
    if (listboxs.size() == 0) return false;

    listboxs.each(function(i) {
        var val = $(this).attr("value");
        var txt = $(this).attr("txt");
        strname = txt;
        strcode = val;
    });

    $("#" + objname).val(strname);
    $("#" + objcode).val(strcode);

    $("#" + objname).css("display", "");
    $("#" + objname).attr("readonly", "true");
}

//医院信息
function yySelect(objname, objcode) {
    window.top.art.dialog({ title: '医院信息', id: 'yySelect', iframe: 'supplier/VendorManage/select/yyselectList.aspx', lock: true }, function() { GetSelectedyy(objname, objcode); });
}
function GetSelectedyy(objname, objcode) {
    var strname = "";
    var strcode = "";
    var listboxs = $(window.top.art.dialog({ id: 'yySelect' }).data.iframe.document).find("input:checked");
    if (listboxs.size() == 0) return false;

    listboxs.each(function(i) {
        var val = $(this).attr("value");
        var txt = $(this).attr("title");
        strname = txt;
        strcode = val;
    });

    $("#" + objname).val(strname);
    $("#" + objcode).val(strcode);

    if ($('#txtDepartmentNamexx').size() > 0) {
        $('#txtDepartmentNamexx').val('');
         $('#txtDepartmentCodexx').val('');
    }

    //    $("#" + objname).css("display", "");
    //    $("#" + objname).attr("readonly", "true");
}


//采购通道供应商信息
function gysSelect(objname, objcode) {
    window.top.art.dialog({ title: '医院信息', id: 'gysSelect', iframe: 'supplier/VendorManage/select/gysselectList.aspx', lock: true }, function() { GetSelectedgys(objname, objcode); });
}
function GetSelectedgys(objname, objcode) {
    var strname = "";
    var strcode = "";
    var listboxs = $(window.top.art.dialog({ id: 'gysSelect' }).data.iframe.document).find("input:checked");
    if (listboxs.size() == 0) return false;

    listboxs.each(function(i) {
        var val = $(this).attr("value");
        var txt = $(this).attr("title");
        strname = txt;
        strcode = val;
    });

    $("#" + objname).val(strname);
    $("#" + objcode).val(strcode);

    if ($('#txtDepartmentNamexx').size() > 0) {
        $('#txtDepartmentNamexx').val('');
        $('#txtDepartmentCodexx').val('');
    }

    //    $("#" + objname).css("display", "");
    //    $("#" + objname).attr("readonly", "true");
}

//通道供应商选择
function SelectCustomer() {

    window.top.art.dialog({ title: '供应商列表', id: 'Selectcustomer', iframe: 'hospital/EInvoic/Select/SelectCustomerAdmin.aspx', lock: true }, function() { GetCustomerList(); });

}

function GetCustomerList() {

    var templist = $("body").find("input:checkbox");
    var listboxs = $(window.top.art.dialog({ id: 'Selectcustomer' }).data.iframe.document).find("input:checked");
    if (listboxs.size() == 0) return false;
    $("#divsave").css("display", "");
    listboxs.each(function(i) {
        var val = $.trim($(this).attr("value"));
        var txt = $.trim($(this).attr("txt"));
        //去重复
        var ch = true;
        for (var i = 0; i < templist.length; i++) {
            if ($.trim(templist[i].value) == val) {
                templist[i].checked = 'true'; ch = false; break;
            }
        }
        if (ch) {
             $("#newChanel").append(" <input type='checkbox' name='ckbcustomerCode' value='" + val + "$" + txt + "' id='" + val + "' checked='checked' onclick='CheckBoxSelectChange(this)'/>");
             $("#newChanel").append("<label id='lb_" + val + "' for='" + val + "'>(" + val + ")" + txt + "</label>");

            

        }
    });
}


//药品选 择
function drugSelect(objname, objcode) {
    window.top.art.dialog({ title: '药品信息', id: 'drugSelect', iframe: 'hospital/EInvoic/select/drugselectList.aspx', lock: true }, function() { GetSelecteddrug(objname, objcode); });
}
function GetSelecteddrug(objname, objcode) {
    var strname = "";
    var strcode = "";
    var makercode = "";
    var makername = "";
    var listboxs = $(window.top.art.dialog({ id: 'drugSelect' }).data.iframe.document).find("input:checked");
    if (listboxs.size() == 0) return false;

    listboxs.each(function(i) {
        var val = $(this).attr("value");
        var txt = $(this).attr("title");
        makercode = $(this).attr("makerCode");
        makername = $(this).attr("makerName");
        strname = txt;
        strcode = val;
    });

    $("#" + objname).val(strname);
    $("#" + objcode).val(strcode);
    $("#txtmaker_name").val(makername);
    $("#hfmaker_no").val(makercode);
}


//部门选 择
function DepartmentSelect(objname, objcode) {
    window.top.art.dialog({ title: '部门信息', id: 'DepartmentSelect', iframe: 'hospital/EInvoic/select/DepartmentselectList.aspx', lock: true }, function() { GetSelectedDepartment(objname, objcode); });
}
function GetSelectedDepartment(objname, objcode) {
    var strname = "";
    var strcode = "";
    var listboxs = $(window.top.art.dialog({ id: 'DepartmentSelect' }).data.iframe.document).find("input:checked");
    if (listboxs.size() == 0) return false;

    listboxs.each(function(i) {
        var val = $(this).attr("value");
        var txt = $(this).attr("title");
        strname = txt;
        strcode = val;
    });

    $("#" + objname).val(strname);
    $("#" + objcode).val(strcode);
}

//移除未选中的
function CheckBoxSelectChange(obj) {
    var _obj = $(obj);
    var id = "lb_" + _obj.attr("id");
    if (_obj.attr("checked") != "checked") {
        _obj.remove();
        $("#" + id).remove();
    }
}






//选择一个商业公司,默认配送商一样
function GetCustomerInfotwo(objname,objcode,objname2,objcode2) {
    var customerval = "'0'";
    var customertxt = "";
    var listboxs = $(window.top.art.dialog({ id: 'CustomerSelecttwo' }).data.iframe.document).find("input:checked");
    if (listboxs.size() == 0) return false;
    listboxs.each(function() {
        var val = $(this).attr("value");
        var txt = $(this).attr("title");
        customertxt = txt;
        customerval = val;
    });
    
    $("#" + objname).val(customertxt);
    $("#" + objcode).val(customerval);
    $("#" + objname2).val(customertxt);
    $("#" + objcode2).val(customerval);
}

//选择一个商业公司,默认配送商一样
function searchCustomerSelecttwo(objname, objcode,objname2, objcode2) {

    window.top.art.dialog({ title: '供应商列表', id: 'CustomerSelecttwo', iframe: 'hospital/EInvoic/Select/SelectCustomerOne.aspx', lock: true }, function() { GetCustomerInfotwo(objname, objcode, objname2, objcode2); });
}


//选择客户编码，北医药人员内部使用,目前用于外勤订单跟踪查询
function ClientSelect(objname, objcode) {
    window.top.art.dialog({ title: '客户信息', id: 'ClientSelect', iframe: 'supplier/ClientInfo/ClientSelectList.aspx', lock: true }, function() { GetSelectedClient(objname, objcode); });
}
function GetSelectedClient(objname, objcode) {
    var strname = "";
    var strcode = "";
    var listboxs = $(window.top.art.dialog({ id: 'ClientSelect' }).data.iframe.document).find("input:checked");
    if (listboxs.size() == 0) return false;

    listboxs.each(function(i) {
        var val = $(this).attr("value");
        var txt = $(this).attr("title");
        strname = txt;
        strcode = val;
    });

    $("#" + objname).html(strname);
    $("#" + objcode).val(strcode);
}