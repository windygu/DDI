//后台菜单选择
function menuItemSelect() {
    window.top.art.dialog({
        title: '父菜单选择', id: 'menuItemSelect', iframe: 'Authority/Menu/menuSelect.aspx', lock: true, width: 600, height: 400  }, function () { GetSelectedMenu(); });
}

function GetSelectedMenu() {

    var listboxs = $(window.top.art.dialog({ id: 'menuItemSelect' }).data.iframe.document).find("input:checked");
    if (listboxs.size() == 0) return false;

    listboxs.each(function (i) {
        var val = $(this).attr("value");
        var path = $(this).attr("path");
        var txt = $(this).attr("txt");
        $("#hfpid").val(val);
        $("#hfPath").val(path);
        $("#txtPname").val(txt);
    });
}
//用于菜单维护
function selectunall(id) {
    var obj = $("#chkMenu_" + id)
    obj.parent().find(":checkbox").each(function () {
        if (obj.attr("checked")) {
            $(this).attr("checked", "true");
        }

    });
}
function twounselected(id) {
    var obj = $("#chkMenu_" + id);
    var parentid = obj.attr("Parent");
    if (!obj.attr("checked")) {
        $("#chkMenu_" + parentid).removeAttr("checked");
    }
    else {
        selectall(id);
    }
}

function threeunselected(id) {
    var obj = $("#chkMenu_" + id);
    var parentid = obj.attr("parentid");
    if (!obj.attr("checked")) {
        $("#chkMenu_" + parentid).removeAttr("checked");
        var fatherid = $("#chkMenu_" + parentid).attr("parentid");
        $("#chkMenu_" + fatherid).removeAttr("checked");
    }
}
//用于菜单权限授予
function selectall(id) {
    var obj = $("#chkMenu_" + id)
    obj.parent().find(":checkbox").each(function () {
        if (obj.attr("checked")) {
            $(this).attr("checked", "true");
        }
        else {
            $(this).removeAttr("checked");
        }
    });
}
function twoselected(id) {
    selectall(id);
    selectedparent(id);
}

function threeselected(id) {
    var parentid = $("#chkMenu_" + id).attr("parentid");
    selectedparent(id);
    selectedparent(parentid);
}

function selectedparent(id) {
    var ch = false;
    var obj = $("#chkMenu_" + id);
    var parentid = obj.attr("parentid");
    if (obj.attr("checked")) ch = true;
    else {
        obj.parent().parent().find(":checkbox[parentid='" + parentid + "']").each(function () {
            if ($(this).attr("checked")) {
                ch = true;
            }

        });
    }
    if (ch) {
        $("#chkMenu_" + parentid).attr("checked", "true");
    }
    else {
        $("#chkMenu_" + parentid).removeAttr("checked");
    }
}

function funcselected(id) {
    var parentid = $("#chkFunc_" + id).attr("menuid");
    funcselectedparent(id);
    //selectedparent(parentid);
}

function funcselectedparent(id) {
    var ch = false;
    var obj = $("#chkFunc_" + id);
    var parentid = obj.attr("menuid");
    if (obj.attr("checked")) ch = true;
    else {
        obj.parent().parent().find(":checkbox[menuid='" + parentid + "']").each(function () {
            if ($(this).attr("checked")) {
                ch = true;
            }

        });
    }
    if (ch) {
        $("#chkFunc_" + parentid).attr("checked", "true");
    }
    else {
        $("#chkFunc_" + parentid).removeAttr("checked");
    }
}


// 瀑布流插件
//  2013.4.9
; (function ($) {
    $.fn.waterfall = function (options) {
        var df = {
            item: '.item',
            margin: 15,
            addfooter: true
        };
        options = $.extend(df, options);
        return this.each(function () {
            var $box = $(this), pos = [],
    _box_width = $box.width(),
    $items = $box.find(options.item),
    _owidth = $items.eq(0).outerWidth() + options.margin,
    _oheight = $items.eq(0).outerHeight() + options.margin,
    _num = Math.floor(_box_width / _owidth);

            (function () {
                var i = 0;
                for (; i < _num; i++) {
                    pos.push([i * _owidth, 0]);
                }
            })();

            $items.each(function () {
                var _this = $(this),
        _temp = 0,
        _height = _this.outerHeight() + options.margin;

                _this.hover(function () {
                    _this.addClass('hover');
                }, function () {
                    _this.removeClass('hover');
                });

                for (var j = 0; j < _num; j++) {
                    if (pos[j][1] < pos[_temp][1]) {
                        //暂存top值最小那列的index
                        _temp = j;
                    }
                }
                this.style.cssText = 'left:' + pos[_temp][0] + 'px; top:' + pos[_temp][1] + 'px;';
                //插入后，更新下该列的top值
                pos[_temp][1] = pos[_temp][1] + _height;
            });

            // 计算top值最大的赋给外围div
            (function () {
                var i = 0, tops = [];
                for (; i < _num; i++) {
                    tops.push(pos[i][1]);
                }
                tops.sort(function (a, b) {
                    return a - b;
                });
                $box.height(tops[_num - 1]);

                //增加尾部填充div
                if (options.addfooter) {
                    addfooter(tops[_num - 1]);
                }

            })();

            function addfooter(max) {
                var addfooter = document.createElement('div');
                addfooter.className = 'item additem';
                for (var i = 0; i < _num; i++) {
                    if (max != pos[i][1]) {
                        var clone = addfooter.cloneNode(),
                _height = max - pos[i][1] - options.margin;
                        clone.style.cssText = 'left:' + pos[i][0] + 'px; top:' + pos[i][1] + 'px; height:' + _height + 'px;';
                        $box[0].appendChild(clone);
                    }
                }
            }

        });
    }
})(jQuery);