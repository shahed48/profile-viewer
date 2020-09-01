
function login() {
    var userName = document.getElementById('emailAddress').value;
    var password = document.getElementById('password').value;
    $(".loader").show();
    $.ajax({
        type: 'POST',
        url: development_api + 'account/login?pUserName=' + userName + '&pPassword=' + password,
        success: function (resp) {
            localStorage.setItem('token', 'Bearer ' + resp);
            $.ajax({
                type: 'POST',
                url: '/Account/SetToken',
                data: { token: localStorage.getItem('token') },
                success: function (resp) {
                    window.location.href = '/Home/Index';
                },
                error: function (resp) {
                    $(".loader").hide();
                    alert("Something went wrong");
                }
            });
        },
        error: function (resp) {
            $(".loader").hide();
            alert("incorrect username or password");
        }
    });
}

function logout() {

    $.ajax({
        type: 'POST',
        url: development_api + 'account/logout',
        success: function (resp) {
            localStorage.clear();
            window.location.href = '/Account/Logout';
        },
        error: function (resp) {
            console.log(resp);
        }
    });
}

function UpdateSelect(e, selection) {
    $(".nav-anchor").each(function (index, e) {
        if ($(this).hasClass('active')) {
            $(this).removeClass('active').removeClass('arrow');
        }
    });
    $(e).addClass('active').addClass('arrow');

    var action_name = 'Dashboard';
    if (selection === 'profile') { action_name = 'UserProfile'; }
    else if (selection === 'works') { action_name = 'Works'; }
    else if (selection === 'dashboard') { action_name = 'Dashboard' }
    else {
        $('#SiteContent').empty().html('<div class="base-view"<h2>UNDER CONSTRUCTION</h2></div>');
        return;
    }

    LoadViews(action_name);
}
function LoadViews(action_name) {
    $(".loader").fadeIn();
    $.ajax({
        type: 'GET',
        url: '/Home/' + action_name,
        success: function (response) {
            $(".loader").fadeOut();
            $('#SiteContent').empty().html(response);
            $('#pageName').empty().append('Profile Viewer | ' + action_name);
        },
        failure: function (response) {
            $(".loader").fadeOut();
            alert(response.responseText);
        },
        error: function (response) {
            $(".loader").fadeOut();
            alert(response.responseText);
        }
    });
}

$("ul#asideNav li:first-child a").click();
LoadViews('Dashboard');

function ToggleNavigation(e) {
    if ($('.main-content').hasClass('main-content-max')) {
        $('.main-content').removeClass('main-content-max');
        $('.sidebar').removeClass('sidebar-min');
        $('.nav-label').removeClass('d-none');
    }
    else {
        $('.main-content').addClass('main-content-max');
        $('.sidebar').addClass('sidebar-min');
        $('.nav-label').addClass('d-none');
    }
}