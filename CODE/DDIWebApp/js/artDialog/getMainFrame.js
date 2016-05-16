
function getMainFrame() {
    var temp= _getFrame(window.top, "right");
	return temp==null?window:temp;
}

function _getFrame(w, frameName) {
    for (var i = 0; i < w.frames.length; i++) {
        if (w.frames[i].name === frameName) {
            return w.frames[i];
        }
        else {
            var f = _getFrame(w.frames[i], frameName);
            if (f != null) return f;
        }
    }
    return null;
}