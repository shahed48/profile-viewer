
function UpdateSelect(e, selection) {
    $(".nav-anchor").each(function (index, e) {
        if ($(this).hasClass('active')) {
            $(this).removeClass('active').removeClass('arrow');
        }
    });
    $(e.target).addClass('active').addClass('arrow');

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

function Logout() {
    document.getElementById('logoutForm').submit();
}