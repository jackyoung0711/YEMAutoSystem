var dataList = []
var count = 0
var currentDataLen = 1
$('ul.cgb-query-filter  .pt15 .mr25:last-child').click()
$("#submit").click()

function getCurrentListData() {
  $.each($('#table_data tr'), function (index, item) {
    var td = $(item).find('td')
    dataList.push({
      date: $(td[0]).text(),
      type: $(td[1]).text(),
      amount: parseInt($(td[2]).text())
    })
  })
}

function getCurrentStatus() {
  currentDataLen = $('#page_footer')[0].childNodes[0].nodeValue.replace(/^\d+\-(\d+)条.+/, '$1')
  console.log(dataList)
  if ($('#table_data tr').length > 0 && currentDataLen > dataList.length) {
    return 1 // 获取到了最新数据
  }
  if (currentDataLen == dataList.length) {
    return 2 // 所有数据已拉取完成(可以结束轮循)
  }
  return 0 // 为获取到最新数据
}

function xhData() {
  var timer = setInterval(function () {
    if (count > 30) {
      count = 0
      clearInterval(timer)
      return
    }
    var status = getCurrentStatus()
    console.log(status)
    if (status == 1) {
      getCurrentListData()
      count = 0
      $('#next_page').click()
    } else if (status == 2) {
      getCurrentListData()
      var str = ''
      for (var i = 0, len = dataList.length; i < len; i++) {
        str += '<li><a class="date">' + dataList[i].date + '</a><a class="type">' + dataList[i].type + '</a><a class="amount">' + dataList[2].amount + '</a></li>'
      }
      $(document.body).append('<ul id="jinyinmao">' + str + '</ul>')
      clearInterval(timer)
      return
    } else {
      count++
    }
  }, 1000)
}

xhData()