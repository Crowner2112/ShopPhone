function toggleForm(){
    container = document.querySelector(".container");
    container.classList.toggle('active');
}

window.addEventListener('scroll', function(){
    let header = document.querySelector("header");
    header.classList.toggle("sticky", window.scrollY > 10);
});


function validateForm(){
    var username = document.myform.username.value;
    var password = document.myform.password.value;

    if(username == null || username == ""){
        alert("Username khong duoc de trong!!");
        return false;
    }else if(password.length < 8 || password == ""){
        alert("Password co do dai >=8 va khong duoc de trong!!!");
        return false;
    }
}

function validateForm2(){
    var username = document.myform2.username.value;
    var email = document.myform2.email.value;
    var createpass = document.myform2.createpass.value;
    var confirmpass = document.myform2.confirmpass.value;

    var atposition = email.indexOf("@");
    var doposition = email.lastIndexOf(".");

    if(username == null || username == ""){
        alert("Username khong duoc de trong!!");
        return false;
    }else if(email == null || email == ""){
        alert("Email khong duoc de trong");
        return false;
    }else if(atposition < 1 || doposition < (atposition + 2) || (doposition + 2) >= email.length){
        alert("Nhap dung dinh dang email. Ex: abc@gmail.com");
        return false;
    }else if(createpass.length < 8 || createpass == ""){
        alert("Password co do dai >=8 va khong duoc de trong!!!");
        return false;
    }
    if(confirmpass == createpass){
        return true;
    }else {
        alert("Password phai trung nhau");
        return false;
    }
}




// function Dong_ho() {
//     var gio = document.getElementById("gio");
//     var phut = document.getElementById("phut");
//     var giay = document.getElementById("giay");
//     var Gio_hien_tai = new Date().getHours();
//     var Phut_hien_tai = new Date().getMinutes();
//     var Giay_hien_tai = new Date().getSeconds();
//     gio.innerHTML = Gio_hien_tai;
//     phut.innerHTML = Phut_hien_tai;
//     giay.innerHTML = Giay_hien_tai;
// }
// var Dem_gio = setInterval(Dong_ho, 1000);

var target_date = new Date().getTime() + (1000*3600*48);
var days ,hours, minutes, seconds;

var countdown = document.getElementById("titles");

getCountdown();

setInterval(function(){
    getCountdown(); 
}, 1000);

function getCountdown(){
    var current_date = new Date().getTime();
    var seconds_left = (target_date - current_date) / 1000;

    days = pad(parseInt(seconds_left / 86400));
    seconds_left = seconds_left % 86400;

    hours = pad(parseInt(seconds_left / 3600));
    seconds_left = seconds_left % 3600;

    minutes = pad(parseInt(seconds_left / 60));
    seconds = pad(parseInt(seconds_left % 60));

    countdown.innerHTML = "<span>" + days + "</span><span>" + hours + "</span><span>" 
    + minutes + "</span><span>" + seconds + "</span>";
}

function pad(n){return (n < 10 ? '0' : '') + n; }

// click giỏ hàng
var cart=document.querySelector('.cart');
var clickGioHang=document.querySelector('.gio-hang');
var clickThoat=document.querySelector('.nut-thoat');
var clickNenDen=document.querySelector('.nen-den');
var clickThanhToan=document.querySelector('.nut-thanh-toan');
cart.addEventListener('click',function(){
    clickGioHang.classList.add('click-gio-hang');
})
clickThoat.addEventListener('click',function(){
    clickGioHang.classList.remove('click-gio-hang');
})
clickNenDen.addEventListener('click',function(){
    clickGioHang.classList.remove('click-gio-hang');
})
clickThanhToan.addEventListener('click',function(){
    clickGioHang.classList.remove('click-gio-hang');
})