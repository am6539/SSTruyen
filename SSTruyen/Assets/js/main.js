var menuTheLoai = document.getElementById('ListTheLoai');
var selectTheLoai = document.getElementById('SelectCategory');
var listTheLoai = ["Tiên hiệp","Kiếm hiệp","Ngôn tình","Dị giới","Đô thị"];
var listCategory = listTheLoai;
function loadListTheLoai(event){
    var temp = listTheLoai.map(function(item){
        return "<a class= \"dropdown-item\" href=\"/\" >" + item + "</a>";
    });
    menuTheLoai.innerHTML = temp.join('');
    listCategory.unshift("Tất cả");
    var res = listCategory.map(function(item){
        return "<option>" + item + "</option>";
    })
    selectTheLoai.innerHTML = res.join('');
}

window.addEventListener("load", loadListTheLoai);
