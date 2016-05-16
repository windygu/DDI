//厂家选择
function makerSelect()
{
	window.top.art.dialog({title:'厂家信息',id:'makerSelect',iframe:'maker/makerInfo/makerSelectList.aspx',lock:true},function(){GetSelectedMaker();});
}



//Hydee厂家选择
function HydeeMakerSelect()
{
    window.top.art.dialog({ title: '厂家信息', id: 'makerSelect', iframe: 'maker/makerInfo/HydeeMakerSelectList.aspx', lock: true }, function () { GetSelectedMaker(); });
}
function ReserveMakerSelect() {
    window.top.art.dialog({ title: '厂家信息', id: 'makerSelect', iframe: 'maker/makerInfo/ReserveMakerSelectList.aspx', lock: true }, function() { GetSelectedMaker(); });
}
function GetSelectedMaker()
{
   var listboxs=$(window.top.art.dialog({ id: 'makerSelect' }).data.iframe.document).find("input:checked");
  if(listboxs.size()==0) return false;
   
     listboxs.each(function(i){      
	var val = $(this).attr("value");
	var txt=$(this).attr("txt");
	$("#txtmakerId").val(val);  
	$("#txtmakername").val(txt);
	});
}

//品种选择
function makerGoodsSelect()
{
	window.top.art.dialog({title:'品种列表',id:'GoodsSelect',iframe:'maker/goodsInfo/goodsInfoSelect.aspx',lock:true},function(){GetSelectedGoodsInfo();});
}
//hydee的品种选择(全部)
function hydeeMakerGoodsSelect(loginid)
{
    window.top.art.dialog({ title: '品种列表', id: 'GoodsSelect', iframe: 'maker/goodsInfo/HydeeGoodsInfoSelect.aspx?loginid=' + loginid,height:"430",width:"800", lock: true }, function() { GetSelectedGoodsInfo(); });
}

//hydee的品种选择（已分配）
function AssignedhydeeMakerGoodsSelect(departIds) {
    window.top.art.dialog({ title: '品种信息', id: 'GoodsSelect', iframe: 'maker/goodsInfo/AssignedHydeeMakerGoodsSelect.aspx?departIds='+departIds, lock: true }, function () { GetSelectedGoodsInfo(); });
}


//储备品选择
function ReserveGoodsSelect() {
    window.top.art.dialog({ title: '品种列表', id: 'GoodsSelect', iframe: 'maker/goodsInfo/ReserveGoodsSelect.aspx', lock: true }, function() { GetSelectedGoodsInfo(); });
}


//厂家查询品种选择
function searchMakerGoodsSelect(org_id) {debugger;
    var org_id = $("#" + org_id).val(); //alert(org_id);
    window.top.art.dialog({ title: '品种列表', id: 'GoodsSelect', iframe: 'maker/goodsInfo/makerGoodsSelect.aspx?org_id=' + org_id, lock: true }, function() { GetSelectedGoodsInfo(); });
}


function GetSelectedGoodsInfo()
{
   var templist=$("body").find("input:checkbox");
   var listboxs=$(window.top.art.dialog({ id: 'GoodsSelect' }).data.iframe.document).find("input:checked");
  if(listboxs.size()==0) return false;
    $("#divsave").css("display","");
    listboxs.each(function(i) {
    if ($(this).attr("txt")) {
            var val = $(this).attr("value");
            var txt = $(this).attr("txt");
            //去重复
            var ch = true;
            for (var i = 0; i < templist.length; i++) {
                if (templist[i].value == val) {
                    templist[i].checked = 'true'; ch = false; break;
                }
            }
            if (ch) {
                $("#newgoods").append("<input type='checkbox' name='ckbgoodsinfo' value='" + val + "' id='" + val + "' checked='checked' onclick='CheckBoxSelectChange(this)'/>");
                $("#newgoods").append("<label id='lb_" + val + "' for='" + val + "'>(" + val + ")" + txt + "</label>");

            }
        }
    });
}

//厂家允许查询那些组织机构的品种信息，组织机构选择
function searchOrganizationSelect(flag)
{
    if (flag == 'N') {
        return;
    }
	window.top.art.dialog({title:'组织机构列表',id:'OrganizationSelect',iframe:'Organization/SelectOrganization.aspx',lock:true, width:500,height:300},function(){GetSelectedOrganizationInfo();});
	}
