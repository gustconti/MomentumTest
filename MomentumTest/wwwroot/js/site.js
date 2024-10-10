function debounce(func, wait) {
    let timeout;
    return function (...args) {
        const context = this;
        clearTimeout(timeout);
        timeout = setTimeout(() => func.apply(context, args), wait);
    };
}

function toggleMenu() {
    $('#sidebar').toggleClass('closed');
    $('#main-content').toggleClass('shifted');
    $('#page-header').toggleClass('shifted');
}

$(document).ready(function () {
    function handleResponsiveSidebar() {
        var windowWidth = $(window).width();
        var mobileBreakpoint = 768;
        if (windowWidth < mobileBreakpoint) {
            if (!$('#sidebar').hasClass('closed')) {
                $('#sidebar').addClass('closed');
                $('#main-content').addClass('shifted');
                $('#page-header').addClass('shifted');
            }
        } else {
            if ($('#sidebar').hasClass('closed')) {
                $('#sidebar').removeClass('closed');
                $('#main-content').removeClass('shifted');
                $('#page-header').removeClass('shifted');
            }
        }
    }

    handleResponsiveSidebar();

    $(window).resize(handleResponsiveSidebar);
    
    $('#toggle-button').on('click', function () {
        toggleMenu();
    });
});
