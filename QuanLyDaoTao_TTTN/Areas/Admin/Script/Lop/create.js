//Ajax create lop
$(document).ready(function () {
    $('#create').click(function () {
        var maLop = $('.malop').val();
        var tenKhoa = $('.tenlop').val();
        var nienKhoa = $('.nienkhoa option:selected').text();
        var maKhoa = $('.makhoa option:selected').val();
        var lop = {
            MaLop: maKhoa,
            TenLop: tenKhoa,
            NienKhoa: nienKhoa,
            MaKhoa: maKhoa
        };
        var flag = confirm('Bạn có chắc chắn tạo mới khoa ?');
        if (flag) {
            $.ajax({
                type: "POST",
                url: "/Lop/Create",
                data: JSON.stringify(lop),
                dataType: "json",
                contentType: 'application/json; charset=utf-8'
            }).done(function (data) {
                alert(data.msg);
            }).fail(function (data) {
                alert(data.msg);
            })
        }
        location.reload();
        return false;
    });
});

function CallChangefunc(data) {
    var nk = $('.nienkhoa option:selected').val();
    var mk = $('.makhoa option:selected').val();
    var hdt = $('.hedaotao option:selected').val();
    if (nk == null || mk == null || nk == "" || mk == "" || hdt == null || hdt == "") {
        return false;
    }
    var dt = {
        maKhoa : mk,
        nienKhoa: nk ,
        maHDT: hdt
    }
    $.ajax({
        type: "POST",
        url: "/Lop/AutoCreateMaLop",
        data: JSON.stringify(dt),
        dataType: "json",
        contentType: 'application/json; charset=utf-8'
    }).done(function (data) {
        $('.malop').val(data.msg);
    })
    return false;
}