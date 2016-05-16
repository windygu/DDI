//后台菜单选择
function ItemSelect()
{
    var pid="0";
    if($("#hfid").size()>0)
    {pid=$("#hfid").val()};
    //$("#DDL_Menu_Type").attr("disabled","disabled");
	window.top.art.dialog({title:'父级选择',id:'departItemSelect',iframe:'supplier/department/departSelect.aspx?pid='+pid,lock:true},function(){GetSelected();});
	//window.parent.art.dialog.open('hr_menu/menuSelect.aspx',{ok:function(){GetSelectedMenu();}});
	}

function GetSelected()
{

 var listboxs=$(window.top.art.dialog({ id: 'departItemSelect' }).data.iframe.document).find("input:checked");
  if(listboxs.size()==0) return false;
   
     listboxs.each(function(i){      
	var val = $(this).attr("value");
	var path=$(this).attr("path");
	var txt=$(this).attr("txt");
	$("#hfpid").val(val); 
	$("#hfPath").val(path); 
	$("#txtPname").val(txt);
	});
}
//用于菜单维护
function selectunall(id)
{
	var obj=$("#chkdepart_"+id)
	obj.parent().find(":checkbox").each(function(){
					 if (obj.attr("checked"))
					 {
						 $(this).attr("checked","true");
						 }
					
													}); 
	}
function twounselected(id)
	{
		var obj=$("#chkdepart_"+id);
        var parentid=obj.attr("parentid");
        if (!obj.attr("checked")) 
        {
            $("#chkdepart_"+parentid).removeAttr( "checked");
        }
        else
        {
            selectall(id);
        }
    }
		
function threeunselected(id)
{
    var obj=$("#chkdepart_"+id);
    var parentid=obj.attr("parentid");
    if (!obj.attr("checked")) 
    {
        $("#chkdepart_"+parentid).removeAttr( "checked");
        var fatherid=$("#chkdepart_"+parentid).attr("parentid");
        $("#chkdepart_"+fatherid).removeAttr( "checked");
    }
}
//用于菜单权限授予
function selectall(id)
{
	var obj=$("#chkdepart_"+id)
	obj.parent().find(":checkbox").each(function(){
					 if (obj.attr("checked"))
					 {
						 $(this).attr("checked","true");
						 }
					 else
					 {
						$(this).removeAttr( "checked");
						}
													}); 
	}
function twoselected(id)
	{
		selectall(id);
		selectedparent(id);
		}
		
function threeselected(id)
{
	var parentid=$("#chkdepart_"+id).attr("parentid");
	selectedparent(id);
	selectedparent(parentid);
}
function selectedparent(id)
	{
		var ch=false;
		var obj=$("#chkdepart_"+id);
		var parentid=obj.attr("parentid");
		 if (obj.attr("checked")) ch=true;
		 else
		 {
		   obj.parent().parent().find(":checkbox[parentid='"+parentid+"']").each(function(){
					 if ($(this).attr("checked"))
					 {
						ch=true;
					 }
																					   
													});
		   }
		if(ch)
		{
			$("#chkdepart_"+parentid).attr("checked","true");
		}
		else
		{
			$("#chkdepart_"+parentid).removeAttr( "checked");
		}
		}
		
	