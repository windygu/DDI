

//部门信息
function DepartSelect(objname, objcode, YYcode) {
    var customercode = $("#" + YYcode).val();
    if (customercode != "") {
        window.top.art.dialog({ title: '医院信息', id: 'DepartSelect', iframe: 'supplier/VendorManage/select/DepartselectList.aspx?customercode=' + customercode, lock: true }, function() { GetSelectedbm(objname, objcode); });
    } else {
    alert("请先选择医院！");
    }
}
function GetSelectedbm(objname, objcode) {
    var strname = "";
    var strcode = "";
    var listboxs = $(window.top.art.dialog({ id: 'DepartSelect' }).data.iframe.document).find("input:checked");
    if (listboxs.size() == 0) return false;

    listboxs.each(function(i) {
        var val = $(this).attr("value");
        var txt = $(this).attr("title");
        strname = txt;
        strcode = val;
    });

    $("#" + objname).val(strname);
    $("#" + objcode).val(strcode);

    //    $("#" + objname).css("display", "");
    //    $("#" + objname).attr("readonly", "true");
}
