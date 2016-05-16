function getDepartAndAssignGoodsSelect() {
    var checkedNode = $('#TreeViewOrg :checked~span');
    var departIds = '';
    for (var i = 0; i < checkedNode.length; i++) {
        var url = decodeURI($(checkedNode[i]).attr("href"));
        var departId = "'" + url.substring(url.lastIndexOf('/') + 1) + "'" + ',';

        departIds += departId;
    }
    departIds = departIds.substring(0, departIds.length - 1);
    AssignedhydeeMakerGoodsSelect(departIds);
}

//全选
function HydeeSelectAll(obj) {
    var items = $('table :checkbox');
    if (!obj.checked) {

        for (var i = 0; i < items.length; i++) {
            items[i].checked = false;
        }
    } else {
        for (var j = 0; j < items.length; j++) {
            items[j].checked = true;
        }
    }
}