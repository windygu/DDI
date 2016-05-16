
    jQuery(document).ready(function() {
        //table,tr背景颜色事件  
		 $("#gv_bonus tr").mouseover(function(){  
         var _this=$(this);_this.addClass("over");var i = _this.index();  $("#gv_bonus_inf tr").eq(i).addClass("over");}).mouseout(function(){  //给这行添加class值为over，并且当鼠标一出该行时执行函数
         var _this=$(this);_this.removeClass("over");var i = _this.index();  $("#gv_bonus_inf tr").eq(i).removeClass("over");}).click(function(){ var _this=$(this);$("#gv_bonus_inf tr").removeClass("overclick");$("#gv_bonus tr").removeClass("overclick");_this.addClass("overclick");var i = _this.index(); $("#gv_bonus_inf tr").eq(i).addClass("overclick");});  
        //table,tr背景颜色事件  
		 $("#gv_bonus_inf tr").mouseover(function(){  
         var _this=$(this);_this.addClass("over");var i = _this.index();  $("#gv_bonus tr").eq(i).addClass("over");}).mouseout(function(){  //给这行添加class值为over，并且当鼠标一出该行时执行函数
         var _this=$(this);_this.removeClass("over");var i = _this.index();  $("#gv_bonus tr").eq(i).removeClass("over");}).click(function(){var _this=$(this);$("#gv_bonus_inf tr").removeClass("overclick");$("#gv_bonus tr").removeClass("overclick");_this.addClass("overclick");var i = _this.index();  $("#gv_bonus tr").eq(i).addClass("overclick");});  
       
        //绑定部门设置事件处理 
            $("#select_depart").click(function(event) {
                event.stopPropagation();//取消事件冒泡
                $("#div_depart").fadeIn(500);
            });
            $(document).click(function(event) { $("#div_depart").fadeOut(500); }); //单击空白区域隐藏弹出层
         //绑定上传事件处理 
            $("#div_upload").click(function(event) {
                event.stopPropagation();//取消事件冒泡
                $("#uploaddiv").show();
            });
            $(document).click(function(event) { $("#uploaddiv").hide(); }); //单击空白区域隐藏弹出层
       });
    
   function edit(id)
    {
	    window.top.art.dialog({title:'二级成本',id:'bonus_upload_edit',iframe:'supplier/officestaff/bonusUploadEdit.aspx?id='+id,lock:true});
	}
	
	function deleteItem(id,obj)
    {
        $.post('bonusUploadManage.aspx?op=delete&id='+id,'',function(){var i = $(obj).parents("tr").index(); $(obj).parents("tr").remove(); $("#gv_bonus_inf tr").eq(i).remove();});
    }