function GetSelectedOrganizationInfo()
{
   var templist=$("body").find("input:checkbox");
   var listboxs=$(window.top.art.dialog({ id: 'OrganizationSelect' }).data.iframe.document).find("input:checked");
  if(listboxs.size()==0) return false;
  listboxs.each(function(i) {
      if ($(this).attr("txt")) {
          var val = $(this).attr("value");
          var txt = $(this).attr("txt");
          //去重复
          var ch = true;
          for (var i = 0; i < templist.length; i++) {
              if (templist[i].value == val) {
                  templist[i].checked = 'true'; ch = false; break;
              }
          }
          if (ch) {
              $("#divOrganization").append(" <input type='checkbox' name='ckbOrganization' value='" + val + "' id='" + val + "' checked='checked' onclick='CheckBoxSelectChange(this)'/><label id='lb_" + val + "' for='" + val + "'>" + txt + "</label>");

          }
      }
  });
}
//移除未选中的
function CheckBoxSelectChange(obj)
{
    var _obj = $(obj);
    var id = "lb_" + _obj.attr("id"); 
       if(_obj.attr("checked")!="checked")
       {
            _obj.remove();
            $("#"+id).remove();
       }
}
//所属组织机构选择
function searchOrganizationRadioSelect(txtId,valId)
{
	window.top.art.dialog({title:'组织机构列表',id:'OrganizationRadioSelect',iframe:'Organization/SelectRadioOrganization.aspx',lock:true, width:500,height:300},function(){GetRadioSelectedOrganizationInfo(txtId,valId);});
	}
function GetRadioSelectedOrganizationInfo(txtId,valId)
{
   var listboxs=$(window.top.art.dialog({ id: 'OrganizationRadioSelect' }).data.iframe.document).find("input:checked");
   if(listboxs.size()==0) return false;
   
   listboxs.each(function(i){      
	var val = $(this).attr("value");
	var txt=$(this).attr("txt");
	$("#"+valId).val(val);  
	$("#"+txtId).html(txt);
	});
}
//所属组织机构选择
function searchOrganizationRadioSelect3(lblId,txtId,valId)
{
	window.top.art.dialog({title:'组织机构列表',id:'OrganizationRadioSelect',iframe:'Organization/SelectRadioOrganization.aspx',lock:true, width:500,height:300},function(){GetRadioSelectedOrganizationInfo3(lblId,txtId,valId);});
	}
function GetRadioSelectedOrganizationInfo3(lblId,txtId,valId)
{
   var listboxs=$(window.top.art.dialog({ id: 'OrganizationRadioSelect' }).data.iframe.document).find("input:checked");
   if(listboxs.size()==0) return false;
   
   listboxs.each(function(i){      
	var val = $(this).attr("value");
	var txt=$(this).attr("txt");
	$("#"+valId).val(val);
	$("#"+txtId).val(txt);
	$("#"+lblId).text(txt);
	});
}


//厂家品种选择
function makerGoodsSelectRadio(valId, txtId) {
    window.top.art.dialog({ title: '品种列表', id: 'makerGoodsSelectRadio', iframe: 'maker/goodsInfo/makerGoodsSelectRadio.aspx', lock: true }, function() { GetSelectedRadioGoodsInfo(valId, txtId); });
}
function GetSelectedRadioGoodsInfo(valId, txtId) {
    var templist = $("body").find("input:checkbox");
    var listboxs = $(window.top.art.dialog({ id: 'makerGoodsSelectRadio' }).data.iframe.document).find("input:checked");
    if (listboxs.size() == 0) return false;
    listboxs.each(function(i) {
        var val = $(this).attr("value");
        var txt = $(this).attr("txt");
        $("#" + valId).val(val);
        $("#" + txtId).text(txt);
    });
}


//弹出药监码明细界面
function ShowDrugCodeInf(saleproof,str) {
    window.top.art.dialog({ title: '药监码信息', id: 'GoodsDrugInf', iframe: 'maker/userFunctions/SalesDrugInf.aspx?saleproof=' + saleproof+'&str='+str, lock: true });
}