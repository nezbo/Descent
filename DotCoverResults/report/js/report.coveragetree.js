function loadChildren(node) {
    if (!node.data.childIds)
        return;

    $.each(node.data.childIds, function(i, childId) {
            executeWithNode(childId, function(data) {
                var hasChildren = data.c && data.c.length > 0;
                node.addChild({ key: childId, title: data.n, percent: data.p, childIds: data.c, isLazy: hasChildren, isFolder: false, icon: data.i == "" ? false : data.i, url: data.r, clickable: data.r != "" });
            });
    });
}

function createNodePresentation(name, percent, clickable) {
    var renderedNode = "<img src='report/images/" + percent + ".png' style='height:auto;width:auto;vertical-align:middle;left-margin:3px; right-margin:3px;'>";
    if (!clickable) {
        renderedNode += "<a href='#' style='vertical-align:middle;'>" + name + "</a>";
    }else {
        renderedNode += "<a href='#' style='vertical-align:middle;color:#0066cc;text-decoration:underline;'>" + name + "</a>";
    }

    return renderedNode;
}

function executeWithNode(id, handler) {

  var blockIndex = div(id, blockSize);
  var block = coverageData[blockIndex];
  if (!block)
    return;

  var itemIndex = id % blockSize;
  var item = block[itemIndex];
  if (!item)
    return;
  
  handler(item);
}

function div(x, y) {
    var d = x / y;
    // since js has no integer division
    if(d >= 0)
      return Math.floor(d);
    else
      return Math.ceil(d);
